<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebERP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Style/MainStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" Skin="Metro" />
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Metro" ShowChooser="false" />

        <div style="position: absolute; width: 100%; height: 100%">
            <table class="LoginTable">
                <tr>
                    <td style="width: 300px; vertical-align: top; background-image:url('<%=WebClassLibrary.JWebSettings.GetKey("WebSiteLoginPatternImage") %>');" class="LoginTD">
                        <div class="rightContent">
                            <div class="divLogo">
                                <telerik:RadBinaryImage runat="server" ID="imgLogo" ResizeMode="Fit" Width="200px" Height="200px" /><br />
                                <%=WebClassLibrary.JWebSettings.GetKey("WebSiteLogoText") %>
                            </div>
                            <asp:Label ID="lblError" runat="server" Text="نام کاربری یا کلمه عبور اشتباه می باشد." CssClass="lblError" Visible="False"></asp:Label>
                            <table class="LoginForm">
                                <tr>
                                    <td>نام کاربری</td>
                                    <td>
                                        <asp:TextBox ID="txtUsername" runat="server" Width="150" Font-Size="Large" TabIndex="1"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>کلمه عبور</td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" Width="150" TextMode="Password" Font-Size="Large" TabIndex="2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>کد امنیتی</td>
                                    <td>
                                        <telerik:RadCaptcha ID="RadCaptcha1" runat="server" TabIndex="0"
                                            ErrorMessage="کد وارد شده صحیح نمی باشد." Display="Dynamic" ProtectionMode="Captcha" CaptchaImage-TextLength="4" CaptchaImage-TextChars="Numbers" OnCaptchaValidate="RadCaptcha1_CaptchaValidate" CaptchaTextBoxLabel="">
                                        </telerik:RadCaptcha>
                                    </td>
                                </tr>
                            </table>
                            <div class="loginform_footer">
                                <telerik:RadButton ID="btnLogin" runat="server" Text="ورود" Width="140" Height="40" OnClick="btnLogin_Click"></telerik:RadButton>
                                <telerik:RadButton ID="btnRegister" runat="server" Text="ثبت نام" Width="140" Height="40" OnClick="btnRegister_Click" Visible="False"></telerik:RadButton>
                            </div>
                            <%--<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click" Visible="true">ثبت نام در سیستم جهت استفاده از سامانه فروش</asp:LinkButton>--%>
                            <br />
                            <br />
                        </div>
                    </td>
                    <td class="ContentTD" style="vertical-align: top;background-image:url('<%=WebClassLibrary.JWebSettings.GetKey("WebSiteLoginPatternImage") %>');">
                        <%=WebClassLibrary.JWebSettings.GetKey("WebSiteLoginContent") %>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
