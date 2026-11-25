using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fQuanLyTinNhan : Form
{
	[CompilerGenerated]
	private sealed class Class78
	{
		internal Chrome C3851B92;

		internal Control control_0;

		internal void method_0()
		{
			SetParent(C3851B92.Process_0.MainWindowHandle, control_0.Handle);
			MoveWindow(C3851B92.Process_0.MainWindowHandle, -10, 0, control_0.Size.Width + 20, control_0.Size.Height + 20, bool_0: false);
		}
	}

	[CompilerGenerated]
	private sealed class Class79
	{
		internal string BC34CE2C;

		internal fQuanLyTinNhan fQuanLyTinNhan_0;

		internal void D5895DA7()
		{
			fQuanLyTinNhan_0.tabMain.TabPages.Remove(fQuanLyTinNhan_0.tabMain.TabPages[BC34CE2C]);
		}
	}

	[CompilerGenerated]
	private sealed class F99DCCA3
	{
		internal int int_0;

		internal List<int> DA134B9B;

		internal fQuanLyTinNhan fQuanLyTinNhan_0;

		internal void method_0()
		{
			try
			{
				int num = 0;
				while (num < DA134B9B.Count && fQuanLyTinNhan_0.list_0.Count < int_0)
				{
					FC9F7A27 CS_0024_003C_003E8__locals0 = new FC9F7A27
					{
						CC850E20 = this,
						AC2523B8 = DA134B9B[num++]
					};
					if (CS_0024_003C_003E8__locals0.AC2523B8 != 0)
					{
						Thread.Sleep(Base.rd.Next(C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeFrom"), C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeTo") + 1) * 1000);
					}
					Thread thread = new Thread((ThreadStart)delegate
					{
						try
						{
							CS_0024_003C_003E8__locals0.CC850E20.fQuanLyTinNhan_0.method_7(CS_0024_003C_003E8__locals0.AC2523B8);
						}
						catch (Exception exception_2)
						{
							Commom.smethod_57(null, exception_2);
						}
					})
					{
						Name = CS_0024_003C_003E8__locals0.AC2523B8.ToString()
					};
					fQuanLyTinNhan_0.list_0.Add(thread);
					Commom.smethod_52(1.0);
					thread.Start();
				}
				for (int i = 0; i < fQuanLyTinNhan_0.list_0.Count; i++)
				{
					fQuanLyTinNhan_0.list_0[i].Join();
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_);
			}
		}
	}

	[CompilerGenerated]
	private sealed class FC9F7A27
	{
		internal int AC2523B8;

		internal F99DCCA3 CC850E20;

		internal void method_0()
		{
			try
			{
				CC850E20.fQuanLyTinNhan_0.method_7(AC2523B8);
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_);
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class80
	{
		internal fQuanLyTinNhan F1295980;

		internal TabPage tabPage_0;

		internal void method_0()
		{
			F1295980.tabMain.ItemSize = new Size(0, 1);
			F1295980.tabMain.TabPages.Add(tabPage_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class81
	{
		internal string string_0;

		internal fQuanLyTinNhan DDB13D82;

		internal MethodInvoker methodInvoker_0;

		internal void B809010E()
		{
			DDB13D82.tabMain.TabPages.Remove(DDB13D82.tabMain.TabPages[string_0]);
		}
	}

	internal List<string> D8AFF826 = new List<string>();

	internal List<Thread> list_0 = null;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal Button button2;

	internal Button B78177A4;

	internal Button btnMinimize;

	internal BunifuCustomLabel F50EB9A7;

	internal BunifuCards B90B8E86;

	internal Panel panel1;

	internal TabControl tabMain;

	internal DataGridView dgvTaiKhoan;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem B6850F98;

	internal ToolStripMenuItem D0A5633E;

	internal Panel panel2;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal DataGridViewTextBoxColumn E7A4E28F;

	internal DataGridViewImageColumn cAvatar;

	internal DataGridViewTextBoxColumn cTaiKhoan;

	internal DataGridViewTextBoxColumn DE00D535;

	internal DataGridViewTextBoxColumn cPassword;

	internal DataGridViewTextBoxColumn cFa2;

	internal DataGridViewTextBoxColumn F99F2582;

	internal DataGridViewTextBoxColumn F506A89D;

	internal DataGridViewTextBoxColumn cGhiChu;

	internal DataGridViewTextBoxColumn cId;

	[DllImport("user32.dll", SetLastError = true)]
	public static extern long SetParent(IntPtr intptr_0, IntPtr intptr_1);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool MoveWindow(IntPtr intptr_0, int int_0, int int_1, int D6885B20, int B926E9BC, bool bool_0);

	public fQuanLyTinNhan(List<string> list_1)
	{
		InitializeComponent();
		Commom.CreateFolder("avatar");
		D8AFF826 = list_1;
		base.Width = Screen.PrimaryScreen.WorkingArea.Width;
		base.Height = Screen.PrimaryScreen.WorkingArea.Height;
		Language.CD21F0A9(this);
	}

	public int method_0()
	{
		int result = 0;
		try
		{
			result = dgvTaiKhoan.SelectedRows.Count;
		}
		catch
		{
		}
		return result;
	}

	public void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B78177A4_Click(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Maximized)
		{
			base.WindowState = FormWindowState.Normal;
			return;
		}
		Rectangle workingArea = Screen.FromHandle(base.Handle).WorkingArea;
		workingArea.Location = new Point(0, 0);
		base.MaximizedBounds = workingArea;
		base.WindowState = FormWindowState.Maximized;
	}

	public void D2220818(int int_0, string string_0, object object_0, bool C8823D15 = true)
	{
		if (C8823D15 || !(object_0.ToString().Trim() == ""))
		{
			EAB09F19.smethod_3(dgvTaiKhoan, int_0, string_0, object_0);
		}
	}

	public string method_1(int F3A8BCBB, string string_0)
	{
		return EAB09F19.E2A1ED2F(dgvTaiKhoan, F3A8BCBB, string_0);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void method_2()
	{
		for (int i = 0; i < D8AFF826.Count; i++)
		{
			string[] array = D8AFF826[i].Split('|');
			dgvTaiKhoan.Rows.Add(dgvTaiKhoan.RowCount + 1, Image.FromFile("images\\no_avatar.png"), array[0] + "\r\n" + array[5], array[0], array[1], array[2], array[3], array[4], array[6], array[7]);
		}
	}

	private void fQuanLyTinNhan_Load(object sender, EventArgs e)
	{
		method_2();
	}

	private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void method_3(Chrome F91FD9B6, Control C8A9E891)
	{
		Invoke((MethodInvoker)delegate
		{
			SetParent(F91FD9B6.Process_0.MainWindowHandle, C8A9E891.Handle);
			MoveWindow(F91FD9B6.Process_0.MainWindowHandle, -10, 0, C8A9E891.Size.Width + 20, C8A9E891.Size.Height + 20, bool_0: false);
		});
	}

	public int method_4(int int_0, string string_0, string string_1, string EA14011A, TabPage F1A5F02A, string string_2 = "", string string_3 = "")
	{
		int result = 0;
		int num = 0;
		try
		{
			if (string_0 == "")
			{
				string_0 = Regex.Match(string_2, "c_user=(\\d+)").Groups[1].Value;
			}
			Chrome chrome = null;
			bool flag = false;
			string text = "";
			if (string_0 != "")
			{
				text = C5034B95.smethod_2() + "\\" + string_0;
				if (!Directory.Exists(text))
				{
					text = "";
				}
			}
			chrome = new Chrome
			{
				Boolean_2 = false,
				F5BA98AC = new Point(300, 500),
				Point_0 = new Point(0, -1000),
				String_1 = text
			};
			chrome.CF8FD901 = int_0;
			chrome.B4208531 = string_0;
			chrome.C234EEAA = string_1;
			chrome.A1BF36A2 = EA14011A;
			chrome.String_2 = string_2;
			if (string_3 != "")
			{
				int int32_ = 0;
				if (string_3.EndsWith("*1"))
				{
					int32_ = 1;
				}
				if (string_3.EndsWith("*0") || string_3.EndsWith("*1"))
				{
					string_3 = string_3.Substring(0, string_3.Length - 2);
				}
				chrome.A3A32284 = string_3;
				chrome.Int32_1 = int32_;
			}
			do
			{
				(bool success, string error) tuple = chrome.method_0();
				var (flag2, _) = tuple;
				_ = tuple.error;
				if (!flag2)
				{
					break;
				}
				if (!C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP") && !chrome.C018519D())
				{
					chrome.A4B307B3();
					num++;
					continue;
				}
				method_3(chrome, F1A5F02A);
				if (!(flag = chrome.FE31BD92("https://m.facebook.com/") == 1))
				{
					if (string_0 != "" && string_1 != "")
					{
						flag = chrome.method_127(-1, "https://m.facebook.com/") == "1";
					}
					else if (string_2 != "")
					{
						flag = CommonChrome.C01C5FA0(chrome, string_2, "https://m.facebook.com/") == "1";
					}
				}
				if (!flag)
				{
					method_5(int_0, 1);
					string BC34CE2C = dgvTaiKhoan.Rows[int_0].Cells[3].Value.ToString();
					tabMain.Invoke((MethodInvoker)delegate
					{
						tabMain.TabPages.Remove(tabMain.TabPages[BC34CE2C]);
					});
					break;
				}
				method_5(int_0, 2);
				chrome.method_12("https://www.facebook.com/messages/t");
				string text2 = CommonRequest.smethod_4(string_0, "avatar");
				if (File.Exists(text2))
				{
					dgvTaiKhoan.Rows[int_0].Cells[1].Value = Image.FromFile(text2);
				}
				break;
			}
			while (num < 3);
		}
		catch (Exception)
		{
		}
		return result;
	}

	private void method_5(int A1308514, int E90F3F1E)
	{
		switch (E90F3F1E)
		{
		case 1:
			dgvTaiKhoan.Rows[A1308514].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
			break;
		case 2:
			dgvTaiKhoan.Rows[A1308514].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
			break;
		case 3:
			dgvTaiKhoan.Rows[A1308514].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
			break;
		}
	}

	private void method_6(string E634563D, string string_0)
	{
		try
		{
			using WebClient webClient = new WebClient();
			byte[] buffer = webClient.DownloadData(E634563D);
			using MemoryStream stream = new MemoryStream(buffer);
			using Image image = Image.FromStream(stream);
			try
			{
				image.Save(string_0 + ".png", ImageFormat.Png);
			}
			catch
			{
				image.Save(string_0 + ".jpg", ImageFormat.Jpeg);
			}
		}
		catch
		{
		}
	}

	private void AD39DD26(object sender, EventArgs e)
	{
		try
		{
			list_0 = new List<Thread>();
			List<int> DA134B9B = new List<int>();
			foreach (DataGridViewRow selectedRow in dgvTaiKhoan.SelectedRows)
			{
				DA134B9B.Add(selectedRow.Index);
			}
			int int_0 = DA134B9B.Count;
			new Thread((ThreadStart)delegate
			{
				try
				{
					int num = 0;
					while (num < DA134B9B.Count && list_0.Count < int_0)
					{
						int AC2523B8 = DA134B9B[num++];
						if (AC2523B8 != 0)
						{
							Thread.Sleep(Base.rd.Next(C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeFrom"), C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeTo") + 1) * 1000);
						}
						Thread thread = new Thread((ThreadStart)delegate
						{
							try
							{
								method_7(AC2523B8);
							}
							catch (Exception exception_3)
							{
								Commom.smethod_57(null, exception_3);
							}
						})
						{
							Name = AC2523B8.ToString()
						};
						list_0.Add(thread);
						Commom.smethod_52(1.0);
						thread.Start();
					}
					for (int i = 0; i < list_0.Count; i++)
					{
						list_0[i].Join();
					}
				}
				catch (Exception exception_2)
				{
					Commom.smethod_57(null, exception_2);
				}
			}).Start();
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
		}
	}

	private void method_7(int int_0)
	{
		int num = 0;
		string string_ = dgvTaiKhoan.Rows[int_0].Cells[6].Value.ToString();
		string text = dgvTaiKhoan.Rows[int_0].Cells[3].Value.ToString();
		string string_2 = dgvTaiKhoan.Rows[int_0].Cells[4].Value.ToString();
		string eA14011A = dgvTaiKhoan.Rows[int_0].Cells[5].Value.ToString();
		string string_3 = dgvTaiKhoan.Rows[int_0].Cells[7].Value.ToString();
		TabPage tabPage_0 = new TabPage();
		tabPage_0.Name = text;
		tabPage_0.Text = text;
		tabPage_0.BackColor = Color.White;
		tabPage_0.ForeColor = Color.White;
		for (int i = 0; i < tabMain.TabPages.Count; i++)
		{
			if (tabMain.TabPages[i].Name.ToString() == tabPage_0.Name)
			{
				num++;
				break;
			}
		}
		if (num == 0)
		{
			tabMain.Invoke((MethodInvoker)delegate
			{
				tabMain.ItemSize = new Size(0, 1);
				tabMain.TabPages.Add(tabPage_0);
			});
			method_4(int_0, text, string_2, eA14011A, tabPage_0, string_, string_3);
		}
	}

	private void BE260522(object sender, EventArgs e)
	{
		try
		{
			string string_0 = "";
			for (int i = 0; i < dgvTaiKhoan.SelectedRows.Count; i++)
			{
				string_0 = dgvTaiKhoan.SelectedRows[i].Cells[3].Value.ToString();
				if (tabMain.TabPages.Contains(tabMain.TabPages[string_0]))
				{
					tabMain.Invoke((MethodInvoker)delegate
					{
						tabMain.TabPages.Remove(tabMain.TabPages[string_0]);
					});
					method_5(dgvTaiKhoan.SelectedRows[i].Index, 3);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void A7A5E131(object sender, DataGridViewCellEventArgs e)
	{
		string text = dgvTaiKhoan.SelectedRows[0].Cells[3].Value.ToString();
		int num = 0;
		while (true)
		{
			if (num < tabMain.TabPages.Count)
			{
				if (tabMain.TabPages[num].Name.ToString() == text)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		tabMain.SelectedTab = tabMain.TabPages[text];
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		B51FA10D("Notes");
	}

	private void B51FA10D(string EAA5360E)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < dgvTaiKhoan.SelectedRows.Count; i++)
			{
				list.Add(method_1(dgvTaiKhoan.SelectedRows[i].Index, "cId"));
			}
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n ta\u0300i khoa\u0309n câ\u0300n câ\u0323p nhâ\u0323t!", 3);
			}
			else
			{
				Commom.smethod_35(new fUpdateData2(this, EAA5360E));
			}
		}
		catch
		{
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		button2 = new System.Windows.Forms.Button();
		B78177A4 = new System.Windows.Forms.Button();
		btnMinimize = new System.Windows.Forms.Button();
		F50EB9A7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		B90B8E86 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		tabMain = new System.Windows.Forms.TabControl();
		dgvTaiKhoan = new System.Windows.Forms.DataGridView();
		E7A4E28F = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cAvatar = new System.Windows.Forms.DataGridViewImageColumn();
		cTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
		DE00D535 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cFa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F99F2582 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F506A89D = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		B6850F98 = new System.Windows.Forms.ToolStripMenuItem();
		D0A5633E = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		B90B8E86.SuspendLayout();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
		contextMenuStrip1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = pnlHeader;
		bunifuDragControl_0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(B78177A4);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(F50EB9A7);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1080, 29);
		pnlHeader.TabIndex = 0;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(6, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 12;
		pictureBox1.TabStop = false;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Dock = System.Windows.Forms.DockStyle.Right;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.C3AFF300;
		button2.Location = new System.Drawing.Point(984, 0);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(32, 29);
		button2.TabIndex = 0;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		B78177A4.Cursor = System.Windows.Forms.Cursors.Hand;
		B78177A4.Dock = System.Windows.Forms.DockStyle.Right;
		B78177A4.Enabled = false;
		B78177A4.FlatAppearance.BorderSize = 0;
		B78177A4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B78177A4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B78177A4.ForeColor = System.Drawing.Color.White;
		B78177A4.Image = Class155.Bitmap_16;
		B78177A4.Location = new System.Drawing.Point(1016, 0);
		B78177A4.Name = "button1";
		B78177A4.Size = new System.Drawing.Size(32, 29);
		B78177A4.TabIndex = 1;
		B78177A4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B78177A4.UseVisualStyleBackColor = true;
		B78177A4.Click += new System.EventHandler(B78177A4_Click);
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = Class155.Bitmap_15;
		btnMinimize.Location = new System.Drawing.Point(1048, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 29);
		btnMinimize.TabIndex = 2;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		F50EB9A7.AutoSize = true;
		F50EB9A7.BackColor = System.Drawing.Color.Transparent;
		F50EB9A7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F50EB9A7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F50EB9A7.ForeColor = System.Drawing.Color.Black;
		F50EB9A7.Location = new System.Drawing.Point(43, 6);
		F50EB9A7.Name = "bunifuCustomLabel1";
		F50EB9A7.Size = new System.Drawing.Size(177, 16);
		F50EB9A7.TabIndex = 3;
		F50EB9A7.Text = "Quản lý tin nhắn hàng loạt";
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = F50EB9A7;
		bunifuDragControl_1.Vertical = true;
		B90B8E86.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B90B8E86.BackColor = System.Drawing.Color.White;
		B90B8E86.BorderRadius = 0;
		B90B8E86.BottomSahddow = true;
		B90B8E86.color = System.Drawing.Color.RoyalBlue;
		B90B8E86.Controls.Add(pnlHeader);
		B90B8E86.LeftSahddow = false;
		B90B8E86.Location = new System.Drawing.Point(0, -1);
		B90B8E86.Name = "bunifuCards1";
		B90B8E86.RightSahddow = true;
		B90B8E86.ShadowDepth = 20;
		B90B8E86.Size = new System.Drawing.Size(1081, 38);
		B90B8E86.TabIndex = 0;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(dgvTaiKhoan);
		panel1.Controls.Add(B90B8E86);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1082, 565);
		panel1.TabIndex = 8;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(tabMain);
		panel2.Location = new System.Drawing.Point(7, 39);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(693, 519);
		panel2.TabIndex = 8;
		tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		tabMain.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabMain.Location = new System.Drawing.Point(0, 0);
		tabMain.Multiline = true;
		tabMain.Name = "tabMain";
		tabMain.SelectedIndex = 0;
		tabMain.Size = new System.Drawing.Size(693, 518);
		tabMain.TabIndex = 7;
		dgvTaiKhoan.AllowUserToAddRows = false;
		dgvTaiKhoan.AllowUserToDeleteRows = false;
		dgvTaiKhoan.AllowUserToResizeColumns = false;
		dgvTaiKhoan.AllowUserToResizeRows = false;
		dgvTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvTaiKhoan.Columns.AddRange(E7A4E28F, cAvatar, cTaiKhoan, DE00D535, cPassword, cFa2, F99F2582, F506A89D, cGhiChu, cId);
		dgvTaiKhoan.ContextMenuStrip = contextMenuStrip1;
		dgvTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
		dgvTaiKhoan.Location = new System.Drawing.Point(706, 39);
		dgvTaiKhoan.Name = "dgvTaiKhoan";
		dgvTaiKhoan.ReadOnly = true;
		dgvTaiKhoan.RowHeadersVisible = false;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dgvTaiKhoan.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dgvTaiKhoan.RowTemplate.Height = 50;
		dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dgvTaiKhoan.Size = new System.Drawing.Size(369, 519);
		dgvTaiKhoan.TabIndex = 6;
		dgvTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(A7A5E131);
		dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvTaiKhoan_CellContentClick);
		E7A4E28F.HeaderText = "STT";
		E7A4E28F.Name = "cStt";
		E7A4E28F.ReadOnly = true;
		E7A4E28F.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		E7A4E28F.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		E7A4E28F.Width = 40;
		cAvatar.FillWeight = 50f;
		cAvatar.HeaderText = "Avatar";
		cAvatar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
		cAvatar.Name = "cAvatar";
		cAvatar.ReadOnly = true;
		cAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		cAvatar.Width = 70;
		cTaiKhoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		cTaiKhoan.DefaultCellStyle = dataGridViewCellStyle4;
		cTaiKhoan.HeaderText = "Tài khoản";
		cTaiKhoan.Name = "cTaiKhoan";
		cTaiKhoan.ReadOnly = true;
		cTaiKhoan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		cTaiKhoan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		DE00D535.HeaderText = "Uid";
		DE00D535.Name = "cUid";
		DE00D535.ReadOnly = true;
		DE00D535.Visible = false;
		cPassword.HeaderText = "Password";
		cPassword.Name = "cPassword";
		cPassword.ReadOnly = true;
		cPassword.Visible = false;
		cFa2.HeaderText = "2fa";
		cFa2.Name = "cFa2";
		cFa2.ReadOnly = true;
		cFa2.Visible = false;
		F99F2582.HeaderText = "Cookie";
		F99F2582.Name = "cCookies";
		F99F2582.ReadOnly = true;
		F99F2582.Visible = false;
		F506A89D.HeaderText = "Proxy";
		F506A89D.Name = "cProxy";
		F506A89D.ReadOnly = true;
		F506A89D.Visible = false;
		cGhiChu.HeaderText = "Ghi chú";
		cGhiChu.Name = "cGhiChu";
		cGhiChu.ReadOnly = true;
		cId.HeaderText = "Id";
		cId.Name = "cId";
		cId.ReadOnly = true;
		cId.Visible = false;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { B6850F98, D0A5633E, toolStripMenuItem_0 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(165, 70);
		B6850F98.Image = Class155.Bitmap_120;
		B6850F98.Name = "hiểnThịToolStripMenuItem";
		B6850F98.Size = new System.Drawing.Size(164, 22);
		B6850F98.Text = "Mở trình duyệt";
		B6850F98.Click += new System.EventHandler(AD39DD26);
		D0A5633E.Image = Class155.Bitmap_148;
		D0A5633E.Name = "đóngToolStripMenuItem";
		D0A5633E.Size = new System.Drawing.Size(164, 22);
		D0A5633E.Text = "Đóng trình duyệt";
		D0A5633E.Click += new System.EventHandler(BE260522);
		toolStripMenuItem_0.Image = Class155.D28519B3;
		toolStripMenuItem_0.Name = "sửaGhiChúToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(164, 22);
		toolStripMenuItem_0.Text = "Sửa ghi chú";
		toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1082, 565);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fQuanLyTinNhan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Quản lý tin nhắn";
		base.Load += new System.EventHandler(fQuanLyTinNhan_Load);
		pnlHeader.ResumeLayout(false);
		pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		B90B8E86.ResumeLayout(false);
		panel1.ResumeLayout(false);
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
