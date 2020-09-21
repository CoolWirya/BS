using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Purchase
{
    public class JUserPurchaseTable:ClassLibrary.JTable
    {
        public int userCode;
        public int planCode ;
        public bool success ;
        /// <summary>
        /// شروع پلن
        /// </summary>
        public DateTime dateFrom ;
        /// <summary>
        /// پایان پلن
        /// </summary>
        public DateTime dateTo ;
        /// <summary>
        /// مقدار پرداختی کاربر
        /// </summary>
        public double paidPrice ;
        /// <summary>
        /// شماره پیگیری تراکنش
        /// </summary>
        public string transactionCode ;
        /// <summary>
        /// شماره رهگیری بانک ملت
        /// </summary>
        public string bankCode ;
        /// <summary>
        /// تاریخ انجام تراکنش
        /// </summary>
        public DateTime transactionDate ;

        public JUserPurchaseTable()
            : base("AVLUserPurchase")
        {

        }
   
    }
}
