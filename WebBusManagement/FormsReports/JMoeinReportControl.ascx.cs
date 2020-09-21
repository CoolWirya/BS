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
    public partial class JMoeinReportControl : System.Web.UI.UserControl
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
            jGridView.ClassName = "WebBusManagement_FormsManagement_JMoeinReportControl_" + Code;
            jGridView.SQL = @"
select BusNumber Code,BusNumber,OwnerPCode,name, TransactionKarkard,BesDoc FinancialKarKard,isnull(BesDoc0,0) NotVerifiedKarKard,TransactionKarkard-(BesDoc + isnull(BesDoc0,0)) NoDocKarkard
,(select dbo.DateEnToFa(max(date)) from AUTShiftDriver where ownerpcode=TafziliCode1 and date < getdate()) LastDate
from
(
select a.TafziliCode1,a.BusNumber,d.OwnerPCode, a.name, isnull(TransactionKarkard,0)TransactionKarkard,cast(a.Bes-a.bed as bigint) BesDoc,cast(a.Bes0-a.bed0 as bigint) BesDoc0
from
(
	select * from
	(
		select TafziliCode1 ,TafziliCode2 - 30000000 BusNumber
		,(select name from clsAllPerson where code=TafziliCode1) name
		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed

		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes0
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed0
		from FinDocumentDetails a
		where 
		MoeinCode=3 and DocCode between 100000000 and 200000000 
		group by TafziliCode1 ,TafziliCode2
	) as a
) as a
full join
(
	select OwnerPCode,BusNumber, 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard
	from AUTShiftDriver
	where CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
		and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
	group by OwnerPCode,BusNumber
) d
on a.TafziliCode1=d.OwnerPCode and a.BusNumber=d.BusNumber
where a.TafziliCode1=d.OwnerPCode and a.BusNumber=d.BusNumber 
) as a
where TafziliCode1=" + Code;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "MoeinReport";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.MoneyColumns = "TransactionKarkard,FinancialKarKard,NotVerifiedKarKard,NoDocKarkard,Mandeh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("TafziliReport", "TafziliReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JMoeinReportControl._TafziliReport", new List<object>() { "OwnerPCode" }, new List<object>() { Code.ToString() }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JMoeinReportControl._TafziliReport", new List<object>() { "OwnerPCode" }, new List<object>() { Code.ToString() }));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionKarkard", 0);
            jGridView.SumFields.Add("FinancialKarKard", 0);
            jGridView.SumFields.Add("NotVerifiedKarKard", 0);
            jGridView.SumFields.Add("NoDocKarkard", 0);
            jGridView.Bind();

        }
        public string _TafziliReport(string OwnerPCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TafziliReport"
                  , "~/WebBusManagement/FormsReports/JTafziliReportControl.ascx"
                  , "گزارش تفضیلی اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code), new Tuple<string, string>("OwnerPCode", OwnerPCode) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
    }
}