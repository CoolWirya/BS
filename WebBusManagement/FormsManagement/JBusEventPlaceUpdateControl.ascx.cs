using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusEventPlaceUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBusEvent();
            int.TryParse(Request["Code"], out Code);
            _SetForm();

            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "24";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsManagement.JBusEventPlaceUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;


            PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JBusEventPlaceUpdateControl.GetStation");
        }

        public void LoadBusEvent()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],[Name] FROM [dbo].[AUTBusEventDetailes] order by [Code]");
            cmbBusEvent.DataSource = dt;
            cmbBusEvent.DataTextField = "Name";
            cmbBusEvent.DataValueField = "Code";
            cmbBusEvent.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.BusEvent.JBusEventPlace Event = new BusManagment.BusEvent.JBusEventPlace();
                Event.GetData(Code);
                txtTitle.Text = Event.Name;
                cmbBusEvent.SelectedValue = Event.BusEventDetailesCode.ToString();
                txtLongitude.Text = Event.Longitude.ToString();
                txtLatitude.Text = Event.Latitude.ToString();
                txtRadius.Text = Event.Radius.ToString();

                try
                {
                    ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers =
                            new List<WebControllers.MainControls.OpenLayersMap.UserMarker>() { new WebControllers.MainControls.OpenLayersMap.UserMarker("USM_" + Event.Latitude.ToString() + Event.Longitude.ToString(), Convert.ToDouble(Event.Latitude), Convert.ToDouble(Event.Longitude)) };
                }
                catch { }

            }
        }

        public bool Save()
        {
            BusManagment.BusEvent.JBusEventPlace Event = new BusManagment.BusEvent.JBusEventPlace();
            Event.Code = Code;
            Event.Name = txtTitle.Text;
            Event.BusEventDetailesCode = Convert.ToInt32(cmbBusEvent.SelectedValue);
            Event.Radius = Convert.ToInt32(txtRadius.Text);
            try
            {
                Event.Longitude = Convert.ToDouble(txtLongitude.Text);
                Event.Latitude = Convert.ToDouble(txtLatitude.Text);
            }
            catch { Event.Longitude = 0; Event.Latitude = 0; }

            decimal lng = 0, lat = 0;
            if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers.Count() > 0)
            {
                lng = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Longitude);
                lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Latitude);
            }

            if (lng > 0 & lat > 0)
            {
                Event.Longitude = Convert.ToDouble(lat);
                Event.Latitude = Convert.ToDouble(lng);
            }

            if (Code > 0)
            {
                return Event.Update();
            }
            else
            {
                return Event.Insert() > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.BusEvent.JBusEventPlace Event = new BusManagment.BusEvent.JBusEventPlace();
            Event.Code = Code;
            if (Event.Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('مکان واقعه با موفقیت حذف شد');", "ConfirmDialog");
        }

        protected void btnSaveFromMap_Click(object sender, EventArgs e)
        {
            decimal lng, lat;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers.Count() > 0)
            {
                lng = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Longitude);
                lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Latitude);
                if (Code > 0)
                {
                    //BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
                    // Station.Code = Code;
                    db.setQuery("update AUTBusEventPlace set Latitude = " + lng.ToString() + ", Longitude = " + lat.ToString() + " where code = " + Code);
                    if (db.Query_Execute() >= 0)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('نقطه جدید مکان واقعه با موفقیت ثبت شد');", "UpdateSettings");
                    }
                }
                txtLongitude.Text = lng.ToString();
                txtLatitude.Text = lat.ToString();
            }
        }
    }
}