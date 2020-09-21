using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.OpenLayersMap
{
    public partial class OpenLayersMap : System.Web.UI.UserControl
    {
        public MapProvider Provider
        {
            set
            {
                _MapProvider.Value = value.ToString();
            }
        }
        public string CenterPosition
        {
            set
            {
                _MapCenterPosition.Value = value;
            }
        }
        public string Zoom
        {
            set
            {
                _MapZoom.Value = value;
            }
        }
        public string Action
        {
            get
            {
                return ClassLibrary.JEnryption.DecryptStr(_Action.Value, WebClassLibrary.SessionManager.Current.SessionID);
            }
            set
            {
                _Action.Value = ClassLibrary.JEnryption.EncryptStr(value, WebClassLibrary.SessionManager.Current.SessionID);
            }
        }
        public List<JMapDataMarker> Markers
        {
            get
            {
                return JMapDataMarker.Parse(_Markers.Value);
            }
            set
            {
                JMapData mapData = new JMapData();
                mapData.AddData(value);
                string[] lines = mapData.Generate();
                _Lines.Value = "";
                for (int i = 1; i < lines.Count(); i = i + 2)
                {
                    _Lines.Value += "{!~!~!}" + lines[1];
                }
                if (_Lines.Value != null && _Lines.Value != "") _Lines.Value = _Lines.Value.Substring(7);

            }
        }
        public List<JMapDataLine> Lines
        {
            get
            {
                return JMapDataLine.Parse(_Lines.Value);
            }
            set
            {
                JMapData mapData = new JMapData();
                mapData.AddData(value);
                string[] markers = mapData.Generate();
                _Markers.Value = "";
                for (int i = 1; i < markers.Count(); i = i + 2)
                {
                    _Markers.Value += "{!~!~!}" + markers[1];
                }
                if (_Markers.Value != null && _Markers.Value != "") _Markers.Value = _Markers.Value.Substring(7);
            }
        }
        public List<UserMarker> UserMarkers
        {
            get
            {
                return UserMarker.Parse(_UserMarkers.Value);
            }
            set
            {
                _UserMarkers.Value = UserMarker.Generate(value);
            }
        }
        public List<UserLine> UserLines
        {
            get
            {
                return UserLine.Parse(_UserLines.Value);
            }
            set
            {
                _UserLines.Value = UserLine.Generate(value);
            }
        }
        public bool TimerEnabled
        {
            get
            {
                return _TimerEnabled.Value == "True" ? true : false;
            }
            set
            {
                _TimerEnabled.Value = value == true ? "True" : "False";
            }
        }
        public bool HasRightClick
        {
            get
            {
                return _HasRightClick.Value == "True" ? true : false;
            }
            set
            {
                _HasRightClick.Value = value == true ? "True" : "False";
            }
        }
        public bool DraggableMarker
        {
            get
            {
                return _DraggableMarker.Value == "True" ? true : false;
            }
            set
            {
                _DraggableMarker.Value = value == true ? "True" : "False";
            }
        }
        public bool MarkerClick
        {
            get
            {
                return _MarkerClick.Value == "True" ? true : false;
            }
            set
            {
                _MarkerClick.Value = value == true ? "True" : "False";
            }
        }
        public int TimerInterval
        {
            get
            {
                return Convert.ToInt32(_TimerInterval.Value);

            }
            set
            {
                _TimerInterval.Value = value.ToString();
            }
        }
        public bool MouseClickAddUserMarker
        {
            get
            {
                return _MouseClickAddUserMarker.Value == "True" ? true : false;
            }
            set
            {
                _MouseClickAddUserMarker.Value = value == true ? "True" : "False";
            }
        }
        public bool CanAddMultipleMarkers
        {
            get
            {
                return _CanAddMultipleMarkers.Value == "True" ? true : false;
            }
            set
            {
                _CanAddMultipleMarkers.Value = value == true ? "True" : "False";
            }
        }
        public bool DrawMarkers
        {
            get
            {
                return _DrawMarkers.Value == "True" ? true : false;
            }
            set
            {
                _DrawMarkers.Value = value == true ? "True" : "False";
            }
        }
        public bool DrawLines
        {
            get
            {
                return _DrawLines.Value == "True" ? true : false;
            }
            set
            {
                _DrawLines.Value = value == true ? "True" : "False";
            }
        }

        public string DrawMarkersInfo
        {
            set
            {
                _DrawMarkersInfo.Value = value;
            }
        }
        public string DrawLinesInfo
        {
            set
            {
                _DrawLinesInfo.Value = value;
            }
        }
        //public static string googleApi3Key = "AIzaSyCSrp7GwfO5SEii1g8yFhr_ukvNuWxRq8A";
        //public static string googleApi3Key = "AIzaSyABq2dRpjRH74mF3n7h-bj9csVyHWK4Krg"; // By Mohseni
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude("OpenLayersJS", this.ResolveUrl("~/WebControllers/MainControls/OpenLayersMap/Map.js"));
            //Page.ClientScript.RegisterClientScriptInclude("OpenLayersorgJS", "http://openlayers.org/api/OpenLayers.js");

            Page.ClientScript.RegisterClientScriptInclude("OpenLayersorgJS", this.ResolveUrl("~/WebControllers/MainControls/OpenLayersMap/OpenLayers.js"));
            //Page.ClientScript.RegisterClientScriptInclude("OpenLayersorgJS", "http://openlayers.org/api/2.11/OpenLayers.js");
            // Page.ClientScript.RegisterClientScriptInclude("OpenLayersorgJS", "~/WebControllers/MainControls/OpenLayersMap/OpenLayers.js");
            Page.ClientScript.RegisterClientScriptInclude("GoogleV3", "http://maps.google.com/maps/api/js?v=3&sensor=false&key=" + AVL.Controls.Map.NewMapControl.NewGoogleMap.googleApi3Key);
            Page.ClientScript.RegisterClientScriptInclude("MapLoad", this.ResolveUrl("~/WebControllers/MainControls/OpenLayersMap/MapLoad.js?v=2"));
            HtmlLink myHtmlLink = new HtmlLink();
            myHtmlLink.Href = ResolveUrl("~/WebControllers/MainControls/OpenLayersMap/MapStyle.css");
            myHtmlLink.Attributes.Add("rel", "stylesheet");
            myHtmlLink.Attributes.Add("type", "text/css");
            Page.Header.Controls.Add(myHtmlLink);

        }
    }
}