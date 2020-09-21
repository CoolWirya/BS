using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Documents;
using ClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JDocumentAndPaymentReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadBusOwner();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {


                btnSave_Click(null, null);
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadBusOwner()
        {
            DataTable dt = BusManagment.Bus.JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbBusOwner.DataSource = p;
            cmbBusOwner.DataTextField = "Name";
            cmbBusOwner.DataValueField = "Code";
            cmbBusOwner.DataBind();
        }

        public void GetReport(int OwnerCode = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusReports");
            jGridView.ClassName = "WebBusReports_JBusReports_GetReport_JDocumentAndPaymentReportControl" + OwnerCode.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = BusManagment.Documents.JAUTDocumentReport.GetWebQuery(OwnerCode, BusNumebr, StartEventDate, EndEventDate);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code,FaDate";
            jGridView.Title = "JDocumentAndPaymentReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("Bedehkar", 0);
            jGridView.SumFields.Add("Bestankar", 0);

            jGridView.Bind();
        }

        public string GetSumStr = "";
        public void GetSum(int OwnerCode = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            GetSumStr = "";
            DataTable tableSum = JAUTDocumentReport.GetSumData(OwnerCode, BusNumebr, StartEventDate, EndEventDate);
            GetSumStr += "مجموع بدهکار : " + JMoney.StringToMoney(tableSum.Rows[0]["Bed"].ToString()) + "<br />";
            GetSumStr += "مجموع بستانکار : " + JMoney.StringToMoney(tableSum.Rows[0]["Bes"].ToString()) + "<br />";
            GetSumStr += "مانده : " + JMoney.StringToMoney((Convert.ToInt64(tableSum.Rows[0]["Bes"]) - Convert.ToInt64(tableSum.Rows[0]["Bed"])).ToString()) + "<br />";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            GetSum(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}