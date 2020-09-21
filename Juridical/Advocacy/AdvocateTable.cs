using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JAdvocateTable : JTable
    {
        #region Property

        /// <summary>
        /// کد شخص
        /// </summary>
        public int Person_Code;
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime Start_Date;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime End_Date;

        #endregion

        public JAdvocateTable()
            : base(JTableNamesLegal.AdvocateTable)
        {

        }
    }
}
