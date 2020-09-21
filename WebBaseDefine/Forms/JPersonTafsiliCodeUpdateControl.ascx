<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPersonTafsiliCodeUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JPersonTafsiliCodeUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<style type="text/css">
    .KeyCol {
        width: 100px;
    }
</style>
<div class="FormContent">
    <div>
        <table style="width: 100%">
            <%--<tr>
                <td class="KeyCol Table_RowC">نام بانک:</td>
                <td class="Table_RowC">
                    <telerik:RadComboBox runat="server" ID="cmbBankName" Width="50%"></telerik:RadComboBox>
                </td>
            </tr>--%>
            <tr>
                <td class="KeyCol Table_RowB">شخص:</td>
                <td class="Table_RowC">
                    <uc1:JSearchPersonControl runat="server" id="JSearchPersonControlOwner" />
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">کد تفصیلی:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtTafsiliCode" Width="50%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                         ControlToValidate="txtTafsiliCode" ValidationGroup="Account"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
</div>
<div style="position: fixed; bottom: 0px; height: 45px; width: 100%; vertical-align: middle; padding-top: 5px; padding-right: 5px" class="Table_RowD">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Account" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" CssClass="floatLeft" OnClick="btnDelete_Click"></telerik:RadButton>

</div>
