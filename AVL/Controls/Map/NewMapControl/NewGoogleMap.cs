using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace AVL.Controls.Map.NewMapControl
{
    [ParseChildren(true)]
    [System.Drawing.ToolboxBitmap(typeof(NewGoogleMap))]
    public class NewGoogleMap : ScriptControl
    {
        public NewGoogleMap()
        {

        }
        private int _Zoom = 10;
        public int Zoom
        {
            get { return this._Zoom; }
            set { this._Zoom = value; }
        }
        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }

        private string _webServiceUrl = "";
        [System.Web.UI.UrlProperty]
        public string WebServiceUrl { get { return _webServiceUrl; } set { _webServiceUrl = value; } }

        private int _interval = 5000;
        public int Interval { get { return _interval; } set { _interval = value; } }

        private bool _offline = false;
        public bool Offline { get { return _offline; } set { _offline = value; } }
        private bool _offlinemapAnimated = true;
        public bool OfflineMapAnimated { get { return _offlinemapAnimated; } set { _offlinemapAnimated = value; } }

        private int _devicecode = 0;
        public int DeviceCode { get { return _devicecode; } set { _devicecode = value; } }
        private List<int> _devicecodes = new List<int>();
        public List<int> DeviceCodes { get { return _devicecodes; } set { _devicecodes = value; } }
        private List<string> _lineColors = new List<string>();
        public List<string> LinesColors { get { return _lineColors; } set { _lineColors = value; } }

        private string _startdate = "";
        public string Startdate { get { return _startdate; } set { _startdate = value; } }

        private string _enddate = "";
        public string EndDate { get { return _enddate; } set { _enddate = value; } }

        private int _speed = 1;
        public int Speed { get { return _speed; } set { _speed = value; } }

        private int _lastrow = 0;
        public int Lastrow { get { return _lastrow; } set { _lastrow = value; } }

        private string _AnimateIcon = "";
        public string AnimateIcon { get { return _AnimateIcon; } set { _AnimateIcon = value; } }

        private string _ImageSize;
        public string ImageSize { get { return _ImageSize; } set { _ImageSize = value; } }

        public string ClassName;
        public int ObjectCode;
        private string _layers;
        public string Layers 
        {
            set 
            {
                _layers = value.Replace("'", "\"");
            }
        }

        private string _popupWebService = string.Empty;
        [System.Web.UI.UrlProperty]
        public string PopupWebService { get { return _popupWebService; } set { _popupWebService = value; } }
        //string googleApi3Key = "AIzaSyCSrp7GwfO5SEii1g8yFhr_ukvNuWxRq8A";
        public static string googleApi3Key = "AIzaSyABq2dRpjRH74mF3n7h-bj9csVyHWK4Krg"; // By Mohseni
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<script type='text/javascript' src='http://maps.google.com/maps/api/js?v=3&sensor=false&key="+ googleApi3Key + "'></script>");
            writer.Write("<script type='text/javascript' src='/Script/markerwithlabel.js'></script>");
            base.RenderContents(writer);
        }
        
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        private ScriptManager sm;
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // Test for ScriptManager and register if it exists
                sm = ScriptManager.GetCurrent(Page);

                if (sm == null)
                    throw new HttpException("A ScriptManager control must exist on the current page.");

                sm.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            base.Render(writer);
        }

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("AVL.Controls.Map.NewMapControl.NewGoogleMap", this.ClientID);

            descriptor.AddProperty("zoom", this.Zoom);
            descriptor.AddProperty("centerLatitude", this.CenterLatitude);
            descriptor.AddProperty("centerLongitude", this.CenterLongitude);
            descriptor.AddProperty("layers", this._layers);
            descriptor.AddProperty("webServiceUrl", this.WebServiceUrl);
            descriptor.AddProperty("interval", this.Interval);
            descriptor.AddProperty("popupWebService", this.PopupWebService);
            descriptor.AddProperty("offline", this.Offline);
            descriptor.AddProperty("devicecode", this.DeviceCode);
            descriptor.AddProperty("lastrow", this.Lastrow);
            descriptor.AddProperty("startdate", this.Startdate);
            descriptor.AddProperty("enddate", this.EndDate);
            descriptor.AddProperty("speed", this.Speed);
            descriptor.AddProperty("AnimateIcon", this.AnimateIcon);
            descriptor.AddProperty("ImageSize", this.ImageSize);
            descriptor.AddProperty("offlineMapAnimated", this.OfflineMapAnimated);
            descriptor.AddProperty("deviceCodes", this.DeviceCodes);
            descriptor.AddProperty("lineColors", this.LinesColors);
            yield return descriptor;
        }
        // Generate the script reference
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            if (Offline)
                yield return new ScriptReference("AVL.Controls.Map.NewMapControl.NewGoogleMapOffline.js", this.GetType().Assembly.FullName);
            else
                yield return new ScriptReference("AVL.Controls.Map.NewMapControl.NewGoogleMap.js", this.GetType().Assembly.FullName);
        }

        /// <summary>
        /// این متد مقدار اندازه بین هر نیم سانتی متر در زوم های مختلف در نقشه گوگل را می دهد.
        /// </summary>
        /// <param name="zoomLevel"></param>
        /// <returns></returns>
        public static double GetMeterByZoom(int zoomLevel)
        {
            switch (zoomLevel)
            {
                case 0:
                    return 524288;
                    break;
                case 1:
                    return 262144;
                    break;
                case 2:
                    return 131072;
                    break;
                case 3:
                    return 65536;
                    break;
                case 4:
                    return 32768;
                    break;
                case 5:
                    return 16384;
                    break;
                case 6:
                    return 8192;
                    break;
                case 7:
                    return 4096;
                    break;
                case 8:
                    return 2048;
                    break;
                case 9:
                    return 1024;
                    break;
                case 10:
                    return 512;
                    break;
                case 11:
                    return 256;
                    break;
                case 12:
                    return 128;
                    break;
                case 13:
                    return 64;
                    break;
                case 14:
                    return 32;
                    break;
                case 15:
                    return 16;
                    break;
                case 16:
                    return 8;
                    break;
                case 17:
                    return 4;
                    break;
                case 18:
                    return 2;
                    break;
                case 19:
                    return 1;
                    break;
                case 20:
                    return 0;
                    break;
                default:
                    return 0;
            }
        }
        public static double GetDistance(Point startPoint, Point endPoint)
        {
            double dlon = endPoint.Longitude - startPoint.Longitude;
            double dlat = endPoint.Latitude - startPoint.Latitude;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(startPoint.Latitude) * Math.Cos(endPoint.Latitude) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = 6373 * c;
            return d;
        }

        public static List<int> LastSeriBusesCode()
        {
            int Series = -1;
            List<int> ret_data = new List<int>();
            List<AVL.Controls.Map.GCommunicateObject> SesionObjects = new List<AVL.Controls.Map.GCommunicateObject>();
            if (WebClassLibrary.SessionManager.Current.Session["SesionObjects"] != null)
                SesionObjects = (List<AVL.Controls.Map.GCommunicateObject>)WebClassLibrary.SessionManager.Current.Session["SesionObjects"];
            if (WebClassLibrary.SessionManager.Current.Session["Series"] != null)
                Series = Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["Series"]);
            if (SesionObjects == null || SesionObjects.Count == 0 || Series < 0)
                return ret_data;
            else
            {
                return SesionObjects.Where(p => p.Series > Series - 10).Select(p => Convert.ToInt32(p.ID.Split('_')[1])).ToList(); 
            }
        }

        public static GCommunicateObject[] SeparateFixMarkers(AVL.Controls.Map.GCommunicateObject[] objects)
        {
            int Series = 0;
            //AVL.Controls.Map.GetMarkersOutput ret_date = new AVL.Controls.Map.GetMarkersOutput();
            List<AVL.Controls.Map.GCommunicateObject> ret_objects = new List<AVL.Controls.Map.GCommunicateObject>();
            //List<AVL.Controls.Map.GFixCommunicateObject> Fixobjects = new List<AVL.Controls.Map.GFixCommunicateObject>();
            List<AVL.Controls.Map.GCommunicateObject> SesionObjects = new List<AVL.Controls.Map.GCommunicateObject>();
            if (WebClassLibrary.SessionManager.Current.Session["SesionObjects"] != null)
                SesionObjects = (List<AVL.Controls.Map.GCommunicateObject>)WebClassLibrary.SessionManager.Current.Session["SesionObjects"];
            if (WebClassLibrary.SessionManager.Current.Session["Series"] != null)
                Series = Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["Series"]) + 1;
            foreach (AVL.Controls.Map.GCommunicateObject g in objects)
            {
                if (WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] == null || !SesionObjects.Exists(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs)
                    || g.Description == "center")
                {
                    g.Series = Series;
                    SesionObjects.Add(g);
                    ret_objects.Add(g);
                }
                else if (Series != SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Series + 1
                    || g.Location.X != SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Location.X
                    || g.Location.Y != SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Location.Y)
                {
                    SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Location = g.Location;
                    if(g.Series == 0)
                        SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Series = Series;
                    g.Series = Series;
                    ret_objects.Add(g);
                }
                else
                {
                    SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Location = g.Location;
                    if (g.Series == 0)
                        SesionObjects.Find(x1 => x1.ID == g.ID && x1.GroupIDs == g.GroupIDs).Series = Series;
                    //Fixobjects.Add(new AVL.Controls.Map.GFixCommunicateObject()
                    //{
                    //    ID = g.ID,
                    //    GroupIDs = g.GroupIDs
                    //});
                }
            }
            WebClassLibrary.SessionManager.Current.Session["SesionObjects"] = SesionObjects;
            WebClassLibrary.SessionManager.Current.Session.Add("Series", Series);
            return ret_objects.ToArray();
        }
        public static AVL.Controls.Map.GCommunicateObject[] JoinMarkers(List<AVL.Controls.Map.GCommunicateObject> objects,int zoom)
        {
            List<AVL.Controls.Map.GCommunicateObject> Clustered = new List<AVL.Controls.Map.GCommunicateObject>();
            double Meter = AVL.Controls.Map.NewMapControl.NewGoogleMap.GetMeterByZoom(zoom);
            double distance;
            AVL.Controls.Map.Point from;
            AVL.Controls.Map.Point end;
            List<AVL.Controls.Map.GCommunicateObject> temp = objects;
            if (Clustered.Count == 0)
                Clustered.Add(temp[0]);
            int index = 0;
            AVL.Controls.Map.GCommunicateObject c;
            while (temp.Count>0)
            {
                c = Clustered[index];
                if (temp.Count == 1)
                {
                    Clustered[index].GroupIDs = c.ID.ToString();
                    break; 
                }
                foreach (AVL.Controls.Map.GCommunicateObject g in temp)
                {
                    from = new AVL.Controls.Map.Point() { Latitude = c.Location.X, Longitude = c.Location.Y };
                    end = new AVL.Controls.Map.Point() { Latitude = g.Location.X, Longitude = g.Location.Y };
                    distance = AVL.Controls.Map.NewMapControl.NewGoogleMap.GetDistance(from, end);// *.5 / Meter;
                    if (distance <= (Meter/10))
                    {
                        if (c.GroupIDs.Length > 0)
                            c.GroupIDs += ",";
                        c.GroupIDs += g.ID;
                    }
                }
                temp.RemoveAll(x => c.GroupIDs.Contains(x.ID.ToString()));
                if (temp.Count == 0)
                    break;
				try
				{
					Clustered.Add(temp[0]);
				}
				catch
				{
				}
                index++;
            }
            return Clustered.ToArray();
        }
    }
}
