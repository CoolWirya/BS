using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JDriverMonthlyKarkardReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                btnSave_Click(null, null); 
            }
        }

        void GetReport(int PersonCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStr = "";
            if (PersonCode > 0)
                WhereStr += " and person.Code = " + PersonCode;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and karkard.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + "'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JDriverMonthlyKarkardReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JDriverMonthlyKarkardReportControl_NEW_" + PersonCode + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select 1 Code, person.Name, date, AbsenceDays,dbo.MinuteToTime(NormalOvertimeMinutes) N'اضافه کار روز عادی',dbo.MinuteToTime(HolidayOvertimeMinutes) N'اضافه کار روز تعطیل',
                                    dbo.MinuteToTime(MorningOverMinutes) N'اضافه کار صبح',dbo.MinuteToTime(NightWorkTimeMinutes) N'شبکاری'
                                    , 0 KerkardReduction, 0 IllnessDays, 0 WorkTurns, 0 CompanyServices, 0 ServicePrice, 0 LunchPrice, 0 TwelveHourReward
                                from clsAllPerson person
                                join AUTDriverKarkardToSalaryAndWage karkard on karkard.PersonCode = person.Code
                                where 1=1" + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDriverMonthlyKarkardReportControl";
            jGridView.PageOrderByField = " Name";
            jGridView.Buttons = "excel,print,record_print";
          //  ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
//            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
            jGridView.Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() <= DateTime.MinValue ||
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate() <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('تاریخ ابتدا و انتها را انتخاب کنید');", "ConfirmDialog");
                return;
            }
            GetReport(((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode,
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}