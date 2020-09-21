using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JOvertimeTariffReportControl : System.Web.UI.UserControl
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
                WhereStr += " and service.DriverPersonCode = " + PersonCode;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and service.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + "'";
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JOvertimeTariffReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JOvertimeTariffReportControl_";
            jGridView.SQL = @"select 1 Code, service.DriverPersonCode PersonCode, person.Name, dbo.DateEnToFa(service.Date) Date, bus.BusNumber,case when max(cast(service.LastStationDate as time)) > tariff.EndTime
			                     then dbo.MinuteToTime(datediff(minute,tariff.EndTime,cast(max(service.LastStationDate) as time))) end Overtime
                             FROM AutBusServices service JOIN
                                AUTBUS bus ON bus.BusNumber = service.BusNumber JOIN
                                AUTTariff tariff ON tariff.BusCode = bus.Code and cast(tariff.Date as Date) = service.Date LEFT JOIN
								ClsAllPerson person on person.Code = service.DriverPersonCode
                                where cast(service.LastStationDate as time) > tariff.EndTime" + WhereStr + @"
                            group by service.DriverPersonCode, person.Name, service.Date,bus.BusNumber,tariff.EndTime";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JOvertimeTariffReportControl";
            jGridView.PageOrderByField = " PersonCode,BusNumber,Date";
            jGridView.Buttons = "excel,print,record_print";
           // ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
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