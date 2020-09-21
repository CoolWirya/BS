using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JFinanceDecisionTable : JTable
    {
       #region Property

        /// <summary>
        /// کد وکالت
        /// </summary>
        public int DecisionCode;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// توضیحات اموال
        /// </summary>
        public string Comment;
       #endregion

        public JFinanceDecisionTable()
            : base(JTableNamesPetition.FinanceDecision, "")
        {
        }
    }
}
