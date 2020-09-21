<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTypesOfGoodsUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JTypesOfGoodsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">نوع کالا</div>
    <table>
        <tr>
            <td class="Table_RowB">نام :</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">دسته بندی کالا :</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbGoodsHierarchies" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
       <%-- <tr>
            <td class="Table_RowB">سریالی :</td>
            <td class="Table_RowC">
                <asp:CheckBox runat="server" ID="chbHasSerial" Checked="false"></asp:CheckBox>
            </td>
        </tr>--%>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
