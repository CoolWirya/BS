<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMapDirection.ascx.cs" Inherits="WebAVL.Forms.GoogleMapDirection" %>



<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map.NewMapControl" TagPrefix="cc1" %>
<%@ Register Src="~/WebAVL/Controls/Search/JSearchDevice.ascx" TagPrefix="cc1" TagName="JSearchDevice" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

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
        font-size: small;
        direction:ltr;
    }
    input[type=submit] {
        background-color: #F00;
        padding: 6px;
        border: medium none;
        text-align: center;
        background-position: 100%;
        background-repeat: no-repeat;
        font-family: "B Roya";
        font-size: small;
    }

    input[type=text] {
        font-family: "B Roya";
        font-size: small;
        border: solid thin white;
        width: 50px;
    }

    .dropdown {
        border: solid thin white;
        font-family: "B Roya";
        font-size: small;
    }

        .dropdown option {
            font-family: "B Roya";
            font-size: small;
        }

    .textbox {
        font-family: "B Roya";
        font-size: small;
        border: solid thin white;
        border: solid thin white;
    }

    input[type=text]:active {
        border: solid thin yellow;
    }

    .trasparentBackground {
        background: rgba(8, 19, 137, 0.70);
    }
</style>



<div id="Mnu_ControlPanel" class="trasparentBackground" style="width: 100%; height: auto; position: absolute; top: 0px; z-index: 999; color: white; display: block">

    <div style="height: 50px; width: 50px; -ms-transform: rotate(270deg); -webkit-transform: rotate(270deg); transform: rotate(270deg); position: absolute; top: 0px; left: 0px; cursor: pointer"
        onclick="FuncCloseControlPanel();">
        <img style="width: 40px; height: 100px;" src="<%= ResolveClientUrl("~/WebAVL/Image/CloseControlPanel.png") %>"
            alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>

    <%--Path Div--%>
    <div id="PathShowMenuBot" style="width: 100%; height: 100%; overflow: auto">

        <div style="width: 96%; height: auto; text-align: right; opacity: 1; padding-right: 5px; direction: rtl">

            <table dir="rtl">
                <tr>
                    <td><span>متحرک  :</span></td>
                    <td>
                        <cc1:JSearchDevice runat="server" ID="searchDevice" Colorfull="true" MultipleSelection="true" OnClientClick="return false;" AutoPostBack="false"></cc1:JSearchDevice>
                    </td>
                    <td><span>از تاریخ :</span></td>

                    <td>
                        <uc1:JDateControl ID="clrFromDate" runat="server" CssClass="textbox"></uc1:JDateControl></td>

                    <td><span>ساعت شروع :</span></td>
                    <td>
                        <%--ساعت:   
                        <asp:TextBox ID="txtFromHour" runat="server" CssClass="textbox"></asp:TextBox>
                        --%>
                        <cc1:TimeSelector ID="TimeStart" runat="server"
                            DisplaySeconds="false"
                            SelectedTimeFormat="TwentyFour">
                        </cc1:TimeSelector>


                    </td>
                    <%--                    <td>دقیقه: 
                        <asp:TextBox ID="txtFromMin" runat="server" CssClass="textbox"></asp:TextBox></td>--%>
                </tr>
                <tr>
                    <td><span>سرعت نمایش حرکت</span></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSpeed" AutoPostBack="false" CssClass="dropdown" OnSelectedIndexChanged="ddlSpeed_SelectedIndexChanged"></asp:DropDownList></td>

                    <td><span>تا تاریخ :</span></td>
                    <td>
                        <uc1:JDateControl ID="clrToDate" runat="server" CssClass="textbox"></uc1:JDateControl>



                    </td>


                    <td><span>ساعت پایان:</span></td>
                    <td>
                        <%--  ساعت:  
                        <asp:TextBox ID="txtToHour" runat="server" CssClass="textbox"></asp:TextBox>--%>
                        <cc1:TimeSelector ID="timeEnd" runat="server"
                            DisplaySeconds="false"
                            SelectedTimeFormat="TwentyFour">
                        </cc1:TimeSelector>
                    </td>
                    <%-- <td>دقیقه:  
                        <asp:TextBox ID="txtToMin" runat="server" CssClass="textbox"></asp:TextBox></td>--%>
                    <td rowspan="2">
                        <telerik:RadButton ID="Button1" runat="server" Text="نمایش مسیر حرکت" OnClick="Button1_Click" CssClass="Nothing" AutoPostBack="true" />

                    </td>
                </tr>

            </table>
        </div>
        <div id="NumberOfTransactionCount" style="width: 96%; height: auto; text-align: right; padding-right: 5px; direction: rtl"></div>

    </div>
</div>

<div style="width: 100%; height: 100%">
    <%--     <cc1:Map ID="GoogleMap1" runat="server" CenterLatitude="35.6961" Zoom="7"  
        CenterLongitude="51.4231"   
         PointWebservice="/Services/WebBaseDefineService.asmx/GetDirection" 
            PopupWebService="/Services/WebBaseDefineService.asmx/GetInfo"
         Interval="10000"
            Width="100%" Height="100%"  ShowLinesAutomatically="false">
        </cc1:Map>--%>
    <cc1:NewGoogleMap ID="Googlemap" runat="server"
        Width="100%" Height="100%"
        CenterLatitude="36.4" CenterLongitude="50.4"
        Offline="true"
        Zoom="11"
        Interval="2000"
        Speed="1000"
        DeviceCode="0"
        WebServiceUrl="/Services/WebBaseDefineService.asmx/GetDirection"
        PopupWebService="/Services/WebBaseDefineService.asmx/getInfo"
        ClassName="WebAVL_Forms_GoogleMap_createGridNORMAL"
        OfflineMapAnimated="false"></cc1:NewGoogleMap>

    <script type='text/javascript'>
       
    </script>
</div>
<div id="OpenControlPanel" style="-ms-transform: rotate(270deg); -webkit-transform: rotate(270deg); transform: rotate(270deg); height: 50px; width: 50px; position: absolute; top: 0px; left: 0px; cursor: pointer; z-index: 998; display: none"
    onclick="FuncOpenControlPanel();">
    <img style="width: 40px; height: 100px;" src="<%= ResolveClientUrl("~/WebAVL/Image/OpenControlPanel.png") %>"
        alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>

<script type="text/javascript">
    function FuncOpenControlPanel() {
        $("#Mnu_ControlPanel").fadeIn();
        $("#OpenControlPanel").fadeOut();
    }

    function FuncCloseControlPanel() {
        $("#Mnu_ControlPanel").fadeOut();
        $("#OpenControlPanel").fadeIn();
    }


</script>
