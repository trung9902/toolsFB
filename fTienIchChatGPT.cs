using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchChatGPT : Form
{
	internal static List<string> list_0;

	internal static List<string> list_1;

	internal static bool DCA65E05;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel D98FD72F;

	internal BunifuCustomLabel E3BE4B0A;

	internal Button btnMinimize;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox BC23C903;

	internal RichTextBox txtContent;

	internal Label A406B1A1;

	internal Label F58B3D8C;

	internal Button btnCheck;

	internal Label label2;

	internal TextBox txtApiKey;

	internal RichTextBox C2810926;

	internal ProgressBar progressBar;

	internal LinkLabel linkLabel1;

	internal CheckBox ckbWordWap;

	public fTienIchChatGPT()
	{
		InitializeComponent();
		DCA65E05 = false;
		Language.CD21F0A9(this);
		txtApiKey.Text = C5034B95.smethod_0("configChatGPT").BDB80B23("apiKey");
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C2810926_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContent, A406B1A1);
	}

	private void C3839DB5(object sender, EventArgs e)
	{
		if (txtApiKey.Text.Trim() == "")
		{
			MsBoxHelper.Show("Vui lòng nhập API Key!", 3);
			txtApiKey.Focus();
			return;
		}
		C5034B95.smethod_0("configChatGPT").method_4("apiKey", txtApiKey.Text.Trim());
		C5034B95.smethod_1("configChatGPT");
		if (txtContent.Text.Trim() == "")
		{
			MsBoxHelper.Show("Vui lòng nhập nội dung!", 3);
			txtContent.Focus();
			return;
		}
		string string_0 = txtApiKey.Text.Trim();
		string rawContent = txtContent.Text.Trim();
		Thread thread = new Thread((ThreadStart)delegate
		{
			method_0(F03FF037: true);
			string string_ = "";
			try
			{
				if (string_0.StartsWith("sk-"))
				{
					string_ = Commom.CallDeepSeekApi(string_0, rawContent, "deepseek-chat");
				}
				else
				{
					string safeContent = rawContent.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"").Replace("'", "\\'");
					string_ = Commom.smethod_85("Gemini('" + string_0 + "', '" + safeContent + "')");
				}
			}
			catch (Exception ex)
			{
				string_ = "Error: " + ex.Message;
			}
			method_0(F03FF037: false);
			C2810926.Invoke((MethodInvoker)delegate
			{
				C2810926.Text = string_;
			});
		});
		thread.IsBackground = true;
		thread.Start();
	}

	private void method_0(bool F03FF037)
	{
		progressBar.Invoke((MethodInvoker)delegate
		{
			progressBar.Visible = F03FF037;
		});
	}

	private void C00C4E2C(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.CE2E5B3B("https://www.youtube.com/watch?v=alxMQWAaS2M");
	}

	private void ckbWordWap_CheckedChanged(object sender, EventArgs e)
	{
		C2810926.WordWrap = ckbWordWap.Checked;
	}

	protected override void Dispose(bool F9846E8B)
	{
		if (F9846E8B && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(F9846E8B);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		D98FD72F = new System.Windows.Forms.Panel();
		BC23C903 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		E3BE4B0A = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		txtContent = new System.Windows.Forms.RichTextBox();
		A406B1A1 = new System.Windows.Forms.Label();
		F58B3D8C = new System.Windows.Forms.Label();
		btnCheck = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		txtApiKey = new System.Windows.Forms.TextBox();
		C2810926 = new System.Windows.Forms.RichTextBox();
		progressBar = new System.Windows.Forms.ProgressBar();
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		ckbWordWap = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		D98FD72F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BC23C903).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(D98FD72F);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(840, 34);
		bunifuCards1.TabIndex = 0;
		D98FD72F.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D98FD72F.BackColor = System.Drawing.Color.White;
		D98FD72F.Controls.Add(BC23C903);
		D98FD72F.Controls.Add(btnMinimize);
		D98FD72F.Controls.Add(E3BE4B0A);
		D98FD72F.Location = new System.Drawing.Point(0, 3);
		D98FD72F.Name = "pnlHeader";
		D98FD72F.Size = new System.Drawing.Size(840, 28);
		D98FD72F.TabIndex = 9;
		BC23C903.Cursor = System.Windows.Forms.Cursors.Default;
		BC23C903.Image = Class155.DD225F0D;
		BC23C903.Location = new System.Drawing.Point(3, 2);
		BC23C903.Name = "pictureBox1";
		BC23C903.Size = new System.Drawing.Size(34, 27);
		BC23C903.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		BC23C903.TabIndex = 17;
		BC23C903.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = Class155.Bitmap_15;
		btnMinimize.Location = new System.Drawing.Point(808, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 28);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		E3BE4B0A.BackColor = System.Drawing.Color.Transparent;
		E3BE4B0A.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E3BE4B0A.Dock = System.Windows.Forms.DockStyle.Fill;
		E3BE4B0A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E3BE4B0A.ForeColor = System.Drawing.Color.Black;
		E3BE4B0A.Location = new System.Drawing.Point(0, 0);
		E3BE4B0A.Name = "bunifuCustomLabel1";
		E3BE4B0A.Size = new System.Drawing.Size(840, 28);
		E3BE4B0A.TabIndex = 1;
		E3BE4B0A.Text = "AI Content Assistant (DeepSeek / Gemini / ChatGPT)";
		E3BE4B0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = E3BE4B0A;
		bunifuDragControl_0.Vertical = true;
		txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtContent.Font = new System.Drawing.Font("Tahoma", 9.75f);
		txtContent.Location = new System.Drawing.Point(13, 92);
		txtContent.Name = "txtContent";
		txtContent.Size = new System.Drawing.Size(813, 121);
		txtContent.TabIndex = 146;
		txtContent.Text = "";
		txtContent.WordWrap = false;
		txtContent.TextChanged += new System.EventHandler(C2810926_TextChanged);
		A406B1A1.AutoSize = true;
		A406B1A1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A406B1A1.Location = new System.Drawing.Point(10, 73);
		A406B1A1.Name = "label17";
		A406B1A1.Size = new System.Drawing.Size(94, 16);
		A406B1A1.TabIndex = 145;
		A406B1A1.Text = "Nhập nội dung:";
		F58B3D8C.AutoSize = true;
		F58B3D8C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F58B3D8C.Location = new System.Drawing.Point(10, 277);
		F58B3D8C.Name = "label1";
		F58B3D8C.Size = new System.Drawing.Size(55, 16);
		F58B3D8C.TabIndex = 145;
		F58B3D8C.Text = "Kết quả:";
		btnCheck.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCheck.FlatAppearance.BorderSize = 0;
		btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCheck.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCheck.ForeColor = System.Drawing.Color.White;
		btnCheck.Location = new System.Drawing.Point(364, 230);
		btnCheck.Name = "btnCheck";
		btnCheck.Size = new System.Drawing.Size(118, 33);
		btnCheck.TabIndex = 147;
		btnCheck.Text = "Start";
		btnCheck.UseVisualStyleBackColor = false;
		btnCheck.Click += new System.EventHandler(C3839DB5);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label2.Location = new System.Drawing.Point(10, 50);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(55, 16);
		label2.TabIndex = 145;
		label2.Text = "API Key:";
		txtApiKey.Font = new System.Drawing.Font("Tahoma", 9.75f);
		txtApiKey.Location = new System.Drawing.Point(71, 47);
		txtApiKey.Name = "txtApiKey";
		txtApiKey.Size = new System.Drawing.Size(755, 23);
		txtApiKey.TabIndex = 148;
		C2810926.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C2810926.Font = new System.Drawing.Font("Tahoma", 9.75f);
		C2810926.Location = new System.Drawing.Point(13, 296);
		C2810926.Name = "txtResult";
		C2810926.Size = new System.Drawing.Size(813, 293);
		C2810926.TabIndex = 146;
		C2810926.Text = "";
		C2810926.WordWrap = false;
		C2810926.TextChanged += new System.EventHandler(C2810926_TextChanged);
		progressBar.Location = new System.Drawing.Point(521, 235);
		progressBar.Name = "progressBar";
		progressBar.Size = new System.Drawing.Size(258, 23);
		progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
		progressBar.TabIndex = 149;
		progressBar.Visible = false;
		linkLabel1.AutoSize = true;
		linkLabel1.Location = new System.Drawing.Point(12, 238);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(288, 16);
		linkLabel1.TabIndex = 150;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "Hướng dẫn tạo tài khoản ChatGPT và lấy API Key!";
		linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(C00C4E2C);
		ckbWordWap.AutoSize = true;
		ckbWordWap.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWordWap.Location = new System.Drawing.Point(743, 276);
		ckbWordWap.Name = "ckbWordWap";
		ckbWordWap.Size = new System.Drawing.Size(88, 20);
		ckbWordWap.TabIndex = 151;
		ckbWordWap.Text = "WordWrap";
		ckbWordWap.UseVisualStyleBackColor = true;
		ckbWordWap.CheckedChanged += new System.EventHandler(ckbWordWap_CheckedChanged);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(840, 601);
		base.Controls.Add(ckbWordWap);
		base.Controls.Add(linkLabel1);
		base.Controls.Add(progressBar);
		base.Controls.Add(txtApiKey);
		base.Controls.Add(btnCheck);
		base.Controls.Add(C2810926);
		base.Controls.Add(txtContent);
		base.Controls.Add(label2);
		base.Controls.Add(F58B3D8C);
		base.Controls.Add(A406B1A1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fTienIchChatGPT";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		bunifuCards1.ResumeLayout(false);
		D98FD72F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)BC23C903).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
