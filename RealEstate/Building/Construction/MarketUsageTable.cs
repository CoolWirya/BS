using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class jMarketUsageTable : JTable
    {
        public int MarketCode;
        public int UsageCode;
        public decimal Infrastructure;
        
        public jMarketUsageTable()
            : base(JTableNamesEstate.MarketUsage,"" )
        {
        }
    }

    public enum estMarketUsage
    {
        Code,
        MarketCode,
        UsageCode,
        Infrastructure,
    }
}
