using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JDecisionTypeTable : JTable
    {

        #region Property

        /// <summary>
        /// کد تصمیم
        /// </summary>
        public int DecisionCode;
        /// <summary>
        /// کد نوع رای
        /// </summary>
        public int Type;

        #endregion

        public JDecisionTypeTable()
            : base(JTableNamesLegal.DecisionType, "")
        {
        }
    }
}
