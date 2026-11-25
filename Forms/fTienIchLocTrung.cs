using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchLocTrung : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards F2259892;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox B43BE715;

	internal Button btnMinimize;

	internal BunifuCustomLabel lblTitle;

	internal Button btnAdd;

	internal RichTextBox BE197520;

	internal GroupBox F082353B;

	internal RichTextBox txtOutput;

	internal GroupBox BBA5F600;

	internal Button btnNhapTuFile;

	internal TextBox F6811E01;

	internal RadioButton rbTuNhap;

	internal RadioButton rbNhapTuFile;

	public fTienIchLocTrung()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void C098D237(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> source = new List<string>();
			string text = F6811E01.Text.Trim();
			if (rbNhapTuFile.Checked)
			{
				if (text.EndsWith(".txt"))
				{
					if (!File.Exists(text))
					{
						MsBoxHelper.Show("File dữ liệu nhập không tồn tại!", 2);
					}
				}
				else
				{
					MsBoxHelper.Show("File nhập vào chỉ hỗ trợ đối với File (.txt)!", 2);
				}
			}
			if (rbNhapTuFile.Checked)
			{
				source = File.ReadAllLines(text).ToList();
			}
			else if (rbTuNhap.Checked)
			{
				source = BE197520.Lines.ToList();
			}
			List<string> list = source.Distinct().ToList();
			txtOutput.Lines = list.ToArray();
			MsBoxHelper.Show("Đã lọc xong!");
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void B3981684(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = BE197520.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			rbTuNhap.Text = string.Format(Language.GetValue("Tự nhập ({0})"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void rbNhapTuFile_CheckedChanged(object sender, EventArgs e)
	{
		F6811E01.Enabled = rbNhapTuFile.Checked;
		btnNhapTuFile.Enabled = rbNhapTuFile.Checked;
	}

	private void D89675AA(object sender, EventArgs e)
	{
		BE197520.Enabled = rbTuNhap.Checked;
	}

	private void E1B28F88(object sender, EventArgs e)
	{
		F6811E01.Text = Commom.smethod_97();
	}

	private void txtOutput_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtOutput.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			F082353B.Text = $"Output ({list_.Count.ToString()})";
		}
		catch
		{
		}
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void fTienIchLocTrung_Load(object sender, EventArgs e)
	{
		rbNhapTuFile_CheckedChanged(null, null);
		D89675AA(null, null);
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
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		F082353B = new System.Windows.Forms.GroupBox();
		txtOutput = new System.Windows.Forms.RichTextBox();
		BBA5F600 = new System.Windows.Forms.GroupBox();
		btnNhapTuFile = new System.Windows.Forms.Button();
		BE197520 = new System.Windows.Forms.RichTextBox();
		F6811E01 = new System.Windows.Forms.TextBox();
		rbTuNhap = new System.Windows.Forms.RadioButton();
		rbNhapTuFile = new System.Windows.Forms.RadioButton();
		btnAdd = new System.Windows.Forms.Button();
		F2259892 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		B43BE715 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		F082353B.SuspendLayout();
		BBA5F600.SuspendLayout();
		F2259892.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B43BE715).BeginInit();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 5;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(509, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(F082353B);
		panel1.Controls.Add(BBA5F600);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(F2259892);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(838, 270);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		F082353B.Controls.Add(txtOutput);
		F082353B.Location = new System.Drawing.Point(469, 40);
		F082353B.Name = "groupBox2";
		F082353B.Size = new System.Drawing.Size(361, 223);
		F082353B.TabIndex = 51;
		F082353B.TabStop = false;
		F082353B.Text = "Output (0)";
		txtOutput.Location = new System.Drawing.Point(6, 22);
		txtOutput.Name = "txtOutput";
		txtOutput.Size = new System.Drawing.Size(349, 194);
		txtOutput.TabIndex = 50;
		txtOutput.Text = "";
		txtOutput.WordWrap = false;
		txtOutput.TextChanged += new System.EventHandler(txtOutput_TextChanged);
		BBA5F600.Controls.Add(btnNhapTuFile);
		BBA5F600.Controls.Add(BE197520);
		BBA5F600.Controls.Add(F6811E01);
		BBA5F600.Controls.Add(rbTuNhap);
		BBA5F600.Controls.Add(rbNhapTuFile);
		BBA5F600.Location = new System.Drawing.Point(6, 40);
		BBA5F600.Name = "groupBox1";
		BBA5F600.Size = new System.Drawing.Size(361, 223);
		BBA5F600.TabIndex = 51;
		BBA5F600.TabStop = false;
		BBA5F600.Text = "Input";
		btnNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNhapTuFile.Location = new System.Drawing.Point(287, 22);
		btnNhapTuFile.Name = "btnNhapTuFile";
		btnNhapTuFile.Size = new System.Drawing.Size(65, 24);
		btnNhapTuFile.TabIndex = 2;
		btnNhapTuFile.Text = "Chọn";
		btnNhapTuFile.Click += new System.EventHandler(E1B28F88);
		BE197520.Location = new System.Drawing.Point(30, 75);
		BE197520.Name = "txtInput";
		BE197520.Size = new System.Drawing.Size(322, 141);
		BE197520.TabIndex = 50;
		BE197520.Text = "";
		BE197520.WordWrap = false;
		BE197520.TextChanged += new System.EventHandler(B3981684);
		F6811E01.Location = new System.Drawing.Point(110, 22);
		F6811E01.Name = "txtNhapTuFile";
		F6811E01.Size = new System.Drawing.Size(171, 23);
		F6811E01.TabIndex = 1;
		rbTuNhap.AutoSize = true;
		rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		rbTuNhap.Location = new System.Drawing.Point(9, 49);
		rbTuNhap.Name = "rbTuNhap";
		rbTuNhap.Size = new System.Drawing.Size(94, 20);
		rbTuNhap.TabIndex = 0;
		rbTuNhap.Text = "Tự nhập (0)";
		rbTuNhap.UseVisualStyleBackColor = true;
		rbTuNhap.CheckedChanged += new System.EventHandler(D89675AA);
		rbNhapTuFile.AutoSize = true;
		rbNhapTuFile.Checked = true;
		rbNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
		rbNhapTuFile.Location = new System.Drawing.Point(9, 23);
		rbNhapTuFile.Name = "rbNhapTuFile";
		rbNhapTuFile.Size = new System.Drawing.Size(94, 20);
		rbNhapTuFile.TabIndex = 0;
		rbNhapTuFile.TabStop = true;
		rbNhapTuFile.Text = "Nhập từ File";
		rbNhapTuFile.UseVisualStyleBackColor = true;
		rbNhapTuFile.CheckedChanged += new System.EventHandler(rbNhapTuFile_CheckedChanged);
		btnAdd.BackColor = System.Drawing.Color.Green;
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(379, 138);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(78, 29);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Start";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		F2259892.BackColor = System.Drawing.Color.White;
		F2259892.BorderRadius = 0;
		F2259892.BottomSahddow = true;
		F2259892.color = System.Drawing.Color.SaddleBrown;
		F2259892.Controls.Add(pnlHeader);
		F2259892.Dock = System.Windows.Forms.DockStyle.Top;
		F2259892.LeftSahddow = false;
		F2259892.Location = new System.Drawing.Point(0, 0);
		F2259892.Name = "bunifuCards2";
		F2259892.RightSahddow = true;
		F2259892.ShadowDepth = 20;
		F2259892.Size = new System.Drawing.Size(836, 37);
		F2259892.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(B43BE715);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(836, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(805, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(C098D237);
		B43BE715.Cursor = System.Windows.Forms.Cursors.Default;
		B43BE715.Image = Class155.DD225F0D;
		B43BE715.Location = new System.Drawing.Point(3, 2);
		B43BE715.Name = "pictureBox1";
		B43BE715.Size = new System.Drawing.Size(34, 27);
		B43BE715.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B43BE715.TabIndex = 76;
		B43BE715.TabStop = false;
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
		lblTitle.Size = new System.Drawing.Size(836, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Lọc trùng dữ liệu";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = lblTitle;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(838, 270);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchLocTrung";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fTienIchLocTrung_Load);
		panel1.ResumeLayout(false);
		F082353B.ResumeLayout(false);
		BBA5F600.ResumeLayout(false);
		BBA5F600.PerformLayout();
		F2259892.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B43BE715).EndInit();
		ResumeLayout(false);
	}
}
