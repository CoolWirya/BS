using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInsertBusFailureUpdateControl : System.Web.UI.UserControl
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
                LoadBusFailureType();
                _SetForm();
            }
        }

        public void LoadBusFailureType()
        {
            DataTable DtBusFailureType = new DataTable();
            DtBusFailureType = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101033");
            cmbBusFailureType.DataSource = DtBusFailureType;
            cmbBusFailureType.DataTextField = "Name";
            cmbBusFailureType.DataValueField = "Code";
            cmbBusFailureType.DataBind();
        }


        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.JBusFailure BusFailure = new BusManagment.JBusFailure();
                BusFailure.GetData(Code);
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(BusFailure.Date);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(BusFailure.Date);
                cmbBus.SelectedValue = BusFailure.BusCode.ToString();
                cmbBusFailureType.SelectedValue = BusFailure.BusFailureCode.ToString();
                txtDiscription.Text = BusFailure.Description;
            }
        }

        public bool Save(DateTime Date, string StartTime, string EndTime)
        {
            BusManagment.JBusFailure BusFailure = new BusManagment.JBusFailure();
            BusFailure.Code = Code;
            BusFailure.Date = Date;
            BusFailure.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            BusFailure.BusFailureCode = Convert.ToInt32(cmbBusFailureType.SelectedValue);
            BusFailure.Description = txtDiscription.Text;
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
            var dates = GetAllDateBetweenToDates(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            string StartTime = null, EndTime = null;
            if (dates.Count == 1)
            {
                StartTime = txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00";
                EndTime = txtEndTimeHour.Text + ":" + txtEndTimeMinute.Text + ":00";
            }
            else
            {
                StartTime = txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00";
                EndTime = "23:59:59";
            }
            for (int i = 0; i < dates.Count; i++)
            {
                if (i == dates.Count - 1)
                    EndTime = txtEndTimeHour.Text + ":" + txtEndTimeMinute.Text + ":00";
                Save(dates[i], StartTime, EndTime);
            }
            WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}