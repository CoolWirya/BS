<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JApplyInvalidBusUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JApplyInvalidBusUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">تایید اتوبوس نامعتبر</div>
<table style="width: 100%">
    <tr class="Table_RowB">
        <td style="text-align:center;vertical-align:middle">
            <%=Decription %>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
