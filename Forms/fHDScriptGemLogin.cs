using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;

public class fHDScriptGemLogin : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 A912570A;

	internal string string_0;

	internal string string_1;

	internal string EB3B8908;

	internal static bool bool_0;

	internal Dictionary<string, JObject> E62A61A7 = new Dictionary<string, JObject>();

	internal string string_2 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel D0123A84;

	internal TextBox ECB975BF;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards EB2AAEAB;

	internal Panel AD1BCF96;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel D0A78E24;

	internal ComboBox C9A6D207;

	internal Label label4;

	internal Button btnReload;

	internal FlowLayoutPanel flowLayoutPanel;

	internal NumericUpDown nudScriptTimeout;

	internal Label DA08D424;

	internal Label label3;

	internal NumericUpDown nudWidthChrome;

	internal NumericUpDown A998F48A;

	internal Label FF02F116;

	internal Label FA14DF3A;

	public fHDScriptGemLogin(string string_3, string string_4 = "")
	{
		InitializeComponent();
		bool_0 = false;
		string_0 = string_3;
		EB3B8908 = string_4;
		string aA239C = Language.GetValue(D0A78E24.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_4 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			ECB975BF.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_4);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			ECB975BF.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		A912570A = new GClass4(text2, F79F9AB5: true);
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

	private void fHDScriptGemLogin_Load(object sender, EventArgs e)
	{
		try
		{
			nudWidthChrome.Value = A912570A.method_2("nudWidthChrome", 500);
			A998F48A.Value = A912570A.method_2("nudHeighChrome", 700);
			nudScriptTimeout.Value = A912570A.method_2("nudScriptTimeout", 600);
			C9A6D207.Enabled = EB3B8908 == "";
			btnReload.Enabled = EB3B8908 == "";
			method_0();
			if (C9A6D207.Items.Count == 0)
			{
				return;
			}
			string text = A912570A.BDB80B23("cbbScripts");
			if (!E62A61A7.ContainsKey(text))
			{
				text = E62A61A7.First().Key;
			}
			C9A6D207.SelectedValue = text;
			if (EB3B8908 == "")
			{
				ECB975BF.Text = C9A6D207.Text;
				return;
			}
			foreach (Panel control in flowLayoutPanel.Controls)
			{
				GControl0 gControl = control.Controls[0] as GControl0;
				gControl.vmethod_3(A912570A.BDB80B23(gControl.method_1()));
			}
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C13F7386(object sender, EventArgs e)
	{
		string text = ECB975BF.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		JObject jObject = new JObject();
		jObject["nudWidthChrome"] = (JToken)Convert.ToInt32(nudWidthChrome.Value);
		jObject["nudHeighChrome"] = (JToken)Convert.ToInt32(A998F48A.Value);
		jObject["nudScriptTimeout"] = (JToken)Convert.ToInt32(nudScriptTimeout.Value);
		jObject["cbbScripts"] = (JToken)C9A6D207.SelectedValue.ToString();
		foreach (Panel control in flowLayoutPanel.Controls)
		{
			GControl0 gControl = control.Controls[0] as GControl0;
			if (gControl.method_1() != "")
			{
				jObject[gControl.method_1()] = JToken.FromObject(gControl.vmethod_5());
			}
		}
		string e013A = jObject.ToString();
		if (EB3B8908 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					bool_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(EB3B8908, text, e013A))
			{
				bool_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BA109095(object sender, PaintEventArgs e)
	{
		if (D0123A84.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, D0123A84.ClientSize.Width - num, D0123A84.ClientSize.Height - num));
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void btnReload_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		try
		{
			string text = (C9A6D207.SelectedValue ?? "").ToString();
			C9A6D207.SelectedValueChanged -= C9A6D207_SelectedValueChanged;
			E62A61A7.Clear();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text2 = new GClass0().B2157B0A("http://localhost:1010/api/scripts");
			if (text2 == "")
			{
				MsBoxHelper.Show("Không thể kết nối đến GemLogin", 2);
				return;
			}
			JObject jObject = JObject.Parse(text2);
			foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
			{
				string key = item["id"]!.ToString();
				string value = item["name"]!.ToString();
				dictionary.Add(key, value);
				E62A61A7.Add(key, (JObject)item);
			}
			Commom.smethod_24(C9A6D207, dictionary);
			if (E62A61A7.ContainsKey(text))
			{
				C9A6D207.SelectedValue = text;
			}
			else
			{
				C9A6D207.SelectedIndex = -1;
			}
			C9A6D207.SelectedValueChanged += C9A6D207_SelectedValueChanged;
		}
		catch (Exception)
		{
		}
	}

	private void C9A6D207_SelectedValueChanged(object sender, EventArgs e)
	{
		if (C9A6D207.SelectedValue == null || C9A6D207.SelectedValue.ToString() == string_2)
		{
			return;
		}
		string_2 = C9A6D207.SelectedValue.ToString();
		try
		{
			if (EB3B8908 == "")
			{
				ECB975BF.Text = C9A6D207.Text;
			}
			JArray jArray = E62A61A7[C9A6D207.SelectedValue.ToString()]["parameters"] as JArray;
			flowLayoutPanel.Controls.Clear();
			foreach (JObject item in jArray)
			{
				method_1(item);
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_1(JObject BABF6195)
	{
		try
		{
			string text = BABF6195["type"]!.ToString();
			string text2 = BABF6195["name"]!.ToString();
			string f502943D = BABF6195["label"]!.ToString();
			string d224C8B = BABF6195["defaultValue"]!.ToString();
			string text3 = BABF6195["description"]!.ToString();
			Convert.ToBoolean(BABF6195["required"]);
			int num = -1;
			GControl0 gControl = null;
			switch (text)
			{
			case "checkbox":
				gControl = new DCA0BA83();
				break;
			case "filepath":
				gControl = new F0002A31();
				break;
			case "number":
				gControl = new CCA901B5();
				break;
			case "json":
				gControl = new ucInputJson();
				break;
			case "string":
				gControl = new ucInputText();
				break;
			}
			gControl.vmethod_1(text2);
			gControl.vmethod_0(f502943D);
			gControl.vmethod_2(d224C8B);
			gControl.method_0(text3);
			Point pt = new Point(gControl.Size.Width + 2, gControl.Size.Height);
			Panel panel = new Panel();
			panel.Controls.Add(gControl);
			panel.BorderStyle = BorderStyle.FixedSingle;
			panel.Size = new Size(pt);
			flowLayoutPanel.Controls.Add(panel);
			if (num > -1)
			{
				flowLayoutPanel.Controls.SetChildIndex(panel, num);
			}
		}
		catch (Exception)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDScriptGemLogin));
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D0A78E24 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		AD1BCF96 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		D0123A84 = new System.Windows.Forms.Panel();
		flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
		nudScriptTimeout = new System.Windows.Forms.NumericUpDown();
		btnReload = new System.Windows.Forms.Button();
		C9A6D207 = new System.Windows.Forms.ComboBox();
		ECB975BF = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		DA08D424 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		EB2AAEAB = new Bunifu.Framework.UI.BunifuCards();
		nudWidthChrome = new System.Windows.Forms.NumericUpDown();
		A998F48A = new System.Windows.Forms.NumericUpDown();
		FF02F116 = new System.Windows.Forms.Label();
		FA14DF3A = new System.Windows.Forms.Label();
		AD1BCF96.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		D0123A84.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudScriptTimeout).BeginInit();
		EB2AAEAB.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudWidthChrome).BeginInit();
		((System.ComponentModel.ISupportInitialize)A998F48A).BeginInit();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = D0A78E24;
		bunifuDragControl_0.Vertical = true;
		D0A78E24.BackColor = System.Drawing.Color.Transparent;
		D0A78E24.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D0A78E24.Dock = System.Windows.Forms.DockStyle.Fill;
		D0A78E24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D0A78E24.ForeColor = System.Drawing.Color.Black;
		D0A78E24.Location = new System.Drawing.Point(0, 0);
		D0A78E24.Name = "bunifuCustomLabel1";
		D0A78E24.Size = new System.Drawing.Size(554, 31);
		D0A78E24.TabIndex = 12;
		D0A78E24.Text = "Cấu hình Script GemLogin";
		D0A78E24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = AD1BCF96;
		bunifuDragControl_1.Vertical = true;
		AD1BCF96.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		AD1BCF96.BackColor = System.Drawing.Color.White;
		AD1BCF96.Controls.Add(button1);
		AD1BCF96.Controls.Add(pictureBox1);
		AD1BCF96.Controls.Add(D0A78E24);
		AD1BCF96.Cursor = System.Windows.Forms.Cursors.SizeAll;
		AD1BCF96.Location = new System.Drawing.Point(0, 3);
		AD1BCF96.Name = "pnlHeader";
		AD1BCF96.Size = new System.Drawing.Size(554, 31);
		AD1BCF96.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(523, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		System.Drawing.Image iconClose_fHDSc = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDSc != null) button1.Image = iconClose_fHDSc;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDSc = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDSc != null) pictureBox1.Image = iconApp_fHDSc;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		D0123A84.BackColor = System.Drawing.Color.White;
		D0123A84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D0123A84.Controls.Add(pnlTopAccent);
		D0123A84.Controls.Add(nudWidthChrome);
		D0123A84.Controls.Add(A998F48A);
		D0123A84.Controls.Add(FF02F116);
		D0123A84.Controls.Add(flowLayoutPanel);
		D0123A84.Controls.Add(nudScriptTimeout);
		D0123A84.Controls.Add(btnReload);
		D0123A84.Controls.Add(C9A6D207);
		D0123A84.Controls.Add(ECB975BF);
		D0123A84.Controls.Add(label3);
		D0123A84.Controls.Add(FA14DF3A);
		D0123A84.Controls.Add(DA08D424);
		D0123A84.Controls.Add(label4);
		D0123A84.Controls.Add(label1);
		D0123A84.Controls.Add(btnCancel);
		D0123A84.Controls.Add(btnAdd);
		D0123A84.Controls.Add(EB2AAEAB);
		D0123A84.Cursor = System.Windows.Forms.Cursors.Arrow;
		D0123A84.Dock = System.Windows.Forms.DockStyle.Fill;
		D0123A84.Location = new System.Drawing.Point(0, 0);
		D0123A84.Name = "panel1";
		D0123A84.Size = new System.Drawing.Size(557, 591);
		D0123A84.TabIndex = 0;
		D0123A84.Paint += new System.Windows.Forms.PaintEventHandler(BA109095);
		flowLayoutPanel.AutoScroll = true;
		flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		flowLayoutPanel.Location = new System.Drawing.Point(147, 169);
		flowLayoutPanel.Name = "flowLayoutPanel";
		flowLayoutPanel.Size = new System.Drawing.Size(375, 363);
		flowLayoutPanel.TabIndex = 26;
		flowLayoutPanel.WrapContents = false;
		nudScriptTimeout.Location = new System.Drawing.Point(150, 111);
		nudScriptTimeout.Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		nudScriptTimeout.Minimum = new decimal(new int[4] { 60, 0, 0, 0 });
		nudScriptTimeout.Name = "nudScriptTimeout";
		nudScriptTimeout.Size = new System.Drawing.Size(352, 23);
		nudScriptTimeout.TabIndex = 35;
		nudScriptTimeout.Value = new decimal(new int[4] { 60, 0, 0, 0 });
		btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
		btnReload.Location = new System.Drawing.Point(443, 80);
		btnReload.Name = "btnReload";
		btnReload.Size = new System.Drawing.Size(60, 26);
		btnReload.TabIndex = 33;
		btnReload.Text = "Reload";
		btnReload.UseVisualStyleBackColor = true;
		btnReload.Click += new System.EventHandler(btnReload_Click);
		C9A6D207.Cursor = System.Windows.Forms.Cursors.Hand;
		C9A6D207.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		C9A6D207.DropDownWidth = 350;
		C9A6D207.FormattingEnabled = true;
		C9A6D207.Location = new System.Drawing.Point(150, 81);
		C9A6D207.Name = "cbbScripts";
		C9A6D207.Size = new System.Drawing.Size(287, 24);
		C9A6D207.TabIndex = 1;
		ECB975BF.Location = new System.Drawing.Point(150, 52);
		ECB975BF.Name = "txtTenHanhDong";
		ECB975BF.Size = new System.Drawing.Size(352, 23);
		ECB975BF.TabIndex = 0;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(30, 169);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(92, 16);
		label3.TabIndex = 32;
		label3.Text = "Câ\u0301u hi\u0300nh cha\u0323y:";
		DA08D424.AutoSize = true;
		DA08D424.Location = new System.Drawing.Point(30, 113);
		DA08D424.Name = "label2";
		DA08D424.Size = new System.Drawing.Size(79, 16);
		DA08D424.TabIndex = 32;
		DA08D424.Text = "Timeout (s):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(30, 84);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(76, 16);
		label4.TabIndex = 32;
		label4.Text = "Cho\u0323n script:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(30, 55);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(286, 548);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(179, 548);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(C13F7386);
		EB2AAEAB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EB2AAEAB.BackColor = System.Drawing.Color.White;
		EB2AAEAB.BorderRadius = 0;
		EB2AAEAB.BottomSahddow = true;
		EB2AAEAB.color = System.Drawing.Color.FromArgb(37, 99, 235);
		EB2AAEAB.Controls.Add(AD1BCF96);
		EB2AAEAB.LeftSahddow = false;
		EB2AAEAB.Location = new System.Drawing.Point(1, 0);
		EB2AAEAB.Name = "bunifuCards1";
		EB2AAEAB.RightSahddow = true;
		EB2AAEAB.ShadowDepth = 20;
		EB2AAEAB.Size = new System.Drawing.Size(554, 37);
		EB2AAEAB.TabIndex = 28;
		nudWidthChrome.Location = new System.Drawing.Point(150, 140);
		nudWidthChrome.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudWidthChrome.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudWidthChrome.Name = "nudWidthChrome";
		nudWidthChrome.Size = new System.Drawing.Size(43, 23);
		nudWidthChrome.TabIndex = 154;
		nudWidthChrome.Value = new decimal(new int[4] { 320, 0, 0, 0 });
		A998F48A.Location = new System.Drawing.Point(215, 140);
		A998F48A.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A998F48A.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		A998F48A.Name = "nudHeighChrome";
		A998F48A.Size = new System.Drawing.Size(43, 23);
		A998F48A.TabIndex = 153;
		A998F48A.Value = new decimal(new int[4] { 480, 0, 0, 0 });
		FF02F116.AutoSize = true;
		FF02F116.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FF02F116.Location = new System.Drawing.Point(193, 140);
		FF02F116.Name = "label35";
		FF02F116.Size = new System.Drawing.Size(23, 23);
		FF02F116.TabIndex = 152;
		FF02F116.Text = "X";
		FA14DF3A.AutoSize = true;
		FA14DF3A.Location = new System.Drawing.Point(30, 142);
		FA14DF3A.Name = "label5";
		FA14DF3A.Size = new System.Drawing.Size(118, 16);
		FA14DF3A.TabIndex = 32;
		FA14DF3A.Text = "Ki\u0301ch thươ\u0301c chrome:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(557, 591);
		base.Controls.Add(D0123A84);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDScriptGemLogin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDScriptGemLogin_Load);
		AD1BCF96.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		D0123A84.ResumeLayout(false);
		D0123A84.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudScriptTimeout).EndInit();
		EB2AAEAB.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)nudWidthChrome).EndInit();
		((System.ComponentModel.ISupportInitialize)A998F48A).EndInit();
		ResumeLayout(false);
	}
}
