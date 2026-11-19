using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fEditFile : Form
{
	internal string string_0;

	internal string ED3298AD;

	internal bool bool_0 = false;

	internal IContainer C9B472AD = null;

	internal BunifuCards B5150319;

	internal Panel pnlHeader;

	internal BunifuCustomLabel B7360C24;

	internal Button btnMinimize;

	internal Button A90651A9;

	internal Button C6BCFDBE;

	internal Label label1;

	internal BunifuDragControl bunifuDragControl_0;

	internal TextBox AAAEAFA5;

	internal PictureBox pictureBox1;

	internal TextBox txtNameFileNew;

	internal Label label2;

	public fEditFile(string FB8C91AA, string string_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		string_0 = FB8C91AA;
		ED3298AD = string_1;
		bool_0 = false;
	}

	private void BAB151A3(object sender, EventArgs e)
	{
		Close();
	}

	private void C6BCFDBE_Click(object sender, EventArgs e)
	{
		string text = txtNameFileNew.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng điền tên thư mục mới!", 3);
			txtNameFileNew.Focus();
		}
		else if (CommonSQL.smethod_0(text))
		{
			MsBoxHelper.Show("Tên thư mục này đã tồn tại, vui lòng nhập tên khác!", 3);
			txtNameFileNew.Focus();
		}
		else if (text.Equals(AAAEAFA5.Text.Trim()))
		{
			MsBoxHelper.Show("Tên thư mục mới phải khác thư mục cũ!", 3);
			txtNameFileNew.Focus();
		}
		else if (CommonSQL.smethod_3(string_0, text))
		{
			bool_0 = true;
			if (MsBoxHelper.D41C45AC("Cập nhật thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Cập nhật tên thư mục lỗi!");
		}
	}

	private void AD8B7F11(object sender, EventArgs e)
	{
		Close();
	}

	private void txtNameFileNew_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			C6BCFDBE_Click(null, null);
		}
	}

	private void D8325B3A(object sender, EventArgs e)
	{
		AAAEAFA5.Text = ED3298AD;
	}

	protected override void Dispose(bool C2B7C83E)
	{
		if (C2B7C83E && C9B472AD != null)
		{
			C9B472AD.Dispose();
		}
		base.Dispose(C2B7C83E);
	}

	private void InitializeComponent()
	{
		C9B472AD = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEditFile));
		B5150319 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		B7360C24 = new Bunifu.Framework.UI.BunifuCustomLabel();
		A90651A9 = new System.Windows.Forms.Button();
		C6BCFDBE = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(C9B472AD);
		AAAEAFA5 = new System.Windows.Forms.TextBox();
		txtNameFileNew = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		B5150319.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		B5150319.BackColor = System.Drawing.Color.White;
		B5150319.BorderRadius = 0;
		B5150319.BottomSahddow = true;
		B5150319.color = System.Drawing.Color.SaddleBrown;
		B5150319.Controls.Add(pnlHeader);
		B5150319.Dock = System.Windows.Forms.DockStyle.Top;
		B5150319.LeftSahddow = false;
		B5150319.Location = new System.Drawing.Point(0, 0);
		B5150319.Name = "bunifuCards1";
		B5150319.RightSahddow = true;
		B5150319.ShadowDepth = 20;
		B5150319.Size = new System.Drawing.Size(396, 38);
		B5150319.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(B7360C24);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(396, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(4, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 77;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(362, -2);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(BAB151A3);
		B7360C24.BackColor = System.Drawing.Color.Transparent;
		B7360C24.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B7360C24.Dock = System.Windows.Forms.DockStyle.Fill;
		B7360C24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B7360C24.ForeColor = System.Drawing.Color.Black;
		B7360C24.Location = new System.Drawing.Point(0, 0);
		B7360C24.Name = "bunifuCustomLabel1";
		B7360C24.Size = new System.Drawing.Size(396, 32);
		B7360C24.TabIndex = 1;
		B7360C24.Text = "Cập nhật Tên thư mục";
		B7360C24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A90651A9.BackColor = System.Drawing.Color.Maroon;
		A90651A9.Cursor = System.Windows.Forms.Cursors.Hand;
		A90651A9.FlatAppearance.BorderSize = 0;
		A90651A9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A90651A9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A90651A9.ForeColor = System.Drawing.Color.White;
		A90651A9.Location = new System.Drawing.Point(204, 138);
		A90651A9.Name = "btnCancel";
		A90651A9.Size = new System.Drawing.Size(92, 29);
		A90651A9.TabIndex = 4;
		A90651A9.Text = "Hủy";
		A90651A9.UseVisualStyleBackColor = false;
		A90651A9.Click += new System.EventHandler(AD8B7F11);
		C6BCFDBE.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		C6BCFDBE.Cursor = System.Windows.Forms.Cursors.Hand;
		C6BCFDBE.FlatAppearance.BorderSize = 0;
		C6BCFDBE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C6BCFDBE.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C6BCFDBE.ForeColor = System.Drawing.Color.White;
		C6BCFDBE.Location = new System.Drawing.Point(100, 138);
		C6BCFDBE.Name = "btnAdd";
		C6BCFDBE.Size = new System.Drawing.Size(92, 29);
		C6BCFDBE.TabIndex = 3;
		C6BCFDBE.Text = "Cập nhật";
		C6BCFDBE.UseVisualStyleBackColor = false;
		C6BCFDBE.Click += new System.EventHandler(C6BCFDBE_Click);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label1.Location = new System.Drawing.Point(33, 69);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 16);
		label1.TabIndex = 20;
		label1.Text = "Tên thư mu\u0323c cũ:";
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = B7360C24;
		bunifuDragControl_0.Vertical = true;
		AAAEAFA5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		AAAEAFA5.Location = new System.Drawing.Point(150, 66);
		AAAEAFA5.Name = "txtNameFileOld";
		AAAEAFA5.ReadOnly = true;
		AAAEAFA5.Size = new System.Drawing.Size(209, 23);
		AAAEAFA5.TabIndex = 2;
		AAAEAFA5.KeyDown += new System.Windows.Forms.KeyEventHandler(txtNameFileNew_KeyDown);
		txtNameFileNew.Location = new System.Drawing.Point(150, 95);
		txtNameFileNew.Name = "txtNameFileNew";
		txtNameFileNew.Size = new System.Drawing.Size(209, 23);
		txtNameFileNew.TabIndex = 2;
		txtNameFileNew.KeyDown += new System.Windows.Forms.KeyEventHandler(txtNameFileNew_KeyDown);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label2.Location = new System.Drawing.Point(33, 98);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(110, 16);
		label2.TabIndex = 20;
		label2.Text = "Tên thư mu\u0323c mới:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(396, 182);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(A90651A9);
		base.Controls.Add(C6BCFDBE);
		base.Controls.Add(txtNameFileNew);
		base.Controls.Add(AAAEAFA5);
		base.Controls.Add(B5150319);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fEditFile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(D8325B3A);
		B5150319.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
