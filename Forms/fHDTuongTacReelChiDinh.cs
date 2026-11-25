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

public class fHDTuongTacReelChiDinh : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string D7025E8F;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal List<CheckBox> list_0;

	internal IContainer F103B19E = null;

	internal BunifuDragControl D49EAFB7;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel panel1;

	internal NumericUpDown EF374299;

	internal NumericUpDown F3A4E316;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label label5;

	internal Label D137DABC;

	internal Button C138D025;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel B819CFA7;

	internal CheckBox ckbShareWall;

	internal Label label2;

	internal NumericUpDown nudTimeTo;

	internal NumericUpDown nudTimeFrom;

	internal Label label9;

	internal Label FF24FA35;

	internal Panel plCommentText;

	internal RichTextBox BFA7461B;

	internal Label lblComment;

	internal Panel plAnh;

	internal TextBox txtAnh;

	internal RichTextBox txtIdPost;

	internal CheckBox ckbSendAnh;

	internal CheckBox AD95788B;

	internal Label D18F25AB;

	internal Label label49;

	internal NumericUpDown D534FBAD;

	internal NumericUpDown A8020EB4;

	internal Label label66;

	internal CheckBox ckbAutoDeleteComment;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button DB09452A;

	internal Label label8;

	internal CheckBox ckbTuDongXoa;

	internal Panel panel2;

	internal CheckBox ckbInteract;

	internal Panel C6899AAB;

	internal ComboBox cbbTuyChonNoiDungShare;

	internal Button C88128B9;

	internal Label label15;

	internal CheckBox ckbAutoDeleteContentShare;

	internal RichTextBox txtContentShare;

	internal Label lblContentShare;

	internal CheckBox ckbTaoNoiDungAI;

	internal Panel plInteract;

	internal CheckBox DE86C58E;

	internal CheckBox DE2EAA06;

	internal CheckBox ckbWow;

	internal CheckBox F82B8EAE;

	internal CheckBox ckbCare;

	internal CheckBox ckbLove;

	internal CheckBox F330B912;

	internal Panel FA3400BB;

	internal RadioButton radioButton3;

	internal RadioButton radioButton4;

	internal Label B5130925;

	public static bool D695E29B
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

	public fHDTuongTacReelChiDinh(string B6254D18, string string_2 = "")
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
		D695E29B = false;
		string_0 = B6254D18;
		D7025E8F = string_2;
		string aA239C = Language.GetValue(B819CFA7.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
		list_0 = new List<CheckBox> { F330B912, ckbLove, ckbCare, F82B8EAE, ckbWow, DE2EAA06, DE86C58E };
	}

	private void AB24358B(object sender, EventArgs e)
	{
		E49A83B7();
		method_0();
		try
		{
			D534FBAD.Value = gclass4_0.method_2("nudSoLuongUidFrom", 1);
			A8020EB4.Value = gclass4_0.method_2("nudSoLuongUidTo", 1);
			F3A4E316.Value = gclass4_0.method_2("nudDelayFrom", 3);
			EF374299.Value = gclass4_0.method_2("nudDelayTo", 5);
			txtIdPost.Text = gclass4_0.BDB80B23("txtIdPost");
			ckbTuDongXoa.Checked = gclass4_0.method_3("ckbTuDongXoa");
			nudTimeFrom.Value = gclass4_0.method_2("nudTimeFrom", 3);
			nudTimeTo.Value = gclass4_0.method_2("nudTimeTo", 5);
			ckbInteract.Checked = gclass4_0.method_3("ckbInteract");
			string text = gclass4_0.BDB80B23("typeReaction", "Like");
			if (Commom.smethod_45(text.Replace("|", "")))
			{
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
			AD95788B.Checked = gclass4_0.method_3("ckbComment");
			ckbTaoNoiDungAI.Checked = gclass4_0.method_3("ckbTaoNoiDungAI");
			BFA7461B.Text = gclass4_0.BDB80B23("txtComment");
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbAutoDeleteComment.Checked = gclass4_0.method_3("ckbAutoDeleteComment");
			ckbSendAnh.Checked = gclass4_0.method_3("ckbSendAnh");
			txtAnh.Text = gclass4_0.BDB80B23("txtAnh");
			Commom.AttachFolderPicker(txtAnh);
			ckbShareWall.Checked = gclass4_0.method_3("ckbShareWall");
			txtContentShare.Text = gclass4_0.BDB80B23("txtContentShare");
			cbbTuyChonNoiDungShare.SelectedIndex = gclass4_0.method_2("cbbTuyChonNoiDungShare");
			ckbAutoDeleteContentShare.Checked = gclass4_0.method_3("ckbAutoDeleteContentShare");
		}
		catch
		{
		}
		method_1();
	}

	private void E49A83B7()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list);
	}

	private void method_0()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDungShare, list);
	}

	private void C8945728(object sender, EventArgs e)
	{
		Close();
	}

	private void B1289293(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		gclass4_0.method_4("nudSoLuongUidFrom", D534FBAD.Value);
		gclass4_0.method_4("nudSoLuongUidTo", A8020EB4.Value);
		gclass4_0.method_4("nudDelayFrom", F3A4E316.Value);
		gclass4_0.method_4("nudDelayTo", EF374299.Value);
		gclass4_0.method_4("txtIdPost", txtIdPost.Text.Trim());
		gclass4_0.method_4("ckbTuDongXoa", ckbTuDongXoa.Checked);
		gclass4_0.method_4("nudTimeFrom", nudTimeFrom.Value);
		gclass4_0.method_4("nudTimeTo", nudTimeTo.Value);
		gclass4_0.method_4("ckbInteract", ckbInteract.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + list_0[i].Name.Substring(3) + "|";
			}
		}
		gclass4_0.method_4("typeReaction", text2.TrimEnd('|'));
		gclass4_0.method_4("ckbComment", AD95788B.Checked);
		gclass4_0.method_4("ckbTaoNoiDungAI", ckbTaoNoiDungAI.Checked);
		gclass4_0.method_4("txtComment", BFA7461B.Text.Trim());
		gclass4_0.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		gclass4_0.method_4("ckbAutoDeleteComment", ckbAutoDeleteComment.Checked);
		gclass4_0.method_4("ckbSendAnh", ckbSendAnh.Checked);
		gclass4_0.method_4("txtAnh", txtAnh.Text.Trim());
		gclass4_0.method_4("ckbShareWall", ckbShareWall.Checked);
		gclass4_0.method_4("txtContentShare", txtContentShare.Text.Trim());
		gclass4_0.method_4("cbbTuyChonNoiDungShare", cbbTuyChonNoiDungShare.SelectedIndex);
		gclass4_0.method_4("ckbAutoDeleteContentShare", ckbAutoDeleteContentShare.Checked);
		string e013A = gclass4_0.ED11179C();
		if (D7025E8F == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					D695E29B = true;
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
			if (Class154.smethod_13(D7025E8F, text, e013A))
			{
				D695E29B = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void F28D579F(object sender, EventArgs e)
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

	private void BFA7461B_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(BFA7461B, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void method_1()
	{
		E71B7D11(null, null);
		AD95788B_CheckedChanged(null, null);
		ckbSendAnh_CheckedChanged(null, null);
		method_5(null, null);
		BFA7461B_TextChanged(null, null);
		ckbShareWall_CheckedChanged(null, null);
		ckbTaoNoiDungAI_CheckedChanged(null, null);
	}

	private void E71B7D11(object sender, EventArgs e)
	{
		plInteract.Enabled = ckbInteract.Checked;
	}

	private void AD95788B_CheckedChanged(object sender, EventArgs e)
	{
		plCommentText.Enabled = AD95788B.Checked && !ckbTaoNoiDungAI.Checked;
		ckbTaoNoiDungAI.Enabled = AD95788B.Checked;
	}

	private void txtIdPost_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdPost, label2);
	}

	private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbSendAnh.Checked;
	}

	private void FBAA4B0F(object sender, EventArgs e)
	{
	}

	private void DD836EAE(object sender, EventArgs e)
	{
	}

	private void D18F25AB_Click(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void method_4(object sender, EventArgs e)
	{
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(BFA7461B, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void D28C7139(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		BFA7461B.Focus();
	}

	private void C88128B9_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDungShare.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtContentShare.Focus();
	}

	private void txtContentShare_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShare, lblContentShare, cbbTuyChonNoiDungShare.SelectedIndex);
	}

	private void ckbShareWall_CheckedChanged(object sender, EventArgs e)
	{
		C6899AAB.Enabled = ckbShareWall.Checked;
	}

	private void cbbTuyChonNoiDungShare_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShare, lblContentShare, cbbTuyChonNoiDungShare.SelectedIndex);
	}

	private void plCommentText_Paint(object sender, PaintEventArgs e)
	{
	}

	private void ckbTaoNoiDungAI_CheckedChanged(object sender, EventArgs e)
	{
		plCommentText.Enabled = AD95788B.Checked && !ckbTaoNoiDungAI.Checked;
	}

	private void ckbTaoNoiDungAI_Click(object sender, EventArgs e)
	{
		if (ckbTaoNoiDungAI.Checked)
		{
			Commom.smethod_35(new fChonPrompt(gclass4_0));
		}
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F103B19E != null)
		{
			F103B19E.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F103B19E = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTuongTacReelChiDinh));
		D49EAFB7 = new Bunifu.Framework.UI.BunifuDragControl(F103B19E);
		B819CFA7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F103B19E);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		ckbTaoNoiDungAI = new System.Windows.Forms.CheckBox();
		plCommentText = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		DB09452A = new System.Windows.Forms.Button();
		label8 = new System.Windows.Forms.Label();
		ckbAutoDeleteComment = new System.Windows.Forms.CheckBox();
		BFA7461B = new System.Windows.Forms.RichTextBox();
		lblComment = new System.Windows.Forms.Label();
		ckbInteract = new System.Windows.Forms.CheckBox();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		panel2 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		txtIdPost = new System.Windows.Forms.RichTextBox();
		ckbTuDongXoa = new System.Windows.Forms.CheckBox();
		plAnh = new System.Windows.Forms.Panel();
		txtAnh = new System.Windows.Forms.TextBox();
		D18F25AB = new System.Windows.Forms.Label();
		label49 = new System.Windows.Forms.Label();
		D534FBAD = new System.Windows.Forms.NumericUpDown();
		A8020EB4 = new System.Windows.Forms.NumericUpDown();
		label66 = new System.Windows.Forms.Label();
		AD95788B = new System.Windows.Forms.CheckBox();
		nudTimeTo = new System.Windows.Forms.NumericUpDown();
		EF374299 = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		F3A4E316 = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		FF24FA35 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		D137DABC = new System.Windows.Forms.Label();
		C138D025 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		C6899AAB = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDungShare = new System.Windows.Forms.ComboBox();
		C88128B9 = new System.Windows.Forms.Button();
		label15 = new System.Windows.Forms.Label();
		ckbAutoDeleteContentShare = new System.Windows.Forms.CheckBox();
		txtContentShare = new System.Windows.Forms.RichTextBox();
		lblContentShare = new System.Windows.Forms.Label();
		ckbShareWall = new System.Windows.Forms.CheckBox();
		B5130925 = new System.Windows.Forms.Label();
		FA3400BB = new System.Windows.Forms.Panel();
		radioButton4 = new System.Windows.Forms.RadioButton();
		radioButton3 = new System.Windows.Forms.RadioButton();
		F330B912 = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		ckbCare = new System.Windows.Forms.CheckBox();
		F82B8EAE = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		DE2EAA06 = new System.Windows.Forms.CheckBox();
		DE86C58E = new System.Windows.Forms.CheckBox();
		plInteract = new System.Windows.Forms.Panel();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plCommentText.SuspendLayout();
		panel2.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D534FBAD).BeginInit();
		((System.ComponentModel.ISupportInitialize)A8020EB4).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)EF374299).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)F3A4E316).BeginInit();
		bunifuCards1.SuspendLayout();
		C6899AAB.SuspendLayout();
		FA3400BB.SuspendLayout();
		plInteract.SuspendLayout();
		SuspendLayout();
		D49EAFB7.Fixed = true;
		D49EAFB7.Horizontal = true;
		D49EAFB7.TargetControl = B819CFA7;
		D49EAFB7.Vertical = true;
		B819CFA7.BackColor = System.Drawing.Color.Transparent;
		B819CFA7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B819CFA7.Dock = System.Windows.Forms.DockStyle.Fill;
		B819CFA7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B819CFA7.ForeColor = System.Drawing.Color.Black;
		B819CFA7.Location = new System.Drawing.Point(0, 0);
		B819CFA7.Name = "bunifuCustomLabel1";
		B819CFA7.Size = new System.Drawing.Size(1000, 31);
		B819CFA7.TabIndex = 12;
		B819CFA7.Text = "Cấu hình Tương ta\u0301c reel chi\u0309 đi\u0323nh";
		B819CFA7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = pnlHeader;
		bunifuDragControl_0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(B819CFA7);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1000, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(969, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(C8945728);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(DD836EAE);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(C6899AAB);
		panel1.Controls.Add(ckbTaoNoiDungAI);
		panel1.Controls.Add(plInteract);
		panel1.Controls.Add(plCommentText);
		panel1.Controls.Add(ckbInteract);
		panel1.Controls.Add(ckbSendAnh);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(plAnh);
		panel1.Controls.Add(label49);
		panel1.Controls.Add(D534FBAD);
		panel1.Controls.Add(A8020EB4);
		panel1.Controls.Add(label66);
		panel1.Controls.Add(AD95788B);
		panel1.Controls.Add(nudTimeTo);
		panel1.Controls.Add(EF374299);
		panel1.Controls.Add(nudTimeFrom);
		panel1.Controls.Add(F3A4E316);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(FF24FA35);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(D137DABC);
		panel1.Controls.Add(C138D025);
		panel1.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(ckbShareWall);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1003, 491);
		panel1.TabIndex = 0;
		panel1.Click += new System.EventHandler(FBAA4B0F);
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		ckbTaoNoiDungAI.AutoSize = true;
		ckbTaoNoiDungAI.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTaoNoiDungAI.Location = new System.Drawing.Point(823, 77);
		ckbTaoNoiDungAI.Name = "ckbTaoNoiDungAI";
		ckbTaoNoiDungAI.Size = new System.Drawing.Size(149, 20);
		ckbTaoNoiDungAI.TabIndex = 188;
		ckbTaoNoiDungAI.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		ckbTaoNoiDungAI.UseVisualStyleBackColor = true;
		ckbTaoNoiDungAI.CheckedChanged += new System.EventHandler(ckbTaoNoiDungAI_CheckedChanged);
		ckbTaoNoiDungAI.Click += new System.EventHandler(ckbTaoNoiDungAI_Click);
		plCommentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentText.Controls.Add(cbbTuyChonNoiDung);
		plCommentText.Controls.Add(DB09452A);
		plCommentText.Controls.Add(label8);
		plCommentText.Controls.Add(ckbAutoDeleteComment);
		plCommentText.Controls.Add(BFA7461B);
		plCommentText.Controls.Add(lblComment);
		plCommentText.Location = new System.Drawing.Point(661, 99);
		plCommentText.Name = "plCommentText";
		plCommentText.Size = new System.Drawing.Size(311, 276);
		plCommentText.TabIndex = 164;
		plCommentText.Paint += new System.Windows.Forms.PaintEventHandler(plCommentText_Paint);
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(69, 223);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(202, 24);
		cbbTuyChonNoiDung.TabIndex = 180;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		DB09452A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DB09452A.Cursor = System.Windows.Forms.Cursors.Hand;
		DB09452A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DB09452A.Location = new System.Drawing.Point(277, 222);
		DB09452A.Name = "btnHuongDanNhapNoiDung";
		DB09452A.Size = new System.Drawing.Size(26, 26);
		DB09452A.TabIndex = 179;
		DB09452A.Text = "?";
		DB09452A.UseVisualStyleBackColor = true;
		DB09452A.Click += new System.EventHandler(D28C7139);
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(3, 226);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 178;
		label8.Text = "Tùy chọn:";
		ckbAutoDeleteComment.AutoSize = true;
		ckbAutoDeleteComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoDeleteComment.Location = new System.Drawing.Point(6, 251);
		ckbAutoDeleteComment.Name = "ckbAutoDeleteComment";
		ckbAutoDeleteComment.Size = new System.Drawing.Size(169, 20);
		ckbAutoDeleteComment.TabIndex = 176;
		ckbAutoDeleteComment.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		ckbAutoDeleteComment.UseVisualStyleBackColor = true;
		BFA7461B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BFA7461B.Location = new System.Drawing.Point(6, 25);
		BFA7461B.Name = "txtComment";
		BFA7461B.Size = new System.Drawing.Size(297, 191);
		BFA7461B.TabIndex = 1;
		BFA7461B.Text = "";
		BFA7461B.WordWrap = false;
		BFA7461B.TextChanged += new System.EventHandler(BFA7461B_TextChanged);
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(2, 5);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(139, 16);
		lblComment.TabIndex = 0;
		lblComment.Text = "Nội dung bình luận (0):";
		ckbInteract.AutoSize = true;
		ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbInteract.Location = new System.Drawing.Point(317, 107);
		ckbInteract.Name = "ckbInteract";
		ckbInteract.Size = new System.Drawing.Size(48, 20);
		ckbInteract.TabIndex = 181;
		ckbInteract.Text = "Like";
		ckbInteract.UseVisualStyleBackColor = true;
		ckbInteract.CheckedChanged += new System.EventHandler(E71B7D11);
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(661, 381);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(103, 20);
		ckbSendAnh.TabIndex = 165;
		ckbSendAnh.Text = "Bi\u0300nh luâ\u0323n a\u0309nh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txtIdPost);
		panel2.Controls.Add(ckbTuDongXoa);
		panel2.Location = new System.Drawing.Point(30, 137);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(252, 297);
		panel2.TabIndex = 181;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 4);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(176, 16);
		label2.TabIndex = 40;
		label2.Text = "Nhâ\u0323p Id hoă\u0323c link ba\u0300i viê\u0301t (0):";
		txtIdPost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdPost.Location = new System.Drawing.Point(6, 24);
		txtIdPost.Name = "txtIdPost";
		txtIdPost.Size = new System.Drawing.Size(238, 244);
		txtIdPost.TabIndex = 1;
		txtIdPost.Text = "";
		txtIdPost.WordWrap = false;
		txtIdPost.TextChanged += new System.EventHandler(txtIdPost_TextChanged);
		ckbTuDongXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbTuDongXoa.AutoSize = true;
		ckbTuDongXoa.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoa.Location = new System.Drawing.Point(6, 272);
		ckbTuDongXoa.Name = "ckbTuDongXoa";
		ckbTuDongXoa.Size = new System.Drawing.Size(192, 20);
		ckbTuDongXoa.TabIndex = 176;
		ckbTuDongXoa.Text = "Xóa link ba\u0300i viê\u0301t đã tương tác";
		ckbTuDongXoa.UseVisualStyleBackColor = true;
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(txtAnh);
		plAnh.Controls.Add(D18F25AB);
		plAnh.Enabled = false;
		plAnh.Location = new System.Drawing.Point(661, 403);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(311, 31);
		plAnh.TabIndex = 166;
		txtAnh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtAnh.Location = new System.Drawing.Point(86, 3);
		txtAnh.Name = "txtAnh";
		txtAnh.Size = new System.Drawing.Size(220, 23);
		txtAnh.TabIndex = 155;
		D18F25AB.AutoSize = true;
		D18F25AB.Location = new System.Drawing.Point(3, 6);
		D18F25AB.Name = "label12";
		D18F25AB.Size = new System.Drawing.Size(73, 16);
		D18F25AB.TabIndex = 39;
		D18F25AB.Text = "Folder ảnh:";
		D18F25AB.Click += new System.EventHandler(D18F25AB_Click);
		label49.AutoSize = true;
		label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label49.Location = new System.Drawing.Point(27, 80);
		label49.Name = "label49";
		label49.Size = new System.Drawing.Size(84, 16);
		label49.TabIndex = 169;
		label49.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		D534FBAD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		D534FBAD.Location = new System.Drawing.Point(129, 78);
		D534FBAD.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		D534FBAD.Name = "nudSoLuongUidFrom";
		D534FBAD.Size = new System.Drawing.Size(56, 23);
		D534FBAD.TabIndex = 167;
		D534FBAD.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		A8020EB4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A8020EB4.Location = new System.Drawing.Point(226, 78);
		A8020EB4.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		A8020EB4.Name = "nudSoLuongUidTo";
		A8020EB4.Size = new System.Drawing.Size(56, 23);
		A8020EB4.TabIndex = 168;
		A8020EB4.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label66.Location = new System.Drawing.Point(191, 80);
		label66.Name = "label66";
		label66.Size = new System.Drawing.Size(29, 16);
		label66.TabIndex = 171;
		label66.Text = ">";
		label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AD95788B.AutoSize = true;
		AD95788B.Cursor = System.Windows.Forms.Cursors.Hand;
		AD95788B.Location = new System.Drawing.Point(661, 77);
		AD95788B.Name = "ckbComment";
		AD95788B.Size = new System.Drawing.Size(127, 20);
		AD95788B.TabIndex = 163;
		AD95788B.Text = "Bi\u0300nh luâ\u0323n văn bản";
		AD95788B.UseVisualStyleBackColor = true;
		AD95788B.CheckedChanged += new System.EventHandler(AD95788B_CheckedChanged);
		nudTimeTo.Location = new System.Drawing.Point(498, 78);
		nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeTo.Name = "nudTimeTo";
		nudTimeTo.Size = new System.Drawing.Size(51, 23);
		nudTimeTo.TabIndex = 4;
		EF374299.Location = new System.Drawing.Point(226, 107);
		EF374299.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		EF374299.Name = "nudDelayTo";
		EF374299.Size = new System.Drawing.Size(56, 23);
		EF374299.TabIndex = 4;
		nudTimeFrom.Location = new System.Drawing.Point(420, 78);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(51, 23);
		nudTimeFrom.TabIndex = 3;
		F3A4E316.Location = new System.Drawing.Point(129, 107);
		F3A4E316.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		F3A4E316.Name = "nudDelayFrom";
		F3A4E316.Size = new System.Drawing.Size(56, 23);
		F3A4E316.TabIndex = 3;
		txtTenHanhDong.Location = new System.Drawing.Point(129, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(471, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(29, 16);
		label9.TabIndex = 38;
		label9.Text = ">";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(191, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		FF24FA35.AutoSize = true;
		FF24FA35.Location = new System.Drawing.Point(314, 80);
		FF24FA35.Name = "label3";
		FF24FA35.Size = new System.Drawing.Size(103, 16);
		FF24FA35.TabIndex = 34;
		FF24FA35.Text = "Xem bài viết (s):";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 109);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		D137DABC.AutoSize = true;
		D137DABC.Location = new System.Drawing.Point(27, 52);
		D137DABC.Name = "label1";
		D137DABC.Size = new System.Drawing.Size(98, 16);
		D137DABC.TabIndex = 31;
		D137DABC.Text = "Tên ha\u0300nh đô\u0323ng:";
		C138D025.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C138D025.BackColor = System.Drawing.Color.Maroon;
		C138D025.Cursor = System.Windows.Forms.Cursors.Hand;
		C138D025.FlatAppearance.BorderSize = 0;
		C138D025.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C138D025.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C138D025.ForeColor = System.Drawing.Color.White;
		C138D025.Location = new System.Drawing.Point(508, 449);
		C138D025.Name = "btnCancel";
		C138D025.Size = new System.Drawing.Size(92, 29);
		C138D025.TabIndex = 10;
		C138D025.Text = "Đóng";
		C138D025.UseVisualStyleBackColor = false;
		C138D025.Click += new System.EventHandler(F28D579F);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(401, 449);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(B1289293);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(1000, 37);
		bunifuCards1.TabIndex = 28;
		C6899AAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C6899AAB.Controls.Add(cbbTuyChonNoiDungShare);
		C6899AAB.Controls.Add(C88128B9);
		C6899AAB.Controls.Add(label15);
		C6899AAB.Controls.Add(ckbAutoDeleteContentShare);
		C6899AAB.Controls.Add(txtContentShare);
		C6899AAB.Controls.Add(lblContentShare);
		C6899AAB.Location = new System.Drawing.Point(317, 153);
		C6899AAB.Name = "plContentShare";
		C6899AAB.Size = new System.Drawing.Size(312, 281);
		C6899AAB.TabIndex = 164;
		cbbTuyChonNoiDungShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDungShare.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDungShare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDungShare.FormattingEnabled = true;
		cbbTuyChonNoiDungShare.Location = new System.Drawing.Point(69, 227);
		cbbTuyChonNoiDungShare.Name = "cbbTuyChonNoiDungShare";
		cbbTuyChonNoiDungShare.Size = new System.Drawing.Size(203, 24);
		cbbTuyChonNoiDungShare.TabIndex = 180;
		cbbTuyChonNoiDungShare.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDungShare_SelectedIndexChanged);
		C88128B9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		C88128B9.Cursor = System.Windows.Forms.Cursors.Hand;
		C88128B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C88128B9.Location = new System.Drawing.Point(278, 226);
		C88128B9.Name = "button2";
		C88128B9.Size = new System.Drawing.Size(26, 26);
		C88128B9.TabIndex = 179;
		C88128B9.Text = "?";
		C88128B9.UseVisualStyleBackColor = true;
		C88128B9.Click += new System.EventHandler(C88128B9_Click);
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(3, 230);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(64, 16);
		label15.TabIndex = 178;
		label15.Text = "Tùy chọn:";
		ckbAutoDeleteContentShare.AutoSize = true;
		ckbAutoDeleteContentShare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoDeleteContentShare.Location = new System.Drawing.Point(6, 256);
		ckbAutoDeleteContentShare.Name = "ckbAutoDeleteContentShare";
		ckbAutoDeleteContentShare.Size = new System.Drawing.Size(169, 20);
		ckbAutoDeleteContentShare.TabIndex = 176;
		ckbAutoDeleteContentShare.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		ckbAutoDeleteContentShare.UseVisualStyleBackColor = true;
		txtContentShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtContentShare.Location = new System.Drawing.Point(6, 25);
		txtContentShare.Name = "txtContentShare";
		txtContentShare.Size = new System.Drawing.Size(298, 197);
		txtContentShare.TabIndex = 1;
		txtContentShare.Text = "";
		txtContentShare.WordWrap = false;
		txtContentShare.TextChanged += new System.EventHandler(txtContentShare_TextChanged);
		lblContentShare.AutoSize = true;
		lblContentShare.Location = new System.Drawing.Point(2, 5);
		lblContentShare.Name = "lblContentShare";
		lblContentShare.Size = new System.Drawing.Size(119, 16);
		lblContentShare.TabIndex = 0;
		lblContentShare.Text = "Nội dung share (0):";
		ckbShareWall.AutoSize = true;
		ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareWall.Location = new System.Drawing.Point(317, 131);
		ckbShareWall.Name = "ckbShareWall";
		ckbShareWall.Size = new System.Drawing.Size(87, 20);
		ckbShareWall.TabIndex = 6;
		ckbShareWall.Text = "Share wall";
		ckbShareWall.UseVisualStyleBackColor = true;
		ckbShareWall.CheckedChanged += new System.EventHandler(ckbShareWall_CheckedChanged);
		B5130925.AutoSize = true;
		B5130925.Location = new System.Drawing.Point(4, 302);
		B5130925.Name = "label26";
		B5130925.Size = new System.Drawing.Size(64, 16);
		B5130925.TabIndex = 2;
		B5130925.Text = "Tùy chọn:";
		FA3400BB.Controls.Add(radioButton3);
		FA3400BB.Controls.Add(radioButton4);
		FA3400BB.Location = new System.Drawing.Point(67, 300);
		FA3400BB.Name = "panel7";
		FA3400BB.Size = new System.Drawing.Size(200, 43);
		FA3400BB.TabIndex = 43;
		radioButton4.AutoSize = true;
		radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton4.Location = new System.Drawing.Point(3, 23);
		radioButton4.Name = "radioButton4";
		radioButton4.Size = new System.Drawing.Size(200, 20);
		radioButton4.TabIndex = 3;
		radioButton4.Text = "Comment ngẫu nhiên nội dung";
		radioButton4.UseVisualStyleBackColor = true;
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
		F330B912.Cursor = System.Windows.Forms.Cursors.Hand;
		F330B912.Image = Class155.Bitmap_166;
		F330B912.Location = new System.Drawing.Point(2, 1);
		F330B912.Name = "ckbLike";
		F330B912.Size = new System.Drawing.Size(40, 30);
		F330B912.TabIndex = 173;
		F330B912.Tag = "Like";
		F330B912.UseVisualStyleBackColor = true;
		ckbLove.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLove.Image = Class155.AB95A212;
		ckbLove.Location = new System.Drawing.Point(46, 1);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(40, 30);
		ckbLove.TabIndex = 174;
		ckbLove.Tag = "Love";
		ckbLove.UseVisualStyleBackColor = true;
		ckbCare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCare.Image = Class155.Bitmap_20;
		ckbCare.Location = new System.Drawing.Point(90, 1);
		ckbCare.Name = "ckbCare";
		ckbCare.Size = new System.Drawing.Size(40, 30);
		ckbCare.TabIndex = 175;
		ckbCare.Tag = "Care";
		ckbCare.UseVisualStyleBackColor = true;
		F82B8EAE.Cursor = System.Windows.Forms.Cursors.Hand;
		F82B8EAE.Image = Class155.E982D419;
		F82B8EAE.Location = new System.Drawing.Point(134, 1);
		F82B8EAE.Name = "ckbHaha";
		F82B8EAE.Size = new System.Drawing.Size(40, 30);
		F82B8EAE.TabIndex = 176;
		F82B8EAE.Tag = "Haha";
		F82B8EAE.UseVisualStyleBackColor = true;
		ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWow.Image = Class155.Bitmap_181;
		ckbWow.Location = new System.Drawing.Point(178, 1);
		ckbWow.Name = "ckbWow";
		ckbWow.Size = new System.Drawing.Size(40, 30);
		ckbWow.TabIndex = 177;
		ckbWow.Tag = "Wow";
		ckbWow.UseVisualStyleBackColor = true;
		DE2EAA06.Cursor = System.Windows.Forms.Cursors.Hand;
		DE2EAA06.Image = Class155.E1938320;
		DE2EAA06.Location = new System.Drawing.Point(222, 1);
		DE2EAA06.Name = "ckbSad";
		DE2EAA06.Size = new System.Drawing.Size(40, 30);
		DE2EAA06.TabIndex = 178;
		DE2EAA06.Tag = "Sad";
		DE2EAA06.UseVisualStyleBackColor = true;
		DE86C58E.Cursor = System.Windows.Forms.Cursors.Hand;
		DE86C58E.Image = Class155.Bitmap_11;
		DE86C58E.Location = new System.Drawing.Point(266, 1);
		DE86C58E.Name = "ckbAngry";
		DE86C58E.Size = new System.Drawing.Size(40, 30);
		DE86C58E.TabIndex = 179;
		DE86C58E.Tag = "Angry";
		DE86C58E.UseVisualStyleBackColor = true;
		plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plInteract.Controls.Add(DE86C58E);
		plInteract.Controls.Add(DE2EAA06);
		plInteract.Controls.Add(ckbWow);
		plInteract.Controls.Add(F82B8EAE);
		plInteract.Controls.Add(ckbCare);
		plInteract.Controls.Add(ckbLove);
		plInteract.Controls.Add(F330B912);
		plInteract.Controls.Add(FA3400BB);
		plInteract.Controls.Add(B5130925);
		plInteract.Location = new System.Drawing.Point(317, 153);
		plInteract.Name = "plInteract";
		plInteract.Size = new System.Drawing.Size(312, 33);
		plInteract.TabIndex = 182;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1003, 491);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTuongTacReelChiDinh";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(AB24358B);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plCommentText.ResumeLayout(false);
		plCommentText.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)D534FBAD).EndInit();
		((System.ComponentModel.ISupportInitialize)A8020EB4).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)EF374299).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)F3A4E316).EndInit();
		bunifuCards1.ResumeLayout(false);
		C6899AAB.ResumeLayout(false);
		C6899AAB.PerformLayout();
		FA3400BB.ResumeLayout(false);
		FA3400BB.PerformLayout();
		plInteract.ResumeLayout(false);
		plInteract.PerformLayout();
		ResumeLayout(false);
	}
}
