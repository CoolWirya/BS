using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JIncreaseShareTable : JTable
    {
        #region Propetties

        /// <summary>
        /// تاریخ افزایش سرمایه
        /// </summary>
        public DateTime IncDate;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment;
        /// <summary>
        /// کد شرکت
        /// </summary>
        public int CompanyCode;
        /// <summary>
        /// مبلغ هر سهم
        /// </summary>
        public decimal Cost;
        /// <summary>
        /// تعداد کل سهام
        /// </summary>
        public decimal ShareCount;
        /// <summary>
        /// عملیات افزایش / تجمیع / ...ـ
        /// </summary>
        public int Action;
        /// <summary>
        /// تعداد بخش شکستن هر سهم
        /// </summary>
        public int BreakCount;
        /// <summary>
        /// کد کاربر 
        /// </summary>
        public int UserCode;
        /// <summary>
        /// پست کاربر
        /// </summary>
        public int PostCode;
        #endregion Propetties

        public JIncreaseShareTable()
            : base("ShareIncreaseCourse")
        {
        }
    }
}
