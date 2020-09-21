<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHourStatisticalReportControl.ascx.cs" Inherits="WebBusStatisticalReports.FormsStatisticalReports.JHourStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش آماری ساعتی</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از ساعت:</td>
        <td style="direction:ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction:ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Report"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 100px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="تعداد تراکنش در ساعت">
                    </telerik:RadTab>
                    <telerik:RadTab Text="میزان درآمد در ساعت">
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