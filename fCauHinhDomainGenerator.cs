using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhDomainGenerator : Form
{
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards C7BB4F92;

	internal Button btnClose;

	internal PictureBox AEAF5812;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel panel2;

	internal RichTextBox txtPass;

	internal Label lblTitle;

	public fCauHinhDomainGenerator()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		bool_0 = false;
	}

	private void DE9A7C39(object sender, EventArgs e)
	{
		List<string> first = txtPass.smethod_7();
		first = first.Except(new List<string> { "hotmail.com", "outlook.com" }).ToList();
		C5034B95.smethod_0("configGeneral").FD3CCF90("txtGeneratorDomain", first);
		C5034B95.smethod_1("configGeneral");
		bool_0 = true;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhDomainGenerator_Load(object sender, EventArgs e)
	{
		txtPass.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtGeneratorDomain");
		DAAFC2BA(null, null);
	}

	private void DAAFC2BA(object sender, EventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void txtPass_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtPass, lblTitle);
	}

	protected override void Dispose(bool E610ABB7)
	{
		if (E610ABB7 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(E610ABB7);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		C7BB4F92 = new Bunifu.Framework.UI.BunifuCards();
		btnClose = new System.Windows.Forms.Button();
		AEAF5812 = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		txtPass = new System.Windows.Forms.RichTextBox();
		lblTitle = new System.Windows.Forms.Label();
		C7BB4F92.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AEAF5812).BeginInit();
		panel2.SuspendLayout();
		SuspendLayout();
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(172, 251);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(68, 251);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(DE9A7C39);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(330, 38);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Domain Generator";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C7BB4F92.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C7BB4F92.BackColor = System.Drawing.Color.White;
		C7BB4F92.BorderRadius = 0;
		C7BB4F92.BottomSahddow = true;
		C7BB4F92.color = System.Drawing.Color.DarkViolet;
		C7BB4F92.Controls.Add(btnClose);
		C7BB4F92.Controls.Add(AEAF5812);
		C7BB4F92.Controls.Add(bunifuCustomLabel1);
		C7BB4F92.LeftSahddow = false;
		C7BB4F92.Location = new System.Drawing.Point(1, 0);
		C7BB4F92.Name = "bunifuCards1";
		C7BB4F92.RightSahddow = true;
		C7BB4F92.ShadowDepth = 20;
		C7BB4F92.Size = new System.Drawing.Size(330, 38);
		C7BB4F92.TabIndex = 29;
		btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = Class155.FF80C508;
		btnClose.Location = new System.Drawing.Point(298, 5);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(30, 30);
		btnClose.TabIndex = 77;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(btnClose_Click);
		AEAF5812.Cursor = System.Windows.Forms.Cursors.Default;
		AEAF5812.Image = Class155.DD225F0D;
		AEAF5812.Location = new System.Drawing.Point(2, 6);
		AEAF5812.Name = "pictureBox1";
		AEAF5812.Size = new System.Drawing.Size(34, 27);
		AEAF5812.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AEAF5812.TabIndex = 76;
		AEAF5812.TabStop = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(txtPass);
		panel2.Controls.Add(lblTitle);
		panel2.Controls.Add(C7BB4F92);
		panel2.Dock = System.Windows.Forms.DockStyle.Fill;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(332, 292);
		panel2.TabIndex = 30;
		txtPass.Location = new System.Drawing.Point(34, 69);
		txtPass.Name = "txtPass";
		txtPass.Size = new System.Drawing.Size(267, 170);
		txtPass.TabIndex = 31;
		txtPass.Text = "";
		txtPass.WordWrap = false;
		txtPass.TextChanged += new System.EventHandler(txtPass_TextChanged);
		lblTitle.AutoSize = true;
		lblTitle.Location = new System.Drawing.Point(31, 50);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(138, 16);
		lblTitle.TabIndex = 30;
		lblTitle.Text = "Danh sách domain (0):";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(332, 292);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(panel2);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhDomainGenerator";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhDomainGenerator_Load);
		C7BB4F92.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AEAF5812).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		ResumeLayout(false);
	}
}
