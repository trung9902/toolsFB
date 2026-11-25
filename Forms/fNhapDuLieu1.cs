using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapDuLieu1 : Form
{
	internal string EA8F96B2 = "";

	internal string string_0 = "";

	internal List<string> list_0 = new List<string>();

	internal IContainer FE0C4106 = null;

	internal BunifuCards F606D6AD;

	internal Panel D10016A0;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards bunifuCards2;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel lblTitle;

	internal Label F3392A88;

	internal Button btnCancel;

	internal Button btnAdd;

	internal Label EC133991;

	internal RichTextBox E12F981B;

	public fNhapDuLieu1(string DF8B9AA2, string string_1 = "Nhập danh sách Uid cần clone", string EA0A1E18 = "Danh sách Uid", string D6AC29B3 = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})", List<string> list_1 = null)
	{
		InitializeComponent();
		Commom.EF994A31(DF8B9AA2);
		EA8F96B2 = DF8B9AA2;
		string_0 = EA0A1E18;
		lblTitle.Text = string_1;
		F3392A88.Text = EA0A1E18 + " (0):";
		EC133991.Text = D6AC29B3;
		if (list_1 != null)
		{
			File.WriteAllLines(DF8B9AA2, list_1);
			E12F981B.Lines = list_1.ToArray();
		}
		else
		{
			E12F981B.Lines = File.ReadAllLines(DF8B9AA2);
		}
		C1165EBE(null, null);
		Language.CD21F0A9(this);
	}

	public fNhapDuLieu1(List<string> list_1, string string_1 = "Nhập danh sách Uid cần clone", string string_2 = "Danh sách Uid", string string_3 = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})")
	{
		InitializeComponent();
		list_0 = list_1;
		string_0 = string_2;
		lblTitle.Text = string_1;
		F3392A88.Text = string_2 + " (0):";
		EC133991.Text = string_3;
		Language.CD21F0A9(this);
	}

	private void fNhapDuLieu1_Load(object sender, EventArgs e)
	{
		if (EA8F96B2 != "")
		{
			E12F981B.Lines = File.ReadAllLines(EA8F96B2);
		}
		else
		{
			E12F981B.Lines = list_0.ToArray();
		}
	}

	private void D10016A0_Paint(object sender, PaintEventArgs e)
	{
	}

	private void EC0AFE92(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			if (EA8F96B2 != "")
			{
				File.WriteAllText(EA8F96B2, E12F981B.Text.Trim());
			}
			else
			{
				list_0 = E12F981B.Text.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			}
			Close();
		}
		catch
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void CF312892(object sender, EventArgs e)
	{
		Close();
	}

	private void C1165EBE(object sender, EventArgs e)
	{
		Commom.A9BCAF05(E12F981B, F3392A88);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && FE0C4106 != null)
		{
			FE0C4106.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		FE0C4106 = new System.ComponentModel.Container();
		F606D6AD = new Bunifu.Framework.UI.BunifuCards();
		D10016A0 = new System.Windows.Forms.Panel();
		E12F981B = new System.Windows.Forms.RichTextBox();
		EC133991 = new System.Windows.Forms.Label();
		F3392A88 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(FE0C4106);
		D10016A0.SuspendLayout();
		bunifuCards2.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		F606D6AD.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F606D6AD.BackColor = System.Drawing.Color.White;
		F606D6AD.BorderRadius = 5;
		F606D6AD.BottomSahddow = true;
		F606D6AD.color = System.Drawing.Color.SaddleBrown;
		F606D6AD.LeftSahddow = false;
		F606D6AD.Location = new System.Drawing.Point(0, 0);
		F606D6AD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		F606D6AD.Name = "bunifuCards1";
		F606D6AD.RightSahddow = true;
		F606D6AD.ShadowDepth = 20;
		F606D6AD.Size = new System.Drawing.Size(234, 47);
		F606D6AD.TabIndex = 12;
		D10016A0.BackColor = System.Drawing.Color.White;
		D10016A0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D10016A0.Controls.Add(E12F981B);
		D10016A0.Controls.Add(EC133991);
		D10016A0.Controls.Add(F3392A88);
		D10016A0.Controls.Add(btnCancel);
		D10016A0.Controls.Add(btnAdd);
		D10016A0.Controls.Add(bunifuCards2);
		D10016A0.Dock = System.Windows.Forms.DockStyle.Fill;
		D10016A0.Location = new System.Drawing.Point(0, 0);
		D10016A0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		D10016A0.Name = "panel1";
		D10016A0.Size = new System.Drawing.Size(563, 364);
		D10016A0.TabIndex = 37;
		D10016A0.Paint += new System.Windows.Forms.PaintEventHandler(D10016A0_Paint);
		E12F981B.Location = new System.Drawing.Point(16, 64);
		E12F981B.Name = "txtComment";
		E12F981B.Size = new System.Drawing.Size(528, 231);
		E12F981B.TabIndex = 50;
		E12F981B.Text = "";
		E12F981B.WordWrap = false;
		E12F981B.TextChanged += new System.EventHandler(C1165EBE);
		EC133991.AutoSize = true;
		EC133991.Location = new System.Drawing.Point(13, 299);
		EC133991.Name = "lblFooter";
		EC133991.Size = new System.Drawing.Size(265, 16);
		EC133991.TabIndex = 49;
		EC133991.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
		F3392A88.AutoSize = true;
		F3392A88.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F3392A88.Location = new System.Drawing.Point(13, 45);
		F3392A88.Name = "lblStatus";
		F3392A88.Size = new System.Drawing.Size(139, 16);
		F3392A88.TabIndex = 47;
		F3392A88.Text = "Nội dung bình luận (0):";
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(286, 321);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 46;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(CF312892);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(182, 321);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(lblTitle);
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
		button2.Click += new System.EventHandler(EC0AFE92);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Location = new System.Drawing.Point(899, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		lblTitle.BackColor = System.Drawing.Color.Transparent;
		lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
		lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblTitle.ForeColor = System.Drawing.Color.Black;
		lblTitle.Location = new System.Drawing.Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(561, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Nhập nội dung comment";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = lblTitle;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(563, 364);
		base.Controls.Add(D10016A0);
		base.Controls.Add(F606D6AD);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fNhapDuLieu1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fNhapDuLieu1_Load);
		D10016A0.ResumeLayout(false);
		D10016A0.PerformLayout();
		bunifuCards2.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
