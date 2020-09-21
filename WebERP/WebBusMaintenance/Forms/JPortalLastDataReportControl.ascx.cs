using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusMaintenance.Forms
{
    public partial class JPortalLastDataReportControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GetReportLastAvl();
            GetReportLastTicket();
        }

        public void GetReportLastAvl()
        {
            string SortField = "";
            if (rbtSortByEventDate.Checked == true)
            {
                SortField = "EventDate";
            }
            else
            {
                SortField = "RecievedDate";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JPortalLastDataReport");
            jGridView.SQL = @"SELECT TOP 1 aat.Code,ab.BUSNumber,aat.Latitude,aat.Longitude,aat.SimCardCharge,aat.BatteryCharge,aat.Speed
                                ,aat.EventDate,aat.RecievedDate 
                                FROM AUTAvlTransaction aat
                                LEFT JOIN AUTBus ab ON ab.Code = aat.BusCode
                                ORDER BY aat." + SortField + @" DESC";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPortalLastDataReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAvl).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAvl).LoadGrid(true);
        }

        public void GetReportLastTicket()
        {
            string SortField = "";
            if (rbtSortByEventDate.Checked == true)
            {
                SortField = "EventDate";
            }
            else
            {
                SortField = "RecievedDate";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JPortalLastDataReport");
            jGridView.SQL = @"SELECT TOP 1 Code,FleetName,ZoneName,LineNumber,BusNumber,CardType,TicketPrice,RemainPrice,EventDate,RecievedDate 
                                FROM AUTTicketTransaction
                                ORDER BY " + SortField + @" DESC";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPortalLastDataReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReportLastAvl();
            GetReportLastTicket();
        }


    }
}