using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JLoadingServiceTable:JTable
    {
        #region Properties
        /// <summary>
        /// رسید/حواله/مجوز
        /// </summary>
        public string ClassName ;
        /// <summary>
        /// کد  رسید/حواله/مجوز
        /// </summary>
        public int ObjectCode ;
        /// <summary>
        /// تخلیه/بارگیری
        /// </summary>
        public int Type ;
        /// <summary>
        /// سریال  رسید/حواله/مجوز
        /// </summary>
        public string Serial ;
        /// <summary>
        /// تاریخ و ساعت
        /// </summary>
        public DateTime Date ;
        /// <summary>
        /// محل
        /// </summary>
        public int Location ;
        /// <summary>
        /// تعدا نیرو
        /// </summary>
        public int WorkerCount ;
        /// <summary>
        /// مدت - دقیقه
        /// </summary>
        public int WorkerDuration;
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal Cost;
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode;
        #endregion Properties

        public JLoadingServiceTable()
            : base("SCLoadingService")
        {
        }
    }
}
