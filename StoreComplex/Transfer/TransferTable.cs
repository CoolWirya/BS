using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreComplex
{
    public class JSCTransferTable : ClassLibrary.JTable
    {
        public JSCTransferTable()
            : base("SCTransfer")
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
        /// <summary>
        /// تائید نهایی شده
        /// </summary>
        public bool Closed;
        /// <summary>
        /// برای سهولت ارتباط بین اشخاص و خدمات ارائه شده، کد شخص در این قسمت ثبت میشود
        /// </summary>
        public int PCode;
        #endregion Properties
    }
}
