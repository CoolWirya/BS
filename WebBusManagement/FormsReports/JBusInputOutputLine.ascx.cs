using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusInputOutputLine : System.Web.UI.UserControl
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

        public void GetReport(int BusCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null
            , int Zone = 0
            , int Fleet = 0
            , int Line = 0
            , int HourOf = 0
            , int MinuteOf = 0
            , int HourTo = 0
            , int MinuteTo = 0)
        {
            string WhereStr = " where 1 = 1 ";
            if (BusCode > 0)
                WhereStr += " and BusCode=" + BusCode;
            if (Zone > 0)
                WhereStr += " and BusCode in (select code from AUTBus where LastLineNumber = (select linenumber from autline where ZoneCode = " + Zone + "))";
            if (Fleet > 0)
                WhereStr += " and BusCode in (select code from AUTBus where FleetCode = " + Fleet + ")";
            if (Line > 0)
                WhereStr += " and BusCode in (select code from AUTBus where LastLineNumber = " + Line + ")";
            
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and StartDate between '" + StartEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "") + "'";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusPassingStationTicketReportControl_" + BusCode.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" + Fleet.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"
select 
Code
,(select BusNumber from AUTBus where code= BUSCode) BusNumber
,(select LineNumber from AUTLine where code= LineCodeStart) LineStart
,(select LineNumber from AUTLine where code= LineCodeEnd) LineEnd
,Case when isIn=1 THEN N'داخل خط' else N'خارج از خط' end State
,dbo.DateEnToFaWithTime(StartDate) StartDate
,dbo.DateEnToFaWithTime(EndDate) EndDate
,(select Name from clsAllPerson where code= DriverPCodeStart) DriverStart
,(select Name from clsAllPerson where code= DriverPCodeEnd) DriverEnd
,null StreetStart
,null StreetEnd
from AUTInOutBusLine" + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusPassingStationTicketReportControl";
            jGridView.PageOrderByField = "StartDate desc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedItem.Value)
                ,((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().AddHours(Int32.Parse(txtHourOf.Text)).AddMinutes(Int32.Parse(txtMinuteOf.Text))
                , ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate().AddHours(Int32.Parse(txtHourTo.Text)).AddMinutes(Int32.Parse(txtMinuteTo.Text))
                ,Convert.ToInt32(cmbZone.SelectedItem.Value)
                , Convert.ToInt32(cmbFleets.SelectedItem.Value)
                , Convert.ToInt32(cmbLine.SelectedItem.Value)
                , Convert.ToInt32(txtHourOf.Text)
                , Convert.ToInt32(txtMinuteOf.Text)
                , Convert.ToInt32(txtHourTo.Text)
                , Convert.ToInt32(txtMinuteTo.Text));

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