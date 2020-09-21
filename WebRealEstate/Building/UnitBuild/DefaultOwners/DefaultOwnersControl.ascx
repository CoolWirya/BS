<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultOwnersControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.DefaultOwners.DefaultOwnersControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="JComponents" Namespace="JComponents" TagPrefix="cc1" %>
<script type="text/javascript">
	$(document).ready(function () {
		$("#OwnerDiv").dialog({
			autoOpen: false,
			modal: true,
			show: {
				effect: "blind",
				duration: 300
			},
			hide: {
				effect: "blind",
				duration: 300
			},
			width: 400,
			height: 300
		});
		$("#OwnerDiv").parent().appendTo($("form:first"));
		$("#<%= AddButton.ClientID%>").click(function (event) {
			$("#OwnerDiv").dialog("open");
		});
		$("#<%= OwnerCloseButton.ClientID %>").click(function (event) {
			$("#OwnerDiv").dialog("close");
		});
		$("#<%= OwnerSelectButton.ClientID %>").click(function (event) {
			$.ajax({
				type: 'POST',
				url: 'Services/WebRealEstateService.asmx/AddOwner',
				data: '{'
						+ '"code":"' + $('#<%=SelectedOwnerHiddenField.ClientID%>').val() + '"'
						+ ',"pCode":"' + $('#<%=person.ClientID%>').val() + '"'
						+ ',"shareCount":"' + $('#<%=ShareCountNumericTextBox.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					if (msg.d != 'Error') {
						alert(msg.d);
						window['<%=OwnersDGV.ClientID%>GetTablePager'](<%=OwnersDGV.ClientID%>_query, $("#<%=OwnersDGV.ClientID%>").find('#_LastOpenedPage').val(), '<%=OwnersDGV.PageSize%>', $("#<%=OwnersDGV.ClientID%>").find('#_LastSortingField').val().split('|')[0], $("#<%=OwnersDGV.ClientID%>").find('#_LastSortingField').val().split('|')[1]);
						$("#OwnerDiv").dialog("close");
					}
					else
						alert("خطا در اجرای عملیات. لطفا دوباره سعی کنید...!");
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
		});
		$("#<%= DeleteButton.ClientID %>").click(function (event) {
			$.ajax({
				type: 'POST',
				url: 'Services/WebRealEstateService.asmx/RemoveOwner',
				data: '{'
						+ '"code":"' + $('#<%=SelectedOwnerHiddenField.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					if (msg.d != 'Error') {
						alert(msg.d);
						window['<%=OwnersDGV.ClientID%>GetTablePager'](<%=OwnersDGV.ClientID%>_query, $("#<%=OwnersDGV.ClientID%>").find('#_LastOpenedPage').val(), '<%=OwnersDGV.PageSize%>', $("#<%=OwnersDGV.ClientID%>").find('#_LastSortingField').val().split('|')[0], $("#<%=OwnersDGV.ClientID%>").find('#_LastSortingField').val().split('|')[1]);
						$("#OwnerDiv").dialog("close");
					}
					else
						alert("خطا در اجرای عملیات. لطفا دوباره سعی کنید...!");
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
		});
	});
</script>
<div class="FormContent">
	<asp:HiddenField runat="server" ID="SelectedOwnerHiddenField" />
	<div class="BigTitle">مالکین پیش فرض</div>
	<table>
		<tr>
			<td class="Table_RowC" style="vertical-align: top">
				<cc1:DataGridView ID="OwnersDGV" runat="server" />
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="AddButton" Text="اضافه" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="DeleteButton" Text="حذف" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="OwnerDiv">
	<table>
		<tr>
			<td class="Table_RowC">شخص:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="person" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowC">تعداد سهم:</td>
			<td class="Table_RowC">
				<JJson:JNumericTextBox ID="ShareCountNumericTextBox" runat="server"></JJson:JNumericTextBox>
			</td>
		</tr>
	</table>
	<br />
	<telerik:RadButton runat="server" ID="OwnerSelectButton" Text="تایید" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="OwnerCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
