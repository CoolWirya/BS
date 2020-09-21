using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JPollingTable : JTable
    {
        public JPollingTable()
            : base("ShareAssemblyPolling")
        {
        }
        /// <summary>
        /// کد مجمع
        /// </summary>
        public int ACode;
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title;
        /// <summary>
        /// تعداد اعضای اصلی
        /// </summary>
        public int MainMembers;
        /// <summary>
        /// تعداد اعضای علی البدل
        /// </summary>
        public int AlternateMembers;
    }
}
