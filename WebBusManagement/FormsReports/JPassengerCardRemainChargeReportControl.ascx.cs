using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JPassengerCardRemainChargeReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void GetReport()
        {

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JPassengerCardRemainChargeReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JPassengerCardRemainChargeReportControl";
            jGridView.SQL = @"select c.Code,c.RfidNumber,c.LastCharge,c.LastChargeDate from Cards c
                                
                                where c.CardType = 0 and c.Status = 1 and c.LastCharge between 0 and 10000 and c.LastChargeDate<getdate()
                and c.LastChargeDate between " +
                "'" + ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().ToShortDateString() + "'" +
                " and " +
                "'" + ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate().ToShortDateString() + " 23:59:59'";

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = " LastChargeDate desc";
            jGridView.Title = "JPassengerCardRemainChargeReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("LastCharge", 0);
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport();
            }
            catch { }
        }

    }
}