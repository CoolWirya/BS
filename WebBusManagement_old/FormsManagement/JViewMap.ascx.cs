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
        public int GmtMintePlus = 210;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JViewMap.GetBusMarker";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = true;

            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);

            ViewMapActionString.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JViewMap.GetBusMarker");

            if (!IsPostBack)
            {
                LoadBuses();
            }

            string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            {
                GmtMintePlus = 270;
            }

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

                string Query = @"select * from 
                                   (select  ROW_NUMBER() over (order by AUA.Code asc) as RowNumber,
                                    AUA.Code,
                                    AUA.BusCode,
                                    AUB.BusNumber,
                                    AUA.Latitude,
                                    AUA.Longitude,
                                    AUA.Course,
                                    AUA.Speed,
                                    AUA.StopTime,
                                    AUA.DistanceFromLine,
                                    dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate) EventDate,
                                    (DATEPART(hour,dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate))*3600)+(DATEPART(minute,dateadd(minute," +
                                    GmtMintePlus.ToString() + @",AUA.EventDate))*60)+(DATEPART(second,dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate))) EventTimeSecond,
                                    DATEPART(HOUR,dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate)) EventDateHour,
                                    ISNULL(CAST((select top 1 C.PCode from dbo.AUTTicketTransaction A
                                    left join
                                    dbo.Cards C on A.DriverCardSerial = C.RfidNumber 
                                    left join
                                    dbo.clsAllPerson CAP on CAP.Code = C.PCode 
                                    where dateadd(minute," + GmtMintePlus.ToString() + @",EventDate)>='" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"')AS NVARCHAR),N'نا مشخص')PersonnelCode,
                                    ISNULL((select top 1 CAP.Name from dbo.AUTTicketTransaction A
                                    left join
                                    dbo.Cards C on A.DriverCardSerial = C.RfidNumber 
                                    left join
                                    dbo.clsAllPerson CAP on CAP.Code = C.PCode 
                                    where dateadd(minute," + GmtMintePlus.ToString() + @",EventDate)>='" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"'),N'نا مشخص')DriverName,
                                    ISNULL(CAST((select top 1 LineNumber from dbo.AUTTicketTransaction A
                                    where dateadd(minute," + GmtMintePlus.ToString() + @",EventDate)>='" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"')AS NVARCHAR),N'نا مشخص')LineNumber,
                                    ISNULL((select top 1 AZ.Name from dbo.AUTTicketTransaction A
                                    left join dbo.AUTLine AL on A.LineNumber = AL.LineNumber 
                                    left join dbo.AUTZone AZ on Al.ZoneCode = AZ.Code 
                                    where dateadd(minute," + GmtMintePlus.ToString() + @",EventDate)>='" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"'),N'نا مشخص')ZoneName
                                    from dbo.AUTAvlTransaction AUA left join dbo.AUTBus AUB
                                    on AUA.BusCode=AUB.Code
                                    where AUB.BusNumber = " + Param[0].ToString() + @"
                                    and dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate) Between '" + FinalFromDate.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                    and '" + FinalToDate.ToString("yyyy-MM-dd HH:mm:ss") + @"') TransactionTable
                                where (RowNumber = 1 or RowNumber % " + Param[4].ToString() + @" = 0)
                                order by eventdate asc";

                DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(Query);



                string PersonnelCode = "", DriverName = "", LineNumber = "", ZoneName = "";
                if (DtMarkers != null)
                {
                    int DtMarkersRowCount = 0;
                    DtMarkersRowCount = DtMarkers.Rows.Count;
                    string[] ColorArray = new string[DtMarkersRowCount];
                    string[] DifferenceBetweenTime = new string[DtMarkersRowCount];
                    int BusSpeedLimit;
                    int CuAvlTransactionSpeed, CuAvlTransactionHour;
                    if (DtMarkersRowCount > 0)
                    {
                        DifferenceBetweenTime[0] = "1";
                        if (DtMarkersRowCount > 600)
                        {
                            DtMarkersRowCount = 600;
                            Array.Resize(ref ColorArray, 600);
                            Array.Resize(ref DifferenceBetweenTime, 600);
                        }
                        PersonnelCode = DtMarkers.Rows[0]["PersonnelCode"].ToString();
                        DriverName = DtMarkers.Rows[0]["DriverName"].ToString();
                        LineNumber = DtMarkers.Rows[0]["LineNumber"].ToString();
                        ZoneName = DtMarkers.Rows[0]["ZoneName"].ToString();
                        BusSpeedLimit = Convert.ToInt32(GetBusSpeedLimit());
                        for (int i = 0; i < DtMarkersRowCount; i++)
                        {

                            if (i > 0)
                            {
                                DifferenceBetweenTime[i] = Convert.ToString(Convert.ToInt32(DtMarkers.Rows[i]["EventTimeSecond"].ToString()) - Convert.ToInt32(DtMarkers.Rows[i - 1]["EventTimeSecond"].ToString()));
                            }


                            if (ColorByHour == true)
                            {
                                //Line Color By Hour 

                                CuAvlTransactionHour = Convert.ToInt32(DtMarkers.Rows[i]["EventDateHour"].ToString());

                                if (CuAvlTransactionHour >= 0 && CuAvlTransactionHour < 4)
                                {
                                    ColorArray[i] = "0000ff";
                                }
                                else if (CuAvlTransactionHour >= 4 && CuAvlTransactionHour < 8)
                                {
                                    ColorArray[i] = "663399";
                                }
                                else if (CuAvlTransactionHour >= 8 && CuAvlTransactionHour < 12)
                                {
                                    ColorArray[i] = "fda250";
                                }
                                else if (CuAvlTransactionHour >= 12 && CuAvlTransactionHour < 16)
                                {
                                    ColorArray[i] = "FFA500";
                                }
                                else if (CuAvlTransactionHour >= 16 && CuAvlTransactionHour < 20)
                                {
                                    ColorArray[i] = "9f4b00";
                                }
                                else if (CuAvlTransactionHour >= 20 && CuAvlTransactionHour < 24)
                                {
                                    ColorArray[i] = "000";
                                }

                            }
                            else
                            {
                                //Line Color By Speed

                                CuAvlTransactionSpeed = Convert.ToInt32(DtMarkers.Rows[i]["Speed"].ToString());

                                if (CuAvlTransactionSpeed <= 3)
                                {
                                    ColorArray[i] = "000";
                                }
                                else if (CuAvlTransactionSpeed > 3 && CuAvlTransactionSpeed <= BusSpeedLimit)
                                {
                                    ColorArray[i] = "00ff00";
                                }
                                else if (CuAvlTransactionSpeed > BusSpeedLimit)
                                {
                                    ColorArray[i] = "ff0000";
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
                            }

                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), DtMarkers.Rows[i]["Code"].ToString(),
                                "", "../WebBusManagement/Images/ViewMapArrow/" + direction_arrow, 16, 16, 0, 0));
                        }
                        //}
                        //else
                        //{
                        //    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle("123"), Convert.ToSingle("123"), "Error Over 1000", "", "", 0, 0, 0, 0));
                        //}
                    }
                    return new object[] { DtMarkersRowCount, mapData.Generate(), PersonnelCode, DriverName, LineNumber, ZoneName, ColorArray, DifferenceBetweenTime };
                }
                else
                {
                    return new object[] { 0, 0, 0, 0, 0, 0, 0, 0 };
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
                            AUA.Code, AUA.Latitude, AUA.Longitude,dateadd(minute," + GmtMintePlus.ToString() + @",AUA.EventDate) EventDate,AUA.Speed,AUA.BatteryCharge,
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
                <div style=""display:table-cell;background-color:rgba(0,0,0,0.7);width:32px;height:32px;text-align:center;vertical-align:middle""><img src=""../WebBusManagement/Images/close.png"" onclick=""{CLOSE_POPUP}""/></div>
                <div style=""width:100%;height:100%;background-color:rgba(0,0,0,0.7);color:white;text-align:right;text-shadow: 4px 4px 5px #000;box-shadow: 10px 10px 5px #000;padding:5px;"">
                <table width=""100%"">
                    <tr>
                        <td style=""text-align:center"">" + gpsHTML + @" GPS</td>
                        <td style=""text-align:center"">" + batteryHTML + @"</td>
                        <td style=""text-align:center"">" + gsmHTML + @" GSM</td>
                    </tr>
                </table>
                <div style=""clear:both;height:5px""></div>
                تاریخ : " + DtPopup.Rows[0]["EventDate"].ToString().Replace("<br/>", " ") + @"<div style=""clear:both;height:2px""></div>
                سرعت : " + DtPopup.Rows[0]["Speed"].ToString() + @" کیلومتر بر ساعت<div style=""clear:both;height:2px""></div>
                شارژ سیم کارت : " + DtPopup.Rows[0]["SimCardCharge"].ToString() + @" ریال<div style=""clear:both;height:2px""></div>
                فاصله از خط : " + DtPopup.Rows[0]["DistanceFromLine"].ToString().Split('.')[0].ToString() + @" متر<div style=""clear:both;height:2px""></div>
                فاصله از نقطه ی قبل : " + DtPopup.Rows[0]["DistancePerDay"].ToString().Split('.')[0].ToString() + @" متر<div style=""clear:both;height:2px""></div>
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

    }
}