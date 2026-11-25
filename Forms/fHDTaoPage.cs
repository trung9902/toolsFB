using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDTaoPage : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 F82E652C;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool B52DFEBC;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox F2330119;

	internal Label label3;

	internal Label label1;

	internal Button A03915BA;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button C2BEC393;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal RichTextBox txtPageName;

	internal RichTextBox B3AE4A3F;

	internal Label lblPageName;

	internal Label lblCatagory;

	internal TextBox txtToCookie;

	internal Label lblToCookie;

	internal CheckBox F80D11AA;

	internal Label F8A604B3;

	internal Label label9;

	private List<string> list_Bio = new List<string>();

	private List<string> list_Website = new List<string>();

	private List<string> list_Phone = new List<string>();

	private List<string> list_Email = new List<string>();

	private List<string> list_Address = new List<string>();

	private List<string> list_City = new List<string>();

	private List<string> list_ZipCode = new List<string>();

	internal Label lblBio;

	internal Button btnBio;

	internal Label lblWebsite;

	internal Button btnWebsite;

	internal Label lblPhone;

	internal Button btnPhone;

	internal Label lblEmail;

	internal Button btnEmail;

	internal GroupBox grLocation;

	internal Label lblAddress;

	internal Button btnAddress;

	internal Label lblCity;

	internal Button btnCity;

	internal Label lblZipCode;

	internal Button btnZipCode;

	internal Label lblFolderAvatar;

	internal TextBox txtFolderAvatar;

	internal Button btnChooseFolderAvatar;

	internal Label lblFolderCover;

	internal TextBox txtFolderCover;

	internal Button btnChooseFolderCover;

	internal Label lblUidNhanPage;

	internal TextBox txtUidNhanPage;

	internal Button btnChooseUidFile;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return B52DFEBC;
		}
		[CompilerGenerated]
		set
		{
			B52DFEBC = value;
		}
	}

	public fHDTaoPage(string string_3, string string_4 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_3;
		string_2 = string_4;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_4 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			F2330119.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_4);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			F2330119.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		F82E652C = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to close dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		lblToCookie.Visible = false;
		txtToCookie.Visible = false;
		txtUidNhanPage.DoubleClick += (s, e) => btnChooseUidFile_Click(s, e);
	}

	private void fHDTaoPage_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = F82E652C.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = F82E652C.method_2("nudSoLuongTo", 1);
			nudDelayFrom.Value = F82E652C.method_2("nudDelayFrom", 1);
			nudDelayTo.Value = F82E652C.method_2("nudDelayTo", 1);
			txtPageName.Text = F82E652C.BDB80B23("txtPageName");
			B3AE4A3F.Text = F82E652C.BDB80B23("txtCatagory");
			F80D11AA.Checked = F82E652C.method_3("ckbAutoDeleteContent");

			list_Bio = F82E652C.method_1("lstBio");
			list_Website = F82E652C.method_1("lstWebsite");
			list_Phone = F82E652C.method_1("lstPhone");
			list_Email = F82E652C.method_1("lstEmail");
			list_Address = F82E652C.method_1("lstAddress");
			list_City = F82E652C.method_1("lstCity");
			list_ZipCode = F82E652C.method_1("lstZipCode");

			txtFolderAvatar.Text = F82E652C.BDB80B23("txtFolderAvatar");
			txtFolderCover.Text = F82E652C.BDB80B23("txtFolderCover");

			string uid = F82E652C.BDB80B23("txtUidNhanPage");
			if (string.IsNullOrEmpty(uid))
			{
				uid = F82E652C.BDB80B23("txtToCookie");
			}
			txtUidNhanPage.Text = uid;
			txtToCookie.Text = uid;

			btnBio.Text = "Nhập (" + list_Bio.Count + ")";
			btnWebsite.Text = "Nhập (" + list_Website.Count + ")";
			btnPhone.Text = "Nhập (" + list_Phone.Count + ")";
			btnEmail.Text = "Nhập (" + list_Email.Count + ")";
			btnAddress.Text = "Nhập (" + list_Address.Count + ")";
			btnCity.Text = "Nhập (" + list_City.Count + ")";
			btnZipCode.Text = "Nhập (" + list_ZipCode.Count + ")";
		}
		catch
		{
		}
		txtPageName.AF8ADE0B("Nhập tên page (hỗ trợ spin {a|b|c}, * random số)...");
		B3AE4A3F.AF8ADE0B("Nhập danh mục (VD: Digital Creator, Blog cá nhân)...");
		Commom.A9BCAF05(txtPageName, lblPageName);
		Commom.A9BCAF05(B3AE4A3F, lblCatagory);
		Commom.AttachFolderPicker(txtFolderAvatar);
		Commom.AttachFolderPicker(txtFolderCover);
	}

	private void E32FB180(object sender, EventArgs e)
	{
		Close();
	}

	private void D33E1224(object sender, EventArgs e)
	{
		string text = F2330119.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (!string.IsNullOrWhiteSpace(txtFolderAvatar.Text))
		{
			string fAvatar = txtFolderAvatar.Text.Trim();
			if (!Directory.Exists(fAvatar))
			{
				MsBoxHelper.Show("Thư mục avatar không tồn tại! Vui lòng chọn lại.", 3);
				txtFolderAvatar.Focus();
				return;
			}
			if (!Commom.ValidateMediaFolder(fAvatar, out int mCount, out string _) || mCount == 0)
			{
				MsBoxHelper.Show("Thư mục avatar không có file ảnh nào! Vui lòng kiểm tra lại.", 3);
				txtFolderAvatar.Focus();
				return;
			}
		}
		if (!string.IsNullOrWhiteSpace(txtFolderCover.Text))
		{
			string fCover = txtFolderCover.Text.Trim();
			if (!Directory.Exists(fCover))
			{
				MsBoxHelper.Show("Thư mục cover không tồn tại! Vui lòng chọn lại.", 3);
				txtFolderCover.Focus();
				return;
			}
			if (!Commom.ValidateMediaFolder(fCover, out int mCount, out string _) || mCount == 0)
			{
				MsBoxHelper.Show("Thư mục cover không có file ảnh nào! Vui lòng kiểm tra lại.", 3);
				txtFolderCover.Focus();
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		string placeholderPage = "Nhập tên page (hỗ trợ spin {a|b|c}, * random số)...";
		string placeholderPageOld = "Nhập tên page (có thể sử dụng ký tự * để random 1 số từ 0 -> 9, ví dụ: Phần mềm nuôi nick ***)...";
		string placeholderCat = "Nhập danh mục (VD: Digital Creator, Blog cá nhân)...";
		string placeholderCatOld = "Nhập tên danh mục page bằng tiếng anh (ví dụ: digital creator, creator)...";

		string pageNameVal = txtPageName.Text;
		if (pageNameVal == Language.GetValue(placeholderPage) || pageNameVal == txtPageName.Tag?.ToString() || pageNameVal == Language.GetValue(placeholderPageOld))
		{
			pageNameVal = "";
		}
		gClass.method_4("txtPageName", pageNameVal);

		string catVal = B3AE4A3F.Text;
		if (catVal == Language.GetValue(placeholderCat) || catVal == B3AE4A3F.Tag?.ToString() || catVal == Language.GetValue(placeholderCatOld))
		{
			catVal = "";
		}
		gClass.method_4("txtCatagory", catVal);
		gClass.method_4("ckbAutoDeleteContent", F80D11AA.Checked);

		gClass.FD3CCF90("lstBio", list_Bio);
		gClass.FD3CCF90("lstWebsite", list_Website);
		gClass.FD3CCF90("lstPhone", list_Phone);
		gClass.FD3CCF90("lstEmail", list_Email);
		gClass.FD3CCF90("lstAddress", list_Address);
		gClass.FD3CCF90("lstCity", list_City);
		gClass.FD3CCF90("lstZipCode", list_ZipCode);

		gClass.method_4("txtFolderAvatar", txtFolderAvatar.Text.Trim());
		gClass.method_4("txtFolderCover", txtFolderCover.Text.Trim());
		gClass.method_4("txtUidNhanPage", txtUidNhanPage.Text.Trim());
		gClass.method_4("txtToCookie", txtUidNhanPage.Text.Trim());

		string e013A = gClass.ED11179C();
		if (string_2 == "")
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
			if (Class154.smethod_13(string_2, text, e013A))
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

	private void A03915BA_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C114EEB3(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void txtPageName_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtPageName, lblPageName);
	}

	private void E40A2E16(object sender, EventArgs e)
	{
		Commom.A9BCAF05(B3AE4A3F, lblCatagory);
	}

	private void btnBio_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_Bio, "Nhập danh sách Bio", "Danh sách Bio", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_Bio = fNhapDuLieu.list_0;
		btnBio.Text = "Nhập (" + list_Bio.Count + ")";
	}

	private void btnWebsite_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_Website, "Nhập danh sách Website", "Danh sách Website", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_Website = fNhapDuLieu.list_0;
		btnWebsite.Text = "Nhập (" + list_Website.Count + ")";
	}

	private void btnPhone_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_Phone, "Nhập danh sách Phone", "Danh sách Phone", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_Phone = fNhapDuLieu.list_0;
		btnPhone.Text = "Nhập (" + list_Phone.Count + ")";
	}

	private void btnEmail_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_Email, "Nhập danh sách Email", "Danh sách Email", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_Email = fNhapDuLieu.list_0;
		btnEmail.Text = "Nhập (" + list_Email.Count + ")";
	}

	private void btnAddress_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_Address, "Nhập danh sách Address", "Danh sách Address", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_Address = fNhapDuLieu.list_0;
		btnAddress.Text = "Nhập (" + list_Address.Count + ")";
	}

	private void btnCity_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_City, "Nhập danh sách City/town", "Danh sách City/town", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_City = fNhapDuLieu.list_0;
		btnCity.Text = "Nhập (" + list_City.Count + ")";
	}

	private void btnZipCode_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu = new fNhapDuLieu1(list_ZipCode, "Nhập danh sách ZIP code", "Danh sách ZIP code", "(Mỗi nội dung 1 dòng)");
		Commom.smethod_35(fNhapDuLieu);
		list_ZipCode = fNhapDuLieu.list_0;
		btnZipCode.Text = "Nhập (" + list_ZipCode.Count + ")";
	}

	private void btnChooseFolderAvatar_Click(object sender, EventArgs e)
	{
		using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
		{
			folderBrowserDialog.Description = "Chọn thư mục chứa ảnh avatar";
			if (Directory.Exists(txtFolderAvatar.Text.Trim()))
			{
				folderBrowserDialog.SelectedPath = txtFolderAvatar.Text.Trim();
			}
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				txtFolderAvatar.Text = folderBrowserDialog.SelectedPath;
				Commom.ShowFolderMediaTooltip(txtFolderAvatar, folderBrowserDialog.SelectedPath);
			}
		}
	}

	private void btnChooseFolderCover_Click(object sender, EventArgs e)
	{
		using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
		{
			folderBrowserDialog.Description = "Chọn thư mục chứa ảnh cover";
			if (Directory.Exists(txtFolderCover.Text.Trim()))
			{
				folderBrowserDialog.SelectedPath = txtFolderCover.Text.Trim();
			}
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				txtFolderCover.Text = folderBrowserDialog.SelectedPath;
				Commom.ShowFolderMediaTooltip(txtFolderCover, folderBrowserDialog.SelectedPath);
			}
		}
	}

	private void btnChooseUidFile_Click(object sender, EventArgs e)
	{
		using (OpenFileDialog openFileDialog = new OpenFileDialog())
		{
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			openFileDialog.Title = "Chọn file danh sách UID nhận page";
			if (File.Exists(txtUidNhanPage.Text.Trim()))
			{
				try
				{
					openFileDialog.InitialDirectory = Path.GetDirectoryName(txtUidNhanPage.Text.Trim());
					openFileDialog.FileName = Path.GetFileName(txtUidNhanPage.Text.Trim());
				}
				catch { }
			}
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				txtUidNhanPage.Text = openFileDialog.FileName;
			}
		}
	}

	protected override void Dispose(bool AA0D663D)
	{
		if (AA0D663D && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(AA0D663D);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTaoPage));
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		C2BEC393 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		F80D11AA = new System.Windows.Forms.CheckBox();
		txtPageName = new System.Windows.Forms.RichTextBox();
		B3AE4A3F = new System.Windows.Forms.RichTextBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		lblPageName = new System.Windows.Forms.Label();
		lblCatagory = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		F2330119 = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		A03915BA = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		txtToCookie = new System.Windows.Forms.TextBox();
		lblToCookie = new System.Windows.Forms.Label();
		F8A604B3 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();

		lblBio = new System.Windows.Forms.Label();
		btnBio = new System.Windows.Forms.Button();
		lblWebsite = new System.Windows.Forms.Label();
		btnWebsite = new System.Windows.Forms.Button();
		lblPhone = new System.Windows.Forms.Label();
		btnPhone = new System.Windows.Forms.Button();
		lblEmail = new System.Windows.Forms.Label();
		btnEmail = new System.Windows.Forms.Button();

		grLocation = new System.Windows.Forms.GroupBox();
		lblAddress = new System.Windows.Forms.Label();
		btnAddress = new System.Windows.Forms.Button();
		lblCity = new System.Windows.Forms.Label();
		btnCity = new System.Windows.Forms.Button();
		lblZipCode = new System.Windows.Forms.Label();
		btnZipCode = new System.Windows.Forms.Button();

		lblFolderAvatar = new System.Windows.Forms.Label();
		txtFolderAvatar = new System.Windows.Forms.TextBox();
		btnChooseFolderAvatar = new System.Windows.Forms.Button();

		lblFolderCover = new System.Windows.Forms.Label();
		txtFolderCover = new System.Windows.Forms.TextBox();
		btnChooseFolderCover = new System.Windows.Forms.Button();

		lblUidNhanPage = new System.Windows.Forms.Label();
		txtUidNhanPage = new System.Windows.Forms.TextBox();
		btnChooseUidFile = new System.Windows.Forms.Button();

		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		grLocation.SuspendLayout();
		SuspendLayout();

		// bunifuDragControl_0
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;

		// bunifuCustomLabel1
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(668, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tạo page";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// bunifuDragControl_1
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;

		// pnlHeader
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(C2BEC393);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(668, 31);
		pnlHeader.TabIndex = 9;

		// C2BEC393 (Close button)
		C2BEC393.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		C2BEC393.Cursor = System.Windows.Forms.Cursors.Hand;
		C2BEC393.FlatAppearance.BorderSize = 0;
		C2BEC393.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C2BEC393.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C2BEC393.ForeColor = System.Drawing.Color.White;
		C2BEC393.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		C2BEC393.Location = new System.Drawing.Point(636, 1);
		C2BEC393.Name = "button1";
		C2BEC393.Size = new System.Drawing.Size(30, 30);
		C2BEC393.TabIndex = 77;
		C2BEC393.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		C2BEC393.UseVisualStyleBackColor = true;
		C2BEC393.Click += new System.EventHandler(E32FB180);
		System.Drawing.Image iconClose_fHDTa = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDTa != null) C2BEC393.Image = iconClose_fHDTa;

		// pictureBox1
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDTa = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDTa != null) pictureBox1.Image = iconApp_fHDTa;

		// panel1
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(F8A604B3);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(F80D11AA);
		panel1.Controls.Add(txtPageName);
		panel1.Controls.Add(B3AE4A3F);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(lblPageName);
		panel1.Controls.Add(lblCatagory);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(F2330119);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(A03915BA);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(txtToCookie);
		panel1.Controls.Add(lblToCookie);

		panel1.Controls.Add(lblBio);
		panel1.Controls.Add(btnBio);
		panel1.Controls.Add(lblWebsite);
		panel1.Controls.Add(btnWebsite);
		panel1.Controls.Add(lblPhone);
		panel1.Controls.Add(btnPhone);
		panel1.Controls.Add(lblEmail);
		panel1.Controls.Add(btnEmail);
		panel1.Controls.Add(grLocation);
		panel1.Controls.Add(lblFolderAvatar);
		panel1.Controls.Add(txtFolderAvatar);
		panel1.Controls.Add(btnChooseFolderAvatar);
		panel1.Controls.Add(lblFolderCover);
		panel1.Controls.Add(txtFolderCover);
		panel1.Controls.Add(btnChooseFolderCover);
		panel1.Controls.Add(lblUidNhanPage);
		panel1.Controls.Add(txtUidNhanPage);
		panel1.Controls.Add(btnChooseUidFile);

		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(670, 485);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(C114EEB3);

		// bunifuCards1
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(668, 37);
		bunifuCards1.TabIndex = 28;

		// label1 (Tên hành động:)
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";

		// F2330119 (txtTenHanhDong)
		F2330119.Location = new System.Drawing.Point(132, 49);
		F2330119.Name = "txtTenHanhDong";
		F2330119.Size = new System.Drawing.Size(194, 23);
		F2330119.TabIndex = 0;
		F2330119.Text = "Tạo page";

		// label9 (Số lượng:)
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 179;
		label9.Text = "Sô\u0301 lươ\u0323ng:";

		// nudSoLuongFrom
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		nudSoLuongFrom.Value = 1;

		// label3 (>)
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(196, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(18, 16);
		label3.TabIndex = 37;
		label3.Text = ">";

		// nudSoLuongTo
		nudSoLuongTo.Location = new System.Drawing.Point(222, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		nudSoLuongTo.Value = 1;

		// F8A604B3 (Giãn cách (s):)
		F8A604B3.AutoSize = true;
		F8A604B3.Location = new System.Drawing.Point(27, 109);
		F8A604B3.Name = "label2";
		F8A604B3.Size = new System.Drawing.Size(87, 16);
		F8A604B3.TabIndex = 178;
		F8A604B3.Text = "Gia\u0303n ca\u0301ch (s):";

		// nudDelayFrom
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		nudDelayFrom.Value = 1;

		// label7 (>)
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(196, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(18, 16);
		label7.TabIndex = 46;
		label7.Text = ">";

		// nudDelayTo
		nudDelayTo.Location = new System.Drawing.Point(222, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayTo.Value = 1;

		// lblPageName
		lblPageName.AutoSize = true;
		lblPageName.Location = new System.Drawing.Point(27, 137);
		lblPageName.Name = "lblPageName";
		lblPageName.Size = new System.Drawing.Size(87, 16);
		lblPageName.TabIndex = 0;
		lblPageName.Text = "Tên page (0):";

		// txtPageName
		txtPageName.Location = new System.Drawing.Point(30, 156);
		txtPageName.Name = "txtPageName";
		txtPageName.Size = new System.Drawing.Size(296, 108);
		txtPageName.TabIndex = 47;
		txtPageName.Text = "";
		txtPageName.WordWrap = false;
		txtPageName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
		txtPageName.TextChanged += new System.EventHandler(txtPageName_TextChanged);

		// F80D11AA (Xóa nội dung đã sử dụng)
		F80D11AA.AutoSize = true;
		F80D11AA.Cursor = System.Windows.Forms.Cursors.Hand;
		F80D11AA.Location = new System.Drawing.Point(30, 270);
		F80D11AA.Name = "ckbAutoDeleteContent";
		F80D11AA.Size = new System.Drawing.Size(169, 20);
		F80D11AA.TabIndex = 177;
		F80D11AA.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		F80D11AA.UseVisualStyleBackColor = true;

		// lblCatagory
		lblCatagory.AutoSize = true;
		lblCatagory.Location = new System.Drawing.Point(27, 296);
		lblCatagory.Name = "lblCatagory";
		lblCatagory.Size = new System.Drawing.Size(122, 16);
		lblCatagory.TabIndex = 0;
		lblCatagory.Text = "Danh mục page (0):";

		// B3AE4A3F (txtCatagory)
		B3AE4A3F.Location = new System.Drawing.Point(30, 315);
		B3AE4A3F.Name = "txtCatagory";
		B3AE4A3F.Size = new System.Drawing.Size(296, 108);
		B3AE4A3F.TabIndex = 48;
		B3AE4A3F.Text = "";
		B3AE4A3F.WordWrap = false;
		B3AE4A3F.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
		B3AE4A3F.TextChanged += new System.EventHandler(E40A2E16);

		// lblBio
		lblBio.AutoSize = true;
		lblBio.Location = new System.Drawing.Point(350, 52);
		lblBio.Name = "lblBio";
		lblBio.Size = new System.Drawing.Size(31, 16);
		lblBio.TabIndex = 180;
		lblBio.Text = "Bio:";

		// btnBio
		btnBio.Cursor = System.Windows.Forms.Cursors.Hand;
		btnBio.Location = new System.Drawing.Point(440, 47);
		btnBio.Name = "btnBio";
		btnBio.Size = new System.Drawing.Size(195, 27);
		btnBio.TabIndex = 181;
		btnBio.Text = "Nhập (0)";
		btnBio.UseVisualStyleBackColor = true;
		btnBio.Click += new System.EventHandler(btnBio_Click);

		// lblWebsite
		lblWebsite.AutoSize = true;
		lblWebsite.Location = new System.Drawing.Point(350, 81);
		lblWebsite.Name = "lblWebsite";
		lblWebsite.Size = new System.Drawing.Size(58, 16);
		lblWebsite.TabIndex = 182;
		lblWebsite.Text = "Website:";

		// btnWebsite
		btnWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
		btnWebsite.Location = new System.Drawing.Point(440, 76);
		btnWebsite.Name = "btnWebsite";
		btnWebsite.Size = new System.Drawing.Size(195, 27);
		btnWebsite.TabIndex = 183;
		btnWebsite.Text = "Nhập (0)";
		btnWebsite.UseVisualStyleBackColor = true;
		btnWebsite.Click += new System.EventHandler(btnWebsite_Click);

		// lblPhone
		lblPhone.AutoSize = true;
		lblPhone.Location = new System.Drawing.Point(350, 110);
		lblPhone.Name = "lblPhone";
		lblPhone.Size = new System.Drawing.Size(46, 16);
		lblPhone.TabIndex = 184;
		lblPhone.Text = "Phone:";

		// btnPhone
		btnPhone.Cursor = System.Windows.Forms.Cursors.Hand;
		btnPhone.Location = new System.Drawing.Point(440, 105);
		btnPhone.Name = "btnPhone";
		btnPhone.Size = new System.Drawing.Size(195, 27);
		btnPhone.TabIndex = 185;
		btnPhone.Text = "Nhập (0)";
		btnPhone.UseVisualStyleBackColor = true;
		btnPhone.Click += new System.EventHandler(btnPhone_Click);

		// lblEmail
		lblEmail.AutoSize = true;
		lblEmail.Location = new System.Drawing.Point(350, 139);
		lblEmail.Name = "lblEmail";
		lblEmail.Size = new System.Drawing.Size(41, 16);
		lblEmail.TabIndex = 186;
		lblEmail.Text = "Email:";

		// btnEmail
		btnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
		btnEmail.Location = new System.Drawing.Point(440, 134);
		btnEmail.Name = "btnEmail";
		btnEmail.Size = new System.Drawing.Size(195, 27);
		btnEmail.TabIndex = 187;
		btnEmail.Text = "Nhập (0)";
		btnEmail.UseVisualStyleBackColor = true;
		btnEmail.Click += new System.EventHandler(btnEmail_Click);

		// grLocation
		grLocation.Controls.Add(lblAddress);
		grLocation.Controls.Add(btnAddress);
		grLocation.Controls.Add(lblCity);
		grLocation.Controls.Add(btnCity);
		grLocation.Controls.Add(lblZipCode);
		grLocation.Controls.Add(btnZipCode);
		grLocation.Location = new System.Drawing.Point(350, 165);
		grLocation.Name = "grLocation";
		grLocation.Size = new System.Drawing.Size(285, 118);
		grLocation.TabIndex = 188;
		grLocation.TabStop = false;
		grLocation.Text = "Location";

		// lblAddress
		lblAddress.AutoSize = true;
		lblAddress.Location = new System.Drawing.Point(12, 24);
		lblAddress.Name = "lblAddress";
		lblAddress.Size = new System.Drawing.Size(58, 16);
		lblAddress.TabIndex = 0;
		lblAddress.Text = "Address:";

		// btnAddress
		btnAddress.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAddress.Location = new System.Drawing.Point(90, 19);
		btnAddress.Name = "btnAddress";
		btnAddress.Size = new System.Drawing.Size(180, 27);
		btnAddress.TabIndex = 1;
		btnAddress.Text = "Nhập (0)";
		btnAddress.UseVisualStyleBackColor = true;
		btnAddress.Click += new System.EventHandler(btnAddress_Click);

		// lblCity
		lblCity.AutoSize = true;
		lblCity.Location = new System.Drawing.Point(12, 54);
		lblCity.Name = "lblCity";
		lblCity.Size = new System.Drawing.Size(62, 16);
		lblCity.TabIndex = 2;
		lblCity.Text = "City/town:";

		// btnCity
		btnCity.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCity.Location = new System.Drawing.Point(90, 49);
		btnCity.Name = "btnCity";
		btnCity.Size = new System.Drawing.Size(180, 27);
		btnCity.TabIndex = 3;
		btnCity.Text = "Nhập (0)";
		btnCity.UseVisualStyleBackColor = true;
		btnCity.Click += new System.EventHandler(btnCity_Click);

		// lblZipCode
		lblZipCode.AutoSize = true;
		lblZipCode.Location = new System.Drawing.Point(12, 84);
		lblZipCode.Name = "lblZipCode";
		lblZipCode.Size = new System.Drawing.Size(60, 16);
		lblZipCode.TabIndex = 4;
		lblZipCode.Text = "ZIP code:";

		// btnZipCode
		btnZipCode.Cursor = System.Windows.Forms.Cursors.Hand;
		btnZipCode.Location = new System.Drawing.Point(90, 79);
		btnZipCode.Name = "btnZipCode";
		btnZipCode.Size = new System.Drawing.Size(180, 27);
		btnZipCode.TabIndex = 5;
		btnZipCode.Text = "Nhập (0)";
		btnZipCode.UseVisualStyleBackColor = true;
		btnZipCode.Click += new System.EventHandler(btnZipCode_Click);

		// lblFolderAvatar
		lblFolderAvatar.AutoSize = true;
		lblFolderAvatar.Location = new System.Drawing.Point(350, 295);
		lblFolderAvatar.Name = "lblFolderAvatar";
		lblFolderAvatar.Size = new System.Drawing.Size(86, 16);
		lblFolderAvatar.TabIndex = 189;
		lblFolderAvatar.Text = "Folder avatar:";

		// txtFolderAvatar
		txtFolderAvatar.Location = new System.Drawing.Point(440, 292);
		txtFolderAvatar.Name = "txtFolderAvatar";
		txtFolderAvatar.Size = new System.Drawing.Size(155, 23);
		txtFolderAvatar.TabIndex = 190;

		// btnChooseFolderAvatar
		btnChooseFolderAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
		btnChooseFolderAvatar.Location = new System.Drawing.Point(601, 290);
		btnChooseFolderAvatar.Name = "btnChooseFolderAvatar";
		btnChooseFolderAvatar.Size = new System.Drawing.Size(34, 26);
		btnChooseFolderAvatar.TabIndex = 191;
		btnChooseFolderAvatar.Text = "...";
		btnChooseFolderAvatar.UseVisualStyleBackColor = true;
		btnChooseFolderAvatar.Click += new System.EventHandler(btnChooseFolderAvatar_Click);

		// lblFolderCover
		lblFolderCover.AutoSize = true;
		lblFolderCover.Location = new System.Drawing.Point(350, 326);
		lblFolderCover.Name = "lblFolderCover";
		lblFolderCover.Size = new System.Drawing.Size(81, 16);
		lblFolderCover.TabIndex = 192;
		lblFolderCover.Text = "Folder cover:";

		// txtFolderCover
		txtFolderCover.Location = new System.Drawing.Point(440, 323);
		txtFolderCover.Name = "txtFolderCover";
		txtFolderCover.Size = new System.Drawing.Size(155, 23);
		txtFolderCover.TabIndex = 193;

		// btnChooseFolderCover
		btnChooseFolderCover.Cursor = System.Windows.Forms.Cursors.Hand;
		btnChooseFolderCover.Location = new System.Drawing.Point(601, 321);
		btnChooseFolderCover.Name = "btnChooseFolderCover";
		btnChooseFolderCover.Size = new System.Drawing.Size(34, 26);
		btnChooseFolderCover.TabIndex = 194;
		btnChooseFolderCover.Text = "...";
		btnChooseFolderCover.UseVisualStyleBackColor = true;
		btnChooseFolderCover.Click += new System.EventHandler(btnChooseFolderCover_Click);

		// lblUidNhanPage
		lblUidNhanPage.AutoSize = true;
		lblUidNhanPage.Location = new System.Drawing.Point(350, 357);
		lblUidNhanPage.Name = "lblUidNhanPage";
		lblUidNhanPage.Size = new System.Drawing.Size(93, 16);
		lblUidNhanPage.TabIndex = 195;
		lblUidNhanPage.Text = "Uid nhận page:";

		// txtUidNhanPage
		txtUidNhanPage.Location = new System.Drawing.Point(440, 354);
		txtUidNhanPage.Name = "txtUidNhanPage";
		txtUidNhanPage.Size = new System.Drawing.Size(155, 23);
		txtUidNhanPage.TabIndex = 196;

		// btnChooseUidFile
		btnChooseUidFile.Cursor = System.Windows.Forms.Cursors.Hand;
		btnChooseUidFile.Location = new System.Drawing.Point(601, 352);
		btnChooseUidFile.Name = "btnChooseUidFile";
		btnChooseUidFile.Size = new System.Drawing.Size(34, 26);
		btnChooseUidFile.TabIndex = 197;
		btnChooseUidFile.Text = "...";
		btnChooseUidFile.UseVisualStyleBackColor = true;
		btnChooseUidFile.Click += new System.EventHandler(btnChooseUidFile_Click);

		// btnAdd (Cập nhật)
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(235, 442);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(95, 30);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Cập nhật";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(D33E1224);

		// A03915BA (Đóng)
		A03915BA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A03915BA.BackColor = System.Drawing.Color.Maroon;
		A03915BA.Cursor = System.Windows.Forms.Cursors.Hand;
		A03915BA.FlatAppearance.BorderSize = 0;
		A03915BA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A03915BA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A03915BA.ForeColor = System.Drawing.Color.White;
		A03915BA.Location = new System.Drawing.Point(342, 442);
		A03915BA.Name = "btnCancel";
		A03915BA.Size = new System.Drawing.Size(95, 30);
		A03915BA.TabIndex = 7;
		A03915BA.Text = "Đóng";
		A03915BA.UseVisualStyleBackColor = false;
		A03915BA.Click += new System.EventHandler(A03915BA_Click);

		// txtToCookie & lblToCookie (hidden)
		txtToCookie.Location = new System.Drawing.Point(440, 385);
		txtToCookie.Name = "txtToCookie";
		txtToCookie.Size = new System.Drawing.Size(195, 23);
		txtToCookie.TabIndex = 0;
		txtToCookie.Visible = false;
		lblToCookie.AutoSize = true;
		lblToCookie.Location = new System.Drawing.Point(350, 388);
		lblToCookie.Name = "lblToCookie";
		lblToCookie.Size = new System.Drawing.Size(114, 16);
		lblToCookie.TabIndex = 31;
		lblToCookie.Text = "Cookie nhận page:";
		lblToCookie.Visible = false;

		// Form fHDTaoPage
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(670, 485);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTaoPage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDTaoPage_Load);

		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		grLocation.ResumeLayout(false);
		grLocation.PerformLayout();
		ResumeLayout(false);
	}
}
