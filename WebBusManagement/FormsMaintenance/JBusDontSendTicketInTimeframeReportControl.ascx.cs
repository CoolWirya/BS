using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusDontSendTicketInTimeframeReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                     ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = " where 1=1 ";
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and (select sum(TCount) from AUTDailyPerformanceRportOnBus where BusCode = ab.Code and [Date] Between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59') Is NULL";
            }

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusDontSendTicketInTimeframe");
            jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusDontSendTicketInTimeframe" + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select top 100 percent ab.Code Code,ab.BusNumber,ab.TicketLastDate,ab.LastSimCardCharge from AutBus ab"
                            + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "TicketLastDate desc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusDontSendTicketInTimeframe";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }

    }
}