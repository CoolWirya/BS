<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOwnersFinancialTransferUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOwnersFinancialTransferUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">انتقال مالی بین بهره برداران</div>
<table style="width: 400px">
<%--    <tr class="Table_RowC">
        <td style="width: 100px">مبلغ قابل انتقال:</td>
        <td>
            <%=MovablePrice.ToString() %>&nbsp;&nbsp;ریال
        </td>
    </tr>--%>
    <tr class="Table_RowB">
        <td style="width: 100px">از مالک:</td>
        <td>
            <asp:Label ID="lblSenderOwner" Text="" runat="server" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 100px">به مالک:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbReceiverOwner" Width="250px" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
<%--    <tr class="Table_RowB">
        <td style="width: 100px">مبلغ:</td>
        <td>
            <telerik:RadTextBox runat="server" id="txtPrice" InputType="Number" Width="220px"/>&nbsp;&nbsp;ریال
        </td>
    </tr>--%>
</table>
<div class="FormButtons">
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
