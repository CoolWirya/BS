<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSharePriceTextUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JSharePriceTextUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">متن درخواست های خرید و فروش</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">متن:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtText" Width="100%" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>