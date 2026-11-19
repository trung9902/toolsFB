using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChonPrompt : Form
{
	internal GClass4 C123501E;

	internal string string_0;

	internal IContainer BB88E989 = null;

	internal BunifuDragControl F3B6FB0C;

	internal BunifuCards CD8B5AA2;

	internal Button btnClose;

	internal PictureBox FD37243D;

	internal BunifuCustomLabel F715A295;

	internal Panel panel2;

	internal Button btnCancel;

	internal Button btnSave;

	internal Button A3BABF80;

	internal ComboBox cbbPrompt;

	internal Label A5AB0C81;

	public fChonPrompt(GClass4 gclass4_0, string E7A8A117 = "cbbPrompt")
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		C123501E = gclass4_0;
		string_0 = E7A8A117;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fChonPrompt_Load(object sender, EventArgs e)
	{
		C40CC83E();
		try
		{
			cbbPrompt.SelectedValue = C123501E.BDB80B23(string_0);
		}
		catch (Exception)
		{
		}
	}

	private void A3BABF80_Click(object sender, EventArgs e)
	{
		int selectedIndex = cbbPrompt.SelectedIndex;
		Commom.smethod_35(new fCauHinhAI(cbbPrompt.SelectedValue?.ToString()));
		C40CC83E();
		if (selectedIndex != -1 && selectedIndex < cbbPrompt.Items.Count)
		{
			cbbPrompt.SelectedIndex = selectedIndex;
		}
	}

	private void C40CC83E()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<GClass10> list = GClass9.EC28DF14();
		foreach (GClass10 item in list)
		{
			dictionary.Add(item.String_0.ToString(), item.String_1.ToString());
		}
		Commom.smethod_24(cbbPrompt, dictionary);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		C123501E.method_4(string_0, cbbPrompt.SelectedValue.ToString());
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool FE8AB919)
	{
		if (FE8AB919 && BB88E989 != null)
		{
			BB88E989.Dispose();
		}
		base.Dispose(FE8AB919);
	}

	private void InitializeComponent()
	{
		BB88E989 = new System.ComponentModel.Container();
		F3B6FB0C = new Bunifu.Framework.UI.BunifuDragControl(BB88E989);
		F715A295 = new Bunifu.Framework.UI.BunifuCustomLabel();
		CD8B5AA2 = new Bunifu.Framework.UI.BunifuCards();
		btnClose = new System.Windows.Forms.Button();
		FD37243D = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		A3BABF80 = new System.Windows.Forms.Button();
		cbbPrompt = new System.Windows.Forms.ComboBox();
		A5AB0C81 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnSave = new System.Windows.Forms.Button();
		CD8B5AA2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FD37243D).BeginInit();
		panel2.SuspendLayout();
		SuspendLayout();
		F3B6FB0C.Fixed = true;
		F3B6FB0C.Horizontal = true;
		F3B6FB0C.TargetControl = F715A295;
		F3B6FB0C.Vertical = true;
		F715A295.BackColor = System.Drawing.Color.Transparent;
		F715A295.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F715A295.Dock = System.Windows.Forms.DockStyle.Fill;
		F715A295.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F715A295.ForeColor = System.Drawing.Color.Black;
		F715A295.Location = new System.Drawing.Point(0, 0);
		F715A295.Name = "bunifuCustomLabel1";
		F715A295.Size = new System.Drawing.Size(468, 38);
		F715A295.TabIndex = 12;
		F715A295.Text = "Cho\u0323n Prompt";
		F715A295.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CD8B5AA2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CD8B5AA2.BackColor = System.Drawing.Color.White;
		CD8B5AA2.BorderRadius = 0;
		CD8B5AA2.BottomSahddow = true;
		CD8B5AA2.color = System.Drawing.Color.DarkViolet;
		CD8B5AA2.Controls.Add(btnClose);
		CD8B5AA2.Controls.Add(FD37243D);
		CD8B5AA2.Controls.Add(F715A295);
		CD8B5AA2.LeftSahddow = false;
		CD8B5AA2.Location = new System.Drawing.Point(1, 0);
		CD8B5AA2.Name = "bunifuCards1";
		CD8B5AA2.RightSahddow = true;
		CD8B5AA2.ShadowDepth = 20;
		CD8B5AA2.Size = new System.Drawing.Size(468, 38);
		CD8B5AA2.TabIndex = 29;
		btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = Class155.FF80C508;
		btnClose.Location = new System.Drawing.Point(436, 5);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(30, 30);
		btnClose.TabIndex = 77;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(btnClose_Click);
		FD37243D.Cursor = System.Windows.Forms.Cursors.Default;
		FD37243D.Image = Class155.DD225F0D;
		FD37243D.Location = new System.Drawing.Point(2, 6);
		FD37243D.Name = "pictureBox1";
		FD37243D.Size = new System.Drawing.Size(34, 27);
		FD37243D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		FD37243D.TabIndex = 76;
		FD37243D.TabStop = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(A3BABF80);
		panel2.Controls.Add(cbbPrompt);
		panel2.Controls.Add(A5AB0C81);
		panel2.Controls.Add(btnCancel);
		panel2.Controls.Add(btnSave);
		panel2.Controls.Add(CD8B5AA2);
		panel2.Dock = System.Windows.Forms.DockStyle.Fill;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(470, 146);
		panel2.TabIndex = 30;
		A3BABF80.Cursor = System.Windows.Forms.Cursors.Hand;
		A3BABF80.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A3BABF80.Location = new System.Drawing.Point(402, 53);
		A3BABF80.Name = "btnPrompt";
		A3BABF80.Size = new System.Drawing.Size(33, 27);
		A3BABF80.TabIndex = 99;
		A3BABF80.Text = "...";
		A3BABF80.UseVisualStyleBackColor = true;
		A3BABF80.Click += new System.EventHandler(A3BABF80_Click);
		cbbPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbPrompt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbPrompt.DropDownWidth = 120;
		cbbPrompt.FormattingEnabled = true;
		cbbPrompt.Location = new System.Drawing.Point(121, 54);
		cbbPrompt.Name = "cbbPrompt";
		cbbPrompt.Size = new System.Drawing.Size(275, 24);
		cbbPrompt.TabIndex = 98;
		A5AB0C81.AutoSize = true;
		A5AB0C81.Location = new System.Drawing.Point(30, 57);
		A5AB0C81.Name = "label7";
		A5AB0C81.Size = new System.Drawing.Size(86, 16);
		A5AB0C81.TabIndex = 97;
		A5AB0C81.Text = "Cho\u0323n Prompt:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(241, 104);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 96;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSave.ForeColor = System.Drawing.Color.White;
		btnSave.Location = new System.Drawing.Point(137, 104);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 95;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(btnSave_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(470, 146);
		base.Controls.Add(panel2);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fChonPrompt";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fChonPrompt_Load);
		CD8B5AA2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)FD37243D).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		ResumeLayout(false);
	}
}
