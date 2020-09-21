<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMonthlyAccReviewReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JMonthlyAccReviewReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });

</script>

<div class="FormContent">
    <div class="BigTitle"><%=Title %></div>
<!--
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاخیر در پرداخت:</td>
        <td>
            <telerik:RadTextBox runat="server" id="txtPaymentDelay" InputType="Number" Text="1" Width="50px" />
                <span> روز</span>
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="LockButton" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
-->
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%;  height: auto; overflow: auto ;">
            <cc1:JGridView runat="server" id="RadGridReport">
            </cc1:JGridView>
        </td>
    </tr>
</table>
</div>
