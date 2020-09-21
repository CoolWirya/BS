using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JServicesTable : JTable
    {
        public JServicesTable()
            : base("StoreServices")
        {
        }

        #region Property
        /// <summary>
        /// نام کالا  
        /// </summary>
        public string Name;
        /// <summary>
        /// کد گروه 
        /// </summary>
        public int GroupCode;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime Create_Date_Time;
        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price;
        /// <summary>
        /// واحد اندازه گیری
        /// </summary>
        public int Measure;
        /// <summary>
        /// نوع سرویس
        /// </summary>
        public int ServiceType;
        #endregion
    }
}
