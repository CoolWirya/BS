using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JCommissionTable : JTable
    {
        public JCommissionTable()
            : base(JTableNamesMeeting.MetCommission)
        {
        }
        /// <summary>
        /// نام
        /// </summary>
        public string Name;

    }
}

