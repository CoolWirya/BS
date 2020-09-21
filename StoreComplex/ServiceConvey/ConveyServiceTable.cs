using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JConveyServiceTable :JTable
    {
        public JConveyServiceTable()
            : base("SCConveyService")
        {
        }
        #region Properties
        /// <summary>
        /// رسید/حواله/مجوز
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد  رسید/حواله/مجوز
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// سریال رسید/حواله
        /// </summary>
        public string Serial ;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date ;
        /// <summary>
        /// نوع وسیله
        /// </summary>
        public int DriveType ;
        /// <summary>
        /// نام راننده
        /// </summary>
        public string DriverName ;
        /// <summary>
        /// ش پلاک
        /// </summary>
        public string PelakNo ;
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal Cost ;
      /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode;
        #endregion Properties
    }
}
