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

public class fHDPhanHoiBinhLuan : Form
{
	internal GClass4 A8B991BC;

	internal string C31524BC;

	internal string D30FA802;

	internal string D92A7C01;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal List<CheckBox> list_0;

	internal IContainer B834F626 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel B60FB386;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label label5;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel D62F70B5;

	internal Button B00FABB7;

	internal PictureBox D8894B18;

	internal BunifuCustomLabel F3990CB7;

	internal CheckBox ckbInteract;

	internal Label A12A2A17;

	internal NumericUpDown AC3F7387;

	internal NumericUpDown nudTimeFrom;

	internal Label B3805F2A;

	internal Label DC86982C;

	internal Panel EE0C6F95;

	internal RichTextBox txtIdPost;

	internal CheckBox ckbSendAnh;

	internal CheckBox E531E00A;

	internal Label BC06F60B;

	internal NumericUpDown nudSoLuongUidFrom;

	internal NumericUpDown EE1BE69B;

	internal Label label66;

	internal Panel plCommentText;

	internal CheckBox E91E1B15;

	internal Panel panel3;

	internal RadioButton rbCommentTheoThuTu;

	internal RadioButton rbCommentNgauNhien;

	internal Label label13;

	internal RichTextBox C4A947B5;

	internal Label AD8D06B7;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button btnHuongDanNhapNoiDung;

	internal Label label8;

	internal TextBox txtAnh;

	internal Label label12;

	internal CheckBox ckbTuDongXoaUid;

	internal Panel plInteract;

	internal CheckBox D7BFB187;

	internal CheckBox ckbSad;

	internal CheckBox EC1F04BF;

	internal CheckBox D794E1B3;

	internal CheckBox ckbCare;

	internal CheckBox ckbLove;

	internal CheckBox ckbLike;

	internal Panel DE88B79D;

	internal RadioButton radioButton3;

	internal RadioButton F8164B3C;

	internal Label C911CF0A;

	internal CheckBox ckbUuTienMbasic;

	public static bool Boolean_0
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

	public fHDPhanHoiBinhLuan(string A618ACB6, string string_0 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		C31524BC = A618ACB6;
		D92A7C01 = string_0;
		string aA239C = Language.GetValue(F3990CB7.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string string_ = base.Name.Substring(1);
		Class154.FA0E41AD(string_, aA239C);
		string string_2 = "";
		if (string_0 == "")
		{
			DataTable dataTable = Class154.BD904B3B(string_);
			D30FA802 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_0);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		A8B991BC = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
		list_0 = new List<CheckBox> { ckbLike, ckbLove, ckbCare, D794E1B3, EC1F04BF, ckbSad, D7BFB187 };
	}

	private void fHDPhanHoiBinhLuan_Load(object sender, EventArgs e)
	{
		CD8C2832();
		try
		{
			nudTimeFrom.Value = A8B991BC.method_2("nudTimeFrom", 3);
			AC3F7387.Value = A8B991BC.method_2("nudTimeTo", 5);
			nudDelayFrom.Value = A8B991BC.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = A8B991BC.method_2("nudDelayTo", 5);
			nudSoLuongUidFrom.Value = A8B991BC.method_2("nudSoLuongUidFrom", 1);
			EE1BE69B.Value = A8B991BC.method_2("nudSoLuongUidTo", 1);
			ckbInteract.Checked = A8B991BC.method_3("ckbInteract");
			string text = A8B991BC.BDB80B23("typeReaction", "Like");
			List<string> list = text.Split('|').ToList();
			for (int i = 0; i < list.Count; i++)
			{
				foreach (CheckBox item in list_0)
				{
					if (item.Name.Substring(3) == list[i])
					{
						item.Checked = true;
					}
				}
			}
			E531E00A.Checked = A8B991BC.method_3("ckbComment");
			C4A947B5.Text = A8B991BC.BDB80B23("txtComment");
			txtIdPost.Text = A8B991BC.BDB80B23("txtIdPost");
			ckbTuDongXoaUid.Checked = A8B991BC.method_3("ckbTuDongXoaUid");
			ckbUuTienMbasic.Checked = A8B991BC.method_3("ckbUuTienMbasic");
			ckbSendAnh.Checked = A8B991BC.method_3("ckbSendAnh");
			txtAnh.Text = A8B991BC.BDB80B23("txtAnh");
			Commom.AttachFolderPicker(txtAnh);
			cbbTuyChonNoiDung.SelectedIndex = A8B991BC.method_2("typeNganCach");
			if (A8B991BC.method_2("typeComment") == 1)
			{
				rbCommentNgauNhien.Checked = true;
			}
			else
			{
				rbCommentTheoThuTu.Checked = true;
			}
			E91E1B15.Checked = A8B991BC.method_3("ckbAutoDeleteComment");
		}
		catch
		{
		}
		method_1();
	}

	private void CD8C2832()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list);
	}

	private void DE319890(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
			return;
		}
		List<string> list = txtIdPost.Lines.ToList();
		list = Commom.smethod_36(list);
		GClass4 gClass = new GClass4();
		gClass.method_4("nudTimeFrom", nudTimeFrom.Value);
		gClass.method_4("nudTimeTo", AC3F7387.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
		gClass.method_4("nudSoLuongUidTo", EE1BE69B.Value);
		gClass.method_4("ckbInteract", ckbInteract.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + list_0[i].Name.Substring(3) + "|";
			}
		}
		gClass.method_4("typeReaction", text2.TrimEnd('|'));
		gClass.method_4("ckbComment", E531E00A.Checked);
		gClass.method_4("txtComment", C4A947B5.Text.Trim());
		gClass.method_4("txtIdPost", txtIdPost.Text.Trim());
		gClass.method_4("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
		gClass.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);
		gClass.method_4("ckbSendAnh", ckbSendAnh.Checked);
		gClass.method_4("txtAnh", txtAnh.Text.Trim());
		gClass.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		int num = 0;
		if (rbCommentNgauNhien.Checked)
		{
			num = 1;
		}
		gClass.method_4("typeComment", num);
		gClass.method_4("ckbAutoDeleteComment", E91E1B15.Checked);
		string text3 = gClass.ED11179C();
		if (D92A7C01 == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(C31524BC, text, D30FA802, text3))
				{
					Boolean_0 = true;
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
			if (Class154.smethod_13(D92A7C01, text, text3))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B60FB386_Paint(object sender, PaintEventArgs e)
	{
		if (B60FB386.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, B60FB386.ClientSize.Width - num, B60FB386.ClientSize.Height - num));
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		try
		{
			List<string> list = C4A947B5.Lines.ToList();
			list = Commom.smethod_36(list);
			AD8D06B7.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), list.Count.ToString());
		}
		catch
		{
		}
	}

	private void method_1()
	{
		ckbInteract_CheckedChanged(null, null);
		E531E00A_CheckedChanged(null, null);
		method_5(null, null);
		method_6(null, null);
	}

	private void E531E00A_CheckedChanged(object sender, EventArgs e)
	{
		plCommentText.Enabled = E531E00A.Checked;
	}

	private void C001123F(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdPost, A12A2A17);
	}

	private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
	{
		EE0C6F95.Enabled = ckbSendAnh.Checked;
	}

	private void B60FB386_Click(object sender, EventArgs e)
	{
	}

	private void D8894B18_Click(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void D0AC700A(object sender, EventArgs e)
	{
	}

	private void C7960F98(object sender, EventArgs e)
	{
	}

	private void rbCommentNgauNhien_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void B2A19E88(object sender, EventArgs e)
	{
		plCommentText.Height = 195;
	}

	private void FE9E112D(object sender, EventArgs e)
	{
		plCommentText.Height = 267;
	}

	private void method_3(object sender, EventArgs e)
	{
		MsBoxHelper.Show(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
		C4A947B5.Focus();
	}

	private void method_4(object sender, EventArgs e)
	{
		Commom.smethod_35(new fHelpNhapComment());
		C4A947B5.Focus();
	}

	private void C6376EB0(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C4A947B5, AD8D06B7, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void A4298E3F(object sender, EventArgs e)
	{
		MsBoxHelper.Show(Language.GetValue("Có thể dùng [u] để thay thế tên của người đăng bài!"));
	}

	private void E28F8E0E(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	private void E83B9939(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C4A947B5, AD8D06B7);
	}

	private void method_7(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C4A947B5, AD8D06B7, 1);
	}

	private void B2A71C13(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		C4A947B5.Focus();
	}

	private void F69B9A86(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C4A947B5, AD8D06B7, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void ckbInteract_CheckedChanged(object sender, EventArgs e)
	{
		plInteract.Enabled = ckbInteract.Checked;
	}

	protected override void Dispose(bool B6ADA33D)
	{
		if (B6ADA33D && B834F626 != null)
		{
			B834F626.Dispose();
		}
		base.Dispose(B6ADA33D);
	}

	private void InitializeComponent()
	{
		B834F626 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDPhanHoiBinhLuan));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B834F626);
		F3990CB7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(B834F626);
		D62F70B5 = new System.Windows.Forms.Panel();
		B00FABB7 = new System.Windows.Forms.Button();
		D8894B18 = new System.Windows.Forms.PictureBox();
		B60FB386 = new System.Windows.Forms.Panel();
		ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
		plCommentText = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		label8 = new System.Windows.Forms.Label();
		E91E1B15 = new System.Windows.Forms.CheckBox();
		panel3 = new System.Windows.Forms.Panel();
		rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
		rbCommentNgauNhien = new System.Windows.Forms.RadioButton();
		label13 = new System.Windows.Forms.Label();
		C4A947B5 = new System.Windows.Forms.RichTextBox();
		AD8D06B7 = new System.Windows.Forms.Label();
		BC06F60B = new System.Windows.Forms.Label();
		nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
		EE1BE69B = new System.Windows.Forms.NumericUpDown();
		label66 = new System.Windows.Forms.Label();
		EE0C6F95 = new System.Windows.Forms.Panel();
		txtAnh = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		txtIdPost = new System.Windows.Forms.RichTextBox();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		E531E00A = new System.Windows.Forms.CheckBox();
		A12A2A17 = new System.Windows.Forms.Label();
		ckbInteract = new System.Windows.Forms.CheckBox();
		AC3F7387 = new System.Windows.Forms.NumericUpDown();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		B3805F2A = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		DC86982C = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		plInteract = new System.Windows.Forms.Panel();
		D7BFB187 = new System.Windows.Forms.CheckBox();
		ckbSad = new System.Windows.Forms.CheckBox();
		EC1F04BF = new System.Windows.Forms.CheckBox();
		D794E1B3 = new System.Windows.Forms.CheckBox();
		ckbCare = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		ckbLike = new System.Windows.Forms.CheckBox();
		DE88B79D = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		F8164B3C = new System.Windows.Forms.RadioButton();
		C911CF0A = new System.Windows.Forms.Label();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();
		D62F70B5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D8894B18).BeginInit();
		B60FB386.SuspendLayout();
		plCommentText.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)EE1BE69B).BeginInit();
		EE0C6F95.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AC3F7387).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		plInteract.SuspendLayout();
		DE88B79D.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = F3990CB7;
		bunifuDragControl_0.Vertical = true;
		F3990CB7.BackColor = System.Drawing.Color.Transparent;
		F3990CB7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F3990CB7.Dock = System.Windows.Forms.DockStyle.Fill;
		F3990CB7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F3990CB7.ForeColor = System.Drawing.Color.Black;
		F3990CB7.Location = new System.Drawing.Point(0, 0);
		F3990CB7.Name = "bunifuCustomLabel1";
		F3990CB7.Size = new System.Drawing.Size(665, 31);
		F3990CB7.TabIndex = 12;
		F3990CB7.Text = "Cấu hình Phản hồi bình luận";
		F3990CB7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = D62F70B5;
		bunifuDragControl_1.Vertical = true;
		D62F70B5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D62F70B5.BackColor = System.Drawing.Color.White;
		D62F70B5.Controls.Add(B00FABB7);
		D62F70B5.Controls.Add(D8894B18);
		D62F70B5.Controls.Add(F3990CB7);
		D62F70B5.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D62F70B5.Location = new System.Drawing.Point(0, 3);
		D62F70B5.Name = "pnlHeader";
		D62F70B5.Size = new System.Drawing.Size(665, 31);
		D62F70B5.TabIndex = 9;
		B00FABB7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B00FABB7.Cursor = System.Windows.Forms.Cursors.Hand;
		B00FABB7.FlatAppearance.BorderSize = 0;
		B00FABB7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B00FABB7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B00FABB7.ForeColor = System.Drawing.Color.White;
		B00FABB7.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		B00FABB7.Location = new System.Drawing.Point(634, 1);
		B00FABB7.Name = "button1";
		B00FABB7.Size = new System.Drawing.Size(30, 30);
		B00FABB7.TabIndex = 77;
		B00FABB7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B00FABB7.UseVisualStyleBackColor = true;
		B00FABB7.Click += new System.EventHandler(DE319890);
		D8894B18.Cursor = System.Windows.Forms.Cursors.Default;
		D8894B18.Image = Class155.DD225F0D;
		D8894B18.Location = new System.Drawing.Point(3, 2);
		D8894B18.Name = "pictureBox1";
		D8894B18.Size = new System.Drawing.Size(34, 27);
		D8894B18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D8894B18.TabIndex = 76;
		D8894B18.TabStop = false;
		D8894B18.Click += new System.EventHandler(D8894B18_Click);
		B60FB386.BackColor = System.Drawing.Color.White;
		B60FB386.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B60FB386.Controls.Add(ckbUuTienMbasic);
		B60FB386.Controls.Add(plInteract);
		B60FB386.Controls.Add(ckbTuDongXoaUid);
		B60FB386.Controls.Add(plCommentText);
		B60FB386.Controls.Add(BC06F60B);
		B60FB386.Controls.Add(nudSoLuongUidFrom);
		B60FB386.Controls.Add(EE1BE69B);
		B60FB386.Controls.Add(label66);
		B60FB386.Controls.Add(EE0C6F95);
		B60FB386.Controls.Add(txtIdPost);
		B60FB386.Controls.Add(ckbSendAnh);
		B60FB386.Controls.Add(E531E00A);
		B60FB386.Controls.Add(A12A2A17);
		B60FB386.Controls.Add(ckbInteract);
		B60FB386.Controls.Add(AC3F7387);
		B60FB386.Controls.Add(nudDelayTo);
		B60FB386.Controls.Add(nudTimeFrom);
		B60FB386.Controls.Add(nudDelayFrom);
		B60FB386.Controls.Add(txtTenHanhDong);
		B60FB386.Controls.Add(B3805F2A);
		B60FB386.Controls.Add(label7);
		B60FB386.Controls.Add(DC86982C);
		B60FB386.Controls.Add(label5);
		B60FB386.Controls.Add(label1);
		B60FB386.Controls.Add(btnCancel);
		B60FB386.Controls.Add(btnAdd);
		B60FB386.Controls.Add(bunifuCards1);
		B60FB386.Cursor = System.Windows.Forms.Cursors.Arrow;
		B60FB386.Dock = System.Windows.Forms.DockStyle.Fill;
		B60FB386.Location = new System.Drawing.Point(0, 0);
		B60FB386.Name = "panel1";
		B60FB386.Size = new System.Drawing.Size(668, 502);
		B60FB386.TabIndex = 0;
		B60FB386.Click += new System.EventHandler(B60FB386_Click);
		B60FB386.Paint += new System.Windows.Forms.PaintEventHandler(B60FB386_Paint);
		ckbTuDongXoaUid.AutoSize = true;
		ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoaUid.Location = new System.Drawing.Point(30, 394);
		ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
		ckbTuDongXoaUid.Size = new System.Drawing.Size(190, 20);
		ckbTuDongXoaUid.TabIndex = 172;
		ckbTuDongXoaUid.Text = "Tự động xóa ID đã tương tác";
		ckbTuDongXoaUid.UseVisualStyleBackColor = true;
		plCommentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentText.Controls.Add(cbbTuyChonNoiDung);
		plCommentText.Controls.Add(btnHuongDanNhapNoiDung);
		plCommentText.Controls.Add(label8);
		plCommentText.Controls.Add(E91E1B15);
		plCommentText.Controls.Add(panel3);
		plCommentText.Controls.Add(label13);
		plCommentText.Controls.Add(C4A947B5);
		plCommentText.Controls.Add(AD8D06B7);
		plCommentText.Location = new System.Drawing.Point(321, 163);
		plCommentText.Name = "plCommentText";
		plCommentText.Size = new System.Drawing.Size(312, 219);
		plCommentText.TabIndex = 164;
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(70, 169);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(203, 24);
		cbbTuyChonNoiDung.TabIndex = 198;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(F69B9A86);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(279, 168);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 197;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(B2A71C13);
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(4, 172);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 196;
		label8.Text = "Tùy chọn:";
		E91E1B15.AutoSize = true;
		E91E1B15.Cursor = System.Windows.Forms.Cursors.Hand;
		E91E1B15.Location = new System.Drawing.Point(8, 195);
		E91E1B15.Name = "ckbAutoDeleteComment";
		E91E1B15.Size = new System.Drawing.Size(225, 20);
		E91E1B15.TabIndex = 176;
		E91E1B15.Text = "Tự động xóa nội dung đã bình luận";
		E91E1B15.UseVisualStyleBackColor = true;
		panel3.Controls.Add(rbCommentTheoThuTu);
		panel3.Controls.Add(rbCommentNgauNhien);
		panel3.Location = new System.Drawing.Point(67, 300);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(200, 43);
		panel3.TabIndex = 43;
		rbCommentTheoThuTu.AutoSize = true;
		rbCommentTheoThuTu.Checked = true;
		rbCommentTheoThuTu.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentTheoThuTu.Location = new System.Drawing.Point(3, 2);
		rbCommentTheoThuTu.Name = "rbCommentTheoThuTu";
		rbCommentTheoThuTu.Size = new System.Drawing.Size(201, 20);
		rbCommentTheoThuTu.TabIndex = 3;
		rbCommentTheoThuTu.TabStop = true;
		rbCommentTheoThuTu.Text = "Comment theo thứ tự nội dung";
		rbCommentTheoThuTu.UseVisualStyleBackColor = true;
		rbCommentTheoThuTu.CheckedChanged += new System.EventHandler(D0AC700A);
		rbCommentNgauNhien.AutoSize = true;
		rbCommentNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentNgauNhien.Location = new System.Drawing.Point(3, 23);
		rbCommentNgauNhien.Name = "rbCommentNgauNhien";
		rbCommentNgauNhien.Size = new System.Drawing.Size(200, 20);
		rbCommentNgauNhien.TabIndex = 3;
		rbCommentNgauNhien.Text = "Comment ngẫu nhiên nội dung";
		rbCommentNgauNhien.UseVisualStyleBackColor = true;
		rbCommentNgauNhien.CheckedChanged += new System.EventHandler(rbCommentNgauNhien_CheckedChanged);
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(4, 302);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(64, 16);
		label13.TabIndex = 2;
		label13.Text = "Tùy chọn:";
		label13.Click += new System.EventHandler(C7960F98);
		C4A947B5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C4A947B5.Location = new System.Drawing.Point(7, 25);
		C4A947B5.Name = "txtComment";
		C4A947B5.Size = new System.Drawing.Size(298, 137);
		C4A947B5.TabIndex = 1;
		C4A947B5.Text = "";
		C4A947B5.WordWrap = false;
		C4A947B5.TextChanged += new System.EventHandler(C6376EB0);
		AD8D06B7.AutoSize = true;
		AD8D06B7.Location = new System.Drawing.Point(3, 5);
		AD8D06B7.Name = "lblComment";
		AD8D06B7.Size = new System.Drawing.Size(139, 16);
		AD8D06B7.TabIndex = 0;
		AD8D06B7.Text = "Nội dung bình luận (0):";
		BC06F60B.AutoSize = true;
		BC06F60B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		BC06F60B.Location = new System.Drawing.Point(27, 80);
		BC06F60B.Name = "label49";
		BC06F60B.Size = new System.Drawing.Size(107, 16);
		BC06F60B.TabIndex = 169;
		BC06F60B.Text = "Sô\u0301 lươ\u0323ng ID/Nick:";
		nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidFrom.Location = new System.Drawing.Point(134, 78);
		nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
		nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidFrom.TabIndex = 167;
		nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		EE1BE69B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		EE1BE69B.Location = new System.Drawing.Point(231, 78);
		EE1BE69B.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		EE1BE69B.Name = "nudSoLuongUidTo";
		EE1BE69B.Size = new System.Drawing.Size(56, 23);
		EE1BE69B.TabIndex = 168;
		EE1BE69B.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label66.Location = new System.Drawing.Point(196, 80);
		label66.Name = "label66";
		label66.Size = new System.Drawing.Size(29, 16);
		label66.TabIndex = 171;
		label66.Text = ">";
		label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EE0C6F95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EE0C6F95.Controls.Add(txtAnh);
		EE0C6F95.Controls.Add(label12);
		EE0C6F95.Enabled = false;
		EE0C6F95.Location = new System.Drawing.Point(321, 409);
		EE0C6F95.Name = "plAnh";
		EE0C6F95.Size = new System.Drawing.Size(312, 31);
		EE0C6F95.TabIndex = 166;
		txtAnh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtAnh.Location = new System.Drawing.Point(91, 3);
		txtAnh.Name = "txtAnh";
		txtAnh.Size = new System.Drawing.Size(216, 23);
		txtAnh.TabIndex = 161;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(4, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(73, 16);
		label12.TabIndex = 160;
		label12.Text = "Folder ảnh:";
		txtIdPost.Location = new System.Drawing.Point(30, 154);
		txtIdPost.Name = "txtIdPost";
		txtIdPost.Size = new System.Drawing.Size(257, 234);
		txtIdPost.TabIndex = 1;
		txtIdPost.Text = "";
		txtIdPost.WordWrap = false;
		txtIdPost.TextChanged += new System.EventHandler(C001123F);
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(321, 387);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(103, 20);
		ckbSendAnh.TabIndex = 165;
		ckbSendAnh.Text = "Bình luận ảnh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
		E531E00A.AutoSize = true;
		E531E00A.Cursor = System.Windows.Forms.Cursors.Hand;
		E531E00A.Location = new System.Drawing.Point(321, 141);
		E531E00A.Name = "ckbComment";
		E531E00A.Size = new System.Drawing.Size(127, 20);
		E531E00A.TabIndex = 163;
		E531E00A.Text = "Bi\u0300nh luâ\u0323n văn bản";
		E531E00A.UseVisualStyleBackColor = true;
		E531E00A.CheckedChanged += new System.EventHandler(E531E00A_CheckedChanged);
		A12A2A17.AutoSize = true;
		A12A2A17.Location = new System.Drawing.Point(27, 135);
		A12A2A17.Name = "label2";
		A12A2A17.Size = new System.Drawing.Size(167, 16);
		A12A2A17.TabIndex = 40;
		A12A2A17.Text = "Danh sa\u0301ch ID Comment (0):";
		ckbInteract.AutoSize = true;
		ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbInteract.Location = new System.Drawing.Point(321, 80);
		ckbInteract.Name = "ckbInteract";
		ckbInteract.Size = new System.Drawing.Size(99, 20);
		ckbInteract.TabIndex = 5;
		ckbInteract.Text = "Thả cảm xúc";
		ckbInteract.UseVisualStyleBackColor = true;
		ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
		AC3F7387.Location = new System.Drawing.Point(505, 50);
		AC3F7387.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AC3F7387.Name = "nudTimeTo";
		AC3F7387.Size = new System.Drawing.Size(51, 23);
		AC3F7387.TabIndex = 4;
		nudDelayTo.Location = new System.Drawing.Point(231, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudTimeFrom.Location = new System.Drawing.Point(427, 50);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(51, 23);
		nudTimeFrom.TabIndex = 3;
		nudDelayFrom.Location = new System.Drawing.Point(134, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		B3805F2A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B3805F2A.Location = new System.Drawing.Point(478, 52);
		B3805F2A.Name = "label9";
		B3805F2A.Size = new System.Drawing.Size(29, 16);
		B3805F2A.TabIndex = 38;
		B3805F2A.Text = ">";
		B3805F2A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(196, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DC86982C.AutoSize = true;
		DC86982C.Location = new System.Drawing.Point(318, 52);
		DC86982C.Name = "label3";
		DC86982C.Size = new System.Drawing.Size(103, 16);
		DC86982C.TabIndex = 34;
		DC86982C.Text = "Xem bài viết (s):";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 109);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
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
		btnCancel.Location = new System.Drawing.Point(321, 457);
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
		btnAdd.Location = new System.Drawing.Point(214, 457);
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
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(D62F70B5);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(665, 37);
		bunifuCards1.TabIndex = 28;
		plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plInteract.Controls.Add(D7BFB187);
		plInteract.Controls.Add(ckbSad);
		plInteract.Controls.Add(EC1F04BF);
		plInteract.Controls.Add(D794E1B3);
		plInteract.Controls.Add(ckbCare);
		plInteract.Controls.Add(ckbLove);
		plInteract.Controls.Add(ckbLike);
		plInteract.Controls.Add(DE88B79D);
		plInteract.Controls.Add(C911CF0A);
		plInteract.Location = new System.Drawing.Point(321, 102);
		plInteract.Name = "plInteract";
		plInteract.Size = new System.Drawing.Size(312, 33);
		plInteract.TabIndex = 184;
		D7BFB187.Cursor = System.Windows.Forms.Cursors.Hand;
		D7BFB187.Image = Class155.Bitmap_11;
		D7BFB187.Location = new System.Drawing.Point(266, 1);
		D7BFB187.Name = "ckbAngry";
		D7BFB187.Size = new System.Drawing.Size(40, 30);
		D7BFB187.TabIndex = 179;
		D7BFB187.Tag = "Angry";
		D7BFB187.UseVisualStyleBackColor = true;
		ckbSad.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSad.Image = Class155.E1938320;
		ckbSad.Location = new System.Drawing.Point(222, 1);
		ckbSad.Name = "ckbSad";
		ckbSad.Size = new System.Drawing.Size(40, 30);
		ckbSad.TabIndex = 178;
		ckbSad.Tag = "Sad";
		ckbSad.UseVisualStyleBackColor = true;
		EC1F04BF.Cursor = System.Windows.Forms.Cursors.Hand;
		EC1F04BF.Image = Class155.Bitmap_181;
		EC1F04BF.Location = new System.Drawing.Point(178, 1);
		EC1F04BF.Name = "ckbWow";
		EC1F04BF.Size = new System.Drawing.Size(40, 30);
		EC1F04BF.TabIndex = 177;
		EC1F04BF.Tag = "Wow";
		EC1F04BF.UseVisualStyleBackColor = true;
		D794E1B3.Cursor = System.Windows.Forms.Cursors.Hand;
		D794E1B3.Image = Class155.E982D419;
		D794E1B3.Location = new System.Drawing.Point(134, 1);
		D794E1B3.Name = "ckbHaha";
		D794E1B3.Size = new System.Drawing.Size(40, 30);
		D794E1B3.TabIndex = 176;
		D794E1B3.Tag = "Haha";
		D794E1B3.UseVisualStyleBackColor = true;
		ckbCare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCare.Image = Class155.Bitmap_20;
		ckbCare.Location = new System.Drawing.Point(90, 1);
		ckbCare.Name = "ckbCare";
		ckbCare.Size = new System.Drawing.Size(40, 30);
		ckbCare.TabIndex = 175;
		ckbCare.Tag = "Care";
		ckbCare.UseVisualStyleBackColor = true;
		ckbLove.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLove.Image = Class155.AB95A212;
		ckbLove.Location = new System.Drawing.Point(46, 1);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(40, 30);
		ckbLove.TabIndex = 174;
		ckbLove.Tag = "Love";
		ckbLove.UseVisualStyleBackColor = true;
		ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLike.Image = Class155.Bitmap_166;
		ckbLike.Location = new System.Drawing.Point(2, 1);
		ckbLike.Name = "ckbLike";
		ckbLike.Size = new System.Drawing.Size(40, 30);
		ckbLike.TabIndex = 173;
		ckbLike.Tag = "Like";
		ckbLike.UseVisualStyleBackColor = true;
		DE88B79D.Controls.Add(radioButton3);
		DE88B79D.Controls.Add(F8164B3C);
		DE88B79D.Location = new System.Drawing.Point(67, 300);
		DE88B79D.Name = "panel7";
		DE88B79D.Size = new System.Drawing.Size(200, 43);
		DE88B79D.TabIndex = 43;
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
		F8164B3C.AutoSize = true;
		F8164B3C.Cursor = System.Windows.Forms.Cursors.Hand;
		F8164B3C.Location = new System.Drawing.Point(3, 23);
		F8164B3C.Name = "radioButton4";
		F8164B3C.Size = new System.Drawing.Size(200, 20);
		F8164B3C.TabIndex = 3;
		F8164B3C.Text = "Comment ngẫu nhiên nội dung";
		F8164B3C.UseVisualStyleBackColor = true;
		C911CF0A.AutoSize = true;
		C911CF0A.Location = new System.Drawing.Point(4, 302);
		C911CF0A.Name = "label26";
		C911CF0A.Size = new System.Drawing.Size(64, 16);
		C911CF0A.TabIndex = 2;
		C911CF0A.Text = "Tùy chọn:";
		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienMbasic.Location = new System.Drawing.Point(30, 420);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(173, 20);
		ckbUuTienMbasic.TabIndex = 185;
		ckbUuTienMbasic.Text = "Ưu tiên chạy bằng mbasic";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(668, 502);
		base.Controls.Add(B60FB386);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDPhanHoiBinhLuan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDPhanHoiBinhLuan_Load);
		D62F70B5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D8894B18).EndInit();
		B60FB386.ResumeLayout(false);
		B60FB386.PerformLayout();
		plCommentText.ResumeLayout(false);
		plCommentText.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)EE1BE69B).EndInit();
		EE0C6F95.ResumeLayout(false);
		EE0C6F95.PerformLayout();
		((System.ComponentModel.ISupportInitialize)AC3F7387).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		plInteract.ResumeLayout(false);
		plInteract.PerformLayout();
		DE88B79D.ResumeLayout(false);
		DE88B79D.PerformLayout();
		ResumeLayout(false);
	}
}
