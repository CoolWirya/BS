using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Controls.Map
{
    public class GCommunicateObject
    {
        public string ID
        {
            get;
            set;
        }
        public int PCode
        {
            get;
            set;
        }
        //public System.Drawing.PointF Location
        public PointD Location
        {
            get;
            set;
        }
        public int Series
        {
            get;
            set;
        }
        public string Style
        {
            get;
            set;
        }
        public string date { get; set; }
        public static AVL.Controls.Map.BoundsObject BoundsStringtoPoints(string bounds)
        {

            string _sw = bounds.Split(new string[] { "), " }, StringSplitOptions.RemoveEmptyEntries)[0];
            string _ne = bounds.Split(new string[] { "), " }, StringSplitOptions.RemoveEmptyEntries)[1];
            float lat, lng;
            lat = float.Parse(_sw.Split(new string[] { "((", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim(), new System.Globalization.CultureInfo("en-US"));
            lng = float.Parse(_sw.Split(new string[] { "((", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim(), new System.Globalization.CultureInfo("en-US"));
            AVL.Controls.Map.Point SW = new AVL.Controls.Map.Point()
            {
                Latitude = lat,
                Longitude = lng
            };
            lat = float.Parse(_ne.Split(new string[] { "(", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim(), new System.Globalization.CultureInfo("en-US"));
            lng = float.Parse(_ne.Split(new string[] { "))", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim(), new System.Globalization.CultureInfo("en-US"));
            AVL.Controls.Map.Point NE = new AVL.Controls.Map.Point()
            {
                Latitude = lat,
                Longitude = lng
            };
            AVL.Controls.Map.BoundsObject boundsObj = new BoundsObject();
            boundsObj.NorthEast = NE;
            boundsObj.SouthWest = SW;
            return boundsObj;
        }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private string _groupIDs = "";
        public string GroupIDs { get { return _groupIDs; } set { _groupIDs = value; } }
        public int row { get; set; }
        public int Speed { get; set; }
        public int Course { get; set; }
        public int Battery { get; set; }
    }
    public class GFixCommunicateObject
    {
        public int ID
        {
            get;
            set;
        }
        private string _groupIDs = "";
        public string GroupIDs { get { return _groupIDs; } set { _groupIDs = value; } }
    }

    public class GetMarkersOutput 
    {
        public GCommunicateObject[] ChangingMarkers;
        private bool _ClearAllMarkers;
        public bool ClearAllMarkers
        {
            get
            {
                return _ClearAllMarkers;
            }
            set
            {
                _ClearAllMarkers = value;
                if (value)
                    WebClassLibrary.SessionManager.Current.Session["SesionObjects"] = null;
            }
        }
    }

    public class GetLayerOutput
    {
        public GetLayerOutput()
        {
            Markers = new LayerMarker[] { };
            IconSize = new System.Drawing.Size();
        }
        public LayerMarker[] Markers;
        public bool HasLabel;
        public string[] Labels;
        public System.Drawing.Size IconSize;
    }
    public class GetBusesOutput 
    {
        public int BusCode;
        public int BusNumber;
        public double MovePercent;
        public bool IsBack;
        public int StationCode;
        public Int16 Priority;
        public bool NextStationIsBack;
        public int NextStationCode;
        public Int16 NextStationPriority;
        public bool PathChanging;

    }
    public class GetLineStationsOutput
    {
        public Station[] GoStations;
        public Station[] BackStations;
    }
    public class Station
    { 
        public int Code;
        public int Priority;
        public string Name;
    }
    public class LayerMarker
    {
        public LayerMarker()
        {
            ID = 0;
            Location = new PointD();
            IconUrl = "";
        }
        public int ID;
        public PointD Location;
        public string IconUrl;
    }
}
