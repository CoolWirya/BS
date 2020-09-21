<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusTicketFailureTransactionSendReportControl.ascx.cs" Inherits="WebBusMaintenance.Forms.JBusTicketFailureTransactionSendReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">گزارش عدم ارسال تراکنش بلیط</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">عدم ارسال تراکنش از:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtNumOfDay" Width="50px" Text="1" MaxLength="5"></telerik:RadTextBox>روز قبل
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtNumOfDay" ValidationGroup="Report" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="0 تا 10000000" ControlToValidate="txtNumOfDay" MinimumValue="0"
                MaximumValue="10000000" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
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
