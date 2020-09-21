<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinishControl.ascx.cs" Inherits="WebLegal.Contract.Forms.FinishControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<table>
    <tr>
        <td>
            <JJson:JJsonTextBox ID="txtContractInfo" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="btnSave" runat="server" Event="click" /></td>
        <td><JJson:JJsonButton ID="btnBack" runat="server" Event="click" /></td>
        <td></td>
        <td><JJson:JJsonButton ID="btnCancel" runat="server" Event="click" /></td>
    </tr>
</table>
