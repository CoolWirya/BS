<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JToolRealPersonUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JToolRealPersonUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>



<style type="text/css">
    .KeyCol {
        width: 100px;
    }
</style>
<div class="FormContent">

    <div class="BigTitle">درج مالک جــایگاه</div>
    <table style="width: 100%">

        <tr>
            <td class="KeyCol Table_RowB">نام خانوادگی:</td>
            <td class="Table_RowB">
                <telerik:RadTextBox ID="txtFam" runat="server"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFam" ValidationGroup="A"></asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="KeyCol Table_RowC">نام:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox ID="txtName" runat="server"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="KeyCol Table_RowB">جنسیت:</td>
            <td class="Table_RowB">
                <telerik:RadComboBox runat="server" ID="cmbGender">
                    <Items>
                        <telerik:RadComboBoxItem Text="مرد" Value="1" />
                        <telerik:RadComboBoxItem Text="زن" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>

</div>
<div style="position: fixed; bottom: 0px; height: 45px; width: 100%; vertical-align: middle; padding-top: 5px; padding-right: 5px" class="Table_RowD">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="A" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

