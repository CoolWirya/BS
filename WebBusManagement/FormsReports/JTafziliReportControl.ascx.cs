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
    public partial class JTafziliReportControl : System.Web.UI.UserControl
    {
        int BusNumber;
        int OwnerPCode;
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out BusNumber);
            int.TryParse(Request["OwnerPCode"], out OwnerPCode);
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                GetOwnerName();
                GetReport();
            }
        }
        public void GetOwnerName()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select name from clsAllPerson where code = " + OwnerPCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                Title = dt.Rows[0]["name"].ToString() + " - اتوبوس " + BusNumber;
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string Where = "";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            if (StartEventDate != null && EndEventDate != null)
            {
                Where += " and DateSave between '{0}' and '{1}'";
                jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            }
            jGridView.ClassName = "WebBusManagement_FormsReports_JTafziliReportControl_" + OwnerPCode + "_" + BusNumber;
            jGridView.SQL = @"
select Code,BusNumber, DateSave,OwnerPCode,name, TransactionKarkard,BesDoc FinancialKarKard,isnull(BesDoc0,0) NotVerifiedKarKard,TransactionKarkard-(BesDoc + isnull(BesDoc0,0)) NoDocKarkard
, TransactionCount,(select dbo.DateEnToFa(max(date)) from AUTShiftDriver where ownerpcode=TafziliCode1 and date < getdate()) LastDate
from
(
select ROW_NUMBER() over (order by a.DateSave desc) Code, a.TafziliCode1,a.BusNumber, a.DateSave,d.OwnerPCode, a.name, isnull(TransactionKarkard,0)TransactionKarkard,cast(a.Bes-a.bed as bigint) BesDoc,cast(a.Bes0-a.bed0 as bigint) BesDoc0, TransactionCount
from
(
	select * from
	(
		select TafziliCode1 ,TafziliCode2 - 30000000 BusNumber, DateSave, count(*) TransactionCount
		,(select name from clsAllPerson where code=TafziliCode1) name
		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed

		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes0
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed0
		from FinDocumentDetails a
		where 
		MoeinCode=3 and DocCode between 100000000 and 200000000 
		group by TafziliCode1 ,TafziliCode2, DateSave
	) as a
) as a
inner join
(
	select OwnerPCode,BusNumber, 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard, Date
	from AUTShiftDriver
	where CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
		and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
	group by OwnerPCode,BusNumber, Date
) d
on a.TafziliCode1=d.OwnerPCode and a.BusNumber=d.BusNumber and a.DateSave=d.Date 
where a.TafziliCode1 = " + OwnerPCode + " and a.BusNumber = " + BusNumber +@"
) as a
where 1=1 " + Where;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "TafziliReport";
            jGridView.PageOrderByField = "DateSave desc";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "TransactionKarkard,FinancialKarKard,NotVerifiedKarKard,NoDocKarkard";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("GardeshReport", "GardeshReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTafziliReportControl._GardeshReport"
                , new List<object>() { "OwnerPCode", "BusNumber"}
                , new List<object>() { OwnerPCode.ToString(), BusNumber.ToString()})
                , JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JTafziliReportControl._GardeshReport"
                , new List<object>() { "OwnerPCode", "BusNumber"}
                , new List<object>() { OwnerPCode.ToString(), BusNumber.ToString()}));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionKarkard", 0);
            jGridView.SumFields.Add("FinancialKarKard", 0);
            jGridView.SumFields.Add("NotVerifiedKarKard", 0);
            jGridView.SumFields.Add("NoDocKarkard", 0);
            jGridView.Bind();

        }
        public string _GardeshReport(string OwnerPCode, string BusNumber, string code)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"
    select DateSave
    from
    (
    select code, DateSave 
    from
    (
    select ROW_NUMBER() over (order by a.DateSave desc) code, a.TafziliCode1,a.BusNumber, a.DateSave,d.OwnerPCode, a.name, isnull(TransactionKarkard,0)TransactionKarkard,cast(a.Bes-a.bed as bigint) BesDoc,cast(a.Bes0-a.bed0 as bigint) BesDoc0
    from
    (
	    select * from
	    (
		    select TafziliCode1 ,TafziliCode2 - 30000000 BusNumber, DateSave
		    ,(select name from clsAllPerson where code=TafziliCode1) name
		    ,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes
		    ,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed

		    ,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes0
		    ,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534,120160535)) is not null) and b.TafziliCode1=a.TafziliCode1 and b.TafziliCode2=a.TafziliCode2 and b.DateSave=a.DateSave and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed0
		    from FinDocumentDetails a
		    where 
		    MoeinCode=3 and DocCode between 100000000 and 200000000 
		    group by TafziliCode1 ,TafziliCode2, DateSave
	    ) as a
    ) as a
    inner join
    (
	    select OwnerPCode,BusNumber, 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard, Date
	    from AUTShiftDriver
	    where CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
		    and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
	    group by OwnerPCode,BusNumber, Date
    ) d
    on a.TafziliCode1=d.OwnerPCode and a.BusNumber=d.BusNumber and a.DateSave=d.Date  
    where a.TafziliCode1 = " + OwnerPCode + " and a.BusNumber = " + BusNumber + @"
    ) as a
    )a where Code = " + code, false);
            string DateSave = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                DateSave = dt.Rows[0]["DateSave"].ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }
    }
}