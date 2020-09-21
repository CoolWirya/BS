using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Line;

namespace WebBusManagement.FormsManagement
{
    public partial class JLinePathUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Action = "WebBusManagement.FormsManagement.JLineUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).CanAddMultipleMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawLines = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).HasRightClick = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).MarkerClick = false;

            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                List<WebControllers.MainControls.OpenLayersMap.UserMarker> userMarker = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();
                foreach (DataRow row in BusManagment.Line.JLinePoints.GetDataTable(Code).Rows)
                {
                    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker() { Latitude = Convert.ToDouble(row["Latitude"]), Longitude = Convert.ToDouble(row["Longitude"]) });
                }
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers = userMarker;
            }
        }

        public bool Save()
        {
            return BusManagment.Line.JLinePoints.UpdateLinePoints(Code,
                        ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers.Select(m => new JLinePoint() { Latitude = (double)m.Latitude, Longitude = (double)m.Longitude, LineCode = this.Code, OrderNo = 0 }).ToList(), true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}