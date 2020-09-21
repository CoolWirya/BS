<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JProjectsUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JProjectControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %><div class="FormContent">
	<div class="BigTitle">کاربر</div>
	<table>
		<tr>
			<td class="Table_RowB">عنوان پروژه:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="RadTextBox1"></telerik:RadTextBox>
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">تاریخ شروع:</td>
			<td class="Table_RowC">
				<uc1:jdatecontrol runat="server" id="txtFromDate" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">تاریخ پایان:</td>
			<td class="Table_RowC">
				<uc1:jdatecontrol runat="server" id="txtToDate" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">پلتفرم:</td>
			<td class="Table_RowC">
				<telerik:RadComboBox runat="server" ID="cmbPlatform">
					<Items>
						<telerik:RadComboBoxItem Text="فعال" Value="1" />
						<telerik:RadComboBoxItem IsSeparator="true" />
						<telerik:RadComboBoxItem Text="غیر فعال" Value="0" />
					</Items>
				</telerik:RadComboBox>

			</td>
		</tr>
		<tr>
			<td class="Table_RowB">زبان برنامه نویسی:</td>
			<td class="Table_RowC">
				<telerik:RadComboBox runat="server" ID="cmbLanguage">
					<Items>
						<telerik:RadComboBoxItem Text="فعال" Value="1" />
						<telerik:RadComboBoxItem IsSeparator="true" />
						<telerik:RadComboBoxItem Text="غیر فعال" Value="0" />
					</Items>
				</telerik:RadComboBox>
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">نوع پایگاه داده:</td>
			<td class="Table_RowC">
				<telerik:RadComboBox runat="server" ID="cmbDatabase">
					<Items>
						<telerik:RadComboBoxItem Text="فعال" Value="1" />
						<telerik:RadComboBoxItem IsSeparator="true" />
						<telerik:RadComboBoxItem Text="غیر فعال" Value="0" />
					</Items>
				</telerik:RadComboBox>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
