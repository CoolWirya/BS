<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCardBlackListUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JCardBlackListUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">لیست سیاه کارت مسافر</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">شماره آر اف آی دی:</td>
        <td>
            <telerik:RadNumericTextBox runat="server" ID="ntbRfidNumber" Width="100%" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
</div>