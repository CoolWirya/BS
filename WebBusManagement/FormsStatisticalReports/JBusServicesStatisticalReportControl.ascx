<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusServicesStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JBusServicesStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش آماری سرویس های اتوبوس ها در بازه زمانی</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtToDate" />
        </td>
    </tr>
</table>
<div style="clear: both; height: 45px"></div>
<telerik:radbutton runat="server" id="btnSave" text="مشاهده گزارش" autopostback="true" width="100px" height="35px" onclick="btnSave_Click" />
<telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
<div style="clear: both; height: 45px"></div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="نمودار میله ای">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار دایره ای">
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
</telerik:RadMultiPage>
