<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentsControl.ascx.cs" Inherits="WebLegal.Contract.Forms.Documents.DocumentsControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="نوع سند :"></asp:Label></td>
        <td>
            <asp:DropDownList ID="JcmbTypeDoc" runat="server"></asp:DropDownList></td>
        <td>
            <JJson:JJsonButton ID="JbtnPlus" runat="server" Event="click" /></td>
        <td><JJson:JJsonButton ID="JbtnDel" runat="server" Event="click" /></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="JgrdDocuments" runat="server"></telerik:RadGrid>
        </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="JbtnNext" runat="server" Text="بعدی" /></td>
        <td>
             <asp:Button ID="JbtnPre" runat="server" Text="قبلی" />
        </td>
        <td></td>
        <td></td>
        <td></td>
        <td>
             <asp:Button ID="JbtnCancel" runat="server" Text="انصراف" />
        </td>
    </tr>
</table>
