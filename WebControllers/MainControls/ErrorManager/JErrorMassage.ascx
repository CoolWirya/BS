<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JErrorMassage.ascx.cs" Inherits="WebControllers.MainControls.ErrorManager.JErrorMassage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="pnlMessage">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="close_Btn" />
            </UpdatedControls>
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="close_Btn">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="pnlMessage" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<style type="text/css">
    .auto-style1 {
        width: 100px;
    }
</style>

<asp:Panel ID="pnlMessage" runat="server" TabIndex="-1">
    <table cellpadding="0" cellspacing="0" class="auto-style1" dir="rtl" style="width: 100%">
        <tr>
            <td dir="rtl" width="100px">
                <asp:Image ID="imgErrorIcon" Width="50px" runat="server" ImageUrl="~\WebErp\Images\Controls\Messages\Error.png" TabIndex="-1" />
            </td>
            <td>
                <%-- <asp:Label ID="lblMessage" runat="server" Font-Names="Tahoma" Font-Size="10pt" TabIndex="-1"></asp:Label>--%>
                <div runat="server" id="lblMessage" style="font-family: Tahoma; font-size: 10pt;"></div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblErrorDescription" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadButton ID="close_Btn" SingleClickText="بســتن" OnClick="Close_Btn_Click" runat="server" Text="RadButton">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Panel>

