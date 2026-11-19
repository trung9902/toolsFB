using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fGiaiPhongDungLuong : Form
{
	[CompilerGenerated]
	private sealed class DE825C8D
	{
		internal Label label_0;

		internal string string_0;

		internal void D41ECCAA()
		{
			label_0.Text = string_0;
		}
	}

	[CompilerGenerated]
	private sealed class Class71
	{
		internal Label A182410D;

		internal void F48AEB0C()
		{
			A182410D.Visible = true;
		}
	}

	[CompilerGenerated]
	private sealed class Class72
	{
		internal bool bool_0;

		internal Label label_0;

		internal void method_0()
		{
			if (bool_0)
			{
				label_0.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			}
			else
			{
				label_0.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class73
	{
		internal List<string> list_0;

		internal fGiaiPhongDungLuong fGiaiPhongDungLuong_0;
	}

	[CompilerGenerated]
	private sealed class F80C0B21
	{
		internal int B6B37D00;

		internal int int_0;

		internal Class73 class73_0;
	}

	[CompilerGenerated]
	private sealed class Class74
	{
		internal int int_0;

		internal F80C0B21 f80C0B21_0;

		internal void method_0()
		{
			try
			{
				string string_ = C5034B95.smethod_2() + "\\" + f80C0B21_0.class73_0.list_0[int_0];
				Commom.DeleteFolder(string_);
				Interlocked.Increment(ref f80C0B21_0.B6B37D00);
				f80C0B21_0.class73_0.fGiaiPhongDungLuong_0.AA2CE235(f80C0B21_0.class73_0.fGiaiPhongDungLuong_0.AFA0D013, Language.GetValue("Đang chạy") + $" {f80C0B21_0.B6B37D00}/{f80C0B21_0.class73_0.list_0.Count}...");
				Interlocked.Decrement(ref f80C0B21_0.int_0);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class75
	{
		internal int int_0;

		internal List<string> list_0;

		internal int CCBD5F05;

		internal fGiaiPhongDungLuong fGiaiPhongDungLuong_0;
	}

	[CompilerGenerated]
	private sealed class B5857EA4
	{
		internal string string_0;

		internal Class75 class75_0;

		internal void D9167496()
		{
			try
			{
				string f4A671B = C5034B95.smethod_2() + "\\" + string_0;
				Commom.DeleteCacheProfile(f4A671B);
				Interlocked.Increment(ref class75_0.int_0);
				class75_0.fGiaiPhongDungLuong_0.AA2CE235(class75_0.fGiaiPhongDungLuong_0.lblStatusXoaCacheProfile, Language.GetValue("Đang chạy") + $" {class75_0.int_0}/{class75_0.list_0.Count}...");
				Interlocked.Decrement(ref class75_0.CCBD5F05);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class76
	{
		internal List<string> F1103618;

		internal int int_0;

		internal int int_1;

		internal fGiaiPhongDungLuong fGiaiPhongDungLuong_0;
	}

	[CompilerGenerated]
	private sealed class Class77
	{
		internal int int_0;

		internal Class76 class76_0;

		internal void ADB62484()
		{
			try
			{
				Commom.DeleteFolder(class76_0.F1103618[int_0]);
				Interlocked.Increment(ref class76_0.int_0);
				class76_0.fGiaiPhongDungLuong_0.AA2CE235(class76_0.fGiaiPhongDungLuong_0.lblStatusXoaTemp, Language.GetValue("Đang chạy") + $" {class76_0.int_0}/{class76_0.F1103618.Count}...");
				Interlocked.Decrement(ref class76_0.int_1);
			}
			catch
			{
			}
		}
	}

	internal bool DA80DE9B = false;

	internal bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel E31E2AB1;

	internal BunifuCustomLabel C41DE234;

	internal Button btnMinimize;

	internal Button BEB73CAD;

	internal BunifuDragControl C9968A81;

	internal PictureBox pictureBox1;

	internal Label lblXoaFileRac;

	internal Label lblDonDepProfileRac;

	internal Label lblXoaCacheProfile;

	internal Label lblStatusXoaFileRac;

	internal Label AFA0D013;

	internal Label lblStatusXoaCacheProfile;

	internal Label lblStatusXoaTemp;

	internal Label E5A5CD38;

	public fGiaiPhongDungLuong(bool bool_1 = false)
	{
		InitializeComponent();
		DA80DE9B = bool_1;
		Language.CD21F0A9(this);
	}

	private void FBA87732(object sender, EventArgs e)
	{
		Close();
	}

	private void BEB73CAD_Click(object sender, EventArgs e)
	{
		BEB73CAD.Invoke((Action)delegate
		{
			BEB73CAD.Enabled = false;
		});
		bool_0 = true;
	}

	private List<string> A082FC98()
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

	private void AA2CE235(Label label_0, string string_0)
	{
		try
		{
			Invoke((Action)delegate
			{
				label_0.Text = string_0;
			});
		}
		catch
		{
		}
	}

	private void D89B6497(Label label_0)
	{
		try
		{
			Invoke((Action)delegate
			{
				label_0.Visible = true;
			});
		}
		catch
		{
		}
	}

	private void method_0(Label label_0, bool bool_1 = true)
	{
		try
		{
			Invoke((Action)delegate
			{
				if (bool_1)
				{
					label_0.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
				}
				else
				{
					label_0.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			});
		}
		catch
		{
		}
	}

	private void fGiaiPhongDungLuong_Load(object sender, EventArgs e)
	{
		Commom.KillProcess("chromedriver");
		new Thread((ThreadStart)delegate
		{
			try
			{
				method_0(lblXoaFileRac);
				AA2CE235(lblStatusXoaFileRac, Language.GetValue("Đang chạy") + "...");
				D89B6497(lblStatusXoaFileRac);
				Commom.DeleteFolder("log");
				Commom.DeleteFolder("log_capture");
				Commom.DeleteFolder("Plugins");
				Commom.DeleteFolder("golike");
				Commom.E10A40B6("logJob.txt");
				if (!bool_0)
				{
					AA2CE235(lblStatusXoaFileRac, Language.GetValue("Hoàn thành!"));
					method_0(lblXoaFileRac, bool_1: false);
					method_0(lblDonDepProfileRac);
					AA2CE235(AFA0D013, "");
					D89B6497(AFA0D013);
					int num = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
					List<string> list = Directory.GetDirectories(C5034B95.smethod_2()).ToList();
					List<string> list2 = A082FC98();
					List<string> list_ = new List<string>();
					string text = "";
					for (int i = 0; i < list.Count; i++)
					{
						text = list[i].Substring(list[i].LastIndexOf("\\") + 1);
						if (!list2.Contains(text))
						{
							list_.Add(text);
						}
					}
					try
					{
						int int_4 = 0;
						int B6B37D0 = 0;
						int num2 = 0;
						while (num2 < list_.Count && !bool_0)
						{
							if (int_4 < num)
							{
								Interlocked.Increment(ref int_4);
								int int_3 = num2++;
								new Thread((ThreadStart)delegate
								{
									try
									{
										string string_ = C5034B95.smethod_2() + "\\" + list_[int_3];
										Commom.DeleteFolder(string_);
										Interlocked.Increment(ref B6B37D0);
										AA2CE235(AFA0D013, Language.GetValue("Đang chạy") + $" {B6B37D0}/{list_.Count}...");
										Interlocked.Decrement(ref int_4);
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
						while (int_4 > 0)
						{
							Commom.smethod_52(1.0);
						}
					}
					catch
					{
					}
					if (!bool_0)
					{
						AA2CE235(AFA0D013, Language.GetValue("Hoàn thành!"));
						method_0(lblDonDepProfileRac, bool_1: false);
						method_0(lblXoaCacheProfile);
						AA2CE235(lblStatusXoaCacheProfile, "");
						D89B6497(lblStatusXoaCacheProfile);
						int CCBD5F5 = 0;
						int int_2 = 0;
						long totalFreedCacheBytes = 0L;
						List<string> list_0 = A082FC98();
						int num3 = 0;
						while (num3 < list_0.Count && !bool_0)
						{
							if (CCBD5F5 < num)
							{
								Interlocked.Increment(ref CCBD5F5);
								string string_0 = list_0[num3++];
								new Thread((ThreadStart)delegate
								{
									try
									{
										string f4A671B = C5034B95.smethod_2() + "\\" + string_0;
										var cr = SmartCleanProfileCache(f4A671B);
										Interlocked.Add(ref totalFreedCacheBytes, cr.BytesFreed);
										Interlocked.Increment(ref int_2);
										string freedStr = FormatBytes(Interlocked.Read(ref totalFreedCacheBytes));
										AA2CE235(lblStatusXoaCacheProfile, Language.GetValue("Đang chạy") + $" {int_2}/{list_0.Count} ({freedStr})...");
										Interlocked.Decrement(ref CCBD5F5);
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
						while (CCBD5F5 > 0)
						{
							Commom.smethod_52(1.0);
						}
						if (!bool_0)
						{
							string finalFreedStr = FormatBytes(totalFreedCacheBytes);
							AA2CE235(lblStatusXoaCacheProfile, Language.GetValue("Hoàn thành!") + $" ({finalFreedStr})");
							method_0(lblXoaCacheProfile, bool_1: false);
							method_0(E5A5CD38);
							AA2CE235(lblStatusXoaTemp, "");
							D89B6497(lblStatusXoaTemp);
							try
							{
								int int_5 = 0;
								int int_ = 0;
								List<string> F1103618 = Directory.GetDirectories(Path.GetTempPath()).ToList();
								int num4 = 0;
								while (num4 < F1103618.Count && !bool_0)
								{
									if (int_5 < num)
									{
										Interlocked.Increment(ref int_5);
										int int_0 = num4++;
										new Thread((ThreadStart)delegate
										{
											try
											{
												Commom.DeleteFolder(F1103618[int_0]);
												Interlocked.Increment(ref int_);
												AA2CE235(lblStatusXoaTemp, Language.GetValue("Đang chạy") + $" {int_}/{F1103618.Count}...");
												Interlocked.Decrement(ref int_5);
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
								while (int_5 > 0)
								{
									Commom.smethod_52(1.0);
								}
							}
							catch
							{
							}
							Commom.DeleteTempFile();
						}
					}
				}
				if (DA80DE9B && !bool_0)
				{
					Commom.B9191F14();
				}
				Invoke((Action)delegate
				{
					Close();
				});
			}
			catch (Exception ex)
			{
				MsBoxHelper.Show("Error:\n" + ex.ToString());
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
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		E31E2AB1 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		C41DE234 = new Bunifu.Framework.UI.BunifuCustomLabel();
		BEB73CAD = new System.Windows.Forms.Button();
		C9968A81 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		lblXoaFileRac = new System.Windows.Forms.Label();
		lblDonDepProfileRac = new System.Windows.Forms.Label();
		lblXoaCacheProfile = new System.Windows.Forms.Label();
		lblStatusXoaFileRac = new System.Windows.Forms.Label();
		AFA0D013 = new System.Windows.Forms.Label();
		lblStatusXoaCacheProfile = new System.Windows.Forms.Label();
		lblStatusXoaTemp = new System.Windows.Forms.Label();
		E5A5CD38 = new System.Windows.Forms.Label();
		bunifuCards1.SuspendLayout();
		E31E2AB1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(E31E2AB1);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(373, 38);
		bunifuCards1.TabIndex = 0;
		E31E2AB1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E31E2AB1.BackColor = System.Drawing.Color.White;
		E31E2AB1.Controls.Add(pictureBox1);
		E31E2AB1.Controls.Add(btnMinimize);
		E31E2AB1.Controls.Add(C41DE234);
		E31E2AB1.Location = new System.Drawing.Point(0, 5);
		E31E2AB1.Name = "pnlHeader";
		E31E2AB1.Size = new System.Drawing.Size(373, 32);
		E31E2AB1.TabIndex = 9;
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
		btnMinimize.Enabled = false;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = Class155.Bitmap_15;
		btnMinimize.Location = new System.Drawing.Point(341, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(FBA87732);
		C41DE234.BackColor = System.Drawing.Color.Transparent;
		C41DE234.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C41DE234.Dock = System.Windows.Forms.DockStyle.Fill;
		C41DE234.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C41DE234.ForeColor = System.Drawing.Color.Black;
		C41DE234.Location = new System.Drawing.Point(0, 0);
		C41DE234.Name = "bunifuCustomLabel1";
		C41DE234.Size = new System.Drawing.Size(373, 32);
		C41DE234.TabIndex = 1;
		C41DE234.Text = "Giải phóng dung lượng";
		C41DE234.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BEB73CAD.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BEB73CAD.BackColor = System.Drawing.Color.Maroon;
		BEB73CAD.Cursor = System.Windows.Forms.Cursors.Hand;
		BEB73CAD.FlatAppearance.BorderSize = 0;
		BEB73CAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BEB73CAD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BEB73CAD.ForeColor = System.Drawing.Color.White;
		BEB73CAD.Location = new System.Drawing.Point(142, 191);
		BEB73CAD.Name = "btnCancel";
		BEB73CAD.Size = new System.Drawing.Size(92, 29);
		BEB73CAD.TabIndex = 4;
		BEB73CAD.Text = "Dừng";
		BEB73CAD.UseVisualStyleBackColor = false;
		BEB73CAD.Click += new System.EventHandler(BEB73CAD_Click);
		C9968A81.Fixed = true;
		C9968A81.Horizontal = true;
		C9968A81.TargetControl = C41DE234;
		C9968A81.Vertical = true;
		lblXoaFileRac.AutoSize = true;
		lblXoaFileRac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblXoaFileRac.Location = new System.Drawing.Point(35, 71);
		lblXoaFileRac.Name = "lblXoaFileRac";
		lblXoaFileRac.Size = new System.Drawing.Size(90, 16);
		lblXoaFileRac.TabIndex = 5;
		lblXoaFileRac.Text = "1. Xóa File rác";
		lblDonDepProfileRac.AutoSize = true;
		lblDonDepProfileRac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblDonDepProfileRac.Location = new System.Drawing.Point(35, 95);
		lblDonDepProfileRac.Name = "lblDonDepProfileRac";
		lblDonDepProfileRac.Size = new System.Drawing.Size(131, 16);
		lblDonDepProfileRac.TabIndex = 5;
		lblDonDepProfileRac.Text = "2. Dọn dẹp profile rác";
		lblXoaCacheProfile.AutoSize = true;
		lblXoaCacheProfile.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblXoaCacheProfile.Location = new System.Drawing.Point(35, 119);
		lblXoaCacheProfile.Name = "lblXoaCacheProfile";
		lblXoaCacheProfile.Size = new System.Drawing.Size(123, 16);
		lblXoaCacheProfile.TabIndex = 5;
		lblXoaCacheProfile.Text = "3. Xóa Cache profile";
		lblStatusXoaFileRac.AutoSize = true;
		lblStatusXoaFileRac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatusXoaFileRac.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatusXoaFileRac.Location = new System.Drawing.Point(200, 71);
		lblStatusXoaFileRac.Name = "lblStatusXoaFileRac";
		lblStatusXoaFileRac.Size = new System.Drawing.Size(79, 16);
		lblStatusXoaFileRac.TabIndex = 5;
		lblStatusXoaFileRac.Text = "Đang chạy...";
		lblStatusXoaFileRac.Visible = false;
		AFA0D013.AutoSize = true;
		AFA0D013.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AFA0D013.ForeColor = System.Drawing.Color.DarkGreen;
		AFA0D013.Location = new System.Drawing.Point(200, 95);
		AFA0D013.Name = "lblStatusDonDepProfileRac";
		AFA0D013.Size = new System.Drawing.Size(102, 16);
		AFA0D013.TabIndex = 5;
		AFA0D013.Text = "Đang chạy 0/0...";
		AFA0D013.Visible = false;
		lblStatusXoaCacheProfile.AutoSize = true;
		lblStatusXoaCacheProfile.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatusXoaCacheProfile.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatusXoaCacheProfile.Location = new System.Drawing.Point(200, 119);
		lblStatusXoaCacheProfile.Name = "lblStatusXoaCacheProfile";
		lblStatusXoaCacheProfile.Size = new System.Drawing.Size(102, 16);
		lblStatusXoaCacheProfile.TabIndex = 5;
		lblStatusXoaCacheProfile.Text = "Đang chạy 0/0...";
		lblStatusXoaCacheProfile.Visible = false;
		lblStatusXoaTemp.AutoSize = true;
		lblStatusXoaTemp.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatusXoaTemp.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatusXoaTemp.Location = new System.Drawing.Point(200, 144);
		lblStatusXoaTemp.Name = "lblStatusXoaTemp";
		lblStatusXoaTemp.Size = new System.Drawing.Size(102, 16);
		lblStatusXoaTemp.TabIndex = 5;
		lblStatusXoaTemp.Text = "Đang chạy 0/0...";
		lblStatusXoaTemp.Visible = false;
		E5A5CD38.AutoSize = true;
		E5A5CD38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E5A5CD38.Location = new System.Drawing.Point(35, 144);
		E5A5CD38.Name = "lblXoaTemp";
		E5A5CD38.Size = new System.Drawing.Size(81, 16);
		E5A5CD38.TabIndex = 5;
		E5A5CD38.Text = "4. Xóa Temp";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(373, 232);
		base.Controls.Add(E5A5CD38);
		base.Controls.Add(lblXoaCacheProfile);
		base.Controls.Add(lblStatusXoaTemp);
		base.Controls.Add(lblDonDepProfileRac);
		base.Controls.Add(lblStatusXoaCacheProfile);
		base.Controls.Add(AFA0D013);
		base.Controls.Add(lblStatusXoaFileRac);
		base.Controls.Add(lblXoaFileRac);
		base.Controls.Add(BEB73CAD);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fGiaiPhongDungLuong";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fGiaiPhongDungLuong_Load);
		bunifuCards1.ResumeLayout(false);
		E31E2AB1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void method_1()
	{
		BEB73CAD.Enabled = false;
	}

	[CompilerGenerated]
	private void method_2()
	{
		try
		{
			method_0(lblXoaFileRac);
			AA2CE235(lblStatusXoaFileRac, Language.GetValue("Đang chạy") + "...");
			D89B6497(lblStatusXoaFileRac);
			Commom.DeleteFolder("log");
			Commom.DeleteFolder("log_capture");
			Commom.DeleteFolder("Plugins");
			Commom.DeleteFolder("golike");
			Commom.E10A40B6("logJob.txt");
			if (!bool_0)
			{
				AA2CE235(lblStatusXoaFileRac, Language.GetValue("Hoàn thành!"));
				method_0(lblXoaFileRac, bool_1: false);
				method_0(lblDonDepProfileRac);
				AA2CE235(AFA0D013, "");
				D89B6497(AFA0D013);
				int num = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 10);
				List<string> list = Directory.GetDirectories(C5034B95.smethod_2()).ToList();
				List<string> list2 = A082FC98();
				List<string> list_ = new List<string>();
				string text = "";
				for (int i = 0; i < list.Count; i++)
				{
					text = list[i].Substring(list[i].LastIndexOf("\\") + 1);
					if (!list2.Contains(text))
					{
						list_.Add(text);
					}
				}
				try
				{
					int int_4 = 0;
					int B6B37D0 = 0;
					int num2 = 0;
					while (num2 < list_.Count && !bool_0)
					{
						if (int_4 < num)
						{
							Interlocked.Increment(ref int_4);
							int int_3 = num2++;
							new Thread((ThreadStart)delegate
							{
								try
								{
									string string_ = C5034B95.smethod_2() + "\\" + list_[int_3];
									Commom.DeleteFolder(string_);
									Interlocked.Increment(ref B6B37D0);
									AA2CE235(AFA0D013, Language.GetValue("Đang chạy") + $" {B6B37D0}/{list_.Count}...");
									Interlocked.Decrement(ref int_4);
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
					while (int_4 > 0)
					{
						Commom.smethod_52(1.0);
					}
				}
				catch
				{
				}
				if (!bool_0)
				{
					AA2CE235(AFA0D013, Language.GetValue("Hoàn thành!"));
					method_0(lblDonDepProfileRac, bool_1: false);
					method_0(lblXoaCacheProfile);
					AA2CE235(lblStatusXoaCacheProfile, "");
					D89B6497(lblStatusXoaCacheProfile);
					int CCBD5F5 = 0;
					int int_2 = 0;
					List<string> list_0 = A082FC98();
					int num3 = 0;
					while (num3 < list_0.Count && !bool_0)
					{
						if (CCBD5F5 < num)
						{
							Interlocked.Increment(ref CCBD5F5);
							string string_0 = list_0[num3++];
							new Thread((ThreadStart)delegate
							{
								try
								{
									string f4A671B = C5034B95.smethod_2() + "\\" + string_0;
									Commom.DeleteCacheProfile(f4A671B);
									Interlocked.Increment(ref int_2);
									AA2CE235(lblStatusXoaCacheProfile, Language.GetValue("Đang chạy") + $" {int_2}/{list_0.Count}...");
									Interlocked.Decrement(ref CCBD5F5);
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
					while (CCBD5F5 > 0)
					{
						Commom.smethod_52(1.0);
					}
					if (!bool_0)
					{
						AA2CE235(lblStatusXoaCacheProfile, Language.GetValue("Hoàn thành!"));
						method_0(lblXoaCacheProfile, bool_1: false);
						method_0(E5A5CD38);
						AA2CE235(lblStatusXoaTemp, "");
						D89B6497(lblStatusXoaTemp);
						try
						{
							int int_5 = 0;
							int int_ = 0;
							List<string> F1103618 = Directory.GetDirectories(Path.GetTempPath()).ToList();
							int num4 = 0;
							while (num4 < F1103618.Count && !bool_0)
							{
								if (int_5 < num)
								{
									Interlocked.Increment(ref int_5);
									int int_0 = num4++;
									new Thread((ThreadStart)delegate
									{
										try
										{
											Commom.DeleteFolder(F1103618[int_0]);
											Interlocked.Increment(ref int_);
											AA2CE235(lblStatusXoaTemp, Language.GetValue("Đang chạy") + $" {int_}/{F1103618.Count}...");
											Interlocked.Decrement(ref int_5);
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
							while (int_5 > 0)
							{
								Commom.smethod_52(1.0);
							}
						}
						catch
						{
						}
						Commom.DeleteTempFile();
					}
				}
			}
			if (DA80DE9B && !bool_0)
			{
				Commom.B9191F14();
			}
			Invoke((Action)delegate
			{
				Close();
			});
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Error:\n" + ex.ToString());
		}
	}

	[CompilerGenerated]
	private void method_3()
	{
		Close();
	}

	#region Nâng cấp Subagent 3: SmartCleanProfileCache & Dọn dẹp toàn bộ profile LushCare

	/// <summary>
	/// Kết quả chi tiết dọn dẹp cache profile thông minh
	/// </summary>
	public class CleanResult
	{
		public string ProfilePath { get; set; } = "";
		public long BytesFreed { get; set; } = 0L;
		public int DeletedFilesCount { get; set; } = 0;
		public int DeletedFoldersCount { get; set; } = 0;
		public bool Success { get; set; } = true;
		public string ErrorMessage { get; set; } = "";

		public double MegaBytesFreed => Math.Round(BytesFreed / (1024.0 * 1024.0), 2);
		public double GigaBytesFreed => Math.Round(BytesFreed / (1024.0 * 1024.0 * 1024.0), 3);
		public string FormattedFreed => FormatBytes(BytesFreed);

		public static implicit operator long(CleanResult r) => r?.BytesFreed ?? 0L;
		public static implicit operator double(CleanResult r) => r?.MegaBytesFreed ?? 0.0;
	}

	/// <summary>
	/// Kết quả dọn dẹp hàng loạt toàn bộ profiles
	/// </summary>
	public class BatchCleanResult
	{
		public int TotalProfiles { get; set; } = 0;
		public int CleanedProfiles { get; set; } = 0;
		public long TotalBytesFreed { get; set; } = 0L;
		public double TotalMegaBytesFreed => Math.Round(TotalBytesFreed / (1024.0 * 1024.0), 2);
		public double TotalGigaBytesFreed => Math.Round(TotalBytesFreed / (1024.0 * 1024.0 * 1024.0), 3);
		public string FormattedFreed => FormatBytes(TotalBytesFreed);
		public List<CleanResult> Details { get; set; } = new List<CleanResult>();
	}

	/// <summary>
	/// Danh sách các thư mục rác tạm thời được phép xóa an toàn:
	/// Default\Cache, Default\Code Cache, Default\GPUCache, Default\Service Worker\CacheStorage,
	/// Crashpad\reports, ShaderCache, GrShaderCache, DawnCache,...
	/// </summary>
	private static readonly string[] TargetGarbageFolders = new string[]
	{
		@"Default\Cache",
		@"Default\Code Cache",
		@"Default\GPUCache",
		@"Default\Service Worker\CacheStorage",
		@"Default\Service Worker\ScriptCache",
		@"Default\Service Worker",
		@"Crashpad\reports",
		@"Default\Crashpad\reports",
		@"Crashpad",
		@"ShaderCache",
		@"GrShaderCache",
		@"Default\DawnCache",
		@"Default\DawnGraphiteCache",
		@"Default\DawnWebGPUCache",
		@"Default\blob_storage",
		@"Default\AutofillAiModelCache",
		@"Default\optimization_guide_hint_cache_store"
	};

	/// <summary>
	/// Kiểm tra xem một đường dẫn bên trong profile có thuộc diện BẢO VỆ NGHIÊM NGẶT không.
	/// TUYỆT ĐỐI BẢO VỆ NGUYÊN VẸN:
	/// Default\Cookies, Default\Network\Cookies, Default\Local Storage, Default\Session Storage, Default\Preferences,
	/// Login Data, Web Data để tài khoản KHÔNG BỊ LOGOUT.
	/// </summary>
	public static bool IsProtectedProfilePath(string targetPath, string profileRoot)
	{
		if (string.IsNullOrWhiteSpace(targetPath) || string.IsNullOrWhiteSpace(profileRoot))
			return true;

		try
		{
			string normTarget = Path.GetFullPath(targetPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			string normRoot = Path.GetFullPath(profileRoot).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

			if (normTarget.Equals(normRoot, StringComparison.OrdinalIgnoreCase))
				return true;

			if (!normTarget.StartsWith(normRoot + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
				return true;

			string relative = normTarget.Substring(normRoot.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			string[] segments = relative.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var segment in segments)
			{
				if (segment.Equals("Cookies", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Network", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Local Storage", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Session Storage", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Sessions", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("IndexedDB", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Extensions", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Extension State", StringComparison.OrdinalIgnoreCase) ||
					segment.Equals("Accounts", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			string fileName = Path.GetFileName(normTarget);
			if (!string.IsNullOrEmpty(fileName))
			{
				if (fileName.StartsWith("Cookies", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Login Data", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Web Data", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Preferences", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Secure Preferences", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Network Persistent State", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("TransportSecurity", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Local State", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Bookmarks", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("History", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		catch
		{
			return true;
		}

		return false;
	}

	/// <summary>
	/// Nâng cấp SmartCleanProfileCache:
	/// Dọn dẹp cache rác thông minh của 1 Chrome Profile, TUYỆT ĐỐI BẢO VỆ Session, Cookie, LocalStorage, Preferences.
	/// Xử lý ngoại lệ file đang bị khóa (file-in-use) mà không làm gián đoạn tiến trình.
	/// </summary>
	/// <param name="profilePath">Đường dẫn tới thư mục profile Chrome</param>
	/// <returns>CleanResult chứa số bytes đã giải phóng (hỗ trợ cast sang long/double)</returns>
	public static CleanResult SmartCleanProfileCache(string profilePath)
	{
		CleanResult result = new CleanResult
		{
			ProfilePath = profilePath,
			Success = false
		};

		if (string.IsNullOrWhiteSpace(profilePath) || !Directory.Exists(profilePath))
		{
			result.ErrorMessage = "Thư mục profile không tồn tại: " + profilePath;
			return result;
		}

		try
		{
			// 1. Quét và dọn các thư mục cache rác mục tiêu
			foreach (string relDir in TargetGarbageFolders)
			{
				string fullDir = Path.Combine(profilePath, relDir);
				if (!Directory.Exists(fullDir)) continue;

				if (IsProtectedProfilePath(fullDir, profilePath)) continue;

				CleanDirectoryInternal(fullDir, profilePath, result);
			}

			// 2. Dọn các file rác, log, crashdump ở profile root và Default root
			CleanGarbageFiles(profilePath, profilePath, result);
			string defaultDir = Path.Combine(profilePath, "Default");
			if (Directory.Exists(defaultDir))
			{
				CleanGarbageFiles(defaultDir, profilePath, result);
			}

			// 3. Tích hợp thêm ProfileCachePruner để bảo đảm triệt để 100%
			try
			{
				var prunerRes = ProfileCachePruner.SafePruneProfile(profilePath);
				if (prunerRes != null && prunerRes.Success)
				{
					if (prunerRes.BytesFreed > result.BytesFreed)
					{
						result.BytesFreed = prunerRes.BytesFreed;
					}
					result.DeletedFilesCount = Math.Max(result.DeletedFilesCount, prunerRes.FilesDeleted);
					result.DeletedFoldersCount = Math.Max(result.DeletedFoldersCount, prunerRes.DirectoriesDeleted);
				}
			}
			catch { }

			result.Success = true;
		}
		catch (Exception ex)
		{
			result.ErrorMessage = ex.Message;
		}

		return result;
	}

	private static void CleanDirectoryInternal(string dirPath, string profileRoot, CleanResult result)
	{
		try
		{
			string[] files = Directory.GetFiles(dirPath);
			foreach (var file in files)
			{
				try
				{
					if (IsProtectedProfilePath(file, profileRoot)) continue;

					FileInfo fi = new FileInfo(file);
					long len = fi.Length;
					fi.Attributes = FileAttributes.Normal;
					fi.Delete();
					result.BytesFreed += len;
					result.DeletedFilesCount++;
				}
				catch { }
			}

			string[] subDirs = Directory.GetDirectories(dirPath);
			foreach (var sub in subDirs)
			{
				try
				{
					if (IsProtectedProfilePath(sub, profileRoot)) continue;
					CleanDirectoryInternal(sub, profileRoot, result);
					Directory.Delete(sub, false);
					result.DeletedFoldersCount++;
				}
				catch { }
			}
		}
		catch { }
	}

	private static void CleanGarbageFiles(string folderPath, string profileRoot, CleanResult result)
	{
		try
		{
			string[] files = Directory.GetFiles(folderPath);
			foreach (var file in files)
			{
				try
				{
					if (IsProtectedProfilePath(file, profileRoot)) continue;

					string ext = Path.GetExtension(file).ToLowerInvariant();
					string name = Path.GetFileName(file).ToLowerInvariant();

					if (ext == ".dmp" || ext == ".tmp" || ext == ".old" || ext == ".pma" ||
						name == "chrome_debug.log" || name == "lockfile")
					{
						FileInfo fi = new FileInfo(file);
						long len = fi.Length;
						fi.Attributes = FileAttributes.Normal;
						fi.Delete();
						result.BytesFreed += len;
						result.DeletedFilesCount++;
					}
				}
				catch { }
			}
		}
		catch { }
	}

	/// <summary>
	/// Quét và dọn dẹp hàng loạt toàn bộ profile trong thư mục profile của LushCare,
	/// tính toán và hiển thị tổng số dung lượng (MB/GB) đã giải phóng được.
	/// </summary>
	/// <param name="profilesRoot">Đường dẫn thư mục profile (mặc định C5034B95.smethod_2())</param>
	/// <param name="maxThreads">Số luồng xử lý song song</param>
	/// <param name="progressCallback">Callback báo cáo (tiến độ hiện tại, tổng số profile, dung lượng bytes đã dọn, tên profile)</param>
	/// <returns>BatchCleanResult chi tiết</returns>
	public static BatchCleanResult SmartCleanAllProfiles(
		string profilesRoot = null,
		int maxThreads = 4,
		Action<int, int, long, string> progressCallback = null)
	{
		BatchCleanResult batchResult = new BatchCleanResult();

		if (string.IsNullOrWhiteSpace(profilesRoot) || !Directory.Exists(profilesRoot))
		{
			profilesRoot = C5034B95.smethod_2();
		}

		if (string.IsNullOrWhiteSpace(profilesRoot) || !Directory.Exists(profilesRoot))
		{
			return batchResult;
		}

		string[] profileDirs = Directory.GetDirectories(profilesRoot);
		batchResult.TotalProfiles = profileDirs.Length;
		if (profileDirs.Length == 0) return batchResult;

		int processed = 0;
		long totalFreed = 0L;
		object lockObj = new object();

		Parallel.ForEach(profileDirs, new ParallelOptions { MaxDegreeOfParallelism = Math.Max(1, maxThreads) }, dir =>
		{
			try
			{
				var res = SmartCleanProfileCache(dir);
				lock (lockObj)
				{
					batchResult.CleanedProfiles++;
					totalFreed += res.BytesFreed;
					batchResult.Details.Add(res);
				}
			}
			catch { }
			finally
			{
				int cur = Interlocked.Increment(ref processed);
				progressCallback?.Invoke(cur, profileDirs.Length, Interlocked.Read(ref totalFreed), Path.GetFileName(dir));
			}
		});

		batchResult.TotalBytesFreed = totalFreed;
		return batchResult;
	}

	public static BatchCleanResult CleanAllProfiles(
		string profilesRoot = null,
		int maxThreads = 4,
		Action<int, int, long, string> progressCallback = null)
		=> SmartCleanAllProfiles(profilesRoot, maxThreads, progressCallback);

	/// <summary>
	/// Định dạng số bytes thành chuỗi dung lượng thân thiện B, KB, MB, GB
	/// </summary>
	public static string FormatBytes(long bytes)
	{
		if (bytes < 0L) bytes = 0L;
		if (bytes < 1024L)
			return $"{bytes} B";
		if (bytes < 1024L * 1024L)
			return $"{Math.Round(bytes / 1024.0, 2)} KB";
		if (bytes < 1024L * 1024L * 1024L)
			return $"{Math.Round(bytes / (1024.0 * 1024.0), 2)} MB";
		return $"{Math.Round(bytes / (1024.0 * 1024.0 * 1024.0), 2)} GB";
	}

	#endregion

}
