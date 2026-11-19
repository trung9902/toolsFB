using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChuyenThuMuc : Form
{
	internal string AC2D52A9 = "";

	internal string string_0 = "";

	internal IContainer EC0193AB = null;

	internal BunifuCards DF2A6D28;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal ComboBox cbbThuMuc;

	internal Label label1;

	internal Button btnCancel;

	internal Button B0B6E233;

	internal PictureBox B9088D28;

	internal Button button1;

	internal BunifuDragControl B8251EA1;

	internal BunifuDragControl CB083130;

	public fChuyenThuMuc()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		AC2D52A9 = "";
		string_0 = "";
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ADBAF039(object sender, EventArgs e)
	{
		AC2D52A9 = cbbThuMuc.SelectedValue.ToString();
		string_0 = cbbThuMuc.Text.ToString();
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		fAddFile form_ = new fAddFile();
		Commom.smethod_35(form_);
		if (fAddFile.bool_0)
		{
			C908892B();
			cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 1;
		}
	}

	private void C908892B()
	{
		DataTable dataTable = CommonSQL.D0A8D8BC();
		if (dataTable.Rows.Count > 0)
		{
			cbbThuMuc.DataSource = dataTable;
			cbbThuMuc.ValueMember = "id";
			cbbThuMuc.DisplayMember = "Ten";
		}
	}

	private void fChuyenThuMuc_Load(object sender, EventArgs e)
	{
		C908892B();
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && EC0193AB != null)
		{
			EC0193AB.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		EC0193AB = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChuyenThuMuc));
		DF2A6D28 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		B9088D28 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		cbbThuMuc = new System.Windows.Forms.ComboBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		B0B6E233 = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		B8251EA1 = new Bunifu.Framework.UI.BunifuDragControl(EC0193AB);
		CB083130 = new Bunifu.Framework.UI.BunifuDragControl(EC0193AB);
		DF2A6D28.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B9088D28).BeginInit();
		SuspendLayout();
		DF2A6D28.BackColor = System.Drawing.Color.White;
		DF2A6D28.BorderRadius = 5;
		DF2A6D28.BottomSahddow = true;
		DF2A6D28.color = System.Drawing.Color.SaddleBrown;
		DF2A6D28.Controls.Add(pnlHeader);
		DF2A6D28.Dock = System.Windows.Forms.DockStyle.Top;
		DF2A6D28.LeftSahddow = false;
		DF2A6D28.Location = new System.Drawing.Point(0, 0);
		DF2A6D28.Name = "bunifuCards1";
		DF2A6D28.RightSahddow = true;
		DF2A6D28.ShadowDepth = 20;
		DF2A6D28.Size = new System.Drawing.Size(416, 38);
		DF2A6D28.TabIndex = 12;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(B9088D28);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(416, 32);
		pnlHeader.TabIndex = 9;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(382, -1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		B9088D28.Cursor = System.Windows.Forms.Cursors.Default;
		B9088D28.Image = Class155.DD225F0D;
		B9088D28.Location = new System.Drawing.Point(3, 1);
		B9088D28.Name = "pictureBox1";
		B9088D28.Size = new System.Drawing.Size(34, 27);
		B9088D28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B9088D28.TabIndex = 79;
		B9088D28.TabStop = false;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(416, 32);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Chọn thư mục";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbThuMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbThuMuc.DropDownWidth = 350;
		cbbThuMuc.FormattingEnabled = true;
		cbbThuMuc.ItemHeight = 16;
		cbbThuMuc.Items.AddRange(new object[10] { "Token", "Cookie", "Password", "Mail|pass", "PassMail", "2FA", "Birthday", "Useragent", "Proxy", "Notes" });
		cbbThuMuc.Location = new System.Drawing.Point(111, 66);
		cbbThuMuc.Name = "cbbThuMuc";
		cbbThuMuc.Size = new System.Drawing.Size(190, 24);
		cbbThuMuc.TabIndex = 13;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(42, 69);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(63, 16);
		label1.TabIndex = 14;
		label1.Text = "Thư mục:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(209, 108);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 18;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		B0B6E233.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B0B6E233.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		B0B6E233.Cursor = System.Windows.Forms.Cursors.Hand;
		B0B6E233.FlatAppearance.BorderSize = 0;
		B0B6E233.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B0B6E233.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B0B6E233.ForeColor = System.Drawing.Color.White;
		B0B6E233.Location = new System.Drawing.Point(111, 108);
		B0B6E233.Name = "btnAdd";
		B0B6E233.Size = new System.Drawing.Size(92, 29);
		B0B6E233.TabIndex = 17;
		B0B6E233.Text = "Lưu";
		B0B6E233.UseVisualStyleBackColor = false;
		B0B6E233.Click += new System.EventHandler(ADBAF039);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.Location = new System.Drawing.Point(307, 65);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(58, 26);
		button1.TabIndex = 19;
		button1.Text = "Thêm";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		B8251EA1.Fixed = true;
		B8251EA1.Horizontal = true;
		B8251EA1.TargetControl = pnlHeader;
		B8251EA1.Vertical = true;
		CB083130.Fixed = true;
		CB083130.Horizontal = true;
		CB083130.TargetControl = bunifuCustomLabel1;
		CB083130.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(416, 150);
		base.Controls.Add(button1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(B0B6E233);
		base.Controls.Add(label1);
		base.Controls.Add(cbbThuMuc);
		base.Controls.Add(DF2A6D28);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fChuyenThuMuc";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fUpdateData";
		base.Load += new System.EventHandler(fChuyenThuMuc_Load);
		DF2A6D28.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B9088D28).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
