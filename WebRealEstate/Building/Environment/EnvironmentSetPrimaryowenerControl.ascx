<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EnvironmentSetPrimaryowenerControl.ascx.cs" Inherits="WebRealEstate.Building.EnvironmentSetPrimaryowener.EnvironmentSetPrimaryowenerControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td>مجتمع :</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>مالک :</td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox1" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton1" runat="server" Event="click"  Text="انتخاب مالک مشاعات"/></td>
    </tr>
    <tr>
        <td>نماینده قرارداد :</td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox2" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton2" runat="server" Event="click" Text="انتخاب نماینده قرارداد" /></td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JJsonButton3" runat="server" Event="click"  Text="تایید" Width="73px"/></td>
    </tr>
</table>
