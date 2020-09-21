<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlineMapNew.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOnlineMapNew" %>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AVL" Namespace="AVL.Controls.ToggleSlide" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map.NewMapControl" TagPrefix="cc1" %>
<%@ Register Src="~/WebBusManagement/FormsReports/JOnlineMapPanel.ascx" TagPrefix="uc1" TagName="JOnlineMapPanel" %>


<style>
    
@font-face {
    font-family: 'BMitra';
    src: url('../WebAVL/Fonts/BMitra.eot');
    src: url('../WebAVL/Fonts/BMitra.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BMitra.woff') format('woff'),
         url('../WebAVL/Fonts/BMitra.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'BMitraBold';
    src: url('../WebAVL/Fonts/BMitraBold.eot');
    src: url('../WebAVL/Fonts/BMitraBold.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BMitraBold.woff') format('woff'),
         url('../WebAVL/Fonts/BMitraBold.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}

@font-face {
    font-family: 'B Roya';
    src: url('../WebAVL/Fonts/BRoya.eot');
    src: url('../WebAVL/Fonts/BRoya.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BRoya.woff') format('woff'),
         url('../WebAVL/Fonts/BRoya.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'BTabassom';
    src: url('../WebAVL/Fonts/BTabassom.eot');
    src: url('../WebAVL/Fonts/BTabassom.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTabassom.woff') format('woff'),
         url('../WebAVL/Fonts/BTabassom.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'BTitr';
    src: url('../WebAVL/Fonts/BTitr.eot');
    src: url('../WebAVL/Fonts/BTitr.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTitr.woff') format('woff'),
         url('../WebAVL/Fonts/BTitr.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}

@font-face {
    font-family: 'BTitrTGE';
    src: url('../WebAVL/Fonts/BTitrTGE.eot');
    src: url('../WebAVL/Fonts/BTitrTGE.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTitrTGE.woff') format('woff'), 
         url('../WebAVL/Fonts/BTitrTGE.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}

@font-face {
    font-family: 'BYekan';
    src: url('../WebAVL/Fonts/BYekan.eot');
    src: url('../WebAVL/Fonts/BYekan.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BYekan.woff') format('woff'),
         url('../WebAVL/Fonts/BYekan.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}


@font-face {
    font-family: 'BTraffic';
    src: url('../WebAVL/Fonts/BTraffic.eot');
    src: url('../WebAVL/Fonts/BTraffic.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTraffic.woff') format('woff'),
         url('../WebAVL/Fonts/BTraffic.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}


 @font-face {
    font-family: 'BNasim';
    src: url('../WebAVL/Fonts/BNasim.eot');
    src: url('../WebAVL/Fonts/BNasim.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BNasim.woff') format('woff'),
         url('../WebAVL/Fonts/BNasim.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}
    ul{
        list-style:none;
        direction: ltr;
    }
    li {
        padding: 10px;
        margin-top: 1px;
        border-bottom: thin solid white;
    }
    span{
        font-family: "B Roya";
font-size: large;
    }
    input[type=submit]{
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
    .dropdown{   
         width: 100%;
    height: 30px;
    font-family: "B Roya";
font-size: large;
    }
    .dropdown option{
        font-family: "B Roya";
font-size: large;
    }
    .buttonContainer1 {
        margin-top:5px;
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
        height:45px; 
        left: 47%; 
        opacity: 1;
        cursor: pointer;
    }
    .MenuContainer {
        padding-top: 10px;
        padding-right: 30px;
    }

    .MapMenu {
        background-color: #fff;
        background-image: url("WebAVL/Images/webAVLImages/menu.png");
        background-repeat:no-repeat;
        background-position:center;
        border: 2px solid #fff;
        border-radius: 3px;
        box-shadow: 0 2px 6px rgba(0,0,0,.3);
        cursor: pointer;
        /*text-align: center;*/
        width:20px;
        height:20px;
    }
    
    .MapMenu:hover {
        border: 2px solid rgba(220, 220, 220, 1);
        box-shadow: 0 2px 6px rgba(0,0,0,.6);
    }

    .MapMenu div {
        color: rgb(25,25,25);
        font-family: Roboto,Arial,sans-serif;
        font-size: 12px;
        line-height: 38px;
        padding-left: 5px;
        padding-right: 5px;
    }

    .SubMenu {
        background-color: #fff;
        border: 2px solid #fff;
        border-radius: 3px;
        box-shadow: 0 2px 6px rgba(0,0,0,.3);
        cursor: pointer;
        /*text-align: center;*/
        display:none;
    }
    
    .SubMenu:hover {
        border: 2px solid rgba(220, 220, 220, 1);
        box-shadow: 0 2px 6px rgba(0,0,0,.6);
    }

    .SubMenu div {
        color: rgb(25,25,25);
        font-family: Roboto,Arial,sans-serif;
        font-size: 13px;
        line-height: 30px;
        padding-left: 8px;
        padding-right: 0px;
        display:inline;
    }

    .labels{
    color: black;
    background-color: beige;
    font-family: "Arial";/*"Lucida Grande", "Arial", sans-serif*/
    font-size: 12px;
    text-align: center;
    width: auto;     
    white-space: nowrap;
    padding: 4px;
    border: 1px solid grey;
    border-radius:3px;   
    box-shadow: 2px 2px 20px #888888;
        /*position: absolute;
        color: blue;
        font-size: 16px;
        font-weight: bold;*/
    }
</style>

<div style="width: 99%; height: 100%">
   <cc1:NewGoogleMap id="Googlemap" runat="server" 
       Width="100%" Height="100%" 
       CenterLatitude="36.4" CenterLongitude="50.4"
       Zoom="11" 
       Interval="1000" 
       WebServiceUrl="/Services/WebBaseDefineService.asmx/GetBusMarkers" 
       Layers ="[{'Name':'ایستگاه مسیر رفت', 'WebServiceUrl': '/Services/WebBaseDefineService.asmx/GetStationsGo', 'AddingMarkers': true}
       ,{'Name':'ایستگاه مسیر یرگشت', 'WebServiceUrl': '/Services/WebBaseDefineService.asmx/GetStationsBack', 'AddingMarkers': true}
       ,{'Name':'عدم رعایت فاصله', 'AddingMarkers': false, 'StyleName': 'NearNextBus'}
       ,{'Name':'خروج از مسیر', 'AddingMarkers': false, 'StyleName': 'OutLine'}
       ,{'Name':'عدم استفاده از کارت حضور و غیاب', 'AddingMarkers': false, 'StyleName': 'UnknownDriver'}
       ,{'Name':'سرعت غیرمجاز', 'AddingMarkers': false, 'StyleName': 'Overspeed'}
       ,{'Name':'توقف طولانی مدت', 'AddingMarkers': false, 'StyleName': 'LongStop'}
       ,{'Name':'آنلاین', 'AddingMarkers': false, 'StyleName': 'OnLine'}
       ,{'Name':'آفلاین', 'AddingMarkers': false, 'StyleName': 'OffLine'}]"
       PopupWebService="/Services/WebBaseDefineService.asmx/getInfoBus" 
       AnimateIcon="getIcon.aspx?t=a"
       ImageSize ="42,42,26,26"
       ClassName ="WebAVL_Forms_GoogleMap_createGridNORMAL"
       ></cc1:NewGoogleMap>
</div>
<%-- <cc1:TogglePanel ID="togglepanel" runat="server" ButtonIconUrl="/Images/collapse-vertical.png" Width="100%" Height="400" 
     style="width: 100%; height: 400px; position: absolute;bottom:0px;background-color:rgba(208, 151, 164, 0.7);">
 </cc1:TogglePanel>--%>

<div style="width: 100%; height: auto; position: fixed;bottom:0px;background-color:rgba(208, 151, 164, 0.7);"> 
 <uc1:JOnlineMapPanel ID="togglepanel" runat="server" Width="100%">

 </uc1:JOnlineMapPanel>

</div>
<script>
    var a = document.getElementById('ButtonsDiv');
    a.parentNode.removeChild(a);

    function MyControl(MenuContainer, that) {
        $(MenuContainer).addClass('MenuContainer');

        var MapMenu = document.createElement('div');
        $(MapMenu).addClass('MapMenu');
        //MapMenu.title = 'Click to recenter the map';
        MenuContainer.appendChild(MapMenu);

        for (var i = 0; i < that.get_layers().length; i++)
        {
            var SubMenu = document.createElement('div');
            $(SubMenu).addClass('SubMenu');
            //SubMenu.title = 'Click to recenter the map';
            MenuContainer.appendChild(SubMenu);

            var CheckBoxdiv = document.createElement('div');
            SubMenu.appendChild(CheckBoxdiv);

            var SubMenuText = document.createElement('div');
            SubMenuText.innerHTML = that.get_layers()[i].Name;
            SubMenu.appendChild(SubMenuText);

            var CheckBox = document.createElement('input');
            CheckBox.type = 'checkbox';
            CheckBox.id = "CB" + i;
            $(CheckBox).addClass({ 'vertical-align': 'middle' });
            CheckBox.Index = i;
            CheckBox.onchange = function () {
                if (this.checked)
                {
                    ShowWarining('در  حال بارگذاری ...', true, 3, false);
                    if (that.get_layers()[this.Index].AddingMarkers)
                    {
                        that.AddLayer(that, that.get_layers()[this.Index].WebServiceUrl, this.Index);
                    }
                    else
                        that.ToggleStyle(that, that.get_layers()[this.Index].StyleName, true);
                }
                else
                {
                    if (that.get_layers()[this.Index].AddingMarkers)
                        that.RemoveLayer(that, this.Index);
                    else
                        that.ToggleStyle(that, that.get_layers()[this.Index].StyleName, false);
                }
            };
            CheckBoxdiv.appendChild(CheckBox);

            $(SubMenu).mouseover(function () {
                BoxMouseOver = 'SubMenu';
                $('.SubMenu').css('display', 'block');
            }).mouseout(function () {
                BoxMouseOver = '';
                window.setTimeout(function () {
                    if (BoxMouseOver == '' || BoxMouseOver == 'Menu')
                        $('.SubMenu').css('display', 'none');
                }, 300);
            });
        }

        var MapMenuText = document.createElement('div');
        MapMenuText.innerHTML = 'Menu';
        //MapMenu.appendChild(MapMenuText);

        $(MapMenu).click(function () {
            BoxMouseOver = 'Menu';
            $('.SubMenu').css('display', 'block');
        }).mouseover(function () {
            BoxMouseOver = 'Menu';
        }).mouseout(function () {
            BoxMouseOver = '';
            window.setTimeout(function () {
                if (BoxMouseOver == '')
                    $('.SubMenu').css('display', 'none');
            }, 300);
        });
        //MapMenu.addEventListener('click', function () {
        //    alert(33);
        //});
    }
    var BoxMouseOver = '';
</script>

<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlineMapNew.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOnlineMapNew" %>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map" TagPrefix="cc1" %>
<cc1:Map ID="Map1" runat="server" CenterLatitude="38.068636" CenterLongitude="46.294956"
     WebServiceUrl="/Services/WebBaseDefineService.asmx/GetCarsNew"  
   PopupWebService="/Services/WebBaseDefineService.asmx/GetPoupuoCars"  Width="100%" Height="100%" Zoom="12" Interval="10000" GetDetailsInterval="3000"></cc1:Map>--%>