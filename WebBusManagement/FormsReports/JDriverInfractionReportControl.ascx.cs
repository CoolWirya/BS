using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JDriverInfractionReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadFleets();
                LoadZones();
                LoadLines();
                LoadRules();
            }
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
            return new string[] { "" };
        }

        public void LoadFleets()
        {
            DataTable dt = BusManagment.Fleet.JFleets.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbFleets.DataSource = p;
            cmbFleets.DataTextField = "Name";
            cmbFleets.DataValueField = "Code";
            cmbFleets.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadRules()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DataTable dt = null;
            try
            {
                DB.setQuery("select Code,Description from AUTRule");
                dt = DB.Query_DataTable();
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Description = v["Description"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Description = "همه" });
            cmbRule.DataSource = p;
            cmbRule.DataTextField = "Description";
            cmbRule.DataValueField = "Code";
            cmbRule.DataBind();
        }


        public void GetReport(int BusCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null
            , int Zone = 0
            , int Fleet = 0
            , int Line = 0
            , int HourOf = 0
            , int MinuteOf = 0
            , int HourTo = 0
            , int MinuteTo = 0
            , int Rule = 0
            //, int BusServiceCode = 0
           )
        {
            
            // DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select top 10 Code,(select BusNumber from AUTBUS where Code = BusCode) BusNumber,StartDate ,EndDate from dbo.AUTInfractionRegister where Code = " + BusServiceCode.ToString(), false);

            string WhereStr = " where cast(startDate as Date) = cast(EndDate as date) ";
            if (BusCode > 0)
                WhereStr += " and BusCode=" + BusCode;
            if (Zone > 0)
                WhereStr += " and BusCode in (select code from AUTBus where LastLineNumber in (select linenumber from autline where ZoneCode = " + Zone + "))";
            if (Fleet > 0)
                WhereStr += " and BusCode in (select code from AUTBus where FleetCode = " + Fleet + ")";
            if (Line > 0)
                WhereStr += " and BusCode in (select code from AUTBus where LastLineNumber = (select linenumber from autline where Code = " + Line + "))";
            if (Rule > 0)
                WhereStr += " and rul.Code = " + Rule.ToString();

            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and StartDate between '" + StartEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "") + "'";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JDriverInfractionReportControl_" + BusCode.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" + Fleet.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"IF OBJECT_ID('TEMPDB..#T') IS NOT NULL  drop table #T
                              IF OBJECT_ID('TEMPDB..#tvTableD') IS NOT NULL  drop table #tvTableD
             

				select * into #T from 
				(
					select StartDate+StartTime StartDate,EndDate+EndTime EndDate
					,BusCode,(select Name collate Persian_100_CI_AI 
					from AUTBusEventDetailes where code=BusEventDetailesCode) Comment from AUTBusEventRegister where StartDate is not null and StartTime is not null and ISDATE(StartTime) = 1 
                    and StartDate Between '" + StartEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "") + @"'
					and BusEventDetailesCode<100
					union 

					select ATB.StartTime,ATB.FinishTime
					,AT.BusCode,case when EzamBe=0 then N'سرویس' else (select Name from subdefine where code=EzamBe) end Comment 
					from AutTarrifEzamBe ATB inner join AUTTariff AT on ATB.TarrifCode=AT.Code
	                where ATB.StartTime between '" + StartEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "") + @"'
    		    ) A

	select BusCode,Speed,EventDate into #tvTableD from autavltransaction a  where EventDate between '" + StartEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "") + @"'
	group by BusCode,Speed,EventDate

	  <#PreviusSQL#> 

                select
                infraction.Code
                ,(select BusNumber from AUTBus where code= BUSCode) BusNumber
				,(Select Name from clsAllPerson where code = infraction.DriverPCodeStart) DriverName
                ,(select (select name from autZone where code=ZoneCode) from AUTLine where code= LineCodeStart) ZoneStart
                ,(select (select name from autZone where code=ZoneCode) from AUTLine where code= LineCodeEnd) ZoneEnd
                ,(select LineNumber from AUTLine where code= LineCodeStart) LineStart
                ,(select LineNumber from AUTLine where code= LineCodeEnd) LineEnd
                ,rul.Description
				,(select avg(speed) from #tvTableD a  where a.buscode=infraction.buscode and a.eventdate between infraction.startdate and infraction.enddate and infraction.RuleCode='4')OverSpeed
                ,dbo.DateEnToFaWithTime(StartDate) StartDate
                ,dbo.DateEnToFaWithTime(EndDate) EndDate
				,case when datediff(second,StartDate,EndDate) / 3600 = 0 then '00' else cast(datediff(second,StartDate,EndDate) / 3600 as nvarchar(10)) end
				+':'+case when datediff(second,StartDate,EndDate) % 3600 / 60 = 0 then '00' else cast(datediff(second,StartDate,EndDate) % 3600 / 60 as nvarchar(10)) end
				+':'+case when datediff(second,StartDate,EndDate) %3600 % 60 = 0 then '00' else cast(datediff(second,StartDate,EndDate) % 3600 % 60 as nvarchar(10)) end WTime
				,ISNULL((select top 1 Comment from #T a where a.BusCode = infraction.BusCode and a.StartDate between infraction.StartDate and infraction.EndDate OR a.EndDate between infraction.StartDate and infraction.EndDate),'') EventName
                from 
				dbo.AUTInfractionRegister infraction
                inner join AUTRule rul on rul.Code = infraction.RuleCode " + WhereStr;            
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDriverInfractionReportControl";
            jGridView.PageOrderByField = "StartDate desc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JDriverInfractionReportControl._BusServiceShowMap", null, null));

            jGridView.Bind();
        }

        public string _BusServiceShowMap(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusInfractionShowMapUpdateControl"
                  , "~/WebBusManagement/FormsReports/JBusInfractionShowMapUpdateControl.ascx"
                  , "نمایش مسیر سرویس روی نقشه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedItem.Value)
                , ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().AddHours(Int32.Parse(txtHourOf.Text)).AddMinutes(Int32.Parse(txtMinuteOf.Text))
                , ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate().AddHours(Int32.Parse(txtHourTo.Text)).AddMinutes(Int32.Parse(txtMinuteTo.Text))
                , Convert.ToInt32(cmbZone.SelectedItem.Value)
                , Convert.ToInt32(cmbFleets.SelectedItem.Value)
                , Convert.ToInt32(cmbLine.SelectedItem.Value)
                , Convert.ToInt32(txtHourOf.Text)
                , Convert.ToInt32(txtMinuteOf.Text)
                , Convert.ToInt32(txtHourTo.Text)
                , Convert.ToInt32(txtMinuteTo.Text)
                , Convert.ToInt32(cmbRule.SelectedItem.Value));

            }
            catch { }
        }

        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                var p = (from v in dtZones.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();

                DataTable dtBus = BusManagment.Bus.JBuses.GetAllBusesOnly(int.Parse(cmbLine.SelectedValue));
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadZones();
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select top 1 ZoneCode From AutLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + "))");
                var p2 = (from v in dtZones.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p2;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
                LoadLines();
            }
        }

    }
}
