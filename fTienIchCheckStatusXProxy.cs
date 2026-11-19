using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchCheckStatusXProxy : Form
{
	[CompilerGenerated]
	private sealed class F624DA1D
	{
		internal string string_0;

		internal fTienIchCheckStatusXProxy BBA6D611;

		internal void method_0()
		{
			try
			{
				if (string_0 == "")
				{
					for (int i = 0; i < BBA6D611.E0A26223.RowCount; i++)
					{
						Thread thread = new Thread(new Class98
						{
							f624DA1D_0 = this,
							EB33A72A = i
						}.F3B06FAC);
						thread.IsBackground = true;
						thread.Start();
					}
				}
				else if (string_0.StartsWith("http"))
				{
					for (int j = 0; j < BBA6D611.E0A26223.RowCount; j++)
					{
						Thread thread2 = new Thread(new Class99
						{
							f624DA1D_0 = this,
							DEAA5DB5 = j
						}.method_0);
						thread2.IsBackground = true;
						thread2.Start();
					}
				}
				else
				{
					for (int k = 0; k < BBA6D611.E0A26223.RowCount; k++)
					{
						Thread thread3 = new Thread(new Class100
						{
							C4033F3D = this,
							int_0 = k
						}.method_0);
						thread3.IsBackground = true;
						thread3.Start();
					}
				}
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class98
	{
		internal int EB33A72A;

		internal F624DA1D f624DA1D_0;

		internal void F3B06FAC()
		{
			try
			{
				string string_ = f624DA1D_0.BBA6D611.E0A26223.Rows[EB33A72A].Cells["cProxy"].Value.ToString();
				string object_ = Commom.BD994637(string_);
				EAB09F19.smethod_3(f624DA1D_0.BBA6D611.E0A26223, EB33A72A, "cStatus", object_);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class99
	{
		internal int DEAA5DB5;

		internal F624DA1D f624DA1D_0;

		internal void method_0()
		{
			try
			{
				string text = f624DA1D_0.BBA6D611.E0A26223.Rows[DEAA5DB5].Cells["cProxy"].Value.ToString();
				string string_ = f624DA1D_0.string_0 + "/status?proxy=" + text;
				string object_ = new RequestXNet().E58EB99F(string_);
				EAB09F19.smethod_3(f624DA1D_0.BBA6D611.E0A26223, DEAA5DB5, "cStatus", object_);
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class Class100
	{
		internal int int_0;

		internal F624DA1D C4033F3D;

		internal void method_0()
		{
			try
			{
				string text = C4033F3D.BBA6D611.E0A26223.Rows[int_0].Cells["cProxy"].Value.ToString();
				string string_ = "https://api.proxyv6.net/api/check-list-proxy?api_key=" + C4033F3D.string_0;
				string text2 = text.Split(':')[2] + ":" + text.Split(':')[3] + "@" + text.Split(':')[0] + ":" + text.Split(':')[1];
				string d = "{\"proxies\": [\"" + text2 + "\"]}";
				RequestXNet requestXNet = new RequestXNet();
				string object_ = requestXNet.method_1(string_, d, "application/json");
				EAB09F19.smethod_3(C4033F3D.BBA6D611.E0A26223, int_0, "cStatus", object_);
			}
			catch
			{
			}
		}
	}

	internal bool bool_0 = false;

	internal static List<string> CD07EEBB;

	internal static List<string> list_0;

	internal static bool A2095633;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel F13CB396;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox AE16472A;

	internal DataGridView E0A26223;

	internal RichTextBox txtListProxy;

	internal Label CA37590F;

	internal Label C4018524;

	internal DataGridViewTextBoxColumn cStt;

	internal DataGridViewTextBoxColumn D927ED16;

	internal DataGridViewTextBoxColumn cStatus;

	internal Button btnCheck;

	internal Label DEB066B5;

	internal TextBox txtUrl;

	public fTienIchCheckStatusXProxy(bool E92F4835 = false)
	{
		InitializeComponent();
		A2095633 = false;
		bool_0 = E92F4835;
		Language.CD21F0A9(this);
	}

	private void EE9F0E23(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0(object sender, EventArgs e)
	{
		A2095633 = true;
		if (bool_0)
		{
			list_0 = new List<string>();
			for (int i = 0; i < E0A26223.Rows.Count; i++)
			{
				if (Convert.ToBoolean(E0A26223.Rows[i].Cells["cChose"].Value))
				{
					list_0.Add(EAB09F19.E2A1ED2F(E0A26223, i, "cId"));
				}
			}
			if (list_0.Count == 0)
			{
				MsBoxHelper.Show(Language.GetValue("Vui lòng chọn ít nhất 1 thư mục!"), 2);
				return;
			}
		}
		else
		{
			CD07EEBB = new List<string>();
			for (int j = 0; j < E0A26223.Rows.Count; j++)
			{
				if (Convert.ToBoolean(E0A26223.Rows[j].Cells["cChose"].Value))
				{
					CD07EEBB.Add(EAB09F19.E2A1ED2F(E0A26223, j, "cId"));
				}
			}
			if (CD07EEBB.Count == 0)
			{
				MsBoxHelper.Show(Language.GetValue("Vui lòng chọn ít nhất 1 thư mục!"), 2);
				return;
			}
		}
		Close();
	}

	private void E0A26223_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (Convert.ToBoolean(E0A26223.CurrentRow.Cells["cChose"].Value))
			{
				E0A26223.CurrentRow.Cells["cChose"].Value = false;
			}
			else
			{
				E0A26223.CurrentRow.Cells["cChose"].Value = true;
			}
		}
		catch
		{
		}
	}

	private int method_1()
	{
		int num = 0;
		for (int i = 0; i < E0A26223.Rows.Count; i++)
		{
			if (Convert.ToBoolean(E0A26223.Rows[i].Cells["cChose"].Value))
			{
				num++;
			}
		}
		return num;
	}

	private void BF26358D(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex != 0)
		{
			return;
		}
		try
		{
			if (Convert.ToBoolean(E0A26223.CurrentRow.Cells["cChose"].Value))
			{
				E0A26223.CurrentRow.Cells["cChose"].Value = false;
			}
			else
			{
				E0A26223.CurrentRow.Cells["cChose"].Value = true;
			}
		}
		catch
		{
		}
	}

	private void txtListProxy_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtListProxy, CA37590F);
	}

	private void D283B99B(object sender, EventArgs e)
	{
		if (txtListProxy.Text.Trim() == "")
		{
			MsBoxHelper.Show("Vui lòng nhập proxy trước!", 3);
			txtListProxy.Focus();
			return;
		}
		string string_0 = txtUrl.Text.Trim().TrimEnd('/');
		List<string> list = txtListProxy.Lines.ToList();
		list = Commom.smethod_36(list);
		E0A26223.Rows.Clear();
		for (int i = 0; i < list.Count; i++)
		{
			E0A26223.Rows.Add(i + 1, list[i], "Đang check...");
		}
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				if (string_0 == "")
				{
					for (int j = 0; j < E0A26223.RowCount; j++)
					{
						int EB33A72A = j;
						Thread thread2 = new Thread((ThreadStart)delegate
						{
							try
							{
								string string_3 = E0A26223.Rows[EB33A72A].Cells["cProxy"].Value.ToString();
								string object_3 = Commom.BD994637(string_3);
								EAB09F19.smethod_3(E0A26223, EB33A72A, "cStatus", object_3);
							}
							catch
							{
							}
						});
						thread2.IsBackground = true;
						thread2.Start();
					}
				}
				else if (string_0.StartsWith("http"))
				{
					for (int k = 0; k < E0A26223.RowCount; k++)
					{
						int DEAA5DB5 = k;
						Thread thread3 = new Thread((ThreadStart)delegate
						{
							try
							{
								string text3 = E0A26223.Rows[DEAA5DB5].Cells["cProxy"].Value.ToString();
								string string_2 = string_0 + "/status?proxy=" + text3;
								string object_2 = new RequestXNet().E58EB99F(string_2);
								EAB09F19.smethod_3(E0A26223, DEAA5DB5, "cStatus", object_2);
							}
							catch
							{
							}
						});
						thread3.IsBackground = true;
						thread3.Start();
					}
				}
				else
				{
					for (int l = 0; l < E0A26223.RowCount; l++)
					{
						int int_0 = l;
						Thread thread4 = new Thread((ThreadStart)delegate
						{
							try
							{
								string text = E0A26223.Rows[int_0].Cells["cProxy"].Value.ToString();
								string string_ = "https://api.proxyv6.net/api/check-list-proxy?api_key=" + string_0;
								string text2 = text.Split(':')[2] + ":" + text.Split(':')[3] + "@" + text.Split(':')[0] + ":" + text.Split(':')[1];
								string d = "{\"proxies\": [\"" + text2 + "\"]}";
								RequestXNet requestXNet = new RequestXNet();
								string object_ = requestXNet.method_1(string_, d, "application/json");
								EAB09F19.smethod_3(E0A26223, int_0, "cStatus", object_);
							}
							catch
							{
							}
						});
						thread4.IsBackground = true;
						thread4.Start();
					}
				}
			}
			catch
			{
			}
		});
		thread.IsBackground = true;
		thread.Start();
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
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		F13CB396 = new System.Windows.Forms.Panel();
		AE16472A = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		E0A26223 = new System.Windows.Forms.DataGridView();
		cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
		D927ED16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
		txtListProxy = new System.Windows.Forms.RichTextBox();
		CA37590F = new System.Windows.Forms.Label();
		C4018524 = new System.Windows.Forms.Label();
		btnCheck = new System.Windows.Forms.Button();
		DEB066B5 = new System.Windows.Forms.Label();
		txtUrl = new System.Windows.Forms.TextBox();
		bunifuCards1.SuspendLayout();
		F13CB396.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AE16472A).BeginInit();
		((System.ComponentModel.ISupportInitialize)E0A26223).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(F13CB396);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(530, 34);
		bunifuCards1.TabIndex = 0;
		F13CB396.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F13CB396.BackColor = System.Drawing.Color.White;
		F13CB396.Controls.Add(AE16472A);
		F13CB396.Controls.Add(btnMinimize);
		F13CB396.Controls.Add(bunifuCustomLabel1);
		F13CB396.Location = new System.Drawing.Point(0, 3);
		F13CB396.Name = "pnlHeader";
		F13CB396.Size = new System.Drawing.Size(530, 28);
		F13CB396.TabIndex = 9;
		AE16472A.Cursor = System.Windows.Forms.Cursors.Default;
		AE16472A.Image = Class155.DD225F0D;
		AE16472A.Location = new System.Drawing.Point(3, 2);
		AE16472A.Name = "pictureBox1";
		AE16472A.Size = new System.Drawing.Size(34, 27);
		AE16472A.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AE16472A.TabIndex = 17;
		AE16472A.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = Class155.Bitmap_15;
		btnMinimize.Location = new System.Drawing.Point(498, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 28);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(EE9F0E23);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(530, 28);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Check status XProxy";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		E0A26223.AllowUserToAddRows = false;
		E0A26223.AllowUserToDeleteRows = false;
		E0A26223.AllowUserToResizeRows = false;
		E0A26223.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		E0A26223.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		E0A26223.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		E0A26223.Columns.AddRange(cStt, D927ED16, cStatus);
		E0A26223.Location = new System.Drawing.Point(15, 318);
		E0A26223.Name = "dtgv";
		E0A26223.ReadOnly = true;
		E0A26223.RowHeadersVisible = false;
		E0A26223.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		E0A26223.Size = new System.Drawing.Size(499, 211);
		E0A26223.TabIndex = 7;
		E0A26223.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(BF26358D);
		E0A26223.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(E0A26223_CellDoubleClick);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		cStt.DefaultCellStyle = dataGridViewCellStyle2;
		cStt.HeaderText = "STT";
		cStt.Name = "cStt";
		cStt.ReadOnly = true;
		cStt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		cStt.Width = 35;
		D927ED16.HeaderText = "Proxy";
		D927ED16.Name = "cProxy";
		D927ED16.ReadOnly = true;
		D927ED16.Width = 90;
		cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		cStatus.HeaderText = "Status";
		cStatus.Name = "cStatus";
		cStatus.ReadOnly = true;
		txtListProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtListProxy.Font = new System.Drawing.Font("Tahoma", 9.75f);
		txtListProxy.Location = new System.Drawing.Point(15, 92);
		txtListProxy.Name = "txtListProxy";
		txtListProxy.Size = new System.Drawing.Size(499, 158);
		txtListProxy.TabIndex = 146;
		txtListProxy.Text = "";
		txtListProxy.WordWrap = false;
		txtListProxy.TextChanged += new System.EventHandler(txtListProxy_TextChanged);
		CA37590F.AutoSize = true;
		CA37590F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		CA37590F.Location = new System.Drawing.Point(12, 73);
		CA37590F.Name = "label17";
		CA37590F.Size = new System.Drawing.Size(97, 16);
		CA37590F.TabIndex = 145;
		CA37590F.Text = "Nhập Proxy (0):";
		C4018524.AutoSize = true;
		C4018524.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		C4018524.Location = new System.Drawing.Point(12, 299);
		C4018524.Name = "label1";
		C4018524.Size = new System.Drawing.Size(55, 16);
		C4018524.TabIndex = 145;
		C4018524.Text = "Kết quả:";
		btnCheck.BackColor = System.Drawing.Color.Green;
		btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCheck.FlatAppearance.BorderSize = 0;
		btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCheck.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCheck.ForeColor = System.Drawing.Color.White;
		btnCheck.Location = new System.Drawing.Point(223, 261);
		btnCheck.Name = "btnCheck";
		btnCheck.Size = new System.Drawing.Size(82, 33);
		btnCheck.TabIndex = 147;
		btnCheck.Text = "Check";
		btnCheck.UseVisualStyleBackColor = false;
		btnCheck.Click += new System.EventHandler(D283B99B);
		DEB066B5.AutoSize = true;
		DEB066B5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DEB066B5.Location = new System.Drawing.Point(12, 48);
		DEB066B5.Name = "label2";
		DEB066B5.Size = new System.Drawing.Size(34, 16);
		DEB066B5.TabIndex = 145;
		DEB066B5.Text = "URL:";
		txtUrl.Font = new System.Drawing.Font("Tahoma", 9.75f);
		txtUrl.Location = new System.Drawing.Point(53, 47);
		txtUrl.Name = "txtUrl";
		txtUrl.Size = new System.Drawing.Size(461, 23);
		txtUrl.TabIndex = 148;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(530, 547);
		base.Controls.Add(txtUrl);
		base.Controls.Add(btnCheck);
		base.Controls.Add(txtListProxy);
		base.Controls.Add(DEB066B5);
		base.Controls.Add(C4018524);
		base.Controls.Add(CA37590F);
		base.Controls.Add(E0A26223);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fTienIchCheckStatusXProxy";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		bunifuCards1.ResumeLayout(false);
		F13CB396.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AE16472A).EndInit();
		((System.ComponentModel.ISupportInitialize)E0A26223).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
