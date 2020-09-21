using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JTotalAccountTable:JTable
    {
        public JTotalAccountTable(): base(JTableNamesFinance.TotalAccounts)
        {
        }
        /// <summary>
        /// کد حساب کل
        /// </summary>
        public int TotalAccountCode;
        /// <summary>
        /// عنوان حساب کل
        /// </summary>
        public string Name;
        /// <summary>
        /// ماهیت حساب
        /// </summary>
        public TypeOfTotalAccounts Type;
       

    }


}
