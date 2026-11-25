using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fAddFile : Form
{
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel D99973A7;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button DD3702BA;

	internal Label label1;

	internal BunifuDragControl F1933D90;

	internal TextBox A21382B2;

	internal PictureBox F13344BF;

	public fAddFile()
	{
		InitializeComponent();
		bool_0 = false;
		Language.CD21F0A9(this);
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EF089630(object sender, EventArgs e)
	{
		string text = A21382B2.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng điền tên thư mục!");
			A21382B2.Focus();
		}
		else if (CommonSQL.smethod_0(text))
		{
			MsBoxHelper.Show("Tên thư mục này đã tồn tại, vui lòng nhập tên khác!");
			A21382B2.Focus();
		}
		else if (CommonSQL.smethod_2(text))
		{
			bool_0 = true;
			if (MsBoxHelper.D41C45AC("Thêm thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Thêm thư mục lỗi!");
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D0919526(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			EF089630(null, null);
		}
	}

	protected override void Dispose(bool FD94EC92)
	{
		if (FD94EC92 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(FD94EC92);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAddFile));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		F13344BF = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		D99973A7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		DD3702BA = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		F1933D90 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		A21382B2 = new System.Windows.Forms.TextBox();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F13344BF).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(396, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(F13344BF);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(D99973A7);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(396, 32);
		pnlHeader.TabIndex = 9;
		F13344BF.Cursor = System.Windows.Forms.Cursors.Default;
		F13344BF.Image = Class155.DD225F0D;
		F13344BF.Location = new System.Drawing.Point(4, 1);
		F13344BF.Name = "pictureBox1";
		F13344BF.Size = new System.Drawing.Size(34, 27);
		F13344BF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		F13344BF.TabIndex = 77;
		F13344BF.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(364, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		D99973A7.BackColor = System.Drawing.Color.Transparent;
		D99973A7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D99973A7.Dock = System.Windows.Forms.DockStyle.Fill;
		D99973A7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D99973A7.ForeColor = System.Drawing.Color.Black;
		D99973A7.Location = new System.Drawing.Point(0, 0);
		D99973A7.Name = "bunifuCustomLabel1";
		D99973A7.Size = new System.Drawing.Size(396, 32);
		D99973A7.TabIndex = 1;
		D99973A7.Text = "Thêm thư mục";
		D99973A7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(204, 105);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Hủy";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		DD3702BA.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		DD3702BA.Cursor = System.Windows.Forms.Cursors.Hand;
		DD3702BA.FlatAppearance.BorderSize = 0;
		DD3702BA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DD3702BA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DD3702BA.ForeColor = System.Drawing.Color.White;
		DD3702BA.Location = new System.Drawing.Point(100, 105);
		DD3702BA.Name = "btnAdd";
		DD3702BA.Size = new System.Drawing.Size(92, 29);
		DD3702BA.TabIndex = 3;
		DD3702BA.Text = "Thêm";
		DD3702BA.UseVisualStyleBackColor = false;
		DD3702BA.Click += new System.EventHandler(EF089630);
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label1.Location = new System.Drawing.Point(33, 69);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(86, 16);
		label1.TabIndex = 20;
		label1.Text = "Tên thư mu\u0323c:";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		F1933D90.Fixed = true;
		F1933D90.Horizontal = true;
		F1933D90.TargetControl = D99973A7;
		F1933D90.Vertical = true;
		A21382B2.Location = new System.Drawing.Point(125, 66);
		A21382B2.Name = "txbNameFile";
		A21382B2.Size = new System.Drawing.Size(234, 23);
		A21382B2.TabIndex = 2;
		A21382B2.KeyDown += new System.Windows.Forms.KeyEventHandler(D0919526);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(396, 145);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(DD3702BA);
		base.Controls.Add(A21382B2);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fAddFile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)F13344BF).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
