using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInsertBusTicketFailure : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();

            cmbBusTo.DataSource = dt;
            cmbBusTo.DataTextField = "BUSNumber";
            cmbBusTo.DataValueField = "Code";
            cmbBusTo.DataBind();
        }


        public bool Save(DateTime Date, string StartTime, string EndTime)
        {
            BusManagment.JBusFailure BusFailure = new BusManagment.JBusFailure();
            BusFailure.Code = Code;
            BusFailure.Date = Date;
            BusFailure.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            BusFailure.StartTime = StartTime;
            BusFailure.EndTime = EndTime;
            if (Code > 0)
                return BusFailure.Update();
            else
                return BusFailure.Insert() > 0 ? true : false;
        }

        public List<DateTime> GetAllDateBetweenToDates(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            return dates;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime StartDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().AddMinutes(int.Parse(txtStartTimeHour.Text) * 60 + int.Parse(txtStartTimeMinute.Text));
            DateTime EndDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate().AddMinutes(int.Parse(txtEndTimeHour.Text) * 60 + int.Parse(txtEndTimeMinute.Text));

            DateTime StartDateTo = ((WebControllers.MainControls.Date.JDateControl)txtToDateTo).GetDate().AddMinutes(int.Parse(txtStartTimeHourTO.Text) * 60 + int.Parse(txtStartTimeMinuteTO.Text));

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(@"select top " + txtNumberLimit.Text + @" * from AUTTicketTransaction 
	            where busnumber=" + cmbBus.SelectedItem.Text + @" and TicketPrice > 0 and cardtype = 0 and eventdate between '"
                    + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  '"
                    + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and TicketPrice in (select price from AUTPrice) order by EventDate");
                System.Data.DataTable DT = DB.Query_DataTable();

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    DataRow DR = DT.Rows[i];
                    BusManagment.Transaction.JTicketTransactions.AddTicketTransactionManual(DB, Convert.ToInt64(DR["RecordNumber"]),
                        Convert.ToInt32(DR["TransactionID"]),
                        Convert.ToInt32(DR["LineNumber"]),
                        int.Parse(cmbBusTo.SelectedItem.Text),
                       0, Convert.ToInt64(DR["PassengerCardSerial"]),
                       Convert.ToInt32(DR["CardType"]),
                       Convert.ToInt32(DR["TicketPrice"]),
                       Convert.ToInt32(DR["ReaderID"]),
                        Convert.ToInt32(DR["RemainPrice"]),
                        0,
                        new byte[]{95,03,23},
                        StartDateTo.AddSeconds(
                        (System.Convert.ToDateTime( DR["EventDate"]).Hour * 3600 + System.Convert.ToDateTime(DR["EventDate"]).Minute * 60 + System.Convert.ToDateTime(DR["EventDate"]).Second)
                                                    -
                                                    (StartDate.Hour*3600+StartDate.Minute*60+StartDate.Second)
                                                    ),
                        false);
                }
            }
            finally
            {
                DB.Dispose();
            }
            WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}