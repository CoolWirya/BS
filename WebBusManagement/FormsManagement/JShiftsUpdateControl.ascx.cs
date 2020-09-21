using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JShiftsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }


        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.Shift.JShift Shift = new BusManagment.Shift.JShift();
                Shift.GetData(Code);
                txtTitle.Text = Shift.Title;
                txtStartTimeHour.Text = Shift.StartTime.Hours.ToString();
                txtStartTimeMinute.Text = Shift.StartTime.Minutes.ToString();
                txtStartTimeSecond.Text = Shift.StartTime.Seconds.ToString();
                txtEndTimeHour.Text = Shift.EndTime.Hours.ToString();
                txtEndTimeMinute.Text = Shift.EndTime.Minutes.ToString();
                txtEndTimeSecond.Text = Shift.EndTime.Seconds.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(Shift.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(Shift.EndDate);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now); 
            }
        }

        public bool Save(TimeSpan StartTime, TimeSpan EndTime, DateTime StartDate, DateTime EndDate, string Title)
        {
            BusManagment.Shift.JShift Shift = new BusManagment.Shift.JShift();
            Shift.Code = Code;
            Shift.Title = Title;
            Shift.StartTime = StartTime;
            Shift.EndTime = EndTime;
            Shift.StartDate = StartDate;
            Shift.EndDate = EndDate;
            if (Code > 0)
            {
                if (Shift.FindDuplicate() != Code) return false;
                return Shift.Update();
            }
            else
            {
                if (Shift.FindDuplicate() > 0) return false;
                else
                    return Shift.Insert() > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimeSpan TsStartTime;
            TimeSpan TsEndTime;
            DateTime StartDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            DateTime EndDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            int TimeFlag = 0;
            try
            {
                TsStartTime = new TimeSpan(
                        Convert.ToInt32(txtStartTimeHour.Text)
                        , Convert.ToInt32(txtStartTimeMinute.Text)
                        , Convert.ToInt32(txtStartTimeSecond.Text));
            }
            catch
            {
                TsStartTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            try
            {
                TsEndTime = new TimeSpan(
                        Convert.ToInt32(txtEndTimeHour.Text)
                        , Convert.ToInt32(txtEndTimeMinute.Text)
                        , Convert.ToInt32(txtEndTimeSecond.Text));
            }
            catch
            {
                TsEndTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            if (TsStartTime > TsEndTime)
            { 
                WebClassLibrary.JWebManager.RunClientScript("alert('ساعت پایان باید بعد از ساعت شروع باشد');", "ConfirmDialog");
                return;
            }

            if (StartDate <= DateTime.MinValue || EndDate <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('تاریخ شروع و پایان را انتخاب کنید');", "ConfirmDialog");
                return;
            }

            if (StartDate > EndDate)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('تاریخ پایان باید بعد از تاریخ شروع باشد');", "ConfirmDialog");
                return;
            }

            if (TimeFlag == 0)
            {
                if (Save(TsStartTime, TsEndTime, StartDate, EndDate, txtTitle.Text))
                    WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا! شیفت دیگری با همین نام موجود است');", "ConfirmDialog");
            }
            else if (TimeFlag == 1)
                WebClassLibrary.JWebManager.RunClientScript("alert('ساعت شروع و پایان شیفت الزامی است');", "ConfirmDialog");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Shift.JShift Shift = new BusManagment.Shift.JShift();
            Shift.Code = Code;
            if (Shift.Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('شیفت با موفقیت حذف شد');", "ConfirmDialog");
        }
    }
}