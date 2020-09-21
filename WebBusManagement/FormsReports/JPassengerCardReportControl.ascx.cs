using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JPassengerCardReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                btnSave_Click(null, null);
            }
            else
            {

                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }




        public void GetReport(Int64 RFID = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JConsulHistory");
            jGridView.ClassName = "WebBusManagement_FormsReports_JPassengerCardReportControl" + RFID.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select Code,EventDate,DriverPersonName,LineNumber,ZoneName,FleetName,BusNumber,CardType,PassengerCardSerial,TicketPrice,RemainPrice
                                from AUTTicketTransaction where EventDate between '" + StartEventDate.Value.ToShortDateString() + @"' and '" + EndEventDate.Value.ToShortDateString() + @" 23:59:59'
                                and PassengerCardSerial in (" + RFID + "," + RFID * 256 + "," + RFID / 256 + ")";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = " Code asc";
            jGridView.Title = "JPassengerCardReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 CuIMEI;
                if (txtRFID.Text != "")
                {
                    if (Int64.TryParse(txtRFID.Text, out CuIMEI) == true)
                    {
                        GetReport(Convert.ToInt64(txtRFID.Text),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                    }
                }
            }
            catch { }

        }

    }
}