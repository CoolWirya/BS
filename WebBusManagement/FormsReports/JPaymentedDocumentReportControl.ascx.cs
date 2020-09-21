using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JPaymentedDocumentReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadBusOwner();
                LoadDounenmt();
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

        public void LoadDounenmt()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code from AUTDocument order by Code");
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Code"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbDocumentCode.DataSource = p;
            cmbDocumentCode.DataTextField = "Name";
            cmbDocumentCode.DataValueField = "Code";
            cmbDocumentCode.DataBind();
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

        public void GetReport(int OwnerCode = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DocumentCode = 0)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JPaymentedDocumentReportControl");
           jGridView.ClassName = "WebBusReports_JBusReports_GetReport_JPaymentedDocumentReportControl" + OwnerCode.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + DocumentCode.ToString();
            jGridView.SQL = BusManagment.Documents.JAUTDocumentReport.GetPaymentedDocumentWebQuery(OwnerCode, BusNumebr, StartEventDate, EndEventDate, DocumentCode);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPaymentedDocumentReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("Price", 0);
            jGridView.SumFields.Add("TransactionCount", 0);

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbDocumentCode.SelectedValue));
        }
    }
}