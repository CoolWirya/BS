<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JActivityandEventPairingControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JActivityandEventPairingControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">مرتبط سازی فعالیت و وقایع</div>
<table style="width: 500px">
    <tr class="Table_RowA">
        <td style="width: 150px">واقعه:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="cmbBusEvent" Width="100%" Filter="Contains"></telerik:RadComboBox>
            </td>
    </tr>
    <tr class="Table_RowA">
        <td style="width: 150px">فعالیت:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="cmbActivity" Width="100%" Filter="Contains"></telerik:RadComboBox>
            </td>
    </tr>
</table>
<%--sssss--%>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>