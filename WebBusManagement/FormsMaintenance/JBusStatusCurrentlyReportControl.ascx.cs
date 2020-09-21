using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusStatusCurrentlyReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                GetReport();
        }

        public void GetReport()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusStatusCurrentlyReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusStatusCurrentlyReportControl";
            jGridView.SQL = @"select tbl.*,
                                (select top 1 sdf.Name +' - '+abf.[Description] Collate Persian_100_CI_AI from AUTBusFailure abf
                                left join subdefine sdf on sdf.Code = abf.BusFailureCode
                                where BusCode = tbl.Code order By abf.Code Desc)BusFailureType
                                from (
                                select ab.Code,ab.BUSNumber,af.Name FleetName,ab.LastLineNumber,
                                case ab.Active when 1 then N'فعال' else N'غیر فعال' end As [Status],
                                ab.LastSimCardCharge,ab.LastDate AvlLastDate,
                                ab.TicketLastDate,
								(select top 1 IMEI from AUTHeaderTransaction where BusSerial = ab.BUSNumber and IMEI <> 0 order by date desc)IMEI,
								(select top 1 Tel from autdevice where IMEI = 
								(select top 1 IMEI from AUTHeaderTransaction where BusSerial = ab.BUSNumber and IMEI <> 0 order by date desc) and len(Tel) > 1 and Tel IS Not Null
								 order by Code desc)Tel,
                                (select sum(Tcount) from AUTDailyPerformanceRportOnBus where [Date] = cast (getdate() as date) and BusCode = ab.Code)TodayTicketCount,
                                (select sum(Price) from AUTDailyPerformanceRportOnBus where [Date] = cast (getdate() as date) and BusCode = ab.Code)TodayIncome
                                from AUTBus ab
                                left join AUTFleet af on af.code = ab.fleetcode
                                )tbl";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "BUSNumber asc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusStatusCurrentlyReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport();
        }


    }
}