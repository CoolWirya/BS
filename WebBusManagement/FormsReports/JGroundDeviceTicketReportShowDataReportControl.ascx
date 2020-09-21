<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGroundDeviceTicketReportShowDataReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JGroundDeviceTicketReportShowDataReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">نمایش اطلاعات</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td><%=StrDate %></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
