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
    public partial class JDocumentMoeinReportControl : System.Web.UI.UserControl
    {
        int Code;
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (IsPostBack)
            {
            }
            else
            {
                GetOwnerName();
                GetReport();
            }
        }

        public void GetOwnerName()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select name from clsAllPerson where code = " + Code);
            if (dt != null && dt.Rows.Count > 0)
            {
                Title = dt.Rows[0]["name"].ToString();
            }
        }

        public void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsManagement_JDocumentMoeinReportControl_" + Code;
            jGridView.SQL = @"
select a.Code, a.Code DocCode
, (select Name from clsAllPerson where Code = b.TafziliCode1) Name
, a.DateSave, CAST(a.Description AS nvarchar(max)) Description
, 10 * sum(cast(b.BedPrice as bigint)) BedPrice , 10 * sum(cast(b.BesPrice as bigint)) BesPrice
from FinDocument a
inner join FinDocumentDetails b on b.DocCode = a.Code
where DocCode between 100000000 and 200000000 and DocCode not in (120160534,120160535) 
    and MoeinCode = 3 and b.TafziliCode1 = " + Code + @"
group by a.Code, b.TafziliCode1, a.DateSave, CAST(a.Description AS nvarchar(max))";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "DocumentMoeinReport";
            jGridView.PageOrderByField = "DateSave desc";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.MoneyColumns = "BedPrice,BesPrice";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("DocumentGardeshReport", "DocumentGardeshReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JDocumentMoeinReportControl._DocumentGardeshReport", new List<object>() { "OwnerPCode" }, new List<object>() { Code.ToString() }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JDocumentMoeinReportControl._DocumentGardeshReport", new List<object>() { "OwnerPCode" }, new List<object>() { Code.ToString() }));
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