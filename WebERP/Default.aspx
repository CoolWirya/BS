<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebERP.Default" Buffer="true" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/Common.js"></script>
	<link href="Style/PersianDateStyle.css" rel="stylesheet" />
	<link href="Style/persianDatePicker-default.css" rel="stylesheet" />
    <link href="Style/MainStyleSheet.css" rel="stylesheet" />
    <link href="Style/jquery-ui.css" rel="stylesheet" />
    <link href="Style/jquery.ui.all.css" rel="stylesheet" />
    <link href="Style/jquery.ui.dialog.css" rel="stylesheet" />
    <link href="Style/jquery.ui.theme.css" rel="stylesheet" />
    <link href="Style/Slider.css" rel="stylesheet" />
	<script src="Script/jquery-1.8.2.js"></script>
    <script src="Script/JQueryUploader.js"></script>
	<script src="Script/persianDatepicker.js"></script>
    <script src="Script/jquery-ui-1.8.24.js"></script>
    <script src="Script/jquery-ui-1.8.24.min.js"></script>
    <script src="Script/jquery-asyncUpload-0.1.js"></script>--%>
    <script src="Script/JSlider.js"></script>
    <script src="Script/ajaxupload.3.5.js"></script>--%>
    <script src="Script/JSlider.js"></script>
    
    
    <telerik:RadCodeBlock runat="server">
        <script type="text/javascript">
            function ShowMenu(menuItem) {
                if (menuItem == null || menuItem == '') return;
                var data = JSON.stringify({ "menuItem": menuItem });
                var ResultAjaxRequet = $.ajax({
                    url: "../Default.aspx/MenuItemClick",
                    contentType: "application/json",
                    cache: false,
                    type: "POST",
                    data: data,
                    async: true,
                    error: function (err) {
                        alert('ERR');

                    },
                    success: function (data) {
                        if (data.d != null && data.d.toString().trim().length != 0) {
                            var oManager = GetRadWindowManager();
                            oManager.closeAll();
                            var r = data.d.toString().split(":|:");
                            oWindow = radopen(r[0], r[1]);
                            oWindow.set_title(r[1]);
                            oWindow.set_visibleStatusbar(false);
                            if (r[2] == "isRestricted=true") oWindow.set_restrictionZoneID('<%=ContentZone.ClientID %>');
                            oWindow.set_destroyOnClose(true);
                            oWindow.set_animation(Telerik.Web.UI.WindowAnimation.Fade);
                            oWindow.setActive(true);
                            oWindow.maximize();
                            oWindow.center();
                        }
                    }
                });
            }
        </script>
    </telerik:RadCodeBlock>

    <script language="javascript" type="text/javascript">
        $(function () {
            setInterval(KeepSessionAlive, 10000);
        });

        function KeepSessionAlive() {
            $.post("Services/KeepSessionAlive.ashx", null, function () {
                $("#result").append("<p>Session is alive and kicking!<p/>");
            });
        }
    </script>
    

</head>
<body style="overflow: hidden">
    <form id="form1" runat="server" style="height: 100%; overflow: hidden">
        <div style="width: 100%; height: 40px; background-color: #66aeff; background-image: url('<%=WebClassLibrary.JWebSettings.GetKey("WebSiteLogoHeaderImage") %>'); background-position: right; background-repeat: no-repeat">
            <div class="siteHeader" style="float: right; width: 100%; color: white">
                <%=WebClassLibrary.JWebSettings.GetKey("WebSiteLogoText") %>
                <span style="float: left"><%=WebClassLibrary.JWebSettings.GetKey("WebSiteDescriptionText") %></span>
            </div>
            <div style="float: left; display: none">
                <%--<telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" Skin="Metro" />--%>
                <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Windows7" ShowChooser="false" />
                <telerik:RadWindowManager runat="server" ID="winMgr" Style="z-index: 20000" />
            </div>
        </div>
        <div style="" class="topMenuBar" id="topMenuBar">
            <table style="width: 100%; height: 25px">
                <tr>
                    <td>
                        <span id="NormalMenu">
                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                <%
                                    Response.Write("&lt;" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUser.username + "&gt;، " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle + "");
                                %>
                            </telerik:RadCodeBlock>
                            <a href="#" onclick="document.getElementById('PostMenu').style.display='block';document.getElementById('NormalMenu').style.display='none'">( تغییر سمت )</a>
                        </span>
                        <span style="display: none;" id="PostMenu">انتخاب پست: 
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%
                        foreach (System.Data.DataRow dr in (new Employment.JEOrganizationChart()).GetUserPostsByUser_code(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode).Rows)
                        {
                            Response.Write("<a href=\"?cp=" + WebClassLibrary.JDataManager.EncryptString(dr["Code"].ToString()) + "\">" + (new Employment.JPostTitle(Convert.ToInt32(dr["PostTitleCode"]))).Title + "</a>&nbsp;&nbsp;-&nbsp;&nbsp;");
                        }
                    %>
                </telerik:RadCodeBlock>
                            <a href="#" onclick="document.getElementById('PostMenu').style.display='none';document.getElementById('NormalMenu').style.display='block'">( بازگشت )</a>
                        </span>
                    </td>
                    <td style="width: 70px">
                        <a href="#" onclick="ShowMenu('<%=new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>(){ new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration.MainConfiguration",null,null)},"","","",null).ActionsToString() %>');" ><img src="Images/config.png" alt="پروفایل" title="پروفایل" /></a>&nbsp;
                        <a href="?act=logout">
                            <img src="Images/logout.png" alt="خروج از سیستم" title="خروج از سیستم" /></a>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none">
            <telerik:RadAjaxManager ID="AjaxManagerProxy1" runat="server" DefaultLoadingPanelID="AxajLoadingPanel">
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel runat="server" ID="AxajLoadingPanel" />
            <telerik:RadWindowManager runat="server" DestroyOnClose="true" EnableViewState="false"></telerik:RadWindowManager>
        </div>
        <div runat="server" id="MainDiv">
            <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="100%" SplitBarsSize="0" OnLoad="RadSplitter1_Load">
                <telerik:RadPane ID="RightPane" runat="server" Width="250" Scrolling="None">
                </telerik:RadPane>
                <telerik:RadPane ID="MiddlePane" runat="server" Width="100%" Scrolling="None">
                    <div id="ContentZone" runat="server" style="border: 1px solid #FFF; width: 100%; height: 100%; overflow: hidden; padding: 0px; margin: 0px;"></div>
                </telerik:RadPane>
            </telerik:RadSplitter>
        </div>
    </form>
</body>
</html>
<script>
    window.onresize = function (evt) {
        AutoSizePage();
    }
    function AutoSizePage() {
        var sHeight = document.documentElement.clientHeight;
        sHeight -= 65;
        $("#<%=MainDiv.ClientID %>").css('height', sHeight);
    }
    AutoSizePage();
</script>
<script  type="text/javascript" src="Script/jquery-1.6.4.js" ></script>
<script  type="text/javascript" src="Script/jquery.signalR-2.2.2.js" ></script>
<script type="text/javascript">
       $(function () {



           if (!Notification) {
               alert('Desktop notifications not available in your browser. Try Chromium.');
               return;
           }

           if (Notification.permission !== "granted")
               Notification.requestPermission();
           var connection = $.hubConnection("http://localhost:8080/signalr");
           var Notify = connection.createHubProxy('Notification');
           Notify.on('broadcastMessage', function (name, message) {

               if (Notification.permission !== "granted")
                   Notification.requestPermission();
               else {
                   var notification = new Notification('Notification title', {
                       icon: '/Images/Logos/tabriz_bus2.png',
                       body: name + ': ' + message ,
                   });

                   notification.onclick = function () {
                       window.open("/Default.aspx");
                   };

               }

           });

           connection.start()
               .done(function () {
                   Notify.invoke('Run', '<%= WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode %>', 'msg');
                   console.log('Now connected, connection ID=' + connection.id);
               })
               .fail(function () { console.log('Could not connect'); });

       });

</script>