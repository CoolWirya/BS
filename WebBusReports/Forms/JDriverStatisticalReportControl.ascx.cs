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
    public partial class JDriverStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDriver();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void LoadDriver()
        {
            DataTable dt = BusManagment.Personel.JPersonels.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Name = v["Name"].ToString(), PersonCode = v["PersonCode"].ToString() }).ToList();
            p.Insert(0, new { Name = "همه", PersonCode = "0" });
            cmbDriver.DataSource = p;
            cmbDriver.DataTextField = "Name";
            cmbDriver.DataValueField = "PersonCode";
            cmbDriver.DataBind();
        }

        protected void BtnInsertDriver_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbDriver.SelectedValue) != 0)
            {
                RadListBoxItem NewItem = new RadListBoxItem();
                NewItem.Value = cmbDriver.SelectedValue;
                NewItem.Text = cmbDriver.SelectedItem.Text;
                lstDriver.Items.Add(NewItem);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int[] DriverNumberForLstDriver = new int[lstDriver.Items.Count];
            for (int i = 0; i < lstDriver.Items.Count; i++)
            {
                DriverNumberForLstDriver[i] = Convert.ToInt32(lstDriver.Items[i].Value.ToString());
            }
            GetReport(DriverNumberForLstDriver, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }


        public void GetReport(int[] DriverNumber, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(BusManagment.Driver.JDriverseLogs.GetWebDriverPerformanceReportQueryWithMultiDriver(DriverNumber, StartEventDate, EndEventDate));

            TransactionColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            lsTransaction.Name = "تعداد تراکنش رانندگان";
            lsTransaction.LabelsAppearance.DataField = "DriverName";
            lsTransaction.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            lsTransaction.LabelsAppearance.TextStyle.FontSize = 14;
            lsTransaction.DataFieldY = "TransactionCount";
            TransactionColumnChart.PlotArea.Series.Clear();
            TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            TransactionColumnChart.DataBind();

            IncomColumnChart.DataSource = DtReport;
            Telerik.Web.UI.ColumnSeries lsIncome = new Telerik.Web.UI.ColumnSeries();
            lsIncome.Name = "میزان درآمد رانندگان";
            lsIncome.LabelsAppearance.DataField = "DriverName";
            lsIncome.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            lsIncome.LabelsAppearance.TextStyle.FontSize = 14;
            lsIncome.DataFieldY = "InCome";
            IncomColumnChart.PlotArea.Series.Clear();
            IncomColumnChart.PlotArea.Series.Add(lsIncome);
            IncomColumnChart.DataBind();

        }

    }
}