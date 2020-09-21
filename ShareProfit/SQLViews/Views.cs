using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareProfit
{
    public class JSQLViews : ClassLibrary.JSQLViews
    {
        public static string vSumPayment = @" (SELECT     stockno, coursecode, SUM(paycost) AS sumpay
                    FROM         dbo.sahampayment
                    GROUP BY coursecode, stockno) AS vsumpayment ";

    }
}
