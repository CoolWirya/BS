<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusSettingsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusSettingsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">تعریف پارامترهای کنترلی</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">ساعت شروع به کار:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtStartTime" Width="50px" EmptyMessage="7:30" MaxLength="5"></telerik:RadTextBox>نمونه : 7:30
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtStartTime" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">سرعت مجاز:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSpeedLimit" Width="50px" EmptyMessage="60" MaxLength="3"></telerik:RadTextBox>کیلومتر بر ساعت
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="txtSpeedLimit" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">میزان مجاز تجاوز از خط:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTrepassOfLineMeter" Width="50px" EmptyMessage="20" MaxLength="5"></telerik:RadTextBox>متر
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                ControlToValidate="txtTrepassOfLineMeter" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <%-- <tr class="Table_RowC">
        <td style="width: 150px">شماره حساب اتوبوسرانی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBusCompanyAccountNumber" Width="100px"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" 
                ControlToValidate="txtBusCompanyAccountNumber" ValidationGroup="Settings" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>--%>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Settings" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
