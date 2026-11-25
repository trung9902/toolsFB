using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fContact : Form
{
	internal IContainer D231C205 = null;

	internal BunifuCards FE076513;

	internal Panel ADBA7281;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button D2892E27;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox EBA07E19;

	internal Panel F2AC9038;

	internal Panel plContainer;

	public fContact()
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		Language.CD21F0A9(this);
		UserControl userControl = new ucContact();
		userControl.Dock = DockStyle.Fill;
		plContainer.Controls.Add(userControl);
	}

	private void C03C392D(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool B7ADC2A0)
	{
		if (B7ADC2A0 && D231C205 != null)
		{
			D231C205.Dispose();
		}
		base.Dispose(B7ADC2A0);
	}

	private void InitializeComponent()
	{
		D231C205 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fContact));
		FE076513 = new Bunifu.Framework.UI.BunifuCards();
		ADBA7281 = new System.Windows.Forms.Panel();
		EBA07E19 = new System.Windows.Forms.PictureBox();
		D2892E27 = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D231C205);
		F2AC9038 = new System.Windows.Forms.Panel();
		plContainer = new System.Windows.Forms.Panel();
		FE076513.SuspendLayout();
		ADBA7281.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)EBA07E19).BeginInit();
		F2AC9038.SuspendLayout();
		SuspendLayout();
		FE076513.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FE076513.BackColor = System.Drawing.Color.White;
		FE076513.BorderRadius = 0;
		FE076513.BottomSahddow = true;
		FE076513.color = System.Drawing.Color.SaddleBrown;
		FE076513.Controls.Add(ADBA7281);
		FE076513.LeftSahddow = false;
		FE076513.Location = new System.Drawing.Point(1, 0);
		FE076513.Name = "bunifuCards1";
		FE076513.RightSahddow = true;
		FE076513.ShadowDepth = 20;
		FE076513.Size = new System.Drawing.Size(742, 38);
		FE076513.TabIndex = 0;
		ADBA7281.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		ADBA7281.BackColor = System.Drawing.Color.White;
		ADBA7281.Controls.Add(EBA07E19);
		ADBA7281.Controls.Add(D2892E27);
		ADBA7281.Controls.Add(bunifuCustomLabel1);
		ADBA7281.Location = new System.Drawing.Point(0, 5);
		ADBA7281.Name = "pnlHeader";
		ADBA7281.Size = new System.Drawing.Size(742, 32);
		ADBA7281.TabIndex = 9;
		EBA07E19.Cursor = System.Windows.Forms.Cursors.Default;
		EBA07E19.Image = Class155.DD225F0D;
		EBA07E19.Location = new System.Drawing.Point(3, 2);
		EBA07E19.Name = "pictureBox1";
		EBA07E19.Size = new System.Drawing.Size(34, 27);
		EBA07E19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		EBA07E19.TabIndex = 17;
		EBA07E19.TabStop = false;
		D2892E27.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D2892E27.Cursor = System.Windows.Forms.Cursors.Hand;
		D2892E27.FlatAppearance.BorderSize = 0;
		D2892E27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D2892E27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D2892E27.ForeColor = System.Drawing.Color.White;
		D2892E27.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		D2892E27.Location = new System.Drawing.Point(709, -1);
		D2892E27.Name = "btnMinimize";
		D2892E27.Size = new System.Drawing.Size(32, 32);
		D2892E27.TabIndex = 9;
		D2892E27.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D2892E27.UseVisualStyleBackColor = true;
		D2892E27.Click += new System.EventHandler(C03C392D);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(742, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Thông tin liên hệ";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		F2AC9038.BackColor = System.Drawing.Color.White;
		F2AC9038.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F2AC9038.Controls.Add(plContainer);
		F2AC9038.Dock = System.Windows.Forms.DockStyle.Fill;
		F2AC9038.Location = new System.Drawing.Point(0, 0);
		F2AC9038.Name = "panel1";
		F2AC9038.Size = new System.Drawing.Size(743, 531);
		F2AC9038.TabIndex = 5;
		plContainer.Location = new System.Drawing.Point(12, 44);
		plContainer.Name = "plContainer";
		plContainer.Size = new System.Drawing.Size(714, 470);
		plContainer.TabIndex = 0;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(743, 531);
		base.Controls.Add(FE076513);
		base.Controls.Add(F2AC9038);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fContact";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		FE076513.ResumeLayout(false);
		ADBA7281.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)EBA07E19).EndInit();
		F2AC9038.ResumeLayout(false);
		ResumeLayout(false);
	}
}
