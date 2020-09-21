<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilSupplierZonesUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilSupplierZonesUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="FormContent">
    <div class="BigTitle">ثبت و نگهداری مناطق تحت پوشش پیمانکار</div>
    <table>
        <tr>
            <td class="Table_RowB">پیمانکار:</td>
            <td class="Table_RowC">
                <%--<telerik:RadComboBox runat="server" ID="cmbSupplier" Width="100%"></telerik:RadComboBox>--%>
                <telerik:RadTextBox runat="server" ID="txtSupplierNamer" Width="100%" Enabled="false"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">منطقه:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbOilZone" Width="100%" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <telerik:RadButton runat="server" ID="btnSave" Text="افزودن" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />

    <br />
    <br />
    <telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GrvOilSupplierArea" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadGrid ID="GrvOilSupplierArea" runat="server" Width="90%" OnDeleteCommand="GrvOilSupplierArea_DeleteCommand" AutoGenerateColumns="true">
        <MasterTableView>
            <Columns>
                <telerik:GridButtonColumn ItemStyle-Width="30" ButtonType="ImageButton" ImageUrl="~/Images/Controls/menu_delete.png" ConfirmTitle="حذف" ConfirmText="از حذف این منطقه مطمئن هستید؟" CommandName="delete"></telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
