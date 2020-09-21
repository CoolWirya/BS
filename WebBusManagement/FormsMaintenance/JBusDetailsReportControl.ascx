<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusDetailsReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusDetailsReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش جزئیات اتوبوس ها</div>
<%=BusDetails %>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            <cc1:JGridView runat="server" id="RadGridReport">
        </td>
    </tr>
</table>
