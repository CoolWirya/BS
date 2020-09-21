using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JCountPollingTable :JTable
    {
        public JCountPollingTable()
            : base("ShareAssemblyPollingCount")
        {
        }
        /// <summary>
        /// کد انتخابات
        /// </summary>
        public int PollingCode;
        /// <summary>
        /// شماره برگه
        /// </summary>
        public int VoteNo;
        /// <summary>
        /// تعداد حق رأی
        /// </summary>
        public int RightCount;
        public int PCode;
    }
}
