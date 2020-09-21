<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLinesStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JLinesStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش آماری خطوط</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 100px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="تعداد تراکنش خطوط">
                    </telerik:RadTab>
                    <telerik:RadTab Text="میزان درآمد خطوط">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
                Width="700px">
                <telerik:RadPageView runat="server" ID="RadPageView1">
                    <telerik:RadHtmlChart runat="server" ID="TransactionColumnChart" Width="800" Height="500" Transitions="true"
                        Skin="Forest">
                    </telerik:RadHtmlChart>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageView2">
                    <telerik:RadHtmlChart runat="server" ID="IncomColumnChart" Width="800" Height="500" Transitions="true"
                        Skin="Forest">
                    </telerik:RadHtmlChart>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
</table>

