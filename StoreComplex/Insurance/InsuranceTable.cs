using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    class JInsuranceTable: JTable
    {
        public JInsuranceTable()
            : base("SCInsurance")
        {
        }

        /// <summary>
        ///  کد قرارداد
        /// </summary>
        public int ContractCode;
        /// <summary>
        ///  تاریخ شروع
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime ExpireDate;
        /// <summary>
        /// مبلغ بیمه
        /// </summary>
        public decimal Price;
        /// <summary>
        /// ارزش کالا
        /// </summary>
        public decimal CostGoods;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
    }
}
