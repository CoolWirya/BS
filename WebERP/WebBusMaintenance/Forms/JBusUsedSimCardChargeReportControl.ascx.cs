using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusMaintenance.Forms
{
    public partial class JBusUsedSimCardChargeReport : System.Web.UI.UserControl
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
                WhereStrAnd += @" where convert(date,aal.EventDate) between '" + StartEventDate.Value.Date + "' and '" + EndEventDate.Value.Date + "' ";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusUsedSimCardChargeReport");
            jGridView.SQL = @"SELECT TOP 100 percent max(aal.Code)Code,ab.BUSNumber,at.IMEI,MAX(aal.SimCardCharge)FirstPeriodCharge,MIN(aal.SimCardCharge)LastPeriodCharge,
                                (MAX(aal.SimCardCharge)-MIN(aal.SimCardCharge))UsedCharge,COUNT(aal.Code)TransactionCount,
                                (CAST((MAX(aal.SimCardCharge)-MIN(aal.SimCardCharge)) AS FLOAT) / COUNT(aal.Code))UsedChargePerTransaction
                                FROM AUTAvlTransaction aal
                                LEFT JOIN AUTHeaderTransaction at ON aal.HeaderTransactionCode = at.Code
                                LEFT JOIN AUTBus ab ON aal.BusCode = ab.Code
                                "+WhereStrAnd+@"
                                GROUP BY ab.BUSNumber,at.IMEI";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusUsedSimCardChargeReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}