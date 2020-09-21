using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class AreaUpdate : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "ناحیه";
            int.TryParse(Request["Code"], out Code);
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "51.4231,35.6961";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "7";
           // ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JLineUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CanAddMultipleMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).DrawLines = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).HasRightClick = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = false; 
            if (!Page.IsPostBack)
            {
                setPage();
                if (Code > 0)
                {
                    LoadArea(Code);
                }
            }
        }

        private void LoadArea(int AreaCode)
        {
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();//.Clear();
            AVL.Area.JArea area = new AVL.Area.JArea(AreaCode.ToString(), WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString());
            if (area != null)
            {
                string[] points = area.Points.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                List<WebControllers.MainControls.OpenLayersMap.UserMarker> userMarker = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();
                for (int i = 0; i < points.Length; i++)
                {
                    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker(
                        i.ToString(),
                        double.Parse(points[i].Split(',')[0]),
                        double.Parse(points[i].Split(',')[1])));
                }
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers = userMarker;
                txtName.Text = area.Name;
                chbListOfData.ClearSelection();
                foreach (string s in area.ObjectsCodes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    chbListOfData.Items[chbListOfData.Items.IndexOf(chbListOfData.Items.FindByValue(s))].Selected = true;
                rdbGeoKind.SelectedIndex = area.IsGeofence ? 1 : 0;
            }
        }

        private void setPage()
        {
            chbListOfData.Items.Clear();

            //  chbListOfData.Items.Add(new ListItem("<strong> a </strong>", "1"));
            System.Data.DataTable table = AVL.ObjectList.JObjectLists.GetDataTable(Code);
            if (table != null && table.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in table.Rows)
                {
                    chbListOfData.Items.Add(new ListItem("شی " + dr["Code"].ToString(), dr["Code"].ToString()));
                }
            }
        }
        public bool Save()
        {
            AVL.Area.JArea area = new AVL.Area.JArea();
            foreach (ListItem li in chbListOfData.Items)
            {
                if (li.Selected)
                    area.ObjectsCodes += li.Value + ",";
            }
           // area.ObjectsCodes = area.ObjectsCodes.Remove(area.ObjectsCodes.Length - 1);
            area.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            area.IsGeofence = rdbGeoKind.Items[1].Selected ? true : false;
            area.Name = txtName.Text;
            List<BusManagment.Line.JLinePoint> points=((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers.Select(m => new BusManagment.Line.JLinePoint() { Latitude = (double)m.Latitude, Longitude = (double)m.Longitude, LineCode = this.Code, OrderNo = 0 }).ToList();
            foreach (BusManagment.Line.JLinePoint j in points)
            {
                area.Points += j.Latitude + "," + j.Longitude + "|";
            }
            if (rdbGeoKind.Items[1].Selected)
            {
                area.Points += points[0].Latitude + "," + points[0].Longitude;
            }            
            AVL.Area.JAreaTable areatable = new AVL.Area.JAreaTable();
            areatable.SetValueProperty(area);
            if (Code == 0)
            {
                area.code = areatable.Insert();
            }
            else
            {
                
                if (string.IsNullOrEmpty(areatable.Points))
                {
                    areatable.Points = "";
                }
                if (string.IsNullOrEmpty(areatable.ObjectsCodes))
                {
                    areatable.ObjectsCodes = "";
                }
                areatable.UpdateManual("code=" + Code);
            }
            setPage();
            if (area.code > 0)
                return true;
            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh(); 
            chbListOfData.ClearSelection();
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers=new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();//.Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();//.Clear();
    
        }
        protected void btnDeleteArea_Click(object sender, EventArgs e)
        {

            if (new AVL.Area.JArea(Code.ToString(), WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString()).Remove())
                WebClassLibrary.JWebManager.CloseAndRefresh();
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).UserMarkers = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();//.Clear();
            setPage();
        }


    }
}
/*
namespace WebBusManagement.FormsManagement
{
    public partial class JLinePathCircularUpdateControl : System.Web.UI.UserControl
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

            LineCode.Value = Code.ToString();
            PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JLinePathCircularUpdateControl.GetStation");

            _SetForm();
        }
        public string[] GetStation(string[] param)
        {
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
            DataTable DtStation = new DataTable();
            DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL 
                                                                    And Lat <> '0.00000000000000' and Lng <> '0.00000000000000'
                                                                    And Code in (
                                                                    select StationCode from AutLineStation Where LineCode = " + param[0] + ") order by Code");
            if (DtStation != null)
            {
                for (int i = 0; i < DtStation.Rows.Count; i++)
                {
                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                            Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + DtStation.Rows[i]["Code"].ToString(),
                            DtStation.Rows[i]["Name"].ToString(),
                            "", 24, 24, 90, 20));
                }
            }
            return mapData.GenerateMarkerStation();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                List<WebControllers.MainControls.OpenLayersMap.UserMarker> userMarker = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();
                foreach (DataRow row in BusManagment.Line.JLinePoints.GetDataTable(Code, 2).Rows)
                {
                    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker() { Latitude = Convert.ToDouble(row["Latitude"]), Longitude = Convert.ToDouble(row["Longitude"]) });
                }
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers = userMarker;
            }
        }

        public bool Save()
        {
            return BusManagment.Line.JLinePoints.UpdateLinePoints(Code,
                        ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers.Select(m => new JLinePoint() { Latitude = (double)m.Latitude, Longitude = (double)m.Longitude, LineCode = this.Code, OrderNo = 0 }).ToList(), true, 2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (BusManagment.Line.JLinePoints.DeleteLinePoints(Code, 0))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}*/