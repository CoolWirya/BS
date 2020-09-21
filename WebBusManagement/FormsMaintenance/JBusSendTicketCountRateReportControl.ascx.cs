using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusSendTicketCountRateReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                int TicketCount;
                if (txtTicketCount.Text != "")
                {
                    if (int.TryParse(txtTicketCount.Text, out TicketCount) == true)
                    {
                        GetReport(Convert.ToInt32(cmbMode.SelectedValue), Convert.ToInt32(txtTicketCount.Text),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد وارد کنید');", "UpdateSettings");
                    }
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تعداد بلیط را وارد کنید');", "UpdateSettings");
                }
            }
        }


        public void GetReport(int Mode = 0, int TicketCount = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string StrMode = "";
            if (Mode == 0)
            {
                StrMode = "<";
            }
            else if (Mode == 1)
            {
                StrMode = ">";
            }
            else if (Mode == 2)
            {
                StrMode = "=";
            }

            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusMaintenance_JBusSendTicketCountRateReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusSendTicketCountRateReportControl" + Mode.ToString() + "_" + TicketCount.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select top 100 percent ab.Code Code,ab.BusNumber,ab.TicketLastDate,ab.LastSimCardCharge,
                            (select sum(TCount) from AUTDailyPerformanceRportOnBus where BusCode = ab.Code and [Date] Between '" + StartDTime.ToShortDateString() +@" 00:00:00' and '" + EndDTime.ToShortDateString() +@" 23:59:59') TicketCount
                            from AutBus ab
                            Where (select sum(TCount) from AUTDailyPerformanceRportOnBus where BusCode = ab.Code and [Date] Between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59') " + StrMode + @"" + TicketCount.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = "TicketLastDate desc";
            jGridView.Title = "JBusSendTicketCountRateReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int TicketCount;
            if (txtTicketCount.Text != "")
            {
                if (int.TryParse(txtTicketCount.Text, out TicketCount) == true)
                {
                    GetReport(Convert.ToInt32(cmbMode.SelectedValue), Convert.ToInt32(txtTicketCount.Text), 
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد وارد کنید');", "UpdateSettings");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تعداد بلیط را وارد کنید');", "UpdateSettings");
            }
        }


    }
}