<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPermissionSetGroupControl.ascx.cs" Inherits="WebBaseDefine.Forms.JPermissionSetGroupControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent" style="margin-bottom:40px;">
	<asp:HiddenField ID="UserPostCodeHiddenField" runat="server" />
	<div class="BigTitle">مجوزها</div>
	<table>
		<tr>
			<td class="Table_RowB">گروه:</td>
			<td class="Table_RowC" colspan="2">
				<asp:Label ID="GroupLabel" runat="server" />
				<%--: 
				<asp:DropDownList runat="server" ID="PostDropDownList" Height="24px" Width="300px"  AutoPostBack="True" OnSelectedIndexChanged="PostDropDownList_SelectedIndexChanged1" />--%>
			</td>
		</tr>
		<tr>
			<td>
				<table>
					<tr>
						<td>لیست دسترسی ها:</td>
					</tr>
					<tr>
						<td>
							<asp:DropDownList runat="server" ID="GroupDropDownList" Height="24px" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="GroupDropDownList_SelectedIndexChanged"/>
						</td>
					</tr>



					<tr>
						<td>
							<asp:ListBox runat="server" ID="DefineGroupListBox" Height="313px" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="DefineGroupListBox_SelectedIndexChanged" />
						</td>
					</tr>
				</table>
			</td>
			<td valign="top">
				<table>
					<tr>
						<td>لیست اشیاء:</td>
					</tr>
					<tr>
						<td>
							<asp:ListBox runat="server" ID="ObjectListBox" Height="288px" Width="250px" AutoPostBack="True" SelectionMode="Multiple" OnSelectedIndexChanged="ObjectListBox_SelectedIndexChanged" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:CheckBox ID="SelectAllCheckBox" Text="انتخاب همه" runat="server" AutoPostBack="True" OnCheckedChanged="SelectAllCheckBox_CheckedChanged" />
							<br />
							<asp:CheckBox ID="NoneCheckBox" runat="server" Text="عدم فیلتر یک مورد خاص" AutoPostBack="true" OnCheckedChanged="NoneCheckBox_CheckedChanged" />
						</td>
					</tr>
				</table>
			</td>
			<td valign="top">
				<table>
					<tr>
						<td>تصمیمات:</td>
					</tr>
					<tr>
						<td>
							<asp:ListBox runat="server" ID="DecissionsListBox" Height="286px" Width="250px" />
						</td>
					</tr>
					<tr>
						<td>
							<telerik:RadButton runat="server" ID="InsertButton" Text="درج" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Line" OnClick="InsertButton_Click" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:ListBox runat="server" ID="PermissionGroupListBox" Height="152px" Width="929px" SelectionMode="Multiple" />
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="DeleteButton" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Line" OnClick="DeleteButton_Click" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>