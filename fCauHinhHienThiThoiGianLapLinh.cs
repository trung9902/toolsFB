using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhHienThiThoiGianLapLinh : Form
{
	internal IContainer D694E3B2 = null;

	internal BunifuCards B728DF32;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button D822FB99;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal RadioButton rd10p;

	internal RadioButton rd60p;

	internal RadioButton rd30p;

	internal RadioButton CB2B059A;

	internal Panel F298B0B7;

	public fCauHinhHienThiThoiGianLapLinh()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B58F9791(object sender, EventArgs e)
	{
		foreach (Control control in F298B0B7.Controls)
		{
			RadioButton radioButton = control as RadioButton;
			if (radioButton?.Checked ?? false)
			{
				C5034B95.smethod_0("cauHinhThoiGianLapLich").method_4("rdCauHinhThoiGianLapLich", radioButton.Name.ToString());
				C5034B95.smethod_1("cauHinhThoiGianLapLich");
				Close();
			}
		}
	}

	private void D822FB99_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BD127DB2(object sender, EventArgs e)
	{
		foreach (Control control in F298B0B7.Controls)
		{
			RadioButton radioButton = control as RadioButton;
			if (radioButton != null && radioButton.Name == C5034B95.smethod_0("cauHinhThoiGianLapLich").BDB80B23("rdCauHinhThoiGianLapLich"))
			{
				radioButton.Checked = true;
				break;
			}
		}
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D694E3B2 != null)
		{
			D694E3B2.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D694E3B2 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhHienThiThoiGianLapLinh));
		B728DF32 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		D822FB99 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D694E3B2);
		rd10p = new System.Windows.Forms.RadioButton();
		rd60p = new System.Windows.Forms.RadioButton();
		rd30p = new System.Windows.Forms.RadioButton();
		CB2B059A = new System.Windows.Forms.RadioButton();
		F298B0B7 = new System.Windows.Forms.Panel();
		B728DF32.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		F298B0B7.SuspendLayout();
		SuspendLayout();
		B728DF32.BackColor = System.Drawing.Color.White;
		B728DF32.BorderRadius = 0;
		B728DF32.BottomSahddow = true;
		B728DF32.color = System.Drawing.Color.SaddleBrown;
		B728DF32.Controls.Add(pnlHeader);
		B728DF32.Dock = System.Windows.Forms.DockStyle.Top;
		B728DF32.LeftSahddow = false;
		B728DF32.Location = new System.Drawing.Point(0, 0);
		B728DF32.Name = "bunifuCards1";
		B728DF32.RightSahddow = true;
		B728DF32.ShadowDepth = 20;
		B728DF32.Size = new System.Drawing.Size(222, 38);
		B728DF32.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(222, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(190, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(222, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D822FB99.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D822FB99.BackColor = System.Drawing.Color.Maroon;
		D822FB99.Cursor = System.Windows.Forms.Cursors.Hand;
		D822FB99.FlatAppearance.BorderSize = 0;
		D822FB99.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D822FB99.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D822FB99.ForeColor = System.Drawing.Color.White;
		D822FB99.Location = new System.Drawing.Point(114, 114);
		D822FB99.Name = "btnCancel";
		D822FB99.Size = new System.Drawing.Size(92, 29);
		D822FB99.TabIndex = 4;
		D822FB99.Text = "Đo\u0301ng";
		D822FB99.UseVisualStyleBackColor = false;
		D822FB99.Click += new System.EventHandler(D822FB99_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(10, 114);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(B58F9791);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		rd10p.AutoSize = true;
		rd10p.Location = new System.Drawing.Point(123, 3);
		rd10p.Name = "rd10p";
		rd10p.Size = new System.Drawing.Size(68, 20);
		rd10p.TabIndex = 25;
		rd10p.TabStop = true;
		rd10p.Text = "10 Phút";
		rd10p.UseVisualStyleBackColor = true;
		rd60p.AutoSize = true;
		rd60p.Location = new System.Drawing.Point(123, 29);
		rd60p.Name = "rd60p";
		rd60p.Size = new System.Drawing.Size(68, 20);
		rd60p.TabIndex = 26;
		rd60p.TabStop = true;
		rd60p.Text = "60 Phút";
		rd60p.UseVisualStyleBackColor = true;
		rd30p.AutoSize = true;
		rd30p.Location = new System.Drawing.Point(3, 29);
		rd30p.Name = "rd30p";
		rd30p.Size = new System.Drawing.Size(68, 20);
		rd30p.TabIndex = 27;
		rd30p.TabStop = true;
		rd30p.Text = "30 Phút";
		rd30p.UseVisualStyleBackColor = true;
		CB2B059A.AutoSize = true;
		CB2B059A.Location = new System.Drawing.Point(3, 3);
		CB2B059A.Name = "rd5p";
		CB2B059A.Size = new System.Drawing.Size(61, 20);
		CB2B059A.TabIndex = 28;
		CB2B059A.TabStop = true;
		CB2B059A.Text = "5 Phút";
		CB2B059A.UseVisualStyleBackColor = true;
		F298B0B7.Controls.Add(rd60p);
		F298B0B7.Controls.Add(rd30p);
		F298B0B7.Controls.Add(CB2B059A);
		F298B0B7.Controls.Add(rd10p);
		F298B0B7.Location = new System.Drawing.Point(12, 44);
		F298B0B7.Name = "panel1";
		F298B0B7.Size = new System.Drawing.Size(194, 59);
		F298B0B7.TabIndex = 29;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(222, 164);
		base.Controls.Add(F298B0B7);
		base.Controls.Add(D822FB99);
		base.Controls.Add(btnAdd);
		base.Controls.Add(B728DF32);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhHienThiThoiGianLapLinh";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(BD127DB2);
		B728DF32.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		F298B0B7.ResumeLayout(false);
		F298B0B7.PerformLayout();
		ResumeLayout(false);
	}
}
