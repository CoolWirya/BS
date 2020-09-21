<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenLayersMap.ascx.cs" Inherits="WebControllers.MainControls.OpenLayersMap.OpenLayersMap" %>
<style>
    .mapContextMenu div {
        padding-top: 5px;
        padding-bottom: 5px;
        border-bottom: 1px solid #CCC;
    }

        .mapContextMenu div:hover {
            background-color: #CCC;
        }

    .mapContextMenu a {
        text-decoration: none;
        color: #777;
    }

    .mapContextMenu div img {
        float: right;
        padding-left: 3px;
        padding-right: 3px;
    }
    .Popup {
        display:table-cell;
        direction: ltr;
        font:bold 14px MyBMitra;
        background-color:rgba(255, 255, 255,0.5);
        width:100%;height:30px;
        padding:0px 3px 0px 3px; 
        text-align:center;
        vertical-align:middle;
        border-radius: 3px;
        border: 1px solid #ccc;
    }
    .TitlePopup{
        font-size:13px; 
        font-style: MyBMitra; 
        width: 120px;
        height:30px;
        line-height:15px;
        text-align:center;
        vertical-align:top;
    }
</style>
<div style="width: 100%; height: 100%; position: relative">
    <div runat="server" style="width: 100%; height: 100%" id="map" oncontextmenu="return false;" onmouseover="CloseMapModeMenu();">
    </div>
    <div style="width: 110px; height: 18px; position: absolute; left: 50px; top: 0px; background: rgba(8, 19, 137, 0.70); text-align: center; color: white; cursor: pointer; display: none"
        onmouseover="OpenMapModeMenu();">
        انتخاب نقشه
    </div>
    <div id="MapLayerModeMenu" style="width: 110px; height: 82px; position: absolute; left: 50px; top: 0px; background: rgba(8, 19, 137, 0.90); color: white; cursor: default; display: none">
        <input type="radio" id="rbGoogleHybrid" value="GoogleHybrid" title="GoogleHybrid" name="rbMapLayerMode" onclick="ChangeMapLayerMode('Google Hybrid');" />GoogleHybrid
        <div style="clear: both"></div>
        <input type="radio" id="rbGooglePhysical" value="GooglePhysical" title="GooglePhysical" name="rbMapLayerMode" onclick="ChangeMapLayerMode('Google Physical');" />GooglePhysical
        <div style="clear: both"></div>
        <input type="radio" id="rbGoogleSatelite" value="GoogleSatelite" title="GoogleSatelite" name="rbMapLayerMode" onclick="ChangeMapLayerMode('Google Satellite');" />GoogleSatelite
        <div style="clear: both"></div>
        <input type="radio" id="rbGoogleStreet" value="GoogleStreet" title="GoogleStreet" name="rbMapLayerMode" onclick="ChangeMapLayerMode('Google Streets');" />GoogleStreet
    </div>
    <script type="text/ecmascript">
        function OpenMapModeMenu() {
            $("#MapLayerModeMenu").slideDown("slow");
        }
        function CloseMapModeMenu() {
            $("#MapLayerModeMenu").slideUp("slow");
        }
    </script>
</div>

<div runat="server" id="ContextMenu" class="mapContextMenu" style="width: 120px; height: auto; position: absolute; z-index: 101; background-color: rgba(255, 255, 255, 0.8); border: 1px solid #BBB; display: none" oncontextmenu="return false;">
    <%--<a href="#" onclick="rightClickState='Point2Right';">
        <div>
            <img src="../WebControllers/MainControls/OpenLayersMap/Images/rightarrow_s16.png" />افزودن به راست
        </div>
    </a>
    <a href="#" onclick="rightClickState='Point2Left';">
        <div>
            <img src="../WebControllers/MainControls/OpenLayersMap/Images/leftarrow_s16.png" />افزودن به چپ
        </div>
    </a>--%>
    <a href="#" style="cursor:pointer" onclick="RemoveUserMarker(document.getElementById('<%=_SelectedMarker.ClientID %>').value.toString());document.getElementById('<%=ContextMenu.ClientID %>').style.display='none'">
        <div>
            <img src="../WebControllers/MainControls/OpenLayersMap/Images/delete_s16.png" />حذف
        </div>
    </a>
</div>
<input type="hidden" runat="server" id="_MapProvider" name="_MapProvider" />
<input type="hidden" runat="server" id="_MapCenterPosition" name="_MapCenterPosition" />
<input type="hidden" runat="server" id="_MapZoom" name="_MapZoom" />
<input type="hidden" runat="server" id="_TimerInterval" name="_TimerInterval" value="1000" />
<input type="hidden" runat="server" id="_TimerEnabled" name="_TimerEnabled" value="false" />
<input type="hidden" runat="server" id="_Action" name="_Action" />
<input type="hidden" runat="server" id="_Markers" name="_Markers" />
<input type="hidden" runat="server" id="_Lines" name="_Lines" />
<input type="hidden" runat="server" id="_ServiceParam" name="_ServiceParam" value="0" />
<input type="hidden" runat="server" id="_OtherParam" name="_OtherParam" value="" />
<input type="hidden" runat="server" id="_MouseClickAddUserMarker" name="_MouseClickAddUserMarker" value="false" />
<input type="hidden" runat="server" id="_CanAddMultipleMarkers" name="_CanAddMultipleMarkers" value="false" />
<input type="hidden" runat="server" id="_UserMarkers" name="_UserMarkers" />
<input type="hidden" runat="server" id="_UserLines" name="_UserLines" />
<input type="hidden" runat="server" id="_DrawMarkers" name="_DrawMarkers" value="false" />
<input type="hidden" runat="server" id="_DrawMarkersInfo" name="_DrawMarkersInfo" />
<input type="hidden" runat="server" id="_DrawLines" name="_DrawLines" value="false" />
<input type="hidden" runat="server" id="_SelectedMarker" name="_SelectedMarker" />
<input type="hidden" runat="server" id="_DrawLinesInfo" name="_DrawLinesInfo" />
<input type="hidden" runat="server" id="_HasRightClick" name="_HasRightClick" value="False" />
<input type="hidden" runat="server" id="_DraggableMarker" name="_DraggableMarker" value="False" />
<input type="hidden" runat="server" id="_MarkerClick" name="_MarkerClick" value="False" />
<input type="hidden" id="LastDate" name="LastDate" value="0" />
<input type="hidden" id="AddMarkerMode" name="AddMarkerMode" value="Simple" />
<script type="text/javascript" defer>

    MapProviderClientID = '<%= _MapProvider.ClientID %>';
    mapClientID = '<%= map.ClientID%>';
    MapCenterPositionClientID = '<%= _MapCenterPosition.ClientID %>';
    MapZoomClientID = '<%= _MapZoom.ClientID %>';
    TimerEnabledClientID = '<%= _TimerEnabled.ClientID %>';
    TimerIntervalClientID = '<%= _TimerInterval.ClientID %>';
    MarkersClientID = '<%= _Markers.ClientID %>';
    MarkerClickClientID = '<%= _MarkerClick.ClientID %>';
    HasRightClickClientID = '<%= _HasRightClick.ClientID %>';
    DraggableMarkerClientID = '<%= _DraggableMarker.ClientID %>';
    UserMarkersClientID = '<%= _UserMarkers.ClientID %>';
    DrawLinesClientID = '<%= _DrawLines.ClientID %>';
    LinesClientID = '<%= _Lines.ClientID %>';
    ContextMenuClientID = '<%=ContextMenu.ClientID %>';
    MouseClickAddUserMarkerClientID = '<%= _MouseClickAddUserMarker.ClientID %>';
    DrawMarkersInfoClientID = '<%= _DrawMarkersInfo.ClientID %>';
    DrawMarkersClientID = '<%= _DrawMarkers.ClientID %>';
    CanAddMultipleMarkersClientID = '<%= _CanAddMultipleMarkers.ClientID %>';
    SelectedMarkerClientID = "<%=_SelectedMarker.ClientID %>";
    UserLinesClientID = '<%= _UserLines.ClientID %>';
    DrawLinesInfoClientID = '<%= _DrawLinesInfo.ClientID %>';
    ServiceParamClientID = '<%= _ServiceParam.ClientID %>';
    OtherParamClientID = '<%= _OtherParam.ClientID %>';
    ActionClientID = '<%= _Action.ClientID %>';
    init();
</script>
