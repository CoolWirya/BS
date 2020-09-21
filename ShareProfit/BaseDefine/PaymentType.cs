using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    /// <summary>
    /// 
    /// </summary>
    public class JPaymentType : JSubBaseDefine
    {
        public JPaymentType()
            : base(JBaseDefine.PaymentType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JPaymentTypes : JSubBaseDefines
    {
        public JPaymentTypes()
            : base(JBaseDefine.PaymentType)
        {

        }

    }
}
