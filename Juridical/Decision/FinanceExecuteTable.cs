using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JFinanceExecuteTable : JTable
    {
        #region Property

        /// <summary>
        /// کد وکالت
        /// </summary>
        public int ExecuteCode;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// توضیحات اموال
        /// </summary>
        public string Comment;

       #endregion

        public JFinanceExecuteTable()
            : base(JTableNamesPetition.FinanceExecute, "")
        {
        }
    }
}
