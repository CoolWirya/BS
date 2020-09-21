using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

namespace WebBusReports.Forms
{
    public partial class JBusStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = v["Code"].ToString(), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = "0", BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int[] BusNumberForLstBus = new int[lstBus.Items.Count];
            for (int i = 0; i < lstBus.Items.Count; i++)
            {
                BusNumberForLstBus[i] = Convert.ToInt32(lstBus.Items[i].Value.ToString());
            }
            GetReport(BusNumberForLstBus, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }

        public void GetReport(int[] BusNumebr, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(BusManagment.Bus.JBuses.GetWebBusPerPerformanceReportQueryWithMuliBus(BusNumebr, StartEventDate, EndEventDate));

            TransactionColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            lsTransaction.Name = "تعداد تراکنش اتوبوس ها";
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
            lsIncome.Name = "میزان درآمد اتوبوس ها";
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

        protected void BtnInsertBus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) != 0)
            {
                RadListBoxItem NewItem = new RadListBoxItem();
                NewItem.Value = cmbBus.SelectedValue;
                NewItem.Text = cmbBus.SelectedItem.Text;
                lstBus.Items.Add(NewItem);
            }
        }

    }
}