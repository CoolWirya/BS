<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddUsageControl.ascx.cs" Inherits="WebEstate.Land.Ground.Usage.JAddUsageControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Components" TagPrefix="cc1" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>

<table style="direction: rtl">
    <tr>
        <td>کد کاربری:</td>
        <td>
            <asp:Label Text="" ID="lblCode" runat="server" />
        </td>
        <td></td>
    </tr>
    <tr>
        <td>عنوان کاربری:</td>
        <td>
            <asp:TextBox runat="server" ID="txtTitle" /></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>پارکینگ:</td>
        <td>
            <asp:TextBox runat="server" ID="txtParking" /></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <table>
                <tr>
                    <td>تراکم به درصد:</td>
                    <td>
                        <JJson:JNumericTextBox ID="numDensity" runat="server"></JJson:JNumericTextBox>
                    </td>
                    <td></td>
                    <td>دسترسی:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAccess" />

                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>سطح اشتغال:</td>
        <td>
            <JJson:JNumericTextBox ID="numPercent" runat="server"></JJson:JNumericTextBox>
            درصد
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>توضیحات:</td>
        <br />
        <td>
            <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Height="132px" Width="294px" /></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="2">
           <%-- <JJson:jimageuploader runat="server" ID="img1" Type="Image"></JJson:jimageuploader>
            <cc1:jslider runat="server" id="slider1"></cc1:jslider>
            <cc1:jslider runat="server" id="slider2"></cc1:jslider>--%>
            <cc1:jsignup runat="server" id="s11"></cc1:jsignup>
            <%--<JJson:jjsoneditor runat="server" ID="editor1" Width="900" Height="300"></JJson:jjsoneditor>--%>
            <%--<cc1:JContentManager runat="server" ID="content1" Mode="View" />--%>
            <%--<JJson:JGender runat="server" ID="gender1"></JJson:JGender>--%>
            
        </td>

    </tr>
    <tr>
        <td colspan="2">

<%--            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Upload Selected File(s)" OnClientClick="ff(event);" />--%>

        </td>
    </tr>
</table>

<JJson:JJsonButton Text="ذخیره" ID="btnOK" runat="server" Event="click" />
<asp:Button Text="خروج" runat="server" ID="btnExit" OnClick="btnExit_Click" />
<div runat="server" id="res"></div>
