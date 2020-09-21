using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusPassingStationShowPointUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        public string StrInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();

            //Stations
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "18";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsManagement.JLineUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;

            LineCode.Value = GetLineCode(Code).ToString();
            PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JLinePathUpdateControl.GetStation");


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

        public int GetLineCode(int Code)
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code from AutLine where LineNumber = (select LastLineNumber from autbus where busnumber = (SELECT [BusNumber] FROM [AutBusPassingStations] where [Code] = " + Code + " ))", false);
            if(Dt!=null)
            {
                if(Dt.Rows.Count>0)
                {
                    return Convert.ToInt32(Dt.Rows[0]["Code"].ToString());
                }
            }
            return 0;
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT abps.[Code]
                                                                                        ,EventDate FullDate
                                                                                        ,dbo.DateEnToFa([EventDate])EventDate
                                                                                        ,cast([EventDate] as time)Time
                                                                                        ,[BusNumber]
                                                                                        ,abps.[StationCode]StationCode
	                                                                                    ,ast.Name StationName
                                                                                        ,[DriverCardSerial]
                                                                                        ,[DriverPersonCode]
									                                                    ,ISNULL(cap.Name,N'نامشخص')DriverName
                                                                                        ,[InsertDate]
                                                                                    FROM [dbo].[AutBusPassingStations] abps
                                                                                    left join AUTStation ast on abps.[StationCode] = ast.Code
								                                                    left join clsAllPerson cap on cap.Code = abps.DriverPersonCode where abps.[Code] = " + Code, false);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        StrInfo += @"تاریخ تراکنش : " + Dt.Rows[0]["EventDate"].ToString() + "<br /><br />";
                        StrInfo += @"ساعت تراکنش : " + Dt.Rows[0]["Time"].ToString() + "<br /><br />";
                        StrInfo += @"اتوبوس : " + Dt.Rows[0]["BusNumber"].ToString() + "<br /><br />";
                        StrInfo += @"کد ایستگاه : " + Dt.Rows[0]["StationCode"].ToString() + "<br /><br />";
                        StrInfo += @"نام ایستگاه : " + Dt.Rows[0]["StationName"].ToString() + "<br /><br />";
                        StrInfo += @"شماره کارت راننده : " + Dt.Rows[0]["DriverCardSerial"].ToString() + "<br /><br />";
                        StrInfo += @"نام راننده : " + Dt.Rows[0]["DriverName"].ToString() + "<br /><br />";
                    }
                }


                List<WebControllers.MainControls.OpenLayersMap.UserMarker> userMarker = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();
                foreach (DataRow row in WebClassLibrary.JWebDataBase.GetDataTable(@"Select b.BUSNumber,a.Latitude,a.Longitude,a.EventDate from AutAvlTransaction a 
                                                                                    left join AUTBus b on a.BusCode = b.Code
                                                                                    where b.BUSNumber = " + Dt.Rows[0]["BusNumber"].ToString()
                                                                                                          + @" and a.EventDate = '" + Dt.Rows[0]["FullDate"].ToString() + "' "
                                                                                                          , false).Rows)
                {
                    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker() { Latitude = Convert.ToDouble(row["Latitude"]), Longitude = Convert.ToDouble(row["Longitude"]) });
                }
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers = userMarker;

            }
        }

    }
}