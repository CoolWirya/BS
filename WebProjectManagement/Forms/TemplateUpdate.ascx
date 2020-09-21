<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateUpdate.ascx.cs" Inherits="WebProjectManagement.Forms.TemplateUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<style>
    .pnlprompt {
        position: absolute;
    }
</style>
<table>
    <tr>
        <td class="Table_RowB">نام</td>
        <td class="Table_RowC">
            <asp:TextBox runat="server" ID="txtName" /></td>
    </tr>
    <tr>
        <td class="Table_RowB">وزن کل</td>
        <td class="Table_RowC">
            <asp:TextBox runat="server" ID="txtTotalWeight" /></td>
    </tr>
    <% if (int.Parse(Request["Code"] != null ? Request["Code"] : "0") <= 0)
        { %>
    <tr>
        <td class="Table_RowB">کپی آیتم ها از الگوی :</td>
        <td class="Table_RowC">
            <asp:DropDownList runat="server" ID="ddlTemplates" /></td>
    </tr>
    <%} %>
    <tr>
        <td class="Table_RowB">
            <%--<asp:Button runat="server" ID="btnSave" Text="ذخیره" OnClick="btnSave_Click" />--%>
            <telerik:RadButton runat="server" ID="RadButton1" Text="ذخیره" OnClick="btnSave_Click" Width="100px" Height="35px" ValidationGroup="Line" />
        </td>
        <% if (int.Parse(Request["Code"] != null ? Request["Code"] : "0") > 0)
            { %>
        <td class="Table_RowC">
            <telerik:RadButton runat="server" ID="RadButton2" Text="حذف" OnClick="RadButton2_Click" Width="100px" Height="35px" ValidationGroup="Line" />
        </td>
        <%} %>
        <td class="Table_RowC">
            <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
        </td>
    </tr>
</table>

<asp:Panel runat="server" ID="pnlPrompt" CssClass="pnlprompt"></asp:Panel>
