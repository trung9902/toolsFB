using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhTaiAnhTuNhom : Form
{
	internal bool BC854A35 = false;

	internal IContainer B60FC12B = null;

	internal BunifuCards E935848B;

	internal Panel B3A6C42F;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button C0B12389;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal NumericUpDown nudSoLuong;

	internal Label A51A4037;

	internal TextBox txtFolderPath;

	internal Label label2;

	internal Label lblIdNhom;

	internal RichTextBox txtIdNhom;

	public fCauHinhTaiAnhTuNhom()
	{
		InitializeComponent();
		BC854A35 = false;
		Language.CD21F0A9(this);
	}

	private void E8089C00(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configTaiAnhTuNhom").method_4("txtIdNhom", txtIdNhom.Text.Trim());
		C5034B95.smethod_0("configTaiAnhTuNhom").method_4("nudSoLuong", nudSoLuong.Value);
		C5034B95.smethod_0("configTaiAnhTuNhom").method_4("txtFolderPath", txtFolderPath.Text.Trim());
		C5034B95.smethod_1("configTaiAnhTuNhom");
		BC854A35 = true;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhTaiAnhTuNhom_Load(object sender, EventArgs e)
	{
		txtIdNhom.Text = C5034B95.smethod_0("configTaiAnhTuNhom").BDB80B23("txtIdNhom");
		nudSoLuong.Value = C5034B95.smethod_0("configTaiAnhTuNhom").method_2("nudSoLuong", 100);
		txtFolderPath.Text = C5034B95.smethod_0("configTaiAnhTuNhom").BDB80B23("txtFolderPath");
	}

	private void lblIdNhom_Click(object sender, EventArgs e)
	{
	}

	private void nudSoLuong_ValueChanged(object sender, EventArgs e)
	{
	}

	private void txtIdNhom_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdNhom, lblIdNhom);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && B60FC12B != null)
		{
			B60FC12B.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		B60FC12B = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhTaiAnhTuNhom));
		E935848B = new Bunifu.Framework.UI.BunifuCards();
		B3A6C42F = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		C0B12389 = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B60FC12B);
		nudSoLuong = new System.Windows.Forms.NumericUpDown();
		A51A4037 = new System.Windows.Forms.Label();
		txtFolderPath = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		lblIdNhom = new System.Windows.Forms.Label();
		txtIdNhom = new System.Windows.Forms.RichTextBox();
		E935848B.SuspendLayout();
		B3A6C42F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
		SuspendLayout();
		E935848B.BackColor = System.Drawing.Color.White;
		E935848B.BorderRadius = 0;
		E935848B.BottomSahddow = true;
		E935848B.color = System.Drawing.Color.SaddleBrown;
		E935848B.Controls.Add(B3A6C42F);
		E935848B.Dock = System.Windows.Forms.DockStyle.Top;
		E935848B.LeftSahddow = false;
		E935848B.Location = new System.Drawing.Point(0, 0);
		E935848B.Name = "bunifuCards1";
		E935848B.RightSahddow = true;
		E935848B.ShadowDepth = 20;
		E935848B.Size = new System.Drawing.Size(296, 38);
		E935848B.TabIndex = 0;
		B3A6C42F.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B3A6C42F.BackColor = System.Drawing.Color.White;
		B3A6C42F.Controls.Add(pictureBox1);
		B3A6C42F.Controls.Add(C0B12389);
		B3A6C42F.Controls.Add(bunifuCustomLabel1);
		B3A6C42F.Location = new System.Drawing.Point(0, 5);
		B3A6C42F.Name = "pnlHeader";
		B3A6C42F.Size = new System.Drawing.Size(296, 32);
		B3A6C42F.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		C0B12389.Cursor = System.Windows.Forms.Cursors.Hand;
		C0B12389.Dock = System.Windows.Forms.DockStyle.Right;
		C0B12389.FlatAppearance.BorderSize = 0;
		C0B12389.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C0B12389.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C0B12389.ForeColor = System.Drawing.Color.White;
		C0B12389.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		C0B12389.Location = new System.Drawing.Point(264, 0);
		C0B12389.Name = "btnMinimize";
		C0B12389.Size = new System.Drawing.Size(32, 32);
		C0B12389.TabIndex = 9;
		C0B12389.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		C0B12389.UseVisualStyleBackColor = true;
		C0B12389.Click += new System.EventHandler(E8089C00);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(296, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh Ta\u0309i a\u0309nh tư\u0300 nho\u0301m";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(156, 278);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(52, 278);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		nudSoLuong.Location = new System.Drawing.Point(156, 211);
		nudSoLuong.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		nudSoLuong.Name = "nudSoLuong";
		nudSoLuong.Size = new System.Drawing.Size(112, 23);
		nudSoLuong.TabIndex = 1;
		nudSoLuong.ValueChanged += new System.EventHandler(nudSoLuong_ValueChanged);
		A51A4037.AutoSize = true;
		A51A4037.Location = new System.Drawing.Point(25, 213);
		A51A4037.Name = "label1";
		A51A4037.Size = new System.Drawing.Size(125, 16);
		A51A4037.TabIndex = 0;
		A51A4037.Text = "Sô\u0301 lươ\u0323ng a\u0309nh/nho\u0301m:";
		A51A4037.Click += new System.EventHandler(lblIdNhom_Click);
		txtFolderPath.Location = new System.Drawing.Point(93, 240);
		txtFolderPath.Name = "txtFolderPath";
		txtFolderPath.Size = new System.Drawing.Size(175, 23);
		txtFolderPath.TabIndex = 1;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(24, 243);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(70, 16);
		label2.TabIndex = 0;
		label2.Text = "Folder lưu:";
		lblIdNhom.AutoSize = true;
		lblIdNhom.Location = new System.Drawing.Point(25, 51);
		lblIdNhom.Name = "lblIdNhom";
		lblIdNhom.Size = new System.Drawing.Size(143, 16);
		lblIdNhom.TabIndex = 0;
		lblIdNhom.Text = "Danh sa\u0301ch Id nho\u0301m (0):";
		lblIdNhom.Click += new System.EventHandler(lblIdNhom_Click);
		txtIdNhom.Location = new System.Drawing.Point(28, 71);
		txtIdNhom.Name = "txtIdNhom";
		txtIdNhom.Size = new System.Drawing.Size(240, 134);
		txtIdNhom.TabIndex = 5;
		txtIdNhom.Text = "";
		txtIdNhom.WordWrap = false;
		txtIdNhom.TextChanged += new System.EventHandler(txtIdNhom_TextChanged);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(296, 320);
		base.Controls.Add(txtIdNhom);
		base.Controls.Add(txtFolderPath);
		base.Controls.Add(label2);
		base.Controls.Add(nudSoLuong);
		base.Controls.Add(lblIdNhom);
		base.Controls.Add(A51A4037);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(E935848B);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhTaiAnhTuNhom";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhTaiAnhTuNhom_Load);
		E935848B.ResumeLayout(false);
		B3A6C42F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
