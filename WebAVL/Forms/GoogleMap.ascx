<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMap.ascx.cs" Inherits="WebAVL.Forms.GoogleMap" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map" TagPrefix="cc1" %>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.ToggleSlide" TagPrefix="cc1" %>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map.NewMapControl" TagPrefix="cc1" %>



<style>
    @font-face {
        font-family: 'BMitra';
        src: url('../WebAVL/Fonts/BMitra.eot');
        src: url('../WebAVL/Fonts/BMitra.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BMitra.woff') format('woff'), url('../WebAVL/Fonts/BMitra.ttf') format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    @font-face {
        font-family: 'BMitraBold';
        src: url('../WebAVL/Fonts/BMitraBold.eot');
        src: url('../WebAVL/Fonts/BMitraBold.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BMitraBold.woff') format('woff'), url('../WebAVL/Fonts/BMitraBold.ttf') format('truetype');
        font-weight: bold;
        font-style: normal;
    }

    @font-face {
        font-family: 'B Roya';
        src: url('../WebAVL/Fonts/BRoya.eot');
        src: url('../WebAVL/Fonts/BRoya.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BRoya.woff') format('woff'), url('../WebAVL/Fonts/BRoya.ttf') format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    @font-face {
        font-family: 'BTabassom';
        src: url('../WebAVL/Fonts/BTabassom.eot');
        src: url('../WebAVL/Fonts/BTabassom.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BTabassom.woff') format('woff'), url('../WebAVL/Fonts/BTabassom.ttf') format('truetype');
        font-weight: normal;
        font-style: normal;
    }


    @font-face {
        font-family: 'BTitr';
        src: url('../WebAVL/Fonts/BTitr.eot');
        src: url('../WebAVL/Fonts/BTitr.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BTitr.woff') format('woff'), url('../WebAVL/Fonts/BTitr.ttf') format('truetype');
        font-weight: bold;
        font-style: normal;
    }

    @font-face {
        font-family: 'BTitrTGE';
        src: url('../WebAVL/Fonts/BTitrTGE.eot');
        src: url('../WebAVL/Fonts/BTitrTGE.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BTitrTGE.woff') format('woff'), url('../WebAVL/Fonts/BTitrTGE.ttf') format('truetype');
        font-weight: bold;
        font-style: normal;
    }


    @font-face {
        font-family: 'BYekan';
        src: url('../WebAVL/Fonts/BYekan.eot');
        src: url('../WebAVL/Fonts/BYekan.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BYekan.woff') format('woff'), url('../WebAVL/Fonts/BYekan.ttf') format('truetype');
        font-weight: normal;
        font-style: normal;
    }


    @font-face {
        font-family: 'BTraffic';
        src: url('../WebAVL/Fonts/BTraffic.eot');
        src: url('../WebAVL/Fonts/BTraffic.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BTraffic.woff') format('woff'), url('../WebAVL/Fonts/BTraffic.ttf') format('truetype');
        font-weight: normal;
        font-style: normal;
    }


    @font-face {
        font-family: 'BNasim';
        src: url('../WebAVL/Fonts/BNasim.eot');
        src: url('../WebAVL/Fonts/BNasim.eot?#iefix') format('embedded-opentype'), url('../WebAVL/Fonts/BNasim.woff') format('woff'), url('../WebAVL/Fonts/BNasim.ttf') format('truetype');
        font-weight: bold;
        font-style: normal;
    }

    ul {
        list-style: none;
        direction: ltr;
    }

    li {
        padding: 10px;
        margin-top: 1px;
        border-bottom: thin solid white;
    }

    span {
        font-family: "B Roya";
        font-size: large;
    }

    input[type=submit] {
        width: 100%;
        height: 100%;
        background-color: #F00;
        padding: 6px;
        border: medium none;
        text-align: center;
        background-position: 100%;
        background-repeat: no-repeat;
        font-family: "B Roya";
        font-size: large;
    }

    .dropdown {
        width: 100%;
        height: 30px;
        font-family: "B Roya";
        font-size: large;
    }

        .dropdown option {
            font-family: "B Roya";
            font-size: large;
        }

    .buttonContainer1 {
        margin-top: 5px;
        background-image: url("WebAVL/Images/webAVLImages/OneMarker.png");
    }

    .buttonContainer2 {
        background-image: url("WebAVL/Images/webAVLImages/severalMarkers.png");
    }

    .HeightSpace0 {
        clear: both;
        height: 0px;
    }

    .HeightSpace05 {
        clear: both;
        height: 05px;
    }

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }

    .HeightSpace15 {
        clear: both;
        height: 15px;
    }

    .HeightSpace20 {
        clear: both;
        height: 20px;
    }

    .HeightSpace30 {
        clear: both;
        height: 30px;
    }

    .trasparentBackground {
        background: rgba(8, 19, 137, 0.70);
    }

    .ButtonIcon {
        position: absolute;
        top: -37.5px;
        height: 37.5px;
        width: 5%;
        left: 47.5%;
        opacity: 0.6;
        -webkit-transition: all 0.1s ease-in-out, transform 0.6s ease-in-out;
        -moz-transition: all 0.1s ease-in-out, transform 0.6s ease-in-out;
        transition: all 0.1s ease-in-out, transform 0.6s ease-in-out;
        -ms-transform: rotateX(180deg);
        -webkit-transform: rotateX(180deg);
        transform: rotateX(180deg);
    }

        .ButtonIcon:hover {
            top: -45px;
            width: 6%;
            height: 45px;
            left: 47%;
            opacity: 1;
            cursor: pointer;
        }
</style>
<div style="width: 99%; height: 100%">
    <cc1:NewGoogleMap ID="Googlemap" runat="server"
        Width="100%" Height="100%"
        CenterLatitude="36.3" CenterLongitude="59.59"
        Zoom="11"
        Interval="1000"
        WebServiceUrl="/Services/WebBaseDefineService.asmx/GetMarkers"
        PopupWebService="/Services/WebBaseDefineService.asmx/getInfo"
        ImageSize="64,64,32,64"
        Layers="[{'Name':'آنلاین', 'AddingMarkers': false, 'StyleName': 'OnLine'}
       ,{'Name':'آفلاین', 'AddingMarkers': false, 'StyleName': 'OffLine'}]"
        ClassName="WebAVL_Forms_GoogleMap_createGridNORMAL"></cc1:NewGoogleMap>
</div>


<cc1:TogglePanel ID="togglepanel" runat="server" ButtonIconUrl="/Images/collapse-vertical.png" Width="100%" Height="400" Style="width: 100%; height: 400px; position: absolute; bottom: 0px; background-color: rgba(208, 151, 164, 0.7);">

    <div id="PathShowMenuTop" style="float: right; padding: 2px 10px 0 10px; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('PathShowMenuTop');">
        دستگاه ها
    </div>
    <div id="HelpMenuTop" style="float: right; padding: 2px 10px 0 10px; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('HelpMenuTop');">
        راهنما
    </div>
    <div style="clear: both; border-top: solid 2px #3AC0F2">
    </div>
    <div id="PathShowMenuBot" style="height: 350px">
        <asp:Panel runat="server" ID="pnldevices">
        </asp:Panel>
    </div>
    <div id="HelpMenuBot" style="height: 350px; direction: rtl">
        <table>
            <tr class="Titles">
                <td>آنلاین ها امروز</td>
                <td>آنلاین در روز های گذشته</td>
            </tr>
            <tr class="Icons">
                <td>
                    <img src="<%=TodayOnlineIcon%>" />
                </td>
                <td>
                    <img src="<%=PastOnlineIcon%>" />
                </td>
            </tr>
            <tr class="Colors">
                <td></td>
                <td>
                    <div id="dvNearNextBus" runat="server"></div>
                </td>
                <td>
                    <div id="dvOutLine" runat="server"></div>
                </td>
            </tr>
        </table>
    </div>
</cc1:TogglePanel>



<script>
    var a = document.getElementById('ButtonsDiv');
    a.parentNode.removeChild(a);
</script>
<script type="text/javascript">
    function TogglePanel(that) {
        var a = document.getElementById('OnlineMapPanel');
        if (a.style.height == '0px') {
            a.style.height = '400px';
            $(that).css('transform');
            $(that).css({ 'transform': 'rotateX(180deg)' });
        } else {
            a.style.height = '0px';
            $(that).css('transform');
            $(that).css({ 'transform': 'rotateX(0deg)' });
        }
    }
    SelectTab('PathShowMenuTop');
    function SelectTab(STabId) {

        if (STabId == "PathShowMenuTop") {
            $("#PathShowMenuTop").css('height', '20px');
            $("#PathShowMenuTop").css('background-color', '#3AC0F2');

            $("#HelpMenuTop").css('height', '19px');
            $("#HelpMenuTop").css('background-color', 'transparent');

            $("#SimulationMenuBot").css('display', 'none');
            $("#HelpMenuBot").css('display', 'none');
            $("#PathShowMenuBot").fadeIn();
        }
        else if (STabId == "HelpMenuTop") {
            $("#HelpMenuTop").css('height', '20px');
            $("#HelpMenuTop").css('background-color', '#3AC0F2');

            $("#PathShowMenuTop").css('height', '19px');
            $("#PathShowMenuTop").css('background-color', 'transparent');

            $("#PathShowMenuBot").css('display', 'none');
            $("#SimulationMenuBot").css('display', 'none');
            $("#HelpMenuBot").fadeIn();
        }

    }
</script>
