using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Purchase
{
    public class JUserPurchase:ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int userCode { get; set; }
        public int planCode { get; set; }
        public bool success { get; set; }
        /// <summary>
        /// شروع پلن
        /// </summary>
        public DateTime dateFrom { get; set; }
        /// <summary>
        /// پایان پلن
        /// </summary>
        public DateTime dateTo { get; set; }
        /// <summary>
        /// مقدار پرداختی کاربر
        /// </summary>
        public double paidPrice { get; set; }
        /// <summary>
        /// شماره پیگیری تراکنش
        /// </summary>
        public string transactionCode { get; set; }
        /// <summary>
        /// شماره رهگیری بانک ملت
        /// </summary>
        public string bankCode { get; set; }
        /// <summary>
        /// تاریخ انجام تراکنش
        /// </summary>
        public DateTime transactionDate { get; set; }
    }
}
