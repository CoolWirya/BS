using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ShareProfit
{
    public class JReport
    {
        public static DataTable FinancialAdvice(int pPCode, int pCompanyCode)
        {
                JDataBase db = JGlobal.MainFrame.GetDBO();
                string InsertCommand = @"
select SC.Code,Title,SP.PayDate,Sum(Cost) bed , Sum(PayCost) bes,Sum(Cost) - Sum(PayCost) man  from sahamcourse SC
inner join sahamSheet SS ON SC.Code=SS.CoursePaymentCode
left join SahamPayment 
SP ON SP.StockNo = SS.Code and SP.CourseCode=SC.Code
where onLinePayment=0 and SS.CompanyCode={2}
and SS.PCode={0}
group by SC.Code,Title,SP.PayDate
union ALL

select SC.Code,Title,SP.PayDate,isnull(Sum(Cost),0) bed , isnull(Sum(PayCost),0) bes,Sum(Cost) - Sum(PayCost) man from sahamcourse SC
inner join 
(
select SN.Code,SS.COmpanyCode,SS.Status,SS.PCode from ShareSheet SS inner join SahamNumber SN on  SN.Code>= Az AND SN.Code <= Ela 
where SS.CompanyCode={3} and SS.Status=1 and SS.PCode={1}
)
 SS ON 1=1
left join SahamPayment SP ON  SP.StockNo = SS.Code and SP.CourseCode=SC.Code
where onLinePayment=1 
group by SC.Code,Title,SP.PayDate
";
                try
                {
                    db.setQuery(string.Format(InsertCommand, pPCode, pPCode, pCompanyCode, pCompanyCode));
                    return db.Query_DataTable();
                }
                finally
                {
                    db.Dispose();
                }
        }
    }
}
