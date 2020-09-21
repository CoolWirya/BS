using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JLedgerAccountTable:JTable
    {
        public JLedgerAccountTable()
            : base(JTableNamesFinance.LedgerAccount)
        {
        }
        public int LedgerAccountCode;
        /// <summary>
        /// کد حساب کل
        /// </summary>
        public int TotalAccountCode;
        /// <summary>
        /// عنوان حساب معین
        /// </summary>
        public string Name;
        /// <summary>
        /// ماهیت حساب
        /// </summary>
        public TypeOfLedgerAccount Type;
    }
    enum JLedgerAccountEnum
    {
        Code,
        /// <summary>
        /// کدحساب معین
        /// </summary>
        LedgerAccountCode,
        /// <summary>
        /// کد حساب کل
        /// </summary>
        TotalAccountCode,
        /// <summary>
        /// عنوان حساب معین
        /// </summary>
        Name,
        /// <summary>
        /// ماهیت حساب
        /// </summary>
        TypeOfLedgerAccount
    }
}
