using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusDailyPrintPaymentReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //rblTransactionType.SelectedValue = "0";
                //GetReport(Convert.ToInt32(cmbBus.SelectedValue),
                //         ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                //        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(rblTransactionType.SelectedValue));


                btnSave_Click(null, null);
            }
            else
            {
                //rblTransactionType.SelectedValue = "0";
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }


        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int ReportType = 0)
        {
            string where = "";
            if (BusNumebr > 0)
                where = " and allt.BusCode = " + BusNumebr;
            if (ReportType == 1)
                where = @" and allt.TCount <> Printt.TicketCount ";

            if (ReportType == 2)
                where = @" and Printt.TicketCount = 0 ";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusReports");
            jGridView.ClassName = "WebBusReports_JBusReports_GetReport_JBusDailyPrintPaymentReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + ReportType.ToString();
            jGridView.SQL = @"select allt.Code,af.Name FleetName,ab.BUSNumber,cast(dbo.DateEnToFa(allt.Date) as nvarchar)Date,allt.TCount as TicketCount,taeedt.TCount TaeedTicketCount,
                                            Printt.TicketCount ApplyTicketCount,paymentt.TCount PaymentTicketCount 
                                                        from 
                                                        (
                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount from AUTDailyPerformanceRportOnBus adp
                                                        where adp.CardType = 0 and adp.Error = 0 and adp.Tcount > 0 and adp.TicketPrice > 0 and adp.Price > 0
                                                        group by adp.BusCode,adp.Date
                                                        ) allt
                                                        inner join
                                                        (
                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount from AUTDailyPerformanceRportOnBus adp
                                                        where adp.CardType = 0 and adp.Error = 0 and adp.SetPrinter = 1 and adp.Tcount > 0
                                                        and adp.TicketPrice > 0 and adp.Price > 0
                                                        group by adp.BusCode,adp.Date
                                                        ) taeedt on allt.BusCode = taeedt.BusCode and allt.Date = taeedt.Date
                                                        inner join
                                                        (
                                                        select BusNumber,cast(startdate as date)Date,max(TicketCount)TicketCount from (select BusNumber,StartDate,EndDate,max(TicketCount)TicketCount from AUTPrinterRporte
                                                                                        where DailyCode < 1 and TicketCount > 0 and cast(startdate as date) = cast(enddate as date)
                                                                                        and Len(BusNumber)=4 and ShiftDriverCode = 0
                                                                                        group by BusNumber,StartDate,EndDate)b
																						group by b.BusNumber,b.StartDate
                                                        )Printt on allt.BusCode = (select code from AUTBus where BusNumber = Printt.BusNumber) and allt.Date = Printt.Date
                                                        inner join 
                                                        (
                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount from AUTDailyPerformanceRportOnBus adp
                                                        where adp.CardType = 0 and adp.Error = 0 and adp.SetPrinter = 1 and adp.DocumentCode > 0 and adp.Tcount > 0
                                                        and adp.TicketPrice > 0 and adp.Price > 0
                                                        group by adp.BusCode,adp.Date
                                                        ) paymentt on allt.BusCode = paymentt.BusCode and allt.Date = paymentt.Date
                                                        left join AUTBus ab on ab.Code = allt.BusCode
                                                        left join AUTFleet af on af.Code = ab.FleetCode
                                                        where allt.Date between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' 
                                                        and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + @" 23:59:59' " + where;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusDailyPrintPaymentReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = "BusNumber,Date desc";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TicketCount", 0);
            jGridView.SumFields.Add("TaeedTicketCount", 0);
            jGridView.SumFields.Add("ApplyTicketCount", 0);
            jGridView.SumFields.Add("PaymentTicketCount", 0);

            //            string BusCountQuery = @"select adp.BusCode
            //                                from AUTDailyPerformanceRportOnBus adp 
            //                                left join AutBus ab on ab.Code = adp.BusCode
            //                                left join AutFleet af on af.Code = ab.FleetCode
            //                                where adp.CardType = 0  and adp.Tcount > 0 and adp.Price > 0 and adp.TicketPrice > 0
            //                                and adp.Date BBetween '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' and '" +
            //                                                        EndEventDate.Value.ToShortDateString() + @" 23:59:59'
            //                                " + where + @"
            //                                group by adp.BusCode " + Having;
            //            GetBusCount(BusCountQuery);

            jGridView.Bind();


        }

        public string StrBusCount = "";
        public void GetBusCount(string Query)
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            if (Dt != null)
            {
                StrBusCount = "تعداد اتوبوس ها : " + Dt.Rows.Count.ToString();
            }
            else
            {
                StrBusCount = "تعداد اتوبوس ها : 0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue),
                     ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(rblTransactionType.SelectedValue));
            }
            catch { }
        }

    }
}