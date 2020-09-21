<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDriverStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JDriverStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbBus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="BigTitle">گزارش آماری رانندگان</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="cmbZone_SelectedIndexChanged"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="cmbLine_SelectedIndexChanged"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains" AutoPostBack="false" OnSelectedIndexChanged="cmbBus_SelectedIndexChanged"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مالک:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusOwner" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">رانندگان:</td>
        <td>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadComboBox runat="server" ID="cmbDriver" Width="60%" Filter="Contains"></telerik:RadComboBox>
                <br />
                <telerik:RadButton runat="server" ID="BtnInsertDriver" Text="درج" AutoPostBack="true" Width="70px" Height="20px" OnClick="BtnInsertDriver_Click" />
            </div>
            <div style="clear: both; height: 5px"></div>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadListBox runat="server" ID="lstDriver" Width="70%" EnableDragAndDrop="true" AllowTransfer="true"
                    Localization-MoveDown="مرتب سازی به پایین" Localization-MoveUp="مرتب سازی به بالا"
                    Localization-Delete="حذف از لیست"
                    AllowReorder="true" AllowDelete="true">
                </telerik:RadListBox>
            </div>
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
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<div style="clear: both; height: 10px"></div>
<telerik:RadButton runat="server" ID="btnNextPage" Text="صفحه بعد" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnNextPage_Click" Visible="false"/>
<telerik:RadButton runat="server" ID="btnPrevPage" Text="صفحه قبل" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnPrevPage_Click" Visible="false"/>
<div style="clear: both; height: 10px"></div>
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

