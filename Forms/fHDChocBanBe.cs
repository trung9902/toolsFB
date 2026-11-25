using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDChocBanBe : Form
{
	internal GClass4 C83CD83A;

	internal string string_0;

	internal string string_1;

	internal string AB06FCAF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl AC18C485;

	internal Panel B5108228;

	internal NumericUpDown CA0DF3AC;

	internal NumericUpDown A73C4722;

	internal NumericUpDown BD867B35;

	internal NumericUpDown BD98F0B8;

	internal TextBox C9081C8C;

	internal Label E1891F2C;

	internal Label label3;

	internal Label C6A102BA;

	internal Label label2;

	internal Label label1;

	internal Button DB1418B9;

	internal Button btnAdd;

	internal BunifuCards A2BA1EBA;

	internal Panel C89C7222;

	internal Button button1;

	internal PictureBox E32E6232;

	internal BunifuCustomLabel E78CFF3B;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public fHDChocBanBe(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		AB06FCAF = string_3;
		string aA239C = Language.GetValue(E78CFF3B.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			C9081C8C.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			C9081C8C.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		C83CD83A = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void fHDChocBanBe_Load(object sender, EventArgs e)
	{
		try
		{
			BD98F0B8.Value = C83CD83A.method_2("nudSoLuongFrom", 2);
			A73C4722.Value = C83CD83A.method_2("nudSoLuongTo", 2);
			BD867B35.Value = C83CD83A.method_2("nudDelayFrom", 3);
			CA0DF3AC.Value = C83CD83A.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void E88C2BB6(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = C9081C8C.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", BD98F0B8.Value);
		gClass.method_4("nudSoLuongTo", A73C4722.Value);
		gClass.method_4("nudDelayFrom", BD867B35.Value);
		gClass.method_4("nudDelayTo", CA0DF3AC.Value);
		string e013A = gClass.ED11179C();
		if (AB06FCAF == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(AB06FCAF, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void DB1418B9_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E184233B(object sender, PaintEventArgs e)
	{
		if (B5108228.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, B5108228.ClientSize.Width - num, B5108228.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDChocBanBe));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		E78CFF3B = new Bunifu.Framework.UI.BunifuCustomLabel();
		AC18C485 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		C89C7222 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		E32E6232 = new System.Windows.Forms.PictureBox();
		B5108228 = new System.Windows.Forms.Panel();
		CA0DF3AC = new System.Windows.Forms.NumericUpDown();
		A73C4722 = new System.Windows.Forms.NumericUpDown();
		BD867B35 = new System.Windows.Forms.NumericUpDown();
		BD98F0B8 = new System.Windows.Forms.NumericUpDown();
		C9081C8C = new System.Windows.Forms.TextBox();
		E1891F2C = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		C6A102BA = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		DB1418B9 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		A2BA1EBA = new Bunifu.Framework.UI.BunifuCards();
		C89C7222.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E32E6232).BeginInit();
		B5108228.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CA0DF3AC).BeginInit();
		((System.ComponentModel.ISupportInitialize)A73C4722).BeginInit();
		((System.ComponentModel.ISupportInitialize)BD867B35).BeginInit();
		((System.ComponentModel.ISupportInitialize)BD98F0B8).BeginInit();
		A2BA1EBA.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = E78CFF3B;
		bunifuDragControl_0.Vertical = true;
		E78CFF3B.BackColor = System.Drawing.Color.Transparent;
		E78CFF3B.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E78CFF3B.Dock = System.Windows.Forms.DockStyle.Fill;
		E78CFF3B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E78CFF3B.ForeColor = System.Drawing.Color.Black;
		E78CFF3B.Location = new System.Drawing.Point(0, 0);
		E78CFF3B.Name = "bunifuCustomLabel1";
		E78CFF3B.Size = new System.Drawing.Size(318, 31);
		E78CFF3B.TabIndex = 12;
		E78CFF3B.Text = "Cấu hình Cho\u0323c ba\u0323n be\u0300";
		E78CFF3B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AC18C485.Fixed = true;
		AC18C485.Horizontal = true;
		AC18C485.TargetControl = C89C7222;
		AC18C485.Vertical = true;
		C89C7222.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C89C7222.BackColor = System.Drawing.Color.White;
		C89C7222.Controls.Add(button1);
		C89C7222.Controls.Add(E32E6232);
		C89C7222.Controls.Add(E78CFF3B);
		C89C7222.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C89C7222.Location = new System.Drawing.Point(0, 3);
		C89C7222.Name = "pnlHeader";
		C89C7222.Size = new System.Drawing.Size(318, 31);
		C89C7222.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(287, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(E88C2BB6);
		E32E6232.Cursor = System.Windows.Forms.Cursors.Default;
		E32E6232.Image = Class155.DD225F0D;
		E32E6232.Location = new System.Drawing.Point(3, 2);
		E32E6232.Name = "pictureBox1";
		E32E6232.Size = new System.Drawing.Size(34, 27);
		E32E6232.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E32E6232.TabIndex = 76;
		E32E6232.TabStop = false;
		B5108228.BackColor = System.Drawing.Color.White;
		B5108228.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B5108228.Controls.Add(CA0DF3AC);
		B5108228.Controls.Add(A73C4722);
		B5108228.Controls.Add(BD867B35);
		B5108228.Controls.Add(BD98F0B8);
		B5108228.Controls.Add(C9081C8C);
		B5108228.Controls.Add(E1891F2C);
		B5108228.Controls.Add(label3);
		B5108228.Controls.Add(C6A102BA);
		B5108228.Controls.Add(label2);
		B5108228.Controls.Add(label1);
		B5108228.Controls.Add(DB1418B9);
		B5108228.Controls.Add(btnAdd);
		B5108228.Controls.Add(A2BA1EBA);
		B5108228.Cursor = System.Windows.Forms.Cursors.Arrow;
		B5108228.Dock = System.Windows.Forms.DockStyle.Fill;
		B5108228.Location = new System.Drawing.Point(0, 0);
		B5108228.Name = "panel1";
		B5108228.Size = new System.Drawing.Size(321, 189);
		B5108228.TabIndex = 0;
		B5108228.Paint += new System.Windows.Forms.PaintEventHandler(E184233B);
		CA0DF3AC.Location = new System.Drawing.Point(229, 107);
		CA0DF3AC.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CA0DF3AC.Name = "nudDelayTo";
		CA0DF3AC.Size = new System.Drawing.Size(56, 23);
		CA0DF3AC.TabIndex = 4;
		A73C4722.Location = new System.Drawing.Point(229, 78);
		A73C4722.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A73C4722.Name = "nudSoLuongTo";
		A73C4722.Size = new System.Drawing.Size(56, 23);
		A73C4722.TabIndex = 2;
		BD867B35.Location = new System.Drawing.Point(125, 107);
		BD867B35.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BD867B35.Name = "nudDelayFrom";
		BD867B35.Size = new System.Drawing.Size(56, 23);
		BD867B35.TabIndex = 3;
		BD98F0B8.Location = new System.Drawing.Point(125, 78);
		BD98F0B8.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BD98F0B8.Name = "nudSoLuongFrom";
		BD98F0B8.Size = new System.Drawing.Size(56, 23);
		BD98F0B8.TabIndex = 1;
		C9081C8C.Location = new System.Drawing.Point(125, 49);
		C9081C8C.Name = "txtTenHanhDong";
		C9081C8C.Size = new System.Drawing.Size(160, 23);
		C9081C8C.TabIndex = 0;
		E1891F2C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E1891F2C.Location = new System.Drawing.Point(191, 109);
		E1891F2C.Name = "label7";
		E1891F2C.Size = new System.Drawing.Size(29, 16);
		E1891F2C.TabIndex = 38;
		E1891F2C.Text = ">";
		E1891F2C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(191, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C6A102BA.AutoSize = true;
		C6A102BA.Location = new System.Drawing.Point(27, 109);
		C6A102BA.Name = "label5";
		C6A102BA.Size = new System.Drawing.Size(87, 16);
		C6A102BA.TabIndex = 34;
		C6A102BA.Text = "Gia\u0303n ca\u0301ch (s):";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 80);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(88, 16);
		label2.TabIndex = 32;
		label2.Text = "Sô\u0301 lươ\u0323ng bạn:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		DB1418B9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		DB1418B9.BackColor = System.Drawing.Color.Maroon;
		DB1418B9.Cursor = System.Windows.Forms.Cursors.Hand;
		DB1418B9.FlatAppearance.BorderSize = 0;
		DB1418B9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DB1418B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DB1418B9.ForeColor = System.Drawing.Color.White;
		DB1418B9.Location = new System.Drawing.Point(177, 147);
		DB1418B9.Name = "btnCancel";
		DB1418B9.Size = new System.Drawing.Size(92, 29);
		DB1418B9.TabIndex = 10;
		DB1418B9.Text = "Đóng";
		DB1418B9.UseVisualStyleBackColor = false;
		DB1418B9.Click += new System.EventHandler(DB1418B9_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(70, 147);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		A2BA1EBA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A2BA1EBA.BackColor = System.Drawing.Color.White;
		A2BA1EBA.BorderRadius = 0;
		A2BA1EBA.BottomSahddow = true;
		A2BA1EBA.color = System.Drawing.Color.DarkViolet;
		A2BA1EBA.Controls.Add(C89C7222);
		A2BA1EBA.LeftSahddow = false;
		A2BA1EBA.Location = new System.Drawing.Point(1, 0);
		A2BA1EBA.Name = "bunifuCards1";
		A2BA1EBA.RightSahddow = true;
		A2BA1EBA.ShadowDepth = 20;
		A2BA1EBA.Size = new System.Drawing.Size(318, 37);
		A2BA1EBA.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(321, 189);
		base.Controls.Add(B5108228);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDChocBanBe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDChocBanBe_Load);
		C89C7222.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E32E6232).EndInit();
		B5108228.ResumeLayout(false);
		B5108228.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CA0DF3AC).EndInit();
		((System.ComponentModel.ISupportInitialize)A73C4722).EndInit();
		((System.ComponentModel.ISupportInitialize)BD867B35).EndInit();
		((System.ComponentModel.ISupportInitialize)BD98F0B8).EndInit();
		A2BA1EBA.ResumeLayout(false);
		ResumeLayout(false);
	}
}
