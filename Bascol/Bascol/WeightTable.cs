using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    class JWeightTable : JTable
    {
        public JWeightTable()
            : base("BascolWeights")
        {
        }

        #region Property
        /// <summary>
        ///  شماره باسکول
        /// </summary>
        public int BascoolCode;
        /// <summary>
        ///  تاریخ توزین
        /// </summary>
        public DateTime WDate;
        /// <summary>
        ///  ساعت توزین
        /// </summary>
        public string WTime;
        /// <summary>
        ///  شماره پلاک
        /// </summary>
        public string PlokNo;
        /// <summary>
        ///  آیدی محصول
        /// </summary>
        public int ProductCode;
        /// <summary>
        ///  وزن
        /// </summary>
        public int Weights;
        /// <summary>
        ///  آیدی ماشین
        /// </summary>
        public int TruckCode;
        /// <summary>
        ///  وضعیت خالی بار بودن
        /// </summary>
        public int FullW;
        /// <summary>
        ///  تعداد پرینت
        /// </summary>
        public int PrintNo;
        /// <summary>
        ///  تعداد همراه
        /// </summary>
        public int hamrahno;
        /// <summary>
        ///  حذف توزین
        /// </summary>
        public bool dele;
        /// <summary>
        ///  تایید توزین توسط مالی
        /// </summary>
        public bool verify;
        /// <summary>
        ///  هزینه توزین
        /// </summary>
        public int pay;
        /// <summary>
        ///  مبلغ پرداخت شده
        /// </summary>
        public int pay_h;
        /// <summary>
        ///  
        /// </summary>
        public decimal Duty;
        /// <summary>
        ///  مالیات
        /// </summary>
        public decimal Tax;
        /// <summary>
        ///  کد کاربر
        /// </summary>
        public int PersonCode;
        /// <summary>
        ///  کد پست کاربر
        /// </summary>
        public int UserPostCode;
        /// <summary>
        ///  کد بانکlocal
        /// </summary>
        public int BascoolID;
        #endregion
    }
}
