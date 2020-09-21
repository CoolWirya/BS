using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusLineStationPositionReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLines();
            }
            stationPassCalenderReportControl.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsReports.JBusLineStationPositionReportControl.GetReportJquery");
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0, 1);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), LineNumberWithCode = v["LineNumberWithCode"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, LineNumberWithCode = "0 - همه" });
            cmbLine.DataSource = dt;
            cmbLine.DataTextField = "LineNumberWithCode";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }
        public string StrScipt = "";
        public string[] GetReportJquery(string[] param)
        {
            string StrCalender = "";
            int Line = Convert.ToInt32(param[0].ToString());
            DataTable DtStationListGo = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,a.StationCode,b.Name StationName,b.Lat,b.Lng from AUTLineStation a
                                                                                    left join AutStation b on a.StationCode = b.Code
                                                                                    where a.LineCode = " + Line.ToString() + @" and a.IsBack = 0
                                                                                    order by a.[Priority]");
            StrCalender += @"<div style='float:left;width:200px;height:20px;background-color:green;text-align:center;color:white'>مسیر رفت خط " + param[1].ToString()
                + @"</div><div style='clear:both;height:50px'></div>";
            if (DtStationListGo != null & DtStationListGo.Rows.Count > 0)
            {
                for (int i = 0; i < DtStationListGo.Rows.Count; i++)
                {
                    StrCalender += @"<div id='" + DtStationListGo.Rows[i]["StationCode"].ToString() + @"' style=""float:left;width:32px;height:32px;text-align:center;color:red;
                                    background-image:url('WebBusManagement/Images/station_s32.png');background-repeat:no-repeat"" 
                                    onmouseover=""SetStationNameText('" + DtStationListGo.Rows[i]["StationName"].ToString() + @"')""
                                    onmouseout=""ClearStationNameText()"">" + DtStationListGo.Rows[i]["StationCode"].ToString() + @"</div><div style='float:left;width:50px;height:20px;'></div>";
                }
            }

            StrCalender += "<div style='clear:both;height:15px'></div><hr /><div style='clear:both;height:15px'></div>";

            DataTable BusLineGo = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.BusNumber,a.EventDate,a.StationCode,(select  IsBack from AUTLineStation where StationCode = a.StationCode and LineCode =" + param[0].ToString() + @")ISBack,
                                                                                s.Lat SLat,s.Lng SLng,ab.LastLatitude BLat,ab.LastLongitude BLng,ab.LastSpeed,ab.LastDate,
                                                                                dbo.GetDistance2Points(s.Lng,s.Lat,ab.LastLongitude,ab.LastLatitude)DistanceBackStation,
                                                                                (select top 1 dbo.GetDistance2Points(ab.LastLongitude,ab.LastLatitude,AUTStation.Lng,AUTStation.Lat) from AUTLineStation
                                                                                inner join AUTStation on AUTLineStation.StationCode = AUTStation.Code
                                                                                 where Priority in (select Priority+1 from AUTLineStation where StationCode = s.Code and LineCode =" + param[0].ToString() + @") and LineCode =" + param[0].ToString() + @")DistanceNextStation
                                                                                 ,(dbo.GetDistance2Points(s.Lng,s.Lat,ab.LastLongitude,ab.LastLatitude)+
                                                                                 (select top 1 dbo.GetDistance2Points(ab.LastLongitude,ab.LastLatitude,AUTStation.Lng,AUTStation.Lat) from AUTLineStation
                                                                                inner join AUTStation on AUTLineStation.StationCode = AUTStation.Code
                                                                                 where Priority in (select Priority+1 from AUTLineStation where StationCode = s.Code and LineCode =" + param[0].ToString() + @") and LineCode =" + param[0].ToString() + @"))Distance2Station
                                                                                from AutBusPassingStations a 
                                                                                left join AUTStation s on a.StationCode=s.Code
                                                                                left join AUTBus ab on a.BusNumber = ab.BUSNumber
                                                                                where a.BusNumber in (
                                                                                select BusNumber from AutBusPassingStations 
                                                                                where BusNumber in (select BusNumber from AUTBus where LastLineNumber = " + param[1].ToString() + @" and Active = 1 and IsValid = 1 and cast(LastDate as date) = cast(GETDATE() as date))
                                                                                and cast(EventDate as date) = cast(GETDATE() as date)
                                                                                group by BusNumber
                                                                                )
                                                                                and a.EventDate in 
                                                                                (select Max(EventDate)MEventDate from AutBusPassingStations 
                                                                                where BusNumber in (select BusNumber from AUTBus where LastLineNumber = " + param[1].ToString() + @" and Active = 1 and IsValid = 1 and cast(LastDate as date) = cast(GETDATE() as date))
                                                                                and cast(EventDate as date) = cast(GETDATE() as date)
                                                                                group by BusNumber)
                                                                                and (select  IsBack from AUTLineStation where StationCode = a.StationCode and LineCode = " + param[0].ToString() + @") = 0");

            int StationGoFlag = 0;
            if (BusLineGo != null & BusLineGo.Rows.Count > 0)
            {
                //                for (int k = 0; k < BusLineGo.Rows.Count; k++)
                //                {
                //                    StrCalender += "<div id='" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"' 
                //                    style='float:left;background-color:red;color:white;text-align:center;width:50px;height:20px;'>" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"</div>";
                //                    StrScipt += @"var offsets" + k.ToString() + BusLineGo.Rows[k]["StationCode"].ToString() + " = $('#" + BusLineGo.Rows[k]["StationCode"].ToString() + @"').offset();
                //                                  document.getElementById('" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"').style.top = offsets" + k.ToString() + BusLineGo.Rows[k]["StationCode"].ToString() + @".top;
                //                                  document.getElementById('" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"').style.left = offsets" + k.ToString() + BusLineGo.Rows[k]["StationCode"].ToString() + @".left;";
                //                }
                if (DtStationListGo != null & DtStationListGo.Rows.Count > 0)
                {
                    for (int i = 0; i < DtStationListGo.Rows.Count; i++)
                    {
                        StationGoFlag = 0;
                        for (int k = 0; k < BusLineGo.Rows.Count; k++)
                        {
                            if (BusLineGo.Rows[k]["StationCode"].ToString() == DtStationListGo.Rows[i]["StationCode"].ToString())
                            {
                                StrCalender += "<div id='" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"' 
                                style=""float:left;color:red;text-align:center;width:64px;height:43px;margin-left:1px;
                                background-image:url('WebBusManagement/Images/bus_s64_right.png');background-repeat:no-repeat"">" + BusLineGo.Rows[k]["BusNumber"].ToString() + @"</div>";
                                StationGoFlag = 1;
                            }
                        }
                        if (StationGoFlag == 0)
                        {
                            StrCalender += "<div style='float:left;width:50px;height:20px;'></div>";
                        }
                    }
                }
            }

            StrCalender += "<div style='clear:both;height:15px'></div><hr /><div style='clear:both;height:15px'></div>";
            DataTable DtStationListBack = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,a.StationCode,b.Name StationName,b.Lat,b.Lng from AUTLineStation a
                                                                                                left join AutStation b on a.StationCode = b.Code
                                                                                                where a.LineCode = " + Line.ToString() + @" and a.IsBack = 1
                                                                                                order by a.[Priority]");

            DataTable BusLineBack = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.BusNumber,a.EventDate,a.StationCode,(select  IsBack from AUTLineStation where StationCode = a.StationCode and LineCode =" + param[0].ToString() + @")ISBack,
                                                                                s.Lat SLat,s.Lng SLng,ab.LastLatitude BLat,ab.LastLongitude BLng,ab.LastSpeed,ab.LastDate,
                                                                                dbo.GetDistance2Points(s.Lng,s.Lat,ab.LastLongitude,ab.LastLatitude)DistanceBackStation,
                                                                                (select top 1 dbo.GetDistance2Points(ab.LastLongitude,ab.LastLatitude,AUTStation.Lng,AUTStation.Lat) from AUTLineStation
                                                                                inner join AUTStation on AUTLineStation.StationCode = AUTStation.Code
                                                                                 where Priority in (select Priority+1 from AUTLineStation where StationCode = s.Code and LineCode =" + param[0].ToString() + @") and LineCode =" + param[0].ToString() + @")DistanceNextStation
                                                                                 ,(dbo.GetDistance2Points(s.Lng,s.Lat,ab.LastLongitude,ab.LastLatitude)+
                                                                                 (select top 1 dbo.GetDistance2Points(ab.LastLongitude,ab.LastLatitude,AUTStation.Lng,AUTStation.Lat) from AUTLineStation
                                                                                inner join AUTStation on AUTLineStation.StationCode = AUTStation.Code
                                                                                 where Priority in (select Priority+1 from AUTLineStation where StationCode = s.Code and LineCode =" + param[0].ToString() + @") and LineCode =" + param[0].ToString() + @"))Distance2Station
                                                                                from AutBusPassingStations a 
                                                                                left join AUTStation s on a.StationCode=s.Code
                                                                                left join AUTBus ab on a.BusNumber = ab.BUSNumber
                                                                                where a.BusNumber in (
                                                                                select BusNumber from AutBusPassingStations 
                                                                                where BusNumber in (select BusNumber from AUTBus where LastLineNumber = " + param[1].ToString() + @" and Active = 1 and IsValid = 1 and cast(LastDate as date) = cast(GETDATE() as date))
                                                                                and cast(EventDate as date) = cast(GETDATE() as date)
                                                                                group by BusNumber
                                                                                )
                                                                                and a.EventDate in 
                                                                                (select Max(EventDate)MEventDate from AutBusPassingStations 
                                                                                where BusNumber in (select BusNumber from AUTBus where LastLineNumber = " + param[1].ToString() + @" and Active = 1 and IsValid = 1 and cast(LastDate as date) = cast(GETDATE() as date))
                                                                                and cast(EventDate as date) = cast(GETDATE() as date)
                                                                                group by BusNumber)
                                                                                and (select  IsBack from AUTLineStation where StationCode = a.StationCode and LineCode = " + param[0].ToString() + @") = 1");
            int StationBackFlag = 0;

            if (BusLineBack != null & BusLineBack.Rows.Count > 0)
            {
                //                for (int k = 0; k < BusLineBack.Rows.Count; k++)
                //                {
                //                    StrCalender += "<div id='" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"' 
                //                    style='float:right;background-color:red;color:white;text-align:center;width:50px;height:20px;'>" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"</div>";
                //                    StrScipt += @"var offsets" + k.ToString() + BusLineBack.Rows[k]["StationCode"].ToString() + " = $('#" + BusLineBack.Rows[k]["StationCode"].ToString() + @"').offset();
                //                                  document.getElementById('" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"').style.top = offsets" + k.ToString() + BusLineBack.Rows[k]["StationCode"].ToString() + @".top;
                //                                  document.getElementById('" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"').style.left = offsets" + k.ToString() + BusLineBack.Rows[k]["StationCode"].ToString() + ".left;";
                //                }
                if (DtStationListBack != null & DtStationListBack.Rows.Count > 0)
                {
                    for (int j = 0; j < DtStationListBack.Rows.Count; j++)
                    {
                        StationBackFlag = 0;
                        for (int k = 0; k < BusLineBack.Rows.Count; k++)
                        {
                            if (BusLineBack.Rows[k]["StationCode"].ToString() == DtStationListBack.Rows[j]["StationCode"].ToString())
                            {
                                StrCalender += "<div id='" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"' 
                                                style=""float:right;color:red;text-align:center;width:64px;height:43px;margin-right:1px;background-image:url('WebBusManagement/Images/bus_s64.png');background-repeat:no-repeat"">" + BusLineBack.Rows[k]["BusNumber"].ToString() + @"</div>";
                                StationBackFlag = 1;
                            }
                        }
                        if (StationBackFlag == 0)
                        {
                            StrCalender += "<div style='float:right;width:50px;height:20px;'></div>";
                        }
                    }
                }
            }

            StrCalender += "<div style='clear:both;height:15px'></div><hr /><div style='clear:both;height:15px'></div>";

            if (DtStationListBack != null & DtStationListBack.Rows.Count > 0)
            {
                for (int j = 0; j < DtStationListBack.Rows.Count; j++)
                {
                    StrCalender += @"<div id='" + DtStationListBack.Rows[j]["StationCode"].ToString() + @"' style=""float:right;width:32px;color:red;height:32px;background-image:url('WebBusManagement/Images/station_s32.png');background-repeat:no-repeat;text-align:center"" 
                                     onmouseover=""SetStationNameText('" + DtStationListBack.Rows[j]["StationName"].ToString() + @"')""
                                     onmouseout=""ClearStationNameText()"">" + DtStationListBack.Rows[j]["StationCode"].ToString() + @"</div><div style='float:right;width:50px;height:20px;'></div>";
                }
            }
            StrCalender += @"<div style='clear:both;height:50px'></div>
                             <div style='float:right;width:200px;height:20px;background-color:green;text-align:center;color:white'>مسیر برگشت خط " + param[1].ToString() + @"</div>";

            StrCalender += @"<div style='clear: both; height: 5px'></div>
                                <div style=""width: 3000px; height: 50px; margin-right: auto; margin-left: auto; text-align: center; font-size: 20px"" id=""StationNameHtmlDiv"">
                                </div>";

            DataTable DtStationListForLegend = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,a.StationCode,b.Name StationName,b.Lat,b.Lng from AUTLineStation a
                                                                                    left join AutStation b on a.StationCode = b.Code
                                                                                    where a.LineCode = " + Line.ToString() + @"
                                                                                    order by a.[Priority]");
            if (DtStationListForLegend != null)
            {
                if (DtStationListForLegend.Rows.Count > 0)
                {
                    StrCalender += @"<div style='clear:both;height:50px'></div>";
                    for (int i = 0; i < DtStationListForLegend.Rows.Count; i++)
                    {
                        StrCalender += @"<div style='float:right;width:200px;height:20px;background-color:white;text-align:right;color:black;border:1px solid black'>"
                            + DtStationListForLegend.Rows[i]["StationCode"].ToString() + " - " + DtStationListForLegend.Rows[i]["StationName"].ToString() + @"</div><div style='clear:both'></div>";
                    }
                }
            }

            return new string[] { StrCalender };
        }


    }
}