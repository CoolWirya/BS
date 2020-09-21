<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="inviteUC.ascx.cs" Inherits="WebAVL.Forms.inviteUC" %>

<%@ Register Src="~/WebAVL/Controls/Search/JSearchDevice.ascx" TagPrefix="cc1" TagName="JSearchDevice" %>
<table dir="rtl">
    <tr>
        <td><p dir="rtl">IMEI دستگاه مورد نظر را وارد کنید</p></td>
        <td>
            <cc1:JSearchDevice runat="server" ID="searchDevice" OnClientClick="return false;" AutoPostBack="false"></cc1:JSearchDevice></td>
    </tr>
    <tr>
        <td>نام کاربری</td>
        <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>کلمه عبور</td>
        <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
    </tr>
</table>


<BR />
<asp:Button ID="Button1" runat="server" Text="ثبت" OnClick="Button1_Click"/>

<br />
<asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%"></asp:Panel>

 