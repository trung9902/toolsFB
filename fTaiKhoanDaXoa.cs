using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using WindowsFormsControlLibrary1;

public class fTaiKhoanDaXoa : Form
{
	[CompilerGenerated]
	private sealed class B819AA9D
	{
		internal fTaiKhoanDaXoa B092A797;

		internal List<string> list_0;

		internal void EFB3E731()
		{
			try
			{
				string text = "";
				for (int i = 0; i < B092A797.dtgvAcc.RowCount; i++)
				{
					text = B092A797.F31A12A8(i, "cGhiChu");
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
		}
	}

	[CompilerGenerated]
	private sealed class Class51
	{
		internal fTaiKhoanDaXoa EA1D5DAC;

		internal List<string> C21A6D2F;

		internal void method_0()
		{
			try
			{
				string text = "";
				string text2 = "";
				for (int i = 0; i < EA1D5DAC.dtgvAcc.RowCount; i++)
				{
					text = EA1D5DAC.F31A12A8(i, "cStatus").Trim();
					if (text != "")
					{
						text2 = Regex.Match(text, "\\(IP: (.*?)\\)", RegexOptions.Singleline).Value;
						if (text2 != "")
						{
							text = text.Replace(text2, "").Trim();
						}
						text2 = Regex.Match(text, "\\[(.*?)\\]").Value;
						if (text2 != "")
						{
							text = text.Replace(text2, "").Trim();
						}
						if (text != "" && !C21A6D2F.Contains(text))
						{
							C21A6D2F.Add(text);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		internal void method_1()
		{
			try
			{
				string text = "";
				for (int i = 0; i < EA1D5DAC.dtgvAcc.RowCount; i++)
				{
					text = EA1D5DAC.F31A12A8(i, "cInfo");
					if (!text.Equals("") && !C21A6D2F.Contains(text))
					{
						C21A6D2F.Add(text);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class52
	{
		internal string string_0;

		internal fTaiKhoanDaXoa fTaiKhoanDaXoa_0;

		internal void B11D15A0()
		{
			try
			{
				if (string_0 == "start")
				{
					fTaiKhoanDaXoa_0.plQuanLyThuMuc.Enabled = false;
					fTaiKhoanDaXoa_0.F43F0BB3();
				}
				else if (string_0 == "stop")
				{
					fTaiKhoanDaXoa_0.plQuanLyThuMuc.Enabled = true;
					fTaiKhoanDaXoa_0.method_7();
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class BDBD1413
	{
		internal fTaiKhoanDaXoa fTaiKhoanDaXoa_0;

		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal bool D52B39BF;

		internal void D4A77D8B()
		{
			fTaiKhoanDaXoa_0.CA80E69D("start");
			int num = 0;
			while (num < fTaiKhoanDaXoa_0.dtgvAcc.Rows.Count && !fTaiKhoanDaXoa_0.bool_0)
			{
				if (Convert.ToBoolean(fTaiKhoanDaXoa_0.dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						F3B2AD24 CS_0024_003C_003E8__locals0 = new F3B2AD24
						{
							E917768C = this
						};
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_26(CS_0024_003C_003E8__locals0.int_0, Language.GetValue("Đang kiểm tra..."));
							switch (CS_0024_003C_003E8__locals0.E917768C.int_2)
							{
							case 0:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_15(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 1:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_16(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 2:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.E10250B6(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 3:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_17(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 4:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.A38DF985(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 5:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_13(CS_0024_003C_003E8__locals0.int_0, CS_0024_003C_003E8__locals0.E917768C.D52B39BF);
								break;
							case 6:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_18(CS_0024_003C_003E8__locals0.int_0, CS_0024_003C_003E8__locals0.E917768C.D52B39BF);
								break;
							case 7:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_14(CS_0024_003C_003E8__locals0.int_0);
								break;
							case 8:
								CS_0024_003C_003E8__locals0.E917768C.fTaiKhoanDaXoa_0.method_9(CS_0024_003C_003E8__locals0.int_0);
								break;
							}
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.E917768C.int_0);
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
			fTaiKhoanDaXoa_0.CA80E69D("stop");
		}
	}

	[CompilerGenerated]
	private sealed class F3B2AD24
	{
		internal int int_0;

		internal BDBD1413 E917768C;

		internal void method_0()
		{
			E917768C.fTaiKhoanDaXoa_0.method_26(int_0, Language.GetValue("Đang kiểm tra..."));
			switch (E917768C.int_2)
			{
			case 0:
				E917768C.fTaiKhoanDaXoa_0.method_15(int_0);
				break;
			case 1:
				E917768C.fTaiKhoanDaXoa_0.method_16(int_0);
				break;
			case 2:
				E917768C.fTaiKhoanDaXoa_0.E10250B6(int_0);
				break;
			case 3:
				E917768C.fTaiKhoanDaXoa_0.method_17(int_0);
				break;
			case 4:
				E917768C.fTaiKhoanDaXoa_0.A38DF985(int_0);
				break;
			case 5:
				E917768C.fTaiKhoanDaXoa_0.method_13(int_0, E917768C.D52B39BF);
				break;
			case 6:
				E917768C.fTaiKhoanDaXoa_0.method_18(int_0, E917768C.D52B39BF);
				break;
			case 7:
				E917768C.fTaiKhoanDaXoa_0.method_14(int_0);
				break;
			case 8:
				E917768C.fTaiKhoanDaXoa_0.method_9(int_0);
				break;
			}
			Interlocked.Decrement(ref E917768C.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class53
	{
		internal fTaiKhoanDaXoa fTaiKhoanDaXoa_0;

		internal int int_0;

		internal int C727B803;

		internal void method_0()
		{
			fTaiKhoanDaXoa_0.CA80E69D("start");
			int num = 0;
			while (num < fTaiKhoanDaXoa_0.dtgvAcc.Rows.Count)
			{
				Application.DoEvents();
				if (fTaiKhoanDaXoa_0.bool_0)
				{
					break;
				}
				if (Convert.ToBoolean(fTaiKhoanDaXoa_0.dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < C727B803)
					{
						Class54 CS_0024_003C_003E8__locals0 = new Class54
						{
							class53_0 = this
						};
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.class53_0.fTaiKhoanDaXoa_0.method_26(CS_0024_003C_003E8__locals0.int_0, Language.GetValue("Đang kiểm tra..."));
							CS_0024_003C_003E8__locals0.class53_0.fTaiKhoanDaXoa_0.method_20(CS_0024_003C_003E8__locals0.int_0);
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.class53_0.int_0);
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
			fTaiKhoanDaXoa_0.CA80E69D("stop");
		}
	}

	[CompilerGenerated]
	private sealed class Class54
	{
		internal int int_0;

		internal Class53 class53_0;

		internal void method_0()
		{
			class53_0.fTaiKhoanDaXoa_0.method_26(int_0, Language.GetValue("Đang kiểm tra..."));
			class53_0.fTaiKhoanDaXoa_0.method_20(int_0);
			Interlocked.Decrement(ref class53_0.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class B2902916
	{
		internal int B196E72D;

		internal int D330E9BE;

		internal fTaiKhoanDaXoa fTaiKhoanDaXoa_0;

		internal void method_0()
		{
			int num = 0;
			while (num < fTaiKhoanDaXoa_0.dtgvAcc.Rows.Count)
			{
				if (Convert.ToBoolean(fTaiKhoanDaXoa_0.dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (B196E72D < D330E9BE)
					{
						E4357638 CS_0024_003C_003E8__locals0 = new E4357638
						{
							b2902916_0 = this
						};
						Interlocked.Increment(ref B196E72D);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.b2902916_0.fTaiKhoanDaXoa_0.method_26(CS_0024_003C_003E8__locals0.int_0, Language.GetValue("Đang xo\u0301a profile..."));
							CS_0024_003C_003E8__locals0.b2902916_0.fTaiKhoanDaXoa_0.method_21(CS_0024_003C_003E8__locals0.int_0);
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.b2902916_0.B196E72D);
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
		}
	}

	[CompilerGenerated]
	private sealed class E4357638
	{
		internal int int_0;

		internal B2902916 b2902916_0;

		internal void CBBB8C81()
		{
			b2902916_0.fTaiKhoanDaXoa_0.method_26(int_0, Language.GetValue("Đang xo\u0301a profile..."));
			b2902916_0.fTaiKhoanDaXoa_0.method_21(int_0);
			Interlocked.Decrement(ref b2902916_0.B196E72D);
		}
	}

	[CompilerGenerated]
	private sealed class Class55
	{
		internal fTaiKhoanDaXoa D5399727;

		internal int int_0;

		internal int F783DC33;

		internal string A3165B86;

		internal void method_0()
		{
			int num = 0;
			while (num < D5399727.dtgvAcc.RowCount)
			{
				if (Convert.ToBoolean(D5399727.F31A12A8(num, "cChose")))
				{
					if (int_0 < F783DC33)
					{
						AB92D815 CS_0024_003C_003E8__locals0 = new AB92D815
						{
							class55_0 = this
						};
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.class55_0.D5399727.method_26(CS_0024_003C_003E8__locals0.int_0, "Check profile...");
							CS_0024_003C_003E8__locals0.class55_0.D5399727.method_22(CS_0024_003C_003E8__locals0.int_0, CS_0024_003C_003E8__locals0.class55_0.A3165B86);
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.class55_0.int_0);
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
		}
	}

	[CompilerGenerated]
	private sealed class AB92D815
	{
		internal int int_0;

		internal Class55 class55_0;

		internal void method_0()
		{
			class55_0.D5399727.method_26(int_0, "Check profile...");
			class55_0.D5399727.method_22(int_0, class55_0.A3165B86);
			Interlocked.Decrement(ref class55_0.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class56
	{
		internal fTaiKhoanDaXoa fTaiKhoanDaXoa_0;

		internal int int_0;

		internal int int_1;

		internal void method_0()
		{
			fTaiKhoanDaXoa_0.CA80E69D("start");
			int num = 0;
			while (num < fTaiKhoanDaXoa_0.dtgvAcc.Rows.Count)
			{
				Application.DoEvents();
				if (fTaiKhoanDaXoa_0.bool_0)
				{
					break;
				}
				if (Convert.ToBoolean(fTaiKhoanDaXoa_0.dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						A0B1692B CS_0024_003C_003E8__locals0 = new A0B1692B
						{
							E590A6A5 = this
						};
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.E590A6A5.fTaiKhoanDaXoa_0.method_26(CS_0024_003C_003E8__locals0.int_0, Language.GetValue("Đang kiểm tra..."));
							CS_0024_003C_003E8__locals0.E590A6A5.fTaiKhoanDaXoa_0.E80F098D(CS_0024_003C_003E8__locals0.int_0);
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.E590A6A5.int_0);
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
			fTaiKhoanDaXoa_0.CA80E69D("stop");
		}
	}

	[CompilerGenerated]
	private sealed class A0B1692B
	{
		internal int int_0;

		internal Class56 E590A6A5;

		internal void method_0()
		{
			E590A6A5.fTaiKhoanDaXoa_0.method_26(int_0, Language.GetValue("Đang kiểm tra..."));
			E590A6A5.fTaiKhoanDaXoa_0.E80F098D(int_0);
			Interlocked.Decrement(ref E590A6A5.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class57
	{
		internal int EB942ABC;

		internal int int_0;

		internal fTaiKhoanDaXoa BB85E890;

		internal void method_0()
		{
			int num = 0;
			while (num < BB85E890.dtgvAcc.Rows.Count)
			{
				if (Convert.ToBoolean(BB85E890.dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (EB942ABC < int_0)
					{
						Class58 CS_0024_003C_003E8__locals0 = new Class58
						{
							class57_0 = this
						};
						Interlocked.Increment(ref EB942ABC);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							CS_0024_003C_003E8__locals0.class57_0.BB85E890.method_26(CS_0024_003C_003E8__locals0.int_0, Language.GetValue("Đang xo\u0301a Cache Profile..."));
							CS_0024_003C_003E8__locals0.class57_0.BB85E890.method_24(CS_0024_003C_003E8__locals0.int_0);
							Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.class57_0.EB942ABC);
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
		}
	}

	[CompilerGenerated]
	private sealed class Class58
	{
		internal int int_0;

		internal Class57 class57_0;

		internal void DC3B6697()
		{
			class57_0.BB85E890.method_26(int_0, Language.GetValue("Đang xo\u0301a Cache Profile..."));
			class57_0.BB85E890.method_24(int_0);
			Interlocked.Decrement(ref class57_0.EB942ABC);
		}
	}

	internal bool bool_0;

	internal int int_0 = 0;

	internal object object_0 = new object();

	internal int C1A1AC2A = -1;

	internal bool bool_1 = true;

	internal object object_1 = new object();

	internal int int_1 = -1;

	internal bool E3A15AB3 = true;

	internal bool bool_2 = false;

	internal bool bool_3 = false;

	internal int int_2 = 0;

	internal IContainer icontainer_0 = null;

	internal static string string_0 = "";

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards B7A82181;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal Button E0091419;

	internal Button A2164F3A;

	internal Button btnClose;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal MenuStrip E9137420;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ContextMenuStrip EB8F3614;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem liveToolStripMenuItem;

	internal ToolStripMenuItem copyToolStripMenuItem;

	internal ToolStripMenuItem tokenToolStripMenuItem;

	internal ToolStripMenuItem cookieToolStripMenuItem;

	internal ToolStripMenuItem uidPassToolStripMenuItem;

	internal ToolStripMenuItem uidPassTokenCookieToolStripMenuItem;

	internal ToolStripMenuItem C3907130;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem F620C1BC;

	internal ToolStripMenuItem passToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal ToolStripMenuItem mnuChucNang;

	internal ToolStripMenuItem mailPassMailToolStripMenuItem;

	internal ToolStripMenuItem E0997ABE;

	internal ToolStripMenuItem A5ACE00D;

	internal ToolStripMenuItem FBBB02B3;

	internal ToolStripMenuItem toolStripMenuItem_6;

	internal ToolStripMenuItem FBB45DBF;

	internal ToolStripMenuItem uidPassTokenCookieMailPassMail2faToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal ToolStripMenuItem checkProfileToolStripMenuItem;

	internal ToolStripMenuItem F9B7A891;

	internal ToolStripMenuItem tinhTrangToolStripMenuItem;

	internal ToolStripMenuItem locTrungToolStripMenuItem;

	internal ToolStripMenuItem uidPass2FaToolStripMenuItem;

	internal BunifuDragControl bunifuDragControl_1;

	internal ToolStripMenuItem toolStripMenuItem_8;

	internal ToolStripMenuItem D01D698D;

	internal ToolStripMenuItem donDepProfileToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_9;

	internal ToolStripMenuItem AE1837BF;

	internal ToolStripMenuItem proxyToolStripMenuItem1;

	internal ToolStripMenuItem D2BC2A34;

	internal ToolStripMenuItem uidToolStripMenuItem;

	internal ToolStripMenuItem E92BFD1F;

	internal ToolStripMenuItem FFA4A727;

	internal ToolStripMenuItem E4AFF72D;

	internal ToolStripMenuItem checkInfoUIDToolStripMenuItem;

	internal ToolStripMenuItem F4B62128;

	internal ToolStripMenuItem toolStripMenuItem_10;

	internal ToolStripMenuItem FB80C634;

	internal ToolStripMenuItem FA0F873B;

	internal ToolStripMenuItem checkHotmailToolStripMenuItem;

	internal ToolStripMenuItem checkProxyToolStripMenuItem1;

	internal ToolStripMenuItem C637720F;

	internal ToolStripMenuItem checkLiveUidToolStripMenuItem;

	internal ToolStripMenuItem E4B4B4B8;

	internal ToolStripMenuItem emailPassMailMailKpToolStripMenuItem;

	internal StatusStrip miniToolStrip;

	internal ToolStripStatusLabel EA18FB98;

	internal ToolStripStatusLabel lblCountHighline;

	internal ToolStripStatusLabel toolStripStatusLabel5;

	internal ToolStripStatusLabel lblCountSelect;

	internal ToolStripStatusLabel FD1084AF;

	internal ToolStripStatusLabel lblCountTotal;

	internal Panel panel2;

	internal Button BtnSearch;

	internal ComboBox cbbSearch;

	internal BunifuCustomTextbox txbSearch;

	internal Panel plQuanLyThuMuc;

	internal Label D21ECC06;

	internal Label label2;

	internal ComboBox FC271C1A;

	internal ComboBox C9B9DEB1;

	internal Panel panel1;

	internal StatusStrip statusStrip1;

	internal DataGridView dtgvAcc;

	internal ToolStripMenuItem F28E3BAF;

	internal ToolStripMenuItem DA2C0C97;

	internal ToolStripMenuItem toolStripMenuItem_11;

	internal ToolStripMenuItem testSpinTextToolStripMenuItem;

	internal ToolStripMenuItem getTokenEAAAAUToolStripMenuItem;

	internal ToolStripMenuItem getTokenEAAAAUBToolStripMenuItem;

	internal ToolStripMenuItem toolStripMenuItem_12;

	internal ToolStripMenuItem DB3E0301;

	internal ToolStripMenuItem toolStripMenuItem_13;

	internal ToolStripMenuItem toolStripMenuItem_14;

	internal Button btnLoadAcc;

	internal Button A9AE31B9;

	internal Button A18B0B9B;

	internal ToolStripMenuItem toolStripMenuItem_15;

	internal ToolStripMenuItem C919C9A3;

	internal ToolStripMenuItem toolStripMenuItem1;

	internal ToolStripMenuItem BC9B908F;

	internal DataGridViewCheckBoxColumn cChose;

	internal DataGridViewTextBoxColumn C60DF4B6;

	internal DataGridViewTextBoxColumn cId;

	internal DataGridViewTextBoxColumn B4A98981;

	internal DataGridViewTextBoxColumn cToken;

	internal DataGridViewTextBoxColumn cCookies;

	internal DataGridViewTextBoxColumn cEmail;

	internal DataGridViewTextBoxColumn EE0C9538;

	internal DataGridViewTextBoxColumn C79E810B;

	internal DataGridViewTextBoxColumn A5B06D89;

	internal DataGridViewTextBoxColumn A022B99A;

	internal DataGridViewTextBoxColumn cGroup;

	internal DataGridViewTextBoxColumn cPage;

	internal DataGridViewTextBoxColumn cPagePro5;

	internal DataGridViewTextBoxColumn cBirthday;

	internal DataGridViewTextBoxColumn cGender;

	internal DataGridViewTextBoxColumn cPassword;

	internal DataGridViewTextBoxColumn E6213E2C;

	internal DataGridViewTextBoxColumn EB8861A9;

	internal DataGridViewTextBoxColumn cOAuth2;

	internal DataGridViewTextBoxColumn cFa2;

	internal DataGridViewTextBoxColumn CB09DC32;

	internal DataGridViewTextBoxColumn cProxy;

	internal DataGridViewTextBoxColumn cDateCreateAcc;

	internal DataGridViewTextBoxColumn cAvatar;

	internal DataGridViewTextBoxColumn cProfile;

	internal DataGridViewTextBoxColumn cThuMuc;

	internal DataGridViewTextBoxColumn cInteractEnd;

	internal DataGridViewTextBoxColumn cInfo;

	internal DataGridViewTextBoxColumn cGhiChu;

	internal DataGridViewTextBoxColumn cLocation;

	internal DataGridViewTextBoxColumn cHometown;

	internal DataGridViewTextBoxColumn cCurrentCity;

	internal DataGridViewTextBoxColumn F38D180E;

	internal DataGridViewTextBoxColumn cAds;

	internal DataGridViewTextBoxColumn cBM;

	internal DataGridViewTextBoxColumn A808B636;

	internal DataGridViewTextBoxColumn B3BB10B0;

	internal DataGridViewTextBoxColumn AF9E6D03;

	internal DataGridViewTextBoxColumn cDateDelete;

	internal DataGridViewTextBoxColumn E9A8FC92;

	public fTaiKhoanDaXoa()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		base.Icon = Class155.D596C6A5;
		Language.smethod_0(EB8F3614);
		txbSearch.AF8ADE0B();
	}

	protected override void OnLoad(EventArgs FF9E4927)
	{
		Application.Idle += method_0;
	}

	private void method_0(object sender, EventArgs e)
	{
		Application.Idle -= method_0;
		F0AE780E();
		method_31();
		DFAD06A3(1);
		C93D3C03();
		E9137420.Cursor = Cursors.Hand;
	}

	private void F0AE780E()
	{
		Dictionary<string, string> dataSource = new Dictionary<string, string>
		{
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

	private void DFAD06A3(int BABC1E90 = -1)
	{
		bool_1 = false;
		DataTable dataSource = CommonSQL.smethod_1(bool_0: true, bool_1: true);
		FC271C1A.DataSource = dataSource;
		FC271C1A.ValueMember = "id";
		FC271C1A.DisplayMember = "name";
		if (BABC1E90 != -1 && FC271C1A.Items.Count >= BABC1E90)
		{
			FC271C1A.SelectedIndex = BABC1E90;
		}
		else if (FC271C1A.Items.Count == 2)
		{
			FC271C1A.SelectedIndex = -1;
		}
		bool_1 = true;
	}

	private void C93D3C03(List<string> CA2C6308 = null)
	{
		try
		{
			DataTable dataSource = CommonSQL.F314C9A4(CA2C6308, E62F2A92: false);
			C9B9DEB1.DataSource = dataSource;
			C9B9DEB1.ValueMember = "id";
			C9B9DEB1.DisplayMember = "name";
		}
		catch
		{
		}
	}

	private void DCB3320A(object sender, EventArgs e)
	{
		Close();
	}

	private void A2164F3A_Click(object sender, EventArgs e)
	{
		this.E6175915();
	}

	private void ED11D186(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	public void BF0C09AA(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			if (FC271C1A.SelectedValue != null)
			{
				text = FC271C1A.SelectedValue.ToString();
			}
			DFAD06A3();
			if (text != "999999" && text != "-2")
			{
				C1A1AC2A = -1;
				FC271C1A.SelectedValue = text;
				return;
			}
			bool_1 = false;
			FC271C1A.SelectedValue = text;
			bool_1 = true;
			C93D3C03(fChonThuMuc.list_0);
		}
		catch (Exception)
		{
		}
	}

	private List<string> E5927585()
	{
		List<string> result = null;
		try
		{
			string text = FC271C1A.SelectedValue.ToString();
			string text2 = text;
			if (!(text2 == "-2"))
			{
				result = ((text2 == "999999") ? GClass13.C53EB88B(fChonThuMuc.list_0) : new List<string> { FC271C1A.SelectedValue.ToString() });
			}
		}
		catch
		{
		}
		return result;
	}

	private void method_1(List<string> list_0 = null, string string_1 = "")
	{
		try
		{
			dtgvAcc.Rows.Clear();
			if (string_1 == "[Tất cả tình trạng]" || string_1 == Language.GetValue("[Tất cả tình trạng]"))
			{
				string_1 = "";
			}
			DataTable dataTable_ = CommonSQL.A23CD00B(list_0, string_1, bool_0: false);
			method_2(dataTable_);
		}
		catch (Exception)
		{
		}
	}

	private void method_2(DataTable dataTable_0)
	{
		EAB09F19.smethod_4(dtgvAcc, dataTable_0, bool_0: true);
		method_11(0);
		method_30();
		method_10();
	}

	private void CBA0DDB0(string C186E939)
	{
		switch (C186E939)
		{
		case "ToggleCheck":
		{
			for (int k = 0; k < dtgvAcc.SelectedRows.Count; k++)
			{
				int index = dtgvAcc.SelectedRows[k].Index;
				method_27(index, "cChose", !Convert.ToBoolean(F31A12A8(index, "cChose")));
			}
			method_11();
			break;
		}
		case "SelectHighline":
		{
			DataGridViewSelectedRowCollection selectedRows = dtgvAcc.SelectedRows;
			for (int j = 0; j < selectedRows.Count; j++)
			{
				method_27(selectedRows[j].Index, "cChose", true);
			}
			method_11();
			break;
		}
		case "UnAll":
		{
			for (int l = 0; l < dtgvAcc.RowCount; l++)
			{
				method_27(l, "cChose", false);
			}
			method_11(0);
			break;
		}
		case "All":
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				method_27(i, "cChose", true);
			}
			method_11(dtgvAcc.RowCount);
			break;
		}
		}
	}

	private void B328F5A5(string AE9C2AA3)
	{
		if (B3004337())
		{
			try
			{
				List<string> values = D608821A(AE9C2AA3);
				Commom.SetTextToClipboard(string.Join("\r\n", values));
			}
			catch
			{
			}
		}
	}

	private List<string> D608821A(string string_1)
	{
		List<string> list = new List<string>();
		try
		{
			List<string> list2 = string_1.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				List<string> list3 = new List<string>();
				for (int j = 0; j < list2.Count; j++)
				{
					string text = F31A12A8(i, list2[j]);
					if (list2[j] == "cProxy" && text.Length > 2)
					{
						if (text[text.Length - 2].ToString() == "*")
						{
							text = text.Substring(0, text.Length - 2);
						}
					}
					else if (list2[j] == "cMa2Fa")
					{
						text = Commom.smethod_62(F31A12A8(i, "cFa2"));
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

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		CBA0DDB0("All");
	}

	private void liveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CBA0DDB0("SelectHighline");
	}

	private void DC3EEA07(object sender, EventArgs e)
	{
		CBA0DDB0("UnAll");
	}

	private void tokenToolStripMenuItem_Click(object sender, EventArgs e)
	{
		B328F5A5("cToken");
	}

	private void C42F012A(object sender, EventArgs e)
	{
		B328F5A5("cCookies");
	}

	private void BC23123F(object sender, EventArgs e)
	{
		B328F5A5("cUid");
	}

	private void B89FF6A7(object sender, EventArgs e)
	{
		B328F5A5("cPassword");
	}

	private void uidPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		B328F5A5("cUid|cPassword");
	}

	private void uidPassTokenCookieToolStripMenuItem_Click(object sender, EventArgs e)
	{
		B328F5A5("cUid|cPassword|cToken|cCookies");
	}

	private void method_3(object sender, EventArgs e)
	{
		Commom.smethod_35(new fAddFile());
		if (fAddFile.bool_0)
		{
			DFAD06A3();
			FC271C1A.SelectedIndex = FC271C1A.Items.Count - 2;
		}
	}

	private void A31766A9(object sender, CancelEventArgs e)
	{
		FBBB02B3.DropDownItems.Clear();
		List<string> C21A6D2F = new List<string>();
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text2 = "";
				string text3 = "";
				for (int l = 0; l < dtgvAcc.RowCount; l++)
				{
					text2 = F31A12A8(l, "cStatus").Trim();
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
						if (text2 != "" && !C21A6D2F.Contains(text2))
						{
							C21A6D2F.Add(text2);
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
		for (int i = 0; i < C21A6D2F.Count; i++)
		{
			FBBB02B3.DropDownItems.Add(C21A6D2F[i]);
			FBBB02B3.DropDownItems[i].Click += D31BFE3B;
		}
		tinhTrangToolStripMenuItem.DropDownItems.Clear();
		C21A6D2F = new List<string>();
		thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text = "";
				for (int k = 0; k < dtgvAcc.RowCount; k++)
				{
					text = F31A12A8(k, "cInfo");
					if (!text.Equals("") && !C21A6D2F.Contains(text))
					{
						C21A6D2F.Add(text);
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
		for (int j = 0; j < C21A6D2F.Count; j++)
		{
			tinhTrangToolStripMenuItem.DropDownItems.Add(C21A6D2F[j]);
			tinhTrangToolStripMenuItem.DropDownItems[j].Click += method_4;
		}
		toolStripMenuItem_12.DropDownItems.Clear();
		bool_3 = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		method_5("cInfo", (sender as ToolStripMenuItem).Text);
	}

	private void D31BFE3B(object sender, EventArgs e)
	{
		method_5("cStatus", (sender as ToolStripMenuItem).Text);
	}

	private void method_5(string D7B23402, string B53E9627)
	{
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			dtgvAcc.Rows[i].Cells["cChose"].Value = F31A12A8(i, D7B23402).Contains(B53E9627);
		}
		method_11();
	}

	private void method_6(string string_1)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
				}
			}
			if (CommonSQL.smethod_10(list, "idfile", string_1))
			{
				for (int j = 0; j < dtgvAcc.RowCount; j++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
					{
						dtgvAcc.Rows.RemoveAt(j--);
					}
				}
				method_30();
				D58695B5();
				method_11(0);
				method_10();
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

	private void F43F0BB3()
	{
		try
		{
			dtgvAcc.Invoke((MethodInvoker)delegate
			{
				foreach (DataGridViewColumn column in dtgvAcc.Columns)
				{
					column.SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			});
		}
		catch (Exception)
		{
		}
	}

	private void method_7()
	{
		try
		{
			dtgvAcc.Invoke((MethodInvoker)delegate
			{
				foreach (DataGridViewColumn column in dtgvAcc.Columns)
				{
					column.SortMode = DataGridViewColumnSortMode.Automatic;
				}
			});
		}
		catch
		{
		}
	}

	private void method_8(int int_3, string A011479E, string CB84703D, string string_1, int int_4)
	{
		try
		{
			RequestXNet requestXNet = new RequestXNet(CB84703D, ModernUserAgentHub.GetRandomDesktopChrome(), string_1, int_4);
			string text = requestXNet.E58EB99F("https://d.facebook.com/");
			string text2 = requestXNet.method_5();
			if (text2.Contains("checkpoint/disabled"))
			{
				method_26(int_3, A011479E + "Vô hiệu hóa!");
				CE27D30C(int_3, "Checkpoint: vhh");
				D726101C(int_3, 1);
			}
			else if (text2.Contains("828281030927956"))
			{
				string text3 = "956";
				if (Commom.smethod_88(text))
				{
					text3 += "-Bắt đầu";
				}
				else if (Commom.DFBE4C36(text))
				{
					text3 += "-Tìm hiểu thêm";
				}
				method_26(int_3, A011479E + "Checkpoint " + text3 + "!");
				CE27D30C(int_3, "Checkpoint: " + text3);
				D726101C(int_3, 1);
			}
			else if (text2.Contains("1501092823525282"))
			{
				CE27D30C(int_3, "Checkpoint: 282");
				method_26(int_3, A011479E + "Checkpoint 282!");
			}
			else if (text.Contains("facebook.com/login.php") || text.Contains("name=\"login\"") || text.Contains("/login/device-based/validate-pin/"))
			{
				method_26(int_3, A011479E + "No login!");
				D726101C(int_3, 2);
			}
			else if (text2.Contains("facebook.com/gettingstarted") || (text.Contains("href=\"/menu/bookmarks/") && text.Contains("id=\"mbasic_logout_button\"")) || (text.Contains("id=\"MComposer\"") && text.Contains("id=\"MBackNavBar\"")))
			{
				CE27D30C(int_3, "Live");
				method_26(int_3, "Tài khoản live!");
				D726101C(int_3, 2);
			}
			else if (text.Contains("confirmation") && !text.Contains("preconfirmation"))
			{
				method_26(int_3, A011479E + "Novery Live!");
				D726101C(int_3, 2);
			}
			else
			{
				method_26(int_3, A011479E + "Dạng Checkpoint khác!");
				D726101C(int_3, 1);
			}
		}
		catch (Exception)
		{
			method_26(int_3, A011479E + "Không check được!");
		}
	}

	private void method_9(int D53D9524)
	{
		string text = F31A12A8(D53D9524, "cCookies");
		if (text.Trim() == "")
		{
			method_26(D53D9524, Language.GetValue("Cookie trô\u0301ng!"));
			return;
		}
		F31A12A8(D53D9524, "cUseragent").Trim();
		string text2 = "";
		int cE34D = 0;
		if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 9)
		{
			text2 = F31A12A8(D53D9524, "cProxy");
			cE34D = (text2.EndsWith("*1") ? 1 : 0);
			if (text2.EndsWith("*0") || text2.EndsWith("*1"))
			{
				text2 = text2.Substring(0, text2.Length - 2);
			}
		}
		method_26(D53D9524, Language.GetValue("Checking..."));
		try
		{
			RequestXNet requestXNet = new RequestXNet(text, ModernUserAgentHub.GetRandomDesktopChrome(), text2, cE34D);
			string input = requestXNet.E58EB99F("https://d.facebook.com/");
			string value = Regex.Match(text, "c_user=(\\d+)").Groups[1].Value;
			string value2 = Regex.Match(input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
			string value3 = Regex.Match(input, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
			string text3 = "av=" + value + "&__user=" + value + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + value2 + "&jazoest=22037&lsd=" + value3 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern";
			string text4 = "https://www.facebook.com/api/graphql/";
			string d = text3 + "&fb_api_req_friendly_name=useUFACSubmitActionMutation&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + value + "%22%2C%22action%22%3A%22APPEAL_HACKED_DISABLED_OPTIONS_MENU%22%2C%22enrollment_id%22%3Anull%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=6666461530033597";
			input = requestXNet.method_1(text4, d);
			method_26(D53D9524, "Done!");
		}
		catch (Exception)
		{
			method_26(D53D9524, "Fail!");
		}
	}

	private void CA80E69D(string string_1)
	{
		Invoke((MethodInvoker)delegate
		{
			try
			{
				if (string_1 == "start")
				{
					plQuanLyThuMuc.Enabled = false;
					F43F0BB3();
				}
				else if (string_1 == "stop")
				{
					plQuanLyThuMuc.Enabled = true;
					method_7();
				}
			}
			catch (Exception)
			{
			}
		});
	}

	private void dtgvAcc_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyValue == 32)
		{
			CBA0DDB0("ToggleCheck");
		}
	}

	private void E186B800(object sender, EventArgs e)
	{
		BF0C09AA(null, null);
	}

	private void FC271C1A_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_1 || FC271C1A.SelectedValue == null || !B7059719.smethod_0(FC271C1A.SelectedValue.ToString()) || (FC271C1A.SelectedValue.ToString() != "999999" && C1A1AC2A == FC271C1A.SelectedIndex))
		{
			return;
		}
		string text = FC271C1A.SelectedValue.ToString();
		string text2 = text;
		if (!(text2 == "-2"))
		{
			if (!(text2 == "999999"))
			{
				C93D3C03(E5927585());
			}
			else
			{
				Commom.smethod_35(new fChonThuMuc(EB086334: true));
				if (!fChonThuMuc.D3160788 || fChonThuMuc.DA363022 == null || fChonThuMuc.DA363022.Count == 0)
				{
					bool_1 = false;
					FC271C1A.SelectedIndex = ((C1A1AC2A == -1) ? 1 : C1A1AC2A);
					bool_1 = true;
				}
				else
				{
					C93D3C03(fChonThuMuc.DA363022);
				}
			}
		}
		else
		{
			C93D3C03();
		}
		C1A1AC2A = FC271C1A.SelectedIndex;
	}

	private void mailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		B328F5A5("cEmail|cPassMail");
	}

	private void E0997ABE_Click(object sender, EventArgs e)
	{
		B328F5A5("cUid|cPassword|cToken|cCookies|cEmail|cPassMail");
	}

	private void method_10()
	{
		try
		{
			lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
		}
		catch
		{
		}
	}

	private void method_11(int int_3 = -1)
	{
		if (int_3 == -1)
		{
			int_3 = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					int_3++;
				}
			}
		}
		lblCountSelect.Text = int_3.ToString();
	}

	private void method_12(int FF331C0F, bool C88C0FB2 = false)
	{
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		C5034B95.smethod_0("configGeneral").BDB80B23("token");
		bool_0 = false;
		new Thread((ThreadStart)delegate
		{
			CA80E69D("start");
			int num = 0;
			while (num < dtgvAcc.Rows.Count && !bool_0)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_2, Language.GetValue("Đang kiểm tra..."));
							switch (FF331C0F)
							{
							case 0:
								method_15(int_2);
								break;
							case 1:
								method_16(int_2);
								break;
							case 2:
								E10250B6(int_2);
								break;
							case 3:
								method_17(int_2);
								break;
							case 4:
								A38DF985(int_2);
								break;
							case 5:
								method_13(int_2, C88C0FB2);
								break;
							case 6:
								method_18(int_2, C88C0FB2);
								break;
							case 7:
								method_14(int_2);
								break;
							case 8:
								method_9(int_2);
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
			CA80E69D("stop");
		}).Start();
	}

	private void method_13(int int_3, bool bool_4)
	{
		try
		{
			string e72FDB9E = F31A12A8(int_3, "cId");
			string fE2ED = F31A12A8(int_3, "cUid");
			string text = "";
			int num = 0;
			if (bool_4)
			{
				text = F31A12A8(int_3, "cProxy");
				num = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			string text2 = "";
			string text3 = CommonRequest.E083FD83(fE2ED, text, num);
			if (text3.StartsWith("0|"))
			{
				if (CommonRequest.BC9215A7(fE2ED).StartsWith("0|"))
				{
					method_26(int_3, Language.GetValue("Tài khoản Die!"));
					CE27D30C(int_3, "Die");
				}
				else
				{
					method_26(int_3, Language.GetValue("Không check đươ\u0323c!"));
				}
			}
			else if (text3.StartsWith("1|"))
			{
				string[] array = text3.Split('|');
				string text4 = array[1];
				string text5 = array[2];
				string text6 = array[3];
				CommonSQL.smethod_9(e72FDB9E, "name|friends|dateCreateAcc", text4 + "|" + text5 + "|" + text6);
				method_27(int_3, "cName", text4);
				method_27(int_3, "cFriend", text5);
				method_27(int_3, "cDateCreateAcc", text6);
				CE27D30C(int_3, "Live");
				text2 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
				method_26(int_3, text2);
			}
			else
			{
				method_26(int_3, Language.GetValue("Không check đươ\u0323c!"));
			}
		}
		catch
		{
			method_26(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void A38DF985(int int_3)
	{
		try
		{
			string text = F31A12A8(int_3, "cEmail");
			string text2 = F31A12A8(int_3, "cPassMail");
			string text3 = F31A12A8(int_3, "cOAuth2");
			if (text == "" || text2 == "")
			{
				method_26(int_3, Language.GetValue("Không tìm thấy mail!"));
			}
			else if (D831098B.FFA1D7B5(text, text2, text3))
			{
				method_26(int_3, Language.GetValue("Success!"));
				D726101C(int_3, 2);
			}
			else
			{
				method_26(int_3, Language.GetValue("Fail!"));
				D726101C(int_3, 1);
			}
		}
		catch (Exception)
		{
			method_26(int_3, Language.GetValue("Lỗi!"));
		}
	}

	private void method_14(int FFB9F609)
	{
		try
		{
			string text = F31A12A8(FFB9F609, "cName");
			string text2 = "";
			text2 = ((text.Trim() == "") ? Language.GetValue("Không tìm thấy tên!") : ((!Commom.D9AB3B82(text)) ? Language.GetValue("No") : Language.GetValue("Yes")));
			method_26(FFB9F609, text2);
		}
		catch
		{
			method_26(FFB9F609, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_15(int int_3)
	{
		try
		{
			F31A12A8(int_3, "cId");
			string text = F31A12A8(int_3, "cUid");
			string text2 = "";
			string text3 = "";
			string text4 = CommonRequest.BC9215A7(text);
			if (text4.StartsWith("0|"))
			{
				text2 = "Die";
				text3 = "Wall die";
			}
			else if (text4.StartsWith("1|"))
			{
				text2 = "Live";
				text3 = "Wall live";
			}
			else
			{
				text3 = Language.GetValue("Không check được!");
			}
			method_26(int_3, text3);
			if (text2 != "")
			{
				CE27D30C(int_3, text2);
			}
		}
		catch
		{
			method_26(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_16(int C19A9023)
	{
		try
		{
			string text = "";
			F31A12A8(C19A9023, "cId");
			string e6A0553B = F31A12A8(C19A9023, "cCookies");
			string text2 = F31A12A8(C19A9023, "cToken");
			if (text2.Trim() == "")
			{
				method_26(C19A9023, Language.GetValue("Token trô\u0301ng!"));
				return;
			}
			string string_ = F31A12A8(C19A9023, "cUseragent").Trim();
			string text3 = "";
			int dFA = 0;
			if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 9)
			{
				text3 = F31A12A8(C19A9023, "cProxy");
				dFA = (text3.EndsWith("*1") ? 1 : 0);
				if (text3.EndsWith("*0") || text3.EndsWith("*1"))
				{
					text3 = text3.Substring(0, text3.Length - 2);
				}
			}
			string text4 = "";
			if (!CommonRequest.B4B29420(e6A0553B, text2, string_, text3, dFA))
			{
				text4 = "Token die";
			}
			else
			{
				text = "Live";
				text4 = "Token live";
			}
			method_26(C19A9023, text4);
			if (text != "")
			{
				CE27D30C(C19A9023, text);
			}
		}
		catch
		{
			method_26(C19A9023, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void E10250B6(int int_3)
	{
		try
		{
			string text = "";
			F31A12A8(int_3, "cId");
			string text2 = F31A12A8(int_3, "cCookies");
			if (text2.Trim() == "")
			{
				method_26(int_3, Language.GetValue("Cookie trô\u0301ng!"));
				return;
			}
			string string_ = F31A12A8(int_3, "cUseragent").Trim();
			string text3 = "";
			int e6B = 0;
			if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 9)
			{
				text3 = F31A12A8(int_3, "cProxy");
				e6B = (text3.EndsWith("*1") ? 1 : 0);
				if (text3.EndsWith("*0") || text3.EndsWith("*1"))
				{
					text3 = text3.Substring(0, text3.Length - 2);
				}
			}
			string text4 = "";
			if (!CommonRequest.smethod_0(text2, string_, text3, e6B).StartsWith("1|"))
			{
				text4 = "Cookie die";
			}
			else
			{
				text = "Live";
				text4 = "Cookie live";
			}
			method_26(int_3, text4);
			if (text != "")
			{
				CE27D30C(int_3, text);
			}
		}
		catch
		{
			method_26(int_3, Language.GetValue("Không check đươ\u0323c!"));
		}
	}

	private void method_17(int B28B86A7)
	{
		dtgvAcc.Rows[B28B86A7].Cells["cId"].Value.ToString();
		string text = F31A12A8(B28B86A7, "cCookies");
		if (text.Trim() == "")
		{
			method_26(B28B86A7, Language.GetValue("Cookie trô\u0301ng!"));
			return;
		}
		F31A12A8(B28B86A7, "cUseragent").Trim();
		string text2 = "";
		int int_ = 0;
		if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 9)
		{
			text2 = F31A12A8(B28B86A7, "cProxy");
			int_ = (text2.EndsWith("*1") ? 1 : 0);
			if (text2.EndsWith("*0") || text2.EndsWith("*1"))
			{
				text2 = text2.Substring(0, text2.Length - 2);
			}
		}
		method_26(B28B86A7, Language.GetValue("Checking..."));
		method_8(B28B86A7, "", text, text2, int_);
	}

	private void B3249998(object sender, EventArgs e)
	{
		method_12(0);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC("Tính năng này có thể khiến tài khoản bị khóa, bạn vẫn muốn sử dụng?") == DialogResult.Yes)
		{
			method_12(1);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_12(3);
	}

	private void FBB45DBF_Click(object sender, EventArgs e)
	{
		B328F5A5("cEmail");
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
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				string text2 = dtgvAcc.Rows[i].Cells[columnName].Value.ToString();
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
				num = dtgvAcc.CurrentRow.Index;
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
			dtgvAcc.CurrentCell = dtgvAcc.Rows[index2].Cells[columnName];
			dtgvAcc.ClearSelection();
			dtgvAcc.Rows[index2].Selected = true;
		}
		catch (Exception)
		{
		}
	}

	private void uidPassTokenCookieMailPassMail2faToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			B328F5A5("cUid|cPassword|cToken|cCookies|cEmail|cPassMail|cFa2");
		}
	}

	private void D58695B5()
	{
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			method_27(i, "cSTT", i + 1);
		}
	}

	private void D51C0097(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			B328F5A5("cFa2");
		}
	}

	private void toolStripMenuItem_13_Click(object sender, EventArgs e)
	{
		method_12(6);
	}

	private void method_18(int int_3, bool bool_4)
	{
		try
		{
			string text = "";
			int e3839A = 0;
			if (bool_4)
			{
				text = F31A12A8(int_3, "cProxy");
				e3839A = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			string text2 = dtgvAcc.Rows[int_3].Cells["cUid"].Value.ToString();
			switch (CommonRequest.smethod_6(text2, text, e3839A))
			{
			case "2":
				method_26(int_3, Language.GetValue("Không check được!"));
				break;
			case "1":
				method_26(int_3, Language.GetValue("Đa\u0303 co\u0301 avatar!"));
				F8A5990C(int_3, "cAvatar", "Yes", "avatar");
				break;
			case "0":
				method_26(int_3, Language.GetValue("Không co\u0301 avatar!"));
				F8A5990C(int_3, "cAvatar", "No", "avatar");
				break;
			}
		}
		catch
		{
			method_26(int_3, "Lỗi!");
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		int int_0 = 0;
		int C727B803 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		bool_0 = false;
		new Thread((ThreadStart)delegate
		{
			CA80E69D("start");
			int num = 0;
			while (num < dtgvAcc.Rows.Count)
			{
				Application.DoEvents();
				if (bool_0)
				{
					break;
				}
				if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < C727B803)
					{
						Interlocked.Increment(ref int_0);
						int int_ = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_, Language.GetValue("Đang kiểm tra..."));
							method_20(int_);
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
			CA80E69D("stop");
		}).Start();
	}

	private void method_20(int B10F1D28)
	{
		string text = dtgvAcc.Rows[B10F1D28].Cells["cCookies"].Value.ToString();
		dtgvAcc.Rows[B10F1D28].Cells["cId"].Value.ToString();
		string string_ = F31A12A8(B10F1D28, "cUseragent").Trim();
		string text2 = "";
		int e6B = 0;
		if (C5034B95.smethod_0("configGeneral").method_2("ip_iTypeChangeIp") == 9)
		{
			text2 = F31A12A8(B10F1D28, "cProxy");
			e6B = (text2.EndsWith("*1") ? 1 : 0);
			if (text2.EndsWith("*0") || text2.EndsWith("*1"))
			{
				text2 = text2.Substring(0, text2.Length - 2);
			}
		}
		string text3 = "";
		if (text == "")
		{
			text3 = "Cookie trống!";
		}
		else
		{
			string text4 = CommonRequest.smethod_0(text, string_, text2, e6B);
			if (text4.Split('|')[0] == "1")
			{
				text3 = ((!(text4.Split('|')[1] == "1")) ? (text3 + Language.GetValue("Chưa veri!")) : (text3 + Language.GetValue("Đa\u0303 veri!")));
			}
			else if (text4.Split('|')[0] == "0")
			{
				text3 += "Cookie Die!";
			}
			else if (text4.Split('|')[0] == "2")
			{
				text3 += Language.GetValue("Lô\u0303i khi check!");
			}
		}
		method_26(B10F1D28, text3);
	}

	private void locTrungToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					string item = F31A12A8(i, "cUid");
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
			List<string> list_ = Commom.smethod_30(list);
			DataTable dataTable = CommonSQL.FAACE83A(list_, bool_0: false);
			dataTable.DefaultView.Sort = "uid ASC";
			dataTable = dataTable.DefaultView.ToTable();
			dtgvAcc.Rows.Clear();
			method_2(dataTable);
		}
		catch (Exception)
		{
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có chắc muốn xóa Profile của {0} tài khoản?"), method_23())) != DialogResult.Yes)
		{
			return;
		}
		int B196E72D = 0;
		int D330E9BE = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < dtgvAcc.Rows.Count)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (B196E72D < D330E9BE)
					{
						Interlocked.Increment(ref B196E72D);
						int int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_0, Language.GetValue("Đang xo\u0301a profile..."));
							method_21(int_0);
							Interlocked.Decrement(ref B196E72D);
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
		}).Start();
	}

	private void method_21(int int_3)
	{
		try
		{
			string c5A80B = dtgvAcc.Rows[int_3].Cells["cId"].Value.ToString();
			string text = dtgvAcc.Rows[int_3].Cells["cUid"].Value.ToString();
			if (text.Trim() == "")
			{
				method_26(int_3, Language.GetValue("Chưa tạo profile!"));
				return;
			}
			string path = C5034B95.smethod_2() + "\\" + text;
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
				method_26(int_3, Language.GetValue("Xóa profile thành công!"));
				method_27(int_3, "cProfile", "No");
				CommonSQL.B8A0E617(c5A80B, "profile", "No");
			}
			else
			{
				method_26(int_3, Language.GetValue("Chưa tạo profile!"));
			}
		}
		catch
		{
			method_26(int_3, Language.GetValue("Xóa profile thất bại!"));
		}
	}

	private void checkProfileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int int_0 = 0;
		int F783DC33 = 10;
		string A3165B86 = C5034B95.smethod_2();
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < dtgvAcc.RowCount)
			{
				if (Convert.ToBoolean(F31A12A8(num, "cChose")))
				{
					if (int_0 < F783DC33)
					{
						Interlocked.Increment(ref int_0);
						int int_ = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_, "Check profile...");
							method_22(int_, A3165B86);
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
		}).Start();
	}

	private void method_22(int int_3, string AA212529)
	{
		try
		{
			string c5A80B = F31A12A8(int_3, "cId");
			string text = F31A12A8(int_3, "cUid");
			AA212529 = AA212529 + "\\" + text;
			if (Directory.Exists(AA212529))
			{
				method_26(int_3, Language.GetValue("Đã có profile!"));
				method_27(int_3, "cProfile", "Yes");
				CommonSQL.B8A0E617(c5A80B, "profile", "Yes");
			}
			else
			{
				method_26(int_3, Language.GetValue("Chưa tạo profile!"));
				method_27(int_3, "cProfile", "No");
				CommonSQL.B8A0E617(c5A80B, "profile", "No");
			}
		}
		catch
		{
		}
	}

	private void donDepProfileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			Commom.smethod_35(new fClearProfile());
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show(ex.ToString(), 3);
		}
	}

	private void pictureBox1_DoubleClick(object sender, EventArgs e)
	{
		Commom.KillProcess("chrome");
	}

	private void C4110533(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	private void uidPass2FaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Base.smethod_3())
		{
			B328F5A5("cUid|cPassword|cFa2");
		}
	}

	private void F698B402(object sender, EventArgs e)
	{
		GClass4 gclass4_ = new GClass4();
		Commom.smethod_35(new fCauHinhChung(ref gclass4_));
		if (gclass4_.method_3("isChangePathDatabase"))
		{
			DFAD06A3();
			C1A1AC2A = -1;
			FC271C1A.SelectedIndex = -1;
			FC271C1A.SelectedIndex = 0;
		}
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = D608821A("cUid|cPassword|cToken|cCookies|cEmail|cEmail2|cPassMail|cFa2|cUseragent|cProxy|cName|cGender|cFollow|cFriend|cGroup|cBirthday|cDateCreateAcc|cGhiChu|cLocation|cMailRecovery|cInteractEnd|cDating|cAds|cBM");
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

	private void F20D71AC(object sender, EventArgs e)
	{
		B328F5A5("cMa2Fa");
	}

	private void F6306896(object sender, EventArgs e)
	{
	}

	private void dtgvAcc_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		EAB09F19.smethod_5(e);
	}

	private void toolStripMenuItem_9_Click(object sender, EventArgs e)
	{
		string text = C5034B95.smethod_0("configDatagridview").ED11179C();
		Commom.smethod_35(new fCauHinhHienThi());
		if (C5034B95.smethod_0("configDatagridview").ED11179C() != text)
		{
			method_31();
		}
	}

	private void FFA4A727_Click(object sender, EventArgs e)
	{
		int int_0 = 0;
		int int_1 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		bool_0 = false;
		new Thread((ThreadStart)delegate
		{
			CA80E69D("start");
			int num = 0;
			while (num < dtgvAcc.Rows.Count)
			{
				Application.DoEvents();
				if (bool_0)
				{
					break;
				}
				if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int int_2 = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_2, Language.GetValue("Đang kiểm tra..."));
							E80F098D(int_2);
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
			CA80E69D("stop");
		}).Start();
	}

	private void E80F098D(int int_3)
	{
		try
		{
			string text = dtgvAcc.Rows[int_3].Cells["cProxy"].Value.ToString();
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
				method_26(int_3, "Proxy Die!");
			}
			else
			{
				method_26(int_3, "Proxy Live!");
			}
		}
		catch
		{
			method_26(int_3, "Lỗi!");
		}
	}

	private void E738DCA5(object sender, EventArgs e)
	{
		B328F5A5("cUseragent");
	}

	private void F1074A32(object sender, EventArgs e)
	{
		B328F5A5("cProxy");
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Alt)
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

	private void C9B9DEB1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!E3A15AB3 || C9B9DEB1.SelectedValue == null || !B7059719.smethod_0(C9B9DEB1.SelectedValue.ToString()) || (C9B9DEB1.SelectedValue.ToString() != "-1" && int_1 == C9B9DEB1.SelectedIndex))
		{
			return;
		}
		string text = FC271C1A.SelectedValue.ToString();
		string text2 = text;
		if (!(text2 == "-2"))
		{
			if (!(text2 == "999999"))
			{
				method_1(E5927585(), C9B9DEB1.Text);
			}
			else
			{
				method_1(fChonThuMuc.DA363022, C9B9DEB1.Text);
			}
		}
		else
		{
			method_1(null, C9B9DEB1.Text);
		}
		int_1 = C9B9DEB1.SelectedIndex;
	}

	private void D2BC2A34_Click(object sender, EventArgs e)
	{
		method_12(4);
	}

	public int method_23()
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

	private bool B3004337()
	{
		if (method_23() == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn tài khoản muốn sử dụng chức năng này!", 3);
			return false;
		}
		return true;
	}

	private void BB97463A(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có chắc muốn xóa Cache Profile của {0} tài khoản?"), method_23())) != DialogResult.Yes)
		{
			return;
		}
		int EB942ABC = 0;
		int int_0 = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
		new Thread((ThreadStart)delegate
		{
			int num = 0;
			while (num < dtgvAcc.Rows.Count)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
				{
					if (EB942ABC < int_0)
					{
						Interlocked.Increment(ref EB942ABC);
						int int_ = num++;
						new Thread((ThreadStart)delegate
						{
							method_26(int_, Language.GetValue("Đang xo\u0301a Cache Profile..."));
							method_24(int_);
							Interlocked.Decrement(ref EB942ABC);
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
		}).Start();
	}

	private void method_24(int int_3)
	{
		try
		{
			dtgvAcc.Rows[int_3].Cells["cId"].Value.ToString();
			string text = dtgvAcc.Rows[int_3].Cells["cUid"].Value.ToString();
			if (text.Trim() == "")
			{
				method_26(int_3, Language.GetValue("Chưa tạo profile!"));
				return;
			}
			string text2 = C5034B95.smethod_2() + "\\" + text;
			if (Directory.Exists(text2))
			{
				Commom.DeleteFolder(text2 + "\\Default\\Cache");
				Commom.DeleteFolder(text2 + "\\Default\\Code Cache");
				Commom.DeleteFolder(text2 + "\\OptimizationGuidePredictionModels");
				Commom.DeleteFolder(text2 + "\\Default\\optimization_guide_prediction_model_downloads");
				Commom.DeleteFolder(text2 + "\\SwReporter");
				Commom.DeleteFolder(text2 + "\\pnacl");
				method_26(int_3, Language.GetValue("Xóa Cache Profile thành công!"));
			}
			else
			{
				method_26(int_3, Language.GetValue("Chưa tạo profile!"));
			}
		}
		catch
		{
			method_26(int_3, Language.GetValue("Xóa Cache Profile thất bại!"));
		}
	}

	private void FB80C634_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchLocTrung());
	}

	private void D7058035(object sender, EventArgs e)
	{
		try
		{
			Process.Start("chrome.exe", "https://app.minsoftware.vn/textfree.html");
		}
		catch
		{
			Process.Start("https://app.minsoftware.vn/textfree.html");
		}
	}

	private void C3907130_Click(object sender, EventArgs e)
	{
	}

	private void checkHotmailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckImapHotmail());
	}

	private void dtgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex > -1)
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
				method_11();
			}
		}
		catch
		{
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		List<string> list = E5927585();
		if (list != null && list.Count == 1)
		{
			fEditFile fEditFile2 = new fEditFile(list[0], FC271C1A.Text);
			fEditFile2.ShowInTaskbar = false;
			fEditFile2.ShowDialog();
			int selectedIndex = FC271C1A.SelectedIndex;
			if (fEditFile2.bool_0)
			{
				DFAD06A3();
				C1A1AC2A = -1;
				FC271C1A.SelectedIndex = selectedIndex;
			}
		}
	}

	private void checkProxyToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckProxy());
	}

	private void C637720F_Click(object sender, EventArgs e)
	{
		fLocTheoDanhSachUid fLocTheoDanhSachUid2 = new fLocTheoDanhSachUid();
		Commom.smethod_35(fLocTheoDanhSachUid2);
		if (fLocTheoDanhSachUid2.list_0.Count > 0)
		{
			List<string> list_ = Commom.smethod_30(fLocTheoDanhSachUid2.list_0);
			DataTable dataTable_ = CommonSQL.FAACE83A(list_, bool_0: false);
			dtgvAcc.Rows.Clear();
			method_2(dataTable_);
		}
	}

	public void method_26(int int_3, string string_1, int int_4 = -1)
	{
		switch (int_4)
		{
		default:
			EAB09F19.A00F6EA9(dtgvAcc, int_3, "cStatus", int_4, string_1);
			break;
		case -1:
			EAB09F19.smethod_3(dtgvAcc, int_3, "cStatus", string_1);
			break;
		case 0:
			break;
		}
	}

	public void DA9FF5BE(int int_3, string AD0603BF, int int_4, int int_5)
	{
		int int_6 = Base.rd.Next(int_4, int_5 + 1);
		method_26(int_3, AD0603BF, int_6);
	}

	public void CE27D30C(int CE386F37, string AF803A9A)
	{
		EAB09F19.smethod_3(dtgvAcc, CE386F37, "cInfo", AF803A9A);
		method_30(CE386F37);
		CommonSQL.B8A0E617(F31A12A8(CE386F37, "cId"), "info", AF803A9A);
	}

	public void method_27(int int_3, string C703A216, object D6890698, bool bool_4 = true)
	{
		if ((!(C703A216 == "cUid") || !(D6890698.ToString().Trim() == "")) && (bool_4 || !(D6890698.ToString().Trim() == "")))
		{
			EAB09F19.smethod_3(dtgvAcc, int_3, C703A216, D6890698);
		}
	}

	public void method_28(string string_1, string string_2, int C5AF8515, string F7AD260D, string string_3, bool bool_4 = true)
	{
		if ((bool_4 || !(string_3.ToString().Trim() == "")) && !(string_3 == "-2"))
		{
			EAB09F19.smethod_3(dtgvAcc, C5AF8515, F7AD260D, string_3);
			CommonSQL.B8A0E617(string_1, string_2, string_3);
		}
	}

	public void F8A5990C(int D1AC97B6, string EE057585, string E4024F2A, string string_1, bool bool_4 = true)
	{
		method_28(F31A12A8(D1AC97B6, "cId"), string_1, D1AC97B6, EE057585, E4024F2A, bool_4);
	}

	public string method_29(int int_3)
	{
		return EAB09F19.E2A1ED2F(dtgvAcc, int_3, "cInfo");
	}

	public string F31A12A8(int int_3, string E138FFBC)
	{
		return EAB09F19.E2A1ED2F(dtgvAcc, int_3, E138FFBC);
	}

	private void method_30(int int_3 = -1)
	{
		EAB09F19.EBB59018(dtgvAcc, int_3);
	}

	private void D726101C(int int_3, int D8A3A800)
	{
		EAB09F19.smethod_1(dtgvAcc, int_3, D8A3A800);
	}

	private void method_31()
	{
		dtgvAcc.Columns["cToken"].Visible = C5034B95.smethod_0("configDatagridview").method_3("cToken");
		dtgvAcc.Columns["cCookies"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbCookie");
		dtgvAcc.Columns["cEmail"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbEmail");
		dtgvAcc.Columns["cName"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbTen");
		dtgvAcc.Columns["cFriend"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbBanBe");
		dtgvAcc.Columns["cGroup"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNhom");
		dtgvAcc.Columns["cPage"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPage");
		dtgvAcc.Columns["cPagePro5"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPagePro5");
		dtgvAcc.Columns["cBirthday"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNgaySinh");
		dtgvAcc.Columns["cGender"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbGioiTinh");
		dtgvAcc.Columns["cPassword"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhau");
		dtgvAcc.Columns["cPassMail"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhauMail");
		dtgvAcc.Columns["cOAuth2"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbOAuth2");
		dtgvAcc.Columns["cFa2"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMa2FA");
		dtgvAcc.Columns["cUseragent"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbUseragent");
		dtgvAcc.Columns["cProxy"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbProxy");
		dtgvAcc.Columns["cDateCreateAcc"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbNgayTao");
		dtgvAcc.Columns["cAvatar"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbAvatar");
		dtgvAcc.Columns["cProfile"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbProfile");
		dtgvAcc.Columns["cInfo"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbTinhTrang");
		dtgvAcc.Columns["cThuMuc"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbThuMuc");
		dtgvAcc.Columns["cGhiChu"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbGhiChu");
		dtgvAcc.Columns["cFollow"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbFollow");
		dtgvAcc.Columns["cInteractEnd"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbInteractEnd");
		dtgvAcc.Columns["cMailRecovery"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbMailRecovery");
		dtgvAcc.Columns["cPhone"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbPhone");
		dtgvAcc.Columns["cHometown"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbHometown");
		dtgvAcc.Columns["cCurrentCity"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbCurrentCity");
		dtgvAcc.Columns["cJob"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbJob");
		dtgvAcc.Columns["cLocation"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbLocation");
		dtgvAcc.Columns["cDating"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbDating");
		dtgvAcc.Columns["cAds"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbAds");
		dtgvAcc.Columns["cBM"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbBM");
		dtgvAcc.Columns["cWallPosts"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbWallPosts");
		dtgvAcc.Columns["cFbBlock"].Visible = C5034B95.smethod_0("configDatagridview").method_3("ckbFbBlock");
	}

	private void BE84E183(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_2 && e.ColumnIndex == 0)
		{
			method_11();
		}
	}

	private void FAADCFAD(string A0BA47A4)
	{
		Commom.smethod_35(new fSelectFolder());
		string text = fSelectFolder.string_0;
		if (text == "")
		{
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < dtgvAcc.Rows.Count; i++)
		{
			try
			{
				if (Convert.ToBoolean(F31A12A8(i, "cChose")))
				{
					string text2 = F31A12A8(i, "cUid");
					list.Add(A0BA47A4 + "\\" + text2 + "|" + text + "\\" + text2);
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

	private void BABB58AE(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckLiveUid());
	}

	private void E4B4B4B8_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fContact());
	}

	private void dtgvAcc_SelectionChanged(object sender, EventArgs e)
	{
		lblCountHighline.Text = dtgvAcc.SelectedRows.Count.ToString();
	}

	private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex > -1)
		{
			try
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
				method_11();
			}
			catch
			{
			}
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
			{
				dtgvAcc.Rows.RemoveAt(i--);
			}
		}
		D58695B5();
		method_10();
		method_11(0);
	}

	private void CFB3A8A1(object sender, EventArgs e)
	{
		B328F5A5("cEmail|cPassMail|cMailRecovery");
	}

	private void txbSearch_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			BtnSearch_Click(null, null);
		}
	}

	private void AF84633F(object sender, EventArgs e)
	{
		method_12(5);
	}

	private void DA2C0C97_Click(object sender, EventArgs e)
	{
		method_12(5, C88C0FB2: true);
	}

	private void toolStripMenuItem_11_Click(object sender, EventArgs e)
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
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				string text = F31A12A8(i, "cEmail");
				if (text != "" && text.Contains("@"))
				{
					text = text.Substring(text.IndexOf('@'));
					method_27(i, "cChose", list.Contains(text));
				}
			}
		}
		else
		{
			for (int j = 0; j < dtgvAcc.RowCount; j++)
			{
				string item = F31A12A8(j, "cUid");
				string item2 = F31A12A8(j, "cEmail");
				method_27(j, "cChose", list.Contains(item) || list.Contains(item2));
			}
		}
		method_11();
	}

	private void pnlHeader_DoubleClick(object sender, EventArgs e)
	{
		this.E6175915();
	}

	private void testSpinTextToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchTestSpinContent());
	}

	private void toolStripMenuItem_12_MouseEnter(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			return;
		}
		bool_3 = false;
		toolStripMenuItem_12.DropDownItems.Clear();
		List<string> list_0 = new List<string>();
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				string text = "";
				for (int j = 0; j < dtgvAcc.RowCount; j++)
				{
					text = F31A12A8(j, "cGhiChu");
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
		if (!thread.Join(5000))
		{
			thread.Abort();
		}
		for (int i = 0; i < list_0.Count; i++)
		{
			toolStripMenuItem_12.DropDownItems.Add(list_0[i]);
			toolStripMenuItem_12.DropDownItems[i].Click += method_33;
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		method_5("cGhiChu", (sender as ToolStripMenuItem).Text);
	}

	private void D21AA71F(object sender, EventArgs e)
	{
		Commom.smethod_35(new fTienIchCheckStatusXProxy());
	}

	private void B7A26812(object sender, EventArgs e)
	{
		method_12(6, C88C0FB2: true);
	}

	private void CFAE8F35(object sender, EventArgs e)
	{
		int_2++;
		if (int_2 >= 3)
		{
			int_2 = 0;
			new fCauHinhDebug().ShowDialog();
		}
	}

	private void A18B0B9B_Click(object sender, EventArgs e)
	{
		method_34();
	}

	private void method_34()
	{
		if (!B3004337())
		{
			return;
		}
		Commom.smethod_35(new fCauHinhKhoiPhucTaiKhoan());
		if (fCauHinhKhoiPhucTaiKhoan.B53B3334)
		{
			try
			{
				if (fCauHinhKhoiPhucTaiKhoan.int_0 == 0)
				{
					List<string> list = new List<string>();
					List<string> list2 = new List<string>();
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
						{
							string text = EAB09F19.E2A1ED2F(dtgvAcc, i, "cId");
							string item = CommonSQL.smethod_16(text);
							list.Add(text);
							list2.Add(item);
							dtgvAcc.Rows.RemoveAt(i--);
						}
					}
					D58695B5();
					CommonSQL.F31E3E8E(list2, "active", "1");
					if (CommonSQL.smethod_10(list, "active", "1"))
					{
						MsBoxHelper.Show(string.Format(Language.GetValue("Đa\u0303 khôi phu\u0323c tha\u0300nh công {0} ta\u0300i khoa\u0309n!"), list.Count));
					}
					else
					{
						MsBoxHelper.Show("Lô\u0303i khôi phu\u0323c ta\u0300i khoa\u0309n, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
					}
				}
				else
				{
					string string_ = fCauHinhKhoiPhucTaiKhoan.string_0;
					List<string> list3 = new List<string>();
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							string item2 = EAB09F19.E2A1ED2F(dtgvAcc, j, "cId");
							list3.Add(item2);
							dtgvAcc.Rows.RemoveAt(j--);
						}
					}
					D58695B5();
					if (CommonSQL.smethod_10(list3, "idFile", string_) && CommonSQL.smethod_10(list3, "active", "1"))
					{
						MsBoxHelper.Show(string.Format(Language.GetValue("Đa\u0303 khôi phu\u0323c tha\u0300nh công {0} ta\u0300i khoa\u0309n!"), list3.Count));
					}
					else
					{
						MsBoxHelper.Show("Lô\u0303i khôi phu\u0323c ta\u0300i khoa\u0309n, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
					}
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "Khoi Phuc Tai Khoan");
			}
		}
		method_10();
		method_11();
	}

	private void D4160C96()
	{
		if (!B3004337())
		{
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
			{
				list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
			}
		}
		if (list.Count == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn tài khoản cần xóa!", 3);
			return;
		}
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có thực sự muốn xóa {0} tài khoản đã chọn?"), list.Count) + "\r\n\r\n" + Language.GetValue("Chu\u0301 y\u0301: Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a thi\u0300 không thê\u0309 khôi phu\u0323c la\u0323i đươ\u0323c nư\u0303a!")) == DialogResult.Yes)
		{
			if (!CommonSQL.smethod_14(list, bool_0: true))
			{
				MsBoxHelper.Show("Xóa thất bại, vui lòng thử lại sau!", 2);
				return;
			}
			for (int j = 0; j < dtgvAcc.RowCount; j++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
				{
					dtgvAcc.Rows.RemoveAt(j--);
				}
			}
			CommonSQL.smethod_7();
			D58695B5();
		}
		method_10();
		method_11();
	}

	private void A9AE31B9_Click(object sender, EventArgs e)
	{
		D4160C96();
	}

	private void toolStripMenuItem_15_Click(object sender, EventArgs e)
	{
		method_34();
	}

	private void A9B6791B(object sender, EventArgs e)
	{
		D4160C96();
	}

	private void toolStripMenuItem1_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
			{
				dtgvAcc.Rows.RemoveAt(i--);
			}
		}
		D58695B5();
		method_10();
		method_11(0);
	}

	private void D8A21F3C(object sender, EventArgs e)
	{
		for (int i = 0; i < dtgvAcc.RowCount; i++)
		{
			if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
			{
				dtgvAcc.Rows.RemoveAt(i--);
			}
		}
		D58695B5();
		method_10();
	}

	protected override void Dispose(bool AB26B3BC)
	{
		if (AB26B3BC && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(AB26B3BC);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTaiKhoanDaXoa));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		EB8F3614 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		tinhTrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		FBBB02B3 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_11 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_12 = new System.Windows.Forms.ToolStripMenuItem();
		F620C1BC = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		BC9B908F = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_15 = new System.Windows.Forms.ToolStripMenuItem();
		C919C9A3 = new System.Windows.Forms.ToolStripMenuItem();
		copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		uidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		cookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		FBB45DBF = new System.Windows.Forms.ToolStripMenuItem();
		F9B7A891 = new System.Windows.Forms.ToolStripMenuItem();
		D01D698D = new System.Windows.Forms.ToolStripMenuItem();
		uidPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		uidPass2FaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		mailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		emailPassMailMailKpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		uidPassTokenCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		E0997ABE = new System.Windows.Forms.ToolStripMenuItem();
		uidPassTokenCookieMailPassMail2faToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		AE1837BF = new System.Windows.Forms.ToolStripMenuItem();
		proxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_8 = new System.Windows.Forms.ToolStripMenuItem();
		C3907130 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_6 = new System.Windows.Forms.ToolStripMenuItem();
		checkInfoUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		F28E3BAF = new System.Windows.Forms.ToolStripMenuItem();
		DA2C0C97 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_4 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
		E92BFD1F = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_13 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_14 = new System.Windows.Forms.ToolStripMenuItem();
		E4AFF72D = new System.Windows.Forms.ToolStripMenuItem();
		D2BC2A34 = new System.Windows.Forms.ToolStripMenuItem();
		FFA4A727 = new System.Windows.Forms.ToolStripMenuItem();
		mnuChucNang = new System.Windows.Forms.ToolStripMenuItem();
		C637720F = new System.Windows.Forms.ToolStripMenuItem();
		locTrungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		A5ACE00D = new System.Windows.Forms.ToolStripMenuItem();
		checkProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_7 = new System.Windows.Forms.ToolStripMenuItem();
		donDepProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		F4B62128 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_5 = new System.Windows.Forms.ToolStripMenuItem();
		getTokenEAAAAUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		getTokenEAAAAUBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E0091419 = new System.Windows.Forms.Button();
		A2164F3A = new System.Windows.Forms.Button();
		btnClose = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		B7A82181 = new Bunifu.Framework.UI.BunifuCards();
		E9137420 = new System.Windows.Forms.MenuStrip();
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_9 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_10 = new System.Windows.Forms.ToolStripMenuItem();
		checkLiveUidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		checkProxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		checkHotmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		FB80C634 = new System.Windows.Forms.ToolStripMenuItem();
		FA0F873B = new System.Windows.Forms.ToolStripMenuItem();
		DB3E0301 = new System.Windows.Forms.ToolStripMenuItem();
		testSpinTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		E4B4B4B8 = new System.Windows.Forms.ToolStripMenuItem();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		btnLoadAcc = new System.Windows.Forms.Button();
		miniToolStrip = new System.Windows.Forms.StatusStrip();
		EA18FB98 = new System.Windows.Forms.ToolStripStatusLabel();
		lblCountHighline = new System.Windows.Forms.ToolStripStatusLabel();
		toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
		lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
		FD1084AF = new System.Windows.Forms.ToolStripStatusLabel();
		lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
		panel2 = new System.Windows.Forms.Panel();
		BtnSearch = new System.Windows.Forms.Button();
		cbbSearch = new System.Windows.Forms.ComboBox();
		txbSearch = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
		plQuanLyThuMuc = new System.Windows.Forms.Panel();
		C9B9DEB1 = new System.Windows.Forms.ComboBox();
		D21ECC06 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		FC271C1A = new System.Windows.Forms.ComboBox();
		panel1 = new System.Windows.Forms.Panel();
		A9AE31B9 = new System.Windows.Forms.Button();
		A18B0B9B = new System.Windows.Forms.Button();
		statusStrip1 = new System.Windows.Forms.StatusStrip();
		dtgvAcc = new System.Windows.Forms.DataGridView();
		cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		C60DF4B6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		B4A98981 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cCookies = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
		EE0C9538 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		C79E810B = new System.Windows.Forms.DataGridViewTextBoxColumn();
		A5B06D89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		A022B99A = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cPage = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cPagePro5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E6213E2C = new System.Windows.Forms.DataGridViewTextBoxColumn();
		EB8861A9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cOAuth2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cFa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		CB09DC32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cDateCreateAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cThuMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cInteractEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cHometown = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cCurrentCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F38D180E = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cAds = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
		A808B636 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		B3BB10B0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		AF9E6D03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cDateDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E9A8FC92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		EB8F3614.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		B7A82181.SuspendLayout();
		E9137420.SuspendLayout();
		panel2.SuspendLayout();
		plQuanLyThuMuc.SuspendLayout();
		panel1.SuspendLayout();
		statusStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
		SuspendLayout();
		EB8F3614.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
		{
			toolStripMenuItem_1, F620C1BC, toolStripMenuItem1, BC9B908F, toolStripMenuItem_15, C919C9A3, copyToolStripMenuItem, C3907130, mnuChucNang, A5ACE00D,
			toolStripMenuItem_5
		});
		EB8F3614.Name = "ctmsAcc";
		EB8F3614.Size = new System.Drawing.Size(198, 246);
		EB8F3614.Opening += new System.ComponentModel.CancelEventHandler(A31766A9);
		toolStripMenuItem_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { toolStripMenuItem_2, liveToolStripMenuItem, tinhTrangToolStripMenuItem, FBBB02B3, toolStripMenuItem_11, toolStripMenuItem_12 });
		toolStripMenuItem_1.Image = (System.Drawing.Image)resources.GetObject("chọnLiveToolStripMenuItem.Image");
		toolStripMenuItem_1.Name = "chọnLiveToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(197, 22);
		toolStripMenuItem_1.Text = "Chọn";
		toolStripMenuItem_2.Image = (System.Drawing.Image)resources.GetObject("tấtCảToolStripMenuItem.Image");
		toolStripMenuItem_2.Name = "tấtCảToolStripMenuItem";
		toolStripMenuItem_2.Size = new System.Drawing.Size(128, 22);
		toolStripMenuItem_2.Text = "Tất cả";
		toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_2_Click);
		liveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("liveToolStripMenuItem.Image");
		liveToolStripMenuItem.Name = "liveToolStripMenuItem";
		liveToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
		liveToolStripMenuItem.Text = "Bôi đen";
		liveToolStripMenuItem.Click += new System.EventHandler(liveToolStripMenuItem_Click);
		tinhTrangToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tinhTrangToolStripMenuItem.Image");
		tinhTrangToolStripMenuItem.Name = "tinhTrangToolStripMenuItem";
		tinhTrangToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
		tinhTrangToolStripMenuItem.Text = "Ti\u0300nh tra\u0323ng";
		FBBB02B3.Image = (System.Drawing.Image)resources.GetObject("trạngTháiToolStripMenuItem.Image");
		FBBB02B3.Name = "trạngTháiToolStripMenuItem";
		FBBB02B3.Size = new System.Drawing.Size(128, 22);
		FBBB02B3.Text = "Trạng thái";
		FBBB02B3.Click += new System.EventHandler(F6306896);
		toolStripMenuItem_11.Image = Class155.EF116508;
		toolStripMenuItem_11.Name = "chDanhSáchTheoUIDEmailToolStripMenuItem";
		toolStripMenuItem_11.Size = new System.Drawing.Size(128, 22);
		toolStripMenuItem_11.Text = "Theo Uid";
		toolStripMenuItem_11.Click += new System.EventHandler(toolStripMenuItem_11_Click);
		toolStripMenuItem_12.Image = (System.Drawing.Image)resources.GetObject("ghiChúToolStripMenuItem.Image");
		toolStripMenuItem_12.Name = "ghiChúToolStripMenuItem";
		toolStripMenuItem_12.Size = new System.Drawing.Size(128, 22);
		toolStripMenuItem_12.Text = "Ghi chu\u0301";
		toolStripMenuItem_12.MouseEnter += new System.EventHandler(toolStripMenuItem_12_MouseEnter);
		F620C1BC.Image = (System.Drawing.Image)resources.GetObject("bỏChọnTấtCảToolStripMenuItem.Image");
		F620C1BC.Name = "bỏChọnTấtCảToolStripMenuItem";
		F620C1BC.Size = new System.Drawing.Size(197, 22);
		F620C1BC.Text = "Bỏ chọn tất cả";
		F620C1BC.Click += new System.EventHandler(DC3EEA07);
		toolStripMenuItem1.Image = Class155.Bitmap_99;
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
		toolStripMenuItem1.Text = "Ẩn dòng tích chọn";
		toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
		BC9B908F.Image = Class155.Bitmap_99;
		BC9B908F.Name = "toolStripMenuItem2";
		BC9B908F.Size = new System.Drawing.Size(197, 22);
		BC9B908F.Text = "Ẩn dòng không tích";
		BC9B908F.Click += new System.EventHandler(D8A21F3C);
		toolStripMenuItem_15.Image = Class155.E8316184;
		toolStripMenuItem_15.Name = "khôiPhucTaiKhoanToolStripMenuItem";
		toolStripMenuItem_15.Size = new System.Drawing.Size(197, 22);
		toolStripMenuItem_15.Text = "Khôi phu\u0323c ta\u0300i khoa\u0309n";
		toolStripMenuItem_15.Click += new System.EventHandler(toolStripMenuItem_15_Click);
		C919C9A3.Image = Class155.Bitmap_83;
		C919C9A3.Name = "xóaTàiKhoảnToolStripMenuItem";
		C919C9A3.Size = new System.Drawing.Size(197, 22);
		C919C9A3.Text = "Xóa ta\u0300i khoa\u0309n vi\u0303nh viê\u0303n";
		C919C9A3.Click += new System.EventHandler(A9B6791B);
		copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[17]
		{
			uidToolStripMenuItem, passToolStripMenuItem, tokenToolStripMenuItem, cookieToolStripMenuItem, FBB45DBF, F9B7A891, D01D698D, uidPassToolStripMenuItem, uidPass2FaToolStripMenuItem, mailPassMailToolStripMenuItem,
			emailPassMailMailKpToolStripMenuItem, uidPassTokenCookieToolStripMenuItem, E0997ABE, uidPassTokenCookieMailPassMail2faToolStripMenuItem, AE1837BF, proxyToolStripMenuItem1, toolStripMenuItem_8
		});
		copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
		copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
		copyToolStripMenuItem.Text = "Copy";
		uidToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidToolStripMenuItem.Image");
		uidToolStripMenuItem.Name = "uidToolStripMenuItem";
		uidToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		uidToolStripMenuItem.Text = "Uid";
		uidToolStripMenuItem.Click += new System.EventHandler(BC23123F);
		passToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passToolStripMenuItem.Image");
		passToolStripMenuItem.Name = "passToolStripMenuItem";
		passToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		passToolStripMenuItem.Text = "Pass";
		passToolStripMenuItem.Click += new System.EventHandler(B89FF6A7);
		tokenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tokenToolStripMenuItem.Image");
		tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
		tokenToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		tokenToolStripMenuItem.Text = "Token";
		tokenToolStripMenuItem.Click += new System.EventHandler(tokenToolStripMenuItem_Click);
		cookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cookieToolStripMenuItem.Image");
		cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
		cookieToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		cookieToolStripMenuItem.Text = "Cookie";
		cookieToolStripMenuItem.Click += new System.EventHandler(C42F012A);
		FBB45DBF.Image = (System.Drawing.Image)resources.GetObject("mailToolStripMenuItem.Image");
		FBB45DBF.Name = "mailToolStripMenuItem";
		FBB45DBF.Size = new System.Drawing.Size(289, 22);
		FBB45DBF.Text = "Email";
		FBB45DBF.Click += new System.EventHandler(FBB45DBF_Click);
		F9B7A891.Image = (System.Drawing.Image)resources.GetObject("fAToolStripMenuItem.Image");
		F9B7A891.Name = "fAToolStripMenuItem";
		F9B7A891.Size = new System.Drawing.Size(289, 22);
		F9B7A891.Text = "2FA";
		F9B7A891.Click += new System.EventHandler(D51C0097);
		D01D698D.Image = (System.Drawing.Image)resources.GetObject("maBaoMât6SôToolStripMenuItem.Image");
		D01D698D.Name = "maBaoMât6SôToolStripMenuItem";
		D01D698D.Size = new System.Drawing.Size(289, 22);
		D01D698D.Text = "Ma\u0303 ba\u0309o mâ\u0323t 6 sô\u0301 từ 2FA";
		D01D698D.Click += new System.EventHandler(F20D71AC);
		uidPassToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassToolStripMenuItem.Image");
		uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
		uidPassToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		uidPassToolStripMenuItem.Text = "Uid|Pass";
		uidPassToolStripMenuItem.Click += new System.EventHandler(uidPassToolStripMenuItem_Click);
		uidPass2FaToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPass2FaToolStripMenuItem.Image");
		uidPass2FaToolStripMenuItem.Name = "uidPass2FaToolStripMenuItem";
		uidPass2FaToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		uidPass2FaToolStripMenuItem.Text = "Uid|Pass|2Fa";
		uidPass2FaToolStripMenuItem.Click += new System.EventHandler(uidPass2FaToolStripMenuItem_Click);
		mailPassMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailPassMailToolStripMenuItem.Image");
		mailPassMailToolStripMenuItem.Name = "mailPassMailToolStripMenuItem";
		mailPassMailToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		mailPassMailToolStripMenuItem.Text = "Mail|Pass mail";
		mailPassMailToolStripMenuItem.Click += new System.EventHandler(mailPassMailToolStripMenuItem_Click);
		emailPassMailMailKpToolStripMenuItem.Image = Class155.BB212C2D;
		emailPassMailMailKpToolStripMenuItem.Name = "emailPassMailMailKpToolStripMenuItem";
		emailPassMailMailKpToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		emailPassMailMailKpToolStripMenuItem.Text = "Email|PassMail|MailKp";
		emailPassMailMailKpToolStripMenuItem.Click += new System.EventHandler(CFB3A8A1);
		uidPassTokenCookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieToolStripMenuItem.Image");
		uidPassTokenCookieToolStripMenuItem.Name = "uidPassTokenCookieToolStripMenuItem";
		uidPassTokenCookieToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		uidPassTokenCookieToolStripMenuItem.Text = "Uid|Pass|Token|Cookie";
		uidPassTokenCookieToolStripMenuItem.Click += new System.EventHandler(uidPassTokenCookieToolStripMenuItem_Click);
		E0997ABE.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieMailPassMailToolStripMenuItem.Image");
		E0997ABE.Name = "uidPassTokenCookieMailPassMailToolStripMenuItem";
		E0997ABE.Size = new System.Drawing.Size(289, 22);
		E0997ABE.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail";
		E0997ABE.Click += new System.EventHandler(E0997ABE_Click);
		uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image");
		uidPassTokenCookieMailPassMail2faToolStripMenuItem.Name = "uidPassTokenCookieMailPassMail2faToolStripMenuItem";
		uidPassTokenCookieMailPassMail2faToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
		uidPassTokenCookieMailPassMail2faToolStripMenuItem.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail|2fa";
		uidPassTokenCookieMailPassMail2faToolStripMenuItem.Click += new System.EventHandler(uidPassTokenCookieMailPassMail2faToolStripMenuItem_Click);
		AE1837BF.Image = (System.Drawing.Image)resources.GetObject("useragentToolStripMenuItem1.Image");
		AE1837BF.Name = "useragentToolStripMenuItem1";
		AE1837BF.Size = new System.Drawing.Size(289, 22);
		AE1837BF.Text = "Useragent";
		AE1837BF.Click += new System.EventHandler(E738DCA5);
		proxyToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("proxyToolStripMenuItem1.Image");
		proxyToolStripMenuItem1.Name = "proxyToolStripMenuItem1";
		proxyToolStripMenuItem1.Size = new System.Drawing.Size(289, 22);
		proxyToolStripMenuItem1.Text = "Proxy";
		proxyToolStripMenuItem1.Click += new System.EventHandler(F1074A32);
		toolStripMenuItem_8.Image = (System.Drawing.Image)resources.GetObject("đinhDangKhacToolStripMenuItem.Image");
		toolStripMenuItem_8.Name = "đinhDangKhacToolStripMenuItem";
		toolStripMenuItem_8.Size = new System.Drawing.Size(289, 22);
		toolStripMenuItem_8.Text = "Other...";
		toolStripMenuItem_8.Click += new System.EventHandler(toolStripMenuItem_8_Click);
		C3907130.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { toolStripMenuItem_6, checkInfoUIDToolStripMenuItem, toolStripMenuItem_4, toolStripMenuItem_3, E92BFD1F, E4AFF72D, D2BC2A34, FFA4A727 });
		C3907130.Image = (System.Drawing.Image)resources.GetObject("checkCookieToolStripMenuItem.Image");
		C3907130.Name = "checkCookieToolStripMenuItem";
		C3907130.Size = new System.Drawing.Size(197, 22);
		C3907130.Text = "Kiểm tra tài khoản";
		C3907130.Click += new System.EventHandler(C3907130_Click);
		toolStripMenuItem_6.Name = "kiểmTraWallToolStripMenuItem";
		toolStripMenuItem_6.Size = new System.Drawing.Size(199, 22);
		toolStripMenuItem_6.Text = "Check Wall";
		toolStripMenuItem_6.ToolTipText = "Không cần dùng token";
		toolStripMenuItem_6.Click += new System.EventHandler(B3249998);
		checkInfoUIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { F28E3BAF, DA2C0C97 });
		checkInfoUIDToolStripMenuItem.Name = "checkInfoUIDToolStripMenuItem";
		checkInfoUIDToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
		checkInfoUIDToolStripMenuItem.Text = "Check Info Uid";
		checkInfoUIDToolStripMenuItem.ToolTipText = "Không cần dùng token\r\nCâ\u0323p nhâ\u0323t thông tin: Ho\u0323 tên, Giớ\u0301i ti\u0301nh, [Email], [Ba\u0323n be\u0300], [Nho\u0301m], [Nga\u0300y sinh]";
		F28E3BAF.Name = "sửDụngIPMáyToolStripMenuItem";
		F28E3BAF.Size = new System.Drawing.Size(190, 22);
		F28E3BAF.Text = "Không đổi IP";
		F28E3BAF.Click += new System.EventHandler(AF84633F);
		DA2C0C97.Name = "sửDụngProxyĐãGánToolStripMenuItem";
		DA2C0C97.Size = new System.Drawing.Size(190, 22);
		DA2C0C97.Text = "Sử dụng proxy đã gán";
		DA2C0C97.Click += new System.EventHandler(DA2C0C97_Click);
		toolStripMenuItem_4.Name = "kiểmTraTokenToolStripMenuItem";
		toolStripMenuItem_4.Size = new System.Drawing.Size(199, 22);
		toolStripMenuItem_4.Text = "Check Token";
		toolStripMenuItem_4.Click += new System.EventHandler(toolStripMenuItem_4_Click);
		toolStripMenuItem_3.Name = "kiểmTraCookieToolStripMenuItem";
		toolStripMenuItem_3.Size = new System.Drawing.Size(199, 22);
		toolStripMenuItem_3.Text = "Check Cookie";
		toolStripMenuItem_3.Click += new System.EventHandler(toolStripMenuItem_3_Click);
		E92BFD1F.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem_13, toolStripMenuItem_14 });
		E92BFD1F.Name = "checkAvatarToolStripMenuItem";
		E92BFD1F.Size = new System.Drawing.Size(199, 22);
		E92BFD1F.Text = "Check Avatar";
		toolStripMenuItem_13.Name = "khôngĐổiIPToolStripMenuItem";
		toolStripMenuItem_13.Size = new System.Drawing.Size(190, 22);
		toolStripMenuItem_13.Text = "Không đổi IP";
		toolStripMenuItem_13.Click += new System.EventHandler(toolStripMenuItem_13_Click);
		toolStripMenuItem_14.Name = "sửDụngProxyĐãGánToolStripMenuItem1";
		toolStripMenuItem_14.Size = new System.Drawing.Size(190, 22);
		toolStripMenuItem_14.Text = "Sử dụng proxy đã gán";
		toolStripMenuItem_14.Click += new System.EventHandler(B7A26812);
		E4AFF72D.Name = "checkProfileToolStripMenuItem1";
		E4AFF72D.Size = new System.Drawing.Size(199, 22);
		E4AFF72D.Text = "Check Profile";
		E4AFF72D.Click += new System.EventHandler(checkProfileToolStripMenuItem_Click);
		D2BC2A34.Name = "kiểmTraMailpassMailToolStripMenuItem";
		D2BC2A34.Size = new System.Drawing.Size(199, 22);
		D2BC2A34.Text = "Check Connect hotmail";
		D2BC2A34.Click += new System.EventHandler(D2BC2A34_Click);
		FFA4A727.Name = "checkProxyToolStripMenuItem";
		FFA4A727.Size = new System.Drawing.Size(199, 22);
		FFA4A727.Text = "Check Proxy";
		FFA4A727.Click += new System.EventHandler(FFA4A727_Click);
		mnuChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { C637720F, locTrungToolStripMenuItem });
		mnuChucNang.Image = (System.Drawing.Image)resources.GetObject("mnuChucNang.Image");
		mnuChucNang.Name = "mnuChucNang";
		mnuChucNang.Size = new System.Drawing.Size(197, 22);
		mnuChucNang.Text = "Chức năng";
		C637720F.Image = (System.Drawing.Image)resources.GetObject("lToolStripMenuItem.Image");
		C637720F.Name = "lToolStripMenuItem";
		C637720F.Size = new System.Drawing.Size(207, 22);
		C637720F.Text = "Lọc tài khoản theo Uid";
		C637720F.Click += new System.EventHandler(C637720F_Click);
		locTrungToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("locTrungToolStripMenuItem.Image");
		locTrungToolStripMenuItem.Name = "locTrungToolStripMenuItem";
		locTrungToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
		locTrungToolStripMenuItem.Text = "Lọc tài khoản trùng nhau";
		locTrungToolStripMenuItem.Click += new System.EventHandler(locTrungToolStripMenuItem_Click);
		A5ACE00D.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { checkProfileToolStripMenuItem, toolStripMenuItem_7, donDepProfileToolStripMenuItem, F4B62128 });
		A5ACE00D.Image = (System.Drawing.Image)resources.GetObject("profileToolStripMenuItem.Image");
		A5ACE00D.Name = "profileToolStripMenuItem";
		A5ACE00D.Size = new System.Drawing.Size(197, 22);
		A5ACE00D.Text = "Profile Chrome";
		checkProfileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkProfileToolStripMenuItem.Image");
		checkProfileToolStripMenuItem.Name = "checkProfileToolStripMenuItem";
		checkProfileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		checkProfileToolStripMenuItem.Text = "Check profile";
		checkProfileToolStripMenuItem.Click += new System.EventHandler(checkProfileToolStripMenuItem_Click);
		toolStripMenuItem_7.Image = (System.Drawing.Image)resources.GetObject("xóaProfileToolStripMenuItem.Image");
		toolStripMenuItem_7.Name = "xóaProfileToolStripMenuItem";
		toolStripMenuItem_7.Size = new System.Drawing.Size(167, 22);
		toolStripMenuItem_7.Text = "Xóa profile";
		toolStripMenuItem_7.Click += new System.EventHandler(toolStripMenuItem_7_Click);
		donDepProfileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("donDepProfileToolStripMenuItem.Image");
		donDepProfileToolStripMenuItem.Name = "donDepProfileToolStripMenuItem";
		donDepProfileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		donDepProfileToolStripMenuItem.Text = "Do\u0323n de\u0323p profile";
		donDepProfileToolStripMenuItem.Click += new System.EventHandler(donDepProfileToolStripMenuItem_Click);
		F4B62128.Image = (System.Drawing.Image)resources.GetObject("xóaCacheToolStripMenuItem.Image");
		F4B62128.Name = "xóaCacheToolStripMenuItem";
		F4B62128.Size = new System.Drawing.Size(167, 22);
		F4B62128.Text = "Xóa Cache Profile";
		F4B62128.Click += new System.EventHandler(BB97463A);
		toolStripMenuItem_5.Image = (System.Drawing.Image)resources.GetObject("tảiLạiDanhSáchToolStripMenuItem.Image");
		toolStripMenuItem_5.Name = "tảiLạiDanhSáchToolStripMenuItem";
		toolStripMenuItem_5.Size = new System.Drawing.Size(197, 22);
		toolStripMenuItem_5.Text = "Tải lại danh sách";
		toolStripMenuItem_5.Click += new System.EventHandler(E186B800);
		getTokenEAAAAUToolStripMenuItem.Name = "getTokenEAAAAUToolStripMenuItem";
		getTokenEAAAAUToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
		getTokenEAAAAUToolStripMenuItem.Text = "Get Token EAAAAU";
		getTokenEAAAAUBToolStripMenuItem.Name = "getTokenEAAAAUBToolStripMenuItem";
		getTokenEAAAAUBToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
		getTokenEAAAAUBToolStripMenuItem.Text = "Get Token EAAAAU + Bật 2FA";
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = pnlHeader;
		bunifuDragControl_0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(E0091419);
		pnlHeader.Controls.Add(A2164F3A);
		pnlHeader.Controls.Add(btnClose);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(2, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1220, 29);
		pnlHeader.TabIndex = 0;
		pnlHeader.DoubleClick += new System.EventHandler(pnlHeader_DoubleClick);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(6, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 12;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		pictureBox1.DoubleClick += new System.EventHandler(pictureBox1_DoubleClick);
		E0091419.Cursor = System.Windows.Forms.Cursors.Hand;
		E0091419.Dock = System.Windows.Forms.DockStyle.Right;
		E0091419.FlatAppearance.BorderSize = 0;
		E0091419.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E0091419.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E0091419.ForeColor = System.Drawing.Color.White;
		E0091419.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		E0091419.Location = new System.Drawing.Point(1124, 0);
		E0091419.Name = "btnMinimize";
		E0091419.Size = new System.Drawing.Size(32, 29);
		E0091419.TabIndex = 0;
		E0091419.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E0091419.UseVisualStyleBackColor = true;
		E0091419.Click += new System.EventHandler(ED11D186);
		A2164F3A.Cursor = System.Windows.Forms.Cursors.Hand;
		A2164F3A.Dock = System.Windows.Forms.DockStyle.Right;
		A2164F3A.FlatAppearance.BorderSize = 0;
		A2164F3A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A2164F3A.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A2164F3A.ForeColor = System.Drawing.Color.White;
		A2164F3A.Image = (System.Drawing.Image)resources.GetObject("btnMaximize.Image");
		A2164F3A.Location = new System.Drawing.Point(1156, 0);
		A2164F3A.Name = "btnMaximize";
		A2164F3A.Size = new System.Drawing.Size(32, 29);
		A2164F3A.TabIndex = 1;
		A2164F3A.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A2164F3A.UseVisualStyleBackColor = true;
		A2164F3A.Click += new System.EventHandler(A2164F3A_Click);
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.Dock = System.Windows.Forms.DockStyle.Right;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		btnClose.Location = new System.Drawing.Point(1188, 0);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(32, 29);
		btnClose.TabIndex = 2;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(DCB3320A);
		bunifuCustomLabel1.AutoSize = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(43, 6);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(185, 16);
		bunifuCustomLabel1.TabIndex = 3;
		bunifuCustomLabel1.Text = "Danh sách tài khoản đã xóa";
		bunifuCustomLabel1.DoubleClick += new System.EventHandler(CFAE8F35);
		B7A82181.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B7A82181.BackColor = System.Drawing.Color.White;
		B7A82181.BorderRadius = 0;
		B7A82181.BottomSahddow = true;
		B7A82181.color = System.Drawing.Color.DarkRed;
		B7A82181.Controls.Add(pnlHeader);
		B7A82181.LeftSahddow = false;
		B7A82181.Location = new System.Drawing.Point(1, 0);
		B7A82181.Name = "bunifuCards1";
		B7A82181.RightSahddow = true;
		B7A82181.ShadowDepth = 20;
		B7A82181.Size = new System.Drawing.Size(1223, 38);
		B7A82181.TabIndex = 0;
		E9137420.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E9137420.AutoSize = false;
		E9137420.Dock = System.Windows.Forms.DockStyle.None;
		E9137420.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E9137420.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem_0, toolStripMenuItem_9, toolStripMenuItem_10, E4B4B4B8 });
		E9137420.Location = new System.Drawing.Point(1, 37);
		E9137420.Name = "menuStrip1";
		E9137420.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
		E9137420.Size = new System.Drawing.Size(1221, 25);
		E9137420.Stretch = false;
		E9137420.TabIndex = 1;
		E9137420.Text = "menuStrip1";
		toolStripMenuItem_0.Image = (System.Drawing.Image)resources.GetObject("hệThốngToolStripMenuItem.Image");
		toolStripMenuItem_0.Name = "hệThốngToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(123, 21);
		toolStripMenuItem_0.Text = "Câ\u0301u hi\u0300nh chung";
		toolStripMenuItem_0.Click += new System.EventHandler(F698B402);
		toolStripMenuItem_9.Image = (System.Drawing.Image)resources.GetObject("thoátToolStripMenuItem.Image");
		toolStripMenuItem_9.Name = "thoátToolStripMenuItem";
		toolStripMenuItem_9.Size = new System.Drawing.Size(131, 21);
		toolStripMenuItem_9.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
		toolStripMenuItem_9.Click += new System.EventHandler(toolStripMenuItem_9_Click);
		toolStripMenuItem_10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { checkLiveUidToolStripMenuItem, checkProxyToolStripMenuItem1, checkHotmailToolStripMenuItem, FB80C634, FA0F873B, DB3E0301, testSpinTextToolStripMenuItem });
		toolStripMenuItem_10.Image = (System.Drawing.Image)resources.GetObject("tiệnÍchToolStripMenuItem.Image");
		toolStripMenuItem_10.Name = "tiệnÍchToolStripMenuItem";
		toolStripMenuItem_10.Size = new System.Drawing.Size(80, 21);
		toolStripMenuItem_10.Text = "Tiện ích";
		checkLiveUidToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkLiveUidToolStripMenuItem.Image");
		checkLiveUidToolStripMenuItem.Name = "checkLiveUidToolStripMenuItem";
		checkLiveUidToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
		checkLiveUidToolStripMenuItem.Text = "Check Live Uid";
		checkLiveUidToolStripMenuItem.Click += new System.EventHandler(BABB58AE);
		checkProxyToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("checkProxyToolStripMenuItem1.Image");
		checkProxyToolStripMenuItem1.Name = "checkProxyToolStripMenuItem1";
		checkProxyToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
		checkProxyToolStripMenuItem1.Text = "Check Proxy";
		checkProxyToolStripMenuItem1.Click += new System.EventHandler(checkProxyToolStripMenuItem1_Click);
		checkHotmailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkHotmailToolStripMenuItem.Image");
		checkHotmailToolStripMenuItem.Name = "checkHotmailToolStripMenuItem";
		checkHotmailToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
		checkHotmailToolStripMenuItem.Text = "Check Connect hotmail";
		checkHotmailToolStripMenuItem.Click += new System.EventHandler(checkHotmailToolStripMenuItem_Click);
		FB80C634.Image = (System.Drawing.Image)resources.GetObject("lọcTrùngDữLiệuToolStripMenuItem.Image");
		FB80C634.Name = "lọcTrùngDữLiệuToolStripMenuItem";
		FB80C634.Size = new System.Drawing.Size(204, 22);
		FB80C634.Text = "Lọc trùng dữ liệu";
		FB80C634.Click += new System.EventHandler(FB80C634_Click);
		FA0F873B.Image = (System.Drawing.Image)resources.GetObject("xửLýChuỗiOnlineToolStripMenuItem.Image");
		FA0F873B.Name = "xửLýChuỗiOnlineToolStripMenuItem";
		FA0F873B.Size = new System.Drawing.Size(204, 22);
		FA0F873B.Text = "Xử lý chuỗi cơ bản";
		FA0F873B.Click += new System.EventHandler(D7058035);
		DB3E0301.Image = Class155.E31D0A36;
		DB3E0301.Name = "checkStatusXproxyToolStripMenuItem";
		DB3E0301.Size = new System.Drawing.Size(204, 22);
		DB3E0301.Text = "Check Xproxy";
		DB3E0301.Click += new System.EventHandler(D21AA71F);
		testSpinTextToolStripMenuItem.Image = Class155.F887522E;
		testSpinTextToolStripMenuItem.Name = "testSpinTextToolStripMenuItem";
		testSpinTextToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
		testSpinTextToolStripMenuItem.Text = "Test Spin Content";
		testSpinTextToolStripMenuItem.Click += new System.EventHandler(testSpinTextToolStripMenuItem_Click);
		E4B4B4B8.Image = (System.Drawing.Image)resources.GetObject("liênHệToolStripMenuItem.Image");
		E4B4B4B8.Name = "liênHệToolStripMenuItem";
		E4B4B4B8.Size = new System.Drawing.Size(76, 21);
		E4B4B4B8.Text = "Liên hệ";
		E4B4B4B8.Click += new System.EventHandler(E4B4B4B8_Click);
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_1.Vertical = true;
		btnLoadAcc.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnLoadAcc.BackgroundImage");
		btnLoadAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		btnLoadAcc.Cursor = System.Windows.Forms.Cursors.Hand;
		btnLoadAcc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnLoadAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnLoadAcc.Location = new System.Drawing.Point(395, 2);
		btnLoadAcc.Name = "btnLoadAcc";
		btnLoadAcc.Size = new System.Drawing.Size(25, 25);
		btnLoadAcc.TabIndex = 6;
		btnLoadAcc.Click += new System.EventHandler(BF0C09AA);
		miniToolStrip.AccessibleName = "New item selection";
		miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
		miniToolStrip.AutoSize = false;
		miniToolStrip.BackColor = System.Drawing.SystemColors.Control;
		miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
		miniToolStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		miniToolStrip.Location = new System.Drawing.Point(0, 0);
		miniToolStrip.Name = "miniToolStrip";
		miniToolStrip.Size = new System.Drawing.Size(1222, 22);
		miniToolStrip.SizingGrip = false;
		miniToolStrip.TabIndex = 9;
		EA18FB98.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EA18FB98.Name = "toolStripStatusLabel4";
		EA18FB98.Size = new System.Drawing.Size(59, 17);
		EA18FB98.Text = "Bôi đen:";
		lblCountHighline.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblCountHighline.ForeColor = System.Drawing.Color.Blue;
		lblCountHighline.Name = "lblCountHighline";
		lblCountHighline.Size = new System.Drawing.Size(15, 17);
		lblCountHighline.Text = "0";
		toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		toolStripStatusLabel5.Name = "toolStripStatusLabel5";
		toolStripStatusLabel5.Size = new System.Drawing.Size(65, 17);
		toolStripStatusLabel5.Text = "Đã chọn:";
		lblCountSelect.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblCountSelect.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
		lblCountSelect.Name = "lblCountSelect";
		lblCountSelect.Size = new System.Drawing.Size(15, 17);
		lblCountSelect.Text = "0";
		FD1084AF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FD1084AF.Name = "toolStripStatusLabel7";
		FD1084AF.Size = new System.Drawing.Size(52, 17);
		FD1084AF.Text = "Tất cả:";
		lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblCountTotal.ForeColor = System.Drawing.Color.Maroon;
		lblCountTotal.Name = "lblCountTotal";
		lblCountTotal.Size = new System.Drawing.Size(15, 17);
		lblCountTotal.Text = "0";
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(BtnSearch);
		panel2.Controls.Add(cbbSearch);
		panel2.Controls.Add(txbSearch);
		panel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		panel2.Location = new System.Drawing.Point(8, 71);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(269, 31);
		panel2.TabIndex = 10;
		BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		BtnSearch.BackgroundImage = Class155.F23947B4;
		BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
		BtnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BtnSearch.Location = new System.Drawing.Point(240, 3);
		BtnSearch.Name = "BtnSearch";
		BtnSearch.Size = new System.Drawing.Size(24, 23);
		BtnSearch.TabIndex = 3;
		BtnSearch.Click += new System.EventHandler(BtnSearch_Click);
		cbbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbSearch.DropDownWidth = 100;
		cbbSearch.FormattingEnabled = true;
		cbbSearch.Location = new System.Drawing.Point(3, 3);
		cbbSearch.Name = "cbbSearch";
		cbbSearch.Size = new System.Drawing.Size(86, 24);
		cbbSearch.TabIndex = 0;
		txbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txbSearch.BorderColor = System.Drawing.Color.SeaGreen;
		txbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
		txbSearch.Location = new System.Drawing.Point(95, 3);
		txbSearch.Name = "txbSearch";
		txbSearch.Size = new System.Drawing.Size(139, 23);
		txbSearch.TabIndex = 1;
		txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(txbSearch_KeyDown);
		plQuanLyThuMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plQuanLyThuMuc.Controls.Add(C9B9DEB1);
		plQuanLyThuMuc.Controls.Add(btnLoadAcc);
		plQuanLyThuMuc.Controls.Add(D21ECC06);
		plQuanLyThuMuc.Controls.Add(label2);
		plQuanLyThuMuc.Controls.Add(FC271C1A);
		plQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		plQuanLyThuMuc.Location = new System.Drawing.Point(283, 71);
		plQuanLyThuMuc.Name = "plQuanLyThuMuc";
		plQuanLyThuMuc.Size = new System.Drawing.Size(424, 31);
		plQuanLyThuMuc.TabIndex = 10;
		C9B9DEB1.Cursor = System.Windows.Forms.Cursors.Hand;
		C9B9DEB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		C9B9DEB1.DropDownWidth = 300;
		C9B9DEB1.FormattingEnabled = true;
		C9B9DEB1.ItemHeight = 16;
		C9B9DEB1.Items.AddRange(new object[1] { "[Tất cả tình trạng]" });
		C9B9DEB1.Location = new System.Drawing.Point(268, 3);
		C9B9DEB1.Name = "cbbTinhTrang";
		C9B9DEB1.Size = new System.Drawing.Size(121, 24);
		C9B9DEB1.TabIndex = 3;
		C9B9DEB1.SelectedIndexChanged += new System.EventHandler(C9B9DEB1_SelectedIndexChanged);
		D21ECC06.AutoSize = true;
		D21ECC06.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D21ECC06.Location = new System.Drawing.Point(-1, 6);
		D21ECC06.Name = "label1";
		D21ECC06.Size = new System.Drawing.Size(63, 16);
		D21ECC06.TabIndex = 0;
		D21ECC06.Text = "Thư mục:";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(232, 5);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(31, 16);
		label2.TabIndex = 2;
		label2.Text = "Lọc:";
		FC271C1A.Cursor = System.Windows.Forms.Cursors.Hand;
		FC271C1A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FC271C1A.DropDownWidth = 350;
		FC271C1A.FormattingEnabled = true;
		FC271C1A.ItemHeight = 16;
		FC271C1A.Location = new System.Drawing.Point(63, 3);
		FC271C1A.Name = "cbbThuMuc";
		FC271C1A.Size = new System.Drawing.Size(167, 24);
		FC271C1A.TabIndex = 1;
		FC271C1A.SelectedIndexChanged += new System.EventHandler(FC271C1A_SelectedIndexChanged);
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(A9AE31B9);
		panel1.Controls.Add(A18B0B9B);
		panel1.Controls.Add(plQuanLyThuMuc);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(statusStrip1);
		panel1.Controls.Add(dtgvAcc);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1224, 610);
		panel1.TabIndex = 11;
		A9AE31B9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A9AE31B9.BackColor = System.Drawing.Color.White;
		A9AE31B9.Cursor = System.Windows.Forms.Cursors.Hand;
		A9AE31B9.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A9AE31B9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A9AE31B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A9AE31B9.Image = Class155.Bitmap_83;
		A9AE31B9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		A9AE31B9.Location = new System.Drawing.Point(1011, 70);
		A9AE31B9.Name = "button3";
		A9AE31B9.Size = new System.Drawing.Size(201, 32);
		A9AE31B9.TabIndex = 13;
		A9AE31B9.Text = "Xo\u0301a ta\u0300i khoa\u0309n vi\u0303nh viê\u0303n";
		A9AE31B9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		A9AE31B9.UseVisualStyleBackColor = true;
		A9AE31B9.Click += new System.EventHandler(A9AE31B9_Click);
		A18B0B9B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A18B0B9B.BackColor = System.Drawing.Color.White;
		A18B0B9B.Cursor = System.Windows.Forms.Cursors.Hand;
		A18B0B9B.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A18B0B9B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A18B0B9B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A18B0B9B.Image = Class155.E8316184;
		A18B0B9B.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		A18B0B9B.Location = new System.Drawing.Point(847, 70);
		A18B0B9B.Name = "button9";
		A18B0B9B.Size = new System.Drawing.Size(158, 32);
		A18B0B9B.TabIndex = 14;
		A18B0B9B.Text = "Khôi phu\u0323c ta\u0300i khoa\u0309n";
		A18B0B9B.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		A18B0B9B.UseVisualStyleBackColor = true;
		A18B0B9B.Click += new System.EventHandler(A18B0B9B_Click);
		statusStrip1.BackColor = System.Drawing.SystemColors.Control;
		statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { EA18FB98, lblCountHighline, toolStripStatusLabel5, lblCountSelect, FD1084AF, lblCountTotal });
		statusStrip1.Location = new System.Drawing.Point(0, 586);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Size = new System.Drawing.Size(1222, 22);
		statusStrip1.SizingGrip = false;
		statusStrip1.TabIndex = 9;
		statusStrip1.Text = "statusStrip1";
		statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(C4110533);
		dtgvAcc.AllowUserToAddRows = false;
		dtgvAcc.AllowUserToDeleteRows = false;
		dtgvAcc.AllowUserToResizeRows = false;
		dtgvAcc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		dtgvAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dtgvAcc.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dtgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dtgvAcc.Columns.AddRange(cChose, C60DF4B6, cId, B4A98981, cToken, cCookies, cEmail, EE0C9538, C79E810B, A5B06D89, A022B99A, cGroup, cPage, cPagePro5, cBirthday, cGender, cPassword, E6213E2C, EB8861A9, cOAuth2, cFa2, CB09DC32, cProxy, cDateCreateAcc, cAvatar, cProfile, cThuMuc, cInteractEnd, cInfo, cGhiChu, cLocation, cHometown, cCurrentCity, F38D180E, cAds, cBM, A808B636, B3BB10B0, AF9E6D03, cDateDelete, E9A8FC92);
		dtgvAcc.ContextMenuStrip = EB8F3614;
		dtgvAcc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		dtgvAcc.Location = new System.Drawing.Point(8, 108);
		dtgvAcc.Name = "dtgvAcc";
		dtgvAcc.RowHeadersVisible = false;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtgvAcc.RowsDefaultCellStyle = dataGridViewCellStyle2;
		dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dtgvAcc.Size = new System.Drawing.Size(1204, 475);
		dtgvAcc.TabIndex = 0;
		dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellClick);
		dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
		dtgvAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(BE84E183);
		dtgvAcc.SelectionChanged += new System.EventHandler(dtgvAcc_SelectionChanged);
		dtgvAcc.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(dtgvAcc_SortCompare);
		dtgvAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(dtgvAcc_KeyDown);
		cChose.HeaderText = "Chọn";
		cChose.Name = "cChose";
		cChose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		cChose.Width = 40;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		C60DF4B6.DefaultCellStyle = dataGridViewCellStyle3;
		C60DF4B6.HeaderText = "STT";
		C60DF4B6.Name = "cStt";
		C60DF4B6.Width = 35;
		cId.HeaderText = "Id";
		cId.Name = "cId";
		cId.Visible = false;
		cId.Width = 90;
		B4A98981.HeaderText = "UID";
		B4A98981.Name = "cUid";
		B4A98981.Width = 80;
		cToken.HeaderText = "Token";
		cToken.Name = "cToken";
		cToken.Width = 70;
		cCookies.HeaderText = "Cookie";
		cCookies.Name = "cCookies";
		cCookies.Width = 70;
		cEmail.HeaderText = "Email";
		cEmail.Name = "cEmail";
		cEmail.Width = 60;
		EE0C9538.HeaderText = "Phone";
		EE0C9538.Name = "cPhone";
		EE0C9538.Visible = false;
		EE0C9538.Width = 90;
		C79E810B.HeaderText = "Tên";
		C79E810B.Name = "cName";
		C79E810B.Width = 70;
		A5B06D89.HeaderText = "Theo do\u0303i";
		A5B06D89.Name = "cFollow";
		A5B06D89.Visible = false;
		A5B06D89.Width = 85;
		A022B99A.HeaderText = "Ba\u0323n be\u0300";
		A022B99A.Name = "cFriend";
		A022B99A.Width = 75;
		cGroup.HeaderText = "Nho\u0301m";
		cGroup.Name = "cGroup";
		cGroup.Visible = false;
		cGroup.Width = 60;
		cPage.HeaderText = "Page";
		cPage.Name = "cPage";
		cPage.Visible = false;
		cPage.Width = 60;
		cPagePro5.HeaderText = "Page pro5";
		cPagePro5.Name = "cPagePro5";
		cPagePro5.Visible = false;
		cBirthday.HeaderText = "Nga\u0300y sinh";
		cBirthday.Name = "cBirthday";
		cBirthday.Width = 90;
		cGender.HeaderText = "Giới Tính";
		cGender.Name = "cGender";
		cGender.Width = 82;
		cPassword.HeaderText = "Mật khẩu";
		cPassword.Name = "cPassword";
		cPassword.Visible = false;
		cPassword.Width = 85;
		E6213E2C.HeaderText = "Email khôi phục";
		E6213E2C.Name = "cMailRecovery";
		E6213E2C.Visible = false;
		E6213E2C.Width = 125;
		EB8861A9.HeaderText = "Mật khẩu mail";
		EB8861A9.Name = "cPassMail";
		EB8861A9.Visible = false;
		EB8861A9.Width = 120;
		cOAuth2.HeaderText = "OAuth2";
		cOAuth2.Name = "cOAuth2";
		cOAuth2.Visible = false;
		cOAuth2.Width = 70;
		cFa2.HeaderText = "Mã 2FA";
		cFa2.Name = "cFa2";
		cFa2.Width = 80;
		CB09DC32.HeaderText = "Useragent";
		CB09DC32.Name = "cUseragent";
		CB09DC32.Visible = false;
		CB09DC32.Width = 70;
		cProxy.HeaderText = "Proxy";
		cProxy.Name = "cProxy";
		cProxy.Visible = false;
		cProxy.Width = 55;
		cDateCreateAcc.HeaderText = "Nga\u0300y ta\u0323o";
		cDateCreateAcc.Name = "cDateCreateAcc";
		cDateCreateAcc.Visible = false;
		cDateCreateAcc.Width = 85;
		cAvatar.HeaderText = "Avatar";
		cAvatar.Name = "cAvatar";
		cAvatar.Visible = false;
		cAvatar.Width = 50;
		cProfile.HeaderText = "Profile";
		cProfile.Name = "cProfile";
		cProfile.Visible = false;
		cProfile.Width = 50;
		cThuMuc.HeaderText = "Thư mục";
		cThuMuc.Name = "cThuMuc";
		cThuMuc.Visible = false;
		cInteractEnd.HeaderText = "Lâ\u0300n tương ta\u0301c cuô\u0301i";
		cInteractEnd.Name = "cInteractEnd";
		cInteractEnd.Visible = false;
		cInteractEnd.Width = 160;
		cInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		cInfo.HeaderText = "Tình Trạng";
		cInfo.Name = "cInfo";
		cInfo.Visible = false;
		cGhiChu.HeaderText = "Ghi Chú";
		cGhiChu.Name = "cGhiChu";
		cGhiChu.Visible = false;
		cGhiChu.Width = 90;
		cLocation.HeaderText = "Location";
		cLocation.Name = "cLocation";
		cLocation.Visible = false;
		cLocation.Width = 80;
		cHometown.HeaderText = "Hometown";
		cHometown.Name = "cHometown";
		cHometown.Visible = false;
		cHometown.Width = 90;
		cCurrentCity.HeaderText = "Current City";
		cCurrentCity.Name = "cCurrentCity";
		cCurrentCity.Visible = false;
		F38D180E.HeaderText = "Dating";
		F38D180E.Name = "cDating";
		F38D180E.Visible = false;
		cAds.HeaderText = "Ads";
		cAds.Name = "cAds";
		cAds.Visible = false;
		cBM.HeaderText = "BM";
		cBM.Name = "cBM";
		cBM.Visible = false;
		A808B636.HeaderText = "Wall Posts";
		A808B636.Name = "cWallPosts";
		A808B636.Visible = false;
		B3BB10B0.HeaderText = "Fb Block";
		B3BB10B0.Name = "cFbBlock";
		B3BB10B0.Visible = false;
		AF9E6D03.HeaderText = "Job";
		AF9E6D03.Name = "cJob";
		AF9E6D03.Visible = false;
		cDateDelete.HeaderText = "Thơ\u0300i gian xo\u0301a";
		cDateDelete.Name = "cDateDelete";
		cDateDelete.Width = 115;
		E9A8FC92.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		E9A8FC92.HeaderText = "Trạng Thái";
		E9A8FC92.MinimumWidth = 200;
		E9A8FC92.Name = "cStatus";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1224, 610);
		base.Controls.Add(B7A82181);
		base.Controls.Add(E9137420);
		base.Controls.Add(panel1);
		DoubleBuffered = true;
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = E9137420;
		base.Name = "fTaiKhoanDaXoa";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "LushCare";
		EB8F3614.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		B7A82181.ResumeLayout(false);
		E9137420.ResumeLayout(false);
		E9137420.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		plQuanLyThuMuc.ResumeLayout(false);
		plQuanLyThuMuc.PerformLayout();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dtgvAcc).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_35()
	{
		foreach (DataGridViewColumn column in dtgvAcc.Columns)
		{
			column.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
	}

	[CompilerGenerated]
	private void method_36()
	{
		foreach (DataGridViewColumn column in dtgvAcc.Columns)
		{
			column.SortMode = DataGridViewColumnSortMode.Automatic;
		}
	}
}
