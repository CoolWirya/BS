<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TotalReportProjectsChart.ascx.cs" Inherits="WebProjectManagement.Forms.TotalReportProjectsChart" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="~/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.css" rel="stylesheet" />
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<telerik:RadComboBox runat="server" ID="cmbProjects" AutoPostBack="true"></telerik:RadComboBox>
<table>
    <tr>
        <td>بازه ی اول</td>
        <td>
            <uc1:JDateControl runat="server" id="dateFirst" TabIndex="4" />
        </td>
        <td></td>
    </tr>
    <tr>
        <td>بازه ی دوم</td>
        <td>
            <uc1:JDateControl runat="server" id="dateSecond" TabIndex="3" />
        </td>
        <td>
            <telerik:RadButton runat="server" ID="RadButton1" Text="نمایش" Width="100px" Height="35px" TabIndex="2"
                OnClick="btnSave_Click" />
        </td>
        <td>
            <telerik:RadButton runat="server" ID="btnDownloadPDF" Text="دانلود PDF" Width="100px" Height="35px" TabIndex="2"  Enabled="false"
            OnClientClicked="exportRadHtmlChart" />
        </td>
    </tr>
</table>
<style>
    .chart {
        z-index: -1;
    }
</style>
<telerik:RadClientExportManager runat="server" ID="RadClientExportManager1">
</telerik:RadClientExportManager>
<telerik:RadHtmlChart runat="server" ID="RadHtmlChartCOL" Transitions="true" Width="1200px" Height="550px" TabIndex="1" RenderMode="Auto" CssClass="chart"></telerik:RadHtmlChart>
<script>
    var $ = $telerik.$;
 
        function exportRadHtmlChart() {
            $find('<%=RadClientExportManager1.ClientID%>').exportPDF($(".RadHtmlChart"));
        }

</script>
