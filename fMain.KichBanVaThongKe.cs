using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public partial class fMain
{
    private ToolStripMenuItem mnuKichBanRieng;
    private ToolStripMenuItem mnuThongKe;

    public void SetupKichBanVaThongKeMenu()
    {
        try
        {
            KichBanThongKeDB.InitDatabase();

            if (this.ctmsAcc == null) return;

            Image scriptIcon = LoadCustomMenuIcon("script.png", 16, 16, DrawScriptIconFallback);
            Image barChartIcon = LoadCustomMenuIcon("bar-chart.png", 16, 16, DrawBarChartIconFallback);

            // 1. Phân hệ "Kịch bản riêng"
            mnuKichBanRieng = new ToolStripMenuItem
            {
                Name = "mnuKichBanRieng",
                Text = "Kịch bản riêng",
                Font = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font,
                Image = scriptIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft
            };

            ToolStripMenuItem mnuGanKichBanRieng = new ToolStripMenuItem
            {
                Name = "mnuGanKichBanRieng",
                Text = "Gắn kịch bản riêng",
                Font = mnuKichBanRieng.Font,
                Image = scriptIcon,
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuGanKichBanRieng.Click += MnuGanKichBanRieng_Click;

            ToolStripMenuItem mnuChayKichBanRieng = new ToolStripMenuItem
            {
                Name = "mnuChayKichBanRieng",
                Text = "Chạy kịch bản riêng",
                Font = mnuKichBanRieng.Font,
                Image = scriptIcon,
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuChayKichBanRieng.Click += MnuChayKichBanRieng_Click;

            mnuKichBanRieng.DropDownItems.Add(mnuGanKichBanRieng);
            mnuKichBanRieng.DropDownItems.Add(mnuChayKichBanRieng);

            // 2. Phân hệ "Thống kê"
            mnuThongKe = new ToolStripMenuItem
            {
                Name = "mnuThongKe",
                Text = "Thống kê",
                Font = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font,
                Image = barChartIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft
            };

            ToolStripMenuItem mnuDashboard = new ToolStripMenuItem
            {
                Name = "mnuDashboard",
                Text = "Dashboard Tổng quan Thống kê",
                Font = mnuThongKe.Font,
                Image = barChartIcon,
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuDashboard.Click += (s, e) =>
            {
                try
                {
                    using (var f = new fDashboardThongKe())
                    {
                        f.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị Dashboard Thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            ToolStripMenuItem mnuLichSuDangBai = new ToolStripMenuItem
            {
                Name = "mnuLichSuDangBai",
                Text = "Lịch sử Đăng bài",
                Font = mnuThongKe.Font,
                Image = barChartIcon,
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuLichSuDangBai.Click += (s, e) =>
            {
                try
                {
                    string selectedUid = "";
                    if (this.F5325785 != null && this.F5325785.SelectedRows.Count > 0)
                    {
                        selectedUid = F6061E95(this.F5325785.SelectedRows[0].Index, "cUid");
                    }
                    using (var f = new fLichSuDangBai(selectedUid))
                    {
                        f.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị Lịch sử Đăng bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            ToolStripMenuItem mnuLichSuBinhLuan = new ToolStripMenuItem
            {
                Name = "mnuLichSuBinhLuan",
                Text = "Lịch sử Bình luận",
                Font = mnuThongKe.Font,
                Image = barChartIcon,
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuLichSuBinhLuan.Click += (s, e) =>
            {
                try
                {
                    using (var f = new fLichSuBinhLuan())
                    {
                        f.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị Lịch sử Bình luận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            mnuThongKe.DropDownItems.Add(mnuLichSuDangBai);
            mnuThongKe.DropDownItems.Add(mnuLichSuBinhLuan);

            // Gắn "Kịch bản riêng" vào menu con "Chức năng" để giữ root context menu gọn gàng
            if (this.C29582AA != null && !this.C29582AA.DropDownItems.Contains(mnuKichBanRieng))
            {
                this.C29582AA.DropDownItems.Insert(0, mnuKichBanRieng);
            }
            else if (!this.ctmsAcc.Items.Contains(mnuKichBanRieng))
            {
                this.ctmsAcc.Items.Add(mnuKichBanRieng);
            }

            // Gắn "Thống kê" vào menu con "Hệ thống"
            ToolStripMenuItem sysMenu = GetOrCreateHeThongMenu();
            if (sysMenu != null && !sysMenu.DropDownItems.Contains(mnuThongKe))
            {
                sysMenu.DropDownItems.Add(mnuThongKe);
            }

            // Thêm menu Thống kê lên thanh menu chính D39C9728 nếu có
            if (this.D39C9728 != null)
            {
                bool existsTop = false;
                foreach (ToolStripItem it in this.D39C9728.Items)
                {
                    if (it.Name == "mnuThongKeTop" || (it.Text != null && it.Text.Contains("Thống kê")))
                    {
                        existsTop = true;
                        break;
                    }
                }
                if (!existsTop)
                {
                    ToolStripMenuItem mnuThongKeTop = new ToolStripMenuItem
                    {
                        Name = "mnuThongKeTop",
                        Text = "Thống kê",
                        Font = this.D39C9728.Font,
                        Image = barChartIcon,
                        ImageScaling = ToolStripItemImageScaling.None
                    };

                    ToolStripMenuItem mnuLichSuDangBaiTop = new ToolStripMenuItem
                    {
                        Name = "mnuLichSuDangBaiTop",
                        Text = "Lịch sử Đăng bài",
                        Font = this.D39C9728.Font,
                        Image = barChartIcon,
                        ImageScaling = ToolStripItemImageScaling.None
                    };
                    mnuLichSuDangBaiTop.Click += (s, e) =>
                    {
                        try
                        {
                            string selectedUid = "";
                            if (this.F5325785 != null && this.F5325785.SelectedRows.Count > 0)
                            {
                                selectedUid = F6061E95(this.F5325785.SelectedRows[0].Index, "cUid");
                            }
                            using (var f = new fLichSuDangBai(selectedUid))
                            {
                                f.ShowDialog(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hiển thị Lịch sử Đăng bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    ToolStripMenuItem mnuLichSuBinhLuanTop = new ToolStripMenuItem
                    {
                        Name = "mnuLichSuBinhLuanTop",
                        Text = "Lịch sử Bình luận",
                        Font = this.D39C9728.Font,
                        Image = barChartIcon,
                        ImageScaling = ToolStripItemImageScaling.None
                    };
                    mnuLichSuBinhLuanTop.Click += (s, e) =>
                    {
                        try
                        {
                            using (var f = new fLichSuBinhLuan())
                            {
                                f.ShowDialog(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hiển thị Lịch sử Bình luận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    ToolStripMenuItem mnuDashboardTop = new ToolStripMenuItem
                    {
                        Name = "mnuDashboardTop",
                        Text = "Dashboard Tổng quan Thống kê",
                        Font = this.D39C9728.Font,
                        Image = barChartIcon,
                        ImageScaling = ToolStripItemImageScaling.None
                    };
                    mnuDashboardTop.Click += (s, e) =>
                    {
                        try
                        {
                            using (var f = new fDashboardThongKe())
                            {
                                f.ShowDialog(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hiển thị Dashboard Thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    mnuThongKeTop.DropDownItems.Add(mnuDashboardTop);
                    mnuThongKeTop.DropDownItems.Add(mnuLichSuDangBaiTop);
                    mnuThongKeTop.DropDownItems.Add(mnuLichSuBinhLuanTop);

                    int topInsertIndex = this.D39C9728.Items.Count > 1 ? this.D39C9728.Items.Count - 1 : this.D39C9728.Items.Count;
                    this.D39C9728.Items.Insert(topInsertIndex, mnuThongKeTop);
                }
            }

            // Đồng bộ kịch bản riêng vào DataGridView
            SyncCustomScriptsToGrid();
            this.F5325785.RowsAdded += (s, e) => SyncCustomScriptsToGrid();
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupKichBanVaThongKeMenu error: " + ex.Message); } catch { }
        }
    }

    public void SyncCustomScriptsToGrid()
    {
        try
        {
            if (this.F5325785.Columns.Contains("cKichBan"))
            {
                var scriptMap = KichBanThongKeDB.GetAllCustomScriptMap();
                if (scriptMap.Count > 0)
                {
                    this.F5325785.Columns["cKichBan"].Visible = true;
                    var scriptNames = KichBanThongKeDB.GetAllCustomScripts();
                    var nameLookup = new Dictionary<string, string>();
                    foreach (DataRow r in scriptNames.Rows)
                    {
                        string uid = r["uid"]?.ToString() ?? "";
                        string ten = r["ten_kichban"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(uid)) nameLookup[uid] = ten;
                    }

                    for (int i = 0; i < this.F5325785.Rows.Count; i++)
                    {
                        string uid = F6061E95(i, "cUid");
                        if (!string.IsNullOrEmpty(uid) && nameLookup.TryGetValue(uid, out string tenKb))
                        {
                            method_134(i, "cKichBan", tenKb, "kichban");
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void MnuGanKichBanRieng_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> selectedUids = new List<string>();
            List<int> selectedIndices = new List<int>();

            for (int i = 0; i < this.F5325785.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.F5325785.Rows[i].Cells["cChose"].Value))
                {
                    string uid = F6061E95(i, "cUid");
                    if (!string.IsNullOrEmpty(uid))
                    {
                        selectedUids.Add(uid);
                        selectedIndices.Add(i);
                    }
                }
            }

            // Nếu chưa tick checkbox nào thì kiểm tra dòng đang bôi đen
            if (selectedUids.Count == 0 && this.F5325785.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selRow in this.F5325785.SelectedRows)
                {
                    string uid = F6061E95(selRow.Index, "cUid");
                    if (!string.IsNullOrEmpty(uid))
                    {
                        selectedUids.Add(uid);
                        selectedIndices.Add(selRow.Index);
                        selRow.Cells["cChose"].Value = true;
                    }
                }
            }

            if (selectedUids.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một tài khoản để gắn kịch bản riêng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var f = new fGanKichBanRieng(selectedUids, selectedIndices, (rowIdxList, idKb, tenKb) =>
            {
                if (this.F5325785.Columns.Contains("cKichBan"))
                {
                    this.F5325785.Columns["cKichBan"].Visible = true;
                }

                foreach (int idx in rowIdxList)
                {
                    if (idx >= 0 && idx < this.F5325785.Rows.Count)
                    {
                        method_134(idx, "cKichBan", tenKb, "kichban");
                    }
                }
            }))
            {
                f.ShowDialog(this);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi mở Gắn kịch bản riêng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MnuChayKichBanRieng_Click(object sender, EventArgs e)
    {
        try
        {
            int checkedCount = 0;
            List<string> selectedUids = new List<string>();

            for (int i = 0; i < this.F5325785.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.F5325785.Rows[i].Cells["cChose"].Value))
                {
                    checkedCount++;
                    string uid = F6061E95(i, "cUid");
                    if (!string.IsNullOrEmpty(uid))
                    {
                        selectedUids.Add(uid);
                    }
                }
            }

            if (checkedCount == 0 && this.F5325785.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selRow in this.F5325785.SelectedRows)
                {
                    selRow.Cells["cChose"].Value = true;
                    string uid = F6061E95(selRow.Index, "cUid");
                    if (!string.IsNullOrEmpty(uid))
                    {
                        selectedUids.Add(uid);
                        checkedCount++;
                    }
                }
            }

            if (checkedCount == 0)
            {
                MessageBox.Show("Vui lòng tích chọn các tài khoản cần chạy kịch bản riêng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var scriptMap = KichBanThongKeDB.GetAllCustomScriptMap();
            List<string> uidsWithoutScript = new List<string>();
            HashSet<string> distinctScriptIds = new HashSet<string>();

            foreach (var uid in selectedUids)
            {
                if (scriptMap.TryGetValue(uid, out string idKb) && !string.IsNullOrEmpty(idKb))
                {
                    distinctScriptIds.Add(idKb);
                }
                else
                {
                    uidsWithoutScript.Add(uid);
                }
            }

            if (distinctScriptIds.Count == 0)
            {
                if (MessageBox.Show("Tất cả các tài khoản đang chọn chưa được gắn kịch bản riêng nào!\nBạn có muốn mở giao diện Gắn kịch bản riêng ngay bây giờ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MnuGanKichBanRieng_Click(null, null);
                }
                return;
            }

            if (uidsWithoutScript.Count > 0)
            {
                var promptResult = MessageBox.Show($"Có {uidsWithoutScript.Count} tài khoản chưa được gắn kịch bản riêng.\nBạn có muốn tiếp tục chạy cho {selectedUids.Count - uidsWithoutScript.Count} tài khoản ĐÃ ĐƯỢC GẮN kịch bản riêng không?", "Xác nhận chạy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (promptResult != DialogResult.Yes) return;

                // Bỏ tick các tài khoản chưa gắn kịch bản riêng
                for (int i = 0; i < this.F5325785.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.F5325785.Rows[i].Cells["cChose"].Value))
                    {
                        string uid = F6061E95(i, "cUid");
                        if (uidsWithoutScript.Contains(uid))
                        {
                            this.F5325785.Rows[i].Cells["cChose"].Value = false;
                        }
                    }
                }
            }

            // Nạp trước dữ liệu dictionaries cho toàn bộ các kịch bản riêng sắp chạy
            foreach (string scriptId in distinctScriptIds)
            {
                MergeCustomScriptDictionaries(scriptId);
            }

            // Khởi động chạy tương tác với cờ RunCustomScript = true
            GClass4 gClass = new GClass4();
            gClass.method_4("Interact", true);
            gClass.method_4("RunCustomScript", true);

            this.method_12(gClass);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi chạy kịch bản riêng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MergeCustomScriptDictionaries(string scriptId)
    {
        try
        {
            MergeDictHelper(ref dictionary_25, BE9D9A93(scriptId, "HDDanhGiaPage", "txtComment"));
            MergeDictHelper(ref DAB1D692, BE9D9A93(scriptId, "HDThamGiaNhomUid", "txtUid"));
            MergeDictHelper(ref DE0D9D90, BE9D9A93(scriptId, "HDKetBanVoiBanBeCuaUid", "txtUid"));
            MergeDictHelper(ref dictionary_0, BE9D9A93(scriptId, "HDKetBanTepUid", "txtUid"));
            MergeDictHelper(ref D68DE6AD, BE9D9A93(scriptId, "HDSpamBaiViet", "txtUid"));
            var dComment = BE9D9A93(scriptId, "HDSpamBaiViet", "txtComment");
            MergeDictHelper(ref E6810C8F, dComment);
            MergeDictHelper(ref EF9BBAAF, dComment != null ? dComment.smethod_6() : null);
            MergeDictHelper(ref CB89B620, BE9D9A93(scriptId, "HDBuffTinNhanProfile", "txtUid"));
            MergeDictHelper(ref dictionary_10, BE9D9A93(scriptId, "HDBuffLikeComment", "txtIdPost"));
            var dLikeCmt = BE9D9A93(scriptId, "HDBuffLikeComment", "txtComment");
            MergeDictHelper(ref B2978823, dLikeCmt);
            MergeDictHelper(ref dictionary_2, dLikeCmt != null ? dLikeCmt.smethod_6() : null);
            var dShare = BE9D9A93(scriptId, "HDBuffLikeComment", "txtContentShare", "cbbTuyChonNoiDungShare");
            MergeDictHelper(ref BB33F205, dShare);
            MergeDictHelper(ref B0873E9C, dShare != null ? dShare.smethod_6() : null);
            var dShareMess = BE9D9A93(scriptId, "HDBuffLikeComment", "txtContentShareMess", "cbbTuyChonNoiDungShareMess");
            MergeDictHelper(ref dictionary_3, dShareMess);
            MergeDictHelper(ref dictionary_4, dShareMess != null ? dShareMess.smethod_6() : null);
            var dMsg = BE9D9A93(scriptId, "HDBuffTinNhanProfile", "txtNoiDung");
            MergeDictHelper(ref dictionary_5, dMsg);
            MergeDictHelper(ref dictionary_6, dMsg != null ? dMsg.smethod_6() : null);
            var dStatus = BE9D9A93(scriptId, "HDDangStatus", "txtNoiDung");
            MergeDictHelper(ref dictionary_7, dStatus);
            MergeDictHelper(ref A83F1A36, dStatus != null ? dStatus.smethod_6() : null);
            var dStatus2 = BE9D9A93(scriptId, "HDDangStatusV2", "txtNoiDung");
            MergeDictHelper(ref dictionary_8, dStatus2);
            MergeDictHelper(ref dictionary_9, dStatus2 != null ? dStatus2.smethod_6() : null);
            MergeDictHelper(ref dictionary_11, BE9D9A93(scriptId, "HDPhanHoiBinhLuan", "txtIdPost"));
            MergeDictHelper(ref DAB96D09, BE9D9A93(scriptId, "HDBuffFollowLikePage", "txtUid"));
            MergeDictHelper(ref dictionary_12, BE9D9A93(scriptId, "HDLinkToInstagram", "txtBio"));
            MergeDictHelper(ref F53E0407, BE9D9A93(scriptId, "HDReviewPage", "txtUid"));
            MergeDictHelper(ref BB96210A, BE9D9A93(scriptId, "HDTaoPage", "txtPageName"));
            MergeDictHelper(ref dictionary_13, BE9D9A93(scriptId, "HDDangBai", "lstNhomTuNhap"));
            MergeDictHelper(ref dictionary_14, BE9D9A93(scriptId, "HDDangBai", "txtIdPost"));
            MergeDictHelper(ref dictionary_15, BE9D9A93(scriptId, "HDTuongTacReelChiDinh", "txtIdPost"));
            MergeDictHelper(ref dictionary_16, BE9D9A93(scriptId, "HDTuongTacReelChiDinh", "txtContentShare"));
            MergeDictHelper(ref dictionary_17, BE9D9A93(scriptId, "HDTuongTacReelChiDinh", "txtComment"));
            MergeDictHelper(ref dictionary_18, BE9D9A93(scriptId, "HDTuongTacLivestream", "txtComment"));
            MergeDictHelper(ref dictionary_19, BE9D9A93(scriptId, "HDDangBai", "txtNoiDung"));
            MergeDictHelper(ref DBB0FB3E, BE9D9A93(scriptId, "HDDangBai", "txtTTBVComment", "cbbTTBVTuyChonNoiDung"));
            MergeDictHelper(ref A91273B2, BE9D9A93(scriptId, "HDAddMail", "lstHotmail"));
            MergeDictHelper(ref A321A6B2, BE9D9A93(scriptId, "HDPhanHoiBinhLuan", "txtComment"));
            MergeDictHelper(ref dictionary_23, BE9D9A93(scriptId, "HDDangReel", "txtNoiDung"));
            MergeDictHelper(ref dictionary_24, BE9D9A93(scriptId, "HDShareBai", "txtNoiDung"));
            MergeDictHelper(ref dictionary_21, BE9D9A93(scriptId, "HDTuongTacReelNgauNhien", "txtComment"));
            var dTen = BE9D9A93(scriptId, "HDDoiTen", "lstHoTen");
            MergeDictHelper(ref dictionary_26, dTen);
            MergeDictHelper(ref dictionary_27, dTen != null ? dTen.smethod_6() : null);
        }
        catch { }
    }

    private void MergeDictHelper(ref Dictionary<string, List<string>> target, Dictionary<string, List<string>> source)
    {
        if (source == null) return;
        if (target == null) target = new Dictionary<string, List<string>>();
        lock (target)
        {
            foreach (var kvp in source)
            {
                if (!target.ContainsKey(kvp.Key))
                {
                    target[kvp.Key] = new List<string>(kvp.Value);
                }
            }
        }
    }

    private static Image LoadCustomMenuIcon(string fileName, int width, int height, Func<int, int, Image> fallbackGenerator)
    {
        try
        {
            string baseDir = !string.IsNullOrEmpty(Base.DE249839) ? Base.DE249839 : AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');
            string[] checkPaths = new[]
            {
                Path.Combine(baseDir, "images", fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", fileName),
                Path.Combine(Application.StartupPath, "images", fileName),
                Path.Combine(baseDir, "..", "..", "images", fileName),
                Path.Combine("images", fileName),
                @"D:\MaxCare_v25.05.08\images\" + fileName
            };

            foreach (string p in checkPaths)
            {
                if (File.Exists(p))
                {
                    byte[] bytes = File.ReadAllBytes(p);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image orig = Image.FromStream(ms))
                    {
                        if (orig.Width == width && orig.Height == height)
                        {
                            return new Bitmap(orig);
                        }
                        Bitmap scaled = new Bitmap(width, height);
                        using (Graphics g = Graphics.FromImage(scaled))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.DrawImage(orig, 0, 0, width, height);
                        }
                        return scaled;
                    }
                }
            }
        }
        catch { }

        if (fallbackGenerator != null)
        {
            try { return fallbackGenerator(width, height); } catch { }
        }

        return null;
    }

    private static Image DrawScriptIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(Color.FromArgb(99, 102, 241)))
            {
                g.FillRectangle(b, 2, 2, width - 4, height - 4);
            }
            using (Pen p = new Pen(Color.White, 1.5f))
            {
                g.DrawLine(p, 5, 5, width - 5, 5);
                g.DrawLine(p, 5, 9, width - 5, 9);
                g.DrawLine(p, 5, 13, width - 8, 13);
            }
        }
        return bmp;
    }

    private static Image DrawBarChartIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b1 = new SolidBrush(Color.FromArgb(16, 185, 129)))
            using (SolidBrush b2 = new SolidBrush(Color.FromArgb(59, 130, 246)))
            using (SolidBrush b3 = new SolidBrush(Color.FromArgb(245, 158, 11)))
            {
                g.FillRectangle(b1, 2, 10, 3, height - 12);
                g.FillRectangle(b2, 7, 5, 3, height - 7);
                g.FillRectangle(b3, 12, 2, 3, height - 4);
            }
        }
        return bmp;
    }
}
