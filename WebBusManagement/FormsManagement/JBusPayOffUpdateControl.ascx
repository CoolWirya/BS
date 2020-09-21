<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusPayOffUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusPayOffUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<asp:HiddenField ID="hidBusCode" runat="server" Value="0" />
<div class="BigTitle">تصفیه حساب اتوبوس ها</div>
<table style="width: 550px">
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">کد و نام مالک:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
            <telerik:RadTextBox runat="server" ID="txtOwner" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ شروع مالکیت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtStartDate" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">کد تفصیلی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTafsili" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">شماره حساب:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtAccountNo" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تعداد تراکنش ها:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTransactions" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کل کارکرد اتوبوس:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPardakhti" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تعداد مانده:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMande" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کل کارکرد مالک:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtKarkardMalek" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">کل پرداختی مالک:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPardakhtiMalek" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کل مانده مالک:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMandeMalek" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">وضعیت مالی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtStatus" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnSave" Text="بررسی وضعیت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnPayOff" Text="تصفیه حساب" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnPayOff_Click" Enabled="false" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />