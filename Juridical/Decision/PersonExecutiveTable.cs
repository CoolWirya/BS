using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JPersonExecutiveTable : JTable
    {
        #region Property
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int ExecutiveCode;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type;

        #endregion

        public JPersonExecutiveTable()
            : base(JTableNamesLegal.PersonExecute, "")
        {
        }
    }
}
