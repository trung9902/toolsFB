using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class ucContact2 : UserControl
{
	internal IContainer icontainer_0 = null;

	internal Label label12;

	internal Label label3;

	internal Panel DA04C92E;

	internal LinkLabel linkLabel1;

	internal LinkLabel linkLabel2;

	internal Label label4;

	internal Label label5;

	internal Label label6;

	internal Label E9AB1385;

	internal PictureBox E5852D99;

	internal PictureBox pictureBox1;

	internal Label label1;

	internal Label label7;

	internal Label label2;

	public ucContact2()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void EB97CD38(object sender, EventArgs e)
	{
		string text = (sender as LinkLabel).Text;
		try
		{
			Process.Start("chrome.exe", text);
		}
		catch
		{
			Process.Start(text);
		}
	}

	private void BE2BA9A6(object sender, LinkLabelLinkClickedEventArgs e)
	{
	}

	protected override void Dispose(bool D28A4091)
	{
		if (D28A4091 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D28A4091);
	}

	private void InitializeComponent()
	{
		label12 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		DA04C92E = new System.Windows.Forms.Panel();
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		linkLabel2 = new System.Windows.Forms.LinkLabel();
		label4 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		E9AB1385 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		E5852D99 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		DA04C92E.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E5852D99).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label12.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.ForeColor = System.Drawing.Color.Red;
		label12.Location = new System.Drawing.Point(214, 355);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(489, 110);
		label12.TabIndex = 28;
		label12.Text = "Chú ý: Nghiêm cấm sử dụng phần mềm vào các mục đích xấu, vi phạm pháp luật. Nếu cố tình sẽ bị xóa khỏi hệ thống vĩnh viễn, và phải chịu hoàn toàn trách nhiệm trước pháp luật.";
		label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
		label3.Location = new System.Drawing.Point(209, 172);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(164, 25);
		label3.TabIndex = 27;
		label3.Text = "Hỗ trợ phần mềm:";
		DA04C92E.BackColor = System.Drawing.Color.WhiteSmoke;
		DA04C92E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DA04C92E.Controls.Add(linkLabel1);
		DA04C92E.Controls.Add(linkLabel2);
		DA04C92E.Controls.Add(label4);
		DA04C92E.Controls.Add(label7);
		DA04C92E.Controls.Add(label5);
		DA04C92E.Controls.Add(label6);
		DA04C92E.Controls.Add(label2);
		DA04C92E.Controls.Add(E9AB1385);
		DA04C92E.Location = new System.Drawing.Point(214, 200);
		DA04C92E.Name = "panel2";
		DA04C92E.Size = new System.Drawing.Size(489, 121);
		DA04C92E.TabIndex = 25;
		linkLabel1.AutoSize = true;
		linkLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		linkLabel1.Location = new System.Drawing.Point(94, 4);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(190, 25);
		linkLabel1.TabIndex = 9;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "https://bit.ly/43sB9Zq";
		linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(BE2BA9A6);
		linkLabel1.Click += new System.EventHandler(EB97CD38);
		linkLabel2.AutoSize = true;
		linkLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		linkLabel2.Location = new System.Drawing.Point(94, 33);
		linkLabel2.Name = "linkLabel2";
		linkLabel2.Size = new System.Drawing.Size(190, 25);
		linkLabel2.TabIndex = 9;
		linkLabel2.TabStop = true;
		linkLabel2.Text = "https://bit.ly/43sB9Zq";
		linkLabel2.Click += new System.EventHandler(EB97CD38);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.Color.Black;
		label4.Location = new System.Drawing.Point(3, 4);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(83, 25);
		label4.TabIndex = 2;
		label4.Text = "Website:";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.Black;
		label7.Location = new System.Drawing.Point(3, 91);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(62, 25);
		label7.TabIndex = 2;
		label7.Text = "CSKH:";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.Black;
		label5.Location = new System.Drawing.Point(3, 64);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(77, 25);
		label5.TabIndex = 2;
		label5.Text = "Hotline:";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.ForeColor = System.Drawing.Color.Black;
		label6.Location = new System.Drawing.Point(3, 33);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(87, 25);
		label6.TabIndex = 2;
		label6.Text = "Fanpage:";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(94, 91);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(128, 25);
		label2.TabIndex = 2;
		label2.Text = "087-777-8777";
		E9AB1385.AutoSize = true;
		E9AB1385.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E9AB1385.ForeColor = System.Drawing.Color.Black;
		E9AB1385.Location = new System.Drawing.Point(94, 64);
		E9AB1385.Name = "label11";
		E9AB1385.Size = new System.Drawing.Size(128, 25);
		E9AB1385.TabIndex = 2;
		E9AB1385.Text = "089-999-8999";
		label1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(33, 143);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(653, 21);
		label1.TabIndex = 21;
		label1.Text = "PHẦN MỀM HỖ TRỢ KINH DOANH ONLINE - TỰ ĐỘNG HÓA MỌI THAO TÁC CỦA BẠN";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E5852D99.Image = Class155.Bitmap_13;
		E5852D99.Location = new System.Drawing.Point(-17, 172);
		E5852D99.Name = "pictureBox2";
		E5852D99.Size = new System.Drawing.Size(229, 293);
		E5852D99.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E5852D99.TabIndex = 23;
		E5852D99.TabStop = false;
		pictureBox1.Image = Class155.Bitmap_14;
		pictureBox1.Location = new System.Drawing.Point(66, 3);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(620, 130);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		pictureBox1.TabIndex = 22;
		pictureBox1.TabStop = false;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(label12);
		base.Controls.Add(label3);
		base.Controls.Add(DA04C92E);
		base.Controls.Add(E5852D99);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(label1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucContact2";
		base.Size = new System.Drawing.Size(714, 470);
		DA04C92E.ResumeLayout(false);
		DA04C92E.PerformLayout();
		((System.ComponentModel.ISupportInitialize)E5852D99).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
