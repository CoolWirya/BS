using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace AVL.Controls.Map
{
    [ParseChildren(true)]
    [System.Drawing.ToolboxBitmap(typeof(Map))]
    public class Map : ScriptControl
    {
        byte b = 0;

        #region Properties

        private int _Zoom = 10;
        public int Zoom
        {
            get { return this._Zoom; }
            set { this._Zoom = value; }
        }
        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }

        private List<Marker> markers = new List<Marker>();
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Marker> Markers
        {
            get { return this.markers;}
        }

        private List<Line> _lines = new List<Line>();
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Line> Lines
        {
            get { return this._lines; }
        }

        private string _webServiceUrl = "";
        [System.Web.UI.UrlProperty]
        public string WebServiceUrl
        {
            get
            {
                return _webServiceUrl;
            }
            set
            {
                _webServiceUrl = value;
            }
        }

        private string _markerWithLabelAddress = "/WebAVL/Script/markerExtension.js";
        [System.Web.UI.UrlProperty]
        public string MarkerWithLabelAddress
        {
            get
            {
                return _markerWithLabelAddress;
            }
            set
            {
                _markerWithLabelAddress = value;
            }
        }
        private string _popupWebService = string.Empty;
        [System.Web.UI.UrlProperty]
        public string PopupWebService
        {
            get
            {
                return _popupWebService;
            }
            set
            {
                _popupWebService = value;
            }
        }
        private int _getDetailsInterval = 5000;
        public int GetDetailsInterval
        {
            get
            {
                return _getDetailsInterval;
            }
            set
            {
                _getDetailsInterval = value;
            }
        }
        private int _interval = 5000;
        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
            }
        }


        private bool _showLinesAutomatically = false;
        public bool ShowLinesAutomatically
        {
            get
            {
                return _showLinesAutomatically;
            }
            set
            {
                _showLinesAutomatically = value;
            }
        }
        private bool _specifiedArea = false;
        public bool SpecifiedArea
        {
            get
            {
                return _specifiedArea;
            }
            set
            {
                _specifiedArea = value;
            }
        }
        private string _pontWebservice = string.Empty;
        [System.Web.UI.UrlProperty]
        public string PointWebservice
        {
            get
            {
                return _pontWebservice;
            }
            set
            {
                _pontWebservice = value;
            }
        }

        #endregion

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<script type='text/javascript' src='http://maps.google.com/maps/api/js?v=3&sensor=false'></script>");
          
            writer.Write("<script type='text/javascript' src='" + this._markerWithLabelAddress + "'></script>");
            base.RenderContents(writer);
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        public Map()
        {
            //
            // TODO: Add constructor logic here
            //
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

        public override void RenderBeginTag(HtmlTextWriter writer)
        {

            base.RenderBeginTag(writer);
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {

            base.RenderEndTag(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            base.Render(writer);
        }

        protected override IEnumerable<ScriptDescriptor>
                GetScriptDescriptors()
        {
            if (b == 0)
            {
                ScriptControlDescriptor descriptor = new ScriptControlDescriptor("AVL.Controls.Map.Map", this.ClientID);

                descriptor.AddProperty("zoom", this.Zoom);
                descriptor.AddProperty("centerLatitude", this.CenterLatitude);
                descriptor.AddProperty("centerLongitude", this.CenterLongitude);
                descriptor.AddProperty("markers", this.Markers);
                descriptor.AddProperty("webServiceUrl", this.WebServiceUrl);
                descriptor.AddProperty("interval", this.Interval);
                descriptor.AddProperty("getDetailsInterval", this._getDetailsInterval);
                descriptor.AddProperty("popupWebService", this.PopupWebService);
                descriptor.AddProperty("lines", this.Lines);
                descriptor.AddProperty("showLinesAutomatically", this.ShowLinesAutomatically);
                descriptor.AddProperty("pointsWebservice", this.PointWebservice);
                descriptor.AddProperty("specifiedArea", this.SpecifiedArea);
                b++;
                yield return descriptor;
            }
            yield return null;
        }

        // Generate the script reference
        protected override IEnumerable<ScriptReference>
                GetScriptReferences()
        {
            yield return new ScriptReference("AVL.Controls.Map.Map.js", this.GetType().Assembly.FullName);
        }
    }
}
