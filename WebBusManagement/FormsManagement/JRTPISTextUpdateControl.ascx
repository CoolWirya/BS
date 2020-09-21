<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JRTPISTextUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JRTPISTextUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">متن RTPIS</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">متن مورد نظر:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtRTPISText" Width="100%" Height="200px" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
