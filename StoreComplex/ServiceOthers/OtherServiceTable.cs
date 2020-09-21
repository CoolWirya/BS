using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JOtherServiceTable:JTable
    {
        #region properties
        /// <summary>
        /// رسید/حواله/مجوز
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد  رسید/حواله/مجوز
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// نوع سرویس
        /// </summary>
        public int ServiceType;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal ServiceCost;
        #endregion

        public JOtherServiceTable()
            : base("SCService")
        {
        }
    }
}
