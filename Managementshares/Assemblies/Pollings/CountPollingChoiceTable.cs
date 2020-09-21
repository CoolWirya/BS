using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JCountPollingChoiceTable:JTable
    {
        public JCountPollingChoiceTable()
            : base("ShareAssemblyPollingCountChoice")
        {
        }
        /// <summary>
        /// کد برگه شمارش شده
        /// </summary>
        public int PollingCountCode;
        /// <summary>
        /// کد گزینه انتخابی
        /// </summary>
        public int ChoiceCode;
    }
}
