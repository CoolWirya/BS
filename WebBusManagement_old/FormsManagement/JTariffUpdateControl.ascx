<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTariffUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTariffUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>


<div class="BigTitle">تعرفه</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">شخص:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ شروع:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtStartDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ پایان:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFinishDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شیفت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbShift" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Tariff"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
