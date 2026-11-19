using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDTangTuongTac : Form
{
	internal GClass4 gclass4_0 = null;
	internal string string_0;
	internal string B8A61125;
	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool EA148485;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get => EA148485;
		[CompilerGenerated]
		set => EA148485 = value;
	}

	internal IContainer components = null;
	internal BunifuDragControl bunifuDragControl_0;
	internal BunifuDragControl bunifuDragControl_1;
	internal Panel pnlTopAccent;
	internal BunifuCards FE88CD9F;
	internal Panel pnlHeader;
	internal PictureBox pictureBox1;
	internal BunifuCustomLabel bunifuCustomLabel1;
	internal Button btnMinimize;
	internal Button button1;

	internal Panel panel1;
	internal Panel pnlBody;
	internal Panel pnlBottom;

	// Group 1: Tên hành động
	internal Label label1;
	internal TextBox txtTenHanhDong;

	// Group 2: Nguồn Page cần tương tác
	internal GroupBox grbPages;
	internal CheckBox ckbTuongTacPage;
	internal Label lblLinkPage;
	internal RichTextBox rtbLinkPage;

	// Group 3: Link Profile wall cần Follow
	internal GroupBox grbFollow;
	internal CheckBox ckbFollow;
	internal RichTextBox rtbLinkFollow;

	// Group 4: Bài viết cần tương tác
	internal GroupBox grbPost;
	internal Label lblLinkPost;
	internal RichTextBox rtbLinkPost;
	internal CheckBox ckbTuongTacNewfeed;

	// Group 5: Loại tương tác
	internal GroupBox grbReaction;
	internal CheckBox ckbLike;
	internal CheckBox ckbLove;
	internal CheckBox ckbCare;
	internal CheckBox ckbHaha;
	internal CheckBox ckbWow;
	internal CheckBox ckbSad;
	internal CheckBox ckbAngry;
	internal CheckBox ckbComment;
	internal RichTextBox rtbComment;
	internal CheckBox ckbShare;
	internal RadioButton rbShareWall;
	internal RadioButton rbShareStory;
	internal CheckBox ckbSendImg;
	internal TextBox txtImgFolder;
	internal Button btnChonAnh;

	// Group 6: Cài đặt Delay
	internal GroupBox grbDelay;
	internal Label lblDelayPost;
	internal NumericUpDown nudDelayFrom;
	internal Label lblDelayTo;
	internal NumericUpDown nudDelayTo;
	internal Label lblDelayAction;
	internal NumericUpDown nudDelayActionFrom;
	internal Label lblDelayActionTo;
	internal NumericUpDown nudDelayActionTo;
	internal Label lblDelayActionUnit;
	internal CheckBox ckbUuTienMbasic;

	// Buttons
	internal Button BA931F04;
	internal Button btnCancel;

	public fHDTangTuongTac(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			B8A61125 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			BA931F04.Text = Language.GetValue("Cập nhật");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void fHDTangTuongTac_Load(object sender, EventArgs e)
	{
		try
		{
			txtTenHanhDong.Text = gclass4_0.BDB80B23("txtTenHanhDong", txtTenHanhDong.Text);
			ckbTuongTacPage.Checked = gclass4_0.method_3("ckbTuongTacPage", true);
			rtbLinkPage.Text = gclass4_0.BDB80B23("rtbLinkPage");
			ckbFollow.Checked = gclass4_0.method_3("ckbFollow");
			rtbLinkFollow.Text = gclass4_0.BDB80B23("rtbLinkFollow");
			rtbLinkPost.Text = gclass4_0.BDB80B23("rtbLinkPost");
			ckbTuongTacNewfeed.Checked = gclass4_0.method_3("ckbTuongTacNewfeed");

			var reactions = gclass4_0.BDB80B23("typeReaction", "Like");
			ckbLike.Checked = reactions.Contains("Like");
			ckbLove.Checked = reactions.Contains("Love");
			ckbCare.Checked = reactions.Contains("Care");
			ckbHaha.Checked = reactions.Contains("Haha");
			ckbWow.Checked = reactions.Contains("Wow");
			ckbSad.Checked = reactions.Contains("Sad");
			ckbAngry.Checked = reactions.Contains("Angry");

			ckbComment.Checked = gclass4_0.method_3("ckbComment");
			rtbComment.Text = gclass4_0.BDB80B23("rtbComment");
			ckbShare.Checked = gclass4_0.method_3("ckbShare");
			rbShareWall.Checked = gclass4_0.method_3("rbShareWall", true);
			rbShareStory.Checked = !rbShareWall.Checked;
			ckbSendImg.Checked = gclass4_0.method_3("ckbSendImg");
			txtImgFolder.Text = gclass4_0.BDB80B23("txtImgFolder");

			nudDelayFrom.Value = Math.Max(1, gclass4_0.method_2("nudDelayFrom", 3));
			nudDelayTo.Value = Math.Max((int)nudDelayFrom.Value, gclass4_0.method_2("nudDelayTo", 6));
			nudDelayActionFrom.Value = Math.Max(1, gclass4_0.method_2("nudDelayActionFrom", 1));
			nudDelayActionTo.Value = Math.Max((int)nudDelayActionFrom.Value, gclass4_0.method_2("nudDelayActionTo", 2));
			ckbUuTienMbasic.Checked = gclass4_0.method_3("ckbUuTienMbasic");
		}
		catch
		{
		}
	}

	private string GetSelectedReactions()
	{
		var list = new List<string>();
		if (ckbLike.Checked) list.Add("Like");
		if (ckbLove.Checked) list.Add("Love");
		if (ckbCare.Checked) list.Add("Care");
		if (ckbHaha.Checked) list.Add("Haha");
		if (ckbWow.Checked) list.Add("Wow");
		if (ckbSad.Checked) list.Add("Sad");
		if (ckbAngry.Checked) list.Add("Angry");
		return string.Join("|", list);
	}

	private void BA931F04_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng nhập tên hành động!", 3);
			return;
		}

		bool hasInteraction = ckbLike.Checked || ckbLove.Checked || ckbCare.Checked || ckbHaha.Checked || ckbWow.Checked || ckbSad.Checked || ckbAngry.Checked || ckbComment.Checked || ckbShare.Checked || ckbFollow.Checked;
		if (!hasInteraction)
		{
			MsBoxHelper.Show("Vui lòng chọn ít nhất 1 loại tương tác (Like, Comment, Share, Follow)!", 3);
			return;
		}

		GClass4 cfg = new GClass4();
		cfg.method_4("txtTenHanhDong", txtTenHanhDong.Text.Trim());
		cfg.method_4("ckbTuongTacPage", ckbTuongTacPage.Checked);
		cfg.method_4("rtbLinkPage", rtbLinkPage.Text.Trim());
		cfg.method_4("ckbFollow", ckbFollow.Checked);
		cfg.method_4("rtbLinkFollow", rtbLinkFollow.Text.Trim());
		cfg.method_4("rtbLinkPost", rtbLinkPost.Text.Trim());
		cfg.method_4("ckbTuongTacNewfeed", ckbTuongTacNewfeed.Checked);
		cfg.method_4("typeReaction", GetSelectedReactions());
		cfg.method_4("ckbComment", ckbComment.Checked);
		cfg.method_4("rtbComment", rtbComment.Text.Trim());
		cfg.method_4("ckbShare", ckbShare.Checked);
		cfg.method_4("rbShareWall", rbShareWall.Checked);
		cfg.method_4("ckbSendImg", ckbSendImg.Checked);
		cfg.method_4("txtImgFolder", txtImgFolder.Text.Trim());
		cfg.method_4("nudDelayFrom", (int)nudDelayFrom.Value);
		cfg.method_4("nudDelayTo", (int)nudDelayTo.Value);
		cfg.method_4("nudDelayActionFrom", (int)nudDelayActionFrom.Value);
		cfg.method_4("nudDelayActionTo", (int)nudDelayActionTo.Value);
		cfg.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);

		string e013A = cfg.ED11179C();

		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Bạn có muốn thêm hành động mới?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, B8A61125, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thất bại, vui lòng thử lại sau!", 2);
				}
			}
		}
		else
		{
			if (MsBoxHelper.D41C45AC("Bạn có muốn cập nhật hành động?") == DialogResult.Yes)
			{
				if (Class154.smethod_13(string_1, text, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Cập nhật thất bại, vui lòng thử lại sau!", 2);
				}
			}
		}
	}

	private void BD828C30(object sender, EventArgs e)
	{
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnChonAnh_Click(object sender, EventArgs e)
	{
		try
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.Description = "Chọn thư mục chứa ảnh bình luận";
				if (Directory.Exists(txtImgFolder.Text.Trim()))
				{
					fbd.SelectedPath = txtImgFolder.Text.Trim();
				}
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					txtImgFolder.Text = fbd.SelectedPath;
				}
			}
		}
		catch
		{
		}
	}

	private void FC16B6BD(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1.5f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(components);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(components);
		pnlTopAccent = new System.Windows.Forms.Panel();
		FE88CD9F = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();

		panel1 = new System.Windows.Forms.Panel();
		pnlBody = new System.Windows.Forms.Panel();
		pnlBottom = new System.Windows.Forms.Panel();

		label1 = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();

		grbPages = new System.Windows.Forms.GroupBox();
		ckbTuongTacPage = new System.Windows.Forms.CheckBox();
		lblLinkPage = new System.Windows.Forms.Label();
		rtbLinkPage = new System.Windows.Forms.RichTextBox();

		grbFollow = new System.Windows.Forms.GroupBox();
		ckbFollow = new System.Windows.Forms.CheckBox();
		rtbLinkFollow = new System.Windows.Forms.RichTextBox();

		grbPost = new System.Windows.Forms.GroupBox();
		lblLinkPost = new System.Windows.Forms.Label();
		rtbLinkPost = new System.Windows.Forms.RichTextBox();
		ckbTuongTacNewfeed = new System.Windows.Forms.CheckBox();

		grbReaction = new System.Windows.Forms.GroupBox();
		ckbLike = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		ckbCare = new System.Windows.Forms.CheckBox();
		ckbHaha = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		ckbSad = new System.Windows.Forms.CheckBox();
		ckbAngry = new System.Windows.Forms.CheckBox();
		ckbComment = new System.Windows.Forms.CheckBox();
		rtbComment = new System.Windows.Forms.RichTextBox();
		ckbShare = new System.Windows.Forms.CheckBox();
		rbShareWall = new System.Windows.Forms.RadioButton();
		rbShareStory = new System.Windows.Forms.RadioButton();
		ckbSendImg = new System.Windows.Forms.CheckBox();
		txtImgFolder = new System.Windows.Forms.TextBox();
		btnChonAnh = new System.Windows.Forms.Button();

		grbDelay = new System.Windows.Forms.GroupBox();
		lblDelayPost = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		lblDelayTo = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		lblDelayAction = new System.Windows.Forms.Label();
		nudDelayActionFrom = new System.Windows.Forms.NumericUpDown();
		lblDelayActionTo = new System.Windows.Forms.Label();
		nudDelayActionTo = new System.Windows.Forms.NumericUpDown();
		lblDelayActionUnit = new System.Windows.Forms.Label();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();

		BA931F04 = new System.Windows.Forms.Button();
		btnCancel = new System.Windows.Forms.Button();

		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		FE88CD9F.SuspendLayout();
		panel1.SuspendLayout();
		pnlBody.SuspendLayout();
		pnlBottom.SuspendLayout();
		grbPages.SuspendLayout();
		grbFollow.SuspendLayout();
		grbPost.SuspendLayout();
		grbReaction.SuspendLayout();
		grbDelay.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayActionFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayActionTo).BeginInit();
		SuspendLayout();

		// bunifuDragControl_0
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;

		// bunifuCustomLabel1
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(498, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tăng tương tác";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// bunifuDragControl_1
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;

		// pnlTopAccent (#2563EB - 4px)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		// FE88CD9F (BunifuCards header)
		FE88CD9F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FE88CD9F.BackColor = System.Drawing.Color.White;
		FE88CD9F.BorderRadius = 0;
		FE88CD9F.BottomSahddow = true;
		FE88CD9F.color = System.Drawing.Color.FromArgb(37, 99, 235);
		FE88CD9F.Controls.Add(pnlHeader);
		FE88CD9F.LeftSahddow = false;
		FE88CD9F.Location = new System.Drawing.Point(1, 0);
		FE88CD9F.Name = "FE88CD9F";
		FE88CD9F.RightSahddow = true;
		FE88CD9F.ShadowDepth = 20;
		FE88CD9F.Size = new System.Drawing.Size(498, 36);
		FE88CD9F.TabIndex = 0;

		// pnlHeader
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(498, 31);
		pnlHeader.TabIndex = 9;

		// btnMinimize
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(434, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		// button1 (Close)
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose;
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(466, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);

		// pictureBox1
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(5, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(30, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;

		// panel1
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlBody);
		panel1.Controls.Add(pnlBottom);
		panel1.Controls.Add(FE88CD9F);
		panel1.Controls.Add(pnlTopAccent);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(500, 620);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(FC16B6BD);
		pnlTopAccent.BringToFront();

		// pnlBottom
		pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
		pnlBottom.Controls.Add(BA931F04);
		pnlBottom.Controls.Add(btnCancel);
		pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		pnlBottom.Location = new System.Drawing.Point(0, 565);
		pnlBottom.Name = "pnlBottom";
		pnlBottom.Size = new System.Drawing.Size(498, 53);
		pnlBottom.TabIndex = 2;

		// BA931F04 (btnLuu)
		BA931F04.Anchor = System.Windows.Forms.AnchorStyles.None;
		BA931F04.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		BA931F04.Cursor = System.Windows.Forms.Cursors.Hand;
		BA931F04.FlatAppearance.BorderSize = 0;
		BA931F04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BA931F04.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BA931F04.ForeColor = System.Drawing.Color.White;
		BA931F04.Location = new System.Drawing.Point(145, 10);
		BA931F04.Name = "BA931F04";
		BA931F04.Size = new System.Drawing.Size(95, 32);
		BA931F04.TabIndex = 0;
		BA931F04.Text = "Lưu";
		BA931F04.UseVisualStyleBackColor = false;
		BA931F04.Click += new System.EventHandler(BA931F04_Click);

		// btnCancel (btnDong)
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
		btnCancel.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(258, 10);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(95, 32);
		btnCancel.TabIndex = 1;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(BD828C30);

		// pnlBody
		pnlBody.AutoScroll = true;
		pnlBody.BackColor = System.Drawing.Color.White;
		pnlBody.Controls.Add(label1);
		pnlBody.Controls.Add(txtTenHanhDong);
		pnlBody.Controls.Add(grbPages);
		pnlBody.Controls.Add(grbFollow);
		pnlBody.Controls.Add(grbPost);
		pnlBody.Controls.Add(grbReaction);
		pnlBody.Controls.Add(grbDelay);
		pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
		pnlBody.Location = new System.Drawing.Point(0, 36);
		pnlBody.Name = "pnlBody";
		pnlBody.Padding = new System.Windows.Forms.Padding(10);
		pnlBody.Size = new System.Drawing.Size(498, 529);
		pnlBody.TabIndex = 1;

		// label1 (Tên hành động)
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 12);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(103, 14);
		label1.TabIndex = 0;
		label1.Text = "Tên hành động:";

		// txtTenHanhDong
		txtTenHanhDong.Location = new System.Drawing.Point(125, 9);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(335, 23);
		txtTenHanhDong.TabIndex = 1;

		// grbPages (Nhóm 2: Nguồn Page)
		grbPages.Controls.Add(ckbTuongTacPage);
		grbPages.Controls.Add(lblLinkPage);
		grbPages.Controls.Add(rtbLinkPage);
		grbPages.Location = new System.Drawing.Point(12, 38);
		grbPages.Name = "grbPages";
		grbPages.Size = new System.Drawing.Size(450, 125);
		grbPages.TabIndex = 2;
		grbPages.TabStop = false;
		grbPages.Text = "Nguồn Page cần tương tác";

		ckbTuongTacPage.AutoSize = true;
		ckbTuongTacPage.Checked = true;
		ckbTuongTacPage.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbTuongTacPage.Location = new System.Drawing.Point(12, 20);
		ckbTuongTacPage.Name = "ckbTuongTacPage";
		ckbTuongTacPage.Size = new System.Drawing.Size(225, 20);
		ckbTuongTacPage.TabIndex = 0;
		ckbTuongTacPage.Text = "Tương tác tất cả Pages trong TK";
		ckbTuongTacPage.UseVisualStyleBackColor = true;

		lblLinkPage.AutoSize = true;
		lblLinkPage.Location = new System.Drawing.Point(10, 44);
		lblLinkPage.Name = "lblLinkPage";
		lblLinkPage.Size = new System.Drawing.Size(183, 16);
		lblLinkPage.TabIndex = 1;
		lblLinkPage.Text = "Link Page cụ thể (1 dòng/link):";

		rtbLinkPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		rtbLinkPage.Location = new System.Drawing.Point(12, 63);
		rtbLinkPage.Name = "rtbLinkPage";
		rtbLinkPage.Size = new System.Drawing.Size(425, 52);
		rtbLinkPage.TabIndex = 2;
		rtbLinkPage.Text = "";

		// grbFollow (Nhóm 3: Link Profile wall cần Follow)
		grbFollow.Controls.Add(ckbFollow);
		grbFollow.Controls.Add(rtbLinkFollow);
		grbFollow.Location = new System.Drawing.Point(12, 169);
		grbFollow.Name = "grbFollow";
		grbFollow.Size = new System.Drawing.Size(450, 95);
		grbFollow.TabIndex = 3;
		grbFollow.TabStop = false;
		grbFollow.Text = "Link Profile wall cần Follow";

		ckbFollow.AutoSize = true;
		ckbFollow.Location = new System.Drawing.Point(12, 19);
		ckbFollow.Name = "ckbFollow";
		ckbFollow.Size = new System.Drawing.Size(161, 20);
		ckbFollow.TabIndex = 0;
		ckbFollow.Text = "Follow profile / fanpage";
		ckbFollow.UseVisualStyleBackColor = true;

		rtbLinkFollow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		rtbLinkFollow.Location = new System.Drawing.Point(12, 42);
		rtbLinkFollow.Name = "rtbLinkFollow";
		rtbLinkFollow.Size = new System.Drawing.Size(425, 45);
		rtbLinkFollow.TabIndex = 1;
		rtbLinkFollow.Text = "";

		// grbPost (Nhóm 4: Bài viết cần tương tác)
		grbPost.Controls.Add(lblLinkPost);
		grbPost.Controls.Add(rtbLinkPost);
		grbPost.Controls.Add(ckbTuongTacNewfeed);
		grbPost.Location = new System.Drawing.Point(12, 270);
		grbPost.Name = "grbPost";
		grbPost.Size = new System.Drawing.Size(450, 115);
		grbPost.TabIndex = 4;
		grbPost.TabStop = false;
		grbPost.Text = "Bài viết cần tương tác";

		lblLinkPost.AutoSize = true;
		lblLinkPost.Location = new System.Drawing.Point(10, 18);
		lblLinkPost.Name = "lblLinkPost";
		lblLinkPost.Size = new System.Drawing.Size(193, 16);
		lblLinkPost.TabIndex = 0;
		lblLinkPost.Text = "Link bài viết (1 dòng/link):";

		rtbLinkPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		rtbLinkPost.Location = new System.Drawing.Point(12, 37);
		rtbLinkPost.Name = "rtbLinkPost";
		rtbLinkPost.Size = new System.Drawing.Size(425, 45);
		rtbLinkPost.TabIndex = 1;
		rtbLinkPost.Text = "";

		ckbTuongTacNewfeed.AutoSize = true;
		ckbTuongTacNewfeed.Location = new System.Drawing.Point(12, 88);
		ckbTuongTacNewfeed.Name = "ckbTuongTacNewfeed";
		ckbTuongTacNewfeed.Size = new System.Drawing.Size(268, 20);
		ckbTuongTacNewfeed.TabIndex = 2;
		ckbTuongTacNewfeed.Text = "Tương tác bài trên Newsfeed trang cá nhân";
		ckbTuongTacNewfeed.UseVisualStyleBackColor = true;

		// grbReaction (Nhóm 5: Loại tương tác)
		grbReaction.Controls.Add(ckbLike);
		grbReaction.Controls.Add(ckbLove);
		grbReaction.Controls.Add(ckbCare);
		grbReaction.Controls.Add(ckbHaha);
		grbReaction.Controls.Add(ckbWow);
		grbReaction.Controls.Add(ckbSad);
		grbReaction.Controls.Add(ckbAngry);
		grbReaction.Controls.Add(ckbComment);
		grbReaction.Controls.Add(rtbComment);
		grbReaction.Controls.Add(ckbShare);
		grbReaction.Controls.Add(rbShareWall);
		grbReaction.Controls.Add(rbShareStory);
		grbReaction.Controls.Add(ckbSendImg);
		grbReaction.Controls.Add(txtImgFolder);
		grbReaction.Controls.Add(btnChonAnh);
		grbReaction.Location = new System.Drawing.Point(12, 391);
		grbReaction.Name = "grbReaction";
		grbReaction.Size = new System.Drawing.Size(450, 185);
		grbReaction.TabIndex = 5;
		grbReaction.TabStop = false;
		grbReaction.Text = "Loại tương tác";

		// Reactions
		ckbLike.AutoSize = true;
		ckbLike.Checked = true;
		ckbLike.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbLike.Location = new System.Drawing.Point(12, 20);
		ckbLike.Name = "ckbLike";
		ckbLike.Size = new System.Drawing.Size(49, 20);
		ckbLike.TabIndex = 0;
		ckbLike.Text = "Like";
		ckbLike.UseVisualStyleBackColor = true;

		ckbLove.AutoSize = true;
		ckbLove.Location = new System.Drawing.Point(68, 20);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(54, 20);
		ckbLove.TabIndex = 1;
		ckbLove.Text = "Love";
		ckbLove.UseVisualStyleBackColor = true;

		ckbCare.AutoSize = true;
		ckbCare.Location = new System.Drawing.Point(128, 20);
		ckbCare.Name = "ckbCare";
		ckbCare.Size = new System.Drawing.Size(53, 20);
		ckbCare.TabIndex = 2;
		ckbCare.Text = "Care";
		ckbCare.UseVisualStyleBackColor = true;

		ckbHaha.AutoSize = true;
		ckbHaha.Location = new System.Drawing.Point(187, 20);
		ckbHaha.Name = "ckbHaha";
		ckbHaha.Size = new System.Drawing.Size(55, 20);
		ckbHaha.TabIndex = 3;
		ckbHaha.Text = "Haha";
		ckbHaha.UseVisualStyleBackColor = true;

		ckbWow.AutoSize = true;
		ckbWow.Location = new System.Drawing.Point(248, 20);
		ckbWow.Name = "ckbWow";
		ckbWow.Size = new System.Drawing.Size(55, 20);
		ckbWow.TabIndex = 4;
		ckbWow.Text = "Wow";
		ckbWow.UseVisualStyleBackColor = true;

		ckbSad.AutoSize = true;
		ckbSad.Location = new System.Drawing.Point(309, 20);
		ckbSad.Name = "ckbSad";
		ckbSad.Size = new System.Drawing.Size(48, 20);
		ckbSad.TabIndex = 5;
		ckbSad.Text = "Sad";
		ckbSad.UseVisualStyleBackColor = true;

		ckbAngry.AutoSize = true;
		ckbAngry.Location = new System.Drawing.Point(363, 20);
		ckbAngry.Name = "ckbAngry";
		ckbAngry.Size = new System.Drawing.Size(60, 20);
		ckbAngry.TabIndex = 6;
		ckbAngry.Text = "Angry";
		ckbAngry.UseVisualStyleBackColor = true;

		// Comment
		ckbComment.AutoSize = true;
		ckbComment.Location = new System.Drawing.Point(12, 45);
		ckbComment.Name = "ckbComment";
		ckbComment.Size = new System.Drawing.Size(252, 20);
		ckbComment.TabIndex = 7;
		ckbComment.Text = "Bình luận (1 dòng/comment, random):";
		ckbComment.UseVisualStyleBackColor = true;

		rtbComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		rtbComment.Location = new System.Drawing.Point(12, 67);
		rtbComment.Name = "rtbComment";
		rtbComment.Size = new System.Drawing.Size(425, 45);
		rtbComment.TabIndex = 8;
		rtbComment.Text = "";

		// Share
		ckbShare.AutoSize = true;
		ckbShare.Location = new System.Drawing.Point(12, 120);
		ckbShare.Name = "ckbShare";
		ckbShare.Size = new System.Drawing.Size(73, 20);
		ckbShare.TabIndex = 9;
		ckbShare.Text = "Chia sẻ";
		ckbShare.UseVisualStyleBackColor = true;

		rbShareWall.AutoSize = true;
		rbShareWall.Checked = true;
		rbShareWall.Location = new System.Drawing.Point(92, 119);
		rbShareWall.Name = "rbShareWall";
		rbShareWall.Size = new System.Drawing.Size(126, 20);
		rbShareWall.TabIndex = 10;
		rbShareWall.TabStop = true;
		rbShareWall.Text = "Chia sẻ lên Tường";
		rbShareWall.UseVisualStyleBackColor = true;

		rbShareStory.AutoSize = true;
		rbShareStory.Location = new System.Drawing.Point(230, 119);
		rbShareStory.Name = "rbShareStory";
		rbShareStory.Size = new System.Drawing.Size(121, 20);
		rbShareStory.TabIndex = 11;
		rbShareStory.Text = "Chia sẻ lên Story";
		rbShareStory.UseVisualStyleBackColor = true;

		// Send Img
		ckbSendImg.AutoSize = true;
		ckbSendImg.Location = new System.Drawing.Point(12, 149);
		ckbSendImg.Name = "ckbSendImg";
		ckbSendImg.Size = new System.Drawing.Size(183, 20);
		ckbSendImg.TabIndex = 12;
		ckbSendImg.Text = "Đính kèm ảnh vào bình luận";
		ckbSendImg.UseVisualStyleBackColor = true;

		txtImgFolder.Location = new System.Drawing.Point(201, 147);
		txtImgFolder.Name = "txtImgFolder";
		txtImgFolder.Size = new System.Drawing.Size(175, 23);
		txtImgFolder.TabIndex = 13;

		btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnChonAnh.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnChonAnh.Location = new System.Drawing.Point(382, 146);
		btnChonAnh.Name = "btnChonAnh";
		btnChonAnh.Size = new System.Drawing.Size(55, 25);
		btnChonAnh.TabIndex = 14;
		btnChonAnh.Text = "Chọn";
		btnChonAnh.UseVisualStyleBackColor = true;
		btnChonAnh.Click += new System.EventHandler(btnChonAnh_Click);

		// grbDelay (Nhóm 6: Cài đặt Delay)
		grbDelay.Controls.Add(lblDelayPost);
		grbDelay.Controls.Add(nudDelayFrom);
		grbDelay.Controls.Add(lblDelayTo);
		grbDelay.Controls.Add(nudDelayTo);
		grbDelay.Controls.Add(lblDelayAction);
		grbDelay.Controls.Add(nudDelayActionFrom);
		grbDelay.Controls.Add(lblDelayActionTo);
		grbDelay.Controls.Add(nudDelayActionTo);
		grbDelay.Controls.Add(lblDelayActionUnit);
		grbDelay.Controls.Add(ckbUuTienMbasic);
		grbDelay.Location = new System.Drawing.Point(12, 582);
		grbDelay.Name = "grbDelay";
		grbDelay.Size = new System.Drawing.Size(450, 95);
		grbDelay.TabIndex = 6;
		grbDelay.TabStop = false;
		grbDelay.Text = "Cài đặt Delay";

		lblDelayPost.AutoSize = true;
		lblDelayPost.Location = new System.Drawing.Point(10, 22);
		lblDelayPost.Name = "lblDelayPost";
		lblDelayPost.Size = new System.Drawing.Size(155, 16);
		lblDelayPost.TabIndex = 0;
		lblDelayPost.Text = "Delay giữa các bài (giây):";

		nudDelayFrom.Location = new System.Drawing.Point(170, 20);
		nudDelayFrom.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
		nudDelayFrom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(45, 23);
		nudDelayFrom.TabIndex = 1;
		nudDelayFrom.Value = new decimal(new int[] { 3, 0, 0, 0 });

		lblDelayTo.AutoSize = true;
		lblDelayTo.Location = new System.Drawing.Point(220, 22);
		lblDelayTo.Name = "lblDelayTo";
		lblDelayTo.Size = new System.Drawing.Size(28, 16);
		lblDelayTo.TabIndex = 2;
		lblDelayTo.Text = "đến";

		nudDelayTo.Location = new System.Drawing.Point(252, 20);
		nudDelayTo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
		nudDelayTo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(45, 23);
		nudDelayTo.TabIndex = 3;
		nudDelayTo.Value = new decimal(new int[] { 6, 0, 0, 0 });

		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Location = new System.Drawing.Point(315, 21);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(126, 20);
		ckbUuTienMbasic.TabIndex = 4;
		ckbUuTienMbasic.Text = "Ưu tiên mobile";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;

		lblDelayAction.AutoSize = true;
		lblDelayAction.Location = new System.Drawing.Point(10, 56);
		lblDelayAction.Name = "lblDelayAction";
		lblDelayAction.Size = new System.Drawing.Size(211, 16);
		lblDelayAction.TabIndex = 5;
		lblDelayAction.Text = "Delay giữa các loại tương tác (giây):";

		nudDelayActionFrom.Location = new System.Drawing.Point(225, 54);
		nudDelayActionFrom.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
		nudDelayActionFrom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayActionFrom.Name = "nudDelayActionFrom";
		nudDelayActionFrom.Size = new System.Drawing.Size(45, 23);
		nudDelayActionFrom.TabIndex = 6;
		nudDelayActionFrom.Value = new decimal(new int[] { 1, 0, 0, 0 });

		lblDelayActionTo.AutoSize = true;
		lblDelayActionTo.Location = new System.Drawing.Point(275, 56);
		lblDelayActionTo.Name = "lblDelayActionTo";
		lblDelayActionTo.Size = new System.Drawing.Size(28, 16);
		lblDelayActionTo.TabIndex = 7;
		lblDelayActionTo.Text = "đến";

		nudDelayActionTo.Location = new System.Drawing.Point(308, 54);
		nudDelayActionTo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
		nudDelayActionTo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayActionTo.Name = "nudDelayActionTo";
		nudDelayActionTo.Size = new System.Drawing.Size(45, 23);
		nudDelayActionTo.TabIndex = 8;
		nudDelayActionTo.Value = new decimal(new int[] { 2, 0, 0, 0 });

		lblDelayActionUnit.AutoSize = true;
		lblDelayActionUnit.Location = new System.Drawing.Point(358, 56);
		lblDelayActionUnit.Name = "lblDelayActionUnit";
		lblDelayActionUnit.Size = new System.Drawing.Size(30, 16);
		lblDelayActionUnit.TabIndex = 9;
		lblDelayActionUnit.Text = "giây";

		// Form fHDTangTuongTac
		AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		ClientSize = new System.Drawing.Size(500, 620);
		Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		Name = "fHDTangTuongTac";
		StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình Tăng tương tác";
		Load += new System.EventHandler(fHDTangTuongTac_Load);

		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		FE88CD9F.ResumeLayout(false);
		panel1.ResumeLayout(false);
		pnlBody.ResumeLayout(false);
		pnlBody.PerformLayout();
		pnlBottom.ResumeLayout(false);
		grbPages.ResumeLayout(false);
		grbPages.PerformLayout();
		grbFollow.ResumeLayout(false);
		grbFollow.PerformLayout();
		grbPost.ResumeLayout(false);
		grbPost.PerformLayout();
		grbReaction.ResumeLayout(false);
		grbReaction.PerformLayout();
		grbDelay.ResumeLayout(false);
		grbDelay.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayActionFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayActionTo).EndInit();
		ResumeLayout(false);
	}
}
