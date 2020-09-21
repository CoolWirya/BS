<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSendMessageEnteghadUpdateControl.ascx.cs" Inherits="WebManagementShare.Forms.JSendMessageEnteghadUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>

<div class="BigTitle">ارسال انتقاد و پیشنهاد</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">عنوان :</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSubject" Width="100%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtLineNumber" runat="server" Display="Dynamic"
                ControlToValidate="txtSubject" ValidationGroup="CPrint" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شرح :</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBody" Width="100%" TextMode="MultiLine"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                ControlToValidate="txtBody" ValidationGroup="CPrint" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="CPrint" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
