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
    public partial class JMonthlyAccReviewReportControl : System.Web.UI.UserControl
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
            jGridView.ClassName = "WebBusManagement_FormsReports_JMonthlyAccReviewReportControl_" + Code;
            jGridView.SQL = @"
select 
AP.PaymentCode Code ,cast(A.Description as nvarchar(MAX)) PayDesc,cast(F.Description as nvarchar(MAX)) FinDesc,
A.PaymentDate
,SUM(TPrice) KarKard
,sum(cast(AP.PaymentPrice as bigint)) PaymentPrice
,sum(cast(AP.PaymentPrice as bigint))-SUM(TPrice) Mandeh
from FinDocumentPayment FP
inner join AUTPaymentDetail AP ON AP.PaymentCode=FP.PaymentCode
inner join AUTPayment A ON A.Code=AP.PaymentCode
inner join FinDocument F ON F.code=FP.DocCode
inner join (select OwnerPCode,Date,sum(TCount* TicketPrice) TPrice from AUTShiftDriver where OwnerPCode=@OwnerCode group by OwnerPCode,Date) AD ON AD.OwnerPCode=AP.OwnerPCode and AD.Date=F.DateSave
where 1=1
and AP.OwnerPCode=@OwnerCode 
group BY 
AP.PaymentCode,cast(A.Description as nvarchar(MAX)),cast(F.Description as nvarchar(MAX)),
F.Date,A.PaymentDate
"
            .Replace("@OwnerCode", Code.ToString());
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "MonthlyAccReviewReport";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "KarKard,PaymentPrice,Mandeh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("DailyAccReviewReport", "DailyAccReviewReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JMonthlyAccReviewReportControl._DailyAccReviewReport"
            //    , new List<object>() { "OwnerPCode" }
            //    , new List<object>() { Code.ToString() })
            //    , JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));

            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JMonthlyAccReviewReportControl._DailyAccReviewReport"
            //    , new List<object>() { "OwnerPCode" }
            //    , new List<object>() { Code.ToString() }));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("KarKard", 0);
            jGridView.SumFields.Add("PaymentPrice", 0);
            jGridView.SumFields.Add("Mandeh", 0);
            //jGridView.SumFields.Add("MandehDoc", 0);
            jGridView.Bind();

        }
        public string _DailyAccReviewReport(string OwnerPCode, string code)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(string.Format(@"
IF OBJECT_ID('tempdb..#tmpShiftDriver') IS NOT NULL DROP Table #tmpShiftDriver
IF OBJECT_ID('tempdb..#Months') IS NOT NULL DROP Table #Months
IF OBJECT_ID('tempdb..#OldData') IS NOT NULL DROP Table #OldData

  CREATE TABLE #Months (MonthOrder int, MonthName nvarchar(20))
insert into #Months
values (1,N'فروردین'),(2,N'اردیبهشت'),(3,N'خرداد'),(4,N'تیر'),(5,N'مرداد'),(6,N'شهریور')
,(7,N'مهر'),(8,N'آبان'),(9,N'آذر'),(10,N'دی'),(11,N'بهمن'),(12,N'اسفند')

select 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard, dbo.DateEnToFa(shft.Date) Date into #tmpShiftDriver
from AUTShiftDriver shft
where shft.OwnerPCode = {0} and CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
		and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
group by dbo.DateEnToFa(shft.Date)

select 
 (select 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard from AUTShiftDriver shft where shft.OwnerPCode = {0} and CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0 and BusNumber in (select BusNumber from AUTBus where IsValid = 1) and OwnerPCode= {0} and dbo.DateEnToFa(Date) < N'{1}') TransactrionKarkard
,(select 10 * sum(BesPrice) - 10 * sum(BedPrice) bed	from FinDocument doc inner join FinDocumentDetails detail on detail.DocCode = doc.Code	where detail.TafziliCode1 = {0} and doc.Code between 100000000 and 200000000 and doc.Code not in (120160534) and detail.MoeinCode = 3 and TafziliCode1={0} and dbo.DateEnToFa(doc.DateSave) < N'{1}') FunKarKard
,N'-' date
,(select 10 * sum(BedPrice) - 10 * sum(BesPrice)  bed	from FinDocument doc	inner join FinDocumentDetails detail on detail.DocCode = doc.Code	where detail.TafziliCode1 = {0} and doc.Code between 400000000 and 500000000 and detail.MoeinCode = 3 and TafziliCode1={0} and dbo.DateEnToFa(doc.DateSave) < N'{1}') BedBesDoc
into #OldData

select ROW_NUMBER() over (order by a.Date) Code
, {0} OwnerPCode
,(select name from clsAllPerson where code={0}) collate Persian_100_CI_AI Name
,a.Date
, TransactionKarkard TransactionKarkard
,BesDoc FinancialKarKard
,isnull(BedBesDoc,0) BedBesDoc
,sum(isnull(BedBesDoc,0)-isnull(BesDoc,0)) over (order by a.Date) MandehDoc
from
(
	select isnull(TransactionKarkard,0)TransactionKarkard,isnull(cast(a.Bes-a.bed as bigint),0) BesDoc
	, isnull(d.Date,isnull(a.date,b.Date)) date,b.bed-b.bes BedBesDoc
	from
	(
		select dbo.DateEnToFa(doc.DateSave) Date
		, 10 * sum(BesPrice) bes
		, 10 * sum(BedPrice) bed
		from FinDocument doc
		inner join FinDocumentDetails detail on detail.DocCode = doc.Code
		where detail.TafziliCode1 = {0} and doc.Code between 100000000 and 200000000 and doc.Code not in (120160534) and detail.MoeinCode = 3
		group by dbo.DateEnToFa(doc.DateSave)
	) a
	full join  #tmpShiftDriver d on d.Date = a.Date
	full join(
		select dbo.DateEnToFa(doc.DateSave) Date
		, 10 * sum(BesPrice) bes
		, 10 * sum(BedPrice) bed
		from FinDocument doc
		inner join FinDocumentDetails detail on detail.DocCode = doc.Code
		where detail.TafziliCode1 = {0} and doc.Code between 400000000 and 500000000 and detail.MoeinCode = 3
		group by dbo.DateEnToFa(doc.DateSave)
	) b on b.Date=a.Date
union all 
select * from #OldData s
) a
where Replace(Replace(left(date,7),'/',''),'-','')=N'{1}' OR date=N'-'", new object[] { OwnerPCode.ToString(), code.ToString() }), false);
            string StartDate = "", EndDate = "", Month = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                StartDate = dt.Rows[0]["StartDate"].ToString();
                EndDate = dt.Rows[0]["EndDate"].ToString();
                Month = dt.Rows[0]["FaMonth"].ToString();
            }
            return WebClassLibrary.JWebManager.LoadClientControl("DailyAccReviewReport"
                  , "~/WebBusManagement/FormsReports/JDailyAccReviewReportControl.ascx"
                  , "گزارش مرور حساب روزانه"
                  , new List<Tuple<string, string>>() { 
                      new Tuple<string, string>("OwnerPCode", OwnerPCode)
                      , new Tuple<string, string>("StartDate", StartDate)
                      , new Tuple<string, string>("EndDate", EndDate)
                      , new Tuple<string, string>("Month", Month)}
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.LoadControl("MonthlyAccReviewReport"
                  , "~/WebBusManagement/FormsReports/JMonthlyAccReviewReportControl.ascx"
                  , "گزارش مرور حساب ماهانه"
                  , new List<Tuple<string, string>>() { 
                      new Tuple<string, string>("Code", Code.ToString()) 
                    , new Tuple<string, string>("PaymentDelay", txtPaymentDelay.Text)}
                    , WebClassLibrary.WindowTarget.CurrentWindow
                  , true, false, true, 600, 350);
            //try
            //{
            //    GetReport(Convert.ToInt32(txtPaymentDelay.Text));
            //}
            //catch { }
        }
    }
}