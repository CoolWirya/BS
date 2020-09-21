using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JCommissionPersonsTable: JTable
    {
        public JCommissionPersonsTable()
            : base(JTableNamesMeeting.MetCommissionPersons)
        {
        }
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int CommissionCode;
        /// <summary>
        /// کدشخص
        /// </summary>
        public int PersonCode;

    }
}
