<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSendSmsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JSendSmsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">ارسال پیام کوتاه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">شماره مورد نظر:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtReciverMobile" Width="100%" Height="60px" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">متن مورد نظر:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMessageText" Width="100%" Height="200px" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ارسال" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
