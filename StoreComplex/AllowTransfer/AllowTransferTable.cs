using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCAllowTransferTable: JTable
    {
        public JSCAllowTransferTable()
            : base("SCAllowTransfer")
        {
        }
        #region Properties
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode;
        /// <summary>
        ///ش  سریال رسید
        /// </summary>
        public string Serial;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// نام راننده
        /// </summary>
        public string DriverName;
        /// <summary>
        /// نوع خودرو
        /// </summary>
        public int DriveType;
        /// <summary>
        /// ش پلاک
        /// </summary>
        public string PelakNo;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        #endregion Properties
    }
}
