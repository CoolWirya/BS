using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JStationTicketReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadFleets();
                LoadZones();
                LoadLines();
                LoadStation();
            }
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
            //if (cmbFleets.Items.Count > 1)
            //{
            //    cmbFleets.SelectedIndex = 1;
            //}
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

        public void LoadStation()
        {
            DataTable dt = BusManagment.Station.JStations.GetDataTableForComboBox();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), StationName = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, StationName = "همه" });
            cmbStation.DataSource = p;
            cmbStation.DataTextField = "StationName";
            cmbStation.DataValueField = "Code";
            cmbStation.DataBind();
        }

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null
            , int Zone = 0
            , int Fleet = 0
            , int Line = 0
            , int Station = 0
            , int HourOf = 0
            , int MinuteOf = 0
            , int HourTo = 0
            , int MinuteTo = 0
            , int Path = 0)
        {
            string WhereStr = " where 1 = 1 ", WhereDateStr = "";
            if (BusNumebr > 0)
                WhereStr += " and Code in (select StationCode from AutBusPassingStations where BusNumber in (select BusNumber from autBus where Code="+BusNumebr+"))";
            if (Zone > 0)
                WhereStr += " and Code in (select StationCode from AUTLineStation where LineCode in (select Code from AUTLine where ZoneCode=" + Zone + @")) ";
            if (Fleet > 0)
                WhereStr += " and Code in (select StationCode from AutBusPassingStations where BusNumber in (select BusNumber from autbus where fleetCode = " + Fleet + "))";
            if (Line > 0)
                WhereStr += " and Code in (select StationCode from AUTLineStation where LineCode=" + Line + ") ";
            if (Station > 0)
                WhereStr += " and Code=" + Station;
            WhereStr += " and Code in (select StationCode from AUTLineStation where IsBack = "+Path+") ";
            
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereDateStr += " and date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusPassingStationTicketReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" + Fleet.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"
IF OBJECT_ID('tempdb..#TimerPic') IS NOT NULL DROP Table #TimerPic
DECLARE @TimeCounter Time
set @TimeCounter = '" + HourOf + ":" + MinuteOf + @"'

DECLARE @TimeInterval int
set @TimeInterval = " + int.Parse(txtTimeInterval.Text) * 60 + @"

select cast(@TimeCounter as Time) StartTime,dateadd(second,@TimeInterval-1,cast(@TimeCounter as Time)) EndTime into #TimerPic

WHILE @TimeCounter<'" + HourTo + ":" + MinuteTo + @"'
BEGIN
	set @TimeCounter = dateadd(second,@TimeInterval,@TimeCounter)
	insert into #TimerPic
		select cast(@TimeCounter as Time) StartTime,dateadd(second,@TimeInterval-1,cast(@TimeCounter as Time)) EndTime
END
<#PreviusSQL#>
select Code,Name,StartTime,EndTime,
(SELECT isnull(sum(COUNT),0)/case when count(*)=0 then 1 else count(*) end  AverageCount 
	from AUTBusStationTicketCount abst where abst.StationCode = A.code 
		and  cast(CurrentStation_SeeTime as Time) between StartTime and EndTime
		" + WhereDateStr + @") AverageCount,
(SELECT isnull(sum(COUNT),0)  TotlaCount											   
	from AUTBusStationTicketCount abst where abst.StationCode = A.code 
    	and  cast(CurrentStation_SeeTime as Time) between StartTime and EndTime
	    " + WhereDateStr + @") TotlaCount
from AUTStation A inner join #TimerPic on 1=1 
" + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusPassingStationTicketReportControl";
            jGridView.PageOrderByField = "AverageCount desc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedItem.Value)
                ,((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate()
                ,((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate()
                , Convert.ToInt32(cmbZone.SelectedItem.Value)
                , Convert.ToInt32(cmbFleets.SelectedItem.Value)
                , Convert.ToInt32(cmbLine.SelectedItem.Value)
                , Convert.ToInt32(cmbStation.SelectedItem.Value)
                , Convert.ToInt32(txtHourOf.Text)
                , Convert.ToInt32(txtMinuteOf.Text)
                , Convert.ToInt32(txtHourTo.Text)
                , Convert.ToInt32(txtMinuteTo.Text)
                , Convert.ToInt32(cmbPathType.SelectedItem.Value));

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

//                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
//                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
//                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
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