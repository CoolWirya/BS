<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JContractorAccountUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JContractorAccountUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">صورت وضعیت طراحان کنترل شرق</div>
<table style="width: 500px; ">
    <tr class="Table_RowB">
        <td style="width: 150px">پیمانکار:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">سال:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbYears" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ماه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbMount" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="فروردین" Selected="true" />
                    <telerik:RadComboBoxItem Value="2" Text="اردیبهشت" />
                    <telerik:RadComboBoxItem Value="3" Text="خرداد" />
                    <telerik:RadComboBoxItem Value="4" Text="تیر" />
                    <telerik:RadComboBoxItem Value="5" Text="مرداد" />
                    <telerik:RadComboBoxItem Value="6" Text="شهریور" />
                    <telerik:RadComboBoxItem Value="7" Text="مهر" />
                    <telerik:RadComboBoxItem Value="8" Text="آبان" />
                    <telerik:RadComboBoxItem Value="9" Text="آذر" />
                    <telerik:RadComboBoxItem Value="10" Text="دی" />
                    <telerik:RadComboBoxItem Value="11" Text="بهمن" />
                    <telerik:RadComboBoxItem Value="12" Text="اسفند" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کارکرد به ریال:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtKarkard" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">دریافتی به ریال:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDaryafti" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مانده به ریال:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMandeh" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
</table>

<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="آمار کل">
        </telerik:RadTab>
        <telerik:RadTab Text="کاکرد">
        </telerik:RadTab>
        <telerik:RadTab Text="پرداختی">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="100%" style="margin-bottom: 55px">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <%--<uc1:JGridViewControl runat="server" id="RadGridReportAmareKol" />--%>
        <cc1:JGridView runat="server" id="RadGridReportAmareKol"></cc1:JGridView>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
       <%--  <uc1:JGridViewControl runat="server" id="RadGridReportAmareKarKard" />--%>
        <cc1:JGridView runat="server" id="RadGridReportAmareKarKard"></cc1:JGridView>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView3">
        <%-- <uc1:JGridViewControl runat="server" id="RadGridReportAmarePardakhti" />--%>
        <cc1:JGridView runat="server" id="RadGridReportAmarePardakhti"></cc1:JGridView>
    </telerik:RadPageView>
</telerik:RadMultiPage>

<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnCheck" Text="بررسی صورت حساب" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnCheck_Click" />
    <telerik:RadButton runat="server" ID="btnSave" Text="ثبت نهایی صورت حساب" AutoPostBack="true" Width="150px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
