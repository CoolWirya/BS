<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeviceModelSearch.ascx.cs" Inherits="WebAVL.Forms.DeviceModelSearch" %>



<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script src="WebControllers/FormManager/Js/jquery-1.8.2.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.min.js"></script>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtPersonCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtCompany" />
                <telerik:AjaxUpdatedControl ControlID="txtYear" />
                <telerik:AjaxUpdatedControl ControlID="txtModel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function CallShowMenu() {
            ShowMenu('<%=(new WebClassLibrary.JActionsInfo("DeviceModelSearch", WebClassLibrary.JDomains.JActionEvents.MouseClick, "AVL.Device.JDeviceModel.GetPersonWindow",null,null)).ActionToString() %>{!::!}<%=txtCompany.ClientID %>{!::!}<%=txtModel.ClientID %>{!::!}<%=txtYear.ClientID %>{!::!}<%=txtCode.ClientID %>');
        }
    </script>
</telerik:RadCodeBlock>
<table>
    <tr>
        <td>
            کد
        </td>
        <td>
            سال
        </td>
        <td>
            شرکت سازنده
        </td>
        <td>
            مدل
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td style="width: 70px">
           <JJson:JJsonNumericTextBox ID="txtCode" CssClass ="personCode" Width="70px" runat="server" ReadOnly="true"></JJson:JJsonNumericTextBox>
        </td>
        <td style="width: 70px">
           <JJson:JJsonNumericTextBox ID="txtYear" CssClass ="personCode" Width="70px" runat="server" ReadOnly="true"></JJson:JJsonNumericTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtCompany" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtModel" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 50px">
            <telerik:RadButton runat="server" ID="btnSearch" Text="انتخاب مدل" TabIndex="-1" AutoPostBack="false"></telerik:RadButton>
        </td>
    </tr>
</table>
