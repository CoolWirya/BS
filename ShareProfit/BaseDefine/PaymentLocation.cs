using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    /// <summary>
    /// انواع محلهای پرداخت سود
    /// </summary>
    public class JPaymentSource : JSubBaseDefine
    {
        public JPaymentSource()
            : base(JBaseDefine.PaymentSource)
        {
        }
    }

    public class JPaymentSources : JSubBaseDefines
    {
        public JPaymentSources()
            : base(JBaseDefine.PaymentSource)
        {
        }
    }
}
