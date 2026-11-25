using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

public sealed class fCauHinhJev : Form
{
    private readonly TextBox txtApiKey;
    private readonly Label lblStatus;
    private readonly Button btnSave;
    private readonly Button btnTest;
    private readonly Button btnDelete;

    public fCauHinhJev()
    {
        Text = "Cấu hình Jev AI";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(620, 245);
        Font = new Font("Tahoma", 9.75f);

        var title = new Label
        {
            Text = "TypeSafe Jev — Decision AI",
            Font = new Font("Tahoma", 13f, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(22, 20)
        };
        var note = new Label
        {
            Text = "Key được mã hóa bằng Windows DPAPI và chỉ Windows user hiện tại giải mã được.\r\nKhông gửi API key qua chat, email hoặc commit vào Git.",
            AutoSize = true,
            ForeColor = Color.DimGray,
            Location = new Point(24, 55)
        };
        var keyLabel = new Label { Text = "API key mới:", AutoSize = true, Location = new Point(24, 105) };
        txtApiKey = new TextBox
        {
            Location = new Point(125, 101),
            Size = new Size(465, 24),
            UseSystemPasswordChar = true
        };
        lblStatus = new Label { AutoSize = true, Location = new Point(24, 142) };
        btnSave = new Button { Text = "Lưu an toàn", Location = new Point(247, 185), Size = new Size(108, 34) };
        btnTest = new Button { Text = "Kiểm tra", Location = new Point(365, 185), Size = new Size(108, 34) };
        btnDelete = new Button { Text = "Xóa key", Location = new Point(483, 185), Size = new Size(108, 34) };

        btnSave.Click += SaveClick;
        btnTest.Click += TestClick;
        btnDelete.Click += DeleteClick;
        Controls.AddRange(new Control[] { title, note, keyLabel, txtApiKey, lblStatus, btnSave, btnTest, btnDelete });
        RefreshStatus();
    }

    private void RefreshStatus(string message = null, bool error = false)
    {
        lblStatus.Text = message ?? (JevSecureConfiguration.HasApiKey
            ? "✓ Đã lưu key mã hóa. Có thể kiểm tra kết nối."
            : "Chưa lưu API key Jev.");
        lblStatus.ForeColor = error ? Color.Firebrick : (JevSecureConfiguration.HasApiKey ? Color.ForestGreen : Color.DarkOrange);
    }

    private void SaveClick(object sender, EventArgs e)
    {
        try
        {
            string key = txtApiKey.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                RefreshStatus("Hãy dán API key mới vào ô trên.", true);
                return;
            }
            JevSecureConfiguration.SaveApiKey(key);
            txtApiKey.Clear();
            RefreshStatus("✓ Đã mã hóa và lưu key bằng Windows DPAPI.");
        }
        catch (Exception ex)
        {
            RefreshStatus("Không thể lưu key: " + ex.Message, true);
        }
    }

    private async void TestClick(object sender, EventArgs e)
    {
        if (!JevSecureConfiguration.HasApiKey)
        {
            RefreshStatus("Chưa có key. Hãy dán và bấm Lưu an toàn trước.", true);
            return;
        }
        ToggleButtons(false);
        RefreshStatus("Đang kiểm tra kết nối TypeSafe Jev...");
        try
        {
            JevNoulResult result = await Task.Run(() => new JevClient().TestConnection());
            RefreshStatus($"✓ Kết nối thành công — xác suất {result.Probability:P0}, input {result.InputTokens} token.");
        }
        catch (Exception ex)
        {
            RefreshStatus("Kiểm tra thất bại: " + FriendlyError(ex.Message), true);
        }
        finally
        {
            ToggleButtons(true);
        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        if (MessageBox.Show("Xóa API key Jev đã lưu?", "LushCare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        JevSecureConfiguration.DeleteApiKey();
        txtApiKey.Clear();
        RefreshStatus("Đã xóa API key Jev khỏi máy.");
    }

    private void ToggleButtons(bool enabled)
    {
        btnSave.Enabled = enabled;
        btnTest.Enabled = enabled;
        btnDelete.Enabled = enabled;
    }

    private static string FriendlyError(string message)
    {
        if (message.IndexOf("401", StringComparison.OrdinalIgnoreCase) >= 0) return "API key không hợp lệ hoặc đã bị thu hồi.";
        if (message.IndexOf("402", StringComparison.OrdinalIgnoreCase) >= 0) return "Tài khoản TypeSafe không đủ credit.";
        if (message.IndexOf("429", StringComparison.OrdinalIgnoreCase) >= 0) return "Đã chạm rate limit; vui lòng thử lại sau.";
        return message.Length > 240 ? message.Substring(0, 240) + "..." : message;
    }
}
