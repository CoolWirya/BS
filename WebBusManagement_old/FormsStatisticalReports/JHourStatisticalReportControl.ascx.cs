using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusStatisticalReports.FormsStatisticalReports
{
    public partial class JHourStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
                txtStartTimeHour.Text = "07";
                txtStartTimeMinute.Text = "00";
                txtFinishTimeHour.Text = "08";
                txtFinishTimeMinute.Text = "00";
            }
        }

        public void GetReport(DateTime? StartEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            string WhereStr = " where 1=1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            DateTime StartDTime = DateTime.Now, EndDTime = DateTime.Now;
            if (StartEventDate.HasValue == true)
            {
                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,EventDate) between '" + StartEventDate.Value.Date + "' and '" + StartEventDate.Value.Date + "'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                     StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                     EndDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and EventDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }
            }
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT top 100 percent max(Code)Code,COUNT(*)TransactionCount,SUM(TicketPrice)InCome,
                                                                                cast (DATEPART(hour,'" +StartDTime.ToString()+@"') AS nvarchar)
                                                                                +N' - '+
                                                                                cast(DATEPART(hour,'" + EndDTime.ToString() + @"') AS NVARCHAR)HourEvent 
                                                                                FROM AUTTicketTransaction
                                                                             " + WhereStr);

            TransactionColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            lsTransaction.Name = "تعداد تراکنش در ساعت";
            //lsTransaction.LabelsAppearance.DataField = "DateEventDate";
            //lsTransaction.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsTransaction.LabelsAppearance.TextStyle.FontSize = 12;
            lsTransaction.DataFieldY = "TransactionCount";
            TransactionColumnChart.PlotArea.Series.Clear();
            TransactionColumnChart.PlotArea.XAxis.DataLabelsField = "HourEvent";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            TransactionColumnChart.DataBind();

            IncomColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsIncome = new Telerik.Web.UI.ColumnSeries();
            lsIncome.Name = "میزان درآمد در ساعت";
            //lsIncome.LabelsAppearance.DataField = "DateEventDate";
            //lsIncome.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsIncome.LabelsAppearance.TextStyle.FontSize = 12;
            lsIncome.DataFieldY = "InCome";
            IncomColumnChart.PlotArea.Series.Clear();
            IncomColumnChart.PlotArea.XAxis.DataLabelsField = "HourEvent";
            IncomColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            IncomColumnChart.PlotArea.Series.Add(lsIncome);
            IncomColumnChart.DataBind();

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
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate(),TsStartTime, TsEndTime);
            }
            else if (TimeFlag == 1)
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate(),null, null);
            }
        }
    }
}