<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTasfieMandehHesabReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JTasfieMandehHesabReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<%--<script type="text/javascript">
    $(document).ready(function () {
        //GetRadWindow().maximize();
    });

</script>--%>

<%--<telerik:RadButton runat="server" ID="btnPayOff" Text="تسویه" Width="100px" Height="35px" OnClick="btnPayOff_Click" />
<telerik:RadButton runat="server" ID="btnInstallment" Text="تقسیط" Width="100px" Height="35px" OnClick="btnInstallment_Click" />--%>
<%--<div style="margin-top: -50px">  
    <cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView> 
</div>--%>
<div class="BigTitle">گزارش تسویه مانده حساب</div> 
<div class="FormContent" style="top:40px;">
    <cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView> 
</div>
