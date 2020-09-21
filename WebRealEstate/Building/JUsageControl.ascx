<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JUsageControl.ascx.cs" Inherits="WebRealEstate.Building.JUsageControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td>
            لیست کاربری های تعریف شده :
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="gridUsersList" runat="server" ></telerik:RadGrid>
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="اضافه" />
        </td>
        <td>
            <asp:Button ID="btnDel" runat="server" Text="حذف" />
        </td>
        <td>

        </td>
    </tr>
</table>