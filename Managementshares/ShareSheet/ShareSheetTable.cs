using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareSheetTable:JTable
    {
        public JShareSheetTable()
            : base("ShareSheet", "ACode")
        {
        }
        /// <summary>
        /// کد شرکت 
        /// </summary>
        public int CompanyCode;
        /// <summary>
        /// از
        /// </summary>
        public int Az;
        /// <summary>
        /// الی
        /// </summary>
        public int Ela;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// کد وکیل
        /// </summary>
        public int ACode;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;
        /// <summary>
        /// کد دوره افزایش سرمایه
        /// </summary>
        public int CourseCode;
        /// <summary>
        /// تعداد دفعات چاپ
        /// </summary>
        public int NumPrint;
        /// <summary>
        /// تعداد سهم
        /// </summary>
        public int ShareCount;
        /// <summary>
        /// دوره
        /// </summary>
        public int Period;
        /// <summary>
        /// کد والد
        /// </summary>
        public int ParentCode;
    }
}
