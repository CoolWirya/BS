<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertBusTicketTransactionUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JInsertBusTicketTransactionUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>

<div class="BigTitle">ثبت پرینت کنسول اتوبوس ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">دریافت کننده پرینت:</td>
        <td>
            <uc2:JSearchPersonControl runat="server" id="JSearchPersonControlInstaller" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ دریافت پرینت:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtReportDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد تراکنش کنسول:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTransactionCount" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">مبلغ درآمد:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtIncome" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="CPrint" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
