<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="test.ascx.cs" Inherits="CMS.ContentManagement.test" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Components" TagPrefix="cc1" %>

<table>
    <tr>
        <td>
            <asp:Label ID="lblname" runat="server" Text="name"></asp:Label>
        </td>
        <td>
            <JJson:JJsonTextBox ID="txtname" runat="server"></JJson:JJsonTextBox>
        </td>
        <td>
            <asp:Label ID="lbllist" runat="server"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="txtlist" runat="server">
                <asp:ListItem Text="1" Value="1">

                </asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="btnok" runat="server"></JJson:JJsonButton>
        </td>
    </tr>
</table>