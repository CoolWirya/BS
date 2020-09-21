<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilRPMUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JRPMUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="FormContent">
    <div class="BigTitle">آر پی ام</div>
    <table>
        <tr>
            <td class="Table_RowB">ورژن:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtVersion" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtVersion" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ نصب:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="jDateRegister" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">کد فایل:</td>
            <td class="Table_RowC">
                <telerik:RadButton runat="server" Text="دریافت فایل" ID="btnDownloadFile" OnClick="btnDownloadFile_Click"></telerik:RadButton>
                <telerik:RadAsyncUpload runat="server" ID="radUpload" MultipleFileSelection="Disabled"></telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtComment" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جدول سوخت:</td>
            <td class="Table_RowC">

                <telerik:RadNumericTextBox ID="txtTableQuotas" runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" Width="95%">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtTableQuotas" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جدول قیمت:</td>
            <td class="Table_RowC">

                <telerik:RadNumericTextBox ID="txtTablePrices" runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" Width="95%">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="txtTablePrices" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">ورژن PT:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtPtVersion" Width="95%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtPtVersion" ValidationGroup="RPM" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowD">ارسال فایل  موارد اعمال نشده :</td>
            <td class="Table_RowE">
                <asp:FileUpload ID="radUploadXls" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="راهنما : "></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="RPM" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
