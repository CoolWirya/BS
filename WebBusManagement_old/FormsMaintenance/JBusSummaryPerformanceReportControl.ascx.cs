using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusSummaryPerformanceReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                txtStartTimeHour.Text = "00";
                txtStartTimeMinute.Text = "01";
                txtFinishTimeHour.Text = "23";
                txtFinishTimeMinute.Text = "59";
            }
            else
            {
                btnSave_Click(null, null);
            }
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

        public static string GetBusSummaryPerformanceReportQuery(int BusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            string Query = "", WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || StartTime.HasValue == true || BusCode > 0)
            {
                if (BusCode > 0)
                    WhereStr += " and at.BusCode=" + BusCode;

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,at.EventDate) between '" + StartEventDate.Value.Date.ToShortDateString() + "' and '" + EndEventDate.Value.Date.ToShortDateString() + "'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and at.EventDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }
            }

            Query = @"select TOP 100 percent at.BusCode AS Code,ab.BUSNumber,az.Name ZoneName,al.LineNumber,ath.IMEI,
                        case at.ReaderId WHEN 1 THEN N'درب جلو' ELSE N'درب عقب' END AS ReaderType,
                        COUNT(at.Code)TicketCount,SUM(at.TicketPrice)SumPrice 
                        from [dbo].[AUTTicketTransaction] at
                        LEFT JOIN AUTBus ab ON at.BusCode = ab.Code
                        LEFT JOIN AUTHeaderTransaction ath ON at.HeaderTransactionCode=ath.Code
                        LEFT JOIN AUTLine al ON at.LineNumber=al.LineNumber
                        LEFT JOIN AUTZone az ON al.ZoneCode=az.Code
                        where at.ReaderId>0 " + WhereStr + @"
                        group by at.BusCode,at.ReaderId,ab.BUSNumber,az.Name,al.LineNumber,ath.IMEI
                        ORDER BY ab.BUSNumber,at.ReaderId";

            return Query;
        }

        public void GetReport(int BusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusSummaryPerformance");
            jGridView.SQL = GetBusSummaryPerformanceReportQuery(BusCode, StartEventDate, EndEventDate, StartTime, EndTime);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusSummaryPerformanceReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimeSpan TsStartTime;
            TimeSpan TsEndTime;
            int TimeFlag = 0;
            try
            {
                TsStartTime = new TimeSpan(
                        Convert.ToInt32(txtStartTimeHour.Text)
                        , Convert.ToInt32(txtStartTimeMinute.Text), 0);
            }
            catch
            {
                TsStartTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            try
            {
                TsEndTime = new TimeSpan(
                        Convert.ToInt32(txtFinishTimeHour.Text)
                        , Convert.ToInt32(txtFinishTimeMinute.Text), 0);
            }
            catch
            {
                TsEndTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            if (TimeFlag == 0)
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    TsStartTime, TsEndTime);
            }
            else if (TimeFlag == 1)
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    null, null);
            }
        }
    }
}