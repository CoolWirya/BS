<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CMS.Index1" %>

<%@ Register Src="~/Index.ascx" TagPrefix="uc1" TagName="Index" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="WebControllers/MainControls/OpenLayersMap/OpenLayers.js"></script>
    <link href="Style/MainStyleSheet.css" rel="stylesheet" />
    <link href="Style/PersianDateStyle.css" rel="stylesheet" />
    <link href="Style/persianDatePicker-default.css" rel="stylesheet" />
    <link href="Style/Slider.css" rel="stylesheet" />
    <link href="Style/jquery-ui.css" rel="stylesheet" />
    <link href="Style/jquery.ui.all.css" rel="stylesheet" />
    <link href="Style/jquery.ui.dialog.css" rel="stylesheet" />
    <link href="Style/jquery.ui.theme.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte-inner.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte.full.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte.min.css" rel="stylesheet" />
    <link href="Style/elRTE/jquery-ui-1.8.13.custom.css" rel="stylesheet" />
    <link href="Style/fileTree/jqueryFileTree.css" rel="stylesheet" />
    <link href="Style/elRTE/elfinder.min.css" rel="stylesheet" />
    <link href="Style/elRTE/theme.css" rel="stylesheet" />
    <link href="Style/JMenu/style.css" rel="stylesheet" />
    <link href="Style/fileTree/gsFileManager.css" rel="stylesheet" />
    <link href="Style/fileTree/jquery.Jcrop.css" rel="stylesheet" />
    <link href="Style/cms.css" rel="stylesheet" />
    <link href="Style/tab.css" rel="stylesheet" />
    <script src="Script/elRTE/jquery-1.6.1.min.js"></script>
    <script src="Script/jquery-1.8.2.js"></script>
    <script src="Script/JQueryUploader.js"></script>
    <script src="Script/persianDatepicker.js"></script>
    <script src="Script/jquery-ui-1.8.24.js"></script>
    <script src="Script/jquery-ui-1.8.24.min.js"></script>
    <script src="Script/JSlider.js"></script>
    <script src="Script/create.js"></script>
    <script src="Script/elRTE/elfinder.min.js"></script>

    <script src="Script/elRTE/jquery-ui-1.8.13.custom.min.js"></script>
    <script src="Script/elRTE/elrte.min.js"></script>
    <script src="Script/elRTE/elrte.full.js"></script>
    <script src="Script/fileTree/jquery.easing.js"></script>
    <script src="Script/fileTree/jqueryFileTree.js"></script>
    <script src="Script/fileTree/gsFileManager.js"></script>
    <script src="Script/fileTree/jquery.Jcrop.js"></script>
    <script src="Script/JTab/jquery.hashchange.min.js"></script>
    <script src="Script/JTab/jquery.easytabs.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<uc1:Index runat="server" ID="Index" />--%>
    </div>
    </form>
</body>
</html>
