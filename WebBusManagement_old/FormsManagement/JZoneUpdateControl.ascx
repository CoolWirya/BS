<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JZoneUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JZoneUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">مناطق</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نام منطقه:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtName" Width="96%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="Zone" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">رئیس منطقه:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ شروع به کار رئیس منطقه:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtStartDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ پایان کار رئیس منطقه :</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFinishDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">آدرس:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtAddress" Width="96%" TextMode="MultiLine"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtAddress" runat="server" Display="Dynamic" ControlToValidate="txtAddress" ValidationGroup="Zone" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تلفن:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTel" Width="96%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDescription" Width="96%" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Zone" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
