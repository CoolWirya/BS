using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Line;
using BusManagment.Documents;
using ClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JLinePeriodPaymentReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLines();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {


                btnSave_Click(null, null);
            }
        }

        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void GetReport(int LineCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JLinePeriodPaymentReportControl");
            jGridView.ClassName = "WebBusReports_JBusReports_GetReport_JLinePeriodPaymentReportControl" + LineCode.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = BusManagment.Documents.JAUTDocumentReport.GetLinePeriodPaymentWebQuery(LineCode, StartEventDate, EndEventDate);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JLinePeriodPaymentReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("PaymentPrice", 0);
            //jGridView.SumFields.Add("Bestankar", 0);
            jGridView.Bind();

        }

        public string GetSumStr = "";
        public void GetSum(int LineCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            GetSumStr = "";
            DataTable tableSum = JAUTDocumentReport.GetSumPeriodPaymentWebQuery(StartEventDate, EndEventDate);
            GetSumStr += "مجموع اسناد پرداختی در این دوره زمانی : " + JMoney.StringToMoney(tableSum.Rows[0]["PaymentPrice"].ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(Convert.ToInt32(cmbLine.SelectedValue),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            GetSum(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}