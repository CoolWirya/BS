<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGSPropertiesReportControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JGSPropertiesReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>




<div class="BigTitle" ></div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>

        </td>
    </tr>
    <tr class="Table_RowC">
        <td>ناحیه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>پیمانکار:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbSupplier" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>نوع خرابی:</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlDamage" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>کاربر ثبت کننده خطا:</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="JLstCtrUsers" />
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">مکان محل عرضه:</td>
        <td class="Table_RowC">
            <telerik:RadComboBox runat="server" ID="cmbPlaceOfSupply" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">نوع محل عرضه:</td>
        <td class="Table_RowC">
            <telerik:RadComboBox runat="server" ID="cmbTypeOfSupply" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">مالک:</td>
        <td class="Table_RowC">
            <uc1:jsearchpersoncontrol runat="server" id="personOwner" />
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">اپراتور:</td>
        <td class="Table_RowC">
            <uc1:jsearchpersoncontrol runat="server" id="personOperator" />
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">نوع مخزن:</td>
        <td class="Table_RowC">
            <telerik:RadComboBox runat="server" ID="cmbTypeOfFuelTank" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">نوع محصول مخزن:</td>
        <td class="Table_RowC">
            <telerik:RadComboBox runat="server" ID="cmbTypeOfProduct" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">طول جغرافیایی:</td>
        <td class="Table_RowC">
            <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtLat" Width="95%"></telerik:RadNumericTextBox>

        </td>
    </tr>
    <tr>
        <td class="Table_RowB">عرض جغرافیایی:</td>
        <td class="Table_RowC">
            <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" runat="server" ID="txtLon" Width="95%"></telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">ارتفاع جغرافیایی:</td>
        <td class="Table_RowC">
            <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtAlt" Width="95%"></telerik:RadNumericTextBox>
        </td>
    </tr>
</table>



<telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="grdManagerPortalReports" />
        </td>
    </tr>
</table>
