<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDriverStatisticalReportControl.ascx.cs" Inherits="WebBusManagement.FormsStatisticalReports.JDriverStatisticalReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش آماری رانندگان</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">رانندگان:</td>
        <td>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadComboBox runat="server" ID="cmbDriver" Width="60%" Filter="Contains"></telerik:RadComboBox>
                <telerik:RadButton runat="server" ID="BtnInsertDriver" Text="درج" AutoPostBack="true" Width="70px" Height="20px" OnClick="BtnInsertDriver_Click" />
            </div>
            <div style="clear: both; height: 5px"></div>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadListBox runat="server" ID="lstDriver" Width="70%" EnableDragAndDrop="true" AllowTransfer="true"
                    EmptyMessage="لیست رانندگان جهت رسم نمودار" Localization-MoveDown="مرتب سازی به پایین" Localization-MoveUp="مرتب سازی به بالا"
                    Localization-Delete="حذف از لیست"
                    AllowReorder="true" AllowDelete="true">
                </telerik:RadListBox>
            </div>
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
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 100px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="تعداد تراکنش رانندگان">
                    </telerik:RadTab>
                    <telerik:RadTab Text="میزان درآمد رانندگان">
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

