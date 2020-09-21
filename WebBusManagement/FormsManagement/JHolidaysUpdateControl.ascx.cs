using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JHolidaysUpdateControl : System.Web.UI.UserControl
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
                BusManagment.Holiday.JHoliday holiday = new BusManagment.Holiday.JHoliday(Code);
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(holiday.Date);
                txtDescription.Text = holiday.Description;
                rblHoliDaysType.SelectedValue = holiday.HoliDaysType.ToString();
                rblDateType.SelectedValue = holiday.DateType.ToString();
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
            }
        }

        public bool Save()
        {
            BusManagment.Holiday.JHoliday holiday = new BusManagment.Holiday.JHoliday();
            holiday.Code = Code;
            holiday.Date = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate();
            holiday.Description = txtDescription.Text;
            holiday.HoliDaysType = Convert.ToInt16(rblHoliDaysType.SelectedValue);
            holiday.DateType = Convert.ToInt16(rblDateType.SelectedValue);
            if (Code > 0)
            {
                return holiday.Update(true);
            }
            else
            {
                return holiday.Insert(true) > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت انجام است');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Holiday.JHoliday holiday = new BusManagment.Holiday.JHoliday();
            holiday.Code = Code;
            if (holiday.Delete(true))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت انجام است');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
    }
}