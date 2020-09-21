using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JDailyAndPrintComparisonReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnSave_Click(null, null);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JDailyAndPrintComparisonReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JDailyAndPrintComparisonReportControl";
            jGridView.SQL = @"select top 100 percent ROW_NUMBER() over (order by BusCode desc)Code,* from
                                (
                                select BusCode,Date DailyDate,sum(TCOunt) DailyTCount,min(DocumentCode) DocumentCode,min(setPrinter*1)setPrinter from AUTDailyPerformanceRportOnBus where cardtype=0 group by BusCode,Date
                                ) as a
                                inner join
                                (
                                select BusNumber , cast(startdate as date) PrintDate ,TicketCount PrintTCount from AUTPrinterRporte where cast(startdate as time)='00:00:00'  
                                --group by BusNumber , cast(startdate as date) 
                                ) as b
                                on a.DailyDate=b.PrintDate and a.BusCode = (select code from autbus where BusNumber=b.BusNumber) and a.DailyTCount<>b.PrintTCount 
                                and b.PrintTCount>0 
                                and  a.DailyTCount>0
                                and a.SetPrinter=1";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDailyAndPrintComparisonReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

    }
}