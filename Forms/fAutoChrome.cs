using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

public class fAutoChrome : Form
{
	[CompilerGenerated]
	private sealed class FB8B3781
	{
		internal fAutoChrome D9914E9E;

		internal string string_0;

		internal void method_0()
		{
			try
			{
				D9914E9E.btnRun.smethod_1(bool_0: false);
				D9914E9E.btnStop.smethod_1();
				D9914E9E.txtResult.smethod_2("Running...");
				string text = new Chrome
				{
					Int32_2 = D9914E9E.BB9837AF,
					String_5 = D9914E9E.C822DCA2,
					Boolean_5 = false
				}.RunCodeChrome(string_0);
				D9914E9E.txtResult.smethod_2(string.IsNullOrEmpty(text) ? "Empty" : text);
				D9914E9E.btnRun.smethod_1();
			}
			catch (Exception)
			{
			}
		}
	}

	internal int BB9837AF;

	internal string C822DCA2;

	internal IContainer icontainer_0 = null;

	internal RichTextBox txtCode;

	internal Button btnRun;

	internal RichTextBox txtResult;

	internal PictureBox FDB81B37;

	internal Button button1;

	internal Button btnStop;

	public fAutoChrome(int A39FC6BE, string A6BCB39B)
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		BB9837AF = A39FC6BE;
		C822DCA2 = A6BCB39B;
	}

	private void E98BEA9C(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configGeneral").method_4("txtCode", txtCode.Text);
		C5034B95.smethod_0("configGeneral").AEBFED04();
		string string_0 = txtCode.SelectedText.Trim();
		if (string_0 == "")
		{
			string_0 = txtCode.Text.Trim();
		}
		if (File.Exists(string_0))
		{
			string_0 = File.ReadAllText(string_0).Trim();
			if (string_0.Contains("#region"))
			{
				string_0 = Regex.Match(string_0, "\\/\\/\\#region(.*?)\\/\\/\\#endregion", RegexOptions.Singleline).Groups[1].Value.Trim();
			}
		}
		if (string.IsNullOrEmpty(string_0))
		{
			return;
		}
		new Thread((ThreadStart)delegate
		{
			try
			{
				btnRun.smethod_1(bool_0: false);
				btnStop.smethod_1();
				txtResult.smethod_2("Running...");
				string text = new Chrome
				{
					Int32_2 = BB9837AF,
					String_5 = C822DCA2,
					Boolean_5 = false
				}.RunCodeChrome(string_0);
				txtResult.smethod_2(string.IsNullOrEmpty(text) ? "Empty" : text);
				btnRun.smethod_1();
			}
			catch (Exception)
			{
			}
		}).Start();
	}

	private void D2941BAF(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F5)
		{
			E98BEA9C(null, null);
		}
	}

	private void E9B93C85(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F5)
		{
			E98BEA9C(null, null);
		}
	}

	private void fAutoChrome_Load(object sender, EventArgs e)
	{
		txtCode.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtCode");
	}

	private void FA91062A(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			string text = new Chrome
			{
				Int32_2 = BB9837AF,
				String_5 = C822DCA2
			}.method_66("ScreenshotToBase64");
			if (!(text == ""))
			{
				byte[] buffer = Convert.FromBase64String(text);
				using MemoryStream stream = new MemoryStream(buffer);
				FDB81B37.Image = Image.FromStream(stream);
			}
		}).Start();
	}

	private void btnStop_Click(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			try
			{
				btnStop.smethod_1(bool_0: false);
				Chrome chrome = new Chrome();
				chrome.Int32_2 = BB9837AF;
				chrome.String_5 = C822DCA2;
				chrome.Boolean_5 = false;
				chrome.B5A45B08();
			}
			catch (Exception)
			{
			}
		}).Start();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAutoChrome));
		txtCode = new System.Windows.Forms.RichTextBox();
		btnRun = new System.Windows.Forms.Button();
		txtResult = new System.Windows.Forms.RichTextBox();
		FDB81B37 = new System.Windows.Forms.PictureBox();
		button1 = new System.Windows.Forms.Button();
		btnStop = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)FDB81B37).BeginInit();
		SuspendLayout();
		txtCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtCode.Location = new System.Drawing.Point(13, 13);
		txtCode.Name = "txtCode";
		txtCode.Size = new System.Drawing.Size(614, 28);
		txtCode.TabIndex = 0;
		txtCode.Text = "";
		txtCode.WordWrap = false;
		txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(D2941BAF);
		btnRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		btnRun.Location = new System.Drawing.Point(263, 47);
		btnRun.Name = "btnRun";
		btnRun.Size = new System.Drawing.Size(261, 35);
		btnRun.TabIndex = 1;
		btnRun.Text = "Run (F5)";
		btnRun.UseVisualStyleBackColor = true;
		btnRun.Click += new System.EventHandler(E98BEA9C);
		txtResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtResult.Location = new System.Drawing.Point(263, 88);
		txtResult.Name = "txtResult";
		txtResult.Size = new System.Drawing.Size(364, 260);
		txtResult.TabIndex = 0;
		txtResult.Text = "";
		txtResult.WordWrap = false;
		FDB81B37.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		FDB81B37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		FDB81B37.Location = new System.Drawing.Point(13, 47);
		FDB81B37.Name = "pictureBox1";
		FDB81B37.Size = new System.Drawing.Size(244, 260);
		FDB81B37.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		FDB81B37.TabIndex = 2;
		FDB81B37.TabStop = false;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		button1.Location = new System.Drawing.Point(12, 313);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(245, 35);
		button1.TabIndex = 1;
		button1.Text = "Capture";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(FA91062A);
		btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		btnStop.Location = new System.Drawing.Point(530, 47);
		btnStop.Name = "btnStop";
		btnStop.Size = new System.Drawing.Size(97, 35);
		btnStop.TabIndex = 1;
		btnStop.Text = "Stop";
		btnStop.UseVisualStyleBackColor = true;
		btnStop.Click += new System.EventHandler(btnStop_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(640, 358);
		base.Controls.Add(FDB81B37);
		base.Controls.Add(button1);
		base.Controls.Add(btnStop);
		base.Controls.Add(btnRun);
		base.Controls.Add(txtResult);
		base.Controls.Add(txtCode);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "fAutoChrome";
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Auto Chrome";
		base.Load += new System.EventHandler(fAutoChrome_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(E9B93C85);
		((System.ComponentModel.ISupportInitialize)FDB81B37).EndInit();
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_0()
	{
		string text = new Chrome
		{
			Int32_2 = BB9837AF,
			String_5 = C822DCA2
		}.method_66("ScreenshotToBase64");
		if (!(text == ""))
		{
			byte[] buffer = Convert.FromBase64String(text);
			using MemoryStream stream = new MemoryStream(buffer);
			FDB81B37.Image = Image.FromStream(stream);
		}
	}

	[CompilerGenerated]
	private void B8B81087()
	{
		try
		{
			btnStop.smethod_1(bool_0: false);
			Chrome chrome = new Chrome();
			chrome.Int32_2 = BB9837AF;
			chrome.String_5 = C822DCA2;
			chrome.Boolean_5 = false;
			chrome.B5A45B08();
		}
		catch (Exception)
		{
		}
	}
}
