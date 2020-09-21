<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JointFormControl.ascx.cs" Inherits="WebRealEstate.Building.Joint.JointFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=SaveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebRealEstateService.asmx/AddJoint',
				data: '{'
						+ '"code":"' + $('#<%=txtCode.ClientID%>').val() + '"'
						+ ',"type":"' + $('#<%=txtType.ClientID%>').val() + '"'
						+ ',"marketCode":"' + $('#<%=cmbComplex.ClientID%>').val() + '"'
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
	<asp:HiddenField ID="UserPostCodeHiddenField" runat="server" />
	<div class="BigTitle">مجوزها</div>
	<table>
		<tr>
			<td class="Table_RowB">شماره: </td>
			<td class="Table_RowC">
				<JJson:JNumericTextBox ID="txtCode" runat="server" ReadOnly="true"></JJson:JNumericTextBox></td>
			<td></td>
		</tr>
		<tr>
			<td class="Table_RowB">عنوان: </td>
			<td class="Table_RowC">
				<asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
			<td></td>
		</tr>
		<tr>
			<td class="Table_RowB">مجتمع: </td>
			<td class="Table_RowC">
				<asp:DropDownList ID="cmbComplex" runat="server"></asp:DropDownList></td>
			<td></td>
		</tr>
		<%--<tr>
		<td>
			<JJson:JJsonButton runat="server" Text="ثبت" ID="btnOK" Event="click"></JJson:JJsonButton></td>

		<td>
			<JJson:JJsonButton runat="server" Text="تعیین مالک پیش فرض" ID="btnSetDefaultOwner" Event="click"></JJson:JJsonButton></td>
		</td>
        <td></td>
	</tr>--%>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SaveButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
