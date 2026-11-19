using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fUpdateData : Form
{
	internal fMain AF1DE10F;

	internal IContainer D93E9231 = null;

	internal BunifuCards D191ACB8;

	internal Panel pnlHeader;

	internal BunifuCustomLabel B21D9B21;

	internal Button btnMinimize;

	internal ComboBox cbbTypeUpdate;

	internal Label CB3BA380;

	internal TextBox A0B8C494;

	internal Label D2876886;

	internal Button E520C80B;

	internal Button AABACEAB;

	internal PictureBox pictureBox1;

	internal Label label3;

	internal ComboBox ABA6043E;

	internal ComboBox FDB74BA2;

	internal CheckBox F3A72A0C;

	public fUpdateData(fMain fMain_0, string string_0)
	{
		InitializeComponent();
		AF1DE10F = fMain_0;
		cbbTypeUpdate.Text = string_0;
		cbbTypeUpdate_SelectedIndexChanged(null, null);
		ABA6043E.SelectedIndex = 0;
		Language.CD21F0A9(this);
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E520C80B_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AABACEAB_Click(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			if (cbbTypeUpdate.Text != "Tình trạng" && cbbTypeUpdate.Text != "Fb Block" && (A0B8C494.Text.Equals("") || A0B8C494.Text.Equals(" |")))
			{
				if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n xo\u0301a dư\u0303 liê\u0323u của {0} tài khoản?"), AF1DE10F.method_128())) == DialogResult.Yes)
				{
					flag = true;
				}
			}
			else if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n câ\u0323p nhâ\u0323t dư\u0303 liê\u0323u của {0} tài khoản?"), AF1DE10F.method_128())) == DialogResult.Yes)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			List<string> list = new List<string>();
			string text = A0B8C494.Text;
			for (int i = 0; i < AF1DE10F.F5325785.Rows.Count; i++)
			{
				if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[i].Cells["cChose"].Value))
				{
					list.Add(AF1DE10F.F6061E95(i, "cId"));
				}
			}
			string text2 = cbbTypeUpdate.Text;
			string text3 = text2;
			if (text3 == "UID" || text3 == "Uid")
			{
				string[] rawLines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
				List<string> uids = new List<string>();
				foreach (string l in rawLines)
				{
					string trimmed = l.Trim();
					if (!string.IsNullOrEmpty(trimmed)) uids.Add(trimmed);
				}

				if (uids.Count > 1)
				{
					int uIdx = 0;
					for (int i = 0; i < AF1DE10F.F5325785.Rows.Count; i++)
					{
						if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[i].Cells["cChose"].Value))
						{
							if (uIdx < uids.Count)
							{
								string rowId = AF1DE10F.F6061E95(i, "cId");
								string newUid = uids[uIdx];
								CommonSQL.smethod_10(new List<string> { rowId }, "uid", newUid);
								AF1DE10F.B183E907(i, "cUid", newUid);
								uIdx++;
							}
						}
					}
				}
				else if (CommonSQL.smethod_10(list, "uid", text))
				{
					for (int numUID = 0; numUID < AF1DE10F.F5325785.Rows.Count; numUID++)
					{
						if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[numUID].Cells["cChose"].Value))
						{
							AF1DE10F.B183E907(numUID, "cUid", text);
						}
					}
				}
			}
			switch (AFAE75A0.smethod_0(text3))
			{
			case 267393898u:
			{
				if (!(text3 == "Notes") || !CommonSQL.smethod_10(list, "ghiChu", text))
				{
					break;
				}
				for (int l = 0; l < AF1DE10F.F5325785.Rows.Count; l++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[l].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(l, "cGhiChu", text);
					}
				}
				break;
			}
			case 96026087u:
			{
				if (!(text3 == "Mail|pass"))
				{
					break;
				}
				if (text.Split('|').Length != 2)
				{
					MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p la\u0323i đi\u0323nh da\u0323ng Mail|Pass Mail!", 3);
					return;
				}
				if (!CommonSQL.E1BF11BA(list, "email|passmail", text))
				{
					break;
				}
				for (int num11 = 0; num11 < AF1DE10F.F5325785.Rows.Count; num11++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num11].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num11, "cEmail", text.Split('|')[0]);
						AF1DE10F.B183E907(num11, "cPassMail", text.Split('|')[1]);
					}
				}
				break;
			}
			case 976575442u:
			{
				if (!(text3 == "Token") || !CommonSQL.smethod_10(list, "token", text))
				{
					break;
				}
				for (int num10 = 0; num10 < AF1DE10F.F5325785.Rows.Count; num10++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num10].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num10, "cToken", text);
					}
				}
				break;
			}
			case 750979128u:
			{
				if (!(text3 == "Password") || !CommonSQL.smethod_10(list, "pass", text))
				{
					break;
				}
				for (int num6 = 0; num6 < AF1DE10F.F5325785.Rows.Count; num6++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num6].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num6, "cPassword", text);
					}
				}
				break;
			}
			case 1335761915u:
			{
				if (!(text3 == "Proxy"))
				{
					break;
				}
				int selectedIndex = ABA6043E.SelectedIndex;
				string text5 = ((text == "") ? "" : (text + "*" + selectedIndex));
				if (!CommonSQL.smethod_10(list, "proxy", text5))
				{
					break;
				}
				for (int num13 = 0; num13 < AF1DE10F.F5325785.Rows.Count; num13++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num13].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num13, "cProxy", text5);
					}
				}
				break;
			}
			case 1227920463u:
			{
				if (!(text3 == "Phone") || !CommonSQL.E1BF11BA(list, "phone", text))
				{
					break;
				}
				for (int num2 = 0; num2 < AF1DE10F.F5325785.Rows.Count; num2++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num2].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num2, "cPhone", text.Split('|')[0]);
					}
				}
				break;
			}
			case 1802569846u:
			{
				if (!(text3 == "Mail khôi phục") || !CommonSQL.E1BF11BA(list, "mailrecovery", text))
				{
					break;
				}
				for (int num7 = 0; num7 < AF1DE10F.F5325785.Rows.Count; num7++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num7].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num7, "cMailRecovery", text.Split('|')[0]);
					}
				}
				break;
			}
			case 1687876407u:
			{
				if (!(text3 == "Status 282") || !CommonSQL.E1BF11BA(list, "status282", text))
				{
					break;
				}
				for (int num = 0; num < AF1DE10F.F5325785.Rows.Count; num++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num, "cStatus282", text);
					}
				}
				break;
			}
			case 1669390511u:
			{
				if (!(text3 == "PassMail") || !CommonSQL.E1BF11BA(list, "PassMail", text))
				{
					break;
				}
				for (int num9 = 0; num9 < AF1DE10F.F5325785.Rows.Count; num9++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num9].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num9, "cPassMail", text);
					}
				}
				break;
			}
			case 2249983736u:
			{
				if (!(text3 == "2FA") || !CommonSQL.smethod_10(list, "fa2", text))
				{
					break;
				}
				for (int num3 = 0; num3 < AF1DE10F.F5325785.Rows.Count; num3++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num3].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num3, "cFa2", text);
					}
				}
				break;
			}
			case 2152741479u:
			{
				if (!(text3 == "Pass mail khôi phục") || !CommonSQL.E1BF11BA(list, "passmailrecovery", text))
				{
					break;
				}
				for (int k = 0; k < AF1DE10F.F5325785.Rows.Count; k++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[k].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(k, "cPassMailRecovery", text.Split('|')[0]);
					}
				}
				break;
			}
			case 2776932076u:
			{
				if (!(text3 == "Fb Block"))
				{
					break;
				}
				text = (F3A72A0C.Checked ? "Yes" : "");
				if (!CommonSQL.E1BF11BA(list, "fbBlock", text))
				{
					break;
				}
				for (int num5 = 0; num5 < AF1DE10F.F5325785.Rows.Count; num5++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num5].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num5, "cFbBlock", text);
					}
				}
				break;
			}
			case 2422763473u:
			{
				if (!(text3 == "Tình trạng"))
				{
					break;
				}
				string text4 = FDB74BA2.Text;
				if (!CommonSQL.smethod_10(list, "info", text4))
				{
					break;
				}
				for (int m = 0; m < AF1DE10F.F5325785.Rows.Count; m++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[m].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(m, "cInfo", text4);
					}
				}
				break;
			}
			case 3183131359u:
			{
				if (!(text3 == "Cookie") || !CommonSQL.smethod_10(list, "cookie1", text))
				{
					break;
				}
				for (int num12 = 0; num12 < AF1DE10F.F5325785.Rows.Count; num12++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num12].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num12, "cCookies", text);
					}
				}
				break;
			}
			case 3083160018u:
			{
				if (!(text3 == "OAuth2") || !CommonSQL.E1BF11BA(list, "backup", text))
				{
					break;
				}
				for (int num8 = 0; num8 < AF1DE10F.F5325785.Rows.Count; num8++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num8].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num8, "cOAuth2", text.Split('|')[0]);
					}
				}
				break;
			}
			case 4192210162u:
			{
				if (!(text3 == "Email|Mail khôi phục") || !CommonSQL.E1BF11BA(list, "email|mailrecovery", text))
				{
					break;
				}
				for (int num4 = 0; num4 < AF1DE10F.F5325785.Rows.Count; num4++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[num4].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(num4, "cEmail", text.Split('|')[0]);
						AF1DE10F.B183E907(num4, "cMailRecovery", text.Split('|')[1]);
					}
				}
				break;
			}
			case 3646757383u:
			{
				if (!(text3 == "Useragent") || !CommonSQL.smethod_10(list, "useragent", text))
				{
					break;
				}
				for (int n = 0; n < AF1DE10F.F5325785.Rows.Count; n++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[n].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(n, "cUseragent", text);
					}
				}
				break;
			}
			case 3243292492u:
			{
				if (!(text3 == "Birthday") || !CommonSQL.smethod_10(list, "birthday", text))
				{
					break;
				}
				for (int j = 0; j < AF1DE10F.F5325785.Rows.Count; j++)
				{
					if (Convert.ToBoolean(AF1DE10F.F5325785.Rows[j].Cells["cChose"].Value))
					{
						AF1DE10F.B183E907(j, "cBirthday", text);
					}
				}
				break;
			}
			}
			Close();
		}
		catch
		{
			MsBoxHelper.Show("Vui lòng thử lại sau!", 2);
		}
	}

	private void cbbTypeUpdate_SelectedIndexChanged(object sender, EventArgs e)
	{
		label3.Visible = cbbTypeUpdate.Text == "Proxy";
		ABA6043E.Visible = cbbTypeUpdate.Text == "Proxy";
		FDB74BA2.Visible = cbbTypeUpdate.Text == "Tình trạng";
		FDB74BA2.SelectedIndex = 0;
		F3A72A0C.Visible = cbbTypeUpdate.Text == "Fb Block";
		A0B8C494.Visible = cbbTypeUpdate.Text != "Tình trạng" && cbbTypeUpdate.Text != "Fb Block";

		if (cbbTypeUpdate.Text == "UID")
		{
			A0B8C494.Multiline = true;
			A0B8C494.Height = 50;
			A0B8C494.ScrollBars = ScrollBars.Vertical;
			base.Height = 195;
			AABACEAB.Top = 148;
			E520C80B.Top = 148;
		}
		else
		{
			A0B8C494.Multiline = false;
			A0B8C494.Height = 23;
			A0B8C494.ScrollBars = ScrollBars.None;
			base.Height = 180;
			AABACEAB.Top = 141;
			E520C80B.Top = 141;
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D93E9231 != null)
		{
			D93E9231.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUpdateData));
		D191ACB8 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		B21D9B21 = new Bunifu.Framework.UI.BunifuCustomLabel();
		cbbTypeUpdate = new System.Windows.Forms.ComboBox();
		CB3BA380 = new System.Windows.Forms.Label();
		A0B8C494 = new System.Windows.Forms.TextBox();
		D2876886 = new System.Windows.Forms.Label();
		E520C80B = new System.Windows.Forms.Button();
		AABACEAB = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		ABA6043E = new System.Windows.Forms.ComboBox();
		FDB74BA2 = new System.Windows.Forms.ComboBox();
		F3A72A0C = new System.Windows.Forms.CheckBox();
		D191ACB8.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		D191ACB8.BackColor = System.Drawing.Color.White;
		D191ACB8.BorderRadius = 5;
		D191ACB8.BottomSahddow = true;
		D191ACB8.color = System.Drawing.Color.SaddleBrown;
		D191ACB8.Controls.Add(pnlHeader);
		D191ACB8.Dock = System.Windows.Forms.DockStyle.Top;
		D191ACB8.LeftSahddow = false;
		D191ACB8.Location = new System.Drawing.Point(0, 0);
		D191ACB8.Name = "bunifuCards1";
		D191ACB8.RightSahddow = true;
		D191ACB8.ShadowDepth = 20;
		D191ACB8.Size = new System.Drawing.Size(416, 38);
		D191ACB8.TabIndex = 12;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(B21D9B21);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(416, 32);
		pnlHeader.TabIndex = 9;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(382, -1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 79;
		pictureBox1.TabStop = false;
		B21D9B21.BackColor = System.Drawing.Color.Transparent;
		B21D9B21.Dock = System.Windows.Forms.DockStyle.Fill;
		B21D9B21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B21D9B21.ForeColor = System.Drawing.Color.Black;
		B21D9B21.Location = new System.Drawing.Point(0, 0);
		B21D9B21.Name = "bunifuCustomLabel1";
		B21D9B21.Size = new System.Drawing.Size(416, 32);
		B21D9B21.TabIndex = 12;
		B21D9B21.Text = "Cập nhật dữ liệu";
		B21D9B21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		cbbTypeUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeUpdate.FormattingEnabled = true;
		cbbTypeUpdate.ItemHeight = 16;
		cbbTypeUpdate.Items.AddRange(new object[]
		{
			"UID", "Token", "Cookie", "Password", "Mail|pass", "PassMail", "2FA", "Birthday", "Useragent", "Proxy", "Notes",
			"Email|Mail khôi phục", "Pass mail khôi phục", "Mail khôi phục", "Phone", "Fb Block", "Tình trạng", "Status 282", "OAuth2"
		});
		cbbTypeUpdate.Location = new System.Drawing.Point(146, 45);
		cbbTypeUpdate.Name = "cbbTypeUpdate";
		cbbTypeUpdate.Size = new System.Drawing.Size(238, 24);
		cbbTypeUpdate.TabIndex = 13;
		cbbTypeUpdate.SelectedIndexChanged += new System.EventHandler(cbbTypeUpdate_SelectedIndexChanged);
		CB3BA380.AutoSize = true;
		CB3BA380.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CB3BA380.Location = new System.Drawing.Point(34, 48);
		CB3BA380.Name = "label1";
		CB3BA380.Size = new System.Drawing.Size(105, 16);
		CB3BA380.TabIndex = 14;
		CB3BA380.Text = "Dữ liệu cập nhật:";
		A0B8C494.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A0B8C494.Location = new System.Drawing.Point(146, 75);
		A0B8C494.Name = "txbData";
		A0B8C494.Size = new System.Drawing.Size(238, 23);
		A0B8C494.TabIndex = 15;
		A0B8C494.Visible = false;
		D2876886.AutoSize = true;
		D2876886.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D2876886.Location = new System.Drawing.Point(34, 78);
		D2876886.Name = "label2";
		D2876886.Size = new System.Drawing.Size(84, 16);
		D2876886.TabIndex = 16;
		D2876886.Text = "Nhập dữ liệu:";
		E520C80B.BackColor = System.Drawing.Color.Maroon;
		E520C80B.Cursor = System.Windows.Forms.Cursors.Hand;
		E520C80B.FlatAppearance.BorderSize = 0;
		E520C80B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E520C80B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E520C80B.ForeColor = System.Drawing.Color.White;
		E520C80B.Location = new System.Drawing.Point(209, 141);
		E520C80B.Name = "btnCancel";
		E520C80B.Size = new System.Drawing.Size(92, 29);
		E520C80B.TabIndex = 18;
		E520C80B.Text = "Đóng";
		E520C80B.UseVisualStyleBackColor = false;
		E520C80B.Click += new System.EventHandler(E520C80B_Click);
		AABACEAB.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		AABACEAB.Cursor = System.Windows.Forms.Cursors.Hand;
		AABACEAB.FlatAppearance.BorderSize = 0;
		AABACEAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AABACEAB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AABACEAB.ForeColor = System.Drawing.Color.White;
		AABACEAB.Location = new System.Drawing.Point(111, 141);
		AABACEAB.Name = "btnAdd";
		AABACEAB.Size = new System.Drawing.Size(92, 29);
		AABACEAB.TabIndex = 17;
		AABACEAB.Text = "Lưu";
		AABACEAB.UseVisualStyleBackColor = false;
		AABACEAB.Click += new System.EventHandler(AABACEAB_Click);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(34, 107);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(70, 16);
		label3.TabIndex = 16;
		label3.Text = "Loại proxy:";
		ABA6043E.Cursor = System.Windows.Forms.Cursors.Hand;
		ABA6043E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		ABA6043E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ABA6043E.FormattingEnabled = true;
		ABA6043E.Items.AddRange(new object[2] { "HTTP", "Sock5" });
		ABA6043E.Location = new System.Drawing.Point(146, 104);
		ABA6043E.Name = "cbbTypeProxy";
		ABA6043E.Size = new System.Drawing.Size(130, 24);
		ABA6043E.TabIndex = 124;
		FDB74BA2.Cursor = System.Windows.Forms.Cursors.Hand;
		FDB74BA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FDB74BA2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FDB74BA2.FormattingEnabled = true;
		FDB74BA2.Items.AddRange(new object[4] { "Live", "Die", "Checkpoint", "Changed pass" });
		FDB74BA2.Location = new System.Drawing.Point(146, 75);
		FDB74BA2.Name = "cbbTinhTrang";
		FDB74BA2.Size = new System.Drawing.Size(238, 24);
		FDB74BA2.TabIndex = 127;
		FDB74BA2.Visible = false;
		F3A72A0C.AutoSize = true;
		F3A72A0C.Cursor = System.Windows.Forms.Cursors.Hand;
		F3A72A0C.Location = new System.Drawing.Point(146, 78);
		F3A72A0C.Name = "ckbFbBlock";
		F3A72A0C.Size = new System.Drawing.Size(73, 20);
		F3A72A0C.TabIndex = 128;
		F3A72A0C.Text = "Fb Block";
		F3A72A0C.UseVisualStyleBackColor = true;
		F3A72A0C.Visible = false;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(416, 180);
		base.Controls.Add(F3A72A0C);
		base.Controls.Add(FDB74BA2);
		base.Controls.Add(ABA6043E);
		base.Controls.Add(E520C80B);
		base.Controls.Add(AABACEAB);
		base.Controls.Add(label3);
		base.Controls.Add(D2876886);
		base.Controls.Add(A0B8C494);
		base.Controls.Add(CB3BA380);
		base.Controls.Add(cbbTypeUpdate);
		base.Controls.Add(D191ACB8);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fUpdateData";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fUpdateData";
		D191ACB8.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
