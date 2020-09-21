using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusStatusMonthlyReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddMonths(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
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

        public void GetReport(double BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusStatusMonthlyReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusStatusMonthlyReportControl" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select tbl.*,(select sdf.Name +' - '+abf.[Description] Collate Persian_100_CI_AI from AUTBusFailure abf
                                left join subdefine sdf on sdf.Code = abf.BusFailureCode
                                where cast([Date] as date) = tbl.[Date] and BusCode = (select code from autbus where BUSNumber = tbl.BusNumber))BusFailureType
                                from (
                                select max(adprb.Code)Code,ab.BusNumber,adprb.[Date],adprb.TicketPrice,
                                Sum(adprb.Tcount)TransactionCount,Sum(adprb.price) InCome
                                from [AUTDailyPerformanceRportOnBus] adprb
                                left join AutBus ab on adprb.BusCode = ab.Code
                                where ab.BusNumber = " + BusNumebr + @"
                                and adprb.[Date] between '" + StartDTime.ToShortDateString() + @" 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59'
                                and adprb.[Error] = 0
                                group by ab.BusNumber,adprb.[Date],adprb.TicketPrice
                                )tbl";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "Date asc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusStatusMonthlyReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbBus.SelectedValue == "0")
            {
                GetReport(Convert.ToDouble(0),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            else
            {
                GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
        }

    }
}