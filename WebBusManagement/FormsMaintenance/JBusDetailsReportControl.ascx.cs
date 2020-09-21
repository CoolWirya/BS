using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusDetailsReportControl : System.Web.UI.UserControl
    {
        int Code;
        public string BusDetails = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
            LoadPublicInfo(Code);
        }

        public void LoadPublicInfo(int BusCode)
        {
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select ab.Code,ab.BUSNumber,af.Name FleetName,ab.LastLineNumber,
                                                                                    ab.LastSimCardCharge,ab.LastDate as AvlLastDate ,ab.TicketLastDate
                                                                                    from AUTBus ab
                                                                                    left join AUTFleet af on af.Code = ab.FleetCode
                                                                                    where ab.Code = " + BusCode);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                BusDetails = @"<div style=""float:right;padding-right:10px;dir:rtl"">
                               اتوبوس : " + Dt.Rows[0]["BUSNumber"].ToString() + @"<br />
                               ناوگان : " + Dt.Rows[0]["FleetName"].ToString() + @"<br />
                                 خط : " + Dt.Rows[0]["LastLineNumber"].ToString() + @"<br />
                                شارژ سیم کارت : " + Dt.Rows[0]["LastSimCardCharge"].ToString() + @"<br />
                                آخرین تاریخ دریافت AVL : " + Dt.Rows[0]["AvlLastDate"].ToString() + @"<br />
                                آخرین تاریخ دریافت بلیط : " + Dt.Rows[0]["TicketLastDate"].ToString() + @"<br />
                               </div>";
            }
        }

        public void GetReport(int BusCode)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusDetailsReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusDetailsReportControl"+BusCode.ToString();
            jGridView.SQL = @"select ab.Code,ab.BusNumber,aht.IMEI,ad.Tel SimCardNumber,aht.Version,aht.Date from AutBus ab left join
                                AutHeaderTransaction aht on aht.BusSerial = ab.BusNumber
                                left join AutDevice ad on ad.IMEI = aht.IMEI
                                where ab.Code = " + BusCode + @" and LEN(aht.IMEI) > 1";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "Date desc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusDetailsReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            
        }

    }
}