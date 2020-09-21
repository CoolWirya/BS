<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JReportViewer.aspx.cs" Inherits="WebErp.JReportViewer" %>
<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cc1:StiWebViewer runat="server" id="stiWebViewer"  ></cc1:StiWebViewer>
    </div>
    </form>
</body>
</html>
