using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JDivideSheetTable : JTable
    {
        /// <summary>
        /// کد برگه
        /// </summary>
        public int SCode ;
        /// <summary>
        /// کد برگه ایجاد شده جدید
        /// </summary>
        public int NewCode ;
        /// <summary>
        /// تقسیم
        /// </summary>
        public bool IsDivide ;
        /// <summary>
        /// تاریخ تقسیم
        /// </summary>
        public DateTime DJDate ;


        public JDivideSheetTable() :
            base("ShareDivideJoin")
        {
        }
    }
}
