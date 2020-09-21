using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class ShowMarker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            AVL.Coordinate.JCoordinate c = new AVL.Coordinate.JCoordinate();
            c.GetData(Request["code"]);
            if (c.Code > 0)
            {
                AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(c.DeviceCode);
                Googlemap.CenterLatitude = c.lat;
                Googlemap.CenterLongitude = c.lng;
                Googlemap.Zoom = 20;
                Googlemap.Markers.Add(new AVL.Controls.Map.Marker() {
                    Latitude = c.lat,
                    Longitude = c.lng,
                    UID = c.Code,
                    IconUrl = "getIcon.aspx?t=p&d=t&id=" + c.DeviceCode ,
                   Title= d.Name,
                 InfoWindowHtml= d.Name});
            }
        }
    }
}