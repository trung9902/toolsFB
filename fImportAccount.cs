using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fImportAccount : Form
{
	[CompilerGenerated]
	private sealed class F28EFB07
	{
		internal bool bool_0;

		internal int int_0;

		internal string string_0;

		internal List<string> FCADD43D;

		internal fImportAccount C83BB63A;

		internal void method_0()
		{
			try
			{
				C83BB63A.btnAdd.Invoke((MethodInvoker)delegate
				{
					C83BB63A.btnAdd.Enabled = false;
				});
				C83BB63A.method_2(Language.GetValue("Chuẩn bị thêm tài khoản..."), C83BB63A.lblStatus);
				if (bool_0)
				{
					int num = 0;
					while (num < C83BB63A.ABA10B08.Count)
					{
						if (C83BB63A.list_1.Count < int_0)
						{
							Class67 CS_0024_003C_003E8__locals0 = new Class67
							{
								F6A58209 = this,
								int_0 = num++
							};
							C83BB63A.method_2($"Check info {CS_0024_003C_003E8__locals0.int_0 + 1}/{C83BB63A.ABA10B08.Count}...", C83BB63A.lblStatus);
							Thread thread = new Thread((ThreadStart)delegate
							{
								try
								{
									string text3 = CS_0024_003C_003E8__locals0.F6A58209.C83BB63A.ABA10B08[CS_0024_003C_003E8__locals0.int_0];
									if (text3 != "")
									{
										string text4 = CS_0024_003C_003E8__locals0.F6A58209.C83BB63A.method_1(CS_0024_003C_003E8__locals0.F6A58209.string_0, text3, CS_0024_003C_003E8__locals0.F6A58209.bool_0);
										if (text4 != "")
										{
											lock (CS_0024_003C_003E8__locals0.F6A58209.FCADD43D)
											{
												CS_0024_003C_003E8__locals0.F6A58209.FCADD43D.Add(text4);
											}
										}
									}
								}
								catch (Exception)
								{
								}
							});
							C83BB63A.list_1.Add(thread);
							thread.Start();
							continue;
						}
						for (int i = 0; i < C83BB63A.list_1.Count; i++)
						{
							if (!C83BB63A.list_1[i].IsAlive)
							{
								C83BB63A.list_1.RemoveAt(i--);
							}
						}
					}
					for (int j = 0; j < C83BB63A.list_1.Count; j++)
					{
						C83BB63A.list_1[j].Join();
					}
				}
				else
				{
					for (int k = 0; k < C83BB63A.ABA10B08.Count; k++)
					{
						try
						{
							string text = C83BB63A.ABA10B08[k];
							if (text != "")
							{
								string text2 = C83BB63A.method_1(string_0, text, bool_0);
								if (text2 != "")
								{
									FCADD43D.Add(text2);
								}
							}
						}
						catch
						{
						}
					}
				}
				C83BB63A.method_2(Language.GetValue("Đang thêm tài khoản..."), C83BB63A.lblStatus);
				if (FCADD43D.Count >= 0)
				{
					FCADD43D = CommonSQL.smethod_8(FCADD43D);
					for (int l = 0; l < FCADD43D.Count; l++)
					{
						C83BB63A.method_4(C83BB63A.B0B4A28F, Class60.E211632E(FCADD43D[l]));
					}
				}
				C83BB63A.method_2((Convert.ToInt32(C83BB63A.A42CBD16.Text) - Convert.ToInt32(C83BB63A.B0B4A28F.Text)).ToString() ?? "", C83BB63A.lblError);
				C83BB63A.btnAdd.smethod_1();
				C83BB63A.method_2(Language.GetValue("Thêm tài khoản thành công!"), C83BB63A.lblStatus);
				MsBoxHelper.Show("Thêm tài khoản thành công!");
				C83BB63A.bool_0 = true;
				C83BB63A.int_0 = Convert.ToInt32(string_0);
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "AddAccount");
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class67
	{
		internal int int_0;

		internal F28EFB07 F6A58209;

		internal void AC9F7B91()
		{
			try
			{
				string text = F6A58209.C83BB63A.ABA10B08[int_0];
				if (!(text != ""))
				{
					return;
				}
				string text2 = F6A58209.C83BB63A.method_1(F6A58209.string_0, text, F6A58209.bool_0);
				if (text2 != "")
				{
					lock (F6A58209.FCADD43D)
					{
						F6A58209.FCADD43D.Add(text2);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class68
	{
		internal Label EA992B8E;

		internal string string_0;

		internal void method_0()
		{
			Application.DoEvents();
			EA992B8E.Text = string_0;
		}
	}

	[CompilerGenerated]
	private sealed class DE3E7523
	{
		internal Label label_0;

		internal int D00202B3;

		internal void method_0()
		{
			Application.DoEvents();
			label_0.Text = (Convert.ToInt32(label_0.Text) + ((D00202B3 == -1) ? 1 : D00202B3)).ToString();
		}

		internal void method_1()
		{
			Application.DoEvents();
			label_0.Text = (Convert.ToInt32(label_0.Text) + D00202B3).ToString();
		}
	}

	internal bool bool_0 = false;

	internal int int_0 = -1;

	internal bool bool_1 = false;

	internal List<ComboBox> list_0;

	internal int F1AEE002 = 0;

	internal List<string> ABA10B08 = new List<string>();

	internal List<Thread> list_1 = null;

	internal object object_0 = new object();

	internal List<string> list_2 = new List<string>();

	internal string string_0 = Commom.smethod_95() + "\\settings\\inputformat.txt";

	internal IContainer F0073B0C = null;

	internal BunifuCards bunifuCards1;

	internal Button btnAdd;

	internal Button btnCancel;

	internal Label B0B4A28F;

	internal Label lblError;

	internal Label A42CBD16;

	internal Label label3;

	internal Label label4;

	internal Label E1A35B3E;

	internal Label lblStatus;

	internal Label label8;

	internal Label lblAutoDetect;

	private bool isAutoFormatting = false;

	internal ComboBox F599E0BB;

	internal ComboBox cbbDinhDang1;

	internal Label label9;

	internal ComboBox B51D9C23;

	internal Label DA896BBA;

	internal ComboBox cbbDinhDang3;

	internal Label C22CF997;

	internal ComboBox cbbDinhDang4;

	internal Label label12;

	internal ComboBox AC120E0F;

	internal Label label13;

	internal ComboBox CF2AD935;

	internal Label FA12299D;

	internal ComboBox cbbDinhDang7;

	internal BunifuDragControl B08A2B33;

	internal BunifuDragControl ABA8ECBC;

	internal Panel plDinhDangNhap;

	internal PictureBox pictureBox1;

	internal Label E115F8BB;

	internal ComboBox E525CFBC;

	internal Button C3217D1C;

	internal RichTextBox txbAccount;

	internal Label FABC8C0F;

	internal Label label17;

	internal ComboBox cbbDinhDang8;

	internal ComboBox cbbDinhDang9;

	internal Button button2;

	internal Button button3;

	internal Label label19;

	internal Label DB31B101;

	internal ComboBox BAA9680E;

	internal ComboBox cbbDinhDang11;

	internal Panel A833A81E;

	internal Button F2A1DD93;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button metroButton1;

	internal Button BCAC132C;

	internal Panel panel1;

	internal CheckBox ckbCheckThongTin;

	public fImportAccount(string string_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
		if (string_1 != "" && string_1 != "-2" && string_1 != "999999")
		{
			E525CFBC.SelectedValue = string_1;
		}
		F599E0BB.SelectedIndex = 0;
		bool_1 = false;
		bool_0 = false;
		int_0 = -1;
		B621A49C();
	}

	private void B621A49C()
	{
		list_0 = new List<ComboBox>
		{
			cbbDinhDang1, B51D9C23, cbbDinhDang3, cbbDinhDang4, AC120E0F, CF2AD935, cbbDinhDang7, cbbDinhDang8, cbbDinhDang9, BAA9680E,
			cbbDinhDang11
		};
		foreach (ComboBox item in list_0)
		{
			Commom.smethod_23(item, new List<string>
			{
				"", "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy",
				"Birthday", "Bạn bè", "Ngày tạo", "Mail khôi phục", "Pass mail khôi phục", "Ghi chú", "Location", "Refresh_token", "Client_id"
			});
			item.SelectedIndex = -1;
			item.DropDownWidth = 100;
		}
	}

	private void method_0()
	{
		F1AEE002 = E525CFBC.SelectedIndex;
		DataTable dataTable = CommonSQL.smethod_1();
		if (dataTable.Rows.Count > 0)
		{
			E525CFBC.DataSource = dataTable;
			E525CFBC.ValueMember = "id";
			E525CFBC.DisplayMember = "name";
			if (F1AEE002 == -1)
			{
				F1AEE002 = 0;
			}
			E525CFBC.SelectedIndex = F1AEE002;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AD0EA72A(object sender, EventArgs e)
	{
		try
		{
			List<string> list = txbAccount.Lines.ToList();
			list = Commom.smethod_36(list);
			if (list.Count == 0)
			{
				MsBoxHelper.Show(Language.GetValue("Vui lòng nhâ\u0323p thông tin ta\u0300i khoa\u0309n!"), 3);
				txbAccount.Focus();
				return;
			}
			if (E525CFBC.SelectedValue == null)
			{
				MsBoxHelper.Show(Language.GetValue("Vui lòng cho\u0323n thư mu\u0323c!"), 3);
				return;
			}
			string string_0 = E525CFBC.SelectedValue.ToString();
			bool bool_0 = ckbCheckThongTin.Checked;
			string text = F599E0BB.Text;
			if (F599E0BB.SelectedIndex != F599E0BB.Items.Count - 1)
			{
				goto IL_0172;
			}
			bool flag = false;
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i].SelectedIndex > 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng ta\u0300i khoa\u0309n!", 3);
				return;
			}
			text = "";
			for (int j = 0; j < list_0.Count; j++)
			{
				text = text + list_0[j].Text + "|";
			}
			text = text.TrimEnd('|');
			goto IL_0172;
			IL_0172:
			if (text == "")
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng ta\u0300i khoa\u0309n!");
				return;
			}
			int int_0 = 100;
			if (list.Count < 100)
			{
				int_0 = list.Count;
			}
			B0B4A28F.Text = "0";
			lblError.Text = "0";
			ABA10B08 = new List<string>();
			List<string> list2 = text.Split('|').ToList();
			for (int k = 0; k < list.Count; k++)
			{
				string textLine = AccountFormatDetector.NormalizeLine(list[k]);
				List<string> list3 = textLine.Split('|').Select(s => s.Trim()).ToList();
				if (list3.Count < list2.Count)
				{
					for (int l = 0; l < list2.Count - list3.Count; l++)
					{
						list3.Add("");
					}
				}
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
					for (int m = 0; m < list2.Count; m++)
					{
						string text20 = list2[m];
						string text21 = text20;
						uint num = AFAE75A0.smethod_0(text21);
						if (num <= 2249983736u)
						{
							if (num <= 1335761915)
							{
								if (num <= 953496446)
								{
									if (num != 339788125)
									{
										if (num != 776692014)
										{
											if (num == 953496446 && text21 == "Client_id")
											{
												text19 = list3[m];
											}
											continue;
										}
										if (!(text21 == "Ghi chú"))
										{
											continue;
										}
									}
									else if (!(text21 == "Note"))
									{
										continue;
									}
									text16 = list3[m];
									continue;
								}
								switch (num)
								{
								case 1335761915u:
									if (text21 == "Proxy" && list3[m].Trim() != "")
									{
										text10 = list3[m] + "*0";
									}
									break;
								case 1127555431u:
									if (text21 == "Email")
									{
										text6 = list3[m];
									}
									break;
								case 976575442u:
									if (text21 == "Token")
									{
										text4 = list3[m];
									}
									break;
								}
								continue;
							}
							if (num <= 1674345338)
							{
								if (num != 1439766491)
								{
									if (num != 1539345862)
									{
										if (num != 1674345338 || !(text21 == "Friends"))
										{
											continue;
										}
										goto IL_0722;
									}
									if (text21 == "Location")
									{
										text17 = list3[m];
									}
									continue;
								}
								if (!(text21 == "Email recover"))
								{
									continue;
								}
							}
							else
							{
								if (num != 1802569846)
								{
									if (num != 2152741479u)
									{
										if (num == 2249983736u && text21 == "2FA")
										{
											text8 = list3[m];
										}
										continue;
									}
									if (!(text21 == "Pass mail khôi phục"))
									{
										continue;
									}
									goto IL_06df;
								}
								if (!(text21 == "Mail khôi phục"))
								{
									continue;
								}
							}
							text14 = list3[m];
							continue;
						}
						if (num <= 3444637862u)
						{
							if (num <= 3183131359u)
							{
								if (num != 2589850865u)
								{
									if (num != 2958674405u)
									{
										if (num == 3183131359u && text21 == "Cookie")
										{
											text5 = list3[m];
										}
										continue;
									}
									if (!(text21 == "Ngày tạo"))
									{
										continue;
									}
									goto IL_06a8;
								}
								if (!(text21 == "Ngày sinh"))
								{
									continue;
								}
							}
							else
							{
								if (num == 3209957741u)
								{
									if (text21 == "Uid")
									{
										text2 = list3[m];
									}
									continue;
								}
								if (num != 3243292492u)
								{
									if (num == 3444637862u && text21 == "Refresh_token")
									{
										text18 = list3[m];
									}
									continue;
								}
								if (!(text21 == "Birthday"))
								{
									continue;
								}
							}
							text11 = list3[m];
							continue;
						}
						if (num <= 3646757383u)
						{
							if (num != 3578917853u)
							{
								switch (num)
								{
								case 3646757383u:
									if (text21 == "Useragent")
									{
										text9 = list3[m];
									}
									break;
								case 3611366992u:
									if (text21 == "Pass Email")
									{
										text7 = list3[m].Replace("'", "''");
									}
									break;
								}
								continue;
							}
							if (!(text21 == "Date created"))
							{
								continue;
							}
							goto IL_06a8;
						}
						if (num != 3763899592u)
						{
							if (num != 3797654840u)
							{
								if (num != 4067830019u || !(text21 == "Pass mail recover"))
								{
									continue;
								}
								goto IL_06df;
							}
							if (text21 == "Pass")
							{
								text3 = list3[m].Replace("'", "''");
							}
							continue;
						}
						if (!(text21 == "Bạn bè"))
						{
							continue;
						}
						goto IL_0722;
						IL_06a8:
						text13 = list3[m];
						continue;
						IL_0722:
						text12 = list3[m];
						continue;
						IL_06df:
						text15 = list3[m];
					}
					ABA10B08.Add(text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9 + "|" + text10 + "|" + text11 + "|" + text12 + "|" + text13 + "|" + text14 + "|" + text15 + "|" + text16 + "|" + text17 + "|" + text18 + "|" + text19);
				}
				catch
				{
					method_4(lblError);
				}
			}
			List<string> FCADD43D = new List<string>();
			list_1 = new List<Thread>();
			new Thread((ThreadStart)delegate
			{
				try
				{
					btnAdd.Invoke((MethodInvoker)delegate
					{
						btnAdd.Enabled = false;
					});
					method_2(Language.GetValue("Chuẩn bị thêm tài khoản..."), lblStatus);
					if (bool_0)
					{
						int num2 = 0;
						while (num2 < ABA10B08.Count)
						{
							if (list_1.Count < int_0)
							{
								int int_ = num2++;
								method_2($"Check info {int_ + 1}/{ABA10B08.Count}...", lblStatus);
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										string text24 = ABA10B08[int_];
										if (text24 != "")
										{
											string text25 = method_1(string_0, text24, bool_0);
											if (text25 != "")
											{
												lock (FCADD43D)
												{
													FCADD43D.Add(text25);
												}
											}
										}
									}
									catch (Exception)
									{
									}
								});
								list_1.Add(thread);
								thread.Start();
							}
							else
							{
								for (int n = 0; n < list_1.Count; n++)
								{
									if (!list_1[n].IsAlive)
									{
										list_1.RemoveAt(n--);
									}
								}
							}
						}
						for (int num3 = 0; num3 < list_1.Count; num3++)
						{
							list_1[num3].Join();
						}
					}
					else
					{
						for (int num4 = 0; num4 < ABA10B08.Count; num4++)
						{
							try
							{
								string text22 = ABA10B08[num4];
								if (text22 != "")
								{
									string text23 = method_1(string_0, text22, bool_0);
									if (text23 != "")
									{
										FCADD43D.Add(text23);
									}
								}
							}
							catch
							{
							}
						}
					}
					method_2(Language.GetValue("Đang thêm tài khoản..."), lblStatus);
					if (FCADD43D.Count >= 0)
					{
						FCADD43D = CommonSQL.smethod_8(FCADD43D);
						for (int num5 = 0; num5 < FCADD43D.Count; num5++)
						{
							method_4(B0B4A28F, Class60.E211632E(FCADD43D[num5]));
						}
					}
					method_2((Convert.ToInt32(A42CBD16.Text) - Convert.ToInt32(B0B4A28F.Text)).ToString() ?? "", lblError);
					btnAdd.smethod_1();
					method_2(Language.GetValue("Thêm tài khoản thành công!"), lblStatus);
					MsBoxHelper.Show("Thêm tài khoản thành công!");
					this.bool_0 = true;
					this.int_0 = Convert.ToInt32(string_0);
				}
				catch (Exception exception_2)
				{
					Commom.smethod_57(null, exception_2, "AddAccount");
				}
			}).Start();
		}
		catch (Exception exception_)
		{
			MsBoxHelper.Show("Đa\u0303 co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			Commom.smethod_57(null, exception_, "AddAccount");
		}
	}

	private string method_1(string string_1, string string_2, bool E58FC82D)
	{
		try
		{
			string[] array = string_2.Split('|');
			string text = array[0];
			string text2 = array[1];
			string string_3 = array[2];
			string text3 = array[3];
			string string_4 = array[4];
			string string_5 = array[5];
			string string_6 = array[6];
			string string_7 = array[7];
			string cDAA9C8D = array[8];
			string string_8 = array[9];
			string string_9 = array[10];
			string string_10 = array[11];
			string string_11 = array[12];
			string string_12 = array[13];
			string string_13 = "";
			string aD39D1AF = "";
			string string_14 = "";
			string string_15 = "unknow";
			string string_16 = array[14];
			string e = array[15];
			string string_17 = (array[16] + "|" + array[17]).Trim('|');
			if (text == "")
			{
				text = Regex.Match(text3, "c_user=(\\d+)").Groups[1].Value;
			}
			if (E58FC82D && text != "")
			{
				string text4 = CommonRequest.E083FD83(text);
				if (text4.StartsWith("0|"))
				{
					if (CommonRequest.BC9215A7(text).StartsWith("0|"))
					{
						string_15 = "Die";
					}
				}
				else if (text4.StartsWith("1|"))
				{
					string[] array2 = text4.Split('|');
					string_13 = array2[1];
					string_9 = array2[2];
					string_10 = array2[3];
					string_15 = "Live";
				}
			}
			return CommonSQL.E503ACA8(text, text2, string_3, text3, string_4, string_13, string_9, aD39D1AF, string_8, string_14, string_15, string_6, string_1, string_5, string_7, cDAA9C8D, string_10, string_11, string_12, string_16, e, string_17);
		}
		catch (Exception)
		{
		}
		return "";
	}

	private void method_2(string B107CC2B, Label label_0)
	{
		label_0.Invoke((MethodInvoker)delegate
		{
			Application.DoEvents();
			label_0.Text = B107CC2B;
		});
	}

	public static string smethod_0(string E4869BAB)
	{
		if (string.IsNullOrEmpty(E4869BAB)) return "";
		return AccountFormatDetector.DetectSingleLine(E4869BAB);
	}

	private void FA29A6BA(object sender, EventArgs e)
	{
		try
		{
			if (isAutoFormatting) return;

			if (txbAccount.Text.Contains("	") && !txbAccount.Text.Contains("|"))
			{
				isAutoFormatting = true;
				int selStart = txbAccount.SelectionStart;
				txbAccount.Text = txbAccount.Text.Replace('	', '|');
				txbAccount.SelectionStart = selStart;
				isAutoFormatting = false;
			}

			List<string> list = txbAccount.Lines.ToList();
			list = Commom.smethod_36(list);
			A42CBD16.Text = list.Count.ToString();
			if (list.Count == 0)
			{
				if (lblAutoDetect != null) lblAutoDetect.Text = "";
				return;
			}

			string detectedFormat = AccountFormatDetector.DetectFormat(list);
			if (!string.IsNullOrEmpty(detectedFormat))
			{
				ApplyDetectedFormat(detectedFormat, list.Count);
			}
		}
		catch
		{
		}
	}

	private void ApplyDetectedFormat(string detectedFormat, int accountCount)
	{
		try
		{
			if (lblAutoDetect != null)
			{
				lblAutoDetect.Text = $"⚡ Tự động nhận diện: {detectedFormat} ({accountCount} tài khoản)";
				lblAutoDetect.ForeColor = System.Drawing.Color.ForestGreen;
			}

			int existingIndex = -1;
			for (int i = 0; i < F599E0BB.Items.Count; i++)
			{
				if (string.Equals(F599E0BB.Items[i]?.ToString()?.Trim(), detectedFormat, StringComparison.OrdinalIgnoreCase))
				{
					existingIndex = i;
					break;
				}
			}

			if (existingIndex >= 0)
			{
				F599E0BB.SelectedIndex = existingIndex;
			}
			else
			{
				int insertIndex = Math.Max(0, F599E0BB.Items.Count - 1);
				F599E0BB.Items.Insert(insertIndex, detectedFormat);
				if (!list_2.Contains(detectedFormat))
				{
					list_2.Add(detectedFormat);
					try
					{
						File.WriteAllLines(string_0, list_2);
					}
					catch { }
				}
				F599E0BB.SelectedIndex = insertIndex;
			}

			List<string> parts = detectedFormat.Split('|').ToList();
			int num = Math.Min(parts.Count, list_0.Count);
			for (int j = 0; j < num; j++)
			{
				list_0[j].Text = parts[j];
			}
			for (int k = num; k < list_0.Count; k++)
			{
				list_0[k].Text = "";
			}
		}
		catch
		{
		}
	}

	private void method_3(List<string> list_3)
	{
		string item = string.Join("|", list_3);
		ApplyDetectedFormat(item, 1);
	}

	private void method_4(Label B5A7722D, int FD9472BF = -1)
	{
		if (FD9472BF == -1)
		{
			B5A7722D.Invoke((MethodInvoker)delegate
			{
				Application.DoEvents();
				B5A7722D.Text = (Convert.ToInt32(B5A7722D.Text) + ((FD9472BF == -1) ? 1 : FD9472BF)).ToString();
			});
		}
		else
		{
			B5A7722D.Invoke((MethodInvoker)delegate
			{
				Application.DoEvents();
				B5A7722D.Text = (Convert.ToInt32(B5A7722D.Text) + FD9472BF).ToString();
			});
		}
	}

	private void E082AA33(object sender, EventArgs e)
	{
		plDinhDangNhap.Visible = F599E0BB.SelectedIndex == F599E0BB.Items.Count - 1;
		if (plDinhDangNhap.Visible)
		{
			F7A9EF98();
		}
	}

	private void FB94D736(object sender, EventArgs e)
	{
		fAddFile form_ = new fAddFile();
		Commom.smethod_35(form_);
		if (fAddFile.bool_0)
		{
			method_0();
			E525CFBC.SelectedIndex = E525CFBC.Items.Count - 1;
			bool_1 = true;
		}
	}

	private bool method_5()
	{
		return false;
	}

	private void cbbDinhDang9_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (method_5())
		{
			MsBoxHelper.Show("Tu\u0300y cho\u0323n na\u0300y đa\u0303 tô\u0300n ta\u0323i, vui lo\u0300ng cho\u0323n tu\u0300y cho\u0323n kha\u0301c!", 3);
			(sender as ComboBox).SelectedIndex = -1;
		}
	}

	private void A79BA431(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		DF346139();
	}

	private void method_6()
	{
		try
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].SelectedIndex = -1;
			}
		}
		catch
		{
		}
	}

	private void DF346139()
	{
		try
		{
			string text = "";
			for (int i = 0; i < list_0.Count; i++)
			{
				text = text + list_0[i].SelectedIndex + "|";
			}
			text = text.TrimEnd('|');
			C5034B95.smethod_0("configFormat").method_4("pasteFormat", text);
			C5034B95.smethod_0("configFormat").AEBFED04();
		}
		catch
		{
		}
	}

	private void F7A9EF98()
	{
		try
		{
			string text = C5034B95.smethod_0("configFormat").BDB80B23("pasteFormat");
			if (text != "")
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					list_0[i].SelectedIndex = Convert.ToInt32(text.Split('|')[i]);
				}
			}
		}
		catch
		{
		}
	}

	private void BF2BAC9B(object sender, EventArgs e)
	{
		fImportAccountFormatInput fImportAccountFormatInput2 = new fImportAccountFormatInput();
		Commom.smethod_35(fImportAccountFormatInput2);
		string text = fImportAccountFormatInput2.string_0.Trim();
		if (text != "" && !list_2.Contains(text))
		{
			list_2.Add(text);
			File.WriteAllLines(string_0, list_2);
			E60F5B04();
			F599E0BB.SelectedIndex = F599E0BB.Items.Count - 2;
		}
	}

	private void metroButton1_Click(object sender, EventArgs e)
	{
		int selectedIndex = F599E0BB.SelectedIndex;
		if (selectedIndex == -1 || selectedIndex == F599E0BB.Items.Count - 1)
		{
			MsBoxHelper.Show("Không thể xóa định dạng này!", 3);
			return;
		}
		string text = F599E0BB.Text;
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n xóa định dạng \"{0}\"?"), text)) == DialogResult.Yes)
		{
			list_2.Remove(text);
			File.WriteAllLines(string_0, list_2);
			E60F5B04();
			F599E0BB.SelectedIndex = ((selectedIndex != 0 || F599E0BB.Items.Count <= 0) ? (selectedIndex - 1) : 0);
		}
	}

	private void fImportAccount_Load(object sender, EventArgs e)
	{
		Commom.EF994A31(string_0);
		list_2 = File.ReadAllText(string_0).Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
		if (list_2.Count == 0)
		{
			list_2 = new List<string>
			{
				"Uid|Pass|2FA",
				"Uid|Pass|2FA|Cookie",
				"Uid|Pass|2FA|Cookie|Token",
				"Uid|Pass|2FA|Cookie|Token|Email|Pass Email",
				"Uid|Pass|2FA|Token|Cookie|Email|Pass Email",
				"Cookie",
				"Uid|Pass",
				"Uid|Pass|Token|Cookie",
				"Uid|Pass|Token|Cookie|Email|Pass Email",
				"Uid|Pass|Token|Cookie|Email|Pass Email|2FA",
				"Uid|Pass|2FA|Email|Pass Email",
				"Uid|Pass|Email|Pass Email",
				"Uid|Pass|Email|Pass Email|2FA",
				"Uid|Pass|2FA|Proxy"
			};
		}
		E60F5B04();
	}

	private void E60F5B04()
	{
		F599E0BB.Items.Clear();
		for (int i = 0; i < list_2.Count; i++)
		{
			F599E0BB.Items.Add(list_2[i]);
		}
		F599E0BB.Items.Add("Other...");
		F599E0BB.SelectedIndex = 0;
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F0073B0C != null)
		{
			F0073B0C.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F0073B0C = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fImportAccount));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A833A81E = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		F2A1DD93 = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnAdd = new System.Windows.Forms.Button();
		btnCancel = new System.Windows.Forms.Button();
		B0B4A28F = new System.Windows.Forms.Label();
		lblError = new System.Windows.Forms.Label();
		A42CBD16 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		E1A35B3E = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		lblAutoDetect = new System.Windows.Forms.Label();
		F599E0BB = new System.Windows.Forms.ComboBox();
		cbbDinhDang1 = new System.Windows.Forms.ComboBox();
		label9 = new System.Windows.Forms.Label();
		B51D9C23 = new System.Windows.Forms.ComboBox();
		DA896BBA = new System.Windows.Forms.Label();
		cbbDinhDang3 = new System.Windows.Forms.ComboBox();
		C22CF997 = new System.Windows.Forms.Label();
		cbbDinhDang4 = new System.Windows.Forms.ComboBox();
		label12 = new System.Windows.Forms.Label();
		AC120E0F = new System.Windows.Forms.ComboBox();
		label13 = new System.Windows.Forms.Label();
		CF2AD935 = new System.Windows.Forms.ComboBox();
		FA12299D = new System.Windows.Forms.Label();
		cbbDinhDang7 = new System.Windows.Forms.ComboBox();
		B08A2B33 = new Bunifu.Framework.UI.BunifuDragControl(F0073B0C);
		ABA8ECBC = new Bunifu.Framework.UI.BunifuDragControl(F0073B0C);
		plDinhDangNhap = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		button3 = new System.Windows.Forms.Button();
		label19 = new System.Windows.Forms.Label();
		FABC8C0F = new System.Windows.Forms.Label();
		DB31B101 = new System.Windows.Forms.Label();
		BAA9680E = new System.Windows.Forms.ComboBox();
		label17 = new System.Windows.Forms.Label();
		cbbDinhDang8 = new System.Windows.Forms.ComboBox();
		cbbDinhDang11 = new System.Windows.Forms.ComboBox();
		cbbDinhDang9 = new System.Windows.Forms.ComboBox();
		E115F8BB = new System.Windows.Forms.Label();
		E525CFBC = new System.Windows.Forms.ComboBox();
		C3217D1C = new System.Windows.Forms.Button();
		txbAccount = new System.Windows.Forms.RichTextBox();
		metroButton1 = new System.Windows.Forms.Button();
		BCAC132C = new System.Windows.Forms.Button();
		panel1 = new System.Windows.Forms.Panel();
		ckbCheckThongTin = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		A833A81E.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		plDinhDangNhap.SuspendLayout();
		panel1.SuspendLayout();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(A833A81E);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(1142, 37);
		bunifuCards1.TabIndex = 11;
		A833A81E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A833A81E.BackColor = System.Drawing.Color.White;
		A833A81E.Controls.Add(pictureBox1);
		A833A81E.Controls.Add(F2A1DD93);
		A833A81E.Controls.Add(bunifuCustomLabel1);
		A833A81E.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A833A81E.Location = new System.Drawing.Point(0, 3);
		A833A81E.Name = "pnlHeader";
		A833A81E.Size = new System.Drawing.Size(1142, 31);
		A833A81E.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		F2A1DD93.Anchor = System.Windows.Forms.AnchorStyles.Right;
		F2A1DD93.Cursor = System.Windows.Forms.Cursors.Hand;
		F2A1DD93.FlatAppearance.BorderSize = 0;
		F2A1DD93.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F2A1DD93.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F2A1DD93.ForeColor = System.Drawing.Color.White;
		F2A1DD93.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		F2A1DD93.Location = new System.Drawing.Point(1110, 2);
		F2A1DD93.Name = "btnMinimize";
		F2A1DD93.Size = new System.Drawing.Size(30, 30);
		F2A1DD93.TabIndex = 9;
		F2A1DD93.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		F2A1DD93.UseVisualStyleBackColor = true;
		F2A1DD93.Click += new System.EventHandler(btnCancel_Click);
		bunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(1104, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Nhập Tài Khoản";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(459, 480);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(107, 31);
		btnAdd.TabIndex = 13;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(AD0EA72A);
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(573, 480);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(107, 31);
		btnCancel.TabIndex = 14;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		B0B4A28F.AutoSize = true;
		B0B4A28F.BackColor = System.Drawing.SystemColors.Control;
		B0B4A28F.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B0B4A28F.ForeColor = System.Drawing.Color.FromArgb(53, 120, 229);
		B0B4A28F.Location = new System.Drawing.Point(106, 51);
		B0B4A28F.Name = "lblSuccess";
		B0B4A28F.Size = new System.Drawing.Size(19, 19);
		B0B4A28F.TabIndex = 23;
		B0B4A28F.Text = "0";
		lblError.AutoSize = true;
		lblError.BackColor = System.Drawing.SystemColors.Control;
		lblError.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblError.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
		lblError.Location = new System.Drawing.Point(528, 51);
		lblError.Name = "lblError";
		lblError.Size = new System.Drawing.Size(19, 19);
		lblError.TabIndex = 24;
		lblError.Text = "0";
		A42CBD16.AutoSize = true;
		A42CBD16.BackColor = System.Drawing.SystemColors.Control;
		A42CBD16.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A42CBD16.ForeColor = System.Drawing.Color.Teal;
		A42CBD16.Location = new System.Drawing.Point(910, 51);
		A42CBD16.Name = "lblTotal";
		A42CBD16.Size = new System.Drawing.Size(19, 19);
		A42CBD16.TabIndex = 26;
		A42CBD16.Text = "0";
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label3.Location = new System.Drawing.Point(22, 53);
		label3.Name = "label3";
		label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
		label3.Size = new System.Drawing.Size(87, 16);
		label3.TabIndex = 34;
		label3.Text = "Tha\u0300nh công:";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label4.Location = new System.Drawing.Point(480, 53);
		label4.Name = "label4";
		label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
		label4.Size = new System.Drawing.Size(52, 16);
		label4.TabIndex = 35;
		label4.Text = "Lỗi:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		E1A35B3E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		E1A35B3E.Location = new System.Drawing.Point(851, 53);
		E1A35B3E.Name = "label7";
		E1A35B3E.RightToLeft = System.Windows.Forms.RightToLeft.No;
		E1A35B3E.Size = new System.Drawing.Size(63, 16);
		E1A35B3E.TabIndex = 38;
		E1A35B3E.Text = "Tô\u0309ng sô\u0301:";
		E1A35B3E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatus.Location = new System.Drawing.Point(12, 86);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(1023, 28);
		lblStatus.TabIndex = 27;
		lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(12, 397);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(102, 16);
		label8.TabIndex = 39;
		label8.Text = "Định dạng nhập:";
		lblAutoDetect.AutoSize = true;
		lblAutoDetect.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblAutoDetect.ForeColor = System.Drawing.Color.ForestGreen;
		lblAutoDetect.Location = new System.Drawing.Point(455, 397);
		lblAutoDetect.Name = "lblAutoDetect";
		lblAutoDetect.Size = new System.Drawing.Size(0, 14);
		lblAutoDetect.TabIndex = 55;
		lblAutoDetect.Text = "";
		F599E0BB.Cursor = System.Windows.Forms.Cursors.Hand;
		F599E0BB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F599E0BB.FormattingEnabled = true;
		F599E0BB.Items.AddRange(new object[7] { "Uid|Pass|2FA", "Cookie", "Uid|Pass", "Uid|Pass|Token|Cookie", "Uid|Pass|Token|Cookie|Email|Pass Email", "Uid|Pass|Token|Cookie|Email|Pass Email|2FA", "Other..." });
		F599E0BB.Location = new System.Drawing.Point(115, 394);
		F599E0BB.Name = "cbbDinhDangNhap";
		F599E0BB.Size = new System.Drawing.Size(269, 24);
		F599E0BB.TabIndex = 40;
		F599E0BB.SelectedIndexChanged += new System.EventHandler(E082AA33);
		cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang1.DropDownWidth = 100;
		cbbDinhDang1.FormattingEnabled = true;
		cbbDinhDang1.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang1.Location = new System.Drawing.Point(3, 3);
		cbbDinhDang1.Name = "cbbDinhDang1";
		cbbDinhDang1.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang1.TabIndex = 40;
		cbbDinhDang1.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Tahoma", 12f);
		label9.Location = new System.Drawing.Point(81, 3);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(15, 19);
		label9.TabIndex = 41;
		label9.Text = "|";
		B51D9C23.Cursor = System.Windows.Forms.Cursors.Hand;
		B51D9C23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		B51D9C23.DropDownWidth = 100;
		B51D9C23.FormattingEnabled = true;
		B51D9C23.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		B51D9C23.Location = new System.Drawing.Point(96, 3);
		B51D9C23.Name = "cbbDinhDang2";
		B51D9C23.Size = new System.Drawing.Size(78, 24);
		B51D9C23.TabIndex = 40;
		B51D9C23.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		DA896BBA.AutoSize = true;
		DA896BBA.Font = new System.Drawing.Font("Tahoma", 12f);
		DA896BBA.Location = new System.Drawing.Point(174, 3);
		DA896BBA.Name = "label10";
		DA896BBA.Size = new System.Drawing.Size(15, 19);
		DA896BBA.TabIndex = 41;
		DA896BBA.Text = "|";
		cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang3.DropDownWidth = 100;
		cbbDinhDang3.FormattingEnabled = true;
		cbbDinhDang3.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang3.Location = new System.Drawing.Point(189, 3);
		cbbDinhDang3.Name = "cbbDinhDang3";
		cbbDinhDang3.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang3.TabIndex = 40;
		cbbDinhDang3.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		C22CF997.AutoSize = true;
		C22CF997.Font = new System.Drawing.Font("Tahoma", 12f);
		C22CF997.Location = new System.Drawing.Point(267, 3);
		C22CF997.Name = "label11";
		C22CF997.Size = new System.Drawing.Size(15, 19);
		C22CF997.TabIndex = 41;
		C22CF997.Text = "|";
		cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang4.DropDownWidth = 100;
		cbbDinhDang4.FormattingEnabled = true;
		cbbDinhDang4.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang4.Location = new System.Drawing.Point(282, 3);
		cbbDinhDang4.Name = "cbbDinhDang4";
		cbbDinhDang4.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang4.TabIndex = 40;
		cbbDinhDang4.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Tahoma", 12f);
		label12.Location = new System.Drawing.Point(360, 3);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(15, 19);
		label12.TabIndex = 41;
		label12.Text = "|";
		AC120E0F.Cursor = System.Windows.Forms.Cursors.Hand;
		AC120E0F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		AC120E0F.DropDownWidth = 100;
		AC120E0F.FormattingEnabled = true;
		AC120E0F.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		AC120E0F.Location = new System.Drawing.Point(375, 3);
		AC120E0F.Name = "cbbDinhDang5";
		AC120E0F.Size = new System.Drawing.Size(78, 24);
		AC120E0F.TabIndex = 40;
		AC120E0F.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Tahoma", 12f);
		label13.Location = new System.Drawing.Point(453, 3);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(15, 19);
		label13.TabIndex = 41;
		label13.Text = "|";
		CF2AD935.Cursor = System.Windows.Forms.Cursors.Hand;
		CF2AD935.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		CF2AD935.DropDownWidth = 100;
		CF2AD935.FormattingEnabled = true;
		CF2AD935.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		CF2AD935.Location = new System.Drawing.Point(468, 3);
		CF2AD935.Name = "cbbDinhDang6";
		CF2AD935.Size = new System.Drawing.Size(78, 24);
		CF2AD935.TabIndex = 40;
		CF2AD935.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		FA12299D.AutoSize = true;
		FA12299D.Font = new System.Drawing.Font("Tahoma", 12f);
		FA12299D.Location = new System.Drawing.Point(546, 3);
		FA12299D.Name = "label14";
		FA12299D.Size = new System.Drawing.Size(15, 19);
		FA12299D.TabIndex = 41;
		FA12299D.Text = "|";
		cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang7.DropDownWidth = 100;
		cbbDinhDang7.FormattingEnabled = true;
		cbbDinhDang7.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang7.Location = new System.Drawing.Point(561, 3);
		cbbDinhDang7.Name = "cbbDinhDang7";
		cbbDinhDang7.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang7.TabIndex = 40;
		cbbDinhDang7.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		B08A2B33.Fixed = true;
		B08A2B33.Horizontal = true;
		B08A2B33.TargetControl = bunifuCustomLabel1;
		B08A2B33.Vertical = true;
		ABA8ECBC.Fixed = true;
		ABA8ECBC.Horizontal = true;
		ABA8ECBC.TargetControl = A833A81E;
		ABA8ECBC.Vertical = true;
		plDinhDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDinhDangNhap.Controls.Add(button2);
		plDinhDangNhap.Controls.Add(button3);
		plDinhDangNhap.Controls.Add(cbbDinhDang1);
		plDinhDangNhap.Controls.Add(B51D9C23);
		plDinhDangNhap.Controls.Add(cbbDinhDang3);
		plDinhDangNhap.Controls.Add(cbbDinhDang4);
		plDinhDangNhap.Controls.Add(label19);
		plDinhDangNhap.Controls.Add(FABC8C0F);
		plDinhDangNhap.Controls.Add(FA12299D);
		plDinhDangNhap.Controls.Add(AC120E0F);
		plDinhDangNhap.Controls.Add(DB31B101);
		plDinhDangNhap.Controls.Add(BAA9680E);
		plDinhDangNhap.Controls.Add(label17);
		plDinhDangNhap.Controls.Add(cbbDinhDang8);
		plDinhDangNhap.Controls.Add(label13);
		plDinhDangNhap.Controls.Add(cbbDinhDang11);
		plDinhDangNhap.Controls.Add(CF2AD935);
		plDinhDangNhap.Controls.Add(cbbDinhDang9);
		plDinhDangNhap.Controls.Add(label12);
		plDinhDangNhap.Controls.Add(cbbDinhDang7);
		plDinhDangNhap.Controls.Add(C22CF997);
		plDinhDangNhap.Controls.Add(label9);
		plDinhDangNhap.Controls.Add(DA896BBA);
		plDinhDangNhap.Location = new System.Drawing.Point(115, 420);
		plDinhDangNhap.Name = "plDinhDangNhap";
		plDinhDangNhap.Size = new System.Drawing.Size(1016, 32);
		plDinhDangNhap.TabIndex = 46;
		button2.BackColor = System.Drawing.Color.DarkOrange;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(379, 35);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(121, 29);
		button2.TabIndex = 43;
		button2.Text = "Reset định dạng";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		button3.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatAppearance.BorderSize = 0;
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.White;
		button3.Location = new System.Drawing.Point(516, 35);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(120, 29);
		button3.TabIndex = 42;
		button3.Text = "Lưu định dạng";
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Tahoma", 12f);
		label19.Location = new System.Drawing.Point(919, 3);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(15, 19);
		label19.TabIndex = 41;
		label19.Text = "|";
		FABC8C0F.AutoSize = true;
		FABC8C0F.Font = new System.Drawing.Font("Tahoma", 12f);
		FABC8C0F.Location = new System.Drawing.Point(732, 3);
		FABC8C0F.Name = "label18";
		FABC8C0F.Size = new System.Drawing.Size(15, 19);
		FABC8C0F.TabIndex = 41;
		FABC8C0F.Text = "|";
		DB31B101.AutoSize = true;
		DB31B101.Font = new System.Drawing.Font("Tahoma", 12f);
		DB31B101.Location = new System.Drawing.Point(826, 5);
		DB31B101.Name = "label1";
		DB31B101.Size = new System.Drawing.Size(15, 19);
		DB31B101.TabIndex = 41;
		DB31B101.Text = "|";
		BAA9680E.Cursor = System.Windows.Forms.Cursors.Hand;
		BAA9680E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		BAA9680E.DropDownWidth = 100;
		BAA9680E.FormattingEnabled = true;
		BAA9680E.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		BAA9680E.Location = new System.Drawing.Point(841, 3);
		BAA9680E.Name = "cbbDinhDang10";
		BAA9680E.Size = new System.Drawing.Size(78, 24);
		BAA9680E.TabIndex = 40;
		BAA9680E.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Tahoma", 12f);
		label17.Location = new System.Drawing.Point(639, 3);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(15, 19);
		label17.TabIndex = 41;
		label17.Text = "|";
		cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang8.DropDownWidth = 100;
		cbbDinhDang8.FormattingEnabled = true;
		cbbDinhDang8.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang8.Location = new System.Drawing.Point(654, 3);
		cbbDinhDang8.Name = "cbbDinhDang8";
		cbbDinhDang8.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang8.TabIndex = 40;
		cbbDinhDang8.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		cbbDinhDang11.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang11.DropDownWidth = 100;
		cbbDinhDang11.FormattingEnabled = true;
		cbbDinhDang11.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang11.Location = new System.Drawing.Point(934, 3);
		cbbDinhDang11.Name = "cbbDinhDang11";
		cbbDinhDang11.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang11.TabIndex = 40;
		cbbDinhDang11.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang9.DropDownWidth = 100;
		cbbDinhDang9.FormattingEnabled = true;
		cbbDinhDang9.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang9.Location = new System.Drawing.Point(747, 3);
		cbbDinhDang9.Name = "cbbDinhDang9";
		cbbDinhDang9.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang9.TabIndex = 40;
		cbbDinhDang9.SelectedIndexChanged += new System.EventHandler(cbbDinhDang9_SelectedIndexChanged);
		E115F8BB.AutoSize = true;
		E115F8BB.Location = new System.Drawing.Point(12, 368);
		E115F8BB.Name = "label16";
		E115F8BB.Size = new System.Drawing.Size(92, 16);
		E115F8BB.TabIndex = 39;
		E115F8BB.Text = "Cho\u0323n thư mu\u0323c:";
		E525CFBC.Cursor = System.Windows.Forms.Cursors.Hand;
		E525CFBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		E525CFBC.DropDownWidth = 269;
		E525CFBC.FormattingEnabled = true;
		E525CFBC.Location = new System.Drawing.Point(115, 365);
		E525CFBC.Name = "cbbThuMuc";
		E525CFBC.Size = new System.Drawing.Size(268, 24);
		E525CFBC.TabIndex = 40;
		E525CFBC.SelectedIndexChanged += new System.EventHandler(A79BA431);
		C3217D1C.Cursor = System.Windows.Forms.Cursors.Hand;
		C3217D1C.Location = new System.Drawing.Point(389, 364);
		C3217D1C.Name = "button1";
		C3217D1C.Size = new System.Drawing.Size(58, 26);
		C3217D1C.TabIndex = 45;
		C3217D1C.Text = "Thêm";
		C3217D1C.UseVisualStyleBackColor = true;
		C3217D1C.Click += new System.EventHandler(FB94D736);
		txbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txbAccount.Location = new System.Drawing.Point(13, 120);
		txbAccount.Name = "txbAccount";
		txbAccount.Size = new System.Drawing.Size(1118, 238);
		txbAccount.TabIndex = 48;
		txbAccount.Text = "";
		txbAccount.WordWrap = false;
		txbAccount.TextChanged += new System.EventHandler(FA29A6BA);
		metroButton1.BackgroundImage = Class155.Bitmap_149;
		metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		metroButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		metroButton1.Location = new System.Drawing.Point(421, 393);
		metroButton1.Name = "metroButton1";
		metroButton1.Size = new System.Drawing.Size(25, 25);
		metroButton1.TabIndex = 50;
		metroButton1.Click += new System.EventHandler(metroButton1_Click);
		BCAC132C.BackgroundImage = (System.Drawing.Image)resources.GetObject("AddFileAccount.BackgroundImage");
		BCAC132C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		BCAC132C.Cursor = System.Windows.Forms.Cursors.Hand;
		BCAC132C.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		BCAC132C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BCAC132C.Location = new System.Drawing.Point(390, 393);
		BCAC132C.Name = "AddFileAccount";
		BCAC132C.Size = new System.Drawing.Size(25, 25);
		BCAC132C.TabIndex = 51;
		BCAC132C.Click += new System.EventHandler(BF2BAC9B);
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(ckbCheckThongTin);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1143, 524);
		panel1.TabIndex = 52;
		ckbCheckThongTin.AutoSize = true;
		ckbCheckThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCheckThongTin.Location = new System.Drawing.Point(12, 455);
		ckbCheckThongTin.Name = "ckbCheckThongTin";
		ckbCheckThongTin.Size = new System.Drawing.Size(255, 20);
		ckbCheckThongTin.TabIndex = 0;
		ckbCheckThongTin.Text = "Check thông tin (Tên, Bạn bè, Ngày tạo)";
		ckbCheckThongTin.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1143, 524);
		base.Controls.Add(lblAutoDetect);
		base.Controls.Add(metroButton1);
		base.Controls.Add(BCAC132C);
		base.Controls.Add(txbAccount);
		base.Controls.Add(plDinhDangNhap);
		base.Controls.Add(C3217D1C);
		base.Controls.Add(E525CFBC);
		base.Controls.Add(F599E0BB);
		base.Controls.Add(E115F8BB);
		base.Controls.Add(label8);
		base.Controls.Add(E1A35B3E);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(lblStatus);
		base.Controls.Add(A42CBD16);
		base.Controls.Add(lblError);
		base.Controls.Add(B0B4A28F);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fImportAccount";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Nhập tài khoản";
		base.Load += new System.EventHandler(fImportAccount_Load);
		bunifuCards1.ResumeLayout(false);
		A833A81E.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		plDinhDangNhap.ResumeLayout(false);
		plDinhDangNhap.PerformLayout();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void EE97DB12()
	{
		btnAdd.Enabled = false;
	}
}
