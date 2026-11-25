using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhAI : Form
{
	internal IContainer A3B8901E = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards bunifuCards1;

	internal Button btnClose;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel panel2;

	internal ComboBox cbbPrompt;

	internal Label B0965DA1;

	internal Button btnDelete;

	internal Button A50B743A;

	internal Button E58B11AA;

	internal GroupBox grCauHinh;

	internal RichTextBox txtPrompt;

	internal LinkLabel DE8CCD8E;

	internal TextBox txtApiKey;

	internal Label label4;

	internal Label label3;

	internal Label label2;

	internal ComboBox cbbTypeAI;

	internal Label lblNote;

	internal TextBox F01FD70E;

	internal Label CAA74322;

	internal Button B222AD2B;

	internal Button btnTest;

	internal Button CF84D8A5;

	public fCauHinhAI(string B39252A0 = "")
	{
		InitializeComponent();
		Button btnJev = new Button
		{
			Text = "Cấu hình Jev",
			Location = new Point(459, 529),
			Size = new Size(108, 35),
			Cursor = Cursors.Hand
		};
		btnJev.Click += (sender, args) => Commom.smethod_35(new fCauHinhJev());
		panel2.Controls.Add(btnJev);
		Language.CD21F0A9(this);
		if (Base.smethod_2() == "VN")
		{
			lblNote.Text = "Tool se\u0303 tư\u0323 lâ\u0301y nô\u0323i dung trên facebook đê\u0309 thay thê\u0301 tư\u0300 kho\u0301a {content}:\r\n- Khi đăng bài: {content} se\u0303 la\u0300 nô\u0323i dung ba\u0300i viê\u0301t muô\u0301n sư\u0309a.\r\n- Khi comment: {content} sẽ là nội dung bài viết mà bạn muốn bình luận.\r\n- Khi share bài: {content} sẽ là nội dung bài viết gô\u0301c.\r\n- Khi gửi tin nhắn: {content} sẽ là tin nhắn từ người gửi.\r\n- Khi trả lời comment: {content} sẽ là nội dung comment mà bạn cần phản hồi.";
		}
		else
		{
			lblNote.Text = "The tool will automatically retrieve content from Facebook to replace the keyword {content}:\r\n- When posting: {content} will be the content of the post you want to edit.\r\n- When commenting: {content} will be the content of the post you want to comment on.\r\n- When sharing a post: {content} will be the original post content.\r\n- When sending a message: {content} will be the message from the sender.\r\n- When replying to a comment: {content} will be the content of the comment you need to respond to.";
		}
		method_0();
		EF3057B3();
		if (!string.IsNullOrEmpty(B39252A0))
		{
			cbbPrompt.SelectedValue = B39252A0;
		}
		C5B10324(null, null);
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F2089EA9(object sender, EventArgs e)
	{
		grCauHinh.Enabled = false;
		B222AD2B.Enabled = false;
	}

	private void C5B10324(object sender, EventArgs e)
	{
		if (cbbPrompt.SelectedIndex != -1)
		{
			string string_ = cbbPrompt.SelectedValue.ToString();
			GClass10 gClass = GClass9.F404A484(string_);
			F01FD70E.Text = gClass.String_1;
			txtApiKey.Text = gClass.String_2;
			txtPrompt.Text = gClass.String_3;
			cbbTypeAI.Text = gClass.E2AD160C;
		}
	}

	private void EF3057B3()
	{
		cbbPrompt.SelectedValueChanged -= C5B10324;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<GClass10> list = GClass9.EC28DF14();
		foreach (GClass10 item in list)
		{
			dictionary.Add(item.String_0.ToString(), item.String_1.ToString());
		}
		Commom.smethod_24(cbbPrompt, dictionary);
		cbbPrompt.SelectedValueChanged += C5B10324;
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Gemini");
		dictionary.Add("1", "ChatGPT");
		dictionary.Add("2", "DeepSeek");
		Commom.smethod_24(cbbTypeAI, dictionary);
	}

	private void method_1()
	{
		F01FD70E.Clear();
		cbbTypeAI.SelectedIndex = 0;
		txtApiKey.Clear();
		txtPrompt.Clear();
	}

	private void A5348FA5(object sender, EventArgs e)
	{
		method_1();
		F01FD70E.Focus();
		B222AD2B.Tag = "";
		grCauHinh.Enabled = true;
		B222AD2B.Enabled = true;
		E58B11AA.Enabled = false;
		A50B743A.Enabled = false;
		btnDelete.Enabled = false;
	}

	private void E6136980(object sender, EventArgs e)
	{
		if (cbbPrompt.SelectedIndex != -1)
		{
			B222AD2B.Tag = cbbPrompt.SelectedValue.ToString();
			grCauHinh.Enabled = true;
			B222AD2B.Enabled = true;
			E58B11AA.Enabled = false;
			A50B743A.Enabled = false;
			btnDelete.Enabled = false;
		}
	}

	private void EC068993(object sender, EventArgs e)
	{
		if (cbbPrompt.SelectedIndex != -1 && MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n xo\u0301a prompt đang cho\u0323n?") == DialogResult.Yes)
		{
			if (!GClass9.E6115228(cbbPrompt.SelectedValue.ToString()))
			{
				MsBoxHelper.Show("Xo\u0301a prompt thâ\u0301t ba\u0323i!", 2);
				return;
			}
			MsBoxHelper.Show("Xo\u0301a prompt tha\u0300nh công!");
			EF3057B3();
			C5B10324(null, null);
		}
	}

	private void F4171718(object sender, EventArgs e)
	{
		string apiKey = txtApiKey.Text.Trim();
		if (string.IsNullOrEmpty(apiKey))
		{
			MsBoxHelper.Show("Vui lòng nhập API Key trước khi test!", 3);
			txtApiKey.Focus();
			return;
		}

		string testPrompt = txtPrompt.Text;
		// Nếu prompt chứa {content}, tự động điền nội dung mẫu thực tế
		if (!string.IsNullOrEmpty(testPrompt) && testPrompt.Contains("{content}"))
		{
			testPrompt = testPrompt.Replace("{content}", "Sản phẩm này còn hàng không bạn ơi? Giá bao nhiêu vậy?");
		}
		// Nếu prompt rỗng, dùng câu mặc định
		if (string.IsNullOrEmpty(testPrompt))
		{
			testPrompt = "Xin chào, hãy trả lời ngắn gọn: 1+1 bằng mấy?";
		}

		string result = WhiteNewLib.Common.AIRequest(cbbTypeAI.Text, apiKey, testPrompt, "", "");

		if (string.IsNullOrEmpty(result))
		{
			MsBoxHelper.Show("❌ Test thất bại!\n\nKhông nhận được phản hồi từ AI.\nVui lòng kiểm tra lại API Key và kết nối mạng.", 2);
		}
		else if (result.StartsWith("Error:"))
		{
			MsBoxHelper.Show("❌ Test thất bại!\n\n" + result + "\n\nVui lòng kiểm tra lại API Key.", 2);
		}
		else
		{
			string preview = result.Length > 500 ? result.Substring(0, 500) + "..." : result;
			MsBoxHelper.Show("✅ Test thành công! AI đã phản hồi:\n\n" + preview);
		}
	}

	private void DFA93BAE(object sender, EventArgs e)
	{
		string text = B222AD2B.Tag.ToString();
		if (text == "")
		{
			text = Convert.ToInt32(Commom.smethod_15(DateTime.Now)).ToString();
		}
		GClass10 fA01D = new GClass10
		{
			String_0 = text,
			String_1 = F01FD70E.Text,
			E2AD160C = cbbTypeAI.Text,
			String_2 = txtApiKey.Text,
			String_3 = txtPrompt.Text
		};
		if (!GClass9.smethod_1(fA01D))
		{
			MsBoxHelper.Show("Thâ\u0301t ba\u0323i!", 2);
			return;
		}
		EF3057B3();
		cbbPrompt.SelectedValue = text;
		E58B11AA.Enabled = true;
		A50B743A.Enabled = true;
		btnDelete.Enabled = true;
		grCauHinh.Enabled = false;
		B222AD2B.Enabled = false;
	}

	private void DE8CCD8E_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		switch (cbbTypeAI.Text)
		{
		case "Gemini":
			Commom.CE2E5B3B("https://aistudio.google.com/app/apikey");
			break;
		case "ChatGPT":
			Commom.CE2E5B3B("https://platform.openai.com/api-keys");
			break;
		case "DeepSeek":
			Commom.CE2E5B3B("https://platform.deepseek.com/api_keys");
			break;
		}
	}

	private void CA0FE607(object sender, EventArgs e)
	{
		try
		{
			if (cbbPrompt.SelectedIndex == -1)
			{
				return;
			}
			string text = Convert.ToInt32(Commom.smethod_15(DateTime.Now)).ToString();
			string text2 = F01FD70E.Text;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> item in cbbPrompt.Items)
			{
				if (item.Value.StartsWith(text2))
				{
					list.Add(item.Value);
				}
			}
			list.Sort();
			int num = 1;
			while (list.Contains(text2 + " - Copy (" + num + ")"))
			{
				num++;
			}
			text2 = text2 + " - Copy (" + num + ")";
			GClass10 fA01D = new GClass10
			{
				String_0 = text,
				String_1 = text2,
				E2AD160C = cbbTypeAI.Text,
				String_2 = txtApiKey.Text,
				String_3 = txtPrompt.Text
			};
			if (!GClass9.smethod_1(fA01D))
			{
				MsBoxHelper.Show("Thâ\u0301t ba\u0323i!", 2);
				return;
			}
			EF3057B3();
			cbbPrompt.SelectedValue = text;
		}
		catch
		{
		}
	}

	protected override void Dispose(bool CEB9DB90)
	{
		if (CEB9DB90 && A3B8901E != null)
		{
			A3B8901E.Dispose();
		}
		base.Dispose(CEB9DB90);
	}

	private void InitializeComponent()
	{
		A3B8901E = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhAI));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(A3B8901E);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		btnClose = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		B222AD2B = new System.Windows.Forms.Button();
		btnTest = new System.Windows.Forms.Button();
		grCauHinh = new System.Windows.Forms.GroupBox();
		txtPrompt = new System.Windows.Forms.RichTextBox();
		DE8CCD8E = new System.Windows.Forms.LinkLabel();
		F01FD70E = new System.Windows.Forms.TextBox();
		txtApiKey = new System.Windows.Forms.TextBox();
		lblNote = new System.Windows.Forms.Label();
		CAA74322 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		cbbTypeAI = new System.Windows.Forms.ComboBox();
		btnDelete = new System.Windows.Forms.Button();
		A50B743A = new System.Windows.Forms.Button();
		E58B11AA = new System.Windows.Forms.Button();
		cbbPrompt = new System.Windows.Forms.ComboBox();
		B0965DA1 = new System.Windows.Forms.Label();
		CF84D8A5 = new System.Windows.Forms.Button();
		bunifuCards1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel2.SuspendLayout();
		grCauHinh.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(796, 38);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Prompt AI";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(btnClose);
		bunifuCards1.Controls.Add(pictureBox1);
		bunifuCards1.Controls.Add(bunifuCustomLabel1);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(796, 38);
		bunifuCards1.TabIndex = 29;
		btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = Class155.FF80C508;
		btnClose.Location = new System.Drawing.Point(764, 5);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(30, 30);
		btnClose.TabIndex = 77;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(btnClose_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(2, 6);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(CF84D8A5);
		panel2.Controls.Add(B222AD2B);
		panel2.Controls.Add(btnTest);
		panel2.Controls.Add(grCauHinh);
		panel2.Controls.Add(btnDelete);
		panel2.Controls.Add(A50B743A);
		panel2.Controls.Add(E58B11AA);
		panel2.Controls.Add(cbbPrompt);
		panel2.Controls.Add(B0965DA1);
		panel2.Controls.Add(bunifuCards1);
		panel2.Dock = System.Windows.Forms.DockStyle.Fill;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(798, 579);
		panel2.TabIndex = 30;
		B222AD2B.Cursor = System.Windows.Forms.Cursors.Hand;
		B222AD2B.Location = new System.Drawing.Point(676, 529);
		B222AD2B.Name = "btnSave";
		B222AD2B.Size = new System.Drawing.Size(89, 35);
		B222AD2B.TabIndex = 94;
		B222AD2B.Text = "Lưu Prompt";
		B222AD2B.UseVisualStyleBackColor = true;
		B222AD2B.Click += new System.EventHandler(DFA93BAE);
		btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
		btnTest.Location = new System.Drawing.Point(577, 529);
		btnTest.Name = "btnTest";
		btnTest.Size = new System.Drawing.Size(89, 35);
		btnTest.TabIndex = 94;
		btnTest.Text = "Test Prompt";
		btnTest.UseVisualStyleBackColor = true;
		btnTest.Click += new System.EventHandler(F4171718);
		grCauHinh.Controls.Add(txtPrompt);
		grCauHinh.Controls.Add(DE8CCD8E);
		grCauHinh.Controls.Add(F01FD70E);
		grCauHinh.Controls.Add(txtApiKey);
		grCauHinh.Controls.Add(lblNote);
		grCauHinh.Controls.Add(CAA74322);
		grCauHinh.Controls.Add(label4);
		grCauHinh.Controls.Add(label3);
		grCauHinh.Controls.Add(label2);
		grCauHinh.Controls.Add(cbbTypeAI);
		grCauHinh.Location = new System.Drawing.Point(27, 82);
		grCauHinh.Name = "grCauHinh";
		grCauHinh.Size = new System.Drawing.Size(738, 441);
		grCauHinh.TabIndex = 93;
		grCauHinh.TabStop = false;
		grCauHinh.Text = "Câ\u0301u hi\u0300nh";
		txtPrompt.Location = new System.Drawing.Point(93, 110);
		txtPrompt.Name = "txtPrompt";
		txtPrompt.Size = new System.Drawing.Size(639, 216);
		txtPrompt.TabIndex = 34;
		txtPrompt.Text = "";
		txtPrompt.WordWrap = false;
		DE8CCD8E.AutoSize = true;
		DE8CCD8E.Cursor = System.Windows.Forms.Cursors.Hand;
		DE8CCD8E.Location = new System.Drawing.Point(619, 54);
		DE8CCD8E.Name = "linkLabel1";
		DE8CCD8E.Size = new System.Drawing.Size(103, 16);
		DE8CCD8E.TabIndex = 33;
		DE8CCD8E.TabStop = true;
		DE8CCD8E.Text = "Ca\u0301ch lâ\u0301y ApiKey?";
		DE8CCD8E.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(DE8CCD8E_LinkClicked);
		F01FD70E.Location = new System.Drawing.Point(93, 22);
		F01FD70E.Name = "txtTenPrompt";
		F01FD70E.Size = new System.Drawing.Size(639, 23);
		F01FD70E.TabIndex = 32;
		txtApiKey.Location = new System.Drawing.Point(93, 81);
		txtApiKey.Name = "txtApiKey";
		txtApiKey.Size = new System.Drawing.Size(639, 23);
		txtApiKey.TabIndex = 32;
		lblNote.AutoSize = true;
		lblNote.Location = new System.Drawing.Point(20, 331);
		lblNote.Name = "lblNote";
		lblNote.Size = new System.Drawing.Size(459, 96);
		lblNote.TabIndex = 30;
		lblNote.Text = resources.GetString("lblNote.Text");
		CAA74322.AutoSize = true;
		CAA74322.Location = new System.Drawing.Point(6, 25);
		CAA74322.Name = "label6";
		CAA74322.Size = new System.Drawing.Size(79, 16);
		CAA74322.TabIndex = 30;
		CAA74322.Text = "Tên prompt:";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(6, 110);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(53, 16);
		label4.TabIndex = 30;
		label4.Text = "Prompt:";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(6, 84);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(51, 16);
		label3.TabIndex = 30;
		label3.Text = "APIKey:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(6, 54);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(51, 16);
		label2.TabIndex = 30;
		label2.Text = "Loa\u0323i AI:";
		cbbTypeAI.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeAI.FormattingEnabled = true;
		cbbTypeAI.Location = new System.Drawing.Point(93, 51);
		cbbTypeAI.Name = "cbbTypeAI";
		cbbTypeAI.Size = new System.Drawing.Size(520, 24);
		cbbTypeAI.TabIndex = 31;
		btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnDelete.Image = Class155.Bitmap_85;
		btnDelete.Location = new System.Drawing.Point(705, 50);
		btnDelete.Name = "btnDelete";
		btnDelete.Padding = new System.Windows.Forms.Padding(3);
		btnDelete.Size = new System.Drawing.Size(27, 27);
		btnDelete.TabIndex = 90;
		btnDelete.Click += new System.EventHandler(EC068993);
		A50B743A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A50B743A.Cursor = System.Windows.Forms.Cursors.Hand;
		A50B743A.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A50B743A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A50B743A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A50B743A.Image = Class155.Bitmap_90;
		A50B743A.Location = new System.Drawing.Point(672, 50);
		A50B743A.Name = "btnEdit";
		A50B743A.Padding = new System.Windows.Forms.Padding(3);
		A50B743A.Size = new System.Drawing.Size(27, 27);
		A50B743A.TabIndex = 91;
		A50B743A.Click += new System.EventHandler(E6136980);
		E58B11AA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E58B11AA.Cursor = System.Windows.Forms.Cursors.Hand;
		E58B11AA.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		E58B11AA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E58B11AA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E58B11AA.Image = Class155.BF19D114;
		E58B11AA.Location = new System.Drawing.Point(639, 50);
		E58B11AA.Name = "btnAdd";
		E58B11AA.Padding = new System.Windows.Forms.Padding(3);
		E58B11AA.Size = new System.Drawing.Size(27, 27);
		E58B11AA.TabIndex = 92;
		E58B11AA.Click += new System.EventHandler(A5348FA5);
		cbbPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbPrompt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbPrompt.FormattingEnabled = true;
		cbbPrompt.Location = new System.Drawing.Point(120, 52);
		cbbPrompt.Name = "cbbPrompt";
		cbbPrompt.Size = new System.Drawing.Size(513, 24);
		cbbPrompt.TabIndex = 31;
		B0965DA1.AutoSize = true;
		B0965DA1.Location = new System.Drawing.Point(24, 55);
		B0965DA1.Name = "label1";
		B0965DA1.Size = new System.Drawing.Size(86, 16);
		B0965DA1.TabIndex = 30;
		B0965DA1.Text = "Cho\u0323n Prompt:";
		CF84D8A5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		CF84D8A5.Cursor = System.Windows.Forms.Cursors.Hand;
		CF84D8A5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		CF84D8A5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CF84D8A5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CF84D8A5.Image = Class155.AE116F9B;
		CF84D8A5.Location = new System.Drawing.Point(738, 50);
		CF84D8A5.Name = "btnDuplicate";
		CF84D8A5.Padding = new System.Windows.Forms.Padding(3);
		CF84D8A5.Size = new System.Drawing.Size(27, 27);
		CF84D8A5.TabIndex = 95;
		CF84D8A5.Click += new System.EventHandler(CA0FE607);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(798, 579);
		base.Controls.Add(panel2);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhAI";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(F2089EA9);
		bunifuCards1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		grCauHinh.ResumeLayout(false);
		grCauHinh.PerformLayout();
		ResumeLayout(false);
	}
}
