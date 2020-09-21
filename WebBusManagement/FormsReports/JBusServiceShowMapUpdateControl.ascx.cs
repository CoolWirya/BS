using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusServiceShowMapUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                GetReport(Code);
                //Stations
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = ClassLibrary.JConfig.CityCenterLong.ToString()
                    + "," + ClassLibrary.JConfig.CityCenterLat.ToString();
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "14";
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsReports.JBusServiceShowMapUpdateControl.ServiceAction";
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;

                BusServiceCode.Value = Code.ToString();

                PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsReports.JBusServiceShowMapUpdateControl.GetStation");
            }
        }

        public string[] GetStation(string[] param)
        {
            DataTable DtLineCode = null;
           
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select * from AutBusServices where Code = " + param[0].ToString(), false);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Latitude,Longitude from AUTAvlTransaction where BusCode = (select code from AUTBus where BUSNumber = " + Dt.Rows[0]["BusNumber"].ToString() + @")
                                                                                and EventDate between '" + Dt.Rows[0]["FirstStationDate"].ToString() + @"' and '" + Dt.Rows[0]["LastStationDate"].ToString() + @"'
                                                                                order by code");
                }
            }

            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();

            string MapIcon = "";

            if (DtLineCode != null && DtLineCode.Rows.Count > 0)
            {
                for (int i = 0; i < DtLineCode.Rows.Count; i++)
                {

                    if (i == 0 || i == (DtLineCode.Rows.Count - 1))
                    {
                        if (i == 0)
                        {
                            MapIcon = "../WebBusManagement/Images/ViewMapArrow/A.png";    //Start Point
                        }
                        else
                        {
                            MapIcon = "../WebBusManagement/Images/ViewMapArrow/B.png";    //End Point
                        }
                    }
                    else
                    {
                        MapIcon = "../WebBusManagement/Images/DefaultMarker_s64.png";
                    }

                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtLineCode.Rows[i]["Longitude"].ToString()),
                            Convert.ToSingle(DtLineCode.Rows[i]["Latitude"].ToString()), "LinePoint_" + param[0].ToString(),
                            "",
                            MapIcon, 24, 24, 0, 0));
                }
                return mapData.GenerateMarkerStation();
            }
            return new string[] { "" };
        }

        public void GetReport(int BusServiceCode = 0)
        {

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select * from AutBusServices where Code = " + BusServiceCode, false);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
                    jGridView.ClassName = "WebBusManagement_FormsReports_JBusServiceShowMapUpdateControl_" + BusServiceCode.ToString();
                    jGridView.SQL = @"select bps.[Code]
                              ,bps.[EventDate]
                              ,bps.[BusNumber]
                              ,bps.[StationCode]
	                          ,ast.Name StationName
                              ,bps.[DriverPersonCode]
	                          ,cap.Name DriverName
                              ,bps.[InsertDate] 
	                          from AutBusPassingStations  bps
	                          left join AUTStation ast on ast.Code = bps.StationCode
	                          left join clsAllPerson cap on cap.Code = bps.DriverPersonCode
	                          where bps.BusNumber = " + Dt.Rows[0]["BusNumber"].ToString() + @" 
                              and bps.EventDate between '" + Dt.Rows[0]["FirstStationDate"].ToString() + @"' and '" + Dt.Rows[0]["LastStationDate"].ToString() + @"'";
                    jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
                    jGridView.PageSize = 10;
                    //jGridView.HiddenColumns = "Code";
                    jGridView.Title = "JBusServiceShowMapUpdateControl";
                    jGridView.PageOrderByField = "EventDate asc";
                    jGridView.Buttons = "excel,print,record_print";
                    jGridView.Bind();
                }
            }
        }

        protected void btnSaveGo_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] Param = new string[3] { "@Service_code", "@PathType", "@precision_factor" };// precision_factor is horizontal precision distance
            try
            {
                Db.ExecuteProcedure_Query("[dbo].[SP_UpdateAUTFleetLinePointsBySevice]", Param, new string[3] { Code.ToString(), 1.ToString(), 15.ToString() });
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

        protected void btnSaveBack_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] Param = new string[3] { "@Service_code", "@PathType", "@precision_factor" };// precision_factor is horizontal precision distance
            try
            {
                Db.ExecuteProcedure_Query("[dbo].[SP_UpdateAUTFleetLinePointsBySevice]", Param, new string[3] { Code.ToString(), 2.ToString(), 15.ToString() });
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

    }
}