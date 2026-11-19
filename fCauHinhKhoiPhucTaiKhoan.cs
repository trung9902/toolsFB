using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhKhoiPhucTaiKhoan : Form
{
	internal static bool B53B3334 = false;

	internal static int int_0 = 0;

	internal static string string_0 = "";

	internal int A83DF80B = 0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel D281A9A3;

	internal BunifuCustomLabel C591CF9E;

	internal Button A116170C;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal RadioButton rbThuMucCu;

	internal RadioButton rbThuMucKhac;

	internal Button button1;

	internal ComboBox F8377A21;

	internal Panel plThuMucKhac;

	public fCauHinhKhoiPhucTaiKhoan()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		A009F229();
		B53B3334 = false;
		int_0 = 0;
		string_0 = "";
	}

	private void A4305A2C(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		if (rbThuMucKhac.Checked)
		{
			if (F8377A21.SelectedIndex == -1)
			{
				MsBoxHelper.Show("Vui lòng thêm thư mục để lưu tài khoản!", 3);
				return;
			}
			int_0 = 1;
			string_0 = F8377A21.SelectedValue.ToString();
		}
		B53B3334 = true;
		Close();
	}

	private void D2AFFE92(object sender, EventArgs e)
	{
		Close();
	}

	private void EDB6213F(object sender, EventArgs e)
	{
		rbThuMucKhac_CheckedChanged(null, null);
	}

	private void B7221A0C(object sender, EventArgs e)
	{
		fAddFile form_ = new fAddFile();
		Commom.smethod_35(form_);
		if (fAddFile.bool_0)
		{
			A009F229();
			F8377A21.SelectedIndex = F8377A21.Items.Count - 1;
		}
	}

	private void A009F229()
	{
		A83DF80B = F8377A21.SelectedIndex;
		DataTable dataTable = CommonSQL.smethod_1();
		if (dataTable.Rows.Count > 0)
		{
			F8377A21.DataSource = dataTable;
			F8377A21.ValueMember = "id";
			F8377A21.DisplayMember = "name";
			if (A83DF80B == -1)
			{
				A83DF80B = 0;
			}
			F8377A21.SelectedIndex = A83DF80B;
		}
	}

	private void rbThuMucKhac_CheckedChanged(object sender, EventArgs e)
	{
		plThuMucKhac.Enabled = rbThuMucKhac.Checked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhKhoiPhucTaiKhoan));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		D281A9A3 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		A116170C = new System.Windows.Forms.Button();
		C591CF9E = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		rbThuMucCu = new System.Windows.Forms.RadioButton();
		rbThuMucKhac = new System.Windows.Forms.RadioButton();
		button1 = new System.Windows.Forms.Button();
		F8377A21 = new System.Windows.Forms.ComboBox();
		plThuMucKhac = new System.Windows.Forms.Panel();
		bunifuCards1.SuspendLayout();
		D281A9A3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		plThuMucKhac.SuspendLayout();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(D281A9A3);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(365, 34);
		bunifuCards1.TabIndex = 0;
		D281A9A3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D281A9A3.BackColor = System.Drawing.Color.White;
		D281A9A3.Controls.Add(pictureBox1);
		D281A9A3.Controls.Add(A116170C);
		D281A9A3.Controls.Add(C591CF9E);
		D281A9A3.Location = new System.Drawing.Point(0, 3);
		D281A9A3.Name = "pnlHeader";
		D281A9A3.Size = new System.Drawing.Size(365, 28);
		D281A9A3.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		A116170C.Cursor = System.Windows.Forms.Cursors.Hand;
		A116170C.Dock = System.Windows.Forms.DockStyle.Right;
		A116170C.FlatAppearance.BorderSize = 0;
		A116170C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A116170C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A116170C.ForeColor = System.Drawing.Color.White;
		A116170C.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		A116170C.Location = new System.Drawing.Point(333, 0);
		A116170C.Name = "btnMinimize";
		A116170C.Size = new System.Drawing.Size(32, 28);
		A116170C.TabIndex = 9;
		A116170C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A116170C.UseVisualStyleBackColor = true;
		A116170C.Click += new System.EventHandler(A4305A2C);
		C591CF9E.BackColor = System.Drawing.Color.Transparent;
		C591CF9E.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C591CF9E.Dock = System.Windows.Forms.DockStyle.Fill;
		C591CF9E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C591CF9E.ForeColor = System.Drawing.Color.Black;
		C591CF9E.Location = new System.Drawing.Point(0, 0);
		C591CF9E.Name = "bunifuCustomLabel1";
		C591CF9E.Size = new System.Drawing.Size(365, 28);
		C591CF9E.TabIndex = 1;
		C591CF9E.Text = "Câ\u0301u hi\u0300nh Khôi phu\u0323c ta\u0300i khoa\u0309n";
		C591CF9E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(188, 162);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(D2AFFE92);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(84, 162);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = C591CF9E;
		bunifuDragControl_0.Vertical = true;
		rbThuMucCu.AutoSize = true;
		rbThuMucCu.Checked = true;
		rbThuMucCu.Cursor = System.Windows.Forms.Cursors.Hand;
		rbThuMucCu.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbThuMucCu.Location = new System.Drawing.Point(36, 56);
		rbThuMucCu.Name = "rbThuMucCu";
		rbThuMucCu.Size = new System.Drawing.Size(165, 20);
		rbThuMucCu.TabIndex = 5;
		rbThuMucCu.TabStop = true;
		rbThuMucCu.Text = "Khôi phu\u0323c vê\u0300 thư mu\u0323c cu\u0303";
		rbThuMucCu.UseVisualStyleBackColor = true;
		rbThuMucKhac.AutoSize = true;
		rbThuMucKhac.Cursor = System.Windows.Forms.Cursors.Hand;
		rbThuMucKhac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbThuMucKhac.Location = new System.Drawing.Point(36, 82);
		rbThuMucKhac.Name = "rbThuMucKhac";
		rbThuMucKhac.Size = new System.Drawing.Size(179, 20);
		rbThuMucKhac.TabIndex = 5;
		rbThuMucKhac.Text = "Chuyê\u0309n sang thư mu\u0323c kha\u0301c";
		rbThuMucKhac.UseVisualStyleBackColor = true;
		rbThuMucKhac.CheckedChanged += new System.EventHandler(rbThuMucKhac_CheckedChanged);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.Location = new System.Drawing.Point(210, 2);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(62, 27);
		button1.TabIndex = 48;
		button1.Text = "Thêm";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(B7221A0C);
		F8377A21.Cursor = System.Windows.Forms.Cursors.Hand;
		F8377A21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F8377A21.DropDownWidth = 269;
		F8377A21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F8377A21.FormattingEnabled = true;
		F8377A21.Location = new System.Drawing.Point(3, 3);
		F8377A21.Name = "cbbThuMuc";
		F8377A21.Size = new System.Drawing.Size(201, 24);
		F8377A21.TabIndex = 47;
		plThuMucKhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plThuMucKhac.Controls.Add(F8377A21);
		plThuMucKhac.Controls.Add(button1);
		plThuMucKhac.Location = new System.Drawing.Point(55, 108);
		plThuMucKhac.Name = "plThuMucKhac";
		plThuMucKhac.Size = new System.Drawing.Size(278, 33);
		plThuMucKhac.TabIndex = 49;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(365, 205);
		base.Controls.Add(plThuMucKhac);
		base.Controls.Add(rbThuMucKhac);
		base.Controls.Add(rbThuMucCu);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhKhoiPhucTaiKhoan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(EDB6213F);
		bunifuCards1.ResumeLayout(false);
		D281A9A3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		plThuMucKhac.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}
