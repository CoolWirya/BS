<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JClassesControl.ascx.cs" Inherits="WebBaseDefine.Forms.JClassesControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=SaveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/AddClass',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"className":"' + $('#<%=ClassNameTextBox.ClientID%>').val() + '"'
						+ ',"sql":"' + $('#<%=SQLTextBox.ClientID%>').val() + '"'
						+ ',"parentCode":"' + $('#<%=GroupDropDownList.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
				    if (msg.d)
				        ShowWarining("ذخیره اطلاعات با موفقیت انجام شد", true, 4, true);
				    else
				        ShowWarining("نام کلاس تکراری است", true, 1, true);
					//GetRadWindow().BrowserWindow.RefreshGrid();
					//CloseDialog(null);
					//GetRadWindow().BrowserWindow.document.location.href = GetRadWindow().BrowserWindow.document.location.href.split['?'][0] + '?prj=' + $('#<%=GroupDropDownList.ClientID%>').val();
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
			return false;
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">کلاس ها</div>
	<table>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">پروژه:</td>
			<td class="Table_RowC">
				<asp:DropDownList runat="server" ID="GroupDropDownList" Height="24px" Width="400px" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">نام کلاس:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="ClassNameTextBox" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">SQL:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="SQLTextBox" TextMode="MultiLine" Height="224px" Width="237px"></asp:TextBox></td>
		</tr>
		<%--		<tr>
			<td>
				<telerik:RadButton runat="server" ID="RadButton1" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
			</td>
			<td>
				<telerik:RadButton runat="server" ID="RadButton2" Text="بازگشت" AutoPostBack="false" Width="100px" Height="35px" />
			</td>
		</tr>--%>
	</table>
	<%--<table>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="ClassButton" Text="افزودن کلاس" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
			</td>
		</tr>
	</table>
	<div style="height: 300px; overflow-y: auto">
		<asp:GridView runat="server" ID="ClassesGridView" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField DataField="Code" HeaderText="کد" HeaderStyle-HorizontalAlign="Center">
					<ItemStyle HorizontalAlign="Center" Width="100px" />
				</asp:BoundField>
				<asp:BoundField DataField="ClassName" HeaderText="نام کلاس" HeaderStyle-HorizontalAlign="Center">
					<ItemStyle HorizontalAlign="Center" Width="150px" />
				</asp:BoundField>
				<asp:BoundField DataField="SQL" HeaderText="SQL" HeaderStyle-HorizontalAlign="Center">
					<ItemStyle HorizontalAlign="Center" Width="150px" />
				</asp:BoundField>
				<asp:BoundField DataField="ParentCode" HeaderText="ParentCode" HeaderStyle-HorizontalAlign="Center">
					<ItemStyle HorizontalAlign="Center" Width="150px" />
				</asp:BoundField>
			</Columns>
		</asp:GridView>
	</div>--%>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SaveButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<%--<div style="display: none" id="ClassDiv">
	<table>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">پروژه:</td>
			<td class="Table_RowC">
				<asp:DropDownList runat="server" ID="GroupDropDownList" Height="24px" Width="400px" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">نام کلاس:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="ClassNameTextBox" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">SQL:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="SQLTextBox" TextMode="MultiLine" Height="224px" Width="237px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="AddClassButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
			</td>
			<td>
				<telerik:RadButton runat="server" ID="CloseClassButton" Text="بازگشت" AutoPostBack="false" Width="100px" Height="35px" />
			</td>
		</tr>
	</table>
</div>--%>
