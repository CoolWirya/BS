<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sendMessage.ascx.cs" Inherits="WebAVL.Forms.sendMessage" %>

<%@ Register Src="~/WebAVL/Controls/Search/JSearchDevice.ascx" TagPrefix="cc1" TagName="JSearchDevice" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Label id="h3" runat="server" Text=" گروه را انتخاب کنید و پیام را ارسال کنید."></asp:Label>
<table dir="rtl">
    <tr>
        <td><span>دستگاه مدیر</span>
        </td>
        <td>
            <cc1:JSearchDevice runat="server" ID="searchDevice" OnClientClick="return false;" AutoPostBack="false"></cc1:JSearchDevice>

        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">پیام : </td>
        <td>
            <asp:TextBox ID="txtMessage" runat="server" Height="500px" Width="500px" TextMode="MultiLine"></asp:TextBox>
        </td>

    </tr>
    <tr>
       <%-- <asp:Button ID="btnSend" runat="server" Text="ارسال" OnClick="btnSend_Click" CssClass="Nothing" />--%>
                        <telerik:RadButton ID="btnSend" runat="server" Text="ارسال" OnClick="btnSend_Click" CssClass="Nothing" AutoPostBack="true" />
    </tr>

</table>
