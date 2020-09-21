using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    public class JPaymentStepTable :JTable
    {
        public JPaymentStepTable()
            : base("legContractPaymentStep")
        {
        }
        public int Code ;
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode ;
        /// <summary>
        /// نحوه پرداخت
        /// </summary>
        public int PaymentType ;
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal PaymentCost ;
        /// <summary>
        /// درصد از کل مبلغ قرارداد
        /// </summary>
        public decimal PaymentPercent ;
    }
}
