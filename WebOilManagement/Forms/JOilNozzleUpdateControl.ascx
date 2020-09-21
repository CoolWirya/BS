<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilNozzleUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JNozzleUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">نازل</div>
    <table>
        <tr>
            <td class="Table_RowB">پمپ:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbPump" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شماره:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtNumber" Width="100%"></telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbFuelTank" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
