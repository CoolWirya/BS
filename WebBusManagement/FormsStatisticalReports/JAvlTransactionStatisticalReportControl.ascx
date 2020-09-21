<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAvlTransactionStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JAvlTransactionStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<link href="~/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.css" rel="stylesheet" />
<div class="BigTitle">گزارش آماری تعداد تراکنش های AVL</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeSecond" Width="40px" MaxLength="2" EmptyMessage="ثانیه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeSecond" Width="40px" MaxLength="2" EmptyMessage="ثانیه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
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
        <%-- <telerik:RadTab Text="نمودار میله ای درآمد">
        </telerik:RadTab>
        <telerik:RadTab Text="نمودار دایره ای درآمد">
        </telerik:RadTab>--%>
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
