using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public partial class fMain
{
    #region LushCare Friends Module Integration (fMain.Friends.cs)
    /// <summary>
    /// partial class fMain.Friends.cs: Cung cấp cầu nối mở rộng cho toàn bộ 10 chức năng Bạn bè:
    /// - Kết bạn theo gợi ý (HDKetBanGoiY)
    /// - Kết bạn theo tệp UID (HDKetBanTepUid)
    /// - Kết bạn thành viên nhóm (HDKetBanThanhVienNhom)
    /// - Tìm kiếm người dùng theo từ khóa (HDKetBanTheoTuKhoa)
    /// - Kết bạn bạn bè của UID (HDKetBanVoiBanBeCuaUid)
    /// - Xác nhận lời mời kết bạn (HDXacNhanKetBan)
    /// - Hủy kết bạn Unfriend (HDHuyKetBan)
    /// - Hủy lời mời kết bạn đã gửi (HDHuyLoiMoiKetBan)
    /// - Chọc Poke bạn bè (HDChocBanBe)
    /// - Chúc mừng sinh nhật bạn bè (HDChucMungSinhNhat)
    /// </summary>

    /// <summary>
    /// Thực thi Kết bạn gợi ý nâng cao
    /// </summary>
    public int RunFriendAction_KetBanGoiY(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.KetBanGoiY(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Kết bạn theo tệp UID
    /// </summary>
    public int RunFriendAction_KetBanTepUid(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName, string actionId)
    {
        return FriendAutomationHelper.KetBanTepUid(this, rowIndex, accPrefix, chrome, config, actionName, actionId);
    }

    /// <summary>
    /// Thực thi Kết bạn thành viên nhóm
    /// </summary>
    public int RunFriendAction_KetBanThanhVienNhom(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.KetBanThanhVienNhom(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Kết bạn theo từ khóa
    /// </summary>
    public int RunFriendAction_KetBanTheoTuKhoa(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.KetBanTheoTuKhoa(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Kết bạn với bạn bè của UID
    /// </summary>
    public int RunFriendAction_KetBanVoiBanBeCuaUid(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName, string actionId)
    {
        return FriendAutomationHelper.KetBanVoiBanBeCuaUid(this, rowIndex, accPrefix, chrome, config, actionName, actionId);
    }

    /// <summary>
    /// Thực thi Xác nhận lời mời kết bạn
    /// </summary>
    public int RunFriendAction_XacNhanKetBan(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.XacNhanKetBan(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Hủy kết bạn (Unfriend)
    /// </summary>
    public int RunFriendAction_HuyKetBan(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.HuyKetBan(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Hủy lời mời kết bạn đã gửi
    /// </summary>
    public int RunFriendAction_HuyLoiMoiKetBan(int rowIndex, string accPrefix, Chrome chrome, int from, int to, int delayFrom, int delayTo, string actionName)
    {
        return FriendAutomationHelper.HuyLoiMoiKetBan(this, rowIndex, accPrefix, chrome, from, to, delayFrom, delayTo, actionName);
    }

    /// <summary>
    /// Thực thi Thu hồi lời mời kết bạn treo Comet 2026 (FacebookFriendAutomationHelper)
    /// </summary>
    public int RunFriendAction_CancelPendingSentRequests(int rowIndex, string accPrefix, Chrome chrome, int maxCancelCount = 50, int delayMinSec = 1, int delayMaxSec = 3)
    {
        return FacebookFriendAutomationHelper.CancelPendingSentRequests(this, rowIndex, accPrefix, chrome, maxCancelCount, delayMinSec, delayMaxSec);
    }

    /// <summary>
    /// Thực thi Hủy kết bạn tài khoản ảo/die (FacebookFriendAutomationHelper)
    /// </summary>
    public int RunFriendAction_UnfriendInactiveAccounts(int rowIndex, string accPrefix, Chrome chrome, List<string> deadFriendUids, int maxUnfriendCount = 30)
    {
        return FacebookFriendAutomationHelper.UnfriendInactiveAccounts(this, rowIndex, accPrefix, chrome, deadFriendUids, maxUnfriendCount);
    }

    /// <summary>
    /// Tự động quét và hủy kết bạn bạn bè ảo/die (FacebookFriendAutomationHelper)
    /// </summary>
    public int RunFriendAction_FilterAndUnfriendInactive(int rowIndex, string accPrefix, Chrome chrome, int maxCheckCount = 100, int maxUnfriendCount = 30)
    {
        return FacebookFriendAutomationHelper.FilterAndUnfriendInactive(this, rowIndex, accPrefix, chrome, maxCheckCount, maxUnfriendCount);
    }

    /// <summary>
    /// Thực thi Chọc (Poke) bạn bè
    /// </summary>
    public int RunFriendAction_ChocBanBe(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.ChocBanBe(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Thực thi Chúc mừng sinh nhật (đăng tường / tin nhắn spintax)
    /// </summary>
    public int RunFriendAction_ChucMungSinhNhat(int rowIndex, string accPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        return FriendAutomationHelper.ChucMungSinhNhat(this, rowIndex, accPrefix, chrome, config, actionName);
    }

    /// <summary>
    /// Bộ lọc thông minh: Kiểm tra tên có dấu tiếng Việt
    /// </summary>
    public bool ValidateVietnameseName(string name)
    {
        return FriendAutomationHelper.IsVietnameseName(name);
    }

    /// <summary>
    /// Xử lý Spin Syntax {a|b|c} cho nội dung tin nhắn/bài viết chúc mừng
    /// </summary>
    public string SpinText(string text)
    {
        return FriendAutomationHelper.SpinText(text);
    }
    #endregion
}
