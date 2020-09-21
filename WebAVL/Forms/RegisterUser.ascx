<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.ascx.cs" Inherits="WebAVL.Forms.RegisterUser" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
	<div class="BigTitle">ثبت نام</div>
	<table>
		<tr>
			<td class="Table_RowB">نام:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">نام خانوادگی:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtLastname"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">نام کاربری:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtUsername"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">کلمه عبور:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtPassword"></telerik:RadTextBox></td> 
		</tr>
		<tr>
			<td class="Table_RowB">پست الکترونیکی:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtEmail"></telerik:RadTextBox></td> 
		</tr>
		<tr>
			<td class="Table_RowB">شماره همراه:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtMobile"></telerik:RadTextBox></td> 
		</tr>
		<tr>
            <td class="Table_RowB">
                <telerik:RadButton runat="server" ID="rdbResendVerificationCode" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnVerificationCode_Click" Visible="false" ValidationGroup="Line" />
                </td>
			<td class="Table_RowB">
                <asp:Label ID="lblVerificationCode" runat="server" Text="  کد تاییدیه را وارد کنید." Visible="false"></asp:Label>  </td>
			<td class="Table_RowC">
		<telerik:RadTextBox runat="server" ID="txtVerificationCode" Visible="false"></telerik:RadTextBox>
	</td>
            <td class="Table_RowB">
                <telerik:RadButton runat="server" ID="btnVerificationCode" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnVerificationCode_Click" Visible="false" ValidationGroup="Line" />
                </td>

            </tr>
	</table>
    <asp:HiddenField ID="hdfasp" runat="server" />
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ثبت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
</div>