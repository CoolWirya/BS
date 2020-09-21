<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTasfieMethodReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JTasfieMethodReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });

</script>
<div class="BigTitle">گزارش نحوه تسویه حساب اتوبوسها</div> 
<div class="FormContent" style="top:40px;">
    <cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
</div> 
