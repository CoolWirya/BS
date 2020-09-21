<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilFuelTankUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JFuelTankUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">مخزن سوخت</div>
    <table>
        <tr>
            <td class="Table_RowB">شماره مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""  Width="100%"  MinValue="0" MaxValue="2147483647" ID="txtNumber"></telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جایگاه:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbGasStation" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نوع مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbTypeOfFuelTank" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شرکت سازنده:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbManufacturer" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">سال ساخت:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="9999" ID="txtYearBuilt" Width="100%"></telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نوع محصول مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbTypeOfProduct" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تعداد پمپ ها:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtNumberOfPumps" Width="100%"></telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
