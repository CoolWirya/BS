<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSharePCodeUpdateCotrol.ascx.cs" Inherits="WebManagementShare.Forms.JSharePCodeUpdateCotrol" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="BigTitle">تغییر کد سهامداری</div>
<div class="FormContent" style="top: 40px">
    <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" isReadOnly="true" />
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 150px">کد سهامداری قدیم:</td>
            <td><telerik:RadTextBox ID="txtOldSharepCode" runat="server" Enabled="false"></telerik:RadTextBox></td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">کد سهامداری جدید:</td>
            <td><telerik:RadTextBox ID="txtNewSharepCode" runat="server"></telerik:RadTextBox></td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="Bus" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<%--    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />--%>
</div>