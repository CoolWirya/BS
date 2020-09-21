<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDailyAccReviewReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JDailyAccReviewReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });

</script>

<div class="FormContent">
    <div class="BigTitle"><%=Title %></div>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%;  height: auto; overflow: auto ;">
            <cc1:JGridView runat="server" id="RadGridReport">
            </cc1:JGridView>
        </td>
    </tr>
</table>
</div>
