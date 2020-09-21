using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Documents;
using ClassLibrary;

namespace WebBusReports.Forms
{
    public partial class JDocumentAndPaymentReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadBusOwner();
            }

            if (IsPostBack)
                btnSave_Click(null, null);
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetDataTable(0);
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
            DataTable dt = BusManagment.Bus.JBusOwners.GetAllOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { OwnerPCode = Convert.ToInt32(v["OwnerPCode"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { OwnerPCode = 0, Name = "همه" });
            cmbBusOwner.DataSource = p;
            cmbBusOwner.DataTextField = "Name";
            cmbBusOwner.DataValueField = "OwnerPCode";
            cmbBusOwner.DataBind();
        }

        public void GetReport(int OwnerCode = 0, int BusNumebr = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.SQL = BusManagment.Documents.JAUTDocumentReport.GetWebQuery(OwnerCode, BusNumebr);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDocumentAndPaymentReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        public string GetSumStr = "";
        public void GetSum(int OwnerCode = 0, int BusNumebr = 0)
        {
            GetSumStr = "";
            DataTable tableSum = JAUTDocumentReport.GetSumData(OwnerCode, BusNumebr);
            GetSumStr += "مجموع بدهکار : " + JMoney.StringToMoney(tableSum.Rows[0]["Bed"].ToString()) + "<br />";
            GetSumStr += "مجموع بستانکار : " + JMoney.StringToMoney(tableSum.Rows[0]["Bes"].ToString()) + "<br />";
            GetSumStr += "مانده : " + JMoney.StringToMoney((Convert.ToInt64(tableSum.Rows[0]["Bes"]) - Convert.ToInt64(tableSum.Rows[0]["Bed"])).ToString()) + "<br />";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue));
            GetSum(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue));
        }
    }
}