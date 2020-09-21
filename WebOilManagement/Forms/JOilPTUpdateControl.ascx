<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilPTUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JPTUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbGasStation">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbPump" />
                <telerik:AjaxUpdatedControl ControlID="cmbNozzle" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="cmbPump">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbNozzle" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="FormContent">
    <div class="BigTitle">PT</div>
    <table>
        <tr>
            <td class="Table_RowB">جایگاه:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbGasStation" Filter="Contains" OnSelectedIndexChanged="cmbGasStation_SelectedIndexChanged" AutoPostBack="true" EmptyMessage="-- انتخاب جایگاه --"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">پمپ:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbPump" Filter="Contains" OnSelectedIndexChanged="cmbPump_SelectedIndexChanged" AutoPostBack="true" EmptyMessage="-- انتخاب پمپ --"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نازل:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbNozzle" Filter="Contains" EmptyMessage="-- انتخاب نازل --"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شماره PT:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtNumber" Width="100%"></telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
