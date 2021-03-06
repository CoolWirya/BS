﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JReferViewControl.ascx.cs" Inherits="WebAutomation.Refer.JReferViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="radTreeList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="radTreeList" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
    <script type="text/javascript">
        var _evt;
        function onResponseEnd(sender, eventArgs) {
            if (document.getElementById("EventType").value == 'RefreshTree') {
                var masterTable = $find("<%= radTreeList.ClientID %>").get_masterTableView();
                masterTable.rebind();
            }
            document.getElementById("EventType").value = 'none';
        }

        function onRequestStart(sender, eventArgs) {
        }

        function RefreshTree() {
            document.getElementById("EventType").value = 'RefreshTree';
            var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
            ajaxManager.ajaxRequest('');
        }

    </script>
</telerik:RadCodeBlock>--%>
<div runat="server" id="referView">
    <telerik:RadTreeList runat="server" ID="radTreeList" OnNeedDataSource="radTreeList_NeedDataSource" AutoGenerateColumns="true"
        ParentDataKeyNames="parent_code" DataKeyNames="Code" Dir="RTL"  OnAutoGeneratedColumnCreated="radTreeList_AutoGeneratedColumnCreated">
    </telerik:RadTreeList>
</div>
