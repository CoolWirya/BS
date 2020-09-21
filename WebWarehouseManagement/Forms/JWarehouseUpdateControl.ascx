<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JWarehouseUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JWarehouseUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="FormContent">
    <div class="BigTitle">انبار</div>
    <table>
        <tr>
            <td class="Table_RowB">نام:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox>
                  <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtName" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">مالک:</td>
            <td class="Table_RowC">
                <uc1:JSearchPersonControl runat="server"  id="personOwner" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">انباردار :</td>
            <td class="Table_RowC" style="width:300px">
                <telerik:RadComboBox runat="server" ID="cmbUsers" Width="200px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Save" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
