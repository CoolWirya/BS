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
                //txtStartTimeHour.Text = "00";
                //txtStartTimeMinute.Text = "00";
                //txtFinishTimeHour.Text = "23";
                //txtFinishTimeMinute.Text = "59";
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
                    WhereStr += @" and atdpob.[Date] between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and atdpob.[Date] between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }
            }

            Query = @"select top 100 percent max(atdpob.Code)Code,ab.BusNumber,ab.LastLineNumber,
                        atdpob.CardType,atdpob.[Date],sum(atdpob.TCount)TransactionCount,sum(atdpob.Price)InCome,
                        case max(cast(atdpob.FrontDoor as int)) when 1 then N'بلي' else N'خير' end SendFromFrontDoor,
                        case max(cast(atdpob.BackDoor as int)) when 1 then N'بلي' else N'خير' end SendFromBackDoor
                        from AUTDailyPerformanceRportOnBus atdpob
                        left join AutBus ab on ab.Code = atdpob.BusCode
                        where atdpob.Error = 0 and atdpob.CardType = 0 and atdpob.TicketPrice > 0 and atdpob.Tcount > 0 and 
                        (cast(atdpob.FrontDoor as int)=0 or cast(atdpob.BackDoor as int)=0) " + WhereStr + @"
                        group by ab.BusNumber,ab.LastLineNumber,atdpob.CardType,atdpob.[Date]";

            return Query;
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusFailureDoors");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusFailureDoorsReportControl_"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = GetReportQuery(StartEventDate, EndEventDate, StartTime, EndTime);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusFailureDoorsReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //TimeSpan TsStartTime;
            //TimeSpan TsEndTime;
            //int TimeFlag = 0;
            //try
            //{
            //    TsStartTime = new TimeSpan(
            //            Convert.ToInt32(txtStartTimeHour.Text)
            //            , Convert.ToInt32(txtStartTimeMinute.Text), 0);
            //}
            //catch
            //{
            //    TsStartTime = new TimeSpan(0, 0, 0);
            //    TimeFlag = 1;
            //}

            //try
            //{
            //    TsEndTime = new TimeSpan(
            //            Convert.ToInt32(txtFinishTimeHour.Text)
            //            , Convert.ToInt32(txtFinishTimeMinute.Text), 0);
            //}
            //catch
            //{
            //    TsEndTime = new TimeSpan(0, 0, 0);
            //    TimeFlag = 1;
            //}

            //if (TimeFlag == 0)
            //{
            //    GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
            //        TsStartTime, TsEndTime);
            //}
            //else if (TimeFlag == 1)
            //{
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                null, null);
            //}
        }
    }
}