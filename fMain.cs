using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;
using WindowsFormsControlLibrary1;

public partial class fMain : Form
{
    internal static fMain fMain_0;

	internal List<Thread> list_0 = null;

	internal List<ABB2B510> list_1 = null;

	internal List<D413579F> A31D6D9C = null;

	internal Dictionary<string, List<string>> DAB1D692 = null;

	internal Dictionary<string, List<string>> dictionary_0 = null;

	internal Dictionary<string, List<string>> D68DE6AD = null;

	internal Dictionary<string, List<string>> dictionary_1 = null;

	internal Dictionary<string, List<string>> E6810C8F = null;

	internal Dictionary<string, List<string>> EF9BBAAF = null;

	internal Dictionary<string, List<string>> CB89B620 = null;

	internal Dictionary<string, List<string>> B2978823 = null;

	internal Dictionary<string, List<string>> dictionary_2 = null;

	internal Dictionary<string, List<string>> BB33F205 = null;

	internal Dictionary<string, List<string>> B0873E9C = null;

	internal Dictionary<string, List<string>> dictionary_3 = null;

	internal Dictionary<string, List<string>> dictionary_4 = null;

	internal Dictionary<string, List<string>> dictionary_5 = null;

	internal Dictionary<string, List<string>> dictionary_6 = null;

	internal Dictionary<string, List<string>> dictionary_7 = null;

	internal Dictionary<string, List<string>> A83F1A36 = null;

	internal Dictionary<string, List<string>> dictionary_8 = null;

	internal Dictionary<string, List<string>> dictionary_9 = null;

	internal Dictionary<string, List<string>> dictionary_10 = null;

	internal Dictionary<string, List<string>> dictionary_11 = null;

	internal Dictionary<string, List<string>> DAB96D09 = null;

	internal Dictionary<string, List<string>> dictionary_12 = null;

	internal Dictionary<string, List<string>> F53E0407 = null;

	internal Dictionary<string, List<string>> BB96210A = null;

	internal Dictionary<string, List<string>> dictionary_13 = null;

	internal Dictionary<string, List<string>> dictionary_14 = null;

	internal Dictionary<string, List<string>> dictionary_15 = null;

	internal Dictionary<string, List<string>> dictionary_16 = null;

	internal Dictionary<string, List<string>> dictionary_17 = null;

	internal Dictionary<string, List<string>> dictionary_18 = null;

	internal Dictionary<string, List<string>> dictionary_19 = null;

	internal Dictionary<string, List<string>> dictionary_20 = null;

	internal Dictionary<string, List<string>> DBB0FB3E = null;

	internal Dictionary<string, List<string>> dictionary_21 = null;

	internal Dictionary<string, List<string>> A91273B2 = null;

	internal Dictionary<string, List<string>> dictionary_22 = null;

	internal Dictionary<string, List<string>> FE314201 = null;

	internal Dictionary<string, List<string>> DE0D9D90 = null;

	internal Dictionary<string, List<string>> dictionary_23 = null;

	internal Dictionary<string, List<string>> dictionary_24 = null;

	internal Dictionary<string, List<string>> dictionary_25 = null;

	internal Dictionary<string, Dictionary<string, int>> C03C6C3A = null;

	internal Dictionary<string, List<string>> A321A6B2 = null;

	internal Dictionary<string, List<string>> dictionary_26 = null;

	internal Dictionary<string, List<string>> dictionary_27 = null;

	internal Bitmap bitmap_0 = Class155.Bitmap_120;

	internal Bitmap bitmap_1 = Class155.Bitmap_148;

	internal int int_0 = 0;

	internal object object_0 = new object();

	internal object object_1 = new object();

	internal object object_2 = new object();

	internal object object_3 = new object();

	internal object object_4 = new object();

	internal List<string> list_2 = new List<string>();

	internal Dictionary<string, List<string>> C73602B4 = new Dictionary<string, List<string>>();

	internal object object_5 = new object();

	internal Dictionary<string, List<string>> dictionary_28 = new Dictionary<string, List<string>>();

	internal object object_6 = new object();

	internal int int_1 = -1;

	internal bool bool_0 = true;

	internal object object_7 = new object();

	internal int int_2 = -1;

	internal bool bool_1 = true;

	internal bool bool_2 = false;

	internal List<string> list_3 = new List<string>();

	internal List<string> CC057C03 = null;

	internal Dictionary<string, int> ED00A032;

	internal object BC916426 = new object();

	internal object object_8 = new object();

	internal List<string> EB21531C = new List<string>();

	internal object object_9 = new object();

	internal Bitmap bitmap_2 = Class155.Bitmap_179;

	internal Bitmap D5126D0C = Class155.Bitmap_176;

	internal bool bool_3 = false;

	internal int B6B4A129 = 0;

	internal bool A88D2489 = false;

	internal bool bool_4 = false;

	internal Queue<string> AB312AAB = null;

	internal List<string> list_4 = null;

	internal IContainer icontainer_0 = null;

	internal static string CA19F4AD = "";

	internal BunifuDragControl EA382128;

	internal Panel FBA31BBA;

	internal PictureBox pictureBox1;

	internal Button E836E3B2;

	internal Button btnMaximize;

	internal Button ADA8C634;

	internal BunifuCustomLabel B526D03A;

	internal MenuStrip D39C9728;

	internal ToolStripMenuItem C72EAE3C;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ContextMenuStrip ctmsAcc;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem EEAB969B;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem copyToolStripMenuItem;

	internal ToolStripMenuItem tokenToolStripMenuItem;

	internal ToolStripMenuItem cookieToolStripMenuItem;

	internal ToolStripMenuItem uidPassToolStripMenuItem;

	internal ToolStripMenuItem CB044085;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem BE8BBBA0;

	internal ToolStripMenuItem A492F617;

	internal ToolStripMenuItem FC8A5097;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripMenuItem passToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal ToolStripMenuItem toolStripMenuItem_6;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal ToolStripMenuItem toolStripMenuItem_8;

	internal ToolStripMenuItem toolStripMenuItem_9;

	internal ToolStripMenuItem tokenToolStripMenuItem2;

	internal ToolStripMenuItem C698B335;

	internal ToolStripMenuItem C29582AA;

	internal ToolStripMenuItem mailPassMailToolStripMenuItem;

	internal ToolStripMenuItem uidPassTokenCookieMailPassMailToolStripMenuItem;

	internal ToolStripMenuItem A10EFE26;

	internal ToolStripMenuItem toolStripMenuItem_10;

	internal ToolStripMenuItem toolStripMenuItem_11;

	internal ToolStripMenuItem mailToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_12;

	internal ToolStripMenuItem uidPassTokenCookieMailPassMail2faToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_13;

	internal ToolStripMenuItem checkProfileToolStripMenuItem;

	internal ToolStripMenuItem fAToolStripMenuItem;

	internal ToolStripMenuItem tinhTrangToolStripMenuItem;

	internal ToolStripMenuItem AD93A60F;

	internal ToolStripMenuItem uidPass2FaToolStripMenuItem;

	internal BunifuDragControl bunifuDragControl_0;

	internal ToolStripMenuItem E503C69C;

	internal ToolStripMenuItem toolStripMenuItem_14;

	internal ToolStripMenuItem CA31F826;

	internal ToolStripMenuItem BC007112;

	internal ToolStripMenuItem toolStripMenuItem_15;

	internal ToolStripMenuItem C00BE82A;

	internal ToolStripMenuItem DAB92DAC;

	internal ToolStripMenuItem useragentToolStripMenuItem1;

	internal ToolStripMenuItem proxyToolStripMenuItem1;

	internal ToolStripMenuItem giaiCheckpointToolStripMenuItem;

	internal ToolStripMenuItem A8162791;

	internal ToolStripMenuItem B6161039;

	internal ToolStripMenuItem E39B6092;

	internal ToolStripMenuItem D1AFCCA3;

	internal Panel plTrangThai;

	internal Label lblTrangThai;

	internal ToolStripMenuItem uidToolStripMenuItem;

	internal ToolStripMenuItem checkAvatarToolStripMenuItem;

	internal ToolStripMenuItem checkProxyToolStripMenuItem;

	internal ToolStripMenuItem checkProfileToolStripMenuItem1;

	internal ToolStripMenuItem toolStripMenuItem_16;

	internal ToolStripMenuItem checkInfoUIDToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_17;

	internal ToolStripMenuItem FA11F02A;

	internal ToolStripMenuItem toolStripMenuItem_18;

	internal ToolStripMenuItem A681EC38;

	internal ToolStripMenuItem D090E02D;

	internal ToolStripMenuItem EF359EB3;

	internal ToolStripMenuItem F08308B5;

	internal ToolStripMenuItem BA219202;

	internal ToolStripMenuItem toolStripMenuItem_19;

	internal ToolStripMenuItem uidUpdateToolStripMenuItem;

	internal ToolStripMenuItem FFA8771A;

	internal ToolStripMenuItem checkLiveUidToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_20;

	internal ToolStripMenuItem toolStripMenuItem_21;

	internal ToolStripMenuItem toolStripMenuItem_22;

	internal ToolStripMenuItem F4263206;

	internal ToolStripMenuItem toolStripMenuItem_23;

	internal ToolStripMenuItem toolStripMenuItem_24;

	internal ToolStripMenuItem toolStripMenuItem_25;

	internal ToolStripMenuItem CF3F68BB;

	internal ToolStripMenuItem A211BD94;

	internal ToolStripMenuItem toolStripMenuItem_26;

	internal ToolStripMenuItem hotmailToolStripMenuItem;

	internal ToolStripMenuItem B298AA35;

	internal ToolStripMenuItem toolStripMenuItem_27;

	internal ToolStripMenuItem toolStripMenuItem_28;

	internal ToolStripMenuItem A6A5633B;

	internal ToolStripMenuItem toolStripMenuItem_29;

	internal ToolStripMenuItem phoneToolStripMenuItem;

	internal Button btnInteract;

	internal StatusStrip F7121228;

	internal ToolStripStatusLabel A3864980;

	internal ToolStripStatusLabel C3919999;

	internal ToolStripStatusLabel B9BED82A;

	internal ToolStripStatusLabel lblKey;

	internal ToolStripStatusLabel toolStripStatusLabel8;

	internal ToolStripStatusLabel A5376CB6;

	internal ToolStripStatusLabel CC9D630E;

	internal ToolStripStatusLabel toolStripStatusLabel9;

	internal ToolStripStatusLabel toolStripStatusLabel10;

	internal ToolStripStatusLabel lblDateExpried;

	internal ToolStripStatusLabel toolStripStatusLabel4;

	internal ToolStripStatusLabel lblCountHighline;

	internal ToolStripStatusLabel toolStripStatusLabel5;

	internal ToolStripStatusLabel lblCountSelect;

	internal ToolStripStatusLabel toolStripStatusLabel7;

	internal ToolStripStatusLabel lblCountTotal;

	internal ToolStripStatusLabel toolStripStatusLabel6;

	internal ToolStripStatusLabel D81D001E;

	internal Button metroButton1;

	internal Panel DC993629;

	internal Button BtnSearch;

	internal ComboBox cbbSearch;

	internal BunifuCustomTextbox txbSearch;

	internal Panel plQuanLyThuMuc;

	internal Button btnLoadAcc;

	internal Label label1;

	internal Button btnEditFile;

	internal Button CA9D953A;

	internal Button D1117A83;

	internal Label label2;

	internal Button AddFileAccount;

	internal ComboBox D38F4B00;

	internal ComboBox FE921A1C;

	internal Panel panel1;

	internal StatusStrip statusStrip1;

	internal DataGridView F5325785;

	internal ToolStripMenuItem D804239D;

	internal ToolStripMenuItem toolStripMenuItem_30;

	internal ToolStripMenuItem B10418B3;

	internal ToolStripMenuItem toolStripMenuItem_31;

	internal PictureBox picLanguage;

	internal ToolStripMenuItem testSpinTextToolStripMenuItem;

	internal ToolStripMenuItem E3AACC35;

	internal ToolStripMenuItem getTokenEAAAAUBToolStripMenuItem;

	internal ToolStripMenuItem F881A71F;

	internal ToolStripMenuItem C2140F32;

	internal ToolStripMenuItem A70D7D81;

	internal ToolStripMenuItem toolStripMenuItem_32;

	internal ToolStripMenuItem toolStripMenuItem_33;

	internal ToolStripMenuItem toolStripMenuItem_34;

	internal ToolStripMenuItem toolStripMenuItem_35;

	internal ToolStripMenuItem checkNameVNToolStripMenuItem;

	internal ToolStripMenuItem FA1B6D17;

	internal ToolStripMenuItem toolStripMenuItem11;

	internal ToolStripMenuItem toolStripMenuItem_36;

	internal ToolStripMenuItem toolStripMenuItem1;

	internal BunifuGradientPanel D7A63B91;

	internal ToolStripMenuItem C90A602B;

	internal ToolStripMenuItem databaseToolStripMenuItem;

	internal ToolStripMenuItem C2207E1A;

	internal ToolStripMenuItem toolStripMenuItem_37;

	internal ToolStripMenuItem toolStripMenuItem_38;

	internal ToolStripMenuItem toolStripMenuItem_39;

	internal ToolStripMenuItem checkInfoUidtokenTrungGianToolStripMenuItem;

	internal ToolStripMenuItem E51F2F23;

	internal ToolStripMenuItem B60BD1B5;

	internal ToolStripMenuItem getTokenEAAAAToolStripMenuItem;

	internal ToolStripMenuItem taoPageFollowToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_40;

	internal ToolStripMenuItem dataBackupGroupToolStripMenuItem;

	internal ToolStripMenuItem backupGroupToolStripMenuItem;

	internal ToolStripMenuItem checkFileBackupGroupToolStripMenuItem;

	internal ToolStripMenuItem B2A40FA8;

	internal ToolStripMenuItem toolStripMenuItem_41;

	internal ToolStripMenuItem toolStripMenuItem_42;

	internal ToolStripMenuItem E10CC3A7;

	internal ToolStripMenuItem findIdFacebookToolStripMenuItem;

	internal ToolStripMenuItem A637DF36;

	internal ToolStripMenuItem BF3426B5;

	internal ToolStripMenuItem eAAAAToolStripMenuItem;

	internal ToolStripMenuItem eAAGToolStripMenuItem;

	internal ToolStripMenuItem eAABsToolStripMenuItem;

	internal ToolStripMenuItem BEA6D0A0;

	internal ToolStripMenuItem A48E28A7;

	internal ToolStripMenuItem A5BBFD2A;

	internal ToolStripMenuItem toolStripMenuItem3;

	internal ToolStripMenuItem toolStripMenuItem4;

	internal ToolStripMenuItem toolStripMenuItem5;

	internal ToolStripMenuItem toolStripMenuItem9;

	internal ToolStripMenuItem toolStripMenuItem13;

	internal ToolStripMenuItem toolStripMenuItem_43;

	internal ToolStripMenuItem toolStripMenuItem_44;

	internal System.Windows.Forms.Timer timer_0;

	internal ToolStripMenuItem checkCountryToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem10;

	internal ToolStripMenuItem toolStripMenuItem12;

	internal ToolStripMenuItem toolStripMenuItem14;

	internal ToolStripMenuItem toolStripMenuItem15;

	internal ToolStripMenuItem C4A6CD3E;

	internal ToolStripMenuItem toolStripMenuItem18;

	internal ToolStripMenuItem BB8A908F;

	internal ToolStripMenuItem B1809B27;

	internal ToolStripMenuItem toolStripMenuItem_45;

	internal ToolStripMenuItem CEB9A490;

	internal ToolStripMenuItem compareEmailToolStripMenuItem;

	internal DataGridViewCheckBoxColumn cChose;

	internal DataGridViewTextBoxColumn cStt;

	internal DataGridViewTextBoxColumn EF0AA801;

	internal DataGridViewTextBoxColumn EC9B41A9;

	internal DataGridViewTextBoxColumn B585BBB3;

	internal DataGridViewTextBoxColumn DA3B0A90;

	internal DataGridViewTextBoxColumn cToken;

	internal DataGridViewTextBoxColumn cCookies;

	internal DataGridViewTextBoxColumn cEmail;

	internal DataGridViewTextBoxColumn cEmail2;

	internal DataGridViewTextBoxColumn DD2C34BF;

	internal DataGridViewTextBoxColumn cMailRecovery;

	internal DataGridViewTextBoxColumn cPassMailRecovery;

	internal DataGridViewTextBoxColumn cPhone;

	internal DataGridViewTextBoxColumn cName;

	internal DataGridViewTextBoxColumn cFollow;

	internal DataGridViewTextBoxColumn cFriend;

	internal DataGridViewTextBoxColumn cGroup;

	internal DataGridViewTextBoxColumn cPage;

	internal DataGridViewTextBoxColumn cPagePro5;

	internal DataGridViewTextBoxColumn cBirthday;

	internal DataGridViewTextBoxColumn B08334BA;

	internal DataGridViewTextBoxColumn cOAuth2;

	internal DataGridViewTextBoxColumn cUseragent;

	internal DataGridViewTextBoxColumn cProxy;

	internal DataGridViewTextBoxColumn EC1D5D87;

	internal DataGridViewTextBoxColumn cAvatar;

	internal DataGridViewTextBoxColumn cProfile;

	internal DataGridViewTextBoxColumn cThuMuc;

	internal DataGridViewTextBoxColumn AAAA23A0;

	internal DataGridViewTextBoxColumn C3A7F727;

	internal DataGridViewTextBoxColumn cGhiChu;

	internal DataGridViewTextBoxColumn E3A87600;

	internal DataGridViewTextBoxColumn cLocation;

	internal DataGridViewTextBoxColumn C3B975B3;

	internal DataGridViewTextBoxColumn A49D0F28;

	internal DataGridViewTextBoxColumn cDating;

	internal DataGridViewTextBoxColumn cAds;

	internal DataGridViewTextBoxColumn E20C7799;

	internal DataGridViewTextBoxColumn cWallPosts;

	internal DataGridViewTextBoxColumn cFbBlock;

	internal DataGridViewTextBoxColumn cJob;

	internal DataGridViewTextBoxColumn cKichBan;

	internal DataGridViewTextBoxColumn cCookieHotmail;

	internal DataGridViewTextBoxColumn E9057028;

	internal ToolStripMenuItem E88CFB1A;

	internal ToolStripMenuItem BEB1F03C;

	internal ToolStripMenuItem ctmsTinhNangKhac;

	internal ToolStripMenuItem C7BD1D91;

	internal ToolStripMenuItem chayToolStripMenuItem;
    private IContainer components;
    internal DataGridViewTextBoxColumn cId;
    internal DataGridViewTextBoxColumn cUid;
    internal DataGridViewTextBoxColumn cPassword;
    internal DataGridViewTextBoxColumn cFa2;
    internal DataGridViewTextBoxColumn cPassMail;
    internal DataGridViewTextBoxColumn cGender;
    internal DataGridViewTextBoxColumn cDateCreateAcc;
    internal DataGridViewTextBoxColumn cInteractEnd;
    internal DataGridViewTextBoxColumn cInfo;
    internal DataGridViewTextBoxColumn cStatus282;
    internal DataGridViewTextBoxColumn cHometown;
    internal DataGridViewTextBoxColumn cCurrentCity;
    internal DataGridViewTextBoxColumn cBM;
    internal DataGridViewTextBoxColumn cStatus;
    internal ToolStripMenuItem toolStripMenuItem_46;

	public fMain(string string_1)
	{
		InitializeComponent();
		picLanguage.Image = ((Base.smethod_2() != "VN") ? bitmap_2 : D5126D0C);
		picLanguage.Visible = Base.AE177D31;
		base.Icon = Class155.D596C6A5;
		pictureBox1.Image = Class155.DD225F0D;
		Text = "LushCare - Phần Mềm Quản Lý Và Chăm Sóc Tài Khoản Facebook";
		B526D03A.Text = "LushCare - Phần Mềm Quản Lý Và Chăm Sóc Tài Khoản Facebook - LushCare v26.01 Pro";
		string[] array = string_1.Split('|');
		lblDateExpried.Text = Convert.ToDateTime(array[2]).ToString("dd/MM/yyyy");
		lblKey.Text = array[3].Substring(0, 10) + "****";
		CC9D630E.Text = array[0];
		fMain_0 = this;
		EB201A06();
		txbSearch.AF8ADE0B();
		ctmsTinhNangKhac.Visible = Base.bool_0;
        AddProfileSessionMenu();
        SetupAvatarFeatures();
        SetupKichBanVaThongKeMenu();
        SetupAccountWarmUpMenu();
        SetupAccountHealthFeatures();
        SetupCookieVaultFeatures();
        SetupDatabaseBackupFeatures();
        SetupQuickSelectorFeatures();
        SetupProcessGovernorFeatures();
        ApplyCompactContextMenuStyle();
        SetupLiveSearchFeatures();
		try
		{
			typeof(DataGridView).InvokeMember("DoubleBuffered",
				System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
				null, F5325785, new object[] { true });
		}
		catch { }
		try
		{
			ModernUITheme.ApplyTheme(this);
			this.Load += (s, e) =>
			{
				try
				{
					ModernUITheme.ApplyTheme(this);
				}
				catch { }
			};
		}
		catch { }
	}

    /// <summary>
    /// Chuẩn hóa toàn bộ nhãn menu chuột phải (ctmsAcc) ngắn gọn 2-3 từ chuẩn MMO,
    /// loại bỏ hoàn toàn tình trạng bè ngang, thưa thớt và tràn màn hình.
    /// </summary>
    public void ApplyCompactContextMenuStyle()
    {
        try
        {
            if (this.ctmsAcc == null) return;

            // 1. Tinh gọn nhãn các mục trên root menu để menu vuông vắn, không phình ngang
            if (this.toolStripMenuItem_4 != null) this.toolStripMenuItem_4.Text = "Bỏ chọn";
            if (this.toolStripMenuItem_36 != null) this.toolStripMenuItem_36.Text = "Ẩn đã chọn";
            if (this.toolStripMenuItem1 != null) this.toolStripMenuItem1.Text = "Ẩn chưa chọn";
            if (this.toolStripMenuItem_33 != null) this.toolStripMenuItem_33.Text = "Nhập UA";
            if (this.toolStripMenuItem_2 != null) this.toolStripMenuItem_2.Text = "Mở Chrome";
            if (this.toolStripMenuItem_3 != null) this.toolStripMenuItem_3.Text = "Xóa nick";
            if (this.A492F617 != null) this.A492F617.Text = "Kiểm tra";
            if (this.toolStripMenuItem_8 != null) this.toolStripMenuItem_8.Text = "Cập nhật";
            if (this.BE8BBBA0 != null) this.BE8BBBA0.Text = "Chuyển mục";
            if (this.A10EFE26 != null) this.A10EFE26.Text = "Profile";
            if (this.giaiCheckpointToolStripMenuItem != null) this.giaiCheckpointToolStripMenuItem.Text = "Checkpoint";
            if (this.toolStripMenuItem_7 != null) this.toolStripMenuItem_7.Text = "Tải lại";

            // 2. Tắt hiển thị cột phím tắt bên phải trên toàn bộ menu và submenu
            DisableShortcutKeysRecursive(this.ctmsAcc.Items);
        }
        catch { }
    }

    private void DisableShortcutKeysRecursive(ToolStripItemCollection items)
    {
        if (items == null) return;
        foreach (ToolStripItem item in items)
        {
            if (item is ToolStripMenuItem menuItem)
            {
                menuItem.ShowShortcutKeys = false;
                if (menuItem.HasDropDownItems)
                {
                    DisableShortcutKeysRecursive(menuItem.DropDownItems);
                }
            }
        }
    }

	private void EB201A06()
	{
		Language.CD21F0A9(this);
		Language.smethod_0(ctmsAcc);
		try
		{
			if (!Base.bool_8)
			{
				B526D03A.Text = "LushCare - " + Language.GetValue("Phần Mềm Quản Lý Và Chăm Sóc Tài Khoản Facebook") + " - LushCare v26.01 Pro";
			}
		}
		catch (Exception)
		{
		}
	}

	protected override void OnLoad(EventArgs E6A9EB10)
	{
		Application.Idle += B2BB3600;
	}

	private void B2BB3600(object sender, EventArgs e)
	{
		Application.Idle -= B2BB3600;
		C3919999.Text = Language.GetValue("Đã kích hoạt");
		method_0();
		method_137();
		C5A7879A(1);
		method_1(DC234E98());
		D39C9728.Cursor = Cursors.Hand;
		F2A46D35();
		Commom.DeleteTempFile();
	}

	private void method_0()
	{
		Dictionary<string, string> dataSource = new Dictionary<string, string>
		{
			{ "all", Language.GetValue("Tất cả") },
			{ "cUid", "UID" },
			{
				"cPassword",
				Language.GetValue("Mật khẩu")
			},
			{
				"cName",
				Language.GetValue("Tên")
			},
			{
				"cBirthday",
				Language.GetValue("Ngày sinh")
			},
			{
				"cGender",
				Language.GetValue("Giới tính")
			},
			{ "cToken", "Token" },
			{ "cCookies", "Cookie" },
			{ "cEmail", "Email" },
			{ "cPassMail", "Pass email" },
			{ "cFa2", "2FA" },
			{
				"cGhiChu",
				Language.GetValue("Ghi chu\u0301")
			},
			{
				"cInteractEnd",
				Language.GetValue("Tương ta\u0301c cuô\u0301i")
			}
		};
		cbbSearch.DataSource = new BindingSource(dataSource, null);
		cbbSearch.ValueMember = "Key";
		cbbSearch.DisplayMember = "Value";
	}

	private void C5A7879A(int DB27660E = -1)
	{
		try
		{
			bool_0 = false;
			DataTable dataSource = CommonSQL.smethod_1(bool_0: true);
			D38F4B00.DataSource = dataSource;
			D38F4B00.ValueMember = "id";
			D38F4B00.DisplayMember = "name";
			if (DB27660E != -1 && D38F4B00.Items.Count >= DB27660E)
			{
				D38F4B00.SelectedIndex = DB27660E;
			}
			else if (D38F4B00.Items.Count == 2)
			{
				D38F4B00.SelectedIndex = -1;
			}
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	private void method_1(List<string> A9BFBDBC = null)
	{
		try
		{
			DataTable dataSource = CommonSQL.F314C9A4(A9BFBDBC);
			FE921A1C.DataSource = dataSource;
			FE921A1C.ValueMember = "id";
			FE921A1C.DisplayMember = "name";
		}
		catch
		{
		}
	}

	private void ADA8C634_Click(object sender, EventArgs e)
	{
		Commom.DeleteTempFile();
		try
		{
			Class87.smethod_3();
			if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbBackupDB"))
			{
				Commom.CloneDatabase();
			}
			Environment.Exit(0);
		}
		catch
		{
			Close();
		}
	}

	private void btnMaximize_Click(object sender, EventArgs e)
	{
		this.E6175915();
	}

	private void E836E3B2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	public void E48D7F88(object sender, EventArgs e)
	{
		string text = "";
		if (D38F4B00.SelectedValue != null)
		{
			text = D38F4B00.SelectedValue.ToString();
		}
		C5A7879A();
		if (text != "999999" && text != "-2")
		{
			int_1 = -1;
			D38F4B00.SelectedValue = text;
			return;
		}
		bool_0 = false;
		D38F4B00.SelectedValue = text;
		bool_0 = true;
		method_1(fChonThuMuc.list_0);
	}

	private List<string> DC234E98()
	{
		List<string> result = null;
		try
		{
			string text = D38F4B00.SelectedValue.ToString();
			string text2 = text;
			if (!(text2 == "-2"))
			{
				result = ((text2 == "999999") ? GClass13.C53EB88B(fChonThuMuc.list_0) : new List<string> { D38F4B00.SelectedValue.ToString() });
			}
		}
		catch
		{
		}
		return result;
	}

	private void method_2(List<string> list_5 = null, string string_1 = "")
	{
		try
		{
			F5325785.Rows.Clear();
			if (string_1 == "[Tất cả tình trạng]" || string_1 == Language.GetValue("[Tất cả tình trạng]"))
			{
				string_1 = "";
			}
			DataTable dataTable_ = CommonSQL.A23CD00B(list_5, string_1);
			method_3(dataTable_);
		}
		catch (Exception)
		{
		}
	}

	private void method_3(DataTable dataTable_0)
	{
		EAB09F19.smethod_4(F5325785, dataTable_0);
		EA1B25A9(0);
		B32084AC();
		method_116();
	}

	private void EE3FA802(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			if (D38F4B00.SelectedValue != null)
			{
				text = D38F4B00.SelectedValue.ToString();
			}
			fImportAccount fImportAccount2 = new fImportAccount(text);
			Commom.smethod_35(fImportAccount2);
			if (fImportAccount2.bool_0 || fImportAccount2.bool_1)
			{
				C5A7879A();
				int_1 = -1;
				if (fImportAccount2.bool_0)
				{
					D38F4B00.SelectedValue = fImportAccount2.int_0;
				}
				else
				{
					D38F4B00.SelectedValue = text;
				}
			}
		}
		catch
		{
		}
	}

	private void method_4(string string_1)
	{
		switch (string_1)
		{
		case "ToggleCheck":
		{
			for (int k = 0; k < F5325785.SelectedRows.Count; k++)
			{
				int index = F5325785.SelectedRows[k].Index;
				B183E907(index, "cChose", !Convert.ToBoolean(F6061E95(index, "cChose")));
			}
			EA1B25A9();
			break;
		}
		case "SelectHighline":
		{
			DataGridViewSelectedRowCollection selectedRows = F5325785.SelectedRows;
			for (int j = 0; j < selectedRows.Count; j++)
			{
				B183E907(selectedRows[j].Index, "cChose", true);
			}
			EA1B25A9();
			break;
		}
		case "UnAll":
		{
			for (int l = 0; l < F5325785.RowCount; l++)
			{
				B183E907(l, "cChose", false);
			}
			EA1B25A9(0);
			break;
		}
		case "All":
		{
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				B183E907(i, "cChose", true);
			}
			EA1B25A9(F5325785.RowCount);
			break;
		}
		}
	}

	private void method_5(string string_1)
	{
		if (method_129())
		{
			try
			{
				List<string> values = A838519C(string_1);
				Commom.SetTextToClipboard(string.Join("\r\n", values));
			}
			catch
			{
			}
		}
	}

	private List<string> A838519C(string string_1)
	{
		List<string> list = new List<string>();
		try
		{
			List<string> list2 = string_1.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				if (!Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				List<string> list3 = new List<string>();
				for (int j = 0; j < list2.Count; j++)
				{
					string text = F6061E95(i, list2[j]);
					if (list2[j] == "cProxy" && text.Length > 2)
					{
						if (text[text.Length - 2].ToString() == "*")
						{
							text = text.Substring(0, text.Length - 2);
						}
					}
					else if (list2[j] == "cMa2Fa")
					{
						text = Commom.smethod_62(F6061E95(i, "cFa2"));
					}
					list3.Add(text);
				}
				list.Add(string.Join("|", list3));
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	private void FC8A5097_Click(object sender, EventArgs e)
	{
		method_4("All");
	}

	private void EEAB969B_Click(object sender, EventArgs e)
	{
		method_4("SelectHighline");
	}

	private void D422C22F(object sender, EventArgs e)
	{
		method_4("UnAll");
	}

	private void tokenToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_5("cToken");
	}

	private void C5106CA9(object sender, EventArgs e)
	{
		method_5("cCookies");
	}

	private void DBA27319(object sender, EventArgs e)
	{
		method_5("cUid");
	}

	private void passToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_5("cPassword");
	}

	private void uidPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_5("cUid|cPassword");
	}

	private void E63B6D29(object sender, EventArgs e)
	{
		method_5("cUid|cPassword|cToken|cCookies");
	}

	private void AddFileAccount_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fAddFile());
		if (fAddFile.bool_0)
		{
			C5A7879A();
			D38F4B00.SelectedIndex = D38F4B00.Items.Count - 2;
		}
	}

	private void AA0AEBBB(object sender, CancelEventArgs e)
	{
		toolStripMenuItem_10.DropDownItems.Clear();
		List<string> F60F319A = new List<string>();
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text2 = "";
				string text3 = "";
				for (int l = 0; l < F5325785.RowCount; l++)
				{
					text2 = F6061E95(l, "cStatus").Trim();
					if (text2 != "")
					{
						text3 = Regex.Match(text2, "\\(IP: (.*?)\\)", RegexOptions.Singleline).Value;
						if (text3 != "")
						{
							text2 = text2.Replace(text3, "").Trim();
						}
						text3 = Regex.Match(text2, "\\[(.*?)\\]").Value;
						if (text3 != "")
						{
							text2 = text2.Replace(text3, "").Trim();
						}
						if (text2 != "" && !F60F319A.Contains(text2))
						{
							F60F319A.Add(text2);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		});
		thread.Start();
		if (!thread.Join(5000))
		{
			thread.Abort();
		}
		for (int i = 0; i < F60F319A.Count; i++)
		{
			toolStripMenuItem_10.DropDownItems.Add(F60F319A[i]);
			toolStripMenuItem_10.DropDownItems[i].Click += AB058F02;
		}
		tinhTrangToolStripMenuItem.DropDownItems.Clear();
		F60F319A = new List<string>();
		thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text = "";
				for (int k = 0; k < F5325785.RowCount; k++)
				{
					text = F6061E95(k, "cInfo");
					if (!text.Equals("") && !F60F319A.Contains(text))
					{
						F60F319A.Add(text);
					}
				}
			}
			catch (Exception)
			{
			}
		});
		thread.Start();
		if (!thread.Join(5000))
		{
			thread.Abort();
		}
		for (int j = 0; j < F60F319A.Count; j++)
		{
			tinhTrangToolStripMenuItem.DropDownItems.Add(F60F319A[j]);
			tinhTrangToolStripMenuItem.DropDownItems[j].Click += method_6;
		}
		F881A71F.DropDownItems.Clear();
		bool_3 = true;
		C90A602B.DropDownItems.Clear();
		bool_4 = true;
		BE8BBBA0.DropDownItems.Clear();
		A88D2489 = true;
	}

	private void method_6(object sender, EventArgs e)
	{
		DC0B5AAE("cInfo", (sender as ToolStripMenuItem).Text);
	}

	private void AB058F02(object sender, EventArgs e)
	{
		DC0B5AAE("cStatus", (sender as ToolStripMenuItem).Text);
	}

	private void DC0B5AAE(string A534B901, string B31DD7AA)
	{
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			F5325785.Rows[i].Cells["cChose"].Value = F6061E95(i, A534B901).Contains(B31DD7AA);
		}
		EA1B25A9();
	}

	private void method_7(object sender, EventArgs e)
	{
		if (method_129())
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có thực sự muốn chuyển {0} tài khoản sang thư mục [{1}]?"), lblCountSelect.Text, toolStripMenuItem.Text)) == DialogResult.Yes)
			{
				CA120E9B(toolStripMenuItem.Tag.ToString());
			}
		}
	}

	private void CA120E9B(string string_1)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					list.Add(F5325785.Rows[i].Cells["cId"].Value.ToString());
				}
			}
			if (CommonSQL.smethod_10(list, "idfile", string_1))
			{
				for (int j = 0; j < F5325785.RowCount; j++)
				{
					if (Convert.ToBoolean(F5325785.Rows[j].Cells["cChose"].Value))
					{
						F5325785.Rows.RemoveAt(j--);
					}
				}
				B32084AC();
				AF952311();
				EA1B25A9(0);
				method_116();
				MsBoxHelper.Show(string.Format(Language.GetValue("Chuyển thành công {0} tài khoản!"), list.Count));
			}
			else
			{
				MsBoxHelper.Show("Chuyển thất bại, vui lòng thử lại sau!", 2);
			}
		}
		catch
		{
		}
	}

	private void method_8(bool bool_5)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
			{
				list.Add(F5325785.Rows[i].Cells["cId"].Value.ToString());
			}
		}
		if (list.Count == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn tài khoản cần xóa!");
		}
		else
		{
			if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có muốn xóa {0} tài khoản đã chọn?"), method_128()) + "\r\n\r\n" + Language.GetValue("(Ta\u0300i khoa\u0309n sau khi xo\u0301a se\u0303 đươ\u0323c lưu ta\u0323i mu\u0323c [Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a])")) != DialogResult.Yes)
			{
				return;
			}
			if (bool_5)
			{
				int AC3CDBA3 = 0;
				int num = 0;
				while (num < F5325785.Rows.Count)
				{
					if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
					{
						if (AC3CDBA3 < 10)
						{
							Interlocked.Increment(ref AC3CDBA3);
							int int_0 = num++;
							Thread thread = new Thread((ThreadStart)delegate
							{
								method_130(int_0, Language.GetValue("Đang xo\u0301a profile..."));
								A6200B8E(int_0);
								Interlocked.Decrement(ref AC3CDBA3);
							});
							thread.IsBackground = true;
							thread.Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				while (AC3CDBA3 > 0)
				{
					Commom.smethod_52(1.0);
				}
			}
			if (CommonSQL.smethod_14(list))
			{
				for (int j = 0; j < F5325785.RowCount; j++)
				{
					if (Convert.ToBoolean(F5325785.Rows[j].Cells["cChose"].Value))
					{
						F5325785.Rows.RemoveAt(j--);
					}
				}
				AF952311();
				method_116();
				EA1B25A9(0);
			}
			else
			{
				MsBoxHelper.Show("Xóa thất bại, vui lòng thử lại sau!", 2);
			}
		}
	}

	private Dictionary<string, List<string>> BE9D9A93(string string_1, string string_2, string string_3, string E20922AD = "typeNganCach")
	{
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		try
		{
			List<string> list = Class154.FD11BF96(string_1, string_2);
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string key = list[i];
					GClass4 gClass = new GClass4(Class154.smethod_17(key), F79F9AB5: true);
					List<string> list2 = new List<string>();
					list2 = ((!new List<string> { "txtUid", "lstNhomTuNhap", "txtLinkChiaSe", "txtIdPost", "txtLink" }.Contains(string_3)) ? gClass.method_1(string_3, gClass.method_2(E20922AD)) : gClass.method_1(string_3));
					dictionary.Add(key, list2);
				}
			}
		}
		catch
		{
		}
		return dictionary;
	}

	private void B72D90A4(Dictionary<string, List<string>> dictionary_29, string DB8CAA95 = "txtUid", string string_1 = "")
	{
		if (dictionary_29.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<string, List<string>> item in dictionary_29)
		{
			string key = item.Key;
			List<string> value = item.Value;
			GClass4 gClass = new GClass4(Class154.smethod_17(key), F79F9AB5: true);
			if (string_1 == "" || gClass.method_3(string_1))
			{
				gClass.FD3CCF90(DB8CAA95, value);
				Class154.smethod_13(key, "", gClass.ED11179C());
			}
		}
	}

	private void method_9()
	{
		bool flag = false;
		FormCollection openForms = Application.OpenForms;
		foreach (Form item in openForms)
		{
			if (item.Name == "fViewChrome")
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			new fViewChrome(this).Show();
		}
	}

	private void method_10()
	{
		FormCollection openForms = Application.OpenForms;
		foreach (Form CA1766B9 in openForms)
		{
			if (CA1766B9.Name == "fViewChrome")
			{
				CA1766B9.Invoke((MethodInvoker)delegate
				{
					CA1766B9.Close();
				});
				break;
			}
		}
	}

	private void method_11()
	{
		dictionary_1 = new Dictionary<string, List<string>>();
		try
		{
			string text = C5034B95.smethod_0("configGeneral").BDB80B23("pathResult", "output\\resultSpam");
			if (text == "output\\resultSpam")
			{
				Commom.CreateFolder("output");
				Commom.CreateFolder("output\\resultSpam");
			}
		}
		catch
		{
		}
	}

	private bool C496D581(string DF87E5BE)
	{
		foreach (KeyValuePair<string, List<string>> item in dictionary_1)
		{
			if (item.Value.Contains(DF87E5BE))
			{
				return true;
			}
		}
		return false;
	}

	private void C889E701(object sender, EventArgs e)
	{
		try
		{
			if (btnInteract.Image == bitmap_1)
			{
				Base.smethod_6(bool_9: true);
				btnInteract.Enabled = false;
				btnInteract.Text = Language.GetValue("Đang dư\u0300ng...");
			}
			else
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("Interact", true);
				method_12(gClass);
			}
		}
		catch
		{
		}
	}

	private void method_12(GClass4 EDBE2CBF = null)
	{
		try
		{
			if (!method_129())
			{
				return;
			}
			if (Class59.ED081E86() && C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin") && Process.GetProcessesByName("GPMLogin").Length == 0)
			{
				MsBoxHelper.Show("Vui lòng mở GPMLogin trước khi chạy tương tác!", 2);
				return;
			}
			int BD8A5DBD = C5034B95.smethod_0("configGeneral").method_2("nudInteractThread", 3);
			if (EDBE2CBF.method_3("OpenBrowser"))
			{
				BD8A5DBD = method_128();
			}
			list_1 = method_24(ref BD8A5DBD);
			if (list_1 != null && list_1.Count == 0)
			{
				MsBoxHelper.Show("Proxy không đủ, vui lòng cấu hình lại!", 2);
				return;
			}
			List<int> list_0 = new List<int>();
			for (int i = 0; i < BD8A5DBD; i++)
			{
				list_0.Add(0);
			}
			method_113("start");
			bool flag = false;
			if ((!EDBE2CBF.method_3("OpenBrowser")) ? (C5034B95.smethod_0("configGeneral").method_3("ckbAddChromeIntoForm") || C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView")) : C5034B95.smethod_0("configOpenBrowser").method_3("ckbAddChromeIntoForm"))
			{
				method_9();
			}
			dictionary_28 = new Dictionary<string, List<string>>();
			C73602B4 = new Dictionary<string, List<string>>();
			bool_2 = true;
			Base.smethod_6(bool_9: false);
			int EF9EEC32 = 0;
			bool bool_0 = false;
			int_0 = 0;
			this.list_0 = new List<Thread>();
			string BE074EA2;
			Thread thread = new Thread((ThreadStart)delegate
			{
				try
				{
					if (EDBE2CBF.method_3("Interact"))
					{
						List<string> list = new List<string>();
						BE074EA2 = "";
						string text = "";
						int num = C5034B95.smethod_0("configInteractGeneral").method_2("nudSoLuotChay", 1);
						if (num == 0)
						{
							num = 1;
						}
						for (int j = 0; j < num; j++)
						{
							list = new List<string>();
							if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayNhieuKichBan"))
							{
								list = C5034B95.smethod_0("configInteractGeneral").method_1("lstIdKichBan");
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbRandomKichBan"))
								{
									list = Commom.EBBFB196(list);
									list = Commom.EBBFB196(list);
									list = Commom.EBBFB196(list);
								}
							}
							else
							{
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll"))
								{
									text = ((num > 1) ? string.Format(Language.GetValue("Lượt {0}/{1}. "), j + 1, num) : "");
								}
								C5034B95.smethod_0("configInteractGeneral").BDB80B23("cbbKichBan");
								list.Add(C5034B95.smethod_0("configInteractGeneral").BDB80B23("cbbKichBan"));
							}
							for (int k = 0; k < list.Count; k++)
							{
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaCache"))
								{
									AEB68C15(null, null);
								}
								if (Base.smethod_5())
								{
									break;
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbRandomThuTuTaiKhoan"))
								{
									F5325785.Invoke((MethodInvoker)delegate
									{
										method_127();
									});
								}
								BE074EA2 = list[k];
								if (text != "" || list.Count > 1)
								{
									B904D982(text + $"Kịch bản ({k + 1}/{list.Count}): {Class154.F8339D27(BE074EA2)}...");
								}
								dictionary_25 = BE9D9A93(BE074EA2, "HDDanhGiaPage", "txtComment");
								DAB1D692 = BE9D9A93(BE074EA2, "HDThamGiaNhomUid", "txtUid");
								DE0D9D90 = BE9D9A93(BE074EA2, "HDKetBanVoiBanBeCuaUid", "txtUid");
								dictionary_0 = BE9D9A93(BE074EA2, "HDKetBanTepUid", "txtUid");
								D68DE6AD = BE9D9A93(BE074EA2, "HDSpamBaiViet", "txtUid");
								E6810C8F = BE9D9A93(BE074EA2, "HDSpamBaiViet", "txtComment");
								EF9BBAAF = E6810C8F.smethod_6();
								CB89B620 = BE9D9A93(BE074EA2, "HDBuffTinNhanProfile", "txtUid");
								dictionary_10 = BE9D9A93(BE074EA2, "HDBuffLikeComment", "txtIdPost");
								B2978823 = BE9D9A93(BE074EA2, "HDBuffLikeComment", "txtComment");
								dictionary_2 = B2978823.smethod_6();
								BB33F205 = BE9D9A93(BE074EA2, "HDBuffLikeComment", "txtContentShare", "cbbTuyChonNoiDungShare");
								B0873E9C = BB33F205.smethod_6();
								dictionary_3 = BE9D9A93(BE074EA2, "HDBuffLikeComment", "txtContentShareMess", "cbbTuyChonNoiDungShareMess");
								dictionary_4 = dictionary_3.smethod_6();
								dictionary_5 = BE9D9A93(BE074EA2, "HDBuffTinNhanProfile", "txtNoiDung");
								dictionary_6 = dictionary_5.smethod_6();
								dictionary_7 = BE9D9A93(BE074EA2, "HDDangStatus", "txtNoiDung");
								A83F1A36 = dictionary_7.smethod_6();
								dictionary_8 = BE9D9A93(BE074EA2, "HDDangStatusV2", "txtNoiDung");
								dictionary_9 = dictionary_8.smethod_6();
								dictionary_11 = BE9D9A93(BE074EA2, "HDPhanHoiBinhLuan", "txtIdPost");
								DAB96D09 = BE9D9A93(BE074EA2, "HDBuffFollowLikePage", "txtUid");
								dictionary_12 = BE9D9A93(BE074EA2, "HDLinkToInstagram", "txtBio");
								F53E0407 = BE9D9A93(BE074EA2, "HDReviewPage", "txtUid");
								BB96210A = BE9D9A93(BE074EA2, "HDTaoPage", "txtPageName");
								dictionary_13 = BE9D9A93(BE074EA2, "HDDangBai", "lstNhomTuNhap");
								dictionary_14 = BE9D9A93(BE074EA2, "HDDangBai", "txtIdPost");
								dictionary_15 = BE9D9A93(BE074EA2, "HDTuongTacReelChiDinh", "txtIdPost");
								dictionary_16 = BE9D9A93(BE074EA2, "HDTuongTacReelChiDinh", "txtContentShare");
								dictionary_17 = BE9D9A93(BE074EA2, "HDTuongTacReelChiDinh", "txtComment");
								dictionary_18 = BE9D9A93(BE074EA2, "HDTuongTacLivestream", "txtComment");
								dictionary_19 = BE9D9A93(BE074EA2, "HDDangBai", "txtNoiDung");
								dictionary_20 = new Dictionary<string, List<string>>();
								DBB0FB3E = BE9D9A93(BE074EA2, "HDDangBai", "txtTTBVComment", "cbbTTBVTuyChonNoiDung");
								foreach (var kvp in BE9D9A93(BE074EA2, "HDDangBaiV2", "lstNhomTuNhap"))
								{
									dictionary_13[kvp.Key] = kvp.Value;
								}
								foreach (var kvp in BE9D9A93(BE074EA2, "HDDangBaiV2", "txtIdPost"))
								{
									dictionary_14[kvp.Key] = kvp.Value;
								}
								foreach (var kvp in BE9D9A93(BE074EA2, "HDDangBaiV2", "txtNoiDung"))
								{
									dictionary_19[kvp.Key] = kvp.Value;
								}
								foreach (var kvp in BE9D9A93(BE074EA2, "HDDangBaiV2", "txtTTBVComment", "cbbTTBVTuyChonNoiDung"))
								{
									DBB0FB3E[kvp.Key] = kvp.Value;
								}
								A91273B2 = BE9D9A93(BE074EA2, "HDAddMail", "lstHotmail");
								dictionary_22 = new Dictionary<string, List<string>>();
								FE314201 = new Dictionary<string, List<string>>();
								C03C6C3A = new Dictionary<string, Dictionary<string, int>>();
								A321A6B2 = BE9D9A93(BE074EA2, "HDPhanHoiBinhLuan", "txtComment");
								dictionary_23 = BE9D9A93(BE074EA2, "HDDangReel", "txtNoiDung");
								dictionary_24 = BE9D9A93(BE074EA2, "HDShareBai", "txtNoiDung");
								dictionary_21 = BE9D9A93(BE074EA2, "HDTuongTacReelNgauNhien", "txtComment");
								dictionary_26 = BE9D9A93(BE074EA2, "HDDoiTen", "lstHoTen");
								dictionary_27 = dictionary_26.smethod_6();
								method_11();
								if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy") == 1)
								{
									for (int l = 0; l < list_1.Count; l++)
									{
										(list_1[l] as XProxyproxy).method_1();
									}
								}
								if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 14)
								{
									for (int m = 0; m < A31D6D9C.Count; m++)
									{
										A31D6D9C[m].method_1();
									}
								}
								Thread thread2 = new Thread((ThreadStart)delegate
								{
									try
									{
										int num17 = 0;
										while (num17 < F5325785.Rows.Count && !Base.smethod_5())
										{
											if (Convert.ToBoolean(F5325785.Rows[num17].Cells["cChose"].Value))
											{
												if (Base.smethod_5())
												{
													break;
												}
												if (this.list_0.Count < BD8A5DBD)
												{
													if (Base.smethod_5())
													{
														break;
													}
													int int_4 = num17++;
													if (int_4 > 0)
													{
														Commom.smethod_52(0.1);
													}
													Thread thread7 = new Thread((ThreadStart)delegate
													{
														int int_5 = Commom.smethod_56(ref list_0);
														try
														{
															method_17(int_4, int_5, BE074EA2, EDBE2CBF);
															Commom.B33105BA(ref list_0, int_5);
															bool flag2 = false;
															if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll") && !C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayNhieuKichBan"))
															{
																flag2 = true;
															}
															else
															{
																string text2 = BA8BE803(int_4);
																if (text2 != "Live")
																{
																	flag2 = true;
																}
																if (!flag2)
																{
																	string text3 = method_135(int_4).ToLower();
																	flag2 = text3.Contains("checkpoint") || text3.Contains("invalid username or password") || text3.Contains("Proxy chưa ủy quyền!".ToLower()) || text3.Contains("fb block") || text3.Contains("Max Job Today".ToLower()) || text3.Contains("Token die".ToLower()) || text3.Contains("job fail");
																}
															}
															if (flag2)
															{
																B183E907(int_4, "cChose", false);
															}
														}
														catch (Exception ex5)
														{
															if (ex5.ToString().Contains("Thread was being aborted."))
															{
																Commom.B33105BA(ref list_0, int_5);
																if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll") && !C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayNhieuKichBan"))
																{
																	B183E907(int_4, "cChose", false);
																}
															}
														}
													})
													{
														Name = int_4.ToString()
													};
													this.list_0.Add(thread7);
													thread7.Start();
												}
												else
												{
													if (Base.smethod_5())
													{
														break;
													}
													if ((C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 7 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTinsoft")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllXproxy")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 10 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTMProxy")))
													{
														for (int num18 = 0; num18 < this.list_0.Count; num18++)
														{
															this.list_0[num18].Join();
															this.list_0.RemoveAt(num18--);
														}
													}
													else if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 1 || C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 2)
													{
														for (int num19 = 0; num19 < this.list_0.Count; num19++)
														{
															this.list_0[num19].Join();
															this.list_0.RemoveAt(num19--);
														}
														if (Base.smethod_5())
														{
															break;
														}
														Interlocked.Increment(ref EF9EEC32);
														if (EF9EEC32 >= C5034B95.smethod_0("configGeneral").method_2("ip_nudChangeIpCount", 1))
														{
															for (int num20 = 0; num20 < 3; num20++)
															{
																bool_0 = Commom.smethod_59(C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"), C5034B95.smethod_0("configGeneral").method_2("typeDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink"), C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN"));
																if (bool_0)
																{
																	break;
																}
															}
															if (!bool_0)
															{
																MsBoxHelper.Show("Không thê\u0309 đô\u0309i ip!", 2);
																Base.smethod_6(bool_9: true);
																return;
															}
															EF9EEC32 = 0;
														}
													}
													else
													{
														for (int num21 = 0; num21 < this.list_0.Count; num21++)
														{
															if (!this.list_0[num21].IsAlive)
															{
																this.list_0.RemoveAt(num21--);
															}
														}
														Thread.Sleep(50);
													}
												}
											}
											else
											{
												num17++;
											}
											if (Base.smethod_5())
											{
												break;
											}
										}
										for (int num22 = 0; num22 < this.list_0.Count; num22++)
										{
											this.list_0[num22].Join();
										}
									}
									catch (ThreadAbortException ex4)
									{
										if (ex4.ToString().Contains("Thread was being aborted."))
										{
										}
									}
								});
								thread2.IsBackground = true;
								thread2.Start();
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGioiHanThoiGianChayKichBan"))
								{
									int num2 = Base.rd.Next(C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayKichBanFrom"), C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayKichBanTo") + 1);
									if (!thread2.Join(num2 * 60000))
									{
										thread2.Abort();
										for (int n = 0; n < this.list_0.Count; n++)
										{
											this.list_0[n].Abort();
											while (this.list_0[n].IsAlive)
											{
												Thread.Sleep(1000);
											}
										}
										while (thread2.IsAlive)
										{
											Thread.Sleep(1000);
										}
									}
								}
								else
								{
									thread2.Join();
								}
								B72D90A4(dictionary_25, "txtComment");
								B72D90A4(DAB1D692);
								B72D90A4(DE0D9D90);
								B72D90A4(dictionary_0);
								B72D90A4(D68DE6AD);
								B72D90A4(B2978823, "txtComment", "ckbAutoDeleteComment");
								B72D90A4(dictionary_5, "txtNoiDung", "ckbAutoDeleteComment");
								B72D90A4(BB33F205, "txtContentShare", "ckbAutoDeleteContentShare");
								B72D90A4(dictionary_3, "txtContentShareMess", "ckbAutoDeleteContentShareMess");
								B72D90A4(E6810C8F, "txtComment", "ckbAutoDeleteComment");
								B72D90A4(CB89B620);
								B72D90A4(dictionary_10, "txtIdPost");
								B72D90A4(dictionary_11, "txtIdPost");
								method_13(C03C6C3A, "txtIdPost");
								B72D90A4(DAB96D09);
								B72D90A4(dictionary_12, "txtBio");
								B72D90A4(F53E0407);
								B72D90A4(BB96210A, "txtPageName");
								B72D90A4(dictionary_13, "lstNhomTuNhap");
								B72D90A4(dictionary_14, "txtIdPost");
								B72D90A4(dictionary_15, "txtIdPost");
								B72D90A4(dictionary_16, "txtContentShare");
								B72D90A4(dictionary_17, "txtComment");
								B72D90A4(dictionary_18, "txtComment");
								B72D90A4(dictionary_19, "txtNoiDung");
								B72D90A4(DBB0FB3E, "txtTTBVComment");
								B72D90A4(A91273B2, "lstHotmail");
								B72D90A4(A321A6B2, "txtComment");
								B72D90A4(dictionary_23, "txtNoiDung");
								B72D90A4(dictionary_24, "txtNoiDung");
								B72D90A4(dictionary_21, "txtComment");
								B72D90A4(dictionary_26, "lstHoTen", "ckbTuDongXoaNoiDung");
								if (Base.smethod_5())
								{
									break;
								}
								if (k + 1 < list.Count)
								{
									int num3 = Base.rd.Next(C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayKichBanFrom"), C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayKichBanTo") + 1);
									int tickCount = Environment.TickCount;
									while ((Environment.TickCount - tickCount) / 1000 - num3 < 0)
									{
										B904D982(text + string.Format(Language.GetValue("Chạy kịch bản tiếp theo sau {time} giây...").Replace("{time}", (num3 - (Environment.TickCount - tickCount) / 1000).ToString())));
										Commom.smethod_52(0.5);
										if (Base.smethod_5())
										{
											break;
										}
									}
								}
							}
							if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll") || Base.smethod_5())
							{
								break;
							}
							if (j + 1 < num)
							{
								int num4 = Base.rd.Next(C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayTurnFrom"), C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayTurnTo") + 1) * 60;
								int tickCount2 = Environment.TickCount;
								while ((Environment.TickCount - tickCount2) / 1000 - num4 < 0)
								{
									B904D982(text + string.Format(Language.GetValue("Chạy lượt tiếp theo sau {time} giây...").Replace("{time}", (num4 - (Environment.TickCount - tickCount2) / 1000).ToString())));
									Commom.smethod_52(0.5);
									if (Base.smethod_5())
									{
										break;
									}
								}
							}
							if (Base.smethod_5())
							{
								break;
							}
						}
					}
					else if (EDBE2CBF.method_3("OpenBrowser"))
					{
						if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy") == 1)
						{
							for (int num5 = 0; num5 < list_1.Count; num5++)
							{
								(list_1[num5] as XProxyproxy).method_1();
							}
						}
						if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 14)
						{
							for (int num6 = 0; num6 < A31D6D9C.Count; num6++)
							{
								A31D6D9C[num6].method_1();
							}
						}
						Thread thread3 = new Thread((ThreadStart)delegate
						{
							try
							{
								int num15 = 0;
								while (num15 < F5325785.Rows.Count && !Base.smethod_5())
								{
									if (Convert.ToBoolean(F5325785.Rows[num15].Cells["cChose"].Value))
									{
										if (Base.smethod_5() || this.list_0.Count >= BD8A5DBD)
										{
											break;
										}
										if (Base.smethod_5())
										{
											break;
										}
										int int_2 = num15++;
										if (int_2 > 0)
										{
											Commom.smethod_52(0.1);
										}
										Thread thread6 = new Thread((ThreadStart)delegate
										{
											int int_3 = Commom.smethod_56(ref list_0);
											try
											{
												method_17(int_2, int_3, "", EDBE2CBF);
											}
											catch (Exception exception_3)
											{
												Commom.smethod_57(null, exception_3);
											}
										})
										{
											Name = int_2.ToString()
										};
										this.list_0.Add(thread6);
										thread6.Start();
									}
									else
									{
										num15++;
									}
								}
								for (int num16 = 0; num16 < this.list_0.Count; num16++)
								{
									this.list_0[num16].Join();
								}
							}
							catch (ThreadAbortException ex3)
							{
								if (ex3.ToString().Contains("Thread was being aborted."))
								{
								}
							}
						});
						thread3.IsBackground = true;
						thread3.Start();
						thread3.Join();
					}
					else
					{
						if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy") == 1)
						{
							for (int num7 = 0; num7 < list_1.Count; num7++)
							{
								(list_1[num7] as XProxyproxy).method_1();
							}
						}
						if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 14)
						{
							for (int num8 = 0; num8 < A31D6D9C.Count; num8++)
							{
								A31D6D9C[num8].method_1();
							}
						}
						Thread thread4 = new Thread((ThreadStart)delegate
						{
							try
							{
								int num9 = 0;
								while (num9 < F5325785.Rows.Count && !Base.smethod_5())
								{
									if (Convert.ToBoolean(F5325785.Rows[num9].Cells["cChose"].Value))
									{
										if (Base.smethod_5())
										{
											break;
										}
										if (this.list_0.Count < BD8A5DBD)
										{
											if (Base.smethod_5())
											{
												break;
											}
											int int_0 = num9++;
											if (int_0 > 0)
											{
												Commom.smethod_52(0.1);
											}
											Thread thread5 = new Thread((ThreadStart)delegate
											{
												int int_ = Commom.smethod_56(ref list_0);
												try
												{
													method_17(int_0, int_, "", EDBE2CBF);
													Commom.B33105BA(ref list_0, int_);
													if ((!C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll") && !C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayNhieuKichBan")) || BA8BE803(int_0) != "Live" || method_135(int_0).ToLower().Contains("checkpoint") || method_135(int_0).ToLower().Contains("invalid username or password") || method_135(int_0).ToLower().Contains("Proxy chưa ủy quyền!".ToLower()))
													{
														B183E907(int_0, "cChose", false);
													}
												}
												catch (Exception ex2)
												{
													if (ex2.ToString().Contains("Thread was being aborted."))
													{
														Commom.B33105BA(ref list_0, int_);
														if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll") && !C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayNhieuKichBan"))
														{
															B183E907(int_0, "cChose", false);
														}
													}
												}
											})
											{
												Name = int_0.ToString()
											};
											this.list_0.Add(thread5);
											thread5.Start();
										}
										else
										{
											if (Base.smethod_5())
											{
												break;
											}
											if ((C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 7 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTinsoft")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllXproxy")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 10 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTMProxy")))
											{
												for (int num10 = 0; num10 < this.list_0.Count; num10++)
												{
													this.list_0[num10].Join();
													this.list_0.RemoveAt(num10--);
												}
											}
											else if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 1 || C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 2)
											{
												for (int num11 = 0; num11 < this.list_0.Count; num11++)
												{
													this.list_0[num11].Join();
													this.list_0.RemoveAt(num11--);
												}
												if (Base.smethod_5())
												{
													break;
												}
												Interlocked.Increment(ref EF9EEC32);
												if (EF9EEC32 >= C5034B95.smethod_0("configGeneral").method_2("ip_nudChangeIpCount", 1))
												{
													for (int num12 = 0; num12 < 3; num12++)
													{
														bool_0 = Commom.smethod_59(C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"), C5034B95.smethod_0("configGeneral").method_2("typeDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink"), C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN"));
														if (bool_0)
														{
															break;
														}
													}
													if (!bool_0)
													{
														MsBoxHelper.Show("Không thê\u0309 đô\u0309i ip!", 2);
														Base.smethod_6(bool_9: true);
														return;
													}
													EF9EEC32 = 0;
												}
											}
											else
											{
												for (int num13 = 0; num13 < this.list_0.Count; num13++)
												{
													if (!this.list_0[num13].IsAlive)
													{
														this.list_0.RemoveAt(num13--);
													}
												}
												Thread.Sleep(50);
											}
										}
									}
									else
									{
										num9++;
									}
									if (Base.smethod_5())
									{
										break;
									}
								}
								for (int num14 = 0; num14 < this.list_0.Count; num14++)
								{
									this.list_0[num14].Join();
								}
							}
							catch (ThreadAbortException ex)
							{
								if (ex.ToString().Contains("Thread was being aborted."))
								{
								}
							}
						});
						thread4.IsBackground = true;
						thread4.Start();
						thread4.Join();
					}
				}
				catch (Exception exception_2)
				{
					Commom.smethod_57(null, exception_2);
				}
				F529F8AC();
				if (!EDBE2CBF.method_3("OpenBrowser"))
				{
					method_10();
				}
				if (EDBE2CBF.method_3("GetPageProfile"))
				{
					Commom.SetTextToClipboard(string.Join("\n", list_4));
				}
				method_113("stop");
				bool_2 = false;
			});
			thread.IsBackground = true;
			thread.Start();
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			method_113("stop");
			bool_2 = false;
		}
	}

	private void method_13(Dictionary<string, Dictionary<string, int>> CDB41111, string C0371B24)
	{
		if (CDB41111.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, Dictionary<string, int>> item in CDB41111)
		{
			string key = item.Key;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, int> item2 in item.Value)
			{
				list.Add(item2.Value + "|" + item2.Key);
			}
			GClass4 gClass = new GClass4(Class154.smethod_17(key), F79F9AB5: true);
			gClass.FD3CCF90(C0371B24, list);
			Class154.smethod_13(key, "", gClass.ED11179C());
		}
	}

	private bool method_14(Chrome chrome_0)
	{
		bool result = true;
		try
		{
			chrome_0.method_12("https://m.facebook.com/privacy/touch/timeline_and_tagging/");
			if (chrome_0.method_18("[data-store*=\"timeline_and_tagging_selectors\"]"))
			{
				chrome_0.method_45(2, 3);
				if (Convert.ToBoolean(chrome_0.method_14("return document.querySelector('[name=\"privacyX\"]').checked").ToString()))
				{
					chrome_0.method_14("document.querySelectorAll('[name=\"privacyX\"]')[1].click()");
				}
				else
				{
					chrome_0.F7221F34();
				}
				chrome_0.method_45(2, 3);
			}
			if (chrome_0.method_18("[href*=\"/privacy/touch/tags/review/?type=tag\"]"))
			{
				chrome_0.method_45(2, 3);
				if (!Convert.ToBoolean(chrome_0.method_14("return document.querySelector('input[type=\"checkbox\"]').checked+''").ToString()))
				{
					chrome_0.method_18("form div[role=\"button\"]");
				}
				else
				{
					chrome_0.F7221F34();
				}
				chrome_0.method_45(2, 3);
			}
			if (chrome_0.method_18("[href*=\"/privacy/touch/tags/review/?type=profile\"]"))
			{
				chrome_0.method_45(2, 3);
				if (!Convert.ToBoolean(chrome_0.method_14("return document.querySelector('input[type=\"checkbox\"]').checked+''").ToString()))
				{
					chrome_0.method_18("form div[role=\"button\"]");
				}
				else
				{
					chrome_0.F7221F34();
				}
				chrome_0.method_45(2, 3);
				return result;
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	private int method_15(int int_3, string string_1, Chrome chrome_0, List<string> list_5, int int_4, int int_5, int int_6, int int_7, int C416DE80, int int_8, int int_9, int F538A406, string string_2)
	{
		return RunOtherUtilities_GoogleSearch(int_3, string_1, chrome_0, list_5, int_4, int_5, int_6, int_7, C416DE80, int_8, int_9, F538A406, string_2);
	}

	private int method_15_legacy(int int_3, string string_1, Chrome chrome_0, List<string> list_5, int int_4, int int_5, int int_6, int int_7, int C416DE80, int int_8, int int_9, int F538A406, string string_2)
	{
		int result = 0;
		try
		{
			int num = Base.rd.Next(int_4, int_5 + 1);
			for (int i = 0; i < num; i++)
			{
				method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({i}/{num})...");
				if (list_5.Count == 0)
				{
					break;
				}
				string text = list_5[Base.rd.Next(0, list_5.Count)];
				list_5.Remove(text);
				string string_3 = text.Split('|')[0].Trim();
				string text2 = text.Split('|')[1].Trim();
				if (!chrome_0.CD930D04())
				{
					chrome_0.method_12("https://www.google.com.vn/");
					chrome_0.method_45(2, 3);
					string string_4 = "textarea[name=\"q\"], input[name=\"q\"], textarea[role=\"combobox\"]";
					if (!chrome_0.D7A424AE(string_4, 3.0))
					{
						continue;
					}
					chrome_0.method_45(1, 2);
					if (chrome_0.method_35(string_4))
					{
						chrome_0.method_45(1, 2);
					}
					chrome_0.method_28(string_4, string_3, 0.08);
					chrome_0.method_45(2, 3);
					chrome_0.F217FA96(string_4);
					chrome_0.method_45(2, 3);
					string text3 = "(//a[contains(@href, \"" + text2 + "\")])";
					if (!chrome_0.D7A424AE(text3))
					{
						int num2 = Base.rd.Next(int_6, int_7 + 1);
						for (int j = 0; j < num2 - 1 && chrome_0.D7A424AE("[aria-label=\"Page " + (j + 2) + "\"]"); j++)
						{
							chrome_0.method_34("[aria-label=\"Page " + (j + 2) + "\"]");
							chrome_0.method_45(2, 3);
							chrome_0.method_18("[aria-label=\"Page " + (j + 2) + "\"]");
							chrome_0.method_45(2, 3);
							if (chrome_0.D7A424AE(text3))
							{
								break;
							}
						}
					}
					if (chrome_0.D7A424AE(text3))
					{
						for (int k = 0; k < 10; k++)
						{
							if (Base.rd.Next(0, 100) % 5 == 1)
							{
								chrome_0.method_8(-Base.rd.Next(100, 300));
							}
							else
							{
								chrome_0.method_8(Base.rd.Next(100, 300));
							}
							chrome_0.method_45(1, 2);
						}
						chrome_0.method_35(text3 + "[1]");
						chrome_0.method_45(2, 3);
						chrome_0.method_17(text3 + "[1]");
					}
					else
					{
						chrome_0.method_12(text2);
					}
					int num3 = Base.rd.Next(C416DE80, int_8 + 1);
					int num4 = Convert.ToInt32(chrome_0.method_14("var count=0; document.querySelectorAll('a').forEach(e=>{if(e.getAttribute('href')!=null && e.getAttribute('href')!='') count++}); return count+''").ToString());
					for (int l = 0; l < num3; l++)
					{
						if (num4 == 0)
						{
							break;
						}
						int num5 = Base.rd.Next(1, num4 + 1);
						chrome_0.method_35("a|" + num5);
						chrome_0.method_45(2, 3);
						chrome_0.method_18("a|" + num5);
						chrome_0.F8091028(3.0);
						int num6 = Base.rd.Next(1, 3);
						for (int m = 0; m < num6; m++)
						{
							chrome_0.method_8(Base.rd.Next(100, 300));
							chrome_0.method_45(2, 3);
						}
						if (chrome_0.GetURL() != text2)
						{
							chrome_0.F7221F34();
							chrome_0.method_45(2, 3);
						}
					}
					int num7 = Base.rd.Next(int_9, F538A406 + 1);
					int tickCount = Environment.TickCount;
					int num8 = 1;
					do
					{
						num8 = ((Base.rd.Next(1, 1000) % 5 != 0) ? 1 : (-1));
						chrome_0.method_8(num8 * Base.rd.Next(100, 300));
						chrome_0.method_45(2, 3);
					}
					while (Environment.TickCount - tickCount < num7 * 1000);
					continue;
				}
				return -2;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(chrome_0, exception_, "HDSearchGoogle");
			result = -1;
		}
		return result;
	}

	private int method_16(int D492DBA5, string string_1, Chrome D010C785, List<string> list_5, int BA0E3AAD, int int_3, int int_4, int int_5, int BD03C822, int int_6, bool bool_5, string string_2)
	{
		return RunOtherUtilities_WebsiteVisit(D492DBA5, string_1, D010C785, list_5, BA0E3AAD, int_3, int_4, int_5, BD03C822, int_6, bool_5, string_2);
	}

	private int method_16_legacy(int D492DBA5, string string_1, Chrome D010C785, List<string> list_5, int BA0E3AAD, int int_3, int int_4, int int_5, int BD03C822, int int_6, bool bool_5, string string_2)
	{
		int result = 0;
		try
		{
			int num = Base.rd.Next(BA0E3AAD, int_3 + 1);
			for (int i = 0; i < num; i++)
			{
				method_130(D492DBA5, string_1 + Language.GetValue("Đang") + $" {string_2} ({i + 1}/{num})...");
				if (list_5.Count == 0)
				{
					break;
				}
				string text = list_5[Base.rd.Next(0, list_5.Count)];
				list_5.Remove(text);
				if (!D010C785.CD930D04())
				{
					D010C785.DC9244BF();
					if (text.Contains("facebook.com"))
					{
						D010C785.method_12(text);
						D010C785.F8091028(2.0);
						D010C785.method_19("a[href*=\"l.facebook.com\"]");
					}
					else
					{
						D010C785.method_12(text);
					}
					int count = D010C785.ChromeDriver_0.WindowHandles.Count;
					if (count > 1)
					{
						D010C785.method_44();
					}
					int num2 = Base.rd.Next(int_4, int_5 + 1);
					int num3 = Convert.ToInt32(D010C785.method_14("var count=0; document.querySelectorAll('a').forEach(e=>{if(e.getAttribute('href')!=null && e.getAttribute('href')!='') count++}); return count+''").ToString());
					for (int j = 0; j < num2; j++)
					{
						if (num3 == 0)
						{
							break;
						}
						int num4 = Base.rd.Next(1, num3 + 1);
						D010C785.method_35("a|" + num4);
						D010C785.method_45(2, 3);
						D010C785.method_18("a|" + num4);
						D010C785.F8091028(3.0);
						if (D010C785.ChromeDriver_0.WindowHandles.Count > count)
						{
							D010C785.method_44();
						}
						int num5 = Base.rd.Next(1, 3);
						for (int k = 0; k < num5; k++)
						{
							D010C785.method_8(Base.rd.Next(100, 300));
							D010C785.method_45(2, 3);
						}
						if (D010C785.ChromeDriver_0.WindowHandles.Count == 1)
						{
							if (D010C785.GetURL() != text)
							{
								D010C785.F7221F34();
								D010C785.method_45(2, 3);
							}
						}
						else if (D010C785.ChromeDriver_0.WindowHandles.Count > count)
						{
							D010C785.ChromeDriver_0.Close();
							D010C785.method_44();
						}
					}
					int num6 = Base.rd.Next(BD03C822, int_6 + 1);
					if (bool_5)
					{
						int tickCount = Environment.TickCount;
						int num7 = 1;
						do
						{
							num7 = ((Base.rd.Next(1, 1000) % 6 != 0) ? 1 : (-1));
							D010C785.method_8(num7 * Base.rd.Next(100, 300));
							D010C785.method_45(2, 3);
						}
						while (Environment.TickCount - tickCount < num6 * 1000);
					}
					else
					{
						D010C785.F8091028(num6);
					}
					continue;
				}
				return -2;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(D010C785, exception_, "HDSearchGoogle");
			result = -1;
		}
		return result;
	}

	private void method_17(int int_3, int int_4, string string_1, GClass4 A1BCFE35)
	{
		if (A1BCFE35 == null)
		{
			A1BCFE35 = new GClass4();
		}
		int num = 0;
		if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGioiHanThoiGianChayTaiKhoan"))
		{
			num = Base.rd.Next(C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayTaiKhoanFrom"), C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayTaiKhoanTo") + 1);
		}
		GClass3 gClass = new GClass3(Thread.CurrentThread, num);
		string string_2 = "";
		Chrome chrome = null;
		int num2 = 0;
		string string_3 = "";
		int int_5 = 0;
		Chrome chrome2 = new Chrome();
		chrome2.Boolean_2 = true;
		chrome2.F5BA98AC = Commom.E50AD706(5, 2);
		chrome2.Point_0 = new Point(-2000, 0);
		chrome2.Boolean_3 = true;
		chrome2.DA9C9817 = "data:,";
		Chrome chrome3 = chrome2;
		XProxyproxy xproxyproxy_ = null;
		ShopLike shopLike_ = null;
		MinProxyVN minProxyVN_ = null;
		ObcProxy obcProxy_ = null;
		bool flag = false;
		bool flag2 = false;
		string text = "";
		int int_6 = 0;
		int num3 = 0;
		bool flag3 = false;
		string text2 = "";
		string text3 = "";
		int F00C45B = -1;
		int F00C45B2 = -1;
		string text4 = "";
		string text5 = "";
		string AD3ACABD = "";
		string string_4 = "";
		string string_5 = "";
		string string_6 = "";
		string D72C270F = "";
		string string_7 = "";
		string text6 = "";
		string string_8 = "";
		string B588C8AD = "";
		string ACB20DA = "";
		string string_9 = "";
		string string_10 = "";
		string string_11 = "";
		int F21DDB = -1;
		int int_7 = -1;
		int int_8 = -1;
		int EE152CA = -1;
		int num4 = -1;
		string text7 = "";
		int int_9 = -1;
		string text8 = "";
		string FE912FA = "";
		string text9 = "";
		string text10 = "";
		string text11 = F6061E95(int_3, "cUid");
		string text12 = F6061E95(int_3, "cId");
		string text13 = F6061E95(int_3, "cEmail");
		string text14 = F6061E95(int_3, "cPassMail");
		string text15 = F6061E95(int_3, "cOAuth2");
		string a5A6E = F6061E95(int_3, "cCookieHotmail");
		string text16 = F6061E95(int_3, "cMailRecovery");
		string a9304E = F6061E95(int_3, "cPassMailRecovery");
		string text17 = F6061E95(int_3, "cFa2");
		string text18 = F6061E95(int_3, "cPassword");
		string text19 = F6061E95(int_3, "cCookies");
		string text20 = F6061E95(int_3, "cToken");
		if (text11 == "")
		{
			text11 = Regex.Match(text19, "c_user=(\\d+)").Groups[1].Value;
			method_134(int_3, "cUid", text11, "uid");
		}
		if (text11.Trim() != text11)
		{
			text11 = text11.Trim();
			method_134(int_3, "cUid", text11, "uid");
		}
		try
		{
			if (A1BCFE35.method_3("Interact") && C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckLiveUid") && Commom.IsUid(text11) && CommonRequest.BC9215A7(text11).StartsWith("0|"))
			{
				method_130(int_3, Language.GetValue("Tài khoản Die!"));
				E589F93F(int_3, "Die");
				num3 = 1;
			}
			else if (Base.smethod_5())
			{
				method_130(int_3, string_3 + Language.GetValue("Đã dừng!"));
				num3 = 1;
			}
			else if (!method_25(int_3, ref string_2, ref int_5, ref string_3, ref xproxyproxy_, ref shopLike_, ref minProxyVN_, ref obcProxy_))
			{
				if (Base.smethod_5())
				{
					method_130(int_3, string_3 + Language.GetValue("Đã dừng!"));
				}
				num3 = 1;
			}
			else if (Base.smethod_5())
			{
				method_130(int_3, string_3 + Language.GetValue("Đã dừng!"));
				num3 = 1;
			}
			else
			{
				try
				{
					string text21;
					if (A7A62D98(int_3, string_3, A1BCFE35, string_2, int_5))
					{
						num3 = 1;
					}
					else
					{
						text21 = "";
						if (!A1BCFE35.method_3("RecoverPass"))
						{
							goto IL_053f;
						}
						int num5 = 0;
						while (true)
						{
							if (num5 < 2)
							{
								method_130(int_3, string_3 + "Gư\u0309i yêu câ\u0300u khôi phục mật khẩu...");
								string text22 = method_27(int_3, string_3, int_4, A1BCFE35, text13, string_2, int_5);
								if (text22 != "true")
								{
									if (text22 != "")
									{
										method_130(int_3, string_3 + text22);
									}
									num3 = 1;
									break;
								}
								method_130(int_3, string_3 + "Get otp...");
								text21 = FB93BDA4.GetOtpFromMail(2, text13, text14, text15, a5A6E, 60, text11, "");
								if (text21 == "fail")
								{
									text21 = method_58(chrome3, int_3, 2);
									if (text21 == "fail")
									{
										method_130(int_3, string_3 + "Không thể kết nối mail!");
										num3 = 1;
										break;
									}
								}
								if (!text21.StartsWith("https"))
								{
									num5++;
									continue;
								}
							}
							if (text21 == "" || !text21.StartsWith("https"))
							{
								method_130(int_3, string_3 + "Không lấy được otp!");
								num3 = 1;
								break;
							}
							method_130(int_3, string_3 + "Get otp thành công!");
							goto IL_053f;
						}
					}
					goto end_IL_03b7;
					IL_053f:
					chrome = method_23(int_3, string_3, A1BCFE35, int_4, string_2, int_5);
					string string_13;
					if (chrome == null || Base.smethod_5())
					{
						num3 = 1;
					}
					else
					{
						chrome.CF8FD901 = int_3;
						chrome.AF336B2C = text12;
						chrome.B4208531 = text11;
						chrome.C234EEAA = text18;
						chrome.A1BF36A2 = text17;
						chrome.String_2 = text19;
						chrome.F5812DA8 = text20;
						chrome.F8A3B83F = text13;
						chrome.ACBD1889 = text14;
						chrome.A70B4E96 = text15;
                        if (A1BCFE35.method_3("ManualFacebookLogin"))
                        {
                            try { RunManualFacebookLogin(int_3, chrome); }
                            finally { method_26(xproxyproxy_, shopLike_, minProxyVN_, obcProxy_); }
                            return;
                        }
                        if (A1BCFE35.method_3("AccountWarmUp"))
                        {
                            try { RunAccountWarmUp(int_3, chrome); }
                            finally
                            {
                                method_55(int_3, string_3, chrome);
                                method_26(xproxyproxy_, shopLike_, minProxyVN_, obcProxy_);
                            }
                            return;
                        }
						if (A1BCFE35.method_3("LoginTiktok"))
						{
							chrome.method_12("https://tiktok.com/");
							chrome.method_39(text19, "tiktok.com");
							chrome.method_13();
							num3 = 1;
						}
						else
						{
							A539653C(chrome);
							if (A1BCFE35.method_3("RecoverPass"))
							{
								int num6 = 0;
								int num7 = 3;
								string text23 = "";
								List<string> list = new List<string>();
								list.Add("[name=\"password_new\"]");
								list.Add("div:has([name=\"logMeOut\"]) input[type=\"text\"]");
								List<string> d = list;
								string string_12 = "[value=\"kill_sessions\"],[name=\"logMeOut\"]";
								while (true)
								{
									IL_077e:
									chrome.method_12(text21);
									bool flag4 = false;
									int num8 = 0;
									while (true)
									{
										if (num8 < 60 && !chrome.CD930D04() && !chrome.E184CD03())
										{
											text23 = chrome.method_15(0.0, d);
											if (!(text23 != ""))
											{
												if (!chrome.D7A424AE("[href*=\"/login/identify/?ctx=recover\"]") && !chrome.D7A424AE("[href=\"/login/identify?ctx=recover\"]") && !chrome.D7A424AE("[action=\"/ajax/login/help/identify.php?ctx=recover\"]"))
												{
													if (!chrome.method_124())
													{
														chrome.F8091028(1.0);
														num8++;
														continue;
													}
													method_130(int_3, "Checkpoint!");
													E589F93F(int_3, "Checkpoint");
													num3 = 1;
													break;
												}
												if (chrome.D7A424AE("[href*=\"/help/177066345680802\"]"))
												{
													method_130(int_3, string_3 + "Fb Block!");
													num3 = 1;
													break;
												}
												num6++;
												if (num6 >= num7)
												{
													method_130(int_3, string_3 + "Không lấy được otp!");
													num3 = 1;
													break;
												}
												method_130(int_3, string_3 + "Get otp...");
												string text24 = FB93BDA4.GetOtpFromMail(2, text13, text14, text15, a5A6E, 60, text11, text21);
												if (text24 == "fail")
												{
													text24 = method_58(chrome3, int_3, 2, 60, text21);
												}
												if (text24.StartsWith("https"))
												{
													text21 = text24;
													goto IL_077e;
												}
											}
											else
											{
												flag4 = true;
											}
										}
										bool flag5 = false;
										if (flag4)
										{
											flag4 = false;
											chrome.F8091028(2.0);
											string text25 = C223110A();
											chrome.method_22(text23, text25);
											chrome.method_45(2, 3);
											if (C5034B95.smethod_0("configGeneral").method_3("ckbKillSession") && chrome.D7A424AE(string_12))
											{
												flag5 = true;
												chrome.method_18(string_12);
											}
											chrome.F217FA96(text23);
											F0A81525(text12, "pass", int_3, "cPassword", text25);
											chrome.C234EEAA = text25;
											int num9 = 0;
											while (num9 < 60)
											{
												string text26 = chrome.GetURL();
												if (text26.Contains("facebook.com/secured_action/block/?action=password_change"))
												{
													F0A81525(text12, "pass", int_3, "cPassword", text18);
													chrome.C234EEAA = text18;
													break;
												}
												if (text26.Contains("facebook.com/two_step_verification/two_factor/"))
												{
													flag4 = true;
													break;
												}
												if (text26.Contains("facebook.com/checkpoint/"))
												{
													flag4 = true;
													break;
												}
												if (text26.Contains("facebook.com/si/actor_experience/actor_gateway"))
												{
													flag4 = true;
													break;
												}
												string text27 = chrome.method_15(0.0, new List<string> { "[name=\"approvals_code\"]", "#MComposer", "[href*=\"facebook.com/secure_account_learn_more\"]", "[name=\"manage-sessions\"]", "#back[href=\"//www.facebook.com/\"]" });
												if (text27 != "")
												{
													if (text27 == "[name=\"approvals_code\"]" && C5034B95.smethod_0("configGeneral").method_3("ckbKillSession") && !flag5)
													{
														chrome.method_22(text27, Commom.smethod_62(chrome.A1BF36A2));
														chrome.F217FA96(text27);
														chrome.method_18("[name=\"submit[Continue]\"]");
														chrome.F8091028(2.0);
														method_44(chrome, int_3);
													}
													flag4 = ((!(text27 == "#back[href=\"//www.facebook.com/\"]")) ? true : false);
													break;
												}
												if (chrome.D7A424AE("[name=\"submit_action\"]"))
												{
													chrome.method_45(2, 3);
													chrome.method_18("[name=\"submit_action\"]");
													if (chrome.D7A424AE("[value=\"OK\"]", 10.0))
													{
														chrome.method_45(2, 3);
														chrome.method_18("[value=\"OK\"]");
													}
													flag4 = true;
													break;
												}
												if (chrome.D7A424AE("[data-sigil=\"m_login_email\"]"))
												{
													break;
												}
												if (chrome.method_124())
												{
													E589F93F(int_3, "Checkpoint");
													flag4 = true;
													break;
												}
												if (!chrome.D7A424AE("[href*=\"/help/177066345680802\"]"))
												{
													chrome.F8091028(1.0);
													num9++;
													continue;
												}
												method_130(int_3, string_3 + "Fb Block!");
												num3 = 1;
												goto end_IL_03b7;
											}
										}
										if (flag4)
										{
											if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
											{
												text19 = chrome.method_40();
												if (text19 != "")
												{
													method_134(int_3, "cCookies", text19, "cookie1");
												}
											}
											C412B9A5(int_3, 2);
											method_130(int_3, string_3 + "Khôi phục mật khẩu thành công!");
										}
										else
										{
											C412B9A5(int_3, 1);
											method_130(int_3, string_3 + "Khôi phục mật khẩu thất bại!");
										}
										num3 = 1;
										break;
									}
									break;
								}
							}
							else
							{
								method_130(int_3, string_3 + Language.GetValue("Đang đăng nhâ\u0323p..."));
								string_13 = "https://www.facebook.com/";
								switch (C5034B95.smethod_0("configInteractGeneral").method_2("typeBrowserLogin"))
								{
								case 2:
									string_13 = "https://mbasic.facebook.com";
									break;
								case 0:
									string_13 = "https://m.facebook.com/";
									break;
								}
								if (A1BCFE35.method_3("Unlock956") && (A1BCFE35.method_2("TypeUnlock956") == 2 || A1BCFE35.method_2("TypeUnlock956") == 3))
								{
									string_13 = "https://www.facebook.com/";
								}
								else if (A1BCFE35.method_3("Unlock282"))
								{
									string_13 = "https://www.facebook.com/";
								}
								if (!chrome.GetURL().Contains("facebook.com"))
								{
									chrome.method_12(string_13, FC3A841F: true);
									if (chrome.method_40().Contains("i_user"))
									{
										chrome.BE160BA0("i_user");
										chrome.method_12(string_13);
										chrome.method_54();
										chrome.method_52();
									}
								}
								chrome.method_60();
								if (!(chrome.A3A32284 != ""))
								{
									goto IL_0cdc;
								}
								chrome.F8091028(2.0);
								if (!(chrome.AFACE5B4() == "<html><head></head><body></body></html>"))
								{
									goto IL_0cdc;
								}
								num3 = 1;
								method_130(int_3, string_3 + "Proxy yêu cầu User/Pass!");
							}
						}
					}
					goto end_IL_03b7;
					IL_13d2:
					if (flag)
					{
						goto IL_143d;
					}
					if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
					{
						text19 = chrome.method_40();
						method_134(int_3, "cCookies", text19, "cookie1", F713D5BE: false);
					}
					C412B9A5(int_3, 1);
					method_79(chrome, text11, 1);
					num3 = 1;
					goto end_IL_03b7;
					IL_143d:
					if (chrome.PreserveSession && flag && !HasExpectedProfileIdentity(chrome))
                    {
                        method_130(int_3, "Phiên Facebook không khớp UID. Mở mục Đăng nhập Facebook và lưu phiên để kiểm tra.");
                        flag = false;
                        num3 = 1;
                        goto end_IL_03b7;
                    }
					bool flag6;
					uint num15;
					if (A1BCFE35.method_3("Unlock956") || A1BCFE35.method_3("Unlock282"))
					{
						if (flag6)
						{
							chrome.CA294803 = FE33ED1C.AC3A1601;
							bool flag7;
							if (flag7 = method_56(chrome, int_3, string_3, A1BCFE35))
							{
								E589F93F(int_3, "Live");
								method_130(int_3, "Unlock checkpoint success!");
							}
							C412B9A5(int_3, (!flag7) ? 1 : 2);
						}
						else if (flag)
						{
							E589F93F(int_3, "Live");
							method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p tha\u0300nh công!"));
							C412B9A5(int_3, 2);
						}
						if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
						{
							text19 = chrome.method_40();
							if (text19 != "")
							{
								method_134(int_3, "cCookies", text19, "cookie1");
							}
						}
						num3 = 1;
					}
					else
					{
						chrome.method_60();
						E589F93F(int_3, "Live");
						method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p tha\u0300nh công!"));
						C412B9A5(int_3, 2);
						if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbDontSaveBrowser"))
						{
							chrome.method_66("SaveLoginInfo");
						}
						if (chrome.method_61() == 1 && chrome.D7A424AE("[role=\"dialog\"] [aria-label=\"[object Object]\"]"))
						{
							chrome.method_21("[role=\"dialog\"] [aria-label=\"[object Object]\"]");
						}
						if (!chrome.D7A424AE("[href=\"/\"]"))
						{
							chrome.EC9B94B0();
							if (chrome.GetURL().Contains("facebook.com/si/actor_experience/actor_gateway") && chrome.D7A424AE("[data-nt=\"NT:IMAGE\"]", 15.0))
							{
								chrome.method_21("[data-nt=\"NT:IMAGE\"]");
								chrome.F8091028(2.0);
							}
							if (chrome.D7A424AE("[data-cookiebanner=\"accept_button\"]"))
							{
								chrome.method_21("[data-cookiebanner=\"accept_button\"]");
							}
							if (chrome.method_61() == 2 && chrome.D7A424AE("[href^=\"/a/preferences.php?fast_switch_site\"]"))
							{
								chrome.DA2A8C96(0, "[href^=\"/a/preferences.php?fast_switch_site\"]");
							}
							if (chrome.GetURL().StartsWith("https://free.facebook.com/") || chrome.D7A424AE("[href^=\"/upsell/advanced_upsell/in_line\"]"))
							{
								chrome.DA2A8C96(0, "[href^=\"/upsell/advanced_upsell/in_line\"]");
								chrome.DA2A8C96(5, "#upsell_upgrade_confirm_button");
							}
						}
						if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
						{
							text19 = chrome.method_40();
							method_134(int_3, "cCookies", text19, "cookie1", F713D5BE: false);
						}
						if (flag2 = !Commom.IsUid(text11))
						{
							text = text11;
							text11 = chrome.FB94939A();
							CommonSQL.B8A0E617(text12, "uid", text11);
							B183E907(int_3, "cUid", text11);
						}
						A539653C(chrome);
						if (A1BCFE35.method_3("GetPageProfile"))
						{
							List<string> list2 = new List<string>();
							if (C5034B95.smethod_0("configGetPageProfile").method_2("cbbGetToken") == 0)
							{
								if (!text20.StartsWith("EAAG") || !CommonRequest.B4B29420(text19, text20, "", string_2, int_5))
								{
									method_130(int_3, string_3 + "Get token...");
									text20 = chrome.DC8F5A1A();
									if (text20.StartsWith("EAAG"))
									{
										method_134(int_3, "cToken", text20, "token");
									}
								}
							}
							else if (!text20.StartsWith("EAAAAU") || !CommonRequest.B4B29420(text19, text20, "", string_2, int_5))
							{
								method_130(int_3, string_3 + "Get token...");
								text20 = Commom.smethod_6(text11, text18, text17, string_2, int_5);
								if (text20.StartsWith("EAAAAU"))
								{
									text20 = text20.Split('|')[0];
									method_134(int_3, "cToken", text20, "token");
								}
							}
							if (text20 == "")
							{
								method_130(int_3, string_3 + "Không lấy được token!");
								num3 = 1;
							}
							else
							{
								method_130(int_3, string_3 + "Get Page Profile...");
								string string_14 = "[{\"name\":\"token\", \"value\":\"" + text20 + "\", \"type\":\"text\"}]";
								string json = chrome.method_66("GetPageProfile2", string_14);
								JArray jArray = JArray.Parse(json);
								foreach (JToken item in jArray)
								{
									try
									{
										if (item["id"]!.ToString() != "")
										{
											list2.Add(item["id"]?.ToString() + "|" + item["token"]);
										}
									}
									catch (Exception)
									{
									}
								}
								if (list2.Count > 0)
								{
									lock (list_4)
									{
										list_4.AddRange(list2);
										File.AppendAllLines("pageprofile.txt", list2);
									}
								}
								method_130(int_3, string_3 + $"Get Page Profile: {list2.Count}!");
								num3 = 1;
							}
						}
						else if (A1BCFE35.method_3("BackupGroup"))
						{
							method_130(int_3, string_3 + "Backup group...");
							List<string> list3 = chrome.method_56(C5034B95.smethod_0("configBackupGroup").method_3("ckbCheckNhomKiemDuyet"));
							File.WriteAllLines(C5034B95.smethod_0("configBackupGroup").BDB80B23("txtFolderPath") + "\\backupgroup\\" + text11 + ".txt", list3);
							method_130(int_3, string_3 + $"Backup group success: {list3.Count}!");
							method_134(int_3, "cGroup", list3.Count.ToString(), "groups");
							num3 = 1;
						}
						else if (A1BCFE35.method_3("OpenBrowser"))
						{
							AF328D25(int_3, string_3, chrome);
							method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p tha\u0300nh công!"));
							num3 = 1;
							if (A1BCFE35.method_3("TinhNangKhac"))
							{
								method_18(int_3, chrome, text11);
								method_55(int_3, string_3, chrome);
							}
						}
						else
						{
							if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbDisableChatSettings") || chrome.method_61() == 1)
							{
								chrome.A5326904();
							}
							if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbCapNhatThongTin") && C5034B95.smethod_0("configInteractGeneral").method_3("ckbCapNhatThongTinTruocKhiTuongTac"))
							{
								method_130(int_3, string_3 + Language.GetValue("Cập nhật thông tin..."));
								ACA57217(chrome, int_3, string_2, int_5);
							}
							if (A1BCFE35 != null && A1BCFE35.method_3("RunCustomScript"))
							{
								string customScriptId = KichBanThongKeDB.GetCustomScriptId(text11);
								if (!string.IsNullOrEmpty(customScriptId))
								{
									string_1 = customScriptId;
									string customScriptName = KichBanThongKeDB.GetCustomScriptName(text11);
									if (!string.IsNullOrEmpty(customScriptName))
									{
										method_130(int_3, string_3 + $"[Kịch bản: {customScriptName}] " + Language.GetValue("Bắt đầu tương tác..."));
									}
								}
							}
							DataTable dataTable = Class154.smethod_9(string_1);
							string text28 = "";
							string text29 = "";
							DataTable dataTable2 = new DataTable();
							string string_15 = Class154.smethod_3(string_1);
							GClass4 gClass2 = new GClass4(string_15, F79F9AB5: true);
							int num10 = gClass2.method_2("cbbCountAction");
							int num11 = gClass2.method_2("nudCountActionFrom");
							int num12 = gClass2.method_2("nudCountActionTo");
							bool flag8 = gClass2.method_3("ckbRandomAction");
							int num13 = dataTable.Rows.Count;
							if (num10 == 1 && num11 <= num12)
							{
								num13 = Base.rd.Next(num11, num12 + 1);
								if (num13 > dataTable.Rows.Count)
								{
									num13 = dataTable.Rows.Count;
								}
							}
							if (flag8)
							{
								dataTable = Commom.smethod_63(dataTable);
								dataTable = Commom.smethod_63(dataTable);
								dataTable = Commom.smethod_63(dataTable);
							}
							int num14 = 0;
							while (true)
							{
								if (num14 < num13)
								{
									if (Base.smethod_5())
									{
										method_130(int_3, string_3 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										break;
									}
									try
									{
										text29 = dataTable.Rows[num14]["TenHanhDong"].ToString();
										text28 = dataTable.Rows[num14]["Id_HanhDong"].ToString();
										method_130(int_3, string_3 + Language.GetValue("Đang") + " " + text29 + "...");
										dataTable2 = Class154.E6AD9687(text28);
										GClass4 gClass3 = new GClass4(dataTable2.Rows[0]["CauHinh"].ToString(), F79F9AB5: true);
										try
										{
											GClass4 gClass4 = new GClass4();
											string text30 = dataTable2.Rows[0]["TenTuongTac"].ToString();
											string text31 = text30;
											if (text31 == "HDDangBaiV2")
											{
												num2 = PostingV2AutomationHelper.ExecuteDangBaiV2(int_3, string_3, chrome, gClass3, text29, text28, this, dictionary_13, dictionary_14, dictionary_19, dictionary_20, C73602B4);
												goto end_IL_1d4b;
											}
											if (text31 == "HDTangTuongTac")
											{
												num2 = EF99TangTuongTac(int_3, string_3, chrome, gClass3, text29, text28);
												goto end_IL_1d4b;
											}
											num15 = AFAE75A0.smethod_0(text31);
											if (num15 <= 2117563667)
											{
												switch (num15)
												{
												default:
													goto end_IL_1d4b;
												case 111113161u:
													if (text31 == "HDDoiNgonNgu")
													{
														num2 = method_41(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 80860474u:
													if (text31 == "HDUnlockProfile")
													{
														num2 = D191792B(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 170588456u:
													if (text31 == "HDShareBai")
													{
														num2 = method_77(ref F21DDB, int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 167896116u:
													if (text31 == "HDTuongTacBaiVietTuKhoa")
													{
														num2 = F7166A93(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 152310871u:
													if (text31 == "HDUpCover")
													{
														num2 = D017409D(ref string_8, int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 275671526u:
													if (text31 == "HDReviewPage")
													{
														num2 = F31CEBAE(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 271171672u:
													if (text31 == "HDTruyCapWebsite")
													{
														num2 = method_16(int_3, string_3, chrome, gClass3.method_1("txtLinkWeb"), gClass3.method_2("nudCountLinkFrom"), gClass3.method_2("nudCountLinkTo"), gClass3.method_2("nudCountLinkClickFrom"), gClass3.method_2("nudCountLinkClickTo"), gClass3.method_2("nudCountTimeScrollFrom"), gClass3.method_2("nudCountTimeScrollTo"), gClass3.method_3("ckbLuot"), text29);
													}
													goto end_IL_1d4b;
												case 516966741u:
													if (text31 == "HDDangReel")
													{
														num2 = method_75(ref int_9, int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 327820411u:
													if (text31 == "HDBuffTinNhanProfile")
													{
														num2 = method_102(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 311671696u:
													if (text31 == "HDKetBanGoiY")
													{
														num2 = F098622C(int_3, string_3, chrome, gClass3, text29);
														text5 = ((num2 > 0) ? "Yes" : "No");
													}
													goto end_IL_1d4b;
												case 570065009u:
													if (text31 == "HDTuongTacReelNgauNhien")
													{
														num2 = method_111(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 532292684u:
													if (text31 == "HDBuffLikeComment")
													{
														num2 = method_93(ref int_8, ref int_7, int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 445566778u:
													if (text31 == "HDTangTuongTac")
													{
														num2 = EF99TangTuongTac(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 786238800u:
													if (text31 == "HDXemWatch")
													{
														num2 = BEAC0B29(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 614517095u:
													if (text31 == "HDReport")
													{
														num2 = method_101(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 582938346u:
													if (text31 == "HDXemStory")
													{
														num2 = A51D2294(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 894688135u:
													if (text31 == "HDTuongTacReelChiDinh")
													{
														num2 = method_112(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 852508141u:
													if (text31 == "HDKetBanTepUid")
													{
														num2 = D8B8D010(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 1411668073u:
													if (text31 == "HDChangeSoThich")
													{
														num2 = method_62(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1340375996u:
													if (text31 == "HDBatCheDoChuyenNghiep")
													{
														num2 = method_46(ref FE912FA, int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 935513960u:
													if (text31 == "HDMoiLikePage")
													{
														num2 = method_67(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1470935067u:
													if (text31 == "HDDangStatus")
													{
														num2 = method_91(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 1467610808u:
													if (text31 == "HDLinkToInstagram")
													{
														num2 = B48B150E(ref string_9, int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 1672329986u:
													if (text31 == "HDBaiVietNewsfeed2")
													{
														break;
													}
													goto end_IL_1d4b;
												case 1653385921u:
													if (text31 == "HDNghiGiaiLao")
													{
														num2 = method_78(int_3, string_3, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1591506910u:
													if (text31 == "HDTuongTacNhomv2")
													{
														num2 = CB1EB439(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1723758688u:
													if (text31 == "HDXoaBaiTuong")
													{
														num2 = method_69(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1697418988u:
													if (text31 == "HDTimKiemGoogle")
													{
														num2 = method_15(int_3, string_3, chrome, gClass3.method_1("txtTuKhoa"), gClass3.method_2("nudCountTuKhoaFrom"), gClass3.method_2("nudCountTuKhoaTo"), gClass3.method_2("nudCountPageFrom"), gClass3.method_2("nudCountPageTo"), gClass3.method_2("nudCountLinkClickFrom"), gClass3.method_2("nudCountLinkClickTo"), gClass3.method_2("nudCountTimeScrollFrom"), gClass3.method_2("nudCountTimeScrollTo"), text29);
													}
													goto end_IL_1d4b;
												case 1884305945u:
													if (text31 == "HDDocThongBao")
													{
														num2 = method_88(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1823818229u:
													if (text31 == "HDUpAvatar")
													{
														gClass4 = method_33(int_3, string_3, chrome, gClass3, text29, text28);
														if (gClass4.method_3("success"))
														{
															text6 = "Success";
														}
														else
														{
															text6 = "Fail";
															if (gClass4.BDB80B23("error") != "")
															{
																text6 = "Fail (" + gClass4.BDB80B23("error") + ")";
															}
														}
													}
													goto end_IL_1d4b;
												case 1742384383u:
													if (text31 == "HDChangeTenPhu")
													{
														num2 = method_61(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1952866892u:
													if (text31 == "HDKetBanTheoTuKhoa")
													{
														num2 = method_90(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 1906272025u:
													if (text31 == "HDKetBanVoiBanBeCuaUid")
													{
														num2 = method_106(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 2004466602u:
													if (text31 == "HDDoiTen")
													{
														num2 = method_103(ref string_7, int_3, string_3, chrome, gClass3, text29, text28);
														if (string_7 == "Success")
														{
															string string_16 = CommonRequest.D6A50126(chrome.FB94939A(), chrome.A3A32284, chrome.Int32_1);
															method_134(int_3, "cName", string_16, "name", F713D5BE: false);
														}
													}
													goto end_IL_1d4b;
												case 1999692336u:
													if (text31 == "HDVerify")
													{
														num2 = method_54(int_3, string_3, chrome, gClass3);
													}
													goto end_IL_1d4b;
												case 1984335833u:
													if (text31 == "HDBaiVietBanBe")
													{
														num2 = method_96(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 2065195933u:
													if (text31 == "HDBuffFollowLikePage")
													{
														num2 = method_95(ref F00C45B2, int_3, string_3, chrome, gClass3, text29, 1);
													}
													goto end_IL_1d4b;
												case 2030328732u:
													if (text31 == "HDOnOff2FA")
													{
														num2 = method_34(ref B588C8AD, int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 2117563667u:
													if (text31 == "HDKhangSpam")
													{
														num2 = method_68(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												case 2081285240u:
													if (text31 == "HDChocBanBe")
													{
														num2 = method_104(int_3, string_3, chrome, gClass3, text29);
													}
													goto end_IL_1d4b;
												case 2079252553u:
													if (text31 == "HDPhanHoiBinhLuan")
													{
														num2 = method_66(int_3, string_3, chrome, gClass3, text29, text28);
													}
													goto end_IL_1d4b;
												}
												goto IL_2ef4;
											}
											if (num15 <= 3375859832u)
											{
												switch (num15)
												{
												case 2255824322u:
													if (text31 == "HDXoaNhatKyHoatDong")
													{
														num2 = E2053BA2(int_3, string_3, chrome, gClass3);
													}
													break;
												case 2230339588u:
													if (text31 == "HDBuffFollowCaNhan")
													{
														num2 = method_95(ref F00C45B, int_3, string_3, chrome, gClass3, text29, 0);
													}
													break;
												case 2421286761u:
													if (text31 == "HDBaiVietNhom")
													{
														num2 = FC9FC103(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2416405417u:
													if (text31 == "HDHuyLikePage")
													{
														num2 = method_65(int_3, string_3, chrome, gClass3.method_2("nudSoLuongFrom"), gClass3.method_2("nudSoLuongTo"), gClass3.method_2("nudDelayFrom"), gClass3.method_2("nudDelayTo"), text29);
													}
													break;
												case 2277183375u:
													if (text31 == "HDRoiNhom")
													{
														num2 = method_81(int_3, string_3, chrome, text19, gClass3.method_2("nudSoLuongFrom"), gClass3.method_2("nudSoLuongTo"), gClass3.method_2("nudDelayFrom"), gClass3.method_2("nudDelayTo"), gClass3.method_2("typeRoiNhom"), gClass3.method_3("ckbDieuKienThanhVien"), gClass3.method_2("nudThanhVienToiDa"), gClass3.method_3("ckbDieuKienTuKhoa"), gClass3.method_1("txtTuKhoa"), gClass3.method_1("txtIDNhomGiuLai"), gClass3.method_3("ckbDieuKienID"), gClass3.method_1("txtIdNhomRoi"), string_2, int_5, text29);
													}
													break;
												case 2553440797u:
													if (text31 == "HDCapNhatThongTin")
													{
														num2 = method_32(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2540878680u:
													if (text31 == "HDThamGiaNhomTuKhoa")
													{
														num2 = method_83(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2703861858u:
													if (text31 == "HDChucMungSinhNhat")
													{
														num2 = method_105(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2680847194u:
													if (text31 == "HDScriptGemLogin")
													{
														num2 = EDA9DC8F(int_3, string_3, chrome, gClass3);
													}
													break;
												case 2653710823u:
													if (text31 == "HDSharePage")
													{
														num2 = method_94(ref string_11, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2837141903u:
													if (text31 == "HDBaiVietFanpage")
													{
														num2 = method_97(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2821037716u:
													if (text31 == "HDHuyKetBan")
													{
														num2 = method_84(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2924758840u:
													if (text31 == "HDMoiBanBeVaoNhom")
													{
														num2 = method_86(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2922412940u:
													if (text31 == "HDTaoPage")
													{
														num2 = A633080C(ref ACB20DA, int_3, string_3, chrome, gClass3, text29, text28);
													}
													break;
												case 2837258301u:
													if (text31 == "HDKichHoatPageVhh")
													{
														num2 = method_45(ref EE152CA, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 3099572506u:
													if (text31 == "HDDangXuatThietBiCu")
													{
														num2 = method_43(ref string_4, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 2944435598u:
													if (text31 == "HDThamGiaNhomUid")
													{
														num2 = method_107(int_3, string_3, chrome, gClass3, text29, text28);
													}
													break;
												case 3375859832u:
													if (text31 == "HDDanhGiaPage")
													{
														num2 = method_22(int_3, string_3, chrome, gClass3, text28, text29);
													}
													break;
												case 3255732838u:
													if (text31 == "HDDoiMatKhau")
													{
														num2 = method_40(ref D72C270F, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 3169819074u:
													if (text31 == "HDCongKhaiBaiVietGanThe")
													{
														num2 = DB92349A(int_3, string_3, chrome, gClass3, text29, text28);
													}
													break;
												}
											}
											else if (num15 <= 3850864715u)
											{
												if (num15 <= 3656368709u)
												{
													switch (num15)
													{
													case 3550581772u:
														if (text31 == "HDPhanHoiTinNhan")
														{
															num2 = method_87(int_3, string_3, chrome, gClass3.method_2("nudSoLuongFrom"), gClass3.method_2("nudSoLuongTo"), gClass3.method_2("nudDelayFrom"), gClass3.method_2("nudDelayTo"), gClass3.method_1("txtTinNhan"), text29);
														}
														break;
													case 3427768725u:
														if (text31 == "HDBaiVietTrenTuong")
														{
															num2 = method_92(int_3, string_3, chrome, gClass3, text29);
														}
														break;
													case 3656368709u:
														if (text31 == "HDUptopBaiViet")
														{
															num2 = E41ED239(int_3, string_3, chrome, gClass3, text29, text28);
														}
														break;
													case 3609367991u:
														if (text31 == "HDAddMail")
														{
															num2 = method_35(ref string_5, ref string_6, int_3, string_3, chrome, gClass3, text29, text28);
														}
														break;
													case 3598280146u:
														if (text31 == "HDKetBanNewfeed")
														{
															num2 = FF885FA2(int_3, string_3, chrome, gClass3.method_2("nudSoLuongFrom"), gClass3.method_2("nudSoLuongTo"), gClass3.method_2("nudDelayFrom"), gClass3.method_2("nudDelayTo"), text29);
														}
														break;
													}
												}
												else if (num15 <= 3677432718u)
												{
													switch (num15)
													{
													case 3677432718u:
														if (text31 == "HDDangStory")
														{
															num2 = method_89(int_3, string_3, chrome, gClass3, text29);
														}
														break;
													case 3671364376u:
														if (text31 == "HDThamGiaNhomGoiY")
														{
															num2 = method_70(int_3, string_3, chrome, gClass3, text29);
														}
														break;
													}
												}
												else
												{
													if (num15 != 3732058847u)
													{
														switch (num15)
														{
														default:
															goto end_IL_1d4b;
														case 3850864715u:
															if (text31 == "HDDangBai")
															{
																num2 = method_71(int_3, string_3, chrome, gClass3, text29, text28);
															}
															goto end_IL_1d4b;
														case 3742679556u:
															if (text31 == "HDBaiVietNewsfeed" || text31 == "HDBaiVietNewsfeed3")
															{
																break;
															}
															goto end_IL_1d4b;
														}
														goto IL_2ef4;
													}
													if (text31 == "HDDangStatusV2")
													{
														num2 = BF2C451F(int_3, string_3, chrome, gClass3.method_2("nudSoLuongFrom", 1), gClass3.method_2("nudSoLuongTo", 1), gClass3.method_2("nudKhoangCachFrom"), gClass3.method_2("nudKhoangCachTo"), gClass3.method_2("nudWaitFrom"), gClass3.method_2("nudWaitTo"), gClass3.method_3("ckbVanBan"), gClass3.method_3("ckbAnh"), gClass3.BDB80B23("txtPathAnh"), gClass3.method_2("nudSoLuongAnhFrom"), gClass3.method_2("nudSoLuongAnhTo"), gClass3.method_3("ckbDangAnhTheoThuTu"), gClass3.method_3("ckbTag"), gClass3.method_2("nudUidFrom"), gClass3.method_2("nudUidTo"), gClass3.method_3("ckbOnlyTagVNName"), text28, text29, ref int_6, gClass3);
													}
												}
											}
											else
											{
												switch (num15)
												{
												case 3917587807u:
													if (text31 == "HDHuyLoiMoiKetBan")
													{
														num2 = method_85(int_3, string_3, chrome, gClass3.method_2("nudSoLuongFrom"), gClass3.method_2("nudSoLuongTo"), gClass3.method_2("nudDelayFrom"), gClass3.method_2("nudDelayTo"), text29);
													}
													break;
												case 3877387086u:
													if (text31 == "HDTuongTacLivestream")
													{
														num2 = method_47(int_3, string_3, chrome, gClass3, text29, text28);
													}
													break;
												case 4062736188u:
													if (text31 == "HDXoaSdt")
													{
														num2 = method_42(ref AD3ACABD, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4054725761u:
													if (text31 == "HDXemStoryChiDinh")
													{
														num2 = EE18B014(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 3921961843u:
													if (text31 == "HDXoaTinNhan")
													{
														num2 = E385342B(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4167715081u:
													if (text31 == "HDHuyLienKetInstagram")
													{
														num2 = B0A82114(ref string_10, int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4095834327u:
													if (text31 == "HDXacNhanKetBan")
													{
														num2 = D7BE8001(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4226158249u:
													if (text31 == "HDKetBanThanhVienNhom")
													{
														num2 = BB8424AC(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4198930712u:
													if (text31 == "HDXoaThietBiTinCay")
													{
														num2 = F59C7BBF(int_3, string_3, chrome, gClass3, text29);
													}
													break;
												case 4189681400u:
													if (text31 == "HDSpamBaiViet")
													{
														num2 = method_98(int_3, string_3, chrome, gClass3, text29, text28);
													}
													break;
												}
											}
											goto end_IL_1d4b;
											IL_2ef4:
											num2 = B8B090B3(int_3, string_3, chrome, gClass3, text29);
											end_IL_1d4b:;
										}
										catch (Exception exception_)
										{
											Commom.smethod_58(exception_, dataTable2.Rows[0]["TenTuongTac"].ToString());
										}
									}
									catch (Exception exception_2)
									{
										Commom.smethod_58(exception_2, "Tuong tac theo kich ban");
									}
									if (num2 != -4 && !chrome.EE37E6A7)
									{
										num2 = chrome.method_125(bool_9: true);
										switch (num2)
										{
										case -3:
											chrome.CA294803 = FE33ED1C.CDBBFE27;
											num3 = 1;
											goto end_IL_03b7;
										case -2:
											chrome.CA294803 = FE33ED1C.const_1;
											num3 = 1;
											goto end_IL_03b7;
										case -1:
											chrome.CA294803 = FE33ED1C.C2301331;
											E589F93F(int_3, Language.GetValue("Checkpoint"));
											num3 = 1;
											goto end_IL_03b7;
										case 2:
											num3 = 0;
											goto end_IL_03b7;
										}
										num14++;
										continue;
									}
									chrome.EE37E6A7 = true;
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckCreateProfile"))
								{
									method_130(int_3, string_3 + Language.GetValue("Check create profile..."));
									text2 = chrome.method_66("CanCreateSubProfile").ToLower();
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbAllowFollow"))
								{
									method_130(int_3, string_3 + Language.GetValue("Cho phe\u0301p ngươ\u0300i kha\u0301c follow..."));
									chrome.F91F5893();
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbCapNhatThongTin"))
								{
									method_130(int_3, string_3 + Language.GetValue("Cập nhật thông tin..."));
									ACA57217(chrome, int_3, string_2, int_5);
								}
								AF328D25(int_3, string_3, chrome);
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbWallPosts"))
								{
									method_130(int_3, string_3 + Language.GetValue("Check Wall posts..."));
									text8 = chrome.BD9F631D(C5034B95.smethod_0("configInteractGeneral"));
									method_134(int_3, "cWallPosts", text8, "wallPosts");
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbPublicPost"))
								{
									method_130(int_3, string_3 + Language.GetValue("Public posts..."));
									_ = chrome.method_66("PublicPost").ToLower() == "true";
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbPrivateInfo"))
								{
									method_130(int_3, string_3 + "Private Info...");
									E431F983(chrome);
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckPasswordCorrect"))
								{
									method_130(int_3, string_3 + "Check password...");
									string text32 = chrome.RunCodeChrome("ReauthPassword('" + chrome.C234EEAA + "')");
									text9 = ((!(text32 == "true")) ? ((text32 == "") ? "false" : text32) : "true");
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbDoiNgonNgu"))
								{
									string string_17 = C5034B95.smethod_0("configInteractGeneral").BDB80B23("cbbLanguage").Split('|')[0];
									method_130(int_3, string_3 + Language.GetValue("Đô\u0309i ngôn ngư\u0303..."));
									chrome.method_49(string_17);
								}
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckMetaVerified"))
								{
									method_130(int_3, string_3 + "Check Meta Verified...");
									text10 = chrome.method_152();
								}
								if (!chrome.PreserveSession && C5034B95.smethod_0("configInteractGeneral").method_3("ckbLogOut"))
								{
									method_130(int_3, string_3 + Language.GetValue("Đăng xuất..."));
									method_80(chrome);
								}
								break;
							}
						}
					}
					goto end_IL_03b7;
					IL_133b:
					string text33;
					if (text33.Contains("captcha"))
					{
						method_130(int_3, string_3 + "Login fail (" + text33 + ")!");
					}
					else
					{
						if (text33.Contains("Invalid username or password") || text33.Contains("Your password was changed") || text33.Contains("Tên người dùng hoặc mật khẩu không hợp lệ"))
						{
							E589F93F(int_3, "Changed pass");
						}
						method_130(int_3, string_3 + text33);
					}
					goto IL_13d2;
					IL_0e29:
					if (flag)
					{
						goto IL_13d2;
					}
					int num16 = C5034B95.smethod_0("configInteractGeneral").method_2("typeLogin");
					switch (num16)
					{
					case 1:
						method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng email|pass..."));
						goto default;
					case 2:
					case 3:
						method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng cookie..."));
						goto default;
					case 0:
						method_130(int_3, string_3 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng uid|pass..."));
						goto default;
					default:
					{
						chrome.OnStatusUpdate = (msg) =>
						{
							try
							{
								method_130(int_3, string_3 + msg);
							}
							catch { }
						};
						text33 = chrome.method_127(num16, string_13);
						int num17;
						if (num16 != 3)
						{
							num17 = 0;
						}
						else
						{
							List<string> list = new List<string>();
							list.Add("1");
							list.Add("2");
							list.Add("8");
							num17 = ((!list.Contains(text33)) ? 1 : 0);
						}
						if (num17 == 0)
						{
							break;
						}
						num16 = 0;
						int num18 = 0;
						int num19 = 0;
						goto case 0;
					}
					}
					string text34 = text33;
					string text35 = text34;
					num15 = AFAE75A0.smethod_0(text35);
					if (num15 > 890022063)
					{
						if (num15 <= 1007465396)
						{
							if (num15 != 906799682)
							{
								if (num15 != 923577301)
								{
									if (num15 != 1007465396 || !(text35 == "9"))
									{
										goto IL_133b;
									}
									method_130(int_3, string_3 + "Facebook block login!");
								}
								else
								{
									if (!(text35 == "2"))
									{
										goto IL_133b;
									}
									chrome.CA294803 = FE33ED1C.C2301331;
									if (flag2 = !Commom.IsUid(text11))
									{
										text = text11;
										text11 = chrome.FB94939A();
										CommonSQL.B8A0E617(text12, "uid", text11);
										B183E907(int_3, "cUid", text11);
									}
									if (A1BCFE35.method_3("Unlock956") || A1BCFE35.method_3("Unlock282"))
									{
										flag6 = true;
										goto IL_143d;
									}
									if (method_56(chrome, int_3, string_3))
									{
										flag = true;
										chrome.bool_8 = true;
									}
								}
							}
							else
							{
								if (!(text35 == "3"))
								{
									goto IL_133b;
								}
								if (num16 != 2)
								{
									method_130(int_3, string_3 + Language.GetValue("Không có 2fa!"));
								}
								else
								{
									flag = true;
									chrome.bool_8 = true;
								}
							}
						}
						else if (num15 <= 2166136261u)
						{
							if (num15 != 1024243015)
							{
								if (num15 != 2166136261u || text35 == null || text35.Length != 0)
								{
									goto IL_133b;
								}
								if (chrome.CD930D04())
								{
									chrome.CA294803 = FE33ED1C.const_1;
								}
							}
							else
							{
								if (!(text35 == "8"))
								{
									goto IL_133b;
								}
								E589F93F(int_3, "Live");
								C412B9A5(int_3, 2);
								if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
								{
									text19 = chrome.method_40();
									if (text19 != "")
									{
										method_134(int_3, "cCookies", text19, "cookie1");
									}
								}
								method_130(int_3, string_3 + "Account Novery!");
							}
						}
						else if (num15 != 2364708844u)
						{
							if (num15 != 2517938561u || !(text35 == "vhh"))
							{
								goto IL_133b;
							}
							method_130(int_3, string_3 + "Vô hiệu hóa!");
							E589F93F(int_3, "Checkpoint: vhh");
						}
						else
						{
							if (!(text35 == "21"))
							{
								goto IL_133b;
							}
							method_130(int_3, string_3 + "Checkpoint: login - block");
							E589F93F(int_3, "Checkpoint: login - block");
						}
						goto IL_13d2;
					}
					if (num15 > 806133968)
					{
						if (num15 <= 856466825)
						{
							if (num15 != 822911587)
							{
								if (num15 != 856466825 || !(text35 == "6"))
								{
									goto IL_133b;
								}
								method_130(int_3, string_3 + Language.GetValue("Mã 2fa không đúng!"));
							}
							else
							{
								if (!(text35 == "4"))
								{
									goto IL_133b;
								}
								method_130(int_3, string_3 + Language.GetValue("Tài khoản không đúng!"));
								E589F93F(int_3, "Changed pass");
							}
						}
						else if (num15 != 873244444)
						{
							if (num15 != 890022063 || !(text35 == "0"))
							{
								goto IL_133b;
							}
							method_130(int_3, string_3 + Language.GetValue("Đăng nhập thất bại!"));
						}
						else
						{
							if (!(text35 == "1"))
							{
								goto IL_133b;
							}
							flag = true;
							chrome.bool_8 = true;
						}
						goto IL_13d2;
					}
					if (num15 == 365759422)
					{
						if (!(text35 == "-2"))
						{
							goto IL_133b;
						}
						chrome.CA294803 = FE33ED1C.const_1;
						goto IL_13d2;
					}
					if (num15 != 382537041)
					{
						if (num15 != 806133968 || !(text35 == "5"))
						{
							goto IL_133b;
						}
						method_130(int_3, string_3 + Language.GetValue("Mật khẩu không đúng!"));
						E589F93F(int_3, "Changed pass");
						goto IL_13d2;
					}
					if (!(text35 == "-3"))
					{
						goto IL_133b;
					}
					chrome.CA294803 = FE33ED1C.CDBBFE27;
					goto end_IL_03b7;
					IL_0cdc:
					flag6 = false;
					if (!(chrome.String_1.Trim() != ""))
					{
						goto IL_0e29;
					}
					chrome.EC9B94B0();
					num2 = chrome.FE31BD92(string_13);
					switch (num2)
					{
					case -3:
						chrome.CA294803 = FE33ED1C.CDBBFE27;
						goto end_IL_03b7;
					case -2:
						chrome.CA294803 = FE33ED1C.const_1;
						goto end_IL_03b7;
					case 1:
						flag = true;
						chrome.bool_8 = true;
						goto IL_0e29;
					case 2:
						break;
					default:
						goto IL_0e29;
					}
					chrome.CA294803 = FE33ED1C.C2301331;
					if (flag2 = !Commom.IsUid(text11))
					{
						text = text11;
						text11 = chrome.FB94939A();
						method_134(int_3, "cUid", text11, "uid");
					}
					if (A1BCFE35.method_3("Unlock956") || A1BCFE35.method_3("Unlock282"))
					{
						flag6 = true;
						goto IL_143d;
					}
					if (method_56(chrome, int_3, string_3))
					{
						flag = true;
						chrome.bool_8 = true;
						goto IL_0e29;
					}
					if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie") || text19 == "")
					{
						text19 = chrome.method_40();
						method_134(int_3, "cCookies", text19, "cookie1", F713D5BE: false);
					}
					num3 = 1;
					end_IL_03b7:;
				}
				catch (Exception exception_3)
				{
					method_130(int_3, string_3 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
					num3 = 1;
					Commom.smethod_57(chrome, exception_3, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				}
			}
			if (chrome != null && !chrome.PreserveSession && chrome.CA294803 == FE33ED1C.C2301331 && C5034B95.smethod_0("configInteractGeneral").method_3("ckbLogOut"))
			{
				method_130(int_3, string_3 + Language.GetValue("Đăng xuất..."));
				string input = chrome.C604C58C("https://mbasic.facebook.com/help/");
				string value = Regex.Match(input, "href=\"(/logout\\.php.*?)\"").Groups[1].Value;
				chrome.C604C58C("https://mbasic.facebook.com" + value.Replace("&amp;", "&"));
				chrome.method_12("https://mbasic.facebook.com");
			}
			string text36 = "";
			if (num3 == 1)
			{
				if (chrome != null)
				{
					if (chrome.CA294803 == FE33ED1C.C2301331)
					{
						method_79(chrome, text11, 0);
					}
					switch (chrome.CA294803)
					{
					default:
						text36 = method_135(int_3);
						break;
					case FE33ED1C.const_1:
					case FE33ED1C.C2301331:
					case FE33ED1C.CDBBFE27:
						C412B9A5(int_3, 1);
						text36 = GClass16.F5A2C400(chrome.CA294803);
						text19 = chrome.method_40();
						break;
					}
				}
				else
				{
					text36 = method_135(int_3);
				}
			}
			else if (Commom.IsUid(text11) && CommonRequest.BC9215A7(text11).StartsWith("0|"))
			{
				E589F93F(int_3, "Die");
				text36 = Language.GetValue("Tài khoản Die!");
			}
			else
			{
				chrome.CA294803 = FE33ED1C.AC3A1601;
				chrome.A7B3F62B(EE3B6F92: true);
				switch (chrome.CA294803)
				{
				case FE33ED1C.const_1:
				case FE33ED1C.C2301331:
				case FE33ED1C.CDBBFE27:
					C412B9A5(int_3, 1);
					text36 = GClass16.F5A2C400(chrome.CA294803);
					text19 = chrome.method_40();
					break;
				}
			}
			chrome3.A4B307B3();
			if (A1BCFE35.method_3("OpenBrowser"))
			{
				if (!flag && C5034B95.smethod_0("configOpenBrowser").method_3("isAutoCloseChromeLoginFail"))
				{
					method_55(int_3, string_3, chrome);
				}
				else
				{
					if (C5034B95.smethod_0("configOpenBrowser").method_3("ckbAutoOpenLink"))
					{
						chrome.method_12(C5034B95.smethod_0("configOpenBrowser").BDB80B23("txtLink"));
					}
					if (C5034B95.smethod_0("configOpenBrowser").method_3("ckbLoginHotmail") && (text13.Contains("hotmail") || text13.Contains("outlook")))
					{
						chrome.method_42("https://outlook.live.com");
						string json2 = chrome.method_94(text13, text14, text16, a9304E);
						JObject jObject = JObject.Parse(json2);
						if (!Convert.ToBoolean(jObject["success"]))
						{
							text36 = string_3 + jObject["error"]!.ToString() + "!";
						}
						else
						{
							if (jObject["mailRecover"]!.ToString() != "" && jObject["mailRecover"]!.ToString() != text16)
							{
								text16 = jObject["mailRecover"]!.ToString();
								a9304E = jObject["passMailRecover"]!.ToString();
								method_134(int_3, "cMailRecovery", text16, "mailrecovery");
								method_134(int_3, "cPassMailRecovery", a9304E, "passmailrecovery");
							}
							if (text14 != jObject["passmail"]!.ToString())
							{
								text14 = jObject["passmail"]!.ToString();
								method_134(int_3, "cPassMail", text14, "passmail");
							}
							text36 = string_3 + "Login hotmail success!";
						}
					}
				}
			}
			else
			{
				try
				{
					if (chrome != null)
					{
						if (!chrome.CD930D04() && !Base.smethod_5() && C5034B95.smethod_0("configGeneral").method_3("ckbDelayCloseChrome"))
						{
							method_131(int_3, string_3 + Language.GetValue("Đóng tri\u0300nh duyê\u0323t sau {time}s..."), C5034B95.smethod_0("configGeneral").method_2("nudDelayCloseChromeFrom", 1), C5034B95.smethod_0("configGeneral").method_2("nudDelayCloseChromeTo", 1));
						}
						method_55(int_3, string_3, chrome);
					}
				}
				catch
				{
				}
			}
			string text37 = "";
			if (text4 != "")
			{
				text37 = text37 + "- " + text4;
			}
			if (text5 != "")
			{
				text37 = text37 + "- " + Language.GetValue("Gợi ý Kb: ") + text5;
			}
			if (AD3ACABD != "")
			{
				text37 = text37 + "- " + Language.GetValue("Xóa Sđt: ") + AD3ACABD;
			}
			if (string_4 != "")
			{
				text37 = text37 + "- " + Language.GetValue("Đăng xuâ\u0301t thiê\u0301t bi\u0323 cu\u0303: ") + string_4;
			}
			if (string_5 != "")
			{
				text37 = text37 + "- Add mail: " + string_5;
			}
			if (string_6 != "")
			{
				text37 = text37 + "- Xóa mail: " + string_6;
			}
			if (D72C270F != "")
			{
				text37 = text37 + "- Đổi pass: " + D72C270F;
			}
			if (string_7 != "")
			{
				text37 = text37 + "- Đổi tên: " + string_7;
			}
			if (text6 != "")
			{
				text37 = text37 + "- Up avatar: " + text6;
			}
			if (string_8 != "")
			{
				text37 = text37 + "- Up cover: " + string_8;
			}
			if (B588C8AD != "")
			{
				text37 = text37 + "- 2FA: " + B588C8AD;
			}
			if (ACB20DA != "")
			{
				text37 = text37 + "- Tạo page: " + ACB20DA;
			}
			if (string_11 != "")
			{
				text37 = text37 + "- Share page: " + string_11;
			}
			if (chrome?.EE37E6A7 ?? false)
			{
				text37 += "- Fb Block";
				if (F6061E95(int_3, "cFbBlock") == "")
				{
					method_134(int_3, "cFbBlock", "Yes", "fbBlock");
				}
			}
			if (F21DDB > -1)
			{
				text37 = text37 + "- Share: " + F21DDB;
			}
			if (num4 > -1)
			{
				text37 = text37 + "- Job success: " + num4;
				method_132(int_3, num4);
			}
			if (text7 != "")
			{
				text37 = text37 + " (" + text7 + ")";
			}
			if (Base.bool_0)
			{
				if (int_8 > -1)
				{
					text37 = text37 + "- Comment: " + int_8;
				}
				if (int_7 > -1)
				{
					text37 = text37 + "- Share: " + int_7;
				}
			}
			if (EE152CA > -1)
			{
				text37 = text37 + "- Active page: " + EE152CA;
			}
			if (int_9 > -1)
			{
				text37 = text37 + "- Reel: " + int_9;
			}
			if (string_10 != "")
			{
				text37 = text37 + "- Unlink IG: " + string_10;
			}
			if (string_9 != "")
			{
				text37 = text37 + "- Liên kết IG: " + string_9;
			}
			if (text8 != "")
			{
				text37 = text37 + "- Wall posts: " + text8;
			}
			if (FE912FA != "")
			{
				text37 = text37 + "- ProfessionalMode: " + FE912FA;
			}
			if (text2 != "")
			{
				text37 = text37 + "- Create profile: " + text2;
			}
			if (text9 != "")
			{
				text37 = text37 + "- Check password: " + text9;
			}
			if (text10 != "")
			{
				text37 = text37 + "- Meta verified: " + text10;
			}
			string text38 = text36;
			string text39 = text38;
			if (!(text39 == ""))
			{
				method_130(int_3, string_3 + text36);
			}
			else
			{
				string text40 = "";
				if (F00C45B2 > -1)
				{
					text40 = text40 + " -Like page: " + F00C45B2;
				}
				if (F00C45B > -1)
				{
					text40 = text40 + " -Follow: " + F00C45B;
				}
				method_130(int_3, string_3 + Language.GetValue("Đã tương tác xong!") + (flag3 ? "- Facebook spam!" : "") + text40 + ((text3 != "") ? ("- " + text3) : "") + text37 + " [" + gClass.method_0() + "(s)]");
				method_134(int_3, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "interactEnd");
				if (BA8BE803(int_3) != "Changed pass")
				{
					E589F93F(int_3, "Live");
				}
			}
			if (Base.smethod_5())
			{
				method_130(int_3, string_3 + Language.GetValue("Đã dừng!"));
			}
			if (flag2 && Directory.Exists(C5034B95.smethod_2() + "\\" + text) && text != "")
			{
				string text41 = C5034B95.smethod_2() + "\\" + text;
				string text42 = C5034B95.smethod_2() + "\\" + text11;
				if (!Commom.D182708B(text41, text42) && Commom.smethod_64(text41, text42))
				{
					Commom.DeleteFolder(text41);
				}
			}
			method_26(xproxyproxy_, shopLike_, minProxyVN_, obcProxy_);
		}
		catch (Exception ex2)
		{
			if (ex2.ToString().Contains("Thread was being aborted."))
			{
				try
				{
					chrome3.A4B307B3();
					method_55(int_3, string_3, chrome);
					method_130(int_3, string_3 + Language.GetValue("Đã tương tác xong!") + " [" + gClass.method_0() + "(s)]");
					B183E907(int_3, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
					CommonSQL.B8A0E617(text12, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
					method_26(xproxyproxy_, shopLike_, minProxyVN_, obcProxy_);
				}
				catch (Exception)
				{
				}
			}
			else
			{
				try
				{
					Commom.smethod_57(chrome, ex2, "RunAccountThread");
					method_130(int_3, string_3 + Language.GetValue("Lỗi: ") + ex2.Message);
					try
					{
						if (chrome3 != null)
						{
							chrome3.A4B307B3();
						}
						method_55(int_3, string_3, chrome);
					}
					catch {}
					method_26(xproxyproxy_, shopLike_, minProxyVN_, obcProxy_);
				}
				catch
				{
				}
			}
		}
	}

	private void method_18(int FC3E7B29, Chrome chrome_0, string string_1)
	{
		GClass4 gClass = C5034B95.smethod_0(string_1);
		if (gClass.method_3("ckbCrawlPostGroup"))
		{
			method_21(FC3E7B29, chrome_0, gClass);
		}
		if (gClass.method_3("ckbReplyComment"))
		{
			method_20(FC3E7B29, chrome_0, gClass);
		}
	}

	private bool method_19(string F98E7F25, string string_1, string string_2)
	{
		try
		{
			string dD2AC0B = "https://auto.otpgmail.com/api/posts/import";
			JObject jObject = new JObject();
			jObject["link"] = (JToken)string_1;
			jObject["platform_id"] = (JToken)1;
			jObject["campaign_id"] = (JToken)1;
			jObject["data"] = (JToken)F98E7F25;
			jObject["content"] = (JToken)string_2;
			jObject["status"] = (JToken)"pending";
			string string_3 = jObject.ToString();
			GClass0 gClass = new GClass0();
			string json = gClass.method_1(dD2AC0B, string_3, "application/json");
			JObject jObject2 = JObject.Parse(json);
			return Convert.ToBoolean(jObject2["success"]);
		}
		catch (Exception)
		{
		}
		return false;
	}

	public void method_20(int DB973F2B, Chrome chrome_0, GClass4 C8BD8C0D)
	{
		int num = chrome_0.method_50(C8BD8C0D.method_2("nudSoLuongReplyFrom"), C8BD8C0D.method_2("nudSoLuongReplyTo"));
		int int_ = C8BD8C0D.method_2("nudDelayReplyFrom");
		int int_2 = C8BD8C0D.method_2("nudDelayReplyTo");
		bool flag = C8BD8C0D.method_3("ckbContent");
		bool flag2 = C8BD8C0D.method_3("ckbImage");
		string text = C8BD8C0D.BDB80B23("txtIdNhom");
		List<string> list_ = C8BD8C0D.method_1("txtContent");
		List<string> list_2 = Commom.smethod_76(C8BD8C0D.BDB80B23("txtPathImage"));
		chrome_0.method_12("https://www.facebook.com/" + text);
		chrome_0.F8091028(2.0);
		int num2 = 0;
		int num3 = 0;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int tickCount = Environment.TickCount;
		int num4 = 60;
		method_130(DB973F2B, $"Reply Comment Bài viết: {text} ({1}/{num}) ...");
		while (!chrome_0.E184CD03() && !chrome_0.CD930D04() && Environment.TickCount - tickCount <= num4 * 1000)
		{
			string text2 = chrome_0.method_15(0.0, new List<string> { "(//*[@aria-label[contains(., \"Comment by\")]])" });
			string text3 = text2;
			string text4 = text3;
			if (!(text4 == "(//*[@aria-label[contains(., \"Comment by\")]])"))
			{
				continue;
			}
			num2++;
			if (num2 > chrome_0.method_30(text2))
			{
				chrome_0.method_35(text2 + "[last()]");
				chrome_0.F8091028(5.0);
				if (num2 > chrome_0.method_30(text2))
				{
					break;
				}
			}
			string text5 = text2 + $"[{num2}]//*[@href[contains(., \"post\")]]";
			chrome_0.method_20(text5, 2);
			string input = chrome_0.B9BE8807(text5, "href");
			string value = Regex.Match(input, "comment_id=(\\d+)").Groups[1].Value;
			if (value == "")
			{
				break;
			}
			if (chrome_0.D7A424AE("[aria-label*=\"review\" i] [aria-label*=\"Close\" i]"))
			{
				chrome_0.method_18("[aria-label*=\"review\" i] [aria-label*=\"Close\" i]");
				chrome_0.F8091028(2.0);
			}
			string e28DC = "";
			string text6 = "";
			if (flag)
			{
				if (list2.Count == 0)
				{
					list2 = C499BE3B(list_);
				}
				int index = Base.rd.Next(0, list2.Count);
				e28DC = list2[index];
				list2.RemoveAt(index);
				e28DC = Commom.smethod_31(e28DC);
				string newValue = CommonChrome.smethod_1(chrome_0);
				e28DC = e28DC.Replace("[u]", newValue);
			}
			if (flag2)
			{
				if (list.Count == 0)
				{
					list = C499BE3B(list_2);
				}
				text6 = list[Base.rd.Next(0, list.Count)];
				list.Remove(text6);
			}
			chrome_0.method_114(value, "", e28DC, text6);
			if (chrome_0.D7A424AE("[aria-label*=\"review\" i] [aria-label*=\"Close\" i]"))
			{
				chrome_0.method_18("[aria-label*=\"review\" i] [aria-label*=\"Close\" i]");
				chrome_0.F8091028(2.0);
			}
			method_131(DB973F2B, $"Reply Comment Bài viết: {text} ({num3 + 1}/{num}): Delay {{time}}s...", int_, int_2);
			num3++;
			if (num3 < num)
			{
				method_130(DB973F2B, $"Reply Comment Bài viết: {text} ({num3 + 1}/{num}) ...");
				tickCount = Environment.TickCount;
				continue;
			}
			break;
		}
	}

	public void method_21(int A3B0678D, Chrome C6095C13, GClass4 gclass4_0)
	{
		List<string> list = gclass4_0.method_1("txtGroupId");
		int num = gclass4_0.method_2("nudCountPostTurn", 10);
		int int_ = gclass4_0.method_2("nudDelayFrom", 3);
		int int_2 = gclass4_0.method_2("nudDelayTo", 5);
		int int_3 = gclass4_0.method_2("nudDelayTurn", 60);
		while (!C6095C13.E184CD03() && !C6095C13.CD930D04())
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (C6095C13.E184CD03())
				{
					break;
				}
				if (C6095C13.CD930D04())
				{
					break;
				}
				string text = list[i];
				string text2 = Commom.smethod_95() + "\\" + text + ".txt";
				if (!File.Exists(text2))
				{
					Commom.EF994A31(text2);
				}
				List<string> list2 = File.ReadAllText(text2).Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
				string text3 = text;
				if (!text3.StartsWith("http"))
				{
					text3 = "https://www.facebook.com/groups/" + text3 + "/?sorting_setting=CHRONOLOGICAL";
				}
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					C6095C13.method_12(text3, FC3A841F: true);
					C6095C13.F8091028(2.0);
					C6095C13.method_60();
					string text4 = "[aria-label=\"Join Group\" i],[aria-label=\"Follow Group\" i]";
					if (!C6095C13.D7A424AE(text4) || C6095C13.D7A424AE("[href=\"/groups/discover/\"]"))
					{
						break;
					}
					if (C6095C13.method_30(text4) != 1)
					{
						C6095C13.method_19(text4 + "|0");
					}
					else
					{
						C6095C13.method_19(text4);
					}
					C6095C13.F8091028(2.0);
				}
				method_130(A3B0678D, $"Crawl {text} ({num2 + 1}/{num}): Get link...");
				int tickCount = Environment.TickCount;
				int num4 = 60;
				while (!C6095C13.E184CD03() && !C6095C13.CD930D04() && Environment.TickCount - tickCount <= num4 * 1000)
				{
					string text5 = C6095C13.method_15(0.0, new List<string> { "(//*[@aria-posinset])" });
					string text6 = text5;
					string text7 = text6;
					if (text7 == "(//*[@aria-posinset])")
					{
						num3++;
						if (num3 > C6095C13.method_30(text5))
						{
							C6095C13.method_35(text5 + "[last()]");
							C6095C13.F8091028(5.0);
							if (num3 > C6095C13.method_30(text5))
							{
								break;
							}
						}
						string aA32FEA = text5 + $"[{num3}]";
						C6095C13.method_20(aA32FEA, 2);
						string text8 = text5 + $"[{num3}]//*[@dir=\"ltr\"]//*[@id]//*[@href and @role=\"link\"][.//*[contains(@style, \"display:\")]]";
						C6095C13.method_20(text8);
						C6095C13.method_148(text8);
						C6095C13.F8091028(2.0);
						string text9 = C6095C13.B9BE8807(text8, "href");
						if (text9.Contains("?"))
						{
							text9 = text9.Split('?')[0];
						}
						if (list2.Contains(text9))
						{
							break;
						}
						if (!string.IsNullOrEmpty(text9))
						{
							list2.Add(text9);
							try
							{
								method_130(A3B0678D, $"Crawl {text} ({num2 + 1}/{num}): Get content...");
								string json = C6095C13.method_101(text9);
								JObject jObject = JObject.Parse(json);
								string text10 = jObject["content"]!.ToString();
								if (text10 != "")
								{
									method_130(A3B0678D, $"Crawl {text} ({num2 + 1}/{num}): Upload server...");
									method_19(text, text9, text10);
									File.AppendAllText(text2, text9 + "\n");
								}
							}
							catch (Exception)
							{
							}
						}
						method_131(A3B0678D, $"Crawl {text} ({num2 + 1}/{num}): Delay {{time}}s...", int_, int_2);
						num2++;
						if (num2 >= num)
						{
							break;
						}
						tickCount = Environment.TickCount;
						method_130(A3B0678D, $"Crawl {text} ({num2 + 1}/{num}): Get link...");
					}
					C6095C13.F8091028(2.0);
				}
			}
			method_130(A3B0678D, "Crawl: Delay {time}s...", int_3);
		}
		method_130(A3B0678D, "Crawl done!");
	}

	private void AF328D25(int int_3, string EF295FAA, Chrome C599202C)
	{
		if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetToken"))
		{
			method_130(int_3, EF295FAA + "Get token...");
			string text = "";
			switch (C5034B95.smethod_0("configInteractGeneral").method_2("typeToken"))
			{
			case 0:
				text = C599202C.DC8F5A1A();
				break;
			case 1:
				text = C599202C.F23C6F07();
				break;
			case 2:
				text = C599202C.FB001323();
				break;
			case 3:
				text = C599202C.method_88();
				break;
			case 4:
				text = C599202C.method_89();
				break;
			}
			if (text != "")
			{
				method_134(int_3, "cToken", text, "token");
			}
		}
	}

	private int method_22(int int_3, string string_1, Chrome chrome_0, GClass4 F121EE24, string string_2, string string_3)
	{
		string text = F121EE24.BDB80B23("txtUid");
		bool flag = F121EE24.method_3("ckbTuDongXoaNoiDung");
		bool flag2 = F121EE24.method_3("ckbTaoNoiDungAI");
		string f7A7DE = F121EE24.BDB80B23("cbbPrompt");
		string text2 = "";
		if (flag2)
		{
			text2 = Commom.smethod_93(f7A7DE, "", "");
		}
		else
		{
			if (dictionary_25[string_2].Count <= 0)
			{
				return 0;
			}
			if (!flag)
			{
				text2 = dictionary_25[string_2].smethod_8();
			}
			else
			{
				lock (dictionary_25)
				{
					int index = dictionary_25[string_2].smethod_7();
					text2 = dictionary_25[string_2][index];
					dictionary_25[string_2].RemoveAt(index);
				}
			}
		}
		string text3 = "";
		if (!text.StartsWith("https"))
		{
			text3 = "https://www.facebook.com/" + text;
		}
		text3 += "/reviews";
		chrome_0.method_53();
		chrome_0.method_12(text3, FC3A841F: true);
		chrome_0.method_60();
		bool flag3 = chrome_0.A42C8002(text2);
		if (flag && !flag3)
		{
			lock (dictionary_25)
			{
				dictionary_25[string_2].Add(text2);
			}
		}
		chrome_0.method_54();
		return flag3 ? 1 : 0;
	}

	private bool A7A62D98(int int_3, string F133A334, GClass4 FA2F81BF, string string_1, int int_4)
	{
		string text = F6061E95(int_3, "cUid");
		string text2 = F6061E95(int_3, "cPassword");
		string text3 = F6061E95(int_3, "cFa2");
		string text4 = F6061E95(int_3, "cCookies");
		string text5 = F6061E95(int_3, "cToken");
		bool result = false;
		string text6 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36";
		string text8;
		if (FA2F81BF.method_3("Unlock282An") || FA2F81BF.method_3("Unlock956An"))
		{
			result = true;
			method_130(int_3, "Checking...");
			method_28(int_3, F133A334, text4, string_1, int_4);
			string text7 = method_135(int_3);
			if (!(text7 == "No login!"))
			{
				if (FA2F81BF.method_3("Unlock282An") && text7.Contains("282"))
				{
					RequestXNet requestXNet_ = new RequestXNet(text4, text6, string_1, int_4);
					B630B9AA(int_3, F133A334, requestXNet_);
				}
				else if (FA2F81BF.method_3("Unlock956An") && (text7.Contains("956") || text7.Contains("login")))
				{
					RequestXNet a22DAD = new RequestXNet(text4, text6, string_1, int_4);
					B7B2DA04(int_3, F133A334, a22DAD);
				}
			}
		}
		else
		{
			if (FA2F81BF.method_3("GetTokenEAAAAU"))
			{
				result = true;
				string b8BDE = "Get Token fail!";
				if (C5034B95.smethod_0("configGetToken").method_3("ckbCheckWall"))
				{
					method_130(int_3, "Check wall...");
					if (CommonRequest.BC9215A7(text).StartsWith("0|"))
					{
						method_130(int_3, "Get Token fail (Wall die)!");
						E589F93F(int_3, "Die");
						goto IL_133f;
					}
				}
				method_130(int_3, "Get Token...");
				int tokenType = C5034B95.smethod_0("configGetToken").method_2("cbbGetToken");
				string tokenTypeStr = C5034B95.smethod_0("configGetToken").BDB80B23("cbbGetTokenText");
				int runBy = C5034B95.smethod_0("configGetToken").method_2("cbbRunBy");

				if (tokenType == 0 || tokenTypeStr.Contains("EAAG"))
				{
					if (runBy == 1 || runBy == 2)
					{
						text5 = SmartTokenHub.GetTokenEAAG(text4, string_1, int_4);
					}
					if (runBy == 0 || (runBy == 2 && string.IsNullOrEmpty(text5)))
					{
						if (string.IsNullOrEmpty(text4))
						{
							text4 = SmartTokenHub.GetCookieFromCredentials(text, text2, text3, string_1, int_4);
							if (!string.IsNullOrEmpty(text4) && C5034B95.smethod_0("configGetToken").method_3("ckbGetCookie"))
							{
								method_134(int_3, "cCookies", text4, "cookie1");
							}
						}
						text5 = SmartTokenHub.GetTokenEAAG(text4, string_1, int_4);
						if (string.IsNullOrEmpty(text5))
						{
							text5 = Commom.smethod_8(text4, "", string_1, int_4, text3);
						}
					}
				}
				else if (tokenType == 1 || tokenTypeStr.Contains("EAAB"))
				{
					if (runBy == 1 || runBy == 2)
					{
						text5 = SmartTokenHub.GetTokenEAAB(text4, string_1, int_4);
					}
					if (runBy == 0 || (runBy == 2 && string.IsNullOrEmpty(text5)))
					{
						if (string.IsNullOrEmpty(text4))
						{
							text4 = SmartTokenHub.GetCookieFromCredentials(text, text2, text3, string_1, int_4);
							if (!string.IsNullOrEmpty(text4) && C5034B95.smethod_0("configGetToken").method_3("ckbGetCookie"))
							{
								method_134(int_3, "cCookies", text4, "cookie1");
							}
						}
						text5 = SmartTokenHub.GetTokenEAAB(text4, string_1, int_4);
						if (string.IsNullOrEmpty(text5))
						{
							text5 = Commom.F48BF22E(text4, "", string_1, int_4);
						}
					}
				}
				else
				{
					bool isEAAAAY = tokenType == 3 || tokenTypeStr.Contains("EAAAAY");
					if (runBy == 1 || runBy == 2)
					{
						text5 = (isEAAAAY ? Commom.smethod_7(text4, string_1, int_4) : Commom.BE0E5F11(text4, string_1, int_4));
					}
					if (runBy == 0 || (runBy == 2 && text5 == ""))
					{
						text5 = (isEAAAAY ? Commom.B0B017A1(text, text2, text3, string_1, int_4) : Commom.smethod_6(text, text2, text3, string_1, int_4));
					}
				}
				if (text5 == "Invalid username or password")
				{
					method_130(int_3, "Get Token fail (Sai pass)!");
					goto IL_133f;
				}
				if (text5 != "" && text5 != "|")
				{
					if (text5.Contains("|"))
					{
						text4 = text5.Split('|')[1];
						if (C5034B95.smethod_0("configGetToken").method_3("ckbGetCookie"))
						{
							method_134(int_3, "cCookies", text4, "cookie1");
						}
						text5 = text5.Split('|')[0];
					}
					method_134(int_3, "cToken", text5, "token");
					b8BDE = "Get Token Success!";
				}
				method_130(int_3, b8BDE);
			}
			if (FA2F81BF.method_3("GetTokenEAAG"))
			{
				result = true;
				string b8BDE2 = "Get Token fail!";
				if (C5034B95.smethod_0("configGetToken").method_3("ckbCheckWall"))
				{
					method_130(int_3, "Check wall...");
					if (CommonRequest.BC9215A7(text).StartsWith("0|"))
					{
						method_130(int_3, "Get Token fail (Wall die)!");
						E589F93F(int_3, "Die");
						goto IL_133f;
					}
				}
				method_130(int_3, "Get Token...");
				text5 = SmartTokenHub.GetTokenEAAG(text4, string_1, int_4);
				if (string.IsNullOrEmpty(text5))
				{
					text5 = Commom.smethod_8(text4, "", string_1, int_4, text3);
				}
				if (text5.StartsWith("EAAG"))
				{
					method_134(int_3, "cToken", text5, "token");
					b8BDE2 = "Get Token Success!";
				}
				method_130(int_3, b8BDE2);
			}
			if (FA2F81BF.method_3("GetTokenEAABs"))
			{
				result = true;
				string b8BDE3 = "Get Token fail!";
				if (C5034B95.smethod_0("configGetToken").method_3("ckbCheckWall"))
				{
					method_130(int_3, "Check wall...");
					if (CommonRequest.BC9215A7(text).StartsWith("0|"))
					{
						method_130(int_3, "Get Token fail (Wall die)!");
						E589F93F(int_3, "Die");
						goto IL_133f;
					}
				}
				method_130(int_3, "Get Token...");
				text5 = SmartTokenHub.GetTokenEAAB(text4, string_1, int_4);
				if (string.IsNullOrEmpty(text5))
				{
					text5 = Commom.F48BF22E(text4, "", string_1, int_4);
				}
				if (text5.StartsWith("EAAB"))
				{
					method_134(int_3, "cToken", text5, "token");
					b8BDE3 = "Get Token Success!";
				}
				method_130(int_3, b8BDE3);
			}
			if (!FA2F81BF.method_3("TaoPage"))
			{
				goto IL_0e76;
			}
			result = true;
			text8 = "";
			if (text5.StartsWith("EAAAAU") && !C5034B95.smethod_0("configTaoPage").method_3("ckbGetToken"))
			{
				goto IL_05e4;
			}
			method_130(int_3, "Get Token...");
			text5 = Commom.smethod_6(text, text2, text3, string_1, int_4);
			if (text5 == "Invalid username or password")
			{
				method_130(int_3, "Get Token fail (Sai pass)!");
			}
			else
			{
				if (!(text5 == "") && !(text5 == "|"))
				{
					text5 = text5.Split('|')[0];
					method_134(int_3, "cToken", text5, "token");
					text8 += " Get Token Success,";
					goto IL_05e4;
				}
				method_130(int_3, "Get Token fail!");
			}
		}
		goto IL_133f;
		IL_0e76:
		if (!FA2F81BF.method_3("TaiAnhTuNhom"))
		{
			goto IL_1061;
		}
		result = true;
		string text9 = "";
		if (text5.StartsWith("EAAAAU"))
		{
			goto IL_0f49;
		}
		method_130(int_3, "Get Token...");
		text5 = Commom.smethod_6(text, text2, text3, string_1, int_4);
		if (text5 == "Invalid username or password")
		{
			method_130(int_3, "Get Token fail (Sai pass)!");
		}
		else
		{
			if (!(text5 == "") && !(text5 == "|"))
			{
				text5 = text5.Split('|')[0];
				method_134(int_3, "cToken", text5, "token");
				text9 += " Get Token Success,";
				goto IL_0f49;
			}
			method_130(int_3, "Get Token fail!");
		}
		goto IL_133f;
		IL_133f:
		return result;
		IL_111f:
		method_130(int_3, "Bật 2FA...");
		string b8BDE4 = "Bật 2fa fail!";
		if (text5.Trim() != "")
		{
			string text10 = Commom.smethod_85($"Enable2FA('{text2}','{text4}','{text5}','{string_1}',{int_4})");
			if (text10 != "")
			{
				method_134(int_3, "cFa2", text10, "fa2");
				b8BDE4 = "Bật 2fa Success!";
			}
		}
		method_130(int_3, b8BDE4);
		goto IL_11ac;
		IL_05e4:
		string text11 = "";
		if (C5034B95.smethod_0("configTaoPage").method_3("ckbTaoPage"))
		{
			method_130(int_3, "Ta\u0323o page...");
			int num = C5034B95.smethod_0("configTaoPage").method_2("nudSoLuongPage");
			List<string> list = new List<string>();
			for (int i = 0; i < num; i++)
			{
				method_130(int_3, $"Ta\u0323o page: {i + 1}...");
				string text12 = "";
				if (C5034B95.smethod_0("configTaoPage").method_3("ckbRandomTen", C9B3010F: true))
				{
					string text13 = (from D700CB8F in SetupFolder.smethod_4()
						orderby Guid.NewGuid()
						select D700CB8F).First();
					string text14 = (from string_0 in SetupFolder.B92F5E26()
						orderby Guid.NewGuid()
						select string_0).First().Trim();
					string text15 = (from string_0 in SetupFolder.smethod_5()
						orderby Guid.NewGuid()
						select string_0).First();
					text12 = text13 + ((text14 == "") ? " " : (" " + text14 + " ")) + text15;
				}
				else
				{
					text12 = C5034B95.smethod_0("configTaoPage").method_1("lstTenPage").smethod_8();
					text12 = text12.smethod_1();
				}
				string text16 = C5034B95.smethod_0("configTaoPage").method_1("lstDanhMuc").smethod_8();
				string text17 = Commom.smethod_85($"TaoPageByToken('{text12}', '{text16}', '{text4}', '{text5}', '{string_1}', {int_4})");
				Match match = Regex.Match(text17, "(\\d+)\\|(\\d+)");
				if (match.Success)
				{
					list.Add(text17);
					if (i < num - 1)
					{
						method_130(int_3, $"Create page: {i + 1}, delay {{time}}s...", 5);
					}
					continue;
				}
				string value = Regex.Match(text17, "Toast,.*?\"(.*?)\"").Groups[1].Value;
				value = value.Replace("\\\\", "\\").Replace("\\\\", "\\");
				value = Regex.Unescape(value);
				if (value == "")
				{
					value = Regex.Match(text17, "\"message\": \"(.*?)\"").Groups[1].Value;
				}
				text11 = value;
				break;
			}
			text8 += $" Page: {list.Count},";
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (C5034B95.smethod_0("configTaoPage").method_3("ckbFollow"))
		{
			int num2 = 0;
			if (dictionary.Count == 0)
			{
				method_130(int_3, "Get token page...");
				string json = Commom.smethod_85($"GetPageProfile2('{text4}','{text6}','{string_1}',{int_4}, '{text5}')");
				foreach (JToken item in JArray.Parse(json))
				{
					dictionary.Add(item["uid"]!.ToString(), item["token"]!.ToString());
				}
			}
			string text18 = C5034B95.smethod_0("configTaoPage").BDB80B23("txtId");
			foreach (KeyValuePair<string, string> item2 in dictionary)
			{
				method_130(int_3, $"Follow: {num2}/{dictionary.Count}...");
				string text19 = Commom.smethod_85($"FollowByToken('{text4}', '{text6}', '{string_1}', {int_4}, '{item2.Value}', '{text18}')");
				if (text19 == "true")
				{
					num2++;
					continue;
				}
				break;
			}
			text8 += $" Follow: {num2},";
		}
		if (C5034B95.smethod_0("configTaoPage").method_3("ckbLikePage"))
		{
			int num3 = 0;
			if (dictionary.Count == 0)
			{
				method_130(int_3, "Get token page...");
				string json2 = Commom.smethod_85($"GetPageProfile2('{text4}','{text6}','{string_1}',{int_4}, '{text5}')");
				foreach (JToken item3 in JArray.Parse(json2))
				{
					dictionary.Add(item3["uid"]!.ToString(), item3["token"]!.ToString());
				}
			}
			string text20 = C5034B95.smethod_0("configTaoPage").BDB80B23("txtPageId");
			string text21 = Commom.smethod_85($"GetPageId('','','{string_1}',{int_4},'{text20}')");
			if (text21 == "")
			{
				text21 = Commom.smethod_85($"GetPageId('{text4}','','{string_1}',{int_4},'{text20}')");
			}
			if (text21 != "")
			{
				foreach (KeyValuePair<string, string> item4 in dictionary)
				{
					method_130(int_3, $"Like page: {num3}/{dictionary.Count}...");
					string text22 = Commom.smethod_85($"LikePageByToken('{text4}', '{text6}', '{string_1}', {int_4}, '{item4.Value}', '{text20}')");
					if (text22 == "true")
					{
						num3++;
						continue;
					}
					break;
				}
			}
			text8 += $" Like page: {num3},";
		}
		if (C5034B95.smethod_0("configTaoPage").method_3("ckbJoinGroup"))
		{
			int num4 = 0;
			if (dictionary.Count == 0)
			{
				method_130(int_3, "Get token page...");
				string json3 = Commom.smethod_85($"GetPageProfile2('{text4}','{text6}','{string_1}',{int_4}, '{text5}')");
				foreach (JToken item5 in JArray.Parse(json3))
				{
					dictionary.Add(item5["uid"]!.ToString(), item5["token"]!.ToString());
				}
			}
			string text23 = C5034B95.smethod_0("configTaoPage").BDB80B23("txtGroupId");
			foreach (KeyValuePair<string, string> item6 in dictionary)
			{
				method_130(int_3, $"Join group: {num4}/{dictionary.Count}...");
				string text24 = Commom.smethod_85($"JoinGroupByToken('{text4}', '{text6}', '{string_1}', {int_4}, '{item6.Value}', '{text23}', '{item6.Key}')");
				if (text24 == "true")
				{
					num4++;
					continue;
				}
				break;
			}
			text8 += $" Join group: {num4},";
		}
		method_130(int_3, text8.Trim().TrimEnd(',') + ((text11 == "") ? "" : (" (" + text11 + ") ")) + "!");
		goto IL_0e76;
		IL_1061:
		if (!FA2F81BF.method_3("Bat2FA"))
		{
			goto IL_11ac;
		}
		result = true;
		if (text5.StartsWith("EAAAAU"))
		{
			goto IL_111f;
		}
		method_130(int_3, "Get Token...");
		text5 = Commom.smethod_6(text, text2, text3, string_1, int_4);
		if (text5 == "Invalid username or password")
		{
			method_130(int_3, "Get Token fail (Sai pass)!");
		}
		else
		{
			if (!(text5 == "") && !(text5 == "|"))
			{
				text5 = text5.Split('|')[0];
				method_134(int_3, "cToken", text5, "token");
				goto IL_111f;
			}
			method_130(int_3, "Get Token fail!");
		}
		goto IL_133f;
		IL_0f49:
		method_130(int_3, "Ta\u0309i a\u0309nh...");
		string text25 = "";
		lock (AB312AAB)
		{
			text25 = AB312AAB.Dequeue();
		}
		int num5 = C5034B95.smethod_0("configTaiAnhTuNhom").method_2("nudSoLuong");
		string text26 = C5034B95.smethod_0("configTaiAnhTuNhom").BDB80B23("txtFolderPath");
		string text27 = Commom.smethod_85(string.Format("DownloadImageFromGroupByToken('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", text25, num5, text26.Replace("\\", "\\\\\\\\"), text, text2, text3, text4, text5, string_1, int_4));
		if (text27.Contains("No connection could be made because the target machine actively refused it"))
		{
			text27 = "";
		}
		method_130(int_3, $"Ta\u0309i a\u0309nh xong: {text27.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).Length}!");
		goto IL_1061;
		IL_11ac:
		if (FA2F81BF.method_3("UpAvatar"))
		{
			result = true;
			method_130(int_3, "Up Avatar...");
			string b8BDE5 = "Up Avatar fail!";
			if (text5.Trim() != "")
			{
				RequestXNet requestXNet = new RequestXNet("", "", string_1, int_4);
				string text28 = "";
				try
				{
					text28 = requestXNet.method_1("https://graph.facebook.com/me/photos?access_token=" + text5, "url=" + new RequestXNet().E58EB99F("https://download.minsoftware.vn/photos/"));
					if (text28 != "")
					{
						JObject jObject = JObject.Parse(text28);
						string text29 = jObject["id"]!.ToString();
						text28 = requestXNet.method_1("https://graph.facebook.com/me/picture?access_token=" + text5, "focus_y=0.49902534&focus_x=0.5&photo=" + text29 + "&no_feed_story=false&locale=en_US&client_country_code=VN&fb_api_req_friendly_name=set_cover_photo&fb_api_caller_class=SetCoverPhotoHandlerImpl");
						if (text28 != "")
						{
							b8BDE5 = "Up Avatar Success!";
						}
					}
				}
				catch (Exception)
				{
					text28 = requestXNet.F089DBB3.Response.ToString();
				}
			}
			method_130(int_3, b8BDE5);
		}
		if (FA2F81BF.method_3("KichHoatPageVhh"))
		{
			result = true;
			method_130(int_3, "Active Page...");
			string text30 = Commom.smethod_85($"ActivePageProfile('{text4}','','{string_1}',{int_4},'')");
			method_130(int_3, "Active Page " + ((text30 == "true") ? "success" : "fail") + "!");
		}
		goto IL_133f;
	}

	private Chrome method_23(int int_3, string F339160C, GClass4 D1237D10, int int_4, string string_1, int int_5)
	{
		Chrome chrome = new Chrome();
		method_130(int_3, F339160C + Language.GetValue("Chờ đến lượt..."));
		lock (object_0)
		{
			if (!Base.smethod_5())
			{
				if (int_0 > 0)
				{
					method_131(int_3, F339160C + Language.GetValue("Mở tri\u0300nh duyê\u0323t sau") + " {time}s...", C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeFrom", 1), C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeTo", 1));
				}
				else
				{
					int_0++;
				}
				goto IL_00c7;
			}
			method_130(int_3, F339160C + Language.GetValue("Đã dừng!"));
		}
		goto IL_0803;
		IL_00c7:
		method_130(int_3, F339160C + Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
		string text = "data:,";
		Point point_;
		Point f5BA98AC;
		if (D1237D10.method_3("OpenBrowser"))
		{
			text = "";
			if (C5034B95.smethod_0("configOpenBrowser").method_3("ckbAddChromeIntoForm"))
			{
				point_ = new Point(-1000, 0);
				f5BA98AC = new Point(C5034B95.smethod_0("configOpenBrowser").method_2("nudWidthChrome") + 16, C5034B95.smethod_0("configOpenBrowser").method_2("nudHeighChrome"));
			}
			else
			{
				point_ = Commom.smethod_55(int_4, C5034B95.smethod_0("configOpenBrowser").method_2("cbbColumnChrome", 3), C5034B95.smethod_0("configOpenBrowser").method_2("cbbRowChrome", 2));
				f5BA98AC = Commom.E50AD706(C5034B95.smethod_0("configOpenBrowser").method_2("cbbColumnChrome", 3), C5034B95.smethod_0("configOpenBrowser").method_2("cbbRowChrome", 2));
			}
		}
		else if (C5034B95.smethod_0("configGeneral").method_3("ckbAddChromeIntoForm") || C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView"))
		{
			if (text == "")
			{
				point_ = new Point(-1000, 0);
				f5BA98AC = new Point(C5034B95.smethod_0("configGeneral").method_2("nudWidthChrome") + 16, C5034B95.smethod_0("configGeneral").method_2("nudHeighChrome") + 132);
			}
			else
			{
				point_ = new Point(-1000, 0);
				f5BA98AC = new Point(C5034B95.smethod_0("configGeneral").method_2("nudWidthChrome") + 33, C5034B95.smethod_0("configGeneral").method_2("nudHeighChrome") + 39);
			}
		}
		else
		{
			point_ = Commom.smethod_55(int_4, C5034B95.smethod_0("configGeneral").method_2("cbbColumnChrome", 3), C5034B95.smethod_0("configGeneral").method_2("cbbRowChrome", 2));
			f5BA98AC = Commom.E50AD706(C5034B95.smethod_0("configGeneral").method_2("cbbColumnChrome", 3), C5034B95.smethod_0("configGeneral").method_2("cbbRowChrome", 2));
		}
		chrome.F5BA98AC = f5BA98AC;
		chrome.Point_0 = point_;
		chrome.DA9C9817 = text;
		chrome.Boolean_2 = !C5034B95.smethod_0("configGeneral").method_3("ckbShowImageInteract");
		if (D1237D10.method_3("Unlock282") || D1237D10.method_3("OpenBrowser") || D1237D10.method_3("ManualFacebookLogin") || D1237D10.method_3("AccountWarmUp"))
		{
			chrome.Boolean_2 = false;
		}
		chrome.D1154987 = int_3;
		chrome.A3A32284 = string_1;
		chrome.Int32_1 = int_5;
		chrome.CF8FD901 = int_3;
		chrome.AF336B2C = F6061E95(int_3, "cId");
		chrome.B4208531 = F6061E95(int_3, "cUid");
		chrome.C234EEAA = F6061E95(int_3, "cPassword");
		chrome.A1BF36A2 = F6061E95(int_3, "cFa2");
		chrome.F5812DA8 = F6061E95(int_3, "cToken");
		string text2 = F6061E95(int_3, "cUseragent");
		if (D1237D10.method_3("Unlock956") && (D1237D10.method_2("TypeUnlock956") == 2 || D1237D10.method_2("TypeUnlock956") == 3))
		{
			text2 = "";
		}
		chrome.String_0 = text2;
		string string_2 = "";
		string text3 = C5034B95.smethod_2();
		if (text3 != "" && chrome.B4208531 != "")
		{
			string_2 = text3 + "\\" + chrome.B4208531;
		}
		if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbCreateProfile"))
		{
			string_2 = "";
		}
		if (D1237D10.method_3("OpenBrowser") && !C5034B95.smethod_0("configOpenBrowser").method_3("isUseProfile", C9B3010F: true))
		{
			string_2 = "";
		}
		chrome.PreserveSession = ProfileSession.Enabled || D1237D10.method_3("ManualFacebookLogin") || D1237D10.method_3("AccountWarmUp");
        if (chrome.PreserveSession)
            string_2 = ProfileSession.ResolvePath(text3, chrome.B4208531, chrome.AF336B2C);
        chrome.String_1 = string_2;
        if (D1237D10.method_3("ManualFacebookLogin") || D1237D10.method_3("AccountWarmUp")) chrome.ManualSessionLogin = true;
		if (!chrome.PreserveSession && D1237D10.method_3("RecoverPass") && C5034B95.smethod_0("configGeneral").method_3("ckbKhongSuDungProfile"))
		{
			chrome.String_1 = "";
		}
		if (D1237D10.method_3("Unlock956"))
		{
			chrome.BF35E2B2 = true;
		}
		if (D1237D10.method_3("OpenBrowser"))
		{
			chrome.DA248813 = true;
		}
		if (Base.smethod_5())
		{
			method_130(int_3, F339160C + Language.GetValue("Đã dừng!"));
		}
		else
		{
			int num = 0;
			while (true)
			{
				var (flag, text4) = chrome.method_0();
				if (flag)
				{
					if (!Base.smethod_5())
					{
						if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP") && !chrome.C018519D())
						{
							chrome.A4B307B3();
							num++;
							if (num >= 3)
							{
								method_130(int_3, F339160C + Language.GetValue("Lỗi kết nối proxy!"));
								break;
							}
							continue;
						}
						if (D1237D10.method_3("OpenBrowser"))
						{
							if (C5034B95.smethod_0("configOpenBrowser").method_3("ckbAddChromeIntoForm"))
							{
								fViewChrome.fViewChrome_0.method_2(chrome.D1154987, chrome.F5BA98AC.X, chrome.F5BA98AC.Y - 10);
								fViewChrome.fViewChrome_0.method_0(chrome.Process_0.MainWindowHandle, chrome.D1154987, chrome.F5BA98AC.X + 17, chrome.F5BA98AC.Y, -10, 0);
							}
						}
						else if (C5034B95.smethod_0("configGeneral").method_3("ckbAddChromeIntoForm") || C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView"))
						{
							chrome.bool_1 = true;
							double num2 = (double)C5034B95.smethod_0("configGeneral").method_2("nudChromeScale", 100) * 1.0 / 100.0;
							int num3 = Convert.ToInt32((double)chrome.F5BA98AC.X * num2);
							int num4 = Convert.ToInt32((double)chrome.F5BA98AC.Y * num2);
							if (chrome.DA9C9817 != "")
							{
								fViewChrome.fViewChrome_0.method_2(chrome.D1154987, num3 - Convert.ToInt32(33.0 * num2), num4 - Convert.ToInt32(39.0 * num2));
								fViewChrome.fViewChrome_0.method_0(chrome.Process_0.MainWindowHandle, chrome.D1154987, num3, num4, Convert.ToInt32(-10.0 * num2), Convert.ToInt32(-30.0 * num2));
							}
							else
							{
								fViewChrome.fViewChrome_0.method_2(chrome.D1154987, num3 - 16, num4 - 132);
								fViewChrome.fViewChrome_0.method_0(chrome.Process_0.MainWindowHandle, chrome.D1154987, num3 + 17, num4, -10, -125);
							}
						}
						break;
					}
					method_130(int_3, F339160C + Language.GetValue("Đã dừng!"));
					break;
				}
				method_130(int_3, F339160C + Language.GetValue("Lỗi mở trình duyệt!") + ((text4 != "") ? (" (" + text4 + ")") : ""));
				chrome = null;
				break;
			}
		}
		goto IL_0803;
		IL_0803:
		return chrome;
	}

	private List<ABB2B510> method_24(ref int int_3)
	{
		List<ABB2B510> list = new List<ABB2B510>();
		int num = C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp");
		switch (num)
		{
		case 8:
		{
			List<string> list3 = C5034B95.smethod_0("configGeneral").method_1("txtListProxy");
			if (list3.Count != 0)
			{
				for (int j = 0; j < list3.Count; j++)
				{
					list.Add(new XProxyproxy(C5034B95.smethod_0("configGeneral").BDB80B23("txtServiceURLXProxy"), list3[j], C5034B95.smethod_0("configGeneral").method_2("typeProxy"), C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPXProxy")));
				}
				if (list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPXProxy") < int_3)
				{
					int_3 = list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPXProxy");
				}
			}
			break;
		}
		default:
		{
			List<string> list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKey_" + num);
			int num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIP_" + num, -1);
			if (num2 == -1)
			{
				switch (num)
				{
				case 7:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPTinsoft", 1);
					break;
				case 10:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyTMProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPTMProxy", 1);
					break;
				case 11:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtListProxyv6");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPProxyv6", 1);
					break;
				case 12:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiShopLike");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPShopLike", 1);
					break;
				case 15:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyProxyFb");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPProxyFb", 1);
					break;
				case 16:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyWWProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPWWProxy", 1);
					break;
				case 17:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyKiotProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPKiotProxy", 1);
					break;
				case 18:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyFProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPFProxy", 1);
					break;
				case 19:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyNetProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPNetProxy", 1);
					break;
				case 20:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyRaiProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPRaiProxy", 1);
					break;
				case 21:
					list5 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyNortonProxy");
					num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPNortonProxy", 1);
					break;
				}
			}
			if (list5.Count != 0)
			{
				for (int l = 0; l < list5.Count; l++)
				{
					list.Add(new ShopLike(list5[l], num2));
				}
				if (list.Count * num2 < int_3)
				{
					int_3 = list.Count * num2;
				}
			}
			break;
		}
		case 13:
		{
			List<string> list4 = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyMinProxy");
			if (list4.Count != 0)
			{
				for (int k = 0; k < list4.Count; k++)
				{
					list.Add(new MinProxyVN(C5034B95.smethod_0("configGeneral").method_2("typeMin"), list4[k], C5034B95.smethod_0("configGeneral").method_2("typeProxyMin"), C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPMinProxy")));
				}
				if (list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPMinProxy") < int_3)
				{
					int_3 = list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPMinProxy");
				}
			}
			break;
		}
		case 14:
		{
			List<string> list2 = C5034B95.smethod_0("configGeneral").method_1("txtListObcProxy");
			if (list2.Count == 0)
			{
				break;
			}
			A31D6D9C = new List<D413579F>();
			Dictionary<string, List<string>> source = D413579F.smethod_0(C5034B95.smethod_0("configGeneral").BDB80B23("txtLinkWebObcProxy"));
			for (int i = 0; i < list2.Count; i++)
			{
				string F82AE02C = list2[i].Split(':')[1];
				string key = source.FirstOrDefault((KeyValuePair<string, List<string>> keyValuePair_0) => keyValuePair_0.Value.Contains(F82AE02C)).Key;
				if (!string.IsNullOrEmpty(key))
				{
					D413579F d413579F = D413579F.smethod_1(A31D6D9C, key);
					if (d413579F == null)
					{
						d413579F = new D413579F(key);
						A31D6D9C.Add(d413579F);
					}
					ObcProxy obcProxy = new ObcProxy(C5034B95.smethod_0("configGeneral").BDB80B23("txtLinkWebObcProxy"), list2[i], 0, C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPObcProxy"), key);
					list.Add(obcProxy);
					d413579F.method_0(obcProxy);
				}
			}
			if (list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPObcProxy") < int_3)
			{
				int_3 = list.Count * C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPObcProxy");
			}
			break;
		}
		case 0:
		case 1:
		case 2:
		case 9:
			list = null;
			break;
		}
		return list;
	}

	private bool method_25(int int_3, ref string string_1, ref int int_4, ref string string_2, ref XProxyproxy xproxyproxy_0, ref ShopLike shopLike_0, ref MinProxyVN minProxyVN_0, ref ObcProxy obcProxy_0)
	{
		int num = C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp");
		string text = "";
		while (true)
		{
			IL_0ccf:
			bool flag4;
			int num2;
			switch (num)
			{
			case 8:
				method_130(int_3, "Get Proxy...");
				lock (object_1)
				{
					if (C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy") == 0)
					{
						while (!Base.smethod_5())
						{
							xproxyproxy_0 = null;
							while (!Base.smethod_5())
							{
								foreach (XProxyproxy item in list_1)
								{
									if (item.E183403C && (xproxyproxy_0 == null || item.int_1 < xproxyproxy_0.int_1))
									{
										xproxyproxy_0 = item;
									}
								}
								if (xproxyproxy_0.int_1 != xproxyproxy_0.CEA46DB5)
								{
									break;
								}
							}
							if (Base.smethod_5())
							{
								break;
							}
							if (xproxyproxy_0.E183403C)
							{
								bool flag = false;
								if (xproxyproxy_0.int_1 > 0)
								{
									flag = true;
								}
								else
								{
									switch (xproxyproxy_0.method_2())
									{
									case 0:
										xproxyproxy_0.E183403C = false;
										break;
									case 1:
										flag = true;
										break;
									}
								}
								if (flag)
								{
									string_1 = xproxyproxy_0.string_1;
									int_4 = xproxyproxy_0.int_0;
									xproxyproxy_0.A3391CAD++;
									xproxyproxy_0.int_1++;
									break;
								}
							}
							else
							{
								xproxyproxy_0.E183403C = false;
							}
						}
					}
					else
					{
						while (!Base.smethod_5())
						{
							xproxyproxy_0 = null;
							List<XProxyproxy> list = new List<XProxyproxy>();
							foreach (XProxyproxy item2 in list_1)
							{
								if (item2.E183403C)
								{
									if (item2.int_1 < item2.CEA46DB5)
									{
										list.Add(item2);
									}
									else if (item2.A3391CAD == 0)
									{
										item2.method_1();
										item2.int_1 = 0;
									}
								}
							}
							for (int i = 0; i < list.Count; i++)
							{
								if (list[i].A20D1A35(0))
								{
									xproxyproxy_0 = list[i];
									break;
								}
							}
							if (xproxyproxy_0 != null)
							{
								string_1 = xproxyproxy_0.string_1;
								int_4 = xproxyproxy_0.int_0;
								xproxyproxy_0.A3391CAD++;
								xproxyproxy_0.int_1++;
								break;
							}
						}
					}
					if (Base.smethod_5())
					{
						break;
					}
					if (C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP") > 0)
					{
						method_130(int_3, string_2 + "Delay after change ip {time}s...", C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP"));
					}
					bool flag2 = true;
					if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP"))
					{
						string_2 = "(IP: " + string_1 + ") ";
						method_130(int_3, string_2 + "Check IP...");
						text = Commom.BD994637(string_1, int_4);
						if (text == "")
						{
							xproxyproxy_0.E183403C = false;
							flag2 = false;
						}
					}
					if (!flag2)
					{
						xproxyproxy_0.A3391CAD--;
						xproxyproxy_0.int_1--;
						continue;
					}
					goto case 0;
				}
			default:
				method_130(int_3, "Get Proxy...");
				lock (object_1)
				{
					while (!Base.smethod_5())
					{
						shopLike_0 = null;
						while (!Base.smethod_5())
						{
							foreach (ShopLike item3 in list_1)
							{
								if (shopLike_0 == null || item3.int_2 < shopLike_0.int_2)
								{
									shopLike_0 = item3;
								}
							}
							if (shopLike_0.int_2 != shopLike_0.F8ABA49F)
							{
								break;
							}
						}
						if (Base.smethod_5())
						{
							break;
						}
						if (shopLike_0.int_2 > 0 || shopLike_0.E1365814())
						{
							string_1 = shopLike_0.A40F8204;
							if (string_1 == "")
							{
								string_1 = shopLike_0.method_0();
							}
							shopLike_0.int_1++;
							shopLike_0.int_2++;
							break;
						}
					}
					if (Base.smethod_5())
					{
						break;
					}
					if (C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP") > 0)
					{
						method_130(int_3, string_2 + "Delay after change ip {time}s...", C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP"));
					}
					bool flag5 = true;
					if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP"))
					{
						string_2 = "(IP: " + string_1.Split(':')[0] + ") ";
						method_130(int_3, string_2 + "Check IP...");
						text = Commom.BD994637(string_1);
						if (text == "")
						{
							flag5 = false;
						}
					}
					if (!flag5)
					{
						shopLike_0.int_1--;
						shopLike_0.int_2--;
						continue;
					}
					goto case 0;
				}
			case 13:
				method_130(int_3, Language.GetValue("Đang lấy Api MinProxy..."));
				int_4 = ((C5034B95.smethod_0("configGeneral").method_2("typeProxyMin") >= 2) ? 1 : 0);
				minProxyVN_0 = null;
				flag4 = false;
				num2 = 0;
				if (Base.smethod_5())
				{
					break;
				}
				lock (object_1)
				{
					while (!Base.smethod_5())
					{
						foreach (MinProxyVN item4 in list_1)
						{
							if (item4.int_5 != 0)
							{
								if (minProxyVN_0 == null || item4.int_6 < minProxyVN_0.int_6)
								{
									minProxyVN_0 = item4;
								}
								continue;
							}
							minProxyVN_0 = item4;
							break;
						}
						if (minProxyVN_0.int_6 < minProxyVN_0.int_7)
						{
							break;
						}
					}
					if (minProxyVN_0 != null)
					{
						minProxyVN_0.int_5++;
						minProxyVN_0.int_6++;
						num2 = minProxyVN_0.int_6;
						goto IL_06f2;
					}
				}
				goto IL_0953;
			case 14:
				method_130(int_3, "Get Proxy...");
				lock (object_1)
				{
					if (C5034B95.smethod_0("configGeneral").method_2("typeRunObcProxy") == 0)
					{
						while (!Base.smethod_5())
						{
							obcProxy_0 = null;
							List<ObcProxy> list2 = new List<ObcProxy>();
							foreach (ObcProxy item5 in list_1)
							{
								if (item5.bool_0)
								{
									if (item5.C701F934 < item5.E90A3910)
									{
										list2.Add(item5);
									}
									else if (item5.int_0 == 0)
									{
										item5.method_1();
										item5.C701F934 = 0;
									}
								}
							}
							for (int j = 0; j < list2.Count; j++)
							{
								if (list2[j].method_4(0))
								{
									obcProxy_0 = list2[j];
									break;
								}
							}
							if (obcProxy_0 != null)
							{
								string_1 = obcProxy_0.D1AC813F;
								int_4 = obcProxy_0.ED054DB9;
								obcProxy_0.int_0++;
								obcProxy_0.C701F934++;
								break;
							}
						}
					}
					else
					{
						while (!Base.smethod_5())
						{
							obcProxy_0 = null;
							List<ObcProxy> list3 = new List<ObcProxy>();
							foreach (D413579F item6 in A31D6D9C)
							{
								if (item6.method_2())
								{
									item6.method_1();
									list3.AddRange(item6.A32E0104());
								}
								else
								{
									list3.AddRange(item6.B7AAE719());
								}
							}
							for (int k = 0; k < list3.Count; k++)
							{
								if (list3[k].method_4(0))
								{
									obcProxy_0 = list3[k];
									break;
								}
							}
							if (obcProxy_0 != null)
							{
								string_1 = obcProxy_0.D1AC813F;
								int_4 = obcProxy_0.ED054DB9;
								obcProxy_0.int_0++;
								obcProxy_0.C701F934++;
								break;
							}
						}
					}
					if (Base.smethod_5())
					{
						method_130(int_3, string_2 + Language.GetValue("Đã dừng!"));
						break;
					}
					if (C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP") > 0)
					{
						method_130(int_3, string_2 + "Delay after change ip {time}s...", C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP"));
					}
					bool flag3 = true;
					if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP"))
					{
						string_2 = "(IP: " + string_1 + ") ";
						method_130(int_3, string_2 + "Check IP...");
						text = Commom.BD994637(string_1, int_4);
						if (text == "")
						{
							obcProxy_0.bool_0 = false;
							flag3 = false;
						}
					}
					if (!flag3)
					{
						obcProxy_0.int_0--;
						obcProxy_0.C701F934--;
						continue;
					}
					goto case 0;
				}
			case 9:
				if (C5034B95.smethod_0("configGeneral").method_2("cbbProxy") == 0)
				{
					string rawProxy = F6061E95(int_3, "cProxy");
					ProxyInfo p = ProxyHelper.Parse(rawProxy);
					if (p.IsValid)
					{
						string_1 = p.ToCleanString();
						int_4 = p.ProxyType;
					}
					else
					{
						string_1 = "";
					}
				}
				else
				{
					string rawProxy = C5034B95.smethod_0("configGeneral").method_1("txtProxy").smethod_8() ?? "";
					int defaultType = C5034B95.smethod_0("configGeneral").method_2("cbbProxyType");
					ProxyInfo p = ProxyHelper.Parse(rawProxy, defaultType);
					if (p.IsValid)
					{
						string_1 = p.ToCleanString();
						int_4 = p.ProxyType;
					}
					else
					{
						string_1 = "";
					}
				}
				if (string.IsNullOrEmpty(string_1))
				{
					method_130(int_3, Language.GetValue("Tài khoản chưa có proxy!"));
					return false;
				}
				goto case 0;
			case 0:
			case 1:
			case 2:
				{
					if (string.IsNullOrEmpty(string_1))
					{
						string rawNickProxy = F6061E95(int_3, "cProxy").Trim();
						if (!string.IsNullOrEmpty(rawNickProxy))
						{
							ProxyInfo p = ProxyHelper.Parse(rawNickProxy);
							if (p.IsValid)
							{
								string_1 = p.ToCleanString();
								int_4 = p.ProxyType;
							}
						}
					}
					if (C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP"))
					{
						break;
					}
					if (num == 0 || num == 1 || num == 2 || num == 9)
					{
						if (string_1 != "")
						{
							string_2 = "(Proxy: " + string_1 + ") ";
						}
						method_130(int_3, string_2 + "Check IP...");
						// Tích hợp ProxyCircuitBreaker: Fail-fast check và ghi nhận độ trễ
						var cbResult = ProxyCircuitBreaker.CheckProxyHealth(string_1, int_4, 4000);
						if (cbResult.IsLive && !string.IsNullOrEmpty(cbResult.PublicIp))
						{
							text = cbResult.PublicIp;
						}
						else
						{
							text = Commom.BD994637(string_1, int_4);
						}

						if (text == "")
						{
							if (string_1 != "")
							{
								method_130(int_3, string_2 + Language.GetValue("Không thể kết nối proxy!"));
							}
							else
							{
								method_130(int_3, string_2 + Language.GetValue("Không có kết nối Internet!"));
							}
							return false;
						}
					}
					string_2 = "(IP: " + ((string_1 == "") ? "" : (string_1 + "=>")) + text + ") ";
					break;
				}
				IL_06f2:
				method_130(int_3, Language.GetValue("Đang lấy Proxy từ API..."));
				if (num2 > 1)
				{
					int num3 = 0;
					while (minProxyVN_0.A88A2F81)
					{
						Commom.smethod_52(1.0);
						num3++;
						if (num3 > 60)
						{
							break;
						}
					}
					string_1 = minProxyVN_0.method_3();
				}
				else
				{
					while (!Base.smethod_5())
					{
						switch (minProxyVN_0.B9903930())
						{
						case 0:
							method_130(int_3, Language.GetValue("Đang lấy Proxy từ API: Chờ " + minProxyVN_0.Int32_3 + " s"));
							if (minProxyVN_0.Int32_3 > 10)
							{
								Commom.smethod_52(10.0);
							}
							else if (minProxyVN_0.Int32_3 > 0)
							{
								Commom.smethod_52(minProxyVN_0.Int32_3);
							}
							goto IL_07f0;
						case 1:
							string_1 = minProxyVN_0.CB10C9AD;
							minProxyVN_0.A88A2F81 = false;
							goto IL_07f0;
						default:
							goto IL_07f0;
						case -2:
							method_130(int_3, Language.GetValue("Api không đúng"));
							lock (object_1)
							{
								list_1.Remove(minProxyVN_0);
							}
							break;
						case -1:
							method_130(int_3, Language.GetValue("Api hết hạn"));
							lock (object_1)
							{
								list_1.Remove(minProxyVN_0);
							}
							break;
						}
						goto IL_0ccf;
						IL_07f0:
						if (string_1 != "")
						{
							break;
						}
					}
				}
				if (!(string_1 == ""))
				{
					flag4 = true;
					if (C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP") > 0)
					{
						method_130(int_3, string_2 + "Delay check IP {time}s...", C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP"));
					}
					if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP"))
					{
						string_2 = "(IP: " + string_1 + ") ";
						method_130(int_3, string_2 + "Check IP...");
						text = Commom.BD994637(string_1, int_4);
						if (text == "")
						{
							flag4 = false;
						}
					}
				}
				goto IL_0953;
				IL_0953:
				if (!flag4)
				{
					minProxyVN_0.int_5--;
					minProxyVN_0.int_6--;
					continue;
				}
				goto case 0;
			}
			break;
		}
		return true;
	}

	private void method_26(XProxyproxy xproxyproxy_0, ShopLike E8A9CC92, MinProxyVN minProxyVN_0, ObcProxy EA3D099B)
	{
		lock (object_2)
		{
			switch (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"))
			{
			case 8:
				xproxyproxy_0?.method_3();
				break;
			default:
				E8A9CC92?.B32AAD86();
				break;
			case 13:
				minProxyVN_0?.method_1();
				break;
			case 14:
				EA3D099B?.method_3();
				break;
			case 0:
			case 1:
			case 2:
			case 9:
				break;
			}
		}
	}

	private string method_27(int int_3, string string_1, int B3061C8D, GClass4 gclass4_0, string string_2, string DD80FB3C, int C4A79C88)
	{
		if (C5034B95.smethod_0("configGeneral").method_3("ckbQuenMatKhauByChrome"))
		{
			Chrome chrome = method_23(int_3, string_1, gclass4_0, B3061C8D, DD80FB3C, C4A79C88);
			if (chrome == null || Base.smethod_5())
			{
				return "";
			}
			method_130(int_3, string_1 + "Recover pass...");
			try
			{
				chrome.method_12("https://www.facebook.com/?locale=en_US");
				chrome.F8091028(2.0);
				int tickCount = Environment.TickCount;
				for (int num = 60; !Base.smethod_5() && !chrome.CD930D04() && Environment.TickCount - tickCount <= num * 1000; chrome.F8091028(2.0))
				{
					string text = chrome.method_15(0.0, new List<string> { "a[href*=\"facebook.com/recover/initiate/?privacy_mutation_token=\"]", "#identify_email", "[name=\"tryanotherway\"]", "button[name=\"reset_action\"]", "[href=\"/help/121104481304395\"]", "[href*=\"/help/contact/571927962827151\"]", "[href*=\"/help/177066345680802\"]" });
					string text2 = text;
					string text3 = text2;
					uint num2 = AFAE75A0.smethod_0(text3);
					if (num2 <= 2162358271u)
					{
						if (num2 == 726745865)
						{
							if (!(text3 == "#identify_email"))
							{
								continue;
							}
							if (chrome.D7A424AE("#identify_yourself_flow .uiBoxRed"))
							{
								string text4 = chrome.method_6("#identify_yourself_flow .uiBoxRed>div");
								if (text4 != "")
								{
									return text4;
								}
							}
							chrome.method_22("#identify_email", string_2);
							chrome.F8091028(1.0);
							chrome.method_18("[name=\"did_submit\"]");
							continue;
						}
						if (num2 == 1115417188)
						{
							if (!(text3 == "[href=\"/help/121104481304395\"]"))
							{
								continue;
							}
							return Language.GetValue("Ta\u0300i khoa\u0309n đa\u0303 bi\u0323 kho\u0301a!");
						}
						if (num2 != 2162358271u || !(text3 == "a[href*=\"facebook.com/recover/initiate/?privacy_mutation_token=\"]"))
						{
							continue;
						}
					}
					else
					{
						if (num2 <= 3455351771u)
						{
							switch (num2)
							{
							case 3455351771u:
								if (!(text3 == "[href*=\"/help/177066345680802\"]"))
								{
									continue;
								}
								break;
							case 2798629971u:
								if (!(text3 == "[href*=\"/help/contact/571927962827151\"]"))
								{
									continue;
								}
								break;
							default:
								continue;
							}
							return Language.GetValue("Chặn tính năng!");
						}
						if (num2 != 3861603172u)
						{
							if (num2 == 4160056369u && text3 == "button[name=\"reset_action\"]")
							{
								if (chrome.D7A424AE("[name=\"n\"]"))
								{
									return "true";
								}
								chrome.method_18(text);
							}
							continue;
						}
						if (!(text3 == "[name=\"tryanotherway\"]"))
						{
							continue;
						}
					}
					chrome.method_18(text);
				}
			}
			catch
			{
			}
			finally
			{
				chrome.A4B307B3();
			}
			return Language.GetValue("Gư\u0309i yêu câ\u0300u thâ\u0301t ba\u0323i!");
		}
		string text5 = "";
		int num3 = 0;
		while (true)
		{
			if (num3 < 3)
			{
				text5 = CommonRequest.smethod_17(string_2, DD80FB3C, C4A79C88);
				if (text5 == "true")
				{
					break;
				}
				num3++;
				continue;
			}
			return text5;
		}
		return text5;
	}

	private void method_28(int E2AB5512, string string_1, string string_2, string string_3, int D1B1C991)
	{
		var (text, text2) = CommonRequest.smethod_11(string_2, string_3, D1B1C991);
		if (text2 != "")
		{
			E589F93F(E2AB5512, text2);
		}
		if (text2.Contains("282") && text != "")
		{
			method_134(E2AB5512, "cStatus282", text, "status282");
			text = text2;
		}
		if (text == "")
		{
			text = text2;
		}
		method_130(E2AB5512, string_1 + text + "!");
		string text3 = (text2 + text).ToLower();
		if (text3.Contains("live"))
		{
			C412B9A5(E2AB5512, 2);
		}
		else if (text3.Contains("checkpoint"))
		{
			C412B9A5(E2AB5512, 1);
		}
	}

	private int method_29(RequestXNet A8BD03AC, string string_1 = "")
	{
		if (string_1 == "")
		{
			string_1 = C49D34AC(A8BD03AC, "https://m.facebook.com");
		}
		string f0109CB = "https://m.facebook.com" + Regex.Match(string_1, "(/checkpoint/1501092823525282/logout/.*?)\"").Groups[1].Value.Replace("&amp;", "&");
		string_1 = C49D34AC(A8BD03AC, f0109CB);
		string value = Regex.Match(string_1, "sau (\\d+) ngày").Groups[1].Value;
		if (value == "")
		{
			value = Regex.Match(string_1, "are (\\d+) days").Groups[1].Value;
		}
		if (value == "")
		{
			value = Regex.Match(string_1, "in (\\d+) days").Groups[1].Value;
		}
		if (value == "")
		{
			value = Regex.Match(string_1, "have (\\d+) days").Groups[1].Value;
		}
		if (Commom.smethod_45(value))
		{
			return Convert.ToInt32(value);
		}
		return -1;
	}

	private int method_30(Chrome chrome_0, string string_1 = "")
	{
		chrome_0.method_49();
		string text = chrome_0.GetDomainFb(chrome_0.GetURL());
		if (string_1 == "")
		{
			string_1 = chrome_0.C604C58C(text);
		}
		string string_2 = text + Regex.Match(string_1, "(/checkpoint/1501092823525282/logout/.*?)\"").Groups[1].Value.Replace("&amp;", "&");
		string_1 = chrome_0.C604C58C(string_2);
		string value = Regex.Match(string_1, "sau (\\d+) ngày").Groups[1].Value;
		if (value == "")
		{
			value = Regex.Match(string_1, "are (\\d+) days").Groups[1].Value;
		}
		if (value == "")
		{
			value = Regex.Match(string_1, "in (\\d+) days").Groups[1].Value;
		}
		if (value == "")
		{
			value = Regex.Match(string_1, "have (\\d+) days").Groups[1].Value;
		}
		if (Commom.smethod_45(value))
		{
			return Convert.ToInt32(value);
		}
		return -1;
	}

	private string D6AFFF1B(RequestXNet requestXNet_0, string FD399500)
	{
		string text = "";
		for (int i = 0; i < 5; i++)
		{
			try
			{
				byte[] inArray = requestXNet_0.method_0(FD399500);
				text = Convert.ToBase64String(inArray);
				if (text != "")
				{
					return text;
				}
			}
			catch (Exception)
			{
				text = "";
			}
			Commom.smethod_52(1.0);
		}
		return text;
	}

	private string C49D34AC(RequestXNet C5803803, string F0109CB1)
	{
		string result = "";
		for (int i = 0; i < 5; Commom.smethod_52(1.0), i++)
		{
			try
			{
				result = C5803803.E58EB99F(F0109CB1);
			}
			catch (Exception)
			{
				result = "";
				continue;
			}
			break;
		}
		return result;
	}

	private string method_31(RequestXNet D8AB63A7, string string_1, string AA35BF33)
	{
		string result = "";
		for (int i = 0; i < 5; Commom.smethod_52(1.0), i++)
		{
			try
			{
				result = D8AB63A7.method_1(string_1, AA35BF33);
			}
			catch (Exception)
			{
				result = "";
				continue;
			}
			break;
		}
		return result;
	}

	private void B630B9AA(int int_3, string string_1, RequestXNet requestXNet_0, string string_2 = "", Chrome CF031210 = null)
	{
		string text = "";
		int num = 3;
		while (true)
		{
			num--;
			if (num >= 0)
			{
				try
				{
					method_130(int_3, string_1 + "Unlock 282...");
					if (CF031210 != null)
					{
						string imgDir = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPathImage");
						int solve282 = CheckpointClassifier.SolveCheckpoint282(CF031210, imgDir, (msg) => method_130(int_3, string_1 + msg));
						if (solve282 == 1)
						{
							method_130(int_3, string_1 + Language.GetValue("Đợi xét duyệt (Upload selfie OK)"));
							method_134(int_3, "cStatus282", "Đợi xét duyệt (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")", "status282");
							E589F93F(int_3, "Đợi xét duyệt (Upload selfie OK)");
							C412B9A5(int_3, 2);
							break;
						}
					}
					string text2 = Commom.F914B80B(requestXNet_0.method_4(), "c_user=(\\d+)");
					int num2 = C5034B95.smethod_0("configCheckpoint").method_2("typeSim");
					int num3 = 0;
					int num4 = 3;
					int num5 = 0;
					int num6 = 1;
					int num7 = 0;
					int num8 = C5034B95.smethod_0("configCheckpoint").method_2("nudLimitCountGetPhone", 3);
					string text3 = "";
					if (C5034B95.smethod_0("configCheckpoint").method_3("ckbLanguage"))
					{
						lock (EB21531C)
						{
							if (EB21531C.Count == 0)
							{
								EB21531C = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtLanguage").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
									.ToList();
							}
							if (EB21531C.Count > 0)
							{
								text3 = EB21531C.First();
								EB21531C.Remove(text3);
								text3 = text3.Trim();
							}
						}
					}
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					int num9 = C5034B95.smethod_0("configCheckpoint").method_2("cbbTypeMail");
					List<string> list = C5034B95.smethod_0("configCheckpoint").method_1("lstMailDomain");
					if (C5034B95.smethod_0("configCheckpoint").method_3("ckbAddMail") && num9 == 1 && list.Count == 0)
					{
						break;
					}
					string text8 = "";
					if (list.Count > 0)
					{
						text8 = list.OrderBy((string string_0) => Guid.NewGuid()).First();
					}
					List<string> list2 = C5034B95.smethod_0("configCheckpoint").method_1("lstDomain");
					if (C5034B95.smethod_0("configCheckpoint").method_3("ckbAddMail") && num9 == 2 && list2.Count == 0)
					{
						break;
					}
					if (list2.Count > 0)
					{
						list2.OrderBy((string string_0) => Guid.NewGuid()).First();
					}
					string text9 = "";
					string string_3 = "";
					string a8382C3C = "";
					List<string> list3 = new List<string>();
					string e897EAB = requestXNet_0.E58EB99F("https://www.facebook.com/checkpoint/1501092823525282/?next=https%3A%2F%2Fwww.facebook.com%2F");
					string text10 = Commom.F914B80B(e897EAB, "\"LSD\",\\[\\],{\"token\":\"(.*?)\"");
					text = Commom.F914B80B(e897EAB, "\"DTSGInitialData\",\\[\\],{\"token\":\"(.*?)\"");
					if (text == "")
					{
						method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 1)");
						break;
					}
					int num10 = -1;
					try
					{
						num10 = Convert.ToInt32(Commom.F914B80B(e897EAB, "\"log_out_uri\":\".*?\",\"title\":\".*? (\\d+) .*?\"}}}}"));
					}
					catch (Exception)
					{
					}
					JObject jObject = null;
					string text11 = "av=" + text2 + "&__user=" + text2 + "&__a=1&__req=7&__hs=20015.HYP%3Acomet_pkg.2.1..2.1&dpr=3&__ccg=EXCELLENT&__rev=1017496172&__s=pljtfv%3Aznp1jt%3Apkw3sx&__hsi=7427386731673553225&__dyn=7xeXxa1mxu1syaxG4Vp41twWwIxu13w8CewSwAyUco2qwJyE2OwpUe8hwaG0Z82_CwjE1xoswMwto2awgo9oO0n24oaEd82lwv89k2C1Fwc60D8vwRwlE-U2exi4UaEW0Loco4i5o2eUlwhE2Lx-0luVEbUGdG1Jw9h08O321Lwqo5B0bK1Iwqo2swEwkFU-4EdrwsUbUaU3yw&__csr=hJEJaIggyTtZ5RZlhdL8J9bviP5h6nkNpkhp2tltppFl-AaBykJprVbCghKjAgS8KcppWyECqq5pqDKQWVomwVxG3K4E5S0LUdpodEaHwpo5u0h-0A9U-09swqo4-m0PE1do0Rh1q3F0UUhw9m0d6w14K0tu03bC06q-00hl208Nw0Nzw4ZwwwjU0Ci1exe5WoK06So0De0709orx2ECp2otCga805vSew38o08NGa3e2Je9m&__comet_req=15&fb_dtsg=" + text + "&jazoest=25772&lsd=" + text10 + "&__spin_r=1017496172&__spin_b=trunk&__spin_t=1729323233&fb_api_caller_class=RelayModern&";
					string text12 = "useUFACSubmitActionMutation";
					string e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22PROCEED%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=27138611312450305";
					e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
					{
						"x-fb-friendly-name: " + text12,
						"x-fb-lsd: " + text10
					});
					if (e897EAB.Contains("errorSummary"))
					{
						method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 2)");
						break;
					}
					int tickCount = Environment.TickCount;
					for (; !Base.smethod_5(); Commom.smethod_52(1.0))
					{
						try
						{
							jObject = JObject.Parse(e897EAB);
						}
						catch (Exception)
						{
						}
						switch (Commom.F839D53E(e897EAB, new List<string> { "UFACBotCaptchaState", "UFACContactPointChallengeSetContactPointState", "UFACContactPointChallengeSubmitCodeState", "email", "UFACImageUploadChallengeState", "UFACAwaitingReviewState" }))
						{
						default:
							if (!e897EAB.Contains("571927962827151"))
							{
								if (!e897EAB.Contains("828281030927956"))
								{
									if (!e897EAB.Contains("m_login_email"))
									{
										if (e897EAB.Contains("601051028565049"))
										{
											method_130(int_3, string_1 + "Click dismiss...");
											text12 = "FBScrapingWarningMutation";
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%7D&server_timestamps=true&doc_id=6339492849481770";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
											goto case "email";
										}
										e897EAB = requestXNet_0.E58EB99F("https://www.facebook.com/");
										string text25 = requestXNet_0.method_5();
										if (text25.Contains("828281030927956"))
										{
											E589F93F(int_3, "Checkpoint: 956");
											method_130(int_3, string_1 + "Checkpoint 956!");
											C412B9A5(int_3, 1);
										}
										else if (text25.Contains("facebook.com/gettingstarted") || (e897EAB.Contains("href=\"/menu/bookmarks/") && e897EAB.Contains("id=\"mbasic_logout_button\"")) || (e897EAB.Contains("id=\"MComposer\"") && e897EAB.Contains("id=\"MBackNavBar\"")) || e897EAB.Contains("\"is_checkpointed\":false"))
										{
											E589F93F(int_3, "Live");
											method_130(int_3, string_1 + "Unlock checkpoint success");
											C412B9A5(int_3, 2);
										}
										else
										{
											method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 3)");
										}
										break;
									}
									method_130(int_3, string_1 + "Unlock 282 Fail (1)");
									break;
								}
								E589F93F(int_3, "Checkpoint: 956");
								method_130(int_3, string_1 + "Checkpoint 956!");
								C412B9A5(int_3, 1);
								break;
							}
							method_130(int_3, string_1 + "Unlock 282 Fail (Spam)");
							break;
						case "UFACImageUploadChallengeState":
						{
							if (text9 != "")
							{
								method_134(int_3, "cEmail", text9, "email");
								method_134(int_3, "cPassMail", string_3, "passmail");
								B183E907(int_3, "cMailRecovery", "");
								text9 = "";
							}
							bool flag = e897EAB.Contains("ACTOR_ACCOUNTABILITY") || e897EAB.Contains("UFACIVSImageUploadScreenState") || e897EAB.Contains("DECEPTIVE_PERSONA");
							bool flag2 = e897EAB.Contains("UFACIVSSelfieVideoUploadScreenState");
							if (C5034B95.smethod_0("configCheckpoint").method_3("ckbImage"))
							{
								if (!flag || CF031210 == null)
								{
									if (flag2)
									{
										if (CF031210 == null)
										{
											method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu gư\u0309i video!"));
											method_134(int_3, "cStatus282", "Image (Video)-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
											break;
										}
										if (C5034B95.smethod_0("configCheckpoint").method_3("ckbQuayVideo"))
										{
											requestXNet_0.method_1("https://free.facebook.com/intl/save_locale/?loc=en_US&href=https%3A%2F%2Ffree.facebook.com&ls_ref=mobile_suggested_locale_selector", "fb_dtsg=" + text + "&jazoest=25459");
											CF031210.method_13();
											CF031210.F8091028(2.0);
											if (!CF031210.GetURL().Contains("828281030927956"))
											{
												method_130(int_3, string_1 + "Chơ\u0300 up video...");
												lock (object_3)
												{
													method_130(int_3, string_1 + "Up video...");
													if (CF031210.method_153())
													{
														e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22PROCEED%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=27138611312450305";
														e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
														{
															"x-fb-friendly-name: " + text12,
															"x-fb-lsd: " + text10
														});
														if (e897EAB.Contains("errorSummary"))
														{
															method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 2)");
															goto end_IL_22bf;
														}
													}
												}
												goto case "email";
											}
											E589F93F(int_3, "Checkpoint: 956");
											method_130(int_3, string_1 + "Checkpoint 956!");
											C412B9A5(int_3, 1);
											break;
										}
										if (!C5034B95.smethod_0("configCheckpoint").method_3("ckbUseFreeFb"))
										{
											method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu gư\u0309i video!"));
											method_134(int_3, "cStatus282", "Image (Video)-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
											break;
										}
									}
									method_130(int_3, string_1 + "Up image...");
									string text26 = method_144(text2);
									if (!(text26 == ""))
									{
										if (CF031210 != null)
										{
											if (C5034B95.smethod_0("configCheckpoint").method_3("ckbUseFreeFb"))
											{
												CF031210.method_68("https://free.facebook.com");
											}
											else
											{
												CF031210.method_13();
											}
											CF031210.F8091028(2.0);
											if (CF031210.GetURL().Contains("828281030927956"))
											{
												E589F93F(int_3, "Checkpoint: 956");
												method_130(int_3, string_1 + "Checkpoint 956!");
												C412B9A5(int_3, 1);
												break;
											}
											if (CF031210.method_145(text26))
											{
												e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22PROCEED%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=27138611312450305";
												e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
												{
													"x-fb-friendly-name: " + text12,
													"x-fb-lsd: " + text10
												});
												if (e897EAB.Contains("errorSummary"))
												{
													method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 2)");
													break;
												}
											}
										}
										else
										{
											e897EAB = requestXNet_0.method_2($"https://rupload.facebook.com/checkpoint_1501092823525282_media_upload/{Guid.NewGuid()}?__user={text2}&__a=1&fb_dtsg={text}", text26);
											string text27 = Commom.F914B80B(e897EAB, "\"h\":\"(.*?)\"");
											if (text27 == "")
											{
												method_130(int_3, string_1 + "Up image fail!");
												method_134(int_3, "cStatus282", "Image-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
												break;
											}
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22100079885670289%22%2C%22action%22%3A%22UPLOAD_IMAGE%22%2C%22image_upload_handle%22%3A%22" + text27 + "%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
										if (!text26.Contains("Image282\\" + text2 + ".png"))
										{
											Commom.E10A40B6(text26);
										}
										goto case "email";
									}
									method_130(int_3, string_1 + Language.GetValue("Không tìm thấy ảnh!"));
									method_134(int_3, "cStatus282", "Image-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
									break;
								}
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu giấy tờ tùy thân!"));
								method_134(int_3, "cStatus282", "Image (CMT)-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
								break;
							}
							if (flag)
							{
								if (CF031210 != null)
								{
									string imgDir = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPathImage");
									int solve282 = CheckpointClassifier.SolveCheckpoint282(CF031210, imgDir, (msg) => method_130(int_3, string_1 + msg));
									if (solve282 == 1)
									{
										method_130(int_3, string_1 + Language.GetValue("Đợi xét duyệt (Upload selfie OK)"));
										method_134(int_3, "cStatus282", "Đợi xét duyệt (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")", "status282");
										E589F93F(int_3, "Đợi xét duyệt (Upload selfie OK)");
										C412B9A5(int_3, 2);
										break;
									}
								}
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu giấy tờ tùy thân!"));
								method_134(int_3, "cStatus282", "Image (CMT)-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
							}
							else if (flag2)
							{
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu gư\u0309i video!"));
								method_134(int_3, "cStatus282", "Image (Video)-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
							}
							else
							{
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu gửi ảnh!"));
								method_134(int_3, "cStatus282", "Image-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
							}
							break;
						}
						case "UFACContactPointChallengeSubmitCodeState":
							if (text7 == "" && text9 == "")
							{
								e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%222%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22UNSET_CONTACT_POINT%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
								e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
								{
									"x-fb-friendly-name: " + text12,
									"x-fb-lsd: " + text10
								});
							}
							else
							{
								num5++;
								if (num2 == 37 && num5 > 1)
								{
									num5 = 0;
									e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%222%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22UNSET_CONTACT_POINT%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
									e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text12,
										"x-fb-lsd: " + text10
									});
								}
								else
								{
									method_130(int_3, string_1 + Language.GetValue("Get otp " + text7 + "..."));
									string text24 = "";
									if (text7 == "" && text9 != "")
									{
										switch (num9)
										{
										case 0:
											text24 = FB93BDA4.GetOtpFromMail(5, text9, string_3, a8382C3C, "", 90, "", "");
											if (text24 == "fail")
											{
												num5 = num6;
												text24 = "";
											}
											break;
										case 1:
											text24 = FB93BDA4.smethod_0(5, text8, text9);
											break;
										case 2:
											text24 = FB93BDA4.smethod_10(5, text9, 120, "", "");
											break;
										}
									}
									else if (num2 == 37)
									{
										text7 = text7.Replace("+1", "").Replace("+84", "");
										text24 = method_143(null, text3, text7, C5034B95.smethod_0("configCheckpoint").method_2("nudTime") / num6);
									}
									else
									{
										text7 = text7.Replace("+1", "").Replace("+84", "");
										text24 = GClass2.smethod_56(num2, C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + num2), text5, text7, C5034B95.smethod_0("configCheckpoint").method_2("nudTime") / num6);
									}
									if (text24.Trim() != "" && !list3.Contains(text24))
									{
										list3.Add(text24);
										e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%225%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22SUBMIT_CODE%22%2C%22code%22%3A%22" + text24 + "%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
										e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text12,
											"x-fb-lsd: " + text10
										});
										if (e897EAB.Contains("\"errors\""))
										{
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22RESEND_CODE%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
									}
									else if (num5 >= num6)
									{
										e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%222%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22UNSET_CONTACT_POINT%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
										e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text12,
											"x-fb-lsd: " + text10
										});
									}
									else
									{
										e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22RESEND_CODE%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
										e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text12,
											"x-fb-lsd: " + text10
										});
									}
								}
							}
							goto case "email";
						case "UFACContactPointChallengeSetContactPointState":
							while (true)
							{
								if (C5034B95.smethod_0("configCheckpoint").method_3("ckbPhone"))
								{
									if (text3 != "")
									{
										e897EAB = requestXNet_0.method_1("https://free.facebook.com/intl/save_locale/?loc=" + text3 + "&href=https%3A%2F%2Ffree.facebook.com&ls_ref=mobile_suggested_locale_selector", "fb_dtsg=" + text + "&jazoest=25459");
										text3 = "";
									}
									num7++;
									switch (num2)
									{
									case 37:
										if (num7 <= 1)
										{
											text4 = string_2;
											goto IL_107a;
										}
										method_130(int_3, string_1 + Language.GetValue("Không lấy được sđt!"));
										method_134(int_3, "cStatus282", "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
										goto end_IL_000e;
									case 50:
										if (num7 <= num8)
										{
											method_130(int_3, string_1 + Language.GetValue("Đang lấy sđt..."));
											lock (object_9)
											{
												List<string> list4 = C5034B95.smethod_0("configCheckpoint").method_1("txtSdt");
												if (list4.Count == 0)
												{
													Base.smethod_6(bool_9: true);
													method_130(int_3, string_1 + Language.GetValue("Hết sđt!"));
													method_134(int_3, "cStatus282", "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
													goto end_IL_22bf;
												}
												text4 = list4.First();
												list4.Remove(text4);
												C5034B95.smethod_0("configCheckpoint").FD3CCF90("txtSdt", list4);
												C5034B95.smethod_0("configCheckpoint").AEBFED04();
												goto IL_107a;
											}
										}
										method_130(int_3, string_1 + Language.GetValue("Không lấy được sđt!"));
										method_134(int_3, "cStatus282", "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
										goto end_IL_000e;
									default:
										{
											if (num7 <= num8)
											{
												if (text7 != "" || text5 != "")
												{
													GClass2.smethod_59(num2, C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + num2), text7, text5);
												}
												method_130(int_3, string_1 + Language.GetValue("Đang lấy sđt..."));
												text4 = GClass2.D90B63A4(num2, C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + num2), C5034B95.smethod_0("configCheckpoint").method_2("nudLimitTimeGetPhone"), C5034B95.smethod_0("configCheckpoint").BDB80B23("txtServiceId"), C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCustom").Split('*')[0]);
												goto IL_107a;
											}
											method_130(int_3, string_1 + Language.GetValue("Không lấy được sđt!"));
											method_134(int_3, "cStatus282", "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
											goto end_IL_000e;
										}
										IL_107a:
										method_130(int_3, string_1 + "Get phone: " + text4);
										if (text4.Trim('|') == "")
										{
											break;
										}
										if (text4.Split('|').Length > 1)
										{
											text5 = text4.Split('|')[0];
											text7 = text4.Split('|')[1];
										}
										else
										{
											text7 = text4;
										}
										if (new List<int>
										{
											1, 3, 4, 5, 6, 7, 10, 11, 12, 36,
											16, 41, 52, 53, 54, 59, 62
										}.Contains(num2))
										{
											text6 = "US";
											if (text7.StartsWith("+1"))
											{
												text7 = text7.Substring(2);
											}
										}
										else if (new List<int> { 37 }.Contains(num2))
										{
											text6 = "VN";
											if (text7.StartsWith("+855"))
											{
												text6 = "KH";
												text7 = text7.Substring(4);
											}
										}
										else
										{
											text6 = "VN";
											if (text7.StartsWith("+84") || text7.StartsWith("0"))
											{
												text6 = "VN";
												text7 = text7.Replace("+84", "").TrimStart('0');
											}
											else if (text7.StartsWith("+1"))
											{
												text6 = "US";
												text7 = text7.Substring(2);
											}
											else if (text7.StartsWith("+855"))
											{
												text6 = "KH";
												text7 = text7.Substring(4);
											}
											else if (text7.StartsWith("+95"))
											{
												text6 = "MM";
												text7 = text7.Substring(3);
											}
											else if (text7.StartsWith("+7"))
											{
												text6 = "RU";
												text7 = text7.Substring(2);
											}
										}
										goto IL_12cd;
									}
									goto case "email";
								}
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu Add sđt!"));
								method_134(int_3, "cStatus282", "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
								break;
								IL_12cd:
								list3.Clear();
								e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22SET_CONTACT_POINT%22%2C%22contactpoint%22%3A%22" + text7 + "%22%2C%22country_code%22%3A%22" + text6 + "%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=27138611312450305";
								e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
								{
									"x-fb-friendly-name: " + text12,
									"x-fb-lsd: " + text10
								});
								if (e897EAB.Contains("\"errors\""))
								{
									continue;
								}
								goto case "email";
							}
							break;
						case "UFACBotCaptchaState":
							while (true)
							{
								int num11;
								string text13;
								string text14;
								if (C5034B95.smethod_0("configCheckpoint").method_3("ckbCaptcha"))
								{
									num3++;
									if (num3 <= num4)
									{
										method_130(int_3, string_1 + Language.GetValue("Đang giải captcha..."));
										num11 = C5034B95.smethod_0("configCheckpoint").method_2("typeCaptcha");
										text13 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + num11);
										text14 = jObject["data"]!["ufac_client_submit_action"]!["ufac_client"]!["state"]!["captcha_variant"]!.ToString();
										if (!DB81C53D.smethod_2(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4")))
										{
											goto IL_17d5;
										}
										if (text14 == "TEXT_CAPTCHA")
										{
											method_130(int_3, string_1 + "Bypass captcha text...");
											string text15 = jObject["data"]!["ufac_client_submit_action"]!["ufac_client"]!["state"]!["text_captcha_image_url"]!.ToString();
											if (text15 == "")
											{
												continue;
											}
											string text16 = Commom.A794F28D(requestXNet_0.method_4(), text15);
											if (text16 == "")
											{
												continue;
											}
											string text17 = GClass2.smethod_1(num11, text13, text16);
											if (text17 == "")
											{
												continue;
											}
											method_130(int_3, string_1 + "Bypass captcha text: " + text17 + "...");
											string text18 = jObject["data"]!["ufac_client_submit_action"]!["ufac_client"]!["state"]!["captcha_persist_data"]!.ToString();
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22SUBMIT_BOT_CAPTCHA_RESPONSE%22%2C%22bot_captcha_persist_data%22%3A%22" + text18 + "%22%2C%22bot_captcha_response%22%3A%22" + text17 + "%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=9391324407649999";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
										else
										{
											e897EAB = requestXNet_0.E58EB99F("https://free.facebook.com/checkpoint/1501092823525282/?next=https%3A%2F%2Fwww.facebook.com%2F");
											if (!e897EAB.Contains("facebook.com/captcha/tfbimage.php?captcha_challenge_code"))
											{
												goto IL_17d5;
											}
											method_130(int_3, string_1 + "Bypass captcha text...");
											string text19 = "https://free." + Regex.Match(e897EAB, "(facebook.com/captcha/tfbimage.php\\?captcha_challenge_code=.*?)\"").Groups[1].Value.Replace("&amp;", "&");
											if (text19 == "https://free.")
											{
												continue;
											}
											string text20 = Commom.A794F28D(requestXNet_0.method_4(), text19);
											if (text20 == "")
											{
												continue;
											}
											string text21 = GClass2.smethod_1(num11, text13, text20);
											if (text21 == "")
											{
												continue;
											}
											method_130(int_3, string_1 + "Bypass captcha text: " + text21 + "...");
											string value = Regex.Match(e897EAB, "name=\"captcha_persist_data\" value=\"(.*?)\"").Groups[1].Value;
											string value2 = Regex.Match(e897EAB, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
											e4B8F = "captcha_persist_data=" + value + "&captcha_response=" + text21 + "&action_submit_bot_captcha_response=Ti%E1%BA%BFp%20t%E1%BB%A5c&fb_dtsg=" + text + "&jazoest=" + value2;
											e897EAB = method_31(requestXNet_0, "https://free.facebook.com/checkpoint/1501092823525282/submit/?next=https%3A%2F%2Fwww.facebook.com%2F", e4B8F);
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22PROCEED%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=27138611312450305";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
										goto case "email";
									}
									method_130(int_3, string_1 + Language.GetValue("Giải captcha thất bại!"));
									method_134(int_3, "cStatus282", "Captcha-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
									break;
								}
								method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu giải captcha!"));
								method_134(int_3, "cStatus282", "Captcha-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
								break;
								IL_17d5:
								if (!(text14 == "ARKOSE_CAPTCHA"))
								{
									if (text14 == "RECAPTCHA" && num11 == 8 && text13 != "")
									{
										method_130(int_3, string_1 + "Bypass recaptcha...");
										string text22 = GClass2.smethod_0(num11, text13);
										if (text22 == "")
										{
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables=%7B%22designSystem%22%3A%22FDS%22%2C%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + text2 + "%22%2C%22action%22%3A%22PROCEED%22%2C%22caller%22%3Anull%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=27138611312450305";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
										else
										{
											string text23 = jObject["data"]!["ufac_client_submit_action"]!["ufac_client"]!["state"]!["captcha_persist_data"]!.ToString();
											e4B8F = text11 + "fb_api_req_friendly_name=" + text12 + "&variables={\"designSystem\":\"FDS\",\"input\":{\"client_mutation_id\":\"2\",\"actor_id\":\"" + text2 + "\",\"action\":\"SUBMIT_BOT_CAPTCHA_RESPONSE\",\"bot_captcha_persist_data\":\"" + text23 + "\",\"bot_captcha_response\":\"" + text22 + "\",\"caller\":null,\"enrollment_id\":null},\"scale\":1}&doc_id=27138611312450305";
											e897EAB = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", e4B8F, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text12,
												"x-fb-lsd: " + text10
											});
										}
										goto case "email";
									}
									method_130(int_3, string_1 + Language.GetValue("Fb yêu cầu giải captcha!"));
									method_134(int_3, "cStatus282", "Captcha-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
									break;
								}
								method_130(int_3, string_1 + Language.GetValue("Funcaptcha!"));
								method_134(int_3, "cStatus282", "Captcha-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num10 == -1) ? "" : $"-{num10} ngày"), "status282");
								break;
							}
							break;
						case "email":
							if (Environment.TickCount - tickCount < 1200000)
							{
								continue;
							}
							method_130(int_3, string_1 + "Unlock 282 Fail (Timeout)");
							break;
						case "UFACAwaitingReviewState":
							method_130(int_3, string_1 + Language.GetValue("Đợi xét duyệt!"));
							method_134(int_3, "cStatus282", "Đợi xét duyệt (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")", "status282");
							C412B9A5(int_3, 2);
							break;
						}
						break;
					}
					end_IL_000e:;
				}
				catch (Exception)
				{
					continue;
				}
			}
			else
			{
				method_130(int_3, string_1 + "Unlock 282 Fail (Please try again 0)");
			}
			break;
			continue;
			end_IL_22bf:
			break;
		}
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbDoiNgonNguSauKhiUnlock") && text != "")
		{
			requestXNet_0.method_1("https://free.facebook.com/intl/save_locale/?loc=" + C5034B95.smethod_0("configCheckpoint").BDB80B23("cbbLanguageSauKhiUnlock") + "&href=https%3A%2F%2Ffree.facebook.com&ls_ref=mobile_suggested_locale_selector", "fb_dtsg=" + text + "&jazoest=25459");
		}
	}

	private bool B7B2DA04(int A2908805, string string_1, RequestXNet A22DAD24)
	{
		string a088E59D = F6061E95(A2908805, "cUid");
		string c90C3FB = F6061E95(A2908805, "cEmail");
		string string_2 = F6061E95(A2908805, "cPassMail");
		string string_3 = F6061E95(A2908805, "cOAuth2");
		string string_4 = F6061E95(A2908805, "cCookieHotmail");
		string string_5 = F6061E95(A2908805, "cBirthday");
		method_130(A2908805, string_1 + Language.GetValue("Unlock 956 (cha\u0323y â\u0309n)..."));
		var (text, text2, text3) = CommonRequest.smethod_13(A2908805, string_1, A22DAD24, a088E59D, c90C3FB, string_2, string_3, string_4, string_5);
		method_130(A2908805, string_1 + text + "!");
		if (text2 != "")
		{
			E589F93F(A2908805, text2);
		}
		if (text3 != "")
		{
			method_134(A2908805, "cPassword", text3, "pass");
		}
		string text4 = (text2 + text).ToLower();
		if (text4.Contains("live") || text4.Contains("success"))
		{
			C412B9A5(A2908805, 2);
			return true;
		}
		if (text4.Contains("checkpoint"))
		{
			C412B9A5(A2908805, 1);
		}
		return false;
	}

	private int method_32(int int_3, string string_1, Chrome CEB22027, GClass4 gclass4_0, string C60A622C)
	{
		bool flag = gclass4_0.method_3("ckbBio");
		bool flag2 = gclass4_0.method_3("ckbWork");
		int int_4 = gclass4_0.method_2("cbbIfHaveWork");
		bool flag3 = gclass4_0.method_3("ckbHighSchool");
		int f000E1BD = gclass4_0.method_2("cbbIfHaveHighSchool");
		bool flag4 = gclass4_0.method_3("ckbCollege");
		int c623D73F = gclass4_0.method_2("cbbIfHaveCollege");
		bool flag5 = gclass4_0.method_3("ckbCurrentCity");
		bool flag6 = gclass4_0.method_3("ckbHometown");
		bool flag7 = gclass4_0.method_3("ckbRelationship");
		bool flag8 = gclass4_0.method_3("ckbGender");
		bool flag9 = gclass4_0.method_3("ckbBirthday");
		bool flag10 = gclass4_0.method_3("ckbNickname");
		List<string> c8199D0D = gclass4_0.method_1("txtBio", gclass4_0.method_2("typeSplitBio"));
		List<string> c8199D0D2 = gclass4_0.method_1("lstWork");
		List<string> c8199D0D3 = gclass4_0.method_1("lstHighSchool");
		List<string> c8199D0D4 = gclass4_0.method_1("lstCollege");
		List<string> c8199D0D5 = gclass4_0.method_1("lstCurrentCity");
		List<string> c8199D0D6 = gclass4_0.method_1("lstHometown");
		List<string> c8199D0D7 = gclass4_0.method_1("lstNickname");
		string text = gclass4_0.BDB80B23("cbbRelationship");
		string text2 = gclass4_0.BDB80B23("cbbGender");
		List<string> c8199D0D8 = gclass4_0.method_1("lstDay");
		List<string> c8199D0D9 = gclass4_0.method_1("lstMonth");
		List<string> c8199D0D10 = gclass4_0.method_1("lstYear");
		string text3 = string_1 + Language.GetValue("Đang") + " " + C60A622C + ": ";
		method_130(int_3, text3 + Language.GetValue("Đang chạy..."));
		// Resize browser (500x700) for reliable selector matching on www.facebook.com
		CEB22027.method_53();
		CEB22027.F8091028(1.5);
		// Ensure we are on www domain for profile editing
		CEB22027.method_69(1);
		CEB22027.F8091028(1.0);
		if (flag)
		{
			method_130(int_3, text3 + "Bio...");
			ProfileInfoHub.UpdateBio(CEB22027, c8199D0D.smethod_8());
		}
		if (flag2)
		{
			method_130(int_3, text3 + "Work...");
			if (!ProfileInfoHub.UpdateWork(CEB22027, c8199D0D2.smethod_8(), int_4))
			{
				CEB22027.method_141(c8199D0D2.smethod_8(), int_4);
			}
		}
		if (flag3)
		{
			method_130(int_3, text3 + "High School...");
			if (!ProfileInfoHub.UpdateHighSchool(CEB22027, c8199D0D3.smethod_8(), f000E1BD))
			{
				CEB22027.method_142(c8199D0D3.smethod_8(), f000E1BD);
			}
		}
		if (flag4)
		{
			method_130(int_3, text3 + "College...");
			if (!ProfileInfoHub.UpdateCollege(CEB22027, c8199D0D4.smethod_8(), c623D73F))
			{
				CEB22027.B516A6BD(c8199D0D4.smethod_8(), c623D73F);
			}
		}
		if (flag5)
		{
			method_130(int_3, text3 + "Current City...");
			if (!ProfileInfoHub.UpdateCurrentCity(CEB22027, c8199D0D5.smethod_8()))
			{
				CEB22027.D60F4C83(c8199D0D5.smethod_8());
			}
		}
		if (flag6)
		{
			method_130(int_3, text3 + "Hometown...");
			if (!ProfileInfoHub.UpdateHometown(CEB22027, c8199D0D6.smethod_8()))
			{
				CEB22027.method_144(c8199D0D6.smethod_8());
			}
		}
		if (flag7)
		{
			method_130(int_3, text3 + "Relationship...");
			string relVal = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
			if (!ProfileInfoHub.UpdateRelationship(CEB22027, relVal))
			{
				CEB22027.method_149(relVal);
			}
		}
		if (flag9)
		{
			string text4 = c8199D0D8.smethod_8();
			string text5 = c8199D0D9.smethod_8();
			string text6 = c8199D0D10.smethod_8();
			if (!string.IsNullOrEmpty(text4) && !string.IsNullOrEmpty(text5) && !string.IsNullOrEmpty(text6))
			{
				method_130(int_3, text3 + "Birthday...");
				if (!ProfileInfoHub.UpdateBirthday(CEB22027, text4, text5, text6))
				{
					CEB22027.DC0DE395(text4, text5, text6);
				}
			}
		}
		if (flag8)
		{
			method_130(int_3, text3 + "Gender...");
			string genderVal = text2.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
			if (!ProfileInfoHub.UpdateGender(CEB22027, genderVal))
			{
				CEB22027.method_150(genderVal);
			}
		}
		if (flag10)
		{
			method_130(int_3, text3 + "Nickname...");
			string string_2 = c8199D0D7.smethod_8();
			if (!ProfileInfoHub.UpdateNickname(CEB22027, string_2))
			{
				CEB22027.method_98(string_2);
			}
		}
		CEB22027.method_54();
		return 1;
	}

	private GClass4 method_33(int int_3, string string_1, Chrome chrome_0, GClass4 F82BF7AE, string A28E401B, string string_2)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		string text = F82BF7AE.BDB80B23("txtPathFolder");
		bool flag = F82BF7AE.method_3("ckbXoaAnhDaDung");
		bool flag2 = F82BF7AE.method_3("ckbThemKhungAvatar");
		bool flag3 = F82BF7AE.method_3("ckbSkipIfHave");
		bool flag4 = F82BF7AE.method_3("ckbUuTienMbasic");
		bool flag5 = false;
		if (!Directory.Exists(text) || Commom.smethod_76(text).Count == 0)
		{
			gClass.method_4("error", "Empty Image)");
		}
		else
		{
			lock (dictionary_22)
			{
				if (!dictionary_22.ContainsKey(string_2))
				{
					dictionary_22.Add(string_2, Commom.smethod_76(text));
				}
			}
			if (dictionary_22[string_2].Count == 0)
			{
				gClass.method_4("error", "Empty Image)");
			}
			else
			{
				string text2 = string_1 + Language.GetValue("Đang") + " " + A28E401B + ": ";
				method_130(int_3, text2 + "Check avatar...");
				if (flag3 && CommonRequest.smethod_6(chrome_0.B4208531) == "1")
				{
					gClass.method_4("success", true);
				}
				else
				{
					method_130(int_3, text2 + Language.GetValue("Đang chạy..."));
					try
					{
						// Ensure standard window size (500x700) and www domain for modern Meta Comet profile layout
						chrome_0.method_53();
						chrome_0.F8091028(1.5);
						chrome_0.method_69(1);
						chrome_0.F8091028(1.0);
						string text3 = "";
						if (flag)
						{
							lock (dictionary_22[string_2])
							{
								while (string.IsNullOrEmpty(text3) && dictionary_22[string_2].Count != 0)
								{
									text3 = dictionary_22[string_2].OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
									dictionary_22[string_2].Remove(text3);
									if (!File.Exists(text3))
									{
										text3 = "";
									}
								}
							}
						}
						else
						{
							while (string.IsNullOrEmpty(text3) && dictionary_22[string_2].Count != 0)
							{
								text3 = dictionary_22[string_2].OrderBy((string C7A9E50E) => Guid.NewGuid()).FirstOrDefault();
								if (!File.Exists(text3))
								{
									dictionary_22[string_2].Remove(text3);
									text3 = "";
								}
							}
						}
						if (string.IsNullOrEmpty(text3))
						{
							gClass.method_4("error", "Empty Image)");
						}
						else
						{
							bool flagSkipCrop = F82BF7AE.method_3("ckbBoQuaCatAnh", true);
							bool flag6 = ProfileInfoHub.UploadAvatar(chrome_0, text3, flag3, flag4, flagSkipCrop, (msg) => method_130(int_3, text2 + msg));
							gClass.method_4("success", flag6);
							if (flag6)
							{
								if (flag)
								{
									Commom.E10A40B6(text3);
								}
								if (flag2)
								{
									method_130(int_3, text2 + "Meta đã khai tử khung avatar, bỏ qua an toàn...");
								}
							}
							else
							{
								gClass.method_4("error", "Upload failed");
							}
						}
					}
					catch (Exception ex)
					{
						gClass.method_4("error", ex.Message);
					}
				}
			}
		}
		if (flag5)
		{
			chrome_0.method_54();
		}
		return gClass;
	}

	private int method_34(ref string B588C8AD, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string BB111796)
	{
		int result = 2;
		string text = F6061E95(int_3, "cPassword");
		if (text == "")
		{
			B588C8AD = "Fail (No Pass)";
		}
		else
		{
			string text2 = string_1 + Language.GetValue("Đang") + " " + BB111796 + ": ";
			method_130(int_3, text2 + Language.GetValue("Đang chạy..."));
			switch (gclass4_0.method_2("cbbTuyChon"))
			{
			case 0:
				B588C8AD = "Enable fail";
				try
				{
					string text7 = "";
					string text8 = "";
					for (int j = 0; j < 4; j++)
					{
						string json2 = chrome_0.method_131(text7);
						JObject jObject2 = JObject.Parse(json2);
						if (!Convert.ToBoolean(jObject2["success"]))
						{
							string text9 = jObject2["error"]!.ToString();
							if (text9 == "continue" || text9 == "block")
							{
								continue;
							}
							if (!text9.StartsWith("otp"))
							{
								break;
							}
							if (text9.Contains("|"))
							{
								string text10 = text9.Split('|')[1];
								if (chrome_0.F8A3B83F.Substring(chrome_0.F8A3B83F.IndexOf('@') - 1, 3) != text10.Substring(text10.IndexOf('@') - 1, 3))
								{
									B588C8AD = "Enable fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
									break;
								}
							}
							method_130(int_3, text2 + "Get otp...");
							text7 = FB93BDA4.GetOtpFromMail(1, chrome_0.F8A3B83F, chrome_0.ACBD1889, chrome_0.A70B4E96, chrome_0.A990D886, 60, "", text8);
							if (!(text7 == "fail"))
							{
								if (!(text7 == ""))
								{
									if (text7 == text8)
									{
										text7 = "";
										continue;
									}
									text8 = text7;
									j--;
									continue;
								}
								B588C8AD = "Enable fail (" + Language.GetValue("Không lấy được otp!") + ")";
								break;
							}
							B588C8AD = "Enable fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
							break;
						}
						string string_2 = (chrome_0.A1BF36A2 = jObject2["fa2"]!.ToString().Replace(" ", ""));
						method_134(int_3, "cFa2", string_2, "fa2");
						B588C8AD = "Enable success";
						break;
					}
				}
				catch (Exception)
				{
				}
				break;
			case 1:
				B588C8AD = "Disable fail";
				try
				{
					string text3 = "";
					string text4 = "";
					for (int i = 0; i < 4; i++)
					{
						string json = chrome_0.A799E836(text3);
						JObject jObject = JObject.Parse(json);
						if (!Convert.ToBoolean(jObject["success"]))
						{
							string text5 = jObject["error"]!.ToString();
							if (text5 == "continue" || text5 == "block")
							{
								continue;
							}
							if (!text5.StartsWith("otp"))
							{
								break;
							}
							if (text5.Contains("|"))
							{
								string text6 = text5.Split('|')[1];
								if (chrome_0.F8A3B83F.Substring(chrome_0.F8A3B83F.IndexOf('@') - 1, 3) != text6.Substring(text6.IndexOf('@') - 1, 3))
								{
									B588C8AD = "Disable fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
									break;
								}
							}
							method_130(int_3, text2 + "Get otp...");
							text3 = FB93BDA4.GetOtpFromMail(1, chrome_0.F8A3B83F, chrome_0.ACBD1889, chrome_0.A70B4E96, chrome_0.A990D886, 60, "", text4);
							if (!(text3 == "fail"))
							{
								if (!(text3 == ""))
								{
									if (text3 == text4)
									{
										text3 = "";
										continue;
									}
									text4 = text3;
									i--;
									continue;
								}
								B588C8AD = "Disable fail (" + Language.GetValue("Không lấy được otp!") + ")";
								break;
							}
							B588C8AD = "Disable fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
							break;
						}
						B588C8AD = "Disable success";
						method_134(int_3, "cFa2", "", "fa2");
						break;
					}
				}
				catch (Exception)
				{
				}
				break;
			}
		}
		return result;
	}

	private int D017409D(ref string string_1, int int_3, string string_2, Chrome F50C9484, GClass4 A72F8F2D, string EDAE65BC, string DDB9809B)
	{
		string_1 = "Fail";
		string text = A72F8F2D.BDB80B23("txtPathFolder").Trim().Trim('"', '\'');
		bool flag = A72F8F2D.method_3("ckbXoaAnhDaDung");
		bool flag2 = A72F8F2D.method_3("ckbSkipIfHave");
		bool flag3 = A72F8F2D.method_3("ckbUuTienMbasic");
		bool flagNoFeed = A72F8F2D.method_3("ckbKhongDangFeed", true);
		bool flagSkipCrop = A72F8F2D.method_3("ckbBoQuaCanChinh", true);
		int delayFrom = A72F8F2D.method_2("nudDelayFrom", 3);
		int delayTo = A72F8F2D.method_2("nudDelayTo", 5);
		bool flag4 = false;
		string text2 = "";

		bool isDirectFile = File.Exists(text);
		if (!isDirectFile && (!Directory.Exists(text) || Commom.smethod_76(text).Count == 0))
		{
			string_1 = "Fail (Empty Image)";
		}
		else
		{
			if (isDirectFile)
			{
				text2 = text;
			}
			else
			{
				lock (FE314201)
				{
					if (!FE314201.ContainsKey(DDB9809B))
					{
						FE314201.Add(DDB9809B, Commom.smethod_76(text));
					}
				}
				if (FE314201[DDB9809B].Count == 0)
				{
					string_1 = "Fail (Empty Image)";
				}
				else if (flag)
				{
					lock (FE314201[DDB9809B])
					{
						while (string.IsNullOrEmpty(text2) && FE314201[DDB9809B].Count != 0)
						{
							text2 = FE314201[DDB9809B].OrderBy((string DE9EC9A3) => Guid.NewGuid()).FirstOrDefault();
							FE314201[DDB9809B].Remove(text2);
							if (!File.Exists(text2))
							{
								text2 = "";
							}
						}
					}
				}
				else
				{
					while (string.IsNullOrEmpty(text2) && FE314201[DDB9809B].Count != 0)
					{
						text2 = FE314201[DDB9809B].OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
						if (!File.Exists(text2))
						{
							FE314201[DDB9809B].Remove(text2);
							text2 = "";
						}
					}
				}
			}

			if (string.IsNullOrEmpty(text2))
			{
				string_1 = "Fail (Empty Image)";
			}
			else
			{
				string text3 = string_2 + Language.GetValue("Đang") + " " + EDAE65BC + ": ";
				method_130(int_3, text3 + Language.GetValue("Đang chạy..."));
				try
				{
					while (true)
					{
						if (!flag3)
						{
							F50C9484.method_12("https://www.facebook.com/me");
						}
						else
						{
							F50C9484.method_12("https://mbasic.facebook.com/profile.php");
						}
						F50C9484.F8091028(2.0);
						int num = F50C9484.method_125();
						if (num == 1)
						{
							continue;
						}
						if (new List<int> { -3, -2, -1, 2 }.Contains(num))
						{
							break;
						}
						int num2 = F50C9484.method_61();
						if (num2 == 1)
						{
							if (!flag4)
							{
								flag4 = true;
								F50C9484.method_53();
								if (F50C9484.method_49() == 1)
								{
									continue;
								}
							}
							F50C9484.method_60();
						}
						else if (F50C9484.GetURL().Contains("facebook.com/si/actor_experience/actor_gateway"))
						{
							F50C9484.EC9B94B0();
							continue;
						}

						// Luồng hiện đại Comet WWW / Mobile qua ProfileInfoHub trực tiếp
						try
						{
							bool isUpOk = ProfileInfoHub.UploadCover(F50C9484, text2, flag2, flag3, flagNoFeed, flagSkipCrop, (msg) => method_130(int_3, text3 + msg));
							string_1 = isUpOk ? "Success" : "Fail";
							if (isUpOk)
							{
								if (flag && !string.IsNullOrEmpty(text2) && File.Exists(text2))
								{
									Commom.E10A40B6(text2);
								}
								int waitSec = (delayTo > delayFrom && delayFrom > 0) ? new Random().Next(delayFrom, delayTo + 1) : delayFrom;
								if (waitSec > 0)
								{
									method_130(int_3, text3 + $"Chờ {waitSec}s...");
									F50C9484.F8091028(waitSec);
								}
							}
						}
						catch (Exception ex)
						{
							string_1 = "Fail (" + ex.Message + ")";
						}
						break;
					}
				}
				catch
				{
				}
			}
		}
		if (string_1 == "Success" && flag && !string.IsNullOrEmpty(text2) && File.Exists(text2))
		{
			Commom.E10A40B6(text2);
		}
		if (flag4)
		{
			F50C9484.method_54();
		}
		return 1;
	}

	private int method_35(ref string string_1, ref string string_2, int int_3, string string_3, Chrome chrome_0, GClass4 gclass4_0, string string_4, string F623EEA6)
	{
		chrome_0.method_49();
		bool flag = gclass4_0.method_3("ckbAddMail");
		int num = 6;
		int num2 = gclass4_0.method_2("cbbTypeMail");
		int num3 = gclass4_0.method_2("nudDelayOtp", 120);
		string input = "";
		string text = "";
		bool flag2;
		int num4;
		string text4;
		bool flag5;
		string text2;
		string text23;
		string text12;
		string text13;
		string text22;
		int num7;
		int num8;
		GClass0 gClass;
		int num10;
		switch (num2)
		{
		case 1:
		{
			List<string> list6 = gclass4_0.method_1("lstMailDomain");
			if (list6.Count == 0)
			{
				break;
			}
			input = list6.smethod_8();
			goto default;
		}
		case 2:
		{
			List<string> list5 = gclass4_0.method_1("lstDomain");
			if (list5.Count == 0)
			{
				break;
			}
			text = list5.smethod_8();
			goto default;
		}
		case 3:
		{
			List<string> list4 = gclass4_0.method_1("lstDomainUnlimitMail");
			if (list4.Count == 0)
			{
				list4.Add("otpgmail.com");
			}
			text = list4.smethod_8();
			goto default;
		}
		case 4:
			text = chrome_0.RunCodeChrome("GetDomainMailTula()");
			goto default;
		case 5:
			text = "hotmail9.com";
			goto default;
		case 6:
		{
			List<string> list3 = gclass4_0.method_1("lstDomain1secmail");
			if (list3.Count == 0)
			{
				list3.Add("1secmail.com");
			}
			text = list3.smethod_8();
			goto default;
		}
		case 7:
		{
			List<string> list2 = gclass4_0.method_1("lstDomainMailtm");
			if (list2.Count == 0)
			{
				list2.Add("starmail.net");
			}
			text = list2.smethod_8();
			goto default;
		}
		case 8:
		{
			List<string> list = gclass4_0.method_1("lstDomainDonglaomail");
			if (list.Count == 0)
			{
				list.Add("cristionel.com");
			}
			text = list.smethod_8();
			goto default;
		}
		default:
			{
				flag2 = gclass4_0.method_3("ckbXoaMailCu");
				num4 = 3;
				text4 = gclass4_0.BDB80B23("txtNewPass");
				flag5 = gclass4_0.method_3("ckbAnMail");
				F6061E95(int_3, "cId");
				text2 = F6061E95(int_3, "cEmail").ToLower().Trim();
				text23 = chrome_0.FB94939A();
				if (flag)
				{
					method_130(int_3, string_3 + Language.GetValue("Đang") + " Add mail...");
					text12 = "";
					text13 = "";
					text22 = "";
					switch (num2)
					{
					case 0:
						break;
					case 1:
						goto IL_038f;
					case 3:
						goto IL_0431;
					case 5:
						goto IL_046b;
					default:
						goto IL_04a2;
					case 7:
						goto IL_04ad;
					}
					lock (A91273B2)
					{
						while (text12 == "")
						{
							if (A91273B2[F623EEA6].Count != 0)
							{
								int index = 0;
								string[] array = A91273B2[F623EEA6][0].Split('|');
								if (array.Length > 1)
								{
									text12 = array[0].ToLower().Trim();
									text13 = array[1].Trim();
									if (array.Length > 3)
									{
										text22 = array[2].Trim() + "|" + array[3].Trim();
									}
								}
								A91273B2[F623EEA6].RemoveAt(index);
								B72D90A4(A91273B2, "lstHotmail");
								continue;
							}
							string_1 = "Fail (Hết mail)";
							Base.smethod_6(bool_9: true);
							goto end_IL_0053;
						}
					}
					goto IL_04e4;
				}
				goto IL_105a;
			}
			IL_105a:
			if (flag2)
			{
				if (text2 == "")
				{
					break;
				}
				string text3 = F6061E95(int_3, "cPassword");
				if (text3 == "")
				{
					string_2 = "Fail (No pass)";
					break;
				}
				method_130(int_3, string_3 + Language.GetValue("Đang") + " Remove mail...");
				if (num4 == 0)
				{
					string json = chrome_0.method_99(text3, text2);
					JObject jObject = JObject.Parse(json);
					if (Convert.ToBoolean(jObject["success"]))
					{
						string_2 = "Success";
						break;
					}
					string_2 = "Fail";
					switch (jObject["error"]!.ToString())
					{
					case "cant_remove_mail":
						string_2 = string_2 + " (" + Language.GetValue("Không thể xóa mail") + ")";
						break;
					case "checkpoint":
						string_2 += " (Checkpoint)";
						E589F93F(int_3, "Checkpoint");
						break;
					case "changed_pass":
						string_2 += " (Sai pass)";
						E589F93F(int_3, "Changed pass");
						break;
					}
				}
				else if (num4 == 1)
				{
					string string_5 = text4.smethod_1(2);
					if (text4.Trim() == "")
					{
						string_5 = DateTime.Now.ToString("yyMMdd") + "changepass" + Commom.B820DC86(3, "0");
					}
					if (!method_38(int_3, chrome_0, ref string_2, text2, text3, string_5))
					{
						break;
					}
				}
				else
				{
					if (num4 == 2)
					{
						chrome_0.method_49();
						chrome_0.method_53();
						while (true)
						{
							chrome_0.method_12("https://www.facebook.com/settings?tab=account&section=email");
							chrome_0.F8091028(2.0);
							chrome_0.method_60();
							chrome_0.ChromeDriver_0.SwitchTo().Frame(0);
							if (text2 != "")
							{
								int num5 = Convert.ToInt32(chrome_0.method_14("return document.querySelectorAll('[ajaxify*=\"/settings/account/email/primary\"]').length").ToString());
								for (int i = 0; i < num5; i++)
								{
									string value = text2.Replace("@", "%40");
									string text5 = chrome_0.method_14("return document.querySelectorAll('[ajaxify*=\"/settings/account/email/primary\"]')[" + i + "].getAttribute('ajaxify')").ToString();
									if (!text5.Contains(value))
									{
										continue;
									}
									chrome_0.method_18("[ajaxify*=\"/settings/account/email/primary\"]|" + i);
									chrome_0.F8091028(1.0);
									if (chrome_0.D7A424AE("[type=\"password\"]", 5.0))
									{
										chrome_0.method_22("[type=\"password\"]", text3);
										chrome_0.F8091028(1.0);
										chrome_0.F217FA96("[type=\"password\"]");
										chrome_0.F8091028(3.0);
										try
										{
											chrome_0.ChromeDriver_0.SwitchTo().Frame(0);
										}
										catch
										{
										}
									}
								}
							}
							int num6 = 0;
							string text6;
							for (int j = 0; j < 10; j++)
							{
								text6 = chrome_0.method_15(5.0, new List<string> { ".SettingsEmailPendingCancel", "[ajaxify*=\"/email/remove\"]", ".fsm.fwn.fcg" });
								switch (text6)
								{
								case "[ajaxify*=\"/email/remove\"]":
									break;
								case ".fsm.fwn.fcg":
									goto IL_13a9;
								case ".SettingsEmailPendingCancel":
									goto IL_143d;
								default:
									goto IL_1598;
								}
								chrome_0.method_34(text6);
								chrome_0.F8091028(1.0);
								chrome_0.method_17(text6);
								chrome_0.F8091028(1.0);
								if (chrome_0.D7A424AE("#ajax_password", 5.0))
								{
									if (num6 > 2 || chrome_0.D7A424AE("[role=\"dialog\"] .uiBoxRed"))
									{
										goto IL_1580;
									}
									num6++;
									chrome_0.method_22("#ajax_password", text3);
									chrome_0.F8091028(1.0);
									chrome_0.F217FA96("#ajax_password");
								}
								chrome_0.F8091028(1.0);
								continue;
								IL_13a9:
								if (chrome_0.method_30(text6) > 2)
								{
									chrome_0.method_14("document.querySelectorAll('.fsm.fwn.fcg')[1].parentNode.querySelectorAll('a')[1].click()");
									chrome_0.F8091028(1.0);
									if (chrome_0.D7A424AE("#ajax_password", 5.0))
									{
										chrome_0.method_22("#ajax_password", text3);
										chrome_0.F8091028(1.0);
										chrome_0.F217FA96("#ajax_password");
									}
									chrome_0.F8091028(1.0);
								}
							}
							break;
							IL_143d:
							chrome_0.method_34(text6);
							chrome_0.F8091028(1.0);
							chrome_0.method_17(text6);
							chrome_0.F8091028(1.0);
						}
						goto IL_1598;
					}
					bool flag3 = false;
					try
					{
						string text7 = "";
						string text8 = "";
						for (int k = 0; k < 4; k++)
						{
							string json2 = chrome_0.method_134(text2, text7);
							JObject jObject2 = JObject.Parse(json2);
							if (Convert.ToBoolean(jObject2["success"]))
							{
								chrome_0.method_13();
								k = 0;
								continue;
							}
							string text9 = jObject2["error"]!.ToString();
							if (!(text9 == "not_found_email"))
							{
								if (text9 == "continue" || text9 == "block")
								{
									continue;
								}
								if (!text9.StartsWith("otp"))
								{
									break;
								}
								if (text9.Contains("|"))
								{
									string text10 = text9.Split('|')[1];
									if (chrome_0.F8A3B83F.Substring(chrome_0.F8A3B83F.IndexOf('@') - 1, 3) == text10.Substring(text10.IndexOf('@') - 1, 3))
									{
										method_130(int_3, string_3 + "Get otp...");
										text7 = FB93BDA4.GetOtpFromMail(1, chrome_0.F8A3B83F, chrome_0.ACBD1889, chrome_0.A70B4E96, chrome_0.A990D886, 60, "", text8);
									}
									else
									{
										if (!(chrome_0.C72CBD25.Substring(chrome_0.C72CBD25.IndexOf('@') - 1, 3) == text10.Substring(text10.IndexOf('@') - 1, 3)))
										{
											MatchCollection matchCollection = Regex.Matches(chrome_0.AFACE5B4(), "{\"contact_point_type\":\"EMAIL\",\"normalized_contact_point\":\"(.*?)\"");
											foreach (Match item in matchCollection)
											{
												string text11 = item.Groups[1].Value.Replace("\\u0040", "@");
												if (!(text11.Substring(text11.IndexOf('@') - 1, 3) == text10.Substring(text10.IndexOf('@') - 1, 3)))
												{
													continue;
												}
												method_130(int_3, string_3 + "Get otp...");
												text7 = FB93BDA4.GetOtpFromMail(1, text11, "", "", "", 60, "", text8);
												if (text7 == "empty_pass_email")
												{
													continue;
												}
												goto IL_1898;
											}
											string_2 = "Fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
											goto end_IL_0053;
										}
										method_130(int_3, string_3 + "Get otp...");
										text7 = FB93BDA4.GetOtpFromMail(1, chrome_0.C72CBD25, chrome_0.String_3, chrome_0.F2B1E915, "", 60, "", text8);
									}
								}
								else
								{
									method_130(int_3, string_3 + "Get otp...");
									text7 = FB93BDA4.GetOtpFromMail(1, chrome_0.F8A3B83F, chrome_0.ACBD1889, chrome_0.A70B4E96, chrome_0.A990D886, 60, "", text8);
								}
								goto IL_1898;
							}
							flag3 = true;
							break;
							IL_1898:
							if (!(text7 == "fail"))
							{
								if (!(text7 == ""))
								{
									if (text7 == text8)
									{
										text7 = "";
										continue;
									}
									text8 = text7;
									k--;
									continue;
								}
								string_2 = "Fail (" + Language.GetValue("Không lấy được otp!") + ")";
								goto end_IL_0053;
							}
							string_2 = "Fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
							goto end_IL_0053;
						}
					}
					catch (Exception)
					{
					}
					string_2 = (flag3 ? "Success" : "Fail");
				}
			}
			goto IL_1960;
			IL_04ad:
			text12 = FB93BDA4.A18013B7(text);
			text13 = Commom.B820DC86(8, "a_A_0");
			if (FB93BDA4.CreateMailtm(text12, text13) != "true")
			{
				string_1 = "Fail (Không thê\u0309 ta\u0323o hotmail9)";
				break;
			}
			goto IL_04e4;
			IL_046b:
			text12 = FB93BDA4.A18013B7(text);
			text13 = Commom.B820DC86(8, "a_A_0");
			if (MaxCareLibPro.Hotmail9.CreateHotmail9(text12, text13) != "true")
			{
				string_1 = "Fail (Không thê\u0309 ta\u0323o hotmail9)";
				break;
			}
			goto IL_04e4;
			IL_04a2:
			text12 = FB93BDA4.A18013B7(text);
			goto IL_04e4;
			IL_0431:
			text12 = FB93BDA4.A18013B7(text);
			text13 = Commom.B820DC86(8, "a_A_0");
			if (FB93BDA4.EF2C4EBE(text12, text13) != "true")
			{
				string_1 = "Fail (Không thê\u0309 ta\u0323o unlimit email)";
				break;
			}
			goto IL_04e4;
			IL_04e4:
			num7 = 0;
			num8 = 3;
			gClass = new GClass0(chrome_0.method_40(), SetupFolder.GetUseragentIphone(), chrome_0.A3A32284, chrome_0.Int32_1);
			if (num == 0)
			{
				if (!chrome_0.method_76(text12))
				{
					string_1 = "Fail";
					break;
				}
				if (!chrome_0.method_137(text12))
				{
					break;
				}
			}
			else if (num == 5)
			{
				if (!chrome_0.method_77(text12))
				{
					string_1 = "Fail";
					break;
				}
				if (!chrome_0.method_137(text12))
				{
					break;
				}
			}
			else if (num == 3)
			{
				string text14 = F6061E95(int_3, "cPassword");
				if (text14 == "")
				{
					string_1 = "Fail (No pass)";
					break;
				}
				chrome_0.method_49();
				chrome_0.method_12("https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22profile%22%2C%22screen-id%22%3A%22[%5C%22tl0zxv%3A0%5C%22%2Cnull]%22%7D&path=%2Fcontacts%2Fmanagement%2F");
				chrome_0.F8091028(2.0);
				if (chrome_0.method_14("var isOk=0; document.querySelectorAll('[data-nt=\"NT:DECOR\"]>div').forEach(e => {if(e.innerText!='' && e.innerText.toLowerCase().includes('email')) {isOk=1;e.click();return;}}); return isOk+'';").ToString() == "0")
				{
					break;
				}
				if (chrome_0.D7A424AE("[name=\"email\"]", 30.0))
				{
					chrome_0.F8091028(1.0);
					chrome_0.method_22("[name=\"email\"]", text12);
					chrome_0.F8091028(1.0);
					if (chrome_0.D7A424AE("[name=\"save_password\"]"))
					{
						chrome_0.method_22("[name=\"save_password\"]", text14);
						chrome_0.F8091028(1.0);
					}
					chrome_0.method_18("[name=\"save\"]");
					chrome_0.method_33("[name=\"email\"]", 60);
					chrome_0.F8091028(2.0);
					if (chrome_0.D7A424AE("[name=\"pass\"]"))
					{
						string_1 = "Fail (Sai pass)";
						E589F93F(int_3, "Changed pass");
						break;
					}
				}
				string text15 = chrome_0.C604C58C("https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22settings%22%7D&path=%2Fcontacts%2Fmanagement%2F");
				if (!text15.ToLower().Contains(text12.smethod_3()))
				{
					string_1 = "Fail";
					break;
				}
			}
			else if (num == 1)
			{
				string text16 = F6061E95(int_3, "cPassword");
				if (text16 == "")
				{
					string_1 = "Fail (No pass)";
					break;
				}
				string eC2BF = text4.smethod_1(1);
				if (text4.Trim() == "")
				{
					eC2BF = DateTime.Now.ToString("yyMMdd") + "changepass" + Commom.B820DC86(3, "0");
				}
				if (!method_37(int_3, chrome_0, ref string_1, text12, text16, eC2BF))
				{
					break;
				}
			}
			else if (num == 4)
			{
				string text19 = DD3E9B2E(int_3, string_3, chrome_0, text12);
				if (text19 != "true")
				{
					string_1 = "Fail (" + text19 + ")";
					break;
				}
			}
			else if (num == 6)
			{
				string text19 = DD3E9B2E(int_3, string_3, chrome_0, text12);
				if (text19 != "true")
				{
					string_1 = "Fail (" + text19 + ")";
					break;
				}
			}
			else if (num == 7)
			{
				string text20 = AF81341C(gClass, chrome_0.C234EEAA, text12);
				if (text20 != "true")
				{
					string_1 = "Fail (" + text20 + ")";
					break;
				}
			}
			while (true)
			{
				method_130(int_3, string_3 + Language.GetValue("Đang") + " Get otp...");
				if (num7 < num8)
				{
					num7++;
					string text21 = "";
					text21 = num2 switch
					{
						2 => FB93BDA4.smethod_10(0, text12, num3, text23, ""), 
						1 => FB93BDA4.smethod_0(0, input, text12, text23, num3), 
						_ => FB93BDA4.GetOtpFromMail(0, text12, text13, text22, "", num3, text23, ""), 
					};
					method_130(int_3, string_3 + Language.GetValue("Đang") + " Get otp: " + text21);
					if (!(text21 == "not connect") && !(text21 == "fail"))
					{
						if (text21.Trim() == "")
						{
							switch (num)
							{
							case 1:
								chrome_0.method_18("[name=\"resend_code\"]");
								continue;
							case 4:
							{
								chrome_0.method_12("https://mbasic.facebook.com/entercode.php?cp=" + text12.smethod_3() + "&source_verified=m_settings&redirect_to_unified_contact_setting_page");
								string string_6 = "a[href*=\"/entercode.php\"]";
								if (chrome_0.D7A424AE(string_6, 30.0))
								{
									chrome_0.F8091028(2.0);
									chrome_0.method_21(string_6);
								}
								continue;
							}
							case 6:
							{
								string text25 = DD3E9B2E(int_3, string_3, chrome_0, text12);
								if (!(text25 != "true"))
								{
									continue;
								}
								string_1 = "Fail (" + text25 + ")";
								break;
							}
							case 7:
							{
								string text24 = AF81341C(gClass, chrome_0.C234EEAA, text12);
								if (!(text24 != "true"))
								{
									continue;
								}
								string_1 = "Fail (" + text24 + ")";
								break;
							}
							default:
								if (chrome_0.method_137(text12))
								{
									continue;
								}
								break;
							}
							break;
						}
						method_130(int_3, string_3 + Language.GetValue("Đang") + " Submit otp...");
						string text26 = "https://www.facebook.com/";
						if (num == 1 && flag2 && num4 == 1)
						{
							string text27 = "";
							text27 = ((!Commom.smethod_45(text21)) ? Regex.Match(text21, "c=(\\d+)&").Groups[1].Value : text21);
							chrome_0.method_22("[name=\"code\"]", text27);
							chrome_0.F8091028(1.0);
							chrome_0.method_18("button[name=\"submit[Confirm]\"]");
							chrome_0.F8091028(1.0);
							flag2 = false;
						}
						else
						{
							switch (num)
							{
							case 7:
							{
								string text29 = "";
								AF81341C(string_3: (!Commom.smethod_45(text21)) ? Regex.Match(text21, "c=(\\d+)&").Groups[1].Value : text21, B011781B: gClass, string_1: chrome_0.C234EEAA, string_2: text12);
								break;
							}
							case 6:
							{
								string text28 = "";
								text28 = ((!Commom.smethod_45(text21)) ? Regex.Match(text21, "c=(\\d+)&").Groups[1].Value : text21);
								chrome_0.method_136(text12, text28);
								break;
							}
							default:
							{
								if (Commom.smethod_45(text21))
								{
									if (!chrome_0.D7A424AE("[action^=\"/entercode.php\"] [name=\"code\"]"))
									{
										chrome_0.method_12("https://mbasic.facebook.com/entercode.php?cp=" + text12.smethod_3() + "&source_verified=m_settings&redirect_to_unified_contact_setting_page");
									}
									chrome_0.method_22("[action^=\"/entercode.php\"] [name=\"code\"]", text21);
									chrome_0.F8091028(1.0);
									chrome_0.method_18("[action^=\"/entercode.php\"] [type=\"submit\"]");
									break;
								}
								if (chrome_0.method_61() == 3)
								{
									text26 = "https://mbasic.facebook.com/";
								}
								text21 = text21.Replace("https://www.facebook.com/", text26);
								string input2 = chrome_0.C604C58C(text21);
								string value2 = Regex.Match(input2, "href=\"(/confirmcontact.php.*?)\"").Groups[1].Value;
								if (value2 != "")
								{
									value2 = value2.Replace("&amp;", "&");
									input2 = chrome_0.C604C58C(text26.TrimEnd('/') + value2);
								}
								break;
							}
							}
						}
						bool flag4;
						if (!(flag4 = chrome_0.B13A9E19(AE8E2B8E: true).Contains(text12)))
						{
							flag4 = chrome_0.method_71().Contains(text12);
						}
						if (!flag4)
						{
							int num9 = chrome_0.method_125();
							if (new List<int> { -3, -2, -1, 2 }.Contains(num9))
							{
								break;
							}
							if (num9 == 1)
							{
								flag4 = chrome_0.method_71().Contains(text12);
							}
							if (!flag4)
							{
								continue;
							}
						}
						goto IL_0ecf;
					}
					string_1 = "Fail (Cannot connect Mail)";
					break;
				}
				string_1 = "Fail (" + Language.GetValue("Không lấy được otp!") + ")";
				break;
			}
			break;
			IL_038f:
			text12 = Commom.EB835717((from CDB10B99 in SetupFolder.smethod_4()
				orderby Guid.NewGuid()
				select CDB10B99).First() + (from string_0 in SetupFolder.smethod_5()
				orderby Guid.NewGuid()
				select string_0).First()).Replace(" ", "").ToLower() + Commom.B820DC86(6, "0") + Regex.Match(input, "@\\w+.\\w+").Value;
			goto IL_04e4;
			IL_1598:
			chrome_0.method_54();
			goto IL_1960;
			IL_0ecf:
			method_130(int_3, string_3 + Language.GetValue("Đang") + " Submit otp ok...");
			switch (num)
			{
			case 3:
				chrome_0.method_12("https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22profile%22%2C%22screen-id%22%3A%22[%5C%22__ntid%3Aenp3zo%3A0__%5C%22%2Cnull]%22%7D&path=%2Fcontacts%2Fmanagement%2F");
				chrome_0.F8091028(2.0);
				if (chrome_0.method_21("//div[text()=\"" + text12 + "\"]"))
				{
					string text30 = "button[data-nt=\"FB:FDS_TETRA_BUTTON\"]";
					if (chrome_0.D7A424AE(text30, 30.0))
					{
						chrome_0.method_18(text30);
						chrome_0.method_33(text30, 30);
						chrome_0.F8091028(2.0);
					}
				}
				break;
			case 7:
				method_36(gClass, text12);
				break;
			}
			string_1 = "Success";
			method_134(int_3, "cEmail", text12, "email");
			if (!Base.bool_0 || !text12.Contains("@otpgmail.com") || !(text13 == ""))
			{
			}
			method_134(int_3, "cPassMail", text13, "passmail");
			method_134(int_3, "cOAuth2", text22, "backup");
			B183E907(int_3, "cMailRecovery", "");
			B183E907(int_3, "cPassMailRecovery", "");
			text2 = text12;
			chrome_0.C72CBD25 = chrome_0.F8A3B83F;
			chrome_0.String_3 = chrome_0.ACBD1889;
			chrome_0.F2B1E915 = chrome_0.A70B4E96;
			chrome_0.F8A3B83F = text12;
			chrome_0.ACBD1889 = text13;
			chrome_0.A70B4E96 = text22;
			goto IL_105a;
			IL_1580:
			string_2 = "Fail (Sai pass)";
			E589F93F(int_3, "Changed pass");
			break;
			IL_1960:
			if (!flag5)
			{
				break;
			}
			method_130(int_3, string_3 + Language.GetValue("Đang") + " Hide mail...");
			chrome_0.method_12("https://m.facebook.com/settings/email/");
			chrome_0.F8091028(2.0);
			num10 = chrome_0.method_30("a[data-store*=\"privacy\"]");
			for (int l = 0; l < num10; l++)
			{
				if (chrome_0.method_14($"return document.querySelectorAll('a[data-store*=\"privacy\"]')[{l}].getAttribute('data-store').includes('286958161406148')").ToString().ToLower() == "false")
				{
					chrome_0.method_21("a[data-store*=\"privacy\"]|" + l);
					chrome_0.F8091028(2.0);
					chrome_0.method_21("label[data-store*=\"286958161406148\"]");
					chrome_0.F8091028(1.0);
				}
			}
			break;
			end_IL_0053:
			break;
		}
		return 1;
	}

	private string DD3E9B2E(int DA0ACCAB, string EC08F61E, Chrome chrome_0, string string_1)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		for (int i = 0; i < 4; i++)
		{
			string json = chrome_0.method_135(string_1, text);
			JObject jObject = JObject.Parse(json);
			if (!Convert.ToBoolean(jObject["success"]))
			{
				text3 = jObject["error"]!.ToString();
				if (text3 == "continue" || text3 == "block")
				{
					continue;
				}
				if (!text3.StartsWith("otp"))
				{
					break;
				}
				if (!(chrome_0.F8A3B83F == ""))
				{
					if (text3.Contains("|"))
					{
						string text4 = text3.Split('|')[1];
						if (chrome_0.F8A3B83F.Substring(chrome_0.F8A3B83F.IndexOf('@') - 1, 3) != text4.Substring(text4.IndexOf('@') - 1, 3))
						{
							return Language.GetValue("Fb bắt xác minh email không có trên tool");
						}
					}
					method_130(DA0ACCAB, EC08F61E + "Get otp...");
					text = FB93BDA4.GetOtpFromMail(1, chrome_0.F8A3B83F, chrome_0.ACBD1889, chrome_0.A70B4E96, chrome_0.A990D886, 60, "", text2);
					if (!(text == "fail"))
					{
						if (!(text == ""))
						{
							if (text == text2)
							{
								text = "";
								continue;
							}
							text2 = text;
							i--;
							continue;
						}
						return Language.GetValue("Không lấy được otp!");
					}
					return Language.GetValue("Không thể kết nối mail!");
				}
				return Language.GetValue("Fb bắt xác minh email không có trên tool");
			}
			return "true";
		}
		if (text3 == "block")
		{
			return text3;
		}
		return "false";
	}

	private string AF81341C(GClass0 B011781B, string string_1, string string_2, string string_3 = "")
	{
		int num = 10;
		string e897EAB;
		while (true)
		{
			e897EAB = B011781B.B2157B0A("https://m.facebook.com/login_alerts/add/email/");
			string text = Commom.F914B80B(e897EAB, "name=\"fb_dtsg\" value=\"(.*?)\"");
			string text2 = Commom.F914B80B(e897EAB, "name=\"jazoest\" value=\"(.*?)\"");
			if (!(text == ""))
			{
				e897EAB = B011781B.B930129D("https://m.facebook.com/login_alerts/add/email/write/", "jazoest=" + text2 + "&fb_dtsg=" + text + "&new_email=" + string_2);
				if (e897EAB.Contains("/login_alerts/add/email/write/"))
				{
					return "wrong_email";
				}
				if (!e897EAB.Contains("facebook.com/password/reauth"))
				{
					break;
				}
				if (string_1 == "")
				{
					return "empty_pass";
				}
				string d1B1F = Commom.F914B80B(e897EAB, "action=\"(.*?)\"");
				text = Commom.F914B80B(e897EAB, "name=\"fb_dtsg\" value=\"(.*?)\"");
				text2 = Commom.F914B80B(e897EAB, "name=\"jazoest\" value=\"(.*?)\"");
				e897EAB = B011781B.B930129D(d1B1F, "jazoest=" + text2 + "&fb_dtsg=" + text + "&pass=" + string_1);
				if (e897EAB.Contains("facebook.com/password/reauth"))
				{
					return "wrong_pass";
				}
			}
			else
			{
				num--;
				if (num <= 0)
				{
					return "false";
				}
				B011781B.method_0(SetupFolder.GetUseragentIphone());
			}
		}
		if (e897EAB.Contains("/login_alerts/add/confirm/write/"))
		{
			if (string_3 == "")
			{
				return "true";
			}
			string text = Commom.F914B80B(e897EAB, "name=\"fb_dtsg\" value=\"(.*?)\"");
			string text2 = Commom.F914B80B(e897EAB, "name=\"jazoest\" value=\"(.*?)\"");
			e897EAB = B011781B.B930129D("https://m.facebook.com/login_alerts/add/confirm/write/", "jazoest=" + text2 + "&fb_dtsg=" + text + "&code=" + string_3 + "&contact_point=" + string_2);
			if (e897EAB.Contains("/login_alerts/settings/?source=security_settings_page"))
			{
				e897EAB = B011781B.B930129D("https://m.facebook.com/a/settings/email/?paipv=0", "jazoest=" + text2 + "&fb_dtsg=" + text + "&email=" + string_2 + "&add_email=1&qp_id=&c=&qp_h=&source_added=m_settings&save=Add+Email");
				return "true";
			}
			if (e897EAB.Contains("/login_alerts/add/confirm/write/"))
			{
				return "wrong_otp";
			}
		}
		return "false";
	}

	private bool method_36(GClass0 E400D2B8, string AC2907AB)
	{
		string string_ = E400D2B8.B2157B0A("https://m.facebook.com/settings/email/?primary_email");
		string_ = Commom.smethod_53(string_);
		string text = Commom.F914B80B(string_, AC2907AB + "<input type=\"radio\" name=\"email\" value=\"(\\d+)\"");
		if (text == "")
		{
			return false;
		}
		string text2 = Commom.F914B80B(string_, "name=\"fb_dtsg\" value=\"(.*?)\"");
		string text3 = Commom.F914B80B(string_, "name=\"jazoest\" value=\"(.*?)\"");
		string_ = E400D2B8.B930129D("https://m.facebook.com/a/settings/email/?refid=74", "jazoest=" + text3 + "&fb_dtsg=" + text2 + "&email=" + text + "&change_primary=1");
		return true;
	}

	private bool method_37(int B036481B, Chrome E5053B9E, ref string string_1, string string_2, string AF90E621, string EC2BF091)
	{
		E5053B9E.method_53();
		E5053B9E.method_49();
		try
		{
			int num;
			do
			{
				E5053B9E.method_12("https://facebook.com/hacked");
				E5053B9E.F8091028(2.0);
				num = E5053B9E.method_125();
			}
			while (num == 1);
			if (!new List<int> { -3, -2, -1, 2 }.Contains(num))
			{
				bool flag = false;
				int tickCount = Environment.TickCount;
				int num2 = 45;
				while (true)
				{
					string text = E5053B9E.method_15(0.0, new List<string> { "[value=\"someone_accessed\"]", "[name=\"submit[Get Started]\"],[aria-label=\"Get started\"]", "[name=\"submit[Go to News Feed]\"]", "button[name=\"submit[Continue]\"],[aria-label=\"Continue\"]", "[aria-label=\"Enter new password\" i] input", "[aria-label=\"Skip\"]", "[name=\"submit[Add New Email]\"]", "[name=\"new_cp\"]", "[name=\"code\"]" });
					string text2 = text;
					string text3 = text2;
					uint num3 = AFAE75A0.smethod_0(text3);
					if (num3 > 1360473598)
					{
						if (num3 <= 2427039148u)
						{
							if (num3 != 2005644923)
							{
								if (num3 != 2427039148u || !(text3 == "button[name=\"submit[Continue]\"],[aria-label=\"Continue\"]"))
								{
									goto IL_02f9;
								}
								if (E5053B9E.D7A424AE("[name=\"password_new\"]"))
								{
									E5053B9E.method_22("[name=\"password_new\"]", EC2BF091);
									E5053B9E.F8091028(1.0);
									method_134(B036481B, "cPassword", EC2BF091, "pass");
									E5053B9E.C234EEAA = EC2BF091;
									if (E5053B9E.D7A424AE("[name=\"password_confirm\"]"))
									{
										E5053B9E.method_22("[name=\"password_confirm\"]", EC2BF091);
										E5053B9E.F8091028(1.0);
									}
									if (E5053B9E.D7A424AE("[name=\"password_old\"]"))
									{
										if (flag && E5053B9E.method_14("return document.querySelector('[name=\"password_old\"]').value;").ToString() == "")
										{
											method_134(B036481B, "cPassword", AF90E621, "pass");
											E5053B9E.C234EEAA = AF90E621;
											string_1 = "Fail (Sai pass)";
											E589F93F(B036481B, "Changed pass");
											break;
										}
										flag = true;
										E5053B9E.method_22("[name=\"password_old\"]", AF90E621);
										E5053B9E.F8091028(1.0);
									}
									E5053B9E.method_18(text);
								}
								else if (E5053B9E.D7A424AE("[name=\"selected[]\"]"))
								{
									E5053B9E.method_14("document.querySelectorAll('[name=\"selected[]\"]').forEach(e => {if(e.value.includes('@') || e.value.startsWith('+')) e.click(); })");
									E5053B9E.F8091028(1.0);
									E5053B9E.method_18(text);
								}
								else
								{
									if (E5053B9E.method_14("return document.querySelector('form[action=\"/checkpoint/flow\"]').innerText.includes('\\n1\\n')").ToString().ToLower() == "true" && E5053B9E.method_14("return document.querySelector('form[action=\"/checkpoint/flow\"]').innerText.includes('email')").ToString().ToLower() == "false")
									{
										string_1 = "Không có tùy chọn Add mail";
										break;
									}
									E5053B9E.method_18(text);
								}
							}
							else
							{
								if (!(text3 == "[value=\"someone_accessed\"]"))
								{
									goto IL_02f9;
								}
								E5053B9E.method_21(text);
								E5053B9E.F8091028(1.0);
								E5053B9E.method_18("[name=\"confirmed\"],[aria-label=\"Continue\"]");
							}
						}
						else
						{
							if (num3 == 2675892175u)
							{
								if (text3 == "[name=\"submit[Go to News Feed]\"]")
								{
									string_1 = "Không có tùy chọn Add mail";
									break;
								}
								goto IL_02f9;
							}
							if (num3 != 3077872650u)
							{
								if (num3 != 3959105503u || !(text3 == "[name=\"new_cp\"]"))
								{
									goto IL_02f9;
								}
								E5053B9E.method_22(text, string_2);
								E5053B9E.F8091028(1.0);
								E5053B9E.method_18("button[name=\"submit[Add]\"]");
							}
							else
							{
								if (!(text3 == "[name=\"submit[Add New Email]\"]"))
								{
									goto IL_02f9;
								}
								E5053B9E.method_18(text);
							}
						}
					}
					else
					{
						if (num3 > 437511382)
						{
							if (num3 != 866624054)
							{
								if (num3 == 1360473598 && text3 == "[name=\"code\"]")
								{
									return true;
								}
							}
							else if (text3 == "[name=\"submit[Get Started]\"],[aria-label=\"Get started\"]")
							{
								E5053B9E.method_21(text);
								E5053B9E.F8091028(2.0);
								E5053B9E.method_33("[name=\"submit[Continue]\"][disabled],[aria-label=\"Continue\"][disabled]", 60);
								goto IL_0323;
							}
							goto IL_02f9;
						}
						if (num3 != 122195741)
						{
							if (num3 != 437511382 || !(text3 == "[aria-label=\"Enter new password\" i] input"))
							{
								goto IL_02f9;
							}
							E5053B9E.method_22(text, EC2BF091);
							E5053B9E.F8091028(1.0);
							method_134(B036481B, "cPassword", EC2BF091, "pass");
							E5053B9E.C234EEAA = EC2BF091;
							E5053B9E.method_18("[aria-label=\"Save changes\"]");
							E5053B9E.F8091028(2.0);
							E5053B9E.method_33("[aria-label=\"Save changes\"][disabled]", 60);
						}
						else if (!(text3 == "[aria-label=\"Skip\"]"))
						{
							goto IL_02f9;
						}
					}
					goto IL_0323;
					IL_0323:
					if (!Base.smethod_5() && !E5053B9E.CD930D04() && Environment.TickCount - tickCount <= num2 * 1000)
					{
						E5053B9E.F8091028(2.0);
						continue;
					}
					string_1 = "Fail";
					break;
					IL_02f9:
					string text4 = E5053B9E.GetURL();
					if (text4.Contains("828281030927956") || text4.Contains("1501092823525282"))
					{
						string_1 = "Fail (Checkpoint)";
						E589F93F(B036481B, "Checkpoint");
						break;
					}
					goto IL_0323;
				}
			}
		}
		catch (Exception)
		{
			goto IL_0567;
		}
		goto IL_056d;
		IL_0567:
		E5053B9E.method_54();
		goto IL_056d;
		IL_056d:
		return false;
	}

	private bool method_38(int int_3, Chrome chrome_0, ref string D73724A5, string string_1, string string_2, string string_3)
	{
		chrome_0.method_53();
		chrome_0.method_49();
		try
		{
			int num;
			do
			{
				chrome_0.method_12("https://facebook.com/hacked");
				chrome_0.F8091028(2.0);
				num = chrome_0.method_125();
			}
			while (num == 1);
			if (!new List<int> { -3, -2, -1, 2 }.Contains(num))
			{
				bool flag = false;
				bool flag2 = false;
				int tickCount = Environment.TickCount;
				int num2 = 45;
				while (true)
				{
					string text = chrome_0.method_15(0.0, new List<string> { "[value=\"someone_accessed\"]", "[name=\"submit[Get Started]\"]", "[name=\"submit[Go to News Feed]\"]", "button[name=\"submit[Continue]\"]", "[name=\"new_cp\"]", "[name=\"code\"]" });
					switch (text)
					{
					case "[value=\"someone_accessed\"]":
						chrome_0.method_21(text);
						chrome_0.F8091028(1.0);
						chrome_0.method_18("[name=\"confirmed\"],[aria-label=\"Continue\"]");
						goto IL_00b3;
					default:
					{
						string text2 = chrome_0.GetURL();
						if (text2.Contains("828281030927956") || text2.Contains("1501092823525282"))
						{
							D73724A5 = "Fail (Checkpoint)";
							E589F93F(int_3, "Checkpoint");
							break;
						}
						goto IL_00b3;
					}
					case "button[name=\"submit[Continue]\"]":
						if (chrome_0.D7A424AE("[name=\"password_new\"]"))
						{
							chrome_0.method_22("[name=\"password_new\"]", string_3);
							chrome_0.F8091028(1.0);
							method_134(int_3, "cPassword", string_3, "pass");
							chrome_0.C234EEAA = string_3;
							if (chrome_0.D7A424AE("[name=\"password_confirm\"]"))
							{
								chrome_0.method_22("[name=\"password_confirm\"]", string_3);
								chrome_0.F8091028(1.0);
							}
							if (chrome_0.D7A424AE("[name=\"password_old\"]"))
							{
								if (flag2 && chrome_0.method_14("return document.querySelector('[name=\"password_old\"]').value;").ToString() == "")
								{
									method_134(int_3, "cPassword", string_2, "pass");
									chrome_0.C234EEAA = string_2;
									D73724A5 = "Fail (Sai pass)";
									E589F93F(int_3, "Changed pass");
									break;
								}
								flag2 = true;
								chrome_0.method_22("[name=\"password_old\"]", string_2);
								chrome_0.F8091028(1.0);
							}
							chrome_0.method_18(text);
						}
						else if (chrome_0.D7A424AE("[name=\"selected[]\"]"))
						{
							flag = true;
							chrome_0.method_14("var email = '" + string_1 + "'; document.querySelectorAll('[name=\"selected[]\"]').forEach(e => {if((e.value.includes('@') && !e.value.includes(email)) || !isNaN(e.value)) e.click(); })");
							chrome_0.F8091028(1.0);
							chrome_0.method_18(text);
						}
						else
						{
							if (chrome_0.method_14("return document.querySelector('form[action=\"/checkpoint/flow\"]').innerText.includes('\\n1\\n')").ToString().ToLower() == "true" && chrome_0.method_14("return document.querySelector('form[action=\"/checkpoint/flow\"]').innerText.includes('email')").ToString().ToLower() == "false")
							{
								D73724A5 = "Không có tùy chọn Xóa mail";
								break;
							}
							chrome_0.method_18(text);
						}
						goto IL_00b3;
					case "[name=\"submit[Get Started]\"]":
						chrome_0.method_21(text);
						chrome_0.F8091028(2.0);
						chrome_0.method_33("[name=\"submit[Continue]\"][disabled]", 60);
						goto IL_00b3;
					case "[name=\"submit[Go to News Feed]\"]":
						{
							if (flag)
							{
								D73724A5 = "Success";
								return true;
							}
							D73724A5 = "Fail";
							break;
						}
						IL_00b3:
						if (!Base.smethod_5() && !chrome_0.CD930D04() && Environment.TickCount - tickCount <= num2 * 1000)
						{
							goto IL_00c9;
						}
						D73724A5 = "Fail";
						break;
					}
					break;
					IL_00c9:
					chrome_0.F8091028(2.0);
				}
			}
		}
		catch (Exception)
		{
			goto IL_03dd;
		}
		goto IL_03e3;
		IL_03dd:
		chrome_0.method_54();
		goto IL_03e3;
		IL_03e3:
		return false;
	}

	private bool method_39(int B4BC3F8E, Chrome CF042DA5, ref string string_1, string D59A8486, string string_2)
	{
		CF042DA5.method_49();
		CF042DA5.method_53();
		try
		{
			int num;
			do
			{
				CF042DA5.method_12("https://facebook.com/hacked");
				CF042DA5.F8091028(2.0);
				num = CF042DA5.method_125();
			}
			while (num == 1);
			if (!new List<int> { -3, -2, -1, 2 }.Contains(num))
			{
				bool flag = false;
				int tickCount = Environment.TickCount;
				int num2 = 45;
				while (true)
				{
					string text = CF042DA5.method_15(0.0, new List<string> { "[value=\"someone_accessed\"]", "[name=\"submit[Get Started]\"]", "[name=\"submit[Go to News Feed]\"]", "button[name=\"submit[Continue]\"]" });
					switch (text)
					{
					case "[value=\"someone_accessed\"]":
						CF042DA5.method_21(text);
						CF042DA5.F8091028(1.0);
						CF042DA5.method_18("[name=\"confirmed\"],[aria-label=\"Continue\"]");
						goto IL_00b0;
					default:
					{
						string text2 = CF042DA5.GetURL();
						if (!text2.Contains("facebook.com/secured_action/block/"))
						{
							if (text2.Contains("1501092823525282") || text2.Contains("828281030927956") || text2.Contains("465803052217681") || (text2.Contains("facebook.com/nt/screen/?params=") && text2.Contains("checkpoint")))
							{
								string_1 = "Fail (Checkpoint)";
								break;
							}
							goto IL_00b0;
						}
						string_1 = "Fail (Block)";
						break;
					}
					case "button[name=\"submit[Continue]\"]":
						if (CF042DA5.D7A424AE("[name=\"password_new\"]"))
						{
							CF042DA5.method_22("[name=\"password_new\"]", string_2);
							CF042DA5.F8091028(1.0);
							string_1 = "Success";
							if (CF042DA5.D7A424AE("[name=\"password_confirm\"]"))
							{
								CF042DA5.method_22("[name=\"password_confirm\"]", string_2);
								CF042DA5.F8091028(1.0);
							}
							if (CF042DA5.D7A424AE("[name=\"password_old\"]"))
							{
								if (flag && CF042DA5.method_14("return document.querySelector('[name=\"password_old\"]').value;").ToString() == "")
								{
									string_1 = "Fail (Sai pass)";
									E589F93F(B4BC3F8E, "Changed pass");
									break;
								}
								flag = true;
								CF042DA5.method_22("[name=\"password_old\"]", D59A8486);
								CF042DA5.F8091028(1.0);
							}
							CF042DA5.method_18(text);
						}
						else
						{
							CF042DA5.method_18(text);
						}
						goto IL_00b0;
					case "[name=\"submit[Get Started]\"]":
						CF042DA5.method_21(text);
						CF042DA5.F8091028(2.0);
						CF042DA5.method_33("[name=\"submit[Continue]\"][disabled]", 60);
						goto IL_00b0;
					case "[name=\"submit[Go to News Feed]\"]":
						break;
						IL_00b0:
						if (!Base.smethod_5() && !CF042DA5.CD930D04() && Environment.TickCount - tickCount <= num2 * 1000)
						{
							goto IL_00c5;
						}
						string_1 = "Fail";
						break;
					}
					break;
					IL_00c5:
					CF042DA5.F8091028(2.0);
				}
			}
		}
		catch (Exception)
		{
		}
		if (string_1 == "Success")
		{
			method_134(B4BC3F8E, "cPassword", string_2, "pass");
			CF042DA5.C234EEAA = string_2;
		}
		CF042DA5.method_54();
		return false;
	}

	private int method_40(ref string D72C270F, int BEA14AB3, string CE12EF90, Chrome E9879629, GClass4 gclass4_0, string string_1)
	{
		string text = gclass4_0.BDB80B23("txtNewPass");
		int num = gclass4_0.method_2("cbbTypeDoiMatKhau");
		string string_2 = F6061E95(BEA14AB3, "cId");
		string text2 = F6061E95(BEA14AB3, "cPassword");
		if (text2 == "")
		{
			D72C270F = "Fail (No pass)";
		}
		else
		{
			string text3 = CE12EF90 + Language.GetValue("Đang") + " " + string_1 + ": ";
			string text4 = text.smethod_1(2);
			if (text.Trim() == "")
			{
				text4 = DateTime.Now.ToString("yyMMdd") + "changepass" + Commom.B820DC86(3, "0");
			}
			D72C270F = "Fail";
			switch (num)
			{
			case 0:
			{
				method_130(BEA14AB3, CE12EF90 + Language.GetValue("Đang") + " " + string_1 + " (Accounts Center)...");
				string paramJson = "[{\"name\":\"password\", \"value\":\"" + text2.Replace("\"", "\\\"") + "\"},{\"name\":\"new_password\", \"value\":\"" + text4.Replace("\"", "\\\"") + "\"}]";
				string acRes = AccountsCenterHub.Execute(E9879629, "ChangePass", paramJson);
				if (AccountsCenterHub.IsSuccess(acRes))
				{
					D72C270F = "Success";
					F0A81525(string_2, "pass", BEA14AB3, "cPassword", text4);
					E9879629.C234EEAA = text4;
					E9879629.F8091028(2.0);
					break;
				}
				if (acRes == "wrong_password")
				{
					D72C270F = "Fail (Sai pass)";
					E589F93F(BEA14AB3, "Changed pass");
					break;
				}
				string string_3 = "https://m.facebook.com/nt/screen/?params={\"module\":\"password_change\",\"initial_screen_id\":\"[\\\"security_checkup_start_screen\\\",null]\",\"walkthrough_modules\":[\"password_change\",\"two_factor\",\"login_alerts\"],\"source\":\"unknown\",\"entry_point\":\"topic_selection\"}&path=security-checkup/modules/&state";
				E9879629.method_12(string_3);
				E9879629.F8091028(2.0);
				int num2 = 0;
				int tickCount = Environment.TickCount;
				do
				{
					string text5 = E9879629.method_15(0.0, new List<string> { "[name=\"password_old\"]", "[type=\"submit\"]", "[data-nt=\"FB:FDS_TETRA_BUTTON\"]", "[href=\"/\"]" });
					if (!(text5 == "[name=\"password_old\"]"))
					{
						if (text5 == "[type=\"submit\"]" || text5 == "[data-nt=\"FB:FDS_TETRA_BUTTON\"]")
						{
							if (num2 > 0)
							{
								D72C270F = "Success";
								F0A81525(string_2, "pass", BEA14AB3, "cPassword", text4);
								E9879629.C234EEAA = text4;
								E9879629.F8091028(2.0);
								break;
							}
							E9879629.method_17(text5);
						}
						else if (text5 == "[href=\"/\"]")
						{
							D72C270F = "Fail";
							break;
						}
					}
					else
					{
						if (num2 > 0)
						{
							if (E9879629.method_14("return document.querySelector('[id*=\"old_password_error_id\"]').innerText;").ToString() != "")
							{
								D72C270F = "Fail (Sai pass)";
								E589F93F(BEA14AB3, "Changed pass");
								break;
							}
							continue;
						}
						num2++;
						E9879629.method_22("[name=\"password_old\"]", text2);
						E9879629.F8091028(1.0);
						E9879629.method_22("[name=\"password_new\"]", text4);
						E9879629.F8091028(1.0);
						E9879629.method_22("[name=\"password_confirm\"]", text4);
						E9879629.F8091028(1.0);
						for (int j = 0; j < 10; j++)
						{
							E9879629.method_21("[type=\"submit\"]");
							if (E9879629.method_33("[name=\"password_old\"]", 5))
							{
								break;
							}
						}
					}
					E9879629.F8091028(1.0);
				}
				while (Environment.TickCount - tickCount < 30000 && !Base.smethod_5() && !E9879629.CD930D04());
				break;
			}
			case 1:
				method_130(BEA14AB3, CE12EF90 + Language.GetValue("Đang") + " " + string_1 + "...");
				method_39(BEA14AB3, E9879629, ref D72C270F, text2, text4);
				break;
			case 2:
				method_130(BEA14AB3, CE12EF90 + Language.GetValue("Đang") + " " + string_1 + " (cha\u0323y â\u0309n)...");
				try
				{
					string text6 = "";
					string text7 = "";
					for (int k = 0; k < 4; k++)
					{
						string json = E9879629.method_132(text4, text6);
						JObject jObject = JObject.Parse(json);
						if (!Convert.ToBoolean(jObject["success"]))
						{
							string text8 = jObject["error"]!.ToString();
							if (text8 == "continue" || text8 == "block")
							{
								continue;
							}
							if (!text8.StartsWith("otp"))
							{
								break;
							}
							if (text8.Contains("|"))
							{
								string text9 = text8.Split('|')[1];
								if (E9879629.F8A3B83F.Substring(E9879629.F8A3B83F.IndexOf('@') - 1, 3) != text9.Substring(text9.IndexOf('@') - 1, 3))
								{
									D72C270F = "Fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
									break;
								}
							}
							method_130(BEA14AB3, text3 + "Get otp...");
							text6 = FB93BDA4.GetOtpFromMail(1, E9879629.F8A3B83F, E9879629.ACBD1889, E9879629.A70B4E96, E9879629.A990D886, 60, "", text7);
							if (!(text6 == "fail"))
							{
								if (!(text6 == ""))
								{
									if (text6 == text7)
									{
										text6 = "";
										continue;
									}
									text7 = text6;
									k--;
									continue;
								}
								D72C270F = "Fail (" + Language.GetValue("Không lấy được otp!") + ")";
								break;
							}
							D72C270F = "Fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
							break;
						}
						D72C270F = "Success";
						F0A81525(string_2, "pass", BEA14AB3, "cPassword", text4);
						E9879629.C234EEAA = text4;
						E9879629.F8091028(2.0);
						break;
					}
				}
				catch (Exception)
				{
				}
				break;
			case 3:
			{
				method_130(BEA14AB3, CE12EF90 + Language.GetValue("Đang") + " " + string_1 + " (cha\u0323y â\u0309n)...");
				for (int i = 0; i < 2; i++)
				{
					GClass4 gClass = CommonRequest.C180C594(E9879629.B4208531, E9879629.C234EEAA, E9879629.A1BF36A2, text4, E9879629.A3A32284, E9879629.Int32_1);
					if (!gClass.method_3("success"))
					{
						if (!(gClass.BDB80B23("error") == "try_again"))
						{
							if (gClass.BDB80B23("error") != "")
							{
								D72C270F = "Fail (" + gClass.BDB80B23("error") + ")";
							}
							break;
						}
						continue;
					}
					D72C270F = "Success";
					F0A81525(string_2, "pass", BEA14AB3, "cPassword", text4);
					E9879629.C234EEAA = text4;
					break;
				}
				break;
			}
			}
		}
		return 1;
	}

	private int method_41(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string DCA26017)
	{
		string string_2 = gclass4_0.BDB80B23("cbbLanguage").Split('|')[0];
		method_130(int_3, string_1 + Language.GetValue("Đang") + " " + DCA26017 + "...");
		chrome_0.method_49(string_2);
		return 1;
	}

	private int method_42(ref string AD3ACABD, int int_3, string string_1, Chrome DD19ED37, GClass4 gclass4_0, string string_2)
	{
		method_130(int_3, string_1 + Language.GetValue("Đang") + " " + string_2 + "...");
		string text = string_1 + Language.GetValue("Đang") + " " + string_2 + ": ";
		int num = gclass4_0.method_2("cbbFacebookWeb");
		int num2 = 0;
		string text2 = F6061E95(int_3, "cPassword");
		try
		{
			// Uu tien AccountsCenterHub hien dai cho WWW Facebook
			try
			{
				string acRes = AccountsCenterHub.Execute(DD19ED37, "DeletePhone", "{\"password\":\"" + (text2 ?? "").Replace("\"", "\\\"") + "\"}");
				if (AccountsCenterHub.IsSuccess(acRes))
				{
					AD3ACABD = "Success";
					method_134(int_3, "cPhone", "", "phone");
					return 1;
				}
			}
			catch { }
			int num3;
			switch (num)
			{
			case 0:
			{
				DD19ED37.method_53();
				DD19ED37.method_12("https://www.facebook.com/update_security_info.php");
				DD19ED37.F8091028(1.0);
				int num4 = 0;
				while (true)
				{
					string text3 = DD19ED37.method_15(10.0, new List<string> { "[name=\"pass\"]", "[name=\"mirror_submit\"]" });
					if (text3 == "[name=\"pass\"]")
					{
						if (num4 <= 2 && !DD19ED37.D7A424AE(".uiBoxRed"))
						{
							num4++;
							DD19ED37.method_22("[name=\"pass\"]", text2);
							DD19ED37.F8091028(1.0);
							DD19ED37.F217FA96("[name=\"pass\"]");
							DD19ED37.F8091028(1.0);
							continue;
						}
						num2 = 2;
						break;
					}
					if (text3 == "[name=\"mirror_submit\"]")
					{
						int num5 = Convert.ToInt32(DD19ED37.method_14("return document.querySelectorAll('#mirror_section_phone .uiCloseButton.uiCloseButtonSmall').length").ToString());
						for (int i = 0; i < num5; i++)
						{
							DD19ED37.method_19("#mirror_section_phone .uiCloseButton.uiCloseButtonSmall");
							DD19ED37.F8091028(1.0);
							if (!DD19ED37.D7A424AE("#pop_content [name=\"confirm\"]", 10.0))
							{
								continue;
							}
							DD19ED37.method_17("#pop_content [name=\"confirm\"]");
							for (int j = 0; j < 10; j++)
							{
								if (Convert.ToInt32(DD19ED37.method_14("return document.querySelectorAll('#mirror_section_phone .uiCloseButton.uiCloseButtonSmall').length").ToString()) == num5 - i - 1)
								{
									break;
								}
								DD19ED37.F8091028(1.0);
							}
							DD19ED37.F8091028(1.0);
						}
						DD19ED37.method_12("https://www.facebook.com/settings?tab=mobile");
						DD19ED37.F8091028(1.0);
						DD19ED37.method_60();
						for (int k = 0; k < 10; k++)
						{
							if (k != 0)
							{
								DD19ED37.method_13();
							}
							try
							{
								DD19ED37.ChromeDriver_0.SwitchTo().Frame(0);
							}
							catch
							{
							}
							text3 = DD19ED37.method_15(5.0, new List<string> { "[style=\"padding-bottom: 1%;\"] span a", "[class*=\"fbSettingsListItemContent\"] a" });
							if (!(text3 == ""))
							{
								if (text3 == "[style=\"padding-bottom: 1%;\"] span a")
								{
									DD19ED37.method_17(text3);
									DD19ED37.F8091028(1.0);
									if (!DD19ED37.D7A424AE(".uiInputLabel.clearfix label", 10.0))
									{
										continue;
									}
									DD19ED37.method_14("document.querySelector('.uiInputLabel.clearfix label').click()");
									DD19ED37.F8091028(1.0);
									DD19ED37.method_18("[class*=\"layerConfirm uiOverlayButton\"]");
									DD19ED37.F8091028(3.0);
									switch (DD19ED37.method_15(10.0, new List<string> { "[name=\"ajax_password\"]", "[id*=\"fetchstream\"] a", "[class*=\"selected uiButton uiButtonSpecial\"]", "[style=\"padding-bottom: 1%;\"] span a" }))
									{
									case "[class*=\"selected uiButton uiButtonSpecial\"]":
										num2 = 1;
										break;
									case "[id*=\"fetchstream\"] a":
										DD19ED37.method_18("[id*=\"fetchstream\"] a");
										DD19ED37.F8091028(1.0);
										if (DD19ED37.D7A424AE("[class*=\"uiOverlayFooter\"] [type=\"submit\"]", 10.0))
										{
											DD19ED37.method_18("[class*=\"uiOverlayFooter\"] [type=\"submit\"]");
											DD19ED37.F8091028(1.0);
										}
										break;
									case "[name=\"ajax_password\"]":
										DD19ED37.method_22("[name=\"ajax_password\"]", text2);
										DD19ED37.F8091028(1.0);
										DD19ED37.method_18("[class*=\"layerConfirm uiOverlayButton\"]");
										DD19ED37.F8091028(1.0);
										if (DD19ED37.method_124())
										{
											return 0;
										}
										break;
									}
									continue;
								}
								DD19ED37.method_17(text3);
								DD19ED37.F8091028(1.0);
								if (!DD19ED37.D7A424AE("[role=\"dialog\"] [class*=\"layerConfirm uiOverlayButton\"]", 10.0))
								{
									continue;
								}
								DD19ED37.method_18("[role=\"dialog\"] [class*=\"layerConfirm uiOverlayButton\"]");
								DD19ED37.F8091028(1.0);
								switch (DD19ED37.method_15(10.0, new List<string> { "[name=\"ajax_password\"]", "[id*=\"fetchstream\"] a", "[class*=\"selected uiButton uiButtonSpecial\"]", "[style=\"padding-bottom: 1%;\"] span a" }))
								{
								case "[class*=\"selected uiButton uiButtonSpecial\"]":
									num2 = 1;
									break;
								case "[id*=\"fetchstream\"] a":
									DD19ED37.method_18("[id*=\"fetchstream\"] a");
									DD19ED37.F8091028(1.0);
									if (DD19ED37.D7A424AE("[class*=\"uiOverlayFooter\"] [type=\"submit\"]", 10.0))
									{
										DD19ED37.method_18("[class*=\"uiOverlayFooter\"] [type=\"submit\"]");
										DD19ED37.F8091028(1.0);
									}
									break;
								case "[name=\"ajax_password\"]":
									DD19ED37.method_22("[name=\"ajax_password\"]", text2);
									DD19ED37.F8091028(1.0);
									DD19ED37.method_18("[class*=\"layerConfirm uiOverlayButton\"]");
									DD19ED37.F8091028(1.0);
									if (DD19ED37.method_124())
									{
										return 0;
									}
									break;
								}
								continue;
							}
							num2 = 1;
							break;
						}
					}
					DD19ED37.method_54();
					goto IL_096f;
				}
				goto end_IL_0088;
			}
			default:
				num3 = ((num == 4) ? 1 : 0);
				break;
			case 1:
				num3 = 1;
				break;
			}
			if (num3 == 0)
			{
				switch (num)
				{
				case 2:
				{
					List<string> list = DD19ED37.method_70();
					DD19ED37.EE1B8EA5(list);
					num2 = 1;
					break;
				}
				case 3:
					try
					{
						string text4 = "";
						string text5 = "";
						for (int l = 0; l < 4; l++)
						{
							string json = DD19ED37.method_133(text4);
							JObject jObject = JObject.Parse(json);
							if (Convert.ToBoolean(jObject["success"]))
							{
								DD19ED37.method_13();
								l = 0;
								continue;
							}
							string text6 = jObject["error"]!.ToString();
							if (!(text6 == "not_found_phone"))
							{
								if (text6 == "continue" || text6 == "block")
								{
									continue;
								}
								if (!text6.StartsWith("otp"))
								{
									break;
								}
								if (!text6.Contains("|"))
								{
									goto IL_0858;
								}
								string text7 = text6.Split('|')[1];
								if (text7.Contains("@"))
								{
									if (!(DD19ED37.F8A3B83F.Substring(DD19ED37.F8A3B83F.IndexOf('@') - 1, 3) != text7.Substring(text7.IndexOf('@') - 1, 3)))
									{
										goto IL_0858;
									}
									AD3ACABD = "Fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
								}
								else
								{
									AD3ACABD = "Fail (" + Language.GetValue("Fb bắt xác minh phone") + ")";
								}
							}
							else
							{
								num2 = 1;
							}
							goto IL_0981;
							IL_0858:
							method_130(int_3, text + "Get otp...");
							text4 = FB93BDA4.GetOtpFromMail(1, DD19ED37.F8A3B83F, DD19ED37.ACBD1889, DD19ED37.A70B4E96, DD19ED37.A990D886, 60, "", text5);
							if (!(text4 == "fail"))
							{
								if (!(text4 == ""))
								{
									if (text4 == text5)
									{
										text4 = "";
										continue;
									}
									text5 = text4;
									l--;
									continue;
								}
								AD3ACABD = "Fail (" + Language.GetValue("Không lấy được otp!") + ")";
							}
							else
							{
								AD3ACABD = "Fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
							}
							goto IL_0981;
						}
					}
					catch (Exception)
					{
					}
					break;
				}
				goto IL_096f;
			}
			if (text2 == "")
			{
				num2 = 4;
			}
			else
			{
				int c984E38F = 0;
				switch (num)
				{
				case 1:
					c984E38F = 2;
					break;
				case 4:
					c984E38F = 3;
					break;
				}
				string json2 = DD19ED37.method_100(text2, c984E38F);
				JObject jObject2 = JObject.Parse(json2);
				if (!Convert.ToBoolean(jObject2["success"]))
				{
					switch (jObject2["error"]!.ToString())
					{
					case "no_alternate_contact":
						num2 = 5;
						break;
					case "checkpoint":
						num2 = 3;
						break;
					case "changed_pass":
						num2 = 2;
						break;
					}
					goto IL_096f;
				}
				num2 = 1;
			}
			end_IL_0088:;
		}
		catch
		{
			goto IL_096f;
		}
		goto IL_0981;
		IL_096f:
		if (num2 != 3 && DD19ED37.method_124())
		{
			num2 = 3;
		}
		goto IL_0981;
		IL_0981:
		if (AD3ACABD == "")
		{
			AD3ACABD = "Fail";
			switch (num2)
			{
			case 1:
				if (DD19ED37.method_70().Count == 0)
				{
					AD3ACABD = "Success";
					method_134(int_3, "cPhone", "0", "phone");
				}
				break;
			case 2:
				AD3ACABD += " (Sai pass)";
				E589F93F(int_3, "Changed pass");
				break;
			case 3:
				AD3ACABD += " (Checkpoint)";
				E589F93F(int_3, "Checkpoint");
				break;
			case 4:
				AD3ACABD += " (No pass)";
				break;
			case 5:
				AD3ACABD += " (No email)";
				break;
			}
		}
		return num2;
	}

	private int method_43(ref string string_1, int int_3, string string_2, Chrome D43AEB9B, GClass4 gclass4_0, string string_3)
	{
		method_130(int_3, string_2 + Language.GetValue("Đang") + " " + string_3 + "...");
		bool flag = false;
		try
		{
			string pass = F6061E95(int_3, "cPassword");
			string acRes = AccountsCenterHub.Execute(D43AEB9B, "LogoutOldDevices", "{\"password\":\"" + (pass ?? "").Replace("\"", "\\\"") + "\"}");
			if (AccountsCenterHub.IsSuccess(acRes))
			{
				flag = true;
			}
		}
		catch { }

		if (!flag)
		{
			flag = method_44(D43AEB9B, int_3);
		}
		string_1 = (flag ? "Success" : "Fail");
		return 0;
	}

	private bool method_44(Chrome chrome_0, int int_3)
	{
		bool result = false;
		try
		{
			int num = 3;
			int num2 = 3;
			string text = "";
			chrome_0.method_53();
			chrome_0.method_12("https://accountscenter.facebook.com/password_and_security/login_activity?locale=en_US");
			chrome_0.F8091028(2.0);
			int tickCount = Environment.TickCount;
			int num3 = 60;
			while (Environment.TickCount - tickCount <= num3 * 1000 && !chrome_0.CD930D04() && !chrome_0.CD930D04())
			{
				string text2 = chrome_0.method_15(0.0, new List<string> { "[aria-labelledby][role=\"dialog\"] [role=\"button\"] [aria-label][role=\"img\"]" });
				string text3 = text2;
				string text4 = text3;
				if (text4 == "[aria-labelledby][role=\"dialog\"] [role=\"button\"] [aria-label][role=\"img\"]")
				{
					if (chrome_0.D7A424AE("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'ok']"))
					{
						num--;
						if (num < 0)
						{
							break;
						}
						chrome_0.method_18("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'ok']");
					}
					else
					{
						if (chrome_0.D7A424AE("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'you have no other login')]") && chrome_0.method_36("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'you have no other login')]"))
						{
							result = true;
							break;
						}
						if (chrome_0.D7A424AE("[method=\"GET\" i] [type=\"text\" i]"))
						{
							string text5 = F6061E95(int_3, "cEmail");
							string string_ = F6061E95(int_3, "cPassMail");
							string a8382C3C = F6061E95(int_3, "cOAuth2");
							string a5A6E = F6061E95(int_3, "cCookieHotmail");
							num2--;
							if (num2 < 0)
							{
								return false;
							}
							string text6 = FB93BDA4.GetOtpFromMail(1, text5, string_, a8382C3C, a5A6E, 60, "", text);
							tickCount = Environment.TickCount;
							if (text6 == "fail")
							{
								return false;
							}
							if (text6 != "" && text6 == text && num2 > 0)
							{
								text6 = "";
							}
							if (text6 == "")
							{
								chrome_0.method_18("[name=\"send_code\"]");
							}
							else
							{
								text = text6;
								chrome_0.method_22("[method=\"GET\" i] [type=\"text\" i]", text6);
								chrome_0.F8091028(1.0);
								chrome_0.method_18("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'continue']");
							}
						}
						else if (chrome_0.D7A424AE("//*[contains(@role, 'button') and not(@aria-disabled='true')]//*[text()='Log out']"))
						{
							chrome_0.method_18("(//*[contains(@role, 'button') and not(@aria-disabled='true')]//*[text()='Log out'])[last()]");
						}
						else if (chrome_0.D7A424AE("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'select all']"))
						{
							chrome_0.method_18("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'select all']");
						}
						else if (chrome_0.D7A424AE("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'select devices to log out']"))
						{
							chrome_0.method_19("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'select devices to log out']");
						}
						else
						{
							chrome_0.method_18(text2);
						}
					}
				}
				chrome_0.F8091028(2.0);
			}
		}
		catch
		{
		}
		chrome_0.method_54();
		return result;
	}

	private int B0A82114(ref string string_1, int int_3, string F8326F89, Chrome chrome_0, GClass4 C51CAB01, string string_2)
	{
		method_130(int_3, F8326F89 + Language.GetValue("Đang") + " " + string_2 + "...");
		string_1 = chrome_0.method_90();
		return 0;
	}

	private int D191792B(int F63AC827, string string_1, Chrome chrome_0, GClass4 gclass4_0, string DD18C120)
	{
		return PersonalInteractionHelper.UnlockOrLockProfile(this, F63AC827, string_1, chrome_0, gclass4_0, DD18C120);
	}

	private int method_45(ref int EE152CA0, int int_3, string string_1, Chrome chrome_0, GClass4 A621ACAB, string string_2)
	{
		EE152CA0 = 0;
		method_130(int_3, string_1 + Language.GetValue("Đang") + " " + string_2 + "...");
		try
		{
			string json = chrome_0.method_66("ActivePageProfile");
			JObject jObject = JObject.Parse(json);
			EE152CA0 = Convert.ToInt32(jObject["countSuccess"]);
		}
		catch (Exception)
		{
		}
		return 0;
	}

	private int method_46(ref string FE912FA1, int int_3, string string_1, Chrome BDBFB20C, GClass4 D4A00F82, string B0000B04)
	{
		return PersonalInteractionHelper.ToggleProfessionalMode(this, ref FE912FA1, int_3, string_1, BDBFB20C, D4A00F82, B0000B04);
	}

	private int F59C7BBF(int int_3, string F48C2432, Chrome chrome_0, GClass4 gclass4_0, string string_1)
	{
		chrome_0.method_12("https://www.facebook.com/device_based_login/?from_accounts_center=1", FC3A841F: true);
		chrome_0.F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 30;
		while (!chrome_0.E184CD03() && !chrome_0.CD930D04() && Environment.TickCount - tickCount <= num * 1000)
		{
			string text = chrome_0.method_15(0.0, new List<string> { "a[ajaxify^=\"/settings/security/device_based_login/remove/?flow=settings_for_remote_devices\"]", "a[ajaxify*=\"?flow=logged_in_settings\"]" });
			string text2 = text;
			string text3 = text2;
			if (!(text3 == "a[ajaxify^=\"/settings/security/device_based_login/remove/?flow=settings_for_remote_devices\"]"))
			{
				if (text3 == "a[ajaxify*=\"?flow=logged_in_settings\"]")
				{
					break;
				}
			}
			else
			{
				chrome_0.method_19(text);
				tickCount = Environment.TickCount;
			}
			chrome_0.F8091028(2.0);
		}
		return 0;
	}

	private int F31CEBAE(int int_3, string string_1, Chrome D130FF1F, GClass4 gclass4_0, string B12597AD, string string_2)
	{
		int num = 0;
		try
		{
			F6061E95(int_3, "cUid");
			F6061E95(int_3, "cPassword");
			F6061E95(int_3, "cFa2");
			int minValue = gclass4_0.method_2("nudSoLuongFrom");
			int num2 = gclass4_0.method_2("nudSoLuongTo");
			gclass4_0.method_2("nudDelayFrom");
			gclass4_0.method_2("nudDelayTo");
			gclass4_0.method_2("typeReview");
			bool flag = gclass4_0.method_3("ckbTuDongXoaUid");
			string text = "";
			List<string> list = C499BE3B(F53E0407[string_2]);
			try
			{
				for (int num3 = Base.rd.Next(minValue, num2 + 1); num < num3; D130FF1F.method_12("https://www.facebook.com/" + text + "/reviews/?ref=page_internal"), D130FF1F.F8091028(1.0))
				{
					if (string_2 != "" && !flag)
					{
						if (list.Count != 0)
						{
							text = list[Base.rd.Next(0, list.Count)];
							list.Remove(text);
							continue;
						}
						break;
					}
					lock (F53E0407)
					{
						if (F53E0407[string_2].Count == 0)
						{
							break;
						}
						text = F53E0407[string_2][Base.rd.Next(0, F53E0407[string_2].Count)];
						F53E0407[string_2].Remove(text);
						continue;
					}
				}
			}
			catch (Exception ex)
			{
				Commom.smethod_58(null, ex.ToString());
				num = -1;
			}
			return num;
		}
		catch
		{
		}
		return num;
	}

	private int method_47(int int_3, string string_1, Chrome E38BDFB6, GClass4 gclass4_0, string string_2, string string_3)
	{
		return PersonalInteractionHelper.InteractLivestream(this, int_3, string_1, E38BDFB6, gclass4_0, string_2, string_3);
	}

	private int E2053BA2(int int_3, string string_1, Chrome D4AC6B12, GClass4 D1AA6889)
	{
		int num = D1AA6889.method_2("nudSoLuong");
		try
		{
			string format = "https://m.facebook.com/{0}/allactivity/?category_key=all&timestart={1}&timeend={2}";
			string arg = D4AC6B12.method_14("return (document.cookie + ';').match(new RegExp('c_user=(.*?);'))[1]").ToString();
			string text = "";
			string text2 = "";
			string text3 = "";
			int i = 0;
			if (D1AA6889.method_3("ckbXoaThangNay"))
			{
				i = -1;
				num--;
			}
			for (; i < num; i++)
			{
				List<string> list = new List<string>();
				DateTime dateTime = DateTime.Now.AddMonths(-1 - i);
				DateTime dateTime2 = DateTime.Now.AddMonths(-i);
				text = Commom.smethod_15(new DateTime(dateTime.Year, dateTime.Month, 1)).ToString();
				text2 = Commom.smethod_15(new DateTime(dateTime2.Year, dateTime2.Month, 1)).ToString();
				text3 = string.Format(format, arg, text, text2);
				D4AC6B12.method_12(text3);
				D4AC6B12.F8091028(1.0);
				if (!D4AC6B12.D7A424AE("[href*=\"allactivity/?category_key=trash\"]", 30.0))
				{
					continue;
				}
				method_130(int_3, string_1 + Language.GetValue("Đang lấy link xóa tháng " + dateTime.Month + "..."));
				if (!D4AC6B12.D7A424AE("[id*=\"month_" + dateTime.Year + "_" + dateTime.Month + "_more\"]", 5.0))
				{
					continue;
				}
				for (int j = 0; j < 5; j++)
				{
					if (!D4AC6B12.D7A424AE("[id*=\"month_" + dateTime.Year + "_" + dateTime.Month + "_more\"]", 5.0))
					{
						break;
					}
					D4AC6B12.method_19("[id*=\"month_" + dateTime.Year + "_" + dateTime.Month + "_more\"]");
					D4AC6B12.F8091028(1.0);
				}
				int num2 = Convert.ToInt32(D4AC6B12.method_14("return document.querySelectorAll('[href*=\"activity_log/confirm_dialog\"]').length").ToString());
				for (int k = 0; k < num2; k++)
				{
					list.Add(D4AC6B12.method_14("return document.querySelectorAll('[href*=\"activity_log/confirm_dialog\"]')[" + k + "].href").ToString());
				}
				for (int l = 0; l < list.Count; l++)
				{
					if (!Base.smethod_5())
					{
						method_130(int_3, string_1 + Language.GetValue("Đang xóa (" + (l + 1) + "/" + list.Count + ") - Tháng " + dateTime.Month + "..."));
						D4AC6B12.method_12(list[l]);
						D4AC6B12.F8091028(1.0);
						if (!D4AC6B12.D7A424AE("[rel=\"async-post\"]", 10.0))
						{
							continue;
						}
						D4AC6B12.method_18("[rel=\"async-post\"]");
						D4AC6B12.F8091028(1.0);
						for (int m = 0; m < 20; m++)
						{
							if (D4AC6B12.GetURL() != list[l])
							{
								break;
							}
							D4AC6B12.F8091028(1.0);
						}
						D4AC6B12.F8091028(Base.rd.Next(D1AA6889.method_2("nudDelayFrom"), D1AA6889.method_2("nudDelayTo")) + 1);
						continue;
					}
					return 0;
				}
			}
		}
		catch
		{
		}
		return 0;
	}

	private (bool isSuccess, string error, string rq) F3A19109(Chrome chrome_0, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		string text2 = gclass4_0.BDB80B23("reaction");
		bool flag = false;
		string text3 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"},{\"name\":\"reaction\", \"value\":\"" + text2 + "\", \"type\":\"text\"}]";
		string json = chrome_0.method_66("Reaction", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && chrome_0.D6BBEDA3())
			{
				text3 += "fb_blocked";
			}
			else
			{
				string text4 = jObject["error"]!.ToString();
				string text5 = text4;
				if (text5 == "not_exist_post" || text5 == "not_exist_reaction_button")
				{
					text3 += "job_die";
				}
				text3 += jObject["error"]!.ToString();
			}
		}
		return (flag, text3, "");
	}

	private (bool isSuccess, string error, string rq) method_48(Chrome FBB23624, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		bool flag = false;
		string text2 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = FBB23624.method_66("ShareWall", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && FBB23624.D6BBEDA3())
			{
				text2 += "fb_blocked";
			}
			else
			{
				string text3 = jObject["error"]!.ToString();
				string text4 = text3;
				if (text4 == "not_exist_post" || text4 == "not_exist_share_button")
				{
					text2 += "job_die";
				}
				text2 += jObject["error"]!.ToString();
			}
		}
		return (flag, text2, "");
	}

	private (bool isSuccess, string error, string rq) method_49(Chrome chrome_0, GClass4 EBA5F721)
	{
		string text = EBA5F721.BDB80B23("id");
		string text2 = EBA5F721.BDB80B23("content");
		bool flag = false;
		string text3 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"},{\"name\":\"content\", \"value\":\"" + text2 + "\", \"type\":\"text\"}]";
		string json = chrome_0.method_66("Comment", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && chrome_0.D6BBEDA3())
			{
				text3 += "fb_blocked";
			}
			else
			{
				string text4 = jObject["error"]!.ToString();
				string text5 = text4;
				if (text5 == "not_exist_post" || text5 == "not_exist_comment_button")
				{
					text3 += "job_die";
				}
				text3 += jObject["error"]!.ToString();
			}
		}
		return (flag, text3, "");
	}

	private (bool isSuccess, string error, string rq) method_50(Chrome D0894C97, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		bool flag = false;
		string text2 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = D0894C97.method_66("Follow", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && D0894C97.D6BBEDA3())
			{
				text2 += "fb_blocked";
			}
			else
			{
				string text3 = jObject["error"]!.ToString();
				string text4 = text3;
				if (text4 == "not_exist_object" || text4 == "not_exist_follow_button")
				{
					text2 += "job_die";
				}
				text2 += jObject["error"]!.ToString();
			}
		}
		return (flag, text2, "");
	}

	private (bool isSuccess, string error, string rq) method_51(Chrome chrome_0, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		bool flag = false;
		string text2 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = chrome_0.method_66("LikePage", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && chrome_0.D6BBEDA3())
			{
				text2 += "fb_blocked";
			}
			else
			{
				string text3 = jObject["error"]!.ToString();
				string text4 = text3;
				if (text4 == "cant_get_page_id")
				{
					text2 += "job_die";
				}
				text2 += jObject["error"]!.ToString();
			}
		}
		return (flag, text2, "");
	}

	private (bool isSuccess, string error, string rq) method_52(Chrome chrome_0, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		bool flag = false;
		string text2 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = chrome_0.method_66("JoinGroup", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && chrome_0.D6BBEDA3())
			{
				text2 += "fb_blocked";
			}
			else
			{
				string text3 = jObject["error"]!.ToString();
				string text4 = text3;
				if (text4 == "not_exist_object")
				{
					text2 += "job_die";
				}
				text2 += jObject["error"]!.ToString();
			}
		}
		return (flag, text2, "");
	}

	private (bool isSuccess, string error, string rq) method_53(Chrome chrome_0, GClass4 gclass4_0)
	{
		string text = gclass4_0.BDB80B23("id");
		bool flag = false;
		string text2 = "";
		string string_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = chrome_0.method_66("LikeComment", string_);
		JObject jObject = JObject.Parse(json);
		if (!(flag = Convert.ToBoolean(jObject["success"])))
		{
			if (jObject["error"]!.ToString() != "fb_blocked" && chrome_0.D6BBEDA3())
			{
				text2 += "fb_blocked";
			}
			else
			{
				string text3 = jObject["error"]!.ToString();
				string text4 = text3;
				if (text4 == "not_exist_like_button")
				{
					text2 += "job_die";
				}
				text2 += jObject["error"]!.ToString();
			}
		}
		return (flag, text2, "");
	}

	private int method_54(int C0269CA2, string string_1, Chrome chrome_0, GClass4 gclass4_0)
	{
		try
		{
			method_130(C0269CA2, string_1 + Language.GetValue("Đang kiểm tra trạng thái tài khoản..."));

			if (chrome_0 == null || chrome_0.CD930D04())
			{
				method_130(C0269CA2, string_1 + Language.GetValue("Mất kết nối trình duyệt!"));
				return 2;
			}

			string currentUrl = chrome_0.GetURL();
			if (chrome_0.method_124() || currentUrl.Contains("checkpoint") || currentUrl.Contains("/login/checkpoint") || currentUrl.Contains("facebook.com/x/checkpoint") || currentUrl.Contains("/secured_action/block/"))
			{
				method_130(C0269CA2, string_1 + Language.GetValue("Tài khoản Checkpoint!"));
				method_134(C0269CA2, "cStatus", "Checkpoint", "status");
				return 2;
			}

			string cookie = chrome_0.method_40();
			string cUser = Regex.Match(cookie ?? "", "c_user=(\\d+)").Groups[1].Value;
			if (string.IsNullOrEmpty(cUser))
			{
				try
				{
					var cookieObj = chrome_0.ChromeDriver_0?.Manage()?.Cookies?.GetCookieNamed("c_user");
					if (cookieObj != null) cUser = cookieObj.Value;
				}
				catch {}
			}

			if (!string.IsNullOrEmpty(cUser) && cUser != "0")
			{
				method_130(C0269CA2, string_1 + Language.GetValue("Tài khoản Live!"));
				method_134(C0269CA2, "cStatus", "Live", "status");
				return 1;
			}

			int state = chrome_0.method_125(bool_9: true);
			if (state == -1 || state == 2 || chrome_0.method_124())
			{
				method_130(C0269CA2, string_1 + Language.GetValue("Tài khoản Checkpoint!"));
				method_134(C0269CA2, "cStatus", "Checkpoint", "status");
				return 2;
			}

			if (chrome_0.C8825826() || chrome_0.D6BBEDA3())
			{
				method_130(C0269CA2, string_1 + Language.GetValue("Tài khoản Live!"));
				method_134(C0269CA2, "cStatus", "Live", "status");
				return 1;
			}

			method_130(C0269CA2, string_1 + Language.GetValue("Tài khoản Checkpoint!"));
			method_134(C0269CA2, "cStatus", "Checkpoint", "status");
			return 2;
		}
		catch (Exception ex)
		{
			Commom.smethod_58(ex, "HDVerify");
			return 2;
		}
	}

	private void method_55(int int_3, string string_1, Chrome E1A441BB)
	{
		try
		{
			if (E1A441BB != null)
			{
				method_130(int_3, string_1 + "Close chrome...");
				E1A441BB.A4B307B3();
				if (C5034B95.smethod_0("configGeneral").method_3("ckbAddChromeIntoForm") || C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView"))
				{
					fViewChrome.fViewChrome_0.method_1(E1A441BB.D1154987);
				}
			}
		}
		catch
		{
		}
		if (C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaCache"))
		{
			BD213FBD(int_3);
		}
	}

	private bool method_56(Chrome chrome_0, int int_3, string string_1, GClass4 gclass4_0 = null)
	{
		if (gclass4_0 == null)
		{
			gclass4_0 = new GClass4();
		}
		bool flag = gclass4_0.method_3("Unlock956");
		int num = gclass4_0.method_2("TypeUnlock956", 2);
		bool flag2 = gclass4_0.method_3("Unlock282");
		string text = "";
		string string_2 = "[href*=\"facebook.com/security/2fac/setup/intro/\"]";
		string text2 = F6061E95(int_3, "cPassword");
		if (chrome_0.D7A424AE(string_2))
		{
			if (!(text2 == ""))
			{
				chrome_0.method_69(3);
				int num2 = 0;
				int num3 = 3;
				string text3 = "";
				int tickCount = Environment.TickCount;
				while (!chrome_0.GetURL().Contains("facebook.com/secured_action/block/"))
				{
					string text4 = chrome_0.method_15(0.0, new List<string> { "[type=\"submit\"]" });
					string text5 = text4;
					string text6 = text5;
					if (!(text6 == "[type=\"submit\"]"))
					{
						if (chrome_0.D7A424AE("[href=\"/\"]"))
						{
							if (num2 >= num3)
							{
								break;
							}
							num2++;
							chrome_0.F7221F34();
						}
						else if (chrome_0.method_124())
						{
							goto IL_06e4;
						}
					}
					else if (chrome_0.D7A424AE("[href^=\"/security/2fac/setup/turn_off/\"]"))
					{
						if (text3 != "")
						{
							method_134(int_3, "cFa2", text3, "fa2");
							return true;
						}
						if (chrome_0.D7A424AE("[href*=\"/security/2fac/setup/qrcode/generate/\"]"))
						{
							text4 = "[href*=\"/security/2fac/setup/qrcode/generate/\"]";
							string value = Regex.Match(chrome_0.GetURL(), "https://(.*?)facebook.com").Value;
							string text7 = chrome_0.B9BE8807(text4, "href");
							if (!text7.StartsWith("http"))
							{
								text7 = value + text7;
							}
							chrome_0.method_12(text7);
						}
					}
					else if (chrome_0.D7A424AE("[name=\"pass\"]"))
					{
						if (chrome_0.method_14("return document.querySelector('[data-sigil=\"marea\"] .mfsm').innerText").ToString() != "")
						{
							E589F93F(int_3, "Changed pass");
							method_130(int_3, string_1 + Language.GetValue("Mật khẩu không đúng!"));
							return false;
						}
						chrome_0.method_22("[name=\"pass\"]", text2);
						chrome_0.F8091028(2.0);
						chrome_0.method_18("[name=\"save\"]");
					}
					else if (chrome_0.D7A424AE("[name=\"code\"]"))
					{
						string text8 = Commom.smethod_62(text3);
						if (text8 == "")
						{
							break;
						}
						if (text8 != "")
						{
							chrome_0.method_22("[name=\"code\"]", text8);
							chrome_0.F8091028(1.0);
							chrome_0.method_18("#submit_code_button");
							chrome_0.F8091028(2.0);
						}
					}
					else if (chrome_0.D7A424AE("[href^=\"otpauth://totp/ID:\"]"))
					{
						text4 = "[href^=\"otpauth://totp/ID:\"]";
						for (int i = 0; i < 3; i++)
						{
							text3 = chrome_0.method_14("return document.querySelector('" + text4 + "').href.match(new RegExp('secret=(.*?)&'))[1]").ToString().Replace(" ", "");
							if (text3 != "")
							{
								break;
							}
							chrome_0.method_13();
							chrome_0.F8091028(2.0);
						}
						if (text3 == "")
						{
							break;
						}
						chrome_0.method_21("#qr_confirm_button");
					}
					else if (chrome_0.D7A424AE("[href*=\"/security/2fac/setup/qrcode/generate/\"]"))
					{
						text4 = "[href*=\"/security/2fac/setup/qrcode/generate/\"]";
						string value2 = Regex.Match(chrome_0.GetURL(), "https://(.*?)facebook.com").Value;
						string text9 = chrome_0.B9BE8807(text4, "href");
						if (!text9.StartsWith("http"))
						{
							text9 = value2 + text9;
						}
						chrome_0.method_12(text9);
					}
					else
					{
						text = chrome_0.GetURL();
						if (text.Contains("1501092823525282") || text.Contains("828281030927956") || (text.Contains("facebook.com/nt/screen/?params=") && text.Contains("checkpoint")))
						{
							goto IL_06e4;
						}
						if (chrome_0.D7A424AE("#MComposer,[name=\"xc_message\"]"))
						{
							if (text3 != "")
							{
								method_134(int_3, "cFa2", text3, "fa2");
							}
							return true;
						}
						if (chrome_0.D7A424AE(string_2))
						{
							chrome_0.method_18(string_2);
						}
						else if (chrome_0.GetURL().Contains("facebook.com/si/actor_experience/actor_gateway/nt/?flow_id=3510905325602174"))
						{
							chrome_0.method_21("[role=\"main\"] [role=\"button\"]");
						}
						else if (chrome_0.D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
						{
							chrome_0.method_18("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
						}
						else
						{
							chrome_0.method_21(text4);
						}
					}
					chrome_0.F8091028(2.0);
					if (Environment.TickCount - tickCount >= 300000)
					{
						break;
					}
				}
			}
			E589F93F(int_3, "Checkpoint: Bật 2FA");
			method_130(int_3, string_1 + "Checkpoint: Bật 2FA");
			return false;
		}
		string string_3 = "[name=\"password_new\"]";
		bool flag3;
		string text10;
		if (chrome_0.D7A424AE(string_3))
		{
			flag3 = false;
			text10 = "";
			string string_4 = "[name=\"password_old\"]";
			string string_5 = "[name=\"password_confirm\"]";
			if (chrome_0.D7A424AE(string_4))
			{
				if (text2 == "")
				{
					goto IL_068f;
				}
				chrome_0.method_22(string_4, text2);
				chrome_0.F8091028(1.0);
			}
			text10 = Commom.B820DC86(10, "0");
			chrome_0.method_22(string_3, text10);
			chrome_0.F8091028(1.0);
			chrome_0.method_22(string_5, text10);
			chrome_0.F8091028(1.0);
			chrome_0.method_62();
			chrome_0.F217FA96(string_5);
			int tickCount2 = Environment.TickCount;
			int num4 = 30;
			while (true)
			{
				if (!chrome_0.method_63(0) && chrome_0.D7A424AE(string_3))
				{
					if ((chrome_0.D7A424AE(string_3) && chrome_0.method_5(string_3) == "") || Environment.TickCount - tickCount2 > num4 * 1000)
					{
						break;
					}
					chrome_0.F8091028(1.0);
					continue;
				}
				flag3 = true;
				break;
			}
			goto IL_068f;
		}
		goto IL_06e4;
		IL_120c:
		string text11;
		E589F93F(int_3, "Checkpoint: " + text11);
		method_130(int_3, string_1 + "Checkpoint: " + text11);
		return false;
		IL_06e4:
		text11 = "";
		int num5 = 0;
		if (flag && (chrome_0.D7A424AE("[href*=\"facebook.com/secure_account_learn_more\"]") || chrome_0.D7A424AE("[href=\"/help/117450615006715\"]") || chrome_0.GetURL().Contains("465803052217681")))
		{
			bool flag4;
			if (flag4 = EB32900A(chrome_0, int_3, string_1))
			{
				E589F93F(int_3, "Live");
				method_130(int_3, "Unlock checkpoint success!");
			}
			C412B9A5(int_3, (!flag4) ? 1 : 2);
			return flag4;
		}
		if (chrome_0.D7A424AE("#checkpointButtonGetStarted-actual-button"))
		{
			chrome_0.method_12("https://d.facebook.com/");
			if (!chrome_0.D7A424AE("[name=\"submit[Continue]\"]"))
			{
				chrome_0.F7221F34();
			}
			string text12 = Commom.B820DC86(6, "a") + Commom.B820DC86(4, "0") + Commom.B820DC86(5, "a");
			if (C5034B95.smethod_0("configGeneral").method_2("typePass") == 0)
			{
				text12 = C5034B95.smethod_0("configGeneral").BDB80B23("txtPass").smethod_1(2);
			}
			bool flag5 = false;
			int tickCount3 = Environment.TickCount;
			int num6 = 45;
			while (true)
			{
				string text13 = chrome_0.method_15(0.0, new List<string> { "[value=\"someone_accessed\"]", "[name=\"submit[Get Started]\"]", "[name=\"submit[Continue]\"]", "[name=\"new_cp\"]", "[name=\"code\"]", "[name=\"submit[Go to News Feed]\"]" });
				switch (text13)
				{
				case "[value=\"someone_accessed\"]":
					chrome_0.method_21(text13);
					chrome_0.F8091028(1.0);
					chrome_0.method_18("[type=\"submit\"]");
					break;
				case "[name=\"submit[Continue]\"]":
					if (chrome_0.D7A424AE("[name=\"password_new\"]"))
					{
						chrome_0.method_22("[name=\"password_new\"]", text12);
						chrome_0.F8091028(1.0);
						F0A81525(chrome_0.AF336B2C, "pass", int_3, "cPassword", text12);
						chrome_0.C234EEAA = text12;
						if (chrome_0.D7A424AE("[name=\"password_confirm\"]"))
						{
							chrome_0.method_22("[name=\"password_confirm\"]", text12);
							chrome_0.F8091028(1.0);
						}
						if (chrome_0.D7A424AE("[name=\"password_old\"]"))
						{
							if (flag5 && chrome_0.method_14("return document.querySelector('[name=\"password_old\"]').value;").ToString() == "")
							{
								F0A81525(chrome_0.AF336B2C, "pass", int_3, "cPassword", text2);
								chrome_0.C234EEAA = text2;
								E589F93F(int_3, "Changed pass");
								method_130(int_3, string_1 + Language.GetValue("Mật khẩu không đúng!"));
								return false;
							}
							flag5 = true;
							chrome_0.method_22("[name=\"password_old\"]", chrome_0.C234EEAA);
							chrome_0.F8091028(1.0);
						}
						chrome_0.method_18(text13);
					}
					else if (!chrome_0.method_18(text13))
					{
						chrome_0.method_21(text13);
					}
					break;
				case "[name=\"submit[Get Started]\"]":
					chrome_0.method_18(text13);
					chrome_0.F8091028(2.0);
					chrome_0.method_33("[name=\"submit[Continue]\"][disabled]", 30);
					break;
				case "[name=\"submit[Go to News Feed]\"]":
					chrome_0.method_18(text13);
					E589F93F(int_3, "Live");
					method_130(int_3, "Đăng nhập thành công!");
					return true;
				}
				if (Base.smethod_5() || chrome_0.CD930D04() || Environment.TickCount - tickCount3 > num6 * 1000)
				{
					break;
				}
				chrome_0.F8091028(2.0);
			}
		}
		text = chrome_0.GetURL();
		if (text.Contains("facebook.com/checkpoint/588324129567771"))
		{
			if (chrome_0.method_130())
			{
				E589F93F(int_3, "Live");
				method_130(int_3, "Unlock checkpoint success!");
			}
			else
			{
				text11 = "security";
			}
		}
		else if (text.Contains("checkpoint/disabled"))
		{
			text11 = "vhh";
		}
		else if (text.Contains("facebook.com/si/actor_experience/actor_gateway/nt") && chrome_0.method_61(text) != 3)
		{
			chrome_0.method_12("https://d.facebook.com/");
			if (!chrome_0.GetURL().Contains("checkpoint/disabled"))
			{
				goto IL_0e1e;
			}
			text11 = "vhh";
		}
		else
		{
			if (text.Contains("828281030927956") || text.Contains("1501092823525282"))
			{
				goto IL_0e1e;
			}
			if (chrome_0.D7A424AE("#SupportFormRow\\\\.382907505152522"))
			{
				text11 = "Change name";
			}
			else if (text.Contains("facebook.com/auth_platform") || chrome_0.D7A424AE("[href=\"/help/117450615006715\"]"))
			{
				text11 = "login";
			}
			else
			{
				chrome_0.method_69();
				if (!chrome_0.GetURL().Contains("checkpoint/disabled"))
				{
					goto IL_0e1e;
				}
				text11 = "vhh";
			}
		}
		goto IL_120c;
		IL_0e1e:
		while (true)
		{
			num5++;
			text = chrome_0.GetURL();
			if (!text.Contains("facebook.com/si/actor_experience/actor_gateway/nt") || chrome_0.method_61(text) != 3)
			{
				if (!text.Contains("checkpoint/disabled"))
				{
					if (!text.Contains("1501092823525282"))
					{
						if (!text.Contains("828281030927956"))
						{
							if (!chrome_0.D7A424AE("[name=\"verification_method\"]"))
							{
								if (num5 == 1)
								{
									if (chrome_0.method_61() != 3)
									{
										chrome_0.method_12("https://d.facebook.com/");
									}
									continue;
								}
								string text14 = chrome_0.method_15(5.0, new List<string> { "[name=\"email\"]", "#checkpoint_title" });
								if (!(text14 == "[name=\"email\"]"))
								{
									if (text14 == "#checkpoint_title")
									{
										if (chrome_0.D7A424AE("[name=\"submit[Go to Support Inbox]\"]"))
										{
											chrome_0.method_18("[name=\"submit[Go to Support Inbox]\"]");
											chrome_0.F8091028(2.0);
											chrome_0.F7221F34();
											chrome_0.F8091028(2.0);
											continue;
										}
										if (chrome_0.D7A424AE("#checkpointSubmitButton>[name=\"submit[Yes]\"]"))
										{
											chrome_0.method_18("#checkpointSubmitButton>[name=\"submit[Yes]\"]");
											chrome_0.F8091028(2.0);
											if (chrome_0.D7A424AE("[name=\"new_password\"],[name=\"password_new\"]"))
											{
												string text15 = Commom.smethod_77();
												chrome_0.method_22("[name=\"new_password\"],[name=\"password_new\"]", text15);
												method_134(int_3, "cPassword", text15, "pass");
												chrome_0.C234EEAA = text15;
												chrome_0.F8091028(1.0);
												chrome_0.method_62();
												if (chrome_0.D7A424AE("[name=\"new_password\"],[name=\"password_new\"]"))
												{
													chrome_0.F217FA96("[name=\"new_password\"],[name=\"password_new\"]");
												}
												chrome_0.method_63(30);
											}
											continue;
										}
										text11 = "login";
										break;
									}
									if (Regex.IsMatch(chrome_0.AFACE5B4(), "/friends/") || chrome_0.D7A424AE("a[href*='/friends/']") || chrome_0.GetURL().Contains("facebook.com/home.php"))
									{
										E589F93F(int_3, "Live");
										method_130(int_3, "Đăng nhập thành công!");
										return true;
									}
									text11 = "unknow";
									break;
								}
								text11 = "unknow";
								break;
							}
							List<string> list = chrome_0.method_14("var s='';document.getElementsByName('verification_method').forEach(element => {s+=element.value+'|'}); return s;").ToString().TrimEnd('|')
								.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries)
								.ToList();
							for (int j = 0; j < list.Count; j++)
							{
								text11 = text11 + CommonRequest.BB254EB6(list[j]) + "-";
							}
							text11 = text11.TrimEnd('-');
							break;
						}
						text11 = "956";
						if (flag)
						{
							E589F93F(int_3, "Checkpoint: " + text11);
							if (C5034B95.smethod_0("configCheckpoint").method_3("ckbXuatLink956"))
							{
								int num7 = C5034B95.smethod_0("configCheckpoint").method_2("nudCountLink956", 1);
								string text16 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtFolderLink956");
								string text17 = Commom.smethod_50("bGV0IGxpbmtzQXJyYXkgPSBbXTsKbGV0IG51bXMgPSB7Y291bnRMaW5rfTsKZm9yIChsZXQgaSA9IDA7IGkgPCBudW1zOyBpKyspIHsKICBsZXQgcmVzcG9uc2UgPSBhd2FpdChhd2FpdCBmZXRjaCgiaHR0cHM6Ly93d3cuZmFjZWJvb2suY29tL2FwaS9ncmFwaHFsLyIsIHsKICAgIGhlYWRlcnM6IHsKICAgICAgImFjY2VwdCI6ICIqLyoiLAogICAgICAiYWNjZXB0LWxhbmd1YWdlIjogImVuLVVTLGVuO3E9MC45IiwKICAgICAgImNvbnRlbnQtdHlwZSI6ICJhcHBsaWNhdGlvbi94LXd3dy1mb3JtLXVybGVuY29kZWQiLAogICAgICAicHJpb3JpdHkiOiAidT0xLCBpIiwKICAgICAgInNlYy1jaC1wcmVmZXJzLWNvbG9yLXNjaGVtZSI6ICJsaWdodCIsCiAgICAgICJzZWMtY2gtdWEiOiAiXCJDaHJvbWl1bVwiO3Y9XCIxMjhcIiwgXCJOb3Q7QT1CcmFuZFwiO3Y9XCIyNFwiLCBcIkdvb2dsZSBDaHJvbWVcIjt2PVwiMTI4XCIiLAogICAgICAic2VjLWNoLXVhLWZ1bGwtdmVyc2lvbi1saXN0IjogIlwiQ2hyb21pdW1cIjt2PVwiMTI4LjAuNjYxMy4xMTVcIiwgXCJOb3Q7QT1CcmFuZFwiO3Y9XCIyNC4wLjAuMFwiLCBcIkdvb2dsZSBDaHJvbWVcIjt2PVwiMTI4LjAuNjYxMy4xMTVcIiIsCiAgICAgICJzZWMtY2gtdWEtbW9iaWxlIjogIj8wIiwKICAgICAgInNlYy1jaC11YS1tb2RlbCI6ICJcIlwiIiwKICAgICAgInNlYy1jaC11YS1wbGF0Zm9ybSI6ICJcIldpbmRvd3NcIiIsCiAgICAgICJzZWMtY2gtdWEtcGxhdGZvcm0tdmVyc2lvbiI6ICJcIjEwLjAuMFwiIiwKICAgICAgInNlYy1mZXRjaC1kZXN0IjogImVtcHR5IiwKICAgICAgInNlYy1mZXRjaC1tb2RlIjogImNvcnMiLAogICAgICAic2VjLWZldGNoLXNpdGUiOiAic2FtZS1vcmlnaW4iLAogICAgICAieC1hc2JkLWlkIjogIjEyOTQ3NyIsCiAgICAgICJ4LWZiLWZyaWVuZGx5LW5hbWUiOiAiQ29tZXRJWFRGYWNlYm9va0F1dGhlbnRpY2l0eVdpemFyZFRyaWdnZXJSb290UXVlcnkiLAogICAgICAieC1mYi1sc2QiOiAiT3J3QjZkRGZsYk41SFZoZnVoZklTSCIKICAgIH0sCiAgICByZWZlcnJlcjogImh0dHBzOi8vd3d3LmZhY2Vib29rLmNvbS9jaGVja3BvaW50LzgyODI4MTAzMDkyNzk1Ni8/bmV4dD1odHRwcyUzQSUyRiUyRnd3dy5mYWNlYm9vay5jb20lMkYiLAogICAgcmVmZXJyZXJQb2xpY3k6ICJzdHJpY3Qtb3JpZ2luLXdoZW4tY3Jvc3Mtb3JpZ2luIiwKICAgIGJvZHk6IG5ldyBVUkxTZWFyY2hQYXJhbXMoewogICAgICAiX19hIjogIjEiLAogICAgICAiZmJfZHRzZyI6IHJlcXVpcmUoIkRUU0dJbml0aWFsRGF0YSIpLnRva2VuLAogICAgICAidmFyaWFibGVzIjogSlNPTi5zdHJpbmdpZnkoewogICAgICAgICJpbnB1dCI6IHsKICAgICAgICAgICJhdXRoZW50aWNpdHlfcHJvZHVjdCI6ICJDSEVDS1BPSU5UX0VQU0lMT05fU0VMRklFIiwKICAgICAgICAgICJjb3VudHJ5IjogbnVsbCwKICAgICAgICAgICJsb2NhdGlvbiI6ICJDSEVDS1BPSU5UX0ZSQU1FV09SSyIsCiAgICAgICAgICAibG9nZ2VyX3Nlc3Npb25faWQiOiBudWxsLAogICAgICAgICAgIm1zaXRlX2hhbmRvZmZfaWQiOiBudWxsLAogICAgICAgICAgIm5leHRfdXJpIjogbnVsbCwKICAgICAgICAgICJzZWN1cml0eV90b2tlbiI6IG51bGwsCiAgICAgICAgICAidHJpZ2dlcl9ldmVudF90eXBlIjogIkFVVEhFTlRJQ0lUWV9XSVpBUkRfVFJJR0dFUiIsCiAgICAgICAgICAibnRfY29udGV4dCI6IG51bGwsCiAgICAgICAgICAidHJpZ2dlcl9zZXNzaW9uX2lkIjogIjNlMGYzMjE0LTJhZWItNGQwZS1iY2IwLTI5NDE2OWRhNDQyMCIKICAgICAgICB9LAogICAgICAgICJzY2FsZSI6IDEKICAgICAgfSksCiAgICAgICJzZXJ2ZXJfdGltZXN0YW1wcyI6ICJ0cnVlIiwKICAgICAgImRvY19pZCI6ICI4NTE3MTkyNzY4MzAwODA3IgogICAgfSksCiAgICBtZXRob2Q6ICJQT1NUIiwKICAgIG1vZGU6ICJjb3JzIiwKICAgIGNyZWRlbnRpYWxzOiAiaW5jbHVkZSIKICB9KSkuanNvbigpCiAgbGV0IGxpbmsgPSAiaHR0cHM6Ly9tLmZhY2Vib29rLmNvbS9peHQvcmVuZGVyc2NyZWVuL21zaXRlLz9zZXJpYWxpemVkX3N0YXRlPSIgKyByZXNwb25zZS5kYXRhLml4dF9hdXRoZW50aWNpdHlfd2l6YXJkX3RyaWdnZXIuc2NyZWVuLnZpZXdfbW9kZWwuc2VyaWFsaXplZF9zdGF0ZQogIGNvbnNvbGUubG9nKGxpbmspCiAgbGlua3NBcnJheS5wdXNoKGxpbmspOwp9CnJldHVybiBsaW5rc0FycmF5LmpvaW4oJ3wnKQ==");
								text17 = text17.Replace("{countLink}", num7.ToString());
								List<string> list2 = chrome_0.method_14(text17).Split('|').ToList()
									.AF1855B2();
								if (list2.Count > 0)
								{
									File.WriteAllText(text16 + "\\956-" + chrome_0.FB94939A() + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt", string.Join("\n", list2));
									method_130(int_3, $"Đa\u0303 xuâ\u0301t {list2.Count} link!");
								}
								else
								{
									method_130(int_3, "Không lâ\u0301y đươ\u0323c link!");
								}
								return false;
							}
							bool flag6 = false;
							switch (num)
							{
							case 1:
								flag6 = method_57(chrome_0, int_3, string_1);
								break;
							case 2:
								flag6 = F30E23B7(chrome_0, int_3, string_1);
								break;
							case 3:
							{
								RequestXNet a22DAD = new RequestXNet(chrome_0.method_40(), chrome_0.method_9(), chrome_0.A3A32284, chrome_0.Int32_1);
								flag6 = B7B2DA04(int_3, string_1, a22DAD);
								break;
							}
							}
							if (flag6)
							{
								E589F93F(int_3, "Live");
								method_130(int_3, "Unlock checkpoint success!");
							}
							C412B9A5(int_3, (!flag6) ? 1 : 2);
							return flag6;
						}
						for (int k = 0; k < 2; k++)
						{
							string text18 = chrome_0.AFACE5B4();
							if (!Commom.smethod_88(text18))
							{
								if (!Commom.DFBE4C36(text18))
								{
									if (chrome_0.method_61() == 3)
									{
										break;
									}
									chrome_0.method_12("https://d.facebook.com/");
									chrome_0.F8091028(2.0);
									continue;
								}
								text11 += "-Tìm hiểu thêm";
								break;
							}
							text11 += "-Bắt đầu";
							break;
						}
						break;
					}
					text11 = "282";
					if (!flag2)
					{
						break;
					}
					E589F93F(int_3, "Checkpoint: " + text11);
					if (chrome_0 != null)
					{
						string imgDir = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPathImage");
						int solve282 = CheckpointClassifier.SolveCheckpoint282(chrome_0, imgDir, (msg) => method_130(int_3, string_1 + msg));
						if (solve282 == 1)
						{
							method_130(int_3, string_1 + Language.GetValue("Đợi xét duyệt (Upload selfie OK)"));
							method_134(int_3, "cStatus282", "Đợi xét duyệt (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")", "status282");
							E589F93F(int_3, "Đợi xét duyệt (Upload selfie OK)");
							C412B9A5(int_3, 2);
							return false;
						}
					}
					RequestXNet requestXNet_ = new RequestXNet(chrome_0.method_40(), "", chrome_0.A3A32284, chrome_0.Int32_1);
					B630B9AA(int_3, string_1, requestXNet_, "", chrome_0);
					return false;
				}
				text11 = "vhh";
				break;
			}
			text11 = "spam";
			break;
		}
		goto IL_120c;
		IL_068f:
		if (flag3)
		{
			F0A81525(chrome_0.AF336B2C, "pass", int_3, "cPassword", text10);
			chrome_0.C234EEAA = text10;
			return true;
		}
		E589F93F(int_3, "Checkpoint: Đổi pass");
		method_130(int_3, string_1 + "Checkpoint: Đổi pass");
		return false;
	}

	private bool method_57(Chrome chrome_0, int C72B033C, string string_1)
	{
		return false;
	}

	private bool EB32900A(Chrome F631021C, int AE2D5F21, string DC8D1B26)
	{
		string string_3 = F6061E95(AE2D5F21, "cUid").ToLower();
		string text = F6061E95(AE2D5F21, "cPassword");
		string string_2 = F6061E95(AE2D5F21, "cEmail").ToLower();
		string string_4 = F6061E95(AE2D5F21, "cPassMail");
		string a8382C3C = F6061E95(AE2D5F21, "cOAuth2");
		string a5A6E = F6061E95(AE2D5F21, "cCookieHotmail");
		Chrome chrome = new Chrome
		{
			Boolean_2 = true,
			F5BA98AC = Commom.E50AD706(5, 2),
			Point_0 = new Point(-2000, 0),
			Boolean_3 = true,
			DA9C9817 = "data:,"
		};
		method_130(AE2D5F21, DC8D1B26 + "Unlock checkpoint...");
		F631021C.method_53();
		if (F631021C.method_61() != 1)
		{
			F631021C.method_12("https://www.facebook.com");
		}
		string text2 = "";
		string text3 = "";
		int num = 0;
		int num2 = 2;
		int num3 = 0;
		int num4 = 3;
		bool result = false;
		int tickCount = Environment.TickCount;
		int num5 = 600000;
		while (true)
		{
			string text4 = F631021C.method_15(0.0, new List<string> { "#checkpointSubmitButton[name=\"submit[Continue]\"]", "#checkpointSubmitButton[name=\"submit[Yes]\"]", "[name=\"password_new\"]", "[href=\"/help/117450615006715\"]" });
			switch (text4)
			{
			case "#checkpointSubmitButton[name=\"submit[Continue]\"]":
				if (F631021C.D7A424AE("[name=\"verification_method\"]"))
				{
					List<string> list = F631021C.method_14("var s='';document.getElementsByName('verification_method').forEach(element => {s+=element.value+'|'}); return s;").ToString().TrimEnd('|')
						.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries)
						.ToList();
					string text6 = "";
					for (int i = 0; i < list.Count; i++)
					{
						text6 = text6 + CommonRequest.BB254EB6(list[i]) + "-";
					}
					text6 = text6.TrimEnd('-');
					E589F93F(AE2D5F21, "Checkpoint: " + text6);
					if (!list.Contains("37"))
					{
						method_130(AE2D5F21, DC8D1B26 + "Checkpoint: " + text6);
						break;
					}
					if (string_2.IndexOf('@') <= 0)
					{
						method_130(AE2D5F21, "Unlock checkpoint fail (Mail không hợp lệ)!");
						break;
					}
					F631021C.method_21("[name=\"verification_method\"][value=\"37\"]");
					F631021C.method_18("#checkpointSubmitButton");
				}
				else
				{
					if (F631021C.D7A424AE("[name=\"send_code\"]"))
					{
						if (F631021C.D7A424AE("[name=\"captcha_response\"]"))
						{
							num3++;
							if (num3 >= num4)
							{
								method_130(AE2D5F21, DC8D1B26 + Language.GetValue("Không lấy được otp!"));
								return false;
							}
							string text7 = FB93BDA4.GetOtpFromMail(1, string_2, string_4, a8382C3C, a5A6E, 60, string_3, text3);
							if (text7 == "fail")
							{
								text7 = method_58(chrome, AE2D5F21, 1, 60, text3);
								if (text7 == "fail")
								{
									method_130(AE2D5F21, DC8D1B26 + Language.GetValue("Không thể kết nối mail!"));
									return false;
								}
							}
							if (text7 != "" && text7 == text3)
							{
								num++;
								if (num < num2)
								{
									text7 = "";
								}
							}
							if (text7 == "")
							{
								F631021C.method_18("[name=\"send_code\"]");
								goto IL_0425;
							}
							text3 = text7;
							F631021C.method_29("[name=\"captcha_response\"]");
							F631021C.method_22("[name=\"captcha_response\"]", text7);
							F631021C.F8091028(1.0);
						}
						if (F631021C.D7A424AE("input[name=\"eindex\"]"))
						{
							List<string> list2 = F631021C.method_14("arr = []; document.querySelectorAll('input[name=\"eindex\"]').forEach(e => arr.push(e.value)); return arr.join('|');").ToString().Split('|')
								.ToList();
							if (list2[0].Contains("@"))
							{
								string text8 = list2.Where((string string_1) => string_1.Contains(string_2.Substring(string_2.IndexOf('@') - 1, 3)) && string_1.StartsWith(string_2.Substring(0, 1)) && string_1.EndsWith(string_2.Substring(string_2.LastIndexOf('.')))).FirstOrDefault();
								if (string.IsNullOrEmpty(text8))
								{
									method_130(AE2D5F21, DC8D1B26 + Language.GetValue("Fb bắt xác minh email không có trên tool") + "!");
									return false;
								}
								text3 = FB93BDA4.GetOtpFromMail(1, string_2, string_4, a8382C3C, a5A6E, 0, string_3, "");
								if (text3 == "fail")
								{
									text3 = method_58(chrome, AE2D5F21, 1, 0);
									if (text3 == "fail")
									{
										method_130(AE2D5F21, DC8D1B26 + Language.GetValue("Không thể kết nối mail!"));
										return false;
									}
								}
								F631021C.method_21("input[name=\"eindex\"][value=\"" + text8 + "\"]");
								F631021C.F8091028(1.0);
							}
						}
					}
					F631021C.method_18(text4);
				}
				goto IL_0425;
			default:
			{
				string text5 = F631021C.GetURL();
				if (!text5.Contains("828281030927956"))
				{
					if (!text5.Contains("1501092823525282"))
					{
						if (!text5.Contains("465803052217681"))
						{
							if (F631021C.A084051A())
							{
								result = true;
								break;
							}
							goto IL_0425;
						}
						E589F93F(AE2D5F21, "Checkpoint: login");
						method_130(AE2D5F21, DC8D1B26 + "Unlock checkpoint fail");
						break;
					}
					E589F93F(AE2D5F21, "Checkpoint: 282");
					method_130(AE2D5F21, DC8D1B26 + "Checkpoint: 282");
					break;
				}
				E589F93F(AE2D5F21, "Checkpoint: 956");
				method_130(AE2D5F21, DC8D1B26 + "Checkpoint 956!");
				C412B9A5(AE2D5F21, 1);
				break;
			}
			case "[name=\"password_new\"]":
				if (!(text2 != ""))
				{
					text2 = Commom.smethod_77();
					if (F631021C.D7A424AE("[name=\"password_old\"]"))
					{
						F631021C.method_29("[name=\"password_old\"]");
						F631021C.method_22("[name=\"password_old\"]", text);
						F631021C.F8091028(1.0);
					}
					F631021C.method_29(text4);
					F631021C.method_22(text4, text2);
					F631021C.F8091028(1.0);
					F631021C.method_29("[name=\"password_confirm\"]");
					F631021C.method_22("[name=\"password_confirm\"]", text2);
					method_134(AE2D5F21, "cPassword", text2, "pass");
					F631021C.C234EEAA = text2;
					F631021C.method_18("#checkpointSubmitButton[name=\"submit[Next]\"]");
					goto IL_0425;
				}
				method_134(AE2D5F21, "cPassword", text, "pass");
				F631021C.C234EEAA = text;
				method_130(AE2D5F21, "Unlock checkpoint fail (Lỗi đổi pass mới)!");
				break;
			case "#checkpointSubmitButton[name=\"submit[Yes]\"]":
				F631021C.method_18(text4);
				goto IL_0425;
			case "[href=\"/help/117450615006715\"]":
				{
					E589F93F(AE2D5F21, "Checkpoint: login");
					method_130(AE2D5F21, "Unlock checkpoint fail (Không phương thức giải)!");
					break;
				}
				IL_0425:
				if (Environment.TickCount - tickCount < num5)
				{
					goto IL_0439;
				}
				method_130(AE2D5F21, "Unlock checkpoint fail (Timeout)!");
				break;
			}
			break;
			IL_0439:
			F631021C.F8091028(2.0);
			F631021C.method_33("#checkpointSubmitButton[disabled]", 30);
		}
		F631021C.method_54();
		chrome.A4B307B3();
		return result;
	}

	private bool F30E23B7(Chrome chrome_0, int int_3, string string_1)
	{
		string string_2 = F6061E95(int_3, "cUid").ToLower();
		string text = F6061E95(int_3, "cEmail").ToLower();
		string string_3 = F6061E95(int_3, "cPassMail");
		string a8382C3C = F6061E95(int_3, "cOAuth2");
		string a5A6E = F6061E95(int_3, "cCookieHotmail");
		Chrome chrome = new Chrome
		{
			Boolean_2 = true,
			F5BA98AC = Commom.E50AD706(5, 2),
			Point_0 = new Point(-2000, 0),
			Boolean_3 = true,
			DA9C9817 = "data:,"
		};
		string text2 = F6061E95(int_3, "cBirthday");
		string text3 = "";
		string text4 = "";
		string text5 = "";
		int num = 0;
		method_130(int_3, string_1 + "Unlock 956...");
		chrome_0.method_49();
		chrome_0.method_53();
		chrome_0.method_12("https://facebook.com/");

		// Thử giải bằng CheckpointClassifier.SolveCheckpoint956 DOM tự động
		try
		{
			int solve956Res = CheckpointClassifier.SolveCheckpoint956(chrome_0, text, string_3, (m) => {
				try { method_130(int_3, string_1 + m); } catch { }
			});
			if (solve956Res == 1)
			{
				method_130(int_3, string_1 + "Đã vượt qua Checkpoint 956 thành công!");
				return true;
			}
		}
		catch { }

		string text6 = "";
		int num2 = 0;
		int num3 = 2;
		string text7 = "";
		int num4 = 0;
		int num5 = 3;
		bool result = false;
		int tickCount = Environment.TickCount;
		int num6 = 60000; // Hardened: 60s timeout tự động, không để treo luồng bot
		while (!chrome_0.E184CD03())
		{
			string text8 = chrome_0.GetURL();
			if (!text8.Contains("1501092823525282"))
			{
				string text9 = chrome_0.method_15(3.0, new List<string>
				{
					"[role=\"progressbar\"]", "[aria-label=\"Confirm your identity\"] [value*=\"@\"]", "[aria-label=\"Confirm your identity\"] [aria-label=\"Confirmation code\"] input", "[aria-label=\"Close\"]", "[aria-label=\"Next\"],[aria-label=\"Tiếp\"]", "[aria-label=\"Get started\"],[aria-label=\"Get Started\"],[aria-label=\"Start security steps\"],[aria-label=\"Bắt đầu\"]", "[aria-label=\"Get code\"],[aria-label=\"Nhận mã\"]", "[aria-label=\"Type or paste code\"],[aria-label=\"Nhập hoặc dán mã\"]", "[aria-label=\"Enter new password\"]", "[aria-label=\"Back to Facebook\"],[aria-label=\"Quay lại Facebook\"]",
					"[role=\"dialog\"][aria-label=\"Do you want to exit?\"] [aria-label=\"Back\"]"
				});
				string text10 = text9;
				string text11 = text10;
				uint num7 = AFAE75A0.smethod_0(text11);
				if (num7 <= 1880862350)
				{
					if (num7 <= 1751384147)
					{
						if (num7 != 361401288)
						{
							if (num7 == 1751384147 && text11 == "[aria-label=\"Get code\"],[aria-label=\"Nhận mã\"]")
							{
								goto IL_080a;
							}
						}
						else if (text11 == "[aria-label=\"Close\"]")
						{
							if (!chrome_0.D7A424AE("[aria-label=\"Loading...\"][role=\"dialog\"]"))
							{
								if (chrome_0.D7A424AE("[href*=\"facebook.com/help/contact/571927962827151\"]"))
								{
									method_130(int_3, "Checkpoint: 956 (fb block)");
									E589F93F(int_3, "Checkpoint: 956 (fb block)");
									break;
								}
								if (chrome_0.D7A424AE("[role=\"dialog\"] [aria-label=\"Confirm\"]:not([aria-disabled=\"true\"])"))
								{
									text9 = "[role=\"dialog\"] [aria-label=\"Confirm\"]:not([aria-disabled=\"true\"])";
								}
								chrome_0.method_21(text9);
							}
							goto IL_0bf2;
						}
					}
					else
					{
						if (num7 != 1792331266)
						{
							if (num7 != 1821727478)
							{
								if (num7 != 1880862350 || !(text11 == "[role=\"progressbar\"]"))
								{
									goto IL_0919;
								}
								if (chrome_0.A084051A())
								{
									result = true;
									break;
								}
							}
							else
							{
								if (!(text11 == "[aria-label=\"Get started\"],[aria-label=\"Get Started\"],[aria-label=\"Start security steps\"],[aria-label=\"Bắt đầu\"]"))
								{
									goto IL_0919;
								}
								if (chrome_0.E821BD02("help us confirm your identity"))
								{
									text7 = text7 + ((text7 == "") ? "" : "-") + "Xmdt";
									method_130(int_3, "Checkpoint: 956 (" + text7 + ")");
									E589F93F(int_3, "Checkpoint: 956 (" + text7 + ")");
									break;
								}
								chrome_0.method_21(text9);
							}
							goto IL_0bf2;
						}
						if (text11 == "[aria-label=\"Confirm your identity\"] [aria-label=\"Confirmation code\"] input")
						{
							goto IL_0356;
						}
					}
				}
				else if (num7 <= 2937712415u)
				{
					if (num7 != 2009751771)
					{
						if (num7 != 2282888910u)
						{
							if (num7 == 2937712415u && text11 == "[aria-label=\"Type or paste code\"],[aria-label=\"Nhập hoặc dán mã\"]")
							{
								goto IL_0356;
							}
						}
						else if (text11 == "[aria-label=\"Next\"],[aria-label=\"Tiếp\"]")
						{
							if (chrome_0.D7A424AE("//*[text()=\"Enter your birthday\" or text()=\"Enter your date of birth\"]"))
							{
								if (text2 == "" || text2.Split('/').Length < 3)
								{
									method_130(int_3, "Checkpoint ngày sinh (Không có ngày sinh)!");
									break;
								}
								num++;
								if (num == 1)
								{
									text3 = text2.Split('/')[1];
									text4 = text2.Split('/')[0];
									text5 = text2.Split('/')[2];
								}
								else
								{
									if (num != 2)
									{
										method_130(int_3, "Checkpoint ngày sinh (Sai ngày sinh)!");
										break;
									}
									text3 = text2.Split('/')[0];
									text4 = text2.Split('/')[1];
									text5 = text2.Split('/')[2];
								}
								if (text3.Length == 1)
								{
									text3 = "0" + text3;
								}
								if (text4.Length == 1)
								{
									text4 = "0" + text4;
								}
								chrome_0.method_29("[aria-label=\"day\"] input[type=\"text\"]");
								chrome_0.method_22("[aria-label=\"day\"] input[type=\"text\"]", text3);
								chrome_0.F8091028(1.0);
								chrome_0.method_29("[aria-label=\"month\"] input[type=\"text\"]");
								chrome_0.method_22("[aria-label=\"month\"] input[type=\"text\"]", text4);
								chrome_0.F8091028(1.0);
								chrome_0.method_29("[aria-label=\"year\"] input[type=\"text\"]");
								chrome_0.method_22("[aria-label=\"year\"] input[type=\"text\"]", text5);
								chrome_0.F8091028(1.0);
							}
							chrome_0.method_21(text9);
							goto IL_0bf2;
						}
					}
					else if (text11 == "[aria-label=\"Enter new password\"]")
					{
						string text12 = "";
						string text13 = "";
						for (int i = 0; i < 5; i++)
						{
							if (!(text12 != ""))
							{
								goto IL_0716;
							}
							chrome_0.method_21("[aria-label=\"Save changes\"],[aria-label=\"Confirm password\"]");
							bool flag = false;
							int num8 = 0;
							while (true)
							{
								if (num8 < 60)
								{
									if (!chrome_0.D7A424AE("//*[contains(text(),\"Your new login\")]"))
									{
										if (chrome_0.D7A424AE("//*[contains(text(),\"Error performing query\")]") || chrome_0.D7A424AE("//*[contains(text(),\"Something went wrong\")]"))
										{
											break;
										}
										if (!chrome_0.D7A424AE("[aria-label=\"Close\"]"))
										{
											chrome_0.F8091028(1.0);
											num8++;
											continue;
										}
										chrome_0.method_18("[aria-label=\"Close\"]");
									}
									else
									{
										flag = true;
									}
								}
								if (!flag)
								{
									goto IL_0716;
								}
								goto IL_0bf2;
							}
							goto IL_0d07;
							IL_0716:
							if (!(text13 != chrome_0.method_14("return document.documentElement.innerText;").ToString()))
							{
								continue;
							}
							if (!chrome_0.GetURL().Contains("1501092823525282"))
							{
								text12 = Commom.smethod_77();
								chrome_0.method_29("input[type=\"password\"]");
								chrome_0.method_22("input[type=\"password\"]", text12);
								method_134(int_3, "cPassword", text12, "pass");
								chrome_0.C234EEAA = text12;
								chrome_0.F8091028(1.0);
								text13 = chrome_0.method_14("return document.documentElement.innerText;").ToString();
								continue;
							}
							goto IL_0d29;
						}
						goto IL_0bf2;
					}
				}
				else if (num7 != 3438714969u)
				{
					if (num7 != 3474437577u)
					{
						if (num7 == 4128441967u && text11 == "[role=\"dialog\"][aria-label=\"Do you want to exit?\"] [aria-label=\"Back\"]")
						{
							chrome_0.method_18(text9);
							goto IL_0bf2;
						}
					}
					else if (text11 == "[aria-label=\"Confirm your identity\"] [value*=\"@\"]")
					{
						goto IL_080a;
					}
				}
				else if (text11 == "[aria-label=\"Back to Facebook\"],[aria-label=\"Quay lại Facebook\"]")
				{
					if (chrome_0.A084051A())
					{
						result = true;
					}
					else
					{
						method_130(int_3, "Unlock checkpoint fail (1)!");
					}
					break;
				}
				goto IL_0919;
			}
			E589F93F(int_3, "Checkpoint: 282");
			method_130(int_3, string_1 + "Checkpoint: 282");
			break;
			IL_080a:
			string text14 = text.Substring(text.IndexOf('@') - 1, 3);
			if (chrome_0.D7A424AE("//*[contains(text(),\"" + text14 + "\")]"))
			{
				text6 = FB93BDA4.GetOtpFromMail(1, text, string_3, a8382C3C, a5A6E, 0, string_2, "");
				if (text6 == "fail")
				{
					text6 = method_58(chrome, int_3, 1, 0);
					if (text6 == "fail")
					{
						method_130(int_3, string_1 + Language.GetValue("Không thể kết nối mail!"));
						break;
					}
				}
				chrome_0.method_21("//*[contains(text(),\"" + text14 + "\")]");
				chrome_0.F8091028(1.0);
				string text9 = chrome_0.method_15(0.0, new List<string> { "[aria-label=\"Get code\"],[aria-label=\"Nhận mã\"]", "[aria-label=\"Next\"]" });
				chrome_0.method_21(text9);
				chrome_0.F8091028(2.0);
				chrome_0.method_33("[aria-label=\"Next\"] [data-visualcompletion=\"loading-state\"]", 60);
				goto IL_0bf2;
			}
			method_130(int_3, string_1 + Language.GetValue("Fb bắt xác minh email không có trên tool") + "!");
			break;
			IL_0d29:
			E589F93F(int_3, "Checkpoint: 282");
			method_130(int_3, string_1 + "Checkpoint: 282");
			break;
			IL_0d07:
			if (chrome_0.A084051A())
			{
				result = true;
			}
			else
			{
				method_130(int_3, "Unlock checkpoint fail (3)!");
			}
			break;
			IL_0919:
			if (chrome_0.D7A424AE("//*[contains(text(),\"verification challenge\")]"))
			{
				if (chrome_0.method_14("return document.querySelector('input[type=\"text\"]').value+'';").ToString() != "")
				{
					chrome_0.method_13();
				}
				else
				{
					int num9 = C5034B95.smethod_0("configCheckpoint").method_2("typeCaptcha");
					string text15 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + num9);
					if (text15 == "" && !DB81C53D.smethod_2(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4")))
					{
						method_130(int_3, "Facebook bắt giải captcha!");
						break;
					}
					string value = Regex.Match(chrome_0.AFACE5B4(), "src=\"(https://www.facebook.com/captcha/tfbimage.*?)\"").Groups[1].Value;
					string text16 = Commom.A794F28D(chrome_0.method_40(), value);
					if (text16 == "")
					{
						Refresh();
					}
					else
					{
						string text17 = GClass2.smethod_1(num9, text15, text16);
						if (text17 != "")
						{
							chrome_0.method_22("input[type=\"text\"]", text17);
							chrome_0.F8091028(1.0);
							chrome_0.method_18("[aria-label=\"Confirm\"]");
						}
						else
						{
							chrome_0.method_13();
						}
					}
				}
			}
			else
			{
				if (chrome_0.D7A424AE("//*[text()=\"No longer available\"]"))
				{
					method_130(int_3, "Không có phương thức giải!");
					break;
				}
				if (chrome_0.D7A424AE("//*[contains(text(),\"t remove anything\") or contains(text(),\"t Remove Anything\")]"))
				{
					if (C5034B95.smethod_0("configCheckpoint").method_3("ckbDeleteContact"))
					{
						chrome_0.method_14("var email = '" + text + "'; document.querySelectorAll('[role=\"listitem\"]').forEach(e => {if(!e.innerText.toLowerCase().includes(email.toLowerCase())) e.querySelector('[role=\"checkbox\"]').click()})");
						chrome_0.F8091028(1.0);
						chrome_0.method_21("[aria-label=\"Confirm\"]");
					}
					else
					{
						chrome_0.method_21("//*[contains(text(),\"t remove anything\") or contains(text(),\"t Remove Anything\")]");
					}
				}
				else if (chrome_0.D7A424AE("[role=\"dialog\"] [aria-label=\"Confirm\"]:not([aria-disabled=\"true\"])"))
				{
					chrome_0.method_21("[role=\"dialog\"] [aria-label=\"Confirm\"]:not([aria-disabled=\"true\"])");
				}
				else
				{
					if (!chrome_0.D7A424AE("//*[text()=\"Confirm\"]"))
					{
						if (chrome_0.D7A424AE("//*[text()=\"Enter your birthday\" or text()=\"Enter your date of birth\"]"))
						{
							text7 = "Birthday";
							if (text2.Split('/').Length == 3)
							{
								chrome_0.method_21("//*[text()=\"Enter your birthday\" or text()=\"Enter your date of birth\"]");
								goto IL_0bf2;
							}
						}
						if (chrome_0.D7A424AE("//*[text()=\"Get a code by email\" or text()=\"Nhận mã qua email\"]"))
						{
							text7 = text7 + ((text7 == "") ? "" : "-") + "Otp mail";
							if (text != "")
							{
								chrome_0.method_21("//*[text()=\"Get a code by email\" or text()=\"Nhận mã qua email\"]");
								goto IL_0bf2;
							}
						}
						if (chrome_0.D7A424AE("//*[text()=\"Confirm your identity\" or text()=\"Xác nhận danh tính của bạn\"]"))
						{
							text7 = text7 + ((text7 == "") ? "" : "-") + "Xmdt";
						}
						if (chrome_0.D7A424AE("//*[text()=\"Get a code on your phone\"]"))
						{
							text7 = text7 + ((text7 == "") ? "" : "-") + "Phone";
						}
						if (chrome_0.D7A424AE("//*[text()=\"Verify your credit card\"]"))
						{
							text7 = text7 + ((text7 == "") ? "" : "-") + "Verify card";
						}
						if (text7 != "")
						{
							method_130(int_3, "Checkpoint: 956 (" + text7 + ")");
							E589F93F(int_3, "Checkpoint: 956 (" + text7 + ")");
							break;
						}
						if (chrome_0.A084051A())
						{
							result = true;
							break;
						}
						string c53E8F2E = chrome_0.AFACE5B4();
						if (Commom.DFBE4C36(c53E8F2E))
						{
							E589F93F(int_3, "Checkpoint: 956-Tìm hiểu thêm");
							method_130(int_3, "Checkpoint: 956-Tìm hiểu thêm");
						}
						else
						{
							method_130(int_3, "Unlock checkpoint fail (2)!");
						}
						break;
					}
					chrome_0.method_21("//*[text()=\"Confirm\"]");
				}
			}
			goto IL_0bf2;
			IL_0356:
			num4++;
			if (num4 <= num5)
			{
				string text18 = chrome_0.method_15(0.0, new List<string> { "//*[contains(text(),\"Resend code\")]", "//*[contains(text(),\"Get a new code\")]", "//*[contains(text(),\"Gửi lại mã\")]" });
				if (text18 != "")
				{
					chrome_0.method_21(text18);
				}
				string text19 = FB93BDA4.GetOtpFromMail(1, text, string_3, a8382C3C, a5A6E, 60, string_2, text6);
				if (text19 == "fail")
				{
					text19 = method_58(chrome, int_3, 1);
					if (text19 == "fail")
					{
						method_130(int_3, string_1 + Language.GetValue("Không thể kết nối mail!"));
						break;
					}
				}
				if (text19 != "" && text19 == text6)
				{
					num2++;
					if (num2 < num3)
					{
						text19 = "";
					}
				}
				if (text19 == "")
				{
					chrome_0.method_21(text18);
				}
				else
				{
					text6 = text19;
					chrome_0.method_29("input[type=\"text\"]");
					chrome_0.method_22("input[type=\"text\"]", text19);
					chrome_0.F8091028(1.0);
					chrome_0.method_18("[aria-label=\"Submit\"],[aria-label=\"Gửi\"],[aria-label=\"Next\"]:not([aria-disabled=\"true\"])");
				}
				goto IL_0bf2;
			}
			method_130(int_3, string_1 + Language.GetValue("Không lấy được otp!"));
			break;
			IL_0bf2:
			if (Environment.TickCount - tickCount < num6)
			{
				chrome_0.F8091028(2.0);
				continue;
			}
			method_130(int_3, "Unlock checkpoint fail (Timeout)!");
			Commom.smethod_57(chrome_0, null, "Unlock 956");
			break;
		}
		chrome_0.method_54();
		chrome.A4B307B3();
		return result;
	}

	private string method_58(Chrome chrome_0, int int_3, int ADA00429, int int_4 = 60, string A7AB8FBA = "")
	{
		if (!C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetOtpHotmailChrome"))
		{
			return "fail";
		}
		string text = F6061E95(int_3, "cUid").ToLower();
		string text2 = F6061E95(int_3, "cEmail").ToLower();
		string text3 = F6061E95(int_3, "cPassMail");
		string text4 = F6061E95(int_3, "cMailRecovery");
		string string_ = F6061E95(int_3, "cPassMailRecovery");
		string string_2 = text3;
		string string_3 = text4;
		string text5 = chrome_0.DDA19A0D(text2, ref string_2, ref string_3, ref string_);
		if (string_3 != "" && string_3 != text4)
		{
			text4 = string_3;
			method_134(int_3, "cMailRecovery", text4, "mailrecovery");
			method_134(int_3, "cPassMailRecovery", string_, "passmailrecovery");
		}
		if (string_2 != text3)
		{
			text3 = string_2;
			method_134(int_3, "cPassMail", text3, "passmail");
		}
		if (text5 == "" || text5 == "fail")
		{
			return "fail";
		}
		string text6 = D831098B.GetOtpHotmailByCookie(ADA00429, text2, text5, int_4, text, A7AB8FBA);
		if (text6 == "")
		{
			text6 = A7AB8FBA;
		}
		return text6;
	}

	private int E385342B(int int_3, string string_1, Chrome chrome_0, GClass4 AF2DFB36, string EBA8242B)
	{
		int result = 0;
		int num = Base.rd.Next(AF2DFB36.method_2("nudSoLuongFrom"), AF2DFB36.method_2("nudSoLuongTo") + 1);
		try
		{
			chrome_0.method_12("https://m.facebook.com/messages/");
			chrome_0.F8091028(1.0);
			for (int i = 0; i < num; i++)
			{
				if (!chrome_0.D7A424AE("[id*=threadlist_row_other_user_fbid]", 5.0))
				{
					continue;
				}
				chrome_0.method_18("[id*=threadlist_row_other_user_fbid]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[data-sigil=\"select-button select-link touchable\"]", 5.0))
				{
					string string_2 = chrome_0.method_14("return document.querySelector('[value*=\"mm_action=delete\"]').getAttribute('value')").ToString();
					chrome_0.method_47("[data-sigil=\"select-button select-link touchable\"]", string_2);
					chrome_0.F8091028(1.0);
					if (chrome_0.D7A424AE("[href*=\"/messages/action/?mm_action=delete\"]", 5.0))
					{
						chrome_0.method_18("[href*=\"/messages/action/?mm_action=delete\"]");
						chrome_0.F8091028(Base.rd.Next(AF2DFB36.method_2("nudDelayFrom"), AF2DFB36.method_2("nudDelayTo") + 1));
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	private void E431F983(Chrome chrome_0)
	{
		try
		{
			int num;
			do
			{
				chrome_0.method_66("PrivateInfo");
				num = chrome_0.method_125();
			}
			while (num == 1);
		}
		catch
		{
		}
	}

	private void method_59(Chrome chrome_0)
	{
		try
		{
			chrome_0.method_12("https://m.facebook.com/settings/how_people_find_and_contact_you/");
			chrome_0.F8091028(1.0);
			if (chrome_0.D7A424AE("[data-store*=\"8787540733\"]", 20.0))
			{
				chrome_0.method_18("[data-store*=\"8787540733\"]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[name=\"privacyx\"]", 15.0))
				{
					chrome_0.method_17("[name=\"privacyx\"]");
					chrome_0.F8091028(3.0);
				}
			}
			chrome_0.method_12("https://m.facebook.com/settings/framework/msite/posts/?entry_point=unknown");
			chrome_0.F8091028(1.0);
			if (chrome_0.D7A424AE("#root [role=\"button\"]", 15.0))
			{
				chrome_0.method_18("#root [role=\"button\"]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[name=\"privacyx\"]", 15.0))
				{
					chrome_0.method_17("[name=\"privacyx\"]");
					chrome_0.F8091028(3.0);
				}
			}
			chrome_0.method_12("https://m.facebook.com/privacy/touch/timeline_and_tagging");
			chrome_0.F8091028(1.0);
			if (chrome_0.D7A424AE("[data-store*=\"10153940308610734\"]", 15.0))
			{
				chrome_0.method_18("[data-store*=\"10153940308610734\"]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[data-store*=\"286958161406148\"]", 15.0))
				{
					chrome_0.method_17("[data-store*=\"286958161406148\"]");
					chrome_0.F8091028(3.0);
				}
			}
			chrome_0.method_12("https://m.facebook.com/privacy/touch/timeline_and_tagging");
			if (chrome_0.D7A424AE("[data-store*=\"8787530733\"]", 15.0))
			{
				chrome_0.method_18("[data-store*=\"8787530733\"]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[value=\"286958161406148\"]", 15.0))
				{
					chrome_0.method_17("[value=\"286958161406148\"]");
					chrome_0.F8091028(3.0);
				}
			}
		}
		catch
		{
		}
	}

	private int DB92349A(int int_3, string EAB048B8, Chrome chrome_0, GClass4 gclass4_0, string E18256BE, string FB384097)
	{
		int result = 0;
		try
		{
			chrome_0.method_12("https://m.facebook.com/privacy/touch/timeline_and_tagging");
			chrome_0.F8091028(1.0);
			if (chrome_0.D7A424AE("[data-store*=\"8787530733\"]", 15.0))
			{
				chrome_0.method_17("[data-store*=\"8787530733\"]");
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("[data-store*=\"300645083384735\"]", 10.0))
				{
					chrome_0.method_17("[data-store*=\"300645083384735\"]");
					chrome_0.F8091028(3.0);
				}
			}
			chrome_0.method_12("https://m.facebook.com/settings/subscribe/");
			chrome_0.F8091028(1.0);
			if (chrome_0.D7A424AE("[action*=\"can_comment\"] label", 15.0))
			{
				chrome_0.method_34("[action*=\"can_comment\"] label");
				chrome_0.F8091028(1.0);
				chrome_0.method_17("[action*=\"can_comment\"] label");
				chrome_0.method_34("[action*=\"public_profile_media\"] label");
				chrome_0.F8091028(1.0);
				chrome_0.method_17("[action*=\"public_profile_media\"] label");
				chrome_0.F8091028(3.0);
			}
		}
		catch
		{
		}
		return result;
	}

	private int B48B150E(ref string string_1, int int_3, string AAA29134, Chrome chrome_0, GClass4 gclass4_0, string string_2, string string_3)
	{
		int result = 0;
		int num = gclass4_0.method_2("typePass");
		gclass4_0.method_3("ckbUpAvatar");
		gclass4_0.BDB80B23("txtPathImage");
		new List<string>();
		new List<string>();
		gclass4_0.method_3("ckbFollow");
		gclass4_0.method_3("ckbBio");
		Base.rd.Next(gclass4_0.method_2("nudSoLuongFrom"), gclass4_0.method_2("nudSoLuongTo") + 1);
		chrome_0.method_53();
		try
		{
			string_1 = "fail";
			string d10F6D9D = "Minsoft_" + Commom.B820DC86(6, "a");
			if (num == 1)
			{
				d10F6D9D = gclass4_0.BDB80B23("txtPassword");
			}
			chrome_0.method_12("https://www.instagram.com/");
			string text = chrome_0.method_91(d10F6D9D);
			if (Convert.ToBoolean(text.Split('|')[0]))
			{
				string_1 = "success";
				string text2 = text.Substring(text.IndexOf("|") + 1);
				if (text2.Trim('|') != "")
				{
					lock (object_4)
					{
						File.AppendAllText("accountIG.txt", text2 + Environment.NewLine);
					}
				}
			}
			else
			{
				chrome_0.method_12("https://m.facebook.com/home.php");
			}
		}
		catch
		{
		}
		chrome_0.method_54();
		return result;
	}

	private int method_60(Chrome chrome_0, int int_3)
	{
		int result = 1;
		string string_ = F6061E95(int_3, "cPassword");
		try
		{
			chrome_0.method_12("https://m.facebook.com/login_alerts/settings/");
			chrome_0.method_45(2, 3);
			for (int i = 0; i < 2; i++)
			{
				if (!chrome_0.D7A424AE("article [data-sigil=\"touchable\"] a", 5.0))
				{
					continue;
				}
				chrome_0.method_18("article [data-sigil=\"touchable\"] a|" + i);
				chrome_0.F8091028(1.0);
				if (chrome_0.D7A424AE("fieldset label:nth-child(1) [checked=\"1\"]", 5.0))
				{
					chrome_0.method_18("fieldset label:nth-child(1)");
					chrome_0.F8091028(1.0);
					chrome_0.method_18("[type=\"submit\"]");
					chrome_0.F8091028(1.0);
					if (chrome_0.D7A424AE("[type=\"password\"]", 5.0))
					{
						chrome_0.method_22("[type=\"password\"]", string_);
						chrome_0.method_45(2, 3);
						chrome_0.method_18("[type=\"submit\"]");
						chrome_0.method_45(2, 3);
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	private int method_61(int E286DC1D, string D81077BE, Chrome chrome_0, GClass4 gclass4_0, string EA06CA8E)
	{
		List<string> list = gclass4_0.method_1("txtTenPhu");
		if (list == null || list.Count == 0) return 1;
		string nickname = list[Base.rd.Next(0, list.Count)];
		try
		{
			bool ok = ProfileInfoHub.UpdateNickname(chrome_0, nickname);
			return ok ? 1 : 0;
		}
		catch
		{
			return 0;
		}
	}

	private int method_62(int A7092A16, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2)
	{
		int result = 0;
		int num = Base.rd.Next(gclass4_0.method_2("nudSoLuongFrom"), gclass4_0.method_2("nudSoLuongTo") + 1);
		int f8079B = gclass4_0.method_2("nudDelayFrom");
		int num2 = gclass4_0.method_2("nudDelayTo");
		List<string> list = gclass4_0.method_1("txtTuKhoa");
		int num3 = 0;
		string text = "";
		try
		{
			chrome_0.method_12("https://m.facebook.com/profile/intro/edit/public/");
			chrome_0.method_45(2, 3);
			if (chrome_0.D7A424AE("[data-sigil=\"context-layer-root content-pane\"]", 10.0))
			{
				chrome_0.method_20("[role=\"main\"] [role=\"button\"]|" + 6);
				chrome_0.method_18("[role=\"main\"] [role=\"button\"]|" + 6);
				chrome_0.F8091028(1.0);
				string text2 = chrome_0.method_15(10.0, new List<string> { "[data-sigil=\"content-pane\"]>div>div>div>div:nth-child(2)>div:nth-child(3) [data-visualcompletion=\"css-img\"]", "[type=\"text\"]" });
				if (text2 == "[data-sigil=\"content-pane\"]>div>div>div>div:nth-child(2)>div:nth-child(3) [data-visualcompletion=\"css-img\"]")
				{
					chrome_0.method_18("[data-sigil=\"content-pane\"]>div>div>div>div:nth-child(2)>div:nth-child(3) [data-visualcompletion=\"css-img\"]");
					chrome_0.F8091028(1.0);
				}
				else if (text2 == "[type=\"text\"]")
				{
					for (int i = 2; i < num3; i++)
					{
						chrome_0.method_18("[data-visualcompletion=\"css-img\"]|" + i);
						chrome_0.F8091028(1.0);
					}
				}
				if (text2 != "")
				{
					for (int j = 0; j < num; j++)
					{
						text = list[Base.rd.Next(0, list.Count)];
						list.Remove(text);
						chrome_0.method_22("[type=\"text\"]", text);
						chrome_0.method_45(3, 5);
						num3 = Convert.ToInt32(chrome_0.method_14("return document.querySelectorAll('[data-sigil=\"content-pane\"] div:nth-child(2)>div:nth-child(2)>div>div').length").ToString());
						if (num3 > 0)
						{
							chrome_0.method_18("[data-sigil=\"content-pane\"] div:nth-child(2)>div:nth-child(2)>div>div|" + Base.rd.Next(0, num3));
							chrome_0.method_45(f8079B, num2 + 1);
						}
					}
					chrome_0.method_18("[data-sigil=\"content-pane\"] [role=\"button\"]|" + 1);
				}
			}
		}
		catch
		{
			result = 1;
			return 1;
		}
		return result;
	}

	public bool method_63(Chrome FB00CF28, string string_1, string string_2)
	{
		bool result = true;
		try
		{
			string text = string_1 + "\\" + string_2;
			if (Directory.Exists(text) && File.Exists(text + "\\noidung.txt"))
			{
				return true;
			}
			result = false;
			Commom.CreateFolder(text);
			string json = FB00CF28.method_101(string_2);
			JObject jObject = JObject.Parse(json);
			string text2 = jObject["content"]!.ToString();
			if (text2 != "")
			{
				result = true;
				string path = text + "\\noidung.txt";
				File.WriteAllText(path, text2);
			}
			List<string> list = new List<string>();
			JArray jArray = JArray.Parse(jObject["image"]!.ToString());
			for (int i = 0; i < jArray.Count; i++)
			{
				list.Add(jArray[i].ToString());
			}
			if (list.Count > 0)
			{
				result = true;
				string text3 = text + "\\image";
				Commom.CreateFolder(text3);
				for (int j = 0; j < list.Count; j++)
				{
					CommonRequest.smethod_5(list[j], text3, j.ToString());
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public string method_64(Chrome chrome_0, string D50F020B)
	{
		string result = "";
		try
		{
			string text = chrome_0.FB94939A();
			string string_ = "https://m.facebook.com/" + text + "/posts/pcb." + D50F020B;
			string input = chrome_0.C604C58C(string_);
			result = Regex.Match(input, "playable_url_hd:\"(.*?)\"").Groups[1].Value;
		}
		catch
		{
		}
		return result;
	}

	private int method_65(int int_3, string string_1, Chrome chrome_0, int int_4, int int_5, int E59BF10D, int int_6, string string_2)
	{
		int num = 0;
		int num2 = Base.rd.Next(int_4, int_5 + 1);
		try
		{
			chrome_0.method_53();
			int num3;
			do
			{
				chrome_0.method_12("https://www.facebook.com/pages/?category=liked&ref=bookmarks&locale=en_US");
				chrome_0.F8091028(2.0);
				num3 = chrome_0.method_125();
			}
			while (num3 == 1);
			if (new List<int> { -3, -2, -1, 2 }.Contains(num3))
			{
				return -1;
			}
			chrome_0.method_32(400, 0);
			method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num2})...");
			int tickCount = Environment.TickCount;
			int num4 = 30;
			while (Environment.TickCount - tickCount <= num4 * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				string text = chrome_0.method_15(0.0, new List<string> { "[aria-label=\"Following\" i]" });
				string text2 = text;
				string text3 = text2;
				if (text3 == "[aria-label=\"Following\" i]")
				{
					chrome_0.method_19(text);
					method_131(int_3, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_2, num + 1, num2, Language.GetValue("đợi")), E59BF10D, int_6);
					num++;
					if (num >= num2)
					{
						break;
					}
					method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num2})...");
					tickCount = Environment.TickCount;
				}
				chrome_0.F8091028(2.0);
			}
		}
		catch (Exception)
		{
		}
		chrome_0.method_54();
		return num;
	}

	public int method_66(int B39FABB7, string FE2C752B, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "", string FDB3A498 = "")
	{
		int int_ = gclass4_0.method_2("nudTimeFrom");
		int int_2 = gclass4_0.method_2("nudTimeTo");
		int int_3 = gclass4_0.method_2("nudDelayFrom");
		int int_4 = gclass4_0.method_2("nudDelayTo");
		int minValue = gclass4_0.method_2("nudSoLuongUidFrom");
		int num = gclass4_0.method_2("nudSoLuongUidTo");
		bool flag = gclass4_0.method_3("ckbInteract");
		string text = gclass4_0.BDB80B23("typeReaction", "Like");
		bool flag2 = gclass4_0.method_3("ckbComment");
		bool flag3 = gclass4_0.method_3("ckbSendAnh");
		string path = gclass4_0.BDB80B23("txtAnh");
		bool flag4 = gclass4_0.method_3("ckbAutoDeleteComment");
		bool flag5 = gclass4_0.method_3("ckbTuDongXoaUid");
		List<string> list = gclass4_0.method_1("txtIdPost");
		int num2 = 0;
		bool flag7 = false;
		try
		{
			List<string> list2 = new List<string>();
			List<string> list_ = new List<string>();
			List<string> list3 = new List<string>();
			if (flag3 && Directory.Exists(path))
			{
				list_ = Directory.GetFiles(path).ToList();
				list3 = C499BE3B(list_);
			}
			int num3 = Base.rd.Next(minValue, num + 1);
			if (num3 > list.Count)
			{
				num3 = list.Count;
			}
			list = GClass13.smethod_1(list);
			int num4 = 0;
			while (num4 < num3)
			{
				string text2 = "";
				string text3 = "";
				if (flag5)
				{
					lock (dictionary_11)
					{
						if (dictionary_11[FDB3A498].Count == 0)
						{
							break;
						}
						text2 = dictionary_11[FDB3A498][Base.rd.Next(0, dictionary_11[FDB3A498].Count)];
						dictionary_11[FDB3A498].Remove(text2);
						goto IL_01f9;
					}
				}
				text2 = list[num4];
				goto IL_01f9;
				IL_01f9:
				if (Commom.smethod_45(text2))
				{
					text3 = text2;
					text2 = "https://www.facebook.com/" + text3;
				}
				else
				{
					if (text2.StartsWith("http"))
					{
						text3 = Regex.Match(text2, "comment_id=(\\d+)").Groups[1].Value;
						text2 = text2.Replace("mbasic.facebook.com", "www.facebook.com").Replace("m.facebook.com", "www.facebook.com");
					}
					if (text3.Contains("_"))
					{
						text3 = text3.Split('_')[1];
					}
					if (string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3))
					{
						text2 = "https://www.facebook.com/" + text3;
					}
				}
				method_130(B39FABB7, FE2C752B + $"Đang {string_1} ({num2 + 1}/{num3}): Open {text3}...");
				while (true)
				{
					chrome_0.method_12(text2, FC3A841F: true);
					int num5 = chrome_0.method_125();
					if (num5 == 1)
					{
						continue;
					}
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
					{
						if (!flag7)
						{
							flag7 = true;
							chrome_0.method_53();
							chrome_0.method_60();
						}
						break;
					}
					return -1;
				}
				if (!flag)
				{
					text = "";
				}
				string text5 = "";
				string text6 = "";
				if (flag2)
				{
					if (flag4)
					{
						lock (A321A6B2)
						{
							if (A321A6B2[FDB3A498].Count == 0)
							{
								break;
							}
							int index = Base.rd.Next(0, A321A6B2[FDB3A498].Count);
							text5 = A321A6B2[FDB3A498][index];
							A321A6B2[FDB3A498].RemoveAt(index);
							goto IL_048b;
						}
					}
					if (list2.Count == 0)
					{
						list2 = C499BE3B(A321A6B2[FDB3A498]);
					}
					int index2 = Base.rd.Next(0, list2.Count);
					text5 = list2[index2];
					list2.RemoveAt(index2);
					goto IL_048b;
				}
				goto IL_04ac;
				IL_04ac:
				if (flag3)
				{
					if (list3.Count == 0)
					{
						list3 = C499BE3B(list_);
					}
					if (list3.Count > 0)
					{
						text6 = list3[Base.rd.Next(0, list3.Count)];
						list3.Remove(text6);
					}
				}

				method_131(B39FABB7, FE2C752B + $"Đang {string_1} ({num2 + 1}/{num3}): Xem bài viết {{time}}s...", int_, int_2);
				chrome_0.method_114(text3, text, text5, text6);

				num2++;
				if (num2 < num3)
				{
					method_131(B39FABB7, FE2C752B + $"Đang {string_1} ({num2 + 1}/{num3}) đợi {{time}}s...", int_3, int_4);
					num4++;
					continue;
				}
				break;
				IL_048b:
				text5 = Commom.smethod_31(text5);
				string newValue = CommonChrome.smethod_1(chrome_0);
				text5 = text5.Replace("[u]", newValue);
				goto IL_04ac;
			}
		}
		catch
		{
			num2 = -1;
		}
		if (flag7)
		{
			chrome_0.method_54();
		}
		return num2;
	}

	public int method_67(int int_3, string D6A31290, Chrome chrome_0, GClass4 gclass4_0, string string_1)
	{
		string text = gclass4_0.BDB80B23("txtIdPage");
		int int_4 = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int int_5 = gclass4_0.method_2("nudDelayFrom");
		int int_6 = gclass4_0.method_2("nudDelayTo");
		int num = 0;
		int num2 = chrome_0.method_50(int_4, f4960BA);
		bool flag = false;
		try
		{
			while (true)
			{
				IL_01e8:
				if (flag || Commom.IsUid(text))
				{
					chrome_0.method_12("https://facebook.com/" + text);
				}
				else
				{
					chrome_0.method_12("https://m.facebook.com/send_page_invite/?pageid=" + text + "&reference=msite_friends_inviter_card");
				}
				int num3 = chrome_0.method_61();
				if (num3 == 1)
				{
					if (!flag)
					{
						flag = true;
						chrome_0.method_53();
						if (chrome_0.method_49() == 1)
						{
							continue;
						}
					}
					chrome_0.method_60();
					string json = chrome_0.method_66("MoiBanBeLikePageWWW");
					Convert.ToBoolean(JObject.Parse(json)["success"]);
					break;
				}
				if (chrome_0.D7A424AE("#m_invitee_list"))
				{
					while (num < num2)
					{
						int num4 = chrome_0.method_125();
						if (num4 != 1)
						{
							if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
							{
								method_130(int_3, D6A31290 + Language.GetValue("Đang") + $" {string_1} ({num + 1}/{num2})...");
								if (!chrome_0.method_19("[type=\"submit\"]|" + num))
								{
									num++;
									if (num != num2)
									{
										method_131(int_3, D6A31290 + Language.GetValue("Đang") + $" {string_1} ({num}/{num2}), đợi {{time}}s...", int_5, int_6);
										continue;
									}
									break;
								}
								break;
							}
							return -1;
						}
						goto IL_01e8;
					}
					break;
				}
				return num;
			}
		}
		catch
		{
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num;
	}

	public int BF2C451F(int F89CD3AB, string string_1, Chrome FA3D9931, int FB9B83B6, int int_3, int D91C2609, int B98048AE, int D59D20B7, int int_4, bool bool_5, bool bool_6, string string_2, int int_5, int C1A75031, bool bool_7, bool A3894C36, int int_6, int F9349088, bool DC86883A, string string_3, string string_4, ref int int_7, GClass4 FFBA231D)
	{
		int_7 = 2;
		FA3D9931.method_65();
		FA3D9931.method_49();
		int num = 0;
		FA3D9931.method_53();
		try
		{
			bool flag = false;
			int num2 = Base.rd.Next(FB9B83B6, int_3 + 1);
			int num3 = 0;
			while (true)
			{
				IL_003d:
				List<string> list = new List<string>();
				if (A3894C36)
				{
					list = CommonChrome.F8053122(FA3D9931, DC86883A);
					if (list.Count == 0)
					{
						break;
					}
				}
				while (num < num2)
				{
					if (!FA3D9931.CD930D04())
					{
						try
						{
							string content = "";
							if (bool_5)
							{
								lock (dictionary_8)
								{
									if (dictionary_8[string_3].Count == 0)
									{
										dictionary_8[string_3] = C499BE3B(dictionary_9[string_3]);
									}
									content = dictionary_8[string_3][Base.rd.Next(0, dictionary_8[string_3].Count)];
									dictionary_8[string_3].Remove(content);
								}
								content = Commom.smethod_31(content);
							}

							List<string> images = new List<string>();
							if (bool_6)
							{
								List<string> listImg = Commom.smethod_76(string_2);
								int numImg = Base.rd.Next(int_5, C1A75031 + 1);
								for (int k = 0; k < numImg && listImg.Count > 0; k++)
								{
									string img = bool_7 ? listImg[0] : listImg[Base.rd.Next(listImg.Count)];
									images.Add(img);
									listImg.Remove(img);
								}
							}

							bool isUseBg = FFBA231D != null && FFBA231D.method_3("ckbUseBackground");
							method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đang đăng bài WWW...");

							string postRes = FA3D9931.ExecuteDangBaiWWW(0, "", content, isUseBg, images);
							if (!string.IsNullOrEmpty(postRes))
							{
								num++;
								int_7 = 1;
								string statusMsg = Language.GetValue("Đã đăng tường: ") + postRes;
								method_130(F89CD3AB, string_1 + statusMsg);
								try
								{
									string outputDir = Path.Combine(Commom.smethod_95(), "output");
									if (!Directory.Exists(outputDir))
									{
										Directory.CreateDirectory(outputDir);
									}
									string postWallFile = Path.Combine(outputDir, "postWall_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
									Commom.smethod_98(postWallFile, delegate
									{
										File.AppendAllText(postWallFile, FA3D9931.B4208531 + "|" + postRes + Environment.NewLine);
									});
								}
								catch { }
								FA3D9931.method_45(D91C2609, B98048AE);
								continue;
							}
						}
						catch (Exception ex)
						{
							Commom.smethod_58(ex, "HDDangStatusV2_WWW");
						}

						if (num == 0)
						{
							num3++;
							if (num3 == 4)
							{
								break;
							}
						}
						try
						{
							string text = "";
							string string_5 = "[role=\"dialog\"] form[method=\"POST\"] [role=\"textbox\"]";
							bool flag2 = false;
							bool flag3 = true;
							int num4 = 0;
							num4 = 1;
							int num5 = 1;
							int num6 = 1;
							while (true)
							{
								IL_0093:
								FA3D9931.method_12("https://www.facebook.com/");
								FA3D9931.method_45(2, 3);
								text = "[aria-label$=\"imeline\"]~div";
								try
								{
									FA3D9931.ChromeDriver_0.SwitchTo().Alert().Accept();
								}
								catch (Exception)
								{
								}
								method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Check popup...");
								if (flag3)
								{
									FA3D9931.method_60();
								}
								int num7 = FA3D9931.method_125();
								if (num7 == 1)
								{
									continue;
								}
								if (!new List<int> { -3, -2, -1, 2 }.Contains(num7))
								{
									method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Tìm vùng nhập bài...");
									for (int i = 1; i < 5; i++)
									{
										if (flag2 = FA3D9931.D7A424AE(text))
										{
											break;
										}
										FA3D9931.method_32(0, i * 1000);
										FA3D9931.F8091028(2.0);
									}
									if (flag3)
									{
										flag3 = false;
										string text2 = FA3D9931.method_14("return require('DTSGInitData').token").ToString();
										string text3 = FA3D9931.FB94939A();
										string string_6 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=u&__hs=19156.HYP:comet_pkg.2.1.0.2.&dpr=1&__ccg=GOOD&__rev=1005672124&__s=k0bapp:d88xxt:tln68k&__hsi=7108569615822393545-0&__comet_req=1&fb_dtsg=" + text2 + "&jazoest=25337&lsd=&__spin_r=1005672124&__spin_b=trunk&__spin_t=1655092839&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometPrivacySelectorSavePrivacyMutation&variables={\"input\":{\"privacy_mutation_token\":null,\"privacy_row_input\":{\"allow\":[],\"base_state\":\"EVERYONE\",\"deny\":[],\"tag_expansion_state\":\"UNSPECIFIED\"},\"privacy_write_id\":\"cHJpdmFjeV9zY29wZV9yZW5kZXJlcjp7ImlkIjo4Nzg3NjcwNzMzLCJjYXNjIjp0cnVlfQ\",\"render_location\":\"COMET_DEFAULT_PRIVACY_NUX\",\"actor_id\":\"" + text3 + "\",\"client_mutation_id\":\"1\"},\"privacySelectorRenderLocation\":\"COMET_DEFAULT_PRIVACY_NUX\",\"scale\":1,\"storyRenderLocation\":null,\"tags\":[]}&server_timestamps=true&doc_id=5125611420821355";
										string text4 = FA3D9931.method_48("https://www.facebook.com/api/graphql/", string_6);
										if (text4.Contains("A server error"))
										{
											string_6 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=u&__hs=19156.HYP:comet_pkg.2.1.0.2.&dpr=1&__ccg=GOOD&__rev=1005672124&__s=k0bapp:d88xxt:tln68k&__hsi=7108569615822393545-0&__comet_req=1&fb_dtsg=" + text2 + "&jazoest=25337&lsd=&__spin_r=1005672124&__spin_b=trunk&__spin_t=1655092839&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometPrivacySelectorSavePrivacyMutation&variables={\"input\":{\"privacy_mutation_token\":null,\"privacy_row_input\":{\"allow\":[],\"base_state\":\"FRIENDS_OF_FRIENDS\",\"deny\":[],\"tag_expansion_state\":\"UNSPECIFIED\"},\"privacy_write_id\":\"cHJpdmFjeV9zY29wZV9yZW5kZXJlcjp7ImlkIjo4Nzg3NjcwNzMzLCJjYXNjIjp0cnVlfQ\",\"render_location\":\"COMET_DEFAULT_PRIVACY_NUX\",\"actor_id\":\"" + text3 + "\",\"client_mutation_id\":\"1\"},\"privacySelectorRenderLocation\":\"COMET_DEFAULT_PRIVACY_NUX\",\"scale\":1,\"storyRenderLocation\":null,\"tags\":[]}&server_timestamps=true&doc_id=5125611420821355";
											text4 = FA3D9931.method_48("https://www.facebook.com/api/graphql/", string_6);
										}
										string_6 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=v&__hs=19156.HYP:comet_pkg.2.1.0.2.&dpr=1&__ccg=GOOD&__rev=1005672124&__s=k0bapp:d88xxt:tln68k&__hsi=7108569615822393545-0&__comet_req=1&fb_dtsg=" + text2 + "&jazoest=25337&lsd=&__spin_r=1005672124&__spin_b=trunk&__spin_t=1655092839&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ProfileComposerDefaultPrivacyQuery&variables={}&server_timestamps=true&doc_id=3550752381709990";
										text4 = FA3D9931.method_48("https://www.facebook.com/api/graphql/", string_6);
									}
									while (true)
									{
										if (flag2)
										{
											num4++;
											switch (num4)
											{
											case 1:
												break;
											default:
												goto end_IL_0073;
											case 2:
												method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Click vùng nhập bài...");
												FA3D9931.method_20(text);
												FA3D9931.method_17(text);
												flag2 = FA3D9931.D7A424AE(string_5, 30.0);
												continue;
											case 3:
											{
												if (!bool_5)
												{
													continue;
												}
												method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Nhập nội dung...");
												string text8 = "";
												lock (dictionary_8)
												{
													if (dictionary_8[string_3].Count == 0)
													{
														dictionary_8[string_3] = C499BE3B(dictionary_9[string_3]);
													}
													text8 = dictionary_8[string_3][Base.rd.Next(0, dictionary_8[string_3].Count)];
													dictionary_8[string_3].Remove(text8);
												}
												if (!(text8.Trim() != ""))
												{
													continue;
												}
												if (FA3D9931.AE3408BC(string_5, text8))
												{
													FA3D9931.F8091028(3.0);
													continue;
												}
												if (!flag)
												{
													flag = true;
													goto IL_003d;
												}
												goto end_IL_0073;
											}
											case 4:
												if (A3894C36)
												{
													string text5 = "[aria-label^=\"Tag \"]";
													if (FA3D9931.D7A424AE(text5, 10.0))
													{
														int num8 = 0;
														int num9 = Base.rd.Next(int_6, F9349088 + 1);
														FA3D9931.method_34(text5);
														FA3D9931.F8091028(1.0);
														FA3D9931.method_21(text5);
														FA3D9931.method_45(2, 3);
														while (true)
														{
															method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đang tag {num8}/{num9}...");
															if (list.Count == 0)
															{
																break;
															}
															num8 = FA3D9931.method_30("[role=\"listbox\"] [aria-label^=\"Remove\"]");
															if (num8 >= num9)
															{
																break;
															}
															string text6 = list[Base.rd.Next(list.Count)];
															list.Remove(text6);
															if (FA3D9931.method_22("input[role=\"textbox\"]", text6) || FA3D9931.D7A424AE("input[role=\"textbox\"]"))
															{
																bool flag5 = false;
																for (int l = 0; l < 10; l++)
																{
																	if (!FA3D9931.D7A424AE("[role=\"listbox\"] li[role=\"option\"]"))
																	{
																		if (FA3D9931.D7A424AE("//*[text()=\"No people found\"]"))
																		{
																			break;
																		}
																		FA3D9931.F8091028(1.0);
																		continue;
																	}
																	flag5 = true;
																	break;
																}
																if (flag5)
																{
																	FA3D9931.F8091028(2.0);
																	FA3D9931.F4AC0516("input[role=\"textbox\"]");
																	FA3D9931.F8091028(0.5);
																	FA3D9931.F217FA96("input[role=\"textbox\"]");
																	FA3D9931.method_45(FFBA231D.method_2("nudDelayTagFrom"), FFBA231D.method_2("nudDelayTagTo"));
																}
																FA3D9931.EB2B3FB0("input[role=\"textbox\"]");
																continue;
															}
															goto IL_003d;
														}
													}
												}
												FA3D9931.F8091028(1.0);
												FA3D9931.method_21("//*[@method=\"POST\"]//*[text()=\"Done\" or text()=\"done\"]");
												continue;
											case 5:
											{
												if (!bool_6)
												{
													continue;
												}
												string string_7 = "[aria-label^=\"Photo/\"]";
												if (!FA3D9931.D7A424AE(string_7, 30.0))
												{
													continue;
												}
												string text7 = "";
												int num10 = 0;
												int num11 = Base.rd.Next(int_5, C1A75031 + 1);
												List<string> list2 = Commom.smethod_76(string_2);
												FA3D9931.method_14("HTMLInputElement.prototype.click = function() { if(this.type !== 'file') HTMLElement.prototype.click.call(this); };");
												for (int m = 0; m < 10; m++)
												{
													FA3D9931.method_17(string_7);
													if (FA3D9931.D7A424AE("form[method=\"POST\"] input[type=\"file\"]"))
													{
														break;
													}
													FA3D9931.F8091028(1.0);
												}
												while (true)
												{
													method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đăng ảnh {num10}/{num11}...");
													if (list2.Count <= 0 || num10 >= num11)
													{
														break;
													}
													text7 = (bool_7 ? list2[0] : list2[Base.rd.Next(0, list2.Count)]);
													list2.Remove(text7);
													FA3D9931.method_24("form[method=\"POST\"] input[type=\"file\"]", text7);
													FA3D9931.method_45(1, 2);
													num10++;
												}
												FA3D9931.method_45(3, 5);
												continue;
											}
											case 6:
											{
												if (!FA3D9931.D7A424AE("[role=\"dialog\"] form[method=\"POST\"] [aria-label=\"POST\" i]:not([aria-disabled=\"true\"])"))
												{
													continue;
												}
												method_130(F89CD3AB, string_1 + "Chờ {time}s...", Base.rd.Next(D59D20B7, int_4 + 1));
												method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đang đăng...");
												FA3D9931.F8091028(2.0);
												FA3D9931.method_21("[role=\"dialog\"] form[method=\"POST\"] [aria-label=\"POST\" i]:not([aria-disabled=\"true\"])");
												for (int j = 0; j < 30; j++)
												{
													if (!FA3D9931.D7A424AE("[role=\"dialog\"] form[method=\"POST\"] [aria-label=\"POST\" i]:not([aria-disabled=\"true\"])"))
													{
														break;
													}
													if (!FA3D9931.D6BBEDA3())
													{
														method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đăng thành công...");
														FA3D9931.F8091028(1.0);
														continue;
													}
													return -4;
												}
												bool flag4 = false;
												for (int k = 0; k < 60; k++)
												{
													method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đang đăng {k}/60(s)...");
													if (FA3D9931.D7A424AE("[aria-live=\"assertive\"]"))
													{
														FA3D9931.F8091028(1.0);
														continue;
													}
													flag4 = true;
													break;
												}
												if (!flag4)
												{
													method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Mạng lag quá...");
													continue;
												}
												FA3D9931.F8091028(5.0);
												if (!FA3D9931.D6BBEDA3())
												{
													method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num + 1}/{num2}): Đăng thành công...");
													continue;
												}
												return -4;
											}
											}
											goto IL_0093;
										}
										Commom.smethod_57(FA3D9931, null, "HDDangStatusV2: stt" + num4);
										break;
									}
									break;
								}
								return -1;
							}
							end_IL_0073:;
						}
						catch
						{
						}
						int_7 = 1;
						num++;
						method_130(F89CD3AB, string_1 + Language.GetValue("Đang") + $" {string_4} ({num}/{num2})...");
						if (num < num2)
						{
							FA3D9931.method_45(D91C2609, B98048AE);
							continue;
						}
						break;
					}
					return -2;
				}
				break;
			}
		}
		catch
		{
		}
		FA3D9931.method_54();
		return num;
	}

	private int method_68(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2, string B89388BF)
	{
		return PersonalInteractionHelper.AppealSpam(this, int_3, string_1, chrome_0, gclass4_0, string_2, B89388BF);
	}

	private int method_69(int EA8743A9, string string_1, Chrome chrome_0, GClass4 gclass4_0, string B9B2F4BA)
	{
		bool flag = false;
		try
		{
			int num;
			do
			{
				chrome_0.method_12("https://m.facebook.com/profile.php");
				chrome_0.F8091028(2.0);
				num = chrome_0.method_61();
				if (num != 1 || flag)
				{
					break;
				}
				flag = true;
				chrome_0.method_53();
			}
			while (chrome_0.method_49() == 1);
			if (num == 1 || num == 3)
			{
				chrome_0.method_110(gclass4_0);
			}
			else
			{
				A718CC0F(EA8743A9, string_1, chrome_0, gclass4_0, B9B2F4BA);
			}
		}
		catch (Exception)
		{
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return 0;
	}

	private int A718CC0F(int int_3, string string_1, Chrome chrome_0, GClass4 D011D6BC, string string_2)
	{
		int minValue = D011D6BC.method_2("nudSoLuongBaiFrom");
		int num = D011D6BC.method_2("nudSoLuongBaiTo");
		int num2 = Base.rd.Next(minValue, num + 1);
		bool flag = D011D6BC.method_3("ckbOnlyDeleteTagPost");
		int int_4 = D011D6BC.method_2("nudDelayFrom");
		int int_5 = D011D6BC.method_2("nudDelayTo");
		string text = "[data-sigil=\"story-popup-causal-init\"]>a";
		string text2 = "[data-sigil=\" m-layer-root storyFlyout\"]:not([style*=\"display: none\"]) [data-sigil=\"touchable touchable removeStoryButton enabled_action\"]";
		string text3 = "[data-sigil=\" m-layer-root storyFlyout\"]:not([style*=\"display: none\"]) [data-sigil=\"touchable touchable afroDirectAction enabled_action\"]";
		string text4 = "[role=\"dialog\"]:not([style*=\"display: none\"]) [href^=\"/trust/afro/direct_action_execute?hideable_token=\"]";
		int num3 = 0;
		for (int i = 0; i < num2 + 10 && chrome_0.D7A424AE(text, 3.0); i++)
		{
			method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num3 + 1}/{num2})...");
			chrome_0.method_20(text);
			chrome_0.method_21(text);
			chrome_0.method_45(1, 2);
			if (flag)
			{
				string text5 = chrome_0.method_15(5.0, new List<string> { text2, text3 });
				if (text5 == "" || text5 == text2)
				{
					continue;
				}
				chrome_0.method_16(0, new string[1] { text5 });
			}
			else if (!chrome_0.method_16(5, new string[2] { text2, text3 }))
			{
				continue;
			}
			if (chrome_0.method_16(5, new string[1] { text4 }))
			{
				chrome_0.method_33(text4, 30);
				num3++;
				if (num3 >= num2)
				{
					break;
				}
				method_131(int_3, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_2, num3, num2, Language.GetValue("đợi")), int_4, int_5);
			}
		}
		return num3;
	}

	public int method_70(int D5125B96, string string_1, Chrome chrome_0, GClass4 gclass4_0, string BD0F4CA3)
	{
		int int_ = gclass4_0.method_2("nudSoLuongFrom");
		int num = gclass4_0.method_2("nudSoLuongTo", int_);
		int num2 = gclass4_0.method_2("nudDelayFrom");
		int num3 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
		List<string> list_ = gclass4_0.method_1("txtCauTraLoi");
		int num4 = 0;
		bool flag2 = false;
		try
		{
			int num8 = chrome_0.method_50(int_, num);
			if (num8 <= 0)
			{
				return 0;
			}

			flag2 = true;
			chrome_0.method_53();
			chrome_0.method_60();

			method_130(D5125B96, string_1 + Language.GetValue("Đang") + $" {BD0F4CA3} ({num4 + 1}/{num8})...");

			JObject jParams = new JObject
			{
				["nudSoLuongFrom"] = num8,
				["nudSoLuongTo"] = num8,
				["nudDelayFrom"] = num2,
				["nudDelayTo"] = num3,
				["ckbTuDongTraLoiCauHoi"] = flag,
				["lstCauTraLoi"] = (list_ != null && list_.Count > 0) ? string.Join("\n", list_) : ""
			};

			string resultJson = FacebookGroupFriendHub.Execute(chrome_0, "JoinGroupDeXuatWWW", jParams.ToString());
			if (!string.IsNullOrEmpty(resultJson))
			{
				try
				{
					JObject jRes = JObject.Parse(resultJson);
					num4 = jRes["count"]?.ToObject<int>() ?? (jRes["success"]?.ToObject<bool>() == true ? num8 : 0);
				}
				catch { }
			}
		}
		catch
		{
			num4 = -1;
		}
		if (flag2)
		{
			chrome_0.method_54();
		}
		return num4;
	}

	private int method_71(int int_3, string string_1, Chrome AA2A799C, GClass4 gclass4_0, string BA2DAD9F, string string_2)
	{
		int int_4 = gclass4_0.method_2("nudDelayFrom");
		int int_5 = gclass4_0.method_2("nudDelayTo");
		gclass4_0.method_3("ckbVanBan");
		gclass4_0.method_3("ckbXoaNoiDung");
		bool b9322A3C = gclass4_0.method_3("ckbUseBackground");
		bool flag = gclass4_0.method_3("ckbAnh");
		gclass4_0.method_2("nudSoLuongAnhFrom");
		gclass4_0.method_2("nudSoLuongAnhTo");
		bool flag2 = gclass4_0.method_3("ckbUseAvatar");
		bool flag3 = gclass4_0.method_3("ckbXoaAnh");
		bool flag4 = gclass4_0.method_3("ckbDangBaiLenTuong");
		int num = gclass4_0.method_2("nudCountWallFrom");
		int num2 = gclass4_0.method_2("nudCountWallTo");
		bool flag5 = gclass4_0.method_3("ckbDangBaiLenNhom");
		int minValue = gclass4_0.method_2("nudCountGroupFrom");
		int num3 = gclass4_0.method_2("nudCountGroupTo");
		int num4 = gclass4_0.method_2("typePost");
		List<string> FC246C0F = gclass4_0.method_1("lstNhomTuNhap");
		bool flag6 = gclass4_0.method_3("ckbChiDangNhomDaThamGia");
		bool flag7 = gclass4_0.method_3("ckbXoaNhomDaDang");
		bool flag8 = gclass4_0.method_3("ckbOnlyDangNhomKhongKiemDuyet");
		bool flag9 = gclass4_0.method_3("ckbUuTienNhomNhieuThanhVien");
		bool flag10 = gclass4_0.method_3("ckbKhongDangTrung");
		bool flag11 = gclass4_0.method_3("ckbTuongTac");
		bool flag12 = gclass4_0.method_3("ckbTuongTacBaiVietDaDang");
		bool flagDangBaiLenPage = gclass4_0.method_3("ckbDangBaiLenPage");
		int nudCountPageFrom = gclass4_0.method_2("nudCountPageFrom", 1);
		int nudCountPageTo = gclass4_0.method_2("nudCountPageTo", 1);
		bool flag13 = gclass4_0.method_3("ckbCopyPost");
		bool bool_ = gclass4_0.method_3("ckbXoaIdPostDaDung");
		bool flag14 = gclass4_0.method_3("ckbXoaHashtag");
		gclass4_0.method_3("ckbThemVaoCuoiNoiDung");
		gclass4_0.BDB80B23("txtNoiDungThemVaoCuoi");
		int num5 = 0;
		int totalWallPosts = 0;
		if (flag)
		{
			string string_5 = gclass4_0.BDB80B23("txtPathAnh");
			lock (dictionary_20)
			{
				if (!dictionary_20.ContainsKey(string_2))
				{
					dictionary_20.Add(string_2, Commom.smethod_76(string_5));
				}
			}
			if (dictionary_20[string_2].Count == 0)
			{
				method_130(int_3, string_1 + Language.GetValue("Không tìm thấy ảnh tại: ") + string_5);
				Commom.smethod_52(3.0);
				goto IL_0d88;
			}
		}
		if (flag10)
		{
			lock (C73602B4)
			{
				if (!C73602B4.ContainsKey(string_2))
				{
					C73602B4.Add(string_2, new List<string>());
				}
			}
		}
		new List<string>();
		List<string> list = new List<string>();
		AA2A799C.method_53();
		try
		{
			if (flag2)
			{
				CommonRequest.smethod_3(AA2A799C.B4208531, bool_0: true);
			}
			string string_6 = method_72(flag13, bool_, string_2, AA2A799C);
			if (flag4)
			{
				method_130(int_3, string_1 + Language.GetValue("Đăng tường") + "...");
				num5 = 0;
				int num6 = Commom.BF833227(num, num2);
				for (int i = 0; i < num6; i++)
				{
					method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng tường") + " ({0}/{1})", num5 + 1, num6) + "...");
					int num7 = 0;
					int retryNav = 0;
					bool navOk = false;
					while (retryNav < 3 && !navOk)
					{
						retryNav++;
						string targetWallUrl = (retryNav == 1) ? "https://www.facebook.com/profile.php" : "https://www.facebook.com/";
						AA2A799C.method_12(targetWallUrl, FC3A841F: true);
						AA2A799C.F8091028(2.0);
						num7 = AA2A799C.method_125();
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num7))
						{
							navOk = true;
						}
						else if (!AA2A799C.method_124() && !AA2A799C.D6BBEDA3())
						{
							string currUrl = AA2A799C.GetURL().ToLower();
							if (currUrl.Contains("facebook.com"))
							{
								navOk = true;
							}
						}
					}
					if (navOk)
					{
						HumanScroll.ScrollNewsfeed(AA2A799C, 300);
						AA2A799C.F8091028(1.0);

						(string content, bool isUseBackground, List<string> lstPathImage) tuple = method_73(gclass4_0, AA2A799C.B4208531, string_6, string_2);
						var (text, isUseBg, item) = tuple;
						if (item != null && item.Count > 0)
						{
							isUseBg = false;
						}
						if (flag14 && !string.IsNullOrEmpty(text))
						{
							text = Regex.Replace(text, "#\\w+", "").Trim();
						}

						// Chống trùng lặp nội dung trên tường nếu cấu hình
						if (flag10)
						{
							string contentKey = "wall_" + (string.IsNullOrEmpty(text) ? ((item != null && item.Count > 0) ? item.FirstOrDefault() : "") : (text.Length > 80 ? text.Substring(0, 80) : text));
							bool isDuplicate = false;
							lock (C73602B4)
							{
								if (!C73602B4.ContainsKey(string_2))
								{
									C73602B4.Add(string_2, new List<string>());
								}
								if (!string.IsNullOrEmpty(contentKey) && C73602B4[string_2].Contains(contentKey))
								{
									isDuplicate = true;
								}
							}
							if (isDuplicate)
							{
								method_130(int_3, string_1 + Language.GetValue("Bỏ qua nội dung trùng lặp trên tường..."));
								Commom.smethod_52(1.5);
								if (i + 1 < num6)
								{
									string_6 = method_72(flag13, bool_, string_2, AA2A799C);
									continue;
								}
								break;
							}
						}

						string F181CD1B = AA2A799C.method_106(0, "", text, isUseBg, item);
						if (!string.IsNullOrEmpty(F181CD1B))
						{
							if (flag10)
							{
								string contentKey = "wall_" + (string.IsNullOrEmpty(text) ? ((item != null && item.Count > 0) ? item.FirstOrDefault() : "") : (text.Length > 80 ? text.Substring(0, 80) : text));
								lock (C73602B4)
								{
									if (C73602B4.ContainsKey(string_2) && !string.IsNullOrEmpty(contentKey) && !C73602B4[string_2].Contains(contentKey))
									{
										C73602B4[string_2].Add(contentKey);
									}
								}
							}
							if (flag3 && !flag13)
							{
								Commom.smethod_68(item);
							}
							num5++;
							try
							{
								string outputDir = Path.Combine(Commom.smethod_95(), "output");
								if (!Directory.Exists(outputDir))
								{
									Directory.CreateDirectory(outputDir);
								}
								string string_4 = Path.Combine(outputDir, "postWall_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
								Commom.smethod_98(string_4, delegate
								{
									File.AppendAllText(string_4, AA2A799C.B4208531 + "|" + F181CD1B + Environment.NewLine);
								});
							}
							catch { }

							string statusSuccess = Language.GetValue("Đã đăng bài thành công!");
							if (F181CD1B.StartsWith("http") && !F181CD1B.Contains("wall_post_"))
							{
								statusSuccess = Language.GetValue("Đã đăng tường: ") + F181CD1B;
							}
							else
							{
								statusSuccess = string.Format(Language.GetValue("Đã đăng bài thành công ({0}/{1})!"), num5, num6);
							}
							method_130(int_3, string_1 + statusSuccess);

							if (flag12 && !string.IsNullOrEmpty(F181CD1B) && F181CD1B.StartsWith("http") && !F181CD1B.Contains("wall_post_"))
							{
								AA2A799C.method_12(F181CD1B);
								AA2A799C.F8091028(2.0);
								CF031D16(int_3, string_1 + Language.GetValue("Đang tương tác bài viết "), AA2A799C, gclass4_0, string_2);
							}

							if (i + 1 < num6)
							{
								method_131(int_3, string_1 + string.Format(Language.GetValue("Đã đăng tường ({0}/{1})"), num5, num6) + ", đợi {time}s...", int_4, int_5);
							}
							else if (flag5)
							{
								method_131(int_3, string_1 + Language.GetValue("Xong đăng tường, chuyển sang đăng nhóm, đợi {time}s..."), int_4, int_5);
							}
							else
							{
								Commom.smethod_52(1.5);
							}
						}
						else
						{
							method_130(int_3, string_1 + string.Format(Language.GetValue("Đăng tường ({0}/{1}) thất bại!"), i + 1, num6));
							Commom.smethod_52(2.0);
						}

						if (!AA2A799C.D6BBEDA3())
						{
							if (i + 1 >= num6)
							{
								break;
							}
							string_6 = method_72(flag13, bool_, string_2, AA2A799C);
							continue;
						}
						return -4;
					}
					else
					{
						if (AA2A799C.method_124() || AA2A799C.D6BBEDA3())
						{
							return -4;
						}
						method_130(int_3, string_1 + Language.GetValue("Bỏ qua đăng tường, chuyển sang đăng nhóm..."));
						break;
					}
				}
			}
			totalWallPosts = num5;
			if (flag5)
			{
				num5 = 0;
				if (AA2A799C.CD930D04())
				{
					return -2;
				}
				List<string> source = new List<string>();
				if (num4 == 0 || (num4 == 1 && flag6))
				{
					method_130(int_3, string_1 + Language.GetValue("Scan group..."));
					source = AA2A799C.method_56(flag8);
				}

				if (num4 == 0)
				{
					list = ((!flag8) ? source.Select((string B794C3A1) => B794C3A1).ToList() : source.Where((string CA949022) => CA949022.Split('|').Last().ToLower() == "false").ToList());
				}
				else
				{
					if (flag6)
					{
						var targetGids = new HashSet<string>(FC246C0F.Select(x => AccountGroupDB.ExtractGroupId(x)).Where(x => !string.IsNullOrEmpty(x)), StringComparer.OrdinalIgnoreCase);
						list = source.Where(g => targetGids.Contains(AccountGroupDB.ExtractGroupId(g))).ToList();
						if (flag8)
						{
							list = list.Where((string CA949022) => CA949022.Split('|').Last().ToLower() == "false").ToList();
						}
					}
					else
					{
						if (flag7 && dictionary_13 != null && dictionary_13.ContainsKey(string_2))
						{
							lock (dictionary_13)
							{
								list = new List<string>(dictionary_13[string_2]);
							}
						}
						else
						{
							list = new List<string>(FC246C0F);
						}
					}
				}

				if (flag8)
				{
					list = list.Where(g => !AccountGroupDB.IsGroupPendingApproval(AccountGroupDB.ExtractGroupId(g))).ToList();
				}

				if (flag9)
				{
					list = list.OrderByDescending((string g) => AccountGroupDB.GetGroupMemberCount(g, AA2A799C.B4208531)).ToList();
				}
				else
				{
					list = list.OrderBy((string string_0) => Guid.NewGuid()).ToList();
				}

				int num8 = Base.rd.Next(minValue, num3 + 1);
				string string_3 = "";
				if (list.Count != 0)
				{
					method_130(int_3, string_1 + Language.GetValue("Đang đăng nhóm") + "...");
					int num9 = 0;
					while (num9 < num8 && list.Count != 0)
					{
						string_3 = list[0];
						list.RemoveAt(0);
						string originalGroupItem = string_3;

						string cleanGroupId = AccountGroupDB.ExtractGroupId(string_3);
						if (string.IsNullOrEmpty(cleanGroupId))
						{
							continue;
						}

						string groupTargetUrl = "https://www.facebook.com/groups/" + cleanGroupId;

						if (num4 == 1 && flag7 && dictionary_13 != null)
						{
							lock (dictionary_13)
							{
								if (dictionary_13.ContainsKey(string_2) &&
									!dictionary_13[string_2].Contains(originalGroupItem) &&
									!dictionary_13[string_2].Any(x => AccountGroupDB.ExtractGroupId(x).Equals(cleanGroupId, StringComparison.OrdinalIgnoreCase)))
								{
									continue;
								}
							}
						}

						if (flag10)
						{
							bool alreadyClaimedOrPosted = false;
							lock (C73602B4)
							{
								if (!C73602B4.ContainsKey(string_2))
								{
									C73602B4[string_2] = new List<string>();
								}
								if (C73602B4[string_2].Contains(cleanGroupId))
								{
									alreadyClaimedOrPosted = true;
								}
								else
								{
									C73602B4[string_2].Add(cleanGroupId);
								}
							}
							if (alreadyClaimedOrPosted)
							{
								method_130(int_3, string_1 + $"Bỏ qua nhóm {cleanGroupId} (đã đăng hoặc đang xử lý bởi tài khoản khác)...");
								continue;
							}
							if (AccountGroupDB.IsGroupPostedToday(AA2A799C.B4208531, cleanGroupId))
							{
								method_130(int_3, string_1 + $"Bỏ qua nhóm {cleanGroupId} (đã đăng hôm nay trong lịch sử)...");
								continue;
							}
						}

						if (flag8)
						{
							if (AccountGroupDB.IsGroupPendingApproval(cleanGroupId))
							{
								method_130(int_3, string_1 + $"Bỏ qua nhóm {cleanGroupId} (có kiểm duyệt theo CSDL)...");
								continue;
							}
						}

						if (flag11)
						{
							AA2A799C.method_12(groupTargetUrl, FC3A841F: true);
							AA2A799C.F8091028(2.0);
							F12A6CA2(int_3, string_1, AA2A799C, gclass4_0);
						}

						if (flag8)
						{
							method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng nhóm") + " ({0}/{1}), Scan group...", num5 + 1, num8));
							if (!AA2A799C.GetURL().Contains(cleanGroupId))
							{
								AA2A799C.method_12(groupTargetUrl, FC3A841F: true);
								AA2A799C.F8091028(2.0);
							}
							bool isKiemDuyet = false;
							try
							{
								isKiemDuyet = Convert.ToBoolean(AA2A799C.RunCodeChrome("CheckGroupKiemDuyet('" + cleanGroupId + "')"));
							}
							catch { }
							if (!isKiemDuyet)
							{
								isKiemDuyet = AA2A799C.CheckGroupApprovalInDOM();
							}
							if (isKiemDuyet)
							{
								AccountGroupDB.UpdateGroupApproval(cleanGroupId, "Có duyệt bài", AA2A799C.B4208531);
								method_130(int_3, string_1 + $"Bỏ qua nhóm {cleanGroupId} (nhóm có kiểm duyệt)...");
								continue;
							}
						}

						method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng nhóm") + " ({0}/{1})", num5 + 1, num8) + "...");
						if (!AA2A799C.GetURL().Contains(cleanGroupId))
						{
							int navAttempts = 0;
							int num10;
							do
							{
								AA2A799C.method_12(groupTargetUrl, FC3A841F: true);
								num10 = AA2A799C.method_125();
								navAttempts++;
							}
							while (num10 == 1 && navAttempts < 3);

							if (new List<int> { -3, -2, -1, 2 }.Contains(num10))
							{
								if (AA2A799C.method_124() || AA2A799C.D6BBEDA3())
								{
									return -4;
								}
								method_130(int_3, string_1 + "Bỏ qua nhóm lỗi: " + cleanGroupId);
								Commom.smethod_52(1.0);
								continue;
							}
						}

						(string content, bool isUseBackground, List<string> lstPathImage) tuple3 = method_73(gclass4_0, AA2A799C.B4208531, string_6, string_2);
						var (text2, _, _) = tuple3;
						_ = tuple3.isUseBackground;
						List<string> item2 = tuple3.lstPathImage;
						if (flag14)
						{
							text2 = Regex.Replace(text2, "#\\w+", "").Trim();
						}

						HumanScroll.ScrollNewsfeed(AA2A799C, 350);

						string BA1A8118 = AA2A799C.method_106(1, groupTargetUrl, text2, b9322A3C, item2);
						if (!string.IsNullOrEmpty(BA1A8118))
						{
							if (flag10)
							{
								AccountGroupDB.RecordPostedGroup(AA2A799C.B4208531, cleanGroupId);
							}
							if (flag3 && !flag13)
							{
								Commom.smethod_68(item2);
							}
							num5++;
							num9++;

							if (num4 == 1 && flag7 && dictionary_13 != null)
							{
								lock (dictionary_13)
								{
									if (dictionary_13.ContainsKey(string_2))
									{
										dictionary_13[string_2].RemoveAll(x =>
											x == originalGroupItem ||
											x == string_3 ||
											AccountGroupDB.ExtractGroupId(x).Equals(cleanGroupId, StringComparison.OrdinalIgnoreCase)
										);
									}
								}
							}

							string outDir = Path.Combine(Commom.smethod_95(), "output");
							if (!Directory.Exists(outDir))
							{
								Directory.CreateDirectory(outDir);
							}

							if (BA1A8118.Contains("pending_posts"))
							{
								AccountGroupDB.UpdateGroupApproval(cleanGroupId, "Có duyệt bài", AA2A799C.B4208531);
								string B329FA2E = Path.Combine(outDir, "pending_post_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
								Commom.smethod_98(B329FA2E, delegate
								{
									File.AppendAllText(B329FA2E, AA2A799C.B4208531 + "|" + cleanGroupId + "|" + BA1A8118 + Environment.NewLine);
								});
								string statusMsg = string.Format(Language.GetValue("Đã gửi duyệt nhóm ({0}/{1}): {2}"), num5, num8, BA1A8118);
								method_130(int_3, string_1 + statusMsg);
							}
							else
							{
								AccountGroupDB.UpdateGroupApproval(cleanGroupId, "Không duyệt bài", AA2A799C.B4208531);
								string FC81E7B0 = Path.Combine(outDir, "post_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
								Commom.smethod_98(FC81E7B0, delegate
								{
									File.AppendAllText(FC81E7B0, AA2A799C.B4208531 + "|" + cleanGroupId + "|" + BA1A8118 + Environment.NewLine);
								});
								AA2A799C.A80F3C2C(BA1A8118);
								string statusMsg = string.Format(Language.GetValue("Đã đăng nhóm ({0}/{1}): {2}"), num5, num8, BA1A8118);
								method_130(int_3, string_1 + statusMsg);
								if (flag12)
								{
									AA2A799C.method_12(BA1A8118);
									AA2A799C.F8091028(2.0);
									CF031D16(int_3, string_1 + Language.GetValue("Đang tương tác bài viết "), AA2A799C, gclass4_0, string_2);
								}
							}

							if (flag13)
							{
								string_6 = method_72(flag13, bool_, string_2, AA2A799C);
							}

							if (num9 < num8 && list.Count > 0)
							{
								method_131(int_3, string_1 + string.Format(Language.GetValue("Đang đăng nhóm") + " ({0}/{1})", num5, num8) + ", đợi {time}s...", int_4, int_5);
							}
						}
						else
						{
							if (AA2A799C.D6BBEDA3())
							{
								return -4;
							}
							method_130(int_3, string_1 + $"Đăng nhóm {cleanGroupId} không thành công, thử nhóm tiếp theo...");
							Commom.smethod_52(2.0);
						}
					}
				}
				else
				{
					method_130(int_3, string_1 + Language.GetValue("Không có nhóm phù hợp để đăng..."));
					Commom.smethod_52(1.5);
				}
			}

			if (flagDangBaiLenPage)
			{
				int totalPagePosts = 0;
				if (AA2A799C.CD930D04())
				{
					return -2;
				}
				method_130(int_3, string_1 + Language.GetValue("Lấy danh sách Page quản lý..."));
				List<string> lstPages = new List<string>();
				try
				{
					lstPages = AA2A799C.BE0C6B9C();
				}
				catch { }

				if (lstPages == null || lstPages.Count == 0)
				{
					try
					{
						AA2A799C.method_12("https://www.facebook.com/pages/?category=your_pages");
						AA2A799C.F8091028(2.0);
						string jsonPages = AA2A799C.method_14("try { var links = Array.from(document.querySelectorAll('a[href*=\"/latest/\"], a[href*=\"facebook.com/\"]')); var pids = []; var seen = new Set(); for (var a of links) { var href = a.getAttribute('href') || ''; var m = href.match(/(?:asset_id=|[0-9]{8,})/); if (m && !seen.has(m[0])) { seen.add(m[0]); pids.push(m[0]); } } return JSON.stringify(pids); } catch(e) { return '[]'; }");
						if (!string.IsNullOrEmpty(jsonPages) && jsonPages.StartsWith("["))
						{
							var jArr = Newtonsoft.Json.Linq.JArray.Parse(jsonPages);
							foreach (var item in jArr)
							{
								string pid = item?.ToString();
								if (!string.IsNullOrEmpty(pid) && !lstPages.Contains(pid)) lstPages.Add(pid);
							}
						}
					}
					catch { }
				}

				if (lstPages != null && lstPages.Count > 0)
				{
					int maxPagePosts = Commom.BF833227(nudCountPageFrom, nudCountPageTo);
					if (maxPagePosts > lstPages.Count) maxPagePosts = lstPages.Count;

					for (int pIdx = 0; pIdx < maxPagePosts; pIdx++)
					{
						if (AA2A799C.CD930D04()) return -2;
						string pageTarget = lstPages[pIdx].Trim();
						string pageUrl = pageTarget.StartsWith("http") ? pageTarget : ("https://www.facebook.com/" + pageTarget);
						method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng Page ({0}/{1})..."), pIdx + 1, maxPagePosts));

						(string content, bool isUseBackground, List<string> lstPathImage) tuplePage = method_73(gclass4_0, AA2A799C.B4208531, string_6, string_2);
						var (textPage, _, _) = tuplePage;
						List<string> itemPage = tuplePage.lstPathImage;
						if (flag14)
						{
							textPage = Regex.Replace(textPage, "#\\w+", "").Trim();
						}

						string postRes = AA2A799C.method_106(2, pageUrl, textPage, b9322A3C, itemPage);
						if (!string.IsNullOrEmpty(postRes))
						{
							num5++;
							totalPagePosts++;
							string statusMsg = string.Format(Language.GetValue("Đã đăng Page ({0}/{1}): {2}"), totalPagePosts, maxPagePosts, postRes);
							method_130(int_3, string_1 + statusMsg);
						}
						else
						{
							method_130(int_3, string_1 + $"Đăng Page {pageTarget} không thành công...");
						}
						if (pIdx + 1 < maxPagePosts)
						{
							Commom.BF833227(int_4, int_5);
						}
					}
				}
				else
				{
					method_130(int_3, string_1 + Language.GetValue("Không tìm thấy Page quản lý nào..."));
				}
			}
		}
		catch
		{
		}
		goto IL_0d88;
		IL_0d88:
		AA2A799C.method_54();
		return totalWallPosts + num5;
	}

	private string method_72(bool DABB47B3, bool bool_5, string string_1, Chrome CA195492)
	{
		string text = Commom.smethod_95() + "\\posts";
		if (DABB47B3)
		{
			bool flag = false;
			int num = 0;
			while (true)
			{
				string text2;
				if (num < 10)
				{
					text2 = "";
					if (bool_5)
					{
						lock (dictionary_14[string_1])
						{
							if (dictionary_14[string_1].Count == 0)
							{
								break;
							}
							int index = dictionary_14[string_1].smethod_7();
							text2 = dictionary_14[string_1][index];
							dictionary_14[string_1].RemoveAt(index);
							goto IL_00ba;
						}
					}
					text2 = dictionary_14[string_1].smethod_8();
					goto IL_00ba;
				}
				goto IL_00fc;
				IL_00fc:
				if (!flag)
				{
				}
				break;
				IL_00ba:
				if (!Commom.smethod_45(text2))
				{
					text2 = Commom.smethod_87(text2);
				}
				if (!method_63(CA195492, text, text2))
				{
					num++;
					continue;
				}
				flag = true;
				text = text + "\\" + text2;
				goto IL_00fc;
			}
		}
		return text;
	}

	private (string content, bool isUseBackground, List<string> lstPathImage) method_73(GClass4 gclass4_0, string C72C8698, string string_1, string CFA471A7)
	{
		bool flag = gclass4_0.method_3("ckbVanBan");
		bool flag2 = gclass4_0.method_3("ckbXoaNoiDung");
		bool item = gclass4_0.method_3("ckbUseBackground");
		bool flag3 = gclass4_0.method_3("ckbAnh");
		int minValue = gclass4_0.method_2("nudSoLuongAnhFrom");
		int num = gclass4_0.method_2("nudSoLuongAnhTo");
		bool flag4 = gclass4_0.method_3("ckbUseAvatar");
		bool flag5 = gclass4_0.method_3("ckbXoaAnh");
		bool flag6 = gclass4_0.method_3("ckbCopyPost");
		bool flag7 = gclass4_0.method_3("ckbThemVaoCuoiNoiDung");
		string text = gclass4_0.BDB80B23("txtNoiDungThemVaoCuoi");
		List<string> list = new List<string>();
		if (flag6)
		{
			list = Commom.smethod_76(string_1 + "\\image");
			try
			{
				list = list.OrderBy(delegate(string string_0)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_0);
					return int.Parse(fileNameWithoutExtension);
				}).ToList();
			}
			catch (Exception)
			{
			}
		}
		else if (flag3)
		{
			if (flag4)
			{
				string item2 = Commom.smethod_95() + "\\avatar\\" + C72C8698 + ".png";
				list.Add(item2);
			}
			else
			{
				List<string> list2 = new List<string>(dictionary_20[CFA471A7]);
				int num2 = Base.rd.Next(minValue, num + 1);
				for (int i = 0; i < num2; i++)
				{
					string text2 = "";
					if (flag5)
					{
						lock (dictionary_20[CFA471A7])
						{
							while (string.IsNullOrEmpty(text2) && dictionary_20[CFA471A7].Count != 0)
							{
								text2 = dictionary_20[CFA471A7].OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
								dictionary_20[CFA471A7].Remove(text2);
								if (!File.Exists(text2))
								{
									text2 = "";
								}
							}
						}
					}
					else
					{
						while (string.IsNullOrEmpty(text2) && list2.Count != 0)
						{
							text2 = list2.OrderBy((string AAA09018) => Guid.NewGuid()).FirstOrDefault();
							list2.Remove(text2);
							if (!File.Exists(text2))
							{
								dictionary_20[CFA471A7].Remove(text2);
								text2 = "";
							}
						}
					}
					if (text2 != "" && File.Exists(text2))
					{
						list.Add(text2);
					}
				}
			}
		}
		string text3 = "";
		if (flag6)
		{
			item = false;
			if (File.Exists(string_1 + "\\noidung.txt"))
			{
				text3 = File.ReadAllText(string_1 + "\\noidung.txt");
			}
			if (gclass4_0.method_3("ckbTaoNoiDungCopyAI"))
			{
				text3 = Commom.smethod_93(gclass4_0.BDB80B23("cbbPromptCopy"), text3, list.FirstOrDefault() ?? "");
			}
			if (flag7 && !string.IsNullOrEmpty(text))
			{
				text3 = text3 + Environment.NewLine + text;
			}
		}
		else if (flag)
		{
			if (gclass4_0.method_3("ckbTaoNoiDungAI"))
			{
				text3 = Commom.smethod_93(gclass4_0.BDB80B23("cbbPrompt"), "", list.FirstOrDefault() ?? "");
			}
			else if (flag2)
			{
				lock (dictionary_19)
				{
					if (dictionary_19[CFA471A7].Count > 0)
					{
						int index = dictionary_19[CFA471A7].smethod_7();
						text3 = dictionary_19[CFA471A7][index];
						dictionary_19[CFA471A7].RemoveAt(index);
					}
				}
			}
			else if (dictionary_19[CFA471A7].Count > 0)
			{
				text3 = dictionary_19[CFA471A7].smethod_8();
			}
			if (flag7 && !string.IsNullOrEmpty(text))
			{
				text3 = string.IsNullOrEmpty(text3) ? text : text3 + Environment.NewLine + text;
			}
		}
		return (text3, item, list);
	}

	private void method_74(string string_1)
	{
		string path = Commom.smethod_95() + "\\output\\LinkReel.txt";
		lock (object_5)
		{
			File.AppendAllText(path, string_1 + "\n");
		}
	}

	private int method_75(ref int int_3, int int_4, string CDAE8F9F, Chrome chrome_0, GClass4 gclass4_0, string A104E517, string string_1)
	{
		if (int_3 < 0)
		{
			int_3 = 0;
		}
		chrome_0.method_53();
		chrome_0.method_49();
		int num = gclass4_0.method_2("nudSoLuongFrom", 1);
		int num2 = gclass4_0.method_2("nudSoLuongTo", 1);
		int int_5 = gclass4_0.method_2("nudKhoangCachFrom");
		int int_6 = gclass4_0.method_2("nudKhoangCachTo");
		bool flag = gclass4_0.method_3("ckbVanBan");
		bool flag2 = gclass4_0.method_3("ckbXoaNguyenLieuDaDung");
		bool flag3 = gclass4_0.method_3("ckbHashtag");
		List<string> list = gclass4_0.method_1("txtHashtag");
		int num3 = gclass4_0.method_2("nudSoHashtagFrom", 1);
		int num4 = gclass4_0.method_2("nudSoHashtagTo", 1);
		bool flag4 = gclass4_0.method_3("ckbXoaVideoDaDang");
		string path = gclass4_0.BDB80B23("txtPathAnh");
		int num5 = gclass4_0.method_2("nudTimeOutLoadVideo", 300);
		bool flag5 = gclass4_0.method_3("ckbXuatLinkReel");
		int num6 = 0;
		try
		{
			string text = CDAE8F9F + Language.GetValue("Đang") + " " + A104E517 + ": ";
			List<string> list2 = new List<string>();
			string text3 = "";
			new List<string>();
			if (!flag2)
			{
				list2 = Commom.smethod_30(dictionary_23[string_1]);
			}
			int num7 = Commom.BF833227(num, num2);
			for (int i = 0; i < num7 + 5; i++)
			{
				if (num6 >= num7)
				{
					break;
				}
				method_130(int_4, text + $"({num6 + 1}/{num7})...");
				try
				{
					int num8;
					do
					{
						chrome_0.method_12("https://www.facebook.com/reels/create/?locale=en_US");
						chrome_0.F8091028(2.0);
						num8 = chrome_0.method_125();
					}
					while (num8 == 1);
					if (new List<int> { -3, -2, -1, 2 }.Contains(num8))
					{
						return -1;
					}

					// Thử đăng qua PostingV2AutomationHelper PostReelV2 nếu có file video sẵn
					try
					{
						if (Directory.Exists(path))
						{
							var listVids = (from v in Directory.GetFiles(path) where !v.EndsWith(".txt") select v).ToList();
							if (listVids.Count > 0)
							{
								string chosenVideo = listVids.OrderBy(s => Guid.NewGuid()).FirstOrDefault();
								if (!string.IsNullOrEmpty(chosenVideo) && File.Exists(chosenVideo))
								{
									string reelCaption = "";
									if (list2 != null && list2.Count > 0)
									{
										reelCaption = list2.OrderBy(s => Guid.NewGuid()).FirstOrDefault() ?? "";
									}
									bool v2Success = PostingV2AutomationHelper.PostReelV2(chrome_0, chosenVideo, reelCaption, list, (msg) => {
										try { method_130(int_4, text + msg); } catch { }
									});
									if (v2Success)
									{
										int_3++;
										num6++;
										method_131(int_4, text + $"({num6}/{num7}), đợi {{time}}s...", int_5, int_6);
										string reelUrl = "https://www.facebook.com/reel/";
										if (flag5)
										{
											File.AppendAllText("XuatLinkReel.txt", reelUrl + "\r\n");
										}
										try
										{
											KichBanThongKeDB.LogPost(chrome_0.B4208531, reelUrl, reelCaption, "Đăng Reels", "Thành công");
										}
										catch { }
										if (flag4)
										{
											try { File.Delete(chosenVideo); } catch { }
										}
										continue;
									}
								}
							}
						}
					}
					catch { }

					int tickCount = Environment.TickCount;
					int num9 = 60;
					while (true)
					{
						if (chrome_0.D6BBEDA3())
						{
							return -4;
						}
						string text2 = chrome_0.method_15(0.0, new List<string> { 
							"form input[type=\"file\"]", 
							"input[type=\"file\"][accept*=\"video\"]", 
							"input[type=\"file\"]",
							"form [aria-label=\"Publish\"]:not([aria-disabled])", 
							"[aria-label=\"Publish\"]:not([aria-disabled])", 
							"[aria-label=\"Đăng\"]:not([aria-disabled])", 
							"[aria-label=\"Chia sẻ\"]:not([aria-disabled])", 
							"[aria-label=\"Next\"]:not([aria-disabled=\"true\"])",
							"[aria-label=\"Tiếp\"]:not([aria-disabled=\"true\"])",
							"//div[@role=\"button\"][not(@aria-disabled=\"true\")][.//*[text()=\"Next\" or text()=\"Tiếp\"]]",
							"//div[@role=\"button\"][not(@aria-disabled=\"true\")][.//*[text()=\"Publish\" or text()=\"Đăng\" or text()=\"Chia sẻ\"]]"
						});
						switch (text2)
						{
						case "form input[type=\"file\"]":
						case "input[type=\"file\"][accept*=\"video\"]":
						case "input[type=\"file\"]":
						{
							List<string> list3 = (from AB35260B in Directory.GetFiles(path)
								where !AB35260B.EndsWith(".txt")
								select AB35260B).ToList();
							if (list3.Count == 0)
							{
								break;
							}
							string text4 = "";
							if (list3.Count != 0)
							{
								text4 = list3.OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
								list3.Remove(text4);
								chrome_0.method_14("HTMLInputElement.prototype.click = function() { if(this.type !== 'file') HTMLElement.prototype.click.call(this); };");
								chrome_0.method_18("//form//input[@type=\"file\"]/parent::* | //input[@type=\"file\"]/parent::*");
								chrome_0.F8091028(1.0);
								chrome_0.method_22(text2, text4);
								chrome_0.F8091028(2.0);
								// Đợi video preview tải lên sẵn sàng (đa ngôn ngữ Việt - Anh)
								for (int v = 0; v < 30; v++)
								{
									if (chrome_0.D7A424AE("video, [aria-label*='Replace' i], [aria-label*='Thay' i], [aria-label='Next']:not([aria-disabled='true']), [aria-label='Tiếp']:not([aria-disabled='true'])", 1.0))
									{
										break;
									}
								}
								if (flag4)
								{
									Commom.E10A40B6(text4);
								}
								chrome_0.method_18("[aria-label=\"Next\"]:not([aria-disabled=\"true\"]), [aria-label=\"Tiếp\"]:not([aria-disabled=\"true\"]), //div[@role=\"button\"][not(@aria-disabled=\"true\")][.//*[text()=\"Next\" or text()=\"Tiếp\"]]");
								chrome_0.F8091028(2.0);
							}
							goto IL_0338;
						}
						default:
							if (chrome_0.method_15(0.0, new List<string> { "[src=\"/images/comet/empty_states_icons/permissions/permissions_gray_wash.svg\"]", "//*[text()=\"This content isn't available right now\"]" }) != "")
							{
								int_3 = -2;
								break;
							}
							if (!chrome_0.D7A424AE("//form//*[text()=\"Video cannot exceed 60 seconds.\"]"))
							{
								goto IL_0338;
							}
							goto end_IL_01ac;
						case "[aria-label=\"Next\"]:not([aria-disabled=\"true\"])":
						case "[aria-label=\"Tiếp\"]:not([aria-disabled=\"true\"])":
						case "//div[@role=\"button\"][not(@aria-disabled=\"true\")][.//*[text()=\"Next\" or text()=\"Tiếp\"]]":
							chrome_0.method_18(text2);
							goto IL_0338;
						case "form [aria-label=\"Publish\"]:not([aria-disabled])":
						case "[aria-label=\"Publish\"]:not([aria-disabled])":
						case "[aria-label=\"Đăng\"]:not([aria-disabled])":
						case "[aria-label=\"Chia sẻ\"]:not([aria-disabled])":
						case "//div[@role=\"button\"][not(@aria-disabled=\"true\")][.//*[text()=\"Publish\" or text()=\"Đăng\" or text()=\"Chia sẻ\"]]":
							{
								if ((chrome_0.D7A424AE("form [role=\"textbox\"]") || chrome_0.D7A424AE("[role=\"textbox\"][contenteditable=\"true\"]")) && flag)
								{
									text3 = "";
									if (!flag2)
									{
										if (list2.Count == 0)
										{
											list2 = Commom.smethod_30(dictionary_23[string_1]);
										}
										text3 = list2.OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
										list2.Remove(text3);
										goto IL_04ec;
									}
									lock (dictionary_23)
									{
										if (dictionary_23[string_1].Count == 0)
										{
											break;
										}
										int index = dictionary_23[string_1].smethod_7();
										text3 = dictionary_23[string_1][index];
										dictionary_23[string_1].RemoveAt(index);
										goto IL_04ec;
									}
								}
								goto IL_05af;
							}
							IL_05af:
							if (!chrome_0.method_18(text2))
							{
								goto IL_0338;
							}
							chrome_0.method_45(3, 5);
							while (true)
							{
								if (!chrome_0.D7A424AE("[role=\"progressbar\"]>svg"))
								{
									if (!chrome_0.D7A424AE(text2) || chrome_0.D7A424AE("[href=\"/reels/create/\"]"))
									{
										int_3++;
										num6++;
										method_131(int_4, text + $"({num6}/{num7}), đợi {{time}}s...", int_5, int_6);
										string reelUrl = "";
										if (flag5)
										{
											chrome_0.method_12("https://www.facebook.com/profile.php?sk=reels_tab");
											string string_2 = "https://www.facebook.com" + chrome_0.method_14("return document.querySelector('[href$=\"?s=fb_shorts_tab&stack_idx=0\"]').getAttribute('href')").ToString();
											method_74(string_2);
											reelUrl = string_2;
										}
										else
										{
											reelUrl = "https://www.facebook.com/reel/" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
										}
										KichBanThongKeDB.LogPost(chrome_0.B4208531, reelUrl, text3, "Đăng Reels", "Thành công");
										break;
									}
									if (chrome_0.D6BBEDA3())
									{
										return -4;
									}
								}
								if (Environment.TickCount - tickCount <= num5 * 1000)
								{
									chrome_0.F8091028(2.0);
									continue;
								}
								break;
							}
							goto end_IL_01ac;
							IL_04ec:
							if (flag3)
							{
								list = gclass4_0.method_1("txtHashtag");
								int num10 = Commom.BF833227(num3, num4);
								for (int j = 0; j < num10; j++)
								{
									if (list.Count == 0)
									{
										break;
									}
									string text5 = list.OrderBy((string DA052BA2) => Guid.NewGuid()).First();
									list.Remove(text5);
									text3 = text3 + "\n" + text5;
								}
								text3 = text3.Trim();
							}
							if (text3.Trim() != "")
							{
								try
								{
									var elReel = chrome_0.ChromeDriver_0.FindElement(OpenQA.Selenium.By.CssSelector("form [role=\"textbox\"], [role=\"textbox\"][contenteditable=\"true\"]"));
									if (elReel != null)
									{
										HumanTyping.TypeLikeHuman(chrome_0.ChromeDriver_0, elReel, text3);
									}
									else
									{
										chrome_0.AE3408BC("form [role=\"textbox\"]", text3);
									}
								}
								catch
								{
									chrome_0.AE3408BC("form [role=\"textbox\"]", text3);
								}
								chrome_0.F8091028(1.0);
							}
							goto IL_05af;
							IL_0338:
							if (Environment.TickCount - tickCount <= num9 * 1000)
							{
								goto IL_034f;
							}
							goto end_IL_01ac;
						}
						break;
						IL_034f:
						chrome_0.F8091028(2.0);
					}
					goto IL_073a;
					end_IL_01ac:;
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		goto IL_073a;
		IL_073a:
		chrome_0.method_54();
		return num6;
	}

	private int CF031D16(int F991EF3D, string B328531A, Chrome chrome_0, GClass4 gclass4_0, string EFBEB81E = "")
	{
		int int_ = gclass4_0.method_2("nudTTBVTimeFrom", 3);
		int int_2 = gclass4_0.method_2("nudTTBVTimeTo", 3);
		bool flag = gclass4_0.method_3("ckbTTBVInteract");
		string text = gclass4_0.BDB80B23("TTBVtypeReaction", "0");
		bool flag2 = gclass4_0.method_3("ckbTTBVCommentText");
		bool flag3 = gclass4_0.method_3("ckbTTBVCommentImage");
		string string_ = gclass4_0.BDB80B23("txtTTBVImagePath");
		bool flag4 = gclass4_0.method_3("ckbTTBVShareWall");
		bool flag5 = gclass4_0.method_3("ckbTTBVAutoDeleteComment");
		if (Commom.smethod_45(text.Replace("|", "")))
		{
			List<string> list = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
			for (int i = 0; i < list.Count; i++)
			{
				text = text.Replace(i.ToString(), list[i]);
			}
		}
		bool flag6 = false;
		while (true)
		{
			int num = chrome_0.method_125();
			if (num == 1)
			{
				continue;
			}
			if (!new List<int> { -3, -2, -1, 2 }.Contains(num))
			{
				int num2 = chrome_0.method_61();
				if (num2 == 1)
				{
					if (!flag6)
					{
						flag6 = true;
						chrome_0.method_53();
						if (chrome_0.method_49() == 1)
						{
							continue;
						}
					}
				}
				else
				{
					if (chrome_0.method_15(5.0, new List<string> { "[data-sigil=\"m-feed-voice-subtitle\"]", "[data-sigil=\"timestamp\"]" }) == "")
					{
						break;
					}
					if (chrome_0.method_30("[data-sigil=\"m-feed-voice-subtitle\"] > a") > 1)
					{
						chrome_0.method_18("[data-sigil=\"m-feed-voice-subtitle\"] > a");
						chrome_0.F8091028(2.0);
					}
					if (chrome_0.D7A424AE("[data-sigil=\"m-video-play-button playInlineVideo\"]"))
					{
						chrome_0.method_34("[data-sigil=\"m-video-play-button playInlineVideo\"]");
						chrome_0.F8091028(2.0);
						chrome_0.E11EB838("[data-sigil=\"playInlineVideo\"]");
						chrome_0.F8091028(1.0);
						chrome_0.E11EB838("[data-sigil=\"playInlineVideo\"]");
						chrome_0.F8091028(1.0);
					}
				}
				method_131(F991EF3D, B328531A + " View post, delay {time}s...", int_, int_2);
				if (flag)
				{
					method_130(F991EF3D, B328531A + " " + Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c") + "...");
					string text2 = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
					GClass4 gClass = new GClass4();
					gClass.method_4("reaction", text2);
					chrome_0.method_102(num2, gClass, 1);
				}
				if (flag2 || flag3)
				{
					string text3 = "";
					GClass4 gClass2 = new GClass4();
					method_130(F991EF3D, B328531A + " Comment...");
					if (flag3)
					{
						string value = Commom.smethod_76(string_).FirstOrDefault();
						if (!string.IsNullOrEmpty(value))
						{
							gClass2.method_4("image", value);
						}
					}
					if (flag2)
					{
						if (flag5)
						{
							lock (DBB0FB3E)
							{
								if (DBB0FB3E[EFBEB81E].Count > 0)
								{
									text3 = DBB0FB3E[EFBEB81E].smethod_8();
									DBB0FB3E[EFBEB81E].Remove(text3);
								}
							}
						}
						else if (DBB0FB3E[EFBEB81E].Count > 0)
						{
							text3 = DBB0FB3E[EFBEB81E].smethod_8();
						}
						string newValue = CommonChrome.smethod_1(chrome_0);
						text3 = text3.Replace("[u]", newValue);
					}
					gClass2.method_4("content", text3);
					chrome_0.DD052422(num2, gClass2, 1);
					if (chrome_0.D6BBEDA3())
					{
						return -4;
					}
				}
				if (!flag4)
				{
					break;
				}
				string text4 = "";
				method_130(F991EF3D, B328531A + " Share wall...");
				GClass4 gClass3 = new GClass4();
				gClass3.method_4("content", text4);
				chrome_0.AF0F44B1(num2, gClass3, 1);
				if (!chrome_0.D6BBEDA3())
				{
					break;
				}
				return -4;
			}
			return -1;
		}
		if (flag6)
		{
			chrome_0.method_54();
		}
		return 0;
	}

	private bool method_76(Chrome CC87BD8C, string string_1 = "")
	{
		string text = "[data-sigil=\"share-popup\"]";
		if (!CC87BD8C.D7A424AE(text))
		{
			return false;
		}
		CC87BD8C.method_20(text);
		CC87BD8C.method_18(text);
		CC87BD8C.method_45(1, 2);
		List<string> list = new List<string> { "#share-with-message-button", "[data-sigil=\"privacy-composer-menu\"] :not([data-store*=\"300645083384735\"]).checked", "#share_msg_input", "#share-one-click-button", "#share-post-one-click-button", "#share_submit" };
		if (string_1 == "")
		{
			list.Remove("#share-with-message-button");
			list.Remove("#share_msg_input");
		}
		int tickCount = Environment.TickCount;
		int num = 60;
		while (true)
		{
			string text2 = CC87BD8C.method_15(0.0, list);
			switch (text2)
			{
			case "#share-with-message-button":
				CC87BD8C.method_18(text2);
				list.Remove(text2);
				goto default;
			default:
				if (Environment.TickCount - tickCount <= num * 1000)
				{
					goto IL_00de;
				}
				return false;
			case "[data-sigil=\"privacy-composer-menu\"] :not([data-store*=\"300645083384735\"]).checked":
				if (CC87BD8C.method_18("[data-sigil~=\"privacy-button\"]"))
				{
					CC87BD8C.F8091028(1.0);
					CC87BD8C.method_18("[data-sigil=\"privacy-composer-menu\"] [data-store*=\"300645083384735\"]");
					CC87BD8C.F8091028(1.0);
				}
				list.Remove(text2);
				goto default;
			case "#share-one-click-button":
			case "#share-post-one-click-button":
			case "#share_submit":
				CC87BD8C.method_18(text2);
				break;
			case "#share_msg_input":
				CC87BD8C.method_22("#share_msg_input", string_1);
				CC87BD8C.F8091028(2.0);
				CC87BD8C.method_18("#share_submit");
				break;
			}
			break;
			IL_00de:
			CC87BD8C.F8091028(1.0);
		}
		return true;
	}

	private void F12A6CA2(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0)
	{
		try
		{
			if (chrome_0 == null || chrome_0.ChromeDriver_0 == null || chrome_0.CD930D04() || chrome_0.E184CD03())
			{
				return;
			}

			method_130(int_3, string_1 + Language.GetValue("Tương tác nhóm trước khi đăng") + "...");

			// Bước 1: Lướt dạo feed nhóm mô phỏng hành vi người thật
			method_130(int_3, string_1 + Language.GetValue("Lướt dạo bảng tin nhóm...") + "...");
			int scrollTimes = Base.rd.Next(2, 4);
			for (int s = 0; s < scrollTimes; s++)
			{
				if (chrome_0.CD930D04() || chrome_0.E184CD03()) return;
				int scrollDist = Base.rd.Next(500, 950);
				HumanScroll.ScrollNewsfeed(chrome_0, scrollDist);
				chrome_0.F8091028(Base.rd.Next(1, 3));
			}

			// Bước 2: Mô phỏng người thật đọc bài (Click Xem thêm / See More nếu có)
			try
			{
				chrome_0.method_14(@"
					(() => {
						var seeMoreBtns = Array.from(document.querySelectorAll('div[role=""feed""] div[role=""button""], div[role=""main""] div[role=""button""]'));
						for (var b of seeMoreBtns) {
							var t = (b.innerText || '').toLowerCase();
							if (t === 'xem thêm' || t === 'see more') {
								var rect = b.getBoundingClientRect();
								if (rect.top >= 0 && rect.top <= window.innerHeight) {
									b.click();
									break;
								}
							}
						}
					})()
				");
				chrome_0.F8091028(1.0);
			}
			catch { }

			// Bước 3: Cấu hình số bài và cảm xúc
			string text = gclass4_0.BDB80B23("TTPtypeReaction", "0");
			List<string> candidateReactions = new List<string>();
			if (Commom.smethod_45(text.Replace("|", "")))
			{
				List<string> list = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
				string[] parts = text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var p in parts)
				{
					if (int.TryParse(p, out int idx) && idx >= 0 && idx < list.Count)
					{
						candidateReactions.Add(list[idx]);
					}
				}
			}
			else if (text.Contains("|"))
			{
				candidateReactions = text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			}
			else if (!string.IsNullOrEmpty(text))
			{
				candidateReactions.Add(text);
			}

			if (candidateReactions.Count == 0)
			{
				candidateReactions = new List<string> { "Like", "Love", "Care", "Haha", "Wow" };
			}

			int uFrom = gclass4_0.method_2("nudTTPSoLuongFrom", 1);
			int uTo = gclass4_0.method_2("nudTTPSoLuongTo", 1);
			int countPosts = 1;
			if (uTo >= uFrom && uFrom > 0)
			{
				countPosts = Math.Min(5, Math.Max(1, Base.rd.Next(uFrom, uTo + 1)));
			}

			bool allowInteract = gclass4_0.method_3("ckbTTPInteract", true);
			bool allowCommentText = gclass4_0.method_3("ckbTTPCommentText");
			bool allowCommentImage = gclass4_0.method_3("ckbTTPCommentImage");
			bool allowShareWall = gclass4_0.method_3("ckbTTPShareWall");
			string imageFolderPath = gclass4_0.BDB80B23("txtTTPImagePath");
			int delayFrom = gclass4_0.method_2("nudTTPDelayFrom", 3);
			int delayTo = gclass4_0.method_2("nudTTPDelayTo", 5);

			// Chuẩn bị danh sách comment text nếu có
			List<string> commentsList = new List<string>();
			if (allowCommentText)
			{
				string rawCmt = gclass4_0.BDB80B23("txtTTPComment");
				int optCmt = gclass4_0.method_2("cbbTTPTuyChonNoiDung", 0);
				if (!string.IsNullOrWhiteSpace(rawCmt))
				{
					if (optCmt == 0)
					{
						commentsList = rawCmt.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
					}
					else
					{
						commentsList = rawCmt.Split(new string[] { "---", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
					}
				}
			}

			// Chuẩn bị danh sách ảnh nếu có
			List<string> imageFiles = new List<string>();
			if (allowCommentImage && !string.IsNullOrWhiteSpace(imageFolderPath) && Directory.Exists(imageFolderPath))
			{
				try
				{
					imageFiles = Directory.GetFiles(imageFolderPath, "*.*")
						.Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
									s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
									s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
									s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
									s.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
						.ToList();
				}
				catch { }
			}

			int typeComment = gclass4_0.method_2("typeComment", 0); // 0: Ngẫu nhiên, 1: Theo thứ tự
			bool autoDeleteComment = gclass4_0.method_3("ckbAutoDeleteComment", false);

			// Vòng lặp tương tác từng bài viết
			for (int p = 0; p < countPosts; p++)
			{
				if (chrome_0.CD930D04() || chrome_0.E184CD03()) break;

				// 1. Bày tỏ cảm xúc
				if (allowInteract)
				{
					string chosenReaction = candidateReactions[Base.rd.Next(0, candidateReactions.Count)];
					method_130(int_3, string_1 + string.Format(Language.GetValue("Tương tác cảm xúc {0} bài {1}/{2}..."), chosenReaction, p + 1, countPosts));

					try
					{
						Newtonsoft.Json.Linq.JObject reactParam = new Newtonsoft.Json.Linq.JObject();
						reactParam["reaction"] = chosenReaction;
						reactParam["indexPost"] = p;
						FacebookActionsHub.Execute(chrome_0, "ReactionWWW", reactParam.ToString());
					}
					catch { }

					chrome_0.F8091028(Base.rd.Next(1, 3));
				}

				// 2. Bình luận (Text và/hoặc Image)
				if (allowCommentText || (allowCommentImage && imageFiles.Count > 0))
				{
					string cmtToSend = "";
					if (allowCommentText && commentsList.Count > 0)
					{
						int cmtIdx = (typeComment == 1) ? (p % commentsList.Count) : Base.rd.Next(0, commentsList.Count);
						cmtToSend = commentsList[cmtIdx];
						// SPINTAX: Áp dụng Spintax chuẩn LushCare
						cmtToSend = Commom.smethod_44(cmtToSend);

						if (autoDeleteComment)
						{
							commentsList.RemoveAt(cmtIdx);
							gclass4_0.method_4("txtTTPComment", string.Join("\n", commentsList));
						}
					}

					string pickedImage = "";
					if (allowCommentImage && imageFiles.Count > 0)
					{
						pickedImage = imageFiles[Base.rd.Next(0, imageFiles.Count)];
					}

					if (!string.IsNullOrEmpty(cmtToSend) || !string.IsNullOrEmpty(pickedImage))
					{
						method_130(int_3, string_1 + string.Format(Language.GetValue("Bình luận bài viết {0}/{1}..."), p + 1, countPosts));
						try
						{
							Newtonsoft.Json.Linq.JObject cmtParam = new Newtonsoft.Json.Linq.JObject();
							cmtParam["content"] = cmtToSend;
							cmtParam["comment"] = cmtToSend;
							cmtParam["image"] = pickedImage;
							cmtParam["indexPost"] = p;
							FacebookActionsHub.Execute(chrome_0, "CommentWWW", cmtParam.ToString());
						}
						catch { }

						chrome_0.F8091028(Base.rd.Next(1, 3));
					}
				}

				// 3. Chia sẻ về tường (nếu bật)
				if (allowShareWall && p == 0) // Chia sẻ 1 bài tiêu biểu
				{
					try
					{
						method_130(int_3, string_1 + Language.GetValue("Chia sẻ bài viết nhóm về tường..."));
						Newtonsoft.Json.Linq.JObject shareParam = new Newtonsoft.Json.Linq.JObject();
						shareParam["indexPost"] = p;
						FacebookActionsHub.Execute(chrome_0, "ShareWallWWW", shareParam.ToString());
						chrome_0.F8091028(Base.rd.Next(1, 3));
					}
					catch { }
				}

				// Delay giữa các bài
				if (p + 1 < countPosts)
				{
					method_131(int_3, string_1 + string.Format(Language.GetValue("Đã tương tác bài ({0}/{1})"), p + 1, countPosts) + ", đợi {time}s...", delayFrom, delayTo);
					HumanScroll.ScrollNewsfeed(chrome_0, Base.rd.Next(400, 750));
				}
			}

			// Bước 4: Delay tạo trust cao trước khi mở khung đăng bài
			int trustDelay = Base.rd.Next(3, 7);
			method_130(int_3, string_1 + string.Format(Language.GetValue("Hoàn tất tương tác nhóm, nghỉ {0}s tạo trust trước khi đăng..."), trustDelay));
			Commom.smethod_52(trustDelay);
		}
		catch (Exception ex)
		{
			Commom.smethod_49("F12A6CA2 Group Interaction Error: " + ex.Message);
		}
	}

	private int method_77(ref int F21DDB37, int int_3, string E231BC22, Chrome F039B9BE, GClass4 gclass4_0, string string_1, string string_2)
	{
		F21DDB37 = 0;
		int num = gclass4_0.method_2("nudDelayFrom");
		int num2 = gclass4_0.method_2("nudDelayTo");
		List<string> list = gclass4_0.method_1("txtLinkChiaSe");
		bool flag = gclass4_0.method_3("ckbVanBan");
		bool flag2 = gclass4_0.method_3("ckbTuDongXoaNoiDung");
		bool flag3 = gclass4_0.method_3("ckbTuongTacBaiViet");
		bool flag4 = gclass4_0.method_3("ckbShareBaiLenTuong");
		bool flag5 = gclass4_0.method_3("ckbShareBaiLenNhom");
		int minValue = gclass4_0.method_2("nudCountGroupFrom");
		int num3 = gclass4_0.method_2("nudCountGroupTo");
		int num4 = gclass4_0.method_2("typeShare");
		List<string> A89D1BBD = gclass4_0.method_1("lstNhomTuNhap");
		bool flag6 = gclass4_0.method_3("ckbChiShareNhomDaThamGia");
		bool flag7 = gclass4_0.method_3("ckbOnlyShareNhomKhongKiemDuyet");
		bool flag8 = gclass4_0.method_3("ckbUuTienNhomNhieuThanhVien");
		bool flag9 = gclass4_0.method_3("ckbKhongShareTrung");
		bool flag10 = gclass4_0.method_3("ckbTuongTacNhom");
		if (flag9 && !dictionary_28.ContainsKey(string_2))
		{
			dictionary_28.Add(string_2, new List<string>());
		}
		new List<string>();
		List<string> list2 = new List<string>();
		string string_3 = list[int_3 % list.Count];
		string_3 = Commom.smethod_31(string_3);
		string value = Regex.Match(string_3, "https://(.*?)facebook.com/").Value;
		if (value != "")
		{
			string_3 = string_3.Replace(value, "https://www.facebook.com/");
		}
		int num5 = 0;
		try
		{
			if (flag3)
			{
				F039B9BE.method_12(string_3);
				F039B9BE.F8091028(2.0);
				CF031D16(int_3, E231BC22 + Language.GetValue("Đang tương tác bài viết "), F039B9BE, gclass4_0);
			}
			string d30F = "";
			if (flag && gclass4_0.method_3("ckbTaoNoiDungAI"))
			{
				string json = F039B9BE.method_101(string_3);
				try
				{
					JObject jObject = JObject.Parse(json);
					d30F = jObject["content"]!.ToString();
				}
				catch (Exception)
				{
				}
			}
			F039B9BE.method_53();
			if (flag4)
			{
				method_130(int_3, E231BC22 + Language.GetValue("Share tường") + "...");
				if (F039B9BE.CD930D04())
				{
					return -2;
				}
				int num6;
				do
				{
					F039B9BE.method_12("https://www.facebook.com/profile.php?locale=en_US");
					num6 = F039B9BE.method_125();
				}
				while (num6 == 1);
				if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
				{
					return -1;
				}
				string f818BC = "";
				if (flag)
				{
					if (gclass4_0.method_3("ckbTaoNoiDungAI"))
					{
						f818BC = Commom.smethod_93(gclass4_0.BDB80B23("cbbPrompt"), d30F, "");
					}
					else if (dictionary_24[string_2].Count > 0)
					{
						if (!flag2)
						{
							f818BC = dictionary_24[string_2].OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
						}
						else
						{
							lock (dictionary_24)
							{
								int index = dictionary_24[string_2].smethod_7();
								f818BC = dictionary_24[string_2][index];
								dictionary_24[string_2].RemoveAt(index);
							}
						}
					}
				}
				string shareContentWall = string.IsNullOrEmpty(f818BC) ? string_3 : (f818BC + "\n" + string_3);
				if (!string.IsNullOrEmpty(F039B9BE.ExecuteDangBaiWWW(0, "", shareContentWall)))
				{
					F21DDB37++;
					method_130(int_3, E231BC22 + Language.GetValue("Share tường xong, đợi {time}s..."), Commom.BF833227(num, num2));
				}
				if (F039B9BE.D6BBEDA3())
				{
					return -4;
				}
			}
			if (flag5)
			{
				num5 = 0;
				if (F039B9BE.CD930D04())
				{
					return -2;
				}
				List<string> source = new List<string>();
				if (num4 == 0 || (num4 == 1 && flag6))
				{
					method_130(int_3, E231BC22 + Language.GetValue("Scan group..."));
					source = F039B9BE.method_56(flag7);
				}
				list2 = ((!flag7) ? source.Select((string C0802C1E) => C0802C1E).ToList() : source.Where((string BD1EFF8E) => BD1EFF8E.Split('|').Last().ToLower() == "false").ToList());
				if (flag8)
				{
					if (flag7)
					{
						list2.Sort((string BA2BD525, string string_0) => int.Parse(string_0.Split('|')[string_0.Split('|').Length - 2]).CompareTo(int.Parse(BA2BD525.Split('|')[BA2BD525.Split('|').Length - 2])));
					}
					else
					{
						list2.Sort((string string_0, string string_1) => int.Parse(string_1.Split('|').Last()).CompareTo(int.Parse(string_0.Split('|').Last())));
					}
				}
				else
				{
					list2 = list2.OrderBy((string string_0) => Guid.NewGuid()).ToList();
				}
				if (num4 == 1)
				{
					if (flag6)
					{
						source = Commom.smethod_30(list2);
						list2 = source.Where((string C6AA5A23) => A89D1BBD.Contains(C6AA5A23.Split('|')[0])).ToList();
					}
					else
					{
						list2 = new List<string>(A89D1BBD);
						list2 = list2.OrderBy((string string_0) => Guid.NewGuid()).ToList();
					}
				}
				int num7 = Base.rd.Next(minValue, num3 + 1);
				string text = "";
				if (list2.Count > 0)
				{
					method_130(int_3, E231BC22 + Language.GetValue("Đang share nhóm") + "...");
					int num8 = 0;
					while (num8 < num7)
					{
						while (list2.Count != 0)
						{
							text = list2[0];
							list2.Remove(text);
							text = text.Split('|')[0];
							if (flag9)
							{
								lock (dictionary_28[string_2])
								{
									if (dictionary_28[string_2].Contains(text))
									{
										continue;
									}
									dictionary_28[string_2].Add(text);
									goto IL_0683;
								}
							}
							goto IL_0683;
						}
						break;
						IL_0683:
						if (flag10)
						{
							F039B9BE.method_12("https://m.facebook.com/groups/" + text);
							F12A6CA2(int_3, E231BC22, F039B9BE, gclass4_0);
						}
						method_130(int_3, E231BC22 + string.Format(Language.GetValue("Đang share nhóm") + " ({0}/{1})", num5 + 1, num7) + "...");
						int num9;
						do
						{
							F039B9BE.method_12("https://www.facebook.com/groups/" + text + "?locale=en_US");
							num9 = F039B9BE.method_125();
						}
						while (num9 == 1);
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num9))
						{
							string f818BC2 = "";
							if (flag)
							{
								if (gclass4_0.method_3("ckbTaoNoiDungAI"))
								{
									f818BC2 = Commom.smethod_93(gclass4_0.BDB80B23("cbbPrompt"), d30F, "");
								}
								else if (dictionary_24[string_2].Count > 0)
								{
									if (!flag2)
									{
										f818BC2 = dictionary_24[string_2].OrderBy((string string_0) => Guid.NewGuid()).FirstOrDefault();
									}
									else
									{
										lock (dictionary_24)
										{
											int index2 = dictionary_24[string_2].smethod_7();
											f818BC2 = dictionary_24[string_2][index2];
											dictionary_24[string_2].RemoveAt(index2);
										}
									}
								}
							}
							string groupTargetUrl = "https://www.facebook.com/groups/" + text;
							string shareContentGroup = string.IsNullOrEmpty(f818BC2) ? string_3 : (f818BC2 + "\n" + string_3);
							if (!string.IsNullOrEmpty(F039B9BE.ExecuteDangBaiWWW(1, groupTargetUrl, shareContentGroup)))
							{
								F21DDB37++;
								num5++;
								method_130(int_3, E231BC22 + string.Format(Language.GetValue("Đang share nhóm") + " ({0}/{1})", num5, num7) + ", đợi {time}s...", Commom.BF833227(num, num2));
							}
							if (!F039B9BE.D6BBEDA3())
							{
								num8++;
								continue;
							}
							return -4;
						}
						return -1;
					}
				}
			}
			F039B9BE.method_54();
		}
		catch
		{
		}
		return num5;
	}

	private int method_78(int int_3, string string_1, GClass4 gclass4_0, string F7BDC820)
	{
		return PersonalInteractionHelper.TakeBreak(this, int_3, string_1, gclass4_0, F7BDC820);
	}

	private void method_79(Chrome chrome_0, string string_1, int int_3)
	{
		try
		{
			if (chrome_0 != null)
			{
				string text = Commom.smethod_95() + "\\log_capture";
				switch (int_3)
				{
				case 0:
					text += "\\checkpoint";
					break;
				case 1:
					text += "\\loginfail";
					break;
				case 2:
					text += "\\disconnect";
					break;
				}
				Commom.CreateFolder(text);
				chrome_0.method_38(text, string_1);
				File.WriteAllText(text + "\\" + string_1 + ".txt", chrome_0.GetURL());
				File.WriteAllText(text + "\\" + string_1 + ".html", chrome_0.AFACE5B4());
			}
		}
		catch
		{
		}
	}

	private void method_80(Chrome A4103D01)
	{
		try
		{
			A4103D01.method_12("https://www.facebook.com/");
			string text = Commom.F914B80B(A4103D01.AFACE5B4(), "\"logout_hash\":\"(.*?)\"");
			string text2 = A4103D01.method_48("https://www.facebook.com/logout.php?button_location=settings&button_name=logout", "h=" + text + "&ref=mb");
			text2.Contains("royal_login_form");
		}
		catch
		{
		}
	}

	public int method_81(int D63D65A7, string string_1, Chrome chrome_0, string string_2, int int_3, int F0051930, int E3944109, int B42DF427, int A20A160F, bool bool_5, int C5955636, bool BB0F2AA3, List<string> list_5, List<string> DC364126, bool A68AD43F, List<string> CC18B639, string string_3, int int_4, string C30411A4 = "")
	{
		int num = 0;
		int num2 = chrome_0.method_50(int_3, F0051930);
		bool flag = false;
		if (num2 != 0)
		{
			try
			{
				if (A20A160F == 0 && DC364126.Count == 0)
				{
					chrome_0.method_53();
					string text = "";
					int num3;
					do
					{
						chrome_0.method_12("https://www.facebook.com/groups/joins/?nav_source=tab&ordering=viewer_added&locale=en_US");
						chrome_0.F8091028(2.0);
						num3 = chrome_0.method_125();
					}
					while (num3 == 1);
					if (new List<int> { -3, -2, -1, 2 }.Contains(num3))
					{
						return -1;
					}
					chrome_0.method_60();
					method_130(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num + 1}/{num2})...");
					int tickCount = Environment.TickCount;
					int num4 = 60;
					while (Environment.TickCount - tickCount <= num4 * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
					{
						string text2 = chrome_0.method_15(0.0, new List<string> { "[aria-label=\"More\" i]" });
						string text3 = text2;
						string text4 = text3;
						if (!(text4 == "[aria-label=\"More\" i]"))
						{
							if (text != "")
							{
								method_131(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num + 1}/{num2}), delay {{time}}s...", E3944109, B42DF427);
								break;
							}
							if (chrome_0.method_6("[role=\"main\"] [role=\"list\"]") == "")
							{
								break;
							}
						}
						else if (chrome_0.D7A424AE("[aria-labelledby][role=\"dialog\"] [aria-label=\"Close\"]"))
						{
							chrome_0.method_19("[aria-labelledby][role=\"dialog\"] [aria-label=\"Close\"]");
						}
						else if (chrome_0.D7A424AE("[aria-label=\"Leave Group\"]"))
						{
							chrome_0.method_19("[aria-label=\"Leave Group\"]");
						}
						else if (chrome_0.D7A424AE("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'leave group')]"))
						{
							chrome_0.method_19("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'leave group')]");
						}
						else if (chrome_0.D7A424AE("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'cancel request')]"))
						{
							chrome_0.method_19("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'cancel request')]");
						}
						else
						{
							string text5 = chrome_0.B9BE8807("//*[@aria-label=\"More\"]/preceding::*[@aria-label=\"View group\"]", "href");
							if (text == "")
							{
								text = text5;
							}
							if (text5 != text)
							{
								method_131(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num + 1}/{num2}), delay {{time}}s...", E3944109, B42DF427);
								num++;
								if (num >= num2)
								{
									break;
								}
								text = text5;
								tickCount = Environment.TickCount;
								method_130(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num + 1}/{num2})...");
							}
							chrome_0.method_19("[aria-label=\"More\" i]");
						}
						chrome_0.F8091028(2.0);
					}
					chrome_0.method_54();
					return num;
				}
				List<string> list = CB802318(chrome_0, A20A160F, bool_5, C5955636, BB0F2AA3, list_5, A68AD43F, CC18B639);
				if (DC364126.Count > 0)
				{
					list = list.Except(DC364126).ToList();
				}
				if (list.Count != 0)
				{
					num2 = Math.Min(list.Count, num2);
					int num5 = 0;
					while (list.Count > 0)
					{
						method_130(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num + 1}/{num2})...");
						string text6 = list.smethod_8();
						list.Remove(text6);
						string text7 = "";
						while (true)
						{
							if (!flag)
							{
								text7 = chrome_0.C604C58C("https://m.facebook.com/groups/" + text6 + "/?notif_t=added_to_group_reminder");
							}
							else
							{
								chrome_0.method_12("https://facebook.com/" + text6);
								int num6 = chrome_0.method_125();
								if (num6 == 1)
								{
									continue;
								}
								if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
								{
									break;
								}
							}
							int num7 = chrome_0.method_61();
							if (num7 == 1)
							{
								if (!flag)
								{
									flag = true;
									chrome_0.method_53();
									chrome_0.method_49();
									continue;
								}
								chrome_0.method_60();
							}
							bool flag2 = false;
							if (num7 != 1)
							{
								if (!text7.Contains("invite_response=accept"))
								{
									chrome_0.method_12("https://m.facebook.com/groups/" + text6 + "?view=info");
									chrome_0.F8091028(2.0);
									int num8 = chrome_0.method_125();
									if (num8 == 1)
									{
										continue;
									}
									if (new List<int> { -3, -2, -1, 2 }.Contains(num8))
									{
										return -1;
									}
									if (chrome_0.D7A424AE("[href=\"/\"]") || chrome_0.D6BBEDA3())
									{
										break;
									}
									for (int i = 0; i < 3; i++)
									{
										if (!chrome_0.method_18("a[href*=\"/group/leave/\"]"))
										{
											chrome_0.F8091028(2.0);
											continue;
										}
										chrome_0.F8091028(3.0);
										break;
									}
									if (chrome_0.D7A424AE("[name=\"confirm\"]", 10.0))
									{
										num5 = 0;
										chrome_0.method_45(2, 3);
										chrome_0.method_18("[name=\"confirm\"]");
										chrome_0.method_45(2, 3);
										flag2 = true;
									}
									else
									{
										num5++;
										if (num5 == 20)
										{
											break;
										}
									}
								}
								else
								{
									chrome_0.method_12("https://m.facebook.com/groups/" + text6 + "/?notif_t=added_to_group_reminder");
									chrome_0.F8091028(1.0);
									string text8 = chrome_0.GetURL();
									if (chrome_0.D7A424AE("[data-ajaxify-href*=\"invite_response=decline\"]", 10.0))
									{
										chrome_0.method_17("[data-ajaxify-href*=\"invite_response=decline\"]");
										for (int j = 0; j < 20; j++)
										{
											if (chrome_0.GetURL() != text8)
											{
												break;
											}
											Thread.Sleep(1000);
										}
										flag2 = true;
									}
								}
							}
							else
							{
								flag2 = chrome_0.method_107();
								if (!flag2)
								{
									flag2 = OtherUtilitiesHelper.LeaveGroupComet(chrome_0, text6);
								}
							}
							if (flag2)
							{
								num++;
								method_130(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num}/{num2})...");
								if (num >= num2)
								{
									break;
								}
								method_131(D63D65A7, string_1 + Language.GetValue("Đang") + $" {C30411A4} ({num}/{num2}), đợi {{time}}s...", E3944109, B42DF427);
							}
							goto IL_06d9;
						}
						break;
						IL_06d9:;
					}
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(chrome_0, exception_, "Error Leave Group");
			}
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num;
	}

	private bool method_82(string string_1, List<string> A7394F14)
	{
		bool result = false;
		try
		{
			for (int i = 0; i < A7394F14.Count; i++)
			{
				if (Commom.EB835717(string_1).ToLower().Contains(Commom.EB835717(A7394F14[i]).ToLower()))
				{
					result = true;
					return result;
				}
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	private List<string> CB802318(Chrome chrome_0, int D9348FA1, bool bool_5, int int_3, bool bool_6, List<string> list_5, bool bool_7, List<string> list_6)
	{
		List<string> list = new List<string>();
		try
		{
			if (D9348FA1 == 2)
			{
				list_5 = list_5.ConvertAll((string string_0) => string_0.ToLower());
			}
			List<string> list2 = chrome_0.method_56(D9348FA1 == 1);
			for (int i = 0; i < list2.Count; i++)
			{
				string text = list2[i].Split('|')[0];
				switch (D9348FA1)
				{
				case 0:
					list.Add(text);
					continue;
				case 1:
				{
					string text2 = list2[i].Split('|')[3];
					if (text2.ToString().ToLower() == "true")
					{
						list.Add(text);
					}
					continue;
				}
				}
				string string_ = list2[i].Split('|')[1];
				string value = list2[i].Split('|')[2];
				if ((bool_5 && Convert.ToInt32(value) < int_3) || (bool_6 && method_82(string_, list_5)) || (bool_7 && method_82(text, list_6)))
				{
					list.Add(text);
				}
			}
		}
		catch
		{
		}
		return list;
	}

	public int BB8424AC(int DA388136, string F49F9F97, Chrome EE1CBB13, GClass4 gclass4_0, string string_1 = "")
	{
		int int_ = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int int_2 = gclass4_0.method_2("nudDelayFrom");
		int int_3 = gclass4_0.method_2("nudDelayTo");
		List<string> list = gclass4_0.method_1("txtUid");
		bool flag = gclass4_0.method_3("ckbChiKetBanTenCoDau");
		int num = 1;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			int num5 = EE1CBB13.method_50(int_, f4960BA);
			num4 = ((num5 >= 100) ? 10 : 5);
			string text = "";
			if (num == 2)
			{
				while (list.Count > 0)
				{
					text = list[Base.rd.Next(0, list.Count)];
					list.Remove(text);
					int num6;
					do
					{
						EE1CBB13.method_12("https://m.facebook.com/browse/group/members/?id=" + text + "&start=0&listType=list_nonfriend_nonadmin");
						EE1CBB13.F8091028(2.0);
						num6 = EE1CBB13.method_125();
					}
					while (num6 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
					{
						string text2 = "[data-sigil=\"m-add-friend-flyout\"]:not([style*=\"display: none\"])";
						method_130(DA388136, F49F9F97 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num5})...");
						while (true)
						{
							if (!EE1CBB13.D7A424AE(text2))
							{
								for (int i = 1; i < 5; i++)
								{
									EE1CBB13.method_32(0, i * 1000);
									EE1CBB13.F8091028(2.0);
									if (EE1CBB13.D7A424AE(text2))
									{
										break;
									}
								}
								if (!EE1CBB13.D7A424AE(text2))
								{
									break;
								}
							}
							if (!EE1CBB13.method_118())
							{
								num3 = 0;
								goto IL_018b;
							}
							num3++;
							if (num3 < num4)
							{
								EE1CBB13.method_31(text2);
								goto IL_018b;
							}
							goto end_IL_0062;
							IL_018b:
							bool flag2 = true;
							if (flag)
							{
								string string_2 = EE1CBB13.method_14("return document.querySelector('[id^=\"member_\"]:has(" + text2 + ") h3').innerText").ToString();
								if (!Commom.D9AB3B82(string_2))
								{
									flag2 = false;
								}
							}
							if (!flag2 || !EE1CBB13.method_19(text2))
							{
								continue;
							}
							num2++;
							method_131(DA388136, F49F9F97 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_1, num2, num5, Language.GetValue("đợi")), int_2, int_3);
							if (num2 < num5)
							{
								method_130(DA388136, F49F9F97 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num5})...");
								continue;
							}
							goto end_IL_0062;
						}
						continue;
					}
					return -1;
				}
			}
			else if (num == 1)
			{
				while (list.Count > 0)
				{
					text = list[Base.rd.Next(0, list.Count)];
					list.Remove(text);
					Queue<string> queue = new Queue<string>();
					queue.Enqueue("https://www.facebook.com/groups/" + text + "/members");
					string text3 = queue.Dequeue();
					EE1CBB13.method_53();
					int num7;
					do
					{
						EE1CBB13.method_12(text3 + "?locale=en_US");
						EE1CBB13.F8091028(2.0);
						num7 = EE1CBB13.method_125();
					}
					while (num7 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num7))
					{
						method_130(DA388136, F49F9F97 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num5})...");
						int num8 = 0;
						List<int> list2 = new List<int>();
						num3 = 0;
						int tickCount = Environment.TickCount;
						int num9 = 60;
						while (Environment.TickCount - tickCount <= num9 * 1000 && !Base.smethod_5() && !EE1CBB13.CD930D04())
						{
							string text4 = EE1CBB13.method_15(0.0, new List<string> { "//div[@role=\"list\"]//div[@data-visualcompletion and @role=\"listitem\" and not(descendant::span[not(@id) and (descendant::text()=\"Admin\" or descendant::text()=\"Moderator\")]) ]" });
							string text5 = text4;
							string text6 = text5;
							if (!(text6 == "//div[@role=\"list\"]//div[@data-visualcompletion and @role=\"listitem\" and not(descendant::span[not(@id) and (descendant::text()=\"Admin\" or descendant::text()=\"Moderator\")]) ]"))
							{
								if (queue.Count > 0)
								{
									text3 = queue.Dequeue();
									EE1CBB13.method_12(text3);
									num8 = 0;
								}
								continue;
							}
							if (EE1CBB13.method_118())
							{
								num2--;
								if (list2.Count != 0 && list2.Last() != num2)
								{
									list2.Clear();
								}
								list2.Add(num2);
								if (list2.Count < num4)
								{
									continue;
								}
							}
							else
							{
								num8++;
								if (num8 <= EE1CBB13.method_30(text4))
								{
									goto IL_0566;
								}
								EE1CBB13.method_35("(" + text4 + ")[last()]");
								EE1CBB13.F8091028(5.0);
								if (num8 <= EE1CBB13.method_30(text4))
								{
									goto IL_0566;
								}
								if (queue.Count > 0)
								{
									text3 = queue.Dequeue();
									EE1CBB13.method_12(text3);
									num8 = 0;
									continue;
								}
							}
							goto end_IL_0062;
							IL_0566:
							string text7 = $"({text4})[{num8}]";
							string text8 = text7 + "//div[not(@aria-disabled=\"true\") and @aria-label=\"Add friend\"]";
							if (!EE1CBB13.D7A424AE(text8))
							{
								continue;
							}
							if (flag)
							{
								string string_3 = EE1CBB13.method_6(text7 + "//span[@id]");
								if (!Commom.D9AB3B82(string_3))
								{
									continue;
								}
							}
							if (!EE1CBB13.method_19(text8))
							{
								continue;
							}
							method_131(DA388136, F49F9F97 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num5}), delay {{time}}s...", int_2, int_3);
							num2++;
							if (num2 < num5)
							{
								method_130(DA388136, F49F9F97 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num5})...");
								tickCount = Environment.TickCount;
								continue;
							}
							goto end_IL_0062;
						}
						continue;
					}
					return -1;
				}
			}
			end_IL_0062:;
		}
		catch
		{
		}
		EE1CBB13.method_54();
		return num2;
	}

	public int method_83(int int_3, string A92F5F31, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "")
	{
		return GroupJoinAutomationHelper.JoinGroups(this, int_3, A92F5F31, chrome_0, gclass4_0, string_1);
	}

	public int method_84(int B53CC00B, string BD1EE5B8, Chrome chrome_0, GClass4 F6A95624, string DDA80588 = "")
	{
		int num = F6A95624.method_2("cbbTypeHuyKetBan");
		int int_ = F6A95624.method_2("nudSoLuongFrom");
		int f4960BA = F6A95624.method_2("nudSoLuongTo");
		int int_2 = F6A95624.method_2("nudDelayFrom");
		int int_3 = F6A95624.method_2("nudDelayTo");
		List<string> second = F6A95624.method_1("txtUidHuyKetBan");
		List<string> list = F6A95624.method_1("txtUidKhongHuyKetBan");
		int num2 = 0;
		int num3 = chrome_0.method_50(int_, f4960BA);
		if (num3 <= 0)
		{
			return num2;
		}
		if (num == 0 && list.Count == 0)
		{
			new List<int>();
			chrome_0.method_53();
			int num4;
			do
			{
				chrome_0.method_12("https://www.facebook.com/friends/list?Locale=en_US");
				chrome_0.F8091028(2.0);
				num4 = chrome_0.method_125();
			}
			while (num4 == 1);
			if (new List<int> { -3, -2, -1, 2 }.Contains(num4))
			{
				return -1;
			}
			chrome_0.method_60();
			method_130(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2 + 1}/{num3})...");
			int tickCount = Environment.TickCount;
			int num5 = 60;
			while (Environment.TickCount - tickCount <= num5 * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				string text = chrome_0.method_15(0.0, new List<string> { "[aria-label=\"More\" i]" });
				string text2 = text;
				string text3 = text2;
				if (text3 == "[aria-label=\"More\" i]")
				{
					if (chrome_0.D7A424AE("[aria-label=\"Confirm\" i]"))
					{
						chrome_0.method_19("[aria-label=\"Confirm\" i]");
						method_131(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2 + 1}/{num3}), delay {{time}}s...", int_2, int_3);
						num2++;
						if (num2 >= num3)
						{
							break;
						}
						tickCount = Environment.TickCount;
						method_130(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2 + 1}/{num3})...");
					}
					else if (chrome_0.D7A424AE("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'unfriend')]"))
					{
						chrome_0.method_19("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'unfriend')]");
					}
					else
					{
						chrome_0.method_19(text);
					}
				}
				chrome_0.F8091028(2.0);
			}
			chrome_0.method_54();
			return num2;
		}
		List<string> list2 = chrome_0.method_57((num == 1) ? 2 : 0);
		if (num == 2)
		{
			list2 = list2.Intersect(second).ToList();
		}
		if (list.Count > 0)
		{
			list2 = list2.Except(list).ToList();
		}
		if (list2.Count == 0)
		{
			return num2;
		}
		num3 = Math.Min(list2.Count, num3);
		bool flag = false;
		try
		{
			while (list2.Count > 0)
			{
				method_130(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2 + 1}/{num3})...");
				string text4 = list2.smethod_8();
				list2.Remove(text4);
				int num7;
				while (true)
				{
					if (!flag)
					{
						chrome_0.method_12("https://m.facebook.com/removefriend.php?friend_id=" + text4 + "&unref=bd_profile_button");
					}
					else
					{
						chrome_0.method_12("https://facebook.com/" + text4);
					}
					chrome_0.F8091028(2.0);
					int num6 = chrome_0.method_125();
					if (num6 != 1)
					{
						if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
						{
							return -1;
						}
						num7 = chrome_0.method_61();
						if (num7 != 1)
						{
							break;
						}
						if (flag)
						{
							chrome_0.method_60();
							break;
						}
						flag = true;
						chrome_0.method_53();
						chrome_0.method_49();
					}
				}
				bool flag2 = false;
				if (num7 == 1)
				{
					flag2 = chrome_0.method_108();
				}
				else if (chrome_0.D7A424AE("[name=\"confirm\"]", 10.0))
				{
					chrome_0.method_45(2, 3);
					chrome_0.method_18("[name=\"confirm\"]");
					flag2 = true;
				}
				if (flag2)
				{
					num2++;
					method_130(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2}/{num3})...");
					if (num2 >= num3)
					{
						break;
					}
					method_131(B53CC00B, BD1EE5B8 + Language.GetValue("Đang") + $" {DDA80588} ({num2}/{num3}), đợi {{time}}s...", int_2, int_3);
				}
			}
		}
		catch
		{
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num2;
	}

	public int method_85(int int_3, string string_1, Chrome chrome_0, int FE07519E, int int_4, int int_5, int int_6, string string_2 = "")
	{
		int num = chrome_0.method_50(FE07519E, int_4);
		int num2 = 0;
		if (num == 0)
		{
			return num2;
		}
		try
		{
			return FacebookFriendAutomationHelper.CancelPendingSentRequests(this, int_3, string_1, chrome_0, num, int_5, int_6);
		}
		catch
		{
		}
		return num2;
	}

	public int method_86(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string FC80373A = "")
	{
		int int_4 = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int minValue = gclass4_0.method_2("nudDelayFrom");
		int num = gclass4_0.method_2("nudDelayTo");
		List<string> list = gclass4_0.method_1("txtUid");
		int num2 = gclass4_0.method_2("typeInvite");
		int num3 = 0;
		bool flag = false;
		try
		{
			List<string> list_ = new List<string>();
			if (num2 == 0)
			{
				list_ = chrome_0.method_119();
			}
			int num4 = 0;
			while (num4 < list.Count)
			{
				method_130(int_3, string_1 + Language.GetValue("Đang") + $" {FC80373A} ({num4 + 1}/{list.Count})...");
				int num5 = chrome_0.method_50(int_4, f4960BA);
				if (num5 <= 0) num5 = 10;

				string groupUrl = chrome_0.GetLinkFromId(list[num4], "https://www.facebook.com/groups");
				chrome_0.method_12(groupUrl, FC3A841F: true);
				chrome_0.F8091028(3.0);
				int num6 = chrome_0.method_125();
				if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
				{
					return -1;
				}

				if (!flag)
				{
					flag = true;
					chrome_0.method_53();
					chrome_0.method_60();
				}

				string namesStr = (list_ != null && list_.Count > 0) ? string.Join("\n", list_) : "";
				string paramJson = $"[{{\"name\":\"count\", \"value\":\"{num5}\", \"type\":\"number\"}}," +
								   $"{{\"name\":\"typeInvite\", \"value\":\"{num2}\", \"type\":\"number\"}}," +
								   $"{{\"name\":\"arrNames\", \"value\":\"{namesStr.Replace("\"", "\\\"")}\", \"type\":\"text\"}}]";

				string resultJson = FacebookGroupFriendHub.Execute(chrome_0, "MoiBanBeVaoNhom", paramJson);
				bool success = false;
				try
				{
					JObject jObj = JObject.Parse(resultJson);
					success = Convert.ToBoolean(jObj["success"]);
					if (!success && jObj["error"]?.ToString() == "fb_blocked")
					{
						chrome_0.EE37E6A7 = true;
						break;
					}
				}
				catch { }

				if (success)
				{
					num3 += num5;
				}

				chrome_0.F8091028(Base.rd.Next(minValue, num + 1));
				num4++;
			}
		}
		catch
		{
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num3;
	}

	public int method_87(int int_3, string string_1, Chrome chrome_0, int int_4, int int_5, int int_6, int F0BD7C3B, List<string> list_5, string CB93BC97 = "")
	{
		int num = 0;
		int num2 = chrome_0.method_50(int_4, int_5);
		int num3 = 0;
		string text = "";
		List<string> list = C499BE3B(list_5);
		try
		{
			while (true)
			{
				IL_0295:
				if (CommonChrome.smethod_4(chrome_0) != -2)
				{
					int num4 = chrome_0.method_125();
					if (num4 == 1)
					{
						continue;
					}
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
					{
						int num5 = 0;
						while (true)
						{
							if (num5 < 5 && chrome_0.D7A424AE("#see_older_threads", 3.0))
							{
								num3 = Convert.ToInt32(chrome_0.method_14("return document.querySelectorAll('#threadlist_rows a').length").ToString()) - 1;
								if (num3 >= num2)
								{
									break;
								}
								chrome_0.method_18("#see_older_threads");
								chrome_0.method_45(2, 3);
								num5++;
								continue;
							}
							num3 = Convert.ToInt32(chrome_0.method_14("return document.querySelectorAll('#threadlist_rows a').length").ToString());
							if (num3 != 0)
							{
								break;
							}
							return num;
						}
						int num6 = 0;
						while (num6 < num3 && num < num2)
						{
							num4 = chrome_0.method_125();
							if (num4 != 1)
							{
								if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
								{
									chrome_0.method_18("#threadlist_rows a|" + num6);
									chrome_0.method_45(2, 3);
									if (chrome_0.D7A424AE("[data-sigil=\"m-textarea-input photo-textarea\"]", 10.0))
									{
										if (list.Count == 0)
										{
											list = C499BE3B(list_5);
										}
										text = list[Base.rd.Next(0, list.Count)];
										list.Remove(text);
										text = Commom.smethod_31(text);
										string newValue = chrome_0.method_14("return document.title.split('-')[0]").ToString();
										text = text.Replace("[u]", newValue);
										chrome_0.method_22("[data-sigil=\"m-textarea-input photo-textarea\"]", text + " ");
										chrome_0.method_45(2, 3);
										if (chrome_0.D7A424AE("[name=\"Send\"],[name=\"send\"]", 5.0))
										{
											chrome_0.method_18("[name=\"Send\"],[name=\"send\"]");
										}
										if (!chrome_0.D7A424AE("[data-sigil=\"context-layer-root content-pane\"]>div>span>div", 5.0))
										{
											num++;
										}
										method_130(int_3, string_1 + Language.GetValue("Đang") + $" {CB93BC97} ({num}/{num2})...");
										chrome_0.F8091028(Base.rd.Next(int_6, F0BD7C3B + 1));
										if (CommonChrome.smethod_4(chrome_0) == -2)
										{
											return -2;
										}
									}
									num6++;
									continue;
								}
								return -1;
							}
							goto IL_0295;
						}
						break;
					}
					return -1;
				}
				return -2;
			}
		}
		catch
		{
		}
		return num;
	}

	public int BEAC0B29(int CFAD1B05, string D39A8225, Chrome chrome_0, GClass4 F804943F, string ACA2BEBF = "")
	{
		return PersonalInteractionHelper.WatchVideo(this, CFAD1B05, D39A8225, chrome_0, F804943F, ACA2BEBF);
	}

	public int method_88(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string D41E6F97 = "")
	{
		return PersonalInteractionHelper.ReadNotifications(this, int_3, string_1, chrome_0, gclass4_0, D41E6F97);
	}

	public int EDA9DC8F(int CD133F8C, string string_1, Chrome chrome_0, GClass4 B89E3F9D, string string_2 = "")
	{
		chrome_0.method_53(B89E3F9D.method_2("nudWidthChrome", 500), B89E3F9D.method_2("nudHeighChrome", 700));
		try
		{
			string string_3 = B89E3F9D.BDB80B23("cbbScripts");
			int int_ = B89E3F9D.method_2("nudScriptTimeout");
			B89E3F9D.method_5("cbbScripts");
			B89E3F9D.method_5("nudScriptTimeout");
			chrome_0.method_151(string_3, B89E3F9D.ED11179C(), int_);
		}
		catch (Exception)
		{
		}
		chrome_0.method_54();
		return 1;
	}

	public int A51D2294(int int_3, string string_1, Chrome C3A67081, GClass4 AD3C1D98, string string_2 = "")
	{
		return PersonalInteractionHelper.WatchStory(this, int_3, string_1, C3A67081, AD3C1D98, string_2);
	}

	private int EE18B014(int B13032AE, string string_1, Chrome C52B61BA, GClass4 gclass4_0, string string_2)
	{
		return PersonalInteractionHelper.WatchStoryChiDinh(this, B13032AE, string_1, C52B61BA, gclass4_0, string_2);
	}

	private int method_89(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2)
	{
		int result = 0;
		try
		{
			string string_3 = gclass4_0.BDB80B23("txtPathAnh");
			List<string> list = Commom.smethod_76(string_3);
			if (list == null || list.Count == 0)
			{
				return 0;
			}
			string text = list[int_3 % list.Count];
			if (!File.Exists(text))
			{
				text = list.OrderBy((string s) => Guid.NewGuid()).FirstOrDefault();
			}
			if (string.IsNullOrEmpty(text) || !File.Exists(text))
			{
				return 0;
			}

			string paramJson = new Newtonsoft.Json.Linq.JObject(new Newtonsoft.Json.Linq.JProperty("imagePath", text)).ToString();
			string res = AccountsCenterHub.ExecuteDangStoryWWW(chrome_0, paramJson);
			if (AccountsCenterHub.IsSuccess(res))
			{
				result = 1;
				string text2 = F6061E95(int_3, "cUid");
				string text3 = F6061E95(int_3, "cEmail");
				File.AppendAllText("LinkStory.txt", text2 + "|" + text3 + "|success\r\n");
			}
		}
		catch
		{
		}
		return result;
	}

	public int D7BE8001(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2)
	{
		int minValue = gclass4_0.method_2("nudSoLuongFrom");
		int num = gclass4_0.method_2("nudSoLuongTo");
		int int_4 = gclass4_0.method_2("nudDelayFrom");
		int int_5 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbChiKetBanTenCoDau");
		bool flag2 = gclass4_0.method_3("ckbOnlyAddFriendWithMutualFriends");
		int num2 = gclass4_0.method_2("nudTimesWarning", 5);
		int num4 = 0;
		bool flag3 = false;
		try
		{
			int num5 = Base.rd.Next(minValue, num + 1);
			if (num5 <= 0)
			{
				return 0;
			}
			chrome_0.method_12("https://www.facebook.com/friends/requests", FC3A841F: true);
			chrome_0.F8091028(3.0);
			int num6 = chrome_0.method_125();
			if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
			{
				return -1;
			}
			flag3 = true;
			chrome_0.method_53();
			chrome_0.method_60();

			string text = string_1 + Language.GetValue("Đang") + " " + string_2 + " ";
			method_130(int_3, text + $"({num4 + 1}/{num5})...");

			int tickCount = Environment.TickCount;
			int maxTimeoutSec = 180;
			int consecutiveScrolls = 0;
			int warningCount = 0;

			while (num4 < num5 && Environment.TickCount - tickCount <= maxTimeoutSec * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				string jsClick = @"(() => {
					try {
						var cards = document.querySelectorAll('div[data-visualcompletion=""ignore-dynamic""], div[role=""listitem""], div[role=""article""], div[data-pagelet*=""Requests""] > div, div[data-pagelet*=""Friends""] > div');
						for (var i = 0; i < cards.length; i++) {
							var card = cards[i];
							if (card.getAttribute('data-kc-confirm-done') === '1') continue;

							var btn = card.querySelector('div[aria-label=""Xác nhận"" i], div[aria-label=""Confirm"" i], [role=""button""][aria-label*=""Xác nhận"" i], [role=""button""][aria-label*=""Confirm"" i], button[aria-label*=""Xác nhận"" i], button[aria-label*=""Confirm"" i]');
							if (!btn) {
								var allBtns = card.querySelectorAll('[role=""button""], button');
								for (var j = 0; j < allBtns.length; j++) {
									var t = (allBtns[j].innerText || '').trim().toLowerCase();
									if (t === 'xác nhận' || t === 'confirm') {
										btn = allBtns[j];
										break;
									}
								}
							}
							if (!btn) continue;

							var name = '';
							var nameEl = card.querySelector('a[role=""link""] span, h2, h3, span[dir=""auto""], strong');
							if (nameEl) name = (nameEl.innerText || '').trim();

							var mutual = card.innerText || '';

							card.setAttribute('data-kc-confirm-done', '1');
							btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
							btn.click();
							return JSON.stringify({ clicked: true, name: name, mutual: mutual });
						}

						var freeBtns = document.querySelectorAll('div[aria-label=""Xác nhận"" i], div[aria-label=""Confirm"" i], [role=""button""][aria-label*=""Xác nhận"" i], [role=""button""][aria-label*=""Confirm"" i], button[aria-label*=""Xác nhận"" i], button[aria-label*=""Confirm"" i]');
						for (var k = 0; k < freeBtns.length; k++) {
							var fb = freeBtns[k];
							if (fb.getAttribute('data-kc-confirm-done') === '1') continue;
							var rect = fb.getBoundingClientRect();
							if (rect.width > 0 && rect.height > 0) {
								fb.setAttribute('data-kc-confirm-done', '1');
								fb.scrollIntoView({ behavior: 'smooth', block: 'center' });
								fb.click();
								return JSON.stringify({ clicked: true, name: '', mutual: '' });
							}
						}

						return JSON.stringify({ clicked: false });
					} catch (e) {
						return JSON.stringify({ clicked: false, error: e.message });
					}
				})()";

				string resJson = chrome_0.method_14("return " + jsClick + ";");
				bool clicked = false;
				string cardName = "";
				string cardMutual = "";

				if (!string.IsNullOrEmpty(resJson))
				{
					try
					{
						JObject jRes = JObject.Parse(resJson);
						clicked = jRes["clicked"]?.ToObject<bool>() ?? false;
						cardName = jRes["name"]?.ToString() ?? "";
						cardMutual = jRes["mutual"]?.ToString() ?? "";
					}
					catch { }
				}

				if (clicked)
				{
					consecutiveScrolls = 0;
					chrome_0.F8091028(1.0);

					if (flag && !string.IsNullOrEmpty(cardName) && !Commom.D9AB3B82(cardName))
					{
						continue;
					}

					if (flag2 && !string.IsNullOrEmpty(cardMutual) && !Regex.IsMatch(cardMutual, "\\d+\\s*(bạn chung|mutual)"))
					{
						continue;
					}

					if (chrome_0.method_118())
					{
						warningCount++;
						if (warningCount >= num2)
						{
							break;
						}
					}
					else
					{
						num4++;
						method_131(int_3, text + $"({num4}/{num5}), delay {{time}}s...", int_4, int_5);
						if (num4 >= num5)
						{
							break;
						}
						method_130(int_3, text + $"({num4 + 1}/{num5})...");
						tickCount = Environment.TickCount;
					}
				}
				else
				{
					consecutiveScrolls++;
					if (consecutiveScrolls >= 6)
					{
						break;
					}
					chrome_0.method_14("window.scrollBy(0, 800);");
					chrome_0.F8091028(2.0);
				}
			}
		}
		catch
		{
			num4 = -1;
		}
		if (flag3)
		{
			chrome_0.method_54();
		}
		return num4;
	}

	public int method_90(int AD19D686, string CB8D298E, Chrome chrome_0, GClass4 gclass4_0, string D0A85995 = "")
	{
		List<string> c8199D0D = gclass4_0.method_1("txtTuKhoa");
		int int_ = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int int_2 = gclass4_0.method_2("nudDelayFrom");
		int int_3 = gclass4_0.method_2("nudDelayTo");
		int num = 0;
		bool flag = false;
		int num2 = 5;
		int warningCount = 0;
		try
		{
			string string_ = c8199D0D.smethod_8();
			string_ = Commom.smethod_31(string_);
			int num3 = chrome_0.method_50(int_, f4960BA);
			if (num3 <= 0)
			{
				return 0;
			}
			chrome_0.method_12("https://www.facebook.com/search/people/?q=" + Uri.EscapeDataString(string_), FC3A841F: true);
			chrome_0.F8091028(3.0);
			int num4 = chrome_0.method_125();
			if (new List<int> { -3, -2, -1, 2 }.Contains(num4))
			{
				return -1;
			}
			flag = true;
			chrome_0.method_53();
			chrome_0.method_60();

			method_130(AD19D686, CB8D298E + Language.GetValue("Đang") + $" {D0A85995} ({num + 1}/{num3})...");
			int tickCount = Environment.TickCount;
			int maxTimeoutSec = 180;
			int consecutiveScrolls = 0;

			while (num < num3 && Environment.TickCount - tickCount <= maxTimeoutSec * 1000 && !chrome_0.CD930D04() && !chrome_0.E184CD03() && !Base.smethod_5())
			{
				string jsClick = @"(() => {
					try {
						var btns = document.querySelectorAll('div[aria-label=""Add friend"" i], div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], [role=""button""][aria-label*=""Thêm bạn"" i], button[aria-label*=""Add friend"" i], button[aria-label*=""Thêm bạn"" i]');
						for (var i = 0; i < btns.length; i++) {
							var b = btns[i];
							if (b.getAttribute('data-kc-done') === '1') continue;
							var rect = b.getBoundingClientRect();
							if (rect.width > 0 && rect.height > 0) {
								b.setAttribute('data-kc-done', '1');
								b.scrollIntoView({ behavior: 'smooth', block: 'center' });
								b.click();
								return 'clicked';
							}
						}

						var allBtns = document.querySelectorAll('[role=""button""], button');
						for (var j = 0; j < allBtns.length; j++) {
							var el = allBtns[j];
							if (el.getAttribute('data-kc-done') === '1') continue;
							var t = (el.innerText || '').trim().toLowerCase();
							if (t === 'thêm bạn bè' || t === 'thêm bạn' || t === 'add friend') {
								el.setAttribute('data-kc-done', '1');
								el.scrollIntoView({ behavior: 'smooth', block: 'center' });
								el.click();
								return 'clicked';
							}
						}

						return 'not_found';
					} catch (e) {
						return 'error: ' + e.message;
					}
				})()";

				string clickRes = chrome_0.method_14("return " + jsClick + ";");
				if (clickRes == "clicked")
				{
					consecutiveScrolls = 0;
					chrome_0.F8091028(1.0);

					if (chrome_0.method_118())
					{
						warningCount++;
						if (warningCount >= num2)
						{
							break;
						}
					}
					else
					{
						num++;
						method_131(AD19D686, CB8D298E + Language.GetValue("Đang") + $" {D0A85995} ({num}/{num3}), delay {{time}}s...", int_2, int_3);
						if (num >= num3)
						{
							break;
						}
						method_130(AD19D686, CB8D298E + Language.GetValue("Đang") + $" {D0A85995} ({num + 1}/{num3})...");
						tickCount = Environment.TickCount;
					}
				}
				else
				{
					consecutiveScrolls++;
					if (consecutiveScrolls >= 6)
					{
						break;
					}
					chrome_0.method_14("window.scrollBy(0, 800);");
					chrome_0.F8091028(2.0);
				}
			}
		}
		catch
		{
			num = -1;
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num;
	}

	public int F098622C(int EA35FABE, string string_1, Chrome chrome_0, GClass4 C4AC9023, string D72A9A3A)
	{
		int int_ = C4AC9023.method_2("nudSoLuongFrom");
		int f4960BA = C4AC9023.method_2("nudSoLuongTo");
		int int_2 = C4AC9023.method_2("nudDelayFrom");
		int int_3 = C4AC9023.method_2("nudDelayTo");
		int num = C4AC9023.method_2("nudTimesWarning", 5);
		bool flag = C4AC9023.method_3("ckbChiKetBanTenCoDau");
		bool flag2 = C4AC9023.method_3("ckbOnlyAddFriendWithMutualFriends");
		int num2 = 0;
		bool flag3 = false;
		try
		{
			int num3 = chrome_0.method_50(int_, f4960BA);
			if (num3 <= 0)
			{
				return 0;
			}
			chrome_0.method_12("https://www.facebook.com/friends/suggestions", FC3A841F: true);
			chrome_0.F8091028(3.0);
			int num4 = chrome_0.method_125();
			if (new List<int> { -3, -2, -1, 2 }.Contains(num4))
			{
				return -1;
			}
			flag3 = true;
			chrome_0.method_53();
			chrome_0.method_60();

			method_130(EA35FABE, string_1 + Language.GetValue("Đang") + $" {D72A9A3A} ({num2 + 1}/{num3})...");
			int tickCount = Environment.TickCount;
			int maxTimeoutSec = 180;
			int consecutiveScrolls = 0;
			int warningCount = 0;

			while (num2 < num3 && Environment.TickCount - tickCount <= maxTimeoutSec * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				string jsClick = @"(() => {
					try {
						var cards = document.querySelectorAll('div[data-visualcompletion=""ignore-dynamic""], div[role=""listitem""], div[role=""article""], div[data-pagelet*=""Suggestions""] > div, div[data-pagelet*=""Friends""] > div');
						for (var i = 0; i < cards.length; i++) {
							var card = cards[i];
							if (card.getAttribute('data-kc-done') === '1') continue;

							var btn = card.querySelector('div[aria-label=""Thêm bạn bè""], div[aria-label=""Thêm bạn""], div[aria-label=""Add friend"" i], div[aria-label=""Add Friend"" i], [role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], button[aria-label*=""Thêm bạn"" i], button[aria-label*=""Add friend"" i]');
							if (!btn) {
								var allBtns = card.querySelectorAll('[role=""button""], button');
								for (var j = 0; j < allBtns.length; j++) {
									var t = (allBtns[j].innerText || '').trim().toLowerCase();
									if (t === 'thêm bạn bè' || t === 'thêm bạn' || t === 'add friend') {
										btn = allBtns[j];
										break;
									}
								}
							}
							if (!btn) continue;

							var name = '';
							var nameEl = card.querySelector('a[role=""link""] span, h2, h3, span[dir=""auto""], strong');
							if (nameEl) name = (nameEl.innerText || '').trim();

							var mutual = card.innerText || '';

							card.setAttribute('data-kc-done', '1');
							btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
							btn.click();
							return JSON.stringify({ clicked: true, name: name, mutual: mutual });
						}

						var freeBtns = document.querySelectorAll('div[aria-label=""Thêm bạn bè""], div[aria-label=""Thêm bạn""], div[aria-label=""Add friend"" i], div[aria-label=""Add Friend"" i], [role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i]');
						for (var k = 0; k < freeBtns.length; k++) {
							var fb = freeBtns[k];
							if (fb.getAttribute('data-kc-done') === '1') continue;
							var rect = fb.getBoundingClientRect();
							if (rect.width > 0 && rect.height > 0) {
								fb.setAttribute('data-kc-done', '1');
								fb.scrollIntoView({ behavior: 'smooth', block: 'center' });
								fb.click();
								return JSON.stringify({ clicked: true, name: '', mutual: '' });
							}
						}

						return JSON.stringify({ clicked: false });
					} catch (e) {
						return JSON.stringify({ clicked: false, error: e.message });
					}
				})()";

				string resJson = chrome_0.method_14("return " + jsClick + ";");
				bool clicked = false;
				string cardName = "";
				string cardMutual = "";

				if (!string.IsNullOrEmpty(resJson))
				{
					try
					{
						JObject jRes = JObject.Parse(resJson);
						clicked = jRes["clicked"]?.ToObject<bool>() ?? false;
						cardName = jRes["name"]?.ToString() ?? "";
						cardMutual = jRes["mutual"]?.ToString() ?? "";
					}
					catch { }
				}

				if (clicked)
				{
					consecutiveScrolls = 0;
					chrome_0.F8091028(1.0);

					if (flag && !string.IsNullOrEmpty(cardName) && !Commom.D9AB3B82(cardName))
					{
						continue;
					}

					if (flag2 && !string.IsNullOrEmpty(cardMutual) && !Regex.IsMatch(cardMutual, "\\d+\\s*(bạn chung|mutual)"))
					{
						continue;
					}

					if (chrome_0.method_118())
					{
						warningCount++;
						if (warningCount >= num)
						{
							break;
						}
					}
					else
					{
						num2++;
						method_131(EA35FABE, string_1 + $"({num2}/{num3}), delay {{time}}s...", int_2, int_3);
						if (num2 >= num3)
						{
							break;
						}
						method_130(EA35FABE, string_1 + $"({num2 + 1}/{num3})...");
						tickCount = Environment.TickCount;
					}
				}
				else
				{
					consecutiveScrolls++;
					if (consecutiveScrolls >= 6)
					{
						break;
					}
					chrome_0.method_14("window.scrollBy(0, 800);");
					chrome_0.F8091028(2.0);
				}
			}
		}
		catch
		{
			num2 = -1;
		}
		if (flag3)
		{
			chrome_0.method_54();
		}
		return num2;
	}

	public List<string> C499BE3B(List<string> list_5)
	{
		return list_5.ToList();
	}

	private void B904D982(string BD9C222E)
	{
		plTrangThai.Invoke((MethodInvoker)delegate
		{
			if (!plTrangThai.Visible)
			{
				plTrangThai.Visible = true;
			}
		});
		lblTrangThai.Invoke((MethodInvoker)delegate
		{
			lblTrangThai.Text = BD9C222E;
		});
	}

	private void F529F8AC()
	{
		plTrangThai.Invoke((MethodInvoker)delegate
		{
			if (plTrangThai.Visible)
			{
				plTrangThai.Visible = false;
			}
		});
	}

	public int method_91(int int_3, string FF334E97, Chrome chrome_0, GClass4 gclass4_0, string string_1, string string_2)
	{
		int int_4 = gclass4_0.method_2("nudSoLuongFrom", 1);
		int f4960BA = gclass4_0.method_2("nudSoLuongTo", 1);
		int int_5 = gclass4_0.method_2("nudKhoangCachFrom");
		int int_6 = gclass4_0.method_2("nudKhoangCachTo");
		bool flag = gclass4_0.method_3("ckbVanBan");
		bool flag2 = gclass4_0.method_3("ckbUseBackground");
		bool flag3 = gclass4_0.method_3("ckbAnh");
		string string_3 = gclass4_0.BDB80B23("txtPathAnh");
		int minValue = gclass4_0.method_2("nudSoLuongAnhFrom");
		int num = gclass4_0.method_2("nudSoLuongAnhTo");
		bool flag4 = gclass4_0.method_3("ckbVideo");
		bool flag5 = gclass4_0.method_3("ckbTag");
		int num2 = gclass4_0.method_2("typeUidTag");
		List<string> list = gclass4_0.method_1("txtUidTag");
		int minValue2 = gclass4_0.method_2("nudUidFrom");
		int num3 = gclass4_0.method_2("nudUidTo");
		gclass4_0.method_3("ckbUuTienMbasic");
		int num4 = 0;
		try
		{
			int num5 = chrome_0.method_50(int_4, f4960BA);
			while (num4 < num5)
			{
				method_130(int_3, FF334E97 + Language.GetValue("Đang") + $" {string_1} ({num4}/{num5})...");
				try
				{
					if (chrome_0.CD930D04())
					{
						return -2;
					}
					if (flag5 && num2 == 0)
					{
						list = chrome_0.method_57();
					}
					string text = "";
					lock (dictionary_7)
					{
						if (dictionary_7[string_2].Count == 0)
						{
							dictionary_7[string_2] = C499BE3B(A83F1A36[string_2]);
						}
						text = dictionary_7[string_2][Base.rd.Next(0, dictionary_7[string_2].Count)];
						dictionary_7[string_2].Remove(text);
					}
					text = Commom.smethod_31(text);
					if (flag5)
					{
						string text2 = "";
						int num8 = Base.rd.Next(minValue2, num3 + 1);
						for (int i = 0; i < num8; i++)
						{
							if (list.Count == 0)
							{
								break;
							}
							text2 = list[Base.rd.Next(0, list.Count)];
							list.Remove(text2);
							text = text + " @[" + text2 + ":]";
						}
					}
					List<string> list2 = new List<string>();
					List<string> list3 = Commom.smethod_76(string_3);
					int num9 = Base.rd.Next(minValue, num + 1);
					for (int j = 0; j < num9; j++)
					{
						if (list3.Count == 0)
						{
							break;
						}
						string item = list3.smethod_8();
						list2.Add(item);
						list3.Remove(item);
					}
					method_130(int_3, FF334E97 + Language.GetValue("Đang") + $" {string_1} ({num4 + 1}/{num5}): Đang đăng bài WWW...");
					string resWWW = chrome_0.ExecuteDangBaiWWW(0, "", text, flag2, list2);
					if (!string.IsNullOrEmpty(resWWW))
					{
						num4++;
						string statusSuccess = Language.GetValue("Đã đăng tường: ") + resWWW;
						method_130(int_3, FF334E97 + statusSuccess);
						try
						{
							string outputDir = Path.Combine(Commom.smethod_95(), "output");
							if (!Directory.Exists(outputDir))
							{
								Directory.CreateDirectory(outputDir);
							}
							string postWallFile = Path.Combine(outputDir, "postWall_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
							Commom.smethod_98(postWallFile, delegate
							{
								File.AppendAllText(postWallFile, chrome_0.B4208531 + "|" + resWWW + Environment.NewLine);
							});
						}
						catch { }
						if (num4 < num5)
						{
							method_131(int_3, FF334E97 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_1, num4, num5, Language.GetValue("đợi")), int_5, int_6);
							continue;
						}
						break;
					}
					else
					{
						break;
					}
				}
				catch
				{
					continue;
				}
			}
		}
		catch
		{
		}
		return num4;
	}

	public int B8B090B3(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string E105C011 = "")
	{
		return PersonalInteractionHelper.InteractNewsfeed(this, int_3, string_1, chrome_0, gclass4_0, E105C011);
	}

	public int method_92(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string DA1D4496 = "")
	{
		try
		{
			string text = "https://www.facebook.com/me";
			gclass4_0.method_4("link", text);
			return C1A9CA02(int_3, string_1, chrome_0, gclass4_0, DA1D4496);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public int CB1EB439(int D515ACB0, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2)
	{
		try
		{
			string text = "https://www.facebook.com/groups/feed/";
			gclass4_0.method_4("link", text);
			return C1A9CA02(D515ACB0, string_1, chrome_0, gclass4_0, string_2);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public int F7166A93(int int_3, string F931630D, Chrome chrome_0, GClass4 gclass4_0, string ECB4DF17)
	{
		try
		{
			List<string> list = gclass4_0.method_1("txtTuKhoa");
			if (list == null || list.Count == 0)
			{
				return 0;
			}
			string string_ = list[int_3 % list.Count];
			string text = "https://www.facebook.com/search/posts/?q=" + Commom.smethod_54(string_);
			if (gclass4_0.method_3("ckbPostAds"))
			{
				text = "https://www.facebook.com/search/top/?q=" + Commom.smethod_54(string_);
			}
			gclass4_0.method_4("link", text);
			return C1A9CA02(int_3, F931630D, chrome_0, gclass4_0, ECB4DF17);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private int C1A9CA02(int BD346F81, string string_1, Chrome chrome_0, GClass4 B02F271D, string string_2)
	{
		int num = 0;
		bool flag = false;
		try
		{
			string text = B02F271D.BDB80B23("link");
			int num2 = B02F271D.method_2("cbbOptionsPost");
			int num3 = Commom.BF833227(B02F271D.method_2("nudSoLuongFrom", 1), B02F271D.method_2("nudSoLuongTo", 1));
			int num4 = Commom.BF833227(B02F271D.method_2("nudThoiGianFrom", 30), B02F271D.method_2("nudThoiGianTo", 30));
			if (num2 == 1)
			{
				num3 = 10000;
			}
			int num5 = B02F271D.method_2("nudTimeFrom");
			int num6 = B02F271D.method_2("nudTimeTo");
			B02F271D.method_2("nudDelayFrom");
			B02F271D.method_2("nudDelayTo");
			bool flag2 = B02F271D.method_3("ckbInteract");
			int f5A84D = B02F271D.method_2("nudPercentLike", 100);
			string text2 = B02F271D.BDB80B23("typeReaction", "Like");
			bool flag3 = B02F271D.method_3("ckbComment");
			int f5A84D2 = B02F271D.method_2("nudPercentCommentText", 100);
			List<string> c8199D0D = B02F271D.method_1("txtComment", B02F271D.method_2("typeNganCach"));
			bool flag4 = B02F271D.method_3("ckbSendAnh");
			int f5A84D3 = B02F271D.method_2("nudPercentCommentImage", 100);
			string string_3 = B02F271D.BDB80B23("txtAnh");
			bool flag5 = B02F271D.method_3("ckbShareWall");
			int f5A84D4 = B02F271D.method_2("nudPercentShareWall", 100);
			int num7 = 10;
			bool flag6 = B02F271D.method_3("ckbDieuKien");
			List<string> list = B02F271D.method_1("txtTuKhoa");
			if (flag6)
			{
				list = list.Select((string string_0) => Commom.EB835717(string_0.ToLower())).ToList();
				num7 = B02F271D.method_2("nudLuotToiDa", 50);
			}
			bool flag7 = B02F271D.method_3("ckbFeedGroup");
			List<string> list2 = B02F271D.method_1("txtIdNhom");
			if (flag7)
			{
				list2 = list2.Select((string string_0) => string_0.Trim()).ToList();
				num7 = B02F271D.method_2("nudFeedGroupLuotToiDa", 50);
			}
			bool flag8 = B02F271D.method_3("ckbPostAds");
			bool flag9;
			if (flag9 = B02F271D.method_3("ckbFeedAds"))
			{
				num7 = B02F271D.method_2("nudFeedAdsLuotToiDa", 50);
			}
			bool flag10 = B02F271D.method_3("ckbClickXemThem");
			int f8079B = B02F271D.method_2("nudDelayXemThemFrom", 3);
			int f1ADBDB = B02F271D.method_2("nudDelayXemThemTo", 3);
			bool flag11 = B02F271D.method_3("ckbClickXemAnh");
			int f8079B2 = B02F271D.method_2("nudDelayXemAnhFrom", 3);
			int f1ADBDB2 = B02F271D.method_2("nudDelayXemAnhTo", 3);
			while (true)
			{
				if (text != "")
				{
					chrome_0.method_12(text);
					chrome_0.F8091028(2.0);
				}
				int num8 = chrome_0.method_125();
				if (num8 == 1)
				{
					continue;
				}
				if (new List<int> { -3, -2, -1, 2 }.Contains(num8))
				{
					break;
				}
				int num9 = chrome_0.method_61();
				if (num9 == 1)
				{
					if (!flag)
					{
						flag = true;
						chrome_0.method_53();
						if (chrome_0.method_49() == 1)
						{
							continue;
						}
					}
					chrome_0.method_60();
				}
						if (num9 == 2)
						{
						if (!flag)
						{
							flag = true;
							if (chrome_0.method_49() == 1)
							{
								continue;
							}
						}
						}
						if ((num2 == 0 && num3 == 0) || (num2 == 1 && num4 == 0))
						{
						break;
						}
						string text3 = "";
						for (int retryFeed = 0; retryFeed < 3; retryFeed++)
						{
						switch (num9)
						{
						case 1:
							text3 = ((!flag8) ? chrome_0.method_15(3.0, new List<string>
							{
								"//div[@role='feed']/div[contains(@data-pagelet, 'FeedUnit')]",
								"//div[@role='main']//div[contains(@data-pagelet, 'FeedUnit')]",
								"//div[@role='feed']//div[@role='article']",
								"//div[@role='article']",
								"//div[contains(@data-pagelet, 'FeedUnit')]",
								"//div[@role='feed']/div",
								"//div[@role='main']//video/ancestor::div[@role='article']",
								"//video/ancestor::div[contains(@class,'x1yztbdb')]"
							}) : "//*[@role=\"feed\"]//*[@role=\"article\"][.//span[@style=\"display: flex;\"]]");
							break;
						case 2:
						case 3:
						default:
							text3 = chrome_0.method_15(3.0, new List<string>
							{
								"//div[@role='feed']/div[contains(@data-pagelet, 'FeedUnit')]",
								"//div[@role='main']//div[contains(@data-pagelet, 'FeedUnit')]",
								"//div[@role='feed']//div[@role='article']",
								"//div[@role='article']"
							});
							break;
						}
						if (!string.IsNullOrEmpty(text3))
						{
							break;
						}
						HumanScroll.ScrollNewsfeed(chrome_0, Commom.BF833227(350, 650));
						}
						if (string.IsNullOrEmpty(text3))
						{
							text3 = (num9 == 1) ? "//div[@role='feed']/div[contains(@data-pagelet, 'FeedUnit')] | //div[@role='main']//div[contains(@data-pagelet, 'FeedUnit')] | //div[@role='feed']//div[@role='article'] | //div[@role='article']" : "//div[@role='article']";
						}
						List<string> list3 = new List<string>();
						int num10 = 0;
						int num11 = 10;
						int tickCount = Environment.TickCount;
						for (int i = 1; i <= num3 + num7 && !Base.smethod_5() && chrome_0.method_125() == 0; i++)
						{
						string text4 = $"({text3})[{i}]";
						if (num9 == 3 && text.Contains("/search/posts"))
						{
							text4 = "(" + text3 + ")[1]";
						}
						if (!chrome_0.D7A424AE(text4))
						{
							bool flag12 = false;
							for (int scrollRetry = 0; scrollRetry < 3; scrollRetry++)
							{
								HumanScroll.ScrollNewsfeed(chrome_0, Commom.BF833227(350, 650));
								if (chrome_0.D7A424AE(text4, 2.0))
								{
									flag12 = true;
									break;
								}
							}
							if (!flag12 && chrome_0.D7A424AE(text3))
							{
								text4 = $"({text3})[last()]";
								flag12 = true;
							}
							if (!flag12)
							{
								break;
							}
						}

						// Anti-lazy-load virtual placeholder protection (Comet 2026)
						try
						{
							string checkJs = "var el = " + chrome_0.A7B8E3A5(text4) + "; if (!el) return 'empty'; var h = el.clientHeight || el.offsetHeight || 0; var busy = el.getAttribute('aria-busy'); if (busy === 'true' || h < 60) return 'placeholder'; return 'ok';";
							string chk = chrome_0.method_14(checkJs);
							if (chk == "placeholder")
							{
								chrome_0.method_20(text4);
								chrome_0.F8091028(1.0);
							}
						}
						catch { }
					if (flag6)
					{
						if (chrome_0.int_3 == -1)
						{
							chrome_0.int_3 = 0;
						}
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num3}), Lướt bài viết...");
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}), Lướt bài viết...");
						}
						string text5 = text4 + "//h3//a";
						if (num9 == 1)
						{
							text5 = chrome_0.method_15(0.0, new List<string>
							{
								text4 + "//h4",
								text4 + "//a/span/span"
							});
						}
						chrome_0.method_20(text5, 2);
						string text6 = chrome_0.method_6(text5);
						text6 = Commom.EB835717(text6.ToLower());
						bool flag13 = true;
						foreach (string item in list)
						{
							if (text6.Contains(item))
							{
								flag13 = false;
								break;
							}
						}
						if (flag13)
						{
							if (num9 == 1 && i % 12 == 0)
							{
								chrome_0.method_13();
								num7 -= i;
								i = 0;
							}
							continue;
						}
						chrome_0.int_3++;
					}
					if (flag7)
					{
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num3}), Lướt bài viết...");
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}), Lướt bài viết...");
						}
						chrome_0.method_20(text4, 2);
						bool flag14 = true;
						string text7 = chrome_0.D3901939(text4);
						foreach (string item2 in list2)
						{
							if (text7.Contains("/groups/" + item2 + "/?hoisted_section_header_type=recently_seen") || text7.Contains("/groups/" + item2 + "/?__cft__[0]"))
							{
								flag14 = false;
								break;
							}
						}
						if (flag14)
						{
							if (num9 == 1 && i % 12 == 0)
							{
								chrome_0.method_13();
								num7 -= i;
								i = 0;
							}
							continue;
						}
					}
					if (flag9)
					{
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num3}), Lướt bài viết...");
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}), Lướt bài viết...");
						}
						bool flag15 = false;
						string text8 = text4 + "//a[contains(@attributionsrc,\"/privacy_sandbox/comet/register/source/\")][.//span/span/span]";
						if (chrome_0.D7A424AE(text8))
						{
							chrome_0.method_20(text8, 2);
							chrome_0.method_148(text8);
							flag15 = chrome_0.D7A424AE(text4 + "//a[contains(@href,\"/ads/about/\")]");
						}
						else
						{
							chrome_0.method_20(text4, 2);
							flag15 = chrome_0.D7A424AE(text4 + "//span[text()='Sponsored' or text()='Được tài trợ' or contains(text(), 'Sponsored') or contains(text(), 'Được tài trợ')]");
						}
						if (!flag15)
						{
							if (num9 == 1 && i % 12 == 0)
							{
								chrome_0.method_13();
								num7 -= i;
								i = 0;
							}
							continue;
						}
					}
					if (num9 == 3 && text.Contains("/search/posts"))
					{
						string text9 = chrome_0.method_14("let arrId = ''; document.querySelectorAll('#BrowseResultsContainer article [id^=\"like_\"]').forEach(e => arrId+=e.getAttribute('id').replace('like_','')+','); return arrId");
						List<string> first = text9.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
						text9 = first.Except(list3).FirstOrDefault();
						if (string.IsNullOrEmpty(text9))
						{
							if (chrome_0.method_18("#see_more_pager a"))
							{
								i--;
								continue;
							}
							break;
						}
						list3.Add(text9);
						chrome_0.method_19("//*[@id=\"like_" + text9 + "\"]/following-sibling::a[contains(@href,'#footer_action_list')]");
						chrome_0.F8091028(2.0);
					}
					chrome_0.method_20(text4);
					if (num5 > 0 && num6 > 0)
					{
						if (chrome_0.GetURL().Contains("facebook.com/watch"))
						{
							if (num9 == 2)
							{
								chrome_0.method_19(text4 + "//div[contains(@data-sigil,\"playInlineVideo\")]");
								chrome_0.F8091028(1.0);
							}
							chrome_0.B623741C(text4 + "//video");
							chrome_0.F8091028(1.0);
						}
						if (num2 == 0)
						{
							method_131(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_2, num + 1, num3, Language.GetValue("Xem bài viết")), num5, num6);
						}
						else
						{
							method_131(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}), {2} {{time}}s...", string_2, num + 1, Language.GetValue("Xem bài viết")), num5, num6);
						}
					}
					else if (flag2 || flag3 || flag4)
					{
						// Thời gian dừng xem bài viết tự nhiên (random 3-7s) trước khi like/cmt
						int naturalViewSec = Commom.BF833227(3, 7);
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_2, num + 1, num3, Language.GetValue("Xem bài viết")), naturalViewSec);
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}), {2} {{time}}s...", string_2, num + 1, Language.GetValue("Xem bài viết")), naturalViewSec);
						}
					}
					if (flag10)
					{
						string seeMoreSel = text4 + "//div[text()='See more' or text()='Xem thêm' or contains(text(), 'See more') or contains(text(), 'Xem thêm')]";
						if (chrome_0.D7A424AE(seeMoreSel))
						{
							chrome_0.method_19(seeMoreSel);
							chrome_0.method_45(f8079B, f1ADBDB);
						}
					}
					if (flag11)
					{
						string photoSel = text4 + "//*[contains(@href,'/photo/') or contains(@href,'/photo?') or contains(@href,'photo.php')]";
						if (chrome_0.D7A424AE(photoSel))
						{
							chrome_0.method_19(photoSel);
							chrome_0.method_45(f8079B2, f1ADBDB2);
							chrome_0.F7221F34();
						}
					}
					bool flag16 = true;
					if (flag2 && Commom.smethod_51(f5A84D))
					{
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3}...", string_2, num + 1, num3, Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c")));
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}), {2}...", string_2, num + 1, Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c")));
						}
						GClass4 gClass = new GClass4();
						string text10 = text2.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
						gClass.method_4("reaction", text10);
						gClass.method_4("postAds", flag8);
						if (!chrome_0.method_102(num9, gClass, (num9 == 3) ? 1 : i))
						{
							flag16 = false;
						}
						if (chrome_0.EE37E6A7)
						{
							break;
						}
					}
					if (flag3 || flag4)
					{
						bool flag17 = flag3 && Commom.smethod_51(f5A84D2);
						bool flag18 = flag4 && Commom.smethod_51(f5A84D3);
						if (flag17 || flag18)
						{
							if (num2 == 0)
							{
								method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num3}), Comment...");
							}
							else
							{
								method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}), Comment...");
							}
							GClass4 gClass2 = new GClass4();
							if (flag18)
							{
								List<string> c8199D0D2 = Commom.smethod_76(string_3);
								string text11 = c8199D0D2.smethod_8();
								gClass2.method_4("image", text11);
							}
							if (flag17)
							{
								string text12 = "";
								if (B02F271D.method_3("ckbTaoNoiDungAI"))
								{
									string seeMoreStory = text4 + "//*[@data-ad-rendering-role=\"story_message\"]//div[@role=\"button\" and (contains(translate(descendant::text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'see more') or contains(descendant::text(), 'Xem thêm'))]";
									if (chrome_0.D7A424AE(seeMoreStory))
									{
										chrome_0.method_18(seeMoreStory);
										chrome_0.method_33(seeMoreStory, 20);
									}
									string text13 = chrome_0.method_6(text4 + "//*[@data-ad-rendering-role=\"story_message\"]");
									if (string.IsNullOrEmpty(text13))
									{
										text13 = chrome_0.method_6(text4 + "//div[contains(@class, 'xdj266r')]");
									}
									if (string.IsNullOrEmpty(text13))
									{
										text13 = chrome_0.method_6(text4 + "//div[@dir='auto']");
									}
									if (string.IsNullOrEmpty(text13))
									{
										text13 = chrome_0.method_6(text4 + "//p");
									}
									if (!string.IsNullOrEmpty(text13))
									{
										text12 = Commom.smethod_93(B02F271D.BDB80B23("cbbPrompt"), text13, gClass2.BDB80B23("image"));
									}
								}
								else
								{
									text12 = c8199D0D.smethod_8();
								}
								gClass2.method_4("content", text12);
							}
							bool flag19 = B02F271D.method_3("ckbDeleteComment");
							int num12 = B02F271D.method_2("nudDelayDeleteFrom");
							int num13 = B02F271D.method_2("nudDelayDeleteTo");
							gClass2.method_4("ckbDeleteComment", flag19);
							gClass2.method_4("nudDelayDeleteFrom", num12);
							gClass2.method_4("nudDelayDeleteTo", num13);
							gClass2.method_4("postAds", flag8);
							chrome_0.DD052422(num9, gClass2, (num9 == 3) ? 1 : i);
							if (chrome_0.EE37E6A7)
							{
								break;
							}
						}
					}
					if (flag5 && Commom.smethod_51(f5A84D4))
					{
						if (num2 == 0)
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}/{num3}), Share wall...");
						}
						else
						{
							method_130(BD346F81, string_1 + Language.GetValue("Đang") + $" {string_2} ({num + 1}), Share wall...");
						}
						GClass4 gClass3 = new GClass4();
						gClass3.method_4("postAds", flag8);
						bool flag20 = chrome_0.AF0F44B1(num9, gClass3, (num9 == 3) ? 1 : i);
						if (chrome_0.EE37E6A7)
						{
							break;
						}
						if (flag20 && num9 == 1 && !chrome_0.GetURL().Contains("facebook.com/watch/"))
						{
							i++;
						}
					}
					if (!flag16)
					{
						num10++;
						if (num10 >= num11)
						{
							break;
						}
					}
					else
					{
						num10 = 0;
						num++;
						chrome_0.method_60();
						HumanScroll.ScrollNewsfeed(chrome_0, Commom.BF833227(350, 650));
						if (num >= num3)
						{
							break;
						}
					}
					if (num2 != 1 || Environment.TickCount - tickCount < num4 * 1000)
					{
						if (num9 == 3 && text.Contains("/search/posts"))
						{
							chrome_0.method_12(text);
							chrome_0.F8091028(2.0);
						}
						continue;
					}
					break;
				}
				break;
			}
		}
		catch
		{
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num;
	}

	private int EF99TangTuongTac(int rowIndex, string accInfo, Chrome chrome, GClass4 cfg, string taskName, string kichBanId)
	{
		string result = "Fail";
		try
		{
			string labelPrefix = accInfo + " " + Language.GetValue("Đang") + " " + taskName + ": ";
			method_130(rowIndex, labelPrefix + Language.GetValue("Đang chạy..."));

			bool ckbTuongTacPage = cfg.method_3("ckbTuongTacPage", true);
			List<string> listLinkPage = cfg.method_1("rtbLinkPage");
			bool ckbFollow = cfg.method_3("ckbFollow");
			List<string> listLinkFollow = cfg.method_1("rtbLinkFollow");
			List<string> listLinkPost = cfg.method_1("rtbLinkPost");
			bool ckbTuongTacNewfeed = cfg.method_3("ckbTuongTacNewfeed");
			string reactions = cfg.BDB80B23("typeReaction", "Like");
			bool ckbComment = cfg.method_3("ckbComment");
			List<string> listComment = cfg.method_1("rtbComment");
			bool ckbShare = cfg.method_3("ckbShare");
			bool rbShareWall = cfg.method_3("rbShareWall", true);
			bool ckbSendImg = cfg.method_3("ckbSendImg");
			string imgFolder = cfg.BDB80B23("txtImgFolder");
			int delayFrom = cfg.method_2("nudDelayFrom", 3);
			int delayTo = cfg.method_2("nudDelayTo", 6);
			int delayActFrom = cfg.method_2("nudDelayActionFrom", 1);
			int delayActTo = cfg.method_2("nudDelayActionTo", 2);
			bool uuTienMbasic = cfg.method_3("ckbUuTienMbasic");
			List<string> imgPaths = ckbSendImg ? Commom.smethod_76(imgFolder) : new List<string>();

			// Khối thực thi tương tác cho 1 ngữ cảnh (Profile cá nhân hoặc Page đang active)
			Action<string> executeInteractions = (contextTag) =>
			{
				// 1. Follow profiles/pages
				if (ckbFollow && listLinkFollow.Count > 0)
				{
					foreach (var link in listLinkFollow)
					{
						method_130(rowIndex, labelPrefix + $"[{contextTag}] Follow: " + link);
						TangTuongTacHub.FollowProfile(chrome, link, (msg) => method_130(rowIndex, labelPrefix + $"[{contextTag}] " + msg));
						int w = (delayTo > delayFrom && delayFrom > 0) ? new Random().Next(delayFrom, delayTo + 1) : delayFrom;
						chrome.F8091028(w);
					}
				}

				// 2. Tương tác bài viết chỉ định
				if (listLinkPost.Count > 0)
				{
					foreach (var postUrl in listLinkPost)
					{
						method_130(rowIndex, labelPrefix + $"[{contextTag}] Tương tác bài: " + postUrl);
						bool ok = TangTuongTacHub.TuongTacBaiViet(chrome, postUrl, reactions, ckbComment, listComment, ckbShare, rbShareWall, ckbSendImg, imgPaths, delayActFrom, delayActTo, (msg) => method_130(rowIndex, labelPrefix + $"[{contextTag}] " + msg));
						if (ok) result = "Success";
						int w = (delayTo > delayFrom && delayFrom > 0) ? new Random().Next(delayFrom, delayTo + 1) : delayFrom;
						chrome.F8091028(w);
					}
				}
				else if (ckbTuongTacNewfeed)
				{
					// Lướt newsfeed và tương tác
					method_130(rowIndex, labelPrefix + $"[{contextTag}] Tương tác Newsfeed...");
					TangTuongTacHub.TuongTacNewsfeed(chrome, reactions, ckbComment, listComment, ckbShare, rbShareWall, delayActFrom, delayActTo, (msg) => method_130(rowIndex, labelPrefix + $"[{contextTag}] " + msg));
					result = "Success";
				}
			};

			if (ckbTuongTacPage)
			{
				// Chế độ: Vào từng Page trong tài khoản để tương tác
				List<string> targetPages = new List<string>();
				if (listLinkPage != null && listLinkPage.Count > 0)
				{
					targetPages.AddRange(listLinkPage);
				}
				else
				{
					method_130(rowIndex, labelPrefix + "Lấy danh sách Page của tài khoản...");
					targetPages = TangTuongTacHub.GetAllPages(chrome, (msg) => method_130(rowIndex, labelPrefix + msg));
				}

				if (targetPages.Count == 0)
				{
					method_130(rowIndex, labelPrefix + "Không tìm thấy Page nào, tương tác bằng Profile chính...");
					executeInteractions("Profile");
				}
				else
				{
					method_130(rowIndex, labelPrefix + $"Bắt đầu tương tác qua {targetPages.Count} Page...");
					for (int pIdx = 0; pIdx < targetPages.Count; pIdx++)
					{
						string pageTarget = targetPages[pIdx].Trim();
						if (string.IsNullOrEmpty(pageTarget)) continue;

						method_130(rowIndex, labelPrefix + $"Chuyển sang Page {pIdx + 1}/{targetPages.Count} ({pageTarget})...");
						bool switched = TangTuongTacHub.SwitchToPage(chrome, pageTarget, (msg) => method_130(rowIndex, labelPrefix + msg));
						if (switched)
						{
							chrome.F8091028(2.0);
							executeInteractions($"Page: {pageTarget}");
						}
						else
						{
							method_130(rowIndex, labelPrefix + $"Không thể chuyển sang Page {pageTarget}, bỏ qua.");
						}

						int wPage = (delayTo > delayFrom && delayFrom > 0) ? new Random().Next(delayFrom, delayTo + 1) : delayFrom;
						chrome.F8091028(wPage);
					}

					// Quay trở về Profile cá nhân gốc
					TangTuongTacHub.SwitchToPersonalProfile(chrome, (msg) => method_130(rowIndex, labelPrefix + msg));
				}
			}
			else
			{
				// Chế độ: Tương tác bằng Profile cá nhân
				executeInteractions("Profile");
			}

			if (result != "Success") result = "Fail";
		}
		catch (Exception ex)
		{
			result = "Fail (" + ex.Message + ")";
		}

		return result == "Success" ? 1 : 0;
	}

	public int method_93(ref int int_3, ref int int_4, int int_5, string string_1, Chrome A7309AA1, GClass4 gclass4_0, string E5AC0C34, string B02EC714)
	{
		int int_6 = gclass4_0.method_2("nudTimeFrom");
		int int_7 = gclass4_0.method_2("nudTimeTo");
		int int_8 = gclass4_0.method_2("nudDelayFrom");
		int int_9 = gclass4_0.method_2("nudDelayTo");
		int num = gclass4_0.method_2("nudSoLuongUidFrom");
		int num2 = gclass4_0.method_2("nudSoLuongUidTo");
		bool flag = gclass4_0.method_3("ckbTuDongXoa");
		bool flag3 = gclass4_0.method_3("ckbInteract");
		string text = gclass4_0.BDB80B23("typeReaction", "Like");
		bool flag4 = gclass4_0.method_3("ckbComment");
		bool flag5 = gclass4_0.method_3("ckbTaoNoiDungAI");
		string f7A7DE = gclass4_0.BDB80B23("cbbPrompt");
		bool flag6 = gclass4_0.method_3("ckbAutoDeleteComment");
		bool flag7 = gclass4_0.method_3("ckbTag");
		int num3 = gclass4_0.method_2("nudSoLuongTagFrom");
		int num4 = gclass4_0.method_2("nudSoLuongTagTo");
		int num5 = gclass4_0.method_2("typeComment");
		bool flag8 = gclass4_0.method_3("ckbSendAnh");
		string string_2 = gclass4_0.BDB80B23("txtAnh");
		gclass4_0.method_3("ckbSendVideo");
		gclass4_0.BDB80B23("txtVideo");
		List<string> list = gclass4_0.method_1("txtIdPost");
		bool flag9 = gclass4_0.method_3("ckbRunAPI");
		bool flag10 = gclass4_0.method_3("ckbChiTagTenViet");
		bool flag11 = gclass4_0.method_3("ckbShareWall");
		bool flag12 = gclass4_0.method_3("ckbAutoDeleteContentShare");
		bool flag13 = gclass4_0.method_3("ckbShareMess");
		int num6 = gclass4_0.method_2("nudSoLuongMessFrom");
		int num7 = gclass4_0.method_2("nudSoLuongMessTo");
		int num8 = gclass4_0.method_2("nudDelayMessFrom");
		int num9 = gclass4_0.method_2("nudDelayMessTo");
		bool flag14 = gclass4_0.method_3("ckbAutoDeleteContentShareMess");
		List<string> c8199D0D = gclass4_0.method_1("txtCommentEdit", gclass4_0.method_2("cbbTuyChonNoiDungEdit"));
		if (flag4)
		{
			int_3 = 0;
		}
		if (flag11)
		{
			int_4 = 0;
		}
		int num10 = 0;
		bool flag15 = false;
		try
		{
			if (Commom.smethod_45(text.Replace("|", "")))
			{
				List<string> list2 = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
				for (int i = 0; i < list2.Count; i++)
				{
					text = text.Replace(i.ToString(), list2[i]);
				}
			}
			List<string> list_ = new List<string>();
			List<string> list3 = new List<string>();
			if (flag8)
			{
				list_ = Commom.smethod_76(string_2);
				list3 = C499BE3B(list_);
			}
			List<string> list4 = new List<string>();
			if (flag7)
			{
				list4 = A7309AA1.method_57(flag10 ? 1 : 0);
			}
			List<string> list5 = new List<string>();
			string text2 = "";
			int num11 = Commom.BF833227(num, num2);
			if (list.Count < num11)
			{
				num11 = list.Count;
			}
			bool flag16;
			if (!(flag16 = list.Where((string string_0) => string_0.Contains("|")).Count() > 0))
			{
				list = GClass13.smethod_1(list);
				goto IL_0455;
			}
			lock (C03C6C3A)
			{
				if (!C03C6C3A.ContainsKey(B02EC714))
				{
					C03C6C3A.Add(B02EC714, new Dictionary<string, int>());
					for (int j = 0; j < list.Count; j++)
					{
						string[] array = list[j].Split('|');
						int value = 1;
						string key = list[j];
						if (array.Length > 1)
						{
							try
							{
								value = Convert.ToInt32(array[0]);
							}
							catch
							{
							}
							key = array[1];
						}
						C03C6C3A[B02EC714].Add(key, value);
					}
				}
			}
			if (C03C6C3A[B02EC714].Count != 0)
			{
				goto IL_0455;
			}
			goto end_IL_0228;
			IL_0455:
			for (int k = 0; k < num11; k++)
			{
				if (flag16)
				{
					lock (C03C6C3A[B02EC714])
					{
						text2 = "";
						foreach (KeyValuePair<string, int> item3 in C03C6C3A[B02EC714])
						{
							if (!list5.Contains(item3.Key) && item3.Value > 0)
							{
								text2 = item3.Key;
								C03C6C3A[B02EC714][text2]--;
								break;
							}
						}
						if (string.IsNullOrEmpty(text2))
						{
							break;
						}
						list5.Add(text2);
						goto IL_147b;
					}
				}
				if (flag)
				{
					lock (dictionary_10)
					{
						if (dictionary_10[B02EC714].Count == 0)
						{
							break;
						}
						text2 = dictionary_10[B02EC714][Base.rd.Next(0, dictionary_10[B02EC714].Count)];
						dictionary_10[B02EC714].Remove(text2);
						goto IL_147b;
					}
				}
				text2 = list[k];
				goto IL_147b;
				IL_07d9:
				string newValue = CommonChrome.smethod_1(A7309AA1);
				string text3 = text3.Replace("[u]", newValue);
				if (!A7309AA1.method_105(text2, text3))
				{
					if (flag16)
					{
						lock (C03C6C3A[B02EC714])
						{
							C03C6C3A[B02EC714][text2]++;
						}
					}
					if (A7309AA1.F5812DA8 == "")
					{
						return 0;
					}
					if (A7309AA1.CD930D04())
					{
						return -2;
					}
					if (A7309AA1.D6BBEDA3())
					{
						return -4;
					}
					string text4 = A7309AA1.GetURL();
					if (text4.Contains("1501092823525282") || text4.Contains("828281030927956") || (text4.Contains("facebook.com/nt/screen/?params=") && text4.Contains("checkpoint")))
					{
						return 0;
					}
				}
				else
				{
					int_3++;
				}
				goto IL_08d8;
				IL_147b:
				if (flag9 && (flag3 || flag4 || flag11))
				{
					if (flag3)
					{
						method_130(int_5, string_1 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}): {3}...", E5AC0C34, num10 + 1, num11, Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c")));
						string text5 = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8()
							.ToLower();
						string text6 = Commom.smethod_85($"Reaction('{A7309AA1.method_40()}', '{A7309AA1.method_9()}', '{A7309AA1.A3A32284}', {A7309AA1.Int32_1}, '{text2}', '{text5.ToLower()}')");
						if (text6 == "fb_blocked")
						{
							return -4;
						}
					}
					if (flag4)
					{
						method_130(int_5, string_1 + Language.GetValue("Đang") + $" {E5AC0C34} ({num10 + 1}/{num11}): Comment...");
						text3 = "";
						lock (B2978823)
						{
							if (B2978823[B02EC714].Count != 0)
							{
								goto IL_0767;
							}
							if (flag6)
							{
								break;
							}
							B2978823[B02EC714] = C499BE3B(dictionary_2[B02EC714]);
							goto IL_0767;
							IL_0767:
							text3 = ((num5 != 0) ? B2978823[B02EC714][Base.rd.Next(0, B2978823[B02EC714].Count)] : B2978823[B02EC714][0]);
							B2978823[B02EC714].Remove(text3);
							goto IL_07d9;
						}
					}
					goto IL_08d8;
				}
				string text7 = $" {E5AC0C34} ({num10 + 1}/{num11}):";
				while (true)
				{
					string postUrl = A7309AA1.GetLinkFromId(text2, "https://www.facebook.com");
					A7309AA1.method_12(postUrl, FC3A841F: true);
					int num12 = A7309AA1.method_125();
					if (num12 == 1)
					{
						continue;
					}
					if (new List<int> { -3, -2, -1, 2 }.Contains(num12))
					{
						return -1;
					}
					bool flag17 = false;
					if (!flag15)
					{
						flag15 = true;
						A7309AA1.method_53();
						A7309AA1.method_60();
					}
					int num13 = 1;

					if (A7309AA1.D7A424AE("video") && !A7309AA1.GetURL().Contains("facebook.com/reel") && !A7309AA1.D7A424AE("[role=\"dialog\"]"))
					{
						flag17 = true;
						A7309AA1.method_20("video");
						A7309AA1.E11EB838("video");
						A7309AA1.F8091028(1.0);
					}
					method_131(int_5, string_1 + Language.GetValue("Đang") + text7 + " View post, delay {time}s...", int_6, int_7);
					if (flag17 && A7309AA1.D7A424AE("[aria-hidden=\"false\"][aria-label=\"Close\"]"))
					{
						A7309AA1.method_18("[aria-hidden=\"false\"][aria-label=\"Close\"]");
						A7309AA1.F8091028(2.0);
					}
					if (flag3)
					{
						method_130(int_5, string_1 + Language.GetValue("Đang") + text7 + " " + Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c") + "...");
						string text8 = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
						GClass4 gClass = new GClass4();
						gClass.method_4("reaction", text8);
						A7309AA1.method_102(num13, gClass, 1);
					}
					if (!(flag4 || flag8))
					{
						goto IL_118f;
					}
					string text9 = "";
					string text10 = "";
					GClass4 gClass2 = new GClass4();
					method_130(int_5, string_1 + Language.GetValue("Đang") + text7 + " Comment...");
					if (flag8)
					{
						if (list3.Count == 0)
						{
							list3 = C499BE3B(list_);
						}
						text10 = list3[Base.rd.Next(0, list3.Count)];
						list3.Remove(text10);
						gClass2.method_4("image", text10);
					}
					if (!flag4)
					{
						goto IL_100c;
					}
					if (flag5)
					{
						string text11 = "";
						try
						{
							string json = A7309AA1.method_101(A7309AA1.GetURL());
							JObject jObject = JObject.Parse(json);
							text11 = jObject["content"]!.ToString();
						}
						catch (Exception)
						{
						}
						if (text11 == "")
						{
							text11 = A7309AA1.method_126();
						}
						if (text11 != "")
						{
							text9 = Commom.smethod_93(f7A7DE, text11, "");
						}
						goto IL_0f84;
					}
					lock (B2978823)
					{
						if (B2978823[B02EC714].Count != 0)
						{
							goto IL_0f12;
						}
						if (!flag6)
						{
							B2978823[B02EC714] = C499BE3B(dictionary_2[B02EC714]);
							goto IL_0f12;
						}
						goto end_IL_0ec4;
						IL_0f12:
						text9 = ((num5 != 1) ? B2978823[B02EC714][0] : B2978823[B02EC714][Base.rd.Next(0, B2978823[B02EC714].Count)]);
						B2978823[B02EC714].Remove(text9);
						goto IL_0f84;
						end_IL_0ec4:;
					}
					goto end_IL_0228;
					IL_100c:
					gClass2.method_4("content", text9);
					gClass2.method_4("ckbDeleteComment", gclass4_0.method_3("ckbDeleteComment"));
					gClass2.method_4("nudDelayDeleteFrom", gclass4_0.method_2("nudDelayDeleteFrom"));
					gClass2.method_4("nudDelayDeleteTo", gclass4_0.method_2("nudDelayDeleteTo"));
					gClass2.method_4("ckbEditComment", gclass4_0.method_3("ckbEditComment"));
					gClass2.method_4("nudDelayEditFrom", gclass4_0.method_2("nudDelayEditFrom"));
					gClass2.method_4("nudDelayEditTo", gclass4_0.method_2("nudDelayEditTo"));
					gClass2.method_4("contentEdit", c8199D0D.smethod_8());
					if (A7309AA1.DD052422(num13, gClass2, 1))
					{
						int_3++;
					}
					else
					{
						if (flag16)
						{
							lock (C03C6C3A[B02EC714])
							{
								C03C6C3A[B02EC714][text2]++;
							}
						}
						lock (B2978823)
						{
							B2978823[B02EC714].Add(text9);
						}
					}
					if (A7309AA1.D6BBEDA3())
					{
						return -4;
					}
					goto IL_118f;
					IL_0f84:
					if (flag7)
					{
						string text12 = "";
						int num14 = Commom.BF833227(num3, num4);
						for (int l = 0; l < num14; l++)
						{
							if (list4.Count == 0)
							{
								break;
							}
							text12 = list4[Base.rd.Next(0, list4.Count)];
							list4.Remove(text12);
							text9 = text9 + " @[" + text12 + ":]";
						}
					}
					string newValue2 = CommonChrome.smethod_1(A7309AA1);
					text9 = text9.Replace("[u]", newValue2);
					goto IL_100c;
					IL_118f:
					if (flag11)
					{
						string item = "";
						method_130(int_5, string_1 + Language.GetValue("Đang") + text7 + " Share wall...");
						lock (BB33F205)
						{
							if (BB33F205[B02EC714].Count == 0 && !flag12)
							{
								BB33F205[B02EC714] = C499BE3B(B0873E9C[B02EC714]);
							}
							if (BB33F205[B02EC714].Count > 0)
							{
								item = BB33F205[B02EC714][Base.rd.Next(0, BB33F205[B02EC714].Count)];
								BB33F205[B02EC714].Remove(item);
							}
						}
						GClass4 gClass3 = new GClass4();
						gClass3.method_4("content", item);
						if (A7309AA1.AF0F44B1(num13, gClass3, 1))
						{
							int_4++;
						}
						else if (flag16)
						{
							lock (C03C6C3A[B02EC714])
							{
								C03C6C3A[B02EC714][text2]++;
							}
						}
						if (A7309AA1.D6BBEDA3())
						{
							return -4;
						}
					}
					if (flag13)
					{
						string item2 = "";
						method_130(int_5, string_1 + Language.GetValue("Đang") + text7 + " Share wall...");
						lock (dictionary_3)
						{
							if (dictionary_3[B02EC714].Count == 0 && !flag14)
							{
								dictionary_3[B02EC714] = C499BE3B(dictionary_4[B02EC714]);
							}
							if (dictionary_3[B02EC714].Count > 0)
							{
								item2 = dictionary_3[B02EC714].smethod_8();
								dictionary_3[B02EC714].Remove(item2);
							}
						}
						GClass4 gClass4 = new GClass4();
						gClass4.method_4("content", item2);
						gClass4.method_4("soLuongFrom", num6);
						gClass4.method_4("soLuongTo", num7);
						gClass4.method_4("delayFrom", num8);
						gClass4.method_4("delayTo", num9);
						A7309AA1.E40A833A(num13, gClass4, 1);
						if (A7309AA1.D6BBEDA3())
						{
							return -4;
						}
					}
					method_131(int_5, string_1 + Language.GetValue("Đang") + text7 + " delay {time}s...", int_8, int_9);
					num10++;
					break;
				}
				continue;
				IL_08d8:
				if (flag11)
				{
					string text13 = "";
					method_130(int_5, string_1 + Language.GetValue("Đang") + $" {E5AC0C34} ({num10 + 1}/{num11}): Share wall...");
					lock (BB33F205)
					{
						if (BB33F205[B02EC714].Count == 0 && !flag12)
						{
							BB33F205[B02EC714] = C499BE3B(B0873E9C[B02EC714]);
						}
						if (BB33F205[B02EC714].Count > 0)
						{
							text13 = BB33F205[B02EC714][Base.rd.Next(0, BB33F205[B02EC714].Count)];
							BB33F205[B02EC714].Remove(text13);
						}
					}
					if (A7309AA1.C11B5C31(text2, text13))
					{
						int_4++;
					}
					else if (flag16)
					{
						lock (C03C6C3A[B02EC714])
						{
							C03C6C3A[B02EC714][text2]++;
						}
					}
					if (A7309AA1.D6BBEDA3())
					{
						return -4;
					}
				}
				num10++;
				method_131(int_5, string_1 + Language.GetValue("Đang") + $" {E5AC0C34} ({num10}/{num11}), delay {{time}}s...", int_8, int_9);
			}
			end_IL_0228:;
		}
		catch
		{
			num10 = -1;
		}
		if (flag15)
		{
			A7309AA1.method_54();
		}
		return num10;
	}

	public int E41ED239(int A915C611, string string_1, Chrome chrome_0, GClass4 gclass4_0, string EBA98F17, string string_2)
	{
		int numSuccess = 0;
		try
		{
			int delayFrom = gclass4_0.method_2("nudDelayFrom", 3);
			int delayTo = gclass4_0.method_2("nudDelayTo", 5);
			int countFrom = gclass4_0.method_2("nudSoLuongUidFrom", 1);
			int countTo = gclass4_0.method_2("nudSoLuongUidTo", 1);
			int targetCount = Commom.BF833227(countFrom, countTo);
			bool ckbTuDongXoa = gclass4_0.method_3("ckbTuDongXoa") || gclass4_0.method_3("ckbAutoDeleteComment");
			int delayDeleteFrom = gclass4_0.method_2("nudDelayDeleteFrom", 2);
			int delayDeleteTo = gclass4_0.method_2("nudDelayDeleteTo", 5);

			List<string> listPosts = gclass4_0.method_1("txtIdPost");
			List<string> listComments = gclass4_0.method_1("txtComment");
			if (listComments.Count == 0)
			{
				listComments = gclass4_0.method_1("txtCommentEdit", gclass4_0.method_2("cbbTuyChonNoiDungEdit"));
			}

			if (listPosts.Count == 0 || listComments.Count == 0)
			{
				return 0;
			}

			chrome_0.method_53();
			for (int i = 0; i < targetCount && i < listPosts.Count; i++)
			{
				if (chrome_0.CD930D04() || Base.smethod_5()) break;

				string postIdOrUrl = listPosts[i].Trim();
				if (string.IsNullOrEmpty(postIdOrUrl)) continue;

				string postUrl = postIdOrUrl.StartsWith("http") ? postIdOrUrl : ("https://www.facebook.com/" + postIdOrUrl);
				method_130(A915C611, EBA98F17 + Language.GetValue("Đang uptop bài viết ") + $"({numSuccess + 1}/{targetCount})...");

				chrome_0.method_12(postUrl);
				chrome_0.F8091028(2.0);

				string commentContent = listComments[Base.rd.Next(0, listComments.Count)];
				commentContent = Commom.smethod_31(commentContent);

				// Gọi CommentWWW qua FacebookActionsHub để comment đẩy top
				JObject jParam = new JObject
				{
					["url"] = postUrl,
					["content"] = commentContent
				};
				string res = FacebookActionsHub.Execute(chrome_0, "CommentWWW", jParam.ToString());
				bool isCommentSuccess = !string.IsNullOrEmpty(res) && res.Contains("\"success\":true");

				if (isCommentSuccess)
				{
					numSuccess++;
					method_130(A915C611, EBA98F17 + Language.GetValue("Đã bình luận đẩy top bài viết!"));

					// Nếu có tùy chọn tự động xóa comment
					if (ckbTuDongXoa)
					{
						int waitDel = Commom.BF833227(delayDeleteFrom, delayDeleteTo);
						method_130(A915C611, EBA98F17 + string.Format(Language.GetValue("Đợi {0}s để xóa bình luận..."), waitDel));
						chrome_0.F8091028(waitDel);

						try
						{
							// Thực thi xóa comment vừa đăng qua browser JS
							string jsDelete = @"(() => {
								let btns = Array.from(document.querySelectorAll('div[aria-label*=""hành động""], div[aria-label*=""Tùy chọn""], div[aria-label*=""Action""], div[aria-label*=""More""][role=""button""]'));
								if (btns.length > 0) {
									btns[btns.length - 1].click();
									setTimeout(() => {
										let items = Array.from(document.querySelectorAll('div[role=""menuitem""], span'));
										let delItem = items.find(el => el.innerText && (el.innerText.includes('Xóa') || el.innerText.includes('Delete')));
										if (delItem) {
											delItem.click();
											setTimeout(() => {
												let confirmBtn = Array.from(document.querySelectorAll('div[aria-label*=""Xóa""], div[aria-label*=""Delete""], button')).find(b => b.innerText && (b.innerText.includes('Xóa') || b.innerText.includes('Delete')));
												if (confirmBtn) confirmBtn.click();
											}, 1000);
										}
									}, 1000);
									return 'OK';
								}
								return 'FAIL';
							})()";
							chrome_0.ChromeDriver_0?.ExecuteScript(jsDelete);
							chrome_0.F8091028(2.0);
						}
						catch {}
					}

					int delayWait = Commom.BF833227(delayFrom, delayTo);
					method_130(A915C611, EBA98F17 + string.Format(Language.GetValue("Nghỉ {0}s..."), delayWait));
					chrome_0.F8091028(delayWait);
				}
			}
		}
		catch (Exception ex)
		{
			Commom.smethod_58(ex, "HDUptopBaiViet");
		}
		return numSuccess;
	}

	public int A633080C(ref string ACB20DA8, int int_3, string EA3537B2, Chrome BD17C3A1, GClass4 AD833705, string string_1, string string_2)
	{
		int int_4 = AD833705.method_2("nudSoLuongFrom", 1);
		int f4960BA = AD833705.method_2("nudSoLuongTo", 1);
		int int_5 = AD833705.method_2("nudDelayFrom", 10);
		int int_6 = AD833705.method_2("nudDelayTo", 20);
		List<string> collection = AD833705.method_1("txtCatagory");
		string text = AD833705.BDB80B23("txtToCookie");
		bool flag = AD833705.method_3("ckbAutoDeleteContent");

		List<string> list_Bio = AD833705.method_1("lstBio");
		List<string> list_Website = AD833705.method_1("lstWebsite");
		List<string> list_Phone = AD833705.method_1("lstPhone");
		List<string> list_Email = AD833705.method_1("lstEmail");
		List<string> list_Address = AD833705.method_1("lstAddress");
		List<string> list_City = AD833705.method_1("lstCity");
		List<string> list_ZipCode = AD833705.method_1("lstZipCode");
		string txtFolderAvatar = AD833705.BDB80B23("txtFolderAvatar");
		string txtFolderCover = AD833705.BDB80B23("txtFolderCover");
		string txtUidNhanPage = AD833705.BDB80B23("txtUidNhanPage");

		List<string> list = new List<string>();
		List<string> list2 = new List<string>(collection);
		int num = BD17C3A1.method_50(int_4, f4960BA);
		List<string> listUidNhanPage = new List<string>();
		string rawUidNhan = (txtUidNhanPage ?? "").Trim();
		if (!string.IsNullOrEmpty(rawUidNhan))
		{
			if (File.Exists(rawUidNhan))
			{
				try
				{
					string[] lines = File.ReadAllLines(rawUidNhan);
					foreach (string line in lines)
					{
						string trimmed = line.Trim();
						if (string.IsNullOrEmpty(trimmed)) continue;
						string uidVal = Regex.Match(trimmed, @"\d{6,}").Value;
						if (!string.IsNullOrEmpty(uidVal))
						{
							listUidNhanPage.Add(uidVal);
						}
						else if (Commom.smethod_45(trimmed))
						{
							listUidNhanPage.Add(trimmed);
						}
					}
				}
				catch { }
			}
			else
			{
				string[] parts = rawUidNhan.Split(new char[] { '\r', '\n', ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string part in parts)
				{
					string trimmed = part.Trim();
					if (string.IsNullOrEmpty(trimmed)) continue;
					string uidVal = Regex.Match(trimmed, @"\d{6,}").Value;
					if (!string.IsNullOrEmpty(uidVal))
					{
						listUidNhanPage.Add(uidVal);
					}
					else if (Commom.smethod_45(trimmed))
					{
						listUidNhanPage.Add(trimmed);
					}
				}
			}
		}
		if (listUidNhanPage.Count == 0 && !string.IsNullOrEmpty(text))
		{
			string cUser = Regex.Match(text, "c_user=(\\d+)").Groups[1].Value;
			if (!string.IsNullOrEmpty(cUser))
			{
				listUidNhanPage.Add(cUser);
			}
			else if (Commom.smethod_45(text))
			{
				listUidNhanPage.Add(text);
			}
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 2;
		for (int i = 0; i < num + 10; i++)
		{
			string curTargetUid = "";
			if (listUidNhanPage.Count > 0)
			{
				curTargetUid = listUidNhanPage[num2 % listUidNhanPage.Count];
			}
			method_130(int_3, EA3537B2 + Language.GetValue("Đang") + $" {string_1} ({num2 + 1}/{num})...");
			string text3 = "";
			if (flag)
			{
				lock (BB96210A)
				{
					if (BB96210A[string_2].Count > 0)
					{
						text3 = BB96210A[string_2].smethod_8();
						BB96210A[string_2].Remove(text3);
					}
				}
			}
			else if (BB96210A[string_2].Count > 0)
			{
				if (list.Count == 0)
				{
					list = new List<string>(BB96210A[string_2]);
				}
				text3 = list.smethod_8();
				list.Remove(text3);
			}
			string text4 = "";
			if (list2.Count == 0)
			{
				list2 = new List<string>(collection);
			}
			if (list2.Count > 0)
			{
				text4 = list2.smethod_8();
				list2.Remove(text4);
			}
			if (!string.IsNullOrEmpty(text3))
			{
				text3 = Commom.smethod_31(text3);
			}
			if (!string.IsNullOrEmpty(text4))
			{
				text4 = Commom.smethod_31(text4);
			}

			string curBio = (list_Bio != null && list_Bio.Count > 0) ? Commom.smethod_31(list_Bio[Base.rd.Next(0, list_Bio.Count)]) : "";
			string curWebsite = (list_Website != null && list_Website.Count > 0) ? Commom.smethod_31(list_Website[Base.rd.Next(0, list_Website.Count)]) : "";
			string curPhone = (list_Phone != null && list_Phone.Count > 0) ? Commom.smethod_31(list_Phone[Base.rd.Next(0, list_Phone.Count)]) : "";
			string curEmail = (list_Email != null && list_Email.Count > 0) ? Commom.smethod_31(list_Email[Base.rd.Next(0, list_Email.Count)]) : "";
			string curAddress = (list_Address != null && list_Address.Count > 0) ? Commom.smethod_31(list_Address[Base.rd.Next(0, list_Address.Count)]) : "";
			string curCity = (list_City != null && list_City.Count > 0) ? Commom.smethod_31(list_City[Base.rd.Next(0, list_City.Count)]) : "";
			string curZip = (list_ZipCode != null && list_ZipCode.Count > 0) ? Commom.smethod_31(list_ZipCode[Base.rd.Next(0, list_ZipCode.Count)]) : "";

			string curAvatarFile = "";
			if (!string.IsNullOrEmpty(txtFolderAvatar) && Directory.Exists(txtFolderAvatar))
			{
				try
				{
					var extList = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
					var files = Directory.GetFiles(txtFolderAvatar).Where(f => extList.Contains(Path.GetExtension(f).ToLower())).ToList();
					if (files.Count > 0) curAvatarFile = files[Base.rd.Next(0, files.Count)];
				}
				catch { }
			}

			string curCoverFile = "";
			if (!string.IsNullOrEmpty(txtFolderCover) && Directory.Exists(txtFolderCover))
			{
				try
				{
					var extList = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
					var files = Directory.GetFiles(txtFolderCover).Where(f => extList.Contains(Path.GetExtension(f).ToLower())).ToList();
					if (files.Count > 0) curCoverFile = files[Base.rd.Next(0, files.Count)];
				}
				catch { }
			}

			string value = BD17C3A1.method_81(text3, text4, curBio, curWebsite, curPhone, curEmail, curAddress, curCity, curZip, curAvatarFile, curCoverFile, curTargetUid, msg => method_130(int_3, EA3537B2 + msg));
			if (string.IsNullOrEmpty(value))
			{
				num4++;
				if (num4 >= num5)
				{
					break;
				}
				continue;
			}
			if (value == "fb_limit_create_page")
			{
				method_130(int_3, EA3537B2 + Language.GetValue("Tài khoản bị giới hạn tạo Trang (fb_limit_create_page)!"));
				if (num2 == 0)
				{
					ACB20DA8 = Language.GetValue("Bị giới hạn tạo page (fb_limit_create_page)");
				}
				break;
			}
			num2++;
			method_130(int_3, EA3537B2 + Language.GetValue("Tạo thành công Page:") + $" {value} ({num2}/{num})");

			if (PageCreationHub.LastAdminShared)
			{
				num3++;
			}

			// Upload Avatar bổ sung nếu chưa upload trong wizard
			if (!PageCreationHub.LastAvatarUploaded && !string.IsNullOrEmpty(curAvatarFile) && File.Exists(curAvatarFile))
			{
				try
				{
					method_130(int_3, EA3537B2 + $"Up avatar cho Page {value}...");
					BD17C3A1.method_87(value);
					ProfileInfoHub.UploadAvatar(BD17C3A1, curAvatarFile, false, false, log: msg => method_130(int_3, EA3537B2 + msg));
					BD17C3A1.method_87("");
				}
				catch { }
			}

			// Upload Cover bổ sung nếu chưa upload trong wizard
			if (!PageCreationHub.LastCoverUploaded && !string.IsNullOrEmpty(curCoverFile) && File.Exists(curCoverFile))
			{
				try
				{
					method_130(int_3, EA3537B2 + $"Up cover cho Page {value}...");
					BD17C3A1.method_87(value);
					ProfileInfoHub.UploadCover(BD17C3A1, curCoverFile, false, false, msg => method_130(int_3, EA3537B2 + msg));
					BD17C3A1.method_87("");
				}
				catch { }
			}

			if (!PageCreationHub.LastAdminShared && !string.IsNullOrEmpty(curTargetUid))
			{
				try
				{
					method_130(int_3, EA3537B2 + $"Mời UID {curTargetUid} làm quản trị viên Page {value}...");
					if (BD17C3A1.method_83(value, curTargetUid))
					{
						num3++;
						method_130(int_3, EA3537B2 + $"Mời UID {curTargetUid} làm admin thành công!");
					}
					else
					{
						method_130(int_3, EA3537B2 + $"Mời UID {curTargetUid} thất bại hoặc chờ duyệt!");
					}
				}
				catch (Exception ex)
				{
					Commom.smethod_49("method_83 share admin in fMain exception: " + ex.Message);
				}
			}
			if (num2 >= num)
			{
				break;
			}
			if (Base.bool_0)
			{
				method_131(int_3, EA3537B2 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}/{3}), {4} {{time}}s...", string_1, num2, num3, num, Language.GetValue("đợi")), int_5, int_6);
			}
			else
			{
				method_131(int_3, EA3537B2 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_1, num2, num, Language.GetValue("đợi")), int_5, int_6);
			}
		}
		if (num2 == 0 && !string.IsNullOrEmpty(ACB20DA8) && ACB20DA8.Contains("fb_limit"))
		{
		}
		else if (Base.bool_0)
		{
			ACB20DA8 = $"{num2}/{num3}/{num}";
		}
		else
		{
			ACB20DA8 = $"{num2}";
		}
		return 0;
	}

	public int method_94(ref string string_1, int int_3, string string_2, Chrome B2AB9EB1, GClass4 gclass4_0, string CA3DA5A1)
	{
		int int_4 = gclass4_0.method_2("nudSoLuongFrom", 1);
		int f4960BA = gclass4_0.method_2("nudSoLuongTo", 1);
		int int_5 = gclass4_0.method_2("nudDelayFrom", 3);
		int int_6 = gclass4_0.method_2("nudDelayTo", 5);
		string text = gclass4_0.BDB80B23("txtToCookie");
		bool flag = gclass4_0.method_3("ckbLeavePage");
		int num = B2AB9EB1.method_50(int_4, f4960BA);
		string value = "";
		if (!string.IsNullOrEmpty(text))
		{
			if (File.Exists(text))
			{
				try
				{
					string[] lines = File.ReadAllLines(text);
					foreach (var line in lines)
					{
						string m = Regex.Match(line, @"\d{6,}").Value;
						if (!string.IsNullOrEmpty(m)) { value = m; break; }
					}
				}
				catch { }
			}
			if (string.IsNullOrEmpty(value))
			{
				value = Regex.Match(text, "c_user=(\\d+)").Groups[1].Value;
			}
			if (string.IsNullOrEmpty(value))
			{
				value = Regex.Match(text, @"\d{6,}").Value;
			}
		}
		int num2 = 0;
		List<string> list = B2AB9EB1.BE0C6B9C();
		if (list.Count != 0 && !(value == ""))
		{
			for (int i = 0; i < list.Count; i++)
			{
				method_130(int_3, string_2 + Language.GetValue("Đang") + $" {CA3DA5A1} ({num2}/{list.Count})...");
				string text2 = list[i];
				if (B2AB9EB1.method_83(text2, value) && B2AB9EB1.method_80(text, text2))
				{
					num2++;
					if (flag && B2AB9EB1.method_85(text2, ""))
					{
					}
				}
				B2AB9EB1.method_87("");
				if (num2 >= num)
				{
					break;
				}
				method_131(int_3, string_2 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", CA3DA5A1, num2, list.Count, Language.GetValue("đợi")), int_5, int_6);
			}
		}
		string_1 = $"{num2}/{list.Count}";
		return 0;
	}

	public int method_95(ref int F00C45B3, int DDA412A8, string D69B1D21, Chrome chrome_0, GClass4 gclass4_0, string string_1, int BFB244A7)
	{
		int int_ = gclass4_0.method_2("nudDelayFrom");
		int int_2 = gclass4_0.method_2("nudDelayTo");
		List<string> list = gclass4_0.method_1("txtUid");
		F00C45B3 = 0;
		try
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (!chrome_0.CD930D04())
				{
					string text = list[i];
					method_130(DDA412A8, D69B1D21 + Language.GetValue("Đang") + $" {string_1} ({F00C45B3 + 1}/{list.Count})...");
					try
					{
						chrome_0.method_12("https://facebook.com/" + text + "/about");
						chrome_0.F8091028(2.0);
						string string_2 = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
						string json = chrome_0.method_66((BFB244A7 == 0) ? "FollowWWW" : "LikePageWWW", string_2);
						bool isSuccess = false;
						JObject jObject = null;
						try
						{
							jObject = JObject.Parse(json);
							isSuccess = Convert.ToBoolean(jObject["success"]);
						}
						catch { }

						if (!isSuccess)
						{
							isSuccess = RunOtherUtilities_FollowOrLike(DDA412A8, D69B1D21, chrome_0, text, BFB244A7 != 0, string_1);
						}

						if (isSuccess)
						{
							chrome_0.method_13();
							F00C45B3++;
							method_131(DDA412A8, D69B1D21 + Language.GetValue("Đang") + $" {string_1} ({F00C45B3}/{list.Count}), đợi {{time}}s...", int_, int_2);
							continue;
						}
						string text2 = jObject?["error"]?.ToString() ?? "";
						string text3 = text2;
						if (!(text3 == "fb_blocked"))
						{
							if (text3 == "checkpoint")
							{
								goto IL_019b;
							}
							continue;
						}
						chrome_0.EE37E6A7 = true;
						goto IL_019b;
					}
					catch (Exception)
					{
					}
					continue;
				}
				return -2;
			}
		}
		catch
		{
		}
		goto IL_019b;
		IL_019b:
		return F00C45B3;
	}

	public int method_96(int int_3, string E1AE901C, Chrome chrome_0, GClass4 F4AB76AB, string string_1)
	{
		try
		{
			int num = F4AB76AB.method_2("nudSoLuongBanBeFrom");
			int num2 = F4AB76AB.method_2("nudSoLuongBanBeTo");
			int num3 = Commom.BF833227(num, num2);
			F4AB76AB.method_4("nudSoLuongFrom", F4AB76AB.method_2("nudSoLuongBaiVietFrom"));
			F4AB76AB.method_4("nudSoLuongTo", F4AB76AB.method_2("nudSoLuongBaiVietTo"));
			List<string> list = chrome_0.method_57();
			if (list == null || list.Count == 0)
			{
				return 0;
			}
			for (int i = 0; i < num3; i++)
			{
				if (list.Count == 0)
				{
					break;
				}
				string text = list.smethod_8();
				list.Remove(text);
				string text2 = "https://www.facebook.com/profile.php?id=" + text;
				F4AB76AB.method_4("link", text2);
				C1A9CA02(int_3, E1AE901C, chrome_0, F4AB76AB, $"{string_1} ({i + 1}/{num3}):");
				int item = chrome_0.method_125();
				if (new List<int> { -3, -2, -1, 2 }.Contains(item))
				{
					return -1;
				}
			}
		}
		catch (Exception)
		{
		}
		return 0;
	}

	public int FC9FC103(int int_3, string string_1, Chrome B7BC5CA9, GClass4 DD17779B, string string_2)
	{
		try
		{
			int num = DD17779B.method_2("nudSoLuongNhomFrom");
			int num2 = DD17779B.method_2("nudSoLuongNhomTo");
			int num3 = Commom.BF833227(num, num2);
			DD17779B.method_4("nudSoLuongFrom", DD17779B.method_2("nudSoLuongBaiVietFrom"));
			DD17779B.method_4("nudSoLuongTo", DD17779B.method_2("nudSoLuongBaiVietTo"));
			List<string> source = B7BC5CA9.method_56(bool_9: false);
			if (source == null || source.Count == 0)
			{
				return 0;
			}
			source = source.Select((string C6BB7302) => C6BB7302.Split('|')[0]).ToList();
			for (int i = 0; i < num3; i++)
			{
				if (source.Count == 0)
				{
					break;
				}
				string text = source.smethod_8();
				source.Remove(text);
				string text2 = "https://www.facebook.com/groups/" + text + "?sorting_setting=CHRONOLOGICAL";
				DD17779B.method_4("link", text2);
				C1A9CA02(int_3, string_1, B7BC5CA9, DD17779B, $"{string_2} ({i + 1}/{num3}):");
				int item = B7BC5CA9.method_125();
				if (new List<int> { -3, -2, -1, 2 }.Contains(item))
				{
					return -1;
				}
			}
		}
		catch (Exception)
		{
		}
		return 0;
	}

	public int method_97(int int_3, string BB8A7AB4, Chrome chrome_0, GClass4 AA2D998D, string F3190211)
	{
		try
		{
			int num = AA2D998D.method_2("nudSoLuongPageFrom");
			int num2 = AA2D998D.method_2("nudSoLuongPageTo");
			int num3 = Commom.BF833227(num, num2);
			bool flag = AA2D998D.method_3("ckbLikePage");
			AA2D998D.method_4("nudSoLuongFrom", AA2D998D.method_2("nudSoLuongBaiVietFrom"));
			AA2D998D.method_4("nudSoLuongTo", AA2D998D.method_2("nudSoLuongBaiVietTo"));
			List<string> list = AA2D998D.method_1("txtUid");
			if (list == null || list.Count == 0)
			{
				return 0;
			}
			for (int i = 0; i < num3; i++)
			{
				if (list.Count == 0)
				{
					break;
				}
				string text = list.smethod_8();
				list.Remove(text);
				string text2 = "https://www.facebook.com/" + text;
				AA2D998D.method_4("link", text2);
				C1A9CA02(int_3, BB8A7AB4, chrome_0, AA2D998D, $"{F3190211} ({i + 1}/{num3}):");
				int item = chrome_0.method_125();
				if (!new List<int> { -3, -2, -1, 2 }.Contains(item))
				{
					if (flag)
					{
						method_130(int_3, BB8A7AB4 + Language.GetValue("Đang") + $" {F3190211} ({i + 1}/{num3}): Like page...");
						chrome_0.method_12(chrome_0.GetLinkFromId(text, "https://www.facebook.com") + "/about");
						chrome_0.F8091028(2.0);
						_ = "[{\"name\":\"id\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
						chrome_0.method_66("LikePageWWW");
						chrome_0.F8091028(2.0);
					}
					continue;
				}
				return -1;
			}
		}
		catch (Exception)
		{
		}
		return 0;
	}

	public int method_98(int int_3, string C89E33A7, Chrome chrome_0, GClass4 gclass4_0, string string_1, string string_2 = "")
	{
		string text = F6061E95(int_3, "cUid");
		int num = gclass4_0.method_2("typeListUid");
		string path = gclass4_0.BDB80B23("txtPathFileUid");
		int minValue = gclass4_0.method_2("nudSoLuongUidFrom");
		int num2 = gclass4_0.method_2("nudSoLuongUidTo");
		int minValue2 = gclass4_0.method_2("nudSoLuongBaiVietFrom");
		int num3 = gclass4_0.method_2("nudSoLuongBaiVietTo");
		int int_4 = gclass4_0.method_2("nudDelayFrom");
		int int_5 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbInteract");
		bool flag2 = gclass4_0.method_3("ckbComment");
		bool flag3 = gclass4_0.method_3("ckbRunAPI");
		bool bool_ = gclass4_0.method_3("ckbAutoDeleteComment");
		bool flag4 = gclass4_0.method_3("ckbBoQua");
		int minValue3 = gclass4_0.method_2("nudBoQuaFrom");
		int num4 = gclass4_0.method_2("nudBoQuaTo");
		bool flag5 = gclass4_0.method_3("ckbTheoThuTu");
		bool flag6 = gclass4_0.method_3("ckbTuDongThamGiaNhom");
		bool flag7 = gclass4_0.method_3("ckbShareWall");
		bool flag8 = gclass4_0.method_3("ckbSendAnh");
		string string_3 = gclass4_0.BDB80B23("txtAnh");
		bool flag9 = gclass4_0.method_3("ckbTuDongXoaUid");
		bool flag10 = gclass4_0.method_3("ckbUuTienMbasic");
		List<string> c8199D0D = gclass4_0.method_1("txtCommentEdit", gclass4_0.method_2("cbbTuyChonNoiDungEdit"));
		string text2 = gclass4_0.BDB80B23("typeReaction", "0");
		int num5 = gclass4_0.method_2("typeID", -1);
		int num6 = 0;
		int num7 = 0;
		string text3 = "";
		string item = "";
		Queue<string> queue = new Queue<string>();
		List<string> list = new List<string>();
		if (num == 1)
		{
			list = File.ReadAllLines(path).ToList();
			list = Commom.smethod_36(list);
			if (list.Count == 0)
			{
				return 0;
			}
		}
		else if (!flag9)
		{
			list = C499BE3B(D68DE6AD[string_2]);
		}
		List<string> list_ = new List<string>();
		List<string> list2 = new List<string>();
		if (flag8)
		{
			list_ = Commom.smethod_76(string_3);
			list2 = C499BE3B(list_);
		}
		bool flag11 = false;
		try
		{
			int num8 = Base.rd.Next(minValue, num2 + 1);
			int num9 = 0;
			while (num9 < num8)
			{
				string text4;
				if (!chrome_0.CD930D04())
				{
					text4 = "";
					if (flag5)
					{
						lock (object_6)
						{
							if (num == 1)
							{
								list = File.ReadAllLines(path).ToList();
								list = Commom.smethod_36(list);
								queue = new Queue<string>(list);
								if (list.Count == 0)
								{
									break;
								}
								text4 = queue.Dequeue();
								goto IL_0fe2;
							}
							lock (D68DE6AD)
							{
								if (D68DE6AD[string_2].Count == 0)
								{
									break;
								}
								queue = new Queue<string>(D68DE6AD[string_2]);
								text4 = queue.Dequeue();
								goto IL_0fe2;
							}
						}
					}
					if (flag9)
					{
						lock (object_6)
						{
							if (num == 1)
							{
								list = File.ReadAllLines(path).ToList();
								list = Commom.smethod_36(list);
								if (list.Count == 0)
								{
									break;
								}
								text4 = list[Base.rd.Next(0, list.Count)];
								list.Remove(text4);
								File.WriteAllLines(path, list);
								goto IL_0fe2;
							}
							lock (D68DE6AD)
							{
								if (D68DE6AD[string_2].Count == 0)
								{
									break;
								}
								text4 = D68DE6AD[string_2][Base.rd.Next(0, D68DE6AD[string_2].Count)];
								D68DE6AD[string_2].Remove(text4);
								goto IL_0fe2;
							}
						}
					}
					if (list.Count != 0)
					{
						text4 = list[Base.rd.Next(0, list.Count)];
						list.Remove(text4);
						goto IL_0fe2;
					}
					break;
				}
				return -2;
				IL_0fe2:
				do
				{
					IL_0fe2_2:
					text4 = text4.Trim();
					string text5 = "";
					if (!text4.StartsWith("https"))
					{
						if (Commom.smethod_45(text4.Replace("/posts", "")))
						{
							text4 = text4.Replace("/posts", "");
							switch (num5)
							{
							default:
								text5 = "https://m.facebook.com/" + text4;
								break;
							case 1:
								text5 = "https://m.facebook.com/groups/" + text4;
								break;
							case 0:
							case 2:
								text5 = "https://m.facebook.com/profile.php?id=" + text4;
								if (!Commom.IsUid(text4))
								{
									text5 += "/posts";
								}
								break;
							}
						}
						else
						{
							text5 = "https://m.facebook.com/" + text4;
						}
					}
					else
					{
						text5 = text4;
					}
					int num14;
					int num15;
					int j;
					if (flag3 && (flag2 || flag7))
					{
						chrome_0.method_12(text5.Replace("https://m.facebook.com/", "https://mbasic.facebook.com/"));
						int num10 = chrome_0.method_125();
						if (num10 == 1)
						{
							goto IL_0fe2_2;
						}
						if (new List<int> { -3, -2, -1, 2 }.Contains(num10))
						{
							return -1;
						}
						num6++;
						num7 = 0;
						int num11 = Base.rd.Next(minValue2, num3 + 1);
						int num12 = 0;
						int i = 0;
						if (flag4)
						{
							num12 = Base.rd.Next(minValue3, num4 + 1);
							i += num12;
						}
						if (flag6 && chrome_0.D7A424AE("[action^=\"/a/group/join/\"] input[type=\"submit\"]"))
						{
							chrome_0.method_18("[action^=\"/a/group/join/\"] input[type=\"submit\"]");
							chrome_0.F8091028(2.0);
						}
						List<string> list3 = chrome_0.method_111(text4, num11 + i);
						for (; i < num11 + 10; i++)
						{
							method_130(int_3, C89E33A7 + Language.GetValue("Đang") + $" {string_1} ({num6}/{num8}:{num7 + 1}/{num11})...");
							if (num7 >= num11)
							{
								break;
							}
							string text6 = list3[i];
							if (gclass4_0.method_3("ckbKhongCommentTrungBaiCu"))
							{
								lock (dictionary_1)
								{
									if (!dictionary_1.ContainsKey(text))
									{
										dictionary_1.Add(text, new List<string>());
									}
									if (C496D581(text6))
									{
										continue;
									}
									dictionary_1[text].Add(text6);
									File.AppendAllText(C5034B95.smethod_0("configGeneral").BDB80B23("pathResult", "output\\resultSpam") + "\\" + text + ".txt", text6 + Environment.NewLine);
									goto IL_0d7a;
								}
							}
							goto IL_0d7a;
							IL_0d7a:
							if (!flag2)
							{
								continue;
							}
							text3 = method_99(ref E6810C8F, EF9BBAAF, string_2, bool_);
							if (text3 != "")
							{
								string newValue = CommonChrome.smethod_1(chrome_0);
								text3 = text3.Replace("[u]", newValue);
								text3 = text3.Replace("@[uid:0]", "@[" + text4 + ":0]");
								if (!chrome_0.method_105(text6, text3))
								{
									if (gclass4_0.method_3("ckbKhongCommentTrungBaiCu"))
									{
										lock (dictionary_1)
										{
											dictionary_1[text].Remove(text6);
										}
									}
									if (chrome_0.F5812DA8 == "")
									{
										return 0;
									}
									if (chrome_0.CD930D04())
									{
										return -2;
									}
									if (chrome_0.D6BBEDA3())
									{
										return -4;
									}
									string text7 = chrome_0.GetURL();
									if (text7.Contains("1501092823525282") || text7.Contains("828281030927956") || (text7.Contains("facebook.com/nt/screen/?params=") && text7.Contains("checkpoint")))
									{
										return 0;
									}
								}
							}
							if (flag7 && !chrome_0.C11B5C31(text6, ""))
							{
								if (chrome_0.F5812DA8 == "")
								{
									return 0;
								}
								if (chrome_0.CD930D04())
								{
									return -2;
								}
								if (chrome_0.D6BBEDA3())
								{
									return -4;
								}
								string text8 = chrome_0.GetURL();
								if (text8.Contains("1501092823525282") || text8.Contains("828281030927956") || (text8.Contains("facebook.com/nt/screen/?params=") && text8.Contains("checkpoint")))
								{
									return 0;
								}
							}
							num7++;
							method_131(int_3, C89E33A7 + Language.GetValue("Đang") + $" {string_1} ({num6}/{num8}:{num7}/{num11}), delay {{time}}s...", int_4, int_5);
						}
					}
					else
					{
						if (flag11)
						{
							text5 = text5.Replace("/posts", "");
						}
						if (flag10)
						{
							text5 = text5.Replace(Regex.Match(text5, "https://.*?facebook").Value, "https://mbasic.facebook") + "?v=timeline";
						}
						chrome_0.method_12(text5);
						int num13 = chrome_0.method_125();
						if (num13 == 1)
						{
							goto IL_0fe2_2;
						}
						if (new List<int> { -3, -2, -1, 2 }.Contains(num13))
						{
							return -1;
						}
						num14 = chrome_0.method_61();
						if (num14 == 1)
						{
							if (!flag11)
							{
								flag11 = true;
								chrome_0.method_53();
								chrome_0.method_49();
								goto IL_0fe2_2;
							}
							chrome_0.method_60();
							chrome_0.method_32(300, 0);
						}
						num6++;
						num7 = 0;
						num15 = Base.rd.Next(minValue2, num3 + 1);
						int num16 = 0;
						j = 1;
						if (flag4)
						{
							num16 = Base.rd.Next(minValue3, num4 + 1);
							j += num16;
						}
						if (!flag6)
						{
							goto IL_0698;
						}
						if (!chrome_0.method_18("a[data-ajaxify-href*=\"invite_response=accept\"]"))
						{
							if (!chrome_0.D7A424AE("[use=\"special\"]", 5.0))
							{
								goto IL_0698;
							}
							chrome_0.method_18("[use=\"special\"]");
							chrome_0.method_45(2, 3);
							num9--;
						}
						else
						{
							chrome_0.method_45(2, 3);
							num9--;
						}
					}
					goto IL_0fd7;
					IL_0fd7:
					num9++;
					goto IL_0243;
					IL_0698:
					string text9 = ((num14 == 1) ? "//*[@aria-posinset]" : chrome_0.method_15(0.0, new List<string> { "//*[contains(@data-store, \"linkdata\")]", "//*[@data-module-role=\"TOP_PUBLIC_POSTS\"]//*[@data-module-result-type=\"story\"]/div", "//article[.//footer]" }));
					if (chrome_0.D7A424AE(text9, 5.0))
					{
						for (; j < num15 + 10 && num7 < num15; j++)
						{
							method_130(int_3, C89E33A7 + Language.GetValue("Đang") + $" {string_1} ({num6}/{num8}:{num7 + 1}/{num15})...");
							int num13 = chrome_0.method_125();
							string text12;
							if (num13 != 1)
							{
								if (!new List<int> { -3, -2, -1, 2 }.Contains(num13))
								{
									string text10 = $"({text9})[{j}]";
									if (!chrome_0.D7A424AE(text10))
									{
										for (int k = 0; k < 3; k++)
										{
											chrome_0.method_8(10000);
											if (chrome_0.D7A424AE(text10, 10.0))
											{
												break;
											}
										}
										if (!chrome_0.D7A424AE(text10))
										{
											break;
										}
									}
									chrome_0.method_34(text10);
									if (flag)
									{
										GClass4 gClass = new GClass4();
										string text11 = text2.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList().smethod_8();
										gClass.method_4("reaction", text11);
										chrome_0.method_102(num14, gClass, j);
									}
									if (flag2 || flag8)
									{
										if (flag2)
										{
											text3 = method_99(ref E6810C8F, EF9BBAAF, string_2, bool_);
											if (text3 != "")
											{
												text3 = Commom.smethod_31(text3);
												string newValue2 = CommonChrome.smethod_1(chrome_0);
												text3 = text3.Replace("[u]", newValue2);
												text3 = text3.Replace("@[uid:0]", "@[" + text4 + ":0]");
											}
										}
										if (flag8)
										{
											if (list2.Count == 0)
											{
												list2 = C499BE3B(list_);
											}
											item = list2[Base.rd.Next(0, list2.Count)];
											list2.Remove(item);
										}
										text12 = "";
										if (num14 != 1 && gclass4_0.method_3("ckbKhongCommentTrungBaiCu"))
										{
											text12 = chrome_0.method_14($"return JSON.parse(document.querySelectorAll('[data-store*=\"linkdata\"]')[{j}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]').getAttribute('data-click')).target_id").ToString();
											lock (dictionary_1)
											{
												if (!dictionary_1.ContainsKey(text))
												{
													dictionary_1.Add(text, new List<string>());
												}
												if (C496D581(text12))
												{
													continue;
												}
												dictionary_1[text].Add(text12);
												File.AppendAllText(C5034B95.smethod_0("configGeneral").BDB80B23("pathResult", "output\\resultSpam") + "\\" + text + ".txt", text12 + Environment.NewLine);
												goto IL_09fa;
											}
										}
										goto IL_09fa;
									}
									goto IL_0afa;
								}
								return -1;
							}
							goto IL_0b89;
							IL_09fa:
							GClass4 gClass2 = new GClass4();
							if (flag2)
							{
								gClass2.method_4("content", text3);
							}
							if (flag8)
							{
								gClass2.method_4("image", item);
							}
							gClass2.method_4("ckbEditComment", gclass4_0.method_3("ckbEditComment"));
							gClass2.method_4("nudDelayEditFrom", gclass4_0.method_2("nudDelayEditFrom"));
							gClass2.method_4("nudDelayEditTo", gclass4_0.method_2("nudDelayEditTo"));
							gClass2.method_4("contentEdit", c8199D0D.smethod_8());
							bool flag12 = chrome_0.DD052422(num14, gClass2, j);
							if (text12 != "" && !flag12 && gclass4_0.method_3("ckbKhongCommentTrungBaiCu"))
							{
								lock (dictionary_1)
								{
									dictionary_1[text].Remove(text12);
								}
							}
							goto IL_0afa;
							IL_0afa:
							if (flag7)
							{
								GClass4 f8AD3DB = new GClass4();
								chrome_0.AF0F44B1(num14, f8AD3DB, j);
							}
							num7++;
							method_131(int_3, C89E33A7 + Language.GetValue("Đang") + $" {string_1} ({num6}/{num8}:{num7}/{num15}), delay {{time}}s...", int_4, int_5);
						}
					}
					goto IL_0fd7;
					IL_0b89:;
				}
				while (num7 == 0);
				break;
				IL_0243:;
			}
		}
		catch
		{
			num6 = -1;
		}
		if (flag11)
		{
			chrome_0.method_54();
		}
		return num6;
	}

	private string method_99(ref Dictionary<string, List<string>> dictionary_29, Dictionary<string, List<string>> dictionary_30, string string_1, bool bool_5)
	{
		string result = "";
		lock (dictionary_29)
		{
			if (dictionary_29[string_1].Count == 0)
			{
				if (bool_5)
				{
					return "";
				}
				if (dictionary_30[string_1].Count == 0)
				{
					return "";
				}
				dictionary_29[string_1] = new List<string>(dictionary_30[string_1]);
			}
			int index = dictionary_29[string_1].smethod_7();
			result = dictionary_29[string_1][index];
			dictionary_29[string_1].RemoveAt(index);
		}
		return result;
	}

	private bool D52E618A(int int_3, string string_1, Chrome FCBE44AC, GClass4 CF89F209, string string_2 = "", string string_3 = "")
	{
		int tickCount = Environment.TickCount;
		int num = 60;
		string text = CF89F209.BDB80B23("cbbVideoNoiDungCha");
		string text2 = CF89F209.BDB80B23("cbbVideoNoiDungCon");
		bool flag = false;
		bool flag2 = false;
		string text3 = "";
		List<string> list = new List<string> { "Intellectual property", "A friend", "Pretending to be a business" };
		while (!FCBE44AC.E184CD03() && !FCBE44AC.CD930D04() && Environment.TickCount - tickCount <= num * 1000)
		{
			string text4 = FCBE44AC.method_15(0.0, new List<string> { "//*[@aria-labelledby=\"dialog_title\"]//*[@role=\"listitem\"]", "//*[@aria-labelledby=\"dialog_title\"]//*[@role=\"button\"]", "//*[@role=\"dialog\"]//*[@aria-label=\"Actions for this post\"]", "//*[@aria-label=\"Report\"]//*[@aria-label=\"Submit\"]", "//*[@role=\"dialog\"]//*[@aria-label=\"Next\"]", "//*[@role=\"dialog\"]//*[@aria-label=\"Done\"]" });
			switch (text4)
			{
			case "//*[@role=\"dialog\"]//*[@aria-label=\"Continue\"]":
				FCBE44AC.method_18(text4);
				break;
			case "//*[@aria-labelledby=\"dialog_title\"]//*[@role=\"listitem\"]":
			case "//*[@aria-labelledby=\"dialog_title\"]//*[@role=\"button\"]":
				if (!FCBE44AC.D7A424AE("//*[text()=\"Thanks for letting us know\"]"))
				{
					if (!FCBE44AC.D7A424AE("[aria-labelledby=\"dialog_title\"] [aria-label=\"Done\"]"))
					{
						if (FCBE44AC.D7A424AE("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]"))
						{
							FCBE44AC.method_18("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]");
						}
						else if (!flag)
						{
							flag = true;
							if (text != "Random")
							{
								FCBE44AC.method_18("//*[text()=\"" + text + "\"]");
								break;
							}
							text3 = FCBE44AC.method_86(list);
							FCBE44AC.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
						}
						else if (!flag2)
						{
							flag2 = true;
							if (text2 != "Random")
							{
								FCBE44AC.method_18("//*[text()=\"" + text2 + "\"]");
								break;
							}
							text3 = FCBE44AC.method_86(list);
							FCBE44AC.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
						}
						else
						{
							text3 = FCBE44AC.method_86(list);
							FCBE44AC.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
						}
						break;
					}
					return true;
				}
				return true;
			case "//*[@role=\"dialog\"]//*[@aria-label=\"Actions for this post\"]":
				if (!FCBE44AC.D7A424AE("//*[@aria-label=\"Submit\"]"))
				{
					if (FCBE44AC.D7A424AE("//*[@role=\"menuitem\"]//*[text()=\"Report post\"]"))
					{
						FCBE44AC.method_18("//*[@role=\"menuitem\"]//*[text()=\"Report post\"]");
					}
					else
					{
						FCBE44AC.method_18(text4);
					}
					break;
				}
				FCBE44AC.method_18("//*[@aria-label=\"Submit\"]");
				if (!FCBE44AC.method_33("//*[@aria-label=\"Submit\"]", 30))
				{
					return false;
				}
				return true;
			case "//*[@aria-label=\"Report\"]//*[@aria-label=\"Submit\"]":
				FCBE44AC.method_18(text4);
				if (!FCBE44AC.method_33(text4, 30))
				{
					return false;
				}
				return true;
			}
			FCBE44AC.F8091028(2.0);
		}
		return true;
	}

	private bool method_100(int E6B98680, string string_1, Chrome chrome_0, GClass4 gclass4_0, string A3ADFB0F = "", string string_2 = "")
	{
		int tickCount = Environment.TickCount;
		int num = 60;
		string text = gclass4_0.BDB80B23("cbbUserNoiDungCha");
		string text2 = gclass4_0.BDB80B23("cbbUserNoiDungCon");
		bool flag = false;
		bool flag2 = false;
		string text3 = "";
		List<string> list = new List<string> { "Intellectual property", "A friend", "Pretending to be a business", "Someone else", "Celebrity", "A business" };
		while (true)
		{
			if (!chrome_0.E184CD03() && !chrome_0.CD930D04() && Environment.TickCount - tickCount <= num * 1000)
			{
				string text4 = chrome_0.method_15(0.0, new List<string> { "//*[@aria-label=\"Profile settings see more options\"]", "//*[@aria-label=\"Report\"]//*[@aria-label=\"Submit\"]" });
				string text5 = text4;
				string text6 = text5;
				if (!(text6 == "//*[@aria-label=\"Profile settings see more options\"]"))
				{
					if (text6 == "//*[@aria-label=\"Report\"]//*[@aria-label=\"Submit\"]")
					{
						chrome_0.method_18(text4);
						if (!chrome_0.method_33(text4, 30))
						{
							return false;
						}
						return true;
					}
				}
				else
				{
					if (chrome_0.D7A424AE("//*[text()=\"You selected\"]"))
					{
						return true;
					}
					if (chrome_0.D7A424AE("[aria-labelledby=\"dialog_title\"] [aria-label=\"Done\"]"))
					{
						return true;
					}
					if (chrome_0.D7A424AE("//*[@role=\"dialog\"]//*[text()=\"Submit\"]"))
					{
						break;
					}
					if (chrome_0.D7A424AE("//*[@aria-labelledby=\"dialog_title\" and @role=\"dialog\"]//*[text()=\"Report\"]"))
					{
						if (chrome_0.D7A424AE("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]"))
						{
							chrome_0.method_18("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]");
						}
						else if (!flag)
						{
							flag = true;
							if (text != "Random")
							{
								chrome_0.method_18("//*[text()=\"" + text + "\"]");
							}
							else
							{
								text3 = chrome_0.method_86(list);
								chrome_0.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
							}
						}
						else if (!flag2)
						{
							flag2 = true;
							if (text2 != "Random")
							{
								chrome_0.method_18("//*[text()=\"" + text2 + "\"]");
							}
							else
							{
								text3 = chrome_0.method_86(list);
								chrome_0.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
							}
						}
						else
						{
							text3 = chrome_0.method_86(list);
							chrome_0.method_19("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text3);
						}
					}
					else if (chrome_0.D7A424AE("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]"))
					{
						chrome_0.method_18("//*[@role=\"listitem\"]//*[contains(text(), \"Something about\")]");
					}
					else if (chrome_0.D7A424AE("//*[@role=\"menuitem\"]//*[text()=\"Report profile\"]"))
					{
						chrome_0.method_18("//*[@role=\"menuitem\"]//*[text()=\"Report profile\"]");
					}
					else
					{
						chrome_0.method_19(text4);
					}
				}
				chrome_0.F8091028(2.0);
				continue;
			}
			return false;
		}
		chrome_0.method_18("//*[@role=\"dialog\"]//*[text()=\"Submit\"]");
		if (!chrome_0.method_33("//*[@role=\"dialog\"]//*[text()=\"Submit\"]", 30))
		{
			return false;
		}
		return true;
	}

	public int method_101(int int_3, string D1A2689B, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "", string F328729E = "")
	{
		List<string> list = gclass4_0.method_1("txtLink");
		string text = D1A2689B + Language.GetValue("Đang") + " " + string_1 + " ";
		chrome_0.method_53();
		for (int i = 0; i < list.Count; i++)
		{
			if (chrome_0.CD930D04())
			{
				break;
			}
			if (chrome_0.E184CD03())
			{
				break;
			}
			method_130(int_3, text + $"({i + 1}/{list.Count}): Open link...");
			string string_2 = list[i];
			chrome_0.method_12(string_2, FC3A841F: true);
			chrome_0.F8091028(2.0);
			bool flag = true;
			if (chrome_0.GetURL().Contains("posts") || chrome_0.GetURL().Contains("permalink"))
			{
				flag = false;
			}
			method_130(int_3, text + $"({i + 1}/{list.Count}): Report...");
			if (!flag)
			{
				D52E618A(int_3, D1A2689B, chrome_0, gclass4_0, string_1, F328729E);
			}
			else
			{
				method_100(int_3, D1A2689B, chrome_0, gclass4_0, string_1, F328729E);
			}
		}
		chrome_0.method_54();
		return 1;
	}

	public int method_102(int int_3, string string_1, Chrome A525870C, GClass4 gclass4_0, string string_2, string string_3)
	{
		int minValue = gclass4_0.method_2("nudSoLuongUidFrom");
		int num = gclass4_0.method_2("nudSoLuongUidTo");
		int minValue2 = gclass4_0.method_2("nudSoLuongAnhFrom");
		int num2 = gclass4_0.method_2("nudSoLuongAnhTo");
		int int_4 = gclass4_0.method_2("nudDelayFrom");
		int int_5 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbNhanTinVanBan");
		bool flag2 = gclass4_0.method_3("ckbAutoDeleteComment");
		bool flag3 = gclass4_0.method_3("ckbSendAnh");
		string string_4 = gclass4_0.BDB80B23("txtAnh");
		int num3 = gclass4_0.method_2("typeDoiTuong");
		bool flag4 = gclass4_0.method_3("ckbTuDongXoaUid");
		bool flag5 = gclass4_0.method_3("ckbTuongTacKhiNhanTin");
		int num4 = gclass4_0.method_2("typeTuongTacKhiNhanTin");
		if (num3 != 0)
		{
			flag4 = false;
		}
		int num5 = 0;
		List<string> list_ = new List<string>();
		List<string> list = new List<string>();
		if (flag3)
		{
			list_ = Commom.smethod_76(string_4);
			list = C499BE3B(list_);
		}
		int num6 = 0;
		A525870C.method_53(700);
		try
		{
			int num7 = Base.rd.Next(minValue, num + 1);
			if (new List<int> { 0, 1, 2 }.Contains(num3))
			{
				List<string> list2 = new List<string>();
				switch (num3)
				{
				case 0:
					list2 = new List<string>(CB89B620[string_3]);
					break;
				case 1:
					list2 = A525870C.method_57();
					break;
				case 2:
					list2 = A525870C.D5008BAB();
					break;
				}
				for (int num8 = 0; num8 < num7; num8++)
				{
					string text;
					if (!A525870C.CD930D04())
					{
						text = "";
						if (flag4)
						{
							lock (CB89B620)
							{
								if (CB89B620[string_3].Count == 0)
								{
									break;
								}
								text = CB89B620[string_3][Base.rd.Next(0, CB89B620[string_3].Count)];
								CB89B620[string_3].Remove(text);
								goto IL_026b;
							}
						}
						if (list2.Count != 0)
						{
							text = list2[Base.rd.Next(0, list2.Count)];
							list2.Remove(text);
							goto IL_026b;
						}
						break;
					}
					return -2;
					IL_026b:
					method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num5 + 1}/{num7})...");
					if (flag5 && num4 == 0)
					{
						A525870C.method_12("https://www.facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
						A525870C.method_69();
						F12A6CA2(int_3, string_1, A525870C, gclass4_0);
					}
					do
					{
						A525870C.method_12("https://www.facebook.com/messages/t/" + text + "?locale=en_US");
						A525870C.F8091028(2.0);
						num6 = A525870C.method_125();
					}
					while (num6 == 1);
					List<string> list3;
					string text2;
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
					{
						A525870C.method_60();
						list3 = new List<string>();
						if (flag3)
						{
							int num9 = Base.rd.Next(minValue2, num2 + 1);
							for (int i = 0; i < num9; i++)
							{
								if (list.Count == 0)
								{
									list = C499BE3B(list_);
								}
								string item = list[Base.rd.Next(0, list.Count)];
								list.Remove(item);
								list3.Add(item);
							}
						}
						text2 = "";
						if (flag)
						{
							if (!gclass4_0.method_3("ckbTaoNoiDungAI"))
							{
								lock (dictionary_5)
								{
									if (dictionary_5[string_3].Count != 0)
									{
										goto IL_04c2;
									}
									if (flag2)
									{
										break;
									}
									dictionary_5[string_3] = C499BE3B(dictionary_6[string_3]);
									goto IL_04c2;
									IL_04c2:
									text2 = dictionary_5[string_3][0];
									dictionary_5[string_3].Remove(text2);
									goto IL_04fa;
								}
							}
							string text3 = "[data-release-focus-from=\"CLICK\"]:has([style*=\"border-radius\"][src][alt]) [role=\"presentation\"] [role=\"none\"] [role=\"presentation\"]>span";
							string text4 = A525870C.method_6(text3 + $"|{A525870C.method_30(text3) - 1}");
							if (text4 == "")
							{
								text4 = "Hi";
							}
							if (text4 != "")
							{
								text2 = Commom.smethod_93(gclass4_0.BDB80B23("cbbPrompt"), text4, list3.FirstOrDefault() ?? "");
							}
						}
						goto IL_04fa;
					}
					return -1;
					IL_04fa:
					if (A525870C.method_116(text2, string.Join("|", list3)))
					{
						num5++;
						method_131(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num5}/{num7}), đợi {{time}}s...", int_4, int_5);
						if (flag5 && num4 == 1)
						{
							A525870C.method_12("https://www.facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
							A525870C.method_69();
							F12A6CA2(int_3, string_1, A525870C, gclass4_0);
						}
					}
				}
			}
			else
			{
				do
				{
					switch (num3)
					{
					case 4:
						A525870C.method_12("https://www.facebook.com/messages/requests?locale=en_US");
						break;
					case 5:
						A525870C.method_12("https://www.facebook.com/messages/t?locale=en_US");
						break;
					case 3:
						A525870C.method_12("https://www.facebook.com/messages/filtered?locale=en_US");
						break;
					}
					num6 = A525870C.method_125();
				}
				while (num6 == 1);
				if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
				{
					return -1;
				}
				int num10 = 0;
				for (int num11 = 0; num11 < num7 + 10; num11++)
				{
					string text5 = "";
					if (num3 == 3 || num3 == 4)
					{
						text5 = ".html-div:has([role=\"row\"]>[role=\"gridcell\"])|" + num10;
					}
					else if (num3 == 5)
					{
						text5 = ".html-div:has([role=\"row\"]>[role=\"gridcell\"])|" + num11;
					}
					if (!A525870C.D7A424AE(text5, (num11 == 0) ? 10 : 0))
					{
						break;
					}
					method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num5 + 1}/{num7})...");
					A525870C.method_19(text5);
					A525870C.F8091028(2.0);
					string text6 = A525870C.B9BE8807(text5 + "|[aria-current=\"page\"]", "href");
					List<string> list4 = new List<string>();
					if (flag3)
					{
						int num12 = Base.rd.Next(minValue2, num2 + 1);
						for (int j = 0; j < num12; j++)
						{
							if (list.Count == 0)
							{
								list = C499BE3B(list_);
							}
							string item2 = list[Base.rd.Next(0, list.Count)];
							list.Remove(item2);
							list4.Add(item2);
						}
					}
					string text7 = "";
					if (flag)
					{
						if (!gclass4_0.method_3("ckbTaoNoiDungAI"))
						{
							lock (dictionary_5)
							{
								if (dictionary_5[string_3].Count != 0)
								{
									goto IL_087d;
								}
								if (flag2)
								{
									break;
								}
								dictionary_5[string_3] = C499BE3B(dictionary_6[string_3]);
								goto IL_087d;
								IL_087d:
								text7 = dictionary_5[string_3][0];
								dictionary_5[string_3].Remove(text7);
								goto IL_08b5;
							}
						}
						string text8 = "[data-release-focus-from=\"CLICK\"]:has([style*=\"border-radius\"][src][alt]) [role=\"presentation\"] [role=\"none\"] [role=\"presentation\"]>span";
						string text9 = A525870C.method_6(text8 + $"|{A525870C.method_30(text8) - 1}");
						if (text9 == "")
						{
							text9 = "Hi";
						}
						if (text9 != "")
						{
							text7 = Commom.smethod_93(gclass4_0.BDB80B23("cbbPrompt"), text9, list4.FirstOrDefault() ?? "");
						}
					}
					goto IL_08b5;
					IL_08b5:
					bool flag6;
					if ((flag6 = A525870C.method_116(text7, string.Join("|", list4))) && text6 == A525870C.B9BE8807(text5 + "|[aria-current=\"page\"]", "href"))
					{
						flag6 = false;
					}
					if (flag6)
					{
						num5++;
						method_131(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num5}/{num7}), đợi {{time}}s...", int_4, int_5);
						if (num5 >= num7)
						{
							break;
						}
					}
					else if (num3 == 3 || num3 == 4)
					{
						num10++;
					}
				}
			}
		}
		catch
		{
			num5 = -1;
		}
		A525870C.method_54();
		return num5;
	}

	private int method_103(ref string string_1, int int_3, string string_2, Chrome chrome_0, GClass4 BE1D0631, string string_3, string string_4)
	{
		F6061E95(int_3, "cId");
		List<string> source = new List<string>();
		List<string> list = new List<string>();
		List<string> source2 = new List<string>();
		int num = BE1D0631.method_2("typeDatTen");
		int num2 = BE1D0631.method_2("typeTenTuDat");
		if (num == 1)
		{
			if (num2 == 0)
			{
				source = BE1D0631.method_1("lstHo");
				list = BE1D0631.method_1("lstTenDem");
				source2 = BE1D0631.method_1("lstTen");
			}
		}
		else if (BE1D0631.method_2("typeTenRandom") == 0)
		{
			source = SetupFolder.smethod_4();
			list = SetupFolder.B92F5E26();
			source2 = SetupFolder.smethod_5();
		}
		else
		{
			source = SetupFolder.smethod_6();
			list = new List<string>();
			source2 = SetupFolder.smethod_7();
		}
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		if (num == 1 && num2 == 1)
		{
			text4 = method_99(ref dictionary_26, dictionary_27, string_4, BE1D0631.method_3("ckbTuDongXoaNoiDung"));
			string[] array = text4.Split(' ');
			text = array[0];
			text3 = array[array.Length - 1];
			if (array.Length > 2)
			{
				text2 = array[1];
			}
		}
		else
		{
			text = source.OrderBy((string string_0) => Guid.NewGuid()).First();
			if (list.Count > 0)
			{
				text2 = list.OrderBy((string string_0) => Guid.NewGuid()).First().Trim();
			}
			text3 = source2.OrderBy((string string_0) => Guid.NewGuid()).First();
			text4 = text + ((text2 == "") ? " " : (" " + text2 + " ")) + text3;
		}
		string text5 = string_2 + Language.GetValue("Đang") + " " + string_3 + ": ";
		method_130(int_3, text5 + Language.GetValue("Đang chạy..."));
		if (Commom.A01DE9AB(text4))
		{
			string_1 = (chrome_0.D727CD89(text4) ? "Success" : "Fail");
		}
		else
		{
			string_1 = (chrome_0.CE37360F(text, text2, text3).method_3("success") ? "Success" : "Fail");
		}
		return 1;
	}

	public int method_104(int int_3, string F2123D1C, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "")
	{
		int int_4 = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int int_5 = gclass4_0.method_2("nudDelayFrom");
		int int_6 = gclass4_0.method_2("nudDelayTo");
		int num = 0;
		chrome_0.method_53();
		try
		{
			int num2 = chrome_0.method_50(int_4, f4960BA);
			int num3;
			do
			{
				chrome_0.method_12("https://www.facebook.com/pokes/?locale=en_US");
				chrome_0.F8091028(2.0);
				num3 = chrome_0.method_125();
			}
			while (num3 == 1);
			if (new List<int> { -3, -2, -1, 2 }.Contains(num3))
			{
				return -1;
			}
			int tickCount = Environment.TickCount;
			int num4 = 60;
			while (!Base.smethod_5() && Environment.TickCount - tickCount < num4 * 1000 && !chrome_0.CD930D04())
			{
				string text = chrome_0.method_15(5.0, new List<string> { "//*[contains(@aria-label, \"Poke\") and not(contains(@aria-label, \"Poked\"))]", "//*[translate(text(), \"ABCDEFGHIJKLMNOPQRSTUVWXYZ\", \"abcdefghijklmnopqrstuvwxyz\")=\"no results\"]" });
				if (!(text == "") && !(text == "//*[translate(text(), \"ABCDEFGHIJKLMNOPQRSTUVWXYZ\", \"abcdefghijklmnopqrstuvwxyz\")=\"no results\"]"))
				{
					chrome_0.method_19(text);
					num++;
					method_131(int_3, F2123D1C + Language.GetValue("Đang") + $" {string_1} ({num}/{num2}), delay {{time}}s...", int_5, int_6);
					if (num < num2)
					{
						tickCount = Environment.TickCount;
						continue;
					}
					break;
				}
				break;
			}
		}
		catch
		{
		}
		chrome_0.method_54();
		return 1;
	}

	public int method_105(int int_3, string string_1, Chrome chrome_0, GClass4 FAAB10BC, string string_2 = "")
	{
		int int_4 = FAAB10BC.method_2("nudSoLuongFrom");
		int f4960BA = FAAB10BC.method_2("nudSoLuongTo");
		int int_5 = FAAB10BC.method_2("nudDelayFrom");
		int int_6 = FAAB10BC.method_2("nudDelayTo");
		int num = 0;
		chrome_0.method_53();
		try
		{
			int num2 = chrome_0.method_50(int_4, f4960BA);
			int num3;
			do
			{
				chrome_0.method_12("https://www.facebook.com/events/birthdays/?locale=en_US");
				chrome_0.F8091028(2.0);
				num3 = chrome_0.method_125();
			}
			while (num3 == 1);
			if (new List<int> { -3, -2, -1, 2 }.Contains(num3))
			{
				return -1;
			}
			int tickCount = Environment.TickCount;
			int num4 = 60;
			while (!Base.smethod_5() && Environment.TickCount - tickCount < num4 * 1000 && !chrome_0.CD930D04() && chrome_0.D7A424AE("[role=\"main\"] [role=\"textbox\"]", 5.0))
			{
				chrome_0.method_20("[role=\"main\"] [role=\"textbox\"]");
				chrome_0.F217FA96("[role=\"main\"] [role=\"textbox\"]");
				chrome_0.F8091028(2.0);
				if (chrome_0.method_33("[role=\"main\"] [method=\"POST\"] [aria-label=\"Loading...\"][role=\"status\"]", 60))
				{
					num++;
					method_131(int_3, string_1 + Language.GetValue("Đang") + $" {string_2} ({num}/{num2}), delay {{time}}s...", int_5, int_6);
					if (num >= num2)
					{
						return 1;
					}
					tickCount = Environment.TickCount;
				}
			}
		}
		catch
		{
		}
		chrome_0.method_54();
		return 1;
	}

	public int D8B8D010(int int_3, string F809C891, Chrome B22AE883, GClass4 B9063D90, string AFB06193, string EA84291F)
	{
		int minValue = B9063D90.method_2("nudSoLuongFrom");
		int num = B9063D90.method_2("nudSoLuongTo");
		int num2 = B9063D90.method_2("nudDelayFrom");
		int num3 = B9063D90.method_2("nudDelayTo");
		bool flag = B9063D90.method_3("ckbTuongTac");
		B9063D90.method_2("nudSoLuongBaiVietFrom");
		B9063D90.method_2("nudSoLuongBaiVietTo");
		B9063D90.method_3("ckbTuongTacLike");
		B9063D90.method_3("ckbTuongTacComment");
		List<string> list = B9063D90.method_1("txtComment");
		bool flag2 = B9063D90.method_3("ckbTuDongXoaUid");
		bool flag3 = B9063D90.method_3("ckbAddFriendApi");
		bool flag4 = false;
		int num4 = B9063D90.method_2("nudTimesWarning", 5);
		int num5 = 0;
		int num6 = 1;
		int num7 = 0;
		string text = "";
		if (list != null)
		{
			list = Commom.smethod_36(list);
		}
		List<string> list2 = new List<string>();
		if (!flag2)
		{
			list2 = C499BE3B(dictionary_0[EA84291F]);
		}
		try
		{
			if (!flag3 || (B22AE883.F5812DA8.StartsWith("EAAAAU") && CommonRequest.B4B29420(B22AE883.String_2, B22AE883.F5812DA8, B22AE883.method_9(), B22AE883.A3A32284, B22AE883.Int32_1)))
			{
				goto IL_017e;
			}
			B22AE883.F5812DA8 = B22AE883.method_88();
			if (!(B22AE883.F5812DA8 == ""))
			{
				method_134(int_3, "cToken", B22AE883.F5812DA8, "token");
				goto IL_017e;
			}
			goto end_IL_0102;
			IL_017e:
			int num8 = Base.rd.Next(minValue, num + 1);
			while (num7 < num8 && !Base.smethod_5())
			{
				if (flag4 || (EA84291F != "" && !flag2))
				{
					if (list2.Count != 0)
					{
						text = list2[Base.rd.Next(0, list2.Count)];
						list2.Remove(text);
						goto IL_0279;
					}
					break;
				}
				lock (dictionary_0)
				{
					if (dictionary_0[EA84291F].Count == 0)
					{
						break;
					}
					text = dictionary_0[EA84291F][Base.rd.Next(0, dictionary_0[EA84291F].Count)];
					dictionary_0[EA84291F].Remove(text);
					goto IL_0279;
				}
				IL_0279:
				if (flag3)
				{
					try
					{
						switch (Commom.smethod_85($"AddFriendByToken('{B22AE883.F5812DA8}','{text}','{B22AE883.A3A32284}',{B22AE883.Int32_1})"))
						{
						default:
							num5++;
							if (num5 >= num4)
							{
								break;
							}
							continue;
						case "checkpoint":
							break;
						case "fb_blocked":
							B22AE883.EE37E6A7 = true;
							break;
						case "true":
							num7++;
							if (num7 >= num8)
							{
								break;
							}
							method_131(int_3, F809C891 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", AFB06193, num7, num8, Language.GetValue("đợi")), num2, num3);
							num5 = 0;
							continue;
						}
					}
					catch
					{
						continue;
					}
					break;
				}
				while (true)
				{
					if (num6 != 0)
					{
						B22AE883.method_12("https://facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
					}
					else
					{
						B22AE883.method_12("https://m.facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
					}
					if (!B22AE883.D6BBEDA3())
					{
						int num9 = B22AE883.method_125();
						if (num9 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num9))
						{
							switch (B22AE883.method_61())
							{
							case 1:
							{
								B22AE883.GetURL();
								string string_ = "[aria-label^=\"Add \"], [aria-label^=\"Thêm bạn\"], [aria-label=\"Add friend\"], [aria-label=\"Thêm bạn bè\"], //div[@role=\"button\"][.//span[contains(text(),'Add Friend') or contains(text(),'Thêm bạn')]]";
								if (!B22AE883.D7A424AE(string_))
								{
									num9 = B22AE883.method_125();
									if (num9 == 1)
									{
										continue;
									}
									if (new List<int> { -3, -2, -1, 2 }.Contains(num9))
									{
										return -1;
									}
									break;
								}
								if (flag)
								{
									F12A6CA2(int_3, F809C891, B22AE883, B9063D90);
									if (num6 == 0)
									{
										B22AE883.method_12("https://m.facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
										B22AE883.method_69();
									}
									else
									{
										B22AE883.method_12("https://facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
									}
								}
								B22AE883.method_35(string_);
								B22AE883.method_45(2, 3);
								B22AE883.method_18(string_);
								B22AE883.method_45(1, 2);
								num5 = (B22AE883.method_118() ? (num5 + 1) : 0);
								if (num5 < num4)
								{
									num7++;
									method_130(int_3, F809C891 + Language.GetValue("Đang") + $" {AFB06193} ({num7}/{num8})...");
									if (B22AE883.CD930D04())
									{
										return -2;
									}
									string text4 = B22AE883.AFACE5B4();
									if (!text4.Contains("help/contact/571927962827151") && !text4.Contains("/communitystandards"))
									{
										if (num7 < num8)
										{
											method_130(int_3, F809C891 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", AFB06193, num7, num8, Language.GetValue("đợi")), Base.rd.Next(num2, num3 + 1));
											break;
										}
									}
									else
									{
										B22AE883.EE37E6A7 = true;
									}
								}
								goto end_IL_0102;
							}
							case 2:
							{
								string text2 = B22AE883.method_15(5.0, new List<string> { "a[href*=\"friends/profile_add_friend\"]", "a[href*=\"friends/profile/add\"]" });
								if (!(text2 != ""))
								{
									num9 = B22AE883.method_125();
									if (num9 == 1)
									{
										continue;
									}
									if (new List<int> { -3, -2, -1, 2 }.Contains(num9))
									{
										return -1;
									}
									break;
								}
								bool flag5 = false;
								try
								{
									flag5 = !Convert.ToBoolean(B22AE883.method_14("var x=document.querySelector('[data-sigil=\"add-friend hq-profile-logging-action-bar-button\"]').getAttribute('style')+''; return x.includes('display:none')+''").ToString());
								}
								catch
								{
								}
								if (!flag5)
								{
									break;
								}
								if (flag)
								{
									F12A6CA2(int_3, F809C891, B22AE883, B9063D90);
									if (num6 == 0)
									{
										B22AE883.method_12("https://m.facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
										B22AE883.method_69();
									}
									else
									{
										B22AE883.method_12("https://facebook.com/" + (Commom.smethod_45(text) ? ("profile.php?id=" + text) : text));
									}
								}
								B22AE883.method_20(text2);
								B22AE883.method_18(text2);
								B22AE883.method_45(1, 2);
								num5 = (B22AE883.method_118() ? (num5 + 1) : 0);
								if (num5 < num4)
								{
									num7++;
									method_130(int_3, F809C891 + Language.GetValue("Đang") + $" {AFB06193} ({num7}/{num8})...");
									if (B22AE883.CD930D04())
									{
										return -2;
									}
									string text3 = B22AE883.AFACE5B4();
									if (!text3.Contains("help/contact/571927962827151"))
									{
										if (num7 < num8)
										{
											method_131(int_3, F809C891 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", AFB06193, num7, num8, Language.GetValue("đợi")), num2, num3);
											break;
										}
									}
									else
									{
										B22AE883.EE37E6A7 = true;
									}
								}
								goto end_IL_0102;
							}
							}
							break;
						}
						return -1;
					}
					return -4;
				}
			}
			end_IL_0102:;
		}
		catch (Exception ex)
		{
			Commom.smethod_58(null, ex.ToString());
			num7 = -1;
		}
		return num7;
	}

	public int FF885FA2(int int_3, string string_1, Chrome chrome_0, int EC0BD30E, int int_4, int int_5, int int_6, string string_2)
	{
		int num = 0;
		bool flag = false;
		try
		{
			int num2 = 0;
			int num3 = 5;
			int num5 = Base.rd.Next(EC0BD30E, int_4 + 1);
			if (num5 <= 0)
			{
				return 0;
			}
			chrome_0.method_12("https://www.facebook.com/", FC3A841F: true);
			chrome_0.F8091028(3.0);
			int item = chrome_0.method_125();
			if (new List<int> { -3, -2, -1, 2 }.Contains(item))
			{
				return -1;
			}
			flag = true;
			chrome_0.method_53();
			chrome_0.method_60();

			method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2}({num + 1}/{num5})...");

			int tickCount = Environment.TickCount;
			int maxTimeoutSec = 180;
			int consecutiveScrolls = 0;

			while (num < num5 && Environment.TickCount - tickCount <= maxTimeoutSec * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				item = chrome_0.method_125();
				if (new List<int> { -3, -2, -1, 2 }.Contains(item))
			{
					return -1;
				}

				string jsClick = @"(() => {
					try {
						var btns = document.querySelectorAll('div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Thêm bạn"" i], div[aria-label=""Add friend"" i], div[aria-label=""Add Friend"" i], [role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], button[aria-label*=""Thêm bạn"" i], button[aria-label*=""Add friend"" i]');
						for (var i = 0; i < btns.length; i++) {
							var b = btns[i];
							if (b.getAttribute('data-kc-feed-done') === '1') continue;
							var rect = b.getBoundingClientRect();
							if (rect.width > 0 && rect.height > 0) {
								b.setAttribute('data-kc-feed-done', '1');
								b.scrollIntoView({ behavior: 'smooth', block: 'center' });
								b.click();
								return 'clicked';
							}
						}

						var allBtns = document.querySelectorAll('[role=""button""], button');
						for (var j = 0; j < allBtns.length; j++) {
							var el = allBtns[j];
							if (el.getAttribute('data-kc-feed-done') === '1') continue;
							var t = (el.innerText || '').trim().toLowerCase();
							if (t === 'thêm bạn bè' || t === 'thêm bạn' || t === 'add friend') {
								el.setAttribute('data-kc-feed-done', '1');
								el.scrollIntoView({ behavior: 'smooth', block: 'center' });
								el.click();
								return 'clicked';
							}
						}

						return 'not_found';
					} catch (e) {
						return 'error: ' + e.message;
					}
				})()";

				string clickRes = chrome_0.method_14("return " + jsClick + ";");
				if (clickRes == "clicked")
				{
					consecutiveScrolls = 0;
					chrome_0.F8091028(1.0);

					if (chrome_0.method_118())
					{
						num2++;
						if (num2 >= num3)
						{
							break;
						}
					}
					else
					{
						num++;
						method_131(int_3, string_1 + Language.GetValue("Đang") + $" {string_2}({num}/{num5}), delay {{time}}s...", int_5, int_6);
						if (num >= num5)
						{
							break;
						}
						method_130(int_3, string_1 + Language.GetValue("Đang") + $" {string_2}({num + 1}/{num5})...");
						tickCount = Environment.TickCount;
					}
				}
				else
				{
					consecutiveScrolls++;
					if (consecutiveScrolls >= 8)
					{
						break;
					}
					chrome_0.method_14("window.scrollBy(0, 800);");
					chrome_0.F8091028(2.5);
				}
			}
		}
		catch
		{
			num = -1;
		}
		if (flag)
		{
			chrome_0.method_54();
		}
		return num;
	}

	public int method_106(int F7A45986, string string_1, Chrome chrome_0, GClass4 gclass4_0, string B21DFD8D, string string_2)
	{
		int minValue = gclass4_0.method_2("nudSoLuongFrom");
		int num = gclass4_0.method_2("nudSoLuongTo");
		int int_ = gclass4_0.method_2("nudDelayFrom");
		int int_2 = gclass4_0.method_2("nudDelayTo");
		int num2 = gclass4_0.method_2("cbbTuyChon");
		bool flag = gclass4_0.method_3("ckbTuDongXoaUid");
		List<string> list = null;
		list = ((num2 != 1) ? chrome_0.method_57() : gclass4_0.method_1("txtUid"));
		int num3 = 0;
		int num4 = Base.rd.Next(minValue, num + 1);
		List<int> list2 = new List<int>();
		string text = "";
		int num5 = 3;
		try
		{
			if (!flag)
			{
				text = list[Base.rd.Next(0, list.Count)];
				list.Remove(text);
				goto IL_012e;
			}
			lock (DE0D9D90)
			{
				if (DE0D9D90[string_2].Count != 0)
				{
					text = DE0D9D90[string_2].smethod_8();
					DE0D9D90[string_2].Remove(text);
					goto IL_012e;
				}
			}
			goto end_IL_009e;
			IL_012e:
			chrome_0.method_53();
			int num6;
			do
			{
				chrome_0.method_12("https://www.facebook.com/" + text + "/friends?locale=en_US");
				chrome_0.F8091028(2.0);
				num6 = chrome_0.method_125();
			}
			while (num6 == 1);
			if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
			{
				return -1;
			}
			method_130(F7A45986, string_1 + Language.GetValue("Đang") + $" {B21DFD8D} ({num3 + 1}/{num4})");
			int tickCount = Environment.TickCount;
			int num7 = 30;
			while (Environment.TickCount - tickCount <= num7 * 1000 && !Base.smethod_5() && !chrome_0.CD930D04())
			{
				string text2 = chrome_0.method_15(0.0, new List<string> { "[aria-label=\"Add friend\"]:not(:has(img[src]))" });
				string text3 = text2;
				string text4 = text3;
				if (!(text4 == "[aria-label=\"Add friend\"]:not(:has(img[src]))"))
				{
					int num8 = chrome_0.method_30("[aria-label=\"Cancel request\"]:not(:has(img[src]))");
					if (num8 > 0)
					{
						chrome_0.method_20($"[aria-label=\"Cancel request\"]:not(:has(img[src]))|{num8 - 1}", 5);
					}
				}
				else if (chrome_0.method_118())
				{
					num3--;
					if (list2.Count != 0 && list2.Last() != num3)
					{
						list2.Clear();
					}
					list2.Add(num3);
					if (list2.Count >= num5)
					{
						break;
					}
				}
				else
				{
					chrome_0.method_19(text2);
					method_131(F7A45986, string_1 + Language.GetValue("Đang") + $" {B21DFD8D} ({num3 + 1}/{num4}), delay {{time}}s...", int_, int_2);
					num3++;
					if (num3 >= num4)
					{
						break;
					}
					method_130(F7A45986, string_1 + Language.GetValue("Đang") + $" {B21DFD8D} ({num3 + 1}/{num4})...");
					tickCount = Environment.TickCount;
				}
				chrome_0.F8091028(2.0);
			}
			end_IL_009e:;
		}
		catch
		{
		}
		chrome_0.method_54();
		return num3;
	}

	public int method_107(int int_3, string string_1, Chrome C5B28206, GClass4 gclass4_0, string string_2 = "", string A32AF52F = "")
	{
		int int_4 = gclass4_0.method_2("nudSoLuongFrom");
		int f4960BA = gclass4_0.method_2("nudSoLuongTo");
		int int_5 = gclass4_0.method_2("nudDelayFrom");
		int int_6 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
		List<string> list = gclass4_0.method_1("txtCauTraLoi");
		int num = gclass4_0.method_2("cbbCauTraLoi");
		bool flag2 = gclass4_0.method_3("ckbTuDongXoaUid");
		int num2 = 0;
		List<string> list2 = new List<string>();
		if (!flag2)
		{
			list2 = C499BE3B(DAB1D692[A32AF52F]);
		}
		bool flag4 = false;
		try
		{
			int num3 = C5B28206.method_50(int_4, f4960BA);
			string text = "";
			int num4 = 0;
			while (num4 < num3)
			{
				if (A32AF52F != "" && !flag2)
				{
					if (list2.Count != 0)
					{
						text = list2.smethod_8();
						list2.Remove(text);
						goto IL_0168;
					}
					break;
				}
				lock (DAB1D692)
				{
					if (DAB1D692[A32AF52F].Count == 0)
					{
						break;
					}
					text = DAB1D692[A32AF52F].smethod_8();
					DAB1D692[A32AF52F].Remove(text);
					goto IL_0168;
				}
				IL_0168:
				method_130(int_3, string_1 + $"Đang {string_2} ({num2 + 1}/{num3})...");
				bool flag5 = false;
				while (true)
				{
					C5B28206.method_12(C5B28206.GetLinkFromId(text, "https://www.facebook.com/groups"), FC3A841F: true);
					C5B28206.F8091028(2.0);
					int num5 = C5B28206.method_125();
					if (num5 == 1)
					{
						continue;
					}
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
					{
						if (C5B28206.D6BBEDA3())
						{
							break;
						}
						if (!C5B28206.D7A424AE("[href$=\"facebook.com/help\"]"))
						{
							if (!flag4)
							{
								flag4 = true;
								C5B28206.method_53();
								C5B28206.method_60();
							}
							if (num == 0)
							{
								list = GClass13.smethod_1(list);
							}

							string paramJson = $"[{{\"name\":\"isAnswer\", \"value\":\"{flag}\", \"type\":\"bool\"}},{{\"name\":\"answer\", \"value\":\"{string.Join("\\n", list).Replace("\"", "\\\"")}\", \"type\":\"text\"}}]";
							string resultJson = FacebookGroupFriendHub.Execute(C5B28206, "JoinGroupWWW", paramJson);
							bool success = false;
						try
							{
								JObject jObj = JObject.Parse(resultJson);
								success = Convert.ToBoolean(jObj["success"]);
								if (!success && jObj["error"]?.ToString() == "fb_blocked")
								{
									C5B28206.EE37E6A7 = true;
									break;
								}
							}
							catch { }

							if (success)
							{
								flag5 = true;
							}
							else
							{
								string text2 = C5B28206.method_103(flag, list);
								flag5 = (text2 == "success" || text2 == "pending");
							}

							if (flag5)
							{
								num2++;
								if (num2 >= num3)
								{
									break;
								}
								method_131(int_3, string_1 + $"Đang {string_2} ({num2}/{num3}), delay {{time}}s...", int_5, int_6);
								if (C5B28206.CD930D04())
								{
									return -2;
								}
							}
						}
						num4++;
						goto IL_041f;
					}
					return -1;
				}
				break;
				IL_041f:;
			}
		}
		catch
		{
			num2 = -1;
		}
		if (flag4)
		{
			C5B28206.method_54();
		}
		return num2;
	}

	private void method_110(Chrome chrome_0, List<string> list_5, int int_3)
	{
		List<string> list = C499BE3B(list_5);
		int num = Convert.ToInt32(chrome_0.method_14("return document.querySelectorAll('textarea').length").ToString());
		if (num > 0)
		{
			for (int i = 2; i < num + 2; i++)
			{
				if (list.Count == 0)
				{
					list = C499BE3B(list_5);
				}
				string text = "";
				text = ((int_3 != 0) ? list.First() : list.smethod_8());
				list.Remove(text);
				chrome_0.method_22("#root > div > div > div:nth-child(2) > div:nth-child(" + i + ") > div > textarea", text);
				chrome_0.F8091028(2.0);
			}
		}
		chrome_0.method_18("[use=\"primary\"]");
		chrome_0.F8091028(2.0);
		chrome_0.method_13();
	}

	public int method_111(int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2 = "", string string_3 = "")
	{
		return PersonalInteractionHelper.InteractReelRandom(this, int_3, string_1, chrome_0, gclass4_0, string_2, string_3);
	}

	public int method_112(int int_3, string A3248B14, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "", string string_2 = "")
	{
		return PersonalInteractionHelper.InteractReelSpecific(this, int_3, A3248B14, chrome_0, gclass4_0, string_1, string_2);
	}

	private void method_113(string string_1)
	{
		Invoke((MethodInvoker)delegate
		{
			try
			{
				if (string_1 == "start")
				{
					plQuanLyThuMuc.Enabled = false;
					btnInteract.Image = null;
					btnInteract.Text = "⏹  " + Language.GetValue("Dừng Tương Tác");
					btnInteract.BackColor = ModernUITheme.Danger;
					EAB09F19.smethod_0(F5325785, bool_0: false);
				}
				else if (string_1 == "stop")
				{
					btnInteract.Text = "▶  " + Language.GetValue("Chạy Tương Tác");
					plQuanLyThuMuc.Enabled = true;
					btnInteract.Image = null;
					btnInteract.BackColor = ModernUITheme.Primary;
					btnInteract.Enabled = true;
					EAB09F19.smethod_0(F5325785, bool_0: true);
				}
			}
			catch (Exception)
			{
			}
		});
	}

	private void F5325785_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyValue == 32)
		{
			method_4("ToggleCheck");
		}
	}

	private void method_114(string C28C1D3A)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(F6061E95(i, "cChose")))
				{
					list.Add(F6061E95(i, "cId"));
				}
			}
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n ta\u0300i khoa\u0309n câ\u0300n câ\u0323p nhâ\u0323t!", 3);
			}
			else
			{
				Commom.smethod_35(new fUpdateData(this, C28C1D3A));
			}
		}
		catch
		{
		}
	}

	private void uidUpdateToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_114("UID");
	}

	private void BCB71D80(object sender, EventArgs e)
	{
		method_114("Password");
	}

	private void method_115(object sender, EventArgs e)
	{
		method_114("Token");
	}

	private void C698B335_Click(object sender, EventArgs e)
	{
		method_114("Cookie");
	}

	private void toolStripMenuItem_12_Click(object sender, EventArgs e)
	{
		method_114("Mail|pass");
	}

	private void BC007112_Click(object sender, EventArgs e)
	{
		method_114("2FA");
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		E48D7F88(null, null);
	}

	private void DF154C84(object sender, EventArgs e)
	{
		int selectedIndex = D38F4B00.SelectedIndex;
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có thực sự muốn xóa thư mục [{0}] không?"), D38F4B00.Text)) == DialogResult.Yes)
		{
			if (CommonSQL.smethod_4(D38F4B00.SelectedValue.ToString()))
			{
				MsBoxHelper.Show(string.Format(Language.GetValue("Xoá thành công thư mục [{0}] !"), D38F4B00.Text));
				C5A7879A();
				D38F4B00.SelectedIndex = selectedIndex - 1;
			}
			else
			{
				MsBoxHelper.Show(string.Format(Language.GetValue("Không thể xóa thư mục [{0}] !"), D38F4B00.Text), 2);
			}
		}
	}

	private void C326FB11(object sender, EventArgs e)
	{
		if (!bool_0 || D38F4B00.SelectedValue == null || !B7059719.smethod_0(D38F4B00.SelectedValue.ToString()) || (D38F4B00.SelectedValue.ToString() != "999999" && int_1 == D38F4B00.SelectedIndex))
		{
			return;
		}
		string text = D38F4B00.SelectedValue.ToString();
		string text2 = text;
		if (!(text2 == "-2"))
		{
			if (!(text2 == "999999"))
			{
				method_1(DC234E98());
			}
			else
			{
				Commom.smethod_35(new fChonThuMuc());
				if (!fChonThuMuc.D3160788 || fChonThuMuc.list_0 == null || fChonThuMuc.list_0.Count == 0)
				{
					bool_0 = false;
					D38F4B00.SelectedIndex = ((int_1 == -1) ? 1 : int_1);
					bool_0 = true;
				}
				else
				{
					method_1(fChonThuMuc.list_0);
				}
			}
		}
		else
		{
			method_1();
		}
		int_1 = D38F4B00.SelectedIndex;
		if (D38F4B00.SelectedValue != null)
		{
			string text3 = D38F4B00.SelectedValue.ToString();
			if (text3 == "-2" || text3 == "999999")
			{
				D1117A83.BackColor = Color.Gray;
				D1117A83.Enabled = false;
				btnEditFile.BackColor = Color.Gray;
				btnEditFile.Enabled = false;
			}
			else
			{
				D1117A83.BackColor = Color.White;
				D1117A83.Enabled = true;
				btnEditFile.BackColor = Color.White;
				btnEditFile.Enabled = true;
			}
		}
	}

	private void mailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_5("cEmail|cPassMail");
	}

	private void BD963BA5(object sender, EventArgs e)
	{
		method_5("cUid|cPassword|cToken|cCookies|cEmail|cPassMail");
	}

	private void method_116()
	{
		try
		{
			lblCountTotal.Text = F5325785.Rows.Count.ToString();
		}
		catch
		{
		}
	}

	private void EA1B25A9(int C4099AA9 = -1)
	{
		if (C4099AA9 == -1)
		{
			C4099AA9 = 0;
			for (int i = 0; i < F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					C4099AA9++;
				}
			}
		}
		lblCountSelect.Text = C4099AA9.ToString();
	}

	private void method_117(int D48CED93, bool bool_5 = false)
	{
		int int_0 = 0;
		int B30C5AB0 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		C5034B95.smethod_0("configGeneral").BDB80B23("token");
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count && !Base.smethod_5())
			{
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < B30C5AB0)
					{
						Interlocked.Increment(ref int_0);
						int F033159D = num++;
						new Thread((ThreadStart)delegate
						{
							method_130(F033159D, Language.GetValue("Đang kiểm tra..."));
							switch (D48CED93)
							{
							case 0:
								method_119(F033159D);
								break;
							case 1:
								method_120(F033159D);
								break;
							case 2:
								B2317F09(F033159D);
								break;
							case 3:
								B2B2C61C(F033159D);
								break;
							case 4:
								method_118(F033159D);
								break;
							case 5:
								C8B71080(F033159D, bool_5);
								break;
							case 6:
								method_121(F033159D, bool_5);
								break;
							case 7:
								F7957618(F033159D);
								break;
							}
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				else
				{
					num++;
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 60000)
			{
				Commom.smethod_52(1.0);
			}
			method_113("stop");
		}).Start();
	}

	private void C8B71080(int E62BE09C, bool bool_5)
	{
		try
		{
			string e72FDB9E = F6061E95(E62BE09C, "cId");
			string fE2ED = F6061E95(E62BE09C, "cUid");
			if (string.IsNullOrWhiteSpace(fE2ED))
			{
				method_130(E62BE09C, Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
				return;
			}
			string text = "";
			int num = 0;
			if (bool_5)
			{
				text = F6061E95(E62BE09C, "cProxy");
				num = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			method_130(E62BE09C, "Check profile...");
			FbProfileChecker.ProfileResult profileResult = FbProfileChecker.CheckProfile(fE2ED, text, num);
			if (profileResult.Success && profileResult.IsLive)
			{
				string text4 = profileResult.Name;
				CommonSQL.smethod_9(e72FDB9E, "name|avatar", text4 + "|Yes", bool_0: false);
				CommonSQL.B8A0E617(e72FDB9E, "info", "Live");
				B183E907(E62BE09C, "cName", text4, DE3B4487: false);
				B183E907(E62BE09C, "cAvatar", "Yes", DE3B4487: false);
				E589F93F(E62BE09C, "Live");
				method_130(E62BE09C, "Live - " + text4);
				try
				{
					if (F5325785.Columns.Contains("cAvatar"))
					{
						F5325785.InvalidateCell(F5325785.Columns["cAvatar"].Index, E62BE09C);
					}
				}
				catch { }
			}
			else if (profileResult.Success && !profileResult.IsLive)
			{
				CommonSQL.B8A0E617(e72FDB9E, "info", "Die");
				E589F93F(E62BE09C, "Die");
				method_130(E62BE09C, Language.GetValue("Tài khoản Die!"));
			}
			else
			{
				method_130(E62BE09C, Language.GetValue("Không check đươ\u0323c!"));
			}
		}
		catch
		{
			method_130(E62BE09C, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_118(int int_3)
	{
		try
		{
			string text = F6061E95(int_3, "cEmail");
			string text2 = F6061E95(int_3, "cPassMail");
			string text3 = F6061E95(int_3, "cOAuth2");
			if (text == "" || text2 == "")
			{
				method_130(int_3, Language.GetValue("Không tìm thấy mail!"));
			}
			else if (FB93BDA4.CheckHotmail9(text))
			{
				if (MaxCareLibPro.Hotmail9.GetTokenHotmail9(text, text2) != "")
				{
					method_130(int_3, Language.GetValue("Success!"));
					C412B9A5(int_3, 2);
				}
				else
				{
					method_130(int_3, Language.GetValue("Fail!"));
					C412B9A5(int_3, 1);
				}
			}
			else if (D831098B.FFA1D7B5(text, text2, text3))
			{
				method_130(int_3, Language.GetValue("Success!"));
				C412B9A5(int_3, 2);
			}
			else
			{
				method_130(int_3, Language.GetValue("Fail!"));
				C412B9A5(int_3, 1);
			}
		}
		catch (Exception)
		{
			method_130(int_3, Language.GetValue("Lỗi!"));
		}
	}

	private void F7957618(int F314E620)
	{
		try
		{
			string text = F6061E95(F314E620, "cName");
			string text2 = "";
			text2 = ((text.Trim() == "") ? Language.GetValue("Không tìm thấy tên!") : ((!Commom.D9AB3B82(text)) ? Language.GetValue("No") : Language.GetValue("Yes")));
			method_130(F314E620, text2);
		}
		catch
		{
			method_130(F314E620, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_119(int int_3)
	{
		try
		{
			F6061E95(int_3, "cId");
			string string_ = F6061E95(int_3, "cUid");
			if (!Commom.IsUid(string_))
			{
				method_130(int_3, Language.GetValue("Uid không hợp lệ!"));
				return;
			}
			string text = "";
			string text2 = "";
			string text3 = CommonRequest.BC9215A7(string_);
			if (text3.StartsWith("0|"))
			{
				text = "Die";
				text2 = "Wall die";
			}
			else if (text3.StartsWith("1|"))
			{
				text = "Live";
				text2 = "Wall live";
			}
			else
			{
				text2 = Language.GetValue("Không check được!");
			}
			method_130(int_3, text2);
			if (text != "")
			{
				E589F93F(int_3, text);
			}
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_120(int int_3)
	{
		try
		{
			string text = "";
			F6061E95(int_3, "cId");
			string e6A0553B = F6061E95(int_3, "cCookies");
			string text2 = F6061E95(int_3, "cToken");
			if (text2.Trim() == "")
			{
				method_130(int_3, Language.GetValue("Token trô\u0301ng!"));
				return;
			}
			string string_ = F6061E95(int_3, "cUseragent").Trim();
			(string proxy, int typeProxy) tuple = F0B30129(int_3);
			string item = tuple.proxy;
			int item2 = tuple.typeProxy;
			string text3 = "";
			if (!CommonRequest.B4B29420(e6A0553B, text2, string_, item, item2))
			{
				text3 = "Token die";
			}
			else
			{
				text = "Live";
				text3 = "Token live";
			}
			method_130(int_3, text3);
			if (text != "")
			{
				E589F93F(int_3, text);
			}
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void B2317F09(int int_3)
	{
		try
		{
			string text = "";
			F6061E95(int_3, "cId");
			string text2 = F6061E95(int_3, "cCookies");
			if (text2.Trim() == "")
			{
				method_130(int_3, Language.GetValue("Cookie trô\u0301ng!"));
				return;
			}
			string string_ = F6061E95(int_3, "cUseragent").Trim();
			(string proxy, int typeProxy) tuple = F0B30129(int_3);
			string item = tuple.proxy;
			int item2 = tuple.typeProxy;
			string text3 = "";
			if (!CommonRequest.smethod_0(text2, string_, item, item2).StartsWith("1|"))
			{
				text3 = "Cookie die";
			}
			else
			{
				text = "Live";
				text3 = "Cookie live";
			}
			method_130(int_3, text3);
			if (text != "")
			{
				E589F93F(int_3, text);
			}
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private (string proxy, int typeProxy) F0B30129(int E4AB08B4)
	{
		string raw = F6061E95(E4AB08B4, "cProxy").Trim();
		ProxyInfo p = ProxyHelper.Parse(raw);
		if (p.IsValid)
		{
			return (p.ToCleanString(), p.ProxyType);
		}
		return ("", 0);
	}

	private void B2B2C61C(int FF893E01)
	{
		string text = F6061E95(FF893E01, "cCookies");
		if (text.Trim() == "")
		{
			method_130(FF893E01, Language.GetValue("Cookie trô\u0301ng!"));
			return;
		}
		var (string_, d1B1C) = F0B30129(FF893E01);
		method_130(FF893E01, Language.GetValue("Checking..."));
		method_28(FF893E01, "", text, string_, d1B1C);
	}

	private void E7899D3A(object sender, EventArgs e)
	{
		method_117(0);
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC("Tính năng này có thể khiến tài khoản bị khóa, bạn vẫn muốn sử dụng?") != DialogResult.No)
		{
			method_117(1);
		}
	}

	private void FCA02421(object sender, EventArgs e)
	{
		method_117(3);
	}

	private void mailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_5("cEmail");
	}

	private void BtnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (cbbSearch.SelectedIndex == -1)
			{
				MsBoxHelper.Show("Vui lòng chọn kiểu tìm kiếm!", 3);
				return;
			}
			string columnName = cbbSearch.SelectedValue.ToString();
			string text = txbSearch.Text.Trim();
			if (text == "")
			{
				MsBoxHelper.Show("Vui lòng nhập nội dung tìm kiếm!", 3);
				return;
			}
			List<int> list = new List<int>();
			text = Commom.EB835717(text.ToLower());
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				string text2 = F5325785.Rows[i].Cells[columnName].Value.ToString();
				text2 = Commom.EB835717(text2.ToLower());
				text = Commom.EB835717(text.ToLower());
				if (text2.Contains(text))
				{
					list.Add(i);
				}
			}
			int index = 0;
			int num = -1;
			try
			{
				num = F5325785.CurrentRow.Index;
			}
			catch
			{
				num = -1;
			}
			if (list.Count <= 0)
			{
				return;
			}
			if (num >= list[list.Count - 1])
			{
				index = 0;
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (num < list[j])
					{
						index = j;
						break;
					}
				}
			}
			int index2 = list[index];
			F5325785.CurrentCell = F5325785.Rows[index2].Cells[columnName];
			F5325785.ClearSelection();
			F5325785.Rows[index2].Selected = true;
		}
		catch (Exception)
		{
		}
	}

	private void uidPassTokenCookieMailPassMail2faToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			method_5("cUid|cPassword|cToken|cCookies|cEmail|cPassMail|cFa2");
		}
	}

	private void A4A0C627(object sender, EventArgs e)
	{
		Hide();
		C5034B95.smethod_0("settingLogin").method_4("UserName", "");
		C5034B95.smethod_0("settingLogin").method_4("PassWord", "");
		C5034B95.smethod_1("settingLogin");
		fActive fActive2 = new fActive("");
		fActive2.ShowInTaskbar = true;
		fActive2.ShowDialog();
	}

	private void AF952311()
	{
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			B183E907(i, "cSTT", i + 1);
		}
	}

	private void A60AECB8(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			method_5("cFa2");
		}
	}

	private void D090E13A(object sender, EventArgs e)
	{
		method_117(6);
	}

	private void method_121(int int_3, bool BF25A43C)
	{
		try
		{
			string text = "";
			int e3839A = 0;
			if (BF25A43C)
			{
				text = F6061E95(int_3, "cProxy");
				e3839A = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			string text2 = F5325785.Rows[int_3].Cells["cUid"].Value.ToString();
			if (string.IsNullOrWhiteSpace(text2))
			{
				method_130(int_3, Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
				return;
			}
			method_130(int_3, "Đang tải avatar...");
			FbProfileChecker.ProfileResult profileResult = FbProfileChecker.CheckProfile(text2, text, e3839A);
			if (profileResult.Success && profileResult.IsLive)
			{
				method_134(int_3, "cAvatar", "Yes", "avatar");
				if (!string.IsNullOrEmpty(profileResult.Name))
				{
					method_134(int_3, "cName", profileResult.Name, "name");
				}
				E589F93F(int_3, "Live");
				method_130(int_3, Language.GetValue("Đa\u0303 co\u0301 avatar!") + (string.IsNullOrEmpty(profileResult.Name) ? "" : (" (" + profileResult.Name + ")")));
				try
				{
					if (F5325785.Columns.Contains("cAvatar"))
					{
						F5325785.InvalidateCell(F5325785.Columns["cAvatar"].Index, int_3);
					}
				}
				catch { }
			}
			else if (profileResult.Success && !profileResult.IsLive)
			{
				method_134(int_3, "cAvatar", "No", "avatar");
				E589F93F(int_3, "Die");
				method_130(int_3, Language.GetValue("Tài khoản Die!"));
			}
			else
			{
				method_130(int_3, Language.GetValue("Không check được!"));
			}
		}
		catch
		{
			method_130(int_3, "Lỗi!");
		}
	}

	private void AF8C5B2B(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					string item = F6061E95(i, "cUid");
					if (list2.Contains(item))
					{
						list.Add(item);
					}
					else
					{
						list2.Add(item);
					}
				}
			}
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Không có tài khoản trùng nhau!");
				return;
			}
			List<string> list3 = Commom.smethod_30(list);
			DataTable dataTable = CommonSQL.FAACE83A(list3);
			dataTable.DefaultView.Sort = "uid ASC";
			dataTable = dataTable.DefaultView.ToTable();
			F5325785.Rows.Clear();
			method_3(dataTable);
		}
		catch (Exception)
		{
		}
	}

	private void toolStripMenuItem_13_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có chắc muốn xóa Profile của {0} tài khoản?"), method_128())) != DialogResult.Yes)
		{
			return;
		}
		int F917FAB3 = 0;
		int CE192F8D = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		if (Class59.ED081E86())
		{
			Dictionary<string, string> dictionary_0 = Class59.smethod_1();
			new Thread((ThreadStart)delegate
			{
				int num2 = 0;
				while (num2 < F5325785.Rows.Count)
				{
					if (!Convert.ToBoolean(F6061E95(num2, "cChose")))
					{
						num2++;
					}
					else if (F917FAB3 >= CE192F8D)
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
					else
					{
						Interlocked.Increment(ref F917FAB3);
						int CB1DA408 = num2++;
						new Thread((ThreadStart)delegate
						{
							method_130(CB1DA408, Language.GetValue("Đang xo\u0301a profile..."));
							string text = F5325785.Rows[CB1DA408].Cells["cUid"].Value.ToString();
							if (text.Trim() == "")
							{
								method_130(CB1DA408, Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
							}
							else
							{
								string text2 = (dictionary_0.ContainsKey(text) ? dictionary_0[text] : "");
								if (text2 == "")
								{
									method_130(CB1DA408, Language.GetValue("Chưa tạo profile!"));
								}
								else if (Class59.smethod_3(text2))
								{
									method_130(CB1DA408, Language.GetValue("Xóa profile thành công!"));
									method_134(CB1DA408, "cProfile", "No", "profile");
								}
								else
								{
									method_130(CB1DA408, Language.GetValue("Xóa profile thâ\u0301t ba\u0323i!"));
								}
							}
							Interlocked.Decrement(ref F917FAB3);
						}).Start();
					}
				}
			}).Start();
			return;
		}
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < F5325785.Rows.Count)
			{
				if (!Convert.ToBoolean(F6061E95(num, "cChose")))
				{
					num++;
				}
				else if (F917FAB3 >= CE192F8D)
				{
					Application.DoEvents();
					Thread.Sleep(200);
				}
				else
				{
					Interlocked.Increment(ref F917FAB3);
					int B1953E82 = num++;
					new Thread((ThreadStart)delegate
					{
						method_130(B1953E82, Language.GetValue("Đang xo\u0301a profile..."));
						A6200B8E(B1953E82);
						Interlocked.Decrement(ref F917FAB3);
					}).Start();
				}
			}
		}).Start();
	}

	private void A6200B8E(int F8A1DE3A)
	{
		try
		{
			string c5A80B = F5325785.Rows[F8A1DE3A].Cells["cId"].Value.ToString();
			string text = F5325785.Rows[F8A1DE3A].Cells["cUid"].Value.ToString();
			if (text.Trim() == "")
			{
				method_130(F8A1DE3A, Language.GetValue("Chưa tạo profile!"));
				return;
			}
			string path = C5034B95.smethod_2() + "\\" + text;
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
				method_130(F8A1DE3A, Language.GetValue("Xóa profile thành công!"));
				B183E907(F8A1DE3A, "cProfile", "No");
				CommonSQL.B8A0E617(c5A80B, "profile", "No");
			}
			else
			{
				method_130(F8A1DE3A, Language.GetValue("Chưa tạo profile!"));
			}
		}
		catch
		{
			method_130(F8A1DE3A, Language.GetValue("Xóa profile thất bại!"));
		}
	}

	private void checkProfileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int int_0 = 0;
		int CF13AB14 = 10;
		if (Class59.ED081E86())
		{
			List<string> list_0 = Class59.smethod_0();
			new Thread((ThreadStart)delegate
			{
				int num2 = 0;
				while (num2 < F5325785.RowCount)
				{
					if (!Convert.ToBoolean(F6061E95(num2, "cChose")))
					{
						num2++;
					}
					else if (int_0 >= CF13AB14)
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
					else
					{
						Interlocked.Increment(ref int_0);
						int BA99AE3A = num2++;
						new Thread((ThreadStart)delegate
						{
							method_130(BA99AE3A, "Check profile...");
							F6061E95(BA99AE3A, "cId");
							string text = F6061E95(BA99AE3A, "cUid");
							if (text == "")
							{
								method_130(BA99AE3A, Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
							}
							else if (list_0.Contains(text))
							{
								method_130(BA99AE3A, Language.GetValue("Đã có profile!"));
								method_134(BA99AE3A, "cProfile", "Yes", "profile");
							}
							else
							{
								method_130(BA99AE3A, Language.GetValue("Chưa tạo profile!"));
								method_134(BA99AE3A, "cProfile", "No", "profile");
							}
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
				}
			}).Start();
			return;
		}
		string AA05B7BD = C5034B95.smethod_2();
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < F5325785.RowCount)
			{
				if (!Convert.ToBoolean(F6061E95(num, "cChose")))
				{
					num++;
				}
				else if (int_0 >= CF13AB14)
				{
					Application.DoEvents();
					Thread.Sleep(200);
				}
				else
				{
					Interlocked.Increment(ref int_0);
					int int_ = num++;
					new Thread((ThreadStart)delegate
					{
						method_130(int_, "Check profile...");
						FFB24692(int_, AA05B7BD);
						Interlocked.Decrement(ref int_0);
					}).Start();
				}
			}
		}).Start();
	}

	private void FFB24692(int int_3, string string_1)
	{
		try
		{
			F6061E95(int_3, "cId");
			string text = F6061E95(int_3, "cUid");
			if (text == "")
			{
				method_130(int_3, Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
				return;
			}
			string_1 = string_1 + "\\" + text;
			if (Directory.Exists(string_1))
			{
				method_130(int_3, Language.GetValue("Đã có profile!"));
				method_134(int_3, "cProfile", "Yes", "profile");
			}
			else
			{
				method_130(int_3, Language.GetValue("Chưa tạo profile!"));
				method_134(int_3, "cProfile", "No", "profile");
			}
		}
		catch
		{
		}
	}

	private void CA31F826_Click(object sender, EventArgs e)
	{
		try
		{
			if (MsBoxHelper.D41C45AC("Ti\u0301nh năng na\u0300y se\u0303 xo\u0301a profile cu\u0309a như\u0303ng ta\u0300i khoa\u0309n không co\u0301 trên tool, ba\u0323n co\u0301 muô\u0301n tiê\u0301p tu\u0323c?") != DialogResult.No)
			{
				Commom.smethod_35(new fClearProfile());
			}
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show(ex.ToString(), 3);
		}
	}

	private void F62D3B92(object sender, EventArgs e)
	{
		Commom.KillProcess("chrome");
	}

	private void A2AD0898(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	private void C9B597B7(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			method_5("cUid|cPassword|cFa2");
		}
	}

	private void C72EAE3C_Click(object sender, EventArgs e)
	{
		GClass4 gclass4_ = new GClass4();
		Commom.smethod_35(new fCauHinhChung(ref gclass4_));
		if (gclass4_.method_3("isChangePathDatabase"))
		{
			C5A7879A(1);
			method_1(DC234E98());
		}
	}

	private void FB93C785(object sender, EventArgs e)
	{
		try
		{
			List<string> list = A838519C("cUid|cPassword|cToken|cCookies|cEmail|cEmail2|cPassMail|cFa2|cUseragent|cProxy|cName|cGender|cFollow|cFriend|cGroup|cBirthday|cDateCreateAcc|cGhiChu|cLocation|cMailRecovery|cPassMailRecovery|cInteractEnd|cDating|cAds|cBM|cHometown|cCurrentCity|cStatus|cWallPosts|cOAuth2");
			if (list.Count <= 0)
			{
				MsBoxHelper.Show("Vui lòng chọn danh sách tài khoản muốn copy thông tin!", 3);
			}
			else
			{
				Commom.smethod_35(new fCopy(list));
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "Error Copy");
		}
	}

	private void toolStripMenuItem_14_Click(object sender, EventArgs e)
	{
		method_5("cMa2Fa");
	}

	private void A921DA1B(object sender, EventArgs e)
	{
	}

	private void method_122(int int_3)
	{
		int int_4 = 0;
		int int_5 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		string D935E202 = C5034B95.smethod_0("configGeneral").BDB80B23("token");
		string string_0 = C5034B95.smethod_0("configGeneral").BDB80B23("cookie");
		if (int_3 == 0 && !CommonRequest.B4B29420(string_0, D935E202, "", ""))
		{
			string text = "";
			text = ((!CommonRequest.smethod_0(string_0, "", "", 0).StartsWith("1|")) ? "Cookie die!" : "Token die!");
			MsBoxHelper.Show(text, 3);
			return;
		}
		if (int_3 == 4 && CommonRequest.smethod_0(string_0, "", "", 0).StartsWith("0|"))
		{
			MsBoxHelper.Show("Vui lòng kiểm tra lại cookie trung gian!", 3);
			return;
		}
		Base.smethod_6(bool_9: false);
		bool C32CBF24 = false;
		bool CD034BBC = false;
		bool bool_0 = false;
		int ADB66E86 = 0;
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			switch (int_3)
			{
			case 0:
			{
				int num3 = 0;
				while (num3 < F5325785.Rows.Count && !Base.smethod_5())
				{
					if (Convert.ToBoolean(F5325785.Rows[num3].Cells["cChose"].Value))
					{
						if (int_4 < int_5)
						{
							Interlocked.Increment(ref int_4);
							int int_7 = num3++;
							new Thread((ThreadStart)delegate
							{
								method_130(int_7, Language.GetValue("Đang kiểm tra..."));
								if (!method_123(int_7, string_0, D935E202, bool_5: true))
								{
									Base.smethod_6(bool_9: true);
									C32CBF24 = true;
								}
								Interlocked.Decrement(ref int_4);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num3++;
					}
				}
				goto default;
			}
			case 1:
			{
				int num4 = 0;
				while (num4 < F5325785.Rows.Count && !Base.smethod_5())
				{
					if (!Convert.ToBoolean(F5325785.Rows[num4].Cells["cChose"].Value))
					{
						num4++;
						continue;
					}
					if (int_4 < int_5)
					{
						Interlocked.Increment(ref int_4);
						int int_6 = num4++;
						new Thread((ThreadStart)delegate
						{
							method_130(int_6, Language.GetValue("Đang kiểm tra..."));
							ADBD9516(int_6);
							Interlocked.Decrement(ref int_4);
						}).Start();
						continue;
					}
					if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") != 1 && C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") != 2)
					{
						Commom.smethod_52(1.0);
						continue;
					}
					while (int_4 > 0)
					{
						Commom.smethod_52(1.0);
					}
					if (Base.smethod_5())
					{
						break;
					}
					Interlocked.Increment(ref ADB66E86);
					if (ADB66E86 < Convert.ToInt32((C5034B95.smethod_0("configGeneral").BDB80B23("ip_nudChangeIpCount") == "") ? "1" : C5034B95.smethod_0("configGeneral").BDB80B23("ip_nudChangeIpCount")))
					{
						continue;
					}
					for (int j = 0; j < 3; j++)
					{
						bool_0 = Commom.smethod_59(C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"), C5034B95.smethod_0("configGeneral").method_2("typeDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink"), C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN"));
						if (bool_0)
						{
							break;
						}
					}
					if (bool_0)
					{
						ADB66E86 = 0;
						continue;
					}
					goto IL_036c;
				}
				goto default;
			}
			case 2:
			{
				int num2 = 0;
				while (num2 < F5325785.Rows.Count && !Base.smethod_5())
				{
					if (!Convert.ToBoolean(F5325785.Rows[num2].Cells["cChose"].Value))
					{
						num2++;
						continue;
					}
					if (int_4 < int_5)
					{
						Interlocked.Increment(ref int_4);
						int int_8 = num2++;
						new Thread((ThreadStart)delegate
						{
							method_130(int_8, Language.GetValue("Đang kiểm tra..."));
							method_124(int_8);
							Interlocked.Decrement(ref int_4);
						}).Start();
						continue;
					}
					if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") != 1 && C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") != 2)
					{
						Commom.smethod_52(1.0);
						continue;
					}
					while (int_4 > 0)
					{
						Commom.smethod_52(1.0);
					}
					if (Base.smethod_5())
					{
						break;
					}
					Interlocked.Increment(ref ADB66E86);
					if (ADB66E86 < Convert.ToInt32((C5034B95.smethod_0("configGeneral").BDB80B23("ip_nudChangeIpCount") == "") ? "1" : C5034B95.smethod_0("configGeneral").BDB80B23("ip_nudChangeIpCount")))
					{
						continue;
					}
					for (int i = 0; i < 3; i++)
					{
						bool_0 = Commom.smethod_59(C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"), C5034B95.smethod_0("configGeneral").method_2("typeDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink"), C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN"));
						if (bool_0)
						{
							break;
						}
					}
					if (bool_0)
					{
						ADB66E86 = 0;
						continue;
					}
					goto IL_05e7;
				}
				goto default;
			}
			case 4:
			{
				int num = 0;
				while (num < F5325785.Rows.Count && !Base.smethod_5())
				{
					if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
					{
						if (int_4 < int_5)
						{
							Interlocked.Increment(ref int_4);
							int D0831D2B = num++;
							new Thread((ThreadStart)delegate
							{
								method_130(D0831D2B, Language.GetValue("Đang kiểm tra..."));
								if (!EC31B39A(D0831D2B, string_0))
								{
									Base.smethod_6(bool_9: true);
									CD034BBC = true;
								}
								Interlocked.Decrement(ref int_4);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				goto default;
			}
			default:
				{
					int tickCount = Environment.TickCount;
					while (int_4 > 0 && Environment.TickCount - tickCount <= 60000)
					{
						Commom.smethod_52(1.0);
					}
					break;
				}
				IL_036c:
				MsBoxHelper.Show("Không thê\u0309 đô\u0309i ip!", 3);
				break;
				IL_05e7:
				MsBoxHelper.Show("Không thê\u0309 đô\u0309i ip!", 3);
				break;
			}
			method_113("stop");
			if (C32CBF24)
			{
				MsBoxHelper.Show("Token trung gian die!");
			}
			if (CD034BBC)
			{
				MsBoxHelper.Show("Cookie trung gian die!");
			}
		}).Start();
	}

	private bool method_123(int int_3, string string_1, string string_2, bool bool_5)
	{
		try
		{
			string e72FDB9E = F6061E95(int_3, "cId");
			string text = F6061E95(int_3, "cUid");
			string string_3 = F6061E95(int_3, "cUseragent").Trim();
			var (string_4, num) = F0B30129(int_3);
			if (bool_5)
			{
				string_3 = "";
				string_4 = "";
				num = 0;
			}
			string text2 = "";
			string text3 = "";
			if (text == "")
			{
				text3 = Language.GetValue("Không co\u0301 uid!");
			}
			else
			{
				string text4 = CommonRequest.smethod_9(string_1, string_2, text, string_3, string_4, num);
				if (text4 == "-1")
				{
					method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
					return false;
				}
				string[] array = text4.Split('|');
				if (Convert.ToBoolean(array[0]))
				{
					text2 = "Live";
					CommonSQL.smethod_9(e72FDB9E, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
					B183E907(int_3, "cName", array[1]);
					B183E907(int_3, "cGender", array[2]);
					B183E907(int_3, "cBirthday", array[3]);
					if (array[5] != "")
					{
						B183E907(int_3, "cEmail", array[5]);
					}
					B183E907(int_3, "cFriend", array[6]);
					B183E907(int_3, "cGroup", array[7]);
					text3 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
				}
				else
				{
					text2 = "Die";
					text3 = Language.GetValue("Tài khoản die!");
				}
			}
			method_130(int_3, text3);
			if (text2 != "")
			{
				E589F93F(int_3, text2);
			}
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
		return true;
	}

	private void method_124(int int_3)
	{
		try
		{
			string e72FDB9E = F6061E95(int_3, "cId");
			string text = F6061E95(int_3, "cCookies");
			F6061E95(int_3, "cToken");
			string f2A72F = F6061E95(int_3, "cUseragent").Trim();
			(string proxy, int typeProxy) tuple = F0B30129(int_3);
			string item = tuple.proxy;
			int item2 = tuple.typeProxy;
			string text2 = "";
			string text3 = "";
			if (text == "")
			{
				text2 = Language.GetValue("Cookie trô\u0301ng");
			}
			else
			{
				string text4 = CommonRequest.B20D9E0B(text, f2A72F, item, item2);
				if (text4 == "-1")
				{
					text2 = "Cookie die";
				}
				else
				{
					string[] array = text4.Split('|');
					if (Convert.ToBoolean(array[0]))
					{
						text3 = "Live";
						CommonSQL.smethod_9(e72FDB9E, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
						B183E907(int_3, "cName", array[1]);
						B183E907(int_3, "cGender", array[2]);
						B183E907(int_3, "cBirthday", array[3]);
						if (array[5] != "")
						{
							B183E907(int_3, "cEmail", array[5]);
						}
						B183E907(int_3, "cFriend", array[6]);
						B183E907(int_3, "cGroup", array[7]);
						text2 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
					}
					else
					{
						text3 = "Die";
						text2 = Language.GetValue("Tài khoản die!");
					}
				}
			}
			method_130(int_3, text2);
			if (text3 != "")
			{
				E589F93F(int_3, text3);
			}
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private bool EC31B39A(int int_3, string string_1)
	{
		try
		{
			string text = F6061E95(int_3, "cId");
			string a20EC = F6061E95(int_3, "cUid");
			string text2 = "";
			string text3 = CommonRequest.AEB03A15(a20EC, string_1);
			if (text3 == "-1")
			{
				method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
				return false;
			}
			string[] array = text3.Split('|');
			if (Convert.ToBoolean(array[0]))
			{
				CommonSQL.smethod_9(text, "name|gender", array[1] + "|" + array[2]);
				B183E907(int_3, "cName", array[1]);
				B183E907(int_3, "cGender", array[2]);
				if (array[6] != "")
				{
					B183E907(int_3, "cFriend", array[6]);
					CommonSQL.B8A0E617(text, "friends", array[6]);
				}
				if (array[7] != "")
				{
					B183E907(int_3, "cGroup", array[7]);
					CommonSQL.B8A0E617(text, "groups", array[7]);
				}
				E589F93F(int_3, "Live");
				text2 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
			}
			else
			{
				E589F93F(int_3, "Die");
				text2 = Language.GetValue("Tài khoản Die!");
			}
			method_130(int_3, text2);
		}
		catch
		{
			method_130(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
		return true;
	}

	private void method_125(Chrome FC135F08, int int_3)
	{
		try
		{
			FC135F08.method_49("vi_VN");
			FC135F08.method_12("https://m.facebook.com/account_status");
			string text = FC135F08.method_14("return document.querySelector('[data-nt=\"NT:DECOR\"]').innerText.split('\\n').filter(e => e.includes('không thể'))[0]??''").ToString();
			if (text != "")
			{
				method_134(int_3, "cGhiChu", "(" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ") " + text, "ghiChu");
			}
		}
		catch (Exception)
		{
		}
	}

	private void ACA57217(Chrome chrome_0, int int_3, string BB08D92A, int B6975030)
	{
		try
		{
			AccountInfoAutomationHelper.UpdateAccountInfo(this, chrome_0, int_3, BB08D92A, B6975030);
		}
		catch
		{
		}
	}

	private void ADBD9516(int int_3)
	{
		try
		{
			string e72FDB9E = F6061E95(int_3, "cId");
			string text = F6061E95(int_3, "cToken");
			string text2 = F6061E95(int_3, "cCookies");
			string string_ = F6061E95(int_3, "cUseragent").Trim();
			(string proxy, int typeProxy) tuple = F0B30129(int_3);
			string item = tuple.proxy;
			int item2 = tuple.typeProxy;
			string text3 = "";
			string text4 = "";
			if (text == "")
			{
				text4 = Language.GetValue("Token trô\u0301ng");
			}
			else
			{
				string text5 = CommonRequest.smethod_9(text2, text, "", string_, item, item2);
				if (text5 == "-1")
				{
					text4 = "Token die";
				}
				else
				{
					string[] array = text5.Split('|');
					if (Convert.ToBoolean(array[0]))
					{
						text3 = "Live";
						CommonSQL.smethod_9(e72FDB9E, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
						B183E907(int_3, "cName", array[1]);
						B183E907(int_3, "cGender", array[2]);
						B183E907(int_3, "cBirthday", array[3]);
						if (array[5] != "")
						{
							B183E907(int_3, "cEmail", array[5]);
						}
						B183E907(int_3, "cFriend", array[6]);
						B183E907(int_3, "cGroup", array[7]);
					}
					else
					{
						text3 = "Die";
					}
					text4 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
				}
			}
			method_130(int_3, text4);
			if (text3 != "")
			{
				E589F93F(int_3, text3);
			}
		}
		catch
		{
			method_130(int_3, "Không check đươ\u0323c!");
		}
	}

	private void D209253D(object sender, DataGridViewSortCompareEventArgs e)
	{
		EAB09F19.smethod_5(e);
	}

	private void toolStripMenuItem_15_Click(object sender, EventArgs e)
	{
		string text = C5034B95.smethod_0("configDatagridview").ED11179C();
		Commom.smethod_35(new fCauHinhHienThi());
		if (C5034B95.smethod_0("configDatagridview").ED11179C() != text)
		{
			method_137();
		}
	}

	private void C00BE82A_Click(object sender, EventArgs e)
	{
		method_114("Useragent");
	}

	private void checkProxyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count)
			{
				Application.DoEvents();
				if (Base.smethod_5())
				{
					break;
				}
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						new Thread((ThreadStart)delegate
						{
							method_130(int_2, Language.GetValue("Đang kiểm tra..."));
							CD97C811(int_2);
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				else
				{
					num++;
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 30000)
			{
				Application.DoEvents();
				Thread.Sleep(300);
			}
			method_113("stop");
		}).Start();
	}

	private void CD97C811(int D9295E83)
	{
		try
		{
			string text = F5325785.Rows[D9295E83].Cells["cProxy"].Value.ToString();
			if (text == "")
			{
				method_130(D9295E83, Language.GetValue("Proxy trô\u0301ng!"));
				return;
			}
			int num = 0;
			if (text.EndsWith("*1"))
			{
				num = 1;
			}
			text = text.Substring(0, text.Length - 2);
			int num2 = 0;
			int num3 = 0;
			string text2 = "";
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				text2 = Commom.BD994637(text, num);
				if (text2 != "")
				{
					num2++;
					if (num2 == 3)
					{
						flag = true;
						break;
					}
				}
				else
				{
					num3++;
					if (num3 == 3)
					{
						break;
					}
				}
			}
			if (!flag)
			{
				method_130(D9295E83, "Proxy Die!");
			}
			else
			{
				method_130(D9295E83, "Proxy Live!");
			}
		}
		catch
		{
			method_130(D9295E83, "Lỗi!");
		}
	}

	private void EFB628A8(object sender, EventArgs e)
	{
		method_114("Proxy");
	}

	private void useragentToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		method_5("cUseragent");
	}

	private void proxyToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		method_5("cProxy");
	}

	private string C223110A()
	{
		string text = DateTime.Now.ToString("yyMMdd") + Commom.B820DC86(4, "0") + Commom.B820DC86(5, "a");
		if (C5034B95.smethod_0("configGeneral").method_2("typePass") == 0)
		{
			text = C5034B95.smethod_0("configGeneral").BDB80B23("txtPass");
		}
		return text.smethod_1(1);
	}

	private void CC09200B(object sender, EventArgs e)
	{
		method_114("Notes");
	}

	private void B0902D2C(object sender, EventArgs e)
	{
		Commom.KillProcess("chromedriver");
		try
		{
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
			{
				Commom.KillProcess("gpmdriver");
				(from process_0 in Process.GetProcessesByName("chrome")
					where process_0.MainModule.FileName.ToLower().Contains("gpmlogin")
					select process_0).ToList().ForEach(delegate(Process process_0)
				{
					process_0.Kill();
				});
			}
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin"))
			{
				Commom.KillProcess("gemlogindriver");
				(from process_0 in Process.GetProcessesByName("chrome")
					where process_0.MainModule.FileName.ToLower().Contains("gemlogin")
					select process_0).ToList().ForEach(delegate(Process process_0)
				{
					process_0.Kill();
				});
			}
		}
		catch (Exception)
		{
		}
	}

	private void C60DAB0C(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Alt)
		{
			C5034B95.E79C98BF = new Dictionary<string, GClass4>();
		}
		else if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Alt)
		{
			try
			{
				Process.Start(Commom.smethod_95());
			}
			catch
			{
			}
		}
	}

	private void B6161039_Click(object sender, EventArgs e)
	{
		method_114("Birthday");
	}

	private void A134ED34(object sender, EventArgs e)
	{
		if (!bool_1 || FE921A1C.SelectedValue == null || !B7059719.smethod_0(FE921A1C.SelectedValue.ToString()) || (FE921A1C.SelectedValue.ToString() != "-1" && int_2 == FE921A1C.SelectedIndex))
		{
			return;
		}
		string text = D38F4B00.SelectedValue.ToString();
		string text2 = text;
		if (!(text2 == "-2"))
		{
			if (!(text2 == "999999"))
			{
				method_2(DC234E98(), FE921A1C.Text);
			}
			else
			{
				method_2(fChonThuMuc.list_0, FE921A1C.Text);
			}
		}
		else
		{
			method_2(null, FE921A1C.Text);
		}
		int_2 = FE921A1C.SelectedIndex;
	}

	private void E39B6092_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhTaoShortcut());
		if (!fCauHinhTaoShortcut.bool_0)
		{
			return;
		}
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count)
			{
				Application.DoEvents();
				if (Base.smethod_5())
				{
					break;
				}
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						new Thread((ThreadStart)delegate
						{
							method_130(int_2, Language.GetValue("Đang ta\u0323o Shortcut..."));
							try
							{
								F5325785.Rows[int_2].Cells["cId"].Value.ToString();
								string text = F5325785.Rows[int_2].Cells["cUid"].Value.ToString();
								string text2 = F5325785.Rows[int_2].Cells["cName"].Value.ToString();
								string c8BBE = ((text2 == "") ? text : (text2 + "_" + text));
								string text3 = C5034B95.smethod_2() + "\\" + text;
								if (C5034B95.smethod_0("configGeneral").method_3("ckbUsePortable") && Directory.Exists(text3 + "\\Data\\profile"))
								{
									text3 += "\\Data\\profile";
								}
								Commom.CreateFolder(text3);
								bool flag;
								if (!(flag = method_126(text3, c8BBE)))
								{
									c8BBE = text;
									flag = method_126(text3, c8BBE);
								}
								if (!flag)
								{
									method_130(int_2, Language.GetValue("Lô\u0303i ta\u0323o Shortcut!"));
								}
								else
								{
									method_130(int_2, Language.GetValue("Ta\u0323o Shortcut thành công!"));
								}
							}
							catch
							{
								method_130(int_2, Language.GetValue("Lỗi!"));
							}
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				else
				{
					num++;
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 30000)
			{
				Application.DoEvents();
				Thread.Sleep(300);
			}
			method_113("stop");
		}).Start();
	}

	private bool method_126(string F1BDA122, string C8BBE128)
	{
		try
		{
			C8BBE128 = Commom.EB835717(C8BBE128);
			if (F1BDA122.StartsWith("profiles\\"))
			{
				F1BDA122 = Commom.smethod_95() + "\\" + F1BDA122;
			}
			string text = Commom.smethod_95() + "\\images\\chrome.ico";
			if (!File.Exists(text))
			{
				using FileStream outputStream = new FileStream(text, FileMode.Create);
				Class155.B8B52D0D.Save(outputStream);
			}
			if (Commom.smethod_26(C8BBE128, C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtPathShortcut"), F1BDA122, text, C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtPathChromeOrigin")))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private void DE88263A(object sender, EventArgs e)
	{
		method_8(bool_5: false);
	}

	private void B52F3938(object sender, EventArgs e)
	{
		method_117(4);
	}

	private void method_127(int int_3 = 1)
	{
		try
		{
			for (int i = 0; i < int_3; i++)
			{
				if (F5325785.RowCount <= 1)
				{
					continue;
				}
				List<DataGridViewRow> list = new List<DataGridViewRow>();
				foreach (DataGridViewRow item in (IEnumerable)F5325785.Rows)
				{
					list.Add(item);
				}
				int num = list.Count;
				while (num > 1)
				{
					num--;
					int index = Base.rd.Next(num + 1);
					DataGridViewRow value = list[index];
					list[index] = list[num];
					list[num] = value;
				}
				F5325785.Rows.Clear();
				foreach (DataGridViewRow item2 in list)
				{
					F5325785.Rows.Add(item2);
				}
			}
		}
		catch
		{
		}
	}

	public int method_128()
	{
		int result = 0;
		try
		{
			result = Convert.ToInt32(lblCountSelect.Text);
		}
		catch
		{
		}
		return result;
	}

	private bool method_129()
	{
		if (method_128() == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn tài khoản muốn sử dụng chức năng này!", 3);
			return false;
		}
		return true;
	}

	private void toolStripMenuItem_16_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fDownloadAvatar());
		if (!fDownloadAvatar.B1B6AF81)
		{
			return;
		}
		string string_0 = C5034B95.smethod_0("configGeneral").BDB80B23("pathFolderAvatar");
		if (!Directory.Exists(string_0))
		{
			MsBoxHelper.Show("Vui lòng kiểm tra lại nơi lưu Avatar!", 2);
			return;
		}
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count)
			{
				Application.DoEvents();
				if (Base.smethod_5())
				{
					break;
				}
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						new Thread((ThreadStart)delegate
						{
							method_130(int_2, Language.GetValue("Đang kiểm tra..."));
							F423B13D(int_2, string_0);
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				else
				{
					num++;
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 30000)
			{
				Application.DoEvents();
				Thread.Sleep(300);
			}
			method_113("stop");
		}).Start();
	}

	private void F423B13D(int int_3, string string_1)
	{
		try
		{
			string eB = F5325785.Rows[int_3].Cells["cUid"].Value.ToString();
			F5325785.Rows[int_3].Cells["cId"].Value.ToString();
			string text = F6061E95(int_3, "cProxy");
			if (text.EndsWith("*0") || text.EndsWith("*1"))
			{
				text = text.Substring(0, text.Length - 2);
			}
			int num = (text.EndsWith("*1") ? 1 : 0);
			if (!C5034B95.smethod_0("configGeneral").method_3("ckbDownAvatarUseProxy"))
			{
				text = "";
			}
			string text2 = CommonRequest.smethod_4(eB, string_1, text, num);
			if (text2 != "")
			{
				method_130(int_3, Language.GetValue("Tải xuống thành công!"));
			}
			else
			{
				method_130(int_3, Language.GetValue("Tải xuống thất bại!"));
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "DownloadAvatar");
			method_130(int_3, Language.GetValue("Tải xuống thất bại!"));
		}
	}

	private void ED2D348F(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTaiKhoanDaXoa());
	}

	private void AEB68C15(object sender, EventArgs e)
	{
		int int_0 = 0;
		int C30933A8 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				Dictionary<string, string> dictionary_0 = null;
				if (Class59.ED081E86())
				{
					dictionary_0 = Class59.smethod_2();
				}
				int num = 0;
				while (num < F5325785.Rows.Count)
				{
					if (!Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
					{
						num++;
					}
					else if (int_0 >= C30933A8)
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
					else
					{
						Interlocked.Increment(ref int_0);
						int D09B139 = num++;
						Thread thread2 = new Thread((ThreadStart)delegate
						{
							method_130(D09B139, Language.GetValue("Đang xo\u0301a Cache Profile..."));
							BD213FBD(D09B139, dictionary_0);
							Interlocked.Decrement(ref int_0);
						});
						thread2.IsBackground = true;
						thread2.Start();
					}
				}
			}
			catch
			{
			}
		});
		thread.IsBackground = true;
		thread.Start();
		Commom.DeleteTempFile();
	}

	private void BD213FBD(int int_3, Dictionary<string, string> dictionary_29 = null)
	{
		try
		{
			string text = F5325785.Rows[int_3].Cells["cUid"].Value.ToString();
			if (text.Trim() == "")
			{
				method_130(int_3, Language.GetValue("Chưa tạo profile!"));
				return;
			}
			string text2 = "";
			if (dictionary_29 != null)
			{
				if (dictionary_29.ContainsKey(text))
				{
					text2 = dictionary_29[text];
				}
			}
			else
			{
				text2 = C5034B95.smethod_2() + "\\" + text;
			}
			if (!Directory.Exists(text2))
			{
				method_130(int_3, Language.GetValue("Chưa tạo profile!"));
				return;
			}
			Commom.DeleteCacheProfile(text2);
			method_130(int_3, Language.GetValue("Xóa Cache Profile thành công!"));
		}
		catch (Exception)
		{
			method_130(int_3, Language.GetValue("Xóa Cache Profile thất bại!"));
		}
	}

	private void CB9C6A2E(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchLocTrung());
	}

	private void D090E02D_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start("chrome.exe", "https://app.minsoftware.vn/web-app/xu-ly-chuoi");
		}
		catch
		{
			Process.Start("https://app.minsoftware.vn/web-app/xu-ly-chuoi");
		}
	}

	private void EEBD2C9A(object sender, EventArgs e)
	{
	}

	private void EF359EB3_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckImapHotmail());
	}

	private void C30CDCAD(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex > -1)
			{
				F5325785.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(F5325785.CurrentRow.Cells["cChose"].Value);
				EA1B25A9();
			}
		}
		catch
		{
		}
	}

	private void btnEditFile_Click(object sender, EventArgs e)
	{
		List<string> list = DC234E98();
		if (list != null && list.Count == 1)
		{
			fEditFile fEditFile2 = new fEditFile(list[0], D38F4B00.Text);
			fEditFile2.ShowInTaskbar = false;
			fEditFile2.ShowDialog();
			int selectedIndex = D38F4B00.SelectedIndex;
			if (fEditFile2.bool_0)
			{
				C5A7879A();
				int_1 = -1;
				D38F4B00.SelectedIndex = selectedIndex;
			}
		}
	}

	private void D81A0C99(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckProxy());
	}

	private void BD9D4132(object sender, EventArgs e)
	{
		Commom.smethod_35(new fNhapCookieTrungGian());
		if (fNhapCookieTrungGian.bool_0)
		{
			method_122(4);
		}
	}

	private void BA219202_Click(object sender, EventArgs e)
	{
		fLocTheoDanhSachUid fLocTheoDanhSachUid2 = new fLocTheoDanhSachUid();
		Commom.smethod_35(fLocTheoDanhSachUid2);
		if (fLocTheoDanhSachUid2.list_0.Count > 0)
		{
			List<string> list = Commom.smethod_30(fLocTheoDanhSachUid2.list_0);
			DataTable dataTable_ = CommonSQL.FAACE83A(list);
			F5325785.Rows.Clear();
			method_3(dataTable_);
			method_4("All");
		}
	}

	private void E6058690(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhTuongTac());
	}

	public void method_130(int int_3, string B8BDE737, int int_4 = -1)
	{
		switch (int_4)
		{
		case -1:
			EAB09F19.smethod_3(F5325785, int_3, "cStatus", B8BDE737);
			return;
		case 0:
			return;
		}
		int tickCount = Environment.TickCount;
		while (true)
		{
			int num = int_4 - (Environment.TickCount - tickCount) / 1000;
			if (num > 0 && !Base.smethod_5())
			{
				EAB09F19.smethod_3(F5325785, int_3, "cStatus", B8BDE737.Replace("{time}", num.ToString()));
				Commom.smethod_52(0.5);
				continue;
			}
			break;
		}
	}

	public void method_131(int DD93AA2B, string string_1, int int_3, int int_4)
	{
		int int_5 = Commom.BF833227(int_3, int_4);
		method_130(DD93AA2B, string_1, int_5);
	}

	public void E589F93F(int int_3, string string_1)
	{
		EAB09F19.smethod_3(F5325785, int_3, "cInfo", string_1);
		B32084AC(int_3);
		CommonSQL.B8A0E617(F6061E95(int_3, "cId"), "info", string_1);
	}

	public int A5020116(int AAB6003B)
	{
		string text = F6061E95(AAB6003B, "cJob").Trim();
		if (text == "")
		{
			return 0;
		}
		string text2 = DateTime.Now.ToString("dd/MM/yyyy");
		string text3 = text.Split(' ')[0].Trim().Substring(1, 10);
		if (text3 != text2)
		{
			return 0;
		}
		return Convert.ToInt32(text.Split(' ')[1].Trim());
	}

	public void method_132(int int_3, int int_4)
	{
		int num = A5020116(int_3);
		string string_ = "(" + DateTime.Now.ToString("dd/MM/yyyy") + ") " + (int_4 + num);
		method_134(int_3, "cJob", string_, "job");
	}

	public void B183E907(int ABB9BBB1, string string_1, object object_10, bool DE3B4487 = true)
	{
		if ((!(string_1 == "cUid") || !(object_10.ToString().Trim() == "")) && (DE3B4487 || !(object_10.ToString().Trim() == "")))
		{
			EAB09F19.smethod_3(F5325785, ABB9BBB1, string_1, object_10);
		}
	}

	public void method_133(int F4B2D714, int int_3, object object_10)
	{
		EAB09F19.smethod_2(F5325785, F4B2D714, int_3, object_10);
	}

	public void F0A81525(string string_1, string string_2, int int_3, string B8BAF918, string DD1E1010, bool bool_5 = true)
	{
		if ((bool_5 || !(DD1E1010.ToString().Trim() == "")) && !(DD1E1010 == "-2"))
		{
			EAB09F19.smethod_3(F5325785, int_3, B8BAF918, DD1E1010);
			CommonSQL.B8A0E617(string_1, string_2, DD1E1010);
		}
	}

	public void method_134(int int_3, string E023D521, string string_1, string A08836A9, bool F713D5BE = true)
	{
		F0A81525(F6061E95(int_3, "cId"), A08836A9, int_3, E023D521, string_1, F713D5BE);
	}

	public string method_135(int int_3)
	{
		string text = EAB09F19.E2A1ED2F(F5325785, int_3, "cStatus");
		if (text.StartsWith("("))
		{
			return text.Substring(text.IndexOf(')') + 1).Trim();
		}
		return text;
	}

	public string BA8BE803(int int_3)
	{
		return EAB09F19.E2A1ED2F(F5325785, int_3, "cInfo");
	}

	public string F6061E95(int E89CB53E, string ED39F63F)
	{
		return EAB09F19.E2A1ED2F(F5325785, E89CB53E, ED39F63F);
	}

	public string method_136(int D1946120, int A8079412)
	{
		return EAB09F19.EC12300A(F5325785, D1946120, A8079412);
	}

	private void B32084AC(int C3A89001 = -1)
	{
		EAB09F19.EBB59018(F5325785, C3A89001);
	}

	private void C412B9A5(int int_3, int int_4)
	{
		EAB09F19.smethod_1(F5325785, int_3, int_4);
	}

	private void method_137()
	{
		F5325785.Columns["cToken"].Visible = C5034B95.smethod_0("configDatagridview").method_3("cToken");
		F5325785.Columns["cCookies"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbCookie");
		F5325785.Columns["cEmail"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbEmail");
		F5325785.Columns["cEmail2"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbEmailFull");
		F5325785.Columns["cName"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbTen");
		F5325785.Columns["cFriend"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbBanBe");
		F5325785.Columns["cGroup"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNhom");
		F5325785.Columns["cPage"].Visible = false;
		F5325785.Columns["cPagePro5"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPagePro5");
		F5325785.Columns["cBirthday"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNgaySinh");
		F5325785.Columns["cGender"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbGioiTinh");
		F5325785.Columns["cPassword"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhau");
		F5325785.Columns["cPassMail"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhauMail");
		F5325785.Columns["cOAuth2"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbOAuth2");
		F5325785.Columns["cFa2"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMa2FA");
		F5325785.Columns["cUseragent"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbUseragent");
		F5325785.Columns["cProxy"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbProxy");
		F5325785.Columns["cDateCreateAcc"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNgayTao");
		F5325785.Columns["cAvatar"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbAvatar", true);
		F5325785.Columns["cAvatar"].HeaderText = "Avatar";
		F5325785.Columns["cAvatar"].Width = 55;
		try
		{
			if (F5325785.Columns.Contains("cUid") && F5325785.Columns.Contains("cAvatar"))
			{
				F5325785.Columns["cAvatar"].DisplayIndex = F5325785.Columns["cUid"].DisplayIndex + 1;
			}
		}
		catch { }
		F5325785.Columns["cProfile"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbProfile");
		F5325785.Columns["cInfo"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbTinhTrang");
		F5325785.Columns["cThuMuc"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbThuMuc");
		F5325785.Columns["cGhiChu"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbGhiChu");
		F5325785.Columns["cFollow"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbFollow");
		F5325785.Columns["cInteractEnd"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbInteractEnd");
		F5325785.Columns["cMailRecovery"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMailRecovery");
		F5325785.Columns["cPassMailRecovery"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPassMailRecovery");
		F5325785.Columns["cPhone"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPhone");
		F5325785.Columns["cHometown"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbHometown");
		F5325785.Columns["cCurrentCity"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbCurrentCity");
		F5325785.Columns["cJob"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbJob");
		F5325785.Columns["cLocation"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbLocation");
		F5325785.Columns["cDating"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbDating");
		F5325785.Columns["cAds"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbAds");
		F5325785.Columns["cBM"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbBM");
		F5325785.Columns["cWallPosts"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbWallPosts");
		F5325785.Columns["cFbBlock"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbFbBlock");
		F5325785.Columns["cStatus282"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbStatus282");
		F5325785.Columns["cKichBan"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbKichBan");
		F5325785.Columns["cCookieHotmail"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbCookieHotmail");
	}

	private void toolStripMenuItem_19_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCapNhatDuLieu());
		if (fCapNhatDuLieu.bool_0)
		{
			E48D7F88(null, null);
		}
	}

	private void E287B537(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_2 && e.ColumnIndex == 0)
		{
			EA1B25A9();
		}
	}

	private void C0A7291D(object sender, EventArgs e)
	{
		if (Class59.ED081E86())
		{
			CE013223();
		}
		else
		{
			D20D5F13(C5034B95.smethod_2());
		}
	}

	private void CE013223()
	{
		Commom.smethod_35(new fSelectFolder());
		string text = fSelectFolder.string_0;
		if (text == "")
		{
			return;
		}
		Dictionary<string, string> dictionary = null;
		if (Class59.ED081E86())
		{
			dictionary = Class59.smethod_2();
		}
		List<string> list = new List<string>();
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			try
			{
				if (Convert.ToBoolean(F6061E95(i, "cChose")))
				{
					string text2 = F6061E95(i, "cUid");
					string text3 = dictionary[text2];
					list.Add(text3 + "|" + text + "\\" + text2);
				}
			}
			catch
			{
			}
		}
		if (list.Count > 0)
		{
			Commom.smethod_35(new fShowProgressBar(list));
			MsBoxHelper.Show("Đa\u0303 copy dư\u0303 liê\u0323u xong!");
		}
	}

	private void D20D5F13(string string_1)
	{
		Commom.smethod_35(new fSelectFolder());
		string text = fSelectFolder.string_0;
		if (text == "")
		{
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			try
			{
				if (Convert.ToBoolean(F6061E95(i, "cChose")))
				{
					string text2 = F6061E95(i, "cUid");
					list.Add(string_1 + "\\" + text2 + "|" + text + "\\" + text2);
				}
			}
			catch
			{
			}
		}
		if (list.Count > 0)
		{
			Commom.smethod_35(new fShowProgressBar(list));
			MsBoxHelper.Show("Đa\u0303 copy dư\u0303 liê\u0323u xong!");
		}
	}

	private void FDB0FFB9(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckLiveUid());
	}

	private void toolStripMenuItem_20_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fMoTrinhDuyet());
	}

	private bool A539653C(Chrome ED3FE302)
	{
		if (C5034B95.smethod_0("configDebug").method_3("ckbModeDev"))
		{
			new fAutoChrome(ED3FE302.Int32_2, ED3FE302.String_5).ShowDialog();
			return true;
		}
		return false;
	}

	private void toolStripMenuItem_21_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("OpenBrowser", true);
		method_12(gClass);
	}

	private void method_138(object sender, EventArgs e)
	{
	}

	private void method_139(object sender, EventArgs e)
	{
		try
		{
			Commom.smethod_35(new fClearBackup());
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show(ex.ToString(), 3);
		}
	}

	private void BFA85F92(object sender, EventArgs e)
	{
		Commom.smethod_35(new fContact());
	}

	private void method_140(object sender, EventArgs e)
	{
		Commom.smethod_35(new fSelectFolder());
		string text = fSelectFolder.string_0;
		if (text == "")
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			try
			{
				if (!Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				string text2 = F5325785.Rows[i].Cells["cUid"].Value.ToString();
				try
				{
					if (File.Exists(Commom.smethod_95() + "\\backup\\" + text2 + "\\" + text2 + ".txt"))
					{
						File.Copy("backup\\" + text2 + "\\" + text2 + ".txt", text + "\\" + text2 + ".txt");
						num++;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		MsBoxHelper.Show(string.Format(Language.GetValue("Copy thành công {0} tệp backup txt!"), num));
	}

	private void EB2DE717(object sender, EventArgs e)
	{
		method_114("PassMail");
	}

	private void toolStripMenuItem_23_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			if (Convert.ToBoolean(F6061E95(i, "cChose")))
			{
				list.Add(F6061E95(i, "cUid") + "|" + F6061E95(i, "cPassword") + "|" + F6061E95(i, "cFa2") + "|" + F6061E95(i, "cCookies") + "|" + F6061E95(i, "cProxy") + "|" + F6061E95(i, "cName") + "|" + F6061E95(i, "cGhiChu") + "|" + F6061E95(i, "cId"));
			}
		}
		new fQuanLyTinNhan(list).ShowDialog();
		E48D7F88(null, null);
	}

	private void toolStripMenuItem_24_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fCauHinhKhoiPhucMatKhau());
			if (fCauHinhKhoiPhucMatKhau.bool_0)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("RecoverPass", true);
				method_12(gClass);
			}
		}
	}

	private string method_141(string D3B7DD8A)
	{
		string text = "";
		if (C5034B95.smethod_0("configCheckpoint").method_2("typeImage") == 0)
		{
			if (list_3.Contains(D3B7DD8A + ".png") || list_3.Contains(D3B7DD8A + ".PNG"))
			{
				text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage") + "\\" + D3B7DD8A + ".png";
			}
			else
			{
				text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage").Trim();
				if (list_3.Count == 0)
				{
					list_3 = Commom.smethod_76(text);
				}
				if (list_3.Count > 0)
				{
					text = list_3[0];
					list_3.RemoveAt(0);
				}
			}
		}
		else
		{
			string text2 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImageUrl");
			string string_ = Commom.smethod_95() + "\\photos";
			text = CommonRequest.smethod_5(text2, string_);
		}
		return text;
	}

	private void method_142()
	{
		ED00A032 = new Dictionary<string, int>();
		List<string> list = C5034B95.smethod_0("configCheckpoint").method_1("txtSdt");
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i].Split('|');
			if (array.Length >= 2 && !ED00A032.ContainsKey(array[0]))
			{
				ED00A032.Add(array[0], Convert.ToInt32(array[1]));
			}
		}
	}

	private void F81DC4BF()
	{
		if (ED00A032 == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in ED00A032)
		{
			list.Add(item.Key + "|" + item.Value);
		}
		C5034B95.smethod_0("configCheckpoint").method_4("txtSdt", string.Join("\n", list));
	}

	private string method_143(Chrome E4A6F40B, string string_1, string string_2, int D388AFB4)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		int tickCount = Environment.TickCount;
		while (!(E4A6F40B?.CD930D04() ?? false) && Environment.TickCount - tickCount <= D388AFB4 * 1000)
		{
			try
			{
				requestXNet.F089DBB3.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7Im5hbWUiOiJ0cnVuZyJ9LCJpYXQiOjE2ODkxMzQyNDAsImV4cCI6MTc1MTM0MjI0MH0.OLkU8vhwi67BIiqMS2Dvg4Tg_ly0baN7SREuY1m1XWU");
				string json = requestXNet.E58EB99F("http://14.225.255.45:3003/otp?brand=facebook&phone_number=" + string_2);
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					string text2 = item["msgdata"]!.ToString();
					if (!(string_1 == ""))
					{
						if (!(string_1 == "pt_PT") || !text2.Contains("teu código"))
						{
							if (!(string_1 == "hi_IN") || !text2.Contains("प\u0941ष\u094dट\u093fकरण क\u094bड"))
							{
								if (!(string_1 == "th_TH") || !text2.Contains("รห\u0e31สย\u0e37นย\u0e31น"))
								{
									if (!(string_1 == "lo_LA") || !text2.Contains("confirmation"))
									{
										if (!(string_1 == "ja_JP") || !text2.Contains("証コード"))
										{
											if (!(string_1 == "vi_VN") || !text2.Contains("của bạn"))
											{
												if (string_1 == "zh_TW" && text2.Contains("確認碼"))
												{
													text = Regex.Match(text2, "\\d+").Value;
													break;
												}
												continue;
											}
											text = Regex.Match(text2, "\\d+").Value;
											break;
										}
										text = Regex.Match(text2, "\\d+").Value;
										break;
									}
									text = Regex.Match(text2, "\\d+").Value;
									break;
								}
								text = Regex.Match(text2, "\\d+").Value;
								break;
							}
							text = Regex.Match(text2, "\\d+").Value;
							break;
						}
						text = Regex.Match(text2, "\\d+").Value;
						break;
					}
					text = Regex.Match(text2, "\\d+").Value;
					break;
				}
				if (text != "")
				{
					lock (object_8)
					{
						C5034B95.smethod_0("configCheckpoint").method_4("otpSuccess", C5034B95.smethod_0("configCheckpoint").method_2("otpSuccess") + 1);
					}
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	private string method_144(string F19FD197)
	{
		string text = "";
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbBackupAnh"))
		{
			text = Commom.smethod_95() + "\\Image282\\" + F19FD197 + ".png";
			if (!File.Exists(text))
			{
				text = Commom.smethod_95() + "\\Image282\\" + F19FD197 + ".jpg";
			}
			if (!File.Exists(text))
			{
				text = "";
			}
		}
		if (text == "")
		{
			text = method_141(F19FD197);
			if (text != "" && C5034B95.smethod_0("configCheckpoint").method_3("ckbBackupAnh"))
			{
				Commom.smethod_72(text, Commom.smethod_95() + "\\Image282\\" + F19FD197 + ".png", bool_0: true);
			}
		}
		if (text.Trim() == "" || !File.Exists(text))
		{
			return "";
		}
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbChangeMD5"))
		{
			Commom.ChangeMD5(text);
		}
		return text;
	}

	private bool F59267A6(int int_3, string BD2F2832, Chrome chrome_0, string string_1)
	{
		if (chrome_0.method_61() != 1 && chrome_0.method_49("vi_VN") == 1)
		{
			chrome_0.method_13();
		}
		method_130(int_3, BD2F2832 + Language.GetValue("Đang gửi ảnh..."));
		if (!chrome_0.D7A424AE("[type=\"file\"]", 15.0))
		{
			return false;
		}
		string text = method_144(string_1);
		if (text == "")
		{
			method_130(int_3, BD2F2832 + Language.GetValue("Không tìm thấy ảnh!"));
			int num = method_30(chrome_0, chrome_0.AFACE5B4());
			method_134(int_3, "cStatus282", "Image-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ((num == -1) ? "" : $"-{num} ngày"), "status282");
			return false;
		}
		chrome_0.method_24("[type=\"file\"]", text);
		chrome_0.F8091028(1.0);
		if (chrome_0.method_61() == 1)
		{
			chrome_0.method_33("[aria-label=\"Continue\"][aria-disabled=\"true\"]", 60);
			chrome_0.method_18("[aria-label=\"Continue\"]");
			chrome_0.F8091028(2.0);
			chrome_0.method_33("[aria-label=\"Continue\"][aria-disabled=\"true\"]", 60);
		}
		else
		{
			chrome_0.method_18("[name=\"action_upload_image\"]");
			chrome_0.F8091028(2.0);
		}
		if (!text.Contains("Image282\\" + string_1 + ".png"))
		{
			Commom.E10A40B6(text);
		}
		return true;
	}

	public static byte[] smethod_0(Bitmap bitmap_3)
	{
		using MemoryStream memoryStream = new MemoryStream();
		bitmap_3.Save(memoryStream, ImageFormat.Png);
		return memoryStream.ToArray();
	}

	private void F5325785_SelectionChanged(object sender, EventArgs e)
	{
		lblCountHighline.Text = F5325785.SelectedRows.Count.ToString();
	}

	private void D61E5014(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex > -1)
		{
			try
			{
				F5325785.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(F5325785.CurrentRow.Cells["cChose"].Value);
				EA1B25A9();
			}
			catch
			{
			}
		}
	}

	private void FD11AF2E(object sender, EventArgs e)
	{
		Commom.smethod_35(new fGiaiPhongDungLuong());
	}

	private void C71C3FA2(object sender, EventArgs e)
	{
		Commom.smethod_35(new fGiaiPhongDungLuong(bool_1: true));
	}

	private void D82ABB0C(object sender, EventArgs e)
	{
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
			{
				F5325785.Rows.RemoveAt(i--);
			}
		}
		AF952311();
		method_116();
		EA1B25A9(0);
	}

	private void toolStripMenuItem_26_Click(object sender, EventArgs e)
	{
		method_114("Email|Mail khôi phục");
	}

	private void B8A44DA7(object sender, EventArgs e)
	{
		method_5("cEmail|cPassMail|cMailRecovery");
	}

	private void BBB08939(object sender, EventArgs e)
	{
		method_114("Mail khôi phục");
	}

	private void C7BCAF9B(object sender, EventArgs e)
	{
		method_114("Phone");
	}

	private void E49BDB23(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			BtnSearch_Click(null, null);
		}
	}

	public void method_145(int D7AE2211)
	{
		try
		{
			statusStrip1.Invoke((MethodInvoker)delegate
			{
				D81D001E.Text = D7AE2211.ToString();
			});
		}
		catch
		{
		}
	}

	private void D804239D_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int num = 0;
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			if (!Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
			{
				continue;
			}
			try
			{
				string item = F6061E95(i, "cUid");
				if (list2.Contains(item))
				{
					list.Add(F5325785.Rows[i].Cells["cId"].Value.ToString());
					F5325785.Rows.RemoveAt(i);
					i--;
					num++;
				}
				else
				{
					list2.Add(item);
				}
			}
			catch
			{
			}
		}
		CommonSQL.smethod_14(list);
		AF952311();
		method_116();
		EA1B25A9();
		MsBoxHelper.Show($"Đã loại bỏ {num} tài khoản bị trùng!");
	}

	private void C4A352A3(object sender, EventArgs e)
	{
		method_117(5);
	}

	private void B39C7333(object sender, EventArgs e)
	{
		method_117(5, bool_5: true);
	}

	private void EDBC0522(object sender, EventArgs e)
	{
		fLocTheoDanhSachUid fLocTheoDanhSachUid2 = new fLocTheoDanhSachUid();
		Commom.smethod_35(fLocTheoDanhSachUid2);
		List<string> list = Commom.smethod_30(fLocTheoDanhSachUid2.list_0);
		if (list.Count <= 0)
		{
			return;
		}
		if (list[0].StartsWith("@"))
		{
			for (int i = 0; i < F5325785.RowCount; i++)
			{
				string text = F6061E95(i, "cEmail");
				if (text != "" && text.Contains("@"))
				{
					text = text.Substring(text.IndexOf('@'));
					B183E907(i, "cChose", list.Contains(text));
				}
			}
		}
		else
		{
			for (int j = 0; j < F5325785.RowCount; j++)
			{
				string item = F6061E95(j, "cUid");
				string item2 = F6061E95(j, "cEmail");
				B183E907(j, "cChose", list.Contains(item) || list.Contains(item2));
			}
		}
		EA1B25A9();
	}

	private void FBA31BBA_DoubleClick(object sender, EventArgs e)
	{
		this.E6175915();
	}

	private void picLanguage_Click(object sender, EventArgs e)
	{
		if (picLanguage.Image == bitmap_2)
		{
			picLanguage.Image = D5126D0C;
			Base.C601B080();
			MsBoxHelper.Show("Vui lòng mở lại phần mềm để cập nhật ngôn ngữ!");
		}
		else
		{
			picLanguage.Image = bitmap_2;
			Base.C601B080("EN");
		}
		EB201A06();
	}

	private void C9BCABB0(object sender, EventArgs e)
	{
		if (method_129())
		{
			fCauHinhHotmail fCauHinhHotmail2 = new fCauHinhHotmail("DoiPassHotmail");
			Commom.smethod_35(fCauHinhHotmail2);
			if (fCauHinhHotmail2.bool_0)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("DoiPassHotmail", true);
				C4269420(gClass);
			}
		}
	}

	private void FE01C117(object sender, EventArgs e)
	{
		if (method_129())
		{
			fCauHinhHotmail fCauHinhHotmail2 = new fCauHinhHotmail("ThemMailKhoiPhuc");
			Commom.smethod_35(fCauHinhHotmail2);
			if (fCauHinhHotmail2.bool_0)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("ThemMailKhoiPhuc", true);
				C4269420(gClass);
			}
		}
	}

	private void C4269420(GClass4 gclass4_0 = null)
	{
		try
		{
			int int_0;
			if (method_129())
			{
				int_0 = C5034B95.smethod_0("configGeneral").method_2("nudInteractThread", 3);
				if (C5034B95.smethod_0("configHotmail").method_2("cbbChangeIP") != -1)
				{
					goto IL_00a5;
				}
				list_1 = method_24(ref int_0);
				if (list_1 == null || list_1.Count != 0)
				{
					goto IL_00a5;
				}
				MsBoxHelper.Show("Proxy không đủ, vui lòng cấu hình lại!", 2);
			}
			goto end_IL_0014;
			IL_00a5:
			List<int> list_0 = new List<int>();
			for (int i = 0; i < int_0; i++)
			{
				list_0.Add(0);
			}
			method_113("start");
			bool_2 = true;
			Base.smethod_6(bool_9: false);
			int int_1 = 0;
			bool bool_0 = false;
			this.int_0 = 0;
			this.list_0 = new List<Thread>();
			Thread thread = new Thread((ThreadStart)delegate
			{
				try
				{
					Thread thread2 = new Thread((ThreadStart)delegate
					{
						try
						{
							int num = 0;
							while (num < F5325785.Rows.Count && !Base.smethod_5())
							{
								if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
								{
									if (Base.smethod_5())
									{
										break;
									}
									if (this.list_0.Count < int_0)
									{
										if (Base.smethod_5())
										{
											break;
										}
										int int_2 = num++;
										if (int_2 > 0)
										{
											Commom.smethod_52(0.1);
										}
										Thread thread3 = new Thread((ThreadStart)delegate
										{
											int d6103BA = Commom.smethod_56(ref list_0);
											try
											{
												method_146(int_2, d6103BA, gclass4_0);
											}
											catch (Exception)
											{
											}
											Commom.B33105BA(ref list_0, d6103BA);
											B183E907(int_2, "cChose", false);
										})
										{
											Name = int_2.ToString()
										};
										this.list_0.Add(thread3);
										thread3.Start();
									}
									else
									{
										if (Base.smethod_5())
										{
											break;
										}
										if (C5034B95.smethod_0("configHotmail").method_2("cbbChangeIP") != -1)
										{
											for (int j = 0; j < this.list_0.Count; j++)
											{
												if (!this.list_0[j].IsAlive)
												{
													this.list_0.RemoveAt(j--);
												}
											}
										}
										else if ((C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 7 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTinsoft")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 8 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllXproxy")) || (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 10 && C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllTMProxy")))
										{
											for (int k = 0; k < this.list_0.Count; k++)
											{
												this.list_0[k].Join();
												this.list_0.RemoveAt(k--);
											}
										}
										else if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 1 || C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 2)
										{
											for (int l = 0; l < this.list_0.Count; l++)
											{
												this.list_0[l].Join();
												this.list_0.RemoveAt(l--);
											}
											if (Base.smethod_5())
											{
												break;
											}
											Interlocked.Increment(ref int_1);
											if (int_1 >= C5034B95.smethod_0("configGeneral").method_2("ip_nudChangeIpCount", 1))
											{
												for (int m = 0; m < 3; m++)
												{
													bool_0 = Commom.smethod_59(C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp"), C5034B95.smethod_0("configGeneral").method_2("typeDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom"), C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink"), C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot"), C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN"));
													if (bool_0)
													{
														break;
													}
												}
												if (!bool_0)
												{
													MsBoxHelper.Show("Không thê\u0309 đô\u0309i ip!", 2);
													Base.smethod_6(bool_9: true);
													return;
												}
												int_1 = 0;
											}
										}
										else
										{
											for (int n = 0; n < this.list_0.Count; n++)
											{
												if (!this.list_0[n].IsAlive)
												{
													this.list_0.RemoveAt(n--);
												}
											}
										}
									}
								}
								else
								{
									num++;
								}
								if (Base.smethod_5())
								{
									break;
								}
							}
							for (int num2 = 0; num2 < this.list_0.Count; num2++)
							{
								this.list_0[num2].Join();
							}
						}
						catch (ThreadAbortException ex)
						{
							if (ex.ToString().Contains("Thread was being aborted."))
							{
							}
						}
					});
					thread2.IsBackground = true;
					thread2.Start();
					thread2.Join();
				}
				catch (Exception exception_2)
				{
					Commom.smethod_57(null, exception_2);
				}
				F529F8AC();
				method_113("stop");
				bool_2 = false;
			});
			thread.IsBackground = true;
			thread.Start();
			end_IL_0014:;
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			method_113("stop");
			bool_2 = false;
		}
	}

	private void method_146(int int_3, int D6103BA5, GClass4 DB95B73B)
	{
		if (DB95B73B == null)
		{
			DB95B73B = new GClass4();
		}
		Chrome chrome = null;
		int int32_ = 0;
		string text = "";
		string text2 = "";
		XProxyproxy xproxyproxy_ = null;
		ShopLike e8A9CC = null;
		MinProxyVN minProxyVN_ = null;
		ObcProxy eA3D099B = null;
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = F6061E95(int_3, "cUid");
		string text7 = F6061E95(int_3, "cEmail");
		string text8 = F6061E95(int_3, "cPassMail");
		string text9 = F6061E95(int_3, "cMailRecovery").ToLower().Trim();
		string text10 = F6061E95(int_3, "cPassMailRecovery");
		if (!text7.Contains("hotmail.") && !text7.Contains("outlook.") && !text7.Contains("live.") && !text7.Contains("rickystar."))
		{
			method_130(int_3, Language.GetValue("Mail chưa hỗ trợ!"));
			return;
		}
		if (text8 == "")
		{
			method_130(int_3, Language.GetValue("Không có pass mail!"));
			return;
		}
		int num = C5034B95.smethod_0("configHotmail").method_2("cbbChangeIP");
		int num2 = num;
		if (num2 == 9)
		{
			text = F6061E95(int_3, "cProxy");
			int32_ = (text.EndsWith("*1") ? 1 : 0);
			if (text.EndsWith("*0") || text.EndsWith("*1"))
			{
				text = text.Substring(0, text.Length - 2);
			}
		}
		if (Base.smethod_5())
		{
			method_130(int_3, Language.GetValue("Đã dừng!"));
		}
		else
		{
			try
			{
				if (Base.smethod_5())
				{
					method_130(int_3, text2 + Language.GetValue("Đã dừng!"));
				}
				else
				{
					method_130(int_3, text2 + Language.GetValue("Chờ đến lượt..."));
					lock (object_0)
					{
						if (int_0 > 0)
						{
							int num3 = Base.rd.Next(C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeFrom", 1), C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeTo", 1) + 1);
							if (num3 > 0)
							{
								int tickCount = Environment.TickCount;
								while ((Environment.TickCount - tickCount) / 1000 - num3 < 0)
								{
									method_130(int_3, text2 + Language.GetValue("Mở tri\u0300nh duyê\u0323t sau") + " {time}s...".Replace("{time}", (num3 - (Environment.TickCount - tickCount) / 1000).ToString()));
									Commom.smethod_52(0.5);
									if (!Base.smethod_5())
									{
										continue;
									}
									method_130(int_3, text2 + Language.GetValue("Đã dừng!"));
									goto IL_0b0c;
								}
							}
						}
						else
						{
							int_0++;
						}
					}
					method_130(int_3, text2 + Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
					string dA9C = "data:,";
					Point point_ = Commom.smethod_55(D6103BA5, 5, 2);
					Point f5BA98AC = Commom.E50AD706(5, 2);
					if (DB95B73B.method_3("LoginHotmail") && !C5034B95.smethod_0("configHotmail").method_3("ckbCloseChrome"))
					{
						dA9C = "";
					}
					string text11 = C5034B95.smethod_2();
					string string_ = "";
					if (text11 != "" && (text6 != "" || text7 != ""))
					{
						if (text6 != "")
						{
							string_ = text11 + "\\" + text6;
						}
						else if (text7 != "")
						{
							string_ = text11 + "\\" + text7;
						}
						if (!C5034B95.smethod_0("configHotmail").method_3("ckbUseProfile"))
						{
							string_ = "";
						}
					}
					chrome = new Chrome
					{
						D1154987 = int_3,
						Boolean_2 = false,
						String_1 = string_,
						F5BA98AC = f5BA98AC,
						Point_0 = point_,
						A3A32284 = text,
						Int32_1 = int32_,
						Boolean_3 = true,
						DA9C9817 = dA9C
					};
					chrome.CF8FD901 = int_3;
					chrome.B4208531 = text6;
					chrome.F8A3B83F = text7;
					chrome.ACBD1889 = text8;
					if (Base.smethod_5())
					{
						method_130(int_3, text2 + Language.GetValue("Đã dừng!"));
					}
					else
					{
						var (flag, text12) = chrome.method_0();
						if (!flag)
						{
							method_130(int_3, text2 + Language.GetValue("Lỗi mở trình duyệt!") + ((text12 != "") ? (" (" + text12 + ")") : ""));
						}
						else
						{
							method_130(int_3, text2 + Language.GetValue("Đang đăng nhâ\u0323p..."));
							string json = chrome.method_94(text7, text8, text9, text10);
							JObject jObject = JObject.Parse(json);
							if (!Convert.ToBoolean(jObject["success"]))
							{
								method_130(int_3, "Login hotmail fail (" + jObject["error"]!.ToString() + ")!");
								C412B9A5(int_3, 1);
							}
							else
							{
								if (jObject["mailRecover"]!.ToString() != "" && jObject["mailRecover"]!.ToString() != text9)
								{
									text3 = "success";
									text9 = jObject["mailRecover"]!.ToString();
									text10 = jObject["passMailRecover"]!.ToString();
									method_134(int_3, "cMailRecovery", text9, "mailrecovery");
									method_134(int_3, "cPassMailRecovery", text10, "passmailrecovery");
								}
								if (text8 != jObject["passmail"]!.ToString())
								{
									text4 = "success";
									text8 = jObject["passmail"]!.ToString();
									method_134(int_3, "cPassMail", text8, "passmail");
								}
								method_130(int_3, "Login hotmail success!");
								C412B9A5(int_3, 2);
								A539653C(chrome);
								method_130(int_3, "Get cookie...");
								string text13 = D831098B.smethod_0(text7, text8);
								if (text13 != "")
								{
									method_134(int_3, "cCookieHotmail", text13, "cookieHotmail", F713D5BE: false);
								}
								method_130(int_3, "Login hotmail success!");
								if (DB95B73B.method_3("GetOAuth2") || C5034B95.smethod_0("configHotmail").method_3("ckbGetOAuth2"))
								{
									string text14 = chrome.BB357610();
									if (text14 != "")
									{
										method_134(int_3, "cOAuth2", text14, "backup");
									}
									bool flag2 = text14 != "";
									C412B9A5(int_3, (!flag2) ? 1 : 2);
									text5 = (flag2 ? "success" : "fail");
								}
								if (!DB95B73B.method_3("LoginHotmail"))
								{
									if (!DB95B73B.method_3("ThemMailKhoiPhuc") || !(text3 != "success"))
									{
										goto IL_094d;
									}
									bool flag3 = text9 != "";
									method_130(int_3, text2 + Language.GetValue("Thêm mail khôi phục..."));
									string json2 = chrome.E3A1A80C(text7, text8, text9, text10);
									JObject jObject2 = JObject.Parse(json2);
									if (!Convert.ToBoolean(jObject2["success"]))
									{
										text3 = "fail (" + jObject2["error"]!.ToString() + ")";
										method_130(int_3, jObject2["error"]!.ToString() + "!");
										C412B9A5(int_3, 1);
									}
									else
									{
										if (jObject2["mailRecover"]!.ToString() != "" && jObject2["mailRecover"]!.ToString() != text9)
										{
											text3 = "success";
											text9 = jObject2["mailRecover"]!.ToString();
											text10 = jObject2["passMailRecover"]!.ToString();
											method_134(int_3, "cMailRecovery", text9, "mailrecovery");
											method_134(int_3, "cPassMailRecovery", text10, "passmailrecovery");
										}
										if (!flag3 || !(text3 == "success") || !C5034B95.smethod_0("configHotmail").method_3("ckbXoaMailKhoiPhucCu", C9B3010F: true))
										{
											goto IL_094d;
										}
										method_130(int_3, text2 + Language.GetValue("Xóa mail khôi phục cũ..."));
										string json3 = chrome.C21E6A38(text7, text8, text9, text10);
										JObject jObject3 = JObject.Parse(json3);
										if (Convert.ToBoolean(jObject3["success"]))
										{
											goto IL_094d;
										}
										_ = "fail (" + jObject3["error"]!.ToString() + ")";
										method_130(int_3, jObject3["error"]!.ToString() + "!");
										C412B9A5(int_3, 1);
									}
								}
							}
						}
					}
				}
				goto end_IL_0197;
				IL_094d:
				if (DB95B73B.method_3("DoiPassHotmail") && text4 != "success")
				{
					method_130(int_3, text2 + Language.GetValue("Đổi pass mail..."));
					string json4 = chrome.E8032DA4(text7, text8, text9, text10);
					JObject jObject4 = JObject.Parse(json4);
					if (jObject4["mailRecover"]!.ToString() != "" && jObject4["mailRecover"]!.ToString() != text9)
					{
						text3 = "success";
						text9 = jObject4["mailRecover"]!.ToString();
						text10 = jObject4["passMailRecover"]!.ToString();
						method_134(int_3, "cMailRecovery", text9, "mailrecovery");
						method_134(int_3, "cPassMailRecovery", text10, "passmailrecovery");
					}
					if (!Convert.ToBoolean(jObject4["success"]))
					{
						text4 = "fail (" + jObject4["error"]!.ToString() + ")";
						method_130(int_3, jObject4["error"]!.ToString() + "!");
						C412B9A5(int_3, 1);
					}
					else if (text8 != jObject4["passmail"]!.ToString())
					{
						text4 = "success";
						text8 = jObject4["passmail"]!.ToString();
						method_134(int_3, "cPassMail", text8, "passmail");
					}
				}
				end_IL_0197:;
			}
			catch (Exception exception_)
			{
				method_130(int_3, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				Commom.smethod_57(chrome, exception_, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
			}
		}
		goto IL_0b0c;
		IL_0b0c:
		string b8BDE = method_135(int_3);
		bool flag4 = true;
		if (DB95B73B.method_3("LoginHotmail") && !C5034B95.smethod_0("configHotmail").method_3("ckbCloseChrome"))
		{
			flag4 = false;
		}
		if (flag4)
		{
			try
			{
				if (chrome != null)
				{
					method_55(int_3, text2, chrome);
				}
			}
			catch
			{
			}
		}
		string text15 = "";
		if (text5 != "")
		{
			text15 = text15 + "- Enable OAuth2: " + text5;
		}
		if (text3 != "")
		{
			text15 = text15 + "- Add mail kp: " + text3;
		}
		if (text4 != "")
		{
			text15 = text15 + "- Đổi pass: " + text4;
		}
		if (text15 != "")
		{
			b8BDE = text15.TrimStart(' ', '-') + "!";
		}
		method_130(int_3, b8BDE);
		if (C5034B95.smethod_0("configHotmail").method_2("cbbChangeIP") == -1)
		{
			method_26(xproxyproxy_, e8A9CC, minProxyVN_, eA3D099B);
		}
	}

	private void testSpinTextToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchTestSpinContent());
	}

	private void E3AACC35_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("GetTokenEAAAAU", true);
		method_12(gClass);
	}

	private void getTokenEAAAAUBToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("GetTokenEAAAAU", true);
		gClass.method_4("Bat2FA", true);
		method_12(gClass);
	}

	private void method_147(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("GetTokenEAAAAU", true);
		method_12(gClass);
	}

	private void BC1B5AAD(object sender, EventArgs e)
	{
		method_114("Token");
	}

	private void F2A46D35()
	{
	}

	private void F881A71F_MouseEnter(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			return;
		}
		bool_3 = false;
		F881A71F.DropDownItems.Clear();
		List<string> list_0 = new List<string>();
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text = "";
				for (int j = 0; j < F5325785.RowCount; j++)
				{
					text = F6061E95(j, "cGhiChu");
					if (text != "")
					{
						string value = Regex.Match(text, "\\((.*?)\\)", RegexOptions.Singleline).Value;
						if (value != "")
						{
							text = text.Replace(value, "").Trim();
						}
						value = Regex.Match(text, "\\[(.*?)\\]").Value;
						if (value != "")
						{
							text = text.Replace(value, "").Trim();
						}
						if (text.StartsWith("282-") && text.Split('-').Length > 1)
						{
							text = text.Split('-')[0] + "-" + text.Split('-')[1];
						}
						if (text != "" && !list_0.Contains(text))
						{
							list_0.Add(text);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		});
		thread.Start();
		if (!thread.Join(10000))
		{
			thread.Abort();
		}
		for (int i = 0; i < list_0.Count; i++)
		{
			F881A71F.DropDownItems.Add(list_0[i]);
			F881A71F.DropDownItems[i].Click += B9918A14;
		}
	}

	private void B9918A14(object sender, EventArgs e)
	{
		DC0B5AAE("cGhiChu", (sender as ToolStripMenuItem).Text);
	}

	private void method_148(object sender, EventArgs e)
	{
		DC0B5AAE("cStatus282", (sender as ToolStripMenuItem).Text);
	}

	private void method_149(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fCauHinhCheckpoint("956"));
			if (fCauHinhCheckpoint.E1AD3A3A)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("Unlock956", true);
				gClass.method_4("TypeUnlock956", 2);
				method_12(gClass);
			}
		}
	}

	private void A70D7D81_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckStatusXProxy());
	}

	private void toolStripMenuItem_32_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fImportProxy());
		}
	}

	private void toolStripMenuItem_33_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fImportUseragent());
		}
	}

	private void BE8BBBA0_Click(object sender, EventArgs e)
	{
		fChuyenThuMuc fChuyenThuMuc2 = new fChuyenThuMuc();
		Commom.smethod_35(fChuyenThuMuc2);
		if (fChuyenThuMuc2.AC2D52A9 != "" && method_129() && MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có thực sự muốn chuyển {0} tài khoản sang thư mục [{1}]?"), lblCountSelect.Text, fChuyenThuMuc2.string_0)) == DialogResult.Yes)
		{
			CA120E9B(fChuyenThuMuc2.AC2D52A9);
		}
	}

	private void toolStripMenuItem_35_Click(object sender, EventArgs e)
	{
		method_117(6, bool_5: true);
	}

	private void checkNameVNToolStripMenuItem_Click(object sender, EventArgs e)
	{
		method_117(7);
	}

	private void FA1B6D17_Click(object sender, EventArgs e)
	{
		method_114("Fb Block");
	}

	private void toolStripMenuItem11_Click(object sender, EventArgs e)
	{
		method_114("Tình trạng");
	}

	private void B526D03A_DoubleClick(object sender, EventArgs e)
	{
		B6B4A129++;
		if (B6B4A129 >= 3)
		{
			B6B4A129 = 0;
			new fCauHinhDebug().ShowDialog();
		}
	}

	private void toolStripMenuItem1_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < F5325785.RowCount; i++)
		{
			if (!Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
			{
				F5325785.Rows.RemoveAt(i--);
			}
		}
		AF952311();
		method_116();
	}

	private void BE8BBBA0_MouseEnter(object sender, EventArgs e)
	{
		if (!A88D2489)
		{
			return;
		}
		A88D2489 = false;
		BE8BBBA0.DropDownItems.Clear();
		try
		{
			DataTable dataTable = CommonSQL.D0A8D8BC();
			if (dataTable.Rows.Count > 20)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				string text = "";
				if (dataRow["id"].ToString() != text)
				{
					BE8BBBA0.DropDownItems.Add(dataRow["Ten"].ToString());
					BE8BBBA0.DropDownItems[i - num].Tag = dataRow["id"];
					BE8BBBA0.DropDownItems[i - num].Click += method_7;
				}
				else
				{
					num++;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void F838F8B0(object sender, EventArgs e)
	{
		method_117(6);
	}

	private void C90A602B_MouseEnter(object sender, EventArgs e)
	{
		if (!bool_4)
		{
			return;
		}
		bool_4 = false;
		C90A602B.DropDownItems.Clear();
		List<string> A005DE94 = new List<string>();
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text = "";
				for (int j = 0; j < F5325785.RowCount; j++)
				{
					text = F6061E95(j, "cStatus282");
					if (text != "")
					{
						text = ((!text.Contains("-")) ? text.Split('(')[0].Trim() : text.Split('-')[0].Trim());
						if (text != "" && !A005DE94.Contains(text))
						{
							A005DE94.Add(text);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		});
		thread.Start();
		if (!thread.Join(10000))
		{
			thread.Abort();
		}
		for (int i = 0; i < A005DE94.Count; i++)
		{
			C90A602B.DropDownItems.Add(A005DE94[i]);
			C90A602B.DropDownItems[i].Click += method_148;
		}
	}

	private void method_150(object sender, EventArgs e)
	{
	}

	private void F3B9E732(object sender, EventArgs e)
	{
		if (!method_129())
		{
			return;
		}
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					list.Add(F6061E95(i, "cId"));
				}
			}
			if (CommonSQL.smethod_26(list))
			{
				E48D7F88(null, null);
				MsBoxHelper.Show("Khôi phục thành công!");
			}
			else
			{
				MsBoxHelper.Show("Khôi phục thất bại!", 2);
			}
		}
		catch (Exception)
		{
		}
	}

	private void toolStripMenuItem_37_Click(object sender, EventArgs e)
	{
		if (!method_129())
		{
			return;
		}
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
				{
					list.Add(F6061E95(i, "cId"));
				}
			}
			if (CommonSQL.FC3FE720(list))
			{
				E48D7F88(null, null);
				MsBoxHelper.Show("Khôi phục thành công!");
			}
			else
			{
				MsBoxHelper.Show("Khôi phục thất bại!", 2);
			}
		}
		catch (Exception)
		{
		}
	}

	private void D4B81685(object sender, EventArgs e)
	{
		fChonKichBan2 fChonKichBan3 = new fChonKichBan2();
		fChonKichBan3.ShowDialog();
		string text = fChonKichBan3.string_0;
		if (text == "")
		{
			return;
		}
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			if (Convert.ToBoolean(F5325785.Rows[i].Cells["cChose"].Value))
			{
				method_134(i, "cKichBan", text, "kichban");
			}
		}
	}

	private void C6BE9FB7(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
	}

	private void E2A4F229(object sender, EventArgs e)
	{
		Commom.smethod_35(new fNhapTokenTrungGian());
		if (fNhapTokenTrungGian.bool_0)
		{
			method_122(0);
		}
	}

	private void method_151(object sender, EventArgs e)
	{
		int int_0 = 0;
		int FEA85C18 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count && !Base.smethod_5())
			{
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < FEA85C18)
					{
						Interlocked.Increment(ref int_0);
						int F1272EAD = num++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								method_130(F1272EAD, Language.GetValue("Đang kiểm tra..."));
								string text = F6061E95(F1272EAD, "cUid");
								string input = F6061E95(F1272EAD, "cCookies");
								string text2 = Regex.Match(input, "c_user=(\\d+)").Groups[1].Value.Trim();
								string text3 = "";
								text3 = ((!(text2 == "")) ? ((text == text2) ? "Yes" : "No") : "No uid from cookie");
								method_130(F1272EAD, text3);
							}
							catch
							{
								method_130(F1272EAD, Language.GetValue("Không check đươ\u0323c!"));
							}
							Interlocked.Decrement(ref int_0);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				else
				{
					num++;
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 60000)
			{
				Commom.smethod_52(1.0);
			}
			method_113("stop");
		}).Start();
	}

	private void EEA12224(object sender, EventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void C59CD88B(object sender, EventArgs e)
	{
	}

	private void taoPageFollowToolStripMenuItem_Click(object sender, EventArgs e)
	{
		fCauHinhTaoPage fCauHinhTaoPage2 = new fCauHinhTaoPage();
		fCauHinhTaoPage2.ShowDialog();
		if (fCauHinhTaoPage2.bool_0)
		{
			GClass4 gClass = new GClass4();
			gClass.method_4("TaoPage", true);
			method_12(gClass);
		}
	}

	private void EBA87C91(object sender, EventArgs e)
	{
		fCauHinhTaiAnhTuNhom fCauHinhTaiAnhTuNhom2 = new fCauHinhTaiAnhTuNhom();
		fCauHinhTaiAnhTuNhom2.ShowDialog();
		if (!fCauHinhTaiAnhTuNhom2.BC854A35)
		{
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("TaiAnhTuNhom", true);
		List<string> list = C5034B95.smethod_0("configTaiAnhTuNhom").method_1("txtIdNhom");
		if (list.Count == 0)
		{
			return;
		}
		if (list.Count < method_128())
		{
			int num = list.Count;
			for (int i = 0; i < F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(F6061E95(i, "cChose")))
				{
					num--;
					if (num < 0)
					{
						B183E907(i, "cChose", false);
					}
				}
			}
			EA1B25A9(list.Count);
		}
		AB312AAB = new Queue<string>(list);
		method_12(gClass);
	}

	private void backupGroupToolStripMenuItem_Click(object sender, EventArgs e)
	{
		fCauHinhBackupGroup fCauHinhBackupGroup2 = new fCauHinhBackupGroup();
		Commom.smethod_35(fCauHinhBackupGroup2);
		if (fCauHinhBackupGroup2.A9B7300B)
		{
			GClass4 gClass = new GClass4();
			gClass.method_4("BackupGroup", true);
			method_12(gClass);
		}
	}

	private void E4384FB7(object sender, EventArgs e)
	{
		method_152("CheckBackupGroup");
	}

	private void AA3D8FB3(object sender, EventArgs e)
	{
		method_152("DeleteBackupGroup");
	}

	private void toolStripMenuItem_41_Click(object sender, EventArgs e)
	{
	}

	private void method_152(string BF057BB4, GClass4 gclass4_0 = null)
	{
		int int_0 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		string text = "";
		if (BF057BB4 == "CopyBackupDataFb" || BF057BB4 == "CopyDataDevice")
		{
			text = Commom.smethod_96();
			if (text == "")
			{
				return;
			}
		}
		if (BF057BB4 == "TaoThuMucMedia")
		{
			int_0 = 1;
			gclass4_0.BDB80B23("txtFolderMedia");
			gclass4_0.BDB80B23("txtFolderSave");
		}
		Thread thread = new Thread((ThreadStart)delegate
		{
			List<Thread> list = new List<Thread>();
			int num = 0;
			while (num < F5325785.RowCount)
			{
				if (Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					while (list.Count >= int_0)
					{
						Commom.smethod_52(1.0);
						for (int i = 0; i < list.Count; i++)
						{
							list[i].Join();
							list.RemoveAt(i--);
						}
					}
					int int_ = num++;
					Thread thread2 = new Thread((ThreadStart)delegate
					{
						string text2 = BF057BB4;
						string text3 = text2;
						if (!(text3 == "CheckBackupGroup"))
						{
							if (text3 == "DeleteBackupGroup")
							{
								method_153(int_);
							}
						}
						else
						{
							FBAF7C92(int_);
						}
					});
					list.Add(thread2);
					thread2.IsBackground = true;
					thread2.Start();
				}
				else
				{
					num++;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				list[j].Join();
			}
		});
		thread.IsBackground = true;
		thread.Start();
	}

	private void FBAF7C92(int CD2B4095)
	{
		F6061E95(CD2B4095, "cId");
		string text = F6061E95(CD2B4095, "cUid");
		string path = C5034B95.smethod_0("configBackupGroup").BDB80B23("txtFolderPath", Commom.smethod_95()) + "\\backupgroup\\" + text + ".txt";
		if (File.Exists(path))
		{
			method_130(CD2B4095, Language.GetValue("Đã backup group!"));
		}
		else
		{
			method_130(CD2B4095, Language.GetValue("Chưa backup group!"));
		}
	}

	private void method_153(int int_3)
	{
		F6061E95(int_3, "cId");
		string text = F6061E95(int_3, "cUid");
		string text2 = C5034B95.smethod_0("configBackupGroup").BDB80B23("txtFolderPath", Commom.smethod_95()) + "\\backupgroup\\" + text + ".txt";
		if (File.Exists(text2))
		{
			if (Commom.E10A40B6(text2))
			{
				method_130(int_3, Language.GetValue("Xóa data backup group thành công!"));
			}
			else
			{
				method_130(int_3, Language.GetValue("Xóa data backup group thất bại!"));
			}
		}
		else
		{
			method_130(int_3, Language.GetValue("Chưa backup group!"));
		}
	}

	private void toolStripMenuItem_42_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("Bat2FA", true);
		method_12(gClass);
	}

	private void A2353835(object sender, EventArgs e)
	{
		if (!method_129())
		{
			return;
		}
		Commom.smethod_35(new fCauHinhCheckpoint("282"));
		if (!fCauHinhCheckpoint.E1AD3A3A)
		{
			return;
		}
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbImage") && C5034B95.smethod_0("configCheckpoint").method_2("typeImage") == 0)
		{
			string text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage");
			if (text == "")
			{
				MsBoxHelper.Show("Vui lo\u0300ng chọn đường dẫn folder chứa ảnh", 2);
				return;
			}
			list_3 = Commom.smethod_76(text);
			if (list_3.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng thêm a\u0309nh!", 2);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("Unlock282An", true);
		method_12(gClass);
	}

	private void E10CC3A7_Click(object sender, EventArgs e)
	{
		fCauHinhGetPageProfile fCauHinhGetPageProfile2 = new fCauHinhGetPageProfile();
		fCauHinhGetPageProfile2.ShowDialog();
		if (fCauHinhGetPageProfile2.bool_0)
		{
			File.WriteAllText("pageprofile.txt", "");
			list_4 = new List<string>();
			GClass4 gClass = new GClass4();
			gClass.method_4("GetPageProfile", true);
			method_12(gClass);
		}
	}

	private void findIdFacebookToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchFindIdFb());
	}

	private void A5925737(object sender, EventArgs e)
	{
		fLocTheoDanhSachUid fLocTheoDanhSachUid2 = new fLocTheoDanhSachUid();
		Commom.smethod_35(fLocTheoDanhSachUid2);
		if (fLocTheoDanhSachUid2.list_0.Count > 0)
		{
			List<string> list = Commom.smethod_30(fLocTheoDanhSachUid2.list_0);
			DataTable dataTable_ = CommonSQL.FAACE83A(list, bool_0: true, bool_1: true);
			F5325785.Rows.Clear();
			method_3(dataTable_);
			method_4("All");
		}
	}

	private void A637DF36_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhAI());
	}

	private void E3BC0805(object sender, EventArgs e)
	{
	}

	private void B704D913(int int_3)
	{
		string text = Commom.smethod_96();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < F5325785.Rows.Count; i++)
		{
			if (Convert.ToBoolean(F6061E95(i, "cChose")))
			{
				list.Add(F6061E95(i, "cId"));
			}
		}
		List<string> list2 = new List<string>();
		if (int_3 == 1)
		{
			DataTable dataTable = Class60.EEBF5BBB("DESCRIBE accounts;");
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				list2.Add(dataTable.Rows[j]["Field"].ToString());
			}
		}
		else
		{
			DataTable dataTable2 = Class60.EEBF5BBB("pragma table_info(accounts)");
			for (int k = 0; k < dataTable2.Rows.Count; k++)
			{
				string text2 = dataTable2.Rows[k]["name"].ToString();
				if (!(text2 == "") && !(text2 == ""))
				{
					list2.Add(text2);
				}
			}
		}
		string text3 = "INSERT INTO accounts(" + string.Join(",", list2) + ") VALUES ";
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		for (int l = 0; l < list2.Count; l++)
		{
			if (list2[l] == "id")
			{
				num = l;
			}
			else if (list2[l] == "idfile")
			{
				num2 = l;
			}
			else if (list2[l] == "active")
			{
				num3 = l;
			}
		}
		List<string> list3 = new List<string>();
		DataTable dataTable3 = Class60.EEBF5BBB("select " + string.Join(",", list2) + " from accounts WHERE id IN (" + string.Join(",", list) + ")");
		for (int m = 0; m < dataTable3.Rows.Count; m++)
		{
			List<string> list4 = new List<string>();
			for (int n = 0; n < dataTable3.Rows[m].ItemArray.Length; n++)
			{
				if (n == num)
				{
					list4.Add("null");
				}
				else if (n == num2)
				{
					list4.Add("{idfile}");
				}
				else if (n == num3)
				{
					list4.Add(dataTable3.Rows[m][n].ToString());
				}
				else
				{
					list4.Add("'" + dataTable3.Rows[m][n].ToString().Replace("'", "''") + "'");
				}
			}
			list3.Add("(" + string.Join(",", list4) + ")");
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("pre_sql", text3);
		gClass.FD3CCF90("column", list2);
		gClass.FD3CCF90("data", list3);
		File.WriteAllText(text + "\\data_acc.txt", gClass.ED11179C());
		MsBoxHelper.Show("Xong!");
	}

	private void toolStripMenuItem3_Click(object sender, EventArgs e)
	{
	}

	private void EABAE70C(int C3BF0909)
	{
		string text = Commom.smethod_97("Cho\u0323n file data acc");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		string string_ = File.ReadAllText(text);
		GClass4 gClass = new GClass4(string_, F79F9AB5: true);
		List<string> list = gClass.method_1("data");
		if (list.Count == 0)
		{
			MsBoxHelper.Show("Data không đúng định dạng!");
			return;
		}
		string newValue = D38F4B00.SelectedValue.ToString();
		List<string> list2 = new List<string>();
		if (C3BF0909 == 1)
		{
			DataTable dataTable = Class60.EEBF5BBB("DESCRIBE accounts;");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list2.Add(dataTable.Rows[i]["Field"].ToString());
			}
		}
		else
		{
			DataTable dataTable2 = Class60.EEBF5BBB("pragma table_info(accounts)");
			for (int j = 0; j < dataTable2.Rows.Count; j++)
			{
				list2.Add(dataTable2.Rows[j]["name"].ToString());
			}
		}
		List<string> list3 = gClass.method_1("column").Except(list2).ToList();
		if (list3.Count > 0)
		{
			string text2 = "ALTER TABLE accounts ";
			for (int k = 0; k < list3.Count; k++)
			{
				text2 = text2 + "ADD COLUMN " + list3[k] + " TEXT,";
			}
			Class60.E211632E(text2.TrimEnd(','));
		}
		string text3 = gClass.BDB80B23("pre_sql");
		int num = 1000;
		int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list.Count * 1.0 / 1000.0)));
		for (int l = 0; l < num2; l++)
		{
			string text4 = text3 + string.Join(",", list.GetRange(num * l, (num * l + num <= list.Count) ? num : (list.Count % num)));
			text4 = text4.Replace("{idfile}", newValue);
			Class60.E211632E(text4);
		}
		E48D7F88(null, null);
	}

	private void BF3426B5_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("KichHoatPageVhh", true);
		method_12(gClass);
	}

	private void method_154(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("LoginTiktok", true);
		method_12(gClass);
	}

	private void method_155(object sender, EventArgs e)
	{
		if (!method_129())
		{
			return;
		}
		Commom.smethod_35(new fCauHinhCheckpoint("282"));
		if (!fCauHinhCheckpoint.E1AD3A3A)
		{
			return;
		}
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbImage") && C5034B95.smethod_0("configCheckpoint").method_2("typeImage") == 0)
		{
			string text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage");
			if (text == "")
			{
				MsBoxHelper.Show("Vui lo\u0300ng chọn đường dẫn folder chứa ảnh", 2);
				return;
			}
			list_3 = Commom.smethod_76(text);
			if (list_3.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng thêm a\u0309nh!", 2);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("Unlock282An", true);
		method_12(gClass);
	}

	private void eAAAAToolStripMenuItem_Click(object sender, EventArgs e)
	{
		fCauHinhGetToken fCauHinhGetToken2 = new fCauHinhGetToken();
		fCauHinhGetToken2.ShowDialog();
		if (fCauHinhGetToken2.A4970913)
		{
			GClass4 gClass = new GClass4();
			gClass.method_4("GetTokenEAAAAU", true);
			method_12(gClass);
		}
	}

	private void eAAGToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("GetTokenEAAG", true);
		method_12(gClass);
	}

	private void eAABsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("GetTokenEAABs", true);
		method_12(gClass);
	}

	private void A98F3DB3_Click(object sender, EventArgs e)
	{
	}

	private void A48E28A7_Click(object sender, EventArgs e)
	{
		B704D913(0);
	}

	private void A5BBFD2A_Click(object sender, EventArgs e)
	{
		B704D913(1);
	}

	private void ED95BDA3(object sender, EventArgs e)
	{
		EABAE70C(1);
	}

	private void toolStripMenuItem5_Click(object sender, EventArgs e)
	{
		EABAE70C(0);
	}

	private void B59FA6BF(object sender, EventArgs e)
	{
		B704D913(0);
	}

	private void B4BB860C(object sender, EventArgs e)
	{
		EABAE70C(0);
	}

	private void toolStripMenuItem_43_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fCauHinhCheckpoint("956"));
			if (fCauHinhCheckpoint.E1AD3A3A)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("Unlock956An", true);
				method_12(gClass);
			}
		}
	}

	private void FE90AC2B(object sender, EventArgs e)
	{
		if (method_129())
		{
			Commom.smethod_35(new fCauHinhCheckpoint("956"));
			if (fCauHinhCheckpoint.E1AD3A3A)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("Unlock956", true);
				gClass.method_4("TypeUnlock956", 3);
				method_12(gClass);
			}
		}
	}

	private void checkCountryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		Thread thread = new Thread((ThreadStart)delegate
		{
			method_113("start");
			string string_0 = new RequestXNet().E58EB99F("https://minsoftware.xyz/mapdevelopers");
			if (string_0 == "")
			{
				MsBoxHelper.Show(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
			else
			{
				int num = 0;
				while (num < F5325785.Rows.Count)
				{
					if (Base.smethod_5())
					{
						break;
					}
					if (!Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
					{
						num++;
					}
					else if (int_0 >= int_1)
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
					else
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						Thread thread2 = new Thread((ThreadStart)delegate
						{
							try
							{
								string text = F6061E95(int_2, "cLocation");
								if (text == "")
								{
									text = F6061E95(int_2, "cCurrentCity");
								}
								if (text == "")
								{
									text = F6061E95(int_2, "cHometown");
								}
								if (text == "")
								{
									method_130(int_2, Language.GetValue("Không ti\u0300m thâ\u0301y location!"));
								}
								else
								{
									method_130(int_2, Language.GetValue("Check country..."));
									string json = new RequestXNet().E58EB99F("https://api.opencagedata.com/geocode/v1/json?key=" + string_0 + "&q=" + text.Replace(" Province", "") + "&pretty=1&no_annotations=1");
									string text2 = "";
									try
									{
										text2 = JObject.Parse(json)["results"]![0]!["components"]!["country_code"]!.ToString().ToUpper();
									}
									catch (Exception)
									{
									}
									if (text2 != "")
									{
										method_134(int_2, "cLocation", text2.ToUpper(), "location", F713D5BE: false);
										method_130(int_2, Language.GetValue("Done!"));
									}
									else
									{
										method_130(int_2, Language.GetValue("Empty!"));
									}
								}
							}
							catch (Exception)
							{
								method_130(int_2, Language.GetValue("Error!"));
							}
							Interlocked.Decrement(ref int_0);
						});
						thread2.IsBackground = true;
						thread2.Start();
					}
				}
			}
			method_113("stop");
		});
		thread.IsBackground = true;
		thread.Start();
	}

	private void toolStripMenuItem10_Click(object sender, EventArgs e)
	{
		method_5("cEmail|cPassMail|cMailRecovery|cPassMailRecovery");
	}

	private void F2B3D0B7(object sender, EventArgs e)
	{
		method_114("Pass mail khôi phục");
	}

	private void A1AEFE2E(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchHotmail());
	}

	private void method_156(object sender, EventArgs e)
	{
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.Rows.Count)
			{
				if (Base.smethod_5())
				{
					break;
				}
				if (!Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					num++;
				}
				else if (int_0 >= int_1)
				{
					Application.DoEvents();
					Thread.Sleep(200);
				}
				else
				{
					Interlocked.Increment(ref int_0);
					int DE96B1AC = num++;
					new Thread((ThreadStart)delegate
					{
						try
						{
							method_130(DE96B1AC, "Checking...");
							string text = F6061E95(DE96B1AC, "cEmail");
							string string_ = F6061E95(DE96B1AC, "cPassMail");
							string text2 = D831098B.smethod_0(text, string_);
							if (text2 == "")
							{
								method_130(DE96B1AC, "Login fail, vui lo\u0300ng login chrome rô\u0300i thư\u0309 la\u0323i!");
							}
							else
							{
								string text3 = D831098B.smethod_2(text2);
								if (text3 == "")
								{
									method_130(DE96B1AC, "Get OAuth2 fail!");
								}
								else
								{
									method_130(DE96B1AC, "Success");
									method_134(DE96B1AC, "cOAuth2", text3, "backup");
								}
							}
						}
						catch (Exception)
						{
						}
						Interlocked.Decrement(ref int_0);
					}).Start();
				}
			}
			int tickCount = Environment.TickCount;
			while (int_0 > 0 && Environment.TickCount - tickCount <= 60000)
			{
				Commom.smethod_52(1.0);
			}
			method_113("stop");
		}).Start();
	}

	private void E2B86226(object sender, EventArgs e)
	{
		method_5("cEmail|cPassMail|cOAuth2");
	}

	private void C4A6CD3E_Click(object sender, EventArgs e)
	{
		if (!method_129())
		{
			return;
		}
		Commom.smethod_35(new fCauHinhCheckpoint("282chrome"));
		if (!fCauHinhCheckpoint.E1AD3A3A)
		{
			return;
		}
		if (C5034B95.smethod_0("configCheckpoint").method_3("ckbImage") && C5034B95.smethod_0("configCheckpoint").method_2("typeImage") == 0)
		{
			string text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage");
			if (text == "")
			{
				MsBoxHelper.Show("Vui lo\u0300ng chọn đường dẫn folder chứa ảnh", 2);
				return;
			}
			list_3 = Commom.smethod_76(text);
			if (list_3.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng thêm a\u0309nh!", 2);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("Unlock282", true);
		method_12(gClass);
	}

	private void BB8A908F_Click(object sender, EventArgs e)
	{
		method_114("OAuth2");
	}

	private void toolStripMenuItem_45_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			GClass4 gClass = new GClass4();
			gClass.method_4("GetOAuth2", true);
			C4269420(gClass);
		}
	}

	private void D58DA917(object sender, EventArgs e)
	{
		method_157(delegate(int int_3)
		{
			method_130(int_3, "Checking...");
			string text = F6061E95(int_3, "cEmail");
			string string_ = F6061E95(int_3, "cPassMail");
			string text2 = D831098B.smethod_0(text, string_);
			if (text2 == "")
			{
				method_130(int_3, "Login fail, vui lo\u0300ng login chrome rô\u0300i thư\u0309 la\u0323i!");
			}
			else
			{
				method_134(int_3, "cCookieHotmail", text2, "cookieHotmail", F713D5BE: false);
				string text3 = D831098B.smethod_2(text2);
				if (text3 == "")
				{
					method_130(int_3, "Fail!");
					C412B9A5(int_3, 1);
				}
				else
				{
					method_130(int_3, "Success!");
					C412B9A5(int_3, 2);
					method_134(int_3, "cOAuth2", text3, "backup");
				}
			}
		});
	}

	private void method_157(Action<int> action_0)
	{
		int FB36983C = 0;
		int int_0 = C5034B95.smethod_0("configGeneral").method_2("nudInteractThread", 3);
		Base.smethod_6(bool_9: false);
		new Thread((ThreadStart)delegate
		{
			method_113("start");
			int num = 0;
			while (num < F5325785.RowCount)
			{
				if (Base.smethod_5())
				{
					break;
				}
				if (!Convert.ToBoolean(F5325785.Rows[num].Cells["cChose"].Value))
				{
					num++;
				}
				else if (FB36983C >= int_0)
				{
					Commom.smethod_52(1.0);
				}
				else
				{
					Interlocked.Increment(ref FB36983C);
					int int_ = num++;
					new Thread((ThreadStart)delegate
					{
						try
						{
							action_0(int_);
						}
						catch (Exception)
						{
						}
						Interlocked.Decrement(ref FB36983C);
					}).Start();
				}
			}
			int tickCount = Environment.TickCount;
			while (FB36983C > 0 && Environment.TickCount - tickCount <= 60000)
			{
				Commom.smethod_52(1.0);
			}
			method_113("stop");
		}).Start();
	}

	private void E6A7F1A1(object sender, EventArgs e)
	{
		int F20C7B26 = 0;
		int int_0 = 10;
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < F5325785.RowCount)
			{
				if (!Convert.ToBoolean(F6061E95(num, "cChose")))
				{
					num++;
				}
				else if (F20C7B26 >= int_0)
				{
					Application.DoEvents();
					Thread.Sleep(200);
				}
				else
				{
					Interlocked.Increment(ref F20C7B26);
					int int_ = num++;
					new Thread((ThreadStart)delegate
					{
						method_130(int_, "Checking...");
						try
						{
							string text = F6061E95(int_, "cEmail").Trim().ToLower();
							string text2 = F6061E95(int_, "cEmail2").Trim().ToLower();
							if (text == "" || text2 == "")
							{
								method_130(int_, Language.GetValue("Không đu\u0309 thông tin!"));
								return;
							}
							if (text2.Contains(text))
							{
								method_130(int_, "Yes");
							}
							else
							{
								method_130(int_, "No");
							}
						}
						catch
						{
						}
						Interlocked.Decrement(ref F20C7B26);
					}).Start();
				}
			}
		}).Start();
	}

	private void E88CFB1A_Click(object sender, EventArgs e)
	{
		if (method_129())
		{
			fCauHinhHotmail fCauHinhHotmail2 = new fCauHinhHotmail("LoginHotmail");
			Commom.smethod_35(fCauHinhHotmail2);
			if (fCauHinhHotmail2.bool_0)
			{
				GClass4 gClass = new GClass4();
				gClass.method_4("LoginHotmail", true);
				C4269420(gClass);
			}
		}
	}

	private void BEB1F03C_Click(object sender, EventArgs e)
	{
		method_157(delegate(int DF2A5030)
		{
			method_130(DF2A5030, "Checking...");
			string text = F6061E95(DF2A5030, "cEmail");
			string string_ = F6061E95(DF2A5030, "cPassMail");
			string text2 = D831098B.smethod_0(text, string_);
			if (text2 == "")
			{
				method_130(DF2A5030, "Login fail, vui lo\u0300ng login chrome rô\u0300i thư\u0309 la\u0323i!");
				C412B9A5(DF2A5030, 1);
			}
			else
			{
				method_134(DF2A5030, "cCookieHotmail", text2, "cookieHotmail", F713D5BE: false);
				method_130(DF2A5030, "Success!");
				C412B9A5(DF2A5030, 2);
			}
		});
	}

	private void C7BD1D91_Click(object sender, EventArgs e)
	{
		if (F5325785.SelectedRows.Count > 0)
		{
			string string_ = F6061E95(F5325785.SelectedRows[0].Index, "cUid");
			Commom.smethod_35(new fCauHinhTaiKhoan(string_));
		}
	}

	private void chayToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("OpenBrowser", true);
		gClass.method_4("TinhNangKhac", true);
		method_12(gClass);
	}

	private void toolStripMenuItem_46_Click(object sender, EventArgs e)
	{
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctmsAcc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FC8A5097 = new System.Windows.Forms.ToolStripMenuItem();
            this.EEAB969B = new System.Windows.Forms.ToolStripMenuItem();
            this.tinhTrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_31 = new System.Windows.Forms.ToolStripMenuItem();
            this.F881A71F = new System.Windows.Forms.ToolStripMenuItem();
            this.C90A602B = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_36 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_33 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_14 = new System.Windows.Forms.ToolStripMenuItem();
            this.uidPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uidPass2FaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.A6A5633B = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.CB044085 = new System.Windows.Forms.ToolStripMenuItem();
            this.uidPassTokenCookieMailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useragentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.E503C69C = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmsTinhNangKhac = new System.Windows.Forms.ToolStripMenuItem();
            this.chayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.C7BD1D91 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.A492F617 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_11 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInfoUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_30 = new System.Windows.Forms.ToolStripMenuItem();
            this.B10418B3 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInfoUidtokenTrungGianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_34 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_35 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkProfileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.D1AFCCA3 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_19 = new System.Windows.Forms.ToolStripMenuItem();
            this.uidUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_9 = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.C698B335 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_12 = new System.Windows.Forms.ToolStripMenuItem();
            this.F4263206 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_26 = new System.Windows.Forms.ToolStripMenuItem();
            this.BB8A908F = new System.Windows.Forms.ToolStripMenuItem();
            this.BC007112 = new System.Windows.Forms.ToolStripMenuItem();
            this.C00BE82A = new System.Windows.Forms.ToolStripMenuItem();
            this.DAB92DAC = new System.Windows.Forms.ToolStripMenuItem();
            this.A8162791 = new System.Windows.Forms.ToolStripMenuItem();
            this.B6161039 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.FA1B6D17 = new System.Windows.Forms.ToolStripMenuItem();
            this.BE8BBBA0 = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.C2207E1A = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_37 = new System.Windows.Forms.ToolStripMenuItem();
            this.C29582AA = new System.Windows.Forms.ToolStripMenuItem();
            this.BA219202 = new System.Windows.Forms.ToolStripMenuItem();
            this.AD93A60F = new System.Windows.Forms.ToolStripMenuItem();
            this.D804239D = new System.Windows.Forms.ToolStripMenuItem();
            this.E39B6092 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_39 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNameVNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_23 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkCountryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.CF3F68BB = new System.Windows.Forms.ToolStripMenuItem();
            this.A211BD94 = new System.Windows.Forms.ToolStripMenuItem();
            this.C2140F32 = new System.Windows.Forms.ToolStripMenuItem();
            this.compareEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.B298AA35 = new System.Windows.Forms.ToolStripMenuItem();
            this.E88CFB1A = new System.Windows.Forms.ToolStripMenuItem();
            this.BEB1F03C = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_28 = new System.Windows.Forms.ToolStripMenuItem();
            this.B1809B27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_45 = new System.Windows.Forms.ToolStripMenuItem();
            this.CEB9A490 = new System.Windows.Forms.ToolStripMenuItem();
            this.B60BD1B5 = new System.Windows.Forms.ToolStripMenuItem();
            this.getTokenEAAAAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eAAAAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eAAGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eAABsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_42 = new System.Windows.Forms.ToolStripMenuItem();
            this.taoPageFollowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_40 = new System.Windows.Forms.ToolStripMenuItem();
            this.E10CC3A7 = new System.Windows.Forms.ToolStripMenuItem();
            this.BEA6D0A0 = new System.Windows.Forms.ToolStripMenuItem();
            this.A48E28A7 = new System.Windows.Forms.ToolStripMenuItem();
            this.A5BBFD2A = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.BF3426B5 = new System.Windows.Forms.ToolStripMenuItem();
            this.A10EFE26 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_13 = new System.Windows.Forms.ToolStripMenuItem();
            this.CA31F826 = new System.Windows.Forms.ToolStripMenuItem();
            this.FA11F02A = new System.Windows.Forms.ToolStripMenuItem();
            this.FFA8771A = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBackupGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkFileBackupGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.B2A40FA8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_41 = new System.Windows.Forms.ToolStripMenuItem();
            this.giaiCheckpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.C4A6CD3E = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_38 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_44 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_43 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_46 = new System.Windows.Forms.ToolStripMenuItem();
            this.E3AACC35 = new System.Windows.Forms.ToolStripMenuItem();
            this.getTokenEAAAAUBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EA382128 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.FBA31BBA = new System.Windows.Forms.Panel();
            this.picLanguage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.E836E3B2 = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.ADA8C634 = new System.Windows.Forms.Button();
            this.B526D03A = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.D39C9728 = new System.Windows.Forms.MenuStrip();
            this.C72EAE3C = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_18 = new System.Windows.Forms.ToolStripMenuItem();
            this.findIdFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLiveUidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.F08308B5 = new System.Windows.Forms.ToolStripMenuItem();
            this.EF359EB3 = new System.Windows.Forms.ToolStripMenuItem();
            this.A681EC38 = new System.Windows.Forms.ToolStripMenuItem();
            this.D090E02D = new System.Windows.Forms.ToolStripMenuItem();
            this.A70D7D81 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.testSpinTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.E51F2F23 = new System.Windows.Forms.ToolStripMenuItem();
            this.A637DF36 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_22 = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnInteract = new System.Windows.Forms.Button();
            this.AddFileAccount = new System.Windows.Forms.Button();
            this.D1117A83 = new System.Windows.Forms.Button();
            this.btnEditFile = new System.Windows.Forms.Button();
            this.btnLoadAcc = new System.Windows.Forms.Button();
            this.plTrangThai = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.F7121228 = new System.Windows.Forms.StatusStrip();
            this.A3864980 = new System.Windows.Forms.ToolStripStatusLabel();
            this.C3919999 = new System.Windows.Forms.ToolStripStatusLabel();
            this.B9BED82A = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKey = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.A5376CB6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CC9D630E = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateExpried = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountHighline = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.D81D001E = new System.Windows.Forms.ToolStripStatusLabel();
            this.metroButton1 = new System.Windows.Forms.Button();
            this.DC993629 = new System.Windows.Forms.Panel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.cbbSearch = new System.Windows.Forms.ComboBox();
            this.txbSearch = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.plQuanLyThuMuc = new System.Windows.Forms.Panel();
            this.FE921A1C = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CA9D953A = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.D38F4B00 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.D7A63B91 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.F5325785 = new System.Windows.Forms.DataGridView();
            this.cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCookies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmail2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMailRecovery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPassMailRecovery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFollow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFriend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPagePro5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOAuth2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUseragent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateCreateAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cThuMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInteractEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus282 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHometown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCurrentCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWallPosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFbBlock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCookieHotmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer_0 = new System.Windows.Forms.Timer(this.components);
            this.ctmsAcc.SuspendLayout();
            this.FBA31BBA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.D39C9728.SuspendLayout();
            this.plTrangThai.SuspendLayout();
            this.DC993629.SuspendLayout();
            this.plQuanLyThuMuc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F5325785)).BeginInit();
            this.SuspendLayout();
            // 
            // ctmsAcc
            // 
            this.ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_1,
            this.toolStripMenuItem_4,
            this.toolStripMenuItem_36,
            this.toolStripMenuItem1,
            this.toolStripMenuItem_32,
            this.toolStripMenuItem_33,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem_2,
            this.ctmsTinhNangKhac,
            this.toolStripMenuItem_3,
            this.A492F617,
            this.toolStripMenuItem_8,
            this.BE8BBBA0,
            this.databaseToolStripMenuItem,
            this.C29582AA,
            this.hotmailToolStripMenuItem,
            this.B60BD1B5,
            this.A10EFE26,
            this.dataBackupGroupToolStripMenuItem,
            this.giaiCheckpointToolStripMenuItem,
            this.toolStripMenuItem_7,
            this.toolStripMenuItem_46});
            this.ctmsAcc.Name = "ctmsAcc";
            this.ctmsAcc.Size = new System.Drawing.Size(201, 488);
            this.ctmsAcc.Opening += new System.ComponentModel.CancelEventHandler(this.AA0AEBBB);
            // 
            // toolStripMenuItem_1
            // 
            this.toolStripMenuItem_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FC8A5097,
            this.EEAB969B,
            this.tinhTrangToolStripMenuItem,
            this.toolStripMenuItem_10,
            this.toolStripMenuItem_31,
            this.F881A71F,
            this.C90A602B});
            this.toolStripMenuItem_1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_1.Image")));
            this.toolStripMenuItem_1.Name = "toolStripMenuItem_1";
            this.toolStripMenuItem_1.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_1.Text = "Chọn";
            // 
            // FC8A5097
            // 
            this.FC8A5097.Image = ((System.Drawing.Image)(resources.GetObject("FC8A5097.Image")));
            this.FC8A5097.Name = "FC8A5097";
            this.FC8A5097.Size = new System.Drawing.Size(128, 22);
            this.FC8A5097.Text = "Tất cả";
            this.FC8A5097.Click += new System.EventHandler(this.FC8A5097_Click);
            // 
            // EEAB969B
            // 
            this.EEAB969B.Image = ((System.Drawing.Image)(resources.GetObject("EEAB969B.Image")));
            this.EEAB969B.Name = "EEAB969B";
            this.EEAB969B.Size = new System.Drawing.Size(128, 22);
            this.EEAB969B.Text = "Bôi đen";
            this.EEAB969B.Click += new System.EventHandler(this.EEAB969B_Click);
            // 
            // tinhTrangToolStripMenuItem
            // 
            this.tinhTrangToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tinhTrangToolStripMenuItem.Image")));
            this.tinhTrangToolStripMenuItem.Name = "tinhTrangToolStripMenuItem";
            this.tinhTrangToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.tinhTrangToolStripMenuItem.Text = "Tình trạng";
            // 
            // toolStripMenuItem_10
            // 
            this.toolStripMenuItem_10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_10.Image")));
            this.toolStripMenuItem_10.Name = "toolStripMenuItem_10";
            this.toolStripMenuItem_10.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem_10.Text = "Trạng thái";
            this.toolStripMenuItem_10.Click += new System.EventHandler(this.A921DA1B);
            // 
            // toolStripMenuItem_31
            // 
            this.toolStripMenuItem_31.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_31.Image")));
            this.toolStripMenuItem_31.Name = "toolStripMenuItem_31";
            this.toolStripMenuItem_31.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem_31.Text = "Theo Uid";
            this.toolStripMenuItem_31.Click += new System.EventHandler(this.EDBC0522);
            // 
            // F881A71F
            // 
            this.F881A71F.Image = ((System.Drawing.Image)(resources.GetObject("F881A71F.Image")));
            this.F881A71F.Name = "F881A71F";
            this.F881A71F.Size = new System.Drawing.Size(128, 22);
            this.F881A71F.Text = "Ghi chú";
            this.F881A71F.MouseEnter += new System.EventHandler(this.F881A71F_MouseEnter);
            // 
            // C90A602B
            // 
            this.C90A602B.Image = ((System.Drawing.Image)(resources.GetObject("C90A602B.Image")));
            this.C90A602B.Name = "C90A602B";
            this.C90A602B.Size = new System.Drawing.Size(128, 22);
            this.C90A602B.Text = "Status 282";
            this.C90A602B.MouseEnter += new System.EventHandler(this.C90A602B_MouseEnter);
            // 
            // toolStripMenuItem_4
            // 
            this.toolStripMenuItem_4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_4.Image")));
            this.toolStripMenuItem_4.Name = "toolStripMenuItem_4";
            this.toolStripMenuItem_4.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_4.Text = "Bỏ chọn";
            this.toolStripMenuItem_4.Click += new System.EventHandler(this.D422C22F);
            // 
            // toolStripMenuItem_36
            // 
            this.toolStripMenuItem_36.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_36.Image")));
            this.toolStripMenuItem_36.Name = "toolStripMenuItem_36";
            this.toolStripMenuItem_36.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_36.Text = "Ẩn đã chọn";
            this.toolStripMenuItem_36.Click += new System.EventHandler(this.D82ABB0C);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem1.Text = "Ẩn chưa chọn";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem_32
            // 
            this.toolStripMenuItem_32.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_32.Image")));
            this.toolStripMenuItem_32.Name = "toolStripMenuItem_32";
            this.toolStripMenuItem_32.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_32.Text = "Nhập Proxy";
            this.toolStripMenuItem_32.Click += new System.EventHandler(this.toolStripMenuItem_32_Click);
            // 
            // toolStripMenuItem_33
            // 
            this.toolStripMenuItem_33.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_33.Image")));
            this.toolStripMenuItem_33.Name = "toolStripMenuItem_33";
            this.toolStripMenuItem_33.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_33.Text = "Nhập UA";
            this.toolStripMenuItem_33.Click += new System.EventHandler(this.toolStripMenuItem_33_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uidToolStripMenuItem,
            this.passToolStripMenuItem,
            this.tokenToolStripMenuItem,
            this.cookieToolStripMenuItem,
            this.mailToolStripMenuItem,
            this.fAToolStripMenuItem,
            this.toolStripMenuItem_14,
            this.uidPassToolStripMenuItem,
            this.uidPass2FaToolStripMenuItem,
            this.mailPassMailToolStripMenuItem,
            this.A6A5633B,
            this.toolStripMenuItem10,
            this.toolStripMenuItem15,
            this.CB044085,
            this.uidPassTokenCookieMailPassMailToolStripMenuItem,
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem,
            this.useragentToolStripMenuItem1,
            this.proxyToolStripMenuItem1,
            this.E503C69C});
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // uidToolStripMenuItem
            // 
            this.uidToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidToolStripMenuItem.Image")));
            this.uidToolStripMenuItem.Name = "uidToolStripMenuItem";
            this.uidToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.uidToolStripMenuItem.Text = "Uid";
            this.uidToolStripMenuItem.Click += new System.EventHandler(this.DBA27319);
            // 
            // passToolStripMenuItem
            // 
            this.passToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passToolStripMenuItem.Image")));
            this.passToolStripMenuItem.Name = "passToolStripMenuItem";
            this.passToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.passToolStripMenuItem.Text = "Pass";
            this.passToolStripMenuItem.Click += new System.EventHandler(this.passToolStripMenuItem_Click);
            // 
            // tokenToolStripMenuItem
            // 
            this.tokenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tokenToolStripMenuItem.Image")));
            this.tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
            this.tokenToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.tokenToolStripMenuItem.Text = "Token";
            this.tokenToolStripMenuItem.Click += new System.EventHandler(this.tokenToolStripMenuItem_Click);
            // 
            // cookieToolStripMenuItem
            // 
            this.cookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cookieToolStripMenuItem.Image")));
            this.cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
            this.cookieToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.cookieToolStripMenuItem.Text = "Cookie";
            this.cookieToolStripMenuItem.Click += new System.EventHandler(this.C5106CA9);
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mailToolStripMenuItem.Image")));
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.mailToolStripMenuItem.Text = "Email";
            this.mailToolStripMenuItem.Click += new System.EventHandler(this.mailToolStripMenuItem_Click);
            // 
            // fAToolStripMenuItem
            // 
            this.fAToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fAToolStripMenuItem.Image")));
            this.fAToolStripMenuItem.Name = "fAToolStripMenuItem";
            this.fAToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.fAToolStripMenuItem.Text = "2FA";
            this.fAToolStripMenuItem.Click += new System.EventHandler(this.A60AECB8);
            // 
            // toolStripMenuItem_14
            // 
            this.toolStripMenuItem_14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_14.Image")));
            this.toolStripMenuItem_14.Name = "toolStripMenuItem_14";
            this.toolStripMenuItem_14.Size = new System.Drawing.Size(289, 22);
            this.toolStripMenuItem_14.Text = "Mã bảo mật 6 số từ 2FA";
            this.toolStripMenuItem_14.Click += new System.EventHandler(this.toolStripMenuItem_14_Click);
            // 
            // uidPassToolStripMenuItem
            // 
            this.uidPassToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidPassToolStripMenuItem.Image")));
            this.uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
            this.uidPassToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.uidPassToolStripMenuItem.Text = "Uid|Pass";
            this.uidPassToolStripMenuItem.Click += new System.EventHandler(this.uidPassToolStripMenuItem_Click);
            // 
            // uidPass2FaToolStripMenuItem
            // 
            this.uidPass2FaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidPass2FaToolStripMenuItem.Image")));
            this.uidPass2FaToolStripMenuItem.Name = "uidPass2FaToolStripMenuItem";
            this.uidPass2FaToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.uidPass2FaToolStripMenuItem.Text = "Uid|Pass|2Fa";
            this.uidPass2FaToolStripMenuItem.Click += new System.EventHandler(this.C9B597B7);
            // 
            // mailPassMailToolStripMenuItem
            // 
            this.mailPassMailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mailPassMailToolStripMenuItem.Image")));
            this.mailPassMailToolStripMenuItem.Name = "mailPassMailToolStripMenuItem";
            this.mailPassMailToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.mailPassMailToolStripMenuItem.Text = "Mail|Pass mail";
            this.mailPassMailToolStripMenuItem.Click += new System.EventHandler(this.mailPassMailToolStripMenuItem_Click);
            // 
            // A6A5633B
            // 
            this.A6A5633B.Image = ((System.Drawing.Image)(resources.GetObject("A6A5633B.Image")));
            this.A6A5633B.Name = "A6A5633B";
            this.A6A5633B.Size = new System.Drawing.Size(289, 22);
            this.A6A5633B.Text = "Email|PassMail|MailKp";
            this.A6A5633B.Click += new System.EventHandler(this.B8A44DA7);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(289, 22);
            this.toolStripMenuItem10.Text = "Email|PassMail|MailKp|Pass MailKp";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem15.Image")));
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(289, 22);
            this.toolStripMenuItem15.Text = "Email|PassMail|Refresh_token|Client_id";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.E2B86226);
            // 
            // CB044085
            // 
            this.CB044085.Image = ((System.Drawing.Image)(resources.GetObject("CB044085.Image")));
            this.CB044085.Name = "CB044085";
            this.CB044085.Size = new System.Drawing.Size(289, 22);
            this.CB044085.Text = "Uid|Pass|Token|Cookie";
            this.CB044085.Click += new System.EventHandler(this.E63B6D29);
            // 
            // uidPassTokenCookieMailPassMailToolStripMenuItem
            // 
            this.uidPassTokenCookieMailPassMailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidPassTokenCookieMailPassMailToolStripMenuItem.Image")));
            this.uidPassTokenCookieMailPassMailToolStripMenuItem.Name = "uidPassTokenCookieMailPassMailToolStripMenuItem";
            this.uidPassTokenCookieMailPassMailToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.uidPassTokenCookieMailPassMailToolStripMenuItem.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail";
            this.uidPassTokenCookieMailPassMailToolStripMenuItem.Click += new System.EventHandler(this.BD963BA5);
            // 
            // uidPassTokenCookieMailPassMail2faToolStripMenuItem
            // 
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image")));
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem.Name = "uidPassTokenCookieMailPassMail2faToolStripMenuItem";
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail|2fa";
            this.uidPassTokenCookieMailPassMail2faToolStripMenuItem.Click += new System.EventHandler(this.uidPassTokenCookieMailPassMail2faToolStripMenuItem_Click);
            // 
            // useragentToolStripMenuItem1
            // 
            this.useragentToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("useragentToolStripMenuItem1.Image")));
            this.useragentToolStripMenuItem1.Name = "useragentToolStripMenuItem1";
            this.useragentToolStripMenuItem1.Size = new System.Drawing.Size(289, 22);
            this.useragentToolStripMenuItem1.Text = "Useragent";
            this.useragentToolStripMenuItem1.Click += new System.EventHandler(this.useragentToolStripMenuItem1_Click);
            // 
            // proxyToolStripMenuItem1
            // 
            this.proxyToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("proxyToolStripMenuItem1.Image")));
            this.proxyToolStripMenuItem1.Name = "proxyToolStripMenuItem1";
            this.proxyToolStripMenuItem1.Size = new System.Drawing.Size(289, 22);
            this.proxyToolStripMenuItem1.Text = "Proxy";
            this.proxyToolStripMenuItem1.Click += new System.EventHandler(this.proxyToolStripMenuItem1_Click);
            // 
            // E503C69C
            // 
            this.E503C69C.Image = ((System.Drawing.Image)(resources.GetObject("E503C69C.Image")));
            this.E503C69C.Name = "E503C69C";
            this.E503C69C.Size = new System.Drawing.Size(289, 22);
            this.E503C69C.Text = "Other...";
            this.E503C69C.Click += new System.EventHandler(this.FB93C785);
            // 
            // toolStripMenuItem_2
            // 
            this.toolStripMenuItem_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_21,
            this.toolStripMenuItem_20});
            this.toolStripMenuItem_2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_2.Image")));
            this.toolStripMenuItem_2.Name = "toolStripMenuItem_2";
            this.toolStripMenuItem_2.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_2.Text = "Mở Chrome";
            // 
            // toolStripMenuItem_21
            // 
            this.toolStripMenuItem_21.Name = "toolStripMenuItem_21";
            this.toolStripMenuItem_21.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_21.Text = "Tiến hành mở";
            this.toolStripMenuItem_21.Click += new System.EventHandler(this.toolStripMenuItem_21_Click);
            // 
            // toolStripMenuItem_20
            // 
            this.toolStripMenuItem_20.Name = "toolStripMenuItem_20";
            this.toolStripMenuItem_20.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_20.Text = "Cài đặt cấu hình mở";
            this.toolStripMenuItem_20.Click += new System.EventHandler(this.toolStripMenuItem_20_Click);
            // 
            // ctmsTinhNangKhac
            // 
            this.ctmsTinhNangKhac.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chayToolStripMenuItem,
            this.C7BD1D91});
            this.ctmsTinhNangKhac.Image = ((System.Drawing.Image)(resources.GetObject("ctmsTinhNangKhac.Image")));
            this.ctmsTinhNangKhac.Name = "ctmsTinhNangKhac";
            this.ctmsTinhNangKhac.Size = new System.Drawing.Size(200, 22);
            this.ctmsTinhNangKhac.Text = "Tính năng khác";
            // 
            // chayToolStripMenuItem
            // 
            this.chayToolStripMenuItem.Name = "chayToolStripMenuItem";
            this.chayToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.chayToolStripMenuItem.Text = "Chạy";
            this.chayToolStripMenuItem.Click += new System.EventHandler(this.chayToolStripMenuItem_Click);
            // 
            // C7BD1D91
            // 
            this.C7BD1D91.Name = "C7BD1D91";
            this.C7BD1D91.Size = new System.Drawing.Size(122, 22);
            this.C7BD1D91.Text = "Cấu hình";
            this.C7BD1D91.Click += new System.EventHandler(this.C7BD1D91_Click);
            // 
            // toolStripMenuItem_3
            // 
            this.toolStripMenuItem_3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_3.Image")));
            this.toolStripMenuItem_3.Name = "toolStripMenuItem_3";
            this.toolStripMenuItem_3.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_3.Text = "Xóa nick";
            this.toolStripMenuItem_3.Click += new System.EventHandler(this.DE88263A);
            // 
            // A492F617
            // 
            this.A492F617.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_11,
            this.checkInfoUIDToolStripMenuItem,
            this.checkInfoUidtokenTrungGianToolStripMenuItem,
            this.toolStripMenuItem_6,
            this.toolStripMenuItem_5,
            this.checkAvatarToolStripMenuItem,
            this.checkProfileToolStripMenuItem1,
            this.D1AFCCA3,
            this.checkProxyToolStripMenuItem});
            this.A492F617.Image = ((System.Drawing.Image)(resources.GetObject("A492F617.Image")));
            this.A492F617.Name = "A492F617";
            this.A492F617.Size = new System.Drawing.Size(200, 22);
            this.A492F617.Text = "Kiểm tra";
            this.A492F617.Click += new System.EventHandler(this.EEBD2C9A);
            // 
            // toolStripMenuItem_11
            // 
            this.toolStripMenuItem_11.Name = "toolStripMenuItem_11";
            this.toolStripMenuItem_11.Size = new System.Drawing.Size(251, 22);
            this.toolStripMenuItem_11.Text = "Check Wall";
            this.toolStripMenuItem_11.ToolTipText = "Không cần dùng token";
            this.toolStripMenuItem_11.Click += new System.EventHandler(this.E7899D3A);
            // 
            // checkInfoUIDToolStripMenuItem
            // 
            this.checkInfoUIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_30,
            this.B10418B3});
            this.checkInfoUIDToolStripMenuItem.Name = "checkInfoUIDToolStripMenuItem";
            this.checkInfoUIDToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.checkInfoUIDToolStripMenuItem.Text = "Check Info Uid";
            this.checkInfoUIDToolStripMenuItem.ToolTipText = "Không cần dùng token\r\nCập nhật thông tin: Họ tên, Giớ́i tính, [Email], [Bạn " +
    "bè], [Nhóm], [Ngày sinh]";
            // 
            // toolStripMenuItem_30
            // 
            this.toolStripMenuItem_30.Name = "toolStripMenuItem_30";
            this.toolStripMenuItem_30.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem_30.Text = "Không đổi IP";
            this.toolStripMenuItem_30.Click += new System.EventHandler(this.C4A352A3);
            // 
            // B10418B3
            // 
            this.B10418B3.Name = "B10418B3";
            this.B10418B3.Size = new System.Drawing.Size(190, 22);
            this.B10418B3.Text = "Sử dụng proxy đã gán";
            this.B10418B3.Click += new System.EventHandler(this.B39C7333);
            // 
            // checkInfoUidtokenTrungGianToolStripMenuItem
            // 
            this.checkInfoUidtokenTrungGianToolStripMenuItem.Name = "checkInfoUidtokenTrungGianToolStripMenuItem";
            this.checkInfoUidtokenTrungGianToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.checkInfoUidtokenTrungGianToolStripMenuItem.Text = "Check Info Uid (token trung gian)";
            this.checkInfoUidtokenTrungGianToolStripMenuItem.Click += new System.EventHandler(this.E2A4F229);
            // 
            // toolStripMenuItem_6
            // 
            this.toolStripMenuItem_6.Name = "toolStripMenuItem_6";
            this.toolStripMenuItem_6.Size = new System.Drawing.Size(251, 22);
            this.toolStripMenuItem_6.Text = "Check Token";
            this.toolStripMenuItem_6.Click += new System.EventHandler(this.toolStripMenuItem_6_Click);
            // 
            // toolStripMenuItem_5
            // 
            this.toolStripMenuItem_5.Name = "toolStripMenuItem_5";
            this.toolStripMenuItem_5.Size = new System.Drawing.Size(251, 22);
            this.toolStripMenuItem_5.Text = "Check Cookie";
            this.toolStripMenuItem_5.Click += new System.EventHandler(this.FCA02421);
            // 
            // checkAvatarToolStripMenuItem
            // 
            this.checkAvatarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_34,
            this.toolStripMenuItem_35});
            this.checkAvatarToolStripMenuItem.Name = "checkAvatarToolStripMenuItem";
            this.checkAvatarToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.checkAvatarToolStripMenuItem.Text = "Check Avatar";
            this.checkAvatarToolStripMenuItem.Click += new System.EventHandler(this.F838F8B0);
            // 
            // toolStripMenuItem_34
            // 
            this.toolStripMenuItem_34.Name = "toolStripMenuItem_34";
            this.toolStripMenuItem_34.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem_34.Text = "Không đổi IP";
            this.toolStripMenuItem_34.Click += new System.EventHandler(this.D090E13A);
            // 
            // toolStripMenuItem_35
            // 
            this.toolStripMenuItem_35.Name = "toolStripMenuItem_35";
            this.toolStripMenuItem_35.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem_35.Text = "Sử dụng proxy đã gán";
            this.toolStripMenuItem_35.Click += new System.EventHandler(this.toolStripMenuItem_35_Click);
            // 
            // checkProfileToolStripMenuItem1
            // 
            this.checkProfileToolStripMenuItem1.Name = "checkProfileToolStripMenuItem1";
            this.checkProfileToolStripMenuItem1.Size = new System.Drawing.Size(251, 22);
            this.checkProfileToolStripMenuItem1.Text = "Check Profile";
            this.checkProfileToolStripMenuItem1.Click += new System.EventHandler(this.checkProfileToolStripMenuItem_Click);
            // 
            // D1AFCCA3
            // 
            this.D1AFCCA3.Name = "D1AFCCA3";
            this.D1AFCCA3.Size = new System.Drawing.Size(251, 22);
            this.D1AFCCA3.Text = "Check Connect Hotmail";
            this.D1AFCCA3.Click += new System.EventHandler(this.B52F3938);
            // 
            // checkProxyToolStripMenuItem
            // 
            this.checkProxyToolStripMenuItem.Name = "checkProxyToolStripMenuItem";
            this.checkProxyToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.checkProxyToolStripMenuItem.Text = "Check Proxy";
            this.checkProxyToolStripMenuItem.Click += new System.EventHandler(this.checkProxyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_8
            // 
            this.toolStripMenuItem_8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_19,
            this.uidUpdateToolStripMenuItem,
            this.toolStripMenuItem_9,
            this.tokenToolStripMenuItem2,
            this.C698B335,
            this.toolStripMenuItem_12,
            this.F4263206,
            this.toolStripMenuItem_26,
            this.BB8A908F,
            this.BC007112,
            this.C00BE82A,
            this.DAB92DAC,
            this.A8162791,
            this.B6161039,
            this.toolStripMenuItem_29,
            this.toolStripMenuItem12,
            this.phoneToolStripMenuItem,
            this.toolStripMenuItem11,
            this.FA1B6D17});
            this.toolStripMenuItem_8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_8.Image")));
            this.toolStripMenuItem_8.Name = "toolStripMenuItem_8";
            this.toolStripMenuItem_8.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_8.Text = "Cập nhật";
            // 
            // toolStripMenuItem_19
            // 
            this.toolStripMenuItem_19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_19.Image")));
            this.toolStripMenuItem_19.Name = "toolStripMenuItem_19";
            this.toolStripMenuItem_19.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_19.Text = "Cập nhật hàng loạt";
            this.toolStripMenuItem_19.Click += new System.EventHandler(this.toolStripMenuItem_19_Click);
            // 
            // uidUpdateToolStripMenuItem
            // 
            this.uidUpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uidToolStripMenuItem.Image")));
            this.uidUpdateToolStripMenuItem.Name = "uidUpdateToolStripMenuItem";
            this.uidUpdateToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.uidUpdateToolStripMenuItem.Text = "UID";
            this.uidUpdateToolStripMenuItem.Click += new System.EventHandler(this.uidUpdateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_9
            // 
            this.toolStripMenuItem_9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_9.Image")));
            this.toolStripMenuItem_9.Name = "toolStripMenuItem_9";
            this.toolStripMenuItem_9.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_9.Text = "Password";
            this.toolStripMenuItem_9.Click += new System.EventHandler(this.BCB71D80);
            // 
            // tokenToolStripMenuItem2
            // 
            this.tokenToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("tokenToolStripMenuItem2.Image")));
            this.tokenToolStripMenuItem2.Name = "tokenToolStripMenuItem2";
            this.tokenToolStripMenuItem2.Size = new System.Drawing.Size(179, 22);
            this.tokenToolStripMenuItem2.Text = "Token";
            this.tokenToolStripMenuItem2.Click += new System.EventHandler(this.BC1B5AAD);
            // 
            // C698B335
            // 
            this.C698B335.Image = ((System.Drawing.Image)(resources.GetObject("C698B335.Image")));
            this.C698B335.Name = "C698B335";
            this.C698B335.Size = new System.Drawing.Size(179, 22);
            this.C698B335.Text = "Cookie";
            this.C698B335.Click += new System.EventHandler(this.C698B335_Click);
            // 
            // toolStripMenuItem_12
            // 
            this.toolStripMenuItem_12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_12.Image")));
            this.toolStripMenuItem_12.Name = "toolStripMenuItem_12";
            this.toolStripMenuItem_12.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_12.Text = "Email|Pass Email";
            this.toolStripMenuItem_12.Click += new System.EventHandler(this.toolStripMenuItem_12_Click);
            // 
            // F4263206
            // 
            this.F4263206.Image = ((System.Drawing.Image)(resources.GetObject("F4263206.Image")));
            this.F4263206.Name = "F4263206";
            this.F4263206.Size = new System.Drawing.Size(179, 22);
            this.F4263206.Text = "Pass Mail";
            this.F4263206.Click += new System.EventHandler(this.EB2DE717);
            // 
            // toolStripMenuItem_26
            // 
            this.toolStripMenuItem_26.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_26.Image")));
            this.toolStripMenuItem_26.Name = "toolStripMenuItem_26";
            this.toolStripMenuItem_26.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_26.Text = "Email|Mailkp";
            this.toolStripMenuItem_26.Click += new System.EventHandler(this.toolStripMenuItem_26_Click);
            // 
            // BB8A908F
            // 
            this.BB8A908F.Image = ((System.Drawing.Image)(resources.GetObject("BB8A908F.Image")));
            this.BB8A908F.Name = "BB8A908F";
            this.BB8A908F.Size = new System.Drawing.Size(179, 22);
            this.BB8A908F.Text = "OAuth2";
            this.BB8A908F.Click += new System.EventHandler(this.BB8A908F_Click);
            // 
            // BC007112
            // 
            this.BC007112.Image = ((System.Drawing.Image)(resources.GetObject("BC007112.Image")));
            this.BC007112.Name = "BC007112";
            this.BC007112.Size = new System.Drawing.Size(179, 22);
            this.BC007112.Text = "Mã 2FA";
            this.BC007112.Click += new System.EventHandler(this.BC007112_Click);
            // 
            // C00BE82A
            // 
            this.C00BE82A.Image = ((System.Drawing.Image)(resources.GetObject("C00BE82A.Image")));
            this.C00BE82A.Name = "C00BE82A";
            this.C00BE82A.Size = new System.Drawing.Size(179, 22);
            this.C00BE82A.Text = "Useragent";
            this.C00BE82A.Click += new System.EventHandler(this.C00BE82A_Click);
            // 
            // DAB92DAC
            // 
            this.DAB92DAC.Image = ((System.Drawing.Image)(resources.GetObject("DAB92DAC.Image")));
            this.DAB92DAC.Name = "DAB92DAC";
            this.DAB92DAC.Size = new System.Drawing.Size(179, 22);
            this.DAB92DAC.Text = "Proxy";
            this.DAB92DAC.Click += new System.EventHandler(this.EFB628A8);
            // 
            // A8162791
            // 
            this.A8162791.Image = ((System.Drawing.Image)(resources.GetObject("A8162791.Image")));
            this.A8162791.Name = "A8162791";
            this.A8162791.Size = new System.Drawing.Size(179, 22);
            this.A8162791.Text = "Ghi chú";
            this.A8162791.Click += new System.EventHandler(this.CC09200B);
            // 
            // B6161039
            // 
            this.B6161039.Image = ((System.Drawing.Image)(resources.GetObject("B6161039.Image")));
            this.B6161039.Name = "B6161039";
            this.B6161039.Size = new System.Drawing.Size(179, 22);
            this.B6161039.Text = "Ngày sinh";
            this.B6161039.Click += new System.EventHandler(this.B6161039_Click);
            // 
            // toolStripMenuItem_29
            // 
            this.toolStripMenuItem_29.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_29.Image")));
            this.toolStripMenuItem_29.Name = "toolStripMenuItem_29";
            this.toolStripMenuItem_29.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_29.Text = "Mail khôi phục";
            this.toolStripMenuItem_29.Click += new System.EventHandler(this.BBB08939);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem12.Image")));
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem12.Text = "Pass mail khôi phục";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.F2B3D0B7);
            // 
            // phoneToolStripMenuItem
            // 
            this.phoneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("phoneToolStripMenuItem.Image")));
            this.phoneToolStripMenuItem.Name = "phoneToolStripMenuItem";
            this.phoneToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.phoneToolStripMenuItem.Text = "Phone";
            this.phoneToolStripMenuItem.Click += new System.EventHandler(this.C7BCAF9B);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem11.Image")));
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem11.Text = "Tình trạng";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // FA1B6D17
            // 
            this.FA1B6D17.Image = ((System.Drawing.Image)(resources.GetObject("FA1B6D17.Image")));
            this.FA1B6D17.Name = "FA1B6D17";
            this.FA1B6D17.Size = new System.Drawing.Size(179, 22);
            this.FA1B6D17.Text = "Fb Block";
            this.FA1B6D17.Click += new System.EventHandler(this.FA1B6D17_Click);
            // 
            // BE8BBBA0
            // 
            this.BE8BBBA0.Image = ((System.Drawing.Image)(resources.GetObject("BE8BBBA0.Image")));
            this.BE8BBBA0.Name = "BE8BBBA0";
            this.BE8BBBA0.Size = new System.Drawing.Size(200, 22);
            this.BE8BBBA0.Text = "Chuyển mục";
            this.BE8BBBA0.Click += new System.EventHandler(this.BE8BBBA0_Click);
            this.BE8BBBA0.MouseEnter += new System.EventHandler(this.BE8BBBA0_MouseEnter);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C2207E1A,
            this.toolStripMenuItem_37});
            this.databaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("databaseToolStripMenuItem.Image")));
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.databaseToolStripMenuItem.Text = "Database (ẩn)";
            // 
            // C2207E1A
            // 
            this.C2207E1A.Name = "C2207E1A";
            this.C2207E1A.Size = new System.Drawing.Size(229, 22);
            this.C2207E1A.Text = "Khôi phục mật khẩu trước đó";
            this.C2207E1A.Click += new System.EventHandler(this.F3B9E732);
            // 
            // toolStripMenuItem_37
            // 
            this.toolStripMenuItem_37.Name = "toolStripMenuItem_37";
            this.toolStripMenuItem_37.Size = new System.Drawing.Size(229, 22);
            this.toolStripMenuItem_37.Text = "Khôi phục email trước đó";
            this.toolStripMenuItem_37.Click += new System.EventHandler(this.toolStripMenuItem_37_Click);
            // 
            // C29582AA
            // 
            this.C29582AA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BA219202,
            this.AD93A60F,
            this.D804239D,
            this.E39B6092,
            this.toolStripMenuItem_39,
            this.checkNameVNToolStripMenuItem,
            this.toolStripMenuItem_16,
            this.toolStripMenuItem_24,
            this.toolStripMenuItem_23,
            this.checkCountryToolStripMenuItem,
            this.toolStripMenuItem9,
            this.toolStripMenuItem13,
            this.CF3F68BB,
            this.A211BD94,
            this.C2140F32,
            this.compareEmailToolStripMenuItem});
            this.C29582AA.Image = ((System.Drawing.Image)(resources.GetObject("C29582AA.Image")));
            this.C29582AA.Name = "C29582AA";
            this.C29582AA.Size = new System.Drawing.Size(200, 22);
            this.C29582AA.Text = "Chức năng";
            // 
            // BA219202
            // 
            this.BA219202.Image = ((System.Drawing.Image)(resources.GetObject("BA219202.Image")));
            this.BA219202.Name = "BA219202";
            this.BA219202.Size = new System.Drawing.Size(265, 22);
            this.BA219202.Text = "Lọc tài khoản theo Uid";
            this.BA219202.Click += new System.EventHandler(this.BA219202_Click);
            // 
            // AD93A60F
            // 
            this.AD93A60F.Image = ((System.Drawing.Image)(resources.GetObject("AD93A60F.Image")));
            this.AD93A60F.Name = "AD93A60F";
            this.AD93A60F.Size = new System.Drawing.Size(265, 22);
            this.AD93A60F.Text = "Lọc tài khoản trùng nhau";
            this.AD93A60F.Click += new System.EventHandler(this.AF8C5B2B);
            // 
            // D804239D
            // 
            this.D804239D.Image = ((System.Drawing.Image)(resources.GetObject("D804239D.Image")));
            this.D804239D.Name = "D804239D";
            this.D804239D.Size = new System.Drawing.Size(265, 22);
            this.D804239D.Text = "Xóa tài khoản trùng nhau";
            this.D804239D.Click += new System.EventHandler(this.D804239D_Click);
            // 
            // E39B6092
            // 
            this.E39B6092.Image = ((System.Drawing.Image)(resources.GetObject("E39B6092.Image")));
            this.E39B6092.Name = "E39B6092";
            this.E39B6092.Size = new System.Drawing.Size(265, 22);
            this.E39B6092.Text = "Tạo Shortcut Chrome";
            this.E39B6092.Click += new System.EventHandler(this.E39B6092_Click);
            // 
            // toolStripMenuItem_39
            // 
            this.toolStripMenuItem_39.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_39.Image")));
            this.toolStripMenuItem_39.Name = "toolStripMenuItem_39";
            this.toolStripMenuItem_39.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem_39.Text = "Gán kịch bản (ẩn)";
            this.toolStripMenuItem_39.Visible = false;
            this.toolStripMenuItem_39.Click += new System.EventHandler(this.D4B81685);
            // 
            // checkNameVNToolStripMenuItem
            // 
            this.checkNameVNToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkNameVNToolStripMenuItem.Image")));
            this.checkNameVNToolStripMenuItem.Name = "checkNameVNToolStripMenuItem";
            this.checkNameVNToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.checkNameVNToolStripMenuItem.Text = "Check name VN";
            this.checkNameVNToolStripMenuItem.Click += new System.EventHandler(this.checkNameVNToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_16
            // 
            this.toolStripMenuItem_16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_16.Image")));
            this.toolStripMenuItem_16.Name = "toolStripMenuItem_16";
            this.toolStripMenuItem_16.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem_16.Text = "Tải xuống avatar";
            this.toolStripMenuItem_16.Click += new System.EventHandler(this.toolStripMenuItem_16_Click);
            // 
            // toolStripMenuItem_24
            // 
            this.toolStripMenuItem_24.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_24.Image")));
            this.toolStripMenuItem_24.Name = "toolStripMenuItem_24";
            this.toolStripMenuItem_24.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem_24.Text = "Khôi phục mật khẩu";
            this.toolStripMenuItem_24.Click += new System.EventHandler(this.toolStripMenuItem_24_Click);
            // 
            // toolStripMenuItem_23
            // 
            this.toolStripMenuItem_23.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_23.Image")));
            this.toolStripMenuItem_23.Name = "toolStripMenuItem_23";
            this.toolStripMenuItem_23.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem_23.Text = "Mở form quản lý tin nhắn";
            this.toolStripMenuItem_23.Click += new System.EventHandler(this.toolStripMenuItem_23_Click);
            // 
            // checkCountryToolStripMenuItem
            // 
            this.checkCountryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkCountryToolStripMenuItem.Image")));
            this.checkCountryToolStripMenuItem.Name = "checkCountryToolStripMenuItem";
            this.checkCountryToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.checkCountryToolStripMenuItem.Text = "Check country từ location";
            this.checkCountryToolStripMenuItem.Click += new System.EventHandler(this.checkCountryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem9.Text = "Export data acc";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.B59FA6BF);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(265, 22);
            this.toolStripMenuItem13.Text = "Import data acc";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.B4BB860C);
            // 
            // CF3F68BB
            // 
            this.CF3F68BB.Image = ((System.Drawing.Image)(resources.GetObject("CF3F68BB.Image")));
            this.CF3F68BB.Name = "CF3F68BB";
            this.CF3F68BB.Size = new System.Drawing.Size(265, 22);
            this.CF3F68BB.Text = "Giải phóng dung lượng";
            this.CF3F68BB.Click += new System.EventHandler(this.FD11AF2E);
            // 
            // A211BD94
            // 
            this.A211BD94.Image = ((System.Drawing.Image)(resources.GetObject("A211BD94.Image")));
            this.A211BD94.Name = "A211BD94";
            this.A211BD94.Size = new System.Drawing.Size(265, 22);
            this.A211BD94.Text = "Giải phóng dung lượng + Shutdown";
            this.A211BD94.Click += new System.EventHandler(this.C71C3FA2);
            // 
            // C2140F32
            // 
            this.C2140F32.Image = ((System.Drawing.Image)(resources.GetObject("C2140F32.Image")));
            this.C2140F32.Name = "C2140F32";
            this.C2140F32.Size = new System.Drawing.Size(265, 22);
            this.C2140F32.Text = "Chức năng ẩn";
            this.C2140F32.Visible = false;
            // 
            // compareEmailToolStripMenuItem
            // 
            this.compareEmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("compareEmailToolStripMenuItem.Image")));
            this.compareEmailToolStripMenuItem.Name = "compareEmailToolStripMenuItem";
            this.compareEmailToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.compareEmailToolStripMenuItem.Text = "Compare Email";
            this.compareEmailToolStripMenuItem.Click += new System.EventHandler(this.E6A7F1A1);
            // 
            // hotmailToolStripMenuItem
            // 
            this.hotmailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B298AA35,
            this.toolStripMenuItem_27,
            this.toolStripMenuItem_28,
            this.B1809B27});
            this.hotmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hotmailToolStripMenuItem.Image")));
            this.hotmailToolStripMenuItem.Name = "hotmailToolStripMenuItem";
            this.hotmailToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.hotmailToolStripMenuItem.Text = "Hotmail";
            // 
            // B298AA35
            // 
            this.B298AA35.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.E88CFB1A,
            this.BEB1F03C});
            this.B298AA35.Name = "B298AA35";
            this.B298AA35.Size = new System.Drawing.Size(189, 22);
            this.B298AA35.Text = "Login hotmail";
            // 
            // E88CFB1A
            // 
            this.E88CFB1A.Name = "E88CFB1A";
            this.E88CFB1A.Size = new System.Drawing.Size(136, 22);
            this.E88CFB1A.Text = "Mở chrome";
            this.E88CFB1A.Click += new System.EventHandler(this.E88CFB1A_Click);
            // 
            // BEB1F03C
            // 
            this.BEB1F03C.Name = "BEB1F03C";
            this.BEB1F03C.Size = new System.Drawing.Size(136, 22);
            this.BEB1F03C.Text = "Chạy ẩn";
            this.BEB1F03C.Click += new System.EventHandler(this.BEB1F03C_Click);
            // 
            // toolStripMenuItem_27
            // 
            this.toolStripMenuItem_27.Name = "toolStripMenuItem_27";
            this.toolStripMenuItem_27.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_27.Text = "Đổi mật khẩu hotmail";
            this.toolStripMenuItem_27.Click += new System.EventHandler(this.C9BCABB0);
            // 
            // toolStripMenuItem_28
            // 
            this.toolStripMenuItem_28.Name = "toolStripMenuItem_28";
            this.toolStripMenuItem_28.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_28.Text = "Thêm mail khôi phục";
            this.toolStripMenuItem_28.Click += new System.EventHandler(this.FE01C117);
            // 
            // B1809B27
            // 
            this.B1809B27.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_45,
            this.CEB9A490});
            this.B1809B27.Name = "B1809B27";
            this.B1809B27.Size = new System.Drawing.Size(189, 22);
            this.B1809B27.Text = "Enable OAuth2";
            // 
            // toolStripMenuItem_45
            // 
            this.toolStripMenuItem_45.Name = "toolStripMenuItem_45";
            this.toolStripMenuItem_45.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_45.Text = "Mở chrome";
            this.toolStripMenuItem_45.Click += new System.EventHandler(this.toolStripMenuItem_45_Click);
            // 
            // CEB9A490
            // 
            this.CEB9A490.Name = "CEB9A490";
            this.CEB9A490.Size = new System.Drawing.Size(136, 22);
            this.CEB9A490.Text = "Chạy ẩn";
            this.CEB9A490.Click += new System.EventHandler(this.D58DA917);
            // 
            // B60BD1B5
            // 
            this.B60BD1B5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTokenEAAAAToolStripMenuItem,
            this.toolStripMenuItem_42,
            this.taoPageFollowToolStripMenuItem,
            this.toolStripMenuItem_40,
            this.E10CC3A7,
            this.BEA6D0A0,
            this.toolStripMenuItem3,
            this.BF3426B5});
            this.B60BD1B5.Image = ((System.Drawing.Image)(resources.GetObject("B60BD1B5.Image")));
            this.B60BD1B5.Name = "B60BD1B5";
            this.B60BD1B5.Size = new System.Drawing.Size(200, 22);
            this.B60BD1B5.Text = "Chức năng vip (ẩn)";
            // 
            // getTokenEAAAAToolStripMenuItem
            // 
            this.getTokenEAAAAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eAAAAToolStripMenuItem,
            this.eAAGToolStripMenuItem,
            this.eAABsToolStripMenuItem});
            this.getTokenEAAAAToolStripMenuItem.Name = "getTokenEAAAAToolStripMenuItem";
            this.getTokenEAAAAToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.getTokenEAAAAToolStripMenuItem.Text = "Get Token";
            this.getTokenEAAAAToolStripMenuItem.Click += new System.EventHandler(this.C59CD88B);
            // 
            // eAAAAToolStripMenuItem
            // 
            this.eAAAAToolStripMenuItem.Name = "eAAAAToolStripMenuItem";
            this.eAAAAToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.eAAAAToolStripMenuItem.Text = "EAAAA";
            this.eAAAAToolStripMenuItem.Click += new System.EventHandler(this.eAAAAToolStripMenuItem_Click);
            // 
            // eAAGToolStripMenuItem
            // 
            this.eAAGToolStripMenuItem.Name = "eAAGToolStripMenuItem";
            this.eAAGToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.eAAGToolStripMenuItem.Text = "EAAG";
            this.eAAGToolStripMenuItem.Click += new System.EventHandler(this.eAAGToolStripMenuItem_Click);
            // 
            // eAABsToolStripMenuItem
            // 
            this.eAABsToolStripMenuItem.Name = "eAABsToolStripMenuItem";
            this.eAABsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.eAABsToolStripMenuItem.Text = "EAABs";
            this.eAABsToolStripMenuItem.Click += new System.EventHandler(this.eAABsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_42
            // 
            this.toolStripMenuItem_42.Name = "toolStripMenuItem_42";
            this.toolStripMenuItem_42.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem_42.Text = "Bật 2FA";
            this.toolStripMenuItem_42.Click += new System.EventHandler(this.toolStripMenuItem_42_Click);
            // 
            // taoPageFollowToolStripMenuItem
            // 
            this.taoPageFollowToolStripMenuItem.Name = "taoPageFollowToolStripMenuItem";
            this.taoPageFollowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.taoPageFollowToolStripMenuItem.Text = "Tạo Page,  Follow";
            this.taoPageFollowToolStripMenuItem.Click += new System.EventHandler(this.taoPageFollowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_40
            // 
            this.toolStripMenuItem_40.Name = "toolStripMenuItem_40";
            this.toolStripMenuItem_40.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem_40.Text = "Tải ảnh từ nhóm fb";
            this.toolStripMenuItem_40.Click += new System.EventHandler(this.EBA87C91);
            // 
            // E10CC3A7
            // 
            this.E10CC3A7.Name = "E10CC3A7";
            this.E10CC3A7.Size = new System.Drawing.Size(176, 22);
            this.E10CC3A7.Text = "Get Page Profile";
            this.E10CC3A7.Click += new System.EventHandler(this.E10CC3A7_Click);
            // 
            // BEA6D0A0
            // 
            this.BEA6D0A0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.A48E28A7,
            this.A5BBFD2A});
            this.BEA6D0A0.Name = "BEA6D0A0";
            this.BEA6D0A0.Size = new System.Drawing.Size(176, 22);
            this.BEA6D0A0.Text = "Copy data acc";
            this.BEA6D0A0.Click += new System.EventHandler(this.E3BC0805);
            // 
            // A48E28A7
            // 
            this.A48E28A7.Name = "A48E28A7";
            this.A48E28A7.Size = new System.Drawing.Size(106, 22);
            this.A48E28A7.Text = "Sqlite";
            this.A48E28A7.Click += new System.EventHandler(this.A48E28A7_Click);
            // 
            // A5BBFD2A
            // 
            this.A5BBFD2A.Name = "A5BBFD2A";
            this.A5BBFD2A.Size = new System.Drawing.Size(106, 22);
            this.A5BBFD2A.Text = "Mysql";
            this.A5BBFD2A.Click += new System.EventHandler(this.A5BBFD2A_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Paste data acc";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuItem5.Text = "Sqlite";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuItem4.Text = "Mysql";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ED95BDA3);
            // 
            // BF3426B5
            // 
            this.BF3426B5.Name = "BF3426B5";
            this.BF3426B5.Size = new System.Drawing.Size(176, 22);
            this.BF3426B5.Text = "Kích hoạt Page vhh";
            this.BF3426B5.Click += new System.EventHandler(this.BF3426B5_Click);
            // 
            // A10EFE26
            // 
            this.A10EFE26.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkProfileToolStripMenuItem,
            this.toolStripMenuItem_13,
            this.CA31F826,
            this.FA11F02A,
            this.FFA8771A});
            this.A10EFE26.Image = ((System.Drawing.Image)(resources.GetObject("A10EFE26.Image")));
            this.A10EFE26.Name = "A10EFE26";
            this.A10EFE26.Size = new System.Drawing.Size(200, 22);
            this.A10EFE26.Text = "Profile";
            // 
            // checkProfileToolStripMenuItem
            // 
            this.checkProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkProfileToolStripMenuItem.Image")));
            this.checkProfileToolStripMenuItem.Name = "checkProfileToolStripMenuItem";
            this.checkProfileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.checkProfileToolStripMenuItem.Text = "Check profile";
            this.checkProfileToolStripMenuItem.Click += new System.EventHandler(this.checkProfileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_13
            // 
            this.toolStripMenuItem_13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_13.Image")));
            this.toolStripMenuItem_13.Name = "toolStripMenuItem_13";
            this.toolStripMenuItem_13.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItem_13.Text = "Xóa profile";
            this.toolStripMenuItem_13.Click += new System.EventHandler(this.toolStripMenuItem_13_Click);
            // 
            // CA31F826
            // 
            this.CA31F826.Image = ((System.Drawing.Image)(resources.GetObject("CA31F826.Image")));
            this.CA31F826.Name = "CA31F826";
            this.CA31F826.Size = new System.Drawing.Size(167, 22);
            this.CA31F826.Text = "Dọn dẹp profile";
            this.CA31F826.Click += new System.EventHandler(this.CA31F826_Click);
            // 
            // FA11F02A
            // 
            this.FA11F02A.Image = ((System.Drawing.Image)(resources.GetObject("FA11F02A.Image")));
            this.FA11F02A.Name = "FA11F02A";
            this.FA11F02A.Size = new System.Drawing.Size(167, 22);
            this.FA11F02A.Text = "Xóa Cache Profile";
            this.FA11F02A.Click += new System.EventHandler(this.AEB68C15);
            // 
            // FFA8771A
            // 
            this.FFA8771A.Image = ((System.Drawing.Image)(resources.GetObject("FFA8771A.Image")));
            this.FFA8771A.Name = "FFA8771A";
            this.FFA8771A.Size = new System.Drawing.Size(167, 22);
            this.FFA8771A.Text = "Copy Profile";
            this.FFA8771A.Click += new System.EventHandler(this.C0A7291D);
            // 
            // dataBackupGroupToolStripMenuItem
            // 
            this.dataBackupGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupGroupToolStripMenuItem,
            this.checkFileBackupGroupToolStripMenuItem,
            this.B2A40FA8,
            this.toolStripMenuItem_41});
            this.dataBackupGroupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataBackupGroupToolStripMenuItem.Image")));
            this.dataBackupGroupToolStripMenuItem.Name = "dataBackupGroupToolStripMenuItem";
            this.dataBackupGroupToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.dataBackupGroupToolStripMenuItem.Text = "Data Backup Group (ẩn)";
            // 
            // backupGroupToolStripMenuItem
            // 
            this.backupGroupToolStripMenuItem.Name = "backupGroupToolStripMenuItem";
            this.backupGroupToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.backupGroupToolStripMenuItem.Text = "Backup group";
            this.backupGroupToolStripMenuItem.Click += new System.EventHandler(this.backupGroupToolStripMenuItem_Click);
            // 
            // checkFileBackupGroupToolStripMenuItem
            // 
            this.checkFileBackupGroupToolStripMenuItem.Name = "checkFileBackupGroupToolStripMenuItem";
            this.checkFileBackupGroupToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.checkFileBackupGroupToolStripMenuItem.Text = "Check data group";
            this.checkFileBackupGroupToolStripMenuItem.Click += new System.EventHandler(this.E4384FB7);
            // 
            // B2A40FA8
            // 
            this.B2A40FA8.Name = "B2A40FA8";
            this.B2A40FA8.Size = new System.Drawing.Size(168, 22);
            this.B2A40FA8.Text = "Xóa data group";
            this.B2A40FA8.Click += new System.EventHandler(this.AA3D8FB3);
            // 
            // toolStripMenuItem_41
            // 
            this.toolStripMenuItem_41.Name = "toolStripMenuItem_41";
            this.toolStripMenuItem_41.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem_41.Text = "Mở form quản lý";
            this.toolStripMenuItem_41.Click += new System.EventHandler(this.toolStripMenuItem_41_Click);
            // 
            // giaiCheckpointToolStripMenuItem
            // 
            this.giaiCheckpointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_25,
            this.toolStripMenuItem_38});
            this.giaiCheckpointToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("giaiCheckpointToolStripMenuItem.Image")));
            this.giaiCheckpointToolStripMenuItem.Name = "giaiCheckpointToolStripMenuItem";
            this.giaiCheckpointToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.giaiCheckpointToolStripMenuItem.Text = "Checkpoint";
            // 
            // toolStripMenuItem_25
            // 
            this.toolStripMenuItem_25.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C4A6CD3E,
            this.toolStripMenuItem18});
            this.toolStripMenuItem_25.Name = "toolStripMenuItem_25";
            this.toolStripMenuItem_25.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem_25.Text = "282";
            // 
            // C4A6CD3E
            // 
            this.C4A6CD3E.Name = "C4A6CD3E";
            this.C4A6CD3E.Size = new System.Drawing.Size(209, 22);
            this.C4A6CD3E.Text = "Mở chrome để lấy cookie";
            this.C4A6CD3E.Click += new System.EventHandler(this.C4A6CD3E_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem18.Text = "Dùng cookie lưu trên tool";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.A2353835);
            // 
            // toolStripMenuItem_38
            // 
            this.toolStripMenuItem_38.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_44,
            this.toolStripMenuItem_43});
            this.toolStripMenuItem_38.Name = "toolStripMenuItem_38";
            this.toolStripMenuItem_38.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem_38.Text = "956";
            // 
            // toolStripMenuItem_44
            // 
            this.toolStripMenuItem_44.Name = "toolStripMenuItem_44";
            this.toolStripMenuItem_44.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem_44.Text = "Mở chrome để lấy cookie";
            this.toolStripMenuItem_44.Click += new System.EventHandler(this.FE90AC2B);
            // 
            // toolStripMenuItem_43
            // 
            this.toolStripMenuItem_43.Name = "toolStripMenuItem_43";
            this.toolStripMenuItem_43.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem_43.Text = "Dùng cookie lưu trên tool";
            this.toolStripMenuItem_43.Click += new System.EventHandler(this.toolStripMenuItem_43_Click);
            // 
            // toolStripMenuItem_7
            // 
            this.toolStripMenuItem_7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_7.Image")));
            this.toolStripMenuItem_7.Name = "toolStripMenuItem_7";
            this.toolStripMenuItem_7.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_7.Text = "Tải lại";
            this.toolStripMenuItem_7.Click += new System.EventHandler(this.toolStripMenuItem_7_Click);
            // 
            // toolStripMenuItem_46
            // 
            this.toolStripMenuItem_46.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_46.Image")));
            this.toolStripMenuItem_46.Name = "toolStripMenuItem_46";
            this.toolStripMenuItem_46.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_46.Text = "Lên lịch tương tác";
            this.toolStripMenuItem_46.Visible = false;
            this.toolStripMenuItem_46.Click += new System.EventHandler(this.toolStripMenuItem_46_Click);
            // 
            // E3AACC35
            // 
            this.E3AACC35.Name = "E3AACC35";
            this.E3AACC35.Size = new System.Drawing.Size(253, 22);
            this.E3AACC35.Text = "Get Token EAAAAU";
            this.E3AACC35.Click += new System.EventHandler(this.E3AACC35_Click);
            // 
            // getTokenEAAAAUBToolStripMenuItem
            // 
            this.getTokenEAAAAUBToolStripMenuItem.Name = "getTokenEAAAAUBToolStripMenuItem";
            this.getTokenEAAAAUBToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.getTokenEAAAAUBToolStripMenuItem.Text = "Get Token EAAAAU + Bật 2FA";
            this.getTokenEAAAAUBToolStripMenuItem.Click += new System.EventHandler(this.getTokenEAAAAUBToolStripMenuItem_Click);
            // 
            // EA382128
            // 
            this.EA382128.Fixed = true;
            this.EA382128.Horizontal = true;
            this.EA382128.TargetControl = this.FBA31BBA;
            this.EA382128.Vertical = true;
            // 
            // FBA31BBA
            // 
            this.FBA31BBA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FBA31BBA.BackColor = System.Drawing.Color.White;
            this.FBA31BBA.Controls.Add(this.picLanguage);
            this.FBA31BBA.Controls.Add(this.pictureBox1);
            this.FBA31BBA.Controls.Add(this.E836E3B2);
            this.FBA31BBA.Controls.Add(this.btnMaximize);
            this.FBA31BBA.Controls.Add(this.ADA8C634);
            this.FBA31BBA.Controls.Add(this.B526D03A);
            this.FBA31BBA.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FBA31BBA.Location = new System.Drawing.Point(0, 4);
            this.FBA31BBA.Name = "FBA31BBA";
            this.FBA31BBA.Size = new System.Drawing.Size(1221, 29);
            this.FBA31BBA.TabIndex = 0;
            this.FBA31BBA.DoubleClick += new System.EventHandler(this.FBA31BBA_DoubleClick);
            // 
            // picLanguage
            // 
            this.picLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLanguage.Image = ((System.Drawing.Image)(resources.GetObject("picLanguage.Image")));
            this.picLanguage.Location = new System.Drawing.Point(1095, 2);
            this.picLanguage.Name = "picLanguage";
            this.picLanguage.Size = new System.Drawing.Size(25, 25);
            this.picLanguage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLanguage.TabIndex = 13;
            this.picLanguage.TabStop = false;
            this.picLanguage.Click += new System.EventHandler(this.picLanguage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.C60DAB0C);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.F62D3B92);
            // 
            // E836E3B2
            // 
            this.E836E3B2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.E836E3B2.Dock = System.Windows.Forms.DockStyle.Right;
            this.E836E3B2.FlatAppearance.BorderSize = 0;
            this.E836E3B2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.E836E3B2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E836E3B2.ForeColor = System.Drawing.Color.White;
            this.E836E3B2.Image = ((System.Drawing.Image)(resources.GetObject("E836E3B2.Image")));
            this.E836E3B2.Location = new System.Drawing.Point(1125, 0);
            this.E836E3B2.Name = "E836E3B2";
            this.E836E3B2.Size = new System.Drawing.Size(32, 29);
            this.E836E3B2.TabIndex = 0;
            this.E836E3B2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.E836E3B2.UseVisualStyleBackColor = true;
            this.E836E3B2.Click += new System.EventHandler(this.E836E3B2_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(1157, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(32, 29);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // ADA8C634
            // 
            this.ADA8C634.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADA8C634.Dock = System.Windows.Forms.DockStyle.Right;
            this.ADA8C634.FlatAppearance.BorderSize = 0;
            this.ADA8C634.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ADA8C634.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADA8C634.ForeColor = System.Drawing.Color.White;
            this.ADA8C634.Image = ((System.Drawing.Image)(resources.GetObject("ADA8C634.Image")));
            this.ADA8C634.Location = new System.Drawing.Point(1189, 0);
            this.ADA8C634.Name = "ADA8C634";
            this.ADA8C634.Size = new System.Drawing.Size(32, 29);
            this.ADA8C634.TabIndex = 2;
            this.ADA8C634.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ADA8C634.UseVisualStyleBackColor = true;
            this.ADA8C634.Click += new System.EventHandler(this.ADA8C634_Click);
            // 
            // B526D03A
            // 
            this.B526D03A.AutoSize = true;
            this.B526D03A.BackColor = System.Drawing.Color.Transparent;
            this.B526D03A.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.B526D03A.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B526D03A.ForeColor = System.Drawing.Color.Black;
            this.B526D03A.Location = new System.Drawing.Point(43, 6);
            this.B526D03A.Name = "B526D03A";
            this.B526D03A.Size = new System.Drawing.Size(607, 16);
            this.B526D03A.TabIndex = 3;
            this.B526D03A.Text = "LushCare - Phần Mềm Quản Lý Và Chăm Sóc Tài Khoản Facebook";
            this.B526D03A.DoubleClick += new System.EventHandler(this.B526D03A_DoubleClick);
            // 
            // D39C9728
            // 
            this.D39C9728.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.D39C9728.AutoSize = false;
            this.D39C9728.Dock = System.Windows.Forms.DockStyle.None;
            this.D39C9728.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D39C9728.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C72EAE3C,
            this.toolStripMenuItem_0,
            this.toolStripMenuItem_15,
            this.toolStripMenuItem_17,
            this.toolStripMenuItem_18,
            this.toolStripMenuItem_22});
            this.D39C9728.Location = new System.Drawing.Point(1, 37);
            this.D39C9728.Name = "D39C9728";
            this.D39C9728.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.D39C9728.Size = new System.Drawing.Size(1221, 25);
            this.D39C9728.Stretch = false;
            this.D39C9728.TabIndex = 1;
            this.D39C9728.Text = "menuStrip1";
            // 
            // C72EAE3C
            // 
            this.C72EAE3C.Image = ((System.Drawing.Image)(resources.GetObject("C72EAE3C.Image")));
            this.C72EAE3C.Name = "C72EAE3C";
            this.C72EAE3C.Size = new System.Drawing.Size(123, 21);
            this.C72EAE3C.Text = "Cấu hình chung";
            this.C72EAE3C.Click += new System.EventHandler(this.C72EAE3C_Click);
            // 
            // toolStripMenuItem_0
            // 
            this.toolStripMenuItem_0.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_0.Image")));
            this.toolStripMenuItem_0.Name = "toolStripMenuItem_0";
            this.toolStripMenuItem_0.Size = new System.Drawing.Size(143, 21);
            this.toolStripMenuItem_0.Text = "Cấu hình tương tác";
            this.toolStripMenuItem_0.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripMenuItem_0.Click += new System.EventHandler(this.E6058690);
            // 
            // toolStripMenuItem_15
            // 
            this.toolStripMenuItem_15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_15.Image")));
            this.toolStripMenuItem_15.Name = "toolStripMenuItem_15";
            this.toolStripMenuItem_15.Size = new System.Drawing.Size(131, 21);
            this.toolStripMenuItem_15.Text = "Cấu hình hiển thị";
            this.toolStripMenuItem_15.Click += new System.EventHandler(this.toolStripMenuItem_15_Click);
            // 
            // toolStripMenuItem_17
            // 
            this.toolStripMenuItem_17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_17.Image")));
            this.toolStripMenuItem_17.Name = "toolStripMenuItem_17";
            this.toolStripMenuItem_17.Size = new System.Drawing.Size(133, 21);
            this.toolStripMenuItem_17.Text = "Tài khoản đã xóa";
            this.toolStripMenuItem_17.Click += new System.EventHandler(this.ED2D348F);
            // 
            // toolStripMenuItem_18
            // 
            this.toolStripMenuItem_18.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findIdFacebookToolStripMenuItem,
            this.checkLiveUidToolStripMenuItem,
            this.F08308B5,
            this.EF359EB3,
            this.A681EC38,
            this.D090E02D,
            this.A70D7D81,
            this.toolStripMenuItem14,
            this.testSpinTextToolStripMenuItem,
            this.E51F2F23,
            this.A637DF36});
            this.toolStripMenuItem_18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_18.Image")));
            this.toolStripMenuItem_18.Name = "toolStripMenuItem_18";
            this.toolStripMenuItem_18.Size = new System.Drawing.Size(80, 21);
            this.toolStripMenuItem_18.Text = "Tiện ích";
            // 
            // findIdFacebookToolStripMenuItem
            // 
            this.findIdFacebookToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("findIdFacebookToolStripMenuItem.Image")));
            this.findIdFacebookToolStripMenuItem.Name = "findIdFacebookToolStripMenuItem";
            this.findIdFacebookToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.findIdFacebookToolStripMenuItem.Text = "Find Id Facebook";
            this.findIdFacebookToolStripMenuItem.Click += new System.EventHandler(this.findIdFacebookToolStripMenuItem_Click);
            // 
            // checkLiveUidToolStripMenuItem
            // 
            this.checkLiveUidToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkLiveUidToolStripMenuItem.Image")));
            this.checkLiveUidToolStripMenuItem.Name = "checkLiveUidToolStripMenuItem";
            this.checkLiveUidToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.checkLiveUidToolStripMenuItem.Text = "Check Live Uid";
            this.checkLiveUidToolStripMenuItem.Click += new System.EventHandler(this.FDB0FFB9);
            // 
            // F08308B5
            // 
            this.F08308B5.Image = ((System.Drawing.Image)(resources.GetObject("F08308B5.Image")));
            this.F08308B5.Name = "F08308B5";
            this.F08308B5.Size = new System.Drawing.Size(240, 22);
            this.F08308B5.Text = "Check Proxy";
            this.F08308B5.Click += new System.EventHandler(this.D81A0C99);
            // 
            // EF359EB3
            // 
            this.EF359EB3.Image = ((System.Drawing.Image)(resources.GetObject("EF359EB3.Image")));
            this.EF359EB3.Name = "EF359EB3";
            this.EF359EB3.Size = new System.Drawing.Size(240, 22);
            this.EF359EB3.Text = "Check Connect hotmail";
            this.EF359EB3.Click += new System.EventHandler(this.EF359EB3_Click);
            // 
            // A681EC38
            // 
            this.A681EC38.Image = ((System.Drawing.Image)(resources.GetObject("A681EC38.Image")));
            this.A681EC38.Name = "A681EC38";
            this.A681EC38.Size = new System.Drawing.Size(240, 22);
            this.A681EC38.Text = "Lọc trùng dữ liệu";
            this.A681EC38.Click += new System.EventHandler(this.CB9C6A2E);
            // 
            // D090E02D
            // 
            this.D090E02D.Image = ((System.Drawing.Image)(resources.GetObject("D090E02D.Image")));
            this.D090E02D.Name = "D090E02D";
            this.D090E02D.Size = new System.Drawing.Size(240, 22);
            this.D090E02D.Text = "Xử lý chuỗi cơ bản";
            this.D090E02D.Click += new System.EventHandler(this.D090E02D_Click);
            // 
            // A70D7D81
            // 
            this.A70D7D81.Image = ((System.Drawing.Image)(resources.GetObject("A70D7D81.Image")));
            this.A70D7D81.Name = "A70D7D81";
            this.A70D7D81.Size = new System.Drawing.Size(240, 22);
            this.A70D7D81.Text = "Check status Xproxy/ProxyV6";
            this.A70D7D81.Click += new System.EventHandler(this.A70D7D81_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(240, 22);
            this.toolStripMenuItem14.Text = "Hotmail";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.A1AEFE2E);
            // 
            // testSpinTextToolStripMenuItem
            // 
            this.testSpinTextToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testSpinTextToolStripMenuItem.Image")));
            this.testSpinTextToolStripMenuItem.Name = "testSpinTextToolStripMenuItem";
            this.testSpinTextToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.testSpinTextToolStripMenuItem.Text = "Test Spin Content";
            this.testSpinTextToolStripMenuItem.Click += new System.EventHandler(this.testSpinTextToolStripMenuItem_Click);
            // 
            // E51F2F23
            // 
            this.E51F2F23.Image = ((System.Drawing.Image)(resources.GetObject("E51F2F23.Image")));
            this.E51F2F23.Name = "E51F2F23";
            this.E51F2F23.Size = new System.Drawing.Size(240, 22);
            this.E51F2F23.Text = "Hướng dẫn random icon";
            this.E51F2F23.Click += new System.EventHandler(this.EEA12224);
            // 
            // A637DF36
            // 
            this.A637DF36.Image = ((System.Drawing.Image)(resources.GetObject("A637DF36.Image")));
            this.A637DF36.Name = "A637DF36";
            this.A637DF36.Size = new System.Drawing.Size(240, 22);
            this.A637DF36.Text = "Prompt AI";
            this.A637DF36.Click += new System.EventHandler(this.A637DF36_Click);
            // 
            // toolStripMenuItem_22
            // 
            this.toolStripMenuItem_22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_22.Image")));
            this.toolStripMenuItem_22.Name = "toolStripMenuItem_22";
            this.toolStripMenuItem_22.Size = new System.Drawing.Size(76, 21);
            this.toolStripMenuItem_22.Text = "Liên hệ";
            this.toolStripMenuItem_22.Click += new System.EventHandler(this.BFA85F92);
            // 
            // bunifuDragControl_0
            // 
            this.bunifuDragControl_0.Fixed = true;
            this.bunifuDragControl_0.Horizontal = true;
            this.bunifuDragControl_0.TargetControl = this.B526D03A;
            this.bunifuDragControl_0.Vertical = true;
            // 
            // btnInteract
            // 
            this.btnInteract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInteract.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnInteract.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnInteract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInteract.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInteract.Image = ((System.Drawing.Image)(resources.GetObject("btnInteract.Image")));
            this.btnInteract.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInteract.Location = new System.Drawing.Point(8, 71);
            this.btnInteract.Name = "btnInteract";
            this.btnInteract.Size = new System.Drawing.Size(133, 31);
            this.btnInteract.TabIndex = 2;
            this.btnInteract.Text = "Chạy Tương Tác";
            this.btnInteract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInteract.UseVisualStyleBackColor = false;
            this.btnInteract.Click += new System.EventHandler(this.C889E701);
            // 
            // AddFileAccount
            // 
            this.AddFileAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddFileAccount.BackgroundImage")));
            this.AddFileAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddFileAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddFileAccount.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddFileAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFileAccount.Location = new System.Drawing.Point(395, 2);
            this.AddFileAccount.Name = "AddFileAccount";
            this.AddFileAccount.Size = new System.Drawing.Size(25, 25);
            this.AddFileAccount.TabIndex = 4;
            this.AddFileAccount.Click += new System.EventHandler(this.AddFileAccount_Click);
            // 
            // D1117A83
            // 
            this.D1117A83.BackColor = System.Drawing.Color.White;
            this.D1117A83.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D1117A83.BackgroundImage")));
            this.D1117A83.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.D1117A83.Cursor = System.Windows.Forms.Cursors.Hand;
            this.D1117A83.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.D1117A83.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.D1117A83.Location = new System.Drawing.Point(457, 2);
            this.D1117A83.Name = "D1117A83";
            this.D1117A83.Size = new System.Drawing.Size(25, 25);
            this.D1117A83.TabIndex = 5;
            this.D1117A83.UseVisualStyleBackColor = false;
            this.D1117A83.Click += new System.EventHandler(this.DF154C84);
            // 
            // btnEditFile
            // 
            this.btnEditFile.BackColor = System.Drawing.Color.White;
            this.btnEditFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditFile.BackgroundImage")));
            this.btnEditFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditFile.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditFile.Location = new System.Drawing.Point(426, 2);
            this.btnEditFile.Name = "btnEditFile";
            this.btnEditFile.Size = new System.Drawing.Size(25, 25);
            this.btnEditFile.TabIndex = 5;
            this.btnEditFile.UseVisualStyleBackColor = false;
            this.btnEditFile.Click += new System.EventHandler(this.btnEditFile_Click);
            // 
            // btnLoadAcc
            // 
            this.btnLoadAcc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadAcc.BackgroundImage")));
            this.btnLoadAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadAcc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLoadAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAcc.Location = new System.Drawing.Point(489, 2);
            this.btnLoadAcc.Name = "btnLoadAcc";
            this.btnLoadAcc.Size = new System.Drawing.Size(25, 25);
            this.btnLoadAcc.TabIndex = 6;
            this.btnLoadAcc.Click += new System.EventHandler(this.E48D7F88);
            // 
            // plTrangThai
            // 
            this.plTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plTrangThai.BackColor = System.Drawing.Color.Gainsboro;
            this.plTrangThai.Controls.Add(this.lblTrangThai);
            this.plTrangThai.Location = new System.Drawing.Point(848, 36);
            this.plTrangThai.Name = "plTrangThai";
            this.plTrangThai.Size = new System.Drawing.Size(373, 26);
            this.plTrangThai.TabIndex = 10;
            this.plTrangThai.Visible = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(373, 26);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // F7121228
            // 
            this.F7121228.AccessibleName = "New item selection";
            this.F7121228.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.F7121228.AutoSize = false;
            this.F7121228.BackColor = System.Drawing.SystemColors.Control;
            this.F7121228.Dock = System.Windows.Forms.DockStyle.None;
            this.F7121228.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.F7121228.Location = new System.Drawing.Point(0, 0);
            this.F7121228.Name = "F7121228";
            this.F7121228.Size = new System.Drawing.Size(1222, 22);
            this.F7121228.SizingGrip = false;
            this.F7121228.TabIndex = 9;
            // 
            // A3864980
            // 
            this.A3864980.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3864980.Name = "A3864980";
            this.A3864980.Size = new System.Drawing.Size(78, 17);
            this.A3864980.Text = "Trạng thái:";
            // 
            // C3919999
            // 
            this.C3919999.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C3919999.ForeColor = System.Drawing.Color.Green;
            this.C3919999.Name = "C3919999";
            this.C3919999.Size = new System.Drawing.Size(97, 17);
            this.C3919999.Text = "Đang kiểm tra...";
            // 
            // B9BED82A
            // 
            this.B9BED82A.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B9BED82A.Name = "B9BED82A";
            this.B9BED82A.Size = new System.Drawing.Size(81, 17);
            this.B9BED82A.Text = "Mã thiết bị:";
            // 
            // lblKey
            // 
            this.lblKey.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.ForeColor = System.Drawing.Color.Teal;
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(49, 17);
            this.lblKey.Text = "******";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel8.Text = "User:";
            // 
            // A5376CB6
            // 
            this.A5376CB6.Name = "A5376CB6";
            this.A5376CB6.Size = new System.Drawing.Size(0, 17);
            // 
            // CC9D630E
            // 
            this.CC9D630E.Name = "CC9D630E";
            this.CC9D630E.Size = new System.Drawing.Size(55, 17);
            this.CC9D630E.Text = "******";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel9.IsLink = true;
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel9.Text = "Đăng xuất";
            this.toolStripStatusLabel9.Click += new System.EventHandler(this.A4A0C627);
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel10.Text = "Ngày hết hạn:";
            // 
            // lblDateExpried
            // 
            this.lblDateExpried.Name = "lblDateExpried";
            this.lblDateExpried.Size = new System.Drawing.Size(73, 17);
            this.lblDateExpried.Text = "20/10/2020";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel4.Text = "Bôi đen:";
            // 
            // lblCountHighline
            // 
            this.lblCountHighline.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountHighline.ForeColor = System.Drawing.Color.Blue;
            this.lblCountHighline.Name = "lblCountHighline";
            this.lblCountHighline.Size = new System.Drawing.Size(15, 17);
            this.lblCountHighline.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel5.Text = "Đã chọn:";
            // 
            // lblCountSelect
            // 
            this.lblCountSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCountSelect.Name = "lblCountSelect";
            this.lblCountSelect.Size = new System.Drawing.Size(15, 17);
            this.lblCountSelect.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel7.Text = "Tất cả:";
            // 
            // lblCountTotal
            // 
            this.lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblCountTotal.Name = "lblCountTotal";
            this.lblCountTotal.Size = new System.Drawing.Size(15, 17);
            this.lblCountTotal.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel6.Text = "Chrome:";
            // 
            // D81D001E
            // 
            this.D81D001E.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D81D001E.ForeColor = System.Drawing.Color.DarkGreen;
            this.D81D001E.Name = "D81D001E";
            this.D81D001E.Size = new System.Drawing.Size(15, 17);
            this.D81D001E.Text = "0";
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.metroButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.metroButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroButton1.Location = new System.Drawing.Point(1082, 71);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(130, 31);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.Text = "Close Chromedriver";
            this.metroButton1.Click += new System.EventHandler(this.B0902D2C);
            // 
            // DC993629
            // 
            this.DC993629.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DC993629.Controls.Add(this.BtnSearch);
            this.DC993629.Controls.Add(this.cbbSearch);
            this.DC993629.Controls.Add(this.txbSearch);
            this.DC993629.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DC993629.Location = new System.Drawing.Point(147, 71);
            this.DC993629.Name = "DC993629";
            this.DC993629.Size = new System.Drawing.Size(269, 31);
            this.DC993629.TabIndex = 10;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSearch.BackgroundImage")));
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Location = new System.Drawing.Point(240, 3);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(24, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cbbSearch
            // 
            this.cbbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearch.DropDownWidth = 100;
            this.cbbSearch.FormattingEnabled = true;
            this.cbbSearch.Location = new System.Drawing.Point(3, 3);
            this.cbbSearch.Name = "cbbSearch";
            this.cbbSearch.Size = new System.Drawing.Size(86, 24);
            this.cbbSearch.TabIndex = 0;
            // 
            // txbSearch
            // 
            this.txbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearch.BorderColor = System.Drawing.Color.SeaGreen;
            this.txbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbSearch.Location = new System.Drawing.Point(95, 3);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(139, 23);
            this.txbSearch.TabIndex = 1;
            this.txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.E49BDB23);
            // 
            // plQuanLyThuMuc
            // 
            this.plQuanLyThuMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plQuanLyThuMuc.Controls.Add(this.FE921A1C);
            this.plQuanLyThuMuc.Controls.Add(this.btnLoadAcc);
            this.plQuanLyThuMuc.Controls.Add(this.label1);
            this.plQuanLyThuMuc.Controls.Add(this.btnEditFile);
            this.plQuanLyThuMuc.Controls.Add(this.CA9D953A);
            this.plQuanLyThuMuc.Controls.Add(this.D1117A83);
            this.plQuanLyThuMuc.Controls.Add(this.label2);
            this.plQuanLyThuMuc.Controls.Add(this.AddFileAccount);
            this.plQuanLyThuMuc.Controls.Add(this.D38F4B00);
            this.plQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plQuanLyThuMuc.Location = new System.Drawing.Point(422, 71);
            this.plQuanLyThuMuc.Name = "plQuanLyThuMuc";
            this.plQuanLyThuMuc.Size = new System.Drawing.Size(654, 31);
            this.plQuanLyThuMuc.TabIndex = 10;
            // 
            // FE921A1C
            // 
            this.FE921A1C.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FE921A1C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FE921A1C.DropDownWidth = 300;
            this.FE921A1C.FormattingEnabled = true;
            this.FE921A1C.ItemHeight = 16;
            this.FE921A1C.Items.AddRange(new object[] {
            "[Tất cả tình trạng]"});
            this.FE921A1C.Location = new System.Drawing.Point(268, 3);
            this.FE921A1C.Name = "FE921A1C";
            this.FE921A1C.Size = new System.Drawing.Size(121, 24);
            this.FE921A1C.TabIndex = 3;
            this.FE921A1C.SelectedIndexChanged += new System.EventHandler(this.A134ED34);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thư mục:";
            // 
            // CA9D953A
            // 
            this.CA9D953A.BackColor = System.Drawing.Color.White;
            this.CA9D953A.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CA9D953A.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CA9D953A.Image = ((System.Drawing.Image)(resources.GetObject("CA9D953A.Image")));
            this.CA9D953A.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CA9D953A.Location = new System.Drawing.Point(521, 1);
            this.CA9D953A.Name = "CA9D953A";
            this.CA9D953A.Size = new System.Drawing.Size(130, 27);
            this.CA9D953A.TabIndex = 7;
            this.CA9D953A.Text = "Nhập tài khoản";
            this.CA9D953A.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CA9D953A.UseVisualStyleBackColor = true;
            this.CA9D953A.Click += new System.EventHandler(this.EE3FA802);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lọc:";
            // 
            // D38F4B00
            // 
            this.D38F4B00.Cursor = System.Windows.Forms.Cursors.Hand;
            this.D38F4B00.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.D38F4B00.DropDownWidth = 350;
            this.D38F4B00.FormattingEnabled = true;
            this.D38F4B00.ItemHeight = 16;
            this.D38F4B00.Location = new System.Drawing.Point(63, 3);
            this.D38F4B00.Name = "D38F4B00";
            this.D38F4B00.Size = new System.Drawing.Size(167, 24);
            this.D38F4B00.TabIndex = 1;
            this.D38F4B00.SelectedIndexChanged += new System.EventHandler(this.C326FB11);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.D7A63B91);
            this.panel1.Controls.Add(this.plQuanLyThuMuc);
            this.panel1.Controls.Add(this.DC993629);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.btnInteract);
            this.panel1.Controls.Add(this.FBA31BBA);
            this.panel1.Controls.Add(this.F5325785);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 610);
            this.panel1.TabIndex = 11;
            // 
            // D7A63B91
            // 
            this.D7A63B91.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.D7A63B91.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D7A63B91.BackgroundImage")));
            this.D7A63B91.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.D7A63B91.GradientBottomLeft = System.Drawing.Color.RoyalBlue;
            this.D7A63B91.GradientBottomRight = System.Drawing.Color.RoyalBlue;
            this.D7A63B91.GradientTopLeft = System.Drawing.Color.RoyalBlue;
            this.D7A63B91.GradientTopRight = System.Drawing.Color.White;
            this.D7A63B91.Location = new System.Drawing.Point(0, 0);
            this.D7A63B91.Name = "D7A63B91";
            this.D7A63B91.Quality = 10;
            this.D7A63B91.Size = new System.Drawing.Size(1223, 5);
            this.D7A63B91.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.A3864980,
            this.C3919999,
            this.B9BED82A,
            this.lblKey,
            this.toolStripStatusLabel8,
            this.A5376CB6,
            this.CC9D630E,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel10,
            this.lblDateExpried,
            this.toolStripStatusLabel4,
            this.lblCountHighline,
            this.toolStripStatusLabel5,
            this.lblCountSelect,
            this.toolStripStatusLabel7,
            this.lblCountTotal,
            this.toolStripStatusLabel6,
            this.D81D001E});
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.A2AD0898);
            // 
            // F5325785
            // 
            this.F5325785.AllowUserToAddRows = false;
            this.F5325785.AllowUserToDeleteRows = false;
            this.F5325785.AllowUserToResizeRows = false;
            this.F5325785.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.F5325785.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.F5325785.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.F5325785.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.F5325785.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.F5325785.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cChose,
            this.cStt,
            this.cId,
            this.cUid,
            this.cPassword,
            this.cFa2,
            this.cToken,
            this.cCookies,
            this.cEmail,
            this.cEmail2,
            this.cPassMail,
            this.cMailRecovery,
            this.cPassMailRecovery,
            this.cPhone,
            this.cName,
            this.cFollow,
            this.cFriend,
            this.cGroup,
            this.cPage,
            this.cPagePro5,
            this.cBirthday,
            this.cGender,
            this.cOAuth2,
            this.cUseragent,
            this.cProxy,
            this.cDateCreateAcc,
            this.cAvatar,
            this.cProfile,
            this.cThuMuc,
            this.cInteractEnd,
            this.cInfo,
            this.cGhiChu,
            this.cStatus282,
            this.cLocation,
            this.cHometown,
            this.cCurrentCity,
            this.cDating,
            this.cAds,
            this.cBM,
            this.cWallPosts,
            this.cFbBlock,
            this.cJob,
            this.cKichBan,
            this.cCookieHotmail,
            this.cStatus});
            this.F5325785.ContextMenuStrip = this.ctmsAcc;
            this.F5325785.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.F5325785.Location = new System.Drawing.Point(8, 108);
            this.F5325785.Name = "F5325785";
            this.F5325785.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.F5325785.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.F5325785.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.F5325785.Size = new System.Drawing.Size(1204, 475);
            this.F5325785.TabIndex = 0;
            this.F5325785.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.D61E5014);
            this.F5325785.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.C30CDCAD);
            this.F5325785.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.E287B537);
            this.F5325785.SelectionChanged += new System.EventHandler(this.F5325785_SelectionChanged);
            this.F5325785.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.D209253D);
            this.F5325785.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F5325785_KeyDown);
            // 
            // cChose
            // 
            this.cChose.HeaderText = "Chọn";
            this.cChose.Name = "cChose";
            this.cChose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cChose.Width = 40;
            // 
            // cStt
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cStt.DefaultCellStyle = dataGridViewCellStyle2;
            this.cStt.HeaderText = "STT";
            this.cStt.Name = "cStt";
            this.cStt.Width = 35;
            // 
            // cId
            // 
            this.cId.HeaderText = "Id";
            this.cId.Name = "cId";
            this.cId.Visible = false;
            this.cId.Width = 90;
            // 
            // cUid
            // 
            this.cUid.HeaderText = "UID";
            this.cUid.Name = "cUid";
            this.cUid.Width = 80;
            // 
            // cPassword
            // 
            this.cPassword.HeaderText = "Mật khẩu";
            this.cPassword.Name = "cPassword";
            this.cPassword.Visible = false;
            this.cPassword.Width = 85;
            // 
            // cFa2
            // 
            this.cFa2.HeaderText = "2FA";
            this.cFa2.Name = "cFa2";
            this.cFa2.Width = 80;
            // 
            // cToken
            // 
            this.cToken.HeaderText = "Token";
            this.cToken.Name = "cToken";
            this.cToken.Width = 70;
            // 
            // cCookies
            // 
            this.cCookies.HeaderText = "Cookie";
            this.cCookies.Name = "cCookies";
            this.cCookies.Width = 70;
            // 
            // cEmail
            // 
            this.cEmail.HeaderText = "Email";
            this.cEmail.Name = "cEmail";
            this.cEmail.Width = 60;
            // 
            // cEmail2
            // 
            this.cEmail2.HeaderText = "Email full";
            this.cEmail2.Name = "cEmail2";
            // 
            // cPassMail
            // 
            this.cPassMail.HeaderText = "Mật khẩu mail";
            this.cPassMail.Name = "cPassMail";
            this.cPassMail.Visible = false;
            this.cPassMail.Width = 120;
            // 
            // cMailRecovery
            // 
            this.cMailRecovery.HeaderText = "Email khôi phục";
            this.cMailRecovery.Name = "cMailRecovery";
            this.cMailRecovery.Visible = false;
            this.cMailRecovery.Width = 125;
            // 
            // cPassMailRecovery
            // 
            this.cPassMailRecovery.HeaderText = "Pass mail khôi phục";
            this.cPassMailRecovery.Name = "cPassMailRecovery";
            this.cPassMailRecovery.Visible = false;
            this.cPassMailRecovery.Width = 150;
            // 
            // cPhone
            // 
            this.cPhone.HeaderText = "Phone";
            this.cPhone.Name = "cPhone";
            this.cPhone.Visible = false;
            this.cPhone.Width = 90;
            // 
            // cName
            // 
            this.cName.HeaderText = "Tên";
            this.cName.Name = "cName";
            this.cName.Width = 70;
            // 
            // cFollow
            // 
            this.cFollow.HeaderText = "Theo dõi";
            this.cFollow.Name = "cFollow";
            this.cFollow.Visible = false;
            this.cFollow.Width = 85;
            // 
            // cFriend
            // 
            this.cFriend.HeaderText = "Bạn bè";
            this.cFriend.Name = "cFriend";
            this.cFriend.Width = 75;
            // 
            // cGroup
            // 
            this.cGroup.HeaderText = "Nhóm";
            this.cGroup.Name = "cGroup";
            this.cGroup.Visible = false;
            this.cGroup.Width = 60;
            // 
            // cPage
            // 
            this.cPage.HeaderText = "Page";
            this.cPage.Name = "cPage";
            this.cPage.Visible = false;
            this.cPage.Width = 60;
            // 
            // cPagePro5
            // 
            this.cPagePro5.HeaderText = "Page pro5";
            this.cPagePro5.Name = "cPagePro5";
            this.cPagePro5.Visible = false;
            // 
            // cBirthday
            // 
            this.cBirthday.HeaderText = "Ngày sinh";
            this.cBirthday.Name = "cBirthday";
            this.cBirthday.Width = 90;
            // 
            // cGender
            // 
            this.cGender.HeaderText = "Giới Tính";
            this.cGender.Name = "cGender";
            this.cGender.Width = 82;
            // 
            // cOAuth2
            // 
            this.cOAuth2.HeaderText = "OAuth2";
            this.cOAuth2.Name = "cOAuth2";
            this.cOAuth2.Visible = false;
            this.cOAuth2.Width = 70;
            // 
            // cUseragent
            // 
            this.cUseragent.HeaderText = "Useragent";
            this.cUseragent.Name = "cUseragent";
            this.cUseragent.Visible = false;
            this.cUseragent.Width = 70;
            // 
            // cProxy
            // 
            this.cProxy.HeaderText = "Proxy";
            this.cProxy.Name = "cProxy";
            this.cProxy.Visible = false;
            this.cProxy.Width = 55;
            // 
            // cDateCreateAcc
            // 
            this.cDateCreateAcc.HeaderText = "Ngày tạo";
            this.cDateCreateAcc.Name = "cDateCreateAcc";
            this.cDateCreateAcc.Visible = false;
            this.cDateCreateAcc.Width = 85;
            // 
            // cAvatar
            // 
            this.cAvatar.HeaderText = "Avatar";
            this.cAvatar.Name = "cAvatar";
            this.cAvatar.Visible = false;
            this.cAvatar.Width = 50;
            // 
            // cProfile
            // 
            this.cProfile.HeaderText = "Profile";
            this.cProfile.Name = "cProfile";
            this.cProfile.Visible = false;
            this.cProfile.Width = 50;
            // 
            // cThuMuc
            // 
            this.cThuMuc.HeaderText = "Thư mục";
            this.cThuMuc.Name = "cThuMuc";
            this.cThuMuc.Visible = false;
            // 
            // cInteractEnd
            // 
            this.cInteractEnd.HeaderText = "Lần tương tác cuối";
            this.cInteractEnd.Name = "cInteractEnd";
            this.cInteractEnd.Visible = false;
            this.cInteractEnd.Width = 160;
            // 
            // cInfo
            // 
            this.cInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cInfo.HeaderText = "Tình Trạng";
            this.cInfo.Name = "cInfo";
            this.cInfo.Visible = false;
            // 
            // cGhiChu
            // 
            this.cGhiChu.HeaderText = "Ghi Chú";
            this.cGhiChu.Name = "cGhiChu";
            this.cGhiChu.Visible = false;
            this.cGhiChu.Width = 90;
            // 
            // cStatus282
            // 
            this.cStatus282.HeaderText = "Status 282";
            this.cStatus282.Name = "cStatus282";
            this.cStatus282.Visible = false;
            // 
            // cLocation
            // 
            this.cLocation.HeaderText = "Location";
            this.cLocation.Name = "cLocation";
            this.cLocation.Visible = false;
            this.cLocation.Width = 80;
            // 
            // cHometown
            // 
            this.cHometown.HeaderText = "Hometown";
            this.cHometown.Name = "cHometown";
            this.cHometown.Visible = false;
            this.cHometown.Width = 90;
            // 
            // cCurrentCity
            // 
            this.cCurrentCity.HeaderText = "Current City";
            this.cCurrentCity.Name = "cCurrentCity";
            this.cCurrentCity.Visible = false;
            // 
            // cDating
            // 
            this.cDating.HeaderText = "Dating";
            this.cDating.Name = "cDating";
            this.cDating.Visible = false;
            // 
            // cAds
            // 
            this.cAds.HeaderText = "Ads";
            this.cAds.Name = "cAds";
            this.cAds.Visible = false;
            // 
            // cBM
            // 
            this.cBM.HeaderText = "BM";
            this.cBM.Name = "cBM";
            this.cBM.Visible = false;
            // 
            // cWallPosts
            // 
            this.cWallPosts.HeaderText = "Wall Posts";
            this.cWallPosts.Name = "cWallPosts";
            this.cWallPosts.Visible = false;
            // 
            // cFbBlock
            // 
            this.cFbBlock.HeaderText = "Fb Block";
            this.cFbBlock.Name = "cFbBlock";
            this.cFbBlock.Width = 80;
            // 
            // cJob
            // 
            this.cJob.HeaderText = "Job";
            this.cJob.Name = "cJob";
            this.cJob.Visible = false;
            // 
            // cKichBan
            // 
            this.cKichBan.HeaderText = "Kịch bản";
            this.cKichBan.Name = "cKichBan";
            this.cKichBan.Visible = false;
            this.cKichBan.Width = 80;
            // 
            // cCookieHotmail
            // 
            this.cCookieHotmail.HeaderText = "Cookie Hotmail";
            this.cCookieHotmail.Name = "cCookieHotmail";
            this.cCookieHotmail.Visible = false;
            this.cCookieHotmail.Width = 120;
            // 
            // cStatus
            // 
            this.cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cStatus.HeaderText = "Trạng Thái";
            this.cStatus.MinimumWidth = 200;
            this.cStatus.Name = "cStatus";
            // 
            // timer_0
            // 
            this.timer_0.Tick += new System.EventHandler(this.C6BE9FB7);
            // 
            // fMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 610);
            this.Controls.Add(this.plTrangThai);
            this.Controls.Add(this.D39C9728);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.D39C9728;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LushCare";
            this.ctmsAcc.ResumeLayout(false);
            this.FBA31BBA.ResumeLayout(false);
            this.FBA31BBA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLanguage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.D39C9728.ResumeLayout(false);
            this.D39C9728.PerformLayout();
            this.plTrangThai.ResumeLayout(false);
            this.DC993629.ResumeLayout(false);
            this.DC993629.PerformLayout();
            this.plQuanLyThuMuc.ResumeLayout(false);
            this.plQuanLyThuMuc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F5325785)).EndInit();
            this.ResumeLayout(false);

	}
}
