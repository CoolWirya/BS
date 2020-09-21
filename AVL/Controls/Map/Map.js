
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
    this._getDetailsInterval = 3000;

    this._mArray = [];

    this._lines = null;

    this._showLinesAutomatically = false;
    this._specifiedArea = false;
    this._pontsWebservice = "";

    this._polylines = [];

    this._pontRequestIndexer = 0;

    this.layer = null;
    this.pppp = 0;

    this.sInterval;
    //list of intervals numbers
    this.intervals = [];
    this.setsintervals = [];
    this.ItemsList = [];
    this.intervalsList = [];
    this.markersList = [];
    this.offlineLine = null;
    this.listOfIdsInarea;
    //Get details measure stuffs
    this.sumDetailsRequestTime = 0;
    this.startTime = null;
}

AVL.Controls.Map.Map.prototype = {
    initialize: function () {
        AVL.Controls.Map.Map.callBaseMethod(this, 'initialize');
        //alert("raised");
        // Create the map
        this.createMap();
        //set requestanimate
        window.requestAnimFrame = (function (callback) {
            return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
        })();
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
    get_getDetailsInterval: function () {
        return this._getDetailsInterval;
},
    set_getDetailsInterval: function (value) {
        if (this._getDetailsInterval !== value) {
            this._int_getDetailsIntervalerval = value;
            this.raisePropertyChanged("getDetailsInterval");
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
    get_specifiedArea: function () {
        return this._specifiedArea;
    },
    set_specifiedArea: function (value) {
        if (this._specifiedArea !== value) {
            this._specifiedArea = value;
            this.raisePropertyChanged("specifiedArea");
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
        window.map = this._mapObj = new google.maps.Map(this._element.parentNode, options);


        //Show Lines
        if (this.get_showLinesAutomatically()) {
            var that = this;
            var b;
            clearInterval(b);
            b = setInterval(function () {
                that.DrawLine(that);
            }, that._interval);
        }
        this.ShowLines();

        var arr = this.SetMarkers(this.get_markers());
        
        (function (obj) {
            google.maps.event.addListener(map, 'bounds_changed', function () {
               
                for (var i = 0; i < obj.layer._markers.length; i++) {                
                    obj.layer.move(obj.layer._markers[i]._id, obj.layer._markers[i]._latLng, 10);
                }
            })
        })(this);
        // Run a lifetime ajax request to get Ids
        (function (x) {
            google.maps.event.addListenerOnce(map, 'idle', function () {
                // do something only the first time the map is loaded
                if (x.get_webServiceUrl().toString().length >= 2) {
                    var that = x;
                    setTimeout(
                       function () {
                           that.AjaxPerformer(that);
                       }, 10);
                }
                //fit bounds to see all markers
                var markers = x.layer._markers; //some array;
                if (markers.length > 0) {
                    var bounds = new google.maps.LatLngBounds();
                    for (i = 0; i < markers.length; i++) {
                        bounds.extend(markers[i].getPosition());
                    }
                    map.fitBounds(bounds);
                }
            });
        })(this);
    },
    SetMarkers: function (mar) {

        var arr = [];
        var markers = mar;// this.get_markers();
        var i;
        if (markers != null) {
            for (i = 0; i < markers.length; i++) {
                this.ItemsList.push(markers[i].UID.toString());
                arr.push(this.AddMarker(markers[i]));
            }

            this.set_markers(arr);//this.layer._markers);
         ////   if (!this.get_showLinesAutomatically()) {
         //       var that = this;
         //       for (i = 0; i < markers.length; i++) {
         //          (function (marker,t) {
         //              setTimeout(function () {
         //                  that.intervals.push(marker.UID.toString());
         //                 // that.layer.move(marker.UID,)
         //                  //Call after getting data from server                           
         //                 // that.animate(marker, 0, 0, 1, marker.UID, t, true);
         //              }, that._interval);
         //          })(markers[i],that);
         //       }
         //   //}
        }
        if (this.layer == null) {
            this.layer = new com.redfin.FastMarkerOverlay(this._mapObj, arr.map(function (x) { return x.mark; }));
        }
        arr = null;
        markers = null;

    },
    AddMarker: function (m) {
        //m is a AVL.Controls.Map.Marker object
         // id, latLng, innerHtmlArray, divClassName, zIndex, leftOffset, topOffset
        var marker=   new com.redfin.FastMarker(m.UID,
                      new google.maps.LatLng(m.Latitude, m.Longitude),
                      ["<img id='marker" + m.UID + "' src='" + m.IconUrl + "' width='64px' height='64px'  onclick=\"show(this,'" + this.get_popupWebService() + "')\"  style='position:absolute;top:0px;left:0px;' /> "],
                      "myMarker",
                      i,
                      -32,
                      -64,
                     "<span id='markerSpan"+m.UID+"' style='color:red;z-index:10;'>" + m.Title + "</span>",
                      m.IconUrl);
        m.mark = marker;
        return m;

    },
    CleanPolylines: function () {

        var lines = this._polylines;
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
            if (b != null && b != "") {
                console.log(b);
            }
            return b.toString();
        }
        xmlhttp.open("POST", this.get_popupWebService(), true);
        xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        xmlhttp.send("id=" + id);
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
                if (ReceivedPoints == null || ReceivedPoints.length == 0)
                    return;
                // alert(ReceivedPoints);
                var j = 0;
                var lines = obj._lines;
                var points = [];

                for (j = 0; j < ReceivedPoints.length; j++) {
                    points.push(new google.maps.LatLng(ReceivedPoints[j].Location.X, ReceivedPoints[j].Location.Y));
                    var MarkerTemp = {
                        Title: ReceivedPoints[j].Title,
                        IconUrl: ReceivedPoints[j].Icon,
                        UID: ReceivedPoints[j].ID,
                        Latitude: ReceivedPoints[j].Location.X,
                        Longitude: ReceivedPoints[j].Location.Y
                    };
                    MarkerTemp = obj.AddMarker(MarkerTemp);
                    obj.markersList.push(MarkerTemp);
                }
                console.log(obj.layer._markers.length.toString());
                obj.layer._markers = obj.markersList.map(function (x) { return x.mark; });
                obj.layer.draw();
                var iconsetngs = {
                    path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW
                };
                    // Create the poluline
                if (obj.offlineLine == null) {
                    obj.offlineLine = new google.maps.Polyline
                        (
                            {
                                //path: points,
                                geodesic: lines[0].Geodisc,
                                strokeColor: lines[0].Color,
                                strokeOpacity: lines[0].Opacity,
                                strokeWeight: lines[0].Weight,
                                icons: [{
                                    repeat: '70px', //CHANGE THIS VALUE TO CHANGE THE DISTANCE BETWEEN ARROWS
                                    icon: iconsetngs,
                                    offset: '100%'
                                }]
                            }
                        );

                    obj.offlineLine.setMap(obj._mapObj);
                }
                var mArray = obj.get_markers();
                var intervalNUMB;
                if (points[0]) {
                    (function (x, y, z,a,path) {
                        var i = 0;
                        var c = setInterval(function () {
                            if (i < a) {
                                path.push(y[i]);
                                obj.layer.move(x, y[i], z);
                                i++;
                            }
                            else {
                                clearInterval(c);
                                i = null;
                            }
                        }, z);
                    })(mArray[mArray.map(function (x) { return x.UID; }).indexOf(lines[0].MarkerUID)].UID, points, obj._interval / points.length, points.length,obj.offlineLine.getPath());
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
    getAllDetails: function (interval,obj) {
        var xmlhttp2;
        if (XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp2 = new XMLHttpRequest();

        }
        else {// code for IE6, IE5
            xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                points = JSON.parse(xmlhttp2.responseText).d;
                if (points == null)
                    points = [];
                //obj.sumDetailsRequestTime=(new Date().getTime() - obj.startTime);
                var i;
                for (i = 0; i < points.length; i++) {

                    if (obj.markersList.map(function (x) { return x.UID.toString(); }).indexOf(points[i].ID.toString()) < 0) {
                        var MarkerTemp = {
                            Title: points[i].Title,
                            IconUrl: points[i].Icon,
                            UID: points[i].ID,
                            Latitude: points[i].Location.Y,
                            Longitude: points[i].Location.X
                        };
                        MarkerTemp = obj.AddMarker(MarkerTemp);
                        obj.markersList.push(MarkerTemp);
                        MarkerTemp = null;
                    }
                    else {

                        var l;
                        l = new google.maps.LatLng(parseFloat(points[i].Location.Y), parseFloat(points[i].Location.X));
                        (function (x, v) {
                          //  setTimeout(function () {
                            obj.layer.move(x, v, interval /*+ obj.sumDetailsRequestTime*/);
                            //}, 0);
                        })(points[i].ID, l);
                    }
                }
                xmlhttp2 = null;
                i = null;
                points = null;
                l = null;
                setTimeout(function () {
                    obj.getAllDetails(interval,obj);
                }, interval );
            }
        }
        
        if (!obj._specifiedArea) {
            var a = JSON.stringify({ 'bounds': obj._mapObj.getBounds().toString(), 'id': 1 });
        }
        else {
            var a = JSON.stringify({ 'bounds': obj._mapObj.getBounds().toString(), 'id': obj.listOfIdsInarea });
        }
        xmlhttp2.open("POST",obj.get_webServiceUrl(), true);
        xmlhttp2.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        // xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp2.send(a); //JSON.stringify  
        obj.startTime = new Date().getTime();
        a = null;
    },
    IdsManager: function (buses,obj) {
        var i;
        if (obj.layer == null) {
            obj.layer = new com.redfin.FastMarkerOverlay(obj._mapObj, []);
        }
        for (i = 0; i < buses.length; i++) {
            if (obj.ItemsList.indexOf(buses[i]) < 0) {
                obj.ItemsList.push(buses[i]);
            }
        }
        if (obj.intervalsList.length == 0) {
            obj.intervalsList.push(setTimeout(function () {
                obj.getAllDetails(obj._getDetailsInterval,obj);
            }, 0));
        }
        //REMOVE items that didnt recieve last time from server, it shouldnt be exist anymore.    
        var itemListTemp = [];
        
        for (i = 0; i < obj.ItemsList.length; i++) {
            if (buses.indexOf(obj.ItemsList[i]) < 0) {
                obj.layer.removeUnused(obj.ItemsList[i]);
            }
            else {
                itemListTemp.push(obj.ItemsList[i]);
            }
        }
        
        obj.ItemsList = itemListTemp;
        var mlist = [];
        for (i = 0; i < obj.markersList.length; i++) {
            for (var j = 0; j < buses.length; j++) {
                if (obj.markersList[i].UID == buses[j]) {
                    mlist.push(obj.markersList[i]);
                }

            }
        }
        obj.markersList = mlist;
        if (obj.layer == null) {
            obj.layer = new com.redfin.FastMarkerOverlay(obj._mapObj, []);
        }
        else {
            obj.layer._markers = obj.markersList.map(function (x) { return x.mark; });
            obj.layer.draw();
        }
        itemListTemp = null;
        i = null;
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
                //get list of new objects IDs.
                var buses = JSON.parse(xmlhttp.responseText).d;
                obj.IdsManager(buses,obj);
                buses = null;
                xmlhttp = null;
                setTimeout(function () {
                    obj.AjaxPerformer(obj);
                }, obj._interval);
            }
        }
        xmlhttp.open("POST", obj.get_webServiceUrl(), true);
        xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        // xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

        var a = obj._mapObj.getBounds().toString();

        //  alert(JSON.stringify(a));
        a = JSON.stringify({ bounds: a, id: -1 });
        if (!obj._specifiedArea) {
            xmlhttp.send(a); //JSON.stringify
        }
        else {
            var idss = [];
            var mmsm = "";
            for(var i=0;i<obj._markers.length;i++){
                idss.push(obj._markers[i].UID.toString());
                mmsm += obj._markers[i].UID + ",";
            }
            console.log(idss.toString());
            obj.listOfIdsInarea = mmsm;
            obj.IdsManager(idss, obj);
            mmsm = "";
            idss = [];
        }
        a = null;
    },
    //latitude and longitude are destination coordinates
    MarkerAnimate: function (marker, latitude, longitude, interval,counter,that) {
        
        var Y = latitude - marker.Latitude;
        var X = longitude - marker.Longitude;

        var LatLng = new google.maps.LatLng(
            marker.Latitude + ((Y / 16) * counter),
            marker.Longitude + ((X / 16) * counter));
        marker.mark.setPosition(LatLng);
        marker.Latitude = LatLng.lat();
        marker.Longitude = LatLng.lng();
        
        if (counter <= (16)) {

          setTimeout(// window.requestAnimationFrame(
                 function () {
                     that.MarkerAnimate(marker, latitude, longitude, interval, counter + 1,that);
                 }
                 , interval / 16
             );
        }
    },
   
    animate: function (object, Lastlatitude, Lastlongitude, counter, id, that, IsAjax) {
        var MarkerTemp = object;
        var a = JSON.stringify({ bounds: that._mapObj.getBounds().toString(), id: id.toString() });
     //   console.log(a);
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
                // console.log(xmlhttp.responseText);
                var point = (JSON.parse(xmlhttp.responseText).d)[0];

                //If id is not exist Create a marker with arrived data from server
                //Get data from server
                if (object == null) {
                    MarkerTemp = {
                        Title: point.Title,
                        IconUrl: point.Icon,
                        UID: point.ID,
                        Latitude: point.Location.Y,
                        Longitude: point.Location.X
                    };
                    MarkerTemp = that.AddMarker(MarkerTemp);
                    that._markers.push(MarkerTemp);
                setTimeout(//    window.requestAnimationFrame(
                    function () {
                        that.animate(MarkerTemp, Lastlatitude, Lastlongitude, (counter + 1), id, that, true);
                    }
                    ,0
                    );
                }
                else {

                //    Lastlatitude = point.Location.Y;
                    //    Lastlongitude = point.Location.X;
                    MarkerTemp.mark.setIcon(point.Icon);
                    setTimeout(//    window.requestAnimationFrame(
                        function () {
                        that.animate(MarkerTemp, point.Location.Y, point.Location.X, (counter + 1), id, that, false);
                        }
                    , 0
                    );
                }
            }
        }
        if (IsAjax) {
            xmlhttp.open("POST", that.get_webServiceUrl(), true);
            xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            // xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlhttp.send(a); //JSON.stringify   
        }
        else {
            if (counter < 16) {
                if (Lastlatitude == MarkerTemp.Latitude && Lastlongitude == MarkerTemp.Longitude) {
                    setTimeout(//  window.requestAnimationFrame(
                        function () {
                        that.animate(MarkerTemp, Lastlatitude, Lastlongitude, 1, id, that, true);
                        }
                    , 0
                    );
                }
                else {
                    //var that = this;
                    setTimeout(//  window.requestAnimationFrame(
                        function () {
                        var Y = Lastlatitude - MarkerTemp.Latitude;
                        var X = Lastlongitude - MarkerTemp.Longitude;
                        
                        var LatLng = new google.maps.LatLng(
                            MarkerTemp.Latitude + ((Y / 16) * counter),
                            MarkerTemp.Longitude + ((X / 16) * counter));
                        MarkerTemp.mark.setPosition(LatLng);
                        that.animate(MarkerTemp, Lastlatitude, Lastlongitude, (counter + 1), id, that, false);
                        }
                    , 0
                    );
                }
            }
            else {
                //   console.log("id old : " + id + " --- location : " + MarkerTemp.Latitude + "," + MarkerTemp.Longitude);
                MarkerTemp.Latitude = MarkerTemp.mark.getPosition().lat();
                MarkerTemp.Longitude = MarkerTemp.mark.getPosition().lng();
                //  console.log("id : " + id + " --- location : " + MarkerTemp.mark.getPosition().toString());
                var markerTempindex = that._markers.map(function (x) { return x.UID.toString(); }).indexOf(id.toString());
                if (markerTempindex != -1) {
                    setTimeout(//    window.requestAnimationFrame(
                        function () {
                        that.animate(MarkerTemp, Lastlatitude, Lastlongitude, 1, id, that, true);
                        }
                    , 0
                    );
                }
            }
        }
    },
    ajaxRunJSON: function (webservice, params) {
    },
    launchPiWebWorker: function (markers) {
        var worker = new Worker('mi.js');
        this.pppp = 1;
        worker.postMessage({ markers: markers });
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
            console.log("ERROR OCCOURED : " + e.data);
        };
    }
}
AVL.Controls.Map.Map.registerClass('AVL.Controls.Map.Map', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

