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

public class fClearBackup : Form
{
	[CompilerGenerated]
	private sealed class Class69
	{
		internal int int_0;

		internal int int_1;

		internal string EE0B6695;

		internal fClearBackup fClearBackup_0;

		internal int B099B30F;

		internal Action action_0;

		internal void method_0()
		{
			try
			{
				int num = 0;
				while (num < fClearBackup_0.D302C097.Count)
				{
					if (int_0 < int_1)
					{
						Class70 CS_0024_003C_003E8__locals0 = new Class70
						{
							class69_0 = this
						};
						Interlocked.Increment(ref int_0);
						CS_0024_003C_003E8__locals0.B497A291 = num++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string path = CS_0024_003C_003E8__locals0.class69_0.EE0B6695 + "\\" + CS_0024_003C_003E8__locals0.class69_0.fClearBackup_0.D302C097[CS_0024_003C_003E8__locals0.B497A291];
								Directory.Delete(path, recursive: true);
								Interlocked.Increment(ref CS_0024_003C_003E8__locals0.class69_0.B099B30F);
								CS_0024_003C_003E8__locals0.class69_0.fClearBackup_0.DE9D3433(string.Format(Language.GetValue("Đang dọn dẹp backup {0}/{1}..."), CS_0024_003C_003E8__locals0.class69_0.B099B30F, CS_0024_003C_003E8__locals0.class69_0.fClearBackup_0.D302C097.Count));
								Interlocked.Decrement(ref CS_0024_003C_003E8__locals0.class69_0.int_0);
							}
							catch
							{
							}
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				while (int_0 > 0)
				{
					Commom.smethod_52(1.0);
				}
				fClearBackup_0.Invoke((Action)delegate
				{
					fClearBackup_0.Close();
					MsBoxHelper.Show("Đã dọn dẹp file backup xong!");
				});
			}
			catch
			{
			}
		}

		internal void method_1()
		{
			fClearBackup_0.Close();
			MsBoxHelper.Show("Đã dọn dẹp file backup xong!");
		}
	}

	[CompilerGenerated]
	private sealed class Class70
	{
		internal int B497A291;

		internal Class69 class69_0;

		internal void method_0()
		{
			try
			{
				string path = class69_0.EE0B6695 + "\\" + class69_0.fClearBackup_0.D302C097[B497A291];
				Directory.Delete(path, recursive: true);
				Interlocked.Increment(ref class69_0.B099B30F);
				class69_0.fClearBackup_0.DE9D3433(string.Format(Language.GetValue("Đang dọn dẹp backup {0}/{1}..."), class69_0.B099B30F, class69_0.fClearBackup_0.D302C097.Count));
				Interlocked.Decrement(ref class69_0.int_0);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class A43CCE0F
	{
		internal fClearBackup fClearBackup_0;

		internal string string_0;

		internal void method_0()
		{
			fClearBackup_0.B20343B7.Text = string_0;
		}
	}

	internal List<string> D302C097 = new List<string>();

	internal IContainer FB2D2E8E = null;

	internal BunifuCards bunifuCards1;

	internal Panel A825C4AC;

	internal BunifuCustomLabel E89EFA2A;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl BF2BF625;

	internal BunifuCustomLabel B20343B7;

	internal PictureBox pictureBox1;

	public fClearBackup()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		btnAdd.Enabled = false;
		btnCancel.Enabled = false;
		DE9D3433(string.Format(Language.GetValue("Đang dọn dẹp backup {0}/{1}..."), 0, D302C097.Count));
		int int_0 = 0;
		int int_1 = 20;
		int B099B30F = 0;
		string EE0B6695 = Commom.smethod_95() + "\\backup";
		new Thread((ThreadStart)delegate
		{
			try
			{
				int num = 0;
				while (num < D302C097.Count)
				{
					if (int_0 < int_1)
					{
						Interlocked.Increment(ref int_0);
						int B497A291 = num++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string path = EE0B6695 + "\\" + D302C097[B497A291];
								Directory.Delete(path, recursive: true);
								Interlocked.Increment(ref B099B30F);
								DE9D3433(string.Format(Language.GetValue("Đang dọn dẹp backup {0}/{1}..."), B099B30F, D302C097.Count));
								Interlocked.Decrement(ref int_0);
							}
							catch
							{
							}
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				while (int_0 > 0)
				{
					Commom.smethod_52(1.0);
				}
				Invoke((Action)delegate
				{
					Close();
					MsBoxHelper.Show("Đã dọn dẹp file backup xong!");
				});
			}
			catch
			{
			}
		}).Start();
	}

	private void AE2DD208(object sender, EventArgs e)
	{
		Close();
	}

	private void B20343B7_Click(object sender, EventArgs e)
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

	private void DE9D3433(string F992342E)
	{
		Invoke((Action)delegate
		{
			B20343B7.Text = F992342E;
		});
	}

	private void fClearBackup_Load(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			try
			{
				List<string> list = Directory.GetDirectories(Commom.smethod_95() + "\\backup").ToList();
				List<string> list2 = method_0();
				string text = "";
				for (int i = 0; i < list.Count; i++)
				{
					text = list[i].Substring(list[i].LastIndexOf("\\") + 1);
					if (!list2.Contains(text))
					{
						D302C097.Add(text);
					}
				}
				if (D302C097.Count > 0)
				{
					Invoke((Action)delegate
					{
						B20343B7.Text = string.Format(Language.GetValue("Tìm thấy {0} file backup rác!"), D302C097.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
						btnAdd.Visible = true;
						btnCancel.Visible = true;
					});
				}
				else
				{
					Invoke((Action)delegate
					{
						Close();
						MsBoxHelper.Show("Không có file backup rác!");
					});
				}
			}
			catch
			{
			}
		}).Start();
	}

	protected override void Dispose(bool A60C772F)
	{
		if (A60C772F && FB2D2E8E != null)
		{
			FB2D2E8E.Dispose();
		}
		base.Dispose(A60C772F);
	}

	private void InitializeComponent()
	{
		FB2D2E8E = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fClearBackup));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A825C4AC = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		E89EFA2A = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		BF2BF625 = new Bunifu.Framework.UI.BunifuDragControl(FB2D2E8E);
		B20343B7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuCards1.SuspendLayout();
		A825C4AC.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(A825C4AC);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(396, 38);
		bunifuCards1.TabIndex = 0;
		A825C4AC.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A825C4AC.BackColor = System.Drawing.Color.White;
		A825C4AC.Controls.Add(pictureBox1);
		A825C4AC.Controls.Add(btnMinimize);
		A825C4AC.Controls.Add(E89EFA2A);
		A825C4AC.Location = new System.Drawing.Point(0, 5);
		A825C4AC.Name = "pnlHeader";
		A825C4AC.Size = new System.Drawing.Size(396, 32);
		A825C4AC.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
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
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		E89EFA2A.BackColor = System.Drawing.Color.Transparent;
		E89EFA2A.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E89EFA2A.Dock = System.Windows.Forms.DockStyle.Fill;
		E89EFA2A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E89EFA2A.ForeColor = System.Drawing.Color.Black;
		E89EFA2A.Location = new System.Drawing.Point(0, 0);
		E89EFA2A.Name = "bunifuCustomLabel1";
		E89EFA2A.Size = new System.Drawing.Size(396, 32);
		E89EFA2A.TabIndex = 1;
		E89EFA2A.Text = "Dọn dẹp backup";
		E89EFA2A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(204, 105);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Hủy";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Visible = false;
		btnCancel.Click += new System.EventHandler(AE2DD208);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(100, 105);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Đồng ý";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Visible = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		BF2BF625.Fixed = true;
		BF2BF625.Horizontal = true;
		BF2BF625.TargetControl = E89EFA2A;
		BF2BF625.Vertical = true;
		B20343B7.BackColor = System.Drawing.Color.Transparent;
		B20343B7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B20343B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B20343B7.ForeColor = System.Drawing.Color.Black;
		B20343B7.Location = new System.Drawing.Point(-1, 57);
		B20343B7.Name = "lblStatus";
		B20343B7.Size = new System.Drawing.Size(396, 32);
		B20343B7.TabIndex = 21;
		B20343B7.Text = "Đang quét file backup...";
		B20343B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B20343B7.Click += new System.EventHandler(B20343B7_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(396, 145);
		base.Controls.Add(B20343B7);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fClearBackup";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fClearBackup_Load);
		bunifuCards1.ResumeLayout(false);
		A825C4AC.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void B5838F35()
	{
		try
		{
			List<string> list = Directory.GetDirectories(Commom.smethod_95() + "\\backup").ToList();
			List<string> list2 = method_0();
			string text = "";
			for (int i = 0; i < list.Count; i++)
			{
				text = list[i].Substring(list[i].LastIndexOf("\\") + 1);
				if (!list2.Contains(text))
				{
					D302C097.Add(text);
				}
			}
			if (D302C097.Count > 0)
			{
				Invoke((Action)delegate
				{
					B20343B7.Text = string.Format(Language.GetValue("Tìm thấy {0} file backup rác!"), D302C097.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
					btnAdd.Visible = true;
					btnCancel.Visible = true;
				});
			}
			else
			{
				Invoke((Action)delegate
				{
					Close();
					MsBoxHelper.Show("Không có file backup rác!");
				});
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private void D195C9A4()
	{
		B20343B7.Text = string.Format(Language.GetValue("Tìm thấy {0} file backup rác!"), D302C097.Count) + "\r\n" + Language.GetValue("Bạn có muốn dọn dẹp?");
		btnAdd.Visible = true;
		btnCancel.Visible = true;
	}

	[CompilerGenerated]
	private void method_1()
	{
		Close();
		MsBoxHelper.Show("Không có file backup rác!");
	}
}
