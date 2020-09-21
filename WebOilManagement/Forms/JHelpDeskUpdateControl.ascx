<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHelpDeskUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JHelpDeskUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>

<div class="FormContent">
    <div class="BigTitle">رفع خرابی نرم افزاری</div>
    <table>
        <tr>
            <td class="Table_RowB">درخواست انجام شد</td>
            <td class="Table_RowC">
                <asp:CheckBox ID="chbOperationDone" runat="server" CausesValidation="true" ValidationGroup="OperationDone" AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شرح</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtOperationDescription" Width="90%" ValidationGroup="OperationDone" ></telerik:RadTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="OperationDone" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
</div>
