using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace RealEstate
{
    public class JBreakDownUnitBuildTable : JTable
    {
        public JBreakDownUnitBuildTable()
            : base(JRETableNames.RestBreakDownUnitBuild)
        {
        }
        /// <summary>
        /// کد اعیان جدید
        /// </summary>
        public int UnitBuildCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
    }
}
