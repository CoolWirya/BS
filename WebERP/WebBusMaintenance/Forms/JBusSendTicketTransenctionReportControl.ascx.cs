using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusMaintenance.Forms
{
    public partial class JBusSendTicketTransenctionReportControl : System.Web.UI.UserControl
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
                WhereStr = " where 1=1 ";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,att.EventDate) between '" + StartEventDate.Value.Date + "' and '" + EndEventDate.Value.Date + "'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and att.EventDate between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }
            }

            Query = @"SELECT top 100 percent max(att.Code)Code,att.FleetName,att.ZoneName,att.LineNumber,att.BusNumber,att.CardType,
                        COUNT(att.code)TransactionCount,SUM(att.TicketPrice)InCome,MAX(att.EventDate)LastTransactionDate
                        FROM AUTTicketTransaction att
                        " + WhereStr + @"
                        GROUP BY att.FleetName,att.ZoneName,att.LineNumber,att.BusNumber,att.CardType";

            return Query;
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusSendTicketTransenctionReport");
            jGridView.SQL = GetReportQuery(StartEventDate, EndEventDate, StartTime, EndTime);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusSendTicketTransenctionReportControl";
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