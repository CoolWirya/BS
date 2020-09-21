<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGridViewControl.ascx.cs" Inherits="WebControllers.MainControls.Grid.JGridViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<style type="text/css">
    
        
   
</style>
<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1"></telerik:RadAjaxManager>
<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
	<AjaxSettings>
		<%--    <telerik:AjaxSetting AjaxControlID="RadToolBar1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadToolBar2" />
                <telerik:AjaxUpdatedControl ControlID="pnlFilter" />
                <telerik:AjaxUpdatedControl ControlID="GridView1" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
		<%--   <telerik:AjaxSetting AjaxControlID="RadToolBar2">
            <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="RadToolBar1" />
                <telerik:AjaxUpdatedControl ControlID="pnlFilter" />
                <telerik:AjaxUpdatedControl ControlID="GridView1" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
		<telerik:AjaxSetting AjaxControlID="GridView1">
			<UpdatedControls>
				<telerik:AjaxUpdatedControl ControlID="pnlFilter" />
				<telerik:AjaxUpdatedControl ControlID="GridView1" />
				<telerik:AjaxUpdatedControl ControlID="lblFooter" />
			</UpdatedControls>
		</telerik:AjaxSetting>
		<telerik:AjaxSetting AjaxControlID="btnFilter">
			<UpdatedControls>

				<telerik:AjaxUpdatedControl ControlID="pnlFilter" />
				<telerik:AjaxUpdatedControl ControlID="GridView1" />
				<telerik:AjaxUpdatedControl ControlID="hfPageSize" />
			</UpdatedControls>
		</telerik:AjaxSetting>
		<telerik:AjaxSetting AjaxControlID="btnNoFilter">
			<UpdatedControls>

				<telerik:AjaxUpdatedControl ControlID="pnlFilter" />
				<telerik:AjaxUpdatedControl ControlID="GridView1" />
				<telerik:AjaxUpdatedControl ControlID="hfPageSize" />
			</UpdatedControls>
		</telerik:AjaxSetting>
	</AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
	<script type="text/javascript">
		var _evt;
		function RowDblClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();
			$find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("DoubleClick");

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
			    return;
			    alert('0');
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("radGridClickedRowIndex").value = index;
			//document.getElementById("EventType").value = 'GridRowDblClick';

			//sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);
			var vv = '<% if (GridView != null && GridView.Actions != null && GridView.Actions.Count > 0)
				{
					var q = GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemDblClick);
					if (q != null && q.Count() > 0)
					{
						Response.Write(q.First().ActionToString());
						// q.First().runAction();
					}
				} %>';
		    alert('0');

			CallShowMenu2(vv);
		}


        function RowRightClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();
			$find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RightClick");

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
			    return;
			    alert('0');
			  
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("radGridClickedRowIndex").value = index;
			//document.getElementById("EventType").value = 'GridRowDblClick';
  
			//sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);
			var vv = '<% if (GridView != null && GridView.Actions != null && GridView.Actions.Count > 0)
				{
					var q = GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.MouseRightClick);
					if (q != null && q.Count() > 0)
					{
						Response.Write(q.First().ActionToString());
						// q.First().runAction();
					}
				} %>';
alert('1');

			CallShowMenu2(vv);
		}






		function RowClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("radGridClickedRowIndex").value = index;
		}
		function RowContextMenu(sender, eventArgs) {
			var menu = $find("<%=RadContextMenu1.ClientID %>");

			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("radGridClickedRowIndex").value = index;
			document.getElementById("EventType").value = 'GridRowRightClick';

			sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

			var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
			ajaxManager.ajaxRequest('');
			_evt = evt;
		}

		function OnClientItemClicked(sender, args) {
			var item = args.get_item(),
                itemValue = item.get_value(),
                itemText = item.get_text();
			//alert(itemText);
			//alert(itemValue);
			CallShowMenu2(itemValue);
		}

		function onResponseEnd(sender, eventArgs) {
			if (document.getElementById("EventType").value == 'GridRowRightClick') {
				var menu = $find("<%=RadContextMenu1.ClientID %>");
				menu.show(_evt);
				_evt.cancelBubble = true;
				_evt.returnValue = false;

				if (_evt.stopPropagation) {
					_evt.stopPropagation();
					_evt.preventDefault();
				}
			}
			if (document.getElementById("EventType").value == 'RefreshGrid') {
				var masterTable = $find("<%= GridView1.ClientID %>").get_masterTableView();
				masterTable.rebind();
			}
			document.getElementById("EventType").value = 'none';
		}

		function onRequestStart(sender, eventArgs) {
		}

		function RefreshGrid() {
			document.getElementById("EventType").value = 'RefreshGrid';
			var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
			ajaxManager.ajaxRequest('');
		}
		function CallShowMenu(sender, eventArgs) {
			var button = eventArgs.get_item();

			var grid = $find("<%=GridView1.ClientID %>");
			var MasterTable = grid.get_masterTableView();
			var selectedRows = MasterTable.get_selectedItems();
			var param = '';
			if (selectedRows.length > 0) {
				var cell = MasterTable.getCellByColumnUniqueName(selectedRows[0], "Code")
				param = '{!::!}' + cell.innerHTML;
			}
			ShowMenu(button.get_value() + param);
		}
		function CallShowMenu2(v) {
			var grid = $find("<%=GridView1.ClientID %>");
			var MasterTable = grid.get_masterTableView();
			var selectedRows = MasterTable.get_selectedItems();
			var param = '';

			if (selectedRows.length > 0) {

				var cell = MasterTable.getCellByColumnUniqueName(selectedRows[0], "Code")
				if (cell != null)
					param = '{!::!}' + cell.innerHTML;
			}
			if (param != '')
				ShowMenu(v + param);
		}

		function Slide(dir) {
			if (dir == "up") {
				$("#<%=divSearch.ClientID %>").slideUp("slow");
				$("#divUp").css('display', 'none');
				$("#divDown").css('display', 'block');
			}
			else {
				$("#<%=divSearch.ClientID %>").slideDown("slow");
				$("#divDown").css('display', 'none');
				$("#divUp").css('display', 'block');
			}
		}

	    $(document).ready(function () {
	        $('.btnPrint').click(function () { ShowPrintPopup(); });
	        $('.close-reveal-modal').trigger('click:close');
	    });

	    function ShowPrintPopup() {
	        var ClassName = '<%=GridView!=null?GridView.ClassName:string.Empty%>';
	        var Query = "<%=GridView!=null?GridView.SQL.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "):string.Empty%>";
	        var SendData = JSON.stringify({ ClassName: ClassName, Query: Query });// .Replace(Environment.NewLine, " ") 
    	        $.ajax({
	            type: "POST",
	            url: 'Controls.aspx/Print',
	            data: SendData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            global: true,
	            error: function () {
	                //that.sh_error = true;
	            },
	            success: function (data) {
	                $('#a_print').trigger('click');
	                var dv_reveal_modal = document.getElementById('dv-reveal-modal');
	                var dv_print = document.getElementById('dv_print');
	                dv_print.innerHTML = data.d;
	                $(dv_reveal_modal).css({ 'width': '750px', 'hight': '500px', 'left': (document.body.clientWidth - (750)) / 2 - 40 + 'px' });
	                InsertParamsIntoHFs(0, "Report_Dt", ClassName)
	            }
	        });
	    }
	    function InsertParamsIntoHFs(ObjectCode, rSUID, ClassName)
	    { 
	        document.getElementById('hfObjectCode').value = ObjectCode;
	        document.getElementById('hfreportSUID').value = rSUID;
	        document.getElementById('hfClassName').value = ClassName;
	    }
    </script>
</telerik:RadCodeBlock>
<input type="hidden" id="PageNumber" name="PageNumber" />
<input type="hidden" id="EventType" name="EventType" />
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<%--<asp:UpdatePanel runat="server" ID="pnla">
    <ContentTemplate>--%>
<asp:HiddenField ID="hfPageSize" runat="server" />

<telerik:RadToolBar runat="server" ID="RadToolBar1" OnClientButtonClicked="CallShowMenu" RenderMode="Lightweight" EnableViewState="true"></telerik:RadToolBar>
<telerik:RadToolBar runat="server" ID="RadToolBar2" OnButtonClick="RadToolBar2_ButtonClick" RenderMode="Lightweight" EnableViewState="true"></telerik:RadToolBar>

<br />
<br />
<br />
<br />
<div onclick="Slide('down')" id="divDown" style="border: 1px solid #AAA; width: 99%; float: right; background-color: #EEE">
	<table>
		<tr>
			<td>
				<img src="../Images/Controls/arrow_down.png" /></td>
			<td>جستجو و فیلتر</td>
		</tr>
	</table>
</div>
<div onclick="Slide('up')" id="divUp" style="display: none; border: 1px solid #AAA; width: 99%; float: right; background-color: #EEE">
	<table>
		<tr>
			<td>
				<img src="../Images/Controls/arrow_up.png" /></td>
			<td>جستجو و فیلتر</td>
		</tr>
	</table>
</div>


<div id="divSearch" runat="server" style="height: auto; display: none; border: 1px solid #AAA; width: 99%; float: right; background-color: #F5F5F5">
	<asp:Panel runat="server" ID="pnlFilter">
		<table id="tblFilter" runat="server" enableviewstate="true" class="CustomTable">
		</table>

		<telerik:RadButton runat="server" ID="btnFilter" OnClick="btnFilter_Click" Text="فیلتر"></telerik:RadButton>
		<telerik:RadButton runat="server" ID="btnNoFilter" OnClick="btnNoFilter_Click" Text="حذف فیلتر"></telerik:RadButton>
	</asp:Panel>
</div>


<div style="margin-bottom: 20px;">
	<telerik:RadGrid ID="GridView1"
		runat="server"
		AllowSorting="true"
		GroupingEnabled="true"
		EnableHeaderContextMenu="true"
		Width="99%"
		AllowPaging="true"
		OnNeedDataSource="GridView1_NeedDataSource"
		AutoGenerateColumns="true"
		OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
		OnPageIndexChanged="GridView1_PageIndexChanged"
		EnableHeaderContextAggregatesMenu="true"
		GridLines="None"
		AllowCustomPaging="true"
		ShowGroupPanel="false"
		GroupPanel-Width="99%"
		ShowDesignTimeSmartTagMessage="true"
		OnColumnCreated="GridView1_ColumnCreated"
		OnCustomAggregate="GridView1_CustomAggregate"
		OnPageSizeChanged="GridView1_PageSizeChanged"
		OnLoad="GridView1_Load"
		ShowFooter="true" OnSortCommand="GridView1_SortCommand">
		<MasterTableView DataKeyNames="Code">
			<DetailTables>
				<telerik:GridTableView DataKeyNames="Code" Name="grdDetail" Width="100%" Enabled="false">
				</telerik:GridTableView>
			</DetailTables>
			<GroupFooterTemplate>
			</GroupFooterTemplate>
		</MasterTableView>

		<ClientSettings ReorderColumnsOnClient="true" Selecting-AllowRowSelect="true"
			AllowColumnsReorder="true" ColumnsReorderMethod="Reorder" AllowColumnHide="true" AllowRowHide="true" AllowGroupExpandCollapse="true">
			<ClientEvents OnRowContextMenu="RowContextMenu" OnRowDblClick="RowDblClick" OnRowClick="RowClick" /><%-- OnRowRightClick="RowRightClick"--%>
			<%-- <Scrolling AllowScroll="false" UseStaticHeaders="true" EnableVirtualScrollPaging="true" SaveScrollPosition="true" ScrollHeight="500px" />--%>

			<Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" AllowResizeToFit="true" EnableRealTimeResize="true" ClipCellContentOnResize="true" />

		</ClientSettings>
		<PagerStyle Mode="NextPrevNumericAndAdvanced" PageSizeControlType="RadComboBox"></PagerStyle>



		<%-- <FilterItemStyle Width="25px" />--%>
	</telerik:RadGrid>
	<asp:Label ID="lblFooter" runat="server"></asp:Label>
</div>

<%--OnItemClick="RadContextMenu1_ItemClick"--%>
<telerik:RadContextMenu runat="server" ID="RadContextMenu1" OnClientItemClicked="OnClientItemClicked" EnableShadows="True" EnableRoundedCorners="True" EnableViewState="False">
	<Items>
		<telerik:RadMenuItem runat="server" Text="ssss"></telerik:RadMenuItem>
	</Items>
</telerik:RadContextMenu>
<telerik:RadGrid runat="server" ID="radGridForPrint" Visible="false" EnableViewState="false">
</telerik:RadGrid>
<div runat="server" id="divWindows"></div>


<%-- </ContentTemplate>
</asp:UpdatePanel>--%>


<%--<table  cellspacing='0' cellpading='0'  border='0' style='padding: 0px; margin: 0px; border-width: 0px;  width:100%; '  ><tr><td style='width: 45px;' dir="rtl">جمع:</td></tr><tr><td style='text-align:left; '>" + SumFieldsPage[e.Column.UniqueName] + "</td></tr>";
                (e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td>جمع-کل:</td></tr><tr><td style='text-align:left; '>" + SumFields[e.Column.UniqueName] + "</td></tr>";
                (e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td>تاریخ:</td></tr><tr><td style='text-align:left; '> " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now.Date) + "</td></tr>";
                (e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td>ساعت:</td></tr><tr><td style='text-align:left; '>" + DateTime.Now.ToShortTimeString() + "</td></tr></table>"--%>