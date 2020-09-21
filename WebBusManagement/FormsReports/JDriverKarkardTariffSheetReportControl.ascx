<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDriverKarkardTariffSheetReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JDriverKarkardTariffSheetReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<div class="BigTitle">گزارش شناسنامه تعرفه کارکرد رانندگان</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">سال:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbYears" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
    </tr>
    <tr class="Table_RowC">
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
    <tr class="Table_RowB">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
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