<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlineMapPanel.ascx.cs" Inherits="WebBusManagement.FormsReports.JOnlineMapPanel" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<style>
    .Titles td {
        font: normal bold 12px "Segoe UI",Arial;
        padding:5px;
        width:100px;
        height:50px;
        text-align:center;
        vertical-align:middle;
    }

    .Icons td {
        width:100px;
        height:50px;
    }

    .Icons img {
        margin: 9px 34px;
    }

    .Colors td {
        width:100px;
        height:40px;
    }

    .Colors div {
        width:20px;
        height:20px;
        margin: 10px 40px; 
        border-radius: 10px;
        
    }
</style>
<div id="OnlineMapPanel" style="height:400px; overflow:auto"> 

    <img src='/Images/collapse-vertical.png' alt='toggle' onClick="TogglePanel(this);" class='ButtonIcon'/> 

    
    <div id="PathShowMenuTop" style="float: right; padding: 2px 10px 0 10px; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('PathShowMenuTop');">
        اطلاعات اتوبوس
    </div>
    <div id="HelpMenuTop" style="float: right; padding: 2px 10px 0 10px; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('HelpMenuTop');">
        راهنما
    </div>
    <div style="clear:both; border-top:solid 2px #3AC0F2"> 
    </div>  
    <div id="PathShowMenuBot" style="height:350px">  
        <cc1:JGridView runat="server" id="RadGridReport">
        </cc1:JGridView> 
    </div> 
    <div id="HelpMenuBot" style="height:350px; direction:rtl">  
        <table>
            <tr class="Titles">
                <td>مارکر عمومی</td>
                <td>عدم رعایت فاصله</td>
                <td>خروج از مسیر</td>
                <td>عدم استفاده از کارت حضور و غیاب</td>
                <td>سرعت غیرمجاز</td>
                <td>توقف طولانی مدت</td>
            </tr>
            <tr class="Icons">
                <td>
                    <img src="<%=DefaultMarker%>"/>
                </td>
                <td>
                    <img src="<%=NearNextBus%>"/>  
                </td>
                <td>
                    <img src="<%=OutLine%>"/>  
                </td>
                <td>
                    <img src="<%=UnknownDriver%>"/>   
                </td>
                <td>
                    <img src="<%=Overspeed%>"/>   
                </td>
                <td>
                    <img src="<%=LongStop%>"/>  
                </td>
            </tr>
            <tr class="Colors">
                <td>
                </td>
                <td>
                    <div id="dvNearNextBus" runat="server">   </div>    
                </td>
                <td>
                    <div id="dvOutLine" runat="server">   </div>    
                </td>
                <td>
                    <div id="dvUnknownDriver" runat="server">   </div>    
                </td>
                <td>
                    <div id="dvOverspeed" runat="server">   </div>    
                </td>
                <td>
                    <div id="dvLongStop" runat="server">   </div>    
                </td>
            </tr>
        </table>
    </div>
</div>
<script type="text/javascript">    
    function TogglePanel(that){
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
