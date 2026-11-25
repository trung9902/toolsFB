using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchCheckImapHotmail : Form
{
	private enum Enum1
	{
		[Description("Check Connect Hotmail")]
		const_0,
		[Description("Get Code")]
		BBBB410B
	}

	[CompilerGenerated]
	private sealed class FD2FC58F
	{
		internal fTienIchCheckImapHotmail fTienIchCheckImapHotmail_0;

		internal Enum1 FE1E762B;

		internal void method_0()
		{
			fTienIchCheckImapHotmail_0.lblStatus.Visible = true;
		}

		internal void AF942095()
		{
			fTienIchCheckImapHotmail_0.lblStatus.Visible = false;
		}
	}

	[CompilerGenerated]
	private sealed class Class96
	{
		internal string string_0;

		internal int int_0;

		internal FD2FC58F fd2FC58F_0;
	}

	[CompilerGenerated]
	private sealed class Class97
	{
		internal string D80D8599;

		internal Class96 class96_0;

		internal void FBAFB09C()
		{
			try
			{
				if (class96_0.fd2FC58F_0.FE1E762B == Enum1.const_0)
				{
					if (class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_1(D80D8599))
					{
						class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_0(class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.txtDaTao, D80D8599);
					}
					else
					{
						class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_0(class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.FEB19414, D80D8599);
					}
				}
				else if (class96_0.fd2FC58F_0.FE1E762B == Enum1.BBBB410B)
				{
					string text = class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_2(D80D8599, class96_0.string_0);
					if (text.StartsWith("0|"))
					{
						class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_0(class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.FEB19414, D80D8599);
					}
					else
					{
						class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.method_0(class96_0.fd2FC58F_0.fTienIchCheckImapHotmail_0.txtDaTao, D80D8599 + "|" + text.Split('|')[1]);
					}
				}
			}
			catch (Exception object_)
			{
				MsBoxHelper.Show(object_, 2);
			}
			Interlocked.Decrement(ref class96_0.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class AD904480
	{
		internal RichTextBox C033F538;

		internal string string_0;

		internal void method_0()
		{
			Application.DoEvents();
			RichTextBox c033F = C033F538;
			c033F.Text = c033F.Text + string_0 + "\r\n";
		}
	}

	internal IContainer F58A990E = null;

	internal BunifuCards CF9CB4BE;

	internal Panel E302ED31;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards E71776A7;

	internal Panel D6337EB4;

	internal Button DF13EEBE;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel lblTitle;

	internal Button btnAdd;

	internal RichTextBox EB2EA386;

	internal GroupBox grDaTao;

	internal RichTextBox txtDaTao;

	internal GroupBox groupBox1;

	internal Button C29137B2;

	internal TextBox txtNhapTuFile;

	internal RadioButton rbTuNhap;

	internal RadioButton B80C2FAC;

	internal GroupBox FD2FF902;

	internal RichTextBox FEB19414;

	internal Label lblStatus;

	internal TextBox txtTypeGet;

	internal Button btnGetCode;

	public fTienIchCheckImapHotmail()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void DF13EEBE_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		EB2BF4AA(Enum1.const_0);
	}

	private void EB2BF4AA(Enum1 enum1_0)
	{
		try
		{
			List<string> list = new List<string>();
			string text = txtNhapTuFile.Text.Trim();
			if (B80C2FAC.Checked)
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
			if (B80C2FAC.Checked)
			{
				list = File.ReadAllLines(text).ToList();
			}
			else if (rbTuNhap.Checked)
			{
				list = EB2EA386.Lines.ToList();
			}
			string string_0 = txtTypeGet.Text.Trim();
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
					string D80D8599 = list[num2++];
					new Thread((ThreadStart)delegate
					{
						try
						{
							if (enum1_0 == Enum1.const_0)
							{
								if (method_1(D80D8599))
								{
									method_0(txtDaTao, D80D8599);
								}
								else
								{
									method_0(FEB19414, D80D8599);
								}
							}
							else if (enum1_0 == Enum1.BBBB410B)
							{
								string text2 = method_2(D80D8599, string_0);
								if (text2.StartsWith("0|"))
								{
									method_0(FEB19414, D80D8599);
								}
								else
								{
									method_0(txtDaTao, D80D8599 + "|" + text2.Split('|')[1]);
								}
							}
						}
						catch (Exception object_)
						{
							MsBoxHelper.Show(object_, 2);
						}
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

	private bool method_1(string FD207E08)
	{
		try
		{
			string[] array = FD207E08.Split('|');
			string text = array[0];
			string text2 = array[1];
			if (text == "" || text2 == "")
			{
				return false;
			}
			string string_ = "";
			if (array.Length > 3)
			{
				string_ = array[2] + "|" + array[3];
			}
			return D831098B.FFA1D7B5(text, text2, string_);
		}
		catch
		{
		}
		return false;
	}

	private string method_2(string string_0, string string_1)
	{
		try
		{
			string[] array = string_0.Split('|');
			string text = array[0];
			string text2 = array[1];
			if (text == "" || text2 == "")
			{
				return "0|";
			}
			string text3 = D831098B.FD246327(Convert.ToInt32(string_1), text, text2, "", 0, "", "");
			if (text3 == "fail")
			{
				return "0|";
			}
			return "1|" + text3;
		}
		catch
		{
		}
		return "";
	}

	private void EB2EA386_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = EB2EA386.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			rbTuNhap.Text = string.Format(Language.GetValue("Tự nhập ({0})"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void B80C2FAC_CheckedChanged(object sender, EventArgs e)
	{
		txtNhapTuFile.Enabled = B80C2FAC.Checked;
		C29137B2.Enabled = B80C2FAC.Checked;
	}

	private void rbTuNhap_CheckedChanged(object sender, EventArgs e)
	{
		EB2EA386.Enabled = rbTuNhap.Checked;
	}

	private void C29137B2_Click(object sender, EventArgs e)
	{
		txtNhapTuFile.Text = Commom.smethod_97();
	}

	private void D7BD8601(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtDaTao.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			grDaTao.Text = string.Format(Language.GetValue("Live ({0})"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void E302ED31_Paint(object sender, PaintEventArgs e)
	{
	}

	private void C7AD7E30(object sender, EventArgs e)
	{
		B80C2FAC_CheckedChanged(null, null);
		rbTuNhap_CheckedChanged(null, null);
	}

	private void B180593E(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = FEB19414.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			FD2FF902.Text = string.Format(Language.GetValue("Die ({0})"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void C0B07A98(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			btnGetCode.Visible = true;
			txtTypeGet.Visible = true;
		}
	}

	private void btnGetCode_Click(object sender, EventArgs e)
	{
		EB2BF4AA(Enum1.BBBB410B);
	}

	protected override void Dispose(bool EE8AB99B)
	{
		if (EE8AB99B && F58A990E != null)
		{
			F58A990E.Dispose();
		}
		base.Dispose(EE8AB99B);
	}

	private void InitializeComponent()
	{
		F58A990E = new System.ComponentModel.Container();
		CF9CB4BE = new Bunifu.Framework.UI.BunifuCards();
		E302ED31 = new System.Windows.Forms.Panel();
		lblStatus = new System.Windows.Forms.Label();
		FD2FF902 = new System.Windows.Forms.GroupBox();
		FEB19414 = new System.Windows.Forms.RichTextBox();
		txtTypeGet = new System.Windows.Forms.TextBox();
		grDaTao = new System.Windows.Forms.GroupBox();
		txtDaTao = new System.Windows.Forms.RichTextBox();
		groupBox1 = new System.Windows.Forms.GroupBox();
		C29137B2 = new System.Windows.Forms.Button();
		EB2EA386 = new System.Windows.Forms.RichTextBox();
		txtNhapTuFile = new System.Windows.Forms.TextBox();
		rbTuNhap = new System.Windows.Forms.RadioButton();
		B80C2FAC = new System.Windows.Forms.RadioButton();
		btnGetCode = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		E71776A7 = new Bunifu.Framework.UI.BunifuCards();
		D6337EB4 = new System.Windows.Forms.Panel();
		DF13EEBE = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F58A990E);
		E302ED31.SuspendLayout();
		FD2FF902.SuspendLayout();
		grDaTao.SuspendLayout();
		groupBox1.SuspendLayout();
		E71776A7.SuspendLayout();
		D6337EB4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		CF9CB4BE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CF9CB4BE.BackColor = System.Drawing.Color.White;
		CF9CB4BE.BorderRadius = 5;
		CF9CB4BE.BottomSahddow = true;
		CF9CB4BE.color = System.Drawing.Color.SaddleBrown;
		CF9CB4BE.LeftSahddow = false;
		CF9CB4BE.Location = new System.Drawing.Point(0, 0);
		CF9CB4BE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		CF9CB4BE.Name = "bunifuCards1";
		CF9CB4BE.RightSahddow = true;
		CF9CB4BE.ShadowDepth = 20;
		CF9CB4BE.Size = new System.Drawing.Size(466, 47);
		CF9CB4BE.TabIndex = 12;
		E302ED31.BackColor = System.Drawing.Color.White;
		E302ED31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E302ED31.Controls.Add(lblStatus);
		E302ED31.Controls.Add(FD2FF902);
		E302ED31.Controls.Add(txtTypeGet);
		E302ED31.Controls.Add(grDaTao);
		E302ED31.Controls.Add(groupBox1);
		E302ED31.Controls.Add(btnGetCode);
		E302ED31.Controls.Add(btnAdd);
		E302ED31.Controls.Add(E71776A7);
		E302ED31.Dock = System.Windows.Forms.DockStyle.Fill;
		E302ED31.Location = new System.Drawing.Point(0, 0);
		E302ED31.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		E302ED31.Name = "panel1";
		E302ED31.Size = new System.Drawing.Size(795, 404);
		E302ED31.TabIndex = 37;
		E302ED31.Paint += new System.Windows.Forms.PaintEventHandler(E302ED31_Paint);
		lblStatus.AutoSize = true;
		lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
		lblStatus.Location = new System.Drawing.Point(480, 59);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(70, 16);
		lblStatus.TabIndex = 52;
		lblStatus.Text = "Checking...";
		lblStatus.Visible = false;
		FD2FF902.Controls.Add(FEB19414);
		FD2FF902.ForeColor = System.Drawing.Color.DarkRed;
		FD2FF902.Location = new System.Drawing.Point(566, 91);
		FD2FF902.Name = "grChuaTao";
		FD2FF902.Size = new System.Drawing.Size(221, 307);
		FD2FF902.TabIndex = 51;
		FD2FF902.TabStop = false;
		FD2FF902.Text = "Die (0)";
		FEB19414.Dock = System.Windows.Forms.DockStyle.Fill;
		FEB19414.Location = new System.Drawing.Point(3, 19);
		FEB19414.Name = "txtChuaTao";
		FEB19414.Size = new System.Drawing.Size(215, 285);
		FEB19414.TabIndex = 50;
		FEB19414.Text = "";
		FEB19414.WordWrap = false;
		FEB19414.TextChanged += new System.EventHandler(B180593E);
		txtTypeGet.Location = new System.Drawing.Point(675, 56);
		txtTypeGet.Name = "txtTypeGet";
		txtTypeGet.Size = new System.Drawing.Size(28, 23);
		txtTypeGet.TabIndex = 1;
		txtTypeGet.Text = "1";
		txtTypeGet.Visible = false;
		grDaTao.Controls.Add(txtDaTao);
		grDaTao.ForeColor = System.Drawing.Color.DarkGreen;
		grDaTao.Location = new System.Drawing.Point(339, 91);
		grDaTao.Name = "grDaTao";
		grDaTao.Size = new System.Drawing.Size(221, 307);
		grDaTao.TabIndex = 51;
		grDaTao.TabStop = false;
		grDaTao.Text = "Live (0)";
		txtDaTao.Dock = System.Windows.Forms.DockStyle.Fill;
		txtDaTao.Location = new System.Drawing.Point(3, 19);
		txtDaTao.Name = "txtDaTao";
		txtDaTao.Size = new System.Drawing.Size(215, 285);
		txtDaTao.TabIndex = 50;
		txtDaTao.Text = "";
		txtDaTao.WordWrap = false;
		txtDaTao.TextChanged += new System.EventHandler(D7BD8601);
		groupBox1.Controls.Add(C29137B2);
		groupBox1.Controls.Add(EB2EA386);
		groupBox1.Controls.Add(txtNhapTuFile);
		groupBox1.Controls.Add(rbTuNhap);
		groupBox1.Controls.Add(B80C2FAC);
		groupBox1.Location = new System.Drawing.Point(6, 40);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(316, 358);
		groupBox1.TabIndex = 51;
		groupBox1.TabStop = false;
		groupBox1.Text = "Input: Email|Pass mail";
		C29137B2.Cursor = System.Windows.Forms.Cursors.Hand;
		C29137B2.Location = new System.Drawing.Point(243, 21);
		C29137B2.Name = "btnNhapTuFile";
		C29137B2.Size = new System.Drawing.Size(64, 26);
		C29137B2.TabIndex = 2;
		C29137B2.Text = "Chọn";
		C29137B2.Click += new System.EventHandler(C29137B2_Click);
		EB2EA386.Location = new System.Drawing.Point(30, 75);
		EB2EA386.Name = "txtInput";
		EB2EA386.Size = new System.Drawing.Size(277, 277);
		EB2EA386.TabIndex = 50;
		EB2EA386.Text = "";
		EB2EA386.WordWrap = false;
		EB2EA386.TextChanged += new System.EventHandler(EB2EA386_TextChanged);
		txtNhapTuFile.Location = new System.Drawing.Point(110, 22);
		txtNhapTuFile.Name = "txtNhapTuFile";
		txtNhapTuFile.Size = new System.Drawing.Size(127, 23);
		txtNhapTuFile.TabIndex = 1;
		rbTuNhap.AutoSize = true;
		rbTuNhap.Checked = true;
		rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		rbTuNhap.Location = new System.Drawing.Point(9, 49);
		rbTuNhap.Name = "rbTuNhap";
		rbTuNhap.Size = new System.Drawing.Size(94, 20);
		rbTuNhap.TabIndex = 0;
		rbTuNhap.TabStop = true;
		rbTuNhap.Text = "Tự nhập (0)";
		rbTuNhap.UseVisualStyleBackColor = true;
		rbTuNhap.CheckedChanged += new System.EventHandler(rbTuNhap_CheckedChanged);
		B80C2FAC.AutoSize = true;
		B80C2FAC.Cursor = System.Windows.Forms.Cursors.Hand;
		B80C2FAC.Location = new System.Drawing.Point(9, 23);
		B80C2FAC.Name = "rbNhapTuFile";
		B80C2FAC.Size = new System.Drawing.Size(94, 20);
		B80C2FAC.TabIndex = 0;
		B80C2FAC.Text = "Nhập từ File";
		B80C2FAC.UseVisualStyleBackColor = true;
		B80C2FAC.CheckedChanged += new System.EventHandler(B80C2FAC_CheckedChanged);
		btnGetCode.BackColor = System.Drawing.Color.Green;
		btnGetCode.Cursor = System.Windows.Forms.Cursors.Hand;
		btnGetCode.FlatAppearance.BorderSize = 0;
		btnGetCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnGetCode.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnGetCode.ForeColor = System.Drawing.Color.White;
		btnGetCode.Location = new System.Drawing.Point(709, 50);
		btnGetCode.Name = "btnGetCode";
		btnGetCode.Size = new System.Drawing.Size(75, 36);
		btnGetCode.TabIndex = 45;
		btnGetCode.Text = "Get Code";
		btnGetCode.UseVisualStyleBackColor = false;
		btnGetCode.Visible = false;
		btnGetCode.Click += new System.EventHandler(btnGetCode_Click);
		btnAdd.BackColor = System.Drawing.Color.Green;
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(339, 49);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(135, 36);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Check";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		E71776A7.BackColor = System.Drawing.Color.White;
		E71776A7.BorderRadius = 0;
		E71776A7.BottomSahddow = true;
		E71776A7.color = System.Drawing.Color.SaddleBrown;
		E71776A7.Controls.Add(D6337EB4);
		E71776A7.Dock = System.Windows.Forms.DockStyle.Top;
		E71776A7.LeftSahddow = false;
		E71776A7.Location = new System.Drawing.Point(0, 0);
		E71776A7.Name = "bunifuCards2";
		E71776A7.RightSahddow = true;
		E71776A7.ShadowDepth = 20;
		E71776A7.Size = new System.Drawing.Size(793, 37);
		E71776A7.TabIndex = 43;
		D6337EB4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D6337EB4.BackColor = System.Drawing.Color.White;
		D6337EB4.Controls.Add(DF13EEBE);
		D6337EB4.Controls.Add(pictureBox1);
		D6337EB4.Controls.Add(btnMinimize);
		D6337EB4.Controls.Add(lblTitle);
		D6337EB4.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D6337EB4.Location = new System.Drawing.Point(0, 3);
		D6337EB4.Name = "pnlHeader";
		D6337EB4.Size = new System.Drawing.Size(793, 31);
		D6337EB4.TabIndex = 9;
		DF13EEBE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DF13EEBE.Cursor = System.Windows.Forms.Cursors.Hand;
		DF13EEBE.FlatAppearance.BorderSize = 0;
		DF13EEBE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DF13EEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		DF13EEBE.ForeColor = System.Drawing.Color.White;
		DF13EEBE.Image = Class155.Bitmap_15;
		DF13EEBE.Location = new System.Drawing.Point(762, 1);
		DF13EEBE.Name = "button2";
		DF13EEBE.Size = new System.Drawing.Size(30, 30);
		DF13EEBE.TabIndex = 77;
		DF13EEBE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		DF13EEBE.UseVisualStyleBackColor = true;
		DF13EEBE.Click += new System.EventHandler(DF13EEBE_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(C0B07A98);
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
		lblTitle.Size = new System.Drawing.Size(793, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Check có thể kết nối Email bằng Imap không?";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = lblTitle;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(795, 404);
		base.Controls.Add(E302ED31);
		base.Controls.Add(CF9CB4BE);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchCheckImapHotmail";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(C7AD7E30);
		E302ED31.ResumeLayout(false);
		E302ED31.PerformLayout();
		FD2FF902.ResumeLayout(false);
		grDaTao.ResumeLayout(false);
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		E71776A7.ResumeLayout(false);
		D6337EB4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
