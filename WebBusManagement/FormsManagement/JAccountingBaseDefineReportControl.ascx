<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccountingBaseDefineReportControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccountingBaseDefineReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">تعاریف پایه حسابداری</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">شماره حساب اتوبوسرانی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBusCompanyAccountNumber" Width="100px"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                ControlToValidate="txtBusCompanyAccountNumber" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کارمزد پیمانکار:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPeymankarPercent" Width="100px" Text="0"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtPeymankarPercent" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">درصد حسن انجام کار:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtHosneAnjameKarPercent" Width="100px" Text="0"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="txtHosneAnjameKarPercent" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">درصد بیمه:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtInsurancePercent" Width="100px" Text="0"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                ControlToValidate="txtInsurancePercent" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">درصد مالیات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMaliyatPercent" Width="100px" Text="0"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                ControlToValidate="txtMaliyatPercent" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Settings" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

