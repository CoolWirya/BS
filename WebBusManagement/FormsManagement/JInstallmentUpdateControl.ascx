<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInstallmentUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JInstallmentUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">تقسیط مانده حساب ها</div>
<table style="width: 550px">
    <tr class="Table_RowC">
        <td style="width: 150px">مالک :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbTafzili1" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">کد و نام مالک:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTafziliName" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کارکرد به تومان:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtKarkard" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">پرداختی به تومان:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPardakhti" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مانده به تومان:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMandeh" Width="96%" Enabled="true" ReadOnly="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">مبلغ قسط:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtInstallmentAmount" Width="96%" Enabled="true"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">فاصله زمانی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtInstallmentPeriod" Width="96%" Enabled="true"></telerik:RadTextBox>
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnSave" Text="بررسی وضعیت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnInsertDocument" Text="ثبت سند" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnInsertDocument_Click" Enabled="false"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
