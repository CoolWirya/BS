<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSendMessageUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JSendMessageUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc3" TagName="JCustomListSelectorControl" %>

<div class="BigTitle">ارسال پیام</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">گیرنده:</td>
        <td>
           <%-- <uc2:JSearchPersonControl runat="server" id="JSearchPersonControlInstaller" />--%>
             <uc3:JCustomListSelectorControl runat="server" id="JSearchPersonControlInstaller" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">عنوان پیام:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSubject" Width="100%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtLineNumber" runat="server" Display="Dynamic"
                ControlToValidate="txtSubject" ValidationGroup="CPrint" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شرح پیام:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBody" Width="100%" TextMode="MultiLine"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                ControlToValidate="txtBody" ValidationGroup="CPrint" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="CPrint" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
