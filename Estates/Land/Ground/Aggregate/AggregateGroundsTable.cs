using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JAggregateGroundsTable:JTable
    {
        public JAggregateGroundsTable()
            : base(JTableNamesEstates.AggregateGrounds)
        {
        }
        /// <summary>
        /// کد زمینی که با زمین های دیگر تجمیع می شود
        /// </summary>
        public int GroundsAggregationbyCode;
        /// <summary>
        /// کد زمین حاصل از تجمیع زمین ها
        /// </summary>
        public int GroundAggregationbyCode;
    }
    public enum JAggregateGroundsTableEnum
    {
        Code,

        GroundsAggregationbyCode,

        GroundAggregationbyCode,
    }
}
