using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JLinePerformanceAverageReportControl : System.Web.UI.UserControl
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
                LoadLines();
                LoadZones();
                LoadFleets();
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
            if (cmbFleets.Items.Count > 1)
            {
                cmbFleets.SelectedIndex = 1;
            }
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

        public void GetReport(int ZoneCode = 0, int LineNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int FleetCode = 0, int ReportType = 1)
        {
            string WhereStr = "", WhereStr2 = "";
            if (FleetCode > 0)
                WhereStr += " and FleetCode = " + FleetCode;
            if (ZoneCode > 0)
                WhereStr2 += " and a.LineNumber in (select LineNumber from AUTLine where ZoneCode = " + ZoneCode + ") ";
            if (LineNumber > 0)
                WhereStr2 += " and a.LineNumber = " + LineNumber;
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusReports_JLinePerformanceAverageReportControl");
           jGridView.ClassName = "WebBusReports_JBusReports_GetReport_JLinePerformanceAverageReportControl_" + ZoneCode.ToString() + "_" + LineNumber.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + FleetCode.ToString() + "_" + ReportType.ToString();
            if (ReportType == 1)
                jGridView.SQL = @"select 1 Code,a.LineNumber,count(a.BusNumber)BusCount,sum(a.TConut)TransactionCount,sum(a.TConut)/count(a.BusNumber) AvgPerBus
                                    ,(select TransactionCount from AUTDailyLineTransactionCount where LineCode = (select Code from AUTLine where LineNumber = a.LineNumber)) * count(a.BusNumber) KolleTahod
                                    ,(select TransactionCount from AUTDailyLineTransactionCount where LineCode = (select Code from AUTLine where LineNumber = a.LineNumber)) / count(a.BusNumber) AvgTahod
                                     from (
                                    select LineNumber,BusNumber,sum(TCount)TConut from AUTShiftDriver
                                    where Startdate between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + @" 23:59:59'
                                    and CardType = 0 and Error = 0 and BusNumber in (select BusNumber from AUTBus where Active = 1 and IsValid = 1 " + WhereStr + @")
                                    and LineNumber in (select LineNumber from AUTLine)
                                    group by LineNumber,BusNumber
                                    )a
                                    where 1 = 1
                                     " + WhereStr2 + @"
                                    group by a.LineNumber";
            else
                jGridView.SQL = @"select 1 Code,a.LineNumber,a.BusNumber,count(a.DateE)DateN,sum(a.TConut)TConut,sum(a.TConut)/count(a.DateE) AvgPerBus from (
                                    select LineNumber,BusNumber,cast(startdate as date)DateE,sum(TCount)TConut from AUTShiftDriver
                                    where Startdate between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + @" 23:59:59'
                                    and CardType = 0 and Error = 0 and BusNumber in (select BusNumber from AUTBus where Active = 1 and IsValid = 1 " + WhereStr + @")
                                    and LineNumber in (select LineNumber from AUTLine)
                                    group by LineNumber,BusNumber,cast(startdate as date)
                                    )a
                                    where 1 = 1
                                    " + WhereStr2 + @"
                                    group by a.LineNumber,a.BusNumber";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JLinePerformanceAverageReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " LineNumber asc";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("TransactionCount", 0);
            //jGridView.SumFields.Add("InCome", 0);
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(Convert.ToInt32(cmbZone.SelectedValue),
                      Convert.ToInt32(cmbLine.SelectedValue),
                      ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                      ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                      Convert.ToInt32(cmbFleets.SelectedValue),
                      Convert.ToInt32(cmbReportType.SelectedValue));
        }

    }
}