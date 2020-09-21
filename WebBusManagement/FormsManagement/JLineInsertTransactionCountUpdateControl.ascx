<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLineInsertTransactionCountUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JLineInsertTransactionCountUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">ثبت متوسط تراکنش خط به ازای هر اتوبوس در روز</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtLine" Width="96%" Enabled="false"></telerik:RadTextBox>
        </td>
    </tr>
        <tr class="Table_RowC">
        <td style="width: 150px">متوسط تعداد تراکنش روزانه اتوبوس در این خط:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTransactionCount" Width="96%"></telerik:RadTextBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
