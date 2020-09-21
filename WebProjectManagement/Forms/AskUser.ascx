<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskUser.ascx.cs" Inherits="WebProjectManagement.Forms.AskUser" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table style="width:100%;height:100%;">
    <tr>
        <td class="Table_RowC" colspan="2"><telerik:RadLabel runat="server" ID="txtText" /></td>
    </tr>
    <tr>
        <td class="Table_RowB">
            <%--<asp:Button runat="server" ID="btnSave" Text="ذخیره" OnClick="btnSave_Click" />--%>
            <telerik:RadButton runat="server" ID="RadButton1" Text="بله"  OnClick="RadButton1_Click"  Width="100px" Height="35px" ValidationGroup="Line"/>
        </td>
        <td class="Table_RowC">            
            <telerik:RadButton runat="server" ID="RadButton2" Text="خیر"  OnClick="RadButton2_Click"  Width="100px" Height="35px" ValidationGroup="Line"/>
        </td>
    </tr>
</table>