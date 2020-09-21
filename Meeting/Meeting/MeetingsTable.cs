using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Meeting
{
    class JMeetingsTable: JTable
    {
        public JMeetingsTable()
            : base(JTableNamesMeeting.MetMeeting)
        {
        }
        /// <summary>
        /// تاریخ جلسه
        /// </summary>
        public DateTime Date;        
        /// <summary>
        /// موضوع جلسه
        /// </summary>
        public string Subject;
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int CommissionCode;
        /// <summary>
        /// ساعت
        /// </summary>
        public string Time;
        /// <summary>
        /// مکان
        /// </summary>
        public string Location;
    }
}
