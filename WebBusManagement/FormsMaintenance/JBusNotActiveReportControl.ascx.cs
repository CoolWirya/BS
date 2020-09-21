using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusNotActiveReportReport : System.Web.UI.UserControl
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

        public int GmtMintePlus = 210;
        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStrAnd = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStrAnd += @" and convert(date,ab.LastDate) between '" + StartEventDate.Value.Date.ToShortDateString() + "' and '" + EndEventDate.Value.Date.ToShortDateString() + "' ";
            }

            string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            {
                GmtMintePlus = 270;
            }

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusNotActiveReportReport");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusNotActiveReportReport"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"SELECT top 100 percent ab.Code,ab.BUSNumber,ab.LastSimCardCharge,ab.LastBatteryCharge,ab.LastGsmAntenna,ab.LastGpsAntenna,
                                ab.TransactionsCount as TransactionCount,(ab.LastDate) AS LastTransactionDate
                                FROM AUTBus ab
                                WHERE ab.Active = 0 AND ab.BusNumber IN (SELECT BusSerial FROM AUTHeaderTransaction GROUP BY BusSerial)
                                " + WhereStrAnd+@"";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusNotActiveReportReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}