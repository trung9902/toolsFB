using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchTestSpinContent : Form
{
	internal IContainer B41F6123 = null;

	internal BunifuCards bunifuCards1;

	internal Panel B9A178AE;

	internal BunifuDragControl C388ADAF;

	internal BunifuCards A60D6686;

	internal Panel D223E312;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal Button C80B752E;

	internal BunifuCustomLabel lblTitle;

	internal Button B880B223;

	internal RichTextBox txtInput;

	internal GroupBox DA21618C;

	internal RichTextBox C2875790;

	internal GroupBox D09B1134;

	public fTienIchTestSpinContent()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void D7379E22(object sender, EventArgs e)
	{
		Close();
	}

	private void E33E19B9(object sender, EventArgs e)
	{
		try
		{
			string string_ = txtInput.Text;
			C2875790.Text = Commom.smethod_31(string_);
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void txtInput_TextChanged(object sender, EventArgs e)
	{
	}

	private void A59BB02F(object sender, EventArgs e)
	{
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void FC2A8BB5(object sender, EventArgs e)
	{
	}

	private void B826772A(object sender, PaintEventArgs e)
	{
	}

	private void ED9296BB(object sender, EventArgs e)
	{
		A59BB02F(null, null);
		method_0(null, null);
	}

	protected override void Dispose(bool A7348184)
	{
		if (A7348184 && B41F6123 != null)
		{
			B41F6123.Dispose();
		}
		base.Dispose(A7348184);
	}

	private void InitializeComponent()
	{
		B41F6123 = new System.ComponentModel.Container();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		B9A178AE = new System.Windows.Forms.Panel();
		DA21618C = new System.Windows.Forms.GroupBox();
		C2875790 = new System.Windows.Forms.RichTextBox();
		D09B1134 = new System.Windows.Forms.GroupBox();
		txtInput = new System.Windows.Forms.RichTextBox();
		B880B223 = new System.Windows.Forms.Button();
		A60D6686 = new Bunifu.Framework.UI.BunifuCards();
		D223E312 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		C80B752E = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		C388ADAF = new Bunifu.Framework.UI.BunifuDragControl(B41F6123);
		B9A178AE.SuspendLayout();
		DA21618C.SuspendLayout();
		D09B1134.SuspendLayout();
		A60D6686.SuspendLayout();
		D223E312.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
		B9A178AE.BackColor = System.Drawing.Color.White;
		B9A178AE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B9A178AE.Controls.Add(DA21618C);
		B9A178AE.Controls.Add(D09B1134);
		B9A178AE.Controls.Add(B880B223);
		B9A178AE.Controls.Add(A60D6686);
		B9A178AE.Dock = System.Windows.Forms.DockStyle.Fill;
		B9A178AE.Location = new System.Drawing.Point(0, 0);
		B9A178AE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		B9A178AE.Name = "panel1";
		B9A178AE.Size = new System.Drawing.Size(838, 586);
		B9A178AE.TabIndex = 37;
		B9A178AE.Paint += new System.Windows.Forms.PaintEventHandler(B826772A);
		DA21618C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		DA21618C.Controls.Add(C2875790);
		DA21618C.Location = new System.Drawing.Point(469, 40);
		DA21618C.Name = "groupBox2";
		DA21618C.Size = new System.Drawing.Size(361, 539);
		DA21618C.TabIndex = 51;
		DA21618C.TabStop = false;
		DA21618C.Text = "Output";
		C2875790.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C2875790.Location = new System.Drawing.Point(6, 22);
		C2875790.Name = "txtOutput";
		C2875790.Size = new System.Drawing.Size(349, 510);
		C2875790.TabIndex = 50;
		C2875790.Text = "";
		C2875790.WordWrap = false;
		C2875790.TextChanged += new System.EventHandler(FC2A8BB5);
		D09B1134.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		D09B1134.Controls.Add(txtInput);
		D09B1134.Location = new System.Drawing.Point(6, 40);
		D09B1134.Name = "groupBox1";
		D09B1134.Size = new System.Drawing.Size(361, 539);
		D09B1134.TabIndex = 51;
		D09B1134.TabStop = false;
		D09B1134.Text = "Input";
		txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtInput.Location = new System.Drawing.Point(6, 22);
		txtInput.Name = "txtInput";
		txtInput.Size = new System.Drawing.Size(349, 510);
		txtInput.TabIndex = 50;
		txtInput.Text = "";
		txtInput.WordWrap = false;
		txtInput.TextChanged += new System.EventHandler(txtInput_TextChanged);
		B880B223.BackColor = System.Drawing.Color.Green;
		B880B223.Cursor = System.Windows.Forms.Cursors.Hand;
		B880B223.FlatAppearance.BorderSize = 0;
		B880B223.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B880B223.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B880B223.ForeColor = System.Drawing.Color.White;
		B880B223.Location = new System.Drawing.Point(379, 138);
		B880B223.Name = "btnAdd";
		B880B223.Size = new System.Drawing.Size(78, 29);
		B880B223.TabIndex = 45;
		B880B223.Text = "Spin";
		B880B223.UseVisualStyleBackColor = false;
		B880B223.Click += new System.EventHandler(E33E19B9);
		A60D6686.BackColor = System.Drawing.Color.White;
		A60D6686.BorderRadius = 0;
		A60D6686.BottomSahddow = true;
		A60D6686.color = System.Drawing.Color.SaddleBrown;
		A60D6686.Controls.Add(D223E312);
		A60D6686.Dock = System.Windows.Forms.DockStyle.Top;
		A60D6686.LeftSahddow = false;
		A60D6686.Location = new System.Drawing.Point(0, 0);
		A60D6686.Name = "bunifuCards2";
		A60D6686.RightSahddow = true;
		A60D6686.ShadowDepth = 20;
		A60D6686.Size = new System.Drawing.Size(836, 37);
		A60D6686.TabIndex = 43;
		D223E312.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D223E312.BackColor = System.Drawing.Color.White;
		D223E312.Controls.Add(button2);
		D223E312.Controls.Add(pictureBox1);
		D223E312.Controls.Add(C80B752E);
		D223E312.Controls.Add(lblTitle);
		D223E312.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D223E312.Location = new System.Drawing.Point(0, 3);
		D223E312.Name = "pnlHeader";
		D223E312.Size = new System.Drawing.Size(836, 31);
		D223E312.TabIndex = 9;
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
		button2.Click += new System.EventHandler(D7379E22);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		C80B752E.Cursor = System.Windows.Forms.Cursors.Hand;
		C80B752E.FlatAppearance.BorderSize = 0;
		C80B752E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C80B752E.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C80B752E.ForeColor = System.Drawing.Color.White;
		C80B752E.Location = new System.Drawing.Point(899, 1);
		C80B752E.Name = "btnMinimize";
		C80B752E.Size = new System.Drawing.Size(30, 30);
		C80B752E.TabIndex = 9;
		C80B752E.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		C80B752E.UseVisualStyleBackColor = true;
		lblTitle.BackColor = System.Drawing.Color.Transparent;
		lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
		lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblTitle.ForeColor = System.Drawing.Color.Black;
		lblTitle.Location = new System.Drawing.Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(836, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Test Spin Content";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C388ADAF.Fixed = true;
		C388ADAF.Horizontal = true;
		C388ADAF.TargetControl = lblTitle;
		C388ADAF.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(838, 586);
		base.Controls.Add(B9A178AE);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fTienIchTestSpinContent";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(ED9296BB);
		B9A178AE.ResumeLayout(false);
		DA21618C.ResumeLayout(false);
		D09B1134.ResumeLayout(false);
		A60D6686.ResumeLayout(false);
		D223E312.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
