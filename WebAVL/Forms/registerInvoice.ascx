<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="registerInvoice.ascx.cs" Inherits="WebAVL.Forms.registerInvoice" %>


<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
		<tr>
			<td class="Table_RowB">شماره فیش</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtInvoiceNumber"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">تاریخ پرداخت فیش</td>
			<td class="Table_RowC">
                <uc1:JDateControl ID="clrDocumentDate" runat="server"></uc1:JDateControl></td>
		</tr>
		<tr>
			<td class="Table_RowB">تاریخ ثبت</td>
			<td class="Table_RowC">
                <asp:Label ID="lblRegisterDate" runat="server" Text=""></asp:Label></td>
		</tr>
		<tr>
			<td class="Table_RowB">مبلغ</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtPrice"></telerik:RadTextBox> ریال</td>
		</tr>
		<tr>
			<td class="Table_RowB">نام بانک</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtBankName"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">شعبه</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtBranch"></telerik:RadTextBox></td>
		</tr>
</table>
        <telerik:RadButton ID="btnRegister" runat="server" Text="ثبت"  OnClick="btnRegister_Click"/>
       <telerik:RadButton ID="btnUpdate" runat="server" Text="ویرایش"  OnClick="btnUpdate_Click"/>

<hr />

<asp:ListView ID="ListView1" runat="server">

</asp:ListView>
