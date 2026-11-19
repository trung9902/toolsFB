using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapDuLieu3 : Form
{
	internal string B0A92A12 = "";

	internal string FE2DE705 = "";

	internal string C90D3E02 = "";

	internal int A732C0B9 = 0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards FB80908B;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox D8AF5B33;

	internal Button A918AB9E;

	internal BunifuCustomLabel D3AD4405;

	internal Label lblStatus;

	internal Button btnCancel;

	internal Button D2B75632;

	internal Label E4168DB5;

	internal RichTextBox txtComment;

	internal Button button3;

	internal Button F0A52782;

	internal RadioButton FD37BC82;

	internal RadioButton rbNganCachMoiDong;

	internal Label F02515BD;

	public fNhapDuLieu3(string string_0, string FD1C600D = "Nhập danh sách Uid cần clone", string string_1 = "Danh sách Uid", string DF025217 = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})", List<string> list_0 = null)
	{
		InitializeComponent();
		Commom.EF994A31(string_0);
		B0A92A12 = string_0;
		FE2DE705 = string_1;
		D3AD4405.Text = FD1C600D;
		lblStatus.Text = string_1 + " (0):";
		E4168DB5.Text = DF025217;
		if (list_0 != null)
		{
			File.WriteAllLines(string_0, list_0);
			txtComment.Lines = list_0.ToArray();
		}
		else
		{
			txtComment.Lines = File.ReadAllLines(string_0);
		}
		E0B2A7BA(null, null);
		Language.CD21F0A9(this);
	}

	public fNhapDuLieu3(string DC2CAC88, int int_0, string B2051C85 = "Nhập danh sách Uid cần clone", string A984F822 = "Danh sách Uid", string CB3B41AF = "(Spin nội dung {a|b|c})")
	{
		InitializeComponent();
		C90D3E02 = DC2CAC88;
		A732C0B9 = int_0;
		FE2DE705 = A984F822;
		D3AD4405.Text = B2051C85;
		lblStatus.Text = A984F822 + " (0):";
		E4168DB5.Text = CB3B41AF;
		Language.CD21F0A9(this);
	}

	private void fNhapDuLieu3_Load(object sender, EventArgs e)
	{
		if (A732C0B9 == 0)
		{
			rbNganCachMoiDong.Checked = true;
		}
		else
		{
			FD37BC82.Checked = true;
		}
		if (B0A92A12 != "")
		{
			txtComment.Lines = File.ReadAllLines(B0A92A12);
		}
		else
		{
			txtComment.Text = C90D3E02;
		}
	}

	private void DE80FA3F(object sender, PaintEventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D2B75632_Click(object sender, EventArgs e)
	{
		try
		{
			if (B0A92A12 != "")
			{
				File.WriteAllText(B0A92A12, txtComment.Text.Trim());
			}
			else
			{
				C90D3E02 = txtComment.Text;
				A732C0B9 = ((!rbNganCachMoiDong.Checked) ? 1 : 0);
			}
			if (MsBoxHelper.D41C45AC("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
			{
				Close();
			}
		}
		catch
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void A195B78F(object sender, EventArgs e)
	{
		Close();
	}

	private void E0B2A7BA(object sender, EventArgs e)
	{
		int b38B = ((!rbNganCachMoiDong.Checked) ? 1 : 0);
		Commom.A9BCAF05(txtComment, lblStatus, b38B);
	}

	private void E9038A05(object sender, EventArgs e)
	{
		MsBoxHelper.Show(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
	}

	private void BD88B225(object sender, EventArgs e)
	{
		Commom.smethod_35(new fHelpNhapComment());
	}

	private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
	{
		E0B2A7BA(null, null);
	}

	private void FD37BC82_CheckedChanged(object sender, EventArgs e)
	{
		E0B2A7BA(null, null);
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
		panel1 = new System.Windows.Forms.Panel();
		button3 = new System.Windows.Forms.Button();
		F0A52782 = new System.Windows.Forms.Button();
		FD37BC82 = new System.Windows.Forms.RadioButton();
		rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
		F02515BD = new System.Windows.Forms.Label();
		txtComment = new System.Windows.Forms.RichTextBox();
		E4168DB5 = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		D2B75632 = new System.Windows.Forms.Button();
		FB80908B = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		D8AF5B33 = new System.Windows.Forms.PictureBox();
		A918AB9E = new System.Windows.Forms.Button();
		D3AD4405 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		FB80908B.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D8AF5B33).BeginInit();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 5;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(234, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(button3);
		panel1.Controls.Add(F0A52782);
		panel1.Controls.Add(FD37BC82);
		panel1.Controls.Add(rbNganCachMoiDong);
		panel1.Controls.Add(F02515BD);
		panel1.Controls.Add(txtComment);
		panel1.Controls.Add(E4168DB5);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(D2B75632);
		panel1.Controls.Add(FB80908B);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(563, 355);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(DE80FA3F);
		button3.Cursor = System.Windows.Forms.Cursors.Help;
		button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button3.Location = new System.Drawing.Point(237, 274);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(21, 23);
		button3.TabIndex = 198;
		button3.Text = "?";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(BD88B225);
		F0A52782.Cursor = System.Windows.Forms.Cursors.Help;
		F0A52782.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F0A52782.Location = new System.Drawing.Point(237, 251);
		F0A52782.Name = "button1";
		F0A52782.Size = new System.Drawing.Size(21, 23);
		F0A52782.TabIndex = 199;
		F0A52782.Text = "?";
		F0A52782.UseVisualStyleBackColor = true;
		F0A52782.Click += new System.EventHandler(E9038A05);
		FD37BC82.AutoSize = true;
		FD37BC82.Cursor = System.Windows.Forms.Cursors.Hand;
		FD37BC82.Location = new System.Drawing.Point(78, 275);
		FD37BC82.Name = "rbNganCachKyTu";
		FD37BC82.Size = new System.Drawing.Size(159, 20);
		FD37BC82.TabIndex = 197;
		FD37BC82.Text = "Nội dung có nhiều dòng";
		FD37BC82.UseVisualStyleBackColor = true;
		FD37BC82.CheckedChanged += new System.EventHandler(FD37BC82_CheckedChanged);
		rbNganCachMoiDong.AutoSize = true;
		rbNganCachMoiDong.Checked = true;
		rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
		rbNganCachMoiDong.Location = new System.Drawing.Point(78, 253);
		rbNganCachMoiDong.Name = "rbNganCachMoiDong";
		rbNganCachMoiDong.Size = new System.Drawing.Size(155, 20);
		rbNganCachMoiDong.TabIndex = 196;
		rbNganCachMoiDong.TabStop = true;
		rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
		rbNganCachMoiDong.UseVisualStyleBackColor = true;
		rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
		F02515BD.AutoSize = true;
		F02515BD.Location = new System.Drawing.Point(13, 253);
		F02515BD.Name = "label9";
		F02515BD.Size = new System.Drawing.Size(64, 16);
		F02515BD.TabIndex = 195;
		F02515BD.Text = "Tùy chọn:";
		txtComment.Location = new System.Drawing.Point(16, 64);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(528, 186);
		txtComment.TabIndex = 50;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(E0B2A7BA);
		E4168DB5.AutoSize = true;
		E4168DB5.Location = new System.Drawing.Point(404, 253);
		E4168DB5.Name = "lblFooter";
		E4168DB5.Size = new System.Drawing.Size(143, 16);
		E4168DB5.TabIndex = 49;
		E4168DB5.Text = "(Spin nội dung {a|b|c})";
		lblStatus.AutoSize = true;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblStatus.Location = new System.Drawing.Point(13, 45);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(139, 16);
		lblStatus.TabIndex = 47;
		lblStatus.Text = "Nội dung bình luận (0):";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(287, 313);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 46;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(A195B78F);
		D2B75632.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D2B75632.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		D2B75632.Cursor = System.Windows.Forms.Cursors.Hand;
		D2B75632.FlatAppearance.BorderSize = 0;
		D2B75632.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D2B75632.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D2B75632.ForeColor = System.Drawing.Color.White;
		D2B75632.Location = new System.Drawing.Point(183, 313);
		D2B75632.Name = "btnAdd";
		D2B75632.Size = new System.Drawing.Size(92, 29);
		D2B75632.TabIndex = 45;
		D2B75632.Text = "Lưu";
		D2B75632.UseVisualStyleBackColor = false;
		D2B75632.Click += new System.EventHandler(D2B75632_Click);
		FB80908B.BackColor = System.Drawing.Color.White;
		FB80908B.BorderRadius = 0;
		FB80908B.BottomSahddow = true;
		FB80908B.color = System.Drawing.Color.SaddleBrown;
		FB80908B.Controls.Add(pnlHeader);
		FB80908B.Dock = System.Windows.Forms.DockStyle.Top;
		FB80908B.LeftSahddow = false;
		FB80908B.Location = new System.Drawing.Point(0, 0);
		FB80908B.Name = "bunifuCards2";
		FB80908B.RightSahddow = true;
		FB80908B.ShadowDepth = 20;
		FB80908B.Size = new System.Drawing.Size(561, 37);
		FB80908B.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(D8AF5B33);
		pnlHeader.Controls.Add(A918AB9E);
		pnlHeader.Controls.Add(D3AD4405);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(561, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(530, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		D8AF5B33.Cursor = System.Windows.Forms.Cursors.Default;
		D8AF5B33.Image = Class155.DD225F0D;
		D8AF5B33.Location = new System.Drawing.Point(3, 2);
		D8AF5B33.Name = "pictureBox1";
		D8AF5B33.Size = new System.Drawing.Size(34, 27);
		D8AF5B33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D8AF5B33.TabIndex = 76;
		D8AF5B33.TabStop = false;
		A918AB9E.Cursor = System.Windows.Forms.Cursors.Hand;
		A918AB9E.FlatAppearance.BorderSize = 0;
		A918AB9E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A918AB9E.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A918AB9E.ForeColor = System.Drawing.Color.White;
		A918AB9E.Location = new System.Drawing.Point(899, 1);
		A918AB9E.Name = "btnMinimize";
		A918AB9E.Size = new System.Drawing.Size(30, 30);
		A918AB9E.TabIndex = 9;
		A918AB9E.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A918AB9E.UseVisualStyleBackColor = true;
		D3AD4405.BackColor = System.Drawing.Color.Transparent;
		D3AD4405.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D3AD4405.Dock = System.Windows.Forms.DockStyle.Fill;
		D3AD4405.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D3AD4405.ForeColor = System.Drawing.Color.Black;
		D3AD4405.Location = new System.Drawing.Point(0, 0);
		D3AD4405.Name = "lblTitle";
		D3AD4405.Size = new System.Drawing.Size(561, 31);
		D3AD4405.TabIndex = 12;
		D3AD4405.Text = "Nhập nội dung comment";
		D3AD4405.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = D3AD4405;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(563, 355);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fNhapDuLieu3";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fNhapDuLieu3_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		FB80908B.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D8AF5B33).EndInit();
		ResumeLayout(false);
	}
}
