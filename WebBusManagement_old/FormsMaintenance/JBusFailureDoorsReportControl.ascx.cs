using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusFailureDoorsReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        public static string GetReportQuery(DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            string Query = "", WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || StartTime.HasValue == true)
            {
                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,at.EventDate) between '" + StartEventDate.Value.Date.ToShortDateString() + "' and '" + EndEventDate.Value.Date.ToShortDateString() + "'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and at.EventDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }
            }

            Query = @"SELECT top 100 percent MAX(at.Code) AS Code,at.FleetName,at.ZoneName,at.LineNumber,at.BusNumber,cast(at.EventDate AS date)NewEventDate,
                        case at.ReaderId when 1 then N'درب جلو' else N'درب عقب' end as SendDoor,
                        COUNT(at.TicketPrice) AS TransactionCount,SUM(at.TicketPrice) AS InCome
                        FROM AUTTicketTransaction at
                        WHERE 1=1  " + WhereStr + @"
						GROUP BY at.FleetName,at.ZoneName,
						at.LineNumber,at.BusNumber,cast(at.EventDate AS date),at.ReaderId
                        having COUNT(DISTINCT at.ReaderId)=1
						ORDER BY at.BusNumber";

            return Query;
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusFailureDoors");
            jGridView.SQL = GetReportQuery(StartEventDate, EndEventDate, StartTime, EndTime);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusFailureDoorsReportControl";
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
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    TsStartTime, TsEndTime);
            }
            else if (TimeFlag == 1)
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    null, null);
            }
        }
    }
}