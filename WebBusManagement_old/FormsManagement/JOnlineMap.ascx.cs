using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Zone;

namespace WebBusManagement.FormsManagement
{
    public partial class JOnlineMap : System.Web.UI.UserControl
    {
        public string CheckBoxListStr = "";
        public string CheckBoxListScript = "";
        public string CheckBoxBusCodeArray = "";
        public string ZonesCmbStr = "";
        public string LastAvlTransactionStr = "";
        //public int GmtMintePlus = 210;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JOnlineMap.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 800;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = true;
            if (!IsPostBack)
            {
                object[] res = LoadBuses(new object[] { "", "0" });
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
                if (param[1].ToString().Length > 1)
                {
                    Param1Str = param[1].ToString().Remove(0, 1);
                    BusNumerForBusCount = Param1Str.Split(',');
                }

                string[] MapSettingStr;
                string MapSettingWhereStr = "";

                //For Dont show Bus When Last Avl Date Before 1 Hour Ago
                string StrWhereBusesNoAvlTransactionInOneHourAgo = " and bus.LastDate > dateadd(hour,-1,getdate()) ";

                bool ShowStation = false, XMeterDistanceFromLine = false, OverStopTime = false, OneRetardation = false, BusesNoAvlTransactionInOneHourAgo = false;

                if (param[2].ToString() != "" && param[2].ToString() != null)
                {

                    MapSettingStr = param[2].ToString().Remove(0, 1).Split(',');
                    for (int i = 0; i < MapSettingStr.Length; i++)
                    {
                        if (MapSettingStr[i].ToString() == "BusesOnBattery")
                        {
                            MapSettingWhereStr += " and BatteryCharge < 4000";
                        }
                        else if (MapSettingStr[i].ToString() == "BusesUnder1000Toman")
                        {
                            MapSettingWhereStr += " and SimCardCharge < 10000";
                        }
                        else if (MapSettingStr[i].ToString() == "ShowStation")
                        {
                            ShowStation = true;
                        }
                        else if (MapSettingStr[i].ToString() == "OverStopTime")
                        {
                            string[] AllBusFromMap01;
                            AllBusFromMap01 = Param1Str.Split(',');
                            string[] AllBusDelayInStartToday = GetBusDelayInStartToday();
                            Param1Str = "";
                            OverStopTime = true;
                            if (AllBusDelayInStartToday.Length > 0)
                            {
                                for (int j = 0; j < AllBusFromMap01.Length; j++)
                                {
                                    for (int k = 0; k < AllBusDelayInStartToday.Length; k++)
                                    {
                                        if (AllBusFromMap01[j] == AllBusDelayInStartToday[j])
                                        {
                                            Param1Str += "," + AllBusFromMap01[j];
                                        }
                                    }
                                }
                                Param1Str = Param1Str.ToString().Remove(0, 1);
                            }
                        }
                        else if (MapSettingStr[i].ToString() == "OneRetardation")
                        {
                            string[] AllBusFromMap;
                            AllBusFromMap = Param1Str.Split(',');
                            string[] AllBusTrepassOfLineToday = GetBusTrepassOfLineToday();
                            Param1Str = "";
                            OneRetardation = true;
                            if (AllBusTrepassOfLineToday.Length > 0)
                            {
                                for (int j = 0; j < AllBusFromMap.Length; j++)
                                {
                                    for (int k = 0; k < AllBusTrepassOfLineToday.Length; k++)
                                    {
                                        if (AllBusFromMap[j] == AllBusTrepassOfLineToday[j])
                                        {
                                            Param1Str += "," + AllBusFromMap[j];
                                        }
                                    }
                                }
                                Param1Str = Param1Str.ToString().Remove(0, 1);
                            }
                        }
                        else if (MapSettingStr[i].ToString().Substring(0, 6) == "XMeter")
                        {
                            XMeterDistanceFromLine = true;
                            MapSettingWhereStr += " and at.DistanceFromLine > " + MapSettingStr[i].ToString().Split(':')[1].ToString();
                        }
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
                if (Param1Str != "0")
                {
                    Param1StrWhere = " and bus.Code in (" + Param1Str + ") ";
                }

                if (BusNumerForBusCount.Length > 1)
                {
                    ConvertDateInQuery = true;
                    MarkersQuery = @"SELECT distinct bus.Code
                                    ,ISNULL(bus.BUSNumber, 0) as BUSNumber
                                    ,bus.LastCourse as Course
                                    ,bus.LastLatitude as Latitude
                                    ,bus.LastLongitude as Longitude
                                    ,at.BatteryCharge, at.SimCardCharge 
                                    ,bus.LastDate
                                    FROM AUTBus bus
                                    LEFT JOIN AUTAvlTransaction at ON at.EventDate = bus.LastDate AND at.BusCode = bus.Code
                                    WHERE 1 = 1 " + Param1StrWhere + @" " + StrWhereBusesNoAvlTransactionInOneHourAgo + " "
                                    + MapSettingWhereStr +
                                    @" and bus.LastLatitude is not null and bus.LastLatitude>0 and bus.LastLongitude is not null and bus.LastLongitude>0 ";
                }
                else if (BusNumerForBusCount.Length == 1)
                {
                    ConvertDateInQuery = false;
                    if (param[3].ToString() == "0")
                    {
                        MarkersQuery = @"SELECT aavl.Code,ab.BUSNumber,aavl.Course,aavl.Latitude,aavl.Longitude,aavl.BatteryCharge,aavl.SimCardCharge,
                                        aavl.EventDate,
                                        ISNULL(
                                        DATEDIFF(second,
                                        aavl.EventDate
                                        ,
                                        (SELECT TOP 1 a.EventDate FROM AUTAvlTransaction a WHERE a.BusCode IN (" + Param1Str + @") and
                                        a.EventDate > aavl.EventDate ORDER BY a.EventDate)
                                        ),0)SecoundFromPrePoint
                                        FROM AUTAvlTransaction aavl
                                        LEFT JOIN AUTBus ab ON aavl.BusCode = ab.Code
                                        where aavl.BusCode IN (" + Param1Str + @")
                                        and aavl.EventDate > dateadd(minute,-1,GETDATE())
                                        and aavl.Latitude is not null and aavl.Latitude>0 and aavl.Longitude is not null and aavl.Longitude>0
                                        ORDER BY aavl.EventDate ASC";
                    }
                    else
                    {
                        MarkersQuery = @"SELECT aavl.Code,ab.BUSNumber,aavl.Course,aavl.Latitude,aavl.Longitude,aavl.BatteryCharge,aavl.SimCardCharge,
                                        aavl.EventDate,
                                        ISNULL(
                                        DATEDIFF(second,
                                        aavl.EventDate
                                        ,
                                        (SELECT TOP 1 a.EventDate FROM AUTAvlTransaction a WHERE a.BusCode IN (" + Param1Str + @") and 
                                        a.EventDate > aavl.EventDate ORDER BY a.EventDate)
                                        ),0)SecoundFromPrePoint
                                        FROM AUTAvlTransaction aavl
                                        LEFT JOIN AUTBus ab ON aavl.BusCode = ab.Code
                                        where aavl.BusCode IN (" + Param1Str + @")
                                        and aavl.EventDate > '" + param[3].ToString() + @"'
                                        and aavl.Latitude is not null and aavl.Latitude>0 and aavl.Longitude is not null and aavl.Longitude>0
                                        ORDER BY aavl.EventDate ASC";
                    }
                }
                else
                {
                    return null;
                }

                DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(MarkersQuery, ConvertDateInQuery);
                //                DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT top 100 percent avl.Code
                //                                                                              ,ISNULL(a.BUSNumber, 0) as BUSNumber
                //                                                                              ,avl.Latitude
                //                                                                              ,avl.Longitude
                //                                                                        FROM   AUTAvlTransaction avl
                //                                                                               INNER JOIN AUTBus a
                //                                                                                    ON  avl.BusCode = a.Code
                //                                                                        WHERE avl.Code IN (SELECT MAX(Code) FROM AUTAvlTransaction aa GROUP BY aa.BusCode) 
                //                                                                        and a.Code in (" + Param1Str + @")
                //                                                                        order by avl.EventDate desc");

                if (DtMarkers != null)
                {
                    for (int i = 0; i < DtMarkers.Rows.Count; i++)
                    {

                        if (BusNumerForBusCount.Length == 1)
                        {
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                            Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString(),
                            @"<div style=""width:100%;height:100%;text-align:center;color: white;text-shadow:-1px -1px 0 #000,1px -1px 0 #000,-1px 1px 0 #000,1px 1px 0 #000;"">" + DtMarkers.Rows[i]["BUSNumber"].ToString() + "</div>",
                            "../WebBusManagement/Images/bus_s64.png", 48, 32, 90, 20,
                            Convert.ToDateTime(DtMarkers.Rows[i]["EventDate"].ToString()), Convert.ToInt32(DtMarkers.Rows[i]["SecoundFromPrePoint"].ToString())));
                        }
                        else
                        {
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString(),
                                @"<div style=""width:100%;height:100%;text-align:center;color: white;text-shadow:-1px -1px 0 #000,1px -1px 0 #000,-1px 1px 0 #000,1px 1px 0 #000;"">" + DtMarkers.Rows[i]["BUSNumber"].ToString() + "</div>",
                                "../WebBusManagement/Images/bus_s64.png", 48, 32, 90, 20, DateTime.Now, -1));


                            //Over Stop Time Today
                            if (OverStopTime == true)
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_OverStopTime",
                                    "",
                                    "../WebBusManagement/Images/stoptime_clock.gif", 72, 48, 90, 20, DateTime.Now, -1));

                            // MARKER: Battery Low
                            int battery_charge = 0;
                            int.TryParse(DtMarkers.Rows[i]["BatteryCharge"].ToString(), out battery_charge);
                            if (battery_charge < 3600)
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_batterylow",
                                    "",
                                    "../WebBusManagement/Images/battery_low.gif", 72, 48, 90, 20, DateTime.Now, -1));

                            // MARKER: SmiCardCharge Low
                            int simcard_charge = 0;
                            int.TryParse(DtMarkers.Rows[i]["SimCardCharge"].ToString(), out simcard_charge);
                            if (simcard_charge < 10000)
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_simcardchargelow",
                                    "",
                                    "../WebBusManagement/Images/simcardcharge_low.gif", 72, 48, 90, 20, DateTime.Now, -1));

                            // MARKER: Movement direction arrows
                            string direction_arrow = "";
                            int course = Convert.ToInt32(DtMarkers.Rows[i]["Course"]) * 2;
                            if (course >= 330 || course < 30)           // Up
                                direction_arrow = "arrow_up.png";
                            else if (course >= 30 && course < 60)       // Up Right
                                direction_arrow = "arrow_upright.png";
                            else if (course >= 60 && course < 120)      // Right
                                direction_arrow = "arrow_right.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                direction_arrow = "arrow_downright.png";
                            else if (course >= 150 && course < 210)      // Down
                                direction_arrow = "arrow_down.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                direction_arrow = "arrow_downleft.png";
                            else if (course >= 240 && course < 300)      // Left
                                direction_arrow = "arrow_left.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                direction_arrow = "arrow_upleft.png";
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_arrow",
                                "",
                                "../WebBusManagement/Images/Arrow/" + direction_arrow, 32, 32, 90, 20, DateTime.Now, -1));

                            //One Retardation Today
                            if (OneRetardation == true)
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_OneRetardation",
                                    "",
                                    "../WebBusManagement/Images/silver_circle.png", 72, 48, 90, 20, DateTime.Now, -1));

                            //XMeter Distance From Line
                            if (XMeterDistanceFromLine == true)
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["BUSNumber"].ToString() + "_XMeterDistanceFromLine",
                                    "",
                                    "../WebBusManagement/Images/red_circle.png", 72, 48, 90, 20, DateTime.Now, -1));
                        }

                    }
                }


                // MARKER: Station marker
                if (BusNumerForBusCount.Length > 1)
                {
                    if (ShowStation == true)
                    {
                        DataTable DtStation = new DataTable();
                        DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 percent Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation]");
                        if (DtStation != null)
                        {
                            for (int i = 0; i < DtStation.Rows.Count; i++)
                            {
                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarkerWithEventDate(Convert.ToSingle(DtStation.Rows[i]["Lat"]),
                                        Convert.ToSingle(DtStation.Rows[i]["Lng"]), DtStation.Rows[i]["Code"].ToString(),
                                        @"<div style=""width:100%;height:100%;text-align:center"">" + DtStation.Rows[i]["Name"].ToString() + "</div>",
                                        "../WebBusManagement/Images/station_s64.png", 32, 32, 90, 20, DateTime.Now, -1));
                            }
                        }
                    }
                }

                return mapData.GenerateMarkerWithEventDate();

            }
            else if (param[0].ToString() == "Popup")
            {
                // POPUP: Bus description
                int busSerial = 0;
                int.TryParse(param[1].Split('_')[0], out busSerial);
                DataTable DtPopup = new DataTable();
                DtPopup = WebClassLibrary.JWebDataBase.GetDataTable(@"
                            SELECT bus.LastGsmAntenna,
	                                bus.LastGpsAntenna,
	                                bus.LastBatteryCharge,
	                                ISNULL(zone.Name, N'نامشخص') AS Zone,
	                                ISNULL(CAST(line.LineNumber AS NVARCHAR) + ' - ' + line.LineName, N'نامشخص') AS Line,
	                                ISNULL(person.Name,N'ناشناس') AS Driver,
	                                bus.LastDate,
	                                bus.LastSpeed * 2 AS LastSpeed,
	                                bus.LastSimCardCharge,
	                                (SELECT COUNT(*) FROM AUTAvlTransaction at WHERE CAST(at.EventDate AS Date) = CAST(GETDATE() AS Date) AND at.BusCode=bus.Code) AS AvlCount,
	                                bus.MaxDistance,
	                                bus.MaxStopTime,
	                                bus.LastMaxStopTimeDate,
	                                bus.TicketCount,
	                                bus.TicketSumPrice
                                FROM AUTBus bus
                                LEFT JOIN (SELECT * FROM AUTFleetBusStatus abs1 WHERE abs1.Code IN
                                            (SELECT TOP 1 tbl.Code FROM 
	                                            (SELECT TOP 100 PERCENT * FROM AUTFleetBusStatus ORDER BY ReceiveDate) tbl
                                            GROUP BY tbl.BusCode,tbl.Code)) busstatus ON busstatus.BusCode = bus.Code
                                LEFT JOIN clsAllPerson person ON person.Code = busstatus.PersonCode
                                LEFT JOIN AUTLine line ON line.Code = busstatus.LineCode
                                LEFT JOIN AUTZone zone ON zone.Code = line.ZoneCode
                            WHERE bus.BUSNumber = " + busSerial);

                string[] PopUpStr = new string[1];
                if (DtPopup != null)
                {
                    // Battery
                    int batteryCharge = 0;
                    string batteryHTML = "";
                    int.TryParse(DtPopup.Rows[0]["LastBatteryCharge"].ToString(), out batteryCharge);
                    batteryCharge = Convert.ToInt32(Convert.ToDouble(batteryCharge - 3500 >= 0 ? batteryCharge - 3500 : 0) / 500 * 100);
                    if (batteryCharge > 100)
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_direct.png"" /><br/>مستقیم";
                    else if (batteryCharge > 90)
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_5.png"" /><br/>" + batteryCharge + " %";
                    else if (batteryCharge > 65)
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_4.png"" /><br/>" + batteryCharge + " %";
                    else if (batteryCharge > 35)
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_3.png"" /><br/>" + batteryCharge + " %";
                    else if (batteryCharge > 10)
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_2.png"" /><br/>" + batteryCharge + " %";
                    else
                        batteryHTML = @"<img src=""../WebBusManagement/Images/Battery/battery_1.png"" /><br/>" + batteryCharge + " %";
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
<div style=""width:100%;height:100%;background-color:rgba(0,0,0,0.7);color:white;text-align:right;text-shadow: 4px 4px 5px #000;box-shadow: 10px 10px 5px #000;padding:5px;"">
<table width=""100%"">
    <tr>
        <td style=""text-align:center"">" + gpsHTML + @" GPS</td>
        <td style=""text-align:center"">" + batteryHTML + @"</td>
        <td style=""text-align:center"">" + gsmHTML + @" GSM</td>
    </tr>
</table>
<img src=""../WebBusManagement/Images/nopersonimage.png"" style=""position:absolute;left:0px;z-index:10""/>
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
</div>", 310, 340);
                }
                return PopUpStr;
            }
            else
            {
                return null;
            }

        }

        public object[] LoadLastBusAvlTransaction(object[] KeyWord)
        {
            object[] LastAvlTransaction = new object[1];
            DataTable DtLastAvlT = new DataTable();
            DtLastAvlT = WebClassLibrary.JWebDataBase.GetDataTable(@"select ROW_NUMBER() OVER(ORDER BY Ab.LastDate desc) AS RowNumber, 
                                                                    ISNULL(Az.Name,N'نامشخص') as ZoneName,
                                                                    ISNULL(cast(Ab.LineNumber as nvarchar),N'خط نامشخص')LineNumber,
                                                                    cast(Ab.BUSNumber as varchar)+N' - '+
                                                                    ISNULL(Ab.DriverPersonName,N'راننده ناشناس')BusNumber,
                                                                    Ab.LastDate
                                                                    from (select Ab.*,(select top 1 AUTT.LineNumber from AUTTicketTransaction AUTT
                                                                    where AUTT.BusCode = Ab.Code
                                                                    order by AUTT.EventDate desc)LineNumber,(select top 1 AUTT.DriverPersonName from AUTTicketTransaction AUTT
                                                                    where AUTT.BusCode = Ab.Code
                                                                    order by AUTT.EventDate desc)DriverPersonName from AUTBus Ab) Ab
                                                                    left join AUTLine AL on Ab.LineNumber = Al.LineNumber
                                                                    left join AUTZone AZ on Az.Code = AL.ZoneCode
                                                                    where Ab.Active=1
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
            ZonesCmb = @"<select id=""ZonesCmb"" onChange=""CallWsLoadBus();"">";
            for (int i = 0; i < DtZone.Rows.Count; i++)
            {
                if (i == 0)
                {
                    ZonesCmb += @"<option value=""0"">همه ی مناطق</option>";
                }
                else
                {
                    ZonesCmb += @"<option value=""" + DtZone.Rows[i]["Code"].ToString() + @""">" + DtZone.Rows[i]["Name"].ToString() + @"</option>";
                }
            }
            ZonesCmb += @"</select>";
            return ZonesCmb;
        }


        public object[] LoadBuses(object[] KeyWord)
        {
            object[] Result = new object[3];

            string WhereStr = " Where 1=1 ";
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

            string Query = @"select Bus.Code as Code,Bus.BusNumber,
                                    ISNULL(cast(AUTLine.LineNumber as nvarchar),N'نامشخص')LineNumber,
                                    ISNULL(dbo.clsAllPerson.Name,N'ناشناس')Name 
                                    from dbo.AUTBus Bus Left join
                                    (select buscode,max(linecode)linecode,max(personcode)personcode,max(startdate)startdate 
                                    from dbo.AUTFleetBusStatus group by buscode) bss  on Bus.CarCode = bss.buscode
                                    left join dbo.AUTLine on bss.linecode = dbo.AUTLine.code
                                    left join dbo.AUTZone on dbo.AUTLine.ZoneCode = dbo.AUTZone.Code
                                    left join dbo.clsAllPerson on dbo.clsAllPerson.code = bss.personcode
                                    " + WhereStr + "Order By Bus.BusNumber ASC";

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