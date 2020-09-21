using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JGardeshReportControl : System.Web.UI.UserControl
    {
        int BusNumber;
        int OwnerPCode;
        string DateSave = "";
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { DateSave = Request["DateSave"]; }
            catch { }
            int.TryParse(Request["BusNumber"], out BusNumber);
            int.TryParse(Request["OwnerPCode"], out OwnerPCode);
            if (IsPostBack)
            {
            }
            else
            {
                GetTitle();
                GetReport();
            }
        }
        public void GetTitle()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"
                select a.name, cast('" + DateSave + @"' as date) DateSaveFa, b.TransactionKarkard
                from clsAllPerson a ,
                (
                    select 10 * sum(TCount * TicketPrice) TransactionKarkard
                    from AUTShiftDriver
                    where Date = '" + DateSave + "' and OwnerPCode = " + OwnerPCode + " and BusNumber = " + BusNumber + @"
                ) b
                where a.code = " + OwnerPCode );
            if (dt != null && dt.Rows.Count > 0)
            {
                Title = dt.Rows[0]["name"].ToString() + " - اتوبوس " + BusNumber + "<br/>تراکنش " + dt.Rows[0]["DateSaveFa"].ToString() +" مبلغ " +
                    dt.Rows[0]["TransactionKarkard"].ToString();
            }
        }

        public void GetReport()
        {
            string where = "";
            where += " and TafziliCode1 = " + OwnerPCode;
            where += " and TafziliCode2 = 30000000 + " + BusNumber;
            where += " and a.DateSave = '" + DateSave + "'";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JGardeshReportControl_" + OwnerPCode + "_" + BusNumber + "_" + DateSave;
            jGridView.SQL = @"
select DocCode Code, DocCode, cast(a.Description as nvarchar(max)) Description
, 10 * cast(BedPrice as int) BedPrice , 10 * cast(BesPrice as int) BesPrice, DateModifie
from FinDocumentDetails a
where DocCode between 100000000 and 200000000 and MoeinCode = 3 " + where;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "GardeshReport";
            jGridView.PageOrderByField = "DateModifie";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "BedPrice,BesPrice";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("DocumentGardeshReport", "DocumentGardeshReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JGardeshReportControl._DocumentGardeshReport"
                , new List<object>() { "OwnerPCode" }
                , new List<object>() { OwnerPCode.ToString()})
                , JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JGardeshReportControl._DocumentGardeshReport"
                , new List<object>() { "OwnerPCode" }
                , new List<object>() { OwnerPCode.ToString() }));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BedPrice", 0);
            jGridView.SumFields.Add("BesPrice", 0);
            jGridView.Bind();
        }
        public string _DocumentGardeshReport(string OwnerPCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DocumentGardeshReport"
                  , "~/WebBusManagement/FormsReports/JDocumentGardeshReportControl.ascx"
                  , "گزارش گردش سند"
                  , new List<Tuple<string, string>>() { 
                      new Tuple<string, string>("Code", code)
                      , new Tuple<string, string>("OwnerPCode", OwnerPCode)}
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
    }
}