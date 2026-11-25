using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fImportUseragent : Form
{
	internal IContainer A2B8CA1C = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button EC99EB99;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox AA1BFE20;

	internal Label label8;

	internal Label lblStatus;

	internal RichTextBox AA19EA33;

	internal Label label1;

	internal NumericUpDown nudTaiKhoanPerUa;

	internal CheckBox D72BED9C;

	internal Label label2;

	internal RadioButton F5ABFDAE;

	internal RadioButton AF9F1703;

	public fImportUseragent()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void A4325F34(object sender, EventArgs e)
	{
		Close();
	}

	private void AE090484(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = AA19EA33.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			List<string> list = new List<string>();
			if (list_.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p thêm Useragent!", 3);
				return;
			}
			int num = Convert.ToInt32(nudTaiKhoanPerUa.Value);
			for (int i = 0; i < list_.Count; i++)
			{
				for (int j = 0; j < num; j++)
				{
					list.Add(list_[i]);
				}
			}
			if (F5ABFDAE.Checked)
			{
				list = Commom.EBBFB196(list);
			}
			Queue<string> queue = new Queue<string>(list);
			for (int k = 0; k < fMain.fMain_0.F5325785.Rows.Count; k++)
			{
				if (Convert.ToBoolean(fMain.fMain_0.F6061E95(k, "cChose")) && (!(fMain.fMain_0.F6061E95(k, "cUseragent") != "") || !D72BED9C.Checked))
				{
					if (queue.Count == 0)
					{
						break;
					}
					string text = queue.Dequeue().Replace("'", "''");
					if (CommonSQL.B8A0E617(fMain.fMain_0.F6061E95(k, "cId"), "useragent", text))
					{
						fMain.fMain_0.B183E907(k, "cUseragent", text);
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

	private void D8284696(object sender, EventArgs e)
	{
		Close();
	}

	private void D587CA04(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			AE090484(null, null);
		}
	}

	private void AA19EA33_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = AA19EA33.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Useragent ({0}):"), list_.Count);
		}
		catch
		{
		}
	}

	protected override void Dispose(bool B59CEC9A)
	{
		if (B59CEC9A && A2B8CA1C != null)
		{
			A2B8CA1C.Dispose();
		}
		base.Dispose(B59CEC9A);
	}

	private void InitializeComponent()
	{
		A2B8CA1C = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fImportUseragent));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		AA1BFE20 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		EC99EB99 = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(A2B8CA1C);
		label8 = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		AA19EA33 = new System.Windows.Forms.RichTextBox();
		label1 = new System.Windows.Forms.Label();
		nudTaiKhoanPerUa = new System.Windows.Forms.NumericUpDown();
		D72BED9C = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		F5ABFDAE = new System.Windows.Forms.RadioButton();
		AF9F1703 = new System.Windows.Forms.RadioButton();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AA1BFE20).BeginInit();
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
		pnlHeader.Controls.Add(AA1BFE20);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(477, 32);
		pnlHeader.TabIndex = 9;
		AA1BFE20.Cursor = System.Windows.Forms.Cursors.Default;
		AA1BFE20.Image = Class155.DD225F0D;
		AA1BFE20.Location = new System.Drawing.Point(4, 1);
		AA1BFE20.Name = "pictureBox1";
		AA1BFE20.Size = new System.Drawing.Size(34, 27);
		AA1BFE20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AA1BFE20.TabIndex = 77;
		AA1BFE20.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(445, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(A4325F34);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(477, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Nhâ\u0323p Useragent";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(245, 342);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(D8284696);
		EC99EB99.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EC99EB99.Cursor = System.Windows.Forms.Cursors.Hand;
		EC99EB99.FlatAppearance.BorderSize = 0;
		EC99EB99.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EC99EB99.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EC99EB99.ForeColor = System.Drawing.Color.White;
		EC99EB99.Location = new System.Drawing.Point(136, 342);
		EC99EB99.Name = "btnAdd";
		EC99EB99.Size = new System.Drawing.Size(92, 29);
		EC99EB99.TabIndex = 3;
		EC99EB99.Text = "Xa\u0301c nhâ\u0323n";
		EC99EB99.UseVisualStyleBackColor = false;
		EC99EB99.Click += new System.EventHandler(AE090484);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(301, 252);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(141, 16);
		label8.TabIndex = 5;
		label8.Text = "(Mỗi useragent 1 dòng)";
		lblStatus.AutoSize = true;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatus.Location = new System.Drawing.Point(30, 47);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(154, 16);
		lblStatus.TabIndex = 6;
		lblStatus.Text = "Danh sa\u0301ch Useragent (0):";
		AA19EA33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AA19EA33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AA19EA33.Location = new System.Drawing.Point(34, 66);
		AA19EA33.Name = "txtUseragent";
		AA19EA33.Size = new System.Drawing.Size(409, 181);
		AA19EA33.TabIndex = 118;
		AA19EA33.Text = "";
		AA19EA33.WordWrap = false;
		AA19EA33.TextChanged += new System.EventHandler(AA19EA33_TextChanged);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(31, 252);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(146, 16);
		label1.TabIndex = 119;
		label1.Text = "Sô\u0301 ta\u0300i khoa\u0309n/Useragent:";
		nudTaiKhoanPerUa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		nudTaiKhoanPerUa.Location = new System.Drawing.Point(184, 250);
		nudTaiKhoanPerUa.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTaiKhoanPerUa.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudTaiKhoanPerUa.Name = "nudTaiKhoanPerUa";
		nudTaiKhoanPerUa.Size = new System.Drawing.Size(69, 23);
		nudTaiKhoanPerUa.TabIndex = 120;
		nudTaiKhoanPerUa.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		D72BED9C.AutoSize = true;
		D72BED9C.Cursor = System.Windows.Forms.Cursors.Hand;
		D72BED9C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D72BED9C.Location = new System.Drawing.Point(33, 303);
		D72BED9C.Name = "ckbKhongNhapTaiKhoanDaCo";
		D72BED9C.Size = new System.Drawing.Size(310, 20);
		D72BED9C.TabIndex = 121;
		D72BED9C.Text = "Không nhâ\u0323p va\u0300o như\u0303ng ta\u0300i khoa\u0309n đa\u0303 co\u0301 Useragent";
		D72BED9C.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(30, 279);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(158, 16);
		label2.TabIndex = 119;
		label2.Text = "Tu\u0300y cho\u0323n nhâ\u0323p Useragent:";
		F5ABFDAE.AutoSize = true;
		F5ABFDAE.Cursor = System.Windows.Forms.Cursors.Hand;
		F5ABFDAE.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F5ABFDAE.Location = new System.Drawing.Point(274, 277);
		F5ABFDAE.Name = "rbNgauNhien";
		F5ABFDAE.Size = new System.Drawing.Size(89, 20);
		F5ABFDAE.TabIndex = 122;
		F5ABFDAE.Text = "Ngâ\u0303u nhiên";
		F5ABFDAE.UseVisualStyleBackColor = true;
		AF9F1703.AutoSize = true;
		AF9F1703.Checked = true;
		AF9F1703.Cursor = System.Windows.Forms.Cursors.Hand;
		AF9F1703.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AF9F1703.Location = new System.Drawing.Point(184, 277);
		AF9F1703.Name = "rbLanLuot";
		AF9F1703.Size = new System.Drawing.Size(71, 20);
		AF9F1703.TabIndex = 122;
		AF9F1703.TabStop = true;
		AF9F1703.Text = "Lâ\u0300n lươ\u0323t";
		AF9F1703.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(477, 388);
		base.Controls.Add(AF9F1703);
		base.Controls.Add(F5ABFDAE);
		base.Controls.Add(D72BED9C);
		base.Controls.Add(nudTaiKhoanPerUa);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(AA19EA33);
		base.Controls.Add(label8);
		base.Controls.Add(lblStatus);
		base.Controls.Add(btnCancel);
		base.Controls.Add(EC99EB99);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fImportUseragent";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AA1BFE20).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
