<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilAreaUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilAreaUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">ناحیه نفتی</div>
    <table>
        <tr>
            <td class="Table_RowB">منطقه نفتی:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbOilZone" Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نام ناحیه:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtAreaName" Width="100%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtAreaName" ValidationGroup="Area" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Area" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
