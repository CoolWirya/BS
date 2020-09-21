using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JViewMap : System.Web.UI.UserControl
    {

        public JViewMap()
        {

        }
        //public int GmtMintePlus = 210;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JViewMap.GetEventDate";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = false;

            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);

            ViewMapActionString.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JViewMap.GetBusMarker");

            if (!IsPostBack)
            {
                LoadBuses();
            }

            PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JViewMap.GetStation");

            //string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            //if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            //{
            //    GmtMintePlus = 270;
            //}

        }
        public string[] GetEventDate(string[] param)
        {
            Int64 AvlCode = Convert.ToInt64(param[1]);
            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server02", 0));
            try
            {
                db.setQuery("select EventDate from AUTAvlTransaction where code = " + AvlCode);
                DateTime EventDate = Convert.ToDateTime(db.Query_DataTable().Rows[0][0]);
                string strEventDate = EventDate.Hour.ToString("00") + ": " + EventDate.Minute.ToString("00") + ": " + EventDate.Second.ToString("00");
                return new string[] 
                {
                    WebControllers.MainControls.OpenLayersMap.JMapData.GeneratePopup("<div class='Popup'>" + strEventDate + "</div>", 70, 32)
                }; 
            }
            finally { db.Dispose(); }
        }

        public string[] GetStation(string[] param)
        {
            DataTable DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable("select b.Code LineCode from AUTBus a left join AUTLine b on a.LastLineNumber = b.LineNumber  where BUSNumber = " + param[0]);

            if (DtLineCode != null)
            {
                WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
                DataTable DtStation = new DataTable();
                DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"
                    select distinct s.Code, Name, Lat, Lng
                    , (case when Priority in (1,PriorityMax) then 1 else 0 end) isTerminal 
                    from (select *, max(Priority) over (partition by LineCode, IsBack) PriorityMax from AUTLineStation ) ls
                    inner join [dbo].[AUTStation] s on s.Code = ls.StationCode
                    where Lat Is NOT NULL and Lng IS NOT NULL And Lat <> '0.00000000000000' and Lng <> '0.00000000000000'
                    and LineCode = " + DtLineCode.Rows[0]["LineCode"].ToString());
                if (DtStation != null)
                {
                    for (int i = 0; i < DtStation.Rows.Count; i++)
                    {
                        mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                                Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + (Convert.ToInt32(DtStation.Rows[i]["isTerminal"]) == 1 ? "Terminal_" : "") + DtStation.Rows[i]["Code"].ToString(), DtStation.Rows[i]["Name"].ToString(), "", 24, 24, 90, 20));
                    }
                }
                return mapData.GenerateMarkerStation();
            }
            return new string[] {""};
        }

        public void LoadBuses()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public string GetBusSpeedLimit()
        {
            DataTable DtBusSpeedLimit = new DataTable();
            DtBusSpeedLimit = WebClassLibrary.JWebDataBase.GetDataTable(@"select KeyValue from dbo.AUTSettings where KeyName='SpeedLimit'");
            return DtBusSpeedLimit.Rows[0]["KeyValue"].ToString();
        }

        public object[] GetBusMarker(string[] Param)
        {
            DataTable DtMarkers;
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();

            int num1;
            bool res = int.TryParse(Param[0].ToString(), out num1);
            int MaxMarkersNumber = 20;

            if (res == true)
            {
                DateTime FromDate = ClassLibrary.JDateTime.GregorianDate(Param[1].ToString());

                string[] FromTimeStr = new string[3];
                FromTimeStr = Param[2].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                TimeSpan FromTime = new TimeSpan(Convert.ToInt32(FromTimeStr[0].ToString()), Convert.ToInt32(FromTimeStr[1].ToString()), Convert.ToInt32(FromTimeStr[2].ToString()));

                string[] ToTimeStr = new string[3];
                ToTimeStr = Param[3].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                TimeSpan ToTime = new TimeSpan(Convert.ToInt32(ToTimeStr[0].ToString()), Convert.ToInt32(ToTimeStr[1].ToString()), Convert.ToInt32(ToTimeStr[2].ToString()));

                DateTime FinalFromDate = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, FromTime.Hours, FromTime.Minutes, FromTime.Seconds);
                DateTime FinalToDate = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, ToTime.Hours, ToTime.Minutes, ToTime.Seconds);

                bool ColorByHour = false;
                if (Param[5].ToString() == "ColorByHour")
                {
                    ColorByHour = true;
                }

                int PartNumber = Convert.ToInt32(Param[6]);

                if (PartNumber == 1)
                {
                    string Query = @"select  ROW_NUMBER() over (order by AUA.Code asc) as RowNumber,
                                        AUA.Code,
                                        AUA.BusCode,
                                        AUB.BusNumber,
                                        AUA.Latitude,
                                        AUA.Longitude,
                                        AUA.Course,
                                        AUA.Speed,
                                        AUA.StopTime,
                                        AUA.DistanceFromLine,
                                        AUA.EventDate as EventDate,
                                        (DATEPART(hour,AUA.EventDate)*3600)+(DATEPART(minute,AUA.EventDate)*60)+(DATEPART(second,AUA.EventDate)) EventTimeSecond,
                                        DATEPART(HOUR,AUA.EventDate) EventDateHour
										into #T
                                        from dbo.AUTAvlTransaction AUA left join dbo.AUTBus AUB
                                        on AUA.BusCode=AUB.Code
                                        where AUB.BusNumber = " + Param[0].ToString() + @"
                                        and AUA.EventDate Between '" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                        and '" + FinalToDate.ToString("yyyy-MM-dd HH:mm:ss")+ @"'
                                        select Max(Code) Code,BusCode,BUSNumber,Latitude,Longitude,Course,Speed,StopTime,EventDate,DistanceFromLine,EventTimeSecond,EventDateHour from #T TransactionTable
                                        where (RowNumber = 1 or RowNumber % " + Param[4].ToString() + @" = 0)
                                        group by BusCode,BUSNumber,Latitude,Longitude,Course,Speed,EventDate,DistanceFromLine,StopTime,EventTimeSecond,EventDateHour
                                        order by eventdate asc";

                    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                    db.setQuery(Query);
                    DtMarkers = db.Query_DataTable();

                    Query = @"declare @PCode int, @DriverName nvarchar, @LineNumber int
                        select top 1 @PCode = isnull(c.PCode, 0), @DriverName = isnull(p.Name, ''), @LineNumber = isnull(s.LineNumber, 0)
                        from AUTShiftDriver s
                        left join
                        dbo.Cards c on s.DriverCardSerial = c.RfidNumber 
                        left join
                        dbo.clsAllPerson p on p.Code = c.PCode  
                        where Date = '" + FinalFromDate.ToString("yyyy-MM-dd") + @"' and s.BusNumber = " + Param[0].ToString() + @" 
                        and '" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"' < s.Enddate 
                        and '" + FinalToDate.ToString("yyyy-MM-dd HH:mm:ss") + @"' > s.Startdate

                        if @LineNumber > 0
                            select @PCode PCode, @DriverName DriverName, @LineNumber LineNumber, isnull(zone.Name, '') ZoneName 
                            from AUTLine line left join AUTZone zone on zone.Code = line.ZoneCode where line.LineNumber = @LineNumber
                        else
                            select @PCode PCode, @DriverName DriverName, @LineNumber LineNumber, '' ZoneName";
                    db.setQuery(Query);
                    DataTable dt = db.Query_DataTable();
                    db.Dispose();

                    string PersonnelCode = "", DriverName = "", LineNumber = "", ZoneName = "";
                    int DtMarkersRowCount = 0;
                    int PartsCount = 0;
                    if (DtMarkers != null)
                    {
                        DtMarkersRowCount = DtMarkers.Rows.Count;
                        PartsCount = (DtMarkersRowCount - 1) / MaxMarkersNumber + 1;
                        int RowCount = Math.Min(DtMarkersRowCount, MaxMarkersNumber);
                        string[] arrLineColor = new string[RowCount];
                        string[] DifferenceBetweenTime = new string[RowCount];
                        int BusSpeedLimit;
                        int PointSpeed, LineSpeed, TransactionHour;
                        string ArrowColor = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            PersonnelCode = dt.Rows[0]["PCode"].ToString();
                            DriverName = dt.Rows[0]["DriverName"].ToString();
                            LineNumber = dt.Rows[0]["LineNumber"].ToString();
                            ZoneName = dt.Rows[0]["ZoneName"].ToString();
                        }
                        if (RowCount > 0)
                        {
                            if (DtMarkersRowCount > MaxMarkersNumber)
                            {
                                string SessionName = "WebBusManagement.FormsManagement.JViewMap.GetBusMarker_" + Param[0] + "_"
                                    + Param[1] + "_" + Param[2] + "_" + Param[3] + "_" + Param[4] + "_" + Param[5];
                                WebClassLibrary.SessionManager.Current.Session[SessionName] = DtMarkers;
                            }
                            DifferenceBetweenTime[0] = "1";
                            //if (DtMarkersRowCount > 600)
                            //{
                            //    DtMarkersRowCount = 600;
                            //    Array.Resize(ref arrLineColor, 600);
                            //    Array.Resize(ref DifferenceBetweenTime, 600);
                            //}
                            BusSpeedLimit = Convert.ToInt32(GetBusSpeedLimit());
                            for (int i = 0; i < RowCount; i++)
                            {

                                if (i > 0)
                                {
                                    DifferenceBetweenTime[i] = Convert.ToString(Convert.ToInt32(DtMarkers.Rows[i]["EventTimeSecond"].ToString()) - Convert.ToInt32(DtMarkers.Rows[i - 1]["EventTimeSecond"].ToString()));


                                    if (ColorByHour == true)
                                    {
                                        //Line Color By Hour 

                                        TransactionHour = Convert.ToInt32(DtMarkers.Rows[i]["EventDateHour"].ToString());

                                        if (TransactionHour >= 0 && TransactionHour < 4)
                                        {
                                            arrLineColor[i] = "0000ff";
                                        }
                                        else if (TransactionHour >= 4 && TransactionHour < 8)
                                        {
                                            arrLineColor[i] = "663399";
                                        }
                                        else if (TransactionHour >= 8 && TransactionHour < 12)
                                        {
                                            arrLineColor[i] = "fda250";
                                        }
                                        else if (TransactionHour >= 12 && TransactionHour < 16)
                                        {
                                            arrLineColor[i] = "FFA500";
                                        }
                                        else if (TransactionHour >= 16 && TransactionHour < 20)
                                        {
                                            arrLineColor[i] = "9f4b00";
                                        }
                                        else if (TransactionHour >= 20 && TransactionHour < 24)
                                        {
                                            arrLineColor[i] = "000";
                                        }

                                    }
                                    else
                                    {
                                        //Line Color By Speed

                                        PointSpeed = Convert.ToInt32(DtMarkers.Rows[i]["Speed"].ToString());
                                        try
                                        {
                                            LineSpeed =
                                                Convert.ToInt32(3.6 *
                                                distance(Convert.ToDouble(DtMarkers.Rows[i - 1]["Latitude"]), Convert.ToDouble(DtMarkers.Rows[i - 1]["Longitude"])
                                                , Convert.ToDouble(DtMarkers.Rows[i]["Latitude"]), Convert.ToDouble(DtMarkers.Rows[i]["Longitude"]))
                                                / Convert.ToInt32(DifferenceBetweenTime[i]));
                                        }
                                        catch
                                        {
                                            LineSpeed = 0;
                                        }

                                        if (LineSpeed <= 3)
                                        {
                                            arrLineColor[i] = "595959";
                                        }
                                        else if (LineSpeed > 3 && LineSpeed <= BusSpeedLimit)
                                        {
                                            arrLineColor[i] = "00e6e6";
                                        }
                                        else if (LineSpeed > BusSpeedLimit)
                                        {
                                            arrLineColor[i] = "ff66b5";
                                        }

                                        if (PointSpeed <= 3)
                                        {
                                            ArrowColor = "grey";
                                        }
                                        else if (PointSpeed > 3 && PointSpeed <= BusSpeedLimit)
                                        {
                                            ArrowColor = "green";
                                        }
                                        else if (PointSpeed > BusSpeedLimit)
                                        {
                                            ArrowColor = "red";
                                        }

                                    }
                                }

                                string direction_arrow = "";
                                int course = Convert.ToInt32(DtMarkers.Rows[i]["Course"]) * 2;

                                if (i == 0 || i == (DtMarkers.Rows.Count - 1))
                                {
                                    if (i == 0)
                                    {
                                        direction_arrow = "A.png";    //Start Point
                                    }
                                    else
                                    {
                                        direction_arrow = "B.png";    //Finish Point
                                    }
                                }
                                else
                                {
                                    if (course >= 330 || course < 30)           // Up
                                        direction_arrow = "arrow_up";
                                    else if (course >= 30 && course < 60)       // Up Right
                                        direction_arrow = "arrow_upright";
                                    else if (course >= 60 && course < 120)      // Right
                                        direction_arrow = "arrow_right";
                                    else if (course >= 120 && course < 150)      // Down Right
                                        direction_arrow = "arrow_downright";
                                    else if (course >= 150 && course < 210)      // Down
                                        direction_arrow = "arrow_down";
                                    else if (course >= 210 && course < 240)      // Down Left
                                        direction_arrow = "arrow_downleft";
                                    else if (course >= 240 && course < 300)      // Left
                                        direction_arrow = "arrow_left";
                                    else if (course >= 300 && course < 330)      // Up Left
                                        direction_arrow = "arrow_upleft";
                                    direction_arrow = direction_arrow + (!string.IsNullOrWhiteSpace(ArrowColor) ? "_" + ArrowColor : "") + ".png";
                                }

                                mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                    Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["Code"].ToString(),
                                    "", "../WebBusManagement/Images/ViewMapArrow/" + direction_arrow, 32, 32, 0, 0));
                            }


                            //                        DataTable DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable("select b.Code LineCode from AUTBus a left join AUTLine b on a.LastLineNumber = b.LineNumber  where BUSNumber = " + Param[0].ToString());
                            //                        if (DtLineCode != null)
                            //                        {

                            //                            //WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
                            //                            DataTable DtStation = new DataTable();
                            //                            DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL 
                            //                                                                    And Lat <> '0.00000000000000' and Lng <> '0.00000000000000'
                            //                                                                    And Code in (
                            //                                                                    select StationCode from AutLineStation Where LineCode = " + DtLineCode.Rows[0]["LineCode"].ToString() + ") order by Code");
                            //                            if (DtStation != null)
                            //                            {
                            //                                DtMarkersRowCount = DtStation.Rows.Count + DtMarkersRowCount;
                            //                                for (int i = 0; i < DtStation.Rows.Count; i++)
                            //                                {
                            //                                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                            //                                            Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + DtStation.Rows[i]["Code"].ToString(),
                            //                                            DtStation.Rows[i]["Name"].ToString(),
                            //                                            "", 24, 24, 90, 20));
                            //                                }
                            //                            }
                            //                        }

                            //}
                            //else
                            //{
                            //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle("123"), Convert.ToSingle("123"), "Error Over 1000", "", "", 0, 0, 0, 0));
                            //}
                        }
                        return new object[] { MaxMarkersNumber, PartsCount, DtMarkersRowCount, mapData.Generate(), PersonnelCode, DriverName, LineNumber, ZoneName, arrLineColor, DifferenceBetweenTime };
                    }
                    else
                    {
                        return new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                }
                else // when PartNumber > 1
                {
                    string SessionName = "WebBusManagement.FormsManagement.JViewMap.GetBusMarker_" + Param[0] + "_"
                        + Param[1] + "_" + Param[2] + "_" + Param[3] + "_" + Param[4] + "_" + Param[5];
                    DtMarkers = WebClassLibrary.SessionManager.Current.Session[SessionName] as DataTable;
                    int FromRowIndex = (PartNumber - 1) * MaxMarkersNumber;
                    int RowCount = Math.Min(DtMarkers.Rows.Count, PartNumber * MaxMarkersNumber) - (PartNumber - 1) * MaxMarkersNumber;
                    if (PartNumber * MaxMarkersNumber >= DtMarkers.Rows.Count)
                        WebClassLibrary.SessionManager.Current.Session[SessionName] = "";
                    string[] arrLineColor = new string[RowCount];
                    string[] DifferenceBetweenTime = new string[RowCount];
                    int BusSpeedLimit;
                    int PointSpeed = -1, LineSpeed, TransactionHour;
                    string ArrowColor = "";
                        BusSpeedLimit = Convert.ToInt32(GetBusSpeedLimit());
                        for (int i = 0; i < RowCount; i++)
                        {
                            DifferenceBetweenTime[i] = Convert.ToString(Convert.ToInt32(DtMarkers.Rows[FromRowIndex + i]["EventTimeSecond"].ToString()) - Convert.ToInt32(DtMarkers.Rows[FromRowIndex + i - 1]["EventTimeSecond"].ToString()));


                            if (ColorByHour == true)
                            {
                                //Line Color By Hour 

                                TransactionHour = Convert.ToInt32(DtMarkers.Rows[FromRowIndex + i]["EventDateHour"].ToString());

                                if (TransactionHour >= 0 && TransactionHour < 4)
                                {
                                    arrLineColor[i] = "0000ff";
                                }
                                else if (TransactionHour >= 4 && TransactionHour < 8)
                                {
                                    arrLineColor[i] = "663399";
                                }
                                else if (TransactionHour >= 8 && TransactionHour < 12)
                                {
                                    arrLineColor[i] = "fda250";
                                }
                                else if (TransactionHour >= 12 && TransactionHour < 16)
                                {
                                    arrLineColor[i] = "FFA500";
                                }
                                else if (TransactionHour >= 16 && TransactionHour < 20)
                                {
                                    arrLineColor[i] = "9f4b00";
                                }
                                else if (TransactionHour >= 20 && TransactionHour < 24)
                                {
                                    arrLineColor[i] = "000";
                                }

                            }
                            else
                            {
                                //Line Color By Speed

                                PointSpeed = Convert.ToInt32(DtMarkers.Rows[FromRowIndex + i]["Speed"].ToString());
                                LineSpeed =
                                    (Convert.ToInt32(DifferenceBetweenTime[i]) > 0 ?
                                    Convert.ToInt32(3.6 *
                                    distance(Convert.ToDouble(DtMarkers.Rows[FromRowIndex + i - 1]["Latitude"])
                                    , Convert.ToDouble(DtMarkers.Rows[FromRowIndex + i - 1]["Longitude"])
                                    , Convert.ToDouble(DtMarkers.Rows[FromRowIndex + i]["Latitude"]), Convert.ToDouble(DtMarkers.Rows[FromRowIndex + i]["Longitude"]))
                                    / Convert.ToInt32(DifferenceBetweenTime[i]))
                                    : PointSpeed
                                    );

                                if (LineSpeed <= 3)
                                {
                                    arrLineColor[i] = "595959";
                                }
                                else if (LineSpeed > 3 && LineSpeed <= BusSpeedLimit)
                                {
                                    arrLineColor[i] = "00e6e6";
                                }
                                else if (LineSpeed > BusSpeedLimit)
                                {
                                    arrLineColor[i] = "ff66b5";
                                }

                                if (PointSpeed <= 3)
                                {
                                    ArrowColor = "grey";
                                }
                                else if (PointSpeed > 3 && PointSpeed <= BusSpeedLimit)
                                {
                                    ArrowColor = "green";
                                }
                                else if (PointSpeed > BusSpeedLimit)
                                {
                                    ArrowColor = "red";
                                }

                            }

                            string direction_arrow = "";
                            int course = Convert.ToInt32(DtMarkers.Rows[FromRowIndex + i]["Course"]) * 2;

                            if (FromRowIndex + i == (DtMarkers.Rows.Count - 1))
                            {
                                direction_arrow = "B.png";    //Finish Point
                            }
                            else
                            {
                                if (course >= 330 || course < 30)           // Up
                                    direction_arrow = "arrow_up";
                                else if (course >= 30 && course < 60)       // Up Right
                                    direction_arrow = "arrow_upright";
                                else if (course >= 60 && course < 120)      // Right
                                    direction_arrow = "arrow_right";
                                else if (course >= 120 && course < 150)      // Down Right
                                    direction_arrow = "arrow_downright";
                                else if (course >= 150 && course < 210)      // Down
                                    direction_arrow = "arrow_down";
                                else if (course >= 210 && course < 240)      // Down Left
                                    direction_arrow = "arrow_downleft";
                                else if (course >= 240 && course < 300)      // Left
                                    direction_arrow = "arrow_left";
                                else if (course >= 300 && course < 330)      // Up Left
                                    direction_arrow = "arrow_upleft";
                                direction_arrow = direction_arrow + (!string.IsNullOrWhiteSpace(ArrowColor) ? "_" + ArrowColor : "") + ".png";
                            }

                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtMarkers.Rows[FromRowIndex + i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[FromRowIndex + i]["Latitude"]), DtMarkers.Rows[FromRowIndex + i]["Code"].ToString(),
                                "", "../WebBusManagement/Images/ViewMapArrow/" + direction_arrow, 32, 32, 0, 0));
                        }


                        //                        DataTable DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable("select b.Code LineCode from AUTBus a left join AUTLine b on a.LastLineNumber = b.LineNumber  where BUSNumber = " + Param[0].ToString());
                        //                        if (DtLineCode != null)
                        //                        {

                        //                            //WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
                        //                            DataTable DtStation = new DataTable();
                        //                            DtStation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Lat,Lng,isTerminal from [dbo].[AUTStation] where Lat Is NOT NULL and Lng IS NOT NULL 
                        //                                                                    And Lat <> '0.00000000000000' and Lng <> '0.00000000000000'
                        //                                                                    And Code in (
                        //                                                                    select StationCode from AutLineStation Where LineCode = " + DtLineCode.Rows[0]["LineCode"].ToString() + ") order by Code");
                        //                            if (DtStation != null)
                        //                            {
                        //                                DtMarkersRowCount = DtStation.Rows.Count + DtMarkersRowCount;
                        //                                for (int i = 0; i < DtStation.Rows.Count; i++)
                        //                                {
                        //                                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtStation.Rows[i]["Lng"]),
                        //                                            Convert.ToSingle(DtStation.Rows[i]["Lat"]), "Station_" + DtStation.Rows[i]["Code"].ToString(),
                        //                                            DtStation.Rows[i]["Name"].ToString(),
                        //                                            "", 24, 24, 90, 20));
                        //                                }
                        //                            }
                        //                        }

                        //}
                        //else
                        //{
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle("123"), Convert.ToSingle("123"), "Error Over 1000", "", "", 0, 0, 0, 0));
                        //}
                        return new object[] { 0, 0, 0, mapData.Generate(), 0, "", 0, "", arrLineColor, DifferenceBetweenTime };
                }

            }
            else if (Param[0].ToString() == "Popup")
            {
                // POPUP: Bus description
                int TransactionCode = 0;
                int.TryParse(Param[1], out TransactionCode);
                DataTable DtPopup = new DataTable();
                DtPopup = WebClassLibrary.JWebDataBase.GetDataTable(@"
                        select
                            AUA.Code, AUA.Latitude, AUA.Longitude,AUA.EventDate as EventDate,AUA.Speed,AUA.BatteryCharge,
                            AUA.GpsAntenna,AUA.GsmAntenna,SimCardCharge,AUA.StopTime,AUA.DistanceFromLine,AUA.DistancePerDay
                            from dbo.AUTAvlTransaction AUA
                            where Code = " + TransactionCode);

                string[] PopUpStr = new string[1];
                if (DtPopup != null)
                {
                    // Battery
                    int batteryCharge = 0;
                    string batteryHTML = "";
                    int.TryParse(DtPopup.Rows[0]["BatteryCharge"].ToString(), out batteryCharge);
                    batteryCharge = batteryCharge / 3000 * 100;
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
                    int.TryParse(DtPopup.Rows[0]["GsmAntenna"].ToString(), out gsm);
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
                    int.TryParse(DtPopup.Rows[0]["GpsAntenna"].ToString(), out gps);
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
                <div style=""display:table-cell;background-color:rgba(0,0,0,0.7);width:32px;height:32px;text-align:center;vertical-align:middle"">
                <img src=""../WebBusManagement/Images/close.png"" onclick=""{CLOSE_POPUP}""/></div>
                <div style=""width:90%;height:80%;background-color:rgba(0,0,0,0.7);color:white;text-align:right;text-shadow: 4px 4px 5px #000;padding:5px;"">
                <table width=""100%"">
                    <tr>
                        <td style=""text-align:center"">" + gpsHTML + @" GPS</td>
                        <td style=""text-align:center"">" + batteryHTML + @"</td>
                        <td style=""text-align:center"">" + gsmHTML + @" GSM</td>
                    </tr>
                </table>
                <div style=""clear:both;height:3px""></div>
                تاریخ : " + DtPopup.Rows[0]["EventDate"].ToString().Replace("<br/>", " ") + @"<div style=""clear:both;height:1px""></div>
                سرعت : " + DtPopup.Rows[0]["Speed"].ToString() + @" کیلومتر بر ساعت<div style=""clear:both;height:1px""></div>
                شارژ سیم کارت : " + DtPopup.Rows[0]["SimCardCharge"].ToString() + @" ریال<div style=""clear:both;height:1px""></div>
                فاصله از خط : " + DtPopup.Rows[0]["DistanceFromLine"].ToString().Split('.')[0].ToString() + @" متر<div style=""clear:both;height:1px""></div>
                فاصله از نقطه ی قبل : " + DtPopup.Rows[0]["DistancePerDay"].ToString().Split('.')[0].ToString() + @" متر<div style=""clear:both;height:1px""></div>
                زمان توقف : " + DtPopup.Rows[0]["StopTime"].ToString() + @" دقیقه<div style=""clear:both;height:1px""></div>
                ظول و عرض جغرافیایی: " + DtPopup.Rows[0]["Latitude"].ToString() + ", " + DtPopup.Rows[0]["Longitude"].ToString() + @"<div style=""clear:both;height:1px""></div>
                </div>", 310, 240);
                }
                return PopUpStr;
            }
            else
            {
                return null;
            }
        }
        private double distance(double lat1, double lon1, double lat2, double lon2)// lat and lon are in degree
        {
            if (lat1 == lat2 && lon1 == lon2)
                return 0;
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 111189.57696;
            return (dist);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

    }
}