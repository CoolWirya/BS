using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Automation
{
    public class JASendTable : JTable
    {
        public int senderCode;
        /// <summary>
        /// پست فرستنده
        /// </summary>
        public int senderPostCode;
        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        public DateTime SendDate;

        /// <summary>
        /// نوع ارجاع
        /// </summary>
        public int ReferTypeCode; 
        /// <summary>
        /// فوریت
        /// </summary>
        public int Urgency;     
        /// <summary>
        /// محرمانگی
        /// </summary>
        public JAPrivacyMode Privacy;
        /// <summary>
        ///کد شی که باید ارجا داده شود
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// پست گیرنده
        /// </summary>
        public int SenderPostCode;
        /// <summary>
        /// شرح ارسال
        /// </summary>
        public string RefDesc { get; set; }
        /// <summary>
        /// کد  دریافت (جهت ارسالهای بعدی)
        /// </summary>
        public int RecieveCode { get; set; }
        
        public JASendTable()
            : base("refersend")
        {
        }
    }
}
