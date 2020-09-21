using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
        /// <summary>
        /// انواع رای
        /// </summary>
        public enum DecisionType
        {
            /// <summary>
            /// فسخ
            /// </summary>
            revoke = 1,
            /// <summary>
            /// گواهی حصرووراثت
            /// </summary>
            inheritance = 2,
            /// <summary>
            /// توقیف/رد توقیف
            /// </summary>
            Lockup = 3,
            /// <summary>
            /// الزام به پرداخت وجه:
            /// </summary>
            Pay = 4,
            /// <summary>
            /// الزام تنظیم سند
            /// </summary>
            document = 5,
            /// <summary>
            /// سایرموارد
            /// </summary>
            Other = 6,
            /// <summary>
            /// الزام به انجام تعهد
            /// </summary>
            guarantee = 7,
            /// <summary>
            /// قرار
            /// </summary>
            agreement = 8,
        }
}
