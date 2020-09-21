using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JTasfieMandehHesabReportControl : System.Web.UI.UserControl
    {
        string _ConstClassName = "WebBusManagement.FormsReports.JTasfieMandehHesabReportControl";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                GetReport();
            }
        }
        void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JTasfieMandehHesabReportControl";
            jGridView.SQL = @"
                select detail.TafziliCode1 Code, person.Name, (sum(cast(BesPrice as bigint)) - sum(cast(BedPrice as bigint))) Price
                , case when sum(cast(BesPrice as bigint)) > sum(cast(BedPrice as bigint)) then N'اضافه پرداخت' 
	                when sum(cast(BesPrice as bigint)) < sum(cast(BedPrice as bigint)) then N'کسر پرداخت' else N'' end status
                from dbo.FinDocumentDetails detail
                left join clsAllPerson person on person.Code = detail.TafziliCode1
                where DocCode = 120500723
                group by detail.TafziliCode1, person.Name";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "TasfieMandehHesabReport";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("TasfieMethod", "TasfieMethod", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TasfieMethod", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TasfieMethod", null, null));
            jGridView.Bind();
        }
        public string _TasfieMethod()
        {
            return null;
        }
        public string _TasfieMethod(string code)
        {
            if (Convert.ToInt32(code) == 0)
                return null;
            return WebClassLibrary.JWebManager.LoadClientControl("BusTasfieMethodReport"
                  , "~/WebBusManagement/FormsReports/JTasfieMethodReportControl.ascx"
                  , "گزارش نحوه تسویه حساب اتوبوسها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 500, 400);
        }
    }
}