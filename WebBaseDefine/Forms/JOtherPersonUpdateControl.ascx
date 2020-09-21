<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOtherPersonUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JOtherPersonUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%= btnSave.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/SaveOtherPerson',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"title":"' + $('#<%= txtTitle.ClientID%>').val() + '"'
						+ ',"tel":"' + $('#<%= txtTel.ClientID%>').val() + '"'
						+ ',"address":"' + $('#<%= txtAddress.ClientID%>').val() + '"'
						+ ',"desc":"' + $('#<%= txtDesc.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					GetRadWindow().BrowserWindow.RefreshGrid();
					CloseDialog(null);
				},
				error: function (err) {
					//alert("خطا در اجرا");
					alert(err.responseText);
				}
			});
			return false;
		});
	});
</script>
<div class="FormContent">
	<%--<div class="BigTitle">کاربر</div>--%>
	<table>
		<tr>
			<td class="Table_RowB">کد:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" Enabled="false" ID="txtCode"></telerik:RadTextBox>
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">عنوان:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtTitle"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">تلفن:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtTel"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">آدرس:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtAddress" TextMode="MultiLine"></telerik:RadTextBox>
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">توضیحات:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtDesc" TextMode="MultiLine"></telerik:RadTextBox>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
