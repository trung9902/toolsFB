using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fUpdateData2 : Form
{
	internal fQuanLyTinNhan fQuanLyTinNhan_0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel E1820A8D;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button B51BA5A6;

	internal ComboBox F6AFF703;

	internal Label C38B5F92;

	internal TextBox B88C3097;

	internal Label label2;

	internal Button E49498B7;

	internal Button B80A5D04;

	internal PictureBox pictureBox1;

	internal Label label3;

	internal ComboBox cbbTypeProxy;

	public fUpdateData2(fQuanLyTinNhan fQuanLyTinNhan_1, string string_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		fQuanLyTinNhan_0 = fQuanLyTinNhan_1;
		F6AFF703.Text = string_0;
		cbbTypeProxy.SelectedIndex = 0;
	}

	private void B51BA5A6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BB182A28(object sender, EventArgs e)
	{
		Close();
	}

	private void ED1C579B(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			if (B88C3097.Text.Equals("") || B88C3097.Text.Equals("|"))
			{
				if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n xo\u0301a dư\u0303 liê\u0323u của {0} tài khoản?"), fQuanLyTinNhan_0.method_0())) == DialogResult.Yes)
				{
					flag = true;
				}
			}
			else if (MsBoxHelper.D41C45AC(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n câ\u0323p nhâ\u0323t dư\u0303 liê\u0323u của {0} tài khoản?"), fQuanLyTinNhan_0.method_0())) == DialogResult.Yes)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			List<string> list = new List<string>();
			string text = B88C3097.Text;
			for (int i = 0; i < fQuanLyTinNhan_0.dgvTaiKhoan.SelectedRows.Count; i++)
			{
				list.Add(fQuanLyTinNhan_0.method_1(fQuanLyTinNhan_0.dgvTaiKhoan.SelectedRows[i].Index, "cId"));
			}
			string text2 = F6AFF703.Text;
			string text3 = text2;
			if (text3 == "Notes" && CommonSQL.smethod_10(list, "ghiChu", text))
			{
				for (int j = 0; j < fQuanLyTinNhan_0.dgvTaiKhoan.SelectedRows.Count; j++)
				{
					fQuanLyTinNhan_0.D2220818(fQuanLyTinNhan_0.dgvTaiKhoan.SelectedRows[j].Index, "cGhiChu", text);
				}
			}
			Close();
		}
		catch
		{
			MsBoxHelper.Show("Vui lòng thử lại sau!", 2);
		}
	}

	private void F6AFF703_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool visible = F6AFF703.Text == "Proxy";
		label3.Visible = visible;
		cbbTypeProxy.Visible = visible;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUpdateData2));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		E1820A8D = new System.Windows.Forms.Panel();
		B51BA5A6 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		F6AFF703 = new System.Windows.Forms.ComboBox();
		C38B5F92 = new System.Windows.Forms.Label();
		B88C3097 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		E49498B7 = new System.Windows.Forms.Button();
		B80A5D04 = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		cbbTypeProxy = new System.Windows.Forms.ComboBox();
		bunifuCards1.SuspendLayout();
		E1820A8D.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 5;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(E1820A8D);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(416, 38);
		bunifuCards1.TabIndex = 12;
		E1820A8D.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E1820A8D.BackColor = System.Drawing.Color.White;
		E1820A8D.Controls.Add(B51BA5A6);
		E1820A8D.Controls.Add(pictureBox1);
		E1820A8D.Controls.Add(bunifuCustomLabel1);
		E1820A8D.Location = new System.Drawing.Point(0, 5);
		E1820A8D.Name = "pnlHeader";
		E1820A8D.Size = new System.Drawing.Size(416, 32);
		E1820A8D.TabIndex = 9;
		B51BA5A6.Cursor = System.Windows.Forms.Cursors.Hand;
		B51BA5A6.FlatAppearance.BorderSize = 0;
		B51BA5A6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B51BA5A6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B51BA5A6.ForeColor = System.Drawing.Color.White;
		B51BA5A6.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		B51BA5A6.Location = new System.Drawing.Point(382, -1);
		B51BA5A6.Name = "btnMinimize";
		B51BA5A6.Size = new System.Drawing.Size(32, 32);
		B51BA5A6.TabIndex = 9;
		B51BA5A6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B51BA5A6.UseVisualStyleBackColor = true;
		B51BA5A6.Click += new System.EventHandler(B51BA5A6_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 79;
		pictureBox1.TabStop = false;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(416, 32);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cập nhật dữ liệu";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F6AFF703.Cursor = System.Windows.Forms.Cursors.Hand;
		F6AFF703.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F6AFF703.FormattingEnabled = true;
		F6AFF703.ItemHeight = 16;
		F6AFF703.Items.AddRange(new object[10] { "Token", "Cookie", "Password", "Mail|pass", "PassMail", "2FA", "Birthday", "Useragent", "Proxy", "Notes" });
		F6AFF703.Location = new System.Drawing.Point(146, 43);
		F6AFF703.Name = "cbbTypeUpdate";
		F6AFF703.Size = new System.Drawing.Size(238, 24);
		F6AFF703.TabIndex = 13;
		F6AFF703.SelectedIndexChanged += new System.EventHandler(F6AFF703_SelectedIndexChanged);
		C38B5F92.AutoSize = true;
		C38B5F92.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C38B5F92.Location = new System.Drawing.Point(34, 46);
		C38B5F92.Name = "label1";
		C38B5F92.Size = new System.Drawing.Size(105, 16);
		C38B5F92.TabIndex = 14;
		C38B5F92.Text = "Dữ liệu cập nhật:";
		B88C3097.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B88C3097.Location = new System.Drawing.Point(146, 73);
		B88C3097.Name = "txbData";
		B88C3097.Size = new System.Drawing.Size(238, 23);
		B88C3097.TabIndex = 15;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(34, 76);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 16;
		label2.Text = "Nhập dữ liệu:";
		E49498B7.BackColor = System.Drawing.Color.Maroon;
		E49498B7.Cursor = System.Windows.Forms.Cursors.Hand;
		E49498B7.FlatAppearance.BorderSize = 0;
		E49498B7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E49498B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E49498B7.ForeColor = System.Drawing.Color.White;
		E49498B7.Location = new System.Drawing.Point(209, 139);
		E49498B7.Name = "btnCancel";
		E49498B7.Size = new System.Drawing.Size(92, 29);
		E49498B7.TabIndex = 18;
		E49498B7.Text = "Đóng";
		E49498B7.UseVisualStyleBackColor = false;
		E49498B7.Click += new System.EventHandler(BB182A28);
		B80A5D04.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		B80A5D04.Cursor = System.Windows.Forms.Cursors.Hand;
		B80A5D04.FlatAppearance.BorderSize = 0;
		B80A5D04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B80A5D04.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B80A5D04.ForeColor = System.Drawing.Color.White;
		B80A5D04.Location = new System.Drawing.Point(111, 139);
		B80A5D04.Name = "btnAdd";
		B80A5D04.Size = new System.Drawing.Size(92, 29);
		B80A5D04.TabIndex = 17;
		B80A5D04.Text = "Lưu";
		B80A5D04.UseVisualStyleBackColor = false;
		B80A5D04.Click += new System.EventHandler(ED1C579B);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(34, 105);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(70, 16);
		label3.TabIndex = 16;
		label3.Text = "Loại proxy:";
		cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbTypeProxy.FormattingEnabled = true;
		cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
		cbbTypeProxy.Location = new System.Drawing.Point(146, 102);
		cbbTypeProxy.Name = "cbbTypeProxy";
		cbbTypeProxy.Size = new System.Drawing.Size(130, 24);
		cbbTypeProxy.TabIndex = 124;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(416, 181);
		base.Controls.Add(cbbTypeProxy);
		base.Controls.Add(E49498B7);
		base.Controls.Add(B80A5D04);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(B88C3097);
		base.Controls.Add(C38B5F92);
		base.Controls.Add(F6AFF703);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fUpdateData2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fUpdateData";
		bunifuCards1.ResumeLayout(false);
		E1820A8D.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
