using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    /// <summary>
    /// مراحل پرداخت
    /// </summary>
    public class JPaymentStep
    {
        public int Code{get; set;}
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode{get; set;}
        /// <summary>
        /// نحوه پرداخت
        /// </summary>
        public int PaymentType{get; set;}
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal PaymentCost{get; set;}
        /// <summary>
        /// درصد از کل مبلغ قرارداد
        /// </summary>
        public decimal PaymentPercent{get; set;}

    }
}
