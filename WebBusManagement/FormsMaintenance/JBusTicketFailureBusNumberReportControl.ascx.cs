using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusTicketFailureBusNumberReportControl : System.Web.UI.UserControl
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
                btnSave_Click(null, null);
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStrAnd = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStrAnd += @" and AUTT.EventDate between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59' ";
            }
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusTicketFailureBusNumberReport");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusTicketFailureBusNumberReport"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"SELECT top 100 percent max(AUTT.Code)Code,AUTT.FleetName,AUTT.ZoneName,AUTT.LineNumber,AUTT.BusNumber,MIN(AUTT.EventDate)FromDate,MAX(AUTT.EventDate)ToDate,
                                COUNT(AUTT.BusNumber)TransactionCount,SUM(AUTT.TicketPrice) * 10 as InCome
                                FROM [dbo].[AUTTicketTransaction] AUTT
                                WHERE LEN(AUTT.BusNumber)<>4  " + WhereStrAnd + @" 
                                GROUP BY AUTT.FleetName,AUTT.ZoneName,AUTT.LineNumber,AUTT.BusNumber";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusTicketFailureBusNumberReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}