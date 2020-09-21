<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDeviceListControl.ascx.cs" Inherits="WebAVL.Controls.Search.JDeviceListControl" %>
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
			document.getElementById("<%=hdnRowId.ClientID%>").value = index;
		}
	</script>
</telerik:RadCodeBlock>

<input type="hidden" id="EventType" name="EventType" />
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<div style="position: relative; top: 0px; height: 40px; padding: 5px">
	<table>
		<tr>
			<td>
				<telerik:RadTextBox runat="server" ID="txtSearch" Width="200px"></telerik:RadTextBox>
			</td>
			<td style="width: 100px">
				<telerik:RadButton runat="server" ID="btnSearch" Text="جستجو" OnClick="btnSearch_Click" AutoPostBack="true"></telerik:RadButton>
			</td>
		</tr>
	</table>
</div>

<h3><asp:Label runat="server" ID="lblmessage" Visible="false" Text="با نگاه داشتن دکمه CTRL یا SHIFT می توانید چندین آیتم را انتخاب کنید."></asp:Label> </h3>
<div style="position: relative; top: 0px; bottom: 0px; height: auto; overflow-y: auto; overflow-x: hidden">
	<telerik:RadGrid runat="server" 
        ID="grdDevices" 
        AutoGenerateColumns="false" 
        AllowFilteringByColumn="False" 
        AllowMultiRowSelection="true"
     AllowPaging="true"
        Width="100%" 
        ActiveItemStyle-Width="100%"
		AllowSorting="True" 
        GridLines="None">
		<MasterTableView>
			<Columns>
				<telerik:GridBoundColumn UniqueName="Code" DataField="Code" HeaderText="کد" ItemStyle-Width="60px"></telerik:GridBoundColumn>
				<telerik:GridBoundColumn UniqueName="Name" DataField="Name" HeaderText="نام دستگاه" ItemStyle-Width="250px"></telerik:GridBoundColumn>
				<telerik:GridBoundColumn UniqueName="IMEI" DataField="IMEI" HeaderText="IMEI" ItemStyle-Width="250px"></telerik:GridBoundColumn>
			</Columns>
		</MasterTableView>
		<ClientSettings>
			<ClientEvents OnRowClick="RowClick" />
			<Selecting AllowRowSelect="true" ></Selecting>
		</ClientSettings>
	</telerik:RadGrid>
</div>
<div style="position: relative; bottom: 0px; height: 40px;">
	<telerik:RadButton runat="server" ID="btnSelect" Width="80px" Height="30px" Text="انتخاب" OnClick="btnSelect_Click"></telerik:RadButton>
	<asp:HiddenField runat="server" ID="hdnRowId" />
	<%--<asp:TextBox runat="server" ID="hdnRowId" CssClass="hdn1" />--%>
</div>
