<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateItemUpdate.ascx.cs" Inherits="WebProjectManagement.Forms.TemplateItemUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td class="Table_RowB">نام</td>
        <td class="Table_RowC"><telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">درصد وزن</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtWeight"></telerik:RadTextBox>
            </td>
    </tr>
    <tr>
        <td class="Table_RowB"><telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" OnClick="btnSave_Click" Width="100px" Height="35px" ValidationGroup="Line"/></td>
        <td class="Table_RowC"><telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" /></td>
    </tr>
</table>