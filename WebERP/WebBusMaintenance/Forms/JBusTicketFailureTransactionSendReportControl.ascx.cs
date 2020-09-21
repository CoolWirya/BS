using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusMaintenance.Forms
{
    public partial class JBusTicketFailureTransactionSendReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int NumOfDay;
                if (txtNumOfDay.Text != "")
                {
                    if (int.TryParse(txtNumOfDay.Text, out NumOfDay) == true)
                    {
                        GetReport(Convert.ToInt32(txtNumOfDay.Text));
                    }
                }
            }
        }

        public void GetReport(int NumOfDay = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusTicketFailureTransactionSend");
            jGridView.SQL = @"SELECT top 100 percent a.code AS Code,a.BUSNumber,
                                (SELECT max(LineNumber)LineNumber FROM AUTTicketTransaction at WHERE at.BusCode = a.Code and
                                at.EventDate = a.TicketLastDate)LineNumber,
                                az.Name as ZoneName,
                                a.TicketLastDate,
                                (SELECT max(TicketPrice)TicketPrice FROM AUTTicketTransaction at WHERE at.BusCode = a.Code and
                                at.EventDate = a.TicketLastDate)TiketPrice,
                                a.LastSimCardCharge,a.LastBatteryCharge
                                FROM AUTBus a
                                LEFT JOIN AUTLine al ON LineNumber = al.LineNumber
                                LEFT JOIN AUTZone az ON al.ZoneCode = az.Code
                                WHERE a.[Active]=1 and a.TicketLastDate not BETWEEN dateadd(day,-" + NumOfDay + @",GETDATE()) AND GETDATE()
                                ORDER BY a.TicketLastDate";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusTicketFailureTransactionSendReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int NumOfDay;
            if (txtNumOfDay.Text != "")
            {
                if (int.TryParse(txtNumOfDay.Text, out NumOfDay) == true)
                {
                    GetReport(Convert.ToInt32(txtNumOfDay.Text));
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد وارد کنید');", "UpdateSettings");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تعداد روز را وارد کنید');", "UpdateSettings");
            }
        }
    }
}