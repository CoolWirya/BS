using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JbreakupOrgTable : JTable
    {
        public JbreakupOrgTable()
            : base(JTableNamesPetition.BreakupOrg, "")
        {
        }
        #region Property

        /// <summary>
        /// کد شرکت 
        /// </summary>
        public int OrgCode;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        #endregion
    }
}
