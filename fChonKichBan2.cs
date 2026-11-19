using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChonKichBan2 : Form
{
	internal string string_0 = "";

	internal IContainer D4B977AA = null;

	internal BunifuCards D28C98AD;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button C3862D96;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal ComboBox cbbKichBan;

	internal Button btnQuanLyKichBan;

	internal Label label1;

	internal Panel panel1;

	public fChonKichBan2()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B724E988(object sender, EventArgs e)
	{
		Close();
	}

	private void C3862D96_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Bạn có thực sự muốn chọn kịch bản [{0}] không?"), cbbKichBan.Text)) == DialogResult.Yes)
		{
			string_0 = cbbKichBan.SelectedValue.ToString();
			Close();
		}
	}

	private void C8A2D0A2(object sender, EventArgs e)
	{
		Close();
	}

	private void F6931F2F(object sender, EventArgs e)
	{
		string b0BFABAD = "";
		try
		{
			if (cbbKichBan.Items.Count > 0)
			{
				b0BFABAD = cbbKichBan.SelectedValue.ToString();
			}
		}
		catch
		{
		}
		Commom.smethod_35(new fDanhSachKichBan_Old(b0BFABAD));
		method_2();
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void E021B598(object sender, EventArgs e)
	{
	}

	private void method_1()
	{
		method_0(null, null);
		E021B598(null, null);
		method_3(null, null);
		E987E707(null, null);
		method_4(null, null);
		method_5(null, null);
		method_6(null, null);
	}

	private void A7AB2C3D(object sender, EventArgs e)
	{
		method_2();
		method_1();
	}

	private void method_2()
	{
		int num = -1;
		if (cbbKichBan.SelectedIndex != -1)
		{
			num = cbbKichBan.SelectedIndex;
		}
		DataTable dataSource = Class154.smethod_2();
		cbbKichBan.DataSource = dataSource;
		cbbKichBan.ValueMember = "Id_KichBan";
		cbbKichBan.DisplayMember = "Ten";
		if (num != -1 && num != 0 && cbbKichBan.Items.Count >= num + 1)
		{
			cbbKichBan.SelectedIndex = num;
		}
		else if (cbbKichBan.Items.Count > 0)
		{
			cbbKichBan.SelectedIndex = 0;
		}
	}

	private void E30C2937(object sender, PaintEventArgs e)
	{
	}

	private void C4A89218(object sender, EventArgs e)
	{
	}

	private void E987E707(object sender, EventArgs e)
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

	private void method_6(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D4B977AA != null)
		{
			D4B977AA.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D4B977AA = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChonKichBan2));
		D28C98AD = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		C3862D96 = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D4B977AA);
		label1 = new System.Windows.Forms.Label();
		btnQuanLyKichBan = new System.Windows.Forms.Button();
		cbbKichBan = new System.Windows.Forms.ComboBox();
		panel1 = new System.Windows.Forms.Panel();
		D28C98AD.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		SuspendLayout();
		D28C98AD.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D28C98AD.BackColor = System.Drawing.Color.White;
		D28C98AD.BorderRadius = 0;
		D28C98AD.BottomSahddow = true;
		D28C98AD.color = System.Drawing.Color.FromArgb(24, 119, 242);
		D28C98AD.Controls.Add(pnlHeader);
		D28C98AD.LeftSahddow = false;
		D28C98AD.Location = new System.Drawing.Point(2, 1);
		D28C98AD.Name = "bunifuCards1";
		D28C98AD.RightSahddow = true;
		D28C98AD.ShadowDepth = 20;
		D28C98AD.Size = new System.Drawing.Size(434, 38);
		D28C98AD.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(434, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 78;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(C4A89218);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(400, -2);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(B724E988);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(434, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Chọn kịch bản";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(222, 96);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(C8A2D0A2);
		C3862D96.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C3862D96.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		C3862D96.Cursor = System.Windows.Forms.Cursors.Hand;
		C3862D96.FlatAppearance.BorderSize = 0;
		C3862D96.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C3862D96.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C3862D96.ForeColor = System.Drawing.Color.White;
		C3862D96.Location = new System.Drawing.Point(124, 96);
		C3862D96.Name = "btnAdd";
		C3862D96.Size = new System.Drawing.Size(92, 29);
		C3862D96.TabIndex = 3;
		C3862D96.Text = "Lưu";
		C3862D96.UseVisualStyleBackColor = false;
		C3862D96.Click += new System.EventHandler(C3862D96_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(25, 59);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(92, 16);
		label1.TabIndex = 0;
		label1.Text = "Chọn kịch bản:";
		btnQuanLyKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		btnQuanLyKichBan.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnQuanLyKichBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnQuanLyKichBan.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnQuanLyKichBan.Location = new System.Drawing.Point(294, 56);
		btnQuanLyKichBan.Name = "btnQuanLyKichBan";
		btnQuanLyKichBan.Size = new System.Drawing.Size(112, 24);
		btnQuanLyKichBan.TabIndex = 1;
		btnQuanLyKichBan.Text = "Quản lý kịch bản";
		btnQuanLyKichBan.Click += new System.EventHandler(F6931F2F);
		cbbKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbKichBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbKichBan.DropDownWidth = 300;
		cbbKichBan.FormattingEnabled = true;
		cbbKichBan.Location = new System.Drawing.Point(124, 56);
		cbbKichBan.Name = "cbbKichBan";
		cbbKichBan.Size = new System.Drawing.Size(164, 24);
		cbbKichBan.TabIndex = 1;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(C3862D96);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(cbbKichBan);
		panel1.Controls.Add(btnQuanLyKichBan);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(436, 138);
		panel1.TabIndex = 8;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(E30C2937);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(436, 138);
		base.Controls.Add(D28C98AD);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fChonKichBan2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(A7AB2C3D);
		D28C98AD.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
	}
}
