<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilZoneUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilZoneUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">منطقه نفتی</div>
    <table>
        <tr>
            <td class="Table_RowB">حوزه نفتی:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbOilDistrict" Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نام منطقه:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtZoneName" Width="100%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtZoneName" ValidationGroup="Zone" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Zone" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
