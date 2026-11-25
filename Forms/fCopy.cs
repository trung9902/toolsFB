using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCopy : Form
{
	internal List<ComboBox> list_0;

	internal List<string> list_1 = new List<string>();

	internal IContainer E0AA8914 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button D3A5ED9C;

	internal Button E6823614;

	internal Button EC9106A9;

	internal Label B119DE92;

	internal BunifuDragControl B8847A17;

	internal ComboBox cbbDinhDang1;

	internal ComboBox cbbDinhDang2;

	internal ComboBox A828930E;

	internal ComboBox cbbDinhDang4;

	internal Label label14;

	internal ComboBox D6238BBD;

	internal Label E88837A3;

	internal ComboBox D1AC8DBA;

	internal Label A885641B;

	internal ComboBox cbbDinhDang7;

	internal Label BD141E1A;

	internal Label label9;

	internal Label BA1D62AD;

	internal ComboBox cbbDinhDang9;

	internal ComboBox cbbDinhDang8;

	internal Label label2;

	internal Label label3;

	internal Button button1;

	internal ComboBox FC326898;

	internal Label label4;

	public fCopy(List<string> list_2)
	{
		InitializeComponent();
		list_1 = list_2;
		Language.CD21F0A9(this);
		list_0 = new List<ComboBox> { cbbDinhDang1, cbbDinhDang2, A828930E, cbbDinhDang4, D6238BBD, D1AC8DBA, cbbDinhDang7, cbbDinhDang8, cbbDinhDang9, FC326898 };
	}

	private void F2ACC3AF(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0()
	{
		try
		{
			string text = "";
			for (int i = 0; i < list_0.Count; i++)
			{
				text = text + list_0[i].SelectedIndex + "|";
			}
			text = text.TrimEnd('|');
			C5034B95.smethod_0("configFormat").method_4("copyFormat", text);
			C5034B95.smethod_0("configFormat").AEBFED04();
		}
		catch
		{
		}
	}

	private void method_1()
	{
		try
		{
			string text = C5034B95.smethod_0("configFormat").BDB80B23("copyFormat");
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

	private void F19C22A5()
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

	private void EC9106A9_Click(object sender, EventArgs e)
	{
		try
		{
			if (!Base.smethod_3())
			{
				return;
			}
			List<string> list = new List<string>();
			string text = "";
			int num = 0;
			int num2 = list_0.Count - 1;
			while (num2 >= 0)
			{
				if (list_0[num2].SelectedIndex == -1)
				{
					num2--;
					continue;
				}
				num = num2 + 1;
				break;
			}
			if (num == 0)
			{
				MsBoxHelper.Show("vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng câ\u0300n copy!", 3);
				return;
			}
			method_0();
			int num3 = 0;
			for (int i = 0; i < list_1.Count; i++)
			{
				text = "";
				string[] array = list_1[i].Split('|');
				for (int j = 0; j < list_0.Count; j++)
				{
					int selectedIndex = list_0[j].SelectedIndex;
					if (selectedIndex > 0 && array.Length >= selectedIndex)
					{
						text += array[selectedIndex - 1];
					}
					text += "|";
				}
				text = text.TrimEnd('|');
				for (num3 = text.Split('|').Count(); num3 < num; num3++)
				{
					text += "|";
				}
				list.Add(text);
			}
			string string_ = string.Join("\r\n", list);
			Commom.SetTextToClipboard(string_);
			MsBoxHelper.Show("Copy tha\u0300nh công!");
			Close();
		}
		catch (Exception ex)
		{
			Commom.smethod_58(null, ex.ToString());
			MsBoxHelper.Show("Có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void E6823614_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B82AFC0E(object sender, EventArgs e)
	{
		F19C22A5();
	}

	private void B7B12A22(object sender, EventArgs e)
	{
		foreach (ComboBox item in list_0)
		{
			Commom.smethod_23(item, new List<string>
			{
				"", "Uid", "Pass", "Token", "Cookie", "Email", "Email full", "Pass Email", "2FA", "Useragent",
				"Proxy", "Tên", "Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "Ghi chú", "Location",
				"Mail khôi phục", "Pass mail khôi phục", "Tương tác cuối", "Dating", "Ads", "BM", "Hometown", "Current City", "Tra\u0323ng tha\u0301i", "Wall Posts",
				"Refresh_token", "Client_id"
			});
			item.SelectedIndex = -1;
			item.DropDownWidth = 120;
		}
		method_1();
	}

	protected override void Dispose(bool F3B05927)
	{
		if (F3B05927 && E0AA8914 != null)
		{
			E0AA8914.Dispose();
		}
		base.Dispose(F3B05927);
	}

	private void InitializeComponent()
	{
		E0AA8914 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCopy));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		D3A5ED9C = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		E6823614 = new System.Windows.Forms.Button();
		EC9106A9 = new System.Windows.Forms.Button();
		B119DE92 = new System.Windows.Forms.Label();
		B8847A17 = new Bunifu.Framework.UI.BunifuDragControl(E0AA8914);
		cbbDinhDang1 = new System.Windows.Forms.ComboBox();
		cbbDinhDang2 = new System.Windows.Forms.ComboBox();
		A828930E = new System.Windows.Forms.ComboBox();
		cbbDinhDang4 = new System.Windows.Forms.ComboBox();
		label14 = new System.Windows.Forms.Label();
		D6238BBD = new System.Windows.Forms.ComboBox();
		E88837A3 = new System.Windows.Forms.Label();
		D1AC8DBA = new System.Windows.Forms.ComboBox();
		A885641B = new System.Windows.Forms.Label();
		cbbDinhDang7 = new System.Windows.Forms.ComboBox();
		BD141E1A = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		BA1D62AD = new System.Windows.Forms.Label();
		cbbDinhDang9 = new System.Windows.Forms.ComboBox();
		cbbDinhDang8 = new System.Windows.Forms.ComboBox();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		FC326898 = new System.Windows.Forms.ComboBox();
		label4 = new System.Windows.Forms.Label();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(1122, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(D3A5ED9C);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1122, 32);
		pnlHeader.TabIndex = 9;
		D3A5ED9C.Cursor = System.Windows.Forms.Cursors.Hand;
		D3A5ED9C.Dock = System.Windows.Forms.DockStyle.Right;
		D3A5ED9C.FlatAppearance.BorderSize = 0;
		D3A5ED9C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D3A5ED9C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D3A5ED9C.ForeColor = System.Drawing.Color.White;
		D3A5ED9C.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		D3A5ED9C.Location = new System.Drawing.Point(1090, 0);
		D3A5ED9C.Name = "btnMinimize";
		D3A5ED9C.Size = new System.Drawing.Size(32, 32);
		D3A5ED9C.TabIndex = 9;
		D3A5ED9C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D3A5ED9C.UseVisualStyleBackColor = true;
		D3A5ED9C.Click += new System.EventHandler(F2ACC3AF);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(1122, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Tu\u0300y cho\u0323n đi\u0323nh da\u0323ng sao che\u0301p";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E6823614.BackColor = System.Drawing.Color.Maroon;
		E6823614.Cursor = System.Windows.Forms.Cursors.Hand;
		E6823614.FlatAppearance.BorderSize = 0;
		E6823614.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E6823614.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E6823614.ForeColor = System.Drawing.Color.White;
		E6823614.Location = new System.Drawing.Point(622, 124);
		E6823614.Name = "btnCancel";
		E6823614.Size = new System.Drawing.Size(92, 29);
		E6823614.TabIndex = 4;
		E6823614.Text = "Đo\u0301ng";
		E6823614.UseVisualStyleBackColor = false;
		E6823614.Click += new System.EventHandler(E6823614_Click);
		EC9106A9.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EC9106A9.Cursor = System.Windows.Forms.Cursors.Hand;
		EC9106A9.FlatAppearance.BorderSize = 0;
		EC9106A9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EC9106A9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EC9106A9.ForeColor = System.Drawing.Color.White;
		EC9106A9.Location = new System.Drawing.Point(514, 124);
		EC9106A9.Name = "btnAdd";
		EC9106A9.Size = new System.Drawing.Size(92, 29);
		EC9106A9.TabIndex = 3;
		EC9106A9.Text = "Xa\u0301c nhâ\u0323n";
		EC9106A9.UseVisualStyleBackColor = false;
		EC9106A9.Click += new System.EventHandler(EC9106A9_Click);
		B119DE92.AutoSize = true;
		B119DE92.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B119DE92.Location = new System.Drawing.Point(20, 66);
		B119DE92.Name = "label1";
		B119DE92.Size = new System.Drawing.Size(131, 16);
		B119DE92.TabIndex = 20;
		B119DE92.Text = "Cho\u0323n đi\u0323nh da\u0323ng copy:";
		B8847A17.Fixed = true;
		B8847A17.Horizontal = true;
		B8847A17.TargetControl = bunifuCustomLabel1;
		B8847A17.Vertical = true;
		cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang1.FormattingEnabled = true;
		cbbDinhDang1.Location = new System.Drawing.Point(158, 65);
		cbbDinhDang1.Name = "cbbDinhDang1";
		cbbDinhDang1.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang1.TabIndex = 42;
		cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang2.FormattingEnabled = true;
		cbbDinhDang2.Location = new System.Drawing.Point(255, 65);
		cbbDinhDang2.Name = "cbbDinhDang2";
		cbbDinhDang2.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang2.TabIndex = 43;
		A828930E.Cursor = System.Windows.Forms.Cursors.Hand;
		A828930E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A828930E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A828930E.FormattingEnabled = true;
		A828930E.Location = new System.Drawing.Point(352, 65);
		A828930E.Name = "cbbDinhDang3";
		A828930E.Size = new System.Drawing.Size(78, 24);
		A828930E.TabIndex = 44;
		cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang4.FormattingEnabled = true;
		cbbDinhDang4.Location = new System.Drawing.Point(449, 65);
		cbbDinhDang4.Name = "cbbDinhDang4";
		cbbDinhDang4.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang4.TabIndex = 45;
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(721, 67);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(19, 19);
		label14.TabIndex = 49;
		label14.Text = "|";
		D6238BBD.Cursor = System.Windows.Forms.Cursors.Hand;
		D6238BBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		D6238BBD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D6238BBD.FormattingEnabled = true;
		D6238BBD.Location = new System.Drawing.Point(546, 65);
		D6238BBD.Name = "cbbDinhDang5";
		D6238BBD.Size = new System.Drawing.Size(78, 24);
		D6238BBD.TabIndex = 46;
		E88837A3.AutoSize = true;
		E88837A3.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E88837A3.Location = new System.Drawing.Point(624, 67);
		E88837A3.Name = "label13";
		E88837A3.Size = new System.Drawing.Size(19, 19);
		E88837A3.TabIndex = 50;
		E88837A3.Text = "|";
		D1AC8DBA.Cursor = System.Windows.Forms.Cursors.Hand;
		D1AC8DBA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		D1AC8DBA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D1AC8DBA.FormattingEnabled = true;
		D1AC8DBA.Location = new System.Drawing.Point(643, 65);
		D1AC8DBA.Name = "cbbDinhDang6";
		D1AC8DBA.Size = new System.Drawing.Size(78, 24);
		D1AC8DBA.TabIndex = 47;
		A885641B.AutoSize = true;
		A885641B.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A885641B.Location = new System.Drawing.Point(527, 67);
		A885641B.Name = "label12";
		A885641B.Size = new System.Drawing.Size(19, 19);
		A885641B.TabIndex = 51;
		A885641B.Text = "|";
		cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang7.FormattingEnabled = true;
		cbbDinhDang7.Location = new System.Drawing.Point(740, 65);
		cbbDinhDang7.Name = "cbbDinhDang7";
		cbbDinhDang7.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang7.TabIndex = 48;
		BD141E1A.AutoSize = true;
		BD141E1A.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BD141E1A.Location = new System.Drawing.Point(430, 67);
		BD141E1A.Name = "label11";
		BD141E1A.Size = new System.Drawing.Size(19, 19);
		BD141E1A.TabIndex = 52;
		BD141E1A.Text = "|";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(236, 67);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(19, 19);
		label9.TabIndex = 53;
		label9.Text = "|";
		BA1D62AD.AutoSize = true;
		BA1D62AD.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BA1D62AD.Location = new System.Drawing.Point(333, 67);
		BA1D62AD.Name = "label10";
		BA1D62AD.Size = new System.Drawing.Size(19, 19);
		BA1D62AD.TabIndex = 54;
		BA1D62AD.Text = "|";
		cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang9.FormattingEnabled = true;
		cbbDinhDang9.Location = new System.Drawing.Point(934, 65);
		cbbDinhDang9.Name = "cbbDinhDang9";
		cbbDinhDang9.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang9.TabIndex = 48;
		cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbDinhDang8.FormattingEnabled = true;
		cbbDinhDang8.Location = new System.Drawing.Point(837, 65);
		cbbDinhDang8.Name = "cbbDinhDang8";
		cbbDinhDang8.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang8.TabIndex = 47;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(818, 67);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(19, 19);
		label2.TabIndex = 50;
		label2.Text = "|";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(915, 67);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(19, 19);
		label3.TabIndex = 49;
		label3.Text = "|";
		button1.BackColor = System.Drawing.Color.DarkOrange;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(377, 124);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(121, 29);
		button1.TabIndex = 4;
		button1.Text = "Reset định dạng";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(B82AFC0E);
		FC326898.Cursor = System.Windows.Forms.Cursors.Hand;
		FC326898.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FC326898.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FC326898.FormattingEnabled = true;
		FC326898.Location = new System.Drawing.Point(1033, 65);
		FC326898.Name = "cbbDinhDang10";
		FC326898.Size = new System.Drawing.Size(78, 24);
		FC326898.TabIndex = 48;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(1014, 67);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(19, 19);
		label4.TabIndex = 49;
		label4.Text = "|";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1122, 165);
		base.Controls.Add(cbbDinhDang1);
		base.Controls.Add(cbbDinhDang2);
		base.Controls.Add(A828930E);
		base.Controls.Add(cbbDinhDang4);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label14);
		base.Controls.Add(D6238BBD);
		base.Controls.Add(label2);
		base.Controls.Add(cbbDinhDang8);
		base.Controls.Add(E88837A3);
		base.Controls.Add(D1AC8DBA);
		base.Controls.Add(FC326898);
		base.Controls.Add(cbbDinhDang9);
		base.Controls.Add(A885641B);
		base.Controls.Add(cbbDinhDang7);
		base.Controls.Add(BD141E1A);
		base.Controls.Add(label9);
		base.Controls.Add(BA1D62AD);
		base.Controls.Add(B119DE92);
		base.Controls.Add(button1);
		base.Controls.Add(E6823614);
		base.Controls.Add(EC9106A9);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCopy";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(B7B12A22);
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}
