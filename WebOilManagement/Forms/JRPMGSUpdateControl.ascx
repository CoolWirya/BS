<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JRPMGSUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JRPMGSUpdateControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<style type="text/css">
	.auto-style1 {
		width: 405px;
	}
</style>

<div class="FormContent">
    <div class="BigTitle">وضعیت RPM جایگاه ها</div>
    <table>
        <tr>
            <td class="Table_RowB">جایگاه:</td>
            <td class="auto-style1">
                <telerik:RadTextBox runat="server" ID="txtStation" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtStation" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">ورژن:</td>
            <td class="auto-style1">
                <telerik:RadTextBox runat="server" ID="txtVersion" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtVersion" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">وضعیت:</td>
            <td class="auto-style1">
                <telerik:RadTextBox runat="server" ID="txtStatus" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="txtStatus" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ نصب:</td>
            <td class="auto-style1">
                <uc1:JDateControl runat="server" id="jDateRegister" />
            </td>
        </tr>
		        <tr>
            <td class="Table_RowB">ساعت نصب:</td>
            <td class="auto-style1">
				<JJson:JNumericTextBox ID="txtHour" runat="server" Width="26px"></JJson:JNumericTextBox> :
				<JJson:JNumericTextBox ID="txtMin" runat="server" Width="26px"></JJson:JNumericTextBox>
			</td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات:</td>
            <td class="auto-style1">
                <telerik:RadTextBox runat="server" ID="txtComment" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">کد پیمانکار:</td>
            <td class="auto-style1">
                <telerik:RadTextBox runat="server" ID="txtPCode" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtPCode" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="RPM" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
	<telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnRefer_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
