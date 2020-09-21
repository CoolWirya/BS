<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Callback.aspx.cs" Inherits="WebAVL.Callback" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BP PGW Test</title>
    <link href="Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="80%" cellspacing="0" cellpadding="0" align="center">
       
        <tr>
            <td>
                <table class="MainTable" cellspacing="5" cellpadding="1" align="center" dir="rtl" style="border:solid; border-radius:5px;">
                    <tr class="HeaderTr" style="background-color:greenyellow;border-top-left-radius:5px;border-bottom-right-radius:5px;">
                        <th colspan="2" align="center" height="25">
                            <asp:Label ID="Label11" runat="server" class="HeaderText" Text="رسید پرداخت"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label2" runat="server" Text="كد ‫مرجع‬ ‫‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="RefIdLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label1" runat="server" Text="وضعيت ‫خريد‬ ‫‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="ResCodeLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label30" runat="server" Text="شماره درخواست ‫خريد‬ ‫‬ ‫‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="SaleOrderIdLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label3" runat="server" Text="كد مرجع ‫تراكنش‬ ‫‬ ‫‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="SaleReferenceIdLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label4" runat="server" Text="‫مبلغ‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelTd">
                            <asp:Label ID="Label6" runat="server" Text="‫مانده حساب کاربری شما‬"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

