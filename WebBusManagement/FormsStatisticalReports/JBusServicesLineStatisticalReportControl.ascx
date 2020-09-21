<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusServicesLineStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JBusServicesLineStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<telerik:radajaxmanagerproxy runat="server" id="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:radajaxmanagerproxy>
<telerik:radajaxmanagerproxy runat="server" id="Radajaxmanagerproxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:radajaxmanagerproxy>
<div class="BigTitle">گزارش آماری سرویس های اتوبوس ها بر اساس خط در بازه زمانی</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:radcombobox runat="server" id="cmbZone" width="100%" filter="Contains" autopostback="true" onselectedindexchanged="cmbZone_SelectedIndexChanged"></telerik:radcombobox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:radcombobox runat="server" id="cmbLine" width="100%" filter="Contains" autopostback="true" onselectedindexchanged="cmbLine_SelectedIndexChanged"></telerik:radcombobox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:radcombobox runat="server" id="cmbBus" width="60%" filter="Contains" autopostback="false" onselectedindexchanged="cmbBus_SelectedIndexChanged"></telerik:radcombobox>
        </td>
    </tr>
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
<telerik:radtabstrip runat="server" id="RadTabStrip1"
    selectedindex="0" multipageid="RadMultiPage1" width="100%">
    <Tabs>
        <telerik:RadTab Text="نمودار میله ای">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار دایره ای">
        </telerik:RadTab>
    </Tabs>
</telerik:radtabstrip>
<telerik:radmultipage runat="server" id="RadMultiPage1" selectedindex="0"
    width="100%">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartCOL" Transitions="true" Width="1400px" Height="550px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
        <div dir="ltr" style="overflow-x: scroll; overflow-y: hidden">
            <center>
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChartPIE" Transitions="true" Width="1400px" Height="700px"></telerik:RadHtmlChart>
                </center>
        </div>
    </telerik:RadPageView>
</telerik:radmultipage>
