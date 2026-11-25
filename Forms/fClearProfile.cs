using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fClearProfile : Form
{
	[CompilerGenerated]
	private sealed class Class103
	{
		internal int int_0;

		internal int int_1;

		internal fClearProfile A51EFE3F;

		internal int E437CA01;

		internal Action C9297228;

		internal void D40C73A2()
		{
			try
			{
				if (Class59.ED081E86())
				{
					int num = 0;
					while (num < A51EFE3F.list_0.Count)
					{
						Class104 CS_0024_003C_003E8__locals0 = new Class104
						{
							class103_0 = this
						};
						if (int_0 >= int_1)
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.int_0 = num++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								Class59.smethod_3(CS_0024_003C_003E8__locals0.class103_0.A51EFE3F.list_0[CS_0024_003C_003E8__locals0.int_0]);
								Interlocked.Increment(ref CS_0024_003C_003E8__locals0.class103_0.E437CA01);
								CS_0024_003C_003E8__locals0.class103_0.A51EFE3F.method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), CS_0024_003C_003E8__locals0.class103_0.E437CA01, CS_0024_003C_003E8__locals0.class103_0.A51EFE3F.list_0.Count));
								Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.class103_0.int_0);
							}
							catch
							{
							}
						}).Start();
					}
				}
				else
				{
					int num2 = 0;
					while (num2 < A51EFE3F.list_0.Count)
					{
						Class105 CS_0024_003C_003E8__locals1 = new Class105
						{
							class103_0 = this
						};
						if (int_0 >= int_1)
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals1.int_0 = num2++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string path = C5034B95.smethod_2() + "\\" + CS_0024_003C_003E8__locals1.class103_0.A51EFE3F.list_0[CS_0024_003C_003E8__locals1.int_0];
								Directory.Delete(path, recursive: true);
								Interlocked.Increment(ref CS_0024_003C_003E8__locals1.class103_0.E437CA01);
								CS_0024_003C_003E8__locals1.class103_0.A51EFE3F.method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), CS_0024_003C_003E8__locals1.class103_0.E437CA01, CS_0024_003C_003E8__locals1.class103_0.A51EFE3F.list_0.Count));
								Interlocked.Decrement(ref CS_0024_003C_003E8__locals1.class103_0.int_0);
							}
							catch
							{
							}
						}).Start();
					}
				}
				while (int_0 > 0)
				{
					Commom.smethod_52(1.0);
				}
				A51EFE3F.Invoke((Action)delegate
				{
					A51EFE3F.Close();
					MsBoxHelper.Show("Đã dọn dẹp profile xong!");
				});
			}
			catch
			{
			}
		}

		internal void AC0B8C8E()
		{
			A51EFE3F.Close();
			MsBoxHelper.Show("Đã dọn dẹp profile xong!");
		}
	}

	[CompilerGenerated]
	private sealed class Class104
	{
		internal int int_0;

		internal Class103 class103_0;

		internal void EEAAEB2C()
		{
			try
			{
				Class59.smethod_3(class103_0.A51EFE3F.list_0[int_0]);
				Interlocked.Increment(ref class103_0.E437CA01);
				class103_0.A51EFE3F.method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), class103_0.E437CA01, class103_0.A51EFE3F.list_0.Count));
				Interlocked.Decrement(ref class103_0.int_0);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class105
	{
		internal int int_0;

		internal Class103 class103_0;

		internal void method_0()
		{
			try
			{
				string path = C5034B95.smethod_2() + "\\" + class103_0.A51EFE3F.list_0[int_0];
				Directory.Delete(path, recursive: true);
				Interlocked.Increment(ref class103_0.E437CA01);
				class103_0.A51EFE3F.method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), class103_0.E437CA01, class103_0.A51EFE3F.list_0.Count));
				Interlocked.Decrement(ref class103_0.int_0);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class106
	{
		internal fClearProfile fClearProfile_0;

		internal string string_0;

		internal void method_0()
		{
			fClearProfile_0.D7999C1A.Text = string_0;
		}
	}

	internal List<string> list_0 = new List<string>();

	internal IContainer icontainer_0 = null;

	internal BunifuCards DB8FB294;

	internal Panel D8209732;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button CBB4B225;

	internal Button CDBC3B89;

	internal BunifuDragControl B8A4298A;

	internal BunifuCustomLabel D7999C1A;

	internal PictureBox FB8CAAB8;

	public fClearProfile()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B0270085(object sender, EventArgs e)
	{
		Close();
	}

	private void AA0A6E1E(object sender, EventArgs e)
	{
		CDBC3B89.Enabled = false;
		CBB4B225.Enabled = false;
		int E437CA = 0;
		method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), E437CA, list_0.Count));
		int int_0 = 0;
		int int_1 = 20;
		new Thread((ThreadStart)delegate
		{
			try
			{
				if (Class59.ED081E86())
				{
					int num = 0;
					while (num < list_0.Count)
					{
						if (int_0 >= int_1)
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
						Interlocked.Increment(ref int_0);
						int int_3 = num++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								Class59.smethod_3(list_0[int_3]);
								Interlocked.Increment(ref E437CA);
								method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), E437CA, list_0.Count));
								Interlocked.Decrement(ref int_0);
							}
							catch
							{
							}
						}).Start();
					}
				}
				else
				{
					int num2 = 0;
					while (num2 < list_0.Count)
					{
						if (int_0 >= int_1)
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
						Interlocked.Increment(ref int_0);
						int int_2 = num2++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string path = C5034B95.smethod_2() + "\\" + list_0[int_2];
								Directory.Delete(path, recursive: true);
								Interlocked.Increment(ref E437CA);
								method_1(string.Format(Language.GetValue("Đang dọn dẹp profile {0}/{1}..."), E437CA, list_0.Count));
								Interlocked.Decrement(ref int_0);
							}
							catch
							{
							}
						}).Start();
					}
				}
				while (int_0 > 0)
				{
					Commom.smethod_52(1.0);
				}
				Invoke((Action)delegate
				{
					Close();
					MsBoxHelper.Show("Đã dọn dẹp profile xong!");
				});
			}
			catch
			{
			}
		}).Start();
	}

	private void CBB4B225_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A816E12E(object sender, EventArgs e)
	{
	}

	private List<string> method_0()
	{
		List<string> list = new List<string>();
		try
		{
			DataTable dataTable = CommonSQL.smethod_12();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list.Add(dataTable.Rows[i]["uid"].ToString());
			}
		}
		catch
		{
		}
		return list;
	}

	private void method_1(string string_0)
	{
		Invoke((Action)delegate
		{
			D7999C1A.Text = string_0;
		});
	}

	private void fClearProfile_Load(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			try
			{
				List<string> list = method_0();
				if (Class59.ED081E86())
				{
					Dictionary<string, string> dictionary = Class59.smethod_1();
					foreach (KeyValuePair<string, string> item in dictionary)
					{
						if (!list.Contains(item.Key))
						{
							list_0.Add(item.Value);
						}
					}
				}
				else
				{
					List<string> list2 = Directory.GetDirectories(C5034B95.smethod_2()).ToList();
					string text = "";
					for (int i = 0; i < list2.Count; i++)
					{
						text = list2[i].Substring(list2[i].LastIndexOf("\\") + 1);
						if (!list.Contains(text))
						{
							list_0.Add(text);
						}
					}
				}
				if (list_0.Count > 0)
				{
					Invoke((Action)delegate
					{
						D7999C1A.Text = string.Format(Language.GetValue("Tìm thấy {0} profile rác!"), list_0.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
						CDBC3B89.Visible = true;
						CBB4B225.Visible = true;
					});
				}
				else
				{
					Invoke((Action)delegate
					{
						Close();
						MsBoxHelper.Show("Không có profile rác!");
					});
				}
			}
			catch (Exception)
			{
			}
		}).Start();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fClearProfile));
		DB8FB294 = new Bunifu.Framework.UI.BunifuCards();
		D8209732 = new System.Windows.Forms.Panel();
		FB8CAAB8 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		CBB4B225 = new System.Windows.Forms.Button();
		CDBC3B89 = new System.Windows.Forms.Button();
		B8A4298A = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D7999C1A = new Bunifu.Framework.UI.BunifuCustomLabel();
		DB8FB294.SuspendLayout();
		D8209732.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FB8CAAB8).BeginInit();
		SuspendLayout();
		DB8FB294.BackColor = System.Drawing.Color.White;
		DB8FB294.BorderRadius = 0;
		DB8FB294.BottomSahddow = true;
		DB8FB294.color = System.Drawing.Color.SaddleBrown;
		DB8FB294.Controls.Add(D8209732);
		DB8FB294.Dock = System.Windows.Forms.DockStyle.Top;
		DB8FB294.LeftSahddow = false;
		DB8FB294.Location = new System.Drawing.Point(0, 0);
		DB8FB294.Name = "bunifuCards1";
		DB8FB294.RightSahddow = true;
		DB8FB294.ShadowDepth = 20;
		DB8FB294.Size = new System.Drawing.Size(396, 38);
		DB8FB294.TabIndex = 0;
		D8209732.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D8209732.BackColor = System.Drawing.Color.White;
		D8209732.Controls.Add(FB8CAAB8);
		D8209732.Controls.Add(btnMinimize);
		D8209732.Controls.Add(bunifuCustomLabel1);
		D8209732.Location = new System.Drawing.Point(0, 5);
		D8209732.Name = "pnlHeader";
		D8209732.Size = new System.Drawing.Size(396, 32);
		D8209732.TabIndex = 9;
		FB8CAAB8.Cursor = System.Windows.Forms.Cursors.Default;
		FB8CAAB8.Image = Class155.DD225F0D;
		FB8CAAB8.Location = new System.Drawing.Point(3, 2);
		FB8CAAB8.Name = "pictureBox1";
		FB8CAAB8.Size = new System.Drawing.Size(34, 27);
		FB8CAAB8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		FB8CAAB8.TabIndex = 17;
		FB8CAAB8.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(364, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(B0270085);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(396, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Dọn dẹp profile";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CBB4B225.BackColor = System.Drawing.Color.Maroon;
		CBB4B225.Cursor = System.Windows.Forms.Cursors.Hand;
		CBB4B225.FlatAppearance.BorderSize = 0;
		CBB4B225.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CBB4B225.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CBB4B225.ForeColor = System.Drawing.Color.White;
		CBB4B225.Location = new System.Drawing.Point(204, 105);
		CBB4B225.Name = "btnCancel";
		CBB4B225.Size = new System.Drawing.Size(92, 29);
		CBB4B225.TabIndex = 4;
		CBB4B225.Text = "Hủy";
		CBB4B225.UseVisualStyleBackColor = false;
		CBB4B225.Visible = false;
		CBB4B225.Click += new System.EventHandler(CBB4B225_Click);
		CDBC3B89.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		CDBC3B89.Cursor = System.Windows.Forms.Cursors.Hand;
		CDBC3B89.FlatAppearance.BorderSize = 0;
		CDBC3B89.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CDBC3B89.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CDBC3B89.ForeColor = System.Drawing.Color.White;
		CDBC3B89.Location = new System.Drawing.Point(100, 105);
		CDBC3B89.Name = "btnAdd";
		CDBC3B89.Size = new System.Drawing.Size(92, 29);
		CDBC3B89.TabIndex = 3;
		CDBC3B89.Text = "Đồng ý";
		CDBC3B89.UseVisualStyleBackColor = false;
		CDBC3B89.Visible = false;
		CDBC3B89.Click += new System.EventHandler(AA0A6E1E);
		B8A4298A.Fixed = true;
		B8A4298A.Horizontal = true;
		B8A4298A.TargetControl = bunifuCustomLabel1;
		B8A4298A.Vertical = true;
		D7999C1A.BackColor = System.Drawing.Color.Transparent;
		D7999C1A.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D7999C1A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D7999C1A.ForeColor = System.Drawing.Color.Black;
		D7999C1A.Location = new System.Drawing.Point(-1, 57);
		D7999C1A.Name = "lblStatus";
		D7999C1A.Size = new System.Drawing.Size(396, 32);
		D7999C1A.TabIndex = 21;
		D7999C1A.Text = "Đang quét profile...";
		D7999C1A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D7999C1A.Click += new System.EventHandler(A816E12E);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(396, 145);
		base.Controls.Add(D7999C1A);
		base.Controls.Add(CBB4B225);
		base.Controls.Add(CDBC3B89);
		base.Controls.Add(DB8FB294);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fClearProfile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fClearProfile_Load);
		DB8FB294.ResumeLayout(false);
		D8209732.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)FB8CAAB8).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void BCAA1095()
	{
		try
		{
			List<string> list = method_0();
			if (Class59.ED081E86())
			{
				Dictionary<string, string> dictionary = Class59.smethod_1();
				foreach (KeyValuePair<string, string> item in dictionary)
				{
					if (!list.Contains(item.Key))
					{
						list_0.Add(item.Value);
					}
				}
			}
			else
			{
				List<string> list2 = Directory.GetDirectories(C5034B95.smethod_2()).ToList();
				string text = "";
				for (int i = 0; i < list2.Count; i++)
				{
					text = list2[i].Substring(list2[i].LastIndexOf("\\") + 1);
					if (!list.Contains(text))
					{
						list_0.Add(text);
					}
				}
			}
			if (list_0.Count > 0)
			{
				Invoke((Action)delegate
				{
					D7999C1A.Text = string.Format(Language.GetValue("Tìm thấy {0} profile rác!"), list_0.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
					CDBC3B89.Visible = true;
					CBB4B225.Visible = true;
				});
			}
			else
			{
				Invoke((Action)delegate
				{
					Close();
					MsBoxHelper.Show("Không có profile rác!");
				});
			}
		}
		catch (Exception)
		{
		}
	}

	[CompilerGenerated]
	private void D4A71418()
	{
		D7999C1A.Text = string.Format(Language.GetValue("Tìm thấy {0} profile rác!"), list_0.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
		CDBC3B89.Visible = true;
		CBB4B225.Visible = true;
	}

	[CompilerGenerated]
	private void method_2()
	{
		Close();
		MsBoxHelper.Show("Không có profile rác!");
	}
}
