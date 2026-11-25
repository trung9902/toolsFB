using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhGetToken : Form
{
	internal bool A4970913 = false;

	internal IContainer icontainer_0 = null;

	internal BunifuCards C811BD20;

	internal Panel pnlHeader;

	internal BunifuCustomLabel B424A21B;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button D43E6B90;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal CheckBox ckbGetCookie;

	internal ComboBox B83DA193;

	internal Label A08D58A6;

	internal CheckBox ckbCheckWall;

	internal ComboBox cbbRunBy;

	internal Label DF06FEB3;

	public fCauHinhGetToken()
	{
		InitializeComponent();
		A4970913 = false;
		Language.CD21F0A9(this);
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ED128AA6(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configGetToken").method_4("cbbGetToken", B83DA193.SelectedIndex);
		C5034B95.smethod_0("configGetToken").method_4("cbbGetTokenText", B83DA193.SelectedItem != null ? B83DA193.SelectedItem.ToString() : "");
		C5034B95.smethod_0("configGetToken").method_4("cbbRunBy", cbbRunBy.SelectedIndex);
		C5034B95.smethod_0("configGetToken").method_4("ckbCheckWall", ckbCheckWall.Checked);
		C5034B95.smethod_0("configGetToken").method_4("ckbGetCookie", ckbGetCookie.Checked);
		C5034B95.smethod_1("configGetToken");
		A4970913 = true;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhGetToken_Load(object sender, EventArgs e)
	{
		int selectedIndex = C5034B95.smethod_0("configGetToken").method_2("cbbGetToken");
		if (selectedIndex < 0 || selectedIndex >= B83DA193.Items.Count)
		{
			selectedIndex = 0;
		}
		B83DA193.SelectedIndex = selectedIndex;
		int runBy = C5034B95.smethod_0("configGetToken").method_2("cbbRunBy");
		if (runBy < 0 || runBy >= cbbRunBy.Items.Count)
		{
			runBy = 0;
		}
		cbbRunBy.SelectedIndex = runBy;
		ckbCheckWall.Checked = C5034B95.smethod_0("configGetToken").method_3("ckbCheckWall");
		ckbGetCookie.Checked = C5034B95.smethod_0("configGetToken").method_3("ckbGetCookie");
	}

	private void A12F0C1E(object sender, EventArgs e)
	{
		if (cbbRunBy.SelectedIndex == 1)
		{
			ckbGetCookie.Enabled = false;
			ckbGetCookie.Checked = false;
		}
		else
		{
			ckbGetCookie.Enabled = true;
		}
	}

	protected override void Dispose(bool D117B0A6)
	{
		if (D117B0A6 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D117B0A6);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhGetToken));
		C811BD20 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		B424A21B = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		D43E6B90 = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		ckbGetCookie = new System.Windows.Forms.CheckBox();
		B83DA193 = new System.Windows.Forms.ComboBox();
		A08D58A6 = new System.Windows.Forms.Label();
		ckbCheckWall = new System.Windows.Forms.CheckBox();
		cbbRunBy = new System.Windows.Forms.ComboBox();
		DF06FEB3 = new System.Windows.Forms.Label();
		C811BD20.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		C811BD20.BackColor = System.Drawing.Color.White;
		C811BD20.BorderRadius = 0;
		C811BD20.BottomSahddow = true;
		C811BD20.color = System.Drawing.Color.SaddleBrown;
		C811BD20.Controls.Add(pnlHeader);
		C811BD20.Dock = System.Windows.Forms.DockStyle.Top;
		C811BD20.LeftSahddow = false;
		C811BD20.Location = new System.Drawing.Point(0, 0);
		C811BD20.Name = "bunifuCards1";
		C811BD20.RightSahddow = true;
		C811BD20.ShadowDepth = 20;
		C811BD20.Size = new System.Drawing.Size(304, 38);
		C811BD20.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(B424A21B);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(304, 32);
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
		btnMinimize.Location = new System.Drawing.Point(272, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		B424A21B.BackColor = System.Drawing.Color.Transparent;
		B424A21B.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B424A21B.Dock = System.Windows.Forms.DockStyle.Fill;
		B424A21B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B424A21B.ForeColor = System.Drawing.Color.Black;
		B424A21B.Location = new System.Drawing.Point(0, 0);
		B424A21B.Name = "bunifuCustomLabel1";
		B424A21B.Size = new System.Drawing.Size(304, 32);
		B424A21B.TabIndex = 1;
		B424A21B.Text = "Câ\u0301u hi\u0300nh Get Token";
		B424A21B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(160, 148);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		D43E6B90.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D43E6B90.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		D43E6B90.Cursor = System.Windows.Forms.Cursors.Hand;
		D43E6B90.FlatAppearance.BorderSize = 0;
		D43E6B90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D43E6B90.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D43E6B90.ForeColor = System.Drawing.Color.White;
		D43E6B90.Location = new System.Drawing.Point(56, 148);
		D43E6B90.Name = "btnAdd";
		D43E6B90.Size = new System.Drawing.Size(92, 29);
		D43E6B90.TabIndex = 3;
		D43E6B90.Text = "Lưu";
		D43E6B90.UseVisualStyleBackColor = false;
		D43E6B90.Click += new System.EventHandler(ED128AA6);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = B424A21B;
		bunifuDragControl_0.Vertical = true;
		ckbGetCookie.AutoSize = true;
		ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGetCookie.Location = new System.Drawing.Point(175, 115);
		ckbGetCookie.Name = "ckbGetCookie";
		ckbGetCookie.Size = new System.Drawing.Size(85, 20);
		ckbGetCookie.TabIndex = 5;
		ckbGetCookie.Text = "Get cookie";
		ckbGetCookie.UseVisualStyleBackColor = true;
		B83DA193.Cursor = System.Windows.Forms.Cursors.Hand;
		B83DA193.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		B83DA193.FormattingEnabled = true;
		B83DA193.Items.AddRange(new object[4] { "EAAG (Business)", "EAAB (Business Suite)", "EAAAAU", "EAAAAY" });
		B83DA193.Location = new System.Drawing.Point(129, 55);
		B83DA193.Name = "cbbGetToken";
		B83DA193.Size = new System.Drawing.Size(131, 24);
		B83DA193.TabIndex = 6;
		A08D58A6.AutoSize = true;
		A08D58A6.Location = new System.Drawing.Point(53, 58);
		A08D58A6.Name = "label1";
		A08D58A6.Size = new System.Drawing.Size(70, 16);
		A08D58A6.TabIndex = 7;
		A08D58A6.Text = "Loa\u0323i token:";
		ckbCheckWall.AutoSize = true;
		ckbCheckWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCheckWall.Location = new System.Drawing.Point(56, 115);
		ckbCheckWall.Name = "ckbCheckWall";
		ckbCheckWall.Size = new System.Drawing.Size(89, 20);
		ckbCheckWall.TabIndex = 5;
		ckbCheckWall.Text = "Check Wall";
		ckbCheckWall.UseVisualStyleBackColor = true;
		cbbRunBy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbRunBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbRunBy.FormattingEnabled = true;
		cbbRunBy.Items.AddRange(new object[3] { "Uid|pass", "Cookie", "Cookie>Uid|pass" });
		cbbRunBy.Location = new System.Drawing.Point(129, 85);
		cbbRunBy.Name = "cbbRunBy";
		cbbRunBy.Size = new System.Drawing.Size(131, 24);
		cbbRunBy.TabIndex = 6;
		cbbRunBy.SelectedIndexChanged += new System.EventHandler(A12F0C1E);
		DF06FEB3.AutoSize = true;
		DF06FEB3.Location = new System.Drawing.Point(53, 88);
		DF06FEB3.Name = "label2";
		DF06FEB3.Size = new System.Drawing.Size(72, 16);
		DF06FEB3.TabIndex = 7;
		DF06FEB3.Text = "Chạy bằng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(304, 190);
		base.Controls.Add(DF06FEB3);
		base.Controls.Add(A08D58A6);
		base.Controls.Add(cbbRunBy);
		base.Controls.Add(B83DA193);
		base.Controls.Add(ckbCheckWall);
		base.Controls.Add(ckbGetCookie);
		base.Controls.Add(btnCancel);
		base.Controls.Add(D43E6B90);
		base.Controls.Add(C811BD20);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhGetToken";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhGetToken_Load);
		C811BD20.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
