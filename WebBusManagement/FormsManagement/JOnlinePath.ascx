<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlinePath.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOnlinePath" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });
</script>--%>

<style>

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }

    .trasparentBackground {
        background: rgba(8, 19, 137, 0.70);
    }
    #dv_info {
    position: fixed;
    -webkit-transition: all 0.4s;
    transition: all 0.4s;
    width:0px;
    height: 0px;
    padding: 0px 15px;
    left: 0px;
    margin-top: 200px;
    z-index:101;
    overflow:hidden;
    border-radius: 5px;
    box-shadow: 0px 3px 10px rgba(34, 25, 25, 0.4);
    background-color:rgba(255, 255, 255, 0.78);
    }
    .a_close {
    float:left;
    margin: 10px 10px 10px -5px;
    color: rgba(170, 170, 170, 0.7);
    font-size: 1.4rem;
    line-height: 10px;
    font-weight: 600;
    }
</style>
<div id="OpenControlPanel" style="width: 40px; height: 100px; position: absolute; top: 40px; right: 0px; cursor: pointer; z-index: 5999; display: none"
    onclick="FuncOpenControlPanel();">
    <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/OpenControlPanel.png") %>"
        style="width: 40px; height: 100px" alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>
    <div id="dv_info">
        <div style="height: 30px;"> 
        <a href='#' class="a_close" onclick="CloseProperties()">×</a>   
        </div>
        <div id="dv_info_content">   
        </div> 
    </div>
<%--position: absolute; top: 0px; right: 0px; z-index: 999;--%>

<div id="Mnu_ControlPanel" class="trasparentBackground" style="width: 250px; height: 95%;  color: white; float:right;display: block;">
    <%--Path Div--%>
    <div id="PathShowMenuBot" style="float:right; width:200px; margin-top:20px">
        <div class="HeightSpace10"></div>
        <%--<div style="width: 96%; height: auto; text-align: right; opacity: 1; padding-right: 5px; direction: rtl">--%>
        <ul style="padding: 0px 10px 0px 0px;">
            <li>خط :</li>
            <li>
                <telerik:RadComboBox runat="server" ID="cmbLines" Width="170px" Filter="Contains"></telerik:RadComboBox>
            </li>
            <li style="margin-top: 10px">تعداد ایستگاه در ردیف :</li>
            <li>
                <telerik:RadComboBox runat="server" ID="cmbStationPerLevel" Width="170px" Filter="Contains">
                    <Items>
                        <telerik:RadComboBoxItem Text="3" Value="3"/>
                        <telerik:RadComboBoxItem Text="4" Value="4"/>
                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                        <telerik:RadComboBoxItem Text="6" Value="6" Selected="true"/>
                        <telerik:RadComboBoxItem Text="7" Value="7"/>
                        <telerik:RadComboBoxItem Text="8" Value="8"/>
                        <telerik:RadComboBoxItem Text="9" Value="9"/>
                        <telerik:RadComboBoxItem Text="10" Value="10"/>
                    </Items>
                </telerik:RadComboBox>
            </li>
            <li style="margin-top: 10px">
                <div style="float:left">
                    <input type="button" id="BtnGetInfo" value="مشاهده مسیر خط" onclick="OnlinePath.Load()"/>
                </div>
            </li>
        </ul>
<%--            خط :
            <telerik:RadComboBox runat="server" ID="cmbLines" Width="170px" Filter="Contains"></telerik:RadComboBox>
            خط :
            <telerik:RadComboBox runat="server" ID="RadComboBox1" Width="170px" Filter="Contains"></telerik:RadComboBox>
            <div class="HeightSpace10"></div>
            <div style="float:left">
                <input type="button" id="BtnGetInfo" value="مشاهده مسیر خط" onclick="OnlinePath.Load()"/>
            </div>--%>

        <%--</div>--%>

    </div>
    <div style="float:left;width: 40px;  margin-top:50px; cursor: pointer" onclick="FuncCloseControlPanel();">
        <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/CloseControlPanel.png") %>"
            style="width: 40px; height: 100px" alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>
</div>
<div style="width: 800px; height: 500px;  background-color: white; float:right; display: block; overflow-y:auto">   
    <div id="PathPanel" style="width: 100%; position: relative; overflow-x: hidden">

    </div>
</div>
<script type="text/javascript">

    $(document).ready(function () {
        SetPathPanelSize();
        setInterval(function () { OnlinePath.GetBuses(); }, 5000);
    });

    $(window).resize(function () { SetPathPanelSize(); });

    function CloseProperties() {
        var dv_info = $('#dv_info');
        var PathPanel = document.getElementById('PathPanel');
        var parent_width = 0;
        if (document.getElementById('Mnu_ControlPanel').style.display == 'none') {
            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 50);
        }
        else {
            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 300);
        }
        $(dv_info).css({ 'width': '0px', 'height': '0px', 'left': (parent_width / 2 + 50) + 'px', 'margin-top': '200px' });
        document.getElementById('dv_info_content').innerHTML = '';
    }

    function SetPathPanelSize() {
        var dv_info = $('#dv_info');
        var PathPanel = document.getElementById('PathPanel');
        var parent_width = 0;
        if (document.getElementById('Mnu_ControlPanel').style.display == 'none')
            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 50);
        else{
            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 300);
        }
        PathPanel.parentNode.style.width = parent_width + 'px';
        PathPanel.parentNode.style.height = (PathPanel.parentNode.parentNode.clientHeight - 50) + 'px';
        if($(dv_info).width() == 0)
            $(dv_info).css({ 'width': '0px', 'height': '0px', 'left': (parent_width / 2 + 50) + 'px', 'margin-top': '200px' });
        else
            $(dv_info).css({'left': ((parent_width - 360) / 2 + 50) + 'px'});
    }

    function FuncOpenControlPanel() {
        $("#Mnu_ControlPanel").fadeIn();
        $("#OpenControlPanel").fadeOut(function () { SetPathPanelSize(); });
        SetPathPanelSize();
    }

    function FuncCloseControlPanel() {
        $("#Mnu_ControlPanel").fadeOut(function () { SetPathPanelSize(); });
        $("#OpenControlPanel").fadeIn(function () { SetPathPanelSize(); });
    }

    var OnlinePath =
    {
        PanelPaddingLeft: 80,
        PanelPaddingTop: 70,
        RoadWidth: 20,
        StationWidth: 40,
        BusWidth: 32,
        StationNameWidth: 130,
        StationNameHeight: 20,
        StationsHorizontalDistance: 130,
        StationsVerticalDistance: 100,
        GoStations: [],
        BackStations: [],
        StationCountPerLevel: 6,
        LineCode: 0,
        GettingStationData: false,
        GettingBusData: false,
        Load: function()
        {
            ShowWarining('در  حال بارگذاری ...', true, 3, false);
            var that = this;
            that.GettingStationData = true;
            that.Clear();
            var cmbLines = $find('<%=cmbLines.ClientID%>');
            var cmbStationPerLevel = $find('<%=cmbStationPerLevel.ClientID%>');
            that.LineCode = parseInt(cmbLines.get_selectedItem().get_value());
            that.StationCountPerLevel = parseInt(cmbStationPerLevel.get_selectedItem().get_value());
            var json = JSON.stringify({ 'LineCode': that.LineCode });
            var xmlhttp2 = that.AjaxRequest('/Services/WebBaseDefineService.asmx/GetLineStations', json);
            xmlhttp2.onreadystatechange = function () {
                if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                    var res = JSON.parse(xmlhttp2.responseText);
                    if (typeof res.d !== 'undefined' && res.d !== null) {
                        that.GoStations = res.d.GoStations;
                        that.BackStations = res.d.BackStations;
                        that.AddStationsAndRoad();
                        that.GettingStationData = false;
                    }
                }
                HideWarining();
            }
            xmlhttp2.send(json);
        },
        GetBuses: function()
        {
            var that = this;
            if (that.GettingStationData || that.GettingBusData)
                return;
            that.GettingBusData = true;
            var json = JSON.stringify({ 'LineCode': that.LineCode });
            var xmlhttp2 = that.AjaxRequest('/Services/WebBaseDefineService.asmx/GetBuses', json);
            xmlhttp2.onreadystatechange = function () {
                if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                    if (that.GettingStationData) {
                        that.GettingBusData = false;
                        return;
                    }
                    var res = JSON.parse(xmlhttp2.responseText);
                    if (typeof res.d !== 'undefined' && res.d !== null) {
                        var arrBuses = res.d;
                        for (var i = 0; i < arrBuses.length; i++)
                        {
                            if (document.getElementById(arrBuses[i].BusCode.toString()))
                            {
                                that.AnimateBus(arrBuses[i]);
                            }
                            else {
                                that.CreateBus(arrBuses[i]);
                            }
                        }
                    }
                    that.GettingBusData = false;
                }
            }
            xmlhttp2.send(json);
        },
        AnimateBus: function (bus)
        {
            try {
                var that = this;
                var MovePercent = bus.MovePercent;
                var Priority = bus.Priority;
                var IsBack = bus.IsBack;
                var NextStationPriority = bus.NextStationPriority;
                var NextStationIsBack = bus.NextStationIsBack;
                var left = 0,
                    top = 0;
                if (bus.NextStationCode == 0) {
                    left = IsBack ? that.BackStations[Priority - 1].Left : that.GoStations[Priority - 1].Left;
                    top = IsBack ? that.BackStations[Priority - 1].Top : that.GoStations[Priority - 1].Top;
                }
                else
                {
                    var top1 = IsBack ? that.BackStations[Priority - 1].Top : that.GoStations[Priority - 1].Top;
                    var top2 = NextStationIsBack ? that.BackStations[NextStationPriority - 1].Top : that.GoStations[NextStationPriority - 1].Top;
                    var left1 = IsBack ? that.BackStations[Priority - 1].Left : that.GoStations[Priority - 1].Left;
                    var left2 = NextStationIsBack ? that.BackStations[NextStationPriority - 1].Left : that.GoStations[NextStationPriority - 1].Left;
                    left = left1 + MovePercent * (left2 - left1);
                    top = top1 + MovePercent * (top2 - top1);
                }
                var div_bus = document.getElementById(bus.BusCode.toString());
                $(div_bus).animate({
                    left: (left - that.BusWidth / 2) + 'px',
                    top: (top - that.BusWidth / 2) + 'px'
                });
            }
            catch (err) {
                //alert(err.message);
            }
        },
        CreateBus: function (bus)
        {
            try {
               
                var that = this;
                var PathPanel = document.getElementById('PathPanel');
                var MovePercent = bus.MovePercent;
                var Priority = bus.Priority;
                var IsBack = bus.IsBack;
                var NextStationPriority = bus.NextStationPriority;
                var NextStationIsBack = bus.NextStationIsBack;
                var left = 0,
                    top = 0;
                if (bus.NextStationCode == 0)
                {
                    left = IsBack ? that.BackStations[Priority - 1].Left : that.GoStations[Priority - 1].Left;
                    top = IsBack ? that.BackStations[Priority - 1].Top : that.GoStations[Priority - 1].Top;
                }
                else
                {
                    var top1 = IsBack ? that.BackStations[Priority - 1].Top : that.GoStations[Priority - 1].Top;
                    var top2 = NextStationIsBack ? that.BackStations[NextStationPriority - 1].Top : that.GoStations[NextStationPriority - 1].Top;
                    var left1 = IsBack ? that.BackStations[Priority - 1].Left : that.GoStations[Priority - 1].Left;
                    var left2 = NextStationIsBack ? that.BackStations[NextStationPriority - 1].Left : that.GoStations[NextStationPriority - 1].Left;
                    left = left1 + MovePercent * (left2 - left1);
                    top = top1 + MovePercent * (top2 - top1);
                }
                var div_bus = document.createElement('div');
                var div_bus_code = document.createElement('div');
                div_bus.id = bus.BusCode;
                div_bus.title = bus.BusNumber;
                div_bus.style.position = 'absolute';
                div_bus.style.width = that.BusWidth + 'px';
                div_bus.style.height = (that.BusWidth + 20) + 'px';
                div_bus.style.top = (top - that.BusWidth / 2) + 'px';
                div_bus.style.left = (left - that.BusWidth / 2) + 'px';
                div_bus_code.style.width = that.BusWidth + 'px';
                div_bus_code.style.height = 20 + 'px';
                div_bus_code.style.clear = 'both';
                div_bus_code.innerHTML = '<center>' + bus.BusNumber + '</center>';
                var img_bus = document.createElement('img');
                img_bus.src = '/WebBusManagement/Images/bus_s42.png';
                //'<%=BusUrl%>';
                img_bus.style.cursor = 'pointer';
                img_bus.onclick = function () { that.ShowInfo(bus.BusCode); };
                div_bus.appendChild(img_bus);
                div_bus.appendChild(div_bus_code);
                PathPanel.appendChild(div_bus);
            }
            catch (err) {
                //alert(err.message);
            }
        },
        ShowInfo: function(BusCode)
        {
            var that = this;
            ShowWarining('در  حال بارگذاری ...', true, 3, false);
            var json = JSON.stringify({ 'id': 'Bus_' + BusCode, 'groupIDs': '0', offline: false });
            var xmlhttp2 = that.AjaxRequest('/Services/WebBaseDefineService.asmx/getInfoBus', json);
            xmlhttp2.onreadystatechange = function () {
                if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                    if (that.GettingStationData) {
                        that.GettingBusData = false;
                        return;
                    }
                    var res = JSON.parse(xmlhttp2.responseText);
                    if (typeof res.d !== 'undefined' && res.d !== null) {
                        var dv_info = document.getElementById('dv_info');
                        var PathPanel = document.getElementById('PathPanel');
                        var parent_width = 0;
                        if (document.getElementById('Mnu_ControlPanel').style.display == 'none')
                            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 50);
                        else {
                            parent_width = (PathPanel.parentNode.parentNode.clientWidth - 300);
                        }
                        $(dv_info).css('width');
                        $(dv_info).css('height');
                        $(dv_info).css('right');
                        $(dv_info).css('margin-top');
                        $(dv_info).css({ 'width': '360px', 'height': '250px', 'left': ((parent_width - 360) / 2 + 50) + 'px', 'margin-top': '75px' });
                        window.setTimeout(function () {
                            document.getElementById('dv_info_content').innerHTML = res.d;
                        }, 400);
                        HideWarining();
                    }
                }
            }
            xmlhttp2.send(json);
        },
        Clear: function()
        {
            this.GoStations = [];
            this.BackStations = [];
            document.getElementById('PathPanel').innerHTML = '';
        },
        AddStationsAndRoad: function ()
        {
            var PathPanel = document.getElementById('PathPanel'), that = this;
            var BackPathSpace = 0;
            var TerminalSpace = 0;
            // if you want to change the back path direction just change ChangeDirection variable from the line below
            var ChangeDirection = true;
            var GoLevelCount = 0;
            if ((that.GoStations.length - 1) % that.StationCountPerLevel == 0) {
                GoLevelCount = parseInt((that.GoStations.length - 1) / that.StationCountPerLevel);
            }
            else {
                GoLevelCount = parseInt((that.GoStations.length - 1) / that.StationCountPerLevel) + 1;
            }
            if ((that.GoStations.length - 1) % that.StationCountPerLevel == 0) {
                ChangeDirection = true;
                BackPathSpace = 0;
                if (GoLevelCount % 2 == 0) {
                    TerminalSpace = 0;
                }
                else {
                    TerminalSpace = that.StationCountPerLevel - 1;
                }
            }
            else if ((that.GoStations.length - 1) % that.StationCountPerLevel == 1) {
                ChangeDirection = false;
                BackPathSpace = 0;
                if (GoLevelCount % 2 == 0) {
                    TerminalSpace = that.StationCountPerLevel - 1;
                }
                else {
                    TerminalSpace = 0;
                }
            }
            else // (that.GoStations.length - 1) % that.StationCountPerLevel > 1
            {
                if (GoLevelCount % 2 == 0) {
                    TerminalSpace = that.StationCountPerLevel - (that.GoStations.length - 1) % that.StationCountPerLevel;
                }
                else {
                    TerminalSpace = (that.GoStations.length - 1) % that.StationCountPerLevel - 1;
                }
                if (ChangeDirection)
                    BackPathSpace = that.StationCountPerLevel - (that.GoStations.length - 1) % that.StationCountPerLevel;
                else
                    BackPathSpace = (that.GoStations.length - 1) % that.StationCountPerLevel - 1;
            }
            var BackLevelCount = 0;
            if ((that.BackStations.length + BackPathSpace - 1) % that.StationCountPerLevel == 0) {
                BackLevelCount = parseInt((that.BackStations.length + BackPathSpace - 1) / that.StationCountPerLevel);
            }
            else
            {
                BackLevelCount = parseInt((that.BackStations.length + BackPathSpace - 1) / that.StationCountPerLevel) + 1;
            }

            // Adding Go Stations
            var GoPriority = 0;
            for (var i = 0; i < GoLevelCount; i++)
            {
                for (var j = 0; j < that.StationCountPerLevel; j++) {
                    GoPriority++;
                    if (GoPriority > that.GoStations.length - 1) break;
                    var left = 0;
                    if (i % 2 == 0)
                        left = that.PanelPaddingLeft + j * that.StationsHorizontalDistance;
                    else
                        left = that.PanelPaddingLeft + (that.StationCountPerLevel - j - 1) * that.StationsHorizontalDistance;
                    var div_station = document.createElement('div');
                    div_station.id = that.GoStations[GoPriority - 1].Code;
                    div_station.style.position = 'absolute';
                    div_station.style.width = that.StationWidth + 'px';
                    div_station.style.height = that.StationWidth + 'px';
                    div_station.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationWidth / 2) + 'px';
                    div_station.style.left = (left - that.StationWidth / 2) + 'px';
                    div_station.title = that.GoStations[GoPriority - 1].Name;
                    var img_station = document.createElement('img');
                    img_station.src = '/WebBusManagement/Images/station.png';
                    div_station.appendChild(img_station);
                    PathPanel.appendChild(div_station);

                    that.GoStations[GoPriority - 1].Top = i * that.StationsVerticalDistance + that.PanelPaddingTop;
                    that.GoStations[GoPriority - 1].Left = left;
                    //that.GoStations[GoPriority - 1].VerticalOrder = i % 2 == 0 ? (j + 1) : (that.StationCountPerLevel - j);

                    var top = 0;
                    if ((i == 0 && j == 0) || (j > 0 && i % 2 == 0) || GoPriority % (2 * that.StationCountPerLevel) == 0
                        || GoPriority == that.GoStations.length - 1)
                        top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationNameHeight - that.StationWidth / 2);
                    else
                        top = (i * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2);
                    if (GoPriority == that.GoStations.length - 1 && (that.GoStations.length - 1) % that.StationCountPerLevel == 1)
                    {
                        if (TerminalSpace < that.StationCountPerLevel/2)
                        {
                            top += that.StationWidth / 2 + that.StationNameHeight / 2;
                            left += that.StationWidth / 2 + that.StationNameWidth / 2;
                        }
                        else
                        {
                            top += that.StationWidth / 2 + that.StationNameHeight / 2;
                            left -= that.StationWidth / 2 + that.StationNameWidth / 2;
                        }
                    }
                    var div_station_name = document.createElement('div');
                    div_station_name.style.position = 'absolute';
                    div_station_name.style.width = that.StationNameWidth + 'px';
                    div_station_name.style.height = that.StationNameHeight + 'px';
                    div_station_name.style.top = top + 'px';
                    div_station_name.style.left = (left - that.StationNameWidth / 2) + 'px';
                    div_station_name.style.lineHeight = that.StationNameHeight + 'px';
                    div_station_name.style.overflow = 'hidden';
                    div_station_name.innerHTML = '<center>' + that.GoStations[GoPriority - 1].Name + '</center>';
                    div_station_name.title = that.GoStations[GoPriority - 1].Name;
                    PathPanel.appendChild(div_station_name);
                }
            }

            // Adding the icon of the terminal between go and back paths
            var left_s0 = that.PanelPaddingLeft + TerminalSpace * that.StationsHorizontalDistance;
            var div_station0 = document.createElement('div');
            div_station0.style.position = 'absolute';
            div_station0.style.width = that.StationWidth + 'px';
            div_station0.style.height = that.StationWidth + 'px';
            div_station0.style.top = (GoLevelCount * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationWidth / 2) + 'px';
            div_station0.style.left = (left_s0 - that.StationWidth / 2) + 'px';
            var img_station0 = document.createElement('img');
            img_station0.src = '/WebBusManagement/Images/terminal.png';
            div_station0.appendChild(img_station0);
            PathPanel.appendChild(div_station0);


            var div_station_name0 = document.createElement('div');
            div_station_name0.style.position = 'absolute';
            div_station_name0.style.width = that.StationNameWidth + 'px';
            div_station_name0.style.height = that.StationNameHeight + 'px';
            div_station_name0.style.top = (GoLevelCount * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationNameHeight / 2) + 'px';
            if (TerminalSpace < that.StationCountPerLevel / 2)
                div_station_name0.style.left = (left_s0 + that.StationWidth / 2) + 'px';
            else
                div_station_name0.style.left = (left_s0 - that.StationNameWidth - that.StationWidth / 2) + 'px';
            div_station_name0.style.lineHeight = that.StationNameHeight + 'px';
            div_station_name0.style.overflow = 'hidden';
            div_station_name0.innerHTML = '<center>' + that.GoStations[that.GoStations.length - 1].Name + '</center>';
            div_station_name0.title = that.GoStations[that.GoStations.length - 1].Name;
            PathPanel.appendChild(div_station_name0);

            that.GoStations[that.GoStations.length - 1].Top = GoLevelCount * that.StationsVerticalDistance + that.PanelPaddingTop;
            that.GoStations[that.GoStations.length - 1].Left = left_s0;
            that.BackStations[0].Top = that.GoStations[that.GoStations.length - 1].Top;
            that.BackStations[0].Left = that.GoStations[that.GoStations.length - 1].Left;

            // Adding Back Stations
            var BackPriority = 0;
            for (var i = GoLevelCount + 1; i < GoLevelCount + BackLevelCount + 1; i++) {
                for (var j = 0; j < that.StationCountPerLevel; j++) {
                    if (i > GoLevelCount + 1 | j + 1 > BackPathSpace)// standing for adding a shift for the second station
                    {
                        BackPriority++;
                        if (BackPriority > that.BackStations.length - 1) break;
                        var left = 0;
                        if ((i + (ChangeDirection ? 1: 0)) % 2 == 0)
                            left = that.PanelPaddingLeft + j * that.StationsHorizontalDistance;
                        else
                            left = that.PanelPaddingLeft + (that.StationCountPerLevel - j - 1) * that.StationsHorizontalDistance;
                        var div_station = document.createElement('div');
                        div_station.id = that.BackStations[BackPriority].Code;
                        div_station.style.position = 'absolute';
                        div_station.style.width = that.StationWidth + 'px';
                        div_station.style.height = that.StationWidth + 'px';
                        div_station.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationWidth / 2) + 'px';
                        div_station.style.left = (left - that.StationWidth / 2) + 'px';
                        div_station.title = that.BackStations[BackPriority].Name;
                        var img_station = document.createElement('img');
                        img_station.src = '/WebBusManagement/Images/station.png';
                        div_station.appendChild(img_station);
                        PathPanel.appendChild(div_station);

                        that.BackStations[BackPriority].Top = i * that.StationsVerticalDistance + that.PanelPaddingTop;
                        that.BackStations[BackPriority].Left = left;
                        //that.BackStations[BackPriority].VerticalOrder = (i + (ChangeDirection ? 1 : 0)) % 2 == 0 ? (j + 1) : (that.StationCountPerLevel - j);

                        var top = 0;
                        if ((i == GoLevelCount + 1 && j == BackPathSpace) || (j == 0 && (i + (ChangeDirection ? 1 : 0)) % 2 == 1) 
                            || (j < that.StationCountPerLevel - 1 && (i + (ChangeDirection ? 1 : 0)) % 2 == 0))
                            top = (i * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2) + 'px';
                        else
                            top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.StationNameHeight - that.StationWidth / 2) + 'px';
                        var div_station_name = document.createElement('div');
                        div_station_name.style.position = 'absolute';
                        div_station_name.style.width = that.StationNameWidth + 'px';
                        div_station_name.style.height = that.StationNameHeight + 'px';
                        div_station_name.style.top = top;
                        div_station_name.style.left = (left - that.StationNameWidth / 2) + 'px';
                        div_station_name.style.lineHeight = that.StationNameHeight + 'px';
                        div_station_name.style.overflow = 'hidden';
                        div_station_name.innerHTML = '<center>' + that.BackStations[BackPriority].Name + '</center>';
                        div_station_name.title = that.BackStations[BackPriority].Name;
                        PathPanel.appendChild(div_station_name);
                    }
                }
            }

            // Adding Go Road
            GoPriority = 0;
            for (var i = 0; i < GoLevelCount; i++) {
                for (var j = 0; j < that.StationCountPerLevel - 1; j++) {
                    GoPriority++;
                    if (GoPriority > that.GoStations.length - 2) break;
                    var left = 0;
                    if (i % 2 == 0)
                        left = that.PanelPaddingLeft + j * that.StationsHorizontalDistance + that.StationWidth / 2;
                    else
                        left = that.PanelPaddingLeft + (that.StationCountPerLevel - j - 2) * that.StationsHorizontalDistance + that.StationWidth / 2;
                    var road = document.createElement('div');
                    road.style.position = 'absolute';
                    road.style.width = (that.StationsHorizontalDistance - that.StationWidth) + 'px';
                    road.style.height = that.RoadWidth + 'px';
                    road.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.RoadWidth / 2) + 'px';
                    road.style.left = left + 'px';
                    road.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-go-h.png') repeat-x left top";
                    PathPanel.appendChild(road);
                }
                GoPriority++;
                if (i < GoLevelCount - 1)
                {
                    var left = 0;
                    if (i % 2 == 0)
                        left = that.PanelPaddingLeft + (that.StationCountPerLevel - 1) * that.StationsHorizontalDistance;
                    else
                        left = that.PanelPaddingLeft;
                    var road = document.createElement('div');
                    road.style.position = 'absolute';
                    road.style.width = that.RoadWidth + 'px';
                    road.style.height = (that.StationsVerticalDistance - that.StationWidth) + 'px';
                    road.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2) + 'px';
                    road.style.left = (left - that.RoadWidth / 2) + 'px';
                    road.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-go-v.png') repeat-y left top";
                    PathPanel.appendChild(road);
                }
            }

            // Adding Back Road
            BackPriority = 0;
            for (var i = GoLevelCount + 1; i < GoLevelCount + BackLevelCount + 1; i++) {
                for (var j = 0; j < that.StationCountPerLevel - 1; j++) {
                    if (i > GoLevelCount + 1 | j + 1 > BackPathSpace)// standing for adding a shift for the second station
                    {
                        BackPriority++;
                        if (BackPriority > that.BackStations.length - 2) break;
                        var left = 0;
                        if ((i + (ChangeDirection ? 1 : 0)) % 2 == 0)
                            left = that.PanelPaddingLeft + j * that.StationsHorizontalDistance + that.StationWidth / 2;
                        else
                            left = that.PanelPaddingLeft + (that.StationCountPerLevel - j - 2) * that.StationsHorizontalDistance + that.StationWidth / 2;
                        var road = document.createElement('div');
                        road.style.position = 'absolute';
                        road.style.width = (that.StationsHorizontalDistance - that.StationWidth) + 'px';
                        road.style.height = that.RoadWidth + 'px';
                        road.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop - that.RoadWidth / 2) + 'px';
                        road.style.left = left + 'px';
                        road.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-back-h.png') repeat-x left top";
                        PathPanel.appendChild(road);
                    }
                }
                BackPriority++;
                if (i < GoLevelCount + BackLevelCount) {
                    var left = 0;
                    if ((i + (ChangeDirection ? 1 : 0)) % 2 == 0)
                        left = that.PanelPaddingLeft + (that.StationCountPerLevel - 1) * that.StationsHorizontalDistance;
                    else
                        left = that.PanelPaddingLeft;
                    var road = document.createElement('div');
                    road.style.position = 'absolute';
                    road.style.width = that.RoadWidth + 'px';
                    road.style.height = (that.StationsVerticalDistance - that.StationWidth) + 'px';
                    road.style.top = (i * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2) + 'px';
                    road.style.left = (left - that.RoadWidth / 2) + 'px';
                    road.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-back-v.png') repeat-y left top";
                    PathPanel.appendChild(road);
                }
            }

            // Adding the road of the terminal between go and back paths
            var left_r0 = that.PanelPaddingLeft + TerminalSpace * that.StationsHorizontalDistance;
            var road0 = document.createElement('div');
            road0.style.position = 'absolute';
            road0.style.width = that.RoadWidth + 'px';
            road0.style.height = (that.StationsVerticalDistance - that.StationWidth) + 'px';
            road0.style.top = (GoLevelCount * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2) + 'px';
            road0.style.left = (left_r0 - that.RoadWidth / 2) + 'px';
            road0.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-back-v.png') repeat-y left top";
            PathPanel.appendChild(road0);

            var road1 = document.createElement('div');
            road1.style.position = 'absolute';
            road1.style.width = that.RoadWidth + 'px';
            road1.style.height = (that.StationsVerticalDistance - that.StationWidth) + 'px';
            road1.style.top = ((GoLevelCount - 1) * that.StationsVerticalDistance + that.PanelPaddingTop + that.StationWidth / 2) + 'px';
            road1.style.left = (left_r0 - that.RoadWidth / 2) + 'px';
            road1.style.background = "#f3f3f3 url('/WebBusManagement/Images/road-go-v.png') repeat-y left top";
            PathPanel.appendChild(road1);

            that.Resize(GoLevelCount, BackLevelCount);
        },
        Resize: function (GoLevelCount, BackLevelCount)
        {
            var PathPanel = document.getElementById('PathPanel');
            PathPanel.style.height = ((GoLevelCount + BackLevelCount) * this.StationsVerticalDistance + 2 * this.PanelPaddingTop) + 'px';
        },
        AjaxRequest: function (url, jsonParams) {
            var xmlhttp2;
            if (XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp2 = new XMLHttpRequest();
            } else {// code for IE6, IE5
                xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp2.open("POST", url, true);
            xmlhttp2.setRequestHeader("Content-Type", "application/json; charset=utf-8");

            return xmlhttp2
        }
    }

</script>
