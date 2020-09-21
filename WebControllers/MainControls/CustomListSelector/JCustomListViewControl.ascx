<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCustomListViewControl.ascx.cs" Inherits="WebControllers.MainControls.JCustomListViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
            document.getElementById("EventType").value = 'GridRowDblClick';

            sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

            var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
            ajaxManager.ajaxRequest('');
        }
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdList" />
                <telerik:AjaxUpdatedControl ControlID="Hfsearch_query" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<input type="hidden" id="EventType" name="EventType" />
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<input type="hidden" runat="server" id="Hfsearch_query" name="Hfsearch_query" />
<table style="width: 100%">
    <tr>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSearch" Width="300px"></telerik:RadTextBox><telerik:RadButton runat="server" ID="btnSearch" Text="جستجو" OnClick="btnSearch_Click"></telerik:RadButton>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadButton runat="server" ID="btnSelect" Width="70px" Height="35px" Text="انتخاب" OnClick="btnSelect_Click"></telerik:RadButton>
            <telerik:RadGrid runat="server" ID="grdList" AutoGenerateColumns="true" OnNeedDataSource="grdList_NeedDataSource" OnPreRender="grdList_PreRender" 
                AllowFilteringByColumn="False" Width="100%" ActiveItemStyle-Width="100%"
                AllowSorting="True" GridLines="None" MasterTableView-DataKeyNames="Code">
                
                <ClientSettings>
                    <ClientEvents OnRowClick="RowClick" />
                    <Selecting AllowRowSelect="true"></Selecting>
                    
                </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
