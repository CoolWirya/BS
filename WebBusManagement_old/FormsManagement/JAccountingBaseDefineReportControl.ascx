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
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Settings"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

