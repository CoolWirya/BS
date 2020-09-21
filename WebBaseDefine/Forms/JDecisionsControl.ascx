<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDecisionsControl.ascx.cs" Inherits="WebBaseDefine.Forms.JDecisionsControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
	    $('#<%=SaveButton.ClientID%>').click(function () {
	        ShowWarining('در  حال بارگذاری ...', true, 3, true);
			$.ajax({
				type: 'POST',
				url: 'Services/WebBaseDefineService.asmx/AddDecision',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"decisionName":"' + $('#<%=DecisionTextBox.ClientID%>').val() + '"'
						+ ',"classCode":"' + '<%= Request["ClassCode"]!=null?Request["ClassCode"].ToString():null%>' + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
				    ShowWarining('ذخیره با موفقیت انجام شد', false, 4, true);
				},
				error: function (err) {
				    ShowWarining('دوباره تلاش کنید', false, 1, true);
				}
			});
			return false;
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">تصمیمات</div>
	<table>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">تصمیم:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="DecisionTextBox"></asp:TextBox></td>
		</tr>
	</table>
	<%--<table>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="DecisionButton" Text="افزودن تصمیم" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
			</td>
		</tr>
	</table>
	<div style="height: 300px; overflow-y: auto">
		<asp:GridView runat="server" ID="DecisionsGridView" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField DataField="Code" HeaderText="کد" HeaderStyle-HorizontalAlign="Center">
					<ItemStyle HorizontalAlign="Center" Width="100px" />
				</asp:BoundField>
				<asp:BoundField DataField="Name" HeaderText="نام" HeaderStyle-HorizontalAlign="Center">
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
<%--<div style="display: none" id="DecisionDiv">
	<table>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">کلاس:</td>
			<td class="Table_RowC">
				<asp:DropDownList runat="server" ID="GroupClassDropDownList" Height="24px" Width="300px" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB" style="vertical-align: top">تصمیم:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="DecisionTextBox"></asp:TextBox></td>
		</tr>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="AddDecisionButton" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
			</td>
			<td>
				<telerik:RadButton runat="server" ID="CloseDecisionButton" Text="بازگشت" AutoPostBack="false" Width="100px" Height="35px" />
			</td>
		</tr>
	</table>
</div>--%>
