/*
 Copyright 2010 Redfin Corporation
 Licensed under the Apache License, Version 2.0: 
 http://www.apache.org/licenses/LICENSE-2.0 
 */

com = {redfin: {}};

/* Construct a new FastMarkerOverlay layer for a V2 map
 * @constructor
 * @param {google.maps.Map} map the map to which we'll add markers
 * @param {Array.<com.redfin.FastMarker>} markers the array of markers to display on the map
 */
com.redfin.FastMarkerOverlay = function (map, markers) {
    if (this._div) {

    }
    else {

        this._div = document.createElement("div");
        //var ctx = this._div.getContext("2d");
        //ctx.fillStyle = "#FF0000";
        //ctx.fillRect(0, 0, 150, 75);
    }
  this.setMap(map);
  this._markers = markers;
  this.overlayProjection;
}

com.redfin.FastMarkerOverlay.prototype = new google.maps.OverlayView();

com.redfin.FastMarkerOverlay.prototype.onAdd = function() {
  
  var panes = this.getPanes();
  panes.floatPane.appendChild(this._div);

}

/* Copy our data to a new FastMarkerOverlay
 * @param {google.maps.Map} map the map to which the copy will add markers
 * @return {FastMarkerOverlay} Copy of FastMarkerOverlay
 */
com.redfin.FastMarkerOverlay.prototype.copy = function(map) {
  var markers = this._markers;
  var i = markers.length;
  var markersCopy = new Array(i);
  while (i--) {
    markersCopy[i] = markers[i].copy();
  }
  return new com.redfin.FastMarkerOverlay(map, markers);
};

/* Draw the FastMarkerOverlay based on the current projection and zoom level; called by Gmaps */
com.redfin.FastMarkerOverlay.prototype.draw = function() {
  // if already removed, never draw
  if (!this._div) return;
  
  // Size and position the overlay. We use a southwest and northeast
  // position of the overlay to peg it to the correct position and size.
  // We need to retrieve the projection from this overlay to do this.
  this.overlayProjection = this.getProjection();

  // DGF use fastloop http://ajaxian.com/archives/fast-loops-in-js
  // JD Create string with all the markers
   var i = this._markers.length;
   var id;

  var textArray = [];
  while (i--) {
      id = i;// (this._markers.length - this._markers[i]._id - 1);
    var marker = this._markers[id];
    var divPixel = this.overlayProjection.fromLatLngToDivPixel(marker._latLng);
    if (document.getElementById('marker' + this._markers[id]._id)) {
        continue;
    }
   // console.log(divPixel.toString());
    textArray.push("<div id='marker" + (this._markers[id]._id ) + "' style='position:absolute; cursor: pointer;left:");
    textArray.push(divPixel.x + marker._leftOffset);
    textArray.push("px; top:");
    textArray.push(divPixel.y + marker._topOffset);
    textArray.push("px;")
    if (marker._zIndex) {
      textArray.push(" z-index:");
      textArray.push(marker._zIndex);
      textArray.push(";");
    }
    textArray.push("'");
    if (marker._divClassName) {
      textArray.push(" class='");
      textArray.push(marker._divClassName);
      textArray.push("'");
    }
    textArray.push(" id='");
    textArray.push(this._markers[id]._id);
    textArray.push("' >");
      //Label
    textArray.push(marker._label);
    var markerHtmlArray = marker._htmlTextArray;
    var j = markerHtmlArray.length;
    var currentSize = textArray.length;
    while (j--) {
      textArray[j + currentSize] = markerHtmlArray[j];
    }
    textArray.push("</div>");
    
  }

      this._div.innerHTML += textArray.join('');
      
      i = null;
      id = null;
      textArray = null;
}

/** Hide all of the markers */
com.redfin.FastMarkerOverlay.prototype.hide = function() {
  if (!this._div) return;
  this._div.style.display = "none";
}

/** Show all of the markers after hiding them */
com.redfin.FastMarkerOverlay.prototype.unhide = function() {
  if (!this._div) return;
  this._div.style.display = "block";
}

/** Remove the overlay from the map; never use the overlay again after calling this function */
com.redfin.FastMarkerOverlay.prototype.onRemove = function() {
  this._div.parentNode.removeChild(this._div);
  this._div = null;
}
com.redfin.FastMarkerOverlay.prototype.removeUnused = function (Id) {

    var item=document.getElementById('marker' +Id);
if(item!=null)
    item.parentNode.removeChild(item);
    //var elementPos = -1;
    //for (var i = 0; i < this._div.childNodes.length; i++) {
    //    elementPos = markers.map(function (x) { return parseFloat(x._id); }).indexOf(parseFloat(this._markers[i]._id));
    //    if (elementPos == -1) {
    //        this._div.removeChild(this._div.childNodes[i]);
    //    }

    //}
}
com.redfin.FastMarkerOverlay.prototype.move = function (id, latLng,interval) {
   // console.log("id= "+id.toString());
    this.overlayProjection = this.getProjection();
    var divPixel = this.overlayProjection.fromLatLngToDivPixel(latLng);
   // console.log("divpixel= " + divPixel.toString());
    //  this._div.children[id].style.left = divPixel.x+"px";

    $("#marker" +id)// this._div.children[id].id.toString())
        .animate({ left: divPixel.x + "px", top: divPixel.y + "px" },
         {"duration":interval-50, "queue": false });
}

/** Create a single marker for use in FastMarkerOverlay
 * @constructor
 * @param {string} id DOM node ID of the div that will contain the marker
 * @param {google.maps.LatLng} latLng geographical location of the marker 
 * @param {Array.<string>} htmlTextArray an array of strings which we'll join together to form the HTML of your marker
 * @param {string=} divClassName the CSS class of the div that will contain the marker. (optional)
 * @param {string=} zIndex zIndex of the div that will contain the marker. (optional, 'auto' by default)
 * @param {number=} leftOffset the offset in pixels by which we'll horizontally adjust the marker position (optional)
 * @param {number=} topOffset the offset in pixels by which we'll vertically adjust the marker position (optional)
*/
com.redfin.FastMarker = function(id, latLng, htmlTextArray, divClassName, zIndex, leftOffset, topOffset,label,iconPath) {
  this._id = id;
  this._latLng = latLng;
  this._htmlTextArray = htmlTextArray;
  this._divClassName = divClassName;
  this._zIndex = zIndex;
  this._leftOffset = leftOffset || 0;
  this._topOffset = topOffset || 0;
  this._label = label;
  this._iconPath = iconPath;
}

//com.redfin.FastMarker.prototype = new google.maps.Marker();
com.redfin.FastMarker.prototype.move = function (latlng) {
    //console.log("last lat lng: " + this._latLng.toString());
    //this._latLng = latlng;
    //console.log("NEW lat lng: " + latlng.toString());

  /*  
    */
}

/** Copy the FastMarker
 * @return {com.redfin.FastMarker} duplicate of this marker
 */
com.redfin.FastMarker.prototype.copy = function () {
  var htmlArray = this._htmlTextArray;
  var i = htmlArray.length;
  var htmlArrayCopy = new Array(i);
  while (i--) {
    htmlArrayCopy[i] = htmlArray[i];
  }
  return new com.redfin.FastMarker(this._id, latLng, htmlArrayCopy, this._divClassName, this._zIndex, this._leftOffset, this._topOffset,this._label,this._iconPath);
}


var infowindow;
var div;
var a, b = 'default';
var i = 0;
window.onload = function () {
}
function show(elem, serviceAddress) {
    infowindow = null;

    var id = elem.getAttribute('id');
    id = id.substring(6, id.length);
    var xmlhttp;
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
    }
    xmlhttp.onreadystatechange = function () {
        a = xmlhttp.responseText.substr();
        b = a.substring(a.indexOf('http://tempuri.org/') + 21, a.indexOf('</string>'));
        while (b.indexOf('&lt;') >= 0 || b.indexOf('&gt;') >= 0) {
            b = b.replace('&lt;', '<');
            b = b.replace('&gt;', '>');
        }

        if (b != "") {
            div = document.createElement('DIV');
            div.setAttribute('id', 'infowindowDiv');
            div.style.position = 'absolute';
            div.style.left = 0;
            div.style.top = 0;
            document.body.appendChild(div);
            div.innerHTML = b;
           // a = elem.parentElement.children[2].value.toString();
            //a = a.substring(1, a.length - 1);

            //console.log(elem.parentElement.children[2].value.toString());
          //  infowindow = new google.maps.InfoWindow({ position: new google.maps.LatLng(parseFloat(a.split(',')[0]), a.split(',')[1]), content: b }).open(window.map);
        }
    }
    xmlhttp.open('POST',""+ serviceAddress+"", true);
    xmlhttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
    xmlhttp.send('id=' + id);
}
