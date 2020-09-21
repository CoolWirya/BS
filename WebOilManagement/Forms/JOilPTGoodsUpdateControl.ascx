<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilPTGoodsUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilPTGoodsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnAdd_Click">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdGoods" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnDelete_Click">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdGoods" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
        }
    </script>
</telerik:RadCodeBlock>

<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<div class="FormContent">
    <div class="BigTitle">کالاهای PT</div>
    <table>
        <tr>
            <td class="Table_RowB">کالا:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbGoods" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <telerik:RadButton runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="افزودن به لیست"></telerik:RadButton>
    <telerik:RadButton runat="server" ID="btnDelete" OnClick="btnDelete_Click" Text="حذف از لیست"></telerik:RadButton>
    <telerik:RadGrid runat="server" ID="grdGoods">
        <ClientSettings>
            <ClientEvents OnRowClick="RowClick" />
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>
    </telerik:RadGrid>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
