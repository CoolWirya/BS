<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOwnerBusReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JOwnerBusReportControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">مشخصات اتوبوس مالک</div>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
          
        </td>
    </tr>
</table>