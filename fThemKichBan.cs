using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fThemKichBan : Form
{
	internal int AB996E93 = 0;

	internal string F7310CB7 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel B5056E93;

	internal Button button1;

	internal Label label2;

	internal Button btnCancel;

	internal Button btnAdd;

	internal TextBox txtTen;

	internal Panel DD164906;

	public fThemKichBan(int A52B23AE, string string_0 = "")
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		AB996E93 = A52B23AE;
		F7310CB7 = string_0;
		if (A52B23AE == 1)
		{
			B5056E93.Text = Language.GetValue("Câ\u0323p nhâ\u0323t ki\u0323ch ba\u0309n");
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTen.Text = Class154.smethod_1(string_0).Rows[0]["TenKichBan"].ToString();
		}
	}

	private void EBA7D934(object sender, EventArgs e)
	{
	}

	private void E12F9DBD(object sender, EventArgs e)
	{
		Close();
	}

	private void F60BC23C(object sender, EventArgs e)
	{
		string text = txtTen.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ki\u0323ch ba\u0309n!", 2);
		}
		else if (AB996E93 == 0)
		{
			string text2 = "";
			try
			{
				text2 = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Kich_Ban ORDER BY STT DESC LIMIT 1").Rows[0]["STT"].ToString();
			}
			catch
			{
			}
			text2 = ((text2 == "") ? "1" : (Convert.ToInt32(text2) + 1).ToString());
			if (Class154.smethod_5(text, text2))
			{
				Close();
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
		else if (Class154.smethod_6(F7310CB7, text))
		{
			Close();
		}
		else
		{
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void F9AA4F0A(object sender, EventArgs e)
	{
		Close();
	}

	private void E18C10A7(object sender, PaintEventArgs e)
	{
		if (DD164906.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, DD164906.ClientSize.Width - num, DD164906.ClientSize.Height - num));
		}
	}

	private void txtTen_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			F60BC23C(null, null);
		}
	}

	protected override void Dispose(bool DD0C2314)
	{
		if (DD0C2314 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(DD0C2314);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemKichBan));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		B5056E93 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		txtTen = new System.Windows.Forms.TextBox();
		DD164906 = new System.Windows.Forms.Panel();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = B5056E93;
		bunifuDragControl_0.Vertical = true;
		B5056E93.BackColor = System.Drawing.Color.Transparent;
		B5056E93.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B5056E93.Dock = System.Windows.Forms.DockStyle.Fill;
		B5056E93.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B5056E93.ForeColor = System.Drawing.Color.Black;
		B5056E93.Location = new System.Drawing.Point(0, 0);
		B5056E93.Name = "bunifuCustomLabel1";
		B5056E93.Size = new System.Drawing.Size(324, 31);
		B5056E93.TabIndex = 12;
		B5056E93.Text = "Thêm kịch bản";
		B5056E93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(B5056E93);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(1, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(324, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(293, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(E12F9DBD);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(2, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(327, 37);
		bunifuCards1.TabIndex = 12;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label2.Location = new System.Drawing.Point(32, 55);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(85, 16);
		label2.TabIndex = 24;
		label2.Text = "Tên kịch bản:";
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(171, 96);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 2;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F9AA4F0A);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(67, 96);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 1;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(F60BC23C);
		txtTen.Location = new System.Drawing.Point(124, 52);
		txtTen.Name = "txtTen";
		txtTen.Size = new System.Drawing.Size(171, 23);
		txtTen.TabIndex = 0;
		txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(txtTen_KeyDown);
		DD164906.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DD164906.Dock = System.Windows.Forms.DockStyle.Fill;
		DD164906.Location = new System.Drawing.Point(0, 0);
		DD164906.Name = "panel1";
		DD164906.Size = new System.Drawing.Size(330, 137);
		DD164906.TabIndex = 25;
		DD164906.Paint += new System.Windows.Forms.PaintEventHandler(E18C10A7);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(330, 137);
		base.Controls.Add(label2);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(txtTen);
		base.Controls.Add(bunifuCards1);
		base.Controls.Add(DD164906);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fThemKichBan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(EBA7D934);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}
