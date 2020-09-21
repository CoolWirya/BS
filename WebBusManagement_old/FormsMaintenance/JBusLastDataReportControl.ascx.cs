using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusLastDataReportControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //GetReport();
        }

        public int GmtMintePlus = 210;
        public void GetReport()
        {
            string SortField = "";
            if (rbtSortByNewAvlTransaction.Checked == true)
            {
                SortField = "LastDate";
            }
            else
            {
                SortField = "TicketLastDate";
            }

            string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            {
                GmtMintePlus = 270;
            }

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusLastDataReport");
            jGridView.SQL = @"SELECT TOP 100 PERCENT ab.Code,BUSNumber,cap.Name AS DriverName,LastSimCardCharge,LastBatteryCharge,LastSpeed,
                                dateadd(minute," + GmtMintePlus.ToString() + @",LastDate) AS LastAvlTransactionDate,TicketLastDate
                                FROM AUTBus ab
                                LEFT JOIN clsAllPerson cap ON ab.LastPersonCode = cap.Code 
                                ORDER BY " + SortField + @" DESC";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusLastDataReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport();
        }
    }
}