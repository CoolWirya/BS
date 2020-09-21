<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JUserPasswordUpdateControl.ascx.cs" Inherits="WebControllers.MainControls.Configuration.jUserPasswordUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">تغییر کلمه عبور</div>
    <table>
        <tr>
            <td class="Table_RowB">کلمه عبور فعلی:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtCurrentPassword" TextMode="Password" Width="100%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">کلمه عبور جدید:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtNewPassword" TextMode="Password" Width="100%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtNewPassword" ValidationGroup="pwdGroup" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">کلمه عبور جدید(تکرار):</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtNewPassword2" TextMode="Password" Width="100%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtNewPassword2" ValidationGroup="pwdGroup" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtNewPassword2" ValidationGroup="pwdGroup" ErrorMessage="**"></asp:CompareValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="pwdGroup" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
