using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapMailAdd : Form
{
	internal string B1312F3B = "configschange\\addmail\\hotmail.txt";

	internal string string_0 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuCards CD317C12;

	internal Panel C512DB95;

	internal BunifuDragControl C0167F9F;

	internal BunifuCards bunifuCards2;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal Button E529A2BA;

	internal BunifuCustomLabel D1A21D25;

	internal Label AFAF9830;

	internal Button C11ADF99;

	internal Button EB334198;

	internal Label AC93A4B9;

	internal RichTextBox txtComment;

	internal Label label3;

	internal Label label4;

	internal Label label2;

	internal Label label1;

	public fNhapMailAdd()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		Commom.EF994A31(B1312F3B);
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void fNhapMailAdd_Load(object sender, EventArgs e)
	{
		txtComment.Lines = File.ReadAllLines(B1312F3B);
	}

	private void BFBF66BC(object sender, EventArgs e)
	{
	}

	private void C512DB95_Paint(object sender, PaintEventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void DA2C9323(object sender, EventArgs e)
	{
		try
		{
			File.WriteAllText(B1312F3B, txtComment.Text.Trim());
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

	private void C11ADF99_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void txtComment_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtComment.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			AFAF9830.Text = "Danh sách Email (" + list_.Count + "):";
		}
		catch
		{
		}
	}

	protected override void Dispose(bool D60C5D9C)
	{
		if (D60C5D9C && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D60C5D9C);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		CD317C12 = new Bunifu.Framework.UI.BunifuCards();
		C512DB95 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txtComment = new System.Windows.Forms.RichTextBox();
		AC93A4B9 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		AFAF9830 = new System.Windows.Forms.Label();
		C11ADF99 = new System.Windows.Forms.Button();
		EB334198 = new System.Windows.Forms.Button();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E529A2BA = new System.Windows.Forms.Button();
		D1A21D25 = new Bunifu.Framework.UI.BunifuCustomLabel();
		C0167F9F = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		C512DB95.SuspendLayout();
		bunifuCards2.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		CD317C12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CD317C12.BackColor = System.Drawing.Color.White;
		CD317C12.BorderRadius = 5;
		CD317C12.BottomSahddow = true;
		CD317C12.color = System.Drawing.Color.SaddleBrown;
		CD317C12.LeftSahddow = false;
		CD317C12.Location = new System.Drawing.Point(0, 0);
		CD317C12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		CD317C12.Name = "bunifuCards1";
		CD317C12.RightSahddow = true;
		CD317C12.ShadowDepth = 20;
		CD317C12.Size = new System.Drawing.Size(234, 47);
		CD317C12.TabIndex = 12;
		C512DB95.BackColor = System.Drawing.Color.White;
		C512DB95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C512DB95.Controls.Add(label3);
		C512DB95.Controls.Add(label4);
		C512DB95.Controls.Add(label2);
		C512DB95.Controls.Add(txtComment);
		C512DB95.Controls.Add(AC93A4B9);
		C512DB95.Controls.Add(label1);
		C512DB95.Controls.Add(AFAF9830);
		C512DB95.Controls.Add(C11ADF99);
		C512DB95.Controls.Add(EB334198);
		C512DB95.Controls.Add(bunifuCards2);
		C512DB95.Dock = System.Windows.Forms.DockStyle.Fill;
		C512DB95.Location = new System.Drawing.Point(0, 0);
		C512DB95.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		C512DB95.Name = "panel1";
		C512DB95.Size = new System.Drawing.Size(563, 364);
		C512DB95.TabIndex = 37;
		C512DB95.Paint += new System.Windows.Forms.PaintEventHandler(C512DB95_Paint);
		label3.AutoSize = true;
		label3.BackColor = System.Drawing.Color.Transparent;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label3.ForeColor = System.Drawing.Color.DarkRed;
		label3.Location = new System.Drawing.Point(381, 45);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(34, 16);
		label3.TabIndex = 47;
		label3.Text = "hoặc";
		label4.AutoSize = true;
		label4.ForeColor = System.Drawing.Color.DarkGreen;
		label4.Location = new System.Drawing.Point(414, 45);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(132, 16);
		label4.TabIndex = 51;
		label4.Text = "Email|Pass Mail|Imap";
		label2.AutoSize = true;
		label2.ForeColor = System.Drawing.Color.DarkGreen;
		label2.Location = new System.Drawing.Point(286, 45);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(101, 16);
		label2.TabIndex = 51;
		label2.Text = "Email|Pass Mail ";
		txtComment.Location = new System.Drawing.Point(16, 64);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(528, 231);
		txtComment.TabIndex = 50;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
		AC93A4B9.AutoSize = true;
		AC93A4B9.Location = new System.Drawing.Point(13, 299);
		AC93A4B9.Name = "lblFooter";
		AC93A4B9.Size = new System.Drawing.Size(133, 16);
		AC93A4B9.TabIndex = 49;
		AC93A4B9.Text = "(Mỗi nội dung 1 dòng)";
		label1.AutoSize = true;
		label1.BackColor = System.Drawing.Color.Transparent;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label1.ForeColor = System.Drawing.Color.DarkRed;
		label1.Location = new System.Drawing.Point(187, 45);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 16);
		label1.TabIndex = 47;
		label1.Text = "Định dạng nhập:";
		AFAF9830.AutoSize = true;
		AFAF9830.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		AFAF9830.Location = new System.Drawing.Point(13, 45);
		AFAF9830.Name = "lblStatus";
		AFAF9830.Size = new System.Drawing.Size(127, 16);
		AFAF9830.TabIndex = 47;
		AFAF9830.Text = "Danh sách Email (0):";
		C11ADF99.BackColor = System.Drawing.Color.Maroon;
		C11ADF99.Cursor = System.Windows.Forms.Cursors.Hand;
		C11ADF99.FlatAppearance.BorderSize = 0;
		C11ADF99.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C11ADF99.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C11ADF99.ForeColor = System.Drawing.Color.White;
		C11ADF99.Location = new System.Drawing.Point(286, 321);
		C11ADF99.Name = "btnCancel";
		C11ADF99.Size = new System.Drawing.Size(92, 29);
		C11ADF99.TabIndex = 46;
		C11ADF99.Text = "Đóng";
		C11ADF99.UseVisualStyleBackColor = false;
		C11ADF99.Click += new System.EventHandler(C11ADF99_Click);
		EB334198.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EB334198.Cursor = System.Windows.Forms.Cursors.Hand;
		EB334198.FlatAppearance.BorderSize = 0;
		EB334198.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EB334198.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EB334198.ForeColor = System.Drawing.Color.White;
		EB334198.Location = new System.Drawing.Point(182, 321);
		EB334198.Name = "btnAdd";
		EB334198.Size = new System.Drawing.Size(92, 29);
		EB334198.TabIndex = 45;
		EB334198.Text = "Lưu";
		EB334198.UseVisualStyleBackColor = false;
		EB334198.Click += new System.EventHandler(DA2C9323);
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(pnlHeader);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(561, 37);
		bunifuCards2.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(E529A2BA);
		pnlHeader.Controls.Add(D1A21D25);
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
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		E529A2BA.Cursor = System.Windows.Forms.Cursors.Hand;
		E529A2BA.FlatAppearance.BorderSize = 0;
		E529A2BA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E529A2BA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E529A2BA.ForeColor = System.Drawing.Color.White;
		E529A2BA.Location = new System.Drawing.Point(899, 1);
		E529A2BA.Name = "btnMinimize";
		E529A2BA.Size = new System.Drawing.Size(30, 30);
		E529A2BA.TabIndex = 9;
		E529A2BA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E529A2BA.UseVisualStyleBackColor = true;
		D1A21D25.BackColor = System.Drawing.Color.Transparent;
		D1A21D25.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D1A21D25.Dock = System.Windows.Forms.DockStyle.Fill;
		D1A21D25.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D1A21D25.ForeColor = System.Drawing.Color.Black;
		D1A21D25.Location = new System.Drawing.Point(0, 0);
		D1A21D25.Name = "lblTitle";
		D1A21D25.Size = new System.Drawing.Size(561, 31);
		D1A21D25.TabIndex = 12;
		D1A21D25.Text = "Nhâ\u0323p danh sa\u0301ch Email cần add";
		D1A21D25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C0167F9F.Fixed = true;
		C0167F9F.Horizontal = true;
		C0167F9F.TargetControl = D1A21D25;
		C0167F9F.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(563, 364);
		base.Controls.Add(C512DB95);
		base.Controls.Add(CD317C12);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fNhapMailAdd";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fNhapMailAdd_Load);
		C512DB95.ResumeLayout(false);
		C512DB95.PerformLayout();
		bunifuCards2.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
