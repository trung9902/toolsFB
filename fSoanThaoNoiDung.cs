using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fSoanThaoNoiDung : Form
{
	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
	private const int EM_SETMARGINS = 0xD3;
	private const int EC_LEFTMARGIN = 0x1;
	private const int EC_RIGHTMARGIN = 0x2;

	public string Content { get; set; } = "";
	public bool IsMultiPost { get; set; } = false;

	private BunifuCards bunifuCards1;
	private Panel pnlHeader;
	private BunifuCustomLabel lblTitle;
	private Button btnClose;
	private BunifuDragControl bunifuDragControl;

	private Panel pnlToolbar;
	private FlowLayoutPanel flpEmoji;
	private FlowLayoutPanel flpTags;
	private RadioButton rbDonDong;
	private RadioButton rbDaDong;

	private Panel pnlEditorContainer;
	private RichTextBox txtNoiDung;

	private Panel pnlFooter;
	private Label lblStats;
	private Button btnXacNhan;
	private Button btnHuy;

	public fSoanThaoNoiDung(string initialText = "", int typeNganCach = 0)
	{
		InitializeComponent();
		txtNoiDung.Text = initialText ?? "";
		if (typeNganCach == 1 || (initialText != null && initialText.Contains("\n|\n")))
		{
			rbDaDong.Checked = true;
		}
		else
		{
			rbDonDong.Checked = true;
		}
		UpdateStats();
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		if (txtNoiDung.IsHandleCreated)
		{
			SendMessage(txtNoiDung.Handle, EM_SETMARGINS, (IntPtr)(EC_LEFTMARGIN | EC_RIGHTMARGIN), (IntPtr)(8 | (8 << 16)));
		}
	}

	private void InitializeComponent()
	{
		Font fontSegoe = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Font fontSegoeBold = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);

		bunifuCards1 = new BunifuCards();
		pnlHeader = new Panel();
		lblTitle = new BunifuCustomLabel();
		btnClose = new Button();
		bunifuDragControl = new BunifuDragControl();

		pnlToolbar = new Panel();
		flpEmoji = new FlowLayoutPanel();
		flpTags = new FlowLayoutPanel();
		rbDonDong = new RadioButton();
		rbDaDong = new RadioButton();

		pnlEditorContainer = new Panel();
		txtNoiDung = new RichTextBox();

		pnlFooter = new Panel();
		lblStats = new Label();
		btnXacNhan = new Button();
		btnHuy = new Button();

		SuspendLayout();

		// Form setup
		AutoScaleDimensions = new SizeF(7f, 16f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(248, 250, 252);
		ClientSize = new Size(860, 640);
		Font = fontSegoe;
		FormBorderStyle = FormBorderStyle.None;
		StartPosition = FormStartPosition.CenterParent;
		Name = "fSoanThaoNoiDung";
		Text = "Soạn thảo nội dung chi tiết";

		// Bunifu Header
		bunifuCards1.BackColor = Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = false;
		bunifuCards1.color = Color.FromArgb(53, 120, 229);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = false;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new Size(860, 38);
		bunifuCards1.TabIndex = 0;

		pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		pnlHeader.BackColor = Color.White;
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Controls.Add(btnClose);
		pnlHeader.Cursor = Cursors.SizeAll;
		pnlHeader.Location = new Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new Size(860, 34);
		pnlHeader.TabIndex = 9;

		lblTitle.AutoSize = true;
		lblTitle.Font = new Font("Segoe UI", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
		lblTitle.Location = new Point(14, 8);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(270, 19);
		lblTitle.Text = "SOẠN THẢO NỘI DUNG BÀI VIẾT";

		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.Cursor = Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnClose.ForeColor = Color.FromArgb(100, 116, 139);
		btnClose.Location = new Point(824, 1);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(34, 32);
		btnClose.Text = "✕";
		btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
		btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 38, 38);
		btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.White;
		btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(100, 116, 139);
		btnClose.Click += (s, e) => Close();

		bunifuDragControl.Fixed = true;
		bunifuDragControl.Horizontal = true;
		bunifuDragControl.TargetControl = pnlHeader;
		bunifuDragControl.Vertical = true;

		// Toolbar Container
		pnlToolbar.Location = new Point(14, 46);
		pnlToolbar.Size = new Size(832, 80);
		pnlToolbar.BackColor = Color.White;
		pnlToolbar.Paint += (s, pe) =>
		{
			using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
			{
				pe.Graphics.DrawRectangle(p, 0, 0, pnlToolbar.Width - 1, pnlToolbar.Height - 1);
				pe.Graphics.DrawLine(p, 0, 39, pnlToolbar.Width, 39);
			}
		};

		// Row 1: Emojis
		flpEmoji.Location = new Point(6, 4);
		flpEmoji.Size = new Size(820, 32);
		flpEmoji.BackColor = Color.Transparent;
		flpEmoji.WrapContents = false;
		flpEmoji.AutoScroll = false;

		ToolTip toolTip1 = new ToolTip();
		EmojiIconHelper.PopulateEmojiToolbar(flpEmoji, InsertTextAtCursor, toolTip1, 28, 20);

		// Row 2: Tags & Format Options
		flpTags.Location = new Point(6, 44);
		flpTags.Size = new Size(520, 30);
		flpTags.BackColor = Color.Transparent;
		flpTags.WrapContents = false;

		Button btnSpin = CreateToolbarButton("Spin {A|B|C}", (s, e) => InsertTextAtCursor("{Nội dung 1|Nội dung 2|Nội dung 3}"), 96);
		Button btnTagTime = CreateToolbarButton("{time}", (s, e) => InsertTextAtCursor("{time}"), 62);
		Button btnTagRandom = CreateToolbarButton("{random}", (s, e) => InsertTextAtCursor("{random}"), 74);
		Button btnDongTrong = CreateToolbarButton("+ Dòng trống", (s, e) => InsertTextAtCursor("\r\n\r\n"), 92);
		Button btnNgatBai = CreateToolbarButton("+ Ngắt bài (|)", (s, e) => { InsertTextAtCursor("\r\n|\r\n"); rbDaDong.Checked = true; }, 98);

		Button btnClearText = new Button
		{
			Text = "Xóa trắng",
			Size = new Size(86, 26),
			FlatStyle = FlatStyle.Flat,
			Cursor = Cursors.Hand,
			Font = fontSegoe,
			BackColor = Color.FromArgb(254, 242, 242),
			ForeColor = Color.FromArgb(220, 38, 38),
			Margin = new Padding(2)
		};
		btnClearText.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
		btnClearText.FlatAppearance.BorderSize = 1;
		btnClearText.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
		btnClearText.Click += (s, e) =>
		{
			if (MessageBox.Show("Bạn có chắc muốn xóa trắng nội dung soạn thảo?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				txtNoiDung.Clear();
		};

		flpTags.Controls.Add(btnSpin);
		flpTags.Controls.Add(btnTagTime);
		flpTags.Controls.Add(btnTagRandom);
		flpTags.Controls.Add(btnDongTrong);
		flpTags.Controls.Add(btnNgatBai);
		flpTags.Controls.Add(btnClearText);

		// Format Options on the right of Row 2
		Panel plFormat = new Panel
		{
			Location = new Point(532, 44),
			Size = new Size(295, 30),
			BackColor = Color.Transparent
		};
		Label lblTuyChon = new Label
		{
			Text = "Định dạng:",
			Location = new Point(2, 6),
			AutoSize = true,
			Font = fontSegoeBold,
			ForeColor = Color.FromArgb(71, 85, 105)
		};
		rbDonDong.Text = "1 dòng/bài";
		rbDonDong.Location = new Point(78, 5);
		rbDonDong.AutoSize = true;
		rbDonDong.Cursor = Cursors.Hand;
		rbDonDong.Font = fontSegoe;

		rbDaDong.Text = "Nhiều dòng";
		rbDaDong.Location = new Point(172, 5);
		rbDaDong.AutoSize = true;
		rbDaDong.Cursor = Cursors.Hand;
		rbDaDong.Font = fontSegoe;
		rbDaDong.Checked = true;

		toolTip1.SetToolTip(rbDonDong, "Mỗi dòng tương ứng với 1 bài viết riêng biệt");
		toolTip1.SetToolTip(rbDaDong, "Bài viết có nhiều đoạn văn, phân tách các bài bằng dấu gạch đứng (|) trên một dòng riêng");

		plFormat.Controls.Add(lblTuyChon);
		plFormat.Controls.Add(rbDonDong);
		plFormat.Controls.Add(rbDaDong);

		pnlToolbar.Controls.Add(flpEmoji);
		pnlToolbar.Controls.Add(flpTags);
		pnlToolbar.Controls.Add(plFormat);

		// Editor Container
		pnlEditorContainer.Location = new Point(14, 134);
		pnlEditorContainer.Size = new Size(832, 446);
		pnlEditorContainer.BackColor = Color.White;
		pnlEditorContainer.Padding = new Padding(12, 10, 12, 10);
		pnlEditorContainer.Paint += (s, pe) =>
		{
			using (Pen p = new Pen(Color.FromArgb(203, 213, 225), 1))
			{
				pe.Graphics.DrawRectangle(p, 0, 0, pnlEditorContainer.Width - 1, pnlEditorContainer.Height - 1);
			}
		};

		txtNoiDung.Dock = DockStyle.Fill;
		txtNoiDung.BorderStyle = BorderStyle.None;
		txtNoiDung.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		txtNoiDung.ForeColor = Color.FromArgb(30, 41, 59);
		txtNoiDung.BackColor = Color.White;
		txtNoiDung.WordWrap = true;
		txtNoiDung.ScrollBars = RichTextBoxScrollBars.Vertical;
		txtNoiDung.TextChanged += (s, e) => UpdateStats();

		pnlEditorContainer.Controls.Add(txtNoiDung);

		// Footer Area
		pnlFooter.Location = new Point(14, 588);
		pnlFooter.Size = new Size(832, 42);
		pnlFooter.BackColor = Color.Transparent;

		lblStats.Location = new Point(4, 12);
		lblStats.AutoSize = true;
		lblStats.Font = new Font("Segoe UI", 9.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblStats.ForeColor = Color.FromArgb(100, 116, 139);
		lblStats.Text = "Dòng: 0  •  Ký tự: 0  •  Từ: 0  •  Số bài: 0";

		btnHuy.Location = new Point(605, 4);
		btnHuy.Size = new Size(88, 34);
		btnHuy.Text = "Đóng";
		btnHuy.Font = fontSegoe;
		btnHuy.BackColor = Color.White;
		btnHuy.ForeColor = Color.FromArgb(71, 85, 105);
		btnHuy.FlatStyle = FlatStyle.Flat;
		btnHuy.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
		btnHuy.FlatAppearance.BorderSize = 1;
		btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnHuy.Cursor = Cursors.Hand;
		btnHuy.Click += (s, e) => Close();

		btnXacNhan.Location = new Point(702, 4);
		btnXacNhan.Size = new Size(126, 34);
		btnXacNhan.Text = "Lưu nội dung";
		btnXacNhan.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnXacNhan.BackColor = Color.FromArgb(53, 120, 229);
		btnXacNhan.ForeColor = Color.White;
		btnXacNhan.FlatStyle = FlatStyle.Flat;
		btnXacNhan.FlatAppearance.BorderSize = 0;
		btnXacNhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
		btnXacNhan.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);
		btnXacNhan.Cursor = Cursors.Hand;
		btnXacNhan.Click += BtnXacNhan_Click;

		pnlFooter.Controls.Add(lblStats);
		pnlFooter.Controls.Add(btnHuy);
		pnlFooter.Controls.Add(btnXacNhan);

		// Outer form border
		Paint += (s, pe) =>
		{
			using (Pen p = new Pen(Color.FromArgb(203, 213, 225), 1))
			{
				pe.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
			}
		};

		Controls.Add(bunifuCards1);
		Controls.Add(pnlToolbar);
		Controls.Add(pnlEditorContainer);
		Controls.Add(pnlFooter);

		ResumeLayout(false);
	}

	private Button CreateToolbarButton(string text, EventHandler onClick, int width)
	{
		Button btn = new Button
		{
			Text = text,
			Size = new Size(width, 26),
			FlatStyle = FlatStyle.Flat,
			Cursor = Cursors.Hand,
			Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0),
			BackColor = Color.FromArgb(248, 250, 252),
			ForeColor = Color.FromArgb(51, 65, 85),
			Margin = new Padding(2)
		};
		btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		btn.FlatAppearance.BorderSize = 1;
		btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btn.Click += onClick;
		return btn;
	}

	private void InsertTextAtCursor(string text)
	{
		int selStart = txtNoiDung.SelectionStart;
		txtNoiDung.SelectedText = text;
		txtNoiDung.SelectionStart = selStart + text.Length;
		txtNoiDung.Focus();
	}

	private void UpdateStats()
	{
		string text = txtNoiDung.Text;
		int lines = string.IsNullOrEmpty(text) ? 0 : text.Split('\n').Length;
		int chars = text.Length;
		int words = string.IsNullOrWhiteSpace(text) ? 0 : Regex.Matches(text, @"\b\w+\b").Count;

		int postCount = 1;
		if (rbDaDong.Checked)
		{
			postCount = text.Split(new string[] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
			if (postCount == 0 && text.Length > 0) postCount = 1;
		}

		lblStats.Text = string.Format("Dòng: {0}  •  Ký tự: {1:N0}  •  Từ: {2:N0}  •  Số bài: {3}", lines, chars, words, postCount);
	}

	private void BtnXacNhan_Click(object sender, EventArgs e)
	{
		Content = txtNoiDung.Text.Trim();
		IsMultiPost = rbDaDong.Checked || Content.Contains("\n|\n");
		DialogResult = DialogResult.OK;
		Close();
	}
}
