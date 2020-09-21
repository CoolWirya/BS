<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailVarification.aspx.cs" Inherits="WebERP.EmailVarification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMsg" runat="server" Text="" Visible="true" ></asp:Label>
        <%--<asp:HyperLink ID="HyperLink1" NavigateUrl="~/"+ClassLibrary.JConfig.LoginPage Visible="false" runat="server">ورود به سیستم</asp:HyperLink>--%>
    </div>
    </form>
</body>
</html>
