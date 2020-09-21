<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGroupControl.ascx.cs" Inherits="WebBaseDefine.Forms.JGroupControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=SaveButton.ClientID%>').click(function() {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/AddGroup',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"groupName":"' + $('#<%=GroupNameTextBox.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					GetRadWindow().BrowserWindow.RefreshGrid();
					CloseDialog(null);
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
	<div class="BigTitle">کلاس های گروه</div>
	<table>
		
		<tr>
			<td class="Table_RowB">نام گروه:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="GroupNameTextBox" />
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SaveButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
