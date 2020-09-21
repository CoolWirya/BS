//<%--    map = new OpenLayers.Map(mapClientID);
//    var gearth = new OpenLayers.Layer.Google(
//        "Google Streets", // the default
//        { numZoomLevels: 20 });

//    map.addLayers([gearth]);

//    map.setCenter(new OpenLayers.LonLat(-120, 32), 5)--%>

var map, baseLayer, markers, renderer, VectorLayerForMarker, ModifyControl, timer, GoogleStreetsLayer, GooglePhysicalLayer, GoogleHybridLayer, GoogleSatelliteLayer, OpenStreetMapLayer;


var counter = 0;
var rightClickState = 'none';
var MarkerRightClicked = false;
var BaseMarkerIndex = -1, UserMarkerCount;
var lineLayer;
var Projection_4326 = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
var Projection_3857 = new OpenLayers.Projection("EPSG:3857"); // to Spherical Mercator Projection
var MapProviderClientID, mapClientID = '<%= map.ClientID%>';
var MapCenterPositionClientID, MapZoomClientID, TimerEnabledClientID, TimerIntervalClientID, MarkersClientID, MarkerClickClientID, HasRightClickClientID, ActionClientID;
var DraggableMarkerClientID, UserMarkersClientID, DrawLinesClientID, LinesClientID, ContextMenuClientID, MouseClickAddUserMarkerClientID, DrawMarkersInfoClientID;
var DrawMarkersClientID, CanAddMultipleMarkersClientID, SelectedMarkerClientID, UserLinesClientID, DrawLinesInfoClientID, ServiceParamClientID, OtherParamClientID;


function init() {
    if (document.getElementById(MapProviderClientID).value != "" && document.getElementById(MapProviderClientID).value != null) {
        if (document.getElementById(MapProviderClientID).value == "GoogleStreets") {
            //<%--map = new OpenLayers.Map(mapClientID, {
            //    //projection: 'EPSG:3857',
            //    layers: [
            //        new OpenLayers.Layer.Google(
            //            "Google Streets", // the default
            //            { numZoomLevels: 18 }
            //        )
            //    ],
            //    controls: [
            //        new OpenLayers.Control.Navigation(),
            //        new OpenLayers.Control.PanZoomBar(),
            //        new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
            //        new OpenLayers.Control.OverviewMap(),
            //        new OpenLayers.Control.KeyboardDefaults()
            //    ],
            //    //center: new OpenLayers.LonLat(10.2, 48.9)
            //    //    .transform(Projection_4326, Projection_3857),
            //    zoom: 12
            //});--%>
            map = new OpenLayers.Map(mapClientID, {
                layers: [new OpenLayers.Layer.Google(
    "Google Streets", // the default
    {
        type: google.maps.MapTypeId.ROADMAP,
        numZoomLevels: 28
    })]
                //,controls: [
                //    new OpenLayers.Control.Navigation(),
                //    new OpenLayers.Control.PanZoomBar(),
                //    new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
                //    new OpenLayers.Control.OverviewMap(),
                //    new OpenLayers.Control.KeyboardDefaults()
                //]
            });
            $("#rbGoogleStreet").attr('checked', 'true');

            var position = new OpenLayers.LonLat(10.2, 48.9).transform(Projection_4326, Projection_3857);

            map.setCenter(position, 6)
        }
        else if (document.getElementById(MapProviderClientID).value == "GooglePhysical") {
            map = new OpenLayers.Map(mapClientID, {
                projection: 'EPSG:3857',
                layers: [
                    new OpenLayers.Layer.Google(
                        "Google Physical",
                        { type: google.maps.MapTypeId.TERRAIN, numZoomLevels: 28 }
                    )
                ],
                controls: [
                    new OpenLayers.Control.Navigation(),
                    new OpenLayers.Control.PanZoomBar(),
                    new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
                    new OpenLayers.Control.OverviewMap(),
                    new OpenLayers.Control.KeyboardDefaults()
                ],
                center: new OpenLayers.LonLat(10.2, 48.9)
                    .transform(Projection_4326, Projection_3857),
                zoom: 12
            });
            $("#rbGooglePhysical").attr('checked', 'true');
        }
        else if (document.getElementById(MapProviderClientID).value == "GoogleHybrid") {
            map = new OpenLayers.Map(mapClientID, {
                projection: 'EPSG:3857',
                layers: [
                    new OpenLayers.Layer.Google(
                        "Google Hybrid",
                        { type: google.maps.MapTypeId.HYBRID, numZoomLevels: 28 }
                    )
                ],
                controls: [
                    new OpenLayers.Control.Navigation(),
                    new OpenLayers.Control.PanZoomBar(),
                    new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
                    new OpenLayers.Control.OverviewMap(),
                    new OpenLayers.Control.KeyboardDefaults()
                ],
                center: new OpenLayers.LonLat(10.2, 48.9)
                    .transform(Projection_4326, Projection_3857),
                zoom: 12
            });
            $("#rbGoogleHybrid").attr('checked', 'true');
        }
        else if (document.getElementById(MapProviderClientID).value == "GoogleSatellite") {
            map = new OpenLayers.Map(mapClientID, {
                projection: 'EPSG:3857',
                layers: [
                    new OpenLayers.Layer.Google(
                        "Google Satellite",
                        { type: google.maps.MapTypeId.SATELLITE, numZoomLevels: 28 }
                    )
                ],
                controls: [
                    new OpenLayers.Control.Navigation(),
                    new OpenLayers.Control.PanZoomBar(),
                    new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
                    new OpenLayers.Control.OverviewMap(),
                    new OpenLayers.Control.KeyboardDefaults()
                ],
                center: new OpenLayers.LonLat(10.2, 48.9)
                    .transform(Projection_4326, Projection_3857),
                zoom: 12
            });
            $("#rbGoogleSatelite").attr('checked', 'true');
        }
        else if (document.getElementById(MapProviderClientID).value == "OpenStreetMap") {
            map = new OpenLayers.Map(mapClientID);
            baseLayer = new OpenLayers.Layer.OSM("Simple OSM Map");
            map.addLayer(baseLayer);
        }
    }
    else {
        map = new OpenLayers.Map(mapClientID, {
            layers: [new OpenLayers.Layer.Google(
"Google Streets", // the default
{ numZoomLevels: 28 })]
            //,controls: [
            //    new OpenLayers.Control.Navigation(),
            //    new OpenLayers.Control.PanZoomBar(),
            //    new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
            //    new OpenLayers.Control.OverviewMap(),
            //    new OpenLayers.Control.KeyboardDefaults()
            //]
        });
    }
    var CenterLonLat;
    if (document.getElementById(MapCenterPositionClientID).value != "" && document.getElementById(MapCenterPositionClientID).value != null) {

        CenterLonLat = new OpenLayers.LonLat(document.getElementById(MapCenterPositionClientID).value.split(',')[0], document.getElementById(MapCenterPositionClientID).value.split(',')[1]).transform(Projection_4326, Projection_3857);

        if (document.getElementById(MapZoomClientID).value != "" && document.getElementById(MapZoomClientID).value != null) {
            map.setCenter(CenterLonLat, document.getElementById(MapZoomClientID).value);
        }
        else {
            map.setCenter(CenterLonLat, 5);
        }

    }
    else {
        CenterLonLat = new OpenLayers.LonLat(52.287597, 34.343436).transform(Projection_4326, Projection_3857);
        map.setCenter(CenterLonLat, 5);

    }


    lineLayer = new OpenLayers.Layer.Vector("MyLines");
    map.addLayer(lineLayer);

    markers = new OpenLayers.Layer.Markers("MyMarkers");
    map.addLayer(markers);

    var wms = new OpenLayers.Layer.WMS("OpenLayers WMS",
        "http://vmap0.tiles.osgeo.org/wms/vmap0?", { layers: 'basic' });

    OpenLayers.Feature.Vector.style['default']['strokeWidth'] = '2';

    // allow testing of specific renderers via "?renderer=Canvas", etc
    renderer = OpenLayers.Util.getParameters(window.location.href).renderer;
    renderer = (renderer) ? [renderer] : OpenLayers.Layer.Vector.prototype.renderers;

    map.addLayer(wms);

    VectorLayerForMarker = new OpenLayers.Layer.Vector("MarkerLabel", {
        renderers: renderer
    });

    if (console && console.log) {
        function report(event) {
            console.log(event.type, event.feature ? event.feature.id : event.components);
        }
        VectorLayerForMarker.events.on({
            "beforefeaturemodified": report,
            "featuremodified": report,
            "afterfeaturemodified": report,
            "vertexmodified": report,
            "sketchmodified": report,
            "sketchstarted": report,
            "sketchcomplete": report
        });
    }

    map.addLayer(VectorLayerForMarker);


    if (document.getElementById(TimerEnabledClientID).value == 'True') {
        counter = parseInt(document.getElementById(TimerIntervalClientID).value) - 1;
        timer = setInterval(Timer, 1);
    }
    if (document.getElementById(MarkersClientID).value != "" && document.getElementById(MarkersClientID).value != null) {
        LoadMarkers('False', false, false, 0, false, false);
    }
    var HasLeftClick = document.getElementById(MarkerClickClientID).value == "True";
    var HasRightClick = document.getElementById(HasRightClickClientID).value == "True";
    var IsDraggable = document.getElementById(DraggableMarkerClientID).value == "True";
    if (IsDraggable) {
        ModifyControl = new OpenLayers.Control.ModifyFeature(VectorLayerForMarker);
        map.addControl(ModifyControl);
    }
    if (document.getElementById(UserMarkersClientID).value != "" && document.getElementById(UserMarkersClientID).value != null) {
        LoadUserMarkers(HasRightClick, HasLeftClick, IsDraggable);
        if (document.getElementById(DrawLinesClientID).value == "True" && !IsDraggable) {
            LoadUserLines();
        }
        if (IsDraggable) {
            ModifyControl.activate();
            ModifyControl.createVertices = true;
        }
    }
    if (document.getElementById(LinesClientID).value != "" && document.getElementById(LinesClientID).value != null) {
        LoadLines();
    }

    map.events.register("zoomend", map, function () {
        // Hide Context Menu if it is visible.
        $("#" + ContextMenuClientID).fadeOut();
        MarkerRightClicked = false;
    });

    map.events.register("movestart", map, function () {
        // Hide Context Menu if it is visible.
        $("#" + ContextMenuClientID).fadeOut();
        MarkerRightClicked = false;
    });

    var MouseClickCounter = 0;
    // --- Map Click ***********************************************************************

    map.events.register("click", map, function (e) {
        if (IsDraggable) return;
        if (!MarkerRightClicked) {
            RemovePopups();
            if (document.getElementById(MouseClickAddUserMarkerClientID).value != 'True') return;
            var xys = map.getLonLatFromViewPortPx(e.xy);
            var MLon = xys.lon;
            var MLat = xys.lat;

            var points = new Array();
            points[0] = new OpenLayers.LonLat(MLon, MLat).transform(new OpenLayers.Projection("EPSG:900913"), new OpenLayers.Projection("EPSG:4326"));

            //<%--                if (document.getElementById(DrawMarkersInfoClientID).value != "" && document.getElementById(DrawMarkersInfoClientID).value != null) {///////////////////////////
            //                    Name = DMI[0] + "_" + MouseClickCounter;
            //                    Title = DMI[1] + MouseClickCounter;
            //                    imageUrl = DMI[2];
            //                    imgWidth = DMI[3];
            //                    imgHeight = DMI[4];
            //                    titleWidth = DMI[5];
            //                    titleHeight = DMI[6];

            //                    //Start Marker
            //                    var Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight;
            //                    var DMI = new Array();
            //                    DMI = document.getElementById(DrawMarkersInfoClientID).value.toString().split('{!~!}');

            //                    if (document.getElementById(DrawMarkersClientID).value == 'True') {

            //                        if (document.getElementById(CanAddMultipleMarkersClientID).value == 'False') {
            //                            document.getElementById(UserMarkersClientID).value = Name + "," + points[0].lon + "," + points[0].lat;
            //                            RemoveUsersMarkers(false);
            //                            RemovePopups();
            //                        }
            //                        else {
            //                            if (rightClickState == "Point2Right") {
            //                                var m = getUserMarkers();
            //                                var selectedMarker = document.getElementById(SelectedMarkerClientID).value.toString();
            //                                var index = findUserMarker(m, selectedMarker);
            //                                m.splice(index, 0, selectedMarker);
            //                                rightClickState = "none";
            //                                RemoveUsersMarkers(false);
            //                                LoadUserMarkers(HasRightClick, HasLeftClick, false);
            //                            }
            //                            if (rightClickState == "Point2Left") {
            //                                var m = getUserMarkers();
            //                                var selectedMarker = document.getElementById(SelectedMarkerClientID).value.toString();
            //                                var index = findUserMarker(m, selectedMarker);
            //                                m.splice(index - 1, 0, selectedMarker);
            //                                rightClickState = "none";
            //                                RemoveUsersMarkers(false);
            //                                LoadUserMarkers(HasRightClick, HasLeftClick, false);
            //                            }
            //                            else {
            //                            }
            //                            document.getElementById(UserMarkersClientID).value += "{!~!}" + Name + "," + points[0].lat + "," + points[0].lon;
            //                        }
            //                        AddMarker(MLon, MLat, Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight, false, false, false, HasRightClick, HasLeftClick, false);

            //                    }
            //                    //End Marker

            //                    //Start Line
            //                    var LineName, LineTitle, LineColor, LineOpacity, LineWidth, LineDirection;
            //                    if (CheckOption("DrawUserLines") == true) {

            //                        var AllUserMarker = new Array();
            //                        AllUserMarker = document.getElementById(UserMarkersClientID).value.toString().split("{!~!}");
            //                        if (AllUserMarker.length > 1) {
            //                            var PreMarker = AllUserMarker[AllUserMarker.length - 2];
            //                            var PreLonLat = PreMarker.split(",");

            //                            document.getElementById(UserLinesClientID).value += "{!~!}" + PreLonLat[2] + "," + PreLonLat[1] + "#" + points[0].lon + "," + points[0].lat;

            //                            if (document.getElementById(DrawLinesInfoClientID).value != "" && document.getElementById(DrawLinesInfoClientID).value != null) {
            //                                var DLI = new Array();
            //                                DLI = document.getElementById(DrawLinesInfoClientID).value.toString().split('{!~!}');
            //                                LineName = DLI[0];
            //                                LineTitle = DLI[1];
            //                                LineColor = DLI[2];
            //                                LineOpacity = DLI[3];
            //                                LineWidth = DLI[4];
            //                                LineDirection = DLI[5];
            //                            }
            //                            else {
            //                                LineName = MouseClickCounter;
            //                                LineTitle = "";
            //                                LineColor = "ff0000";
            //                                LineOpacity = "0.7";
            //                                LineWidth = 4;
            //                                LineDirection = "false";
            //                            }
            //                            var ConvertPointsForShow = new Array();
            //                            ConvertPointsForShow[0] = new OpenLayers.LonLat(PreLonLat[2], PreLonLat[1]).transform(new OpenLayers.Projection('EPSG:4326'), new OpenLayers.Projection('EPSG:3857'));

            //                            DrawLine(ConvertPointsForShow[0].lon, ConvertPointsForShow[0].lat, MLon, MLat, "USL_" + LineName + "_" + MouseClickCounter, LineTitle, LineColor, LineOpacity, LineWidth, LineDirection, false);
            //                        }
            //                    }
            //                    //End Line
            //                    MouseClickCounter += 1;

            //                }/////////////
            //                else {--%>
            if (document.getElementById(CanAddMultipleMarkersClientID).value == 'False') {
                MarkerItem = document.getElementById(UserMarkersClientID).value = 'USM_' + points[0].lat + points[0].lon
                    + ',' + points[0].lon + ',' + points[0].lat;
            }
            else // CanAddMultipleMarkers == true
            {
                var MarkerItem = new Array();
                var strUserMarkers = '';
                if (document.getElementById(UserMarkersClientID).value != null && document.getElementById(UserMarkersClientID).value != '') {
                    MarkerItem = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
                }
                if (BaseMarkerIndex != -1)
                    for (var i = 0; i <= BaseMarkerIndex; i++)
                        strUserMarkers += MarkerItem[i] + '{!~!}';
                strUserMarkers += "," + points[0].lon + "," + points[0].lat + '{!~!}';
                if (BaseMarkerIndex != -1)
                    for (var i = BaseMarkerIndex + 1; i < MarkerItem.length; i++)
                        strUserMarkers += MarkerItem[i] + '{!~!}';
                document.getElementById(UserMarkersClientID).value = strUserMarkers.substr(0, strUserMarkers.length - '{!~!}'.length);
                BaseMarkerIndex++;
            }
            LoadUserMarkers(HasRightClick, HasLeftClick, false);
            if (document.getElementById(DrawLinesClientID).value == "True") {
                LoadUserLines();
                LoadMarkers('False', false, true, 0, false, false);
            }
            //}
        }
        else {
            // Hide Context Menu if it is visible.
            $("#" + ContextMenuClientID).fadeOut();
            MarkerRightClicked = false;
        }
    });
    //map.addControl(new OpenLayers.Control.PanZoomBar());
}

function onFeatureSelectt(feature) {
    alert(123);
}

function onFeatureSelect(feature) {
    alert(feature.id);
}

function onFeatureDrag(feature) {
    alert(feature.id);
}

function ChangeMapLayerMode(Layer) {
    var ol_wms = new OpenLayers.Map(mapClientID, {
        projection: 'EPSG:3857',
        layers: [
            new OpenLayers.Layer.Google(
                "Layer",
                { numZoomLevels: 28 }
            )
        ],
        center: new OpenLayers.LonLat(10.2, 48.9)
            .transform(Projection_4326, Projection_3857),
        zoom: map.zoom
    });
    map.addLayer(ol_wms);
}


var StrRequest;
// Timer Tick ***********************************
function Timer() {
    if (counter == -1) return;
    counter++;
    if (counter >= document.getElementById(TimerIntervalClientID).value) {
        counter = -1;
        var param = new Array();
        param[0] = 'MapData';
        param[1] = document.getElementById(ServiceParamClientID).value;
        param[2] = document.getElementById(OtherParamClientID).value;
        param[3] = document.getElementById('LastDate').value;
        if (param[1] == "0") param[1] = "NoParam";
        Request(document.getElementById(ActionClientID).value, param, true, function () {
            if (StrRequest != "" && StrRequest != null) {
                ParseData(StrRequest);
                if (document.getElementById('AddMarkerMode').value == "Simple") {
                    RemoveMarkers();
                    RemovePopups();
                    LoadMarkers('False', false, false, 0, false, false);
                }
                else {
                    AnimateMarker();
                }
                LoadLines();
            }
            else {
                if (document.getElementById('AddMarkerMode').value == "Simple") {
                    RemoveMarkers();
                    RemovePopups();
                    RemoveMarkerDescriptionPopup();
                }
            }
        });
    }
}

var MapRequestIsRun = null;
function Request(actionString, param, isAsync, successFunction) {
    if (MapRequestIsRun != null) {
        MapRequestIsRun.abort();
    }
    var data = "{actionString:'" + actionString + "',param:" + JSON.stringify(param) + "}";
    MapRequestIsRun = $.ajax({
        url: "Services/WebBaseDefineService.asmx/MapRequest",
        contentType: "application/json",
        cache: false,
        type: "POST",
        data: data,
        async: isAsync,
        error: function (err) {
        },
        success: function (data) {
            if (data.d != null) {
                if (data.d.length > 0) {
                    StrRequest = data.d;
                    successFunction();
                }
                else {
                    counter = 0;
                    RemoveMarkers();
                    RemovePopups();
                }
            }
        }
    });
}

var ParseDataStatus = false;
function ParseData(data) {
    counter = 0;
    if (data == null) return;
    document.getElementById(MarkersClientID).value = "";
    document.getElementById(LinesClientID).value = "";
    var j = 1;
    for (i = 0; i < data.length; i++) {
        if (data[i].toString() == "Marker") {
            document.getElementById(MarkersClientID).value = document.getElementById(MarkersClientID).value + "{!~!~!}" + data[i + 1].toString();
        }
        else if (data[i].toString() == "Line") {
            document.getElementById(LinesClientID).value = document.getElementById(LinesClientID).value + "{!~!~!}" + data[i + 1].toString();
        }

        j++;
        if (j >= data.length) {
            ParseDataStatus = true;
        }
    };
}

var AnimateMarkerItem = new Array();
var AnimateMarkerIndex = 0;
var AnimateCounter = 0;
var AnimateTimerInterval = 0;
var AnimateMarkerHandler;
function AnimateMarker() {

    var PrimaryAnimateMarkerItem = new Array();
    PrimaryAnimateMarkerItem = document.getElementById(MarkersClientID).value.toString().split('{!~!~!}');
    //AnimateMarkerItem = document.getElementById(MarkersClientID).value.toString().split('{!~!~!}');


    var AnimateMarkerItemArrayIndex = 0;
    for (jj = 1 ; jj < PrimaryAnimateMarkerItem.length ; jj++) {
        AnimateMarkerItem[AnimateMarkerItemArrayIndex] = PrimaryAnimateMarkerItem[jj];
        AnimateMarkerItemArrayIndex++;
    }


    if (AnimateMarkerItem.length > 0) {
        RemoveMarkers();
        RemovePopups();
    }
    AnimateMarkerIndex = 0;
    AnimateCounter = 0;
    //var AnimateIntervalArray = new Array();
    //AnimateIntervalArray = AnimateMarkerItem[1].toString().split('{!~!}');
    //AnimateTimerInterval = AnimateIntervalArray[10];
    AnimateTimerInterval = 1;
    if (AnimateMarkerHandler != null) {
        clearInterval(AnimateMarkerHandler);
    }
    AnimateMarkerHandler = setInterval(AnimateMarkerTimer, 1000);

}

function AnimateMarkerTimer() {
    if (AnimateMarkerIndex >= AnimateMarkerItem.length) return;
    AnimateCounter++;
    if (AnimateCounter >= AnimateTimerInterval) {
        AddAnimateMarkerOnMap(AnimateMarkerIndex);
        AnimateMarkerIndex++;
        if (AnimateMarkerIndex >= AnimateMarkerItem.length) return;
        AnimateCounter = 0;
        var AnimateIntervalArray = new Array();
        AnimateIntervalArray = AnimateMarkerItem[AnimateMarkerIndex].toString().split('{!~!}');
        AnimateTimerInterval = AnimateIntervalArray[10];
    }
}

function AddAnimateMarkerOnMap(MarkerIndex) {
    var AnimateMarkerOption = new Array();
    AnimateMarkerOption = AnimateMarkerItem[MarkerIndex].toString().split('{!~!}');
    RemoveMarkers();
    RemovePopups();
    MapSetCenter(AnimateMarkerOption[0], AnimateMarkerOption[1]);
    AddMarker(AnimateMarkerOption[0], AnimateMarkerOption[1], AnimateMarkerOption[2], AnimateMarkerOption[3], AnimateMarkerOption[4], AnimateMarkerOption[5], AnimateMarkerOption[6], AnimateMarkerOption[7], AnimateMarkerOption[8], true, false, false, false, false, false, false);
    document.getElementById('LastDate').value = AnimateMarkerOption[9];

}

function LoadMarkers(DrawLineBetweenMarkers, HasPopup, VerticalCentering, StartIndex, _IsDraggable, ShowTitle) {
    if (AnimateMarkerHandler != null) {
        clearInterval(AnimateMarkerHandler);
    }
    //--
    //--
    //MapSetCenter(document.getElementById(MapCenterPositionClientID).value.split(',')[0], document.getElementById(MapCenterPositionClientID).value.split(',')[1]);
    var PreMarkers = new Array();
    var MarkerItem = new Array();
    MarkerItem = document.getElementById(MarkersClientID).value.toString().split('{!~!~!}');
    //Line Color
    var CuDrawLineColor = "ff0000";
    var LineColorFromLinesInfo = new Array();
    if (document.getElementById(DrawLinesInfoClientID).value != "" && document.getElementById(DrawLinesInfoClientID).value != null) {
        LineColorFromLinesInfo = document.getElementById(DrawLinesInfoClientID).value.toString().split("{!~!~!}");
    }

    if (StartIndex > 0) {
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[StartIndex - 1].toString().split('{!~!}');
        PreMarkers[StartIndex - 1] = MarkerOption[0] + "#" + MarkerOption[1];
    }

    for (i = StartIndex; i < MarkerItem.length; i++) {
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[i].toString().split('{!~!}');

        //if (MarkerOption[2].split('_')[0] = "Bus")
        //    AddMarker(MarkerOption[0], MarkerOption[1], "Arrow_" + MarkerOption[2], "", MarkerOption[4], 32, 32, 90, 20, true, HasPopup);

        AddMarker(MarkerOption[0], MarkerOption[1], MarkerOption[2], MarkerOption[3], MarkerOption[4], MarkerOption[5], MarkerOption[6], MarkerOption[7], MarkerOption[8], true, HasPopup, VerticalCentering, false, false, _IsDraggable, ShowTitle);
        //             lon              lat             name             title           imageUrl           width           height          TitleWidth      TitleHeight

        PreMarkers[i] = MarkerOption[0] + "#" + MarkerOption[1];

        if (DrawLineBetweenMarkers == "True" && i > 0) {
            if (LineColorFromLinesInfo[i] != null && LineColorFromLinesInfo[i] != "") {
                CuDrawLineColor = LineColorFromLinesInfo[i].toString();
                DrawLine(PreMarkers[i - 1].split('#')[0], PreMarkers[i - 1].split('#')[1], MarkerOption[0], MarkerOption[1], "LBM" + i, "", CuDrawLineColor, "0.6", "6", true, true);
                //                lon1                               lat1                          lon2          lat2           name   title     color      opacity width direction
            }
        }
    }
    map.addLayer(markers);
}

function LoadUserMarkers(_HasRightClick, _HasLeftClick, _IsDraggable) {
    RemoveUsersMarkers(_IsDraggable);
    var Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight;
    var MarkerItem = new Array();
    MarkerItem = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
    if (BaseMarkerIndex == -1)
        BaseMarkerIndex = MarkerItem.length - 1;
    UserMarkerCount = MarkerItem.length;

    var points = new Array();
    for (i = 0; i < MarkerItem.length; i++) {
        if (MarkerItem[i] == null || MarkerItem[i] == "")
            continue;
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[i].toString().split(',');
        if (_IsDraggable) {
            points.push(new OpenLayers.Geometry.Point(MarkerOption[1], MarkerOption[2]).transform(Projection_4326, Projection_3857));
        }
        else {
            if (document.getElementById(DrawMarkersInfoClientID).value != "" && document.getElementById(DrawMarkersInfoClientID).value != null) {
                var DMI = new Array();
                DMI = document.getElementById(DrawMarkersInfoClientID).value.toString().split('{!~!}');
                Name = MarkerOption[0];
                Title = DMI[1] + MouseClickCounter;
                imageUrl = DMI[2];
                imgWidth = DMI[3];
                imgHeight = DMI[4];
                titleWidth = DMI[5];
                titleHeight = DMI[6];
            }
            else {
                Name = "M" + "_" + i;
                Title = "M" + i;
                imageUrl = "../WebControllers/MainControls/OpenLayersMap/DefaultMarker_s64.png";
                imgWidth = 32;
                imgHeight = 32;
                titleWidth = 15;
                titleHeight = 15;
            }
            AddMarker(MarkerOption[1], MarkerOption[2], "USM_" + Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight, true, false, false, _HasRightClick, _HasLeftClick, false, false);
        }
    }
    if (_IsDraggable) {
        var line = new OpenLayers.Geometry.LineString(points);

        var style = {
            strokeColor: '#0000ff',
            strokeOpacity: 0.5,
            strokeWidth: 3
        };

        var lineFeature = new OpenLayers.Feature.Vector(line, null, style);
        VectorLayerForMarker.addFeatures([lineFeature]);
    }
}

function SaveUserMarkers(sender, e) {
    var points = VectorLayerForMarker.features[0].geometry.getVertices();
    var _strMarkers = '';
    for (var i = 0; i < points.length; i++) {
        var point = points[i].transform(Projection_3857, Projection_4326);
        _strMarkers += '{!~!},' + point.x + ',' + point.y;
    }
    _strMarkers = _strMarkers.substr("{!~!}".length, _strMarkers.length - "{!~!}".length);
    document.getElementById(UserMarkersClientID).value = _strMarkers;
}

function LoadLines() {
    var LineItem = new Array();
    LineItem = document.getElementById(LinesClientID).value.toString().split('{!~!~!}');
    for (i = 1; i < LineItem.length; i++) {
        var LineOption = new Array();
        LineOption = LineItem[i].toString().split('{!~!}');
        DrawLine(LineOption[0], LineOption[1], LineOption[2], LineOption[3], LineOption[4], LineOption[5], LineOption[6], LineOption[7], LineOption[8], LineOption[9], true);
        //           lon1           lat1           lon2           lat2           name           title          color          opacity         width       direction
    }
}

function LoadUserLines() {
    RemoveAllLine();
    var LineName, LineTitle, LineColor, LineOpacity, LineWidth, LineDirection;
    var Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight;
    var MarkerItem = new Array();
    MarkerItem = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
    for (i = 0; i < MarkerItem.length; i++) {
        if (MarkerItem[i] == null || MarkerItem[i] == "")
            continue;
        var Point1Lon, Point1Lat, Point2Lon, Point2Lat;
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[i].toString().split(',');
        Point1Lon = MarkerOption[1].toString();
        Point1Lat = MarkerOption[2].toString();
        var MarkerOptionNext = new Array();
        if ((i + 1) < MarkerItem.length) {
            MarkerOptionNext = MarkerItem[i + 1].toString().split(',');
            Point2Lon = MarkerOptionNext[1].toString();
            Point2Lat = MarkerOptionNext[2].toString();
        }
        else {
            return;
        }
        if (document.getElementById(DrawLinesInfoClientID).value != "" && document.getElementById(DrawLinesInfoClientID).value != null) {
            var DLI = new Array();
            DLI = document.getElementById(DrawLinesInfoClientID).value.toString().split('{!~!}');
            LineName = DLI[0];
            LineTitle = DLI[1];
            LineColor = DLI[2];
            LineOpacity = DLI[3];
            LineWidth = DLI[4];
            LineDirection = DLI[5];
        }
        else {
            LineName = i;
            LineTitle = "";
            LineColor = "ff0000";
            LineOpacity = "0.7";
            LineWidth = 8;
            LineDirection = "false";
        }
        DrawLine(Point1Lon, Point1Lat, Point2Lon, Point2Lat, "USL_" + LineName + "_" + i, LineTitle, LineColor, LineOpacity, LineWidth, LineDirection, true);
    }
}

function AddMarker(lon, lat, name, title, imgURL, imgWidth, imgHeight, TitleWidth, TitleHeight, TransformLocation, HasPopup, VerticalCentering, _HasRightClick, _HasLeftClick, _IsDraggable, ShowTitle, hasInfraction) {
    var location = (TransformLocation == true) ? new OpenLayers.LonLat(lon, lat).transform(new OpenLayers.Projection('EPSG:4326'), new OpenLayers.Projection('EPSG:3857')) :
                    new OpenLayers.LonLat(lon, lat);
    var size = new OpenLayers.Size(imgWidth, imgHeight);
    var offset;
    if (VerticalCentering)
        offset = new OpenLayers.Pixel(-(size.w / 2), -(size.h / 2));
    else
        offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
    var IconType = name.split('_')[0];
    if (IconType == "Bus") {
        if (parseInt(imgURL) >= 30 & parseInt(imgURL) < 150) {
            imgURL = "../WebBusManagement/Images/bus_s64_right.png";
        }
        else {
            imgURL = "../WebBusManagement/Images/bus_s64.png";
        }
    }
    else if (IconType == "USM") {
        var MarkerIndex = parseInt(name.split('_')[2]);
        if (MarkerIndex == 0) {
            imgURL = "../WebBusManagement/Images/ViewMapArrow/A.png";
            offset = new OpenLayers.Pixel(-(size.w / 2), -(size.h / 2));
        }
        else if (MarkerIndex == UserMarkerCount - 1) {
            imgURL = "../WebBusManagement/Images/ViewMapArrow/B.png";
            offset = new OpenLayers.Pixel(-(size.w / 2), -(size.h / 2));
        }
        else if (MarkerIndex == BaseMarkerIndex)
            imgURL = "../WebControllers/MainControls/OpenLayersMap/SelectedMarker_64.png";
        else
            imgURL = "../WebControllers/MainControls/OpenLayersMap/DefaultMarker_s64.png";
        //imgURL = "../WebBusManagement/Images/station_s64.png";
    }
    else if (IconType == "Sim") {
        imgURL = "../WebBusManagement/Images/simcardcharge_low.gif";
    }
    else if (IconType == "Speed") {
        imgURL = "../WebBusManagement/Images/red_circle.png";
    }
    else if (IconType == "Station") {
        if (name.split('_')[1] == "Terminal") {
            size = new OpenLayers.Size(36, 36);
            offset = new OpenLayers.Pixel(-(size.w / 2), -(size.h / 2));
            imgURL = "../WebBusManagement/Images/BusTerminal.png";
        }
        else
            imgURL = "../WebBusManagement/Images/station_s64.png";
    }
    else if (IconType == "Arrow") {
        if (parseInt(imgURL) >= 330) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_up.png";
        }
        else if (parseInt(imgURL) >= 0 & parseInt(imgURL) < 30) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_up.png";
        }
        else if (parseInt(imgURL) >= 30 & parseInt(imgURL) < 60) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_upright.png";
        }
        else if (parseInt(imgURL) >= 60 & parseInt(imgURL) < 120) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_right.png";
        }
        else if (parseInt(imgURL) >= 120 & parseInt(imgURL) < 150) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_downright.png";
        }
        else if (parseInt(imgURL) >= 150 & parseInt(imgURL) < 210) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_down.png";
        }
        else if (parseInt(imgURL) >= 210 & parseInt(imgURL) < 240) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_downleft.png";
        }
        else if (parseInt(imgURL) >= 240 & parseInt(imgURL) < 300) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_left.png";
        }
        else if (parseInt(imgURL) >= 300 & parseInt(imgURL) < 330) {
            imgURL = "../WebBusManagement/Images/Arrow/arrow_upleft.png";
        }
    }
    //var icon = new OpenLayers.Icon(imgURL, size, offset);
    //var MyMarker = new OpenLayers.Marker(location, icon.clone());

    if (HasPopup && hasInfraction)
        markers = new OpenLayers.Layer.Markers("MyMarkers");//Action Click

    if (_IsDraggable) {
        var feature = new OpenLayers.Feature.Vector(
            new OpenLayers.Geometry.Point(lon, lat).transform(Projection_4326, Projection_3857)
        );
        feature.id = name;
        VectorLayerForMarker.addFeatures(feature);

    }
    else // Is Not A Draggable Marker
    {
        var icon = new OpenLayers.Icon(imgURL, size, offset);
        var MyMarker = new OpenLayers.Marker(location, icon.clone());

        MyMarker.id = name;
        icon.imageDiv.title = name.split('_')[1];
        if (_HasRightClick) {
            MyMarker.events.register("mousedown", MyMarker, function (e) {
                var markerLocation = new OpenLayers.LonLat(MyMarker.lonlat.lon, MyMarker.lonlat.lat).transform(new OpenLayers.Projection('EPSG:3857'), new OpenLayers.Projection('EPSG:4326'));
                var MLat = markerLocation.lon;
                var MLon = markerLocation.lat;
                if (OpenLayers.Event.isRightClick(e)) {
                    var menu = document.getElementById(ContextMenuClientID);
                    document.getElementById(SelectedMarkerClientID).value = MyMarker.id;
                    menu.style.left = e.pageX + 'px';
                    menu.style.top = e.pageY + 'px';
                    $("#" + ContextMenuClientID).fadeIn();
                    MarkerRightClicked = true;
                }
                else {
                    $("#" + ContextMenuClientID).fadeOut();
                    MarkerRightClicked = false;
                }
            });
        }
        var clickCounter = 0;
        var Clickpopup;

        if (ShowTitle) {
            MyMarker.events.register("click", MyMarker, function (e) {
                if (clickCounter == 0) {
                    clickCounter = 1;
                    //RemoveMarkerDescriptionPopup();
                    //ShowLoading("Popup", MyMarker.lonlat);
                    Clickpopup = new OpenLayers.Popup.Anchored("Pop_" + name,
                             MyMarker.lonlat,
                             new OpenLayers.Size(50, 30),
                             "<div class='TitlePopup'>" + title + "</div>", null, false);
                    Clickpopup.backgroundColor = 'transparent';
                    Clickpopup.autoSize = true;
                    var offset = { 'size': new OpenLayers.Size(0, 0), 'offset': new OpenLayers.Pixel(-74, 60) };
                    Clickpopup.anchor = offset;
                    Clickpopup.panMapIfOutOfView = true;
                    Clickpopup.relativePosition = "br";
                    Clickpopup.calculateRelativePosition = function () {
                        return 'tr';
                    }
                    Clickpopup.opacity = 1;
                    //Clickpopup.displayClass = 'MarkerClickPopupClass';
                    map.addPopup(Clickpopup);
                    return;
                    //HideLoading("Popup");
                }
                else if (clickCounter == 1) {
                    map.removePopup(Clickpopup);
                    clickCounter = 0;
                }
            });
        }

        //_MouseClickAddUserMarker
        if (HasPopup) {
            //MyMarker.events.register('mouseover', MyMarker, function (evt) {
            //    MyMarker.Icon.url = "../WebBusManagement/Images/Arrow/arrow_upleft.png";
            //});
            MyMarker.events.register("click", MyMarker, function (e) {
                if (clickCounter == 0) {
                    clickCounter = 1;
                    RemoveMarkerDescriptionPopup();
                    var PopupTextFromServer = new Array();
                    var PopupParam = new Array();
                    PopupParam[0] = "Popup";
                    PopupParam[1] = name;
                    ShowLoading("Popup", MyMarker.lonlat);
                    Request(document.getElementById(ActionClientID).value, PopupParam, true, function () {
                        HideLoading("Popup");
                        PopupTextFromServer = StrRequest[0].toString().split('{!~!}');
                        if (PopupTextFromServer[0] != null) {
                            Clickpopup = new OpenLayers.Popup.Anchored("Pop_" + name,
                                     MyMarker.lonlat,
                                     new OpenLayers.Size(PopupTextFromServer[0], PopupTextFromServer[1]),
                                     PopupTextFromServer[2], null, false);
                            Clickpopup.backgroundColor = 'transparent';
                            Clickpopup.autoSize = false;
                            var offset = { 'size': new OpenLayers.Size(0, 0), 'offset': new OpenLayers.Pixel(-50, -15) };
                            Clickpopup.anchor = offset;
                            Clickpopup.panMapIfOutOfView = true;
                            Clickpopup.relativePosition = "br";
                            Clickpopup.calculateRelativePosition = function () {
                                return 'tr';
                            }
                            Clickpopup.opacity = 1;
                            //Clickpopup.displayClass = 'MarkerClickPopupClass';
                            map.addPopup(Clickpopup);
                        }
                    });
                    //HideLoading("Popup");
                }
                else if (clickCounter == 1) {
                    map.removePopup(Clickpopup);
                    clickCounter = 0;
                }
            });
        }
        else if (_HasLeftClick) {
            MyMarker.events.register("click", MyMarker, function (e) {
                var MarkerIndex = parseInt(name.split('_')[2]);
                BaseMarkerIndex = MarkerIndex;
                LoadUserMarkers(_HasRightClick, _HasLeftClick, _IsDraggable);
                LoadMarkers('False', false, true, 0, false, false);
            });
        }
        markers.addMarker(MyMarker);
    }
    if (HasPopup)
        map.addLayer(markers);//Action Click
}

function AddMarkerWithLabel(lon, lat, name, title, imgURL, imgWidth, imgHeight, TitleWidth, TitleHeight, TransformLocation) {
    var location = (TransformLocation == true) ? new OpenLayers.LonLat(lon, lat).transform(new OpenLayers.Projection('EPSG:4326'), new OpenLayers.Projection('EPSG:3857')) :
                    new OpenLayers.LonLat(lon, lat);
    var size = new OpenLayers.Size(imgWidth, imgHeight);
    var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
    var icon = new OpenLayers.Icon(imgURL, size, offset);
    var MyMarker = new OpenLayers.Marker(location, icon.clone());
    MyMarker.id = name;
    MyMarker.icon.imageDiv.title = name.split('_')[0];

    if (document.getElementById(HasRightClickClientID).value == "True") {
        MyMarker.events.register("mousedown", MyMarker, function (e) {
            var markerLocation = new OpenLayers.LonLat(MyMarker.lonlat.lon, MyMarker.lonlat.lat).transform(new OpenLayers.Projection('EPSG:3857'), new OpenLayers.Projection('EPSG:4326'));
            var MLat = markerLocation.lon;
            var MLon = markerLocation.lat;
            if (OpenLayers.Event.isRightClick(e)) {
                var menu = document.getElementById(ContextMenuClientID);
                document.getElementById(SelectedMarkerClientID).value = MyMarker.id;
                menu.style.left = e.pageX + 'px';
                menu.style.top = e.pageY + 'px';
                $("#" + ContextMenuClientID).fadeIn();
            }
            else {
                $("#" + ContextMenuClientID).fadeOut();
            }
        });
    }
    var clickCounter = 0;
    var Clickpopup;

    //_MouseClickAddUserMarker
    if (document.getElementById(MarkerClickClientID).value == "True") {
        MyMarker.events.register("click", MyMarker, function (e) {
            if (clickCounter == 0) {
                clickCounter = 1;
                RemoveMarkerDescriptionPopup();
                var PopupTextFromServer = new Array();
                var PopupParam = new Array();
                PopupParam[0] = "Popup";
                PopupParam[1] = name;
                ShowLoading("Popup", MyMarker.lonlat);
                Request(document.getElementById(ActionClientID).value, PopupParam, true, function () {
                    HideLoading("Popup");
                    PopupTextFromServer = StrRequest[0].toString().split('{!~!}');
                    if (PopupTextFromServer[0] != null) {
                        Clickpopup = new OpenLayers.Popup.Anchored("Description_" + name,
                                 MyMarker.lonlat,
                                 new OpenLayers.Size(PopupTextFromServer[0], PopupTextFromServer[1]),
                                 PopupTextFromServer[2].replace("{CLOSE_POPUP}", "RemoveMarkerDescriptionPopup();"), null, true);
                        Clickpopup.backgroundColor = 'transparent';
                        Clickpopup.relativePosition = "bl";
                        Clickpopup.opacity = 1;
                        //Clickpopup.displayClass = 'MarkerClickPopupClass';
                        map.addPopup(Clickpopup);
                    }
                });
                //HideLoading("Popup");
            }
            else if (clickCounter == 1) {
                map.removePopup(Clickpopup);
                clickCounter = 0;
            }
        });
    }

    if (title != null && title.length > 0) {
        var popup = new OpenLayers.Popup.Anchored("Popup_" + name,
                         MyMarker.lonlat,
                         new OpenLayers.Size(TitleWidth, TitleHeight),
                         title,
                         null, true);
        popup.backgroundColor = 'transparent';
        popup.relativePosition = "tr";
        popup.opacity = 1;
        map.addPopup(popup);
        //var popup = new OpenLayers.Popup("Popup_" + name,
        //       new OpenLayers.LonLat(lon, lat),
        //       new OpenLayers.Size(TitleWidth, TitleHeight),
        //       title,
        //       true);
        //map.addPopup(popup);
    }
    markers.addMarker(MyMarker);
}

function ShowLoading(name, lonlat) {
    loadingPopup = new OpenLayers.Popup.Anchored("Loading_" + name,
     lonlat,
     new OpenLayers.Size(48, 48),
     "<img src='Images/loading_s32.png'/>", null, true);
    loadingPopup.backgroundColor = 'transparent';
    loadingPopup.relativePosition = "bl";
    loadingPopup.opacity = 1;
    map.addPopup(loadingPopup);
}

function HideLoading(name) {
    for (i = map.popups.length - 1; i >= 0; i--) {
        stringId = map.popups[i].id.toString();
        if (stringId == "Loading_" + name) {
            map.removePopup(map.popups[i]);
            return;
        }
    }
}

function RemoveMarkers() {
    //markers.clearMarkers();
    VectorLayerForMarker.destroy();
    VectorLayerForMarker = new OpenLayers.Layer.Vector("MarkerLabel");
    map.addLayer(VectorLayerForMarker);
    markers.destroy();
    document.getElementById(MarkersClientID).value = "";
    markers = new OpenLayers.Layer.Markers("MyMarkers");
    map.addLayer(markers);
}

function RemoveUsersMarkers(_IsDraggable) {
    if (_IsDraggable)
        ModifyControl.destroy();
    VectorLayerForMarker.destroy();
    VectorLayerForMarker = new OpenLayers.Layer.Vector("MarkerLabel", {
        renderers: renderer
    });
    if (_IsDraggable) {
        ModifyControl = new OpenLayers.Control.ModifyFeature(VectorLayerForMarker);
        map.addControl(ModifyControl);
    }
    map.addLayer(VectorLayerForMarker);
    markers.destroy();
    markers = new OpenLayers.Layer.Markers("MyMarkers");
    map.addLayer(markers);
}

function RemovePopups() {
    var stringId;
    for (i = map.popups.length - 1; i >= 0; i--) {
        stringId = map.popups[i].id.toString();
        if (stringId.substr(0, 3) == "Pop") {
            map.removePopup(map.popups[i]);
        }
    }
}

function RemoveUserPopups() {
    var stringId;
    for (i = map.popups.length - 1; i >= 0; i--) {
        stringId = map.popups[i].id.toString();
        if (stringId.length > 11 && stringId.substr(0, 11) == "Popup_USM_M") {
            map.removePopup(map.popups[i]);
        }
    }
}

function RemoveMarkerDescriptionPopup() {
    var stringId;
    for (i = map.popups.length - 1; i >= 0; i--) {
        stringId = map.popups[i].id.toString();
        if (stringId.substr(0, 3) == "Des") {
            map.removePopup(map.popups[i]);
        }
    }
}

function SetServiceParam(strParam) {
    document.getElementById(ServiceParamClientID).value = "";
    document.getElementById(ServiceParamClientID).value = strParam;
}

function SetOtherParam(strParam) {
    document.getElementById(OtherParamClientID).value = "";
    document.getElementById(OtherParamClientID).value = strParam;
}

function SetMarkers(strMarkers, DrawLine, LineColor) {
    document.getElementById(MarkersClientID).value = "";
    document.getElementById(DrawLinesInfoClientID).value = "";
    RemoveMarkers();
    RemovePopups();
    RemoveAllLine();
    var j = 1;
    for (i = 0; i < strMarkers.length; i++) {
        if (strMarkers[i].toString() == "Marker") {
            document.getElementById(MarkersClientID).value = document.getElementById(MarkersClientID).value + "{!~!~!}" + strMarkers[i + 1].toString();
        }
    }
    if (DrawLine == "True" && LineColor.length > 0) {
        for (j = 0 ; j < LineColor.length ; j++) {
            if (LineColor[j] != null)
                document.getElementById(DrawLinesInfoClientID).value += "{!~!~!}" + LineColor[j].toString();
            else
                document.getElementById(DrawLinesInfoClientID).value += "{!~!~!}";
        }
    }
    if (strMarkers.length > 0) {
        var _strMarkers = document.getElementById(MarkersClientID).value;
        _strMarkers = _strMarkers.substr("{!~!~!}".length, _strMarkers.length - "{!~!~!}".length);
        document.getElementById(MarkersClientID).value = _strMarkers;
    }
    if (DrawLine == "True" && LineColor.length > 0) {
        var _LineColor = document.getElementById(DrawLinesInfoClientID).value;
        _LineColor = _LineColor.substr("{!~!~!}".length, _LineColor.length - "{!~!~!}".length);
        document.getElementById(DrawLinesInfoClientID).value = _LineColor;
    }
    LoadMarkers(DrawLine, false, false, 0, false, false);
}


function SetMarkersAppend(strMarkers, DrawLine, LineColor, HasPopup, StartIndex) {
    var j = 1;
    if (StartIndex == 0) {
        document.getElementById(MarkersClientID).value = "";
        document.getElementById(DrawLinesInfoClientID).value = "";
    }
    for (i = 0; i < strMarkers.length; i++) {
        if (strMarkers[i].toString() == "Marker") {
            document.getElementById(MarkersClientID).value += "{!~!~!}" + strMarkers[i + 1].toString();
        }
    }
    if (DrawLine == "True" && LineColor.length > 0) {
        for (j = 0 ; j < LineColor.length ; j++) {
            if (LineColor[j] != null)
                document.getElementById(DrawLinesInfoClientID).value += "{!~!~!}" + LineColor[j].toString();
            else
                document.getElementById(DrawLinesInfoClientID).value += "{!~!~!}";
        }
    }
    if (StartIndex == 0) {
        if (strMarkers.length > 0) {
            var _strMarkers = document.getElementById(MarkersClientID).value;
            _strMarkers = _strMarkers.substr("{!~!~!}".length, _strMarkers.length - "{!~!~!}".length);
            document.getElementById(MarkersClientID).value = _strMarkers;
        }
        if (DrawLine == "True" && LineColor.length > 0) {
            var _LineColor = document.getElementById(DrawLinesInfoClientID).value;
            _LineColor = _LineColor.substr("{!~!~!}".length, _LineColor.length - "{!~!~!}".length);
            document.getElementById(DrawLinesInfoClientID).value = _LineColor;
        }
    }
    //<%--    else {
    //        for (i = 0; i < strMarkers.length; i++) {
    //            if (strMarkers[i].toString() == "Marker")
    //            document.getElementById(DrawLinesInfoClientID).value += "{!~!~!}";
    //        }
    //    }--%>
    LoadMarkers(DrawLine, HasPopup, true, StartIndex, false, false);
}

function AddOneMarkerAndDrawLine(RemoveOldMarkerAndLine, Marker, DrawLineStatus, Line) {
    if (RemoveOldMarkerAndLine == "True") {
        RemoveAllLine();
        RemoveMarkers();
    }
    var MarkerOption = new Array();
    MarkerOption = Marker.split("{!~!}");
    if (DrawLineStatus == "True") {
        DrawLine(Line[2], Line[3], MarkerOption[0], MarkerOption[1], Line[4], Line[5], Line[6], Line[7], Line[8], true, true);
    }
    AddMarker(MarkerOption[0], MarkerOption[1], MarkerOption[2], MarkerOption[3], MarkerOption[4], MarkerOption[5], MarkerOption[6], MarkerOption[7], MarkerOption[8], true, false, false, false, false, false, false);
}

function DrawLine(lonPoint1, latPoint1, lonPoint2, latPoint2, Name, Title, LineColorHeX, LineOpacity, LineWidth, Direction, TransformLocation) {
    map.addControl(new OpenLayers.Control.DrawFeature(lineLayer, OpenLayers.Handler.Path));
    var points = new Array();
    points[0] = (TransformLocation == true) ? new OpenLayers.LonLat(lonPoint1, latPoint1).transform(new OpenLayers.Projection('EPSG:4326'), new OpenLayers.Projection('EPSG:3857')) :
                    new OpenLayers.LonLat(lonPoint1, latPoint1);
    //new OpenLayers.LonLat(lonPoint1, latPoint1).transform(new OpenLayers.Projection("EPSG:4326"), new OpenLayers.Projection('EPSG:3857'));;
    points[0] = new OpenLayers.Geometry.Point(points[0].lon, points[0].lat);

    points[1] = (TransformLocation == true) ? new OpenLayers.LonLat(lonPoint2, latPoint2).transform(new OpenLayers.Projection('EPSG:4326'), new OpenLayers.Projection('EPSG:3857')) :
                    new OpenLayers.LonLat(lonPoint2, latPoint2);
    //new OpenLayers.LonLat(lonPoint2, latPoint2).transform(new OpenLayers.Projection("EPSG:4326"), new OpenLayers.Projection('EPSG:3857'));;
    points[1] = new OpenLayers.Geometry.Point(points[1].lon, points[1].lat);

    var line = new OpenLayers.Geometry.LineString(points);
    var style = {
        label: Title,
        labelAlign: 'cm',
        strokeColor: '#' + LineColorHeX,
        strokeOpacity: LineOpacity,
        strokeWidth: LineWidth
    };
    var lineFeature = new OpenLayers.Feature.Vector(line, null, style);
    lineLayer.addFeatures([lineFeature]);
}

function RemoveAllLine() {
    lineLayer.removeAllFeatures();
    //<%--    document.getElementById(DrawLinesInfoClientID).value = "";
    //    lineLayer.destroy();
    //    lineLayer = new OpenLayers.Layer.Vector("MyLines");
    //    map.addLayer(lineLayer);--%>
}

function getUserMarkers() {
    var result = new Array();
    var markers_field = document.getElementById(UserMarkersClientID);
    var markers_obj = markers_field.value.toString().split("{!~!}");
    for (var i = 0; i < markers_obj.length; i++) {
        result.push([markers_obj[i].toString().split(",")]);
    }
    return result;
}

function setUserMarkers(markers_obj) {
    var result = "";
    for (var i = 0; i < markers_obj.length; i++) {
        result += "{!~!}" + markers_obj[i].toString();
    }
    if (result.length > 4) result = result.substr(5, result.length - 5);
    return result;
}

function findUserMarker(markers_obj, item) {
    for (var i = 0; i < markers_obj.length; i++) {
        if (markers_obj[i].toString() == item)
            return i;
    }
    return -1;
}

function RemoveUserMarker(item) {
    var MarkerIndex = parseInt(item.toString().split('_')[2]);
    var MarkerItem = new Array();
    var strUserMarkers = '';
    if (document.getElementById(UserMarkersClientID).value != null && document.getElementById(UserMarkersClientID).value != '') {
        MarkerItem = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
    }

    for (var i = 0; i < MarkerIndex; i++)
        strUserMarkers += MarkerItem[i] + '{!~!}';

    for (var i = MarkerIndex + 1; i < MarkerItem.length; i++)
        strUserMarkers += MarkerItem[i] + '{!~!}';
    document.getElementById(UserMarkersClientID).value = strUserMarkers.substr(0, strUserMarkers.length - '{!~!}'.length);

    if (BaseMarkerIndex >= MarkerIndex)
        BaseMarkerIndex--;

    LoadUserMarkers(true, true, false);
    if (document.getElementById(DrawLinesClientID).value == "True") {
        LoadUserLines();
        LoadMarkers('False', false, true, 0, false, false);
    }
    $("#" + ContextMenuClientID).fadeOut();
    MarkerRightClicked = false;
    //<%--    var MarkerId = item.toString().split('_');
    //    var markersarr = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
    //    //document.getElementById(UserMarkersClientID).value = "";
    //    for (var i = 0; i < markersarr.length; i++) {
    //        if (i == parseInt(MarkerId[2])) {
    //            document.getElementById(UserMarkersClientID).value = document.getElementById(UserMarkersClientID).value.toString().replace(markersarr[i], '');
    //        }
    //        //document.getElementById(UserMarkersClientID).value = markersarr[i].toString() + "{!~!}";
    //    }
    //    RemovePopups();
    //    RemoveAllLine();
    //    //if (CheckOption("DrawUserLines") == true)
    //    //    LoadUserLines();
    //    LoadUserMarkersLinePath();--%>
}

function LoadUserMarkersLinePath() {
    RemoveUsersMarkers(false);
    var Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight;
    var MarkerItem = new Array();
    MarkerItem = document.getElementById(UserMarkersClientID).value.toString().split('{!~!}');
    for (i = 0; i < MarkerItem.length; i++) {
        if (MarkerItem[i] == null || MarkerItem[i] == "")
            continue;
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[i].toString().split(',');
        if (document.getElementById(DrawMarkersInfoClientID).value != "" && document.getElementById(DrawMarkersInfoClientID).value != null) {
            var DMI = new Array();
            DMI = document.getElementById(DrawMarkersInfoClientID).value.toString().split('{!~!}');
            Name = MarkerOption[0];
            Title = DMI[1] + MouseClickCounter;
            imageUrl = DMI[2];
            imgWidth = DMI[3];
            imgHeight = DMI[4];
            titleWidth = DMI[5];
            titleHeight = DMI[6];
        }
        else {
            Name = "M" + "_" + i;
            Title = "M" + i;
            imageUrl = "../WebControllers/MainControls/OpenLayersMap/DefaultMarker_s64.png";
            imgWidth = 32;
            imgHeight = 32;
            titleWidth = 15;
            titleHeight = 15;
        }
        AddMarker(MarkerOption[2], MarkerOption[1], "USM_" + Name, Title, imageUrl, imgWidth, imgHeight, titleWidth, titleHeight, true, false, false, false, false, false, false);
    }
}

function CheckOption(optionType) {
    if (optionType == "DrawUserLines")
        if (document.getElementById(DrawLinesClientID).value == "True")
            return true;

    return false;
}

function SetNewTimerInterval(Interval, CounterUpdate) {
    document.getElementById(TimerIntervalClientID).value = Interval;
    if (CounterUpdate == true) {
        counter = parseInt(Interval) + 1;
    }
}

function SetAddMarkerMode(Mode) {
    document.getElementById('AddMarkerMode').value = Mode;
}

function MapSetCenter(Lon, Lat) {
    var CenterLonLat;
    CenterLonLat = new OpenLayers.LonLat(Lon, Lat).transform(Projection_4326, Projection_3857);
    var MapZoom = map.zoom;
    if (parseInt(MapZoom) <= 12) {
        map.setCenter(CenterLonLat, 12);
    }
    else {
        map.setCenter(CenterLonLat, MapZoom);
    }
}

function MapSetCenterWithZoom(Lon, Lat, Zoom) {
    var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
    var toProjection = new OpenLayers.Projection("EPSG:3857"); // to Spherical Mercator Projection

    CenterLonLat = new OpenLayers.LonLat(Lon, Lat).transform(fromProjection, toProjection);
    map.setCenter(CenterLonLat, Zoom);
}

function SetMarkerAndloadIt(Marker) {
    var strMarker = Marker.toString().substr("Marker,{!~!~!}".length, Marker.toString().length - "Marker,{!~!~!}".length);
    document.getElementById(MarkersClientID).value = strMarker;
    //var strMarkers = 
    LoadMarkers('False', false, true, 0, false, true);
    //<%--    if (Marker != null)
    //    for (i = 0; i < Marker.length / 2; i++) {
    //            document.getElementById(DrawLinesInfoClientID).value = document.getElementById(DrawLinesInfoClientID).value + "{!~!~!}";
    //        }--%>
}

function SetMarkerAndloadItNoDelete(Marker, hasPopup, hasInfraction) {
    document.getElementById(MarkersClientID).value += Marker;
    LoadMarkersNoDelete('False', hasPopup, hasInfraction);
}

function LoadMarkersNoDelete(DrawLineBetweenMarkers, hasPopup, hasInfraction) {
    if (AnimateMarkerHandler != null) {
        clearInterval(AnimateMarkerHandler);
    }
    //RemoveMarkers();
    //RemovePopups();
    //--
    //--
    //MapSetCenter(document.getElementById(MapCenterPositionClientID).value.split(',')[0], document.getElementById(MapCenterPositionClientID).value.split(',')[1]);
    var PreMarkers = new Array();
    var MarkerItem = new Array();
    MarkerItem = document.getElementById(MarkersClientID).value.toString().split('{!~!~!}');

    //Line Color
    var CuDrawLineColor = "ff0000";
    var LineColorFromLinesInfo = new Array();
    if (document.getElementById(DrawLinesInfoClientID).value != "" || document.getElementById(DrawLinesInfoClientID).value != null) {
        LineColorFromLinesInfo = document.getElementById(DrawLinesInfoClientID).value.toString().split("{!~!~!}");
    }

    for (i = 1; i < MarkerItem.length; i++) {
        var MarkerOption = new Array();
        MarkerOption = MarkerItem[i].toString().split('{!~!}');
        if (MarkerOption[2].split('_')[0] == "LinePoint" || MarkerOption[2].split('_')[0] == "Bus")
            AddMarker(MarkerOption[0], MarkerOption[1], MarkerOption[2], MarkerOption[3], MarkerOption[4], MarkerOption[5], MarkerOption[6], MarkerOption[7], MarkerOption[8], true, hasPopup, false, false, false, false, false, hasInfraction);
        //                lon              lat             name             title           imageUrl           width           height          TitleWidth      TitleHeight
        if (MarkerOption[2].split('_')[0] = "Bus") {
            //AddMarker(MarkerOption[0], MarkerOption[1], "Arrow_" + MarkerOption[2], "", MarkerOption[4], 32, 32, 90, 20, true);
        }

        PreMarkers[i] = MarkerOption[0] + "#" + MarkerOption[1];

        if (DrawLineBetweenMarkers == "True" && i > 1) {
            if (LineColorFromLinesInfo[i] != null || LineColorFromLinesInfo[i] != "") {
                CuDrawLineColor = LineColorFromLinesInfo[i].toString();
            }
            DrawLine(PreMarkers[i - 1].split('#')[0], PreMarkers[i - 1].split('#')[1], MarkerOption[0], MarkerOption[1], "LBM" + i, "", CuDrawLineColor, "0.6", "6", true, true);
            //                lon1                               lat1                          lon2          lat2           name   title     color      opacity width direction
        }
    }
}