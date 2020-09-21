using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebControllers.MainControls.GoogleMapControl;

namespace WebBusManagement.OnlineMap
{
    public partial class JOnlineMap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GoogleMapControl googleMap = (GoogleMapControl)LoadControl("~/WebControllers/MainControls/GoogleMapControl/GoogleMapControl.ascx");
                googleMap.GoogleMapObject.APIKey = "AIzaSyCZH-2KjQHsAAOW38n8i5wkLnOZPKM1xDs";
                googleMap.GoogleMapObject.Width = "1000px"; // You can also specify percentage(e.g. 80%) here
                googleMap.GoogleMapObject.Height = "500px";
                //Specify initial Zoom level.
                googleMap.GoogleMapObject.ZoomLevel = 14;

                //Specify Center Point for map. Map will be centered on this point.
                googleMap.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66619, -79.44268);
                divMap.Controls.Add(googleMap);
            }
        }
    }
}