using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    class JPrepaymentTable : JTable
    {
        public JPrepaymentTable()
            : base("StorePrepayment")
        {
        }
        /// <summary>
        ///   کد فاکتور
        /// </summary>
        public int BillGoodsCode;
        /// <summary>
        ///   قیمت
        /// </summary>
        public decimal Price;
        /// <summary>
        ///   تاریخ
        /// </summary>
        public DateTime Date;
         /// <summary>
        ///   توضیحات
        /// </summary>
        public string Description;
    }
}
