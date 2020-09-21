<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JUserUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JUserUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<script type="text/javascript">
	$(document).ready(function () {
	    $('#<%= btnSave.ClientID%>').click(function () {
	        ShowWarining('در حال ذخیره اطلاعات...', true, 3, true);
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/SaveUser',
				//url: 'JJsonService/Services/WebBaseDefine/JWebBaseDefineServices.asmx/Save',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"username":"' + $('#<%= txtUsername.ClientID%>').val() + '"'
						+ ',"pass1":"' + $('#<%= txtPassword1.ClientID%>').val() + '"'
						+ ',"pass2":"' + $('#<%= txtPassword2.ClientID%>').val() + '"'
						+ ',"status":"' + $('#<%= cmbUserStatus.ClientID%>').val() + '"'
						+ ',"personCode":"' + $('#<%= jSearchPersonControl.ClientID%>_txtPersonCode').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
                //if(msg.success==true)
				    //GetRadWindow().BrowserWindow.RefreshGrid();
				    if(msg.d)
				        ShowWarining("ذخیره اطلاعات با موفقیت انجام شد", true, 4, true);
				    else
				        ShowWarining("خطا در انجام عملیات", true, 1, true);
					//CloseDialog(null);
				},
				error: function (xhr, status, error) {
				    var err = eval("(" + xhr.responseText + ")");
				    ShowWarining(err.Message, false, 1, true);
				}
			});
			return false;
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">کاربر</div>
	<table>
		<tr>
			<td class="Table_RowB">شخص / شرکت:</td>
			<td class="Table_RowC">
				<uc1:JSearchPersonControl runat="server" id="jSearchPersonControl" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">نام کاربری:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtUsername"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">کلمه عبور:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtPassword1" TextMode="Password"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">تکرار کلمه عبور:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtPassword2" TextMode="Password"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">وضعیت کاربر:</td>
			<td class="Table_RowC">
				<telerik:RadComboBox runat="server" ID="cmbUserStatus">
					<Items>
						<telerik:RadComboBoxItem Text="فعال" Value="1" />
						<telerik:RadComboBoxItem IsSeparator="true" />
						<telerik:RadComboBoxItem Text="غیرفعال" Value="0" />
					</Items>
				</telerik:RadComboBox>
				<%--<asp:DropDownList runat="server" ID="cmbUserStatus">
					<asp:ListItem Text="فعال" Value="1" />
					<asp:ListItem Text="غیرفعال" Value="0" />
				</asp:DropDownList>--%>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
