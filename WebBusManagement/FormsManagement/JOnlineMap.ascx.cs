using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Zone;
using BusManagment.Line;

namespace WebBusManagement.FormsManagement
{
    public partial class JOnlineMap : System.Web.UI.UserControl
    {
        public string CheckBoxListStr = "";
        public string CheckBoxListScript = "";
        public string CheckBoxBusCodeArray = "";
        public string ZonesCmbStr = "", LinesCmbStr = "";
        public string LastAvlTransactionStr = "";
        //public int GmtMintePlus = 210;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JOnlineMap.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 30;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = true;
            if (!IsPostBack)
            {
                object[] res = LoadBuses(new object[] { "", "0", "0" });
                if (res[1].ToString() != null && res[1].ToString() != "")
                {
                    CheckBoxListStr = res[1].ToString();
                }
                if (res[0].ToString() != null && res[0].ToString() != "")
                {
                    CheckBoxListScript = res[0].ToString();
                }
                if (res[2].ToString() != null && res[2].ToString() != "")
                {
                    CheckBoxBusCodeArray = res[2].ToString();
                }
            }

            ZonesCmbStr = LoadZonesCmb();
            LinesCmbStr = LoadLinesCmb();
            object[] LastAvlObject = LoadLastBusAvlTransaction(new object[] { "" });
            LastAvlTransactionStr = LastAvlObject[0].ToString();

            OnlineMapActionString.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JOnlineMap.LoadBuses");
            OnlineMapLastAvlActionString.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JOnlineMap.LoadLastBusAvlTransaction");

            //string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            //if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            //{
            //    GmtMintePlus = 270;
            //}

        }

        public string[] GetBusTrepassOfLineToday()
        {
            string[] ResBusCode = { };
            DataTable DtBuses = new DataTable();
            DtBuses = WebClassLibrary.JWebDataBase.GetDataTable(@"select distinct BusCode from AUTAvlTransaction
                                                                    where convert(date,EventDate) = convert(date,getdate())
                                                                    and DistanceFromLine > (select KeyValue from AUTSettings where KeyName = 'TrepassOfLineMeter')
                                                                    group by BusCode");
            for (int i = 0; i < DtBuses.Rows.Count; i++)
            {
                ResBusCode[i] = DtBuses.Rows[i]["BusCode"].ToString();
            }
            return ResBusCode;
        }

        public string[] GetBusDelayInStartToday()
        {
            string[] ResBusCode = { };
            DataTable DtBuses = new DataTable();
            DtBuses = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from (select BusCode,min(eventdate)MEventDate from AUTAvlTransaction
                                                                    where convert(date,EventDate) = convert(date,getdate())
                                                                    group by BusCode)Top1StopTime 
                                                                    where convert(time,MEventDate) > (select KeyValue from AUTSettings where KeyName = 'BusStartTime')");
            for (int i = 0; i < DtBuses.Rows.Count; i++)
            {
                ResBusCode[i] = DtBuses.Rows[i]["BusCode"].ToString();
            }
            return ResBusCode;
        }

        // 
        /// <summary>
        /// ServiceAction returns map data in readable format for JOpenLayersMap control.
        /// </summary>
        /// <param name="param">JOpenLayersMap data in String Array</param>
        /// <returns>String Array in readable format for JOpenLayersMap control.</returns>
        public string[] ServiceAction(string[] param)
        {
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
            if (param[0].ToString() == "MapData")
            {
                DataTable DtMarkers = new DataTable();

                string Param1Str = "";
                string[] BusNumerForBusCount = new string[0];
                if (param[1].ToString().Length > 1 && param[1].ToLower().ToString() != "all")
                {
                    Param1Str = param[1].ToString().Remove(0, 1);
                    BusNumerForBusCount = Param1Str.Split(',');
                }
                else
                {
                    Param1Str = "all";
                    Array.Resize(ref BusNumerForBusCount, 2);
                    BusNumerForBusCount[0] = "all";
                    BusNumerForBusCount[1] = "bus";
                }

                string[] MapSettingStr;
                string MapSettingWhereStr = "";

                //For Dont show Bus When Last Avl Date Before 1 Hour Ago
                string StrWhereBusesNoAvlTransactionInOneHourAgo = " and bus.LastDate > dateadd(hour,-24,getdate()) ";

                bool ShowStation = false, XMeterDistanceFromLine = false, OverStopTime = false, OneRetardation = false, BusesNoAvlTransactionInOneHourAgo = false;

                int TrueSpeed = 0;
                try
                {
                    TrueSpeed = Convert.ToInt32(WebClassLibrary.JWebDataBase.GetDataTable(@"select KeyValue from AUTSettings where KeyName = 'SpeedLimit'").Rows[0][0].ToString());
                }
                catch { }

                if (param[2].ToString() != "" && param[2].ToString() != null)
                {

                    MapSettingStr = param[2].ToString().Remove(0, 1).Split(',');
                    for (int i = 0; i < MapSettingStr.Length; i++)
                    {
                        //if (MapSettingStr[i].ToString() == "BusesOnBattery")
                        //{
                        //    MapSettingWhereStr += " and BatteryCharge < 400000";
                        //}
                        //else 
                        if (MapSettingStr[i].ToString() == "BusesUnder1000Toman")
                        {
                            MapSettingWhereStr += " and SimCardCharge < 10000";
                        }
                        else if (MapSettingStr[i].ToString() == "ShowStation")
                        {
                            ShowStation = true;
                        }
                        // else if (MapSettingStr[i].ToString() == "OverStopTime")
                        //  {
                        //string[] AllBusFromMap01;
                        //AllBusFromMap01 = Param1Str.Split(',');
                        //string[] AllBusDelayInStartToday = GetBusDelayInStartToday();
                        //Param1Str = "";
                        //OverStopTime = true;
                        //if (AllBusDelayInStartToday.Length > 0)
                        //{
                        //    for (int j = 0; j < AllBusFromMap01.Length; j++)
                        //    {
                        //        for (int k = 0; k < AllBusDelayInStartToday.Length; k++)
                        //        {
                        //            if (AllBusFromMap01[j] == AllBusDelayInStartToday[j])
                        //            {
                        //                Param1Str += "," + AllBusFromMap01[j];
                        //            }
                        //        }
                        //    }
                        //    Param1Str = Param1Str.ToString().Remove(0, 1);
                        //}
                        // }
                        //  else if (MapSettingStr[i].ToString() == "OneRetardation")
                        //  {
                        //string[] AllBusFromMap;
                        //AllBusFromMap = Param1Str.Split(',');
                        //string[] AllBusTrepassOfLineToday = GetBusTrepassOfLineToday();
                        //Param1Str = "";
                        //OneRetardation = true;
                        //if (AllBusTrepassOfLineToday.Length > 0)
                        //{
                        //    for (int j = 0; j < AllBusFromMap.Length; j++)
                        //    {
                        //        for (int k = 0; k < AllBusTrepassOfLineToday.Length; k++)
                        //        {
                        //            if (AllBusFromMap[j] == AllBusTrepassOfLineToday[j])
                        //            {
                        //                Param1Str += "," + AllBusFromMap[j];
                        //            }
                        //        }
                        //    }
                        //    Param1Str = Param1Str.ToString().Remove(0, 1);
                        //}
                        // }
                        //else if (MapSettingStr[i].ToString().Substring(0, 6) == "XMeter")
                        //{
                        //    XMeterDistanceFromLine = true;
                        //    MapSettingWhereStr += " and at.DistanceFromLine > " + MapSettingStr[i].ToString().Split(':')[1].ToString();
                        //}
                        else if (MapSettingStr[i].ToString() == "BusesNoAvlTransactionInOneHourAgo")
                        {
                            BusesNoAvlTransactionInOneHourAgo = true;
                            StrWhereBusesNoAvlTransactionInOneHourAgo = " ";
                        }
                    }
                }

                string MarkersQuery = "";
                bool ConvertDateInQuery = true;

                string Param1StrWhere = "";
                bool StationFilterByLine = false;
                if (Param1Str != "0" && Param1Str.ToLower() != "all")
                {
                    Param1StrWhere = " and bus.Code in (" + Param1Str + ") ";
                    StationFilterByLine = true;

                }


                string PermitionSqlZone = " And " + ClassLibrary.JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "al.ZoneCode");
                if (PermitionSqlZone.Length < 5)
                {
                    PermitionSqlZone = "";
                }

                if (BusNumerForBusCount.Length == 1)
                {
                    ConvertDateInQuery = true;
                    MarkersQuery = @"SELECT bus.Code
                                    ,ISNULL(bus.BUSNumber, 0) as BUSNumber
                                    ,bus.LastCourse as Course
                                    ,bus.LastLatitude as Latitude
                                    ,bus.LastLongitude as Longitude
                                    ,bus.LastBatteryCharge AS BatteryCharge, bus.LastSimCardCharge AS SimCardCharge 
                                    ,bus.LastDate
                                    ,bus.LastSpeed
                                    ,al.LineNumber,al.ZoneCode
                                    FROM AUTBus bus
									left join AUTLine al on al.LineNumber = bus.LastLineNumber
                                    WHERE 1 = 1 " + Param1StrWhere + @" and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "bus.Code") + @"
                                    and bus.LastLatitude is not null and bus.LastLatitude>0 and bus.LastLongitude is not null and bus.LastLongitude>0 and bus.active=1 and bus.isvalid = 1 ";
                }
                else if (BusNumerForBusCount.Length > 1)
                {
                    ConvertDateInQuery = true;
                    MarkersQuery = @"SELECT distinct bus.Code
                                    ,bus.CarCode as CarCode
                                    ,ISNULL(bus.BUSNumber, 0) as BUSNumber
                                    ,bus.LastCourse as Course
                                    ,bus.LastLatitude as Latitude
                                    ,bus.LastLongitude as Longitude
                                    ,bus.LastBatteryCharge AS BatteryCharge, bus.LastSimCardCharge AS SimCardCharge 
                                    ,bus.LastDate
                                    ,bus.LastSpeed
                                   ,al.LineNumber,al.ZoneCode
                                    FROM AUTBus bus
                                    left join AUTLine al on al.LineNumber = bus.LastLineNumber
                                    WHERE 1 = 1  and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "bus.Code")
                                    +@" " + Param1StrWhere + @" " + StrWhereBusesNoAvlTransactionInOneHourAgo + " "
                                    + MapSettingWhereStr +
                                    @" and bus.LastLatitude is not null and bus.LastLatitude>0 and bus.LastLongitude is not null and bus.LastLongitude>0
                                       and Len(bus.BUSNumber)=4 and bus.BUSNumber between 1000 and 6999 and bus.active=1 and bus.isvalid = 1 ";
                }
                else
                {
                    return new string[] { " " };
                }

                DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(MarkersQuery, ConvertDateInQuery);
                //DtMarkers = null;

                bool ShowStationModeFlag = false;

                if (DtMarkers != null)
                {
                    for (int i = 0; i < DtMarkers.Rows.Count; i++)
                    {

                        //if (BusNumerForBusCount.Length == 1)
                        //{
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString(),
                        //    @"<div style=""width:100%;height:100%;text-align:center;color: white;text-shadow:-1px -1px 0 #000,1px -1px 0 #000,-1px 1px 0 #000,1px 1px 0 #000;"">" + DtMarkers.Rows[i]["BUSNumber"].ToString() + "</div>",
                        //    "../WebBusManagement/Images/bus_s64.png", 48, 32, 90, 20,
                        //    Convert.ToDateTime(DtMarkers.Rows[i]["EventDate"].ToString()), Convert.ToInt32(DtMarkers.Rows[i]["SecoundFromPrePoint"].ToString())));
                        //}
                        //else
                        //{

                        // MARKER: Movement direction arrows
                        //string direction_arrow = "", bus_icon = "";
                        int course = Convert.ToInt32(DtMarkers.Rows[i]["Course"]) * 2;
                        int LastSpeed = Convert.ToInt32(DtMarkers.Rows[i]["LastSpeed"]);
                        //if (course >= 330 || course < 30)
                        //{// Up
                        //    direction_arrow = "arrow_up.png";
                        //    bus_icon = "bus_s64_right.png";
                        //}
                        //else if (course >= 30 && course < 60)
                        //{// Up Right
                        //    direction_arrow = "arrow_upright.png";
                        //    bus_icon = "bus_s64_right.png";
                        //}
                        //else if (course >= 60 && course < 120)
                        //{// Right
                        //    direction_arrow = "arrow_right.png";
                        //    bus_icon = "bus_s64_right.png";
                        //}
                        //else if (course >= 120 && course < 150)
                        //{// Down Right
                        //    direction_arrow = "arrow_downright.png";
                        //    bus_icon = "bus_s64_right.png";
                        //}
                        //else if (course >= 150 && course < 210)
                        //{// Down
                        //    direction_arrow = "arrow_down.png";
                        //    bus_icon = "bus_s64.png";
                        //}
                        //else if (course >= 210 && course < 240)
                        //{// Down Left
                        //    direction_arrow = "arrow_downleft.png";
                        //    bus_icon = "bus_s64.png";
                        //}
                        //else if (course >= 240 && course < 300)      // Left
                        //{
                        //    direction_arrow = "arrow_left.png";
                        //    bus_icon = "bus_s64.png";
                        //}
                        //else if (course >= 300 && course < 330)
                        //{// Up Left
                        //    direction_arrow = "arrow_upleft.png";
                        //    bus_icon = "bus_s64.png";
                        //}

                        mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                            Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), "Bus_" + DtMarkers.Rows[i]["BUSNumber"].ToString(),
                            DtMarkers.Rows[i]["BUSNumber"].ToString(),
                            course.ToString(), 48, 32, 70, 20, DateTime.Now, -1));

                        //LoadBusIconImage(Convert.ToInt32(DtMarkers.Rows[i]["CarCode"].ToString()), course)

                        //mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_MarkerTitle",
                        //    DtMarkers.Rows[i]["BUSNumber"].ToString(),
                        //    "", 0, 0, 50, 20, DateTime.Now, -1));


                        //Over Stop Time Today
                        //if (OverStopTime == true)
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //        Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_OverStopTime",
                        //        "",
                        //        "../WebBusManagement/Images/stoptime_clock.gif", 72, 48, 90, 20, DateTime.Now, -1));

                        // MARKER: Battery Low
                        //int battery_charge = 0;
                        //int.TryParse(DtMarkers.Rows[i]["BatteryCharge"].ToString(), out battery_charge);
                        //if (battery_charge < 3600)
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //        Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_batterylow",
                        //        "",
                        //        "../WebBusManagement/Images/battery_low.gif", 72, 48, 90, 20, DateTime.Now, -1));

                        // MARKER: SmiCardCharge Low
                        int simcard_charge = 0;
                        int.TryParse(DtMarkers.Rows[i]["SimCardCharge"].ToString(), out simcard_charge);
                        if (simcard_charge < 10000)
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), "Sim_" + DtMarkers.Rows[i]["BUSNumber"].ToString(),
                                "",
                                "", 72, 48, 90, 20, DateTime.Now, -1));

                        //Dicrection Arrow
                        //mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), "Arrow_" + DtMarkers.Rows[i]["BUSNumber"].ToString(),
                        //    "",
                        //    course.ToString(), 32, 32, 90, 20, DateTime.Now, -1));

                        //One Retardation Today
                        //if (OneRetardation == true)
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //        Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_OneRetardation",
                        //        "",
                        //        "../WebBusManagement/Images/silver_circle.png", 72, 48, 90, 20, DateTime.Now, -1));

                        //XMeter Distance From Line
                        //if (XMeterDistanceFromLine == true)
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                        //        Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_XMeterDistanceFromLine",
                        //        "",
                        //        "../WebBusManagement/Images/red_circle.png", 72, 48, 90, 20, DateTime.Now, -1));

                        //Speed
                        if (LastSpeed > TrueSpeed)
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), "Speed_" + DtMarkers.Rows[i]["BUSNumber"].ToString(),
                                "",
                                "", 48, 32, 90, 20, DateTime.Now, -1));

                    }

                    //}

                }
                else if (ShowStation == true)
                {
                    ShowStationModeFlag = true;
                    // MARKER: Station marker
                    DataTable DtStation = new DataTable();
                    if (StationFilterByLine == false)
                    {
                        DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL order by Code");
                    }
                    else
                    {
                        DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where
                                                                                code in (select StationCode from AUTLineStation where LineCode in 
                                                                                (select Code from AUTLine where LineNumber in 
                                                                                (select LastLineNumber from AUTBus bus where 1 = 1 " + Param1StrWhere + @")))
                                                                                and Lat Is NOT NULL and Lng IS NOT NULL order by Code");
                    }
                    if (DtStation != null)
                    {
                        for (int i = 0; i < DtStation.Rows.Count; i++)
                        {
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                                    Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + DtStation.Rows[i]["Code"].ToString(),
                                    "",
                                    "", 24, 24, 90, 20, DateTime.Now, -1));
                        }
                    }
                    else
                    {
                        return new string[] { " " };
                    }
                }
                else
                {
                    return new string[] { " " };
                }

                if (ShowStation == true && ShowStationModeFlag == false)
                {
                    // MARKER: Station marker
                    DataTable DtStation = new DataTable();
                    if (StationFilterByLine == false)
                    {
                        DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL order by Code");
                    }
                    else
                    {
                        DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where
                                                                                code in (select StationCode from AUTLineStation where LineCode in 
                                                                                (select Code from AUTLine where LineNumber in 
                                                                                (select LastLineNumber from AUTBus bus where 1 = 1 " + Param1StrWhere + @")))
                                                                                and Lat Is NOT NULL and Lng IS NOT NULL order by Code");
                    }
                    if (DtStation != null)
                    {
                        for (int i = 0; i < DtStation.Rows.Count; i++)
                        {
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                                    Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + DtStation.Rows[i]["Code"].ToString(),
                                    "",
                                    "", 24, 24, 90, 20, DateTime.Now, -1));
                        }
                    }
                }

                return mapData.GenerateMarkerWithEventDate();

            }
            else if (param[0].ToString() == "Popup")
            {
                // POPUP: Bus description
                int busSerial = 0;
                int.TryParse(param[1].Split('_')[2], out busSerial);
                DataTable DtPopup = new DataTable();
                DtPopup = WebClassLibrary.JWebDataBase.GetDataTable(@"
                            SELECT bus.LastGsmAntenna,
	                                bus.LastGpsAntenna,
	                                bus.LastBatteryCharge,
	                                ISNULL(zone.Name, N'نامشخص') AS Zone,
	                                ISNULL(cast(bus.LastLineNumber AS nvarchar), N'نامشخص') AS Line,
	                                ISNULL(person.Name,N'ناشناس') AS Driver,
	                                bus.LastDate,
	                                bus.LastSpeed * 2 AS LastSpeed,
	                                bus.LastSimCardCharge,
	                                bus.TransactionsCount AS AvlCount,
	                                bus.MaxDistance,
	                                bus.MaxStopTime,
	                                bus.LastMaxStopTimeDate,
                                    ISNULL(bus.LastDriverPersonCode,0)LastDriverPersonCode,
	                                (select sum(TCount) from AUTDailyPerformanceRportOnBus where cast([date] as date) = cast(getdate() as date) and Cardtype = 0 and BusCode = bus.Code)TicketCount,
	                                (select sum(Price)*10 from AUTDailyPerformanceRportOnBus where cast([date] as date) = cast(getdate() as date) and Cardtype = 0 and BusCode = bus.Code)TicketSumPrice
                                FROM AUTBus bus
                                LEFT JOIN clsAllPerson person ON person.Code = bus.LastDriverPersonCode
                                LEFT JOIN AUTLine line ON line.LineNumber = bus.LastLineNumber
                                LEFT JOIN AUTZone zone ON zone.Code = line.ZoneCode
                            WHERE bus.BUSNumber = " + busSerial);

                string[] PopUpStr = new string[1];
                if (DtPopup != null)
                {
                    // Battery
                    //int batteryCharge = 0;
                    string batteryHTML = "";
                    //int.TryParse(DtPopup.Rows[0]["LastBatteryCharge"].ToString(), out batteryCharge);
                    //batteryCharge = Convert.ToInt32(Convert.ToDouble(batteryCharge - 3500 >= 0 ? batteryCharge - 3500 : 0) / 500 * 100);
                    //if (batteryCharge > 100)
                    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_direct.png"" /><br/>مستقیم";
                    //else if (batteryCharge > 90)
                    //    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_5.png"" /><br/>" + batteryCharge + " %";
                    //else if (batteryCharge > 65)
                    //    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_4.png"" /><br/>" + batteryCharge + " %";
                    //else if (batteryCharge > 35)
                    //    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_3.png"" /><br/>" + batteryCharge + " %";
                    //else if (batteryCharge > 10)
                    //    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_2.png"" /><br/>" + batteryCharge + " %";
                    //else
                    //    batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_1.png"" /><br/>" + batteryCharge + " %";
                    // GSM Antenna
                    int gsm = 0;
                    string gsmHTML = "";
                    int.TryParse(DtPopup.Rows[0]["LastGsmAntenna"].ToString(), out gsm);
                    if (gsm > 75)
                        gsmHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_4.png"" /><br/>" + gsm + " %";
                    else if (gsm > 45)
                        gsmHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_3.png"" /><br/>" + gsm + " %";
                    else if (gsm > 15)
                        gsmHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_2.png"" /><br/>" + gsm + " %";
                    else
                        gsmHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_1.png"" /><br/>" + gsm + " %";
                    // GPS Antenna
                    int gps = 0;
                    string gpsHTML = "";
                    int.TryParse(DtPopup.Rows[0]["LastGpsAntenna"].ToString(), out gps);
                    if (gps > 75)
                        gpsHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_4.png"" /><br/>" + gps + " %";
                    else if (gps > 45)
                        gpsHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_3.png"" /><br/>" + gps + " %";
                    else if (gps > 15)
                        gpsHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_2.png"" /><br/>" + gps + " %";
                    else
                        gpsHTML = @"<img src=""../WebBusManagement/Images/Anten/anten_1.png"" /><br/>" + gps + " %";


                    PopUpStr[0] = WebControllers.MainControls.OpenLayersMap.JMapData.GeneratePopup(
@"
<div style=""display:table-cell;background-color:rgba(0,0,0,0.7);width:32px;height:32px;text-align:center;vertical-align:middle""><img src=""../WebBusManagement/Images/close.png"" onclick=""{CLOSE_POPUP}""/></div>
<div style=""width:90%;height:80%;background-color:rgba(0,0,0,0.7);color:white;text-align:right;text-shadow: 4px 4px 5px #000;padding:5px;"">
<table width=""100%"">
    <tr>
        <td style=""text-align:center"">" + gpsHTML + @" GPS</td>
        <td style=""text-align:center"">" + batteryHTML + @"</td>
        <td style=""text-align:center"">" + gsmHTML + @" GSM</td>
    </tr>
</table>
<img src=""" + LoadPersonImage(Convert.ToInt32(DtPopup.Rows[0]["LastDriverPersonCode"].ToString())) + @""" style=""position:absolute;left:30px;z-index:10;width:80px;height:80px""/>
خط : " + DtPopup.Rows[0]["Line"].ToString() + @"<div style=""clear:both;height:1px""></div>
منطقه : " + DtPopup.Rows[0]["Zone"].ToString() + @"<div style=""clear:both;height:1px""></div>
اتوبوس : " + busSerial + @"<div style=""clear:both;height:1px""></div>
راننده : " + DtPopup.Rows[0]["Driver"].ToString() + @"<div style=""clear:both;height:1px""></div>
تاریخ : " + DtPopup.Rows[0]["LastDate"].ToString().Replace("<br/>", " ") + @"<div style=""clear:both;height:1px""></div>
سرعت : " + DtPopup.Rows[0]["LastSpeed"].ToString() + @"<div style=""clear:both;height:1px""></div>
شارژ سیم کارت : " + DtPopup.Rows[0]["LastSimCardCharge"].ToString() + @"<div style=""clear:both;height:1px""></div>
تعداد نقاط حرکت طی امروز : " + DtPopup.Rows[0]["AvlCount"].ToString() + @"<div style=""clear:both;height:1px""></div>
فاصله از خط : " + DtPopup.Rows[0]["MaxDistance"].ToString() + @"<div style=""clear:both;height:1px""></div>
زمان توقف : " + DtPopup.Rows[0]["MaxStopTime"].ToString() + @"<div style=""clear:both;height:1px""></div>
قیمت کل بلیط های فروخته شده امروز : " + DtPopup.Rows[0]["TicketSumPrice"].ToString() + @"<div style=""clear:both;height:1px""></div>
تعداد کارت های زده شده مسافرین از ابتدای روز : " + DtPopup.Rows[0]["TicketCount"].ToString() + @"<div style=""clear:both;height:1px""></div>
</div>", 330, 340);
                }
                return PopUpStr;
            }
            else
            {
                return null;
            }

        }


        private string LoadBusIconImage(int CarCode, int course)
        {
            if (CarCode > 0)
            {
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                try
                {
                    DataTable Dt = archive.Retrieve("AUTOMOBILE.AutomobileDefine.JAutomobileDefine", CarCode);
                    if (Dt.Rows.Count > 0)
                    {
                        ClassLibrary.JFile image = archive._RetrieveContent(Convert.ToInt32(Dt.Rows[0]["ArchiveCode"].ToString()));
                        if (image != null)
                            return "data:image/png;base64," + Convert.ToBase64String(WebClassLibrary.JDataManager.ReadToEnd(image.Stream));
                        else
                        {
                            if (course < 150)
                                return "../WebBusManagement/Images/bus_s64.png";
                            else
                                return "../WebBusManagement/Images/bus_s64_right.png";
                        }
                    }
                    else
                    {
                        if (course < 150)
                            return "../WebBusManagement/Images/bus_s64.png";
                        else
                            return "../WebBusManagement/Images/bus_s64_right.png";
                    }
                }
                catch
                {
                    if (course < 150)
                        return "../WebBusManagement/Images/bus_s64.png";
                    else
                        return "../WebBusManagement/Images/bus_s64_right.png";
                }
            }
            else
            {
                if (course < 150)
                    return "../WebBusManagement/Images/bus_s64.png";
                else
                    return "../WebBusManagement/Images/bus_s64_right.png";
            }
        }


        private string LoadPersonImage(int PersonCode)
        {
            if (PersonCode > 0)
            {
                ClassLibrary.JPerson person = new ClassLibrary.JPerson(PersonCode);
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                try
                {
                    if (archive.Retrieve(person.PersonImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            return "data:image/png;base64," + Convert.ToBase64String(WebClassLibrary.JDataManager.ReadToEnd(image.Stream));
                        else
                            return "../WebBusManagement/Images/nopersonimage.png";
                    }
                    else
                        return "../WebBusManagement/Images/nopersonimage.png";
                    //imgPerson.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage);
                }
                catch
                {
                    return "../WebBusManagement/Images/nopersonimage.png";
                }
            }
            else
            {
                return "../WebBusManagement/Images/nopersonimage.png";
            }
        }

        public object[] LoadLastBusAvlTransaction(object[] KeyWord)
        {
            object[] LastAvlTransaction = new object[1];
            DataTable DtLastAvlT = new DataTable();
            DtLastAvlT = WebClassLibrary.JWebDataBase.GetDataTable(@"select ROW_NUMBER() OVER(ORDER BY Ab.LastDate desc) AS RowNumber, 
                                                                    ISNULL(Az.Name,N'نامشخص') as ZoneName,
                                                                    ISNULL(cast(Ab.LastLineNumber as nvarchar),N'خط نامشخص')LineNumber,
                                                                    cast(Ab.BUSNumber as varchar)+N' - '+
                                                                    ISNULL(cap.Name,N'راننده ناشناس')BusNumber,
                                                                    Ab.LastDate
                                                                    from AUTBus ab
                                                                    left join AUTLine AL on Ab.LastLineNumber = Al.LineNumber
                                                                    left join AUTZone AZ on Az.Code = AL.ZoneCode
                                                                    LEFT JOIN clsAllPerson cap ON cap.Code = Ab.LastDriverPersonCode
                                                                    where len(ab.BusNumber)=4 and (ab.BusNumber between 1000 and 6999) and LastDate > dateadd(hour,-24,getdate())
                                                                    and Ab.Active=1 and " +
                                                                    ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "ab.Code") + @"
                                                                    order by Ab.LastDate desc");
            for (int i = 0; i < DtLastAvlT.Rows.Count; i++)
            {
                LastAvlTransaction[0] += @"<tr>
                <td style=""text-align:center;border: 1px solid #fff"">" + DtLastAvlT.Rows[i]["RowNumber"].ToString() + @"</td>
                <td style=""text-align:center;border: 1px solid #fff"">" + DtLastAvlT.Rows[i]["ZoneName"].ToString() + @"</td>
                <td style=""text-align:center;border: 1px solid #fff"">" + DtLastAvlT.Rows[i]["LineNumber"].ToString() + @"</td>
                <td style=""text-align:center;border: 1px solid #fff"">" + DtLastAvlT.Rows[i]["BusNumber"].ToString() + @"</td>
                <td style=""text-align:center;border: 1px solid #fff"">" + DtLastAvlT.Rows[i]["LastDate"].ToString() + @"</td>
            </tr>";
            }

            if (LastAvlTransaction[0] == "")
            {
                LastAvlTransaction[0] = "موردی یافت نشد";
            }

            return LastAvlTransaction;
        }

        public string LoadZonesCmb()
        {
            string ZonesCmb = "";
            DataTable DtZone = new DataTable();
            DtZone = JZones.GetDataTable(0);
            ZonesCmb = @"<select id=""ZonesCmb"" onChange=""CallWsLoadBus('');"">";
            ZonesCmb += @"<option value=""0"">همه ی مناطق</option>";
            for (int i = 0; i < DtZone.Rows.Count; i++)
            {
                    ZonesCmb += @"<option value=""" + DtZone.Rows[i]["Code"].ToString() + @""">" + DtZone.Rows[i]["Name"].ToString() + @"</option>";
            }
            ZonesCmb += @"</select>";
            return ZonesCmb;
        }

        public string LoadLinesCmb()
        {
            string LinesCmb = "";
            DataTable DtLine = new DataTable();
            DtLine = JLines.GetSimpletWebDataTable(0);
            LinesCmb = @"<select id=""LinesCmb"" onChange=""CallWsLoadBus('');"">";
            LinesCmb += @"<option value=""0"">همه ی خطوط</option>";
            for (int i = 0; i < DtLine.Rows.Count; i++)
            {
                    LinesCmb += @"<option value=""" + DtLine.Rows[i]["Code"].ToString() + @""">" + DtLine.Rows[i]["lineName"].ToString() + @"</option>";
            }
            LinesCmb += @"</select>";
            return LinesCmb;
        }


        public object[] LoadBuses(object[] KeyWord)
        {
            object[] Result = new object[3];

            string WhereStr = " Where Bus.Active = 1 ";
            if (KeyWord[0].ToString() != null && KeyWord[0].ToString() != "")
            {
                WhereStr += @" and (BusNumber like '%" + KeyWord[0].ToString() + @"%' 
                             or 
                             LineNumber like '%" + KeyWord[0].ToString() + @"%'
                             or
                             clsAllPerson.Name like '%" + KeyWord[0].ToString() + @"%') ";
            }
            if (KeyWord[1].ToString() != "0")
            {
                WhereStr += @" and (dbo.AUTZone.Code=" + KeyWord[1].ToString() + @") ";
            }

            if (KeyWord[2].ToString() != "0")
            {
                WhereStr += @" and (dbo.AUTLine.Code=" + KeyWord[2].ToString() + @") ";
            }

            string Query = @"select Bus.Code as Code,Bus.BusNumber,
                                    ISNULL(cast(Bus.LastLineNumber as nvarchar),N'نامشخص')LineNumber,
                                    ISNULL(dbo.clsAllPerson.Name,N'ناشناس')Name 
                                    from dbo.AUTBus Bus
                                    left join dbo.AUTLine on Bus.LastLineNumber = dbo.AUTLine.LineNumber
                                    left join dbo.AUTZone on dbo.AUTLine.ZoneCode = dbo.AUTZone.Code
                                    left join dbo.clsAllPerson on dbo.clsAllPerson.code = Bus.LastDriverPersonCode
                                    " + WhereStr + " and " +
                                    ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "Bus.Code")
                                    + @"  Order By Bus.BusNumber ASC";

            DataTable Buses = WebClassLibrary.JWebDataBase.GetDataTable(Query);

            int i = 0;
            Result[0] = "function SetEnableCheckBox(Enable){";
            Result[1] = "";
            Result[2] = "";
            for (i = 0; i < Buses.Rows.Count; i++)
            {
                Result[1] += @"<br /><input type=""checkbox"" id=""ckhBus" + Buses.Rows[i]["Code"].ToString() +
                    @""" checked=""checked"" onchange=""CreateStrServiceParamFromCkhBus();""/>" + "اتوبوس " + Buses.Rows[i]["BusNumber"].ToString() + " - " + "خط " +
                    Buses.Rows[i]["LineNumber"].ToString() + " - " + Buses.Rows[i]["Name"].ToString();
                Result[0] += @"$(""#ckhBus" + Buses.Rows[i]["Code"].ToString() + @""").attr(""disabled"", Enable);";
                Result[2] += @"CkhBusCode[" + i + "]=" + Buses.Rows[i]["Code"].ToString() + ";";
            }
            Result[0] += "}SetEnableCheckBox(true);ChkBusCount=" + Buses.Rows.Count + ";";

            if (Result[1] == "")
            {
                Result[1] = "موردی یافت نشد";
            }

            return Result;
        }

    }
}