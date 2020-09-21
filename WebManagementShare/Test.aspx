<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebManagementShare.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 102px;
        }
        .auto-style2 {
            width: 102px;
            height: 29px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            width: 102px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" dir="rtl">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">نام کاربری:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">کلمه عبور:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="login" OnClick="btnLogin_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="btnShowInfo" runat="server" Text="نمایش اطلاعات شخص" OnClick="btnShowInfo_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAgents" runat="server" Text="نمایش اطلاعات وکیل" OnClick="btnGetAgents_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">تعداد سهام:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtShareCount" runat="server"></asp:TextBox>
                    <asp:Button ID="btnInsertBuyRequest" runat="server" Text="درج درخواست خرید" OnClick="btnInsertBuyRequest_Click" />
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3">
                    <asp:Button ID="btnShowByRequests" runat="server" Text="لیست درخواستهای خرید" OnClick="btnShowByRequests_Click" style="direction: ltr" />
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">تعداد سهام:</td>
                <td>
                    <asp:TextBox ID="txtShareCountToSell" runat="server"></asp:TextBox>
                    <asp:Button ID="btnInsertSelRequest" runat="server" Text="درج درخواست فروش" OnClick="btnInsertSelRequest_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    <asp:Button ID="btnShowSellRequests" runat="server" Text="لیست درخواستهای فروش" OnClick="btnShowSellRequests_Click" style="direction: ltr" />
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    <asp:Button ID="btnShowShareCount" runat="server" Text="نمایش تعداد سهام سهامدار" OnClick="btnShowShareCount_Click" />
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
