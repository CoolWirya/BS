<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAssetSearchControl.ascx.cs" Inherits="WebFinance.Asset.JAssetSearchControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
	<script type="text/javascript">
		function RowDblClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("<%=hdnRowId.ClientID%>").value = index;
			sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

			var ajaxManager = $find("");
			ajaxManager.ajaxRequest('');
		}
		function RowClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			document.getElementById("<%=hdnRowId.ClientID%>").value = index;
		}
	</script>
</telerik:RadCodeBlock>
<table>
	<tr>
		<td>نوع دارایی:
		</td>
		<td>
			<asp:DropDownList runat="server" ID="cmbAssetType"></asp:DropDownList>
		</td>
		<td></td>
		<td>جستجو در عنوان:
		</td>
		<td>
			<asp:TextBox runat="server" ID="txtComment" />
		</td>
		<td></td>
		<td>
			<asp:Button Text="جستجو" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
		</td>
	</tr>
</table>
<telerik:RadGrid runat="server" ID="gvAssets" AllowSorting="True">
	<clientsettings>
		<ClientEvents OnRowClick="RowClick" />
		<Selecting AllowRowSelect="true"></Selecting>
	</clientsettings>
</telerik:RadGrid>
<%--<asp:HiddenField runat="server" ID="hdnRowId" />--%>
<asp:TextBox runat="server" ID="hdnRowId" />