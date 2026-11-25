using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhKhoiPhucMatKhau : Form
{
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal RadioButton rbPassNgauNhien;

	internal RadioButton D6807807;

	internal TextBox txtPass;

	internal BunifuCards bunifuCards1;

	internal Button btnClose;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel ED90900C;

	internal Panel F018E336;

	internal CheckBox ckbKhongSuDungProfile;

	internal CheckBox A0A1E331;

	internal CheckBox D8A1B7B4;

	public fCauHinhKhoiPhucMatKhau()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		bool_0 = false;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (rbPassNgauNhien.Checked)
		{
			num = 1;
		}
		C5034B95.smethod_0("configGeneral").method_4("typePass", num);
		C5034B95.smethod_0("configGeneral").method_4("txtPass", txtPass.Text.Trim());
		C5034B95.smethod_0("configGeneral").method_4("ckbKillSession", A0A1E331.Checked);
		C5034B95.smethod_0("configGeneral").method_4("ckbKhongSuDungProfile", ckbKhongSuDungProfile.Checked);
		C5034B95.smethod_0("configGeneral").method_4("ckbQuenMatKhauByChrome", D8A1B7B4.Checked);
		C5034B95.smethod_1("configGeneral");
		bool_0 = true;
		Close();
	}

	private void ACB7A72C(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhKhoiPhucMatKhau_Load(object sender, EventArgs e)
	{
		if (C5034B95.smethod_0("configGeneral").method_2("typePass") == 0)
		{
			D6807807.Checked = true;
		}
		else
		{
			rbPassNgauNhien.Checked = true;
		}
		txtPass.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtPass");
		A0A1E331.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbKillSession");
		ckbKhongSuDungProfile.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbKhongSuDungProfile");
		D8A1B7B4.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbQuenMatKhauByChrome");
		A43F2014(null, null);
	}

	private void A43F2014(object sender, EventArgs e)
	{
		txtPass.Enabled = D6807807.Checked;
	}

	private void F1042C37(object sender, EventArgs e)
	{
		Close();
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
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		ED90900C = new Bunifu.Framework.UI.BunifuCustomLabel();
		rbPassNgauNhien = new System.Windows.Forms.RadioButton();
		D6807807 = new System.Windows.Forms.RadioButton();
		txtPass = new System.Windows.Forms.TextBox();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		btnClose = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		F018E336 = new System.Windows.Forms.Panel();
		A0A1E331 = new System.Windows.Forms.CheckBox();
		D8A1B7B4 = new System.Windows.Forms.CheckBox();
		ckbKhongSuDungProfile = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		F018E336.SuspendLayout();
		SuspendLayout();
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(172, 188);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(ACB7A72C);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(68, 188);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = ED90900C;
		bunifuDragControl_0.Vertical = true;
		ED90900C.BackColor = System.Drawing.Color.Transparent;
		ED90900C.Cursor = System.Windows.Forms.Cursors.SizeAll;
		ED90900C.Dock = System.Windows.Forms.DockStyle.Fill;
		ED90900C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		ED90900C.ForeColor = System.Drawing.Color.Black;
		ED90900C.Location = new System.Drawing.Point(0, 0);
		ED90900C.Name = "bunifuCustomLabel1";
		ED90900C.Size = new System.Drawing.Size(330, 38);
		ED90900C.TabIndex = 12;
		ED90900C.Text = "Cấu hình Khôi phục mật khẩu";
		ED90900C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		rbPassNgauNhien.AutoSize = true;
		rbPassNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassNgauNhien.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbPassNgauNhien.Location = new System.Drawing.Point(27, 81);
		rbPassNgauNhien.Name = "rbPassNgauNhien";
		rbPassNgauNhien.Size = new System.Drawing.Size(144, 20);
		rbPassNgauNhien.TabIndex = 5;
		rbPassNgauNhien.TabStop = true;
		rbPassNgauNhien.Text = "Mâ\u0323t khâ\u0309u ngẫu nhiên";
		rbPassNgauNhien.UseVisualStyleBackColor = true;
		D6807807.AutoSize = true;
		D6807807.Cursor = System.Windows.Forms.Cursors.Hand;
		D6807807.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D6807807.Location = new System.Drawing.Point(27, 55);
		D6807807.Name = "rbPassTuDat";
		D6807807.Size = new System.Drawing.Size(130, 20);
		D6807807.TabIndex = 6;
		D6807807.TabStop = true;
		D6807807.Text = "Mâ\u0323t khâ\u0309u chỉ định:";
		D6807807.UseVisualStyleBackColor = true;
		D6807807.CheckedChanged += new System.EventHandler(A43F2014);
		txtPass.Location = new System.Drawing.Point(163, 54);
		txtPass.Name = "txtPass";
		txtPass.Size = new System.Drawing.Size(132, 23);
		txtPass.TabIndex = 7;
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(btnClose);
		bunifuCards1.Controls.Add(pictureBox1);
		bunifuCards1.Controls.Add(ED90900C);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(330, 38);
		bunifuCards1.TabIndex = 29;
		btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = Class155.FF80C508;
		btnClose.Location = new System.Drawing.Point(298, 5);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(30, 30);
		btnClose.TabIndex = 77;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(F1042C37);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(2, 6);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		F018E336.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F018E336.Controls.Add(txtPass);
		F018E336.Controls.Add(A0A1E331);
		F018E336.Controls.Add(D8A1B7B4);
		F018E336.Controls.Add(ckbKhongSuDungProfile);
		F018E336.Controls.Add(D6807807);
		F018E336.Controls.Add(rbPassNgauNhien);
		F018E336.Controls.Add(bunifuCards1);
		F018E336.Dock = System.Windows.Forms.DockStyle.Fill;
		F018E336.Location = new System.Drawing.Point(0, 0);
		F018E336.Name = "panel2";
		F018E336.Size = new System.Drawing.Size(332, 229);
		F018E336.TabIndex = 30;
		A0A1E331.AutoSize = true;
		A0A1E331.Cursor = System.Windows.Forms.Cursors.Hand;
		A0A1E331.Location = new System.Drawing.Point(27, 107);
		A0A1E331.Name = "ckbKillSession";
		A0A1E331.Size = new System.Drawing.Size(144, 20);
		A0A1E331.TabIndex = 30;
		A0A1E331.Text = "Đăng xuất thiết bị cũ";
		A0A1E331.UseVisualStyleBackColor = true;
		D8A1B7B4.AutoSize = true;
		D8A1B7B4.Cursor = System.Windows.Forms.Cursors.Hand;
		D8A1B7B4.Location = new System.Drawing.Point(27, 159);
		D8A1B7B4.Name = "ckbQuenMatKhauByChrome";
		D8A1B7B4.Size = new System.Drawing.Size(192, 20);
		D8A1B7B4.TabIndex = 30;
		D8A1B7B4.Text = "Quên mâ\u0323t khâ\u0309u bă\u0300ng chrome";
		D8A1B7B4.UseVisualStyleBackColor = true;
		D8A1B7B4.Visible = false;
		ckbKhongSuDungProfile.AutoSize = true;
		ckbKhongSuDungProfile.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKhongSuDungProfile.Location = new System.Drawing.Point(27, 133);
		ckbKhongSuDungProfile.Name = "ckbKhongSuDungProfile";
		ckbKhongSuDungProfile.Size = new System.Drawing.Size(198, 20);
		ckbKhongSuDungProfile.TabIndex = 30;
		ckbKhongSuDungProfile.Text = "Không sử dụng profile chrome";
		ckbKhongSuDungProfile.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(332, 229);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(F018E336);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhKhoiPhucMatKhau";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhKhoiPhucMatKhau_Load);
		bunifuCards1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		F018E336.ResumeLayout(false);
		F018E336.PerformLayout();
		ResumeLayout(false);
	}
}
