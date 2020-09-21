<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusWorkSheetReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusWorkSheetReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="BigTitle">گزارش شناسنامه کاری اتوبوس</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains">
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
        <td style="width: 150px">نوع گزارش:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbReportType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="با جزئیات" Selected="true" />
                    <telerik:RadComboBoxItem Value="2" Text="بصورت کلی" />
                    <telerik:RadComboBoxItem Value="3" Text="فقط کلیات" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
        </td>
    </tr>
</table>
