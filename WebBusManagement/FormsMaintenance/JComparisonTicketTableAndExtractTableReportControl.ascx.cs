using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JComparisonTicketTableAndExtractTableReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnSave_Click(null, null);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JComparisonTicketTableAndExtractTableReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_";
            jGridView.SQL = @"select top 100 percent et.Code,et.recordNumber as recordNumbers,et.TransactionID,et.LineNumber
                                ,et.BusSerial,et.DriverSerialCard,et.PassengerCardSerial,et.CardType
                                ,et.EventDate,et.TicketPrice,et.IMEI
                                from ExtractedTickets et
                                left join AUTTicketTransaction at on at.EventDate = et.EventDate 
                                and at.RemainPrice = et.RemainPrice and at.PassengerCardSerial = et.PassengerCardSerial
                                where at.TransactionId is null";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JComparisonTicketTableAndExtractTableReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }
    }
}