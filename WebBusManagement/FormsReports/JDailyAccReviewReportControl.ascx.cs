using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JDailyAccReviewReportControl : System.Web.UI.UserControl
    {
        int OwnerPCode;
        string StartDate;
        string EndDate;
        string Month;
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["OwnerPCode"], out OwnerPCode);
            try
            {
                StartDate = Request["StartDate"].ToString();
                EndDate = Request["EndDate"].ToString();
                Month = Request["Month"].ToString();
            }
            catch { }
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
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select name from clsAllPerson where code = " + OwnerPCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                Title = dt.Rows[0]["name"].ToString() + "<br/>مرور حساب " + Month + " ماه";
            }
        }

        public void GetReport(int PaymentDelay = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JDailyAccReviewReportControl_" + OwnerPCode + "_" + StartDate;
            jGridView.SQL = string.Format(@"
IF OBJECT_ID('tempdb..#tmpShiftDriver') IS NOT NULL DROP Table #tmpShiftDriver
select 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard, shft.Date into #tmpShiftDriver
from AUTShiftDriver shft
where shft.OwnerPCode = {0} and CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
		and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
		and shft.Date between '{2}' and '{3}'
group by shft.Date
<#PreviusSQL#>
select ROW_NUMBER() over (order by Date) Code, {0} OwnerPCode,(select name from clsAllPerson where code={0}) Name, Date
, sum(TransactionKarkard) TransactionKarkard,sum(BesDoc) FinancialKarKard,sum(BesDoc0) NotVerifiedKarKard,sum(TransactionKarkard-(BesDoc + BesDoc0)) NoDocKarkard
,sum(BedPayment) Payment, sum(sum(TransactionKarkard-BedPayment)) over (order by Date) Mandeh
from
(
select isnull(TransactionKarkard,0)TransactionKarkard,isnull(cast(a.Bes-a.bed as bigint),0) BesDoc,isnull(cast(a.Bes0-a.bed0 as bigint),0) BesDoc0
,isnull(Price, 0) BedPayment, a.Date
from
(
	select doc.DateSave Date
	, 10 * sum(cast((case when IsOk = 1 then BesPrice else 0 end) as bigint)) bes
	, 10 * sum(cast((case when IsOk = 1 then BedPrice else 0 end) as bigint)) bed
	, 10 * sum(cast((case when IsOk = 0 then BesPrice else 0 end) as bigint)) bes0
	, 10 * sum(cast((case when IsOk = 0 then BedPrice else 0 end) as bigint)) bed0
	from FinDocument doc
	inner join FinDocumentDetails detail on detail.DocCode = doc.Code
	where detail.TafziliCode1 = {0} and doc.Code between 100000000 and 200000000 and doc.Code not in (120160534,120160535) and detail.MoeinCode = 3
	and doc.DateSave between '{2}' and '{3}'
	group by doc.DateSave
) a
full join
(
select DATEADD(DAY, -({1}), pay.PaymentDate) Date, 10 * sum(cast(TotalPrice as bigint)) Price
from AUTPayment pay
inner join AUTPaymentDetail detail on detail.PaymentCode = pay.Code
where detail.OwnerPCode = {0}
	and pay.PaymentDate between DATEADD(DAY, {1}, '{2}') and DATEADD(DAY, {1}, '{3}')
group by DATEADD(DAY, -({1}), pay.PaymentDate)
) b on b.Date = a.Date
full join  #tmpShiftDriver d on d.Date = a.Date
) a
group by a.Date", new object[] { OwnerPCode.ToString(), (Convert.ToInt32(PaymentDelay)).ToString(), StartDate, EndDate });
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "DailyAccReviewReport";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "TransactionKarkard,FinancialKarKard,NotVerifiedKarKard,NoDocKarkard,Payment,Mandeh";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionKarkard", 0);
            jGridView.SumFields.Add("FinancialKarKard", 0);
            jGridView.SumFields.Add("NotVerifiedKarKard", 0);
            jGridView.SumFields.Add("NoDocKarkard", 0);
            jGridView.SumFields.Add("Payment", 0);
            jGridView.Bind();

        }
    }
}