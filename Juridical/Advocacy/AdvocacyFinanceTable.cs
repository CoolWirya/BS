using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JAdvocacyFinanceTable: JTable
    {
       #region Property

        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;

       #endregion

        public JAdvocacyFinanceTable()
            : base(JTableNamesContracts.AdvocacyFinance, "")
        {
        }

    }
}
