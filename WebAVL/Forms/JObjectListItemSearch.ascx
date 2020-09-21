<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JObjectListItemSearch.ascx.cs" Inherits="WebAVL.Forms.JObjectListItemSearch" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function CallShowMenuObjectList() {
            ShowMenu('<%=(new WebClassLibrary.JActionsInfo("ObjectListItemSearch", WebClassLibrary.JDomains.JActionEvents.MouseClick, "AVL.Device.JDeviceModel.getObjectList",null,null)).ActionToString() %>{!::!}<%= txtCode.ClientID%>{!::!}<%=txtLabel.ClientID %>');
        }
    </script>
</telerik:RadCodeBlock>

<table>
    <tr>
        <th>کد</th>
        <th>برچسب</th>
        <th></th>
    </tr>
    <tr>        
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtCode" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtLabel" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 50px">
            <telerik:RadButton runat="server" ID="btnSearch" Text="یافتن متحرک" TabIndex="-1" AutoPostBack="false"></telerik:RadButton>
        </td>
    </tr>
</table>