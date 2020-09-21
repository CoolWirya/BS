<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSuccessorUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JSuccessorUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=SuccessorsGridView.ClientID%> tr').css({ "background-color": "White", "color": "Black" });
		if (window.location.href.indexOf("evt_idx") >= 0)
			$('#<%=SuccessorsGridView.ClientID%> tr:eq(' + (Number(((window.location.href.split('?')[1]).split('&')[2]).split('=')[1]) + 1) + ')').css({ "background-color": "Black", "color": "White" });
		$('#<%=SuccessorsGridView.ClientID%> tr[idx]').click(function () {
			//$(this).css({ "background-color": "White", "color": "Black" });
			//$(this).css({ "background-color": "Black", "color": "White" });
			$('#<%=SuccessorsGridView.ClientID%> tr').each(function () {
				$(this).css({ "background-color": "White", "color": "Black" });
			});
			window.location.href = window.location.href.split('?')[0] + '?SUID=Successor' + '&evt=SuccessorsGridView_SelectedIndexChanged&evt_idx=' + $(this).attr("idx");
		});
		$('#<%=SuccessorsGridView.ClientID%> tr[idx]').mouseover(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
			//$(this).css({ "background-color": "Black", "color": "White" });
		});
		$('#<%=SuccessorsGridView.ClientID%> tr[idx]').mouseout(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
			//$(this).css({ "background-color": "White", "color": "Black" });
		});
		$('#<%=PermissionsCheckBoxList.ClientID%> :input').change(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/SuccessorPermission',
				data: '{'
						+ '"objectCode":"' + $(this).val() + '"'
						+ ',"userPostCode":"' + $('#<%= UserPostCodeHiddenField.ClientID%>').val() + '"'
						+ ',"fromDate":"' + $('#<%= FromDateJDateControl.ClientID%>_PersianDateTextBox1').val() + '"'
						+ ',"toDate":"' + $('#<%= ToDateJDateControl.ClientID%>_PersianDateTextBox1').val() + '"'
						+ ',"status":"' + $(this).attr("checked") + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					//window.location.href = window.location.href.split('?')[0] + '?SUID=Successor';
					alert(msg.d);
				},
				error: function (err) {
					alert("خطا در اجرا");
					//alert(err.responseText);
				}
			});
		});
		$('#<%= SaveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/SaveSuccessor',
				data: '{'
						+ '"code":"' + '<%= Request["Code2"]!=null?Request["Code2"].ToString():null%>' + '"'
						+ ',"postCode":"' + $('#<%= ReferInternalComboBox.ClientID%>').val() + '"'
						+ ',"fromDate":"' + $('#<%= FromDateJDateControl.ClientID%>_PersianDateTextBox1').val() + '"'
						+ ',"toDate":"' + $('#<%= ToDateJDateControl.ClientID%>_PersianDateTextBox1').val() + '"'
						+ ',"status":"' + $('#<%= StatusCheckBox.ClientID%>').attr("checked") + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					window.location.href = window.location.href.split('?')[0] + '?SUID=Successor';
					alert(msg.d);
				},
				error: function (err) {
					alert("خطا در اجرا");
					//alert(err.responseText);
				}
			});
			return false;
		});
	});
</script>
<div class="FormContent">
	<asp:HiddenField ID="UserPostCodeHiddenField" runat="server" />
	<div class="BigTitle">جانشین</div>
	<table>
		<tr>
			<td class="Table_RowB">جانشین:</td>
			<td class="Table_RowC" colspan="7">
				<asp:DropDownList runat="server" ID="ReferInternalComboBox" Height="24px" Width="300px" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">از تاریخ:</td>
			<td class="Table_RowC">
				<uc1:JDateControl runat="server" id="FromDateJDateControl" />
			</td>
			<td class="Table_RowB">تا تاریخ:</td>
			<td class="Table_RowC">
				<uc1:JDateControl runat="server" id="ToDateJDateControl" />
			</td>
			<td class="Table_RowC">
				<asp:CheckBox Text="فعال" ID="StatusCheckBox" runat="server" />
			</td>
		</tr>
		<tr>
			<td colspan="3" valign="top">
				<asp:GridView runat="server" ID="SuccessorsGridView" AutoGenerateColumns="False" OnRowDataBound="SuccessorsGridView_RowDataBound">
					<Columns>
						<asp:BoundField DataField="Successer_post_code1" HeaderText="جانشین">
							<ItemStyle Width="300px" />
						</asp:BoundField>
						<asp:BoundField DataField="start_date_time" HeaderText="تاریخ شروع" />
						<asp:BoundField DataField="end_date_time" HeaderText="تاریخ پایان" />
						<asp:BoundField DataField="Code" HeaderText="تاریخ پایان" />
						<asp:BoundField DataField="Successer_post_code" HeaderText="تاریخ پایان" />
						<asp:BoundField DataField="Person_post_code" HeaderText="تاریخ پایان" />
						<asp:BoundField DataField="Active" HeaderText="تاریخ پایان" />
					</Columns>
				</asp:GridView>
			</td>
			<td class="Table_RowC" colspan="2">
				<asp:CheckBoxList runat="server" ID="PermissionsCheckBoxList" Height="333px" Width="300px" AutoPostBack="false" />
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SaveButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
