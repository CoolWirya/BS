using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JPrivateTransferTable:JTable
    {
        #region Properties
        /// <summary>
        /// کد اجاره انبار اختصاصی که در رسید ثبت شده است
        /// </summary>
        public int PrivateStorageCode ;
        /// <summary>
        /// کد حواله
        /// </summary>
        public int TransferCode ;
        /// <summary>
        /// تعداد باکس تخلیه شده
        /// </summary>
        public decimal BoxCount ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description ;
        #endregion 

        public JPrivateTransferTable()
            : base("SCPrivateTransfer")
        {
        }
    }
}
