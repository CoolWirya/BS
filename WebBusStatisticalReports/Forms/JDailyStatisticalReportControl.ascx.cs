using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusReports.Forms
{
    public partial class JDailyStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true)
            {
                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" where DP.[Date] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }
            }
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 percent DP.Code,DP.[Date] as DateEventDate,DP.TCount as TransactionCount,
                                                                                DP.Price as InCome
                                                                                from [dbo].[AUTDailyPerformanceRportOnBus] DP " + WhereStr);

            TransactionColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            lsTransaction.Name = "تعداد تراکنش در روز";
            //lsTransaction.LabelsAppearance.DataField = "DateEventDate";
            //lsTransaction.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsTransaction.LabelsAppearance.TextStyle.FontSize = 12;
            lsTransaction.DataFieldY = "TransactionCount";
            TransactionColumnChart.PlotArea.Series.Clear();
            TransactionColumnChart.PlotArea.XAxis.DataLabelsField = "DateEventDate";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            TransactionColumnChart.DataBind();

            IncomColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsIncome = new Telerik.Web.UI.ColumnSeries();
            lsIncome.Name = "میزان درآمد در روز";
            //lsIncome.LabelsAppearance.DataField = "DateEventDate";
            //lsIncome.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsIncome.LabelsAppearance.TextStyle.FontSize = 12;
            lsIncome.DataFieldY = "InCome";
            IncomColumnChart.PlotArea.Series.Clear();
            IncomColumnChart.PlotArea.XAxis.DataLabelsField = "DateEventDate";
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
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}