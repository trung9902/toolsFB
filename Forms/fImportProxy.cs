using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fImportProxy : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button E4AD448D;

	internal Button D507FFAD;

	internal Button btnAdd;

	internal BunifuDragControl B5247339;

	internal PictureBox pictureBox1;

	internal Label label8;

	internal Label lblStatus;

	internal RichTextBox txtProxy;

	internal Label B80C1983;

	internal NumericUpDown nudTaiKhoanPerUa;

	internal CheckBox ckbKhongNhapTaiKhoanDaCo;

	internal Label label2;

	internal RadioButton rbNgauNhien;

	internal RadioButton rbLanLuot;

	internal Label E1B8AC08;

	internal ComboBox cbbTypeProxy;

	public fImportProxy()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		cbbTypeProxy.SelectedIndex = 0;
	}

	private void E4AD448D_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtProxy.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			List<string> list = new List<string>();
			if (list_.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p thêm Proxy!", 3);
				return;
			}
			int num = Convert.ToInt32(nudTaiKhoanPerUa.Value);
			for (int i = 0; i < num; i++)
			{
				list.AddRange(list_);
			}
			if (rbNgauNhien.Checked)
			{
				list = Commom.EBBFB196(list);
			}
			Queue<string> queue = new Queue<string>(list);
			int selectedIndex = cbbTypeProxy.SelectedIndex;
			List<string> list2 = new List<string>();
			for (int j = 0; j < fMain.fMain_0.F5325785.Rows.Count; j++)
			{
				if (Convert.ToBoolean(fMain.fMain_0.F6061E95(j, "cChose")) && (!(fMain.fMain_0.F6061E95(j, "cProxy") != "") || !ckbKhongNhapTaiKhoanDaCo.Checked))
				{
					if (queue.Count == 0)
					{
						break;
					}
					string text = (queue.Dequeue() + "*" + selectedIndex).Replace("'", "''");
					list2.Add(fMain.fMain_0.F6061E95(j, "cId") + "|" + text);
				}
			}
			if (CommonSQL.smethod_5("proxy", list2))
			{
				queue = new Queue<string>(list);
				for (int k = 0; k < fMain.fMain_0.F5325785.Rows.Count; k++)
				{
					if (Convert.ToBoolean(fMain.fMain_0.F6061E95(k, "cChose")) && (!(fMain.fMain_0.F6061E95(k, "cProxy") != "") || !ckbKhongNhapTaiKhoanDaCo.Checked))
					{
						if (queue.Count == 0)
						{
							break;
						}
						string object_ = (queue.Dequeue() + "*" + selectedIndex).Replace("'", "''");
						fMain.fMain_0.B183E907(k, "cProxy", object_);
					}
				}
			}
			if (MsBoxHelper.D41C45AC("Nhâ\u0323p thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
			{
				Close();
			}
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void ED07AEBD(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			btnAdd_Click(null, null);
		}
	}

	private void txtProxy_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtProxy.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Proxy ({0}):"), list_.Count.ToString());
		}
		catch
		{
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fImportProxy));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E4AD448D = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		D507FFAD = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		B5247339 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		label8 = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		txtProxy = new System.Windows.Forms.RichTextBox();
		B80C1983 = new System.Windows.Forms.Label();
		nudTaiKhoanPerUa = new System.Windows.Forms.NumericUpDown();
		ckbKhongNhapTaiKhoanDaCo = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		rbNgauNhien = new System.Windows.Forms.RadioButton();
		rbLanLuot = new System.Windows.Forms.RadioButton();
		E1B8AC08 = new System.Windows.Forms.Label();
		cbbTypeProxy = new System.Windows.Forms.ComboBox();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(477, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(E4AD448D);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(477, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(4, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 77;
		pictureBox1.TabStop = false;
		E4AD448D.Cursor = System.Windows.Forms.Cursors.Hand;
		E4AD448D.Dock = System.Windows.Forms.DockStyle.Right;
		E4AD448D.FlatAppearance.BorderSize = 0;
		E4AD448D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E4AD448D.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E4AD448D.ForeColor = System.Drawing.Color.White;
		E4AD448D.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		E4AD448D.Location = new System.Drawing.Point(445, 0);
		E4AD448D.Name = "btnMinimize";
		E4AD448D.Size = new System.Drawing.Size(32, 32);
		E4AD448D.TabIndex = 9;
		E4AD448D.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E4AD448D.UseVisualStyleBackColor = true;
		E4AD448D.Click += new System.EventHandler(E4AD448D_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(477, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Nhâ\u0323p Proxy";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D507FFAD.BackColor = System.Drawing.Color.Maroon;
		D507FFAD.Cursor = System.Windows.Forms.Cursors.Hand;
		D507FFAD.FlatAppearance.BorderSize = 0;
		D507FFAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D507FFAD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D507FFAD.ForeColor = System.Drawing.Color.White;
		D507FFAD.Location = new System.Drawing.Point(244, 386);
		D507FFAD.Name = "btnCancel";
		D507FFAD.Size = new System.Drawing.Size(92, 29);
		D507FFAD.TabIndex = 4;
		D507FFAD.Text = "Đo\u0301ng";
		D507FFAD.UseVisualStyleBackColor = false;
		D507FFAD.Click += new System.EventHandler(ED07AEBD);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(135, 386);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Xa\u0301c nhâ\u0323n";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		B5247339.Fixed = true;
		B5247339.Horizontal = true;
		B5247339.TargetControl = bunifuCustomLabel1;
		B5247339.Vertical = true;
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(331, 252);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(115, 16);
		label8.TabIndex = 5;
		label8.Text = "(Mỗi proxy 1 dòng)";
		lblStatus.AutoSize = true;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatus.Location = new System.Drawing.Point(30, 47);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(127, 16);
		lblStatus.TabIndex = 6;
		lblStatus.Text = "Danh sa\u0301ch Proxy (0):";
		txtProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtProxy.Location = new System.Drawing.Point(34, 66);
		txtProxy.Name = "txtProxy";
		txtProxy.Size = new System.Drawing.Size(409, 181);
		txtProxy.TabIndex = 118;
		txtProxy.Text = "";
		txtProxy.WordWrap = false;
		txtProxy.TextChanged += new System.EventHandler(txtProxy_TextChanged);
		B80C1983.AutoSize = true;
		B80C1983.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B80C1983.Location = new System.Drawing.Point(31, 298);
		B80C1983.Name = "label1";
		B80C1983.Size = new System.Drawing.Size(119, 16);
		B80C1983.TabIndex = 119;
		B80C1983.Text = "Sô\u0301 ta\u0300i khoa\u0309n/proxy:";
		nudTaiKhoanPerUa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		nudTaiKhoanPerUa.Location = new System.Drawing.Point(157, 296);
		nudTaiKhoanPerUa.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTaiKhoanPerUa.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudTaiKhoanPerUa.Name = "nudTaiKhoanPerUa";
		nudTaiKhoanPerUa.Size = new System.Drawing.Size(69, 23);
		nudTaiKhoanPerUa.TabIndex = 120;
		nudTaiKhoanPerUa.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		ckbKhongNhapTaiKhoanDaCo.AutoSize = true;
		ckbKhongNhapTaiKhoanDaCo.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKhongNhapTaiKhoanDaCo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbKhongNhapTaiKhoanDaCo.Location = new System.Drawing.Point(33, 349);
		ckbKhongNhapTaiKhoanDaCo.Name = "ckbKhongNhapTaiKhoanDaCo";
		ckbKhongNhapTaiKhoanDaCo.Size = new System.Drawing.Size(283, 20);
		ckbKhongNhapTaiKhoanDaCo.TabIndex = 121;
		ckbKhongNhapTaiKhoanDaCo.Text = "Không nhâ\u0323p va\u0300o như\u0303ng ta\u0300i khoa\u0309n đa\u0303 co\u0301 Proxy";
		ckbKhongNhapTaiKhoanDaCo.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(30, 325);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(131, 16);
		label2.TabIndex = 119;
		label2.Text = "Tu\u0300y cho\u0323n nhâ\u0323p Proxy:";
		rbNgauNhien.AutoSize = true;
		rbNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbNgauNhien.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbNgauNhien.Location = new System.Drawing.Point(246, 323);
		rbNgauNhien.Name = "rbNgauNhien";
		rbNgauNhien.Size = new System.Drawing.Size(89, 20);
		rbNgauNhien.TabIndex = 122;
		rbNgauNhien.Text = "Ngâ\u0303u nhiên";
		rbNgauNhien.UseVisualStyleBackColor = true;
		rbLanLuot.AutoSize = true;
		rbLanLuot.Checked = true;
		rbLanLuot.Cursor = System.Windows.Forms.Cursors.Hand;
		rbLanLuot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbLanLuot.Location = new System.Drawing.Point(157, 323);
		rbLanLuot.Name = "rbLanLuot";
		rbLanLuot.Size = new System.Drawing.Size(71, 20);
		rbLanLuot.TabIndex = 122;
		rbLanLuot.TabStop = true;
		rbLanLuot.Text = "Lâ\u0300n lươ\u0323t";
		rbLanLuot.UseVisualStyleBackColor = true;
		E1B8AC08.AutoSize = true;
		E1B8AC08.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E1B8AC08.Location = new System.Drawing.Point(31, 267);
		E1B8AC08.Name = "label3";
		E1B8AC08.Size = new System.Drawing.Size(70, 16);
		E1B8AC08.TabIndex = 119;
		E1B8AC08.Text = "Loa\u0323i Proxy:";
		cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cbbTypeProxy.FormattingEnabled = true;
		cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
		cbbTypeProxy.Location = new System.Drawing.Point(157, 264);
		cbbTypeProxy.Name = "cbbTypeProxy";
		cbbTypeProxy.Size = new System.Drawing.Size(140, 24);
		cbbTypeProxy.TabIndex = 123;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(477, 432);
		base.Controls.Add(cbbTypeProxy);
		base.Controls.Add(rbLanLuot);
		base.Controls.Add(rbNgauNhien);
		base.Controls.Add(ckbKhongNhapTaiKhoanDaCo);
		base.Controls.Add(nudTaiKhoanPerUa);
		base.Controls.Add(label2);
		base.Controls.Add(E1B8AC08);
		base.Controls.Add(B80C1983);
		base.Controls.Add(txtProxy);
		base.Controls.Add(label8);
		base.Controls.Add(lblStatus);
		base.Controls.Add(D507FFAD);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fImportProxy";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
