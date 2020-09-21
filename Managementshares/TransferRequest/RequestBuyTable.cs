using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares.TransferRequest
{
    public class JRequestBuyTable : JTable
    {
        #region Properties
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// تاریخ درخواست
        /// </summary>
        public DateTime RequestDate;
        /// <summary>
        /// تعداد سهم درخواستی جهت خرید
        /// </summary>
        public int ShareCount;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;
        /// <summary>
        /// شرح
        /// </summary>
        public int Description;
        #endregion

        public JRequestBuyTable()
            : base("ShareRequestBuy")
        {
        }
    }
}
