using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    public class JARecieveTable : JTable
    {
        /// <summary>
        /// کد در جدول ارسال شده ها
        /// </summary>
        public int SendCode;
        /// <summary>
        /// تاریخ دریافت (تاریخ خواندن نامه)
        /// </summary>
        public DateTime ReciveDate;
        /// <summary>
        /// کد گیرنده
        /// </summary>
        public int RecieverCode;
        /// <summary>
        /// پست گیرنده
        /// </summary>
        public int ReciverPostCode;
        /// <summary>
        /// کد آبجکت
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// فوریت
        /// </summary>
        public int Urgency;
        /// <summary>
        /// نوع ارجاع
        /// </summary>
        public int ReferTypeCode; 

        public JARecieveTable()
            : base("referrecieve")
        {
        }
    }
}
