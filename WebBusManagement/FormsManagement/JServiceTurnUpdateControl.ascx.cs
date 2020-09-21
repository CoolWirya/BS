using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JServiceTurnUpdateControl : System.Web.UI.UserControl
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
                LoadDays();
                _SetForm();
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "-" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "BUSNumber";
            cmbBus.DataBind();
        }

        public void LoadDays()
        {
            List<KeyValuePair<int, string>> Days = new List<KeyValuePair<int, string>>();
            Days.Add(new KeyValuePair<int, string>(0, "-"));
            for (int i = 1; i < 31; i++)
                Days.Add(new KeyValuePair<int, string>(i, i.ToString()));
            cmbDay1.DataSource = Days;
            cmbDay1.DataTextField = "Value";
            cmbDay1.DataValueField = "Key";
            cmbDay1.DataBind();
            cmbDay2.DataSource = Days;
            cmbDay2.DataTextField = "Value";
            cmbDay2.DataValueField = "Key";
            cmbDay2.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BusNumber = 0;
            DateTime FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            DateTime ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            int Day1 = 0;
            int Day2 = 0;

            if (!Int32.TryParse(cmbBus.SelectedValue, out BusNumber) || BusNumber == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً اتوبوس را انتخاب کنید');", "ConfirmDialog");
                return;
            }

            if (FromDate == DateTime.MinValue || ToDate == DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً تاریخ شروع و پایان را انتخاب کنید');", "ConfirmDialog");
                return;
            }

            if (Code == 0)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery("select isnull((select Code from AUTBusServiceTurn where BusNumber = " + BusNumber.ToString() + "),0) Code");
                    int _Code = Convert.ToInt32(DB.Query_ExecutSacler());
                    if (_Code > 0)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('برای این اتوبوس قبلاً نوبت سرویس تعریف شده است');", "ConfirmDialog");
                        return;
                    }
                }
                catch
                {
                    return;
                }
                finally
                {
                    DB.Dispose();
                } 
            }
            BusManagment.WorkOrder.Tariff.ServiceTurn SrvTurn = new BusManagment.WorkOrder.Tariff.ServiceTurn();
            SrvTurn.Code = Code;
            SrvTurn.BusNumber = BusNumber;
            SrvTurn.FromDate = FromDate;
            SrvTurn.ToDate = ToDate;
            if (Int32.TryParse(cmbDay1.SelectedValue, out Day1))
                SrvTurn.FirstDay = Day1;
            if (Int32.TryParse(cmbDay2.SelectedValue, out Day2))
                SrvTurn.SecondDay = Day2;
            if (Code > 0)
            {
                if( SrvTurn.Update())
                    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
            else
            {
                if (SrvTurn.Insert() > 0)
                    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
        }

        void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.WorkOrder.Tariff.ServiceTurn SrvTurn = new BusManagment.WorkOrder.Tariff.ServiceTurn();
                SrvTurn.GetData(Code);
                cmbBus.SelectedValue = SrvTurn.BusNumber.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(SrvTurn.FromDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(SrvTurn.ToDate);
                if (SrvTurn.FirstDay > 0)
                    cmbDay1.SelectedValue = SrvTurn.FirstDay.ToString();
                if (SrvTurn.SecondDay > 0)
                    cmbDay2.SelectedValue = SrvTurn.SecondDay.ToString();
            }
        }
    }
}