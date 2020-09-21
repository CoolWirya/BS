<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSubDefineUpdateControl.ascx.cs" Inherits="WebControllers.MainControls.Grid.JSubDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!--
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=btnSave.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'WebControllers/MainControls/Grid/SubDefineService.asmx/SaveSubDefine',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"bCode":"' + $('#<%=BCodeHiddenField.ClientID%>').val() + '"'
						+ ',"text":"' + $('#<%=txtName.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					GetRadWindow().BrowserWindow.RefreshGrid();
					CloseDialog(null);
				},
				error: function (err) {
					alert("خطا در اجرا");
					alert(err.responseText);
				}
			});
			return false;
		});
		$('#<%=btnDelete.ClientID%>').click(function () {
			if (!confirm("از حذف این آیتم مطمئن هستید؟"))
				return;
			$.ajax({
				type: 'POST',
				url: 'WebControllers/MainControls/Grid/SubDefineService.asmx/DeleteSubDefine',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"bCode":"' + $('#<%=BCodeHiddenField.ClientID%>').val() + '"'
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
    -->
<asp:HiddenField runat="server" ID="BCodeHiddenField" />
<div class="FormContent">
    <div class="BigTitle">تعاریف</div>
    <table style="width: 500px">
        <tr class="Table_RowB">
            <td style="width: 150px">نام:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtName" Width="96%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="Zone" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px"  ValidationGroup="Zone" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true"  Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" /><%-- OnClientClicking="OnClientClicking" />--%>
</div>
