using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Meeting
{
    class JMeetingPersonsTable : JTable
    {
        public JMeetingPersonsTable()
            : base(JTableNamesMeeting.MetMeetingPersons)
        {
        }
        /// <summary>
        /// کد جلسه
        /// </summary>
        public int MeetingCode;
        /// <summary>
        /// کدشخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// امضا
        /// </summary>
        public bool Signature;
    }
}
