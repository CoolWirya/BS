<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JComparisonTicketTExtractTAndDailyTReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JComparisonTicketTExtractTAndDailyTReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table style="width: 100%; height: auto; margin-top: 15px">

<div class="BigTitle">گزارش مقایسه سه جدول بلیط ، اکسترکت و تجمیع</div>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            <telerik:RadGrid runat="server" ID="RadGridReport1" OnPreRender="RadGridReport1_PreRender" AllowPaging="true" PageSize="30" AllowMultiRowSelection="false">
            </telerik:RadGrid>
        </td>
    </tr>
</table>
