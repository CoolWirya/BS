using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusDontSendPrintReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(Convert.ToDouble(0),
                                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
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

        public void GetReport(double BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null,int ReportType = 0)
        {
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = "";
            if (BusNumebr > 0)
                WhereStr += " and ab.BusNumber = " + BusNumebr;
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and (adp.[Date] Between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59')";
            }

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusDontSendPrintReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusDontSendPrintReportControl"+BusNumebr.ToString()+"_"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "")+"_"+ReportType.ToString();
            jGridView.SQL = @"select top 100 percent Max(adp.Code)Code,adp.[Date],ab.BusNumber,sum(TCount)AllTicketCount,
                                    ISNULL((select sum(Tcount) from AUTDailyPerformanceRportOnBus where [Date] = adp.Date and BusCode = adp.BusCode and SetPrinter = 1 and CardType = 0),0)ApplyTicketCount,
                                    ISNULL((select sum(Tcount) from AUTDailyPerformanceRportOnBus where [Date] = adp.Date and BusCode = adp.BusCode and SetPrinter = 0 and CardType = 0),0)DontApplyTicketCount,
                                    ISNULL((select count(*) from AUTPrinterRporte where Cast(Startdate as date) = adp.Date and BusNumber = ab.BusNumber),0)PrintRequestCount,
                                    ISNULL((select count(*) from AUTPrinterRporte where State = 1 and Cast(Startdate as date) = adp.Date and BusNumber = ab.BusNumber),0)GetPrinteRequestCount,
                                    ISNULL((select count(*) from AUTPrinterRporte where State = 0 and Cast(Startdate as date) = adp.Date and BusNumber = ab.BusNumber),0)DontSendPrinteRequestCount,
                                    (select TicketLastDate from AutBus where BusNumber = ab.BusNumber)TicketLastDate,
                                    ISNULL((select LastSimCardCharge from AutBus where BusNumber = ab.BusNumber),0)LastSimCardCharge,
                                    (select top 1 cast(cast(substring(at.[Version],0,2) AS INT)AS NVARCHAR)+
                                    cast(cast(substring(at.[Version],2,1) AS INT)AS NVARCHAR)+
                                    cast(cast(substring(at.[Version],3,1) AS INT)AS NVARCHAR)ConsulVersion from AutHeaderTransaction at
                                    where at.BusSerial = ab.BusNumber
                                    order by at.Date desc)ConsulVersion
                                    from AUTDailyPerformanceRportOnBus adp
                                    left join AutBus ab on ab.Code = adp.BusCode
                                    where adp.CardType = 0 " + WhereStr + @"
                                    group by adp.[Date],ab.BusNumber,adp.BusCode
                                    having 
                                    (select sum(Tcount) from AUTDailyPerformanceRportOnBus where [Date] = adp.Date and BusCode = adp.BusCode and SetPrinter = 0 and CardType = 0) > 0";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusDontSendPrintReportControl";
            jGridView.Buttons = "excel";
            jGridView.PageOrderByField = @"DontApplyTicketCount desc";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("AllTicketCount", 0);
            jGridView.SumFields.Add("ApplyTicketCount", 0);
            jGridView.SumFields.Add("DontApplyTicketCount", 0);
            jGridView.SumFields.Add("PrintRequestCount", 0);
            jGridView.SumFields.Add("GetPrinteRequestCount", 0);
            jGridView.SumFields.Add("DontSendPrinteRequestCount", 0);

            jGridView.Bind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbBus.SelectedValue == "0")
            {
                GetReport(Convert.ToDouble(0),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            else
            {
                GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
        }

    }
}