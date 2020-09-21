using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace RealEstate
{
    public class JAggregateUnitBuildTable:JTable
    {
        public JAggregateUnitBuildTable()
            : base(JRETableNames.RestAggregateUnitBuild)
        {
        }
        /// <summary>
        /// کد اعیان قدیم
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
