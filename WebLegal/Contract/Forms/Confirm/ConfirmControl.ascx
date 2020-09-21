<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmControl.ascx.cs" Inherits="WebLegal.Contract.Forms.Confirm.ConfirmControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td>
            <asp:CheckBox ID="JchkSignS" runat="server" /></td>
        <td></td>
        <td><asp:CheckBox ID="JchkSignB" runat="server" /></td>
        <td></td>
        <td>
            <asp:CheckBox ID="JchkSignSh" runat="server" /></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JbtnAgree" runat="server" Event="click" /></td>
        <td>
            <JJson:JJsonButton ID="JbtnSave" runat="server" Event="click" />
        </td>
        <td></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JbtnExit" runat="server" Event="click" />
        </td>
    </tr>
</table>
