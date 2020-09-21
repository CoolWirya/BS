using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JUndefinedDriversBusReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
                  
                    btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }


        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStr = " 1 = 1 ";
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            //    WhereStr += " and cast(Date as date) between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
            //WhereStr += "and not exists( select * from Cards"+
            //    " join clsAllPerson on Cards.PCode = clsAllPerson.Code where bn.DriverCardSerial = Cards.Code)";
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JUndefinedDriversBusReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JUndefinedDriversBusReportControl_"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+ "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select 1 Code,DriverCardSerial,BusNumber,line.LineName, zone.Name ZoneName
                            from AUTShiftDriver bn 
                            left join AUTLine line on line.LineNumber = bn.LineNumber
                            left join AUTZone zone on zone.Code = line.ZoneCode 
                            where  1 = 1 and busnumber in (select BusNumber from AUTBus where Active = 1 and IsValid = 1)
                                and bn.Startdate between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00' 
                                and '" + StartEventDate.Value.ToShortDateString() + @" 23:59:59'
                                and not  exists( select * from Cards join clsAllPerson on Cards.PCode = clsAllPerson.Code
                                    where bn.DriverCardSerial = Cards.Code) group by BusNumber,DriverCardSerial,line.LineName, zone.Name";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JUndefinedDriversBusReportControl";
            jGridView.PageOrderByField = " BusNumber Desc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}