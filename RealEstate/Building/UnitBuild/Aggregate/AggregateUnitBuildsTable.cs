using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace RealEstate
{
    public class JAggregateUnitBuildsTable:JTable
    {
        public JAggregateUnitBuildsTable()
            : base(JRETableNames.RestAggregateUnitBuilds)
        {
        }



        /// <summary>
        /// کد تجمیع
        /// </summary>
        public int AggregateCode;
        /// <summary>
        /// کد اعیان قدیم
        /// </summary>
        public int UnitBuildCode;

    }
}
