using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fActive : Form
{
    [CompilerGenerated]
    private sealed class Class110
    {
        internal fActive fActive_0;

        internal string BE2CEB22;

        internal string E1199A25;

        internal MethodInvoker methodInvoker_0;

        internal MethodInvoker methodInvoker_1;

        internal MethodInvoker AD3DDB3E;

        internal MethodInvoker methodInvoker_2;

        internal MethodInvoker methodInvoker_3;

        internal MethodInvoker CCBC6F2D;

        internal MethodInvoker methodInvoker_4;

        internal void E1B7A109()
        {
            fActive_0.btnLogin.Invoke((MethodInvoker)delegate
            {
                fActive_0.btnLogin.Enabled = false;
            });
            fActive_0.lblStatus.Invoke((MethodInvoker)delegate
            {
                fActive_0.lblStatus.Text = Language.GetValue("Đang kiểm tra đăng nhập...");
            });
            try
            {
                Class111 CS_0024_003C_003E8__locals0 = new Class111
                {
                    class110_0 = this,
                    string_0 = Commom.checkLicense2(BE2CEB22, E1199A25)
                };
                if (CS_0024_003C_003E8__locals0.string_0.StartsWith("0|"))
                {
                    fActive_0.lblStatus.Invoke((MethodInvoker)delegate
                    {
                        CS_0024_003C_003E8__locals0.class110_0.fActive_0.lblStatus.Text = Language.GetValue(CS_0024_003C_003E8__locals0.string_0.Substring(2));
                    });
                    fActive_0.btnLogin.Invoke((MethodInvoker)delegate
                    {
                        fActive_0.btnLogin.Enabled = true;
                    });
                    return;
                }
                CS_0024_003C_003E8__locals0.string_0 = CS_0024_003C_003E8__locals0.string_0.Substring(2);
                if (CS_0024_003C_003E8__locals0.string_0.Split('|').Length < 3)
                {
                    fActive_0.lblStatus.Invoke((MethodInvoker)delegate
                    {
                        fActive_0.lblStatus.Text = Language.GetValue("Không thể kích hoạt tài khoản của bạn, vui lòng thử lại!!!");
                    });
                    fActive_0.btnLogin.Invoke((MethodInvoker)delegate
                    {
                        fActive_0.btnLogin.Enabled = true;
                    });
                    return;
                }
                C5034B95.smethod_0("settingLogin").method_4("UserName", BE2CEB22);
                C5034B95.smethod_0("settingLogin").method_4("PassWord", E1199A25);
                C5034B95.smethod_1("settingLogin");
                fActive_0.lblStatus.Invoke((MethodInvoker)delegate
                {
                    fActive_0.lblStatus.Text = Language.GetValue("Đăng nhập thành công!");
                });
                Commom.smethod_83();
                return;
            }
            catch (Exception ex)
            {
                MsBoxHelper.Show("Active error:\n" + ex.ToString(), 3);
                Commom.smethod_57(null, ex, "Active error");
                MsBoxHelper.Show("Lỗi không xác định!!!", 2);
            }
            fActive_0.btnLogin.Invoke((MethodInvoker)delegate
            {
                fActive_0.btnLogin.Enabled = true;
            });
        }

        internal void method_0()
        {
            fActive_0.btnLogin.Enabled = false;
        }

        internal void method_1()
        {
            fActive_0.lblStatus.Text = Language.GetValue("Đang kiểm tra đăng nhập...");
        }

        internal void method_2()
        {
            fActive_0.btnLogin.Enabled = true;
        }

        internal void FBA1C833()
        {
            fActive_0.lblStatus.Text = Language.GetValue("Không thể kích hoạt tài khoản của bạn, vui lòng thử lại!!!");
        }

        internal void E21BF62B()
        {
            fActive_0.btnLogin.Enabled = true;
        }

        internal void method_3()
        {
            fActive_0.lblStatus.Text = Language.GetValue("Đăng nhập thành công!");
        }

        internal void C886E7A1()
        {
            fActive_0.btnLogin.Enabled = true;
        }
    }

    [CompilerGenerated]
    private sealed class Class111
    {
        internal string string_0;

        internal Class110 class110_0;

        internal void BC0CFB33()
        {
            class110_0.fActive_0.lblStatus.Text = Language.GetValue(string_0.Substring(2));
        }
    }

    internal string B9B53AA2 = "https://lushmkt.com";

    internal Bitmap bitmap_0 = Class155.Bitmap_179;

    internal Bitmap bitmap_1 = Class155.Bitmap_176;

    internal IContainer icontainer_0 = null;

    internal BunifuCards D9958388;

    internal Panel pnlHeader;

    internal PictureBox E70B4723;

    internal BunifuCustomLabel A2064C80;

    internal BunifuMetroTextbox CA9A050D;

    internal BunifuCustomLabel bunifuCustomLabel2;

    internal BunifuCustomLabel B2AC5B9C;

    internal BunifuMetroTextbox txbPassword;

    internal Button btnLogin;

    internal Label lblStatus;

    internal LinkLabel linkLabel1;

    internal Label E5B65610;

    internal Button btnMinimize;

    internal BunifuDragControl bunifuDragControl_0;

    internal PictureBox EA1494B1;

    internal BunifuCustomLabel lblWebsiteDetail;

    internal BunifuCustomLabel lblWebsite;

    internal BunifuCustomLabel D285B206;

    internal BunifuCustomLabel lblKey;

    internal BunifuCustomLabel bunifuCustomLabel7;

    internal BunifuDragControl EB94822F;

    internal BunifuCustomLabel lblHotlineDetail;

    internal BunifuCustomLabel E017B0BF;

    internal ComboBox F60BFE8A;

    internal LinkLabel DC300F16;

    internal Label label2;

    internal PictureBox A9310711;

    public fActive(string string_0)
    {
        InitializeComponent();
        Language.CD21F0A9(this);
        lblStatus.Text = Language.GetValue(string_0);
        lblKey.Text = Commom.smethod_12();
        Commom.smethod_24(F60BFE8A, Base.smethod_1());
        A9310711.Image = ((Base.smethod_2() != "VN") ? bitmap_0 : bitmap_1);
        A9310711.Visible = Base.AE177D31;
        base.Icon = Class155.D596C6A5;
        if (Base.bool_8)
        {
            B9B53AA2 = "https://lushmkt.com";
            E017B0BF.Visible = false;
            F60BFE8A.Visible = false;
            base.Height = 279;
            lblWebsiteDetail.Text = "https://lushmkt.com";
            D285B206.Text = "Hotline:";
            lblHotlineDetail.Text = "0359.261.551";
            Text = "LushCare Facebook";
            A2064C80.Text = A2064C80.Text.Replace("LushCare", Text);
            base.Icon = Class155.D596C6A5;
        }
        A2064C80.Text = A2064C80.Text.Split('-')[0] + "- " + Language.GetValue(A2064C80.Text.Split('-')[1].Trim());
    }

    private void E788D48C(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string BE2CEB22 = CA9A050D.Text.Trim();
        string E1199A25 = txbPassword.Text.Trim();
        if (BE2CEB22 == "" || E1199A25 == "")
        {
            MsBoxHelper.Show("Vui lòng điền đầy đủ thông tin!", 3);
            return;
        }
        if (!BE2CEB22.Contains("@"))
        {
            BE2CEB22 += "@gmail.com";
        }
        C5034B95.smethod_0("settingLogin").method_4("Server", F60BFE8A.SelectedValue);
        C5034B95.smethod_1("settingLogin");
        string string_0;
        new Thread((ThreadStart)delegate
        {
            btnLogin.Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = false;
            });
            lblStatus.Invoke((MethodInvoker)delegate
            {
                lblStatus.Text = Language.GetValue("Đang kiểm tra đăng nhập...");
            });
            try
            {
                string_0 = Commom.checkLicense2(BE2CEB22, E1199A25);
                if (string_0.StartsWith("0|"))
                {
                    lblStatus.Invoke((MethodInvoker)delegate
                    {
                        lblStatus.Text = Language.GetValue(string_0.Substring(2));
                    });
                    btnLogin.Invoke((MethodInvoker)delegate
                    {
                        btnLogin.Enabled = true;
                    });
                }
                else
                {
                    string_0 = string_0.Substring(2);
                    if (string_0.Split('|').Length < 3)
                    {
                        lblStatus.Invoke((MethodInvoker)delegate
                        {
                            lblStatus.Text = Language.GetValue("Không thể kích hoạt tài khoản của bạn, vui lòng thử lại!!!");
                        });
                        btnLogin.Invoke((MethodInvoker)delegate
                        {
                            btnLogin.Enabled = true;
                        });
                    }
                    else
                    {
                        C5034B95.smethod_0("settingLogin").method_4("UserName", BE2CEB22);
                        C5034B95.smethod_0("settingLogin").method_4("PassWord", E1199A25);
                        C5034B95.smethod_1("settingLogin");
                        lblStatus.Invoke((MethodInvoker)delegate
                        {
                            lblStatus.Text = Language.GetValue("Đăng nhập thành công!");
                        });
                        Commom.smethod_83();
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MsBoxHelper.Show("Active error:\n" + ex.ToString(), 3);
                Commom.smethod_57(null, ex, "Active error");
                MsBoxHelper.Show("Lỗi không xác định!!!", 2);
            }
            btnLogin.Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = true;
            });
        }).Start();
    }

    private void fActive_FormClosing(object sender, FormClosingEventArgs e)
    {
        Environment.Exit(0);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Commom.CE2E5B3B(B9B53AA2);
    }

    private void EA1494B1_Click(object sender, EventArgs e)
    {
        Commom.SetTextToClipboard(lblKey.Text);
        MsBoxHelper.Show("Đã copy mã thiết bị!");
    }

    private void txbPassword_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            btnLogin_Click(null, null);
        }
    }

    private void EA37A18D(object sender, EventArgs e)
    {
        if (!E017B0BF.Visible)
        {
            E017B0BF.Visible = true;
            F60BFE8A.Visible = true;
            base.Height = 320;
        }
        else
        {
            E017B0BF.Visible = false;
            F60BFE8A.Visible = false;
            base.Height = 275;
        }
    }

    private void B22CF808(object sender, EventArgs e)
    {
        F60BFE8A.SelectedValue = Base.smethod_0();
    }

    private void A60F1082(object sender, LinkLabelLinkClickedEventArgs e)
    {
        string text = "https://bit.ly/DieukhoanvaChinhsach";
        try
        {
            Process.Start("chrome.exe", text);
        }
        catch
        {
            Process.Start(text);
        }
    }

    private void C7B9CA8C(object sender, EventArgs e)
    {
        if (A9310711.Image == bitmap_0)
        {
            A9310711.Image = bitmap_1;
            Base.C601B080();
            MsBoxHelper.Show("Vui lòng mở lại phần mềm để cập nhật ngôn ngữ!");
        }
        else
        {
            A9310711.Image = bitmap_0;
            Base.C601B080("EN");
        }
        Base.smethod_2();
        Language.CD21F0A9(this);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fActive));
        D9958388 = new Bunifu.Framework.UI.BunifuCards();
        pnlHeader = new System.Windows.Forms.Panel();
        A9310711 = new System.Windows.Forms.PictureBox();
        btnMinimize = new System.Windows.Forms.Button();
        E70B4723 = new System.Windows.Forms.PictureBox();
        A2064C80 = new Bunifu.Framework.UI.BunifuCustomLabel();
        CA9A050D = new Bunifu.Framework.UI.BunifuMetroTextbox();
        bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
        B2AC5B9C = new Bunifu.Framework.UI.BunifuCustomLabel();
        txbPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
        btnLogin = new System.Windows.Forms.Button();
        lblStatus = new System.Windows.Forms.Label();
        linkLabel1 = new System.Windows.Forms.LinkLabel();
        E5B65610 = new System.Windows.Forms.Label();
        bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
        EA1494B1 = new System.Windows.Forms.PictureBox();
        lblWebsiteDetail = new Bunifu.Framework.UI.BunifuCustomLabel();
        lblWebsite = new Bunifu.Framework.UI.BunifuCustomLabel();
        D285B206 = new Bunifu.Framework.UI.BunifuCustomLabel();
        lblKey = new Bunifu.Framework.UI.BunifuCustomLabel();
        bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
        EB94822F = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
        lblHotlineDetail = new Bunifu.Framework.UI.BunifuCustomLabel();
        E017B0BF = new Bunifu.Framework.UI.BunifuCustomLabel();
        F60BFE8A = new System.Windows.Forms.ComboBox();
        DC300F16 = new System.Windows.Forms.LinkLabel();
        label2 = new System.Windows.Forms.Label();
        D9958388.SuspendLayout();
        pnlHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)A9310711).BeginInit();
        ((System.ComponentModel.ISupportInitialize)E70B4723).BeginInit();
        ((System.ComponentModel.ISupportInitialize)EA1494B1).BeginInit();
        SuspendLayout();
        D9958388.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        D9958388.BackColor = System.Drawing.Color.White;
        D9958388.BorderRadius = 0;
        D9958388.BottomSahddow = true;
        D9958388.color = System.Drawing.Color.SaddleBrown;
        D9958388.Controls.Add(pnlHeader);
        D9958388.LeftSahddow = false;
        D9958388.Location = new System.Drawing.Point(0, 0);
        D9958388.Name = "bunifuCards1";
        D9958388.RightSahddow = true;
        D9958388.ShadowDepth = 20;
        D9958388.Size = new System.Drawing.Size(395, 38);
        D9958388.TabIndex = 11;
        pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlHeader.BackColor = System.Drawing.Color.White;
        pnlHeader.Controls.Add(A9310711);
        pnlHeader.Controls.Add(btnMinimize);
        pnlHeader.Controls.Add(E70B4723);
        pnlHeader.Controls.Add(A2064C80);
        pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
        pnlHeader.Location = new System.Drawing.Point(0, 5);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new System.Drawing.Size(393, 32);
        pnlHeader.TabIndex = 9;
        A9310711.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        A9310711.Cursor = System.Windows.Forms.Cursors.Hand;
        A9310711.Image = Class155.Bitmap_176;
        A9310711.Location = new System.Drawing.Point(330, 3);
        A9310711.Name = "picLanguage";
        A9310711.Size = new System.Drawing.Size(25, 25);
        A9310711.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        A9310711.TabIndex = 15;
        A9310711.TabStop = false;
        A9310711.Click += new System.EventHandler(C7B9CA8C);
        btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
        btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
        btnMinimize.FlatAppearance.BorderSize = 0;
        btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        btnMinimize.ForeColor = System.Drawing.Color.White;
        btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
        btnMinimize.Location = new System.Drawing.Point(361, 0);
        btnMinimize.Name = "btnMinimize";
        btnMinimize.Size = new System.Drawing.Size(32, 32);
        btnMinimize.TabIndex = 13;
        btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnMinimize.UseVisualStyleBackColor = true;
        btnMinimize.Click += new System.EventHandler(E788D48C);
        E70B4723.Image = Class155.DD225F0D;
        E70B4723.Location = new System.Drawing.Point(6, 2);
        E70B4723.Name = "pictureBox1";
        E70B4723.Size = new System.Drawing.Size(34, 27);
        E70B4723.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        E70B4723.TabIndex = 12;
        E70B4723.TabStop = false;
        E70B4723.Click += new System.EventHandler(EA37A18D);
        A2064C80.AutoSize = true;
        A2064C80.BackColor = System.Drawing.Color.Transparent;
        A2064C80.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        A2064C80.ForeColor = System.Drawing.Color.Black;
        A2064C80.Location = new System.Drawing.Point(42, 7);
        A2064C80.Name = "bunifuCustomLabel1";
        A2064C80.Size = new System.Drawing.Size(221, 16);
        A2064C80.TabIndex = 7;
        A2064C80.Text = "LushCare - Kích hoạt bản quyền";
        CA9A050D.Anchor = System.Windows.Forms.AnchorStyles.Top;
        CA9A050D.BorderColorFocused = System.Drawing.Color.FromArgb(192, 64, 0);
        CA9A050D.BorderColorIdle = System.Drawing.Color.FromArgb(64, 64, 64);
        CA9A050D.BorderColorMouseHover = System.Drawing.Color.FromArgb(192, 64, 0);
        CA9A050D.BorderThickness = 3;
        CA9A050D.Cursor = System.Windows.Forms.Cursors.IBeam;
        CA9A050D.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        CA9A050D.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        CA9A050D.isPassword = false;
        CA9A050D.Location = new System.Drawing.Point(117, 46);
        CA9A050D.Margin = new System.Windows.Forms.Padding(4);
        CA9A050D.Name = "txbUserName";
        CA9A050D.Size = new System.Drawing.Size(228, 29);
        CA9A050D.TabIndex = 0;
        CA9A050D.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        CA9A050D.KeyDown += new System.Windows.Forms.KeyEventHandler(txbPassword_KeyDown);
        bunifuCustomLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
        bunifuCustomLabel2.AutoSize = true;
        bunifuCustomLabel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        bunifuCustomLabel2.Location = new System.Drawing.Point(37, 52);
        bunifuCustomLabel2.Name = "bunifuCustomLabel2";
        bunifuCustomLabel2.Size = new System.Drawing.Size(44, 16);
        bunifuCustomLabel2.TabIndex = 13;
        bunifuCustomLabel2.Text = "Email:";
        B2AC5B9C.Anchor = System.Windows.Forms.AnchorStyles.Top;
        B2AC5B9C.AutoSize = true;
        B2AC5B9C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        B2AC5B9C.Location = new System.Drawing.Point(37, 88);
        B2AC5B9C.Name = "bunifuCustomLabel3";
        B2AC5B9C.Size = new System.Drawing.Size(72, 16);
        B2AC5B9C.TabIndex = 15;
        B2AC5B9C.Text = "Mật khẩu:";
        txbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
        txbPassword.BorderColorFocused = System.Drawing.Color.FromArgb(192, 64, 0);
        txbPassword.BorderColorIdle = System.Drawing.Color.FromArgb(64, 64, 64);
        txbPassword.BorderColorMouseHover = System.Drawing.Color.FromArgb(192, 64, 0);
        txbPassword.BorderThickness = 3;
        txbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        txbPassword.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        txbPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        txbPassword.isPassword = true;
        txbPassword.Location = new System.Drawing.Point(117, 83);
        txbPassword.Margin = new System.Windows.Forms.Padding(4);
        txbPassword.Name = "txbPassword";
        txbPassword.Size = new System.Drawing.Size(228, 29);
        txbPassword.TabIndex = 1;
        txbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(txbPassword_KeyDown);
        btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        btnLogin.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
        btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        btnLogin.ForeColor = System.Drawing.Color.White;
        btnLogin.Location = new System.Drawing.Point(149, 178);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new System.Drawing.Size(115, 29);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Đăng nhập";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += new System.EventHandler(btnLogin_Click);
        lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        lblStatus.ForeColor = System.Drawing.Color.Red;
        lblStatus.Location = new System.Drawing.Point(10, 157);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(371, 18);
        lblStatus.TabIndex = 28;
        lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        linkLabel1.AutoSize = true;
        linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
        linkLabel1.LinkColor = System.Drawing.Color.FromArgb(53, 120, 229);
        linkLabel1.Location = new System.Drawing.Point(285, 217);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new System.Drawing.Size(27, 16);
        linkLabel1.TabIndex = 3;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "đây";
        linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
        E5B65610.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        E5B65610.AutoSize = true;
        E5B65610.Location = new System.Drawing.Point(100, 217);
        E5B65610.Name = "label1";
        E5B65610.Size = new System.Drawing.Size(187, 16);
        E5B65610.TabIndex = 30;
        E5B65610.Text = "Đăng ký tài khoản mới bấm vào";
        E5B65610.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        bunifuDragControl_0.Fixed = true;
        bunifuDragControl_0.Horizontal = true;
        bunifuDragControl_0.TargetControl = pnlHeader;
        bunifuDragControl_0.Vertical = true;
        EA1494B1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        EA1494B1.Cursor = System.Windows.Forms.Cursors.Hand;
        EA1494B1.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
        EA1494B1.Location = new System.Drawing.Point(357, 281);
        EA1494B1.Name = "pictureBox2";
        EA1494B1.Size = new System.Drawing.Size(20, 20);
        EA1494B1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        EA1494B1.TabIndex = 42;
        EA1494B1.TabStop = false;
        EA1494B1.Click += new System.EventHandler(EA1494B1_Click);
        lblWebsiteDetail.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblWebsiteDetail.AutoSize = true;
        lblWebsiteDetail.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        lblWebsiteDetail.ForeColor = System.Drawing.Color.Gray;
        lblWebsiteDetail.Location = new System.Drawing.Point(94, 240);
        lblWebsiteDetail.Name = "lblWebsiteDetail";
        lblWebsiteDetail.Size = new System.Drawing.Size(140, 13);
        lblWebsiteDetail.TabIndex = 40;
        lblWebsiteDetail.Text = "https://lushmkt.com";
        lblWebsite.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblWebsite.AutoSize = true;
        lblWebsite.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        lblWebsite.Location = new System.Drawing.Point(22, 240);
        lblWebsite.Name = "lblWebsite";
        lblWebsite.Size = new System.Drawing.Size(56, 13);
        lblWebsite.TabIndex = 38;
        lblWebsite.Text = "Website:";
        D285B206.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        D285B206.AutoSize = true;
        D285B206.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        D285B206.Location = new System.Drawing.Point(22, 262);
        D285B206.Name = "lblHotline";
        D285B206.Size = new System.Drawing.Size(53, 13);
        D285B206.TabIndex = 39;
        D285B206.Text = "Hotline: ";
        lblKey.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblKey.AutoSize = true;
        lblKey.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        lblKey.ForeColor = System.Drawing.Color.Gray;
        lblKey.Location = new System.Drawing.Point(94, 284);
        lblKey.Name = "lblKey";
        lblKey.Size = new System.Drawing.Size(231, 13);
        lblKey.TabIndex = 37;
        lblKey.Text = "********************************";
        bunifuCustomLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        bunifuCustomLabel7.AutoSize = true;
        bunifuCustomLabel7.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        bunifuCustomLabel7.Location = new System.Drawing.Point(22, 284);
        bunifuCustomLabel7.Name = "bunifuCustomLabel7";
        bunifuCustomLabel7.Size = new System.Drawing.Size(70, 13);
        bunifuCustomLabel7.TabIndex = 36;
        bunifuCustomLabel7.Text = "Mã thiết bị:";
        EB94822F.Fixed = true;
        EB94822F.Horizontal = true;
        EB94822F.TargetControl = A2064C80;
        EB94822F.Vertical = true;
        lblHotlineDetail.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblHotlineDetail.AutoSize = true;
        lblHotlineDetail.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        lblHotlineDetail.ForeColor = System.Drawing.Color.Gray;
        lblHotlineDetail.Location = new System.Drawing.Point(94, 262);
        lblHotlineDetail.Name = "lblHotlineDetail";
        lblHotlineDetail.Size = new System.Drawing.Size(257, 13);
        lblHotlineDetail.TabIndex = 41;
        lblHotlineDetail.Text = "0359.261.551";
        E017B0BF.Anchor = System.Windows.Forms.AnchorStyles.Top;
        E017B0BF.AutoSize = true;
        E017B0BF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        E017B0BF.Location = new System.Drawing.Point(37, 127);
        E017B0BF.Name = "lblServer";
        E017B0BF.Size = new System.Drawing.Size(56, 16);
        E017B0BF.TabIndex = 43;
        E017B0BF.Text = "Server:";
        F60BFE8A.Cursor = System.Windows.Forms.Cursors.Hand;
        F60BFE8A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        F60BFE8A.FormattingEnabled = true;
        F60BFE8A.ItemHeight = 16;
        F60BFE8A.Location = new System.Drawing.Point(119, 122);
        F60BFE8A.Name = "cbbServer";
        F60BFE8A.Size = new System.Drawing.Size(226, 24);
        F60BFE8A.TabIndex = 46;
        DC300F16.Cursor = System.Windows.Forms.Cursors.Hand;
        DC300F16.Location = new System.Drawing.Point(153, 419);
        DC300F16.Name = "linkLabel2";
        DC300F16.Size = new System.Drawing.Size(109, 16);
        DC300F16.TabIndex = 50;
        DC300F16.TabStop = true;
        DC300F16.Text = "(Xem điều khoản)";
        DC300F16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        DC300F16.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(A60F1082);
        label2.ForeColor = System.Drawing.Color.Red;
        label2.Location = new System.Drawing.Point(0, 400);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(393, 16);
        label2.TabIndex = 49;
        label2.Text = "Khi đăng nhập, bạn đã đồng ý với điều khoản của chúng tôi!";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        base.ClientSize = new System.Drawing.Size(393, 311);
        base.Controls.Add(DC300F16);
        base.Controls.Add(label2);
        base.Controls.Add(E017B0BF);
        base.Controls.Add(EA1494B1);
        base.Controls.Add(lblWebsiteDetail);
        base.Controls.Add(lblHotlineDetail);
        base.Controls.Add(lblWebsite);
        base.Controls.Add(D285B206);
        base.Controls.Add(lblKey);
        base.Controls.Add(bunifuCustomLabel7);
        base.Controls.Add(linkLabel1);
        base.Controls.Add(E5B65610);
        base.Controls.Add(lblStatus);
        base.Controls.Add(btnLogin);
        base.Controls.Add(B2AC5B9C);
        base.Controls.Add(txbPassword);
        base.Controls.Add(bunifuCustomLabel2);
        base.Controls.Add(CA9A050D);
        base.Controls.Add(D9958388);
        base.Controls.Add(F60BFE8A);
        Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "fActive";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "LushCare";
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fActive_FormClosing);
        base.Load += new System.EventHandler(B22CF808);
        D9958388.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)A9310711).EndInit();
        ((System.ComponentModel.ISupportInitialize)E70B4723).EndInit();
        ((System.ComponentModel.ISupportInitialize)EA1494B1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
