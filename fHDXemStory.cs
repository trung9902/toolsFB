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

public class fHDXemStory : Form
{
	internal GClass4 D006E632;

	internal string DBA9ADA5;

	internal string CB3D3728;

	internal string string_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal List<CheckBox> list_0;

	internal IContainer F234EC35 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl E90BBB89;

	internal Panel panel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown B825F3B8;

	internal NumericUpDown nudDelayFrom;

	internal NumericUpDown CB253109;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label A6A7BC83;

	internal Label BE961B18;

	internal Button E6BD081C;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel FC148ABB;

	internal Button A79BEC39;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plComment;

	internal CheckBox ckbComment;

	internal CheckBox C6BEDE8D;

	internal RichTextBox txtComment;

	internal Label FB31C288;

	internal Panel CD077CBD;

	internal Panel panel7;

	internal RadioButton radioButton3;

	internal RadioButton E59DA7A7;

	internal Label label26;

	internal CheckBox ckbAngry;

	internal CheckBox F9B70715;

	internal CheckBox EA89CCBB;

	internal CheckBox B79E038A;

	internal CheckBox ckbCare;

	internal CheckBox ckbLove;

	internal CheckBox ckbLike;

	internal Label label2;

	internal Label label9;

	public static bool A990FE1D
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

	public fHDXemStory(string CEB99F3A, string string_1 = "")
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		A990FE1D = false;
		DBA9ADA5 = CEB99F3A;
		string_0 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			CB3D3728 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		D006E632 = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
		list_0 = new List<CheckBox> { ckbLike, ckbLove, ckbCare, B79E038A, EA89CCBB, F9B70715, ckbAngry };
	}

	private void fHDXemStory_Load(object sender, EventArgs e)
	{
		try
		{
			CB253109.Value = D006E632.method_2("nudSoLuongFrom", 1);
			B825F3B8.Value = D006E632.method_2("nudSoLuongTo", 3);
			nudDelayFrom.Value = D006E632.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = D006E632.method_2("nudDelayTo", 5);
			C6BEDE8D.Checked = D006E632.method_3("ckbInteract");
			string text = D006E632.BDB80B23("typeReaction", "Like");
			if (Commom.smethod_45(text.Replace("|", "")))
			{
				if (!text.Contains("|"))
				{
					text = string.Join("|", text.ToArray());
				}
				List<string> list = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
				for (int i = 0; i < list.Count; i++)
				{
					text = text.Replace(i.ToString(), list[i]);
				}
			}
			List<string> list2 = text.Split('|').ToList();
			for (int j = 0; j < list2.Count; j++)
			{
				foreach (CheckBox item in list_0)
				{
					if (item.Name.Substring(3) == list2[j])
					{
						item.Checked = true;
					}
				}
			}
			ckbComment.Checked = D006E632.method_3("ckbComment");
			txtComment.Text = D006E632.BDB80B23("txtComment");
		}
		catch
		{
		}
		F1A960B0();
	}

	private void A79BEC39_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (ckbComment.Checked)
		{
			List<string> list = txtComment.Lines.ToList();
			list = Commom.smethod_36(list);
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!", 3);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", CB253109.Value);
		gClass.method_4("nudSoLuongTo", B825F3B8.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbInteract", C6BEDE8D.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + list_0[i].Name.Substring(3) + "|";
			}
		}
		gClass.method_4("typeReaction", text2.TrimEnd('|'));
		gClass.method_4("ckbComment", ckbComment.Checked);
		gClass.method_4("txtComment", txtComment.Text.Trim());
		string text3 = gClass.ED11179C();
		if (string_0 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(DBA9ADA5, text, CB3D3728, text3))
				{
					A990FE1D = true;
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
			if (Class154.smethod_13(string_0, text, text3))
			{
				A990FE1D = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A63C1C0B(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void F1A960B0()
	{
		AA8FA61F(null, null);
		ckbComment_CheckedChanged(null, null);
	}

	private void AA8FA61F(object sender, EventArgs e)
	{
		CD077CBD.Enabled = C6BEDE8D.Checked;
	}

	private void ckbComment_CheckedChanged(object sender, EventArgs e)
	{
		plComment.Enabled = ckbComment.Checked;
	}

	private void txtComment_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, FB31C288);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F234EC35 != null)
		{
			F234EC35.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F234EC35 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDXemStory));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F234EC35);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		E90BBB89 = new Bunifu.Framework.UI.BunifuDragControl(F234EC35);
		FC148ABB = new System.Windows.Forms.Panel();
		A79BEC39 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		CD077CBD = new System.Windows.Forms.Panel();
		ckbAngry = new System.Windows.Forms.CheckBox();
		F9B70715 = new System.Windows.Forms.CheckBox();
		EA89CCBB = new System.Windows.Forms.CheckBox();
		B79E038A = new System.Windows.Forms.CheckBox();
		ckbCare = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		ckbLike = new System.Windows.Forms.CheckBox();
		panel7 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		E59DA7A7 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		plComment = new System.Windows.Forms.Panel();
		txtComment = new System.Windows.Forms.RichTextBox();
		FB31C288 = new System.Windows.Forms.Label();
		ckbComment = new System.Windows.Forms.CheckBox();
		C6BEDE8D = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		B825F3B8 = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		CB253109 = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		A6A7BC83 = new System.Windows.Forms.Label();
		BE961B18 = new System.Windows.Forms.Label();
		E6BD081C = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		FC148ABB.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		CD077CBD.SuspendLayout();
		panel7.SuspendLayout();
		plComment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)B825F3B8).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)CB253109).BeginInit();
		bunifuCards1.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(391, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Xem Story";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E90BBB89.Fixed = true;
		E90BBB89.Horizontal = true;
		E90BBB89.TargetControl = FC148ABB;
		E90BBB89.Vertical = true;
		FC148ABB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FC148ABB.BackColor = System.Drawing.Color.White;
		FC148ABB.Controls.Add(A79BEC39);
		FC148ABB.Controls.Add(pictureBox1);
		FC148ABB.Controls.Add(bunifuCustomLabel1);
		FC148ABB.Cursor = System.Windows.Forms.Cursors.SizeAll;
		FC148ABB.Location = new System.Drawing.Point(0, 3);
		FC148ABB.Name = "pnlHeader";
		FC148ABB.Size = new System.Drawing.Size(391, 31);
		FC148ABB.TabIndex = 9;
		A79BEC39.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A79BEC39.Cursor = System.Windows.Forms.Cursors.Hand;
		A79BEC39.FlatAppearance.BorderSize = 0;
		A79BEC39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A79BEC39.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A79BEC39.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(FC148ABB.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		FC148ABB.Controls.Add(btnMinimize);
		FC148ABB.Resize += (s, e) =>
		{
			if (A79BEC39 != null) A79BEC39.Location = new System.Drawing.Point(FC148ABB.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(FC148ABB.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		A79BEC39.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		A79BEC39.Text = iconClose == null ? "✕" : "";
		A79BEC39.Location = new System.Drawing.Point(360, 1);
		A79BEC39.Name = "button1";
		A79BEC39.Size = new System.Drawing.Size(30, 30);
		A79BEC39.TabIndex = 77;
		A79BEC39.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A79BEC39.UseVisualStyleBackColor = true;
		A79BEC39.Click += new System.EventHandler(A79BEC39_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(label2);
		panel1.Controls.Add(CD077CBD);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(plComment);
		panel1.Controls.Add(ckbComment);
		panel1.Controls.Add(C6BEDE8D);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(B825F3B8);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(CB253109);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(A6A7BC83);
		panel1.Controls.Add(BE961B18);
		panel1.Controls.Add(E6BD081C);
		panel1.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(394, 438);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		CD077CBD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		CD077CBD.Controls.Add(ckbAngry);
		CD077CBD.Controls.Add(F9B70715);
		CD077CBD.Controls.Add(EA89CCBB);
		CD077CBD.Controls.Add(B79E038A);
		CD077CBD.Controls.Add(ckbCare);
		CD077CBD.Controls.Add(ckbLove);
		CD077CBD.Controls.Add(ckbLike);
		CD077CBD.Controls.Add(panel7);
		CD077CBD.Controls.Add(label26);
		CD077CBD.Location = new System.Drawing.Point(48, 157);
		CD077CBD.Name = "plInteract";
		CD077CBD.Size = new System.Drawing.Size(310, 33);
		CD077CBD.TabIndex = 180;
		ckbAngry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbAngry.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAngry.Image = Class155.Bitmap_11;
		ckbAngry.Location = new System.Drawing.Point(266, 0);
		ckbAngry.Name = "ckbAngry";
		ckbAngry.Size = new System.Drawing.Size(40, 30);
		ckbAngry.TabIndex = 186;
		ckbAngry.Tag = "Angry";
		ckbAngry.UseVisualStyleBackColor = true;
		F9B70715.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F9B70715.Cursor = System.Windows.Forms.Cursors.Hand;
		F9B70715.Image = Class155.E1938320;
		F9B70715.Location = new System.Drawing.Point(222, 0);
		F9B70715.Name = "ckbSad";
		F9B70715.Size = new System.Drawing.Size(40, 30);
		F9B70715.TabIndex = 185;
		F9B70715.Tag = "Sad";
		F9B70715.UseVisualStyleBackColor = true;
		EA89CCBB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		EA89CCBB.Cursor = System.Windows.Forms.Cursors.Hand;
		EA89CCBB.Image = Class155.Bitmap_181;
		EA89CCBB.Location = new System.Drawing.Point(178, 0);
		EA89CCBB.Name = "ckbWow";
		EA89CCBB.Size = new System.Drawing.Size(40, 30);
		EA89CCBB.TabIndex = 184;
		EA89CCBB.Tag = "Wow";
		EA89CCBB.UseVisualStyleBackColor = true;
		B79E038A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B79E038A.Cursor = System.Windows.Forms.Cursors.Hand;
		B79E038A.Image = Class155.E982D419;
		B79E038A.Location = new System.Drawing.Point(134, 0);
		B79E038A.Name = "ckbHaha";
		B79E038A.Size = new System.Drawing.Size(40, 30);
		B79E038A.TabIndex = 183;
		B79E038A.Tag = "Haha";
		B79E038A.UseVisualStyleBackColor = true;
		ckbCare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbCare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCare.Image = Class155.Bitmap_20;
		ckbCare.Location = new System.Drawing.Point(90, 0);
		ckbCare.Name = "ckbCare";
		ckbCare.Size = new System.Drawing.Size(40, 30);
		ckbCare.TabIndex = 182;
		ckbCare.Tag = "Care";
		ckbCare.UseVisualStyleBackColor = true;
		ckbLove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbLove.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLove.Image = Class155.AB95A212;
		ckbLove.Location = new System.Drawing.Point(46, 0);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(40, 30);
		ckbLove.TabIndex = 181;
		ckbLove.Tag = "Love";
		ckbLove.UseVisualStyleBackColor = true;
		ckbLike.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLike.Image = Class155.Bitmap_166;
		ckbLike.Location = new System.Drawing.Point(2, 0);
		ckbLike.Name = "ckbLike";
		ckbLike.Size = new System.Drawing.Size(40, 30);
		ckbLike.TabIndex = 180;
		ckbLike.Tag = "Like";
		ckbLike.UseVisualStyleBackColor = true;
		panel7.Controls.Add(radioButton3);
		panel7.Controls.Add(E59DA7A7);
		panel7.Location = new System.Drawing.Point(67, 300);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(200, 43);
		panel7.TabIndex = 43;
		radioButton3.AutoSize = true;
		radioButton3.Checked = true;
		radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton3.Location = new System.Drawing.Point(3, 2);
		radioButton3.Name = "radioButton3";
		radioButton3.Size = new System.Drawing.Size(201, 20);
		radioButton3.TabIndex = 3;
		radioButton3.TabStop = true;
		radioButton3.Text = "Comment theo thứ tự nội dung";
		radioButton3.UseVisualStyleBackColor = true;
		E59DA7A7.AutoSize = true;
		E59DA7A7.Cursor = System.Windows.Forms.Cursors.Hand;
		E59DA7A7.Location = new System.Drawing.Point(3, 23);
		E59DA7A7.Name = "radioButton4";
		E59DA7A7.Size = new System.Drawing.Size(200, 20);
		E59DA7A7.TabIndex = 3;
		E59DA7A7.Text = "Comment ngẫu nhiên nội dung";
		E59DA7A7.UseVisualStyleBackColor = true;
		label26.AutoSize = true;
		label26.Location = new System.Drawing.Point(4, 302);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(64, 16);
		label26.TabIndex = 2;
		label26.Text = "Tùy chọn:";
		plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plComment.Controls.Add(txtComment);
		plComment.Controls.Add(FB31C288);
		plComment.Location = new System.Drawing.Point(48, 217);
		plComment.Name = "plComment";
		plComment.Size = new System.Drawing.Size(310, 164);
		plComment.TabIndex = 8;
		txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtComment.Location = new System.Drawing.Point(5, 24);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(298, 135);
		txtComment.TabIndex = 3;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
		FB31C288.AutoSize = true;
		FB31C288.Location = new System.Drawing.Point(1, 4);
		FB31C288.Name = "lblComment";
		FB31C288.Size = new System.Drawing.Size(139, 16);
		FB31C288.TabIndex = 2;
		FB31C288.Text = "Nội dung bình luận (0):";
		ckbComment.AutoSize = true;
		ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbComment.Location = new System.Drawing.Point(30, 195);
		ckbComment.Name = "ckbComment";
		ckbComment.Size = new System.Drawing.Size(127, 20);
		ckbComment.TabIndex = 7;
		ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
		ckbComment.UseVisualStyleBackColor = true;
		ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
		C6BEDE8D.AutoSize = true;
		C6BEDE8D.Cursor = System.Windows.Forms.Cursors.Hand;
		C6BEDE8D.Location = new System.Drawing.Point(30, 135);
		C6BEDE8D.Name = "ckbInteract";
		C6BEDE8D.Size = new System.Drawing.Size(112, 20);
		C6BEDE8D.TabIndex = 5;
		C6BEDE8D.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
		C6BEDE8D.UseVisualStyleBackColor = true;
		C6BEDE8D.CheckedChanged += new System.EventHandler(AA8FA61F);
		nudDelayTo.Location = new System.Drawing.Point(229, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		B825F3B8.Location = new System.Drawing.Point(229, 78);
		B825F3B8.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B825F3B8.Name = "nudSoLuongTo";
		B825F3B8.Size = new System.Drawing.Size(56, 23);
		B825F3B8.TabIndex = 2;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		CB253109.Location = new System.Drawing.Point(132, 78);
		CB253109.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CB253109.Name = "nudSoLuongFrom";
		CB253109.Size = new System.Drawing.Size(56, 23);
		CB253109.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(194, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A6A7BC83.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A6A7BC83.Location = new System.Drawing.Point(194, 80);
		A6A7BC83.Name = "label3";
		A6A7BC83.Size = new System.Drawing.Size(29, 16);
		A6A7BC83.TabIndex = 37;
		A6A7BC83.Text = ">";
		A6A7BC83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BE961B18.AutoSize = true;
		BE961B18.Location = new System.Drawing.Point(27, 52);
		BE961B18.Name = "label1";
		BE961B18.Size = new System.Drawing.Size(98, 16);
		BE961B18.TabIndex = 31;
		BE961B18.Text = "Tên ha\u0300nh đô\u0323ng:";
		E6BD081C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E6BD081C.BackColor = System.Drawing.Color.Maroon;
		E6BD081C.Cursor = System.Windows.Forms.Cursors.Hand;
		E6BD081C.FlatAppearance.BorderSize = 0;
		E6BD081C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E6BD081C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E6BD081C.ForeColor = System.Drawing.Color.White;
		E6BD081C.Location = new System.Drawing.Point(207, 396);
		E6BD081C.Name = "btnCancel";
		E6BD081C.Size = new System.Drawing.Size(92, 29);
		E6BD081C.TabIndex = 10;
		E6BD081C.Text = "Đóng";
		E6BD081C.UseVisualStyleBackColor = false;
		E6BD081C.Click += new System.EventHandler(A63C1C0B);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(100, 396);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(FC148ABB);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(391, 37);
		bunifuCards1.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 187;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 188;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(394, 438);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDXemStory";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDXemStory_Load);
		FC148ABB.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		CD077CBD.ResumeLayout(false);
		CD077CBD.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		plComment.ResumeLayout(false);
		plComment.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)B825F3B8).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)CB253109).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
