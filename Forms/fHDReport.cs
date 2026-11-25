using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDReport : Form
{
	internal GClass4 gclass4_0 = null;

	internal Panel pnlTopAccent;

	internal string string_0;

	internal string string_1;

	internal string F3A92E11;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal Dictionary<string, List<string>> ED8B1DAC = new Dictionary<string, List<string>>
	{
		{
			"Pretending to be someone",
			new List<string> { "Me" }
		},
		{
			"Fake account",
			new List<string>()
		},
		{
			"Fake name",
			new List<string>()
		},
		{
			"Posting inappropriate things",
			new List<string> { "Submit without post" }
		},
		{
			"Harassment or bullying",
			new List<string>()
		},
		{
			"I want to help",
			new List<string> { "Suicide", "Self-injury", "Harassment", "Hacked" }
		},
		{
			"Problem involving someone under 18",
			new List<string> { "Threatening to share my nude images", "Seems like sexual exploitation", "Sharing someone’s nude images", "Bullying or harassment", "Physical abuse" }
		},
		{
			"Bullying, harassment or abuse",
			new List<string> { "Threatening to share my nude images", "Seems like sexual exploitation", "Seems like human trafficking", "Bullying or harassment" }
		},
		{
			"Suicide or self-harm",
			new List<string> { "Suicide or self-injury", "Eating disorder" }
		},
		{
			"Violent, hateful or disturbing content",
			new List<string> { "Credible threat to safety", "Seems like terrorism", "Calling for violence", "Seems like organized crime", "Promoting hate", "Showing violence, death or severe injury", "Animal abuse" }
		},
		{
			"Selling or promoting restricted items",
			new List<string> { "Drugs", "Weapons", "Animals" }
		},
		{
			"Adult content",
			new List<string> { "Threatening to share my nude images", "Seems like prostitution", "My nude images have been shared", "Seems like sexual exploitation", "Nudity or sexual activity" }
		},
		{
			"Scam, fraud or false information",
			new List<string> { "Fraud or scam", "Sharing false information", "Spam" }
		},
		{
			"Something else",
			new List<string>()
		}
	};

	internal Dictionary<string, List<string>> dictionary_0 = new Dictionary<string, List<string>>
	{
		{
			"Problem involving someone under 18",
			new List<string> { "Threatening to share my nude images", "Seems like sexual exploitation", "Sharing someone’s nude images", "Bullying or harassment", "Physical abuse" }
		},
		{
			"Bullying, harassment or abuse",
			new List<string> { "Threatening to share my nude images", "Seems like sexual exploitation", "Seems like human trafficking", "Bullying or harassment" }
		},
		{
			"Suicide or self-harm",
			new List<string> { "Suicide or self-injury", "Eating disorder" }
		},
		{
			"Violent, hateful or disturbing content",
			new List<string> { "Credible threat to safety", "Seems like terrorism", "Calling for violence", "Seems like organized crime", "Promoting hate", "Showing violence, death or severe injury", "Animal abuse" }
		},
		{
			"Selling or promoting restricted items",
			new List<string> { "Drugs", "Weapons", "Animals" }
		},
		{
			"Adult content",
			new List<string> { "Threatening to share my nude images", "Seems like prostitution", "My nude images have been shared", "Seems like sexual exploitation", "Nudity or sexual activity" }
		},
		{
			"Scam, fraud or false information",
			new List<string> { "Fraud or scam", "Sharing false information", "Spam" }
		},
		{
			"Intellectual property",
			new List<string>()
		},
		{
			"Something else",
			new List<string>()
		},
		{
			"I don’t want to see this",
			new List<string>()
		}
	};

	internal IContainer C18A6200 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label lblLink;

	internal Label EC90C5BA;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards BC81D228;

	internal Panel pnlHeader;

	internal Button A4374B28;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel DBB47401;

	internal ComboBox cbbUserNoiDungCon;

	internal ComboBox F73447A8;

	internal RichTextBox EA348304;

	internal GroupBox groupBox2;

	internal ComboBox E6198183;

	internal ComboBox cbbVideoNoiDungCon;

	internal GroupBox groupBox1;

	public static bool C4B4CD84
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public fHDReport(string FD9721A7, string string_2 = "")
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		pictureBox1.Image = Class155.DD225F0D;
		C4B4CD84 = false;
		string_0 = FD9721A7;
		F3A92E11 = string_2;
		string aA239C = Language.GetValue(DBB47401.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to close dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void fHDReport_Load(object sender, EventArgs e)
	{
		try
		{
			B934C984();
			method_1();
			EA348304.Text = gclass4_0.BDB80B23("txtLink");
			F73447A8.Text = gclass4_0.BDB80B23("cbbUserNoiDungCha", "Random");
			E6198183.Text = gclass4_0.BDB80B23("cbbVideoNoiDungCha", "Random");
			F73447A8_SelectedIndexChanged(null, null);
			E6198183_SelectedIndexChanged(null, null);
			cbbUserNoiDungCon.Text = gclass4_0.BDB80B23("cbbUserNoiDungCon", "Random");
			cbbVideoNoiDungCon.Text = gclass4_0.BDB80B23("cbbVideoNoiDungCon", "Random");
		}
		catch
		{
		}
	}

	private void B934C984()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("-1", "Random");
		for (int i = 0; i < ED8B1DAC.Keys.Count; i++)
		{
			dictionary.Add(i.ToString(), ED8B1DAC.Keys.ElementAt(i));
		}
		F73447A8.DataSource = new BindingSource(dictionary, null);
		F73447A8.DisplayMember = "Value";
		F73447A8.ValueMember = "Key";
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Random", "Random");
		foreach (string item in ED8B1DAC[F73447A8.Text])
		{
			dictionary.Add(item, item);
		}
		cbbUserNoiDungCon.DataSource = new BindingSource(dictionary, null);
		cbbUserNoiDungCon.DisplayMember = "Value";
		cbbUserNoiDungCon.ValueMember = "Key";
	}

	private void method_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("-1", "Random");
		for (int i = 0; i < dictionary_0.Keys.Count; i++)
		{
			dictionary.Add(i.ToString(), dictionary_0.Keys.ElementAt(i));
		}
		E6198183.DataSource = new BindingSource(dictionary, null);
		E6198183.DisplayMember = "Value";
		E6198183.ValueMember = "Key";
	}

	private void method_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Random", "Random");
		foreach (string item in dictionary_0[E6198183.Text])
		{
			dictionary.Add(item, item);
		}
		cbbVideoNoiDungCon.DataSource = new BindingSource(dictionary, null);
		cbbVideoNoiDungCon.DisplayMember = "Value";
		cbbVideoNoiDungCon.ValueMember = "Key";
	}

	private void F2BAC72D(object sender, EventArgs e)
	{
		Close();
	}

	private void E53712B7(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("txtLink", EA348304.Text);
		gClass.method_4("cbbUserNoiDungCha", F73447A8.Text);
		gClass.method_4("cbbVideoNoiDungCha", E6198183.Text);
		if (F73447A8.Text == "Random")
		{
			gClass.method_4("cbbUserNoiDungCon", "Random");
		}
		else
		{
			gClass.method_4("cbbUserNoiDungCon", cbbUserNoiDungCon.Text);
		}
		if (E6198183.Text == "Random")
		{
			gClass.method_4("cbbVideoNoiDungCon", "Random");
		}
		else
		{
			gClass.method_4("cbbVideoNoiDungCon", cbbVideoNoiDungCon.Text);
		}
		string e013A = gClass.ED11179C();
		if (F3A92E11 == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					C4B4CD84 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
		{
			if (Class154.smethod_13(F3A92E11, text, e013A))
			{
				C4B4CD84 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void FDB49025(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void F73447A8_SelectedIndexChanged(object sender, EventArgs e)
	{
		string key = F73447A8.Text;
		if (ED8B1DAC.ContainsKey(key) && ED8B1DAC[key].Count > 0)
		{
			cbbUserNoiDungCon.Visible = true;
			method_0();
			cbbUserNoiDungCon.SelectedIndex = 0;
		}
		else
		{
			cbbUserNoiDungCon.Visible = false;
		}
	}

	private void E6198183_SelectedIndexChanged(object sender, EventArgs e)
	{
		string key = E6198183.Text;
		if (dictionary_0.ContainsKey(key) && dictionary_0[key].Count > 0)
		{
			cbbVideoNoiDungCon.Visible = true;
			method_2();
			cbbVideoNoiDungCon.SelectedIndex = 0;
		}
		else
		{
			cbbVideoNoiDungCon.Visible = false;
		}
	}

	private void EA348304_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(EA348304, lblLink);
	}

	protected override void Dispose(bool B9B456B6)
	{
		if (B9B456B6 && C18A6200 != null)
		{
			C18A6200.Dispose();
		}
		base.Dispose(B9B456B6);
	}

	private void InitializeComponent()
	{
		C18A6200 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDReport));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(C18A6200);
		DBB47401 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(C18A6200);
		pnlHeader = new System.Windows.Forms.Panel();
		A4374B28 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		groupBox2 = new System.Windows.Forms.GroupBox();
		E6198183 = new System.Windows.Forms.ComboBox();
		cbbVideoNoiDungCon = new System.Windows.Forms.ComboBox();
		groupBox1 = new System.Windows.Forms.GroupBox();
		F73447A8 = new System.Windows.Forms.ComboBox();
		cbbUserNoiDungCon = new System.Windows.Forms.ComboBox();
		EA348304 = new System.Windows.Forms.RichTextBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		lblLink = new System.Windows.Forms.Label();
		EC90C5BA = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		BC81D228 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		groupBox2.SuspendLayout();
		groupBox1.SuspendLayout();
		BC81D228.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = DBB47401;
		bunifuDragControl_0.Vertical = true;
		DBB47401.BackColor = System.Drawing.Color.Transparent;
		DBB47401.Cursor = System.Windows.Forms.Cursors.SizeAll;
		DBB47401.Dock = System.Windows.Forms.DockStyle.Fill;
		DBB47401.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DBB47401.ForeColor = System.Drawing.Color.Black;
		DBB47401.Location = new System.Drawing.Point(0, 0);
		DBB47401.Name = "bunifuCustomLabel1";
		DBB47401.Size = new System.Drawing.Size(359, 31);
		DBB47401.TabIndex = 12;
		DBB47401.Text = "Cấu hình Report";
		DBB47401.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(A4374B28);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(DBB47401);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		A4374B28.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A4374B28.Cursor = System.Windows.Forms.Cursors.Hand;
		A4374B28.FlatAppearance.BorderSize = 0;
		A4374B28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A4374B28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A4374B28.ForeColor = System.Drawing.Color.White;
		A4374B28.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		A4374B28.Location = new System.Drawing.Point(328, 1);
		A4374B28.Name = "button1";
		A4374B28.Size = new System.Drawing.Size(30, 30);
		A4374B28.TabIndex = 77;
		A4374B28.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A4374B28.UseVisualStyleBackColor = true;
		A4374B28.Click += new System.EventHandler(F2BAC72D);
		System.Drawing.Image iconClose_fHDRe = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDRe != null) A4374B28.Image = iconClose_fHDRe;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDRe = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDRe != null) pictureBox1.Image = iconApp_fHDRe;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(groupBox2);
		panel1.Controls.Add(groupBox1);
		panel1.Controls.Add(EA348304);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(lblLink);
		panel1.Controls.Add(EC90C5BA);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(BC81D228);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 486);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		groupBox2.Controls.Add(E6198183);
		groupBox2.Controls.Add(cbbVideoNoiDungCon);
		groupBox2.Location = new System.Drawing.Point(30, 346);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(296, 82);
		groupBox2.TabIndex = 37;
		groupBox2.TabStop = false;
		groupBox2.Text = "Report post";
		E6198183.Cursor = System.Windows.Forms.Cursors.Hand;
		E6198183.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		E6198183.DropDownWidth = 300;
		E6198183.FormattingEnabled = true;
		E6198183.Location = new System.Drawing.Point(6, 22);
		E6198183.Name = "cbbVideoNoiDungCha";
		E6198183.Size = new System.Drawing.Size(284, 24);
		E6198183.TabIndex = 35;
		E6198183.SelectedIndexChanged += new System.EventHandler(E6198183_SelectedIndexChanged);
		cbbVideoNoiDungCon.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbVideoNoiDungCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbVideoNoiDungCon.DropDownWidth = 300;
		cbbVideoNoiDungCon.FormattingEnabled = true;
		cbbVideoNoiDungCon.Location = new System.Drawing.Point(6, 52);
		cbbVideoNoiDungCon.Name = "cbbVideoNoiDungCon";
		cbbVideoNoiDungCon.Size = new System.Drawing.Size(284, 24);
		cbbVideoNoiDungCon.TabIndex = 35;
		groupBox1.Controls.Add(F73447A8);
		groupBox1.Controls.Add(cbbUserNoiDungCon);
		groupBox1.Location = new System.Drawing.Point(30, 258);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(296, 82);
		groupBox1.TabIndex = 37;
		groupBox1.TabStop = false;
		groupBox1.Text = "Report user";
		F73447A8.Cursor = System.Windows.Forms.Cursors.Hand;
		F73447A8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F73447A8.DropDownWidth = 300;
		F73447A8.FormattingEnabled = true;
		F73447A8.Location = new System.Drawing.Point(6, 22);
		F73447A8.Name = "cbbUserNoiDungCha";
		F73447A8.Size = new System.Drawing.Size(284, 24);
		F73447A8.TabIndex = 35;
		F73447A8.SelectedIndexChanged += new System.EventHandler(F73447A8_SelectedIndexChanged);
		cbbUserNoiDungCon.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbUserNoiDungCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbUserNoiDungCon.DropDownWidth = 300;
		cbbUserNoiDungCon.FormattingEnabled = true;
		cbbUserNoiDungCon.Location = new System.Drawing.Point(6, 52);
		cbbUserNoiDungCon.Name = "cbbUserNoiDungCon";
		cbbUserNoiDungCon.Size = new System.Drawing.Size(284, 24);
		cbbUserNoiDungCon.TabIndex = 35;
		EA348304.Location = new System.Drawing.Point(30, 98);
		EA348304.Name = "txtLink";
		EA348304.Size = new System.Drawing.Size(296, 154);
		EA348304.TabIndex = 36;
		EA348304.Text = "";
		EA348304.TextChanged += new System.EventHandler(EA348304_TextChanged);
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
		txtTenHanhDong.TabIndex = 0;
		lblLink.AutoSize = true;
		lblLink.Location = new System.Drawing.Point(27, 79);
		lblLink.Name = "lblLink";
		lblLink.Size = new System.Drawing.Size(115, 16);
		lblLink.TabIndex = 34;
		lblLink.Text = "Danh sa\u0301ch link (0):";
		EC90C5BA.AutoSize = true;
		EC90C5BA.Location = new System.Drawing.Point(27, 52);
		EC90C5BA.Name = "label1";
		EC90C5BA.Size = new System.Drawing.Size(98, 16);
		EC90C5BA.TabIndex = 31;
		EC90C5BA.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(189, 441);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(FDB49025);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 441);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(E53712B7);
		BC81D228.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BC81D228.BackColor = System.Drawing.Color.White;
		BC81D228.BorderRadius = 0;
		BC81D228.BottomSahddow = true;
		BC81D228.color = System.Drawing.Color.FromArgb(37, 99, 235);
		BC81D228.Controls.Add(pnlHeader);
		BC81D228.LeftSahddow = false;
		BC81D228.Location = new System.Drawing.Point(1, 0);
		BC81D228.Name = "bunifuCards1";
		BC81D228.RightSahddow = true;
		BC81D228.ShadowDepth = 20;
		BC81D228.Size = new System.Drawing.Size(359, 37);
		BC81D228.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 486);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDReport";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDReport_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		groupBox2.ResumeLayout(false);
		groupBox1.ResumeLayout(false);
		BC81D228.ResumeLayout(false);
		ResumeLayout(false);
	}
}
