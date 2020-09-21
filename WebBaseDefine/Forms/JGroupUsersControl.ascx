<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGroupUsersControl.ascx.cs" Inherits="WebBaseDefine.Forms.JGroupUsersControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc2" %>
<%--<%@ Register Assembly="JComponents" Namespace="JComponents" TagPrefix="cc1" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		function getAllUsersData() {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/GetAllUsersPosts',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString()+"_AllUsers":null%>' + '"'
							+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
							+ ',"parameters":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
							+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					FillListControl('<%= AllUsersPostsListBox.ClientID%>', msg, "code", "full_title");
				},
				error: function (err) {
					alert(err.responseText);
				}
			});
			}
		function getGroupUsersData() {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/GetGroupUsersPosts',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString()+"_GroupUsers":null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ ',"parameters":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					FillListControl('<%= GroupUsersPostsListBox.ClientID%>', msg, "code", "full_title");
				},
				error: function (err) {
					alert(err.responseText);
				}
			});
			}

		function addUserToGroup(groupCode, userPostCode) {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/AddUserToGroup',
				data: '{'
							+ '"groupCode":"' + groupCode + '"'
							+ ',"userPostCode":"' + userPostCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					getAllUsersData();
					getGroupUsersData();
				},
				error: function (err) {
					alert(err.responseText);
				}
			});
		}

		function removeUserFromGroup(groupCode, userPostCode) {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/RemoveUserFromGroup',
				data: '{'
							+ '"groupCode":"' + groupCode + '"'
							+ ',"userPostCode":"' + userPostCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					getAllUsersData();
					getGroupUsersData();
				},
				error: function (err) {
					alert(err.responseText);
				}
			});
		}

		getAllUsersData();
		getGroupUsersData();

		$('#<%= GroupUsersPostsListBox.ClientID%>').dblclick(function () {
			$(this).find('option:selected').each(function () {
				removeUserFromGroup('<%= Request["Code"]!=null?Request["Code"].ToString():null%>', $(this).val());
			});
		});
		$('#<%= AllUsersPostsListBox.ClientID%>').dblclick(function () {
			$(this).find('option:selected').each(function () {
				addUserToGroup('<%= Request["Code"]!=null?Request["Code"].ToString():null%>', $(this).val());
			});
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">کاربران گروه</div>
	<table>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">همه کاربران:</td>
			<td class="Table_RowC" style="vertical-align: top">
				<%--<cc1:DataGridView ID="AllUsersDGV" runat="server" />--%>
				<%--<cc2:JGridView ID="AllUsersDGV" runat="server"></cc2:JGridView>--%>
				<asp:ListBox runat="server" ID="AllUsersPostsListBox" Width="400px" Height="500px"></asp:ListBox>
			</td>
			<%--</tr>
		<tr>--%>
			<td class="Table_RowB" style="vertical-align: top">کاربران گروه:</td>
			<td class="Table_RowC" style="vertical-align: top">
				<%--<cc1:DataGridView ID="GroupUsersDGV" runat="server" />--%>
				<%--<cc2:JGridView ID="GroupUsersDGV" runat="server"></cc2:JGridView>--%>
				<asp:ListBox runat="server" ID="GroupUsersPostsListBox" Width="400px" Height="500px"></asp:ListBox>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
