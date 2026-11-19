using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchHotmail : Form
{
	[CompilerGenerated]
	private sealed class Class88
	{
		internal string string_0;

		internal int int_0;

		internal fTienIchHotmail fTienIchHotmail_0;
	}

	[CompilerGenerated]
	private sealed class Class89
	{
		internal string string_0;

		internal Class88 C4BF511C;

		internal void C19E4FBF()
		{
			try
			{
				switch (C4BF511C.string_0)
				{
				case "5":
				{
					string text7 = D831098B.D8869319(1, string_0.Split('|')[0], string_0.Split('|')[2] + "|" + string_0.Split('|')[3], 0);
					if (text7.Contains("fail") || text7 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|" + text7);
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text7);
					}
					break;
				}
				case "4":
				{
					string text2 = D831098B.D8869319(0, string_0.Split('|')[0], string_0.Split('|')[2] + "|" + string_0.Split('|')[3], 0);
					if (text2.Contains("fail") || text2 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|" + text2);
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text2);
					}
					break;
				}
				case "3":
				{
					string text3 = D831098B.smethod_0(string_0.Split('|')[0], string_0.Split('|')[1]);
					if (text3 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|");
						break;
					}
					string text4 = D831098B.smethod_2(text3);
					if (text4 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|" + text4);
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text4);
					}
					break;
				}
				case "2":
				{
					string text6 = D831098B.FD246327(1, string_0.Split('|')[0], string_0.Split('|')[1], "", 0, "", "");
					if (text6.Contains("fail") || text6 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|" + text6);
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text6);
					}
					break;
				}
				case "1":
				{
					string text5 = D831098B.FD246327(0, string_0.Split('|')[0], string_0.Split('|')[1], "", 0, "", "");
					if (text5.Contains("fail") || text5 == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|" + text5);
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text5);
					}
					break;
				}
				case "0":
				{
					string text = D831098B.smethod_0(string_0.Split('|')[0], string_0.Split('|')[1]);
					if (text == "")
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtChuaTao, string_0 + "|");
					}
					else
					{
						C4BF511C.fTienIchHotmail_0.method_2(C4BF511C.fTienIchHotmail_0.txtDaTao, string_0 + "|" + text);
					}
					break;
				}
				}
			}
			catch (Exception object_)
			{
				MsBoxHelper.Show(object_, 2);
			}
			Interlocked.Decrement(ref C4BF511C.int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class90
	{
		internal RichTextBox D88E023E;

		internal string string_0;

		internal void method_0()
		{
			Application.DoEvents();
			RichTextBox d88E023E = D88E023E;
			d88E023E.Text = d88E023E.Text + string_0 + "\r\n";
		}
	}

	internal IContainer F2BCAE37 = null;

	internal BunifuCards DEB226A2;

	internal Panel panel1;

	internal BunifuDragControl C1A26688;

	internal BunifuCards BD393D22;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel lblTitle;

	internal Button btnAdd;

	internal RichTextBox txtInput;

	internal GroupBox BA3D3DAD;

	internal RichTextBox txtDaTao;

	internal GroupBox A710BD20;

	internal ComboBox cbbFunctions;

	internal Label label1;

	internal GroupBox C92CA2AB;

	internal RichTextBox txtChuaTao;

	public fTienIchHotmail()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Login hotmail");
		dictionary.Add("1", "Get otp Add mail");
		dictionary.Add("2", "Get otp Checkpoint");
		dictionary.Add("3", "Get OAuth2");
		dictionary.Add("4", "Get otp Add mail OAuth2");
		dictionary.Add("5", "Get otp Checkpoint OAuth2");
		Commom.smethod_24(cbbFunctions, dictionary);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void method_1()
	{
		try
		{
			List<string> list = txtInput.smethod_7();
			string string_ = cbbFunctions.SelectedValue.ToString();
			int int_0 = 0;
			int num = 50;
			int num2 = 0;
			while (num2 < list.Count)
			{
				if (int_0 < num)
				{
					Interlocked.Increment(ref int_0);
					string string_0 = list[num2++];
					new Thread((ThreadStart)delegate
					{
						try
						{
							switch (string_)
							{
							case "5":
							{
								string text7 = D831098B.D8869319(1, string_0.Split('|')[0], string_0.Split('|')[2] + "|" + string_0.Split('|')[3], 0);
								if (text7.Contains("fail") || text7 == "")
								{
									method_2(txtChuaTao, string_0 + "|" + text7);
								}
								else
								{
									method_2(txtDaTao, string_0 + "|" + text7);
								}
								break;
							}
							case "4":
							{
								string text2 = D831098B.D8869319(0, string_0.Split('|')[0], string_0.Split('|')[2] + "|" + string_0.Split('|')[3], 0);
								if (text2.Contains("fail") || text2 == "")
								{
									method_2(txtChuaTao, string_0 + "|" + text2);
								}
								else
								{
									method_2(txtDaTao, string_0 + "|" + text2);
								}
								break;
							}
							case "3":
							{
								string text3 = D831098B.smethod_0(string_0.Split('|')[0], string_0.Split('|')[1]);
								if (text3 == "")
								{
									method_2(txtChuaTao, string_0 + "|");
								}
								else
								{
									string text4 = D831098B.smethod_2(text3);
									if (text4 == "")
									{
										method_2(txtChuaTao, string_0 + "|" + text4);
									}
									else
									{
										method_2(txtDaTao, string_0 + "|" + text4);
									}
								}
								break;
							}
							case "2":
							{
								string text6 = D831098B.FD246327(1, string_0.Split('|')[0], string_0.Split('|')[1], "", 0, "", "");
								if (text6.Contains("fail") || text6 == "")
								{
									method_2(txtChuaTao, string_0 + "|" + text6);
								}
								else
								{
									method_2(txtDaTao, string_0 + "|" + text6);
								}
								break;
							}
							case "1":
							{
								string text5 = D831098B.FD246327(0, string_0.Split('|')[0], string_0.Split('|')[1], "", 0, "", "");
								if (text5.Contains("fail") || text5 == "")
								{
									method_2(txtChuaTao, string_0 + "|" + text5);
								}
								else
								{
									method_2(txtDaTao, string_0 + "|" + text5);
								}
								break;
							}
							case "0":
							{
								string text = D831098B.smethod_0(string_0.Split('|')[0], string_0.Split('|')[1]);
								if (text == "")
								{
									method_2(txtChuaTao, string_0 + "|");
								}
								else
								{
									method_2(txtDaTao, string_0 + "|" + text);
								}
								break;
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
			MsBoxHelper.Show("Đã check xong!");
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void method_2(RichTextBox D19655B5, string EC8F5820)
	{
		D19655B5.Invoke((MethodInvoker)delegate
		{
			Application.DoEvents();
			RichTextBox richTextBox = D19655B5;
			richTextBox.Text = richTextBox.Text + EC8F5820 + "\r\n";
		});
	}

	private void C2013C1E(object sender, EventArgs e)
	{
		Commom.FE214EB5(txtDaTao, BA3D3DAD);
	}

	private void BC0EBD0E(object sender, PaintEventArgs e)
	{
	}

	private void fTienIchHotmail_Load(object sender, EventArgs e)
	{
	}

	private void E8271DAC(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtChuaTao.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			C92CA2AB.Text = string.Format(Language.GetValue("Die ({0})"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void E2B2DB0C(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F2BCAE37 != null)
		{
			F2BCAE37.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F2BCAE37 = new System.ComponentModel.Container();
		DEB226A2 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		cbbFunctions = new System.Windows.Forms.ComboBox();
		label1 = new System.Windows.Forms.Label();
		C92CA2AB = new System.Windows.Forms.GroupBox();
		txtChuaTao = new System.Windows.Forms.RichTextBox();
		BA3D3DAD = new System.Windows.Forms.GroupBox();
		txtDaTao = new System.Windows.Forms.RichTextBox();
		A710BD20 = new System.Windows.Forms.GroupBox();
		txtInput = new System.Windows.Forms.RichTextBox();
		btnAdd = new System.Windows.Forms.Button();
		BD393D22 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		C1A26688 = new Bunifu.Framework.UI.BunifuDragControl(F2BCAE37);
		panel1.SuspendLayout();
		C92CA2AB.SuspendLayout();
		BA3D3DAD.SuspendLayout();
		A710BD20.SuspendLayout();
		BD393D22.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		DEB226A2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DEB226A2.BackColor = System.Drawing.Color.White;
		DEB226A2.BorderRadius = 5;
		DEB226A2.BottomSahddow = true;
		DEB226A2.color = System.Drawing.Color.SaddleBrown;
		DEB226A2.LeftSahddow = false;
		DEB226A2.Location = new System.Drawing.Point(0, 0);
		DEB226A2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		DEB226A2.Name = "bunifuCards1";
		DEB226A2.RightSahddow = true;
		DEB226A2.ShadowDepth = 20;
		DEB226A2.Size = new System.Drawing.Size(469, 47);
		DEB226A2.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(cbbFunctions);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(C92CA2AB);
		panel1.Controls.Add(BA3D3DAD);
		panel1.Controls.Add(A710BD20);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(BD393D22);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(798, 405);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(BC0EBD0E);
		cbbFunctions.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbFunctions.FormattingEnabled = true;
		cbbFunctions.Location = new System.Drawing.Point(405, 50);
		cbbFunctions.Name = "cbbFunctions";
		cbbFunctions.Size = new System.Drawing.Size(265, 24);
		cbbFunctions.TabIndex = 54;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(339, 53);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(60, 16);
		label1.TabIndex = 53;
		label1.Text = "Function:";
		C92CA2AB.Controls.Add(txtChuaTao);
		C92CA2AB.ForeColor = System.Drawing.Color.DarkRed;
		C92CA2AB.Location = new System.Drawing.Point(339, 251);
		C92CA2AB.Name = "grChuaTao";
		C92CA2AB.Size = new System.Drawing.Size(448, 147);
		C92CA2AB.TabIndex = 51;
		C92CA2AB.TabStop = false;
		C92CA2AB.Text = "Fail (0)";
		txtChuaTao.Dock = System.Windows.Forms.DockStyle.Fill;
		txtChuaTao.Location = new System.Drawing.Point(3, 19);
		txtChuaTao.Name = "txtChuaTao";
		txtChuaTao.Size = new System.Drawing.Size(442, 125);
		txtChuaTao.TabIndex = 50;
		txtChuaTao.Text = "";
		txtChuaTao.WordWrap = false;
		txtChuaTao.TextChanged += new System.EventHandler(E8271DAC);
		BA3D3DAD.Controls.Add(txtDaTao);
		BA3D3DAD.ForeColor = System.Drawing.Color.DarkGreen;
		BA3D3DAD.Location = new System.Drawing.Point(339, 91);
		BA3D3DAD.Name = "grDaTao";
		BA3D3DAD.Size = new System.Drawing.Size(448, 154);
		BA3D3DAD.TabIndex = 51;
		BA3D3DAD.TabStop = false;
		BA3D3DAD.Text = "Success (0)";
		txtDaTao.Dock = System.Windows.Forms.DockStyle.Fill;
		txtDaTao.Location = new System.Drawing.Point(3, 19);
		txtDaTao.Name = "txtDaTao";
		txtDaTao.Size = new System.Drawing.Size(442, 132);
		txtDaTao.TabIndex = 50;
		txtDaTao.Text = "";
		txtDaTao.WordWrap = false;
		txtDaTao.TextChanged += new System.EventHandler(C2013C1E);
		A710BD20.Controls.Add(txtInput);
		A710BD20.Location = new System.Drawing.Point(6, 40);
		A710BD20.Name = "groupBox1";
		A710BD20.Size = new System.Drawing.Size(316, 358);
		A710BD20.TabIndex = 51;
		A710BD20.TabStop = false;
		A710BD20.Text = "Input: Email|Pass mail";
		txtInput.Location = new System.Drawing.Point(8, 22);
		txtInput.Name = "txtInput";
		txtInput.Size = new System.Drawing.Size(301, 330);
		txtInput.TabIndex = 50;
		txtInput.Text = "";
		txtInput.WordWrap = false;
		btnAdd.BackColor = System.Drawing.Color.Green;
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(676, 44);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(111, 36);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Check";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		BD393D22.BackColor = System.Drawing.Color.White;
		BD393D22.BorderRadius = 0;
		BD393D22.BottomSahddow = true;
		BD393D22.color = System.Drawing.Color.SaddleBrown;
		BD393D22.Controls.Add(pnlHeader);
		BD393D22.Dock = System.Windows.Forms.DockStyle.Top;
		BD393D22.LeftSahddow = false;
		BD393D22.Location = new System.Drawing.Point(0, 0);
		BD393D22.Name = "bunifuCards2";
		BD393D22.RightSahddow = true;
		BD393D22.ShadowDepth = 20;
		BD393D22.Size = new System.Drawing.Size(796, 37);
		BD393D22.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(796, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(765, 1);
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
		pictureBox1.Click += new System.EventHandler(E2B2DB0C);
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
		lblTitle.Size = new System.Drawing.Size(796, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Hotmail";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C1A26688.Fixed = true;
		C1A26688.Horizontal = true;
		C1A26688.TargetControl = lblTitle;
		C1A26688.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(798, 405);
		base.Controls.Add(panel1);
		base.Controls.Add(DEB226A2);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchHotmail";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fTienIchHotmail_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		C92CA2AB.ResumeLayout(false);
		BA3D3DAD.ResumeLayout(false);
		A710BD20.ResumeLayout(false);
		BD393D22.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
