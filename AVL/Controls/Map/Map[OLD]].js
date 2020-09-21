
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


Type.registerNamespace("AVL.Controls.Map");

AVL.Controls.Map.Map = function (element) {
    AVL.Controls.Map.Map.initializeBase(this, [element]);

    // Define properties
    this._zoom = null;
    this._centerLatitude = null;
    this._centerLongitude = null;
    this._markers = null;

    this._mapObj = null;
    this._infoWindow = null;

    this._popupWebService = "";
    this._webServiceUrl = "";
    this._interval = 5000;
   
    this._mArray = [];

    this._lines = null;

    this._showLinesAutomatically = false;
    this._pontsWebservice = "";

    this._polylines = [];

    this._pontRequestIndexer = 0;

    this.layer = null;
    this.pppp = 0;

    this.sInterval;
}

AVL.Controls.Map.Map.prototype = {
    initialize: function () {
        AVL.Controls.Map.Map.callBaseMethod(this, 'initialize');
        //alert("raised");
        // Create the map
        this.createMap();
       // alert(this.get_webServiceUrl() + "-" + this.get_webServiceUrl().toString().length);
        if (this.get_webServiceUrl().toString().length >= 2) {
            var that = this;
            
            clearInterval(this.sInterval);
            this.sInterval = setInterval(
                function () {
                that.AjaxPerformer(that);
            }, this.get_interval());
        }
    },
    dispose: function () {
        //Add custom dispose actions here
        AVL.Controls.Map.Map.callBaseMethod(this, 'dispose');
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
    get_markers: function () {
        return this._markers;
    },
    set_markers: function (value) {
        if (this._markers !== value) {
            this._markers = value;
            
            this.raisePropertyChanged("markers");
        }
    },
    get_lines: function () {
        return this._lines;
    },
    set_lines: function (value) {
        if (this._lines !== value) {
            this._lines = value;
            this.raisePropertyChanged("lines");
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
    get_popupWebService: function () {
        return this._popupWebService;
    },
    set_popupWebService: function (value) {
        if (this._popupWebService !== value) {
            this._popupWebService = value;
            this.raisePropertyChanged("popupWebService");
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
    get_mArray: function () {
        return this._mArray;
    },
    set_mArray: function (value) {
        if (this._mArray !== value) {
            this._mArray = value;
            this.raisePropertyChanged("mArray");
        }
    },
    get_showLinesAutomatically: function () {
        return this._showLinesAutomatically;
    },
    set_showLinesAutomatically: function (value) {
        if (this._showLinesAutomatically !== value) {
            this._showLinesAutomatically = value;
            this.raisePropertyChanged("showLinesAutomatically");
        }
    },
    get_pointsWebservice: function () {
        return this._pointsWebservice;
    },
    set_pointsWebservice: function (value) {
        if (this._pointsWebservice !== value) {
            this._pointsWebservice = value;
            this.raisePropertyChanged("pointsWebservice");
        }
    },
    createMap: function () {
        // Set the center point, zoom, and type of map
        var centerPoint = new google.maps.LatLng(this.get_centerLatitude(), this.get_centerLongitude());
        var options = {
            zoom: this.get_zoom(),
            center: centerPoint,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        // Create the map, using the above options
       window.map= this._mapObj = new google.maps.Map(this._element, options);
        

        //Show Lines
        if (this.get_showLinesAutomatically())
        {
            var that = this;
            var b;
            clearInterval(b);
            b = setInterval(function () { that.DrawLine(that); },that.interval);
        }
        this.ShowLines();

        var arr = this.SetMarkers(this.get_markers());
    },
    SetMarkers: function (mar) {
        //array to store google map markers
        var arr = [];
        // Get the array of markers and iterate through them
        var markers = mar;// this.get_markers();
        if (markers != null) {
            for (var i = 0; i < markers.length; i++) {

                arr.push(new com.redfin.FastMarker(markers[i].UID,
                   new google.maps.LatLng(markers[i].Latitude, markers[i].Longitude),
                   ["<img id='marker" + markers[i].UID + "' src='" + markers[i].IconUrl + "' width='32px' height='32px'  onclick=\"show(this,'" + this.get_popupWebService() + "')\"  style='position:absolute;top:0px;left:0px;' /> "],
                   "myMarker",
                   i,
                   0,
                   0,
                   "<span style='color:red;'>" + markers[i].Title + "</span>",
                   markers[i].IconUrl));
            }

            this.layer = new com.redfin.FastMarkerOverlay(this._mapObj, arr);
            this.set_markers(this.layer._markers);
        }
        arr = null;
        markers = null;

    },
    AddMarker: function (m) {
        // id, latLng, innerHtmlArray, divClassName, zIndex, leftOffset, topOffset
       
        // Create the marker
        var marker = new MarkerWithLabel// new google.maps.Marker//
        (
            {
                position: new google.maps.LatLng(m.Latitude, m.Longitude),
                map: this._mapObj,
                title: m.Title,
                icon: m.IconUrl,
                labelContent: m.Title,
                labelAnchor: new google.maps.Point(10, 20),
                labelClass: "markerWithLabel", // the CSS class for the label
                labelInBackground: false
            }
        ); 
        // Save the current context to the 'that' variable
        var that = this;
        (function (marker, infoHtml, id) {

            // Add an event handler for the click event on the marker
            google.maps.event.addListener(marker, 'click', function () {

                // Check if the info window has been created, and if not create it
                if (!that._infoWindow) {
                    that._infoWindow = new google.maps.InfoWindow();
                }
                if (that.get_popupWebService() === "")
                    // Set the content of the info window
                    that._infoWindow.setContent(infoHtml.toString());
                else {
                    that._infoWindow.setContent(that.PopupUpdate(id).toString());
                }
                // Show the info window
                that._infoWindow.open(that._mapObj, marker);
            });
        })(marker, m.InfoWindowHtml, m.UID);
       
        return marker;
    },
    CleanPolylines:function(){

        var lines=   this._polylines;
        for (var i = 0; i < lines.length; i++) {

            lines[i].setMap(null);
        }
    },
    ShowLine: function (markeruid) {
        this.CleanPolylines();
        var lines = this._lines;
        
        if (lines != null) {
            var lineObj;
            for (var i = 0; i < lines.length; i++) {
                if (lines[i].MarkerUID == markeruid) {
                    lineObj = lines[i];
                    break;
                }
            }
            var points = [];

            for (var j = 0; j < lineObj.Points.length; j++) {
                points.push(new google.maps.LatLng(lineObj.Points[j].Latitude, lineObj.Points[j].Longitude));

            }
            // Create the poluline
            var line = new google.maps.Polyline
            (
                {
                    path: points,
                    geodesic: lines[i].Geodisc,
                    strokeColor: lines[i].Color,
                    strokeOpacity: lines[i].Opacity,
                    strokeWeight: lines[i].Weight
                }
            );
            line.setMap(this._mapObj);
            this._polylines.push(line);
        }
    },
    ShowLines: function () {
        this.CleanPolylines();
        var lines = this._lines;
        //alert(lines.length.toString());
        if (lines != null) {
            for (var i = 0; i < lines.length; i++) {
                var points = [];
                for (var j = 0; j < lines[i].Points.length; j++) {
                    points.push(new google.maps.LatLng(lines[i].Points[j].Latitude, lines[i].Points[j].Longitude));
                   
                }
                // Create the poluline
                var line = new google.maps.Polyline
                (
                    {
                        path: points,
                        geodesic: lines[i].Geodisc,
                        strokeColor: lines[i].Color,
                        strokeOpacity: lines[i].Opacity,
                        strokeWeight: lines[i].Weight
                    }
                );
                line.setMap(this._mapObj);
                this._polylines.push(line);
            }
        }
    },
    PopupUpdate: function (id) {
        var xmlhttp;
        var a, b = "default";
        if (window.XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            a = xmlhttp.responseText.substr();
            b = a.substring(a.indexOf("http://tempuri.org/") + 21, a.indexOf("</string>"));
            while (b.indexOf("&lt;") >= 0 || b.indexOf("&gt;") >= 0) {
                b = b.replace("&lt;", "<");
                b = b.replace("&gt;", ">");
            }
        }
        xmlhttp.open("POST", this.get_popupWebService(), false);
        xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        xmlhttp.send("id=" + id);
        return b;
    },
    DrawLine: function (obj) {
        var xmlhttp;
        if (window.XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                var ReceivedPoints = JSON.parse(xmlhttp.responseText).d;
                // alert(ReceivedPoints);
                var j = 0;
                var lines = obj._lines;
                var points = [];
                for (j= 0; j < ReceivedPoints.length; j++) {
                    points.push(new google.maps.LatLng(ReceivedPoints[j].Latitude, ReceivedPoints[j].Longitude));

                }
                // Create the poluline
                var line = new google.maps.Polyline
                (
                    {
                        path: points,
                        geodesic: lines[0].Geodisc,
                        strokeColor: lines[0].Color,
                        strokeOpacity: lines[0].Opacity,
                        strokeWeight: lines[0].Weight
                    }
                );
                line.setMap(obj._mapObj);
                var mArray = obj.get_mArray();
                //var j = 0;
                for (j = 0; j < mArray.length; j++) {
                    if (mArray[j].ID === lines[0].MarkerUID) {
                        obj.MarkerAnimate(mArray[j], 
                            ReceivedPoints[ReceivedPoints.length - 1].Latitude,
                            ReceivedPoints[ReceivedPoints.length - 1].Longitude,
                            obj.interval);

                    }
                }

            }
        }
       // alert(obj.get_pointsWebservice());
        xmlhttp.open("POST", obj.get_pointsWebservice(), true);
        xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        var lines = obj._lines;
        var s = [];
        s.push(lines[0].MarkerUID);
        //alert(lines[0].MarkerUID.toString());
        s.push(lines[0].StartDate);
        s.push(lines[0].EndDate);
        s.push(obj._pontRequestIndexer);
        obj._pontRequestIndexer += 10;
        s.push(obj._pontRequestIndexer);
        var a = JSON.stringify({ param: s });
        
        xmlhttp.send(a); //JSON.stringify
    },
    MarkerEdit: function (marker, newMarker) {
        if (newMarker.Title) {
            marker.marker.set('labelContent', newMarker.Title);
            marker.marker.set('title', newMarker.Title);
        }
       // alert(newMarker.Icon.toString());
        if (newMarker.Icon)
            marker.marker.set('icon', newMarker.Icon);
    },
    AjaxPerformer: function (obj) {
        var xmlhttp;
        if (window.XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var buses = JSON.parse(xmlhttp.responseText).d;
                var elementPos = -1;
                var markers = [];
                
                var latlng;
                var mar;
                if (buses == null)
                    buses = [];
               for (i = 0; i < buses.length; i++) {
                   latlng=new google.maps.LatLng(buses[i].Location.X, buses[i].Location.Y);
                   if (obj._mapObj.getBounds().contains(latlng)) {
                       if (obj.layer != null) {
                           elementPos = obj.layer._markers.map(function (x) { return x._id; }).indexOf(buses[i].ID);
                       }
                       if (elementPos == -1) {
                           mar = new com.redfin.FastMarker(buses[i].ID,
                              latlng,
                              ["<img id='marker" + buses[i].ID + "' src='" + buses[i].Icon + "' width='32px' height='32px'  onclick=\"show(this,'" + obj.get_popupWebService() + "')\"  style='position:absolute;top:0px;left:0px;' /> "],
                              "myMarker",
                              i,
                              0,
                              0,
                              "<span style='color:red;'>" + buses[i].Title + "</span>",
                              buses[i].Icon);
                       }
                       else {
                           if (obj.layer != null) {
                               mar = obj.layer._markers[elementPos];
                             //   mar._latLng = latlng;
                               obj.layer.move(elementPos,latlng);
                               mar._iconPath = buses[i].Icon;
                               mar._label = buses[i].Title;
                           }
                       }
                       markers.push(mar);
                   }
               }
               //obj.launchPiWebWorker(markers,this);
               if (obj.layer != null) {
                   //  obj.layer.setMap(null);
                   
                }
                else {

               }
               if (obj.layer != null) {
                   obj.layer.removeUnused(markers);
                   obj.set_markers(obj.layer._markers);
                   obj.layer._markers = markers;
                 obj.layer.draw();
               }
               else {
                   obj.layer = new com.redfin.FastMarkerOverlay(obj._mapObj, markers);
                   obj.set_markers(obj.layer._markers);
               }
               mar = null;
                ss = null;
                markers = null;
                elementPos = null;
                latlng=null;
                buses = null;               
            }
        }
        xmlhttp.open("POST", this.get_webServiceUrl(), true);
       xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        // xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        
       var a = this._mapObj.getBounds().toString();

     //  alert(JSON.stringify(a));
       a = JSON.stringify({bounds:a});
        xmlhttp.send(a); //JSON.stringify
    },
    //latitude and longitude are destination coordinates
    MarkerAnimate: function (marker, latitude, longitude, interval) {
        var fPosition = marker.marker.getPosition();
        
        var nlat=0, nlng=0;
            var i = interval / 10;
            var u = setInterval(function () {
                if (i <= 0)
                    clearInterval(u);
            }, 10);
    },
    launchPiWebWorker: function (markers) {       
        var worker = new Worker('mi.js');
        this.pppp = 1;
        worker.postMessage({ markers:markers});
        worker.onmessage = function (e) {
            console.log("RETURNED : " + e.data);
            var m = [];
            for (var i = 0; i < e.data.length; i++) {
                m.push(e.data[i]);
            }
            //this.pppp += 2;
            this.layer = new com.redfin.FastMarkerOverlay(this._mapObj, m);
            console.log(this.pppp.toString() + "aaaa    " + this.layer._markers.length.toString());
        //.set_markers(m);
            m = null;
            
            
            worker.terminate();
          //  self.close();
        };

        worker.onerror = function (e) {
            console.log("ERROR OCCOURED : "+e.data );
        };
    }
}
AVL.Controls.Map.Map.registerClass('AVL.Controls.Map.Map', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
