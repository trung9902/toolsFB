using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhCheckpoint : Form
{
	internal static bool E1AD3A3A;

	internal List<string> FA294104 = new List<string>();

	internal List<string> list_0 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl A72AB110;

	internal Panel panel1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox AC961EA9;

	internal BunifuCustomLabel FD8D883E;

	internal CheckBox ckbCaptcha;

	internal TextBox BF925007;

	internal CheckBox ckbImage;

	internal CheckBox ckbPhone;

	internal Panel plPhone;

	internal NumericUpDown FFAFAE37;

	internal Label label2;

	internal BackgroundWorker D52DAB84;

	internal Panel plImage;

	internal RadioButton BE949F25;

	internal RadioButton rbFolder;

	internal Panel D69D8324;

	internal ComboBox cbbCaptcha;

	internal TextBox D02FF312;

	internal Panel plServiceId;

	internal TextBox txtServiceId;

	internal Label B99C6B88;

	internal ComboBox cbbTypePhone;

	internal TextBox BD19A19E;

	internal CheckBox ckbLanguage;

	internal LinkLabel F930CAB4;

	internal Label label3;

	internal GroupBox groupBox2;

	internal RadioButton rbPassTuDat;

	internal RadioButton rbPassNgauNhien;

	internal TextBox txtPass;

	internal GroupBox F7906D17;

	internal Button C112C107;

	internal NumericUpDown nudLimitCountGetPhone;

	internal Label F1A13AA8;

	internal Label label5;

	internal NumericUpDown nudLimitTimeGetPhone;

	internal CheckBox ckbAddMail;

	internal Panel plMail;

	internal Button FD1457AE;

	internal ComboBox cbbTypeMail;

	internal Label label7;

	internal CheckBox F7A5560E;

	internal CheckBox F0830193;

	internal ComboBox cbbLanguageSauKhiUnlock;

	internal CheckBox D0085A2A;

	internal Button AF1D3A06;

	internal LinkLabel linkLabel2;

	internal CheckBox ckbXoaMailCu;

	internal TextBox txtLanguage;

	internal ComboBox A398DCA7;

	internal Button button4;

	internal Panel plNhapSdt;

	internal RichTextBox F116D807;

	internal Label lblSdt;

	internal CheckBox C0856CB8;

	internal CheckBox ckbDeleteContact;

	internal CheckBox ckbSkipRecaptcha;

	internal Panel A199EB2A;

	internal Button button11;

	internal TextBox txtFolderLink956;

	internal NumericUpDown nudCountLink956;

	internal Label FC846581;

	internal Label label8;

	internal CheckBox B91C26AD;

	internal TextBox F0958426;

	internal Label BA9D3D0B;

	internal Button C5B8CEA1;

	internal CheckBox C1A8C1B6;

	internal CheckBox ckbQuayVideo;

	public fCauHinhCheckpoint(string D487329E = "")
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		E1AD3A3A = false;
		ckbDeleteContact.Visible = D487329E.Contains("956");
		F7906D17.Enabled = D487329E.Contains("282");
		C1A8C1B6.Enabled = D487329E == "282chrome";
		ckbQuayVideo.Enabled = Base.bool_0 || Base.bool_7;
		ckbQuayVideo.Visible = Base.bool_0 || Base.bool_7;
	}

	private void fCauHinhCheckpoint_Load(object sender, EventArgs e)
	{
		B2326CA5();
		method_0();
		try
		{
			if (C5034B95.smethod_0("configCheckpoint").method_2("typePass", 1) == 0)
			{
				rbPassTuDat.Checked = true;
			}
			else
			{
				rbPassNgauNhien.Checked = true;
			}
			txtPass.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPass");
			ckbCaptcha.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbCaptcha");
			ckbSkipRecaptcha.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbSkipRecaptcha");
			int num = C5034B95.smethod_0("configCheckpoint").method_2("typeCaptcha", 8);
			if (num == 4)
			{
				num = 8;
			}
			try
			{
				cbbCaptcha.SelectedValue = num.ToString();
			}
			catch
			{
			}
			F0958426.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4");
			D02FF312.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + num);
			if (D02FF312.Text == "")
			{
				switch (num)
				{
				case 9:
					D02FF312.Text = GeminiVisionCaptchaHelper.GetGeminiApiKey();
					break;
				case 2:
					D02FF312.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtAnyCaptcha");
					break;
				case 0:
					D02FF312.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txt2Captcha");
					break;
				}
			}
			C0856CB8.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbSwitch282To956");
			ckbPhone.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbPhone");
			int num2 = C5034B95.smethod_0("configCheckpoint").method_2("typeSim");
			try
			{
				cbbTypePhone.SelectedValue = num2.ToString();
			}
			catch
			{
			}
			BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + num2);
			if (BD19A19E.Text == "")
			{
				switch (num2)
				{
				case 0:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtAhaSim");
					break;
				case 2:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtSimCode");
					break;
				case 4:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPrimeOtp");
					break;
				case 6:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtOtpfb");
					break;
				case 8:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtViotp");
					break;
				case 9:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtOtpTextnow");
					break;
				case 10:
					BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtTempCode");
					break;
				}
			}
			txtServiceId.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtServiceId", "fb_tn");
			FFAFAE37.Value = C5034B95.smethod_0("configCheckpoint").method_2("nudTime", 120);
			nudLimitCountGetPhone.Value = C5034B95.smethod_0("configCheckpoint").method_2("nudLimitCountGetPhone", 3);
			nudLimitTimeGetPhone.Value = C5034B95.smethod_0("configCheckpoint").method_2("nudLimitTimeGetPhone", 100);
			ckbLanguage.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbLanguage");
			txtLanguage.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtLanguage", "en_US,th_TH,my_MM");
			D0085A2A.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbDoiNgonNguSauKhiUnlock");
			cbbLanguageSauKhiUnlock.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("cbbLanguageSauKhiUnlock", "en_US");
			F116D807.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtSdt");
			ckbAddMail.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbAddMail");
			cbbTypeMail.SelectedIndex = C5034B95.smethod_0("configCheckpoint").method_2("cbbTypeMail");
			FA294104 = C5034B95.smethod_0("configCheckpoint").method_1("lstHotmail");
			list_0 = C5034B95.smethod_0("configCheckpoint").method_1("lstMailDomain");
			list_1 = C5034B95.smethod_0("configCheckpoint").method_1("lstDomain");
			ckbImage.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbImage");
			F7A5560E.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbBackupAnh");
			F0830193.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbChangeMD5");
			C1A8C1B6.Checked = C1A8C1B6.Enabled && C5034B95.smethod_0("configCheckpoint").method_3("ckbUseFreeFb");
			ckbQuayVideo.Checked = ckbQuayVideo.Enabled && C5034B95.smethod_0("configCheckpoint").method_3("ckbQuayVideo");
			if (C5034B95.smethod_0("configCheckpoint").method_2("typeImage") == 0)
			{
				rbFolder.Checked = true;
			}
			else
			{
				BE949F25.Checked = true;
			}
			BF925007.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImage");
			A398DCA7.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtImageUrl", "https://thispersondoesnotexist.com/");
			ckbDeleteContact.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbDeleteContact");
			B91C26AD.Checked = C5034B95.smethod_0("configCheckpoint").method_3("ckbXuatLink956");
			nudCountLink956.Value = C5034B95.smethod_0("configCheckpoint").method_2("nudCountLink956", 1);
			txtFolderLink956.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtFolderLink956");
		}
		catch
		{
		}
		BB1FD3A3();
	}

	private void B2326CA5()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "https://2captcha.com/");
		dictionary.Add("8", "https://capsolver.com/");
		dictionary.Add("9", "Google Gemini Vision AI (Miễn phí & Tức thì)");
		cbbCaptcha.DataSource = new BindingSource(dictionary, null);
		cbbCaptcha.DisplayMember = "Value";
		cbbCaptcha.ValueMember = "Key";
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("36", "https://usotp.xyz/");
		dictionary.Add("62", "https://sms.dichvummo.org/ -> https://globalotp.org/");
		dictionary.Add("59", "https://muasms.com/");
		dictionary.Add("56", "https://random-otp.io.vn/");
		if (Base.bool_0)
		{
			dictionary.Add("50", "http://mthgroup.vn");
		}
		dictionary.Add("12", "https://winmail.shop/");
		dictionary.Add("45", "https://winmail.shop/ RU");
		dictionary.Add("30", "https://ironsim.com/ VN");
		dictionary.Add("41", "https://ironsim.com/ US");
		dictionary.Add("54", "https://ironsim.com/ Canada");
		dictionary.Add("17", "https://2ndline.pro/");
		dictionary.Add("19", "http://hcotp.com/");
		dictionary.Add("13", "https://sim24.cc/ -> https://funotp.com/");
		dictionary.Add("52", "https://sim24.cc/ US -> https://funotp.com/ US");
		dictionary.Add("14", "https://codetext247.com/");
		dictionary.Add("2", "http://chothuesimcode.com/ -> https://chaycodeso3.com/");
		dictionary.Add("8", "https://viotp.com/");
		dictionary.Add("48", "https://otptextnow.com/ 500đ");
		dictionary.Add("9", "https://otptextnow.com/");
		dictionary.Add("32", "https://thuesim.app/");
		dictionary.Add("23", "https://codeotp.site/");
		dictionary.Add("16", "https://otp282.com/");
		dictionary.Add("53", "https://fastsim.online/");
		cbbTypePhone.DataSource = new BindingSource(dictionary, null);
		cbbTypePhone.DisplayMember = "Value";
		cbbTypePhone.ValueMember = "Key";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			if (rbPassNgauNhien.Checked)
			{
				num = 1;
			}
			C5034B95.smethod_0("configCheckpoint").method_4("typePass", num);
			C5034B95.smethod_0("configCheckpoint").method_4("txtPass", txtPass.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbCaptcha", ckbCaptcha.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbSkipRecaptcha", ckbSkipRecaptcha.Checked);
			int num2 = 0;
			try
			{
				num2 = Convert.ToInt32(cbbCaptcha.SelectedValue);
			}
			catch (Exception)
			{
			}
			C5034B95.smethod_0("configCheckpoint").method_4("typeCaptcha", num2);
			C5034B95.smethod_0("configCheckpoint").method_4("txtCaptcha_4", F0958426.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("txtCaptcha_" + num2, D02FF312.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbSwitch282To956", C0856CB8.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbPhone", ckbPhone.Checked);
			int num3 = 0;
			try
			{
				num3 = Convert.ToInt32(cbbTypePhone.SelectedValue);
			}
			catch
			{
			}
			C5034B95.smethod_0("configCheckpoint").method_4("typeSim", num3);
			C5034B95.smethod_0("configCheckpoint").method_4("txtApiPhone_" + num3, BD19A19E.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("txtServiceId", txtServiceId.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("nudTime", FFAFAE37.Value);
			C5034B95.smethod_0("configCheckpoint").method_4("nudLimitCountGetPhone", nudLimitCountGetPhone.Value);
			C5034B95.smethod_0("configCheckpoint").method_4("nudLimitTimeGetPhone", nudLimitTimeGetPhone.Value);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbLanguage", ckbLanguage.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("txtLanguage", txtLanguage.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbDoiNgonNguSauKhiUnlock", D0085A2A.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("cbbLanguageSauKhiUnlock", cbbLanguageSauKhiUnlock.Text.Split('|')[0]);
			C5034B95.smethod_0("configCheckpoint").method_4("txtSdt", F116D807.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbAddMail", ckbAddMail.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("cbbTypeMail", cbbTypeMail.SelectedIndex);
			C5034B95.smethod_0("configCheckpoint").FD3CCF90("lstHotmail", FA294104);
			C5034B95.smethod_0("configCheckpoint").FD3CCF90("lstMailDomain", list_0);
			C5034B95.smethod_0("configCheckpoint").FD3CCF90("lstDomain", list_1);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbImage", ckbImage.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbBackupAnh", F7A5560E.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbChangeMD5", F0830193.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbUseFreeFb", C1A8C1B6.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbQuayVideo", ckbQuayVideo.Checked);
			int num4 = 0;
			if (BE949F25.Checked)
			{
				num4 = 1;
			}
			C5034B95.smethod_0("configCheckpoint").method_4("typeImage", num4);
			C5034B95.smethod_0("configCheckpoint").method_4("txtImage", BF925007.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("txtImageUrl", A398DCA7.Text);
			C5034B95.smethod_0("configCheckpoint").method_4("ckbXuatLink956", B91C26AD.Checked);
			C5034B95.smethod_0("configCheckpoint").method_4("nudCountLink956", nudCountLink956.Value);
			C5034B95.smethod_0("configCheckpoint").method_4("txtFolderLink956", txtFolderLink956.Text);
			C5034B95.smethod_1("configCheckpoint");
			E1AD3A3A = true;
			C5034B95.smethod_0("configCheckpoint").method_4("ckbDeleteContact", ckbDeleteContact.Checked);
			Close();
		}
		catch
		{
			MsBoxHelper.Show("Vui lòng thử lại sau!", 2);
		}
	}

	private void BB1FD3A3()
	{
		ckbCaptcha_CheckedChanged(null, null);
		ckbPhone_CheckedChanged(null, null);
		D13FCD39(null, null);
		rbFolder_CheckedChanged(null, null);
		BE949F25_CheckedChanged(null, null);
		DE997814(null, null);
		B4869904(null, null);
		B52FD3A4();
		D0085A2A_CheckedChanged(null, null);
		cbbTypePhone_SelectedIndexChanged(null, null);
		F116D807_TextChanged(null, null);
		A5265C30(null, null);
		F33B90B8(null, null);
		EBA87BBC(null, null);
	}

	private void B52FD3A4()
	{
		switch (cbbTypeMail.SelectedIndex)
		{
		case 0:
			Commom.E998C514(FD1457AE, FA294104.Count);
			break;
		case 1:
			Commom.E998C514(FD1457AE, list_0.Count);
			break;
		case 2:
			Commom.E998C514(FD1457AE, list_1.Count);
			break;
		}
	}

	private void B6B8C989(object sender, EventArgs e)
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

	private void ckbCaptcha_CheckedChanged(object sender, EventArgs e)
	{
		D69D8324.Enabled = ckbCaptcha.Checked;
	}

	private void ckbPhone_CheckedChanged(object sender, EventArgs e)
	{
		plPhone.Enabled = ckbPhone.Checked;
	}

	private void D13FCD39(object sender, EventArgs e)
	{
		plImage.Enabled = ckbImage.Checked;
	}

	private void rbFolder_CheckedChanged(object sender, EventArgs e)
	{
		BF925007.Enabled = rbFolder.Checked;
	}

	private void cbbCaptcha_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			D02FF312.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + cbbCaptcha.SelectedValue.ToString());
		}
		catch
		{
		}
	}

	private void D8BD7D92(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = "https://minsoftware.vn/tong-hop-ma-danh-sach-ngon-ngu-giai-checkpoint282-facebook/#4_Doi_ngon_ngu_khi_giai";
		try
		{
			Process.Start("chrome.exe", text);
		}
		catch
		{
			Process.Start(text);
		}
	}

	private void DE997814(object sender, EventArgs e)
	{
		txtLanguage.Enabled = ckbLanguage.Checked;
	}

	private void cbbTypePhone_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = "0";
		try
		{
			text = cbbTypePhone.SelectedValue.ToString();
		}
		catch (Exception)
		{
		}
		BD19A19E.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + text);
		plServiceId.Visible = text == "10";
		plNhapSdt.Visible = text == "37" || text == "50";
	}

	private void rbPassTuDat_CheckedChanged(object sender, EventArgs e)
	{
		txtPass.Enabled = rbPassTuDat.Checked;
	}

	private void EB1474B6(object sender, EventArgs e)
	{
		string object_ = "Có thể sử dụng ký tự * để random 1 ký tự ngẫu nhiên!\r\nVí dụ: MIN****** => MINdfghta";
		MsBoxHelper.Show(object_);
	}

	private void B4869904(object sender, EventArgs e)
	{
		plMail.Enabled = ckbAddMail.Checked;
	}

	private void D12BE8B6(object sender, EventArgs e)
	{
		switch (cbbTypeMail.SelectedIndex)
		{
		case 0:
		{
			fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(FA294104, "Nhâ\u0323p danh sa\u0301ch hotmail (mail|pass mail)", "Danh sa\u0301ch mail|pass mail", "(Mô\u0303i nội dung 1 do\u0300ng)");
			Commom.smethod_35(fNhapDuLieu4);
			FA294104 = fNhapDuLieu4.list_0;
			Commom.E998C514(FD1457AE, FA294104.Count);
			break;
		}
		case 1:
		{
			fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_0, "Nhâ\u0323p danh sa\u0301ch link mail domain", "Danh sa\u0301ch link mail domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
			Commom.smethod_35(fNhapDuLieu4);
			list_0 = fNhapDuLieu4.list_0;
			Commom.E998C514(FD1457AE, list_0.Count);
			break;
		}
		case 2:
		{
			fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_1, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
			Commom.smethod_35(fNhapDuLieu4);
			list_1 = fNhapDuLieu4.list_0;
			Commom.E998C514(FD1457AE, list_1.Count);
			break;
		}
		}
	}

	private void BE949F25_CheckedChanged(object sender, EventArgs e)
	{
		A398DCA7.Enabled = BE949F25.Checked;
	}

	private void cbbTypeMail_SelectedIndexChanged(object sender, EventArgs e)
	{
		B52FD3A4();
	}

	private void D0085A2A_CheckedChanged(object sender, EventArgs e)
	{
		cbbLanguageSauKhiUnlock.Enabled = D0085A2A.Checked;
	}

	private void AF1D3A06_Click(object sender, EventArgs e)
	{
		int num = C5034B95.smethod_0("configCheckpoint").method_2("typeSim");
		string object_ = GClass2.D90B63A4(C5034B95.smethod_0("configCheckpoint").method_2("typeSim"), C5034B95.smethod_0("configCheckpoint").BDB80B23("txtApiPhone_" + num), C5034B95.smethod_0("configCheckpoint").method_2("nudLimitTimeGetPhone"), C5034B95.smethod_0("configCheckpoint").BDB80B23("txtServiceId"), C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCustom").Split('*')[0]);
		MsBoxHelper.Show(object_);
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.CE2E5B3B(Base.string_2 + "/download/MaxDownloadImage.zip");
	}

	private void button4_Click(object sender, EventArgs e)
	{
		string text = "";
		if (cbbCaptcha.SelectedValue?.ToString() == "9" || (cbbCaptcha.Text != null && cbbCaptcha.Text.Contains("Gemini")))
		{
			string key = D02FF312.Text.Trim();
			if (string.IsNullOrEmpty(key)) key = GeminiVisionCaptchaHelper.GetGeminiApiKey();
			if (string.IsNullOrEmpty(key))
			{
				text = "Vui lòng nhập Google Gemini API Key!";
			}
			else
			{
				string testRes = Commom.CallGeminiApi(key, "Test connection. Trả về đúng từ OK.");
				if (!testRes.StartsWith("Error:", StringComparison.OrdinalIgnoreCase))
				{
					text = "Kết nối Google Gemini Vision AI thành công! (Phản hồi: " + testRes.Trim() + ")";
				}
				else
				{
					text = "Lỗi kết nối Gemini: " + testRes;
				}
			}
		}
		else
		{
			text = ((!(cbbCaptcha.Text == "https://capsolver.com/")) ? Commom.smethod_0(cbbCaptcha.Text.ToString(), D02FF312.Text.Trim()) : Commom.smethod_0("https://www.capsolver.com", D02FF312.Text.Trim()));
		}
		MsBoxHelper.Show(text);
	}

	private void F116D807_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(F116D807, lblSdt);
	}

	private void button11_Click(object sender, EventArgs e)
	{
		string text = Commom.smethod_40(txtFolderLink956.Text);
		if (text != "")
		{
			txtFolderLink956.Text = text;
		}
	}

	private void A5265C30(object sender, EventArgs e)
	{
		A199EB2A.Enabled = B91C26AD.Checked;
	}

	private void A9AD0C30(object sender, EventArgs e)
	{
		string object_ = Commom.smethod_0("https://omocaptcha.com/", F0958426.Text.Trim());
		MsBoxHelper.Show(object_);
	}

	private void F33B90B8(object sender, EventArgs e)
	{
		if (C1A8C1B6.Enabled)
		{
			if (C1A8C1B6.Checked)
			{
				ckbQuayVideo.Checked = false;
				ckbQuayVideo.Enabled = false;
			}
			else
			{
				ckbQuayVideo.Enabled = true;
			}
		}
	}

	private void EBA87BBC(object sender, EventArgs e)
	{
		if (ckbQuayVideo.Enabled)
		{
			if (ckbQuayVideo.Checked)
			{
				C1A8C1B6.Checked = false;
				C1A8C1B6.Enabled = false;
			}
			else
			{
				C1A8C1B6.Enabled = true;
			}
		}
	}

	protected override void Dispose(bool E2804517)
	{
		if (E2804517 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(E2804517);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		FD8D883E = new Bunifu.Framework.UI.BunifuCustomLabel();
		A72AB110 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		AC961EA9 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		A199EB2A = new System.Windows.Forms.Panel();
		button11 = new System.Windows.Forms.Button();
		txtFolderLink956 = new System.Windows.Forms.TextBox();
		nudCountLink956 = new System.Windows.Forms.NumericUpDown();
		FC846581 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		B91C26AD = new System.Windows.Forms.CheckBox();
		plNhapSdt = new System.Windows.Forms.Panel();
		F116D807 = new System.Windows.Forms.RichTextBox();
		lblSdt = new System.Windows.Forms.Label();
		groupBox2 = new System.Windows.Forms.GroupBox();
		C112C107 = new System.Windows.Forms.Button();
		rbPassTuDat = new System.Windows.Forms.RadioButton();
		rbPassNgauNhien = new System.Windows.Forms.RadioButton();
		txtPass = new System.Windows.Forms.TextBox();
		F7906D17 = new System.Windows.Forms.GroupBox();
		linkLabel2 = new System.Windows.Forms.LinkLabel();
		cbbLanguageSauKhiUnlock = new System.Windows.Forms.ComboBox();
		plPhone = new System.Windows.Forms.Panel();
		txtLanguage = new System.Windows.Forms.TextBox();
		BD19A19E = new System.Windows.Forms.TextBox();
		AF1D3A06 = new System.Windows.Forms.Button();
		F930CAB4 = new System.Windows.Forms.LinkLabel();
		plServiceId = new System.Windows.Forms.Panel();
		txtServiceId = new System.Windows.Forms.TextBox();
		B99C6B88 = new System.Windows.Forms.Label();
		nudLimitTimeGetPhone = new System.Windows.Forms.NumericUpDown();
		nudLimitCountGetPhone = new System.Windows.Forms.NumericUpDown();
		FFAFAE37 = new System.Windows.Forms.NumericUpDown();
		label5 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		F1A13AA8 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		ckbLanguage = new System.Windows.Forms.CheckBox();
		cbbTypePhone = new System.Windows.Forms.ComboBox();
		C0856CB8 = new System.Windows.Forms.CheckBox();
		ckbPhone = new System.Windows.Forms.CheckBox();
		ckbAddMail = new System.Windows.Forms.CheckBox();
		ckbImage = new System.Windows.Forms.CheckBox();
		plMail = new System.Windows.Forms.Panel();
		FD1457AE = new System.Windows.Forms.Button();
		cbbTypeMail = new System.Windows.Forms.ComboBox();
		label7 = new System.Windows.Forms.Label();
		plImage = new System.Windows.Forms.Panel();
		A398DCA7 = new System.Windows.Forms.ComboBox();
		BE949F25 = new System.Windows.Forms.RadioButton();
		rbFolder = new System.Windows.Forms.RadioButton();
		BF925007 = new System.Windows.Forms.TextBox();
		ckbQuayVideo = new System.Windows.Forms.CheckBox();
		C1A8C1B6 = new System.Windows.Forms.CheckBox();
		F0830193 = new System.Windows.Forms.CheckBox();
		F7A5560E = new System.Windows.Forms.CheckBox();
		D0085A2A = new System.Windows.Forms.CheckBox();
		D69D8324 = new System.Windows.Forms.Panel();
		cbbCaptcha = new System.Windows.Forms.ComboBox();
		F0958426 = new System.Windows.Forms.TextBox();
		D02FF312 = new System.Windows.Forms.TextBox();
		ckbSkipRecaptcha = new System.Windows.Forms.CheckBox();
		BA9D3D0B = new System.Windows.Forms.Label();
		C5B8CEA1 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		ckbDeleteContact = new System.Windows.Forms.CheckBox();
		ckbCaptcha = new System.Windows.Forms.CheckBox();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		ckbXoaMailCu = new System.Windows.Forms.CheckBox();
		D52DAB84 = new System.ComponentModel.BackgroundWorker();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AC961EA9).BeginInit();
		panel1.SuspendLayout();
		A199EB2A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountLink956).BeginInit();
		plNhapSdt.SuspendLayout();
		groupBox2.SuspendLayout();
		F7906D17.SuspendLayout();
		plPhone.SuspendLayout();
		plServiceId.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLimitTimeGetPhone).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudLimitCountGetPhone).BeginInit();
		((System.ComponentModel.ISupportInitialize)FFAFAE37).BeginInit();
		plMail.SuspendLayout();
		plImage.SuspendLayout();
		D69D8324.SuspendLayout();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = FD8D883E;
		bunifuDragControl_0.Vertical = true;
		FD8D883E.BackColor = System.Drawing.Color.Transparent;
		FD8D883E.Cursor = System.Windows.Forms.Cursors.SizeAll;
		FD8D883E.Dock = System.Windows.Forms.DockStyle.Fill;
		FD8D883E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FD8D883E.ForeColor = System.Drawing.Color.Black;
		FD8D883E.Location = new System.Drawing.Point(0, 0);
		FD8D883E.Name = "bunifuCustomLabel1";
		FD8D883E.Size = new System.Drawing.Size(873, 31);
		FD8D883E.TabIndex = 12;
		FD8D883E.Text = "Cấu hình Giải Checkpoint";
		FD8D883E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A72AB110.Fixed = true;
		A72AB110.Horizontal = true;
		A72AB110.TargetControl = pnlHeader;
		A72AB110.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(AC961EA9);
		pnlHeader.Controls.Add(FD8D883E);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(873, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.FF80C508;
		button1.Location = new System.Drawing.Point(842, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		AC961EA9.Cursor = System.Windows.Forms.Cursors.Default;
		AC961EA9.Image = Class155.DD225F0D;
		AC961EA9.Location = new System.Drawing.Point(3, 2);
		AC961EA9.Name = "pictureBox1";
		AC961EA9.Size = new System.Drawing.Size(34, 27);
		AC961EA9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AC961EA9.TabIndex = 76;
		AC961EA9.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(A199EB2A);
		panel1.Controls.Add(B91C26AD);
		panel1.Controls.Add(plNhapSdt);
		panel1.Controls.Add(groupBox2);
		panel1.Controls.Add(F7906D17);
		panel1.Controls.Add(D69D8324);
		panel1.Controls.Add(ckbDeleteContact);
		panel1.Controls.Add(ckbCaptcha);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(ckbXoaMailCu);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(876, 550);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		A199EB2A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A199EB2A.Controls.Add(button11);
		A199EB2A.Controls.Add(txtFolderLink956);
		A199EB2A.Controls.Add(nudCountLink956);
		A199EB2A.Controls.Add(FC846581);
		A199EB2A.Controls.Add(label8);
		A199EB2A.Location = new System.Drawing.Point(45, 281);
		A199EB2A.Name = "plXuatLink956";
		A199EB2A.Size = new System.Drawing.Size(367, 61);
		A199EB2A.TabIndex = 202;
		A199EB2A.Visible = false;
		button11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button11.Cursor = System.Windows.Forms.Cursors.Hand;
		button11.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		button11.ForeColor = System.Drawing.Color.Black;
		button11.Location = new System.Drawing.Point(303, 31);
		button11.Name = "button11";
		button11.Size = new System.Drawing.Size(59, 25);
		button11.TabIndex = 150;
		button11.Text = "...";
		button11.UseVisualStyleBackColor = true;
		button11.Click += new System.EventHandler(button11_Click);
		txtFolderLink956.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtFolderLink956.Location = new System.Drawing.Point(95, 32);
		txtFolderLink956.Name = "txtFolderLink956";
		txtFolderLink956.Size = new System.Drawing.Size(202, 23);
		txtFolderLink956.TabIndex = 151;
		nudCountLink956.Location = new System.Drawing.Point(95, 4);
		nudCountLink956.Name = "nudCountLink956";
		nudCountLink956.Size = new System.Drawing.Size(78, 23);
		nudCountLink956.TabIndex = 1;
		FC846581.AutoSize = true;
		FC846581.Location = new System.Drawing.Point(3, 34);
		FC846581.Name = "label9";
		FC846581.Size = new System.Drawing.Size(70, 16);
		FC846581.TabIndex = 0;
		FC846581.Text = "Folder lưu:";
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(3, 5);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(86, 16);
		label8.TabIndex = 0;
		label8.Text = "Sô\u0301 lươ\u0323ng link:";
		B91C26AD.AutoSize = true;
		B91C26AD.Cursor = System.Windows.Forms.Cursors.Hand;
		B91C26AD.Location = new System.Drawing.Point(24, 259);
		B91C26AD.Name = "ckbXuatLink956";
		B91C26AD.Size = new System.Drawing.Size(164, 20);
		B91C26AD.TabIndex = 201;
		B91C26AD.Text = "Xuâ\u0301t link checkpoint 956";
		B91C26AD.UseVisualStyleBackColor = true;
		B91C26AD.Visible = false;
		B91C26AD.CheckedChanged += new System.EventHandler(A5265C30);
		plNhapSdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plNhapSdt.Controls.Add(F116D807);
		plNhapSdt.Controls.Add(lblSdt);
		plNhapSdt.Location = new System.Drawing.Point(24, 559);
		plNhapSdt.Name = "plNhapSdt";
		plNhapSdt.Size = new System.Drawing.Size(388, 103);
		plNhapSdt.TabIndex = 200;
		plNhapSdt.Visible = false;
		F116D807.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F116D807.Location = new System.Drawing.Point(7, 24);
		F116D807.Name = "txtSdt";
		F116D807.Size = new System.Drawing.Size(374, 74);
		F116D807.TabIndex = 3;
		F116D807.Text = "";
		F116D807.WordWrap = false;
		F116D807.TextChanged += new System.EventHandler(F116D807_TextChanged);
		lblSdt.AutoSize = true;
		lblSdt.Location = new System.Drawing.Point(3, 4);
		lblSdt.Name = "lblSdt";
		lblSdt.Size = new System.Drawing.Size(113, 16);
		lblSdt.TabIndex = 2;
		lblSdt.Text = "Danh sách sđt (0):";
		groupBox2.Controls.Add(C112C107);
		groupBox2.Controls.Add(rbPassTuDat);
		groupBox2.Controls.Add(rbPassNgauNhien);
		groupBox2.Controls.Add(txtPass);
		groupBox2.Location = new System.Drawing.Point(24, 58);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(388, 73);
		groupBox2.TabIndex = 198;
		groupBox2.TabStop = false;
		groupBox2.Text = "Mật khẩu mới";
		C112C107.Cursor = System.Windows.Forms.Cursors.Hand;
		C112C107.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C112C107.Location = new System.Drawing.Point(358, 21);
		C112C107.Name = "button2";
		C112C107.Size = new System.Drawing.Size(24, 24);
		C112C107.TabIndex = 197;
		C112C107.Text = "?";
		C112C107.UseVisualStyleBackColor = true;
		C112C107.Click += new System.EventHandler(EB1474B6);
		rbPassTuDat.AutoSize = true;
		rbPassTuDat.Checked = true;
		rbPassTuDat.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassTuDat.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbPassTuDat.Location = new System.Drawing.Point(19, 22);
		rbPassTuDat.Name = "rbPassTuDat";
		rbPassTuDat.Size = new System.Drawing.Size(115, 20);
		rbPassTuDat.TabIndex = 195;
		rbPassTuDat.TabStop = true;
		rbPassTuDat.Text = "Mật khẩu tự đặt";
		rbPassTuDat.UseVisualStyleBackColor = true;
		rbPassTuDat.CheckedChanged += new System.EventHandler(rbPassTuDat_CheckedChanged);
		rbPassNgauNhien.AutoSize = true;
		rbPassNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassNgauNhien.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbPassNgauNhien.Location = new System.Drawing.Point(19, 47);
		rbPassNgauNhien.Name = "rbPassNgauNhien";
		rbPassNgauNhien.Size = new System.Drawing.Size(125, 20);
		rbPassNgauNhien.TabIndex = 194;
		rbPassNgauNhien.Text = "Mật khẩu random";
		rbPassNgauNhien.UseVisualStyleBackColor = true;
		txtPass.Location = new System.Drawing.Point(142, 21);
		txtPass.Name = "txtPass";
		txtPass.Size = new System.Drawing.Size(210, 23);
		txtPass.TabIndex = 196;
		F7906D17.Controls.Add(linkLabel2);
		F7906D17.Controls.Add(cbbLanguageSauKhiUnlock);
		F7906D17.Controls.Add(plPhone);
		F7906D17.Controls.Add(C0856CB8);
		F7906D17.Controls.Add(ckbPhone);
		F7906D17.Controls.Add(ckbAddMail);
		F7906D17.Controls.Add(ckbImage);
		F7906D17.Controls.Add(plMail);
		F7906D17.Controls.Add(plImage);
		F7906D17.Controls.Add(D0085A2A);
		F7906D17.Location = new System.Drawing.Point(435, 58);
		F7906D17.Name = "grCheckpoint282";
		F7906D17.Size = new System.Drawing.Size(415, 433);
		F7906D17.TabIndex = 197;
		F7906D17.TabStop = false;
		F7906D17.Text = "Checkpoint 282";
		linkLabel2.Location = new System.Drawing.Point(238, 261);
		linkLabel2.Name = "linkLabel2";
		linkLabel2.Size = new System.Drawing.Size(170, 18);
		linkLabel2.TabIndex = 197;
		linkLabel2.TabStop = true;
		linkLabel2.Text = "Phần mềm tải ảnh miễn phí!";
		linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
		cbbLanguageSauKhiUnlock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		cbbLanguageSauKhiUnlock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
		cbbLanguageSauKhiUnlock.DropDownWidth = 150;
		cbbLanguageSauKhiUnlock.FormattingEnabled = true;
		cbbLanguageSauKhiUnlock.Items.AddRange(new object[112]
		{
			"so_SO|Tiếng Somali", "af_ZA|Tiếng Afrikaans", "az_AZ|Tiếng Azerbaijan", "id_ID|Tiếng Indo", "ms_MY|Tiếng Mã Lai", "jv_ID|Tiếng Java", "cx_PH|Tiếng Cebuano", "bs_BA|Tiếng Bosnia", "br_FR|Tiếng Breton", "ca_ES|Tiếng Ca-ta-lăng",
			"co_FR|Tiếng Corse", "cy_GB|Tiếng Wales", "da_DK|Tiếng Đan Mạch", "de_DE|Tiếng Đức", "et_EE|Tiếng Estonia", "en_GB|Tiếng Anh (Anh)", "en_US|Tiếng Anh (Mỹ)", "es_LA|Tiếng Tây Ban Nha", "es_ES|Tiếng Tây Ban Nha (Tây Ban Nha)", "eo_EO|Tiếng Esperanto",
			"eu_ES|Tiếng Basque", "tl_PH|Tiếng Philippines", "fr_CA|Tiếng Pháp (Canada)", "fr_FR|Tiếng Pháp (Pháp)", "fy_NL|Tiếng Frisia", "ff_NG|Tiếng Fula", "fo_FO|Tiếng Faroe", "ga_IE|Tiếng Ai-len", "gl_ES|Tiếng Galic", "gn_PY|Tiếng Guarani",
			"ha_NG|Tiếng Hausa", "hr_HR|Tiếng Croatia", "rw_RW|Tiếng Kinyarwanda", "iu_CA|Tiếng Inuktitut", "it_IT|Tiếng Ý", "ik_US|Tiếng Inupiaq", "sw_KE|Tiếng Swahili", "ht_HT|Tiếng Haitian Creole", "ku_TR|Tiếng Kurdish (Kurmanji)", "lv_LV|Tiếng Latvia",
			"lt_LT|Tiếng Lithuania", "hu_HU|Tiếng Hungary", "mg_MG|Tiếng Malagasy", "mt_MT|Tiếng Malta", "nl_NL|Tiếng Hà Lan", "nb_NO|Tiếng Na Uy (bokmal)", "nn_NO|Tiếng Na-uy (nynorsk)", "uz_UZ|Tiếng Uzbek", "pl_PL|Tiếng Ba Lan", "pt_BR|Tiếng Bồ Đào Nha (Brazil)",
			"pt_PT|Tiếng Bồ Đào Nha (Bồ Đào Nha)", "ro_RO|Tiếng Rumani", "sc_IT|Tiếng Sardinia", "sn_ZW|Tiếng Shona", "sq_AL|Tiếng Albani", "sk_SK|Tiếng Slovakia", "sl_SI|Tiếng Sloven", "fi_FI|Tiếng Phần Lan", "sv_SE|Tiếng Thụy Điển", "vi_VN|Tiếng Việt",
			"tr_TR|Tiếng Thổ Nhĩ Kỳ", "nl_BE|Tiếng Hà Lan-Bỉ", "zz_TR|Tiếng Zaza", "is_IS|Tiếng Iceland", "cs_CZ|Tiếng Séc", "sz_PL|Tiếng Silesia", "el_GR|Tiếng Hy Lạp", "be_BY|Tiếng Belarus", "bg_BG|Tiếng Bungari", "mk_MK|Tiếng Macedoni",
			"mn_MN|Tiếng Mông Cổ", "ru_RU|Tiếng Nga", "sr_RS|Tiếng Serbia", "tt_RU|Tiê\u0301ng Tatar", "tg_TJ|Tiếng Tajik", "uk_UA|Tiếng U-krai-na", "ky_KG|Tiếng Kyrgyz", "kk_KZ|Tiếng Kazakh", "hy_AM|Tiếng Armenia", "he_IL|Tiếng Do Thái",
			"ur_PK|Tiếng Urdu", "ar_AR|Tiếng Ả Rập", "fa_IR|Tiếng Ba Tư", "ps_AF|Tiếng Pashto", "cb_IQ|Tiếng Kurd Sorani", "sy_SY|Tiếng Syria", "ne_NP|Tiếng Nepan", "mr_IN|Tiếng Marathi", "hi_IN|Tiếng Hin-di (Ấn Độ)", "as_IN|Tiếng Assam",
			"bn_IN|Tiếng Bengali", "pa_IN|Tiếng Punjabi", "gu_IN|Tiếng Gujarati", "or_IN|Tiếng Oriya", "ta_IN|Tiếng Tamil", "te_IN|Tiếng Telugu", "kn_IN|Tiếng Kannada", "ml_IN|Tiếng Malayalam", "si_LK|Tiếng Sinhala", "th_TH|Tiếng Thái",
			"lo_LA|Tiếng Lào", "my_MM|Tiếng Miến Điện", "ka_GE|Tiếng Georgia", "am_ET|Tiếng Amhara", "km_KH|Tiếng Khơ-me", "tz_MA|Tiếng Tamazight", "zh_TW|Tiếng Trung phồn thể (Đài Loan)", "zh_CN|Tiếng Trung giản thể (Trung Quốc)", "zh_HK|Tiếng Trung phồn thể (Hồng Kông)", "ja_JP|Tiếng Nhật",
			"ja_KS|Tiếng Nhật (Kansai)", "ko_KR|Tiếng Hàn"
		});
		cbbLanguageSauKhiUnlock.Location = new System.Drawing.Point(197, 400);
		cbbLanguageSauKhiUnlock.Name = "cbbLanguageSauKhiUnlock";
		cbbLanguageSauKhiUnlock.Size = new System.Drawing.Size(205, 24);
		cbbLanguageSauKhiUnlock.TabIndex = 196;
		plPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plPhone.Controls.Add(txtLanguage);
		plPhone.Controls.Add(BD19A19E);
		plPhone.Controls.Add(AF1D3A06);
		plPhone.Controls.Add(F930CAB4);
		plPhone.Controls.Add(plServiceId);
		plPhone.Controls.Add(nudLimitTimeGetPhone);
		plPhone.Controls.Add(nudLimitCountGetPhone);
		plPhone.Controls.Add(FFAFAE37);
		plPhone.Controls.Add(label5);
		plPhone.Controls.Add(label3);
		plPhone.Controls.Add(F1A13AA8);
		plPhone.Controls.Add(label2);
		plPhone.Controls.Add(ckbLanguage);
		plPhone.Controls.Add(cbbTypePhone);
		plPhone.Location = new System.Drawing.Point(35, 45);
		plPhone.Name = "plPhone";
		plPhone.Size = new System.Drawing.Size(367, 150);
		plPhone.TabIndex = 38;
		txtLanguage.Location = new System.Drawing.Point(223, 62);
		txtLanguage.Name = "txtLanguage";
		txtLanguage.Size = new System.Drawing.Size(118, 23);
		txtLanguage.TabIndex = 45;
		txtLanguage.Text = "en_US,th_TH,my_MM";
		BD19A19E.Location = new System.Drawing.Point(161, 5);
		BD19A19E.Name = "txtApiPhone";
		BD19A19E.Size = new System.Drawing.Size(199, 23);
		BD19A19E.TabIndex = 34;
		AF1D3A06.Cursor = System.Windows.Forms.Cursors.Hand;
		AF1D3A06.Location = new System.Drawing.Point(319, 4);
		AF1D3A06.Name = "button3";
		AF1D3A06.Size = new System.Drawing.Size(42, 25);
		AF1D3A06.TabIndex = 197;
		AF1D3A06.Text = "Test";
		AF1D3A06.UseVisualStyleBackColor = true;
		AF1D3A06.Click += new System.EventHandler(AF1D3A06_Click);
		F930CAB4.AutoSize = true;
		F930CAB4.Cursor = System.Windows.Forms.Cursors.Hand;
		F930CAB4.Location = new System.Drawing.Point(347, 65);
		F930CAB4.Name = "linkLabel1";
		F930CAB4.Size = new System.Drawing.Size(13, 16);
		F930CAB4.TabIndex = 195;
		F930CAB4.TabStop = true;
		F930CAB4.Text = "?";
		F930CAB4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(D8BD7D92);
		plServiceId.Controls.Add(txtServiceId);
		plServiceId.Controls.Add(B99C6B88);
		plServiceId.Location = new System.Drawing.Point(148, 32);
		plServiceId.Name = "plServiceId";
		plServiceId.Size = new System.Drawing.Size(213, 25);
		plServiceId.TabIndex = 194;
		txtServiceId.Location = new System.Drawing.Point(75, 1);
		txtServiceId.Name = "txtServiceId";
		txtServiceId.Size = new System.Drawing.Size(137, 23);
		txtServiceId.TabIndex = 45;
		B99C6B88.AutoSize = true;
		B99C6B88.Location = new System.Drawing.Point(8, 4);
		B99C6B88.Name = "label1";
		B99C6B88.Size = new System.Drawing.Size(69, 16);
		B99C6B88.TabIndex = 44;
		B99C6B88.Text = "service_id:";
		nudLimitTimeGetPhone.Location = new System.Drawing.Point(223, 120);
		nudLimitTimeGetPhone.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudLimitTimeGetPhone.Name = "nudLimitTimeGetPhone";
		nudLimitTimeGetPhone.Size = new System.Drawing.Size(137, 23);
		nudLimitTimeGetPhone.TabIndex = 38;
		nudLimitCountGetPhone.Location = new System.Drawing.Point(223, 91);
		nudLimitCountGetPhone.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudLimitCountGetPhone.Name = "nudLimitCountGetPhone";
		nudLimitCountGetPhone.Size = new System.Drawing.Size(137, 23);
		nudLimitCountGetPhone.TabIndex = 38;
		FFAFAE37.Location = new System.Drawing.Point(60, 34);
		FFAFAE37.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FFAFAE37.Name = "nudTime";
		FFAFAE37.Size = new System.Drawing.Size(54, 23);
		FFAFAE37.TabIndex = 38;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(0, 122);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(172, 16);
		label5.TabIndex = 37;
		label5.Text = "Giới hạn thời gian lấy sđt (s):";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(114, 36);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(30, 16);
		label3.TabIndex = 37;
		label3.Text = "giây";
		F1A13AA8.AutoSize = true;
		F1A13AA8.Location = new System.Drawing.Point(0, 93);
		F1A13AA8.Name = "label4";
		F1A13AA8.Size = new System.Drawing.Size(137, 16);
		F1A13AA8.TabIndex = 37;
		F1A13AA8.Text = "Giới hạn số lần lấy sđt:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(0, 36);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(56, 16);
		label2.TabIndex = 37;
		label2.Text = "Chờ otp:";
		ckbLanguage.AutoSize = true;
		ckbLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLanguage.Location = new System.Drawing.Point(4, 64);
		ckbLanguage.Name = "ckbLanguage";
		ckbLanguage.Size = new System.Drawing.Size(205, 20);
		ckbLanguage.TabIndex = 34;
		ckbLanguage.Text = "Đổi ngôn ngữ trước khi lấy Sđt:";
		ckbLanguage.UseVisualStyleBackColor = true;
		ckbLanguage.CheckedChanged += new System.EventHandler(DE997814);
		cbbTypePhone.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypePhone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypePhone.DropDownWidth = 350;
		cbbTypePhone.FormattingEnabled = true;
		cbbTypePhone.Location = new System.Drawing.Point(4, 4);
		cbbTypePhone.Name = "cbbTypePhone";
		cbbTypePhone.Size = new System.Drawing.Size(151, 24);
		cbbTypePhone.TabIndex = 193;
		cbbTypePhone.SelectedIndexChanged += new System.EventHandler(cbbTypePhone_SelectedIndexChanged);
		C0856CB8.AutoSize = true;
		C0856CB8.Cursor = System.Windows.Forms.Cursors.Hand;
		C0856CB8.Location = new System.Drawing.Point(276, 22);
		C0856CB8.Name = "ckbSwitch282To956";
		C0856CB8.Size = new System.Drawing.Size(119, 20);
		C0856CB8.TabIndex = 34;
		C0856CB8.Text = "Đa\u0301 956 (nê\u0301u co\u0301)";
		C0856CB8.UseVisualStyleBackColor = true;
		ckbPhone.AutoSize = true;
		ckbPhone.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPhone.Location = new System.Drawing.Point(14, 22);
		ckbPhone.Name = "ckbPhone";
		ckbPhone.Size = new System.Drawing.Size(88, 20);
		ckbPhone.TabIndex = 34;
		ckbPhone.Text = "Thêm SĐT";
		ckbPhone.UseVisualStyleBackColor = true;
		ckbPhone.CheckedChanged += new System.EventHandler(ckbPhone_CheckedChanged);
		ckbAddMail.AutoSize = true;
		ckbAddMail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAddMail.Location = new System.Drawing.Point(14, 199);
		ckbAddMail.Name = "ckbAddMail";
		ckbAddMail.Size = new System.Drawing.Size(76, 20);
		ckbAddMail.TabIndex = 36;
		ckbAddMail.Text = "Add mail";
		ckbAddMail.UseVisualStyleBackColor = true;
		ckbAddMail.CheckedChanged += new System.EventHandler(B4869904);
		ckbImage.AutoSize = true;
		ckbImage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbImage.Location = new System.Drawing.Point(14, 260);
		ckbImage.Name = "ckbImage";
		ckbImage.Size = new System.Drawing.Size(66, 20);
		ckbImage.TabIndex = 36;
		ckbImage.Text = "Up ảnh";
		ckbImage.UseVisualStyleBackColor = true;
		ckbImage.CheckedChanged += new System.EventHandler(D13FCD39);
		plMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plMail.Controls.Add(FD1457AE);
		plMail.Controls.Add(cbbTypeMail);
		plMail.Controls.Add(label7);
		plMail.Location = new System.Drawing.Point(35, 221);
		plMail.Name = "plMail";
		plMail.Size = new System.Drawing.Size(367, 34);
		plMail.TabIndex = 49;
		FD1457AE.Cursor = System.Windows.Forms.Cursors.Hand;
		FD1457AE.Location = new System.Drawing.Point(274, 3);
		FD1457AE.Name = "btnNhapMail";
		FD1457AE.Size = new System.Drawing.Size(86, 26);
		FD1457AE.TabIndex = 122;
		FD1457AE.Text = "Nhập (0)";
		FD1457AE.UseVisualStyleBackColor = true;
		FD1457AE.Click += new System.EventHandler(D12BE8B6);
		cbbTypeMail.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeMail.DropDownWidth = 200;
		cbbTypeMail.FormattingEnabled = true;
		cbbTypeMail.Items.AddRange(new object[3] { "Hotmail", "Mail domain", "https://generator.email/" });
		cbbTypeMail.Location = new System.Drawing.Point(74, 4);
		cbbTypeMail.Name = "cbbTypeMail";
		cbbTypeMail.Size = new System.Drawing.Size(194, 24);
		cbbTypeMail.TabIndex = 121;
		cbbTypeMail.SelectedIndexChanged += new System.EventHandler(cbbTypeMail_SelectedIndexChanged);
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(4, 7);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(63, 16);
		label7.TabIndex = 119;
		label7.Text = "Loại mail:";
		plImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plImage.Controls.Add(A398DCA7);
		plImage.Controls.Add(BE949F25);
		plImage.Controls.Add(rbFolder);
		plImage.Controls.Add(BF925007);
		plImage.Controls.Add(ckbQuayVideo);
		plImage.Controls.Add(C1A8C1B6);
		plImage.Controls.Add(F0830193);
		plImage.Controls.Add(F7A5560E);
		plImage.Location = new System.Drawing.Point(35, 282);
		plImage.Name = "plImage";
		plImage.Size = new System.Drawing.Size(367, 112);
		plImage.TabIndex = 49;
		A398DCA7.Cursor = System.Windows.Forms.Cursors.Hand;
		A398DCA7.DropDownWidth = 250;
		A398DCA7.FormattingEnabled = true;
		A398DCA7.Items.AddRange(new object[4] { "https://thispersondoesnotexist.com", "https://this-person-does-not-exist.com", "https://www.unrealperson.com", "https://boredhumans.com" });
		A398DCA7.Location = new System.Drawing.Point(161, 33);
		A398DCA7.Name = "cbbImageUrl";
		A398DCA7.Size = new System.Drawing.Size(200, 24);
		A398DCA7.TabIndex = 200;
		BE949F25.AutoSize = true;
		BE949F25.Cursor = System.Windows.Forms.Cursors.Hand;
		BE949F25.Location = new System.Drawing.Point(7, 34);
		BE949F25.Name = "rbWeb";
		BE949F25.Size = new System.Drawing.Size(88, 20);
		BE949F25.TabIndex = 38;
		BE949F25.Text = "Lấy từ web";
		BE949F25.UseVisualStyleBackColor = true;
		BE949F25.CheckedChanged += new System.EventHandler(BE949F25_CheckedChanged);
		rbFolder.AutoSize = true;
		rbFolder.Checked = true;
		rbFolder.Cursor = System.Windows.Forms.Cursors.Hand;
		rbFolder.Location = new System.Drawing.Point(7, 5);
		rbFolder.Name = "rbFolder";
		rbFolder.Size = new System.Drawing.Size(144, 20);
		rbFolder.TabIndex = 38;
		rbFolder.TabStop = true;
		rbFolder.Text = "Đường dẫn thư mục:";
		rbFolder.UseVisualStyleBackColor = true;
		rbFolder.CheckedChanged += new System.EventHandler(rbFolder_CheckedChanged);
		BF925007.Location = new System.Drawing.Point(161, 4);
		BF925007.Name = "txtImage";
		BF925007.Size = new System.Drawing.Size(200, 23);
		BF925007.TabIndex = 37;
		ckbQuayVideo.AutoSize = true;
		ckbQuayVideo.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbQuayVideo.Location = new System.Drawing.Point(278, 86);
		ckbQuayVideo.Name = "ckbQuayVideo";
		ckbQuayVideo.Size = new System.Drawing.Size(89, 20);
		ckbQuayVideo.TabIndex = 34;
		ckbQuayVideo.Text = "Quay video";
		ckbQuayVideo.UseVisualStyleBackColor = true;
		ckbQuayVideo.CheckedChanged += new System.EventHandler(EBA87BBC);
		C1A8C1B6.AutoSize = true;
		C1A8C1B6.Cursor = System.Windows.Forms.Cursors.Hand;
		C1A8C1B6.Location = new System.Drawing.Point(7, 86);
		C1A8C1B6.Name = "ckbUseFreeFb";
		C1A8C1B6.Size = new System.Drawing.Size(208, 20);
		C1A8C1B6.TabIndex = 34;
		C1A8C1B6.Text = "Up a\u0309nh bă\u0300ng free.facebook.com";
		C1A8C1B6.UseVisualStyleBackColor = true;
		C1A8C1B6.CheckedChanged += new System.EventHandler(F33B90B8);
		F0830193.AutoSize = true;
		F0830193.Cursor = System.Windows.Forms.Cursors.Hand;
		F0830193.Location = new System.Drawing.Point(7, 60);
		F0830193.Name = "ckbChangeMD5";
		F0830193.Size = new System.Drawing.Size(138, 20);
		F0830193.TabIndex = 34;
		F0830193.Text = "Change MD5 Image";
		F0830193.UseVisualStyleBackColor = true;
		F7A5560E.AutoSize = true;
		F7A5560E.Cursor = System.Windows.Forms.Cursors.Hand;
		F7A5560E.Location = new System.Drawing.Point(161, 60);
		F7A5560E.Name = "ckbBackupAnh";
		F7A5560E.Size = new System.Drawing.Size(176, 20);
		F7A5560E.TabIndex = 34;
		F7A5560E.Text = "Ưu tiên gửi ảnh đã backup";
		F7A5560E.UseVisualStyleBackColor = true;
		D0085A2A.AutoSize = true;
		D0085A2A.Cursor = System.Windows.Forms.Cursors.Hand;
		D0085A2A.Location = new System.Drawing.Point(14, 402);
		D0085A2A.Name = "ckbDoiNgonNguSauKhiUnlock";
		D0085A2A.Size = new System.Drawing.Size(187, 20);
		D0085A2A.TabIndex = 34;
		D0085A2A.Text = "Đổi ngôn ngữ sau khi unlock";
		D0085A2A.UseVisualStyleBackColor = true;
		D0085A2A.CheckedChanged += new System.EventHandler(D0085A2A_CheckedChanged);
		D69D8324.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D69D8324.Controls.Add(cbbCaptcha);
		D69D8324.Controls.Add(F0958426);
		D69D8324.Controls.Add(D02FF312);
		D69D8324.Controls.Add(ckbSkipRecaptcha);
		D69D8324.Controls.Add(BA9D3D0B);
		D69D8324.Controls.Add(C5B8CEA1);
		D69D8324.Controls.Add(button4);
		D69D8324.Location = new System.Drawing.Point(45, 163);
		D69D8324.Name = "plCaptcha";
		D69D8324.Size = new System.Drawing.Size(367, 64);
		D69D8324.TabIndex = 48;
		cbbCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbCaptcha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbCaptcha.DropDownWidth = 200;
		cbbCaptcha.FormattingEnabled = true;
		cbbCaptcha.Location = new System.Drawing.Point(6, 33);
		cbbCaptcha.Name = "cbbCaptcha";
		cbbCaptcha.Size = new System.Drawing.Size(148, 24);
		cbbCaptcha.TabIndex = 193;
		cbbCaptcha.SelectedIndexChanged += new System.EventHandler(cbbCaptcha_SelectedIndexChanged);
		F0958426.Location = new System.Drawing.Point(160, 5);
		F0958426.Name = "txtCaptcha_4";
		F0958426.Size = new System.Drawing.Size(147, 23);
		F0958426.TabIndex = 34;
		D02FF312.Location = new System.Drawing.Point(160, 34);
		D02FF312.Name = "txtCaptcha";
		D02FF312.Size = new System.Drawing.Size(147, 23);
		D02FF312.TabIndex = 34;
		ckbSkipRecaptcha.AutoSize = true;
		ckbSkipRecaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSkipRecaptcha.Location = new System.Drawing.Point(6, 64);
		ckbSkipRecaptcha.Name = "ckbSkipRecaptcha";
		ckbSkipRecaptcha.Size = new System.Drawing.Size(170, 20);
		ckbSkipRecaptcha.TabIndex = 32;
		ckbSkipRecaptcha.Text = "Bo\u0309 qua khi gă\u0323p recaptcha";
		ckbSkipRecaptcha.UseVisualStyleBackColor = true;
		ckbSkipRecaptcha.CheckedChanged += new System.EventHandler(ckbCaptcha_CheckedChanged);
		BA9D3D0B.AutoSize = true;
		BA9D3D0B.Location = new System.Drawing.Point(3, 7);
		BA9D3D0B.Name = "label6";
		BA9D3D0B.Size = new System.Drawing.Size(130, 16);
		BA9D3D0B.TabIndex = 0;
		BA9D3D0B.Text = "API Key Omocaptcha:";
		C5B8CEA1.Cursor = System.Windows.Forms.Cursors.Hand;
		C5B8CEA1.Location = new System.Drawing.Point(312, 4);
		C5B8CEA1.Name = "button5";
		C5B8CEA1.Size = new System.Drawing.Size(49, 25);
		C5B8CEA1.TabIndex = 122;
		C5B8CEA1.Text = "Check";
		C5B8CEA1.UseVisualStyleBackColor = true;
		C5B8CEA1.Click += new System.EventHandler(A9AD0C30);
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.Location = new System.Drawing.Point(312, 33);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(49, 25);
		button4.TabIndex = 122;
		button4.Text = "Check";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(button4_Click);
		ckbDeleteContact.AutoSize = true;
		ckbDeleteContact.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDeleteContact.Location = new System.Drawing.Point(24, 233);
		ckbDeleteContact.Name = "ckbDeleteContact";
		ckbDeleteContact.Size = new System.Drawing.Size(261, 20);
		ckbDeleteContact.TabIndex = 32;
		ckbDeleteContact.Text = "Xo\u0301a thông tin liên hê\u0323 kha\u0301c email trên tool";
		ckbDeleteContact.UseVisualStyleBackColor = true;
		ckbDeleteContact.CheckedChanged += new System.EventHandler(ckbCaptcha_CheckedChanged);
		ckbCaptcha.AutoSize = true;
		ckbCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCaptcha.Location = new System.Drawing.Point(24, 137);
		ckbCaptcha.Name = "ckbCaptcha";
		ckbCaptcha.Size = new System.Drawing.Size(95, 20);
		ckbCaptcha.TabIndex = 32;
		ckbCaptcha.Text = "Giải captcha";
		ckbCaptcha.UseVisualStyleBackColor = true;
		ckbCaptcha.CheckedChanged += new System.EventHandler(ckbCaptcha_CheckedChanged);
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(435, 505);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(B6B8C989);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(328, 505);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(873, 37);
		bunifuCards1.TabIndex = 28;
		ckbXoaMailCu.AutoSize = true;
		ckbXoaMailCu.Font = new System.Drawing.Font("Tahoma", 8.75f);
		ckbXoaMailCu.Location = new System.Drawing.Point(441, 431);
		ckbXoaMailCu.Name = "ckbXoaMailCu";
		ckbXoaMailCu.Size = new System.Drawing.Size(167, 18);
		ckbXoaMailCu.TabIndex = 199;
		ckbXoaMailCu.Text = "Xóa email cũ (Nếu Fb hỏi)";
		ckbXoaMailCu.UseVisualStyleBackColor = true;
		ckbXoaMailCu.Visible = false;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(876, 550);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fCauHinhCheckpoint";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fCauHinhCheckpoint_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AC961EA9).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		A199EB2A.ResumeLayout(false);
		A199EB2A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountLink956).EndInit();
		plNhapSdt.ResumeLayout(false);
		plNhapSdt.PerformLayout();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		F7906D17.ResumeLayout(false);
		F7906D17.PerformLayout();
		plPhone.ResumeLayout(false);
		plPhone.PerformLayout();
		plServiceId.ResumeLayout(false);
		plServiceId.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLimitTimeGetPhone).EndInit();
		((System.ComponentModel.ISupportInitialize)nudLimitCountGetPhone).EndInit();
		((System.ComponentModel.ISupportInitialize)FFAFAE37).EndInit();
		plMail.ResumeLayout(false);
		plMail.PerformLayout();
		plImage.ResumeLayout(false);
		plImage.PerformLayout();
		D69D8324.ResumeLayout(false);
		D69D8324.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
