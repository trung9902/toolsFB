using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ucContact3 : UserControl
{
	internal IContainer D20C9215 = null;

	internal LinkLabel linkLabel1;

	internal LinkLabel linkLabel2;

	internal Label label4;

	internal Label F6A1B3BD;

	internal Label FE2C5B0C;

	internal PictureBox pictureBox2;

	internal PictureBox pictureBox1;

	internal LinkLabel FA327EAE;

	public ucContact3()
	{
		InitializeComponent();
		Controls.Clear();
		ucContact uc = new ucContact();
		uc.Dock = DockStyle.Fill;
		Controls.Add(uc);
	}

	private void B10DD4BC(object sender, EventArgs e)
	{
		method_0(sender);
	}

	private void method_0(object object_0)
	{
		string d6BE2B8B = (object_0 as LinkLabel).Text;
		Commom.CE2E5B3B(d6BE2B8B);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D20C9215 != null)
		{
			D20C9215.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		linkLabel2 = new System.Windows.Forms.LinkLabel();
		label4 = new System.Windows.Forms.Label();
		F6A1B3BD = new System.Windows.Forms.Label();
		FE2C5B0C = new System.Windows.Forms.Label();
		FA327EAE = new System.Windows.Forms.LinkLabel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		linkLabel1.AutoSize = true;
		linkLabel1.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		linkLabel1.Location = new System.Drawing.Point(316, 344);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(232, 21);
		linkLabel1.TabIndex = 9;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "https://www.oaksoftware.net";
		linkLabel1.Click += new System.EventHandler(B10DD4BC);
		linkLabel2.AutoSize = true;
		linkLabel2.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		linkLabel2.Location = new System.Drawing.Point(316, 299);
		linkLabel2.Name = "linkLabel2";
		linkLabel2.Size = new System.Drawing.Size(164, 21);
		linkLabel2.TabIndex = 9;
		linkLabel2.TabStop = true;
		linkLabel2.Text = "@oaksoftwareofficial";
		linkLabel2.Click += new System.EventHandler(B10DD4BC);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.Color.Black;
		label4.Location = new System.Drawing.Point(225, 344);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(76, 21);
		label4.TabIndex = 2;
		label4.Text = "Website:";
		F6A1B3BD.AutoSize = true;
		F6A1B3BD.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F6A1B3BD.ForeColor = System.Drawing.Color.Black;
		F6A1B3BD.Location = new System.Drawing.Point(225, 256);
		F6A1B3BD.Name = "label5";
		F6A1B3BD.Size = new System.Drawing.Size(92, 21);
		F6A1B3BD.TabIndex = 2;
		F6A1B3BD.Text = "Instagram:";
		FE2C5B0C.AutoSize = true;
		FE2C5B0C.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FE2C5B0C.ForeColor = System.Drawing.Color.Black;
		FE2C5B0C.Location = new System.Drawing.Point(225, 299);
		FE2C5B0C.Name = "label6";
		FE2C5B0C.Size = new System.Drawing.Size(86, 21);
		FE2C5B0C.TabIndex = 2;
		FE2C5B0C.Text = "Telegram:";
		FA327EAE.AutoSize = true;
		FA327EAE.Font = new System.Drawing.Font("Tahoma", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FA327EAE.Location = new System.Drawing.Point(316, 256);
		FA327EAE.Name = "linkLabel3";
		FA327EAE.Size = new System.Drawing.Size(373, 21);
		FA327EAE.TabIndex = 9;
		FA327EAE.TabStop = true;
		FA327EAE.Text = "https://www.instagram.com/oaksoftware.official\r\n";
		FA327EAE.Click += new System.EventHandler(B10DD4BC);
		pictureBox2.Image = Class155.F88F1980;
		pictureBox2.Location = new System.Drawing.Point(7, 188);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(212, 265);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox2.TabIndex = 23;
		pictureBox2.TabStop = false;
		pictureBox1.Image = Class155.C83DA30F;
		pictureBox1.Location = new System.Drawing.Point(49, 36);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(620, 130);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 22;
		pictureBox1.TabStop = false;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(linkLabel1);
		base.Controls.Add(FA327EAE);
		base.Controls.Add(pictureBox2);
		base.Controls.Add(linkLabel2);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(label4);
		base.Controls.Add(F6A1B3BD);
		base.Controls.Add(FE2C5B0C);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucContact3";
		base.Size = new System.Drawing.Size(714, 470);
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
