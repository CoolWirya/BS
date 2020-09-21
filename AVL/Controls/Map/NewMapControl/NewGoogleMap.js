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
    this._layers = [];
    this._popupWebService = "";
    this._GCommunicationObjects = [];
    this._AutoZooms = [];
    this._Markers = [];
    this._inLoop = 0;
    this._AnimateIcon = "";
    this._ImageSize = "42";
    this._firstPosition = 0;
    this._GetData = true;
    this._GetPop = true;
    this._offlineMapAnimated = true;
    this._deviceCodes = [];
    this._lineColors = [];
}


AVL.Controls.Map.NewMapControl.NewGoogleMap.prototype = {
    initialize: function () {
        AVL.Controls.Map.NewMapControl.NewGoogleMap.callBaseMethod(this, 'initialize');

        // Create the map
        this.CreateMap();
    },
    dispose: function () {
        //Add custom dispose actions here
        AVL.Controls.Map.NewMapControl.NewGoogleMap.callBaseMethod(this, 'dispose');
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
    get_deviceCodes: function () {
        return this._deviceCodes;
    },
    set_deviceCodes: function (value) {
        if (this._deviceCodes !== value) {
            this._deviceCodes = value;
            this.raisePropertyChanged("deviceCodes");
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
    get_layers: function () {
        return this._layers;
    },
    set_layers: function (value) {
        if (this._layers !== JSON.parse(value)) {
            this._layers = JSON.parse(value);
            this.raisePropertyChanged("layers");
        }
    },
    get_AnimateIcon: function () {
        return this._AnimateIcon;
    },
    set_AnimateIcon: function (value) {
        if (this._AnimateIcon !== value) {
            this._AnimateIcon = value;
            this.raisePropertyChanged("popupWebService");
        }
    },
    get_ImageSize: function () {
        return this._ImageSize;
    },
    set_ImageSize: function (value) {
        if (this._ImageSize !== value) {
            this._ImageSize = value;
            this.raisePropertyChanged("popupWebService");
        }
    },
    CreateMap: function () {



        var point = { lat: 22.5667, lng: 88.3667 };
        var markerSize = { x: 22, y: 40 };

        google.maps.Marker.prototype.setLabel = function (label) {
            this.label = new MarkerLabel({
                map: this.map,
                marker: this,
                text: label
            });
            this.label.bindTo('position', this, 'position');
        };
        var MarkerLabel = function (options) {
            this.setValues(options);
            this.span = document.createElement('span');
            this.span.className = 'map-marker-label';
        };

        MarkerLabel.prototype = $.extend(new google.maps.OverlayView(), {
            onAdd: function () {
                this.getPanes().overlayImage.appendChild(this.span);
                var self = this;
                this.listeners = [
                google.maps.event.addListener(this, 'position_changed', function () { self.draw(); })];
            },
            draw: function () {
                var text = String(this.get('text'));
                var position = this.getProjection().fromLatLngToDivPixel(this.get('position'));
                this.span.innerHTML = text;
                this.span.style.left = (position.x - (markerSize.x / 2)) - (text.length * 3) + 10 + 'px';
                this.span.style.top = (position.y - markerSize.y + 40) + 'px';
            }
        });

        // Set the center point, zoom, and type of map
        var centerPoint = new google.maps.LatLng(this.get_centerLatitude(), this.get_centerLongitude());
        var options = {
            zoom: this.get_zoom(),
            center: centerPoint,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        // Create the map, using the above options
        var map = this._mapObj = new google.maps.Map(this._element.parentNode, options);

        google.maps.event.addListener(map, 'bounds_changed', function () {
            //
        });
        google.maps.event.addListener(map, 'zoom_changed', function () {
            //
        });



        var controlDiv = document.createElement('div');

        //var myControl = new MyControl(controlDiv, this);
        this.MyControl(controlDiv, this);
        controlDiv.index = 1;
        map.controls[google.maps.ControlPosition.TOP_RIGHT].push(controlDiv);

        console.log("interval");
        (function (obj) { setInterval(function () { obj.GetMarkers(obj._GCommunicationObjects, obj._mapObj, obj); }, obj.get_interval()) })(this);
        (function (obj) { setInterval(function () { obj.MarkersPOP(obj._mapObj); }, 1000) })(this);
    },
    GetMarkers: function (gcommObjects, map, that) {
        if (!that._GetData)
            return;
        var bounds = map.getBounds().toString();
        var zoom = map.getZoom().toString();
        var json = JSON.stringify({ 'bounds': bounds, 'zoom': zoom });
        var xmlhttp2 = this.AjaxRequest(this.get_webServiceUrl(), json);
        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                var res = JSON.parse(xmlhttp2.responseText);
                var array = [];
                if (res.d.ClearAllMarkers)
                    that.DeleteAllMarker(that);
                if (typeof res.d.ChangingMarkers !== 'undefined' && res.d.ChangingMarkers !== null && res.d.ChangingMarkers.length > 0) {
                    array = res.d.ChangingMarkers;
                }
                for (i = 0; i < array.length; i++) {
                    if (array[i].Description == 'center')
                        that._AutoZooms.unshift(array[i]);
                    that._GCommunicationObjects.unshift(array[i]);
                }
                that.AutoZoom(that, map);
                that._GetData = true;
            }
        }
        that._GetData = false;
        xmlhttp2.send(json);
    },
    ToggleStyle: function (that, StyleName, AddingStyle) {
        var json = JSON.stringify({ 'StyleName': StyleName, 'AddingStyle': AddingStyle });
        var xmlhttp2 = this.AjaxRequest('/Services/WebBaseDefineService.asmx/ToggleStyle', json);
        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                //var res = JSON.parse(xmlhttp2.responseText);
                //var array = [];
                //var labels = [];
                //if (typeof res.d.Markers !== 'undefined' && res.d.Markers !== null && res.d.Markers.length > 0) {
                //    array = res.d.Markers;
                //    if (res.d.HasLabel) {
                //        labels = res.d.Labels;
                //        for (i = 0; i < array.length; i++) {
                //            that.AddLayerMarker(array[i], labels[i], that._mapObj, res.d.IconSize, LayerIndex);
                //        }
                //    }
                //    else {
                //        for (i = 0; i < array.length; i++) {
                //            that.AddLayerMarker(array[i], '', that._mapObj, res.d.IconSize, LayerIndex);
                //        }
                //    }
                //}
                //that._GetData = true;
                HideWarining();
            }
            else
                ShowWarining('دوباره تلاش کنید', true, 1, false);
        }
        //that._GetData = false;
        xmlhttp2.send(json);
    },
    AddLayer: function (that, LayerUrl, LayerIndex) {
        //if (!that._GetData){
        //    var CheckBox = document.getElementById("CB" + LayerIndex);
        //    CheckBox.checked = false;
        //    return;
        //}
        var json = '';
        var xmlhttp2 = this.AjaxRequest(LayerUrl, json);
        xmlhttp2.onreadystatechange = function () {
            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                var res = JSON.parse(xmlhttp2.responseText);
                var array = [];
                var labels = [];
                if (typeof res.d.Markers !== 'undefined' && res.d.Markers !== null && res.d.Markers.length > 0) {
                    array = res.d.Markers;
                    if (res.d.HasLabel) {
                        labels = res.d.Labels;
                        for (i = 0; i < array.length; i++) {
                            that.AddLayerMarker(array[i], labels[i], that._mapObj, res.d.IconSize, LayerIndex);
                        }
                    }
                    else {
                        for (i = 0; i < array.length; i++) {
                            that.AddLayerMarker(array[i], '', that._mapObj, res.d.IconSize, LayerIndex);
                        }
                    }
                }
                //that._GetData = true;
                HideWarining();
            }
            else
                ShowWarining('دوباره تلاش کنید', true, 1, false);
        }
        //that._GetData = false;
        xmlhttp2.send(json);
    },
    RemoveLayer: function (that, LayerIndex) {
        for (var i = that._Markers.length; i > 0; i--) {
            var ID = that._Markers[i - 1].ID.toString();
            if (ID.split('_')[0] == 'Lyr' + LayerIndex) {
                that._Markers[i - 1].setMap(null);
                that._Markers.splice(i - 1, 1);
            }
        }
    },
    GetLabelWidth: function (text) {
        var label = $('<div>' + text + '</div>').addClass('labels')
          .css({ 'position': 'absolute', 'visibility': 'hidden' })
          .appendTo($('body'));

        var label_width = label.width();
        label.remove();
        return label_width;

    },
    AddLayerMarker: function (Marker, Label, map, IconSize, LayerIndex) {

        var markerImage = new google.maps.MarkerImage(Marker.IconUrl,
        new google.maps.Size(IconSize.Width, IconSize.Height),
        new google.maps.Point(0, 0),
        new google.maps.Point(IconSize.Width / 2, IconSize.Height / 2),
        new google.maps.Size(IconSize.Width, IconSize.Height));
        var _marker;
        if (Label == '')
            _marker = new google.maps.Marker({
                position: new google.maps.LatLng(Marker.Location.X, Marker.Location.Y),
                map: map,
                icon: markerImage
            });
        else {
            var LabelWidth = this.GetLabelWidth(Label);
            var box_shadow = 2 + 2;
            _marker = new MarkerWithLabel({
                position: new google.maps.LatLng(Marker.Location.X, Marker.Location.Y),
                map: map,
                icon: markerImage,
                labelContent: Label,
                labelAnchor: new google.maps.Point(LabelWidth / 2 + box_shadow, -IconSize.Height / 2 - 3),
                labelClass: "labels", // the CSS class for the label
                labelInBackground: true,
                labelStyle: { opacity: 0.8 }
            });
        }

        (function (that) {
            google.maps.event.addListener(_marker, 'click', function () {
                ShowWarining('در  حال بارگذاری ...', true, 3, false);
                var json = JSON.stringify({
                    'id': 'Lyr' + LayerIndex + '_' + Marker.ID, 'groupIDs': '', 'offline': false
                });
                var xmlhttp2 = that.AjaxRequest(that.get_popupWebService(), json);
                xmlhttp2.onreadystatechange = function () {
                    if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                        var res = xmlhttp2.responseText;
                        var infowindow = new google.maps.InfoWindow({
                            content: JSON.parse(res).d
                        });
                        infowindow.open(map, _marker);
                        HideWarining();
                    }
                    else
                        ShowWarining('دوباره تلاش کنید', true, 1, false);
                }
                xmlhttp2.send(json);
            });
        })(this);
        //marker.Series = gCommunicationObject.Series;
        _marker.ID = 'Lyr' + LayerIndex + '_' + Marker.ID;
        this._Markers.push(_marker);
    },
    AutoZoom: function (that, map) {
        var minX = 0;
        var maxX = 0;
        var minY = 0;
        var maxY = 0;

        while (that._AutoZooms.length > 0) {
            var tZoom = that._AutoZooms.pop();
            if (minX == 0 || minX > tZoom.Location.X)
                minX = tZoom.Location.X;

            if (maxX == 0 || maxX < tZoom.Location.X)
                maxX = tZoom.Location.X;

            if (minY == 0 || minY > tZoom.Location.Y)
                minY = tZoom.Location.Y;

            if (maxY == 0 || maxY < tZoom.Location.Y)
                maxY = tZoom.Location.Y;
        }

        if (minX > 0 && minY > 0 && maxX > 0 && maxY > 0) {

            var latLng = [
                    new google.maps.LatLng(minX, minY),
                    new google.maps.LatLng(maxX, maxY)
            ];
            var qwe = new google.maps.LatLngBounds();
            qwe.extend(latLng[0]);
            qwe.extend(latLng[1]);
            map.fitBounds(qwe);
            map.zoom = map.getZoom() - 1;
        }
    },
    MarkersPOP: function (map) {
        if (!this._GetPop)
            return;
        this._GetPop = false;
        if (typeof this._GCommunicationObjects == null || this._GCommunicationObjects.length == 0) {
            this._inLoop = 0;
            this._GetPop = true;
            return;
        }
        if (this._inLoop == 1) {
            this._GetPop = true;
            return;
        }
        this._inLoop = 1;
        while (this._GCommunicationObjects.length > 0) {
            var gCommunicationObject = this._GCommunicationObjects.pop();
            this.setFunctionValue(gCommunicationObject, map, this);
        }
        this._inLoop = 0;
        this._GetPop = true;
    },
    setFunctionValue: function (gcommObjects, map, that) {
        (function (obj) { setTimeout(function () { obj.SetMarkersMap(gcommObjects, map, obj); }, 10); })(that);
    },
    SetMarkersMap: function (gcommObjects, map, that) {
        var index = that._Markers.map(function (x) { return x.ID; }).lastIndexOf(gcommObjects.ID);
        if (index < 0) {
            that.CreateMarker(gcommObjects, map);
        }
        else {
            that._Markers[index].Series = gcommObjects.Series;
            that.MoveMarker(that._Markers[index], gcommObjects.Location.X, gcommObjects.Location.Y, gcommObjects.Course, gcommObjects.Style);
        }
    },
    CreateMarker: function (gCommunicationObject, map) {

        //var _zoom = map.getZoom();

        var tWidth = this._ImageSize * 1;
        var tHeight = this._ImageSize * 1;
        var tWidthAnchor = this._ImageSize * 1 / 2;
        var tHeighAnchor = this._ImageSize * 1 / 2;

        var TempIS = this._ImageSize.split(",");
        if (TempIS.length > 1) {
            tWidth = TempIS[0] * 1;
            tHeight = TempIS[1] * 1;
            tWidthAnchor = TempIS[2] * 1;
            tHeighAnchor = TempIS[3] * 1;
        }
        //console.log(tWidth+ tHeight + tWidthAnchor + tHeighAnchor);
        var markerImage = new google.maps.MarkerImage(gCommunicationObject.Icon,
        new google.maps.Size(tWidth, tHeight),
        new google.maps.Point(0, 0),
        new google.maps.Point(tWidthAnchor, tHeighAnchor),
        new google.maps.Size(tWidth, tHeight));


        //var marker = new MarkerWithLabel({
        //    position: new google.maps.LatLng(gCommunicationObject.Location.X, gCommunicationObject.Location.Y),
        //    map: map,
        //    icon: markerImage,
        //    raiseOnDrag: true,
        //    labelContent: gCommunicationObject.Title,
        //    labelAnchor: new google.maps.Point(3, 30),
        //    labelClass: "labels", // the CSS class for the label
        //    labelInBackground: false
        //});        
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(gCommunicationObject.Location.X, gCommunicationObject.Location.Y),
            map: map,
            icon: markerImage
        });

        if (this._firstPosition == 0) {
            this._firstPosition = 1;
            //var qwe = new google.maps.LatLngBounds();
            //qwe.extend(marker.position);
            //map.fitBounds(qwe);
            //map.setZoom(map.getZoom() - 3);
        }

        (function (that) {
            google.maps.event.addListener(marker, 'click', function () {
                var json = JSON.stringify({ 'id': gCommunicationObject.ID, 'groupIDs': gCommunicationObject.GroupIDs, 'offline': false });
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
        })(this);
        marker.Series = gCommunicationObject.Series;
        marker.Course = gCommunicationObject.Course;
        marker.ID = gCommunicationObject.ID;
        this._Markers.push(marker);
    },
    MoveMarker: function (Marker, DestLat, DestLan, DesCourse, MarkerSyle) {
        var Series = Marker.Series;
        var frames = [];
        var FromCourse = Marker.Course;
        var fromLat = Marker.getPosition().lat();
        var fromLng = Marker.getPosition().lng();
        var FrameCount = 0.2 / this._mapObj.getZoom();
        if (this.getDistance(Marker.getPosition(), new google.maps.LatLng(DestLat, DestLan)) > 100)
            FrameCount = 0.99;
        var toLat = DestLat;
        var toLng = DestLan;
        var delLng = (toLng - fromLng);
        var arg = Math.sin(delLng) * Math.cos(toLat) / (Math.cos(fromLat) * Math.sin(toLat) - Math.sin(fromLat)
            * Math.cos(toLat) * Math.cos(delLng));
        var angle = (fromLat - toLat) > 0 ? (Math.atan(arg) * (180 / Math.PI) + 90) % 360 : (Math.atan(arg) * (180 / Math.PI) + 270) % 360;
        if (this.get_AnimateIcon() !== "") {

            var tWidth = this._ImageSize * 1;
            var tHeight = this._ImageSize * 1;
            var tWidthAnchor = this._ImageSize * 1 / 2;
            var tHeighAnchor = this._ImageSize * 1 / 2;

            var TempIS = this._ImageSize.split(",");
            if (TempIS.length > 1) {
                tWidth = TempIS[0] * 1;
                tHeight = TempIS[1] * 1;
                tWidthAnchor = TempIS[2] * 1;
                tHeighAnchor = TempIS[3] * 1;
            }

            Marker.setIcon({
                url: this.GetMarkerUrl(DesCourse, MarkerSyle),
                size: new google.maps.Size(tWidth, tHeight),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(tWidthAnchor, tHeighAnchor),
                scaledSize: new google.maps.Size(tWidth, tHeight)
            });
            //new google.maps.Point(30 + 25 * Math.cos(DesCourse * Math.PI / 180), 30 - 25 * Math.sin(DesCourse * Math.PI / 180)),
        }
        var curLat, curLng, curCourse;
        var percent;
        for (percent = 0; percent < 1; percent += FrameCount) {
            curLat = fromLat + percent * (toLat - fromLat);
            curLng = fromLng + percent * (toLng - fromLng);
            frames.push({ LatLng: new google.maps.LatLng(curLat, curLng) });
        }
        (function (that) { setTimeout(function () { that.AnimateMarker(Marker, 0, frames, that, Series); }, 50) })(this);
    },
    AnimateMarker: function (Marker, index, frames, that, Series) {
        if (Series != Marker.Series) { return; };
        Marker.setPosition(frames[index].LatLng);
        Marker.Course = frames[index].Course;
        index++;
        if (index < frames.length)
            (function (t) { setTimeout(function () { t.AnimateMarker(Marker, index, frames, t, Series); }, 50); })(that);
    },
    DeleteMarker: function (i) {
        this._Markers[i].setMap(null);
        this._Markers.splice(i, 1);
    },
    DeleteAllMarker: function (that) {
        //alert('DeleteAllMarker'+this._Markers.length);
        while (this._Markers.length > 0) {
            this._Markers.pop().setMap(null);
        }

        for (var i = 0; i < that.get_layers().length; i++) {
            if (that.get_layers()[i].AddingMarkers) {
                var CheckBox = document.getElementById('CB' + i);
                CheckBox.checked = false;
            }
        }
    },
    AjaxRequest: function (url, jsonParams) {
        console.log("AjaxRequest: " + url + " : " + jsonParams)
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
    GetMarkerUrl: function (angle, style) {
        var Index = Math.round(16 * angle / 360 + 1);
        var url = this.get_AnimateIcon() + "&AngleIndex=" + (Index != 17 ? Index : 1) + "&Style=" + style;
        return url;
    },


    MyControl: function (MenuContainer, that) {
        var BoxMouseOver = '';
        $(MenuContainer).addClass('MenuContainer');

        var MapMenu = document.createElement('div');
        $(MapMenu).addClass('MapMenu');
        //MapMenu.title = 'Click to recenter the map';
        MenuContainer.appendChild(MapMenu);

        for (var i = 0; i < that.get_layers().length; i++) {
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
                if (this.checked) {
                    ShowWarining('در  حال بارگذاری ...', true, 3, false);
                    if (that.get_layers()[this.Index].AddingMarkers) {
                        that.AddLayer(that, that.get_layers()[this.Index].WebServiceUrl, this.Index);
                    }
                    else
                        that.ToggleStyle(that, that.get_layers()[this.Index].StyleName, true);
                }
                else {
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
}
AVL.Controls.Map.NewMapControl.NewGoogleMap.registerClass('AVL.Controls.Map.NewMapControl.NewGoogleMap', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();