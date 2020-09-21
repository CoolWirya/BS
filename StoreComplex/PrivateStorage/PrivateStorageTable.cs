using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JPrivateStorageTable : JTable
    {
        public JPrivateStorageTable()
            : base("SCPrivateStorage")
        {
        }
        /// <summary>
        /// محل اجاره
        /// </summary>
        public int StorageCode ;
        /// <summary>
        /// کد رسید
        /// </summary>
        public int ReceiptCode ;
        /// <summary>
        /// تعداد باکس مورد اجاره
        /// </summary>
        public decimal BoxCount ;
        /// <summary>
        /// مبلغ اجاره
        /// </summary>
        public decimal Cost ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
      
    }
}
