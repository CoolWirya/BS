using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JDailyReport : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                cmbBus.SelectedIndex = 0;
                ((WebControllers.MainControls.Date.JDateControl)dteControlDay).SetDate(ClassLibrary.JDateTime.Now());
            }
            else
            {


                btnSave_Click(null, null);
            }
        }
        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(int.Parse(cmbBus.SelectedItem.Text),
                ((WebControllers.MainControls.Date.JDateControl)dteControlDay).GetDate(),
                cmbstate.SelectedValue.ToString() == "1" ? true : false);

        }

        /// <summary>
        /// Get report in a day
        /// </summary>
        private void GetReport(int busNumber = 0, DateTime? StartDate = null, bool State = false)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.ClassName = "WebBusReports_JBusReports_GetReport_DailyReport_" + busNumber.ToString() + "_" + StartDate.Value.ToShortDateString() + "_" + State.ToString();
            jGridView.SQL = BusManagment.JBusPrintReports.GetDailyPrintReportWithState(busNumber, StartDate.Value.ToString("u").Split(' ')[0], State ? "1" : "0");
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDailyReports";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();

        }
    }
}