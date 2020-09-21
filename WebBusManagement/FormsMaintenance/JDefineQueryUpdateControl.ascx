<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDefineQueryUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JDefineQueryUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">تعریف کوئری</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نام:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtName" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کوئری:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtQuery" Width="100%" TextMode="MultiLine" Height="75px"></telerik:RadTextBox></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>