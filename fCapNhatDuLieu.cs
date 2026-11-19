using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;

public class fCapNhatDuLieu : Form
{
	[CompilerGenerated]
	private sealed class D7202F1E
	{
		internal Label AB9BD08B;

		internal void method_0()
		{
			int num = Convert.ToInt32(AB9BD08B.Text);
			AB9BD08B.Text = (num + 1).ToString();
		}
	}

	[CompilerGenerated]
	private sealed class F40C819C
	{
		internal fCapNhatDuLieu FA043CA2;

		internal string string_0;

		internal void method_0()
		{
			FA043CA2.lblStatus.Text = string_0;
		}
	}

	internal static bool bool_0;

	internal List<ComboBox> DE96248A;

	internal JArray jarray_0 = new JArray();

	internal List<string> list_0 = new List<string>();

	internal List<string> B7BDF4AD = new List<string>();

	internal List<string> A13AEE85 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal IContainer EE8FEABA = null;

	internal Button btnAdd;

	internal Button btnCancel;

	internal Label E41BC291;

	internal ComboBox cbbDinhDangNhap;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal RichTextBox F8229C80;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel pnlHeader;

	internal BunifuCards AF831F95;

	internal ContextMenuStrip ctmsAcc;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem F233A48F;

	internal ToolStripMenuItem CDAE7FAF;

	internal ToolStripMenuItem toolStripMenuItem2;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem DC03FC29;

	internal ToolStripMenuItem A8B43107;

	internal Label A9A2D6A9;

	internal Label lblSuccess;

	internal Label B52B3710;

	internal Label BF8647A8;

	internal Label label4;

	internal Label D0A13519;

	internal Label lblStatus;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal PictureBox pictureBox2;

	internal Panel F43B181F;

	internal Label label1;

	internal ComboBox B1319289;

	internal ComboBox cbbDinhDang2;

	internal ComboBox cbbDinhDang3;

	internal ComboBox cbbDinhDang4;

	internal Label label14;

	internal ComboBox cbbDinhDang5;

	internal Label label17;

	internal ComboBox cbbDinhDang8;

	internal Label label13;

	internal ComboBox cbbDinhDang6;

	internal Label label12;

	internal ComboBox cbbDinhDang7;

	internal Label C9A50C33;

	internal Label label9;

	internal Label label10;

	internal ComboBox cbbTypeProxy;

	internal Label D4B221A6;

	internal Label EA01ECBF;

	internal ComboBox cbbDinhDang9;

	internal Label label15;

	internal ComboBox cbbDinhDang11;

	internal Label label6;

	internal ComboBox cbbDinhDang10;

	internal Label D0A82B92;

	internal ComboBox cbbDinhDang12;

	private bool isAutoFormatting = false;

	public fCapNhatDuLieu()
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox2.Image = Class155.DD225F0D;
		DE96248A = new List<ComboBox>
		{
			B1319289, cbbDinhDang2, cbbDinhDang3, cbbDinhDang4, cbbDinhDang5, cbbDinhDang6, cbbDinhDang7, cbbDinhDang8, cbbDinhDang9, cbbDinhDang10,
			cbbDinhDang11, cbbDinhDang12
		};
		bool_0 = false;
		Language.CD21F0A9(this);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F3101AA7(object sender, EventArgs e)
	{
		B7BDF4AD = new List<string>();
		A13AEE85 = new List<string>();
		try
		{
			List<string> list = F8229C80.Lines.ToList();
			list = Commom.smethod_36(list);
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Vui lòng nhâ\u0323p thông tin ta\u0300i khoa\u0309n!");
				F8229C80.Focus();
				return;
			}
			string text = cbbDinhDangNhap.Text;
			if (cbbDinhDangNhap.SelectedIndex != cbbDinhDangNhap.Items.Count - 1)
			{
				goto IL_0129;
			}
			bool flag = false;
			for (int i = 0; i < DE96248A.Count; i++)
			{
				if (DE96248A[i].SelectedIndex > -1)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng ta\u0300i khoa\u0309n!");
				return;
			}
			text = "Uid|";
			for (int j = 0; j < DE96248A.Count; j++)
			{
				text = text + DE96248A[j].Text + "|";
			}
			text = text.TrimEnd('|');
			goto IL_0129;
			IL_0129:
			if (MsBoxHelper.D41C45AC($"Ba\u0323n co\u0301 chă\u0301c muô\u0301n câ\u0323p nhâ\u0323t dư\u0303 liê\u0323u theo đi\u0323nh da\u0323ng [{text}] không?") == DialogResult.No)
			{
				return;
			}
			lblSuccess.Text = "0";
			B52B3710.Text = "0";
			list_0 = new List<string>();
			List<string> list2 = text.Split('|').ToList();
			for (int k = 0; k < list.Count; k++)
			{
				string textLine = AccountFormatDetector.NormalizeLine(list[k]);
				string[] array = textLine.Split('|').Select(s => s.Trim()).ToArray();
				try
				{
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					string text11 = "";
					string text12 = "";
					string text13 = "";
					string text14 = "";
					string text15 = "";
					string text16 = "";
					string text17 = "";
					string text18 = "";
					string text19 = "";
					string text20 = "";
					for (int l = 0; l < list2.Count; l++)
					{
						string text21 = list2[l];
						string text22 = text21;
						uint num = AFAE75A0.smethod_0(text22);
						if (num <= 2152741479u)
						{
							if (num <= 953496446)
							{
								if (num <= 747205759)
								{
									if (num != 339788125)
									{
										if (num != 746320690)
										{
											if (num != 747205759 || !(text22 == "Tương tác cuối"))
											{
												continue;
											}
											goto IL_031e;
										}
										if (!(text22 == "Giơ\u0301i ti\u0301nh"))
										{
											continue;
										}
										goto IL_04bf;
									}
									if (!(text22 == "Note"))
									{
										continue;
									}
								}
								else
								{
									if (num != 776692014)
									{
										if (num != 798471697)
										{
											if (num == 953496446 && text22 == "Client_id")
											{
												text20 = array[l];
											}
											continue;
										}
										if (!(text22 == "Last Interact"))
										{
											continue;
										}
										goto IL_031e;
									}
									if (!(text22 == "Ghi chú"))
									{
										continue;
									}
								}
								text17 = array[l];
								continue;
							}
							if (num <= 1335761915)
							{
								switch (num)
								{
								case 1335761915u:
									if (text22 == "Proxy" && array[l].Trim() != "")
									{
										text10 = array[l] + "*0";
									}
									break;
								case 1127555431u:
									if (text22 == "Email")
									{
										text6 = array[l];
									}
									break;
								case 976575442u:
									if (text22 == "Token")
									{
										text4 = array[l];
									}
									break;
								}
								continue;
							}
							if (num <= 1674345338)
							{
								if (num != 1439766491)
								{
									if (num != 1674345338 || !(text22 == "Friends"))
									{
										continue;
									}
									goto IL_0657;
								}
								if (!(text22 == "Email recover"))
								{
									continue;
								}
							}
							else
							{
								if (num != 1802569846)
								{
									if (num != 2152741479u || !(text22 == "Pass mail khôi phục"))
									{
										continue;
									}
									goto IL_0697;
								}
								if (!(text22 == "Mail khôi phục"))
								{
									continue;
								}
							}
							text15 = array[l];
							continue;
						}
						if (num <= 3243292492u)
						{
							if (num <= 2804681632u)
							{
								if (num == 2249983736u)
								{
									if (text22 == "2FA")
									{
										text8 = array[l];
									}
									continue;
								}
								if (num != 2589850865u)
								{
									if (num != 2804681632u || !(text22 == "Gender"))
									{
										continue;
									}
									goto IL_04bf;
								}
								if (!(text22 == "Ngày sinh"))
								{
									continue;
								}
							}
							else
							{
								if (num <= 3183131359u)
								{
									if (num != 2958674405u)
									{
										if (num == 3183131359u && text22 == "Cookie")
										{
											text5 = array[l];
										}
										continue;
									}
									if (!(text22 == "Ngày tạo"))
									{
										continue;
									}
									goto IL_0605;
								}
								if (num == 3209957741u)
								{
									if (text22 == "Uid")
									{
										text2 = array[l];
									}
									continue;
								}
								if (num != 3243292492u || !(text22 == "Birthday"))
								{
									continue;
								}
							}
							text11 = array[l];
							continue;
						}
						if (num <= 3611366992u)
						{
							if (num != 3444637862u)
							{
								if (num != 3578917853u)
								{
									if (num == 3611366992u && text22 == "Pass Email")
									{
										text7 = array[l].Replace("'", "''");
									}
									continue;
								}
								if (!(text22 == "Date created"))
								{
									continue;
								}
								goto IL_0605;
							}
							if (text22 == "Refresh_token")
							{
								text19 = array[l];
							}
							continue;
						}
						if (num <= 3763899592u)
						{
							if (num != 3646757383u)
							{
								if (num != 3763899592u || !(text22 == "Bạn bè"))
								{
									continue;
								}
								goto IL_0657;
							}
							if (text22 == "Useragent")
							{
								text9 = array[l];
							}
							continue;
						}
						if (num != 3797654840u)
						{
							if (num != 4067830019u || !(text22 == "Pass mail recover"))
							{
								continue;
							}
							goto IL_0697;
						}
						if (text22 == "Pass")
						{
							text3 = array[l].Replace("'", "''");
						}
						continue;
						IL_0605:
						text14 = array[l];
						continue;
						IL_0657:
						text12 = array[l];
						continue;
						IL_04bf:
						text13 = array[l];
						continue;
						IL_0697:
						text16 = array[l];
						continue;
						IL_031e:
						text18 = array[l];
					}
					list_0.Add(text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9 + "|" + text10 + "|" + text11 + "|" + text12 + "|" + text13 + "|" + text14 + "|" + text15 + "|" + text16 + "|" + text17 + "|" + text18 + "|" + text19 + "|" + text20);
					B7BDF4AD.Add(list[k]);
					JObject jObject = CommonSQL.smethod_15(text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9 + "|" + text10 + "|" + text11 + "|" + text12 + "|" + text13 + "|" + text14 + "|" + text15 + "|" + text16 + "|" + text17 + "|" + text18 + "|" + text19 + "|" + text20);
					if (jObject != null)
					{
						jarray_0.Add(jObject);
						continue;
					}
					A182A8AC(B52B3710);
					A13AEE85.Add(list[k]);
				}
				catch
				{
					A182A8AC(B52B3710);
					A13AEE85.Add(list[k]);
				}
			}
			btnAdd.smethod_1(bool_0: false);
			method_0(Language.GetValue("Đang cập nhật dữ liệu..."));
			if (text.StartsWith("Email"))
			{
				if (CommonSQL.smethod_6(jarray_0, "email"))
				{
					lblSuccess.smethod_2(jarray_0.Count.ToString());
				}
			}
			else if (CommonSQL.smethod_6(jarray_0))
			{
				lblSuccess.smethod_2(jarray_0.Count.ToString());
			}
			btnAdd.smethod_1();
			method_0(Language.GetValue("Cập nhật dữ liệu xong!"));
			MsBoxHelper.Show("Cập nhật dữ liệu xong!");
			bool_0 = true;
		}
		catch (Exception exception_)
		{
			MsBoxHelper.Show("Đa\u0303 co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!");
			Commom.smethod_58(exception_, "UpdateAccount");
		}
	}

	private void method_0(string string_0)
	{
		Application.DoEvents();
		lblStatus.Invoke((MethodInvoker)delegate
		{
			lblStatus.Text = string_0;
		});
	}

	private void F8229C80_TextChanged(object sender, EventArgs e)
	{
		try
		{
			if (isAutoFormatting) return;

			if (F8229C80.Text.Contains("	") && !F8229C80.Text.Contains("|"))
			{
				isAutoFormatting = true;
				int selStart = F8229C80.SelectionStart;
				F8229C80.Text = F8229C80.Text.Replace('	', '|');
				F8229C80.SelectionStart = selStart;
				isAutoFormatting = false;
			}

			List<string> list = F8229C80.Lines.ToList();
			list = Commom.smethod_36(list);
			BF8647A8.Text = list.Count.ToString();
			if (list.Count == 0) return;

			string detectedFormat = AccountFormatDetector.DetectFormat(list);
			if (!string.IsNullOrEmpty(detectedFormat))
			{
				int existingIndex = -1;
				for (int i = 0; i < cbbDinhDangNhap.Items.Count; i++)
				{
					if (string.Equals(cbbDinhDangNhap.Items[i]?.ToString()?.Trim(), detectedFormat, StringComparison.OrdinalIgnoreCase))
					{
						existingIndex = i;
						break;
					}
				}

				if (existingIndex >= 0)
				{
					cbbDinhDangNhap.SelectedIndex = existingIndex;
				}
				else
				{
					int insertIndex = Math.Max(0, cbbDinhDangNhap.Items.Count - 1);
					cbbDinhDangNhap.Items.Insert(insertIndex, detectedFormat);
					if (!list_1.Contains(detectedFormat))
					{
						list_1.Add(detectedFormat);
					}
					cbbDinhDangNhap.SelectedIndex = insertIndex;
				}

				List<string> parts = detectedFormat.Split('|').ToList();
				if (parts.Count > 0 && parts[0] == "Uid")
				{
					parts.RemoveAt(0);
				}
				int num = Math.Min(parts.Count, DE96248A.Count);
				for (int j = 0; j < num; j++)
				{
					DE96248A[j].Text = parts[j];
				}
				for (int k = num; k < DE96248A.Count; k++)
				{
					DE96248A[k].Text = "";
				}
			}
		}
		catch
		{
		}
	}

	public static string smethod_0(string E693BC3B)
	{
		if (string.IsNullOrEmpty(E693BC3B)) return "";
		return AccountFormatDetector.DetectSingleLine(E693BC3B);
	}

	private void method_1(List<string> list_2)
	{
		list_2 = list_2.AF1855B2();
		string item = string.Join("|", list_2);
		if (list_1.Contains(item))
		{
			cbbDinhDangNhap.Text = item;
			return;
		}
		if (list_2.Count > 0 && list_2[0] == "Uid")
		{
			list_2.RemoveAt(0);
		}
		cbbDinhDangNhap.SelectedIndex = cbbDinhDangNhap.Items.Count - 1;
		int num = ((list_2.Count < DE96248A.Count) ? list_2.Count : DE96248A.Count);
		for (int i = 0; i < num; i++)
		{
			DE96248A[i].Text = list_2[i];
		}
		for (int j = num; j < DE96248A.Count; j++)
		{
			DE96248A[j].Text = "";
		}
	}

	private void A182A8AC(Label label_0)
	{
		Application.DoEvents();
		lock (label_0)
		{
			label_0.Invoke((MethodInvoker)delegate
			{
				int num = Convert.ToInt32(label_0.Text);
				label_0.Text = (num + 1).ToString();
			});
		}
	}

	private void cbbDinhDangNhap_SelectedIndexChanged(object sender, EventArgs e)
	{
		F43B181F.Visible = cbbDinhDangNhap.SelectedIndex == cbbDinhDangNhap.Items.Count - 1;
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void DE93F635(object sender, EventArgs e)
	{
		bool visible = false;
		for (int i = 0; i < DE96248A.Count; i++)
		{
			if (DE96248A[i].Text == "Proxy")
			{
				visible = true;
				break;
			}
		}
		D4B221A6.Visible = visible;
		cbbTypeProxy.Visible = visible;
	}

	private void fCapNhatDuLieu_Load(object sender, EventArgs e)
	{
		foreach (ComboBox item in DE96248A)
		{
			Commom.smethod_23(item, new List<string>
			{
				"", "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy",
				"Ngày sinh", "Bạn bè", "Giơ\u0301i ti\u0301nh", "Ngày tạo", "Mail khôi phục", "Pass mail khôi phục", "Ghi chú", "Tương tác cuối"
			});
			item.SelectedIndex = 0;
			item.DropDownWidth = 100;
		}
		cbbTypeProxy.SelectedIndex = 0;
		list_1 = new List<string> { "Uid|Pass", "Uid|Pass|2FA", "Uid|Pass|2FA|Cookie", "Uid|Pass|2FA|Cookie|Token", "Uid|Pass|2FA|Cookie|Token|Email|Pass Email", "Uid|Pass|2FA|Token|Cookie|Email|Pass Email", "Uid|Pass|Token|Cookie", "Uid|Pass|Token|Cookie|Email|Pass Email", "Uid|Pass|Token|Cookie|Email|Pass Email|2FA", "Email|Pass Email", "Email|Pass Email|Mail khôi phục", "Email|Pass Email|Mail khôi phục|Pass mail khôi phục", "Email|Refresh_token|Client_id", "Email|Pass Email|Refresh_token|Client_id" };
		method_2();
	}

	private void method_2()
	{
		cbbDinhDangNhap.Items.Clear();
		for (int i = 0; i < list_1.Count; i++)
		{
			cbbDinhDangNhap.Items.Add(list_1[i]);
		}
		cbbDinhDangNhap.Items.Add("Other...");
		cbbDinhDangNhap.SelectedIndex = 0;
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && EE8FEABA != null)
		{
			EE8FEABA.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		EE8FEABA = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCapNhatDuLieu));
		btnAdd = new System.Windows.Forms.Button();
		btnCancel = new System.Windows.Forms.Button();
		E41BC291 = new System.Windows.Forms.Label();
		cbbDinhDangNhap = new System.Windows.Forms.ComboBox();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(EE8FEABA);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(EE8FEABA);
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		F8229C80 = new System.Windows.Forms.RichTextBox();
		AF831F95 = new Bunifu.Framework.UI.BunifuCards();
		ctmsAcc = new System.Windows.Forms.ContextMenuStrip(EE8FEABA);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		F233A48F = new System.Windows.Forms.ToolStripMenuItem();
		CDAE7FAF = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
		DC03FC29 = new System.Windows.Forms.ToolStripMenuItem();
		A8B43107 = new System.Windows.Forms.ToolStripMenuItem();
		A9A2D6A9 = new System.Windows.Forms.Label();
		lblSuccess = new System.Windows.Forms.Label();
		B52B3710 = new System.Windows.Forms.Label();
		BF8647A8 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		D0A13519 = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		F43B181F = new System.Windows.Forms.Panel();
		D0A82B92 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		EA01ECBF = new System.Windows.Forms.Label();
		cbbDinhDang12 = new System.Windows.Forms.ComboBox();
		cbbDinhDang11 = new System.Windows.Forms.ComboBox();
		cbbDinhDang9 = new System.Windows.Forms.ComboBox();
		cbbTypeProxy = new System.Windows.Forms.ComboBox();
		D4B221A6 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		B1319289 = new System.Windows.Forms.ComboBox();
		cbbDinhDang2 = new System.Windows.Forms.ComboBox();
		cbbDinhDang3 = new System.Windows.Forms.ComboBox();
		cbbDinhDang4 = new System.Windows.Forms.ComboBox();
		label14 = new System.Windows.Forms.Label();
		cbbDinhDang5 = new System.Windows.Forms.ComboBox();
		label6 = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		cbbDinhDang10 = new System.Windows.Forms.ComboBox();
		cbbDinhDang8 = new System.Windows.Forms.ComboBox();
		label13 = new System.Windows.Forms.Label();
		cbbDinhDang6 = new System.Windows.Forms.ComboBox();
		label12 = new System.Windows.Forms.Label();
		cbbDinhDang7 = new System.Windows.Forms.ComboBox();
		C9A50C33 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		AF831F95.SuspendLayout();
		ctmsAcc.SuspendLayout();
		F43B181F.SuspendLayout();
		SuspendLayout();
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(482, 460);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(97, 31);
		btnAdd.TabIndex = 13;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(F3101AA7);
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(599, 460);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(97, 31);
		btnCancel.TabIndex = 14;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		E41BC291.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E41BC291.Location = new System.Drawing.Point(9, 367);
		E41BC291.Name = "label8";
		E41BC291.Size = new System.Drawing.Size(97, 14);
		E41BC291.TabIndex = 39;
		E41BC291.Text = "Chọn định dạng:";
		E41BC291.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		cbbDinhDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDangNhap.DropDownWidth = 320;
		cbbDinhDangNhap.FormattingEnabled = true;
		cbbDinhDangNhap.Location = new System.Drawing.Point(112, 364);
		cbbDinhDangNhap.Name = "cbbDinhDangNhap";
		cbbDinhDangNhap.Size = new System.Drawing.Size(269, 24);
		cbbDinhDangNhap.TabIndex = 40;
		cbbDinhDangNhap.SelectedIndexChanged += new System.EventHandler(cbbDinhDangNhap_SelectedIndexChanged);
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(1179, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cập nhật dữ liệu";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox2);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1179, 31);
		pnlHeader.TabIndex = 9;
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox2.Image = Class155.DD225F0D;
		pictureBox2.Location = new System.Drawing.Point(2, 3);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(34, 27);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox2.TabIndex = 79;
		pictureBox2.TabStop = false;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(-156, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 78;
		pictureBox1.TabStop = false;
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(1147, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 77;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		F8229C80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F8229C80.Location = new System.Drawing.Point(12, 77);
		F8229C80.Name = "txbAccount";
		F8229C80.Size = new System.Drawing.Size(1147, 277);
		F8229C80.TabIndex = 48;
		F8229C80.Text = "";
		F8229C80.WordWrap = false;
		F8229C80.TextChanged += new System.EventHandler(F8229C80_TextChanged);
		AF831F95.BackColor = System.Drawing.Color.White;
		AF831F95.BorderRadius = 0;
		AF831F95.BottomSahddow = true;
		AF831F95.color = System.Drawing.Color.DarkViolet;
		AF831F95.Controls.Add(pnlHeader);
		AF831F95.Dock = System.Windows.Forms.DockStyle.Top;
		AF831F95.LeftSahddow = false;
		AF831F95.Location = new System.Drawing.Point(0, 0);
		AF831F95.Name = "bunifuCards1";
		AF831F95.RightSahddow = true;
		AF831F95.ShadowDepth = 20;
		AF831F95.Size = new System.Drawing.Size(1179, 37);
		AF831F95.TabIndex = 49;
		ctmsAcc.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { toolStripMenuItem_0, toolStripMenuItem2, toolStripMenuItem_3, DC03FC29, A8B43107 });
		ctmsAcc.Name = "ctmsAcc";
		ctmsAcc.Size = new System.Drawing.Size(179, 114);
		toolStripMenuItem_0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem_1, toolStripMenuItem_2, F233A48F, CDAE7FAF });
		toolStripMenuItem_0.Name = "chọnToolStripMenuItem1";
		toolStripMenuItem_0.Size = new System.Drawing.Size(178, 22);
		toolStripMenuItem_0.Text = "Chọn";
		toolStripMenuItem_1.Name = "tấtCảToolStripMenuItem1";
		toolStripMenuItem_1.Size = new System.Drawing.Size(143, 22);
		toolStripMenuItem_1.Text = "Tất cả";
		toolStripMenuItem_2.Name = "bôiĐenToolStripMenuItem1";
		toolStripMenuItem_2.Size = new System.Drawing.Size(143, 22);
		toolStripMenuItem_2.Text = "Bôi đen";
		F233A48F.Name = "tàiKhoản0ToolStripMenuItem";
		F233A48F.Size = new System.Drawing.Size(143, 22);
		F233A48F.Text = "Tài khoản=0";
		CDAE7FAF.Name = "tàiKhoản1ToolStripMenuItem";
		CDAE7FAF.Size = new System.Drawing.Size(143, 22);
		CDAE7FAF.Text = "Tài khoản=1";
		toolStripMenuItem2.Name = "toolStripMenuItem2";
		toolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
		toolStripMenuItem2.Text = "Bỏ chọn tất cả";
		toolStripMenuItem_3.Name = "tạoThiếtBịToolStripMenuItem";
		toolStripMenuItem_3.Size = new System.Drawing.Size(178, 22);
		toolStripMenuItem_3.Text = "Tạo thiết bị";
		DC03FC29.Name = "xóaThiếtBịToolStripMenuItem";
		DC03FC29.Size = new System.Drawing.Size(178, 22);
		DC03FC29.Text = "Xóa thiết bị";
		A8B43107.Name = "loadDanhSachThiêtBiToolStripMenuItem1";
		A8B43107.Size = new System.Drawing.Size(178, 22);
		A8B43107.Text = "Làm mới danh sa\u0301ch";
		A9A2D6A9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		A9A2D6A9.Location = new System.Drawing.Point(698, 58);
		A9A2D6A9.Name = "label3";
		A9A2D6A9.Size = new System.Drawing.Size(87, 16);
		A9A2D6A9.TabIndex = 55;
		A9A2D6A9.Text = "Tha\u0300nh công:";
		A9A2D6A9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lblSuccess.AutoSize = true;
		lblSuccess.BackColor = System.Drawing.SystemColors.Control;
		lblSuccess.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblSuccess.ForeColor = System.Drawing.Color.FromArgb(53, 120, 229);
		lblSuccess.Location = new System.Drawing.Point(781, 55);
		lblSuccess.Name = "lblSuccess";
		lblSuccess.Size = new System.Drawing.Size(19, 19);
		lblSuccess.TabIndex = 50;
		lblSuccess.Text = "0";
		B52B3710.AutoSize = true;
		B52B3710.BackColor = System.Drawing.SystemColors.Control;
		B52B3710.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B52B3710.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
		B52B3710.Location = new System.Drawing.Point(904, 55);
		B52B3710.Name = "lblError";
		B52B3710.Size = new System.Drawing.Size(19, 19);
		B52B3710.TabIndex = 51;
		B52B3710.Text = "0";
		BF8647A8.AutoSize = true;
		BF8647A8.BackColor = System.Drawing.SystemColors.Control;
		BF8647A8.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BF8647A8.ForeColor = System.Drawing.Color.Teal;
		BF8647A8.Location = new System.Drawing.Point(1064, 56);
		BF8647A8.Name = "lblTotal";
		BF8647A8.Size = new System.Drawing.Size(19, 19);
		BF8647A8.TabIndex = 53;
		BF8647A8.Text = "0";
		label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label4.Location = new System.Drawing.Point(855, 58);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(52, 16);
		label4.TabIndex = 56;
		label4.Text = "Lỗi:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		D0A13519.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		D0A13519.Location = new System.Drawing.Point(1004, 58);
		D0A13519.Name = "label7";
		D0A13519.Size = new System.Drawing.Size(63, 16);
		D0A13519.TabIndex = 59;
		D0A13519.Text = "Tô\u0309ng sô\u0301:";
		D0A13519.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatus.Location = new System.Drawing.Point(12, 44);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(227, 28);
		lblStatus.TabIndex = 60;
		lblStatus.Text = "Nhập thông tin tài khoản:";
		lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F43B181F.Controls.Add(D0A82B92);
		F43B181F.Controls.Add(label15);
		F43B181F.Controls.Add(EA01ECBF);
		F43B181F.Controls.Add(cbbDinhDang12);
		F43B181F.Controls.Add(cbbDinhDang11);
		F43B181F.Controls.Add(cbbDinhDang9);
		F43B181F.Controls.Add(cbbTypeProxy);
		F43B181F.Controls.Add(D4B221A6);
		F43B181F.Controls.Add(label1);
		F43B181F.Controls.Add(B1319289);
		F43B181F.Controls.Add(cbbDinhDang2);
		F43B181F.Controls.Add(cbbDinhDang3);
		F43B181F.Controls.Add(cbbDinhDang4);
		F43B181F.Controls.Add(label14);
		F43B181F.Controls.Add(cbbDinhDang5);
		F43B181F.Controls.Add(label6);
		F43B181F.Controls.Add(label17);
		F43B181F.Controls.Add(cbbDinhDang10);
		F43B181F.Controls.Add(cbbDinhDang8);
		F43B181F.Controls.Add(label13);
		F43B181F.Controls.Add(cbbDinhDang6);
		F43B181F.Controls.Add(label12);
		F43B181F.Controls.Add(cbbDinhDang7);
		F43B181F.Controls.Add(C9A50C33);
		F43B181F.Controls.Add(label9);
		F43B181F.Controls.Add(label10);
		F43B181F.Location = new System.Drawing.Point(12, 392);
		F43B181F.Name = "plDinhDangNhap";
		F43B181F.Size = new System.Drawing.Size(1157, 62);
		F43B181F.TabIndex = 61;
		D0A82B92.AutoSize = true;
		D0A82B92.Font = new System.Drawing.Font("Tahoma", 12f);
		D0A82B92.Location = new System.Drawing.Point(1057, 7);
		D0A82B92.Name = "label16";
		D0A82B92.Size = new System.Drawing.Size(15, 19);
		D0A82B92.TabIndex = 128;
		D0A82B92.Text = "|";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Tahoma", 12f);
		label15.Location = new System.Drawing.Point(961, 6);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(15, 19);
		label15.TabIndex = 128;
		label15.Text = "|";
		EA01ECBF.AutoSize = true;
		EA01ECBF.Font = new System.Drawing.Font("Tahoma", 12f);
		EA01ECBF.Location = new System.Drawing.Point(774, 4);
		EA01ECBF.Name = "label5";
		EA01ECBF.Size = new System.Drawing.Size(15, 19);
		EA01ECBF.TabIndex = 128;
		EA01ECBF.Text = "|";
		cbbDinhDang12.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang12.FormattingEnabled = true;
		cbbDinhDang12.Location = new System.Drawing.Point(1072, 7);
		cbbDinhDang12.Name = "cbbDinhDang12";
		cbbDinhDang12.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang12.TabIndex = 127;
		cbbDinhDang11.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang11.FormattingEnabled = true;
		cbbDinhDang11.Location = new System.Drawing.Point(976, 6);
		cbbDinhDang11.Name = "cbbDinhDang11";
		cbbDinhDang11.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang11.TabIndex = 127;
		cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang9.FormattingEnabled = true;
		cbbDinhDang9.Location = new System.Drawing.Point(789, 4);
		cbbDinhDang9.Name = "cbbDinhDang9";
		cbbDinhDang9.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang9.TabIndex = 127;
		cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbTypeProxy.FormattingEnabled = true;
		cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
		cbbTypeProxy.Location = new System.Drawing.Point(85, 33);
		cbbTypeProxy.Name = "cbbTypeProxy";
		cbbTypeProxy.Size = new System.Drawing.Size(130, 24);
		cbbTypeProxy.TabIndex = 126;
		cbbTypeProxy.Visible = false;
		D4B221A6.AutoSize = true;
		D4B221A6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D4B221A6.Location = new System.Drawing.Point(7, 36);
		D4B221A6.Name = "label2";
		D4B221A6.Size = new System.Drawing.Size(70, 16);
		D4B221A6.TabIndex = 125;
		D4B221A6.Text = "Loại proxy:";
		D4B221A6.Visible = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 12f);
		label1.Location = new System.Drawing.Point(5, 3);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(39, 19);
		label1.TabIndex = 42;
		label1.Text = "Uid|";
		B1319289.Cursor = System.Windows.Forms.Cursors.Hand;
		B1319289.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		B1319289.FormattingEnabled = true;
		B1319289.Location = new System.Drawing.Point(44, 3);
		B1319289.Name = "cbbDinhDang1";
		B1319289.Size = new System.Drawing.Size(78, 24);
		B1319289.TabIndex = 40;
		B1319289.SelectedIndexChanged += new System.EventHandler(DE93F635);
		cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang2.FormattingEnabled = true;
		cbbDinhDang2.Location = new System.Drawing.Point(137, 3);
		cbbDinhDang2.Name = "cbbDinhDang2";
		cbbDinhDang2.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang2.TabIndex = 40;
		cbbDinhDang2.SelectedIndexChanged += new System.EventHandler(DE93F635);
		cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang3.FormattingEnabled = true;
		cbbDinhDang3.Location = new System.Drawing.Point(230, 3);
		cbbDinhDang3.Name = "cbbDinhDang3";
		cbbDinhDang3.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang3.TabIndex = 40;
		cbbDinhDang3.SelectedIndexChanged += new System.EventHandler(DE93F635);
		cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang4.FormattingEnabled = true;
		cbbDinhDang4.Location = new System.Drawing.Point(323, 3);
		cbbDinhDang4.Name = "cbbDinhDang4";
		cbbDinhDang4.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang4.TabIndex = 40;
		cbbDinhDang4.SelectedIndexChanged += new System.EventHandler(DE93F635);
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Tahoma", 12f);
		label14.Location = new System.Drawing.Point(587, 3);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(15, 19);
		label14.TabIndex = 41;
		label14.Text = "|";
		cbbDinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang5.FormattingEnabled = true;
		cbbDinhDang5.Location = new System.Drawing.Point(416, 3);
		cbbDinhDang5.Name = "cbbDinhDang5";
		cbbDinhDang5.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang5.TabIndex = 40;
		cbbDinhDang5.SelectedIndexChanged += new System.EventHandler(DE93F635);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Tahoma", 12f);
		label6.Location = new System.Drawing.Point(867, 5);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(15, 19);
		label6.TabIndex = 41;
		label6.Text = "|";
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Tahoma", 12f);
		label17.Location = new System.Drawing.Point(680, 3);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(15, 19);
		label17.TabIndex = 41;
		label17.Text = "|";
		cbbDinhDang10.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang10.FormattingEnabled = true;
		cbbDinhDang10.Location = new System.Drawing.Point(882, 5);
		cbbDinhDang10.Name = "cbbDinhDang10";
		cbbDinhDang10.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang10.TabIndex = 40;
		cbbDinhDang10.SelectedIndexChanged += new System.EventHandler(DE93F635);
		cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang8.FormattingEnabled = true;
		cbbDinhDang8.Location = new System.Drawing.Point(695, 3);
		cbbDinhDang8.Name = "cbbDinhDang8";
		cbbDinhDang8.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang8.TabIndex = 40;
		cbbDinhDang8.SelectedIndexChanged += new System.EventHandler(DE93F635);
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Tahoma", 12f);
		label13.Location = new System.Drawing.Point(494, 3);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(15, 19);
		label13.TabIndex = 41;
		label13.Text = "|";
		cbbDinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang6.FormattingEnabled = true;
		cbbDinhDang6.Location = new System.Drawing.Point(509, 3);
		cbbDinhDang6.Name = "cbbDinhDang6";
		cbbDinhDang6.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang6.TabIndex = 40;
		cbbDinhDang6.SelectedIndexChanged += new System.EventHandler(DE93F635);
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Tahoma", 12f);
		label12.Location = new System.Drawing.Point(401, 3);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(15, 19);
		label12.TabIndex = 41;
		label12.Text = "|";
		cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang7.FormattingEnabled = true;
		cbbDinhDang7.Location = new System.Drawing.Point(602, 3);
		cbbDinhDang7.Name = "cbbDinhDang7";
		cbbDinhDang7.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang7.TabIndex = 40;
		cbbDinhDang7.SelectedIndexChanged += new System.EventHandler(DE93F635);
		C9A50C33.AutoSize = true;
		C9A50C33.Font = new System.Drawing.Font("Tahoma", 12f);
		C9A50C33.Location = new System.Drawing.Point(308, 3);
		C9A50C33.Name = "label11";
		C9A50C33.Size = new System.Drawing.Size(15, 19);
		C9A50C33.TabIndex = 41;
		C9A50C33.Text = "|";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Tahoma", 12f);
		label9.Location = new System.Drawing.Point(122, 3);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(15, 19);
		label9.TabIndex = 41;
		label9.Text = "|";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Tahoma", 12f);
		label10.Location = new System.Drawing.Point(215, 3);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(15, 19);
		label10.TabIndex = 41;
		label10.Text = "|";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1179, 502);
		base.Controls.Add(F43B181F);
		base.Controls.Add(lblStatus);
		base.Controls.Add(A9A2D6A9);
		base.Controls.Add(lblSuccess);
		base.Controls.Add(B52B3710);
		base.Controls.Add(BF8647A8);
		base.Controls.Add(label4);
		base.Controls.Add(D0A13519);
		base.Controls.Add(btnAdd);
		base.Controls.Add(btnCancel);
		base.Controls.Add(F8229C80);
		base.Controls.Add(AF831F95);
		base.Controls.Add(cbbDinhDangNhap);
		base.Controls.Add(E41BC291);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCapNhatDuLieu";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Nhập tài khoản";
		base.Load += new System.EventHandler(fCapNhatDuLieu_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		AF831F95.ResumeLayout(false);
		ctmsAcc.ResumeLayout(false);
		F43B181F.ResumeLayout(false);
		F43B181F.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
