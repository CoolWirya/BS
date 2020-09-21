using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JZonesStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void GetReport(int ZoneCode = 0, int DayType = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(BusManagment.Zone.JZones.GetWebReportQuery(ZoneCode, DayType, StartEventDate, EndEventDate));

            TransactionColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            lsTransaction.Name = "تعداد تراکنش مناطق";
            //lsTransaction.LabelsAppearance.DataField = "ColumnName";
            //lsTransaction.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsTransaction.LabelsAppearance.TextStyle.FontSize = 14;
            lsTransaction.DataFieldY = "TransactionCount";
            TransactionColumnChart.PlotArea.Series.Clear();
            TransactionColumnChart.PlotArea.XAxis.DataLabelsField = "ColumnName";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            TransactionColumnChart.DataBind();

            IncomColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsIncome = new Telerik.Web.UI.ColumnSeries();
            lsIncome.Name = "میزان درآمد مناطق";
            //lsIncome.LabelsAppearance.DataField = "ColumnName";
            //lsIncome.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //lsIncome.LabelsAppearance.TextStyle.FontSize = 14;
            lsIncome.DataFieldY = "InCome";
            IncomColumnChart.PlotArea.Series.Clear();
            IncomColumnChart.PlotArea.XAxis.DataLabelsField = "ColumnName";
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
            GetReport(0, 0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}