<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSearchDevice.ascx.cs" Inherits="WebAVL.Controls.Search.JSearchDevice" %>

<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<script src="WebControllers/FormManager/Js/jquery-1.8.2.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.min.js"></script>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtPersonCode">
            <UpdatedControls>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function CallShowMenu() {
            ShowMenu('<%=(new WebClassLibrary.JActionsInfo("JDeviceList", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebAVL.Controls.Search.JDeviceLists.GetPersonWindow",null,null)).ActionToString() %>{!::!}<%=txtImei.ClientID %>{!::!}<%=txtName.ClientID %>{!::!}<%=txtCode.ClientID %>{!::!}<%= this.MultipleSelection.ToString() %>');
        }
    </script>
</telerik:RadCodeBlock>
<table>
    <tr>
        <td>
            کد
        </td>
        <td>
            نام دستگاه 
        </td>
        <td>
            IMEI
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td style="width: 70px">
         <telerik:RadTextBox ID="txtCode" CssClass ="personCode" Width="70px" runat="server" ReadOnly="true" ></telerik:RadTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtName" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true" ></telerik:RadTextBox>
        </td>
        <td style="width: 70px">
            <telerik:RadTextBox ID="txtImei" CssClass ="personCode" Width="70px" runat="server" ReadOnly="true" >  </telerik:RadTextBox>
        </td>
        <td style="width: 50px">
            <telerik:RadButton runat="server" ID="btnSearch" Text="انتخاب دستگاه" TabIndex="-1" AutoPostBack="false" ></telerik:RadButton>
        </td>
    </tr>
    <tr>
        <td colspan="4">
           <telerik:RadGrid runat="server" on 
        ID="grdDevices" 
        AutoGenerateColumns="true" 
        AllowFilteringByColumn="False" 
        AllowMultiRowSelection="true"
     AllowPaging="true"
        Width="100%" 
        ActiveItemStyle-Width="100%"
		AllowSorting="True" 
        GridLines="None">
               
	</telerik:RadGrid>
        </td>
    </tr>
</table>