<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InternalLetterControl.ascx.cs" Inherits="WebAutomation.Controls.InternalLetterControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridView1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridView1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadContextMenu1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridView1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadComboBox_Page">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadComboBox_Page" />
                <telerik:AjaxUpdatedControl ControlID="GridView1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadEditor ID="RadEditor1" runat="server" ToolbarMode="RibbonBar" ToolsFile="tools.xml"
    SkinID="DefaultSetOfTools">
</telerik:RadEditor>
