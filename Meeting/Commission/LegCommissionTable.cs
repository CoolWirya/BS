using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JLegCommissionTable : JTable
    {
        public JLegCommissionTable()
            : base(JTableNamesMeeting.MetLegCommission)
        {
        }
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int CommissionCode;
        /// <summary>
        /// گروه مصوبه
        /// </summary>
        public int LegislationGroup;
    }
}
