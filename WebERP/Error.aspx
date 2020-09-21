<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebERP.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction: rtl; line-height: 110%; font-family: Tahoma;">
            <%
                if (Request.QueryString["err"] != null)
                {
                    Response.Write("<p style='font-size:24px;background-color:#EEE;padding:5px'>Error <span style='font-size:32px'>" + Request.QueryString["err"] + "</span></p>" +"<br/>");
                    if (Request.QueryString["err"] == "0")
                        Response.Write("Database Error: Could not connect to database. Try again." + "<br/>" + Request.QueryString["r"]);
                    else if (Request.QueryString["err"] == "1")
                    {
                        Response.Write(ClassLibrary.JLanguages._Text("WebError_1") + "<br/>" + Request.QueryString["r"]);
                        %>
                        <script type="text/javascript">
                            window.top.location = 'Login.aspx';
                        </script>
                        <%
                    }
                    else if (Request.QueryString["err"] == "2")

                        Response.Write(ClassLibrary.JLanguages._Text("WebError_2") + "<br/>" + Request.QueryString["r"]);
                    else if (Request.QueryString["err"] == "5")
                        Response.Write(ClassLibrary.JLanguages._Text("WebError_5_ControlNotFound") + "<br/>" + Request.QueryString["r"]);
                    else if (Request.QueryString["err"] == "10")
                        Response.Write(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "<br/>" + Request.QueryString["r"]);
                    else if (Request.QueryString["err"] == "11")
                        Response.Write(Page.MapPath("~") + "<br/>" + Server.MapPath("~") + "<br/>" + Request.QueryString["r"]);
                    else if (Request.QueryString["err"] == "9999")
                        Response.Write("Invalid domain name. Contact your administrator." +"<br/>"+ Request.QueryString["r"]);
                        
                }
            %>
        </div>
    </form>
</body>
</html>
