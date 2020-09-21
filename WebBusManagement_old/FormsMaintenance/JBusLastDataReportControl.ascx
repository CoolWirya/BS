<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusLastDataReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusLastDataReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">گزارش آخرین اطلاعات دریافتی اتوبوس ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">مرتب سازی بر اساس:</td>
        <td>
            <asp:RadioButton ID="rbtSortByNewAvlTransaction" runat="server" GroupName="Sort" Checked="true" />آخرین تراکنش های AVL
            <asp:RadioButton ID="rbtSortByNewTicketTransaction" runat="server" GroupName="Sort" />آخرین تراکنش های بلیط
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>
