using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchCheckLiveUid : Form
{
	[CompilerGenerated]
	private sealed class AD1E56B2
	{
		internal int D4370D2F;

		internal fTienIchCheckLiveUid fTienIchCheckLiveUid_0;
	}

	[CompilerGenerated]
	private sealed class BBA9ACB0
	{
		internal string string_0;

		internal AD1E56B2 ad1E56B2_0;

		internal void method_0()
		{
			string text = CommonRequest.BC9215A7(string_0);
			if (text.StartsWith("0|"))
			{
				ad1E56B2_0.fTienIchCheckLiveUid_0.method_0(ad1E56B2_0.fTienIchCheckLiveUid_0.txtDie, string_0);
			}
			else if (text.StartsWith("1|"))
			{
				ad1E56B2_0.fTienIchCheckLiveUid_0.method_0(ad1E56B2_0.fTienIchCheckLiveUid_0.FF17F021, string_0);
			}
			else
			{
				ad1E56B2_0.fTienIchCheckLiveUid_0.method_0(ad1E56B2_0.fTienIchCheckLiveUid_0.txtKhongCheckDuoc, string_0);
			}
			Interlocked.Decrement(ref ad1E56B2_0.D4370D2F);
		}
	}

	[CompilerGenerated]
	private sealed class Class91
	{
		internal RichTextBox B216560A;

		internal string D710F09E;

		internal void method_0()
		{
			Application.DoEvents();
			RichTextBox b216560A = B216560A;
			b216560A.Text = b216560A.Text + D710F09E + "\r\n";
		}
	}

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards bunifuCards2;

	internal Panel EB934D36;

	internal Button button2;

	internal PictureBox A20F8E9C;

	internal BunifuCustomLabel lblTitle;

	internal Button E4A94106;

	internal RichTextBox txtInput;

	internal GroupBox grDaTao;

	internal RichTextBox FF17F021;

	internal GroupBox groupBox1;

	internal GroupBox grChuaTao;

	internal RichTextBox txtDie;

	internal Label lblStatus;

	internal GroupBox grKhongCheckDuoc;

	internal RichTextBox txtKhongCheckDuoc;

	internal NumericUpDown nudThread;

	internal Label C0B96518;

	public fTienIchCheckLiveUid()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B61BFE95(object sender, EventArgs e)
	{
		Close();
	}

	private void E4A94106_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			list = txtInput.Lines.ToList();
			int D4370D2F = 0;
			int num = Convert.ToInt32(nudThread.Value);
			if (num == 0)
			{
				MsBoxHelper.Show("Số luồng phải >0, vui lòng nhập lại!", 3);
				return;
			}
			if (list.Count < num)
			{
				num = list.Count;
			}
			lblStatus.Invoke((MethodInvoker)delegate
			{
				lblStatus.Visible = true;
			});
			int num2 = 0;
			while (num2 < list.Count)
			{
				if (D4370D2F < num)
				{
					Interlocked.Increment(ref D4370D2F);
					string string_0 = list[num2++];
					new Thread((ThreadStart)delegate
					{
						string text = CommonRequest.BC9215A7(string_0);
						if (text.StartsWith("0|"))
						{
							method_0(txtDie, string_0);
						}
						else if (text.StartsWith("1|"))
						{
							method_0(FF17F021, string_0);
						}
						else
						{
							method_0(txtKhongCheckDuoc, string_0);
						}
						Interlocked.Decrement(ref D4370D2F);
					}).Start();
				}
				else
				{
					Application.DoEvents();
					Commom.smethod_52(1.0);
				}
			}
			while (D4370D2F > 0)
			{
				Commom.smethod_52(1.0);
			}
			lblStatus.Invoke((MethodInvoker)delegate
			{
				lblStatus.Visible = false;
			});
			MsBoxHelper.Show("Đã check xong!");
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void method_0(RichTextBox richTextBox_0, string A293698B)
	{
		richTextBox_0.Invoke((MethodInvoker)delegate
		{
			Application.DoEvents();
			RichTextBox richTextBox = richTextBox_0;
			richTextBox.Text = richTextBox.Text + A293698B + "\r\n";
		});
	}

	private void F3B0E4AA(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtInput, groupBox1);
	}

	private void B105F70D(object sender, EventArgs e)
	{
		Commom.FE214EB5(FF17F021, grDaTao);
	}

	private void CE2F2E37(object sender, PaintEventArgs e)
	{
	}

	private void fTienIchCheckLiveUid_Load(object sender, EventArgs e)
	{
	}

	private void D10FBA2D(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtDie, grChuaTao);
	}

	private void D50B858D(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtKhongCheckDuoc, grKhongCheckDuoc);
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
		nudThread = new System.Windows.Forms.NumericUpDown();
		C0B96518 = new System.Windows.Forms.Label();
		lblStatus = new System.Windows.Forms.Label();
		grKhongCheckDuoc = new System.Windows.Forms.GroupBox();
		txtKhongCheckDuoc = new System.Windows.Forms.RichTextBox();
		grChuaTao = new System.Windows.Forms.GroupBox();
		txtDie = new System.Windows.Forms.RichTextBox();
		grDaTao = new System.Windows.Forms.GroupBox();
		FF17F021 = new System.Windows.Forms.RichTextBox();
		groupBox1 = new System.Windows.Forms.GroupBox();
		txtInput = new System.Windows.Forms.RichTextBox();
		E4A94106 = new System.Windows.Forms.Button();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		EB934D36 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		A20F8E9C = new System.Windows.Forms.PictureBox();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThread).BeginInit();
		grKhongCheckDuoc.SuspendLayout();
		grChuaTao.SuspendLayout();
		grDaTao.SuspendLayout();
		groupBox1.SuspendLayout();
		bunifuCards2.SuspendLayout();
		EB934D36.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A20F8E9C).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(649, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(nudThread);
		panel1.Controls.Add(C0B96518);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(grKhongCheckDuoc);
		panel1.Controls.Add(grChuaTao);
		panel1.Controls.Add(grDaTao);
		panel1.Controls.Add(groupBox1);
		panel1.Controls.Add(E4A94106);
		panel1.Controls.Add(bunifuCards2);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(978, 407);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(CE2F2E37);
		nudThread.Location = new System.Drawing.Point(360, 60);
		nudThread.Maximum = new decimal(new int[4] { 999999999, 0, 0, 0 });
		nudThread.Name = "nudThread";
		nudThread.Size = new System.Drawing.Size(69, 23);
		nudThread.TabIndex = 54;
		nudThread.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		C0B96518.AutoSize = true;
		C0B96518.Location = new System.Drawing.Point(294, 62);
		C0B96518.Name = "label2";
		C0B96518.Size = new System.Drawing.Size(59, 16);
		C0B96518.TabIndex = 53;
		C0B96518.Text = "Threads:";
		lblStatus.AutoSize = true;
		lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatus.Location = new System.Drawing.Point(617, 62);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(70, 16);
		lblStatus.TabIndex = 52;
		lblStatus.Text = "Checking...";
		lblStatus.Visible = false;
		grKhongCheckDuoc.Controls.Add(txtKhongCheckDuoc);
		grKhongCheckDuoc.ForeColor = System.Drawing.Color.Red;
		grKhongCheckDuoc.Location = new System.Drawing.Point(748, 91);
		grKhongCheckDuoc.Name = "grKhongCheckDuoc";
		grKhongCheckDuoc.Size = new System.Drawing.Size(221, 307);
		grKhongCheckDuoc.TabIndex = 51;
		grKhongCheckDuoc.TabStop = false;
		grKhongCheckDuoc.Text = "Can't check (0)";
		txtKhongCheckDuoc.Dock = System.Windows.Forms.DockStyle.Fill;
		txtKhongCheckDuoc.Location = new System.Drawing.Point(3, 19);
		txtKhongCheckDuoc.Name = "txtKhongCheckDuoc";
		txtKhongCheckDuoc.Size = new System.Drawing.Size(215, 285);
		txtKhongCheckDuoc.TabIndex = 50;
		txtKhongCheckDuoc.Text = "";
		txtKhongCheckDuoc.WordWrap = false;
		txtKhongCheckDuoc.TextChanged += new System.EventHandler(D50B858D);
		grChuaTao.Controls.Add(txtDie);
		grChuaTao.ForeColor = System.Drawing.Color.DarkRed;
		grChuaTao.Location = new System.Drawing.Point(521, 91);
		grChuaTao.Name = "grChuaTao";
		grChuaTao.Size = new System.Drawing.Size(221, 307);
		grChuaTao.TabIndex = 51;
		grChuaTao.TabStop = false;
		grChuaTao.Text = "DIE (0)";
		txtDie.Dock = System.Windows.Forms.DockStyle.Fill;
		txtDie.Location = new System.Drawing.Point(3, 19);
		txtDie.Name = "txtDie";
		txtDie.Size = new System.Drawing.Size(215, 285);
		txtDie.TabIndex = 50;
		txtDie.Text = "";
		txtDie.WordWrap = false;
		txtDie.TextChanged += new System.EventHandler(D10FBA2D);
		grDaTao.Controls.Add(FF17F021);
		grDaTao.ForeColor = System.Drawing.Color.DarkGreen;
		grDaTao.Location = new System.Drawing.Point(294, 91);
		grDaTao.Name = "grDaTao";
		grDaTao.Size = new System.Drawing.Size(221, 307);
		grDaTao.TabIndex = 51;
		grDaTao.TabStop = false;
		grDaTao.Text = "LIVE (0)";
		FF17F021.Dock = System.Windows.Forms.DockStyle.Fill;
		FF17F021.Location = new System.Drawing.Point(3, 19);
		FF17F021.Name = "txtLive";
		FF17F021.Size = new System.Drawing.Size(215, 285);
		FF17F021.TabIndex = 50;
		FF17F021.Text = "";
		FF17F021.WordWrap = false;
		FF17F021.TextChanged += new System.EventHandler(B105F70D);
		groupBox1.Controls.Add(txtInput);
		groupBox1.Location = new System.Drawing.Point(6, 40);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(282, 358);
		groupBox1.TabIndex = 51;
		groupBox1.TabStop = false;
		groupBox1.Text = "Nhập Uid (0)";
		txtInput.Location = new System.Drawing.Point(9, 19);
		txtInput.Name = "txtInput";
		txtInput.Size = new System.Drawing.Size(267, 336);
		txtInput.TabIndex = 50;
		txtInput.Text = "";
		txtInput.WordWrap = false;
		txtInput.TextChanged += new System.EventHandler(F3B0E4AA);
		E4A94106.BackColor = System.Drawing.Color.Green;
		E4A94106.Cursor = System.Windows.Forms.Cursors.Hand;
		E4A94106.FlatAppearance.BorderSize = 0;
		E4A94106.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E4A94106.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E4A94106.ForeColor = System.Drawing.Color.White;
		E4A94106.Location = new System.Drawing.Point(476, 52);
		E4A94106.Name = "btnAdd";
		E4A94106.Size = new System.Drawing.Size(135, 36);
		E4A94106.TabIndex = 45;
		E4A94106.Text = "Check";
		E4A94106.UseVisualStyleBackColor = false;
		E4A94106.Click += new System.EventHandler(E4A94106_Click);
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(EB934D36);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(976, 37);
		bunifuCards2.TabIndex = 43;
		EB934D36.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EB934D36.BackColor = System.Drawing.Color.White;
		EB934D36.Controls.Add(button2);
		EB934D36.Controls.Add(A20F8E9C);
		EB934D36.Controls.Add(lblTitle);
		EB934D36.Cursor = System.Windows.Forms.Cursors.SizeAll;
		EB934D36.Location = new System.Drawing.Point(0, 3);
		EB934D36.Name = "pnlHeader";
		EB934D36.Size = new System.Drawing.Size(976, 31);
		EB934D36.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(945, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(B61BFE95);
		A20F8E9C.Cursor = System.Windows.Forms.Cursors.Default;
		A20F8E9C.Image = Class155.DD225F0D;
		A20F8E9C.Location = new System.Drawing.Point(3, 2);
		A20F8E9C.Name = "pictureBox1";
		A20F8E9C.Size = new System.Drawing.Size(34, 27);
		A20F8E9C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		A20F8E9C.TabIndex = 76;
		A20F8E9C.TabStop = false;
		lblTitle.BackColor = System.Drawing.Color.Transparent;
		lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
		lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblTitle.ForeColor = System.Drawing.Color.Black;
		lblTitle.Location = new System.Drawing.Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(976, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Check Live Uid";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = lblTitle;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(978, 407);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchCheckLiveUid";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fTienIchCheckLiveUid_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThread).EndInit();
		grKhongCheckDuoc.ResumeLayout(false);
		grChuaTao.ResumeLayout(false);
		grDaTao.ResumeLayout(false);
		groupBox1.ResumeLayout(false);
		bunifuCards2.ResumeLayout(false);
		EB934D36.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)A20F8E9C).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_1()
	{
		lblStatus.Visible = true;
	}

	[CompilerGenerated]
	private void method_2()
	{
		lblStatus.Visible = false;
	}
}
