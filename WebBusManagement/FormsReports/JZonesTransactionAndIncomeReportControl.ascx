<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JZonesTransactionAndIncomeReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JZonesTransactionAndIncomeReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش تراکنش و درآمد مناطق</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">ناوگان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains"></telerik:RadComboBox>
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
    <tr class="Table_RowC">
        <td style="width: 150px">نوع کارت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbCardType" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نوع روز:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbDayType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="-1" Text="همه ی روزها" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="روزهای عادی" />
                    <telerik:RadComboBoxItem Value="1" Text="روزهای تعطیل" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">فقط مناطق:</td>
        <td>
            <asp:CheckBox runat="server" ID="chkJustZone" Width="100%" Filter="Contains">
            </asp:CheckBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>
