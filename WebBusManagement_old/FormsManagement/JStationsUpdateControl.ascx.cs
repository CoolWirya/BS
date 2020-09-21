using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusManagment.Zone;
using System.Data;
using BusManagment.Station;

namespace WebBusManagement.FormsManagement
{
    public partial class JStationsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadZones();
            StationType();
            _SetForm();

            //Stations
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsManagement.JStationsUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;
        }

        public void LoadZones()
        {
            DataTable DtZone = new DataTable();
            DtZone = JZones.GetDataTable(0);
            cmbZoneCode.DataSource = DtZone;
            cmbZoneCode.DataTextField = "Name";
            cmbZoneCode.DataValueField = "Code";
            cmbZoneCode.DataBind();
        }

        public void StationType()
        {
            DataTable Station = new DataTable();
            Station = (new BusManagment.Station.JStationTypes()).GetList();
            cmbStationType.DataSource = Station;
            cmbStationType.DataTextField = "Name";
            cmbStationType.DataValueField = "Code";
            cmbStationType.DataBind();
        }

        public void _SetForm()
        {
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ClassName = "BusManagment.Station";
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ObjectCode = 1000002;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).isMultiple = false;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).LoadProperty();

            if (Code > 0)
            {
                BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
                Station.GetData(Code);
                txtName.Text = Station.Name;
                cmbZoneCode.SelectedValue = Station.ZoneCode.ToString();
                cmbStationType.SelectedValue = Station.StationTypeCode.ToString();
                chkIsTerminal.Checked = Station.isTerminal;
                txtAddress.Text = Station.Address;
                if ((Station.Lng != Convert.ToDecimal(0)) && (Station.Lat != Convert.ToDecimal(0)))
                {
                    txtLat.Text = Station.Lat.ToString();
                    txtLng.Text = Station.Lng.ToString();
                    ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers =
                        new List<WebControllers.MainControls.OpenLayersMap.UserMarker>() { new WebControllers.MainControls.OpenLayersMap.UserMarker("USM_" + Station.Lng.ToString() + Station.Lat.ToString(), Convert.ToDouble(Station.Lng), Convert.ToDouble(Station.Lat)) };
                }
            }
        }

        public bool Save()
        {
            BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
            Station.Code = Code;
            Station.Name = txtName.Text;
            Station.ZoneCode = Convert.ToInt32(cmbZoneCode.SelectedValue);
            Station.StationTypeCode = Convert.ToInt32(cmbStationType.SelectedValue);
            Station.isTerminal = chkIsTerminal.Checked;
            Station.Address = txtAddress.Text;

            if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers.Count() > 0)
            {
                Station.Lng = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Longitude);
                Station.Lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Latitude);
            }
            else
            {
                try
                {
                    Station.Lat = Convert.ToDecimal(txtLat.Text);
                    Station.Lng = Convert.ToDecimal(txtLng.Text);
                }
                catch
                {
                    Station.Lat = 0;
                    Station.Lng = 0;
                }
            }

            if (Code > 0)
            {
                ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
                if (Station.Update(true))
                {
                    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).Save();
                    return true;
                }
            }
            else
            {
                Code = Station.Insert(true);
                if (Code > 0)
                {
                    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
                    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).Save();
                    return true;
                }

            }

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}