using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    class JLegislationTable : JTable
    {
        public JLegislationTable()
            : base(JTableNamesMeeting.MetLegislation)
        {
        }
        #region Property
        /// <summary>
        /// گروه مصوبه
        /// </summary>
        public int LegislationGroup;     
        /// <summary>
        /// مصوبه
        /// </summary>
        public string Legislation;
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int MeetingCode;
        /// <summary>
        /// پیگیری
        /// </summary>
        public int Flow;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ پیگیری
        /// </summary>
        public DateTime FlowDate;
        /// <summary>
        /// پیگیری کننده
        /// </summary>
        public string PersonFlow;
        #endregion
    }
}
