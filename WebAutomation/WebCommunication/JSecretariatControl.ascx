<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSecretariatControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JSecretariatControl" %>
<%@ Register Assembly="JComponents" Namespace="JComponents" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		
		$('#<%= OkButton.ClientID%>').click(function () {
			
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/SaveSecretariat',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"managerPostCode":"' + $('#<%= ManagerAutoCompleteTextBox.ClientID%>').val() + '"'
						+ ',"name":"' + $('#<%= NameTextBox.ClientID%>').val() + '"'
						+ ',"prefix":"' + $('#<%= PrefixTextBox.ClientID%>').val() + '"'
						+ ',"postfix":"' + $('#<%= PostFixTextBox.ClientID%>').val() + '"'
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
	<div class="BigTitle">فرم مدیریت دبیرخانه</div>
	<telerik:RadTabStrip runat="server" ID="SecretariatRadTabStrip" MultiPageID="SecretariatRadMultiPage" Width="500px">
		<Tabs>
			<telerik:RadTab Text="دبیرخانه" Value="Secretariat" PageViewID="SecretariatRadTab" Selected="True">
			</telerik:RadTab>
			<telerik:RadTab Text="کاربران" Value="Users" PageViewID="UsersRadTab">
			</telerik:RadTab>
		</Tabs>
	</telerik:RadTabStrip>
	<telerik:RadMultiPage runat="server" ID="SecretariatRadMultiPage" SelectedIndex="0">
		<telerik:RadPageView runat="server" ID="SecretariatRadTab">
			<table>
				<tr>
					<td class="Table_RowB" style="vertical-align: top">نام:
					</td>
					<td class="Table_RowC" colspan="3">
						<asp:TextBox runat="server" ID="NameTextBox" />
					</td>
				</tr>
				<tr>
					<td class="Table_RowB" style="vertical-align: top">پیشوند:
					</td>
					<td class="Table_RowC" style="margin-right: 50px">
						<asp:TextBox runat="server" ID="PrefixTextBox" />
					</td>
					<td class="Table_RowB" style="vertical-align: top">پسوند:
					</td>
					<td class="Table_RowC">
						<asp:TextBox runat="server" ID="PostFixTextBox" />
					</td>
				</tr>
				<%--<tr>
					<td class="Table_RowB" style="vertical-align: top">مخزن:
					</td>
					<td class="Table_RowC" colspan="3">
						<asp:TextBox runat="server" ID="StorageTextBox" />
					</td>
				</tr>--%>
				<tr>
					<td class="Table_RowB" style="vertical-align: top">مدیر:
					</td>
					<td class="Table_RowC" colspan="3">
						<cc1:AutoCompleteTextBox ID="ManagerAutoCompleteTextBox" runat="server" URL="Services/WebBaseDefineService.asmx/GetAutoCompleteResult" SQL="select full_title,orgcode from ( select *,  ISNULL(users.Fam + ' ', '') + ISNULL(users.Name, '')+ '_' + CASE WHEN (Select count(*) from subdefine left join EmpJobTitle on EmpJobTitle.TitleCode = subdefine.Code WHERE EmpJobTitle.Code = orgChart.JobTitleCode) = 0 THEN '(عنوان شغلی ندارد)' ELSE (Select name from subdefine left join EmpJobTitle on EmpJobTitle.TitleCode = subdefine.Code WHERE EmpJobTitle.Code = orgChart.JobTitleCode) END + '_' + orgChart.full_title AS full_title2 from (select Code OrgCode,parentcode,JobTitleCode,PostTitleCode,full_title,full_name,user_code,is_unit,0 as [level] from dbo.vorganizationchart b )orgChart left join (select u.Code,p.Name,p.Fam,p.Gender from users u inner join  clsperson p on (u.pcode = p.Code)) users on users.Code = orgChart.user_code )t" DisplayField="full_title" SearchField="full_title" ValueField="orgcode"></cc1:AutoCompleteTextBox>
					</td>
				</tr>
			</table>
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="UsersRadTab">
			<asp:GridView runat="server" ID="UsersGridView"></asp:GridView>
		</telerik:RadPageView>
	</telerik:RadMultiPage>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="OkButton" Text="تایید" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
