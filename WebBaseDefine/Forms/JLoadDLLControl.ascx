<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLoadDLLControl.ascx.cs" Inherits="WebBaseDefine.Forms.JLoadDLLControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
</script>
<div class="FormContent">
	<asp:HiddenField ID="SelectedClassHiddenField" runat="server" />
	<div class="BigTitle">Load DLLs</div>
	<table>
		<tr>
			<td>
				<table>
					<tr>
						<td>
							<asp:ListBox runat="server" ID="PermissionListBox" Height="500px" Width="450px" AutoPostBack="True" OnSelectedIndexChanged="PermissionListBox_SelectedIndexChanged" SelectionMode="Multiple" />
						</td>
					</tr>
				</table>
			</td>
			<td valign="top">
				<table>
					<tr>
						<td>Projects:</td>
					</tr>
					<tr>
						<td>
							<asp:DropDownList runat="server" ID="GroupDropDownList" Width="320px" OnSelectedIndexChanged="GroupDropDownList_SelectedIndexChanged" AutoPostBack="True" />
						</td>
					</tr>
					<tr>
						<td>
							<div width="100%" height="100%" style="overflow-y: scroll;border:solid 1px black;">
								<asp:TreeView runat="server" ID="ClassTreeView" Height="450px" Width="300px" OnSelectedNodeChanged="ClassTreeView_SelectedNodeChanged" ShowLines="True">
									<NodeStyle ForeColor="Black" />
									<SelectedNodeStyle BackColor="Yellow" />
								</asp:TreeView>
							</div>
						</td>
					</tr>
				</table>
			</td>
			<td valign="center">
				<table>
					<tr>
						<td>
							<telerik:RadButton runat="server" ID="AddButton" Text="+" Width="100px" Height="35px" ValidationGroup="Line" OnClick="AddButton_Click" />
							<telerik:RadButton runat="server" ID="DeleteButton" Text="-" Width="100px" Height="35px" ValidationGroup="Line" OnClick="DeleteButton_Click" />
						</td>
					</tr>
				</table>
			</td>
			<td valign="center">
				<table>
					<tr>
						<td>
							<asp:TextBox runat="server" ID="FunctionNameTextBox" Width="280px"/>
						</td>
					</tr>
					<tr>
						<td>
							<asp:ListBox runat="server" ID="ListBox1" Height="450px" Width="300px" AutoPostBack="True" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
