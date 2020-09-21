<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGoodsHierarchyUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JGoodsHierarchyUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">دسته بندی کالاها</div>
    <table>
        <tr>
            <td class="Table_RowB">نام دسته بندی:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
