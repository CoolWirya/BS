using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JDuplicateRecordInDailyReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnSave_Click(null, null);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JDuplicateRecordInDailyReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JDuplicateRecordInDailyReportControl";
            jGridView.SQL = @"select  buscode Code,buscode,driverCardSerial,LineNumber,CardType,TicketPrice,
                                    date,Tcount,Price,count(*)DuplicateTransactionCount from AUTDailyPerformanceRportOnBus
	                                    where 
	                                    DocumentCode=0  and SetPrinter = 1 and Tcount > 0
	                                    group by buscode,driverCardSerial,LineNumber,CardType,TicketPrice,date,Tcount,Price";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDuplicateRecordInDailyReportControl";
            jGridView.Buttons = "excel";
            jGridView.PageOrderByField = "DuplicateTransactionCount desc";

            jGridView.Bind();
        }

    }
}