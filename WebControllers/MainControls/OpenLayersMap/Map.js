//var map = null;
//function init() {
//    var options = {
//        controls: [
//            new OpenLayers.Control.KeyboardDefaults({
//                observeElement: 'map'
//            })
//        ]
//    };
//    map = new OpenLayers.Map('map', options);
//    var wms = new OpenLayers.Layer.WMS(
//        "OpenLayers WMS",
//        "http://vmap0.tiles.osgeo.org/wms/vmap0?",
//        { layers: 'basic' }
//    );
//    map.addLayer(wms);
//    map.zoomToMaxExtent();
//}

function GetAllMarkers() {
    var data = "{}";
    $.ajax({
        url: "../WebControllers/MainControls/OpenLayersMap/MapWS.asmx/GetAllMarkers",
        contentType: "application/json",
        cache: false,
        type: "POST",
        data: data,
        error: function (err) {

        },
        success: function (data) {
            if (data.d != null) {
                RemoveMarker();
                var MarkerStrParse = new Array();
                var LonLatPopUpTextStr = new Array();
                var lon, lat, popupText;
                MarkerStrParse = data.d.toString().split('#');
                for (i = 0; i < MarkerStrParse.length ; i++) {
                    LonLatPopUpTextStr = MarkerStrParse[i].toString().split(',');
                    lon = LonLatPopUpTextStr[0];
                    lat = LonLatPopUpTextStr[1];
                    popupText = LonLatPopUpTextStr[2];
                    AddMarker(lon, lat, '../WebBusManagement/Images/bus_s64.png', 32, 32, popupText);
                }
            }
        }
    });
}

function Send(ActionString, Param) {
    if(ActionString==null)
    {
        ActionString = txtActionString.val();
    }
    var data = "{ActionString:'" + ActionString + "',Param:" + JSON.stringify(Param) + "}";
    $.ajax({
        url: "../WebControllers/MainControls/OpenLayersMap/MapWS.asmx/Send",
        contentType: "application/json",
        cache: false,
        type: "POST",
        data: data,
        error: function (err) {
            alert('Error');
        },
        success: function (data) {
            if (data.d != null) {
                //Txt_Title.val(data.d.Title);
                $(data.d).each(function (index, item) {
                    alert(data);
                });
            }
        }
    });
}

function GetAllMarkers() {
    var data = "{}";
    $.ajax({
        url: "../WebControllers/MainControls/OpenLayersMap/MapWS.asmx/Send",
        contentType: "application/json",
        cache: false,
        type: "POST",
        data: data,
        error: function (err) {
            alert('Error');
        },
        success: function (data) {
            if (data.d != null) {
               
            }
        }
    });
}
