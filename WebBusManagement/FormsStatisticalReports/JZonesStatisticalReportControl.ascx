<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JZonesStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JZonesStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش آماری مناطق</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نوع کارت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbCardType" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div style="clear: both; height: 35px"></div>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<div style="clear: both; height: 35px"></div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="نمودار میله ای تراکنش">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار دایره ای تراکنش">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار میله ای درآمد">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار دایره ای درآمد">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="100%">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartCOL" Transitions="true" Width="1200px" Height="550px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartPIE" Transitions="true" Width="1200px" Height="700px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView3">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartCOLIncome" Transitions="true" Width="1200px" Height="550px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView4">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartPIEIncome" Transitions="true" Width="1200px" Height="700px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
</telerik:RadMultiPage>

