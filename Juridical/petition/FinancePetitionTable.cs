using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JFinancePetitionTable: JTable
    {
               #region Property

        /// <summary>
        /// کد وکالت
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// توضیحات اموال
        /// </summary>
        public string Comment;

       #endregion

        public JFinancePetitionTable()
            : base(JTableNamesPetition.FinancePetition, "")
        {
        }
    }
}
