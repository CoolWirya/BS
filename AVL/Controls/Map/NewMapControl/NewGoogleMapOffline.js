

Type.registerNamespace("AVL.Controls.Map.NewMapControl");

AVL.Controls.Map.NewMapControl.NewGoogleMap = function (element) {
    AVL.Controls.Map.NewMapControl.NewGoogleMap.initializeBase(this, [element]);
    
    // Define properties
    this._zoom = null;
    this._centerLatitude = null;
    this._centerLongitude = null;
    this._mapObj = null;
    this._webServiceUrl = "";
    this._interval = 5000;
    this._popupWebService = "";
    this._GCommunicationObjects = [];
    this._Markers = [];
    this._offline = false;
    this._devicecode = 0;
    this._startdate = "";
    this._enddate = "";
    this._speed = 1000;
    this._lastrow = 0;
    this._lastrowsend = -1;
    this._firstPosition = 0;
    this._lastMarker = null;
    this._offlineMapAnimated = true;
    this._deviceCodes = [];
    this._lineColors = [];
    this.qwe = null;
}


AVL.Controls.Map.NewMapControl.NewGoogleMap.prototype = {
    initialize: function () {
        AVL.Controls.Map.NewMapControl.NewGoogleMap.callBaseMethod(this, 'initialize');
        console.log("from offline");
        // Create the map
        this.CreateMap();
    },
    dispose: function () {
        //Add custom dispose actions here
        AVL.Controls.Map.NewMapControl.NewGoogleMap.callBaseMethod(this, 'dispose');
    },
    get_offline: function () {
        return this._offline;
    },
    set_offline: function (value) {
        if (this._offline !== value) {
            this._offline = value;
            this.raisePropertyChanged("offline");
        }
    },
    get_offlineMapAnimated: function () {
        return this._offlineMapAnimated;
    },
    set_offlineMapAnimated: function (value) {
        if (this._offlineMapAnimated !== value) {
            this._offlineMapAnimated = value;
            this.raisePropertyChanged("offlineMapAnimated");
        }
    },
    get_lastrow: function () {
        return this._lastrow;
    },
    set_lastrow: function (value) {
        if (this._lastrow !== value) {
            this._lastrow = value;
            this.raisePropertyChanged("lastrow");
        }
    },
    get_lastrowsend: function () {
        return this._lastrowsend;
    },
    set_lastrowsend: function (value) {
        if (this._lastrowsend !== value) {
            this._lastrowsend = value;
            this.raisePropertyChanged("lastrowsend");
        }
    },
    get_devicecode: function () {
        return this._devicecode;
    },
    set_devicecode: function (value) {
        if (this._devicecode !== value) {
            this._devicecode = value;
            this.raisePropertyChanged("devicecode");
        }
    },
    get_deviceCodes: function () {
        return this._deviceCodes;
    },
    set_deviceCodes: function (value) {
        if (this._deviceCodes !== value) {
            this._deviceCodes = value;
            this.raisePropertyChanged("deviceCodes");
        }
    },
    get_startdate: function () {
        return this._startdate;
    },
    set_startdate: function (value) {
        if (this._startdate !== value) {
            this._startdate = value;
            this.raisePropertyChanged("startdate");
        }
    },
    get_enddate: function () {
        return this._enddate;
    },
    set_enddate: function (value) {
        if (this._enddate !== value) {
            this._enddate = value;
            this.raisePropertyChanged("enddate");
        }
    },
    get_speed: function () {
        return this._speed;
    },
    set_speed: function (value) {
        if (this._speed !== value) {
            this._speed = value;
            this.raisePropertyChanged("speed");
        }
    },
    get_lineColors: function () {
        return this._lineColors;
    },
    set_lineColors: function (value) {
        if (this._lineColors !== value) {
            this._lineColors = value;
            this.raisePropertyChanged("lineColors");
        }
    },
    get_centerLatitude: function () {
        return this._centerLatitude;
    },
    set_centerLatitude: function (value) {
        if (this._centerLatitude !== value) {
            this._centerLatitude = value;
            this.raisePropertyChanged("centerLatitude");
        }
    },
    get_centerLongitude: function () {
        return this._centerLongitude;
    },
    set_centerLongitude: function (value) {
        if (this._centerLongitude !== value) {
            this._centerLongitude = value;
            this.raisePropertyChanged("centerLongitude");
        }
    },
    get_zoom: function () {
        return this._zoom;
    },
    set_zoom: function (value) {
        if (this._zoom !== value) {
            this._zoom = value;
            this.raisePropertyChanged("zoom");
        }
    },
    get_webServiceUrl: function () {
        return this._webServiceUrl;
    },
    set_webServiceUrl: function (value) {
        if (this._webServiceUrl !== value) {
            this._webServiceUrl = value;
            this.raisePropertyChanged("webServiceUrl");
        }
    },
    get_interval: function () {
        return this._interval;
    },
    set_interval: function (value) {
        if (this._interval !== value) {
            this._interval = value;
            this.raisePropertyChanged("interval");
        }
    },
    get_popupWebService: function () {
        return this._popupWebService;
    },
    set_popupWebService: function (value) {
        if (this._popupWebService !== value) {
            this._popupWebService = value;
            this.raisePropertyChanged("popupWebService");
        }
    },
    CreateMap: function () {
        // Set the center point, zoom, and type of map
        var centerPoint = new google.maps.LatLng(this.get_centerLatitude(), this.get_centerLongitude());
        var options = {
            zoom: this.get_zoom(),
            center: centerPoint,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        // Create the map, using the above options
        var map = this._mapObj = new google.maps.Map(this._element.parentNode, options);
        console.log("initialize google offfline map");
        google.maps.event.addListener(map, 'bounds_changed', function () {
            //
        });
        google.maps.event.addListener(map, 'zoom_changed', function () {
            //
        });
        this.qwe = new google.maps.LatLngBounds();
        //get just one device direction - deviceCode should have more than 0
        if (this.get_devicecode() > 0)
            (function (obj) { setInterval(function () { obj.GetMarkers(obj._GCommunicationObjects, obj._mapObj, obj); }, obj.get_interval()) })(this);
        this._devicesObj = [];
        //Get more than one device direction, deviceCodes should not be null or have item.
        if (this.get_deviceCodes() != null && this.get_deviceCodes().length > 0)
            for (c in this.get_deviceCodes()) {
                this._devicesObj.push({ code: this.get_deviceCodes()[c], lastrow: 0, lastrowsend: -1,lineColor: this.get_lineColors()[c] });
                (function (obj, c) { setInterval(function () { obj.GetMultipleDeviceMarkers(obj._GCommunicationObjects, obj._mapObj, obj, c); }, obj.get_interval()) })(this, c);
            }
       
        (function (obj) { setInterval(function () { obj.CreateMarker(obj._mapObj); }, obj.get_speed()) })(this);
    },
    GetMarkers: function (gcommObjects, map, that) {
        if (this.get_offline() == false || this.get_devicecode() == 0) {
            that.DeleteAllMarker();
            return;
        }

        if (this.get_lastrow() == this.get_lastrowsend())
        {
            return;
        }

        var json = JSON.stringify({ 'devicecode': this.get_devicecode(), 'startdate': this.get_startdate(), 'enddate': this.get_enddate(), 'lastrow': this.get_lastrow() });
        var xmlhttp2 = this.AjaxRequest(this.get_webServiceUrl(), json);

        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                var res = xmlhttp2.responseText;
                var array = JSON.parse(res).d;
                var i;
                var AutoZoom = false;
                for (i = 0; i < array.length; i++) {
                    if (array[i].row > that.get_lastrow())
                        that.set_lastrow(array[i].row);
                    array[i].color ="#FF0000";
                    that._GCommunicationObjects.unshift(array[i]);
                }
            }
        }
        xmlhttp2.send(json);
        this.set_lastrowsend(this.get_lastrow());
    },
    GetMultipleDeviceMarkers: function (gcommObjects, map, that,c) {
        if (this.get_offline() == false || this.get_deviceCodes() == null &&  this.get_deviceCodes().length == 0) {
            that.DeleteAllMarker();
            return;
        }
        var device = that._devicesObj[c];
        if (device.lastrow == device.lastrowsend) {
            return;
        }

        var json = JSON.stringify({ 'devicecode': device.code, 'startdate': this.get_startdate(), 'enddate': this.get_enddate(), 'lastrow': device.lastrow });
        var xmlhttp2 = this.AjaxRequest(this.get_webServiceUrl(), json);

        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                var res = xmlhttp2.responseText;
                var array = JSON.parse(res).d;
                var i;
                var AutoZoom = false;
                for (i = 0; i < array.length; i++) {
                    if (array[i].row > device.lastrow)
                        device.lastrow = (array[i].row);
                    array[i].color = device.lineColor;
                    that._GCommunicationObjects.unshift(array[i]);
                }
            }
        }
        xmlhttp2.send(json);
        device.lastrowsend = (device.lastrow);
    },
    MoveMarker:function(Marker,DestLat,DestLan){
        var frames = [];
        var fromLat = Marker.getPosition().lat();
        var fromLng = Marker.getPosition().lng();
        var toLat = DestLat;
        var toLng=DestLan;
        var curLat, curLng;
        var percent;
        for (percent = 0; percent < 1; percent += 0.01) {
            curLat = fromLat + percent * (toLat - fromLat);
            curLng = fromLng + percent * (toLng - fromLng);
            frames.push(new google.maps.LatLng(curLat, curLng));
        }
       (function (that) { setTimeout(function () { that.AnimateMarker(Marker, 0, frames,that); }, 50) })(this);
    },
    AnimateMarker: function (Marker, index, frames,that) {       
        Marker.setPosition(frames[index]);
        index++;
        if (index < frames.length)
            (function (t) { setTimeout(function () { t.AnimateMarker(Marker, index, frames,t); }, 50); })(that);
    },
    DeleteMarker: function (i) {
        this._Markers[i].setMap(null);
        this._Markers.splice(i, 1);
        this._GCommunicationObjects.splice(i, 1);
    },
    DeleteAllMarker: function (i) {
        //alert('DeleteAllMarker'+this._Markers.length);
        while (this._Markers.length > 0) {
            this._Markers.pop().setMap(null);
        }
        //alert(this._GCommunicationObjects.length);
        while (this._GCommunicationObjects.length > 0) {
            this._GCommunicationObjects.pop();
        }
    },
    CreateMarker: function (map) {
        if (typeof  this._GCommunicationObjects == null || this._GCommunicationObjects.length == 0)
            return;
        
        gCommunicationObject = this._GCommunicationObjects.pop();

        if (this._lastMarker !== null && typeof this._lastMarker !== 'undefined') {
            //var markerImage = new google.maps.MarkerImage("/WebAVL/Icons/last_location.png",
            //        new google.maps.Size(20, 20),
            //        new google.maps.Point(0, 0),
            //        new google.maps.Point(10, 10),
            //        new google.maps.Size(20, 20));
            //this._lastMarker.setIcon(markerImage);
        }

        var markerImage = new google.maps.MarkerImage(gCommunicationObject.Icon,
                new google.maps.Size(40, 40),
                new google.maps.Point(0, 0),
                new google.maps.Point(20, 20),
                new google.maps.Size(40, 40)
            );

        var marker = new google.maps.Marker({
           position: new google.maps.LatLng(gCommunicationObject.Location.X, gCommunicationObject.Location.Y),
           map: map,
           icon: markerImage
        });

        if (this._lastMarker !== null && typeof this._lastMarker !== 'undefined'
            && this.getDistance(this._lastMarker.getPosition(), marker.getPosition()) < 100 ) {

            var line = new google.maps.Polyline({
                path: [
                    this._lastMarker.getPosition(),
                    marker.getPosition()
                ],
                strokeColor:gCommunicationObject.color,// "#FF0000",
                strokeOpacity: 1.0,
                strokeWeight: 2,
                icons: [{
                    icon: {path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW},
                    offset: '50%'
                }],
                map: map
            });

        }

        this._lastMarker = marker;

        if (this._firstPosition == 0 ) {
            this._firstPosition = 1;
            var qwe = new google.maps.LatLngBounds();
           qwe.extend(marker.position);
            map.fitBounds(qwe);
            map.setZoom(map.getZoom() - 3);
        }
        else {
            if (this.get_offlineMapAnimated())
                map.panTo(marker.position);
            else {

                //this.qwe.extend(marker.position);
                //map.fitBounds(this.qwe);
                //map.zoom = map.getZoom() - 1;
            }
        }


        (function (that, gCommunicationObject) {
           google.maps.event.addListener(marker, 'click', function () {
               var json = JSON.stringify({ 'id': gCommunicationObject.ID, 'groupIDs': gCommunicationObject.GroupIDs, 'offline':true });
               var xmlhttp2 = that.AjaxRequest(that.get_popupWebService(), json);
               xmlhttp2.onreadystatechange = function () {
                   if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                       var res = xmlhttp2.responseText;
                       var infowindow = new google.maps.InfoWindow({
                           content: JSON.parse(res).d
                       });
                       infowindow.open(map, marker);
                   }
               }
               xmlhttp2.send(json);
           });
       })(this,gCommunicationObject);
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
    },
    rad: function (x) {
        return x * Math.PI / 180;
    },
    getDistance: function (p1, p2) {
        var that = this;
        var R = 6378137; // Earth’s mean radius in meter
        var dLat = that.rad(p2.lat() - p1.lat());
        var dLong = that.rad(p2.lng() - p1.lng());
        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(that.rad(p1.lat())) * Math.cos(that.rad(p2.lat())) *
          Math.sin(dLong / 2) * Math.sin(dLong / 2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;
        return d; // returns the distance in meter
    },

}
AVL.Controls.Map.NewMapControl.NewGoogleMap.registerClass('AVL.Controls.Map.NewMapControl.NewGoogleMap', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();