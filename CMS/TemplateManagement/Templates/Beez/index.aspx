<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CMS.TemplateManagement.Templates.Beez.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <script src="WebControllers/MainControls/OpenLayersMap/OpenLayers.js"></script>
    <link href="../../../Style/MainStyleSheet.css" rel="stylesheet" />
    <link href="../../../Style/PersianDateStyle.css" rel="stylesheet" />
    <link href="../../../Style/persianDatePicker-default.css" rel="stylesheet" />
    <link href="../../../Style/Slider.css" rel="stylesheet" />
    <link href="../../../Style/jquery-ui.css" rel="stylesheet" />
    <link href="../../../Style/jquery.ui.all.css" rel="stylesheet" />
    <link href="../../../Style/jquery.ui.dialog.css" rel="stylesheet" />
    <link href="../../../Style/jquery.ui.theme.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/elrte-inner.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/elrte.full.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/elrte.min.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/jquery-ui-1.8.13.custom.css" rel="stylesheet" />
    <link href="../../../Style/fileTree/jqueryFileTree.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/elfinder.min.css" rel="stylesheet" />
    <link href="../../../Style/elRTE/theme.css" rel="stylesheet" />
    <link href="../../../Style/JMenu/style.css" rel="stylesheet" />
    <link href="../../../Style/fileTree/gsFileManager.css" rel="stylesheet" />
    <link href="../../../Style/fileTree/jquery.Jcrop.css" rel="stylesheet" />
    <%--<link href="../../../Style/cms.css" rel="stylesheet" />--%>
    <link href="../../../Style/tab.css" rel="stylesheet" />
    <script src="../../../Script/elRTE/jquery-1.6.1.min.js"></script>
    <script src="../../../Script/jquery-1.8.2.js"></script>
    <script src="../../../Script/JQueryUploader.js"></script>
    <script src="../../../Script/persianDatepicker.js"></script>
    <script src="../../../Script/jquery-ui-1.8.24.js"></script>
    <script src="../../../Script/jquery-ui-1.8.24.min.js"></script>
    <script src="../../../Script/JSlider.js"></script>
    <script src="../../../Script/create.js"></script>
    <script src="../../../Script/elRTE/elfinder.min.js"></script>
    <script src="../../../Script/elRTE/jquery-ui-1.8.13.custom.min.js"></script>
    <script src="../../../Script/elRTE/elrte.min.js"></script>
    <script src="../../../Script/elRTE/elrte.full.js"></script>
    <script src="../../../Script/fileTree/jquery.easing.js"></script>
    <script src="../../../Script/fileTree/jqueryFileTree.js"></script>
    <script src="../../../Script/fileTree/gsFileManager.js"></script>
    <script src="../../../Script/fileTree/jquery.Jcrop.js"></script>
    <script src="../../../Script/JTab/jquery.hashchange.min.js"></script>
    <script src="../../../Script/JTab/jquery.easytabs.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
		<div class="body">
        <div id="b_holder" class="container">
            <div class="container_nav_outer">
                <div class="container">
                    <div class="row-fluid">
                        <jdoc type="Module" name="logo1"></jdoc>
                        <span style="font-size: 18px"><jdoc type="Module" name="title"></jdoc></span>
                        <div style="float: left">
                            <asp:PlaceHolder ID="logo2place" runat="server">
                                 <jdoc type="Module" name="logo2"></jdoc>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container_outer_pathway">
                <div class="container">
                    <div class="row-fluid">
                        <ul class="breadcrumb">
                            
                            <li class="active">خانه</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="container_nav_outer">
                <div class="container">
                    <div class="row-fluid">
                        <div id="hor_nav">
                            <asp:PlaceHolder ID="menuplace" runat="server">
                                <jdoc type="Module" name="menu"></jdoc>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container_nav_outer">
                <div class="container">
                    <div class="row-fluid">
                        <div id="sidebar" class="span3">
                            <div class="sidebar-nav">
                                <div class="well">
                                    <div id="page_header_h3" class="page-header">
                                        <label id="Loginlbl" runat="server"></label>
                                    </div>
                                    <div class="custom">
                                        <asp:PlaceHolder ID="loginplace" runat="server">
                                        <jdoc type="Module" name="login"></jdoc>
                                        </asp:PlaceHolder>
                                    </div>
                                </div>
                                <div class="well">
                                    <div id="page_header_h3" class="page-header">
                                        <label id="esteellbl" runat="server"></label>
                                    </div>
                                    <div class="custom">

                                        <span style="line-height: 1.3em;">
                                            <asp:PlaceHolder ID="side1place" runat="server">
                                            <jdoc type="Module" name="side1"></jdoc>
                                            </asp:PlaceHolder>
                                        </span>
                                    </div>
                                </div>
                                <div class="well">
                                    <div id="page_header_h3" class="page-header">
                                        <label id="Rahatilbl" runat="server"></label></div>
                                    <div class="custom">
                                        <span style="line-height: 1.3em;">
                                            <asp:PlaceHolder ID="side2place" runat="server">
                                                <jdoc type="Module" name="side2"></jdoc>
                                            </asp:PlaceHolder>
                                        </span>
                                    </div>
                                </div>
                                <div class="well">
                                    <div id="page_header_h3" class="page-header">
                                        <label id="khablbl" runat="server"></label>
                                    </div>
                                    <div class="custom">
                                        <span style="line-height: 1.3em;">
                                            <asp:PlaceHolder ID="side3place" runat="server">
                                            <jdoc type="Module" name="side3"></jdoc>
                                            </asp:PlaceHolder>
                                        </span>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                        <div id="content" class="span9">
                            <div class="loading" style="display:none"><img src="Images/ajax-loader.gif" /></div>
                            <div id="slide-wrap">
                                <asp:PlaceHolder ID="topplace" runat="server">
                                     <jdoc type="Module" name="top"></jdoc>
                                </asp:PlaceHolder>
                            </div>
                            <div class="outer_tabs">
                                <div class="well " id="mainContent">
                                    <asp:PlaceHolder ID="content1place" runat="server">
                                            <jdoc type="Module" name="content1"></jdoc>
                                    </asp:PlaceHolder>


                                </div>

                                    <div id="featured-row">
                                        <div class="frow">
                                            <div class="moduletable">
                                                <h3 class="module_title ">Cases</h3>
                                                <div class="mod-newsflash mod-newsflash__">
                                                    <div class="item">
                                                        <asp:PlaceHolder ID="content2place" runat="server">
                                                        <jdoc type="Module" name="content2"></jdoc>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="container_nav_outer">
                <div id="footer">
                    <div id="footer-row">
                        <div class="frow">
                            <div class="footer-row-1">
                                <div class="footer-col">
                                    <div>درباره ما</div>
                                    <asp:PlaceHolder ID="aboutusplace" runat="server">
                                        <jdoc type="Module" name="aboutus"></jdoc>
                                    </asp:PlaceHolder>
                                </div>
                                <div class="footer-col">
                                    <div>ارتباط با ما</div>
                                    <asp:PlaceHolder ID="contactusplace" runat="server">
                                        <jdoc type="Module" name="contactus"></jdoc>
                                    </asp:PlaceHolder>
                                </div>
                                <div class="footer-col">
                                    <div>
                                        <img src="Images/ico.facebook.png" width="32" height="32" />
                                        <img src="Images/ico.twitter.png" width="32" height="32" />
                                        <img src="Images/ico.linkedin.png" width="32" height="32" />
                                        <img src="Images/ico.youtube.png" width="32" height="32" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
