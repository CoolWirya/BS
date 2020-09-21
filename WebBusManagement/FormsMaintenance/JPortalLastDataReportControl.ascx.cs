using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JPortalLastDataReportControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //GetReportLastAvl();
            //GetReportLastTicket();
        }

        //public int GmtMintePlus = 210;
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

            //string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            //if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            //{
            //    GmtMintePlus = 270;
            //}

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JPortalLastDataReport");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JPortalLastDataReport";
            jGridView.SQL = @"SELECT TOP 1 aat.Code,ab.BUSNumber,aat.Latitude,aat.Longitude,aat.SimCardCharge,aat.BatteryCharge,aat.Speed
                                ,aat.EventDate,aat.RecievedDate 
                                FROM AUTAvlTransaction aat
                                LEFT JOIN AUTBus ab ON ab.Code = aat.BusCode
								where aat.EventDate > dateadd(day,-1,getdate())
                                ORDER BY aat." + SortField + @" DESC";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPortalLastDataReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAvl).GridView = jGridView;
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAvl).LoadGrid(true);
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
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JPortalLastDataReport");
            jGridView.SQL = @"SELECT TOP 1 Code,FleetName,ZoneName,LineNumber,BusNumber,CardType,TicketPrice * 10 as TicketPrice,RemainPrice * 10 as RemainPrice
                                ,EventDate,RecievedDate 
                                FROM AUTTicketTransaction
	                            where EventDate > dateadd(day,-1,getdate())
                                ORDER BY " + SortField + @" DESC";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPortalLastDataReportControl";
            jGridView.Buttons = "excel";
            
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReportLastAvl();
            GetReportLastTicket();
        }


    }
}