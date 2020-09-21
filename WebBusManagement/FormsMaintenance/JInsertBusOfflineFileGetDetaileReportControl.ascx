<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertBusOfflineFileGetDetaileReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JInsertBusOfflineFileGetDetaileReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<div class="FormContent">
    <div class="BigTitle">ریز جزئیات فایل های آفلاین اتوبوس ها</div>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td style="width: 100%; height: auto; overflow: auto">
                <telerik:RadGrid runat="server" ID="RadGridReport1" OnPreRender="RadGridReport1_PreRender" AllowPaging="true" PageSize="10" AllowMultiRowSelection="false">
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
