using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JJNumOfPerformanceDayDetailsReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
                int.TryParse(Request["Code"], out Code);
            GetReport();
        }




        public void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; 
            jGridView.ClassName = "WebBusManagement_FormsReports_JNumOfPerformanceDayDetailsReportControl_"+Code.ToString();

            string WhereSTR = WebClassLibrary.SessionManager.Current.Session["JNumOfPerformanceDayReportControl"].ToString();
            jGridView.SQL = @"
                    select ISNULL(a.Date,b.Date) Date, isnull(Tcount,0) Ticket,isnull(CService,0) Service from
					(
					    select Date,Sum(Tcount)Tcount from AUTShiftDriver shift where 1=1 "+ WhereSTR + @" and BusNumber="+ Code + @" group by date
					) a
					full join
					(
					    select Date,COunt(*) CService from AutBusServices shift where 1=1 "+ WhereSTR + @" and BusNumber=" + Code + @" and Deleted=0 group by date
					)b 
					on a.Date=b.Date
				   ";

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "JNumOfPerformanceDayDetailsReportControl";
            jGridView.PageOrderByField = " Date asc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Report", "Report", new JActionsInfo("Click", JDomains.JActionEvents.GridItemClick, "WebBusManagement.FormsReports.JHokmeKarReportControl._HokmeKarNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JHokmeKarReportControl._HokmeKarUpdate", null, null));

            jGridView.Bind();
        }
    }
}