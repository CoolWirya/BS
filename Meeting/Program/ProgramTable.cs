using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    class JProgramTable : JTable
    {
        public JProgramTable()
            : base(JTableNamesMeeting.MetProgram)
        {
        }
        #region Property
                    /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// کد 
        /// </summary>
        public int MeetingCode;
        #endregion
    }
}
