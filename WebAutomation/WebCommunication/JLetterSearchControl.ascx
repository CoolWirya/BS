<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLetterSearchControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JLetterSearchControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="FormContent">
	<div class="BigTitle">جستجوی نامه</div>
	<table>
		<tr>
			<td class="Table_RowB">شماره نامه:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="LetterNoTextBox" />
			</td>
			<td class="Table_RowB">فرستنده:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="SenderTextBox" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">موضوع نامه:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="SubjectTextBox" />
			</td>
			<td class="Table_RowB">گیرنده:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="ReceiverTextBox" />
			</td>
		</tr>
		<tr>
			<td class="Table_RowB">متن نامه:</td>
			<td class="Table_RowC">
				<asp:TextBox runat="server" ID="LetterTextTextBox" />
			</td>
			<td class="Table_RowB">جستجو در ارجاعات:</td>
			<td class="Table_RowC">
				<asp:CheckBox Text="" ID="SearchInReferCheckBox" Checked="true" Enabled="true" runat="server" />
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
		</tr>
	</table>
	<uc1:JGridViewControl runat="server" id="JGridViewControl" />
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="SearchButton" Text="جستجو..." AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Line" OnClick="SearchButton_Click" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
