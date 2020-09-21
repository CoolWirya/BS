using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JBreakDownUnitBuildsTable : JTable
    {
        public JBreakDownUnitBuildsTable()
            : base(JRETableNames.RestBreakDownUnitBuilds)
        {
        }

        /// <summary>
        /// کد تفکیک
        /// </summary>
        public int BreakDownCode;
        /// <summary>
        /// کد اعیان جدید
        /// </summary>
        public int UnitBuildCode;
    }
}
