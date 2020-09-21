<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainPage.ascx.cs" Inherits="WebAVL.Forms.MainPage" %>

<%@ Register Assembly="AVL" Namespace="AVL.Controls.SquareList" TagPrefix="cp" %>

<style>
    .t1:hover{
        background-color:gainsboro
    }
</style>
<table style="width:100%; height:100%; background-color:honeydew;margin:0px;padding:0px">
    <tr style="height:25%">
        <td colspan="4" style="text-align:center; vertical-align:central; color:darkblue;" ><h1 style="text-align:center">سلام <%= ClassLibrary.JMainFrame.CurrentUser.Person.Name %> ، خوش آمدی !</h1></td>
    </tr>
    <tr style="height:25%;text-align:center;">
        <td class="t1" style="width:25%; border-left:solid;border-color:darkgray; border-width:2px;padding:20px;">
            <table style="width:100%;height:100%;border-bottom:solid;border-width:3px;border-color:crimson">
                <tr>
                    <td><label title="0" style="font-size:60px"><%= AVL.JoinDevice.JJoinDevices.GetData(0, deviceCode).Rows.Count -1 %></label> عدد</td>
                    <td style="width:80%"></td>
                    <td><image src="../images/icons/gps-icon-64.png" style="right:auto"></image></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;color:darkslategrey">دستگاه</td>
                </tr>
            </table>
        </td>
        <td class="t1" style="width:25%; border-left:solid;border-color:darkgray; border-width:2px;padding:20px;">
            <table style="width:100%;height:100%;border-bottom:solid;border-width:3px;border-color:darkorchid">
                <tr>
                    <td><label title="0" style="font-size:60px"><%= Accounting.Cash.JCash.GetCash(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) %></label>ریال
                        <label title="0" style="font-size:60px">    <%= Accounting.Cash.JCash.GetCash(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) / AVL.RegisterDevice.JRegisterDevices.GetOneDayPrice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) %></label> روز</td>
                    <td style="width:80%"></td>
                    <td><image src="../images/icons/cash-register-icon-64.png" style="right:auto"></image></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;color:darkslategrey">شارژ</td>
                </tr>
            </table>
        </td>
        <td class="t1" style="width:25%; border-left:solid;border-color:darkgray; border-width:2px;padding:20px;">
            <table style="width:100%;height:100%;border-bottom:solid;border-width:3px;border-color:chartreuse">
                <tr>
                    <td><label title="0" style="font-size:60px">0</label></td>
                    <td style="width:80%"></td>
                    <td><image src="../images/icons/help-icon-64.png" style="right:auto"></image></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;color:darkslategrey">تیکت</td>
                </tr>
            </table>
        </td>
        <td class="t1" style="width:25%; padding:20px;">
            <table style="width:100%;height:100%;border-bottom:solid;border-width:3px;border-color:mediumslateblue">
                <tr>
                    <td><label title="0" style="font-size:60px"><%= Accounting.Factor.JFactors.GetNumberOpenFactor() %></label></td>
                    <td style="width:80%"></td>
                    <td><image src="../images/icons/sales-by-payment-method-rep-icon.png" style="right:auto"></image></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;color:darkslategrey">فاکتورها</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:25%">
        <td colspan="2">
            <table style="width:100%; height=100%">
                <tr style="height:10%; background-color:darkgray"><td>آخرین اخبار</td></tr>
                <tr style="height:90%">
                    <td>
                        <br />1
                        <br />2
                        <br />3
                        <br />4

                    </td></tr>
            </table>
        </td>
        <td colspan="2">
            <table style="width:100%; height=100%">
                <tr style="height:10%; background-color:darkgray"><td>دانلود</td></tr>
                <tr style="height:90%">
                    <td>
                        <br />1
                        <br />2
                        <br />3
                        <br />4

                    </td></tr>
            </table>
        </td>
    </tr>
    <tr style="height:25%">
        <td colspan="2">
            <table style="width:100%; height=100%">
                <tr style="height:10%; background-color:darkgray"><td>آنلاین امروز</td></tr>
                <tr style="height:90%">
                    <td>
                        <br />1
                        <br />2
                        <br />3
                        <br />4

                    </td></tr>
            </table>
        </td>
        <td colspan="2">
            <table style="width:100%; height=100%">
                <tr style="height:10%; background-color:darkgray"><td>متراژ امروز</td></tr>
                <tr style="height:90%">
                    <td>
                        <br />1
                        <br />2
                        <br />3
                        <br />4

                    </td></tr>
            </table>
        </td>
    </tr>
</table>