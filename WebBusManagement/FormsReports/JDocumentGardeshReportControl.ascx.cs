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
    public partial class JDocumentGardeshReportControl : System.Web.UI.UserControl
    {
        int Code;
        int OwnerPCode;
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
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
                select name from clsAllPerson where Code = " + OwnerPCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                Title = dt.Rows[0]["name"].ToString() + "<br/>سند " + Code ;
            }
        }

        public void GetReport()
        {
            string where = "1=1";
            where += " and TafziliCode1 = " + OwnerPCode;
            where += " and a.DocCode = " + Code;

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JDocumentGardeshReportControl_" + OwnerPCode + "_" + Code;
            jGridView.SQL = @"
select a.Code, DocCode, a.Description, 10 * cast(BedPrice as int) BedPrice , 10 * cast(BesPrice as int) BesPrice, DateModifie
from FinDocumentDetails a
where DocCode between 100000000 and 200000000 and MoeinCode = 3 and " + where;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "DocumentGardeshReport";
            jGridView.PageOrderByField = "DocCode";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "BedPrice,BesPrice";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("GardeshReport", "GardeshReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JDocumentGardeshReportControl._GardeshReport"
                , new List<object>() { "OwnerPCode"}
                , new List<object>() { OwnerPCode.ToString() })
                , JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JDocumentGardeshReportControl._GardeshReport"
                , new List<object>() { "OwnerPCode" }
                , new List<object>() { OwnerPCode.ToString() }));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BedPrice", 0);
            jGridView.SumFields.Add("BesPrice", 0);
            jGridView.Bind();

        }
        public string _GardeshReport(string OwnerPCode, string code)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select DateSave, TafziliCode2 - 30000000 BusNumber from FinDocumentDetails where Code = " + code, false);
            string BusNumber = "", DateSave = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                DateSave = dt.Rows[0]["DateSave"].ToString();
                BusNumber = dt.Rows[0]["BusNumber"].ToString();
            }
            return WebClassLibrary.JWebManager.LoadClientControl("GardeshReport"
                  , "~/WebBusManagement/FormsReports/JGardeshReportControl.ascx"
                  , "گزارش گردش اتوبوس"
                  , new List<Tuple<string, string>>() { 
                      new Tuple<string, string>("BusNumber", BusNumber)
                      , new Tuple<string, string>("OwnerPCode", OwnerPCode)
                      , new Tuple<string, string>("DateSave", DateSave)}
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
    }
}