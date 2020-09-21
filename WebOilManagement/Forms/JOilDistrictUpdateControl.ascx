<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilDistrictUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilDistrictUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">حوزه نفتی</div>
    <table>
        <tr>
            <td class="Table_RowB">نام حوزه:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtDistrictName" Width="100%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtDistrictName" ValidationGroup="District" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
