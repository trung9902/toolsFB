using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Cụm tính năng Tiện ích Mở rộng (Page, Nhóm, Web, Instagram, Báo cáo, Dọn tường, GemLogin)
/// </summary>
public partial class fMain
{
    /// <summary>
    /// Thực hiện kịch bản Tìm kiếm Google Organic
    /// </summary>
    public int RunOtherUtilities_GoogleSearch(int rowIndex, string accountInfo, Chrome chrome, List<string> keywords, int kwFrom, int kwTo, int pageFrom, int pageTo, int linkFrom, int linkTo, int scrollFrom, int scrollTo, string actionName)
    {
        return OtherUtilitiesHelper.ExecuteGoogleSearch(
            chrome,
            keywords,
            kwFrom,
            kwTo,
            pageFrom,
            pageTo,
            linkFrom,
            linkTo,
            scrollFrom,
            scrollTo,
            msg => method_130(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName}: " + msg),
            (msg, dFrom, dTo) => method_131(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName} - " + msg + ", delay {time}s...", dFrom, dTo)
        );
    }

    /// <summary>
    /// Thực hiện kịch bản Truy cập Website & Nuôi Cookie ngoài
    /// </summary>
    public int RunOtherUtilities_WebsiteVisit(int rowIndex, string accountInfo, Chrome chrome, List<string> urls, int countFrom, int countTo, int linkClickFrom, int linkClickTo, int scrollFrom, int scrollTo, bool randomScroll, string actionName)
    {
        return OtherUtilitiesHelper.ExecuteWebsiteVisit(
            chrome,
            urls,
            countFrom,
            countTo,
            linkClickFrom,
            linkClickTo,
            scrollFrom,
            scrollTo,
            randomScroll,
            msg => method_130(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName}: " + msg),
            (msg, dFrom, dTo) => method_131(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName} - " + msg + ", delay {time}s...", dFrom, dTo)
        );
    }

    /// <summary>
    /// Rời nhóm Facebook với modal Comet mới
    /// </summary>
    public bool RunOtherUtilities_LeaveGroupComet(int rowIndex, string accountInfo, Chrome chrome, string groupId, string actionName)
    {
        return OtherUtilitiesHelper.LeaveGroupComet(
            chrome,
            groupId,
            msg => method_130(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName}: " + msg)
        );
    }

    /// <summary>
    /// Follow / Like Page hoặc Profile với nhận diện đa ngôn ngữ
    /// </summary>
    public bool RunOtherUtilities_FollowOrLike(int rowIndex, string accountInfo, Chrome chrome, string targetId, bool isLikePage, string actionName)
    {
        if (isLikePage)
        {
            return OtherUtilitiesHelper.ExecuteLikePage(
                chrome,
                targetId,
                msg => method_130(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName}: " + msg)
            );
        }
        else
        {
            return OtherUtilitiesHelper.ExecuteFollow(
                chrome,
                targetId,
                msg => method_130(rowIndex, accountInfo + Language.GetValue("Đang") + $" {actionName}: " + msg)
            );
        }
    }
}
