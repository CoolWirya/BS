using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JBillGoodsTable : JTable
    {
        public JBillGoodsTable()
            : base("StoreBillGoods")
        {
        }

        #region Property
        /// <summary>
        ///  سریال
        /// </summary>
        public string Serial;
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime RegDate;
        /// <summary>
        ///  فروشنده
        /// </summary>
        public int Seller;
        /// <summary>
        ///  خریدار
        /// </summary>
        public int Buyer;
        /// <summary>
        ///  وضعیت پرداخت
        /// </summary>
        public int StatePay;
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        ///  کد تنخواه
        /// </summary>
        public string TankhahCode;
        /// <summary>
        ///  تخفیف
        /// </summary>
        public decimal Discount;
        /// <summary>
        ///  مالیات 
        /// </summary>
        //public decimal Tax;
        /// <summary>
        ///  وضعیت فاکتور
        /// </summary>
        public int State;
        /// <summary>
        ///  عوارض
        /// </summary>
        //public decimal Duty;
        /// <summary>
        ///  نوع فاکتور
        /// </summary>
        public int BillType;
        /// <summary>
        ///  ایجادکننده
        /// </summary>
        public int Creator;
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime CreateDate;
        /// <summary>
        ///  شماره سند
        /// </summary>
        public int DocNumber;
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime DocDate;
        /// <summary>
        ///  برگشتی
        /// </summary>
        public bool Returned;
        #endregion
    }
}
