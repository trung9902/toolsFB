using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchFindIdFb : Form
{
	[CompilerGenerated]
	private sealed class E203D31D
	{
		internal int int_0;

		internal fTienIchFindIdFb CEBB0EB3;
	}

	[CompilerGenerated]
	private sealed class Class92
	{
		internal string string_0;

		internal E203D31D e203D31D_0;

		internal void method_0()
		{
			string text = Commom.smethod_87(string_0);
			e203D31D_0.CEBB0EB3.method_0(e203D31D_0.CEBB0EB3.txtOutput1, text);
			e203D31D_0.CEBB0EB3.method_0(e203D31D_0.CEBB0EB3.C2B62DBD, string_0 + "|" + text);
			Interlocked.Decrement(ref e203D31D_0.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class93
	{
		internal RichTextBox richTextBox_0;

		internal string A03D9505;

		internal void method_0()
		{
			Application.DoEvents();
			RichTextBox richTextBox = richTextBox_0;
			richTextBox.Text = richTextBox.Text + A03D9505 + "\r\n";
		}
	}

	internal IContainer icontainer_0 = null;

	internal BunifuCards DE871986;

	internal Panel panel1;

	internal BunifuDragControl A22F2F2A;

	internal BunifuCards bunifuCards2;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel lblTitle;

	internal Button btnAdd;

	internal RichTextBox txtInput;

	internal GroupBox grOutput1;

	internal RichTextBox txtOutput1;

	internal GroupBox ED0EDBB9;

	internal GroupBox grOutput2;

	internal RichTextBox C2B62DBD;

	internal Label lblStatus;

	public fTienIchFindIdFb()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B7803787(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			list = txtInput.Text.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			if (list.Count == 0)
			{
				return;
			}
			txtOutput1.Clear();
			C2B62DBD.Clear();
			int int_0 = 0;
			int num = 50;
			lblStatus.Invoke((MethodInvoker)delegate
			{
				lblStatus.Visible = true;
			});
			int num2 = 0;
			while (num2 < list.Count)
			{
				if (int_0 < num)
				{
					Interlocked.Increment(ref int_0);
					string string_0 = list[num2++];
					new Thread((ThreadStart)delegate
					{
						string text = Commom.smethod_87(string_0);
						method_0(txtOutput1, text);
						method_0(C2B62DBD, string_0 + "|" + text);
						Interlocked.Decrement(ref int_0);
					}).Start();
				}
				else
				{
					Application.DoEvents();
					Commom.smethod_52(1.0);
				}
			}
			while (int_0 > 0)
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

	private void method_0(RichTextBox richTextBox_0, string string_0)
	{
		richTextBox_0.Invoke((MethodInvoker)delegate
		{
			Application.DoEvents();
			RichTextBox richTextBox = richTextBox_0;
			richTextBox.Text = richTextBox.Text + string_0 + "\r\n";
		});
	}

	private void txtInput_TextChanged(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtInput, ED0EDBB9);
	}

	private void E099F52D(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtOutput1, grOutput1);
	}

	private void A69CE31B(object sender, PaintEventArgs e)
	{
	}

	private void fTienIchFindIdFb_Load(object sender, EventArgs e)
	{
	}

	private void C2B62DBD_TextChanged(object sender, EventArgs e)
	{
		Commom.FE214EB5(C2B62DBD, grOutput2);
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
		DE871986 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		lblStatus = new System.Windows.Forms.Label();
		grOutput2 = new System.Windows.Forms.GroupBox();
		C2B62DBD = new System.Windows.Forms.RichTextBox();
		grOutput1 = new System.Windows.Forms.GroupBox();
		txtOutput1 = new System.Windows.Forms.RichTextBox();
		ED0EDBB9 = new System.Windows.Forms.GroupBox();
		txtInput = new System.Windows.Forms.RichTextBox();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		A22F2F2A = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		grOutput2.SuspendLayout();
		grOutput1.SuspendLayout();
		ED0EDBB9.SuspendLayout();
		bunifuCards2.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		DE871986.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DE871986.BackColor = System.Drawing.Color.White;
		DE871986.BorderRadius = 5;
		DE871986.BottomSahddow = true;
		DE871986.color = System.Drawing.Color.SaddleBrown;
		DE871986.LeftSahddow = false;
		DE871986.Location = new System.Drawing.Point(0, 0);
		DE871986.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		DE871986.Name = "bunifuCards1";
		DE871986.RightSahddow = true;
		DE871986.ShadowDepth = 20;
		DE871986.Size = new System.Drawing.Size(421, 47);
		DE871986.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(grOutput2);
		panel1.Controls.Add(grOutput1);
		panel1.Controls.Add(ED0EDBB9);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards2);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(750, 404);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(A69CE31B);
		lblStatus.AutoSize = true;
		lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatus.Location = new System.Drawing.Point(435, 59);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(70, 16);
		lblStatus.TabIndex = 52;
		lblStatus.Text = "Checking...";
		lblStatus.Visible = false;
		grOutput2.Controls.Add(C2B62DBD);
		grOutput2.ForeColor = System.Drawing.SystemColors.ControlText;
		grOutput2.Location = new System.Drawing.Point(521, 91);
		grOutput2.Name = "grOutput2";
		grOutput2.Size = new System.Drawing.Size(221, 307);
		grOutput2.TabIndex = 51;
		grOutput2.TabStop = false;
		grOutput2.Text = "Link|Id (0)";
		C2B62DBD.Dock = System.Windows.Forms.DockStyle.Fill;
		C2B62DBD.Location = new System.Drawing.Point(3, 19);
		C2B62DBD.Name = "txtOutput2";
		C2B62DBD.Size = new System.Drawing.Size(215, 285);
		C2B62DBD.TabIndex = 50;
		C2B62DBD.Text = "";
		C2B62DBD.WordWrap = false;
		C2B62DBD.TextChanged += new System.EventHandler(C2B62DBD_TextChanged);
		grOutput1.Controls.Add(txtOutput1);
		grOutput1.ForeColor = System.Drawing.SystemColors.ControlText;
		grOutput1.Location = new System.Drawing.Point(294, 91);
		grOutput1.Name = "grOutput1";
		grOutput1.Size = new System.Drawing.Size(221, 307);
		grOutput1.TabIndex = 51;
		grOutput1.TabStop = false;
		grOutput1.Text = "Id (0)";
		txtOutput1.Dock = System.Windows.Forms.DockStyle.Fill;
		txtOutput1.Location = new System.Drawing.Point(3, 19);
		txtOutput1.Name = "txtOutput1";
		txtOutput1.Size = new System.Drawing.Size(215, 285);
		txtOutput1.TabIndex = 50;
		txtOutput1.Text = "";
		txtOutput1.WordWrap = false;
		txtOutput1.TextChanged += new System.EventHandler(E099F52D);
		ED0EDBB9.Controls.Add(txtInput);
		ED0EDBB9.Location = new System.Drawing.Point(6, 40);
		ED0EDBB9.Name = "grInput";
		ED0EDBB9.Size = new System.Drawing.Size(282, 358);
		ED0EDBB9.TabIndex = 51;
		ED0EDBB9.TabStop = false;
		ED0EDBB9.Text = "Nhập link Fb (0)";
		txtInput.Location = new System.Drawing.Point(9, 19);
		txtInput.Name = "txtInput";
		txtInput.Size = new System.Drawing.Size(267, 332);
		txtInput.TabIndex = 50;
		txtInput.Text = "";
		txtInput.WordWrap = false;
		txtInput.TextChanged += new System.EventHandler(txtInput_TextChanged);
		btnAdd.BackColor = System.Drawing.Color.Green;
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(294, 49);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(135, 36);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Check";
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
		bunifuCards2.Size = new System.Drawing.Size(748, 37);
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
		pnlHeader.Size = new System.Drawing.Size(748, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(717, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(B7803787);
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
		lblTitle.Size = new System.Drawing.Size(748, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Find Id Facebook";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A22F2F2A.Fixed = true;
		A22F2F2A.Horizontal = true;
		A22F2F2A.TargetControl = lblTitle;
		A22F2F2A.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(750, 404);
		base.Controls.Add(panel1);
		base.Controls.Add(DE871986);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchFindIdFb";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fTienIchFindIdFb_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		grOutput2.ResumeLayout(false);
		grOutput1.ResumeLayout(false);
		ED0EDBB9.ResumeLayout(false);
		bunifuCards2.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void BD048122()
	{
		lblStatus.Visible = true;
	}

	[CompilerGenerated]
	private void E720DAA7()
	{
		lblStatus.Visible = false;
	}
}
