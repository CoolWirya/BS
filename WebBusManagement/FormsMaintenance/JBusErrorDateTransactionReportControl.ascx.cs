using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusErrorDateTransactionReportControl : System.Web.UI.UserControl
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
                WhereStrAnd += @" and convert(date,att.RecievedDate) between '" + StartEventDate.Value.Date.ToShortDateString() + "' and '" + EndEventDate.Value.Date.ToShortDateString() + "' ";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusErrorDateTransactionReport");
            jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusErrorDateTransactionReport" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"SELECT top 100 percent att.Code,att.FleetName,att.ZoneName,att.LineNumber,att.BusNumber,
                                att.CardType,att.ReaderId,att.TicketPrice * 10 as TicketPrice,att.RemainPrice * 10 as RemainPrice,att.EventDate,att.RecievedDate 
                                FROM AUTTicketTransaction att
                                WHERE (att.EventDate < '2013-03-21' OR att.EventDate > DATEADD(DAY,1,GETDATE()))
                                " + WhereStrAnd + @"";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusErrorDateTransactionReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}