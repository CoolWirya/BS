using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JOverPayReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (IsPostBack)
            {
            }
            else
            {
                GetReport();
            }
        }

        public void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JOverPayReportControl_" + Code;
            jGridView.SQL = @"
declare @Table table
(
RW int,
DateSave DateTime,
BesPrice int,
bedPrice int,
descr nvarchar(20),
Description nvarchar(200),
man int,
ezaf int,
Sta int
)

insert into @Table
select ROW_NUMBER()OVER(order by DateSave,ind) RW,DateSave,BesPrice,BedPrice,descr,Description,0 man,0 ezaf,Sta from
(
select FD.DateSave,2 ind,sum(BesPrice)*10 BesPrice , 0 BedPrice , N'کارکرد' descr,N'' Description, 0 Sta from FinDocumentDetails FD inner join FinDocument F ON FD.DocCode=f.Code where TafziliCode1= " + Code + @" and MoeinCode=3 and TafziliCode2>0 and BedPrice=0 group by FD.DateSave
union
select FD.DateSave,3 ind,0 , sum(BedPrice)*10 , N' اضافه تراکنش' ,N'' Description, 1 from FinDocumentDetails FD inner join FinDocument F ON FD.DocCode=f.Code where TafziliCode1= " + Code + @" and MoeinCode=3 and TafziliCode2>0 and BedPrice>0 group by FD.DateSave
union
select f.PaymentDate,1 ind, 0 ,sum(TotalPrice)*10 , N'پرداخت' ,N'' Description, 0 from AUTPaymentDetail ap inner join AUTPayment f on ap.PaymentCode=f.Code where OwnerPCode= " + Code + @"  group by  f.PaymentDate
) a
order by DateSave

declare @man int
set @man=0
update @Table set @man=man=@man+besPrice-bedprice

declare @RW int
set @RW = 1
while(@RW >0)
begin
	set @RW = 0
	select top 1 @RW = RW from @Table where man<0 order by RW
	print @man

	set @man=0
	update @Table set @man=man=@man+besPrice-bedprice where RW>@RW

	update @Table set ezaf=-1*man,bedPrice = bedPrice+man,man=0 , Sta=1 where RW = @RW
end

	set @man=0
	update @Table set @man=man=@man+besPrice-bedprice-ezaf where RW>@RW

IF OBJECT_ID('tempdb..#TTT') IS NOT NULL DROP TABLE #TTT
select RW radif,Sta StatusName,DateSave,descr Comment,Description,BesPrice Karkard,case when descr=N'پرداخت' then 0 else bedPrice end  OverTrans,ezaf OverPay,bedPrice+ezaf CostPay,man Mandeh into #TTT from @Table
<#PreviusSQL#>
select * from #TTT 
";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "OverPayReport";
            jGridView.PageOrderByField = "radif";
            jGridView.Buttons = "excel";
            jGridView.MoneyColumns = "KarKard,OverTrans,OverPay,CostPay,Mandeh";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("KarKard", 0);
            jGridView.SumFields.Add("OverTrans", 0);
            jGridView.SumFields.Add("OverPay", 0);
            jGridView.SumFields.Add("CostPay", 0);
            jGridView.Bind();

        }
    }
}