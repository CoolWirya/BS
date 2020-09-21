using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JBusDontLoginReportControl : System.Web.UI.UserControl
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
            }
        }

        public void GetReport(DateTime? StartEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusDontLoginReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JDriversLoginLogoutReportControl_" + StartEventDate.Value.ToShortDateString();
            jGridView.SQL = @"select 1 Code,a.BusNumber from (
                            select BusNumber from AUTShiftDriver where Startdate between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' and '" + StartEventDate.Value.ToShortDateString() + @" 23:59:59'
                            and CardType = 0 and Error = 0 and len(BusNumber) = 4 and BusNumber in (select BusNumber from AUTBus where Active = 1 and IsValid = 1)                            
                            group by BusNumber
                            )a
                            where a.BusNumber not in
                            (
                            select BusNumber from AUTDriversLoginLogout
                            where Date = '" + StartEventDate.Value.ToShortDateString() + @"'
                            Group by BusNumber
                            ) ";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusDontLoginReportControl";
            jGridView.PageOrderByField = " BusNumber";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate());
        }

    }
}