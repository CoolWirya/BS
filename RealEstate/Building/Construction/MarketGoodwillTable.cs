using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{

    public class JMarketGoodwillTable :JTable
    {
        public int MarketCode ;
        public DateTime FromDate ;
        public DateTime ToDate ;
        public float IncreasePercent ;

        public JMarketGoodwillTable()
            : base(JRETableNames.MarketGoodwill)
        {

        }

    }
    public enum JMarketGoodwillEnum
    {
        Code,
        MarketCode,
        FromDate,
        ToDate,
        FromDateF,
        ToDateF,
        IncreasePercent
    }
}
