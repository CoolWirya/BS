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
            if (!IsPostBack)
            { 
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
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).MarkerClick = true;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DraggableMarker = true;

                LineCode.Value = Code.ToString();
                PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JLinePathUpdateControl.GetStation");

                _SetForm();
            }
        }

        public string[] GetStation(string[] param)
        {
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
            DataTable DtStation = new DataTable();
            DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL 
                                                                    And Lat <> '0.00000000000000' and Lng <> '0.00000000000000'
                                                                    And Code in (
                                                                    select StationCode from AutLineStation Where LineCode = " + param[0] + " and IsBack = 0) order by Code");
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
                foreach (DataRow row in BusManagment.Line.JLinePoints.GetDataTable(Code, 1).Rows)
                {
                    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker() { Latitude = Convert.ToDouble(row["Latitude"]), Longitude = Convert.ToDouble(row["Longitude"]) });
                }
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers = userMarker;
            }
        }

        public bool Save()
        {
            if (BusManagment.Line.JLinePoints.UpdateLinePoints(Code,
                        ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers.Select(m => new JLinePoint() { Latitude = (double)m.Latitude, Longitude = (double)m.Longitude, LineCode = this.Code, OrderNo = 0 }).ToList(), true, 1))
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                string[] Param = new string[3] { "@LineCode", "@PathType", "@precision_factor" };// precision_factor is horizontal precision distance
                try
                {
                    Db.ExecuteProcedure_Query("[dbo].[SP_UpdateAUTFleetLinePoints]", Param, new string[3] { Code.ToString(), 1.ToString(), 2.ToString() });
                    return true;
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
                finally
                {
                    Db.Dispose();
                }
            }
            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (BusManagment.Line.JLinePoints.DeleteLinePoints(Code, 1))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}