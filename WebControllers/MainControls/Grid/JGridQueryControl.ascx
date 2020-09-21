<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGridQueryControl.ascx.cs" Inherits="WebControllers.MainControls.Grid.JGridQueryControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=SaveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/Grid/GridService.asmx/SaveGridQuery',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ ',"query":"' + $('#<%=QueryTextBox.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
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
	<div class="BigTitle">Grid Query</div>
	<table>
		<tr>
			<td>Query:
			</td>
			<td>
				<asp:TextBox runat="server" ID="QueryTextBox" TextMode="MultiLine" Width="400px" Height="300px" />
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SaveButton" Text="ثبت" AutoPostBack="false" Width="100px" Height="35px" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
